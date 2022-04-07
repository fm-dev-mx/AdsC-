using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swdocumentmgr;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;


namespace CB_Base.Classes
{
    public class SolidWorksAPI 
    {
        public SldWorks Aplicacion = null;

        public SolidWorksAPI()
        {
            if(Type.GetTypeFromProgID("SldWorks.Application") != null)
                Aplicacion = (SldWorks)Activator.CreateInstance(Type.GetTypeFromProgID("SldWorks.Application"));
        }

        public int ExtraerPropiedadesParte(string archivo, out Dictionary<string, string> propiedades)
        {
            propiedades = new Dictionary<string, string>();

            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 1;

            ModelDoc2 modelo = default(ModelDoc2);

            // Abrir archivo .part y obtener el objeto de modelo
            int erroresAbrirParte = 0;
            int warningsAbrirParte = 0;

            if(Path.GetExtension(archivo).ToUpper() == ".SLDPRT")
            {
                modelo = (ModelDoc2)Aplicacion.OpenDoc6(archivo,
                                                        (int)swDocumentTypes_e.swDocPART,
                                                        (int)swOpenDocOptions_e.swOpenDocOptions_RapidDraft,
                                                        "", erroresAbrirParte, warningsAbrirParte);
            }
            else if(Path.GetExtension(archivo).ToUpper() == ".SLDASM")
            {
                modelo = (ModelDoc2)Aplicacion.OpenDoc6(archivo,
                                                    (int)swDocumentTypes_e.swDocASSEMBLY,
                                                    (int)swOpenDocOptions_e.swOpenDocOptions_RapidDraft,
                                                    "", erroresAbrirParte, warningsAbrirParte);
            }

            if (modelo == null)
                return 2; // error al generar modelo

            // Obtener configuracion del archivo
            Configuration configuracion = modelo.ConfigurationManager.ActiveConfiguration;
            CustomPropertyManager managerPropiedades = configuracion.CustomPropertyManager;

            // Obtener los nombres de todas las custom properties
            object[] nombresPropiedades = managerPropiedades.GetNames();

            // Por cada custom property
            for(int i=0; i<=managerPropiedades.Count-1; i++)
            {
                string valOut = "";
                string resolvedValOut = "";
                managerPropiedades.Get2(nombresPropiedades[i].ToString(), out valOut, out resolvedValOut);
                propiedades.Add(nombresPropiedades[i].ToString().ToUpper(), resolvedValOut.ToUpper().Replace("FROMPARENT+", string.Empty));
            }

            Aplicacion.CloseDoc(modelo.GetTitle());
            return 0;
        }

        public int ModificarPropiedadParte(string archivo, string nombrePropiedad, string valorPropiedad)
        {
            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 1;

            ModelDoc2 modelo = default(ModelDoc2);

            // Abrir archivo .part y obtener el objeto de modelo
            int erroresAbrirParte = 0;
            int warningsAbrirParte = 0;

            modelo = (ModelDoc2)Aplicacion.OpenDoc6(archivo,
                                                    (int)swDocumentTypes_e.swDocPART,
                                                    (int)swOpenDocOptions_e.swOpenDocOptions_LoadLightweight,
                                                    "", erroresAbrirParte, warningsAbrirParte);

            if (modelo == null)
                return 2; // error al generar modelo

            // Obtener configuracion del archivo
            Configuration configuracion = modelo.ConfigurationManager.ActiveConfiguration;
            CustomPropertyManager managerPropiedades = configuracion.CustomPropertyManager;

            managerPropiedades.Set2(nombrePropiedad, valorPropiedad);
            modelo.Save2(true);
            return 0;
        }

