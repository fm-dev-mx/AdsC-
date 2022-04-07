using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmRegistrarLibreriaDme : Form
    {
        string FtpPath = @"\SGC\LIB_DME\";
        string NombreFamilia = string.Empty;
        string[] CarpetasArchivos;
        bool ArchivosCargados = false;
        LibreriaDme CargarLibreria = new LibreriaDme();
        int Fabricante = 0;
        int IdSubcategoria = 0;
        int IdLibreria = 0;


        public FrmRegistrarLibreriaDme(int idLibreria = 0)
        {
            InitializeComponent();
            IdLibreria = idLibreria;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCategoria();
            CargarFabricantes();

            BtnRegistrar.Enabled = false;
            LblProgreso.Visible = false;
            Progreso.Visible = false;

            if(IdLibreria > 0)
            {
                //se carga una libreria existente
                BtnRegistrar.Text = "Editar";

                int tipoCompra = 0;
                CargarLibreria.CargarDatos(IdLibreria);
                if (CargarLibreria.TieneFilas())
                {
                    //sacamos el id de Materia prima especial
                    ComprasTipos comprasTipo = new ComprasTipos();
                    comprasTipo.SeleccionarTipoDeCompra("MATERIA PRIMA ESPECIAL");
                    if (comprasTipo.TieneFilas())
                        tipoCompra = comprasTipo.Fila().Celda<int>("id");

                    //Seleccionamos la categoria
                    CategoriaMaterial cat = new CategoriaMaterial();
                    cat.SeleccionarCategoriaDeLibreria(CargarLibreria.Fila().Celda<int>("subcategoria"), tipoCompra);
                    if (cat.TieneFilas())
                    {
                        //Cargamos el id de la categoria
                        CmbCategoria.SelectedValue = cat.Fila().Celda<int>("id");

                        //Cargamos el id de la subcategoria
                        CmbSubcategoria.SelectedValue = Convert.ToInt32(CargarLibreria.Fila().Celda("subcategoria"));

                        //cargamos el id del fabricante
                        Fabricante fabricante = new Fabricante();
                        fabricante.CargarDatos(CargarLibreria.Fila().Celda<int>("fabricante"));

                        if (fabricante.TieneFilas())
                            CmbFabricante.SelectedValue = fabricante.Fila().Celda<int>("id");

                        TxtFamilia.Text = CargarLibreria.Fila().Celda("familia").ToString();
                        TxtCarpeta.Text = CargarLibreria.Fila().Celda("carpeta").ToString();
                    }

                    //Cargamos los archivos del servidor
                    LibreriaDmeArchivo libArchivos = new LibreriaDmeArchivo();
                    libArchivos.SeleccionarArchivosDeLibreria(IdLibreria).ForEach(delegate(Fila f)
                    {
                        DgvArchivos.Rows.Add(f.Celda("nombre_archivo"));
                    });

                    MessageBox.Show("Para editar la librería es necesario volver a cargar los archivos", "Cargar archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //si no se puede encontrar el id de la libreria en la tabla cerramos el foarm
                    MessageBox.Show("No se pudo encontrar la librería", "Libreria no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                //Se va a registrar una nueva libreria
                CmbCategoria.Text = "TODOS";
                CmbSubcategoria.Text = "TODOS";
                CmbFabricante.Text = "TODOS";
            }
        }

        private void CargarCategoria()
        {
            int idTipo = 0;

            BindingSource categoriasBinding = new BindingSource();
            ComprasTipos comprasTipo = new ComprasTipos();
            comprasTipo.SeleccionarTipoDeCompra("MATERIA PRIMA ESPECIAL");

            if(comprasTipo.TieneFilas())
                idTipo = Convert.ToInt32(comprasTipo.Fila().Celda("id"));

            categoriasBinding.Add(new
            {
                Text = "TODOS",
                Value = 0
            });

            CategoriaMaterial.Modelo().SeleccionCategoriasDeTipoCompra(idTipo).ForEach(delegate(Fila f)
            {
                categoriasBinding.Add(new
                {
                    Text = f.Celda("categoria").ToString(),
                    Value = Convert.ToInt32(f.Celda("id"))
                });
            });

            CmbCategoria.DisplayMember = "Text";
            CmbCategoria.ValueMember = "Value";
            CmbCategoria.DataSource = categoriasBinding;
        }

        private void CargarSubcategorias()
        {
            BindingSource SubcategoriasBinding = new BindingSource();
            SubcategoriasBinding.Add(new
            {
                Text = "TODOS",
                Value = 0
            });

            CategoriaSubMaterial.Modelo().SeleccionarSubcategoriaPorCategoria(Convert.ToInt32(CmbCategoria.SelectedValue)).ForEach(delegate(Fila f)
            {
                SubcategoriasBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = Convert.ToInt32(f.Celda("id"))
                });
            });

            CmbSubcategoria.DisplayMember = "Text";
            CmbSubcategoria.ValueMember = "Value";
            CmbSubcategoria.DataSource = SubcategoriasBinding;

        }

        private void CargarFabricantes()
        {
            BindingSource FabricantessBinding = new BindingSource();
            FabricantessBinding.Add(new
            {
                Text = "TODOS",
                Value = 0
            });
            
            Fabricante fabricante = new Fabricante();
            fabricante.SeleccionarFabricanteAlfabeticamente().ForEach(delegate(Fila f)
            {
                FabricantessBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = Convert.ToInt32(f.Celda("id"))
                });
            });

            CmbFabricante.DisplayMember = "Text";
            CmbFabricante.ValueMember = "Value";
            CmbFabricante.DataSource = FabricantessBinding;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LblProgreso.Visible = true;
            Progreso.Visible = true;
            CmbCategoria.Enabled = false;
            CmbSubcategoria.Enabled = false;
            TxtFamilia.ReadOnly = true;
            btnBuscar.Enabled = false;
            BtnRegistrar.Enabled = false;
            BtnCancelar.Enabled = false;

            if (IdLibreria > 0)
                BkgEditarLibreria.RunWorkerAsync(TxtCarpeta.Text);
            else
                BkgRegistrarLibreria.RunWorkerAsync(TxtCarpeta.Text);
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarSubcategorias();
            btnBuscar.Enabled = (CmbSubcategoria.Text != "TODOS" && CmbSubcategoria.Text != "TODOS" && CmbFabricante.Text != "TODOS" && TxtFamilia.Text != "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DgvArchivos.Rows.Clear();

                    NombreFamilia = TxtFamilia.Text;
                    Fabricante = Convert.ToInt32(CmbFabricante.SelectedValue);
                    IdSubcategoria = Convert.ToInt32(CmbSubcategoria.SelectedValue);

                    CarpetasArchivos = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.AllDirectories);
                    string buscarLibreria = Array.Find(CarpetasArchivos, x => x.ToLower().Contains("-lib.sldprt") || x.ToLower().Contains("-lib.sldasm"));
                    
                    if(buscarLibreria.Length <= 0)
                    {
                        MessageBox.Show("No se encontró el archivo " + TxtFamilia.Text + "-lib.sldprt o ".ToUpper() + TxtFamilia.Text + "-lib.sldasm".ToUpper());
                        return;
                    }

                    TxtCarpeta.Text = Path.GetFileName(fbd.SelectedPath);
                    foreach (string  path in CarpetasArchivos)
                        DgvArchivos.Rows.Add(ObtenerNombreArchivos(path, TxtCarpeta.Text));

                    BtnRegistrar.Enabled = true;
                }
            }
        }

        private string ObtenerNombreArchivos(string path, string CarpetaPrincipal)
        {
            string nombreArchivo = string.Empty;
            string[] pathDividido = path.Split('\\');
            int carpetaPrincipalIndice = Array.FindIndex(pathDividido, x => x.Equals(CarpetaPrincipal));

            for (int i = carpetaPrincipalIndice; i < pathDividido.Length; i++)
            {
                nombreArchivo += "\\" + pathDividido[i];
            }

            return nombreArchivo;
        }

        public string GetFullPathWithoutExtension(string path)
        {
            return Path.Combine(System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(path));
        }

        FormatoArchivo Extension(string archivo)
        {
            FormatoArchivo extension = FormatoArchivo.sldasm;

            switch (Path.GetExtension(archivo).ToLower())
            {
                case ".sldprt":
                    extension = FormatoArchivo.sldprt;
                    break;
                case ".sldasm":
                    extension = FormatoArchivo.sldasm;
                    break;
            }
            return extension;
        }

        private void BkgRegistrarLibreria_DoWork(object sender, DoWorkEventArgs e)
        {
            int avance = 0;
            int idLibreria = 0;
            string nombreCarpeta = (string)e.Argument;
            string[] carpetas = CarpetasArchivos;
            string libreria = Array.Find(carpetas, x => x.Contains(NombreFamilia + "-LIB."));
            byte[] libreriaDatos = File.ReadAllBytes(libreria);

            //Crera id de libreria para subir libreria
            string rutaFtp = Path.GetDirectoryName(ObtenerNombreArchivos(Path.GetFullPath(libreria), nombreCarpeta));
            Fila insertarLibreria = new Fila();
            insertarLibreria.AgregarCelda("subcategoria", IdSubcategoria);
            insertarLibreria.AgregarCelda("fabricante", Fabricante);
            insertarLibreria.AgregarCelda("familia", NombreFamilia);
            insertarLibreria.AgregarCelda("nombre_archivo",   "\\" + idLibreria.ToString().PadLeft(3,'0') + ObtenerNombreArchivos(Path.GetFullPath(libreria), nombreCarpeta));
            insertarLibreria.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
            insertarLibreria.AgregarCelda("fecha_creacion", DateTime.Now);
            insertarLibreria.AgregarCelda("carpeta", nombreCarpeta);
            idLibreria = Convert.ToInt32(LibreriaDme.Modelo().Insertar(insertarLibreria).Celda("id"));
            avance++;
            BkgRegistrarLibreria.ReportProgress(Global.CalcularPorcentaje(avance, carpetas.Length), "SUBIENDO LIBRERIA...");

            //si la librería se subió al servidor se procede a subir los archivos de la librería
            if (ServidorFtp.SubirDocumento(libreriaDatos, Path.GetFileNameWithoutExtension(libreria), Extension(libreria), FtpPath + idLibreria.ToString().PadLeft(3,'0') + rutaFtp))
            {
                LibreriaDme modificarLib = new LibreriaDme();
                modificarLib.CargarDatos(idLibreria);

                if(modificarLib.TieneFilas())
                {
                    modificarLib.Fila().ModificarCelda("nombre_archivo", "\\" + idLibreria.ToString().PadLeft(3, '0') + ObtenerNombreArchivos(Path.GetFullPath(libreria), nombreCarpeta));
                    modificarLib.GuardarDatos();
                }

                //dar de alta archivos de la librería
                foreach (string archivo in carpetas)
                {
                    if (archivo != libreria)
                    {
                        byte[] archivosDatos = File.ReadAllBytes(archivo);
                        rutaFtp = Path.GetDirectoryName(ObtenerNombreArchivos(Path.GetFullPath(archivo), nombreCarpeta));

                        //subir archivos
                        if (ServidorFtp.SubirDocumento(archivosDatos, Path.GetFileNameWithoutExtension(archivo), Extension(archivo), FtpPath + idLibreria.ToString().PadLeft(3, '0') + rutaFtp + "\\"))
                        {
                            Fila insertarLibreriaDmeArchivos = new Fila();
                            insertarLibreriaDmeArchivos.AgregarCelda("libreria_dme", idLibreria);
                            insertarLibreriaDmeArchivos.AgregarCelda("nombre_archivo", "\\" + idLibreria.ToString().PadLeft(3, '0') + ObtenerNombreArchivos(Path.GetFullPath(archivo), nombreCarpeta));
                            LibreriaDmeArchivo.Modelo().Insertar(insertarLibreriaDmeArchivos);
                            avance++;
                            BkgRegistrarLibreria.ReportProgress(Global.CalcularPorcentaje(avance, carpetas.Length), "SUBIENDO ARCHIVOS...");
                        }
                    }
                }
            }
            else
            {
                //en caso que no se haya podido subir la libreria se borra de la base de datos
                LibreriaDme lib = new LibreriaDme();
                lib.CargarDatos(idLibreria);
                lib.BorrarDatos(idLibreria);
                lib.GuardarDatos();

                BkgRegistrarLibreria.ReportProgress(100, "Error, intente de nuevo");
            }            
        }

        private void BkgRegistrarLibreria_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
            LblProgreso.Text = e.UserState.ToString();
        }

        private void BkgRegistrarLibreria_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void TxtCarpeta_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = (CmbSubcategoria.Text != "TODOS" && CmbSubcategoria.Text != "TODOS" && CmbFabricante.Text != "TODOS" && TxtFamilia.Text != "");
        }

        private void TxtFamilia_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = (CmbSubcategoria.Text != "TODOS" && CmbSubcategoria.Text != "TODOS" && CmbFabricante.Text != "TODOS" && TxtFamilia.Text != "");
        }

        private void CmbFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = (CmbSubcategoria.Text != "TODOS" && CmbSubcategoria.Text != "TODOS" && CmbFabricante.Text != "TODOS" && TxtFamilia.Text != "");
        }

        private void CmbSubcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = (CmbSubcategoria.Text != "TODOS" && CmbSubcategoria.Text != "TODOS" && CmbFabricante.Text != "TODOS" && TxtFamilia.Text != "");
        }

        private void BkgEditarLibreria_DoWork(object sender, DoWorkEventArgs e)
        {
            int avance = 0;
            string nombreCarpeta = (string)e.Argument;
            string[] carpetas = CarpetasArchivos;
            string libreria = Array.Find(carpetas, x => x.Contains(NombreFamilia + "-LIB."));
            byte[] libreriaDatos = File.ReadAllBytes(libreria);

            //Crera id de libreria para subir libreria
            string rutaFtp = Path.GetDirectoryName(ObtenerNombreArchivos(Path.GetFullPath(libreria), nombreCarpeta));
            BkgEditarLibreria.ReportProgress(Global.CalcularPorcentaje(avance, carpetas.Length), "ACTUALIZANDO ARCHIVOS...");

            //borrar archivos de FTP
            bool archivosBorrados = ServidorFtp.EliminarDirectorio(FtpPath + IdLibreria.ToString().PadLeft(3, '0'));

            if (archivosBorrados)
            {
                //si la librería se subió al servidor se procede a subir los archivos de la librería
                if (ServidorFtp.SubirDocumento(libreriaDatos, Path.GetFileNameWithoutExtension(libreria), Extension(libreria), FtpPath + IdLibreria.ToString().PadLeft(3, '0') + rutaFtp))
                {
                    LibreriaDme modificarLib = new LibreriaDme();
                    modificarLib.CargarDatos(IdLibreria);

                    if (modificarLib.TieneFilas())
                    {
                        //modificar registro de la libreria 
                        modificarLib.Fila().ModificarCelda("subcategoria", IdSubcategoria);
                        modificarLib.Fila().ModificarCelda("fabricante", Fabricante);
                        modificarLib.Fila().ModificarCelda("familia", NombreFamilia);
                        modificarLib.Fila().ModificarCelda("carpeta", nombreCarpeta);
                        modificarLib.Fila().ModificarCelda("nombre_archivo", "\\" + IdLibreria.ToString().PadLeft(3, '0') + ObtenerNombreArchivos(Path.GetFullPath(libreria), nombreCarpeta));
                        modificarLib.GuardarDatos();
                    }

                    //borrar archivos fr la libreria del ftp
                    LibreriaDmeArchivo.Modelo().SeleccionarArchivosDeLibreria(IdLibreria).ForEach(delegate(Fila f)
                    {
                        LibreriaDmeArchivo borrarArchivos = new LibreriaDmeArchivo();
                        borrarArchivos.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        borrarArchivos.BorrarDatos(Convert.ToInt32(borrarArchivos.Fila().Celda("id")));
                        borrarArchivos.GuardarDatos();
                    });

                    //dar de alta archivos de la librería
                    foreach (string archivo in carpetas)
                    {
                        if (archivo != libreria)
                        {
                            byte[] archivosDatos = File.ReadAllBytes(archivo);
                            rutaFtp = Path.GetDirectoryName(ObtenerNombreArchivos(Path.GetFullPath(archivo), nombreCarpeta));

                            //subir archivos
                            if (ServidorFtp.SubirDocumento(archivosDatos, Path.GetFileNameWithoutExtension(archivo), Extension(archivo), FtpPath + IdLibreria.ToString().PadLeft(3, '0') + rutaFtp + "\\"))
                            {
                                Fila insertarLibreriaDmeArchivos = new Fila();
                                insertarLibreriaDmeArchivos.AgregarCelda("libreria_dme", IdLibreria);
                                insertarLibreriaDmeArchivos.AgregarCelda("nombre_archivo", "\\" + IdLibreria.ToString().PadLeft(3, '0') + ObtenerNombreArchivos(Path.GetFullPath(archivo), nombreCarpeta));
                                LibreriaDmeArchivo.Modelo().Insertar(insertarLibreriaDmeArchivos);
                                avance++;
                                BkgEditarLibreria.ReportProgress(Global.CalcularPorcentaje(avance, carpetas.Length), "ACTUALIZANDO ARCHIVOS...");
                            }
                        }
                    }
                }
                else
                {
                    //en caso que no se haya podido subir la libreria se borra de la base de datos
                    LibreriaDme lib = new LibreriaDme();
                    lib.CargarDatos(IdLibreria);
                    lib.BorrarDatos(IdLibreria);
                    lib.GuardarDatos();

                    BkgEditarLibreria.ReportProgress(100, "Error, intente de nuevo");
                }
            }
        }

        private void BkgEditarLibreria_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
            LblProgreso.Text = e.UserState.ToString();
        }

        private void BkgEditarLibreria_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