        public int DrawingAPDF(string drawing, out byte[] pdf, swOpenDocOptions_e modo=swOpenDocOptions_e.swOpenDocOptions_LoadLightweight)
        {
            pdf = null;

            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 1;

            ModelDoc2 modelo = default(ModelDoc2);

            // Abrir archivo .part y obtener el objeto de modelo
            int erroresAbrirDrawing = 0;
            int warningsAbrirDrawing = 0;

            modelo = (ModelDoc2)Aplicacion.OpenDoc6(drawing,
                                                    (int)swDocumentTypes_e.swDocDRAWING,
                                                    (int)modo,
                                                    "", erroresAbrirDrawing, warningsAbrirDrawing);

            if (modelo == null)
                return 2;

            DrawingDoc documentoDrawing = (DrawingDoc)modelo;

            if (documentoDrawing == null)
                return 3;

            ModelDocExtension extension = (ModelDocExtension)modelo.Extension;
            ExportPdfData exportarPdf = (ExportPdfData)Aplicacion.GetExportFileData((int)swExportDataFileType_e.swExportPdfData);
            DrawingDoc documentosDrawing = (DrawingDoc)modelo;

            string[] nombresHojas = (string[])documentosDrawing.GetSheetNames();
            int totalHojas = nombresHojas.Length;

            object[] hojasImpresion = new object[totalHojas];
            DispatchWrapper[] hojasImpresionIn = new DispatchWrapper[totalHojas];

            for (int i = 0; i < totalHojas; i++ )
            {
                documentoDrawing.ActivateSheet(nombresHojas[i]);
                Sheet hoja = (Sheet)documentoDrawing.GetCurrentSheet();
                hojasImpresion[i] = hoja;
                hojasImpresionIn[i] = new DispatchWrapper(hojasImpresion[i]);
            }

            // Guardar los drawings a un archivo PDF temporal
            exportarPdf.SetSheets((int)swExportDataSheetsToExport_e.swExportData_ExportSpecifiedSheets, (hojasImpresionIn));
            exportarPdf.ViewPdfAfterSaving = false;

            int errorExportar = 0;
            int warningExportar = 0;

            string pathTemp = Path.GetTempFileName().Replace(".tmp", ".pdf");
            extension.SaveAs(pathTemp, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_Silent, exportarPdf, ref errorExportar, ref warningExportar);
            
            // Cargar el archivo PDF y devolver arreglo de bytes
            pdf = File.ReadAllBytes(pathTemp);
            File.Delete(pathTemp);

            Aplicacion.CloseDoc(modelo.GetTitle());
            return 0;
        }

        public int VistaPrevia(string archivo, swDocumentTypes_e tipo, out byte[] vistaPrevia, swStandardViews_e vista=swStandardViews_e.swIsometricView)
        {
            vistaPrevia = null;

            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 1;

            ModelDoc2 modelo = default(ModelDoc2);

            // Abrir archivo .part y obtener el objeto de modelo
            int erroresAbrirParte = 0;
            int warningsAbrirParte = 0;

            modelo = (ModelDoc2)Aplicacion.OpenDoc6(archivo,
                                                    (int)tipo,
                                                    (int)swOpenDocOptions_e.swOpenDocOptions_RapidDraft,
                                                    "", erroresAbrirParte, warningsAbrirParte);

            if (modelo == null)
                return 2; // error al generar modelo

            if(tipo == swDocumentTypes_e.swDocPART || tipo == swDocumentTypes_e.swDocASSEMBLY)
                modelo.ShowNamedView2("", (int)vista);

            modelo.ViewZoomtofit2();

            // Obtener configuracion del archivo
            Configuration configuracion = modelo.ConfigurationManager.ActiveConfiguration;
            string temp = Path.GetTempFileName();
            modelo.SaveBMP(temp, 0, 0);
            vistaPrevia = File.ReadAllBytes(temp);

            Aplicacion.CloseDoc(modelo.GetTitle());
            return 0;
        }

        public int VistaPrevia(ModelDoc2 modelo, out byte[] vistaPrevia, swStandardViews_e vista = swStandardViews_e.swIsometricView)
        {
            vistaPrevia = null;

            if (modelo == null)
                return 2; // error al generar modelo

            modelo.ShowNamedView2("", (int)vista);
            modelo.ViewZoomtofit2();

            // Obtener configuracion del archivo
            Configuration configuracion = modelo.ConfigurationManager.ActiveConfiguration;
            string temp = Path.GetTempFileName();
            modelo.SaveBMP(temp, 0, 0);
            vistaPrevia = File.ReadAllBytes(temp);
            return 0;
        }
        
        public double VolumenSolido(string solido)
        {
            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 0;

            ModelDoc2 modelo = default(ModelDoc2);

            // Abrir archivo .part y obtener el objeto de modelo
            int erroresAbrirParte = 0;
            int warningsAbrirParte = 0;

            modelo = (ModelDoc2)Aplicacion.OpenDoc6(solido,
                                                    (int)swDocumentTypes_e.swDocPART,
                                                    (int)swOpenDocOptions_e.swOpenDocOptions_Silent,
                                                    "", erroresAbrirParte, warningsAbrirParte);

            if (modelo == null)
                return 0; // error al generar modelo

            ModelDocExtension extension = (ModelDocExtension)modelo.Extension;
            MassProperty mp = extension.CreateMassProperty();
            mp.UseSystemUnits = false; 
            Double volumen = mp.Volume;
            Aplicacion.CloseDoc(modelo.GetTitle());

            return volumen;
        }

        public int ReemplazarComponente(string pathEnsambleLocal, string nombreComponente, string pathReemplazo, bool reemplazarTodos = true) 
        {
            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 1;

            //inicialización de las variables necesarias
            ModelDoc2 modelo = default(ModelDoc2);
            AssemblyDoc ensamble = default(AssemblyDoc);
            FeatureManager featureMgr = default(FeatureManager);
            ModelDocExtension documentoModelo = default(ModelDocExtension);
            SelectionMgr selectionMgr = default(SelectionMgr);
            Feature feature = default(Feature);
            Component2 swComponente = default(Component2);

            List<string> ListaInstanciasDeComponentes = new List<string>();
            int erroresAbrirEnsamble = 0;
            int warningsAbrirEnsamble = 0;
            int locationX = 0;
            int locationY = 0;
            int locationZ = 0;

            // Abrir archivo .SLDASM y obtener el objeto de modelo
            modelo = (ModelDoc2)Aplicacion.OpenDoc6(pathEnsambleLocal,
                                                    (int)swDocumentTypes_e.swDocASSEMBLY,
                                                    (int)swOpenDocOptions_e.swOpenDocOptions_RapidDraft,
                                                    "", erroresAbrirEnsamble, warningsAbrirEnsamble);

            ensamble = (AssemblyDoc)modelo;
            featureMgr = (FeatureManager)modelo.FeatureManager;
            documentoModelo = modelo.Extension;
            selectionMgr = (SelectionMgr)modelo.SelectionManager;

            //seleccionamos el primero que se encuantra en el ensamble
            feature = modelo.FirstFeature();

            if (selectionMgr == null || feature == null)
                return 2;

            //feature será null cuando la lista de partes dentro del ensamble ya haya sido procesada
            while (feature != null)
            {
                if (feature.GetTypeName2() == "Reference")
                {
                    //obtenemos la información del feature seleccionado
                    swComponente = feature.GetSpecificFeature2();

                    //comparamos que el componente sea igual a la parte seleccionada
                    if (swComponente.Name2.Contains(Path.GetFileNameWithoutExtension(nombreComponente) + "-"))
                    {
                        //Creamos el id con el nombre del componente + @ + el nombre del ensamble 
                        string idComponente = swComponente.Name2.ToString() + "@" + Path.GetFileNameWithoutExtension(pathEnsambleLocal);

                        //seleccionamos conforme al id 
                        documentoModelo.SelectByID2(idComponente, "COMPONENT", locationX, locationY, locationZ, true, 0, null, 0);
                        selectionMgr.GetSelectedObject6(1, -1);
                        bool status = ensamble.ReplaceComponents2(pathReemplazo + nombreComponente, "", true, 0, true);
                    }
                }
                //pasamos al siguiente
                feature = feature.GetNextFeature();
            }

            modelo.Save2(true);
            Aplicacion.CloseDoc(modelo.GetTitle());
            return 0;
        }

        public List<int> EnlistarSubensambles(string proyectoPath)
        {
            List<int> subensambles = new List<int>();
            
            //Agarramos los nombres de los archivos que contiene el directorio
            string[] archivosEnDirectorio = Directory.GetFiles(proyectoPath);

            //buscamos los subensambles
            //1.- Buscamos que archivo termine con SLDASM
            //2.- Buscamos que sólo contenga 1 guión, según
            //    la estructura es MPPP_00-00.sldasm por lo tanto buscamos sólo 1
            string[] listaSubensambles = Array.FindAll(archivosEnDirectorio, archivo => archivo.ToUpper().EndsWith("SLDASM") && Path.GetFileName(archivo).Count(x => x == '-') == 1);

            //llenamos la lista con los numeros de los subensambles
            foreach (string item in listaSubensambles)
            {
                string archivoSubensamble = Path.GetFileName(item);
                int intSubensamble = 0;
                if (int.TryParse(archivoSubensamble.Substring(8, 2), out intSubensamble) && intSubensamble > 0)
                    subensambles.Add(intSubensamble);
            }
            //eliminamos los duplicados
            subensambles = subensambles.Distinct().ToList();

            return subensambles;
        }

        public string CrearCarpetasSubensamble(List<int> listaSubensambles, string ensamblePath, decimal proyecto)
        {
            string carpetaRaiz = ensamblePath + "\\" + "M" + proyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');
            Directory.CreateDirectory(carpetaRaiz);

            //Estructura de la carpeta subensamble
            //1. #modulo : ensamble principal del modulo
            //2. CP : sldprt y slddrw
            foreach (int ensamble in listaSubensambles)
            {
                string modulo = ensamble.ToString().PadLeft(2, '0');

                string mpPath = carpetaRaiz + "\\" + modulo + "\\" + "MP";
                string ppPath = carpetaRaiz + "\\" + modulo + "\\" + "PP";
                string productPath = carpetaRaiz + "\\" + modulo + "\\" + "PRODUCT";
                string cpPath = carpetaRaiz + "\\" + modulo + "\\" + "CP";

                Directory.CreateDirectory(mpPath);
                Directory.CreateDirectory(ppPath);
                Directory.CreateDirectory(productPath);
                Directory.CreateDirectory(cpPath);
            }
            return carpetaRaiz;
        }

        public void copiarArchivos(string pathEnsamble, string destinoPathPrincipal, string carpeta)
        {
            string[] archivosEnDirectorio = Directory.GetFiles(pathEnsamble);

            switch (carpeta.Trim())
            {
                case "MP":
                    //buscamos los archivos que contengan -MP- en el ensamble principal
                    string[] copiarArchivosMP = Array.FindAll(archivosEnDirectorio, archivo => archivo.Contains("-MP-"));
                    foreach (string pathMP in copiarArchivosMP)
                    {
                        //creamos la ruta para los MP: MPPP_SS-XX-MP-AAAA-BBB.SLDPART/SLDASM foldeR: \\subensamble\\...-MP-AAAA\\
                        string[] descomponerPath = Path.GetFileNameWithoutExtension(pathMP).Split('-');
                        if (!Directory.Exists(destinoPathPrincipal + "\\" + descomponerPath[1] + "\\MP\\MP-" + descomponerPath[3]))
                            Directory.CreateDirectory(destinoPathPrincipal + "\\" + descomponerPath[1] + "\\MP\\MP-" + descomponerPath[3]);

                        //Copiamos los archivos dentro de la carpeta correspondiente
                        string[] copiarArchivo = {pathMP};
                        CopiarArchivosANuevoPath(copiarArchivo, destinoPathPrincipal + "\\" + descomponerPath[1] + "\\MP\\MP-" + descomponerPath[3]);
                    }
                    break;
                case "CP":

                    int numerico = 0;
                        
                    //buscamos los archivos del ensamble principal MPPP_SS-XX.sldasm (1 guión)
                    string[] archivosDelEnsamble = Array.FindAll(archivosEnDirectorio, archivo => Path.GetFileName(archivo).Count(x => x == '-') == 1 && archivo.Contains("-00."));                      
                    CopiarArchivosANuevoPath(archivosDelEnsamble, destinoPathPrincipal);

                    //buscamos los archivos .sldprt y/o slddrw MPPP_SS-XX-YYY.sldprt/slddrw (2 guiones)
                    string[] archivosDelSubensamble = Array.FindAll(archivosEnDirectorio, archivo => Path.GetFileName(archivo).Count(x => x == '-') == 2);                     
                    foreach (string archivo in archivosDelSubensamble)
	                {
                        string[] partesArchivo = Path.GetFileNameWithoutExtension(archivo).Split('-');
                        string nuevoPathSubensamble = string.Empty;
                        string nuevasPartesDrawings = string.Empty;

                        //buscamos el subensamble principal 
                        string[] subensamblePrincipal = Array.FindAll(archivosEnDirectorio, file => file.ToUpper().Contains(partesArchivo[0].ToUpper() + "-" + partesArchivo[1].ToUpper() + "."));
                        nuevoPathSubensamble = destinoPathPrincipal + "\\" + partesArchivo[1].PadLeft(2, '0');
                        CopiarArchivosANuevoPath(subensamblePrincipal, nuevoPathSubensamble);

                        //buscamos y colocamos los archivos .sldprt y/o slddrw dentro de la carpeta de CP
                        if (partesArchivo[2].Length == 3 && int.TryParse(partesArchivo[2], out numerico))
                        {
                            nuevasPartesDrawings = destinoPathPrincipal + "\\" + partesArchivo[1].PadLeft(2, '0') + "\\CP\\" + Path.GetFileName(archivo);
                            if(!File.Exists(nuevasPartesDrawings))
                                File.Copy(archivo, nuevasPartesDrawings);
                            else
                            {
                                File.Delete(nuevasPartesDrawings);
                                File.Copy(archivo, nuevasPartesDrawings);
                            }
                        }
	                }
                    break;
                default:
                    break;
            }
        }

        public ModelDoc2 CargarModelo(string ensamble, bool invisible=false)
        {
            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return null;

            swOpenDocOptions_e modoApertura = swOpenDocOptions_e.swOpenDocOptions_RapidDraft;

            //inicialización de las variables necesarias
            ModelDoc2 modelo = default(ModelDoc2);

            List<string> ListaInstanciasDeComponentes = new List<string>();
            int erroresAbrirEnsamble = 0;
            int warningsAbrirEnsamble = 0;

            // Abrir archivo .SLDASM y obtener el objeto de modelo
            modelo = (ModelDoc2)Aplicacion.OpenDoc6(ensamble,
                                                    (int)swDocumentTypes_e.swDocASSEMBLY,
                                                    (int)modoApertura,
                                                    "", erroresAbrirEnsamble, warningsAbrirEnsamble);

            if (invisible)
            {
                Frame fr = Aplicacion.Frame();
                fr.KeepInvisible = true;
            }
            return modelo;
        }

        public int testReemplazarComponente(ModelDoc2 modelo, string pathEnsambleLocal, string nombreComponente, string pathReemplazo, bool reemplazarTodos = true)
        {
            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 1;

            //inicialización de las variables necesarias         
            AssemblyDoc ensamble = default(AssemblyDoc);
            FeatureManager featureMgr = default(FeatureManager);
            ModelDocExtension documentoModelo = default(ModelDocExtension);
            SelectionMgr selectionMgr = default(SelectionMgr);
            Feature feature = default(Feature);
            Component2 swComponente = default(Component2);

            List<string> ListaInstanciasDeComponentes = new List<string>();
            int locationX = 0;
            int locationY = 0;
            int locationZ = 0;

            
            ensamble = (AssemblyDoc)modelo;
            featureMgr = (FeatureManager)modelo.FeatureManager;
            documentoModelo = modelo.Extension;
            selectionMgr = (SelectionMgr)modelo.SelectionManager;

            //seleccionamos el primero que se encuantra en el ensamble
            feature = modelo.FirstFeature();

            if (selectionMgr == null || feature == null)
                return 2;

            //feature será null cuando la lista de partes dentro del ensamble ya haya sido procesada
            while (feature != null)
            {
                if (feature.GetTypeName2() == "Reference")
                {
                    //obtenemos la información del feature seleccionado
                    swComponente = feature.GetSpecificFeature2();
                        
                    //comparamos que el componente sea igual a la parte seleccionada
                    if (swComponente.Name2.Contains(Path.GetFileNameWithoutExtension(nombreComponente) + "-"))
                    {
                        //Creamos el id con el nombre del componente + @ + el nombre del ensamble 
                        string idComponente = swComponente.Name2.ToString() + "@" + Path.GetFileNameWithoutExtension(pathEnsambleLocal);

                        //seleccionamos conforme al id 
                        documentoModelo.SelectByID2(idComponente, "COMPONENT", locationX, locationY, locationZ, true, 0, null, 0);
                        selectionMgr.GetSelectedObject6(1, -1);
                        bool status = ensamble.ReplaceComponents2(pathReemplazo, "", true, 0, true);
                    }
                }
                //pasamos al siguiente
                feature = feature.GetNextFeature();
            }
            return 0;
        }

        public int partesTestReemplazarComponente(ModelDoc2 modelo, string pathEnsambleLocal, string pathReemplazo)
        {
            // Si no se pudo inicializar SolidWorks regresa con error
            if (Aplicacion == null)
                return 1;

            //inicialización de las variables necesarias         
            AssemblyDoc ensamble = default(AssemblyDoc);
            FeatureManager featureMgr = default(FeatureManager);
            ModelDocExtension documentoModelo = default(ModelDocExtension);
            SelectionMgr selectionMgr = default(SelectionMgr);
            Feature feature = default(Feature);

            string path = string.Empty;
            string idComponente = string.Empty;
            string componente = string.Empty;

            int numerico = 0;
            int locationX = 0;
            int locationY = 0;
            int locationZ = 0;

            ensamble = (AssemblyDoc)modelo;
            featureMgr = (FeatureManager)modelo.FeatureManager;
            documentoModelo = modelo.Extension;
            selectionMgr = (SelectionMgr)modelo.SelectionManager;

            //seleccionamos el primero que se encuantra en el ensamble
            feature = modelo.FirstFeature();

            if (selectionMgr == null || feature == null)
                return 2;
            
            //feature será null cuando la lista de partes dentro del ensamble ya haya sido procesada
            while (feature != null)
            {
                //iteramos por cada feature encontrado en el subensamble
                if (feature.GetTypeName2() == "FtrFolder")
                {
                   // a.Add(feature.Name);
                    if(feature.Name == "CP")
                    {
                        //seleccionamos el feature CP para obetener el contenido
                        Feature SwfeatureCP = ensamble.FeatureByName("CP");
                        FeatureFolder swFeatFolderCP = SwfeatureCP.GetSpecificFeature2();

                        //obtenemos todos los features correspondientes a la carpeta CP
                        object[] Features = (object[])swFeatFolderCP.GetFeatures();

                        foreach (Feature swfeat in Features)
                        {
                            Component2 Swcomp = ensamble.GetComponentByName(swfeat.Name);
                            string[] checkCP = swfeat.Name.Split('-');
                            string[] descomponerPath = pathReemplazo.Split('\\');

                            //sldprt del subensamble actual
                            if (checkCP.Length == 4 && checkCP[2].Length == 3 && int.TryParse(checkCP[2], out numerico))
                            {
                                for (int i = 0; i < descomponerPath.Length - 2; i++)
                                    path += descomponerPath[i] + "\\";

                                path = path + checkCP[0] + "\\" + checkCP[1] + "\\CP\\";
                                componente = swfeat.Name.ToUpper().Remove(swfeat.Name.Length - 2) + ".SLDPRT";
                            }

                            //si sólo contiene 2 guines significa que va casado con un ensamble
                            else if (checkCP.Length == 3 && checkCP[2].Length == 1 && int.TryParse(checkCP[2], out numerico))
                            {
                                for (int i = 0; i < descomponerPath.Length - 2; i++)
                                    path += descomponerPath[i] + "\\";

                                path = path + checkCP[0] + "\\" + checkCP[1] + "\\";
                                componente = swfeat.Name.ToUpper().Remove(swfeat.Name.Length - 2) + ".SLDASM";
                            }

                            //Creamos el id con el nombre del componente + @ + el nombre del ensamble 
                            idComponente = swfeat.Name + "@" + Path.GetFileNameWithoutExtension(pathEnsambleLocal);

                            //seleccionamos conforme al id 
                            documentoModelo.SelectByID2(idComponente, "COMPONENT", locationX, locationY, locationZ, true, 0, null, 0);
                            selectionMgr.GetSelectedObject6(1, -1);
                            bool status = ensamble.ReplaceComponents2(path + componente, "", true, 0, true);
                        }
                    }
                    if (feature.Name == "PP")
                    {
                        //seleccionamos el feature MP para obetener el contenido
                        Feature SwfeaturePP = ensamble.FeatureByName("PP");
                        FeatureFolder swFeatFolderPP = SwfeaturePP.GetSpecificFeature2();
                        //obtenemos todos los features correspondientes a la carpeta CP
                        object[] FeaturesPP = (object[])swFeatFolderPP.GetFeatures();
                        List<string> a = new List<string>();
                        foreach (Feature swfeat in FeaturesPP)
                        {
                            a.Add(swfeat.Name);
                            string proveedorFolder = swfeat.Name; //nombre del folder TEST1[0], TEST2[1]


                        } 
                    }
                    if (feature.Name == "MP")
                    {
                                          
                    }
                }
                
                //pasamos al siguiente
                feature = feature.GetNextFeature();
            }


            return 0;
        }

        public void cerrarModelo(ModelDoc2 modelo)
        {
            modelo.Save2(true);
            Aplicacion.CloseDoc(modelo.GetTitle());
        }

        public void CopiarArchivosANuevoPath(string[] listaArchivos, string destinoPath)
        {
            foreach (string archivo in listaArchivos)
            {
                string nuevoPathEnsamble = destinoPath + "\\" + Path.GetFileName(archivo);

                if (!File.Exists(nuevoPathEnsamble))
                    File.Copy(archivo, nuevoPathEnsamble);
                else
                {
                    File.Delete(nuevoPathEnsamble);
                    File.Copy(archivo, nuevoPathEnsamble);
                }
            }
        }

        public void Terminar()
        {
            if (Aplicacion != null)
            {
                Aplicacion.ExitApp();
                Aplicacion = null;
            }
        }

    }
}
