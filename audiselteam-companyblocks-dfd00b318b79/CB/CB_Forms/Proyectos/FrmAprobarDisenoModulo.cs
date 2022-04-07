using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;
using System.IO;
using FluentFTP;
using System.Net;
using System.Threading;

namespace CB
{
    public partial class FrmAprobarDisenoModulo : Ventana
    {
        string RaizFtp;
        bool ModuloAprobado = false;
        public Modulo ModuloCargado;
        SolidWorksProyecto PorAprobar = new SolidWorksProyecto();
        SolidWorksAPI SW = null;
        bool CerrarSesionSW = false;
        FtpClient ClienteFtp = new FtpClient();

        public FrmAprobarDisenoModulo(Modulo modulo, SolidWorksAPI sw = null)
        {
            InitializeComponent();
            SW = sw;
            ModuloCargado = modulo;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BtnAprobar_Click(object sender, EventArgs e)
        {
            SplitEstatus.Panel1Collapsed = true;
            TxtEstatus.AppendText("Aprobando modulo..." + Environment.NewLine);
            BkgAprobar.RunWorkerAsync();
        }

        private void FrmAprobarDisenoModulo_Load(object sender, EventArgs e)
        {
            int planosPorDescartar = 0;

            if(!ModuloCargado.TieneFilas())
            {
                MessageBox.Show("Error al cargar modulo");
                Close();
                return;
            }
            SplitEstatus.Panel2Collapsed = true;
            LblModulo.Text = ModuloCargado.Fila().Celda("subensamble").ToString() + " - " + ModuloCargado.Fila().Celda("nombre").ToString();
            PorAprobar.SeleccionarPorAprobar(Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto")),
                                             Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble")));

            
            string strProyecto = Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto")).ToString("F2").PadLeft(6, '0').Replace(".", "_");
            RaizFtp = strProyecto + "/M" + strProyecto + "/";

            DgvPorAprobar.Rows.Clear();
            PorAprobar.Filas().ForEach(delegate(Fila f)
            {
                string nombreArchivo = f.Celda("nombre_archivo").ToString();
                string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(nombreArchivo);
                DgvPorAprobar.Rows.Add(nombreArchivoSinExtension, "");

                PlanoProyecto plano = new PlanoProyecto();
                plano.ConstruirQuery("SELECT * FROM planos_proyectos WHERE INSTR('" + nombreArchivoSinExtension + "', nombre_archivo) > 0 AND estatus!='DESCARTADO' ORDER BY id ASC");
                plano.EjecutarQuery();

                DataGridViewCellStyle estiloCeldaEstatus = DgvPorAprobar.Rows[DgvPorAprobar.RowCount - 1].Cells["estatus_plano"].Style;

                if(plano.LeerFilas().Count > 0)
                {
                    DgvPorAprobar.Rows[DgvPorAprobar.RowCount - 1].Cells["estatus_plano"].Value = "PLANO CON ID " + plano.Fila().Celda("id").ToString() + " POR DESCARTAR";
                    estiloCeldaEstatus.BackColor = Color.Red;
                    estiloCeldaEstatus.ForeColor = Color.White;
                    planosPorDescartar++;
                }
                else
                {
                    DgvPorAprobar.Rows[DgvPorAprobar.RowCount - 1].Cells["estatus_plano"].Value = "LISTO";
                    estiloCeldaEstatus.BackColor = Color.Green;
                    estiloCeldaEstatus.ForeColor = Color.White;
                }
            });

            BtnAprobar.Enabled = planosPorDescartar == 0;

            //if (PorAprobar.Filas().Count == 0)
            //    BtnAprobar.Enabled = false;
        }

        private void LblArchivosServidor_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BkgAprobar_DoWork(object sender, DoWorkEventArgs e)
        {
            ModuloAprobado = false;
            BkgAprobar.ReportProgress(0, "Conectando con SolidWorks... ");

            if(SW == null)
            {
                SW = new SolidWorksAPI();
                CerrarSesionSW = true;
            }

            // Conectar con servidor SolidWorks
            if (SW.Aplicacion == null)
            {
                BkgAprobar.ReportProgress(100, "[ERROR]");
                Thread.Sleep(4000);
                return;
            }
            else
                BkgAprobar.ReportProgress(20, "[OK]" + Environment.NewLine);

            // Conectar con servidor FTP
            BkgAprobar.ReportProgress(20, "Conectando con servidor FTP... ");
            if (Global.TipoConexion == "LOCAL")
            {
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }
            else
            {
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;
                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }

            // Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Connect();

                BkgAprobar.ReportProgress(40, "[OK]" + System.Environment.NewLine);
            }
            catch (Exception ex)
            {
                BkgAprobar.ReportProgress(100, "[ERROR]" + Environment.NewLine + ex.ToString() + Environment.NewLine);
                Thread.Sleep(4000);
                return;
            }

            // Aprobar diseno
            int i = 1;
            PorAprobar.Filas().ForEach(delegate(Fila f)
            {
                int porcentaje = Global.CalcularPorcentaje(i-1, PorAprobar.Filas().Count);
                string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(f.Celda("nombre_archivo").ToString());
                string rutaParcialSinExtension = Path.GetDirectoryName(f.Celda("nombre_archivo").ToString()) + "\\" + nombreArchivoSinExtension;

                string msg = "Aprobando plano '" + nombreArchivoSinExtension + "'..." + Environment.NewLine;
                BkgAprobar.ReportProgress(porcentaje, msg);

                byte[] datosPdf = null;              // bytes que representan el plano pdf 
                byte[] datosMiniaturaPdf = null;     // bytes que representan la imagen miniatura del pdf (png)

                // descargamos el archivo PDF del servidor (el cual debio ser actualizado al momento de revisar el plano)
                // y colocamos los datos en memoria
                if (ClienteFtp.FileExists(RaizFtp + rutaParcialSinExtension + ".PDF"))
                {
                    msg = "  Descargando plano PDF... ";
                    BkgAprobar.ReportProgress(porcentaje, msg);
                    ClienteFtp.Download(out datosPdf, RaizFtp + rutaParcialSinExtension + ".PDF");
                    msg = "[OK]" + Environment.NewLine;
                    BkgAprobar.ReportProgress(porcentaje, msg);
                }
                else
                    MessageBox.Show("El archivo '" + rutaParcialSinExtension + ".PDF' no fue encontrado en el servidor");

                // descargamos la miniatura PDF del servidor (la cual debio ser actualizada al momento de revisar el plano)
                // y colocamos los datos en memoria
                if (ClienteFtp.FileExists(RaizFtp + rutaParcialSinExtension + "_MIN.PNG"))
                {
                    msg = "  Descargando imagen miniatura del plano... ";
                    BkgAprobar.ReportProgress(porcentaje, msg);
                    ClienteFtp.Download(out datosMiniaturaPdf, RaizFtp + rutaParcialSinExtension + "_MIN.PNG");
                    msg = "[OK]" + Environment.NewLine;
                    BkgAprobar.ReportProgress(porcentaje, msg);
                }
                else
                    MessageBox.Show("El archivo '" + rutaParcialSinExtension + "_MIN.PDF' no fue encontrado en el servidor");
                
                // registramos los datos del plano en la base de datos, tabla planos_proyectos
                msg = "  Registrando plano en la base de datos... ";
                BkgAprobar.ReportProgress(porcentaje, msg);
                string strCantidad = string.Empty;
                string stockSize = "N/A";
                int cantidad = 0;
                string tratamiento = "N/A";
                string tipoTrabajo = "N/A";
                string material = "N/A";
                SolidworksCp customProperties = new SolidworksCp();
                customProperties.SeleccionarDrawing(Convert.ToInt32(f.Celda("id")));           

                if(customProperties.TieneFilas())
                {
                    stockSize = customProperties.Fila().Celda("THICKNESS").ToString() + " X " +
                                customProperties.Fila().Celda("WIDTH").ToString() + " X " +
                                customProperties.Fila().Celda("LENGTH").ToString();
                    material = customProperties.Fila().Celda("MATERIAL").ToString();

                    strCantidad = customProperties.Fila().Celda("QTY").ToString();
                    if(strCantidad.All(char.IsDigit))
                        cantidad = Convert.ToInt32(customProperties.Fila().Celda("QTY"));

                    tratamiento = customProperties.Fila().Celda("TREATMENT").ToString();
                    tipoTrabajo = customProperties.Fila().Celda("WORK_TYPE").ToString();
                }

                // inserta datos del plano en la tabla plano_proyecto
                PlanoProyecto plano = new PlanoProyecto();
                Fila filaPlano = new Fila();
                filaPlano.AgregarCelda("proyecto", ModuloCargado.Fila().Celda("proyecto"));
                filaPlano.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                filaPlano.AgregarCelda("cantidad", cantidad);
                filaPlano.AgregarCelda("tipo", tipoTrabajo);
                filaPlano.AgregarCelda("material", material);
                filaPlano.AgregarCelda("presentacion", "N/A");
                filaPlano.AgregarCelda("size", stockSize);
                filaPlano.AgregarCelda("tratamiento", tratamiento);
                filaPlano.AgregarCelda("nombre_archivo", nombreArchivoSinExtension);
                filaPlano.AgregarCelda("estatus", "PENDIENTE");
                filaPlano.AgregarCelda("fecha_creacion", DateTime.Now);
                filaPlano.AgregarCelda("plano_retrabajo", 0);
                filaPlano.AgregarCelda("comentarios_retrabajo", "");
                filaPlano.AgregarCelda("comentarios_ensamble", "");
                filaPlano.AgregarCelda("comentarios_revision", "");
                filaPlano.AgregarCelda("subensamble", ModuloCargado.Fila().Celda("subensamble"));

                // Agregado por Sergio Cazares, Marzo 28 2019
                // buscar una meta de fabricacion correspondiente con el mismo subensamble que el nuevo plano
                // si existe considerar la fecha promesa de la meta como fecha promesa de fabricacion para el nuevo plano
                MetaFabricacion meta = new MetaFabricacion();

                string entregableEsperado = "M";
                entregableEsperado += filaPlano.Celda("proyecto").ToString().Replace(".", "_").PadLeft(6, '0') + "-"; 
                entregableEsperado += filaPlano.Celda("subensamble").ToString().PadLeft(2, '0');

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@entregable", entregableEsperado);
                meta.SeleccionarDatos("tipo_entregable='MODULO' AND entregable=@entregable");

                if(meta.TieneFilas())
                {
                    filaPlano.AgregarCelda("fecha_promesa_fabricacion", meta.Fila().Celda("fecha_promesa"));
                }

                // insertar el nuevo plano en la base de datos y obtener su ID
                plano.Insertar(filaPlano);
                int idPlano = Convert.ToInt32(filaPlano.Celda("id"));

                // incrustar QR al PDF cargado en memoria
                try
                {
                    datosPdf = FormatosPDF.IncrustarQR(datosPdf, nombreArchivoSinExtension, idPlano.ToString(), 1150, 35);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
                // actualizar PDF en el servidor con el QR incluido
                ClienteFtp.Upload(datosPdf, RaizFtp + rutaParcialSinExtension + ".PDF", FtpExists.Overwrite);

                // renombrar los archivos cache (pdf, imagen, imagen miniatura e imagen de revision)
                VincularArchivosCacheConPlano(rutaParcialSinExtension, nombreArchivoSinExtension, idPlano);

                //============================================================================================================
                // debemos guardar una copia del plano y la miniatura correspondiente en la tabla archivos_planos, con el fin de
                // mantener compatibilidad con el monitor de fabricacion v1.
                // 
                // TO-DO: esto no sera necesario en el futuro, borrar cuando el monitor de fabricacion v2 este 100% funcional.
                Fila insertarArchivoPlano = new Fila();
                ArchivoPlano archivoPlano = new ArchivoPlano();

                insertarArchivoPlano.AgregarCelda("plano", idPlano);
                insertarArchivoPlano.AgregarCelda("archivo", datosPdf);
                insertarArchivoPlano.AgregarCelda("miniatura", datosMiniaturaPdf);
                archivoPlano.Insertar(insertarArchivoPlano);
                archivoPlano = null;
                //=============================================================================================================

                // modificar estatus de aprobacion
                msg = "[OK]" + Environment.NewLine; 
                porcentaje = Global.CalcularPorcentaje(i, PorAprobar.Filas().Count);
                BkgAprobar.ReportProgress(porcentaje, msg);

                f.ModificarCelda("estatus_aprobacion", "APROBADO");
                f.ModificarCelda("usuario_aprobacion", Global.UsuarioActual.NombreCompleto());
                f.ModificarCelda("fecha_aprobacion", DateTime.Now);

                // calcular el tetris
                //VincularPlanoConTetris(customProperties, plano, rutaParcialSinExtension);

                i++;
            });
            PorAprobar.GuardarDatos();
            ModuloCargado.Fila().ModificarCelda("estatus_fabricacion", "PENDIENTE");
            ModuloCargado.Fila().ModificarCelda("estatus_aprobacion", "APROBADO");
            ModuloCargado.Fila().ModificarCelda("usuario_aprobacion", Global.UsuarioActual.NombreCompleto());
            ModuloCargado.Fila().ModificarCelda("fecha_aprobacion", DateTime.Now); 
            ModuloCargado.GuardarDatos();
            ModuloAprobado = true;

            // calcula el avance de la meta...
            Meta metaModelo = new Meta();
            MetaEntregable metaEntregable = new MetaEntregable();   
            decimal idProyecto = Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto"));

            int idEntregable = Convert.ToInt32(ModuloCargado.Fila().Celda("id"));
            int idMeta = MetaEntregable.Modelo().BuscarMetaDelEntregable("MODULO CONGELADO", idEntregable);

            //calcular eficiencia
            CalcularEficienciaAvance(idMeta);

            if (idMeta > 0)
            {
                //calcular avance del modulo congelado
                metaModelo.ActualizarAvance(idMeta);           
            }

            //Calcular avance si se agregó un nuevo plano al modulo  
            metaEntregable.BuscarMetaDeModuloFabricado("MODULO FABRICADO", Convert.ToInt32(ModuloCargado.Fila().Celda("id")));
            if (metaEntregable.TieneFilas())
            {
                idMeta = Convert.ToInt32(metaEntregable.Fila().Celda("meta"));
                metaModelo.ActualizarAvance(idMeta);
            }
        }

        private void CalcularEficienciaAvance(int idMeta)
        {
            Meta meta = new Meta();
            meta.CargarDatos(idMeta);

            if (meta.TieneFilas())
            {
                decimal eficiencia = 0;
                DateTime fechaAutorizacion = Convert.ToDateTime(meta.Fila().Celda("fecha_autorizacion"));
                DateTime fechaPromesa = Convert.ToDateTime(meta.Fila().Celda("fecha_promesa"));
                decimal avance = Convert.ToDecimal(meta.Fila().Celda("avance"));

                TimeSpan diferenciaTranscurrida = DateTime.Now.Date - fechaAutorizacion.Date;
                TimeSpan diferenciaAutorizacionPromesa = fechaPromesa.Date - fechaAutorizacion.Date;
                int diasTranscurridos = diferenciaTranscurrida.Days;
                int diasDelProyecto = diferenciaAutorizacionPromesa.Days;
                int tiempoTranscurrido = 0;

                if (diasDelProyecto > 0)
                    tiempoTranscurrido = (diasTranscurridos * 100) / diasDelProyecto;
                else
                    tiempoTranscurrido = (diasTranscurridos * 100);
                if (tiempoTranscurrido == 0)
                    eficiencia = avance;
                else
                    eficiencia = (avance / tiempoTranscurrido) * 100;

                Fila insertarMetaEficiencia = new Fila();
                insertarMetaEficiencia.AgregarCelda("meta", idMeta);
                insertarMetaEficiencia.AgregarCelda("avance", avance);
                insertarMetaEficiencia.AgregarCelda("fecha", DateTime.Now);
                insertarMetaEficiencia.AgregarCelda("tiempo_transcurrido", tiempoTranscurrido);
                insertarMetaEficiencia.AgregarCelda("eficiencia", eficiencia);

                MetaEficiencia.Modelo().Insertar(insertarMetaEficiencia);
            }
        }

        public bool VincularPlanoConTetris(SolidworksCp customProperties, PlanoProyecto planoProyecto, string rutaParcialSinExtension, double widthMaximo=40, double lengthMaximo=40, string alcance="PROYECTO")
        {
            FractionalNumber fraccionDecimal;
            TetrisPlano tetrisPlano = new TetrisPlano();
            PlanoProceso proceso = new PlanoProceso(); 
            List<Fila> tetrisCompatibles = new List<Fila>();

            int modulo = 0;
            
            if(alcance == "MODULO")
                modulo = Convert.ToInt32(planoProyecto.Fila().Celda("subensamble").ToString());
            
            int cantidad = Convert.ToInt32(planoProyecto.Fila().Celda("cantidad").ToString());
            int planoId = Convert.ToInt32(planoProyecto.Fila().Celda("id").ToString());
            string thickness = customProperties.Fila().Celda("THICKNESS").ToString().Replace("\"", "");
            string fraccionPiezaWidth = customProperties.Fila().Celda("WIDTH").ToString().Replace("\"","");
            string fraccionPiezaLength = customProperties.Fila().Celda("LENGTH").ToString().Replace("\"", "");
            string proyecto = planoProyecto.Fila().Celda("proyecto").ToString();
            string material = planoProyecto.Fila().Celda("material").ToString();
            double areaDisponible = 0;

            // espacio maximo disponible en la bancada de la fresadora
            widthMaximo = widthMaximo - ((widthMaximo * 10) / 100);
            lengthMaximo = lengthMaximo - ((lengthMaximo * 10) / 100);

            // pieza
            fraccionDecimal = new FractionalNumber(fraccionPiezaWidth);
            double piezaW = fraccionDecimal.Result + (fraccionDecimal.Result * 10 )/100;
            fraccionDecimal = new FractionalNumber(fraccionPiezaLength);
            double piezaL = fraccionDecimal.Result + (fraccionDecimal.Result * 10)/100;
            fraccionDecimal = new FractionalNumber(thickness);
            double decimalThicness = fraccionDecimal.Result;

            // verificar el espesor, solo considerar espesores estandar: 3/8", 1/2", 3/4" y 1"
            if (thickness != "3/8" && thickness != "1/2" && thickness != "3/4" && thickness != "1")
                return false;

            // verificar el tipo de material, solo considerar aluminio y que no sea angulo
            if ( !material.ToUpper().Contains("ALUM") || material.ToUpper().Contains("ANGLE"))
                return false;

            // verificar si la pieza cabe en la bancada de la fresadora
            if (piezaW > widthMaximo || piezaL > lengthMaximo)
                return false;

            // si seguimos en este punto, la pieza es apta para incluirla en un tetris
            // ahora buscaremos los tetris que son compatibles
            Tetris tetris = new Tetris();
            tetrisCompatibles = tetris.SeleccionarPendientes(Convert.ToDecimal(proyecto), modulo, Convert.ToDecimal(decimalThicness), material, alcance);
            
            // si no encontramos ningun tetris compatible, creamos uno...
            if (tetrisCompatibles.Count == 0)
            {
                int idTetris = 0;
                Fila insertarTetris = new Fila();
                insertarTetris.AgregarCelda("proyecto", Convert.ToDecimal(proyecto).ToString("F2"));
                insertarTetris.AgregarCelda("modulo", modulo);
                insertarTetris.AgregarCelda("espesor_placa", decimalThicness);
                insertarTetris.AgregarCelda("largo_placa", 0);
                insertarTetris.AgregarCelda("ancho_placa", 0);
                insertarTetris.AgregarCelda("area_total", widthMaximo * lengthMaximo);
                insertarTetris.AgregarCelda("area_disponible", widthMaximo * lengthMaximo);
                insertarTetris.AgregarCelda("material", material);
                idTetris = Convert.ToInt32(Tetris.Modelo().Insertar(insertarTetris).Celda("id"));

                tetrisCompatibles.Add(insertarTetris);
            }

            double volumenPiezaActual = CalcularVolumenSolido(rutaParcialSinExtension, SW);
            double areaPiezaActual = (volumenPiezaActual / decimalThicness) * 1.10 * cantidad;
            bool piezaNoCabeEnTetrisCompatibles = true;

            // ciclo para buscar en todos los tetris compatibles las areas disponibles
            foreach(Fila tetrisCompatible in tetrisCompatibles)
            {
                // obtenemos el id del tetris
                int idTetrisCompatible = Convert.ToInt32(tetrisCompatible.Celda("id"));

                // verificamos el area disponible
                tetris.CargarDatos(idTetrisCompatible);
                areaDisponible = Convert.ToInt32(tetris.Fila().Celda("area_disponible"));

                // si la pieza cabe en el tetris, la vinculamos y evitamos crear uno nuevo
                if (areaPiezaActual < areaDisponible)
                {
                    Fila insertarTetrisPlanos = new Fila();
                    insertarTetrisPlanos.AgregarCelda("tetris", idTetrisCompatible);
                    insertarTetrisPlanos.AgregarCelda("plano", planoId);
                    tetrisPlano.Insertar(insertarTetrisPlanos);

                    tetris.CargarDatos(idTetrisCompatible);
                    tetris.Fila().ModificarCelda("area_disponible", areaDisponible - areaPiezaActual);
                    tetris.GuardarDatos();

                    piezaNoCabeEnTetrisCompatibles = false;
                    break;
                }
            }

            // si la pieza ya no cabe en ningun tetris compatible, deberemos crear uno nuevo...
            if (piezaNoCabeEnTetrisCompatibles)
            {
                // calculamos el area disponible del nuevo tetris
                areaDisponible = (widthMaximo * lengthMaximo) - areaPiezaActual;

                // creamos el nuevo tetris
                Fila insertarTetris = new Fila();
                insertarTetris.AgregarCelda("proyecto", Convert.ToDecimal(proyecto).ToString("F2"));
                insertarTetris.AgregarCelda("modulo", modulo);
                insertarTetris.AgregarCelda("espesor_placa", decimalThicness);
                insertarTetris.AgregarCelda("largo_placa", 0);
                insertarTetris.AgregarCelda("ancho_placa", 0);
                insertarTetris.AgregarCelda("area_total", widthMaximo * lengthMaximo);
                insertarTetris.AgregarCelda("area_disponible", areaDisponible);
                insertarTetris.AgregarCelda("material", material);
                int idTetrisInsertado = Convert.ToInt32(Tetris.Modelo().Insertar(insertarTetris).Celda("id"));

                // vinculamos la pieza actual con el tetris creado
                Fila insertarTetrisPlanos = new Fila();
                insertarTetrisPlanos.AgregarCelda("tetris", idTetrisInsertado);
                insertarTetrisPlanos.AgregarCelda("plano", planoId);
                tetrisPlano.Insertar(insertarTetrisPlanos);
            }

            // agregamos el proceso de tetris al plano
            Fila insertarPlanoProceso = new Fila();
            insertarPlanoProceso.AgregarCelda("plano", planoId);
            insertarPlanoProceso.AgregarCelda("proceso", "TETRIS CNC " + thickness + "\"");
            insertarPlanoProceso.AgregarCelda("orden", 10);
            insertarPlanoProceso.AgregarCelda("tipo_asignacion", "LOCAL");
            proceso.Insertar(insertarPlanoProceso);

            // cambiamos el estatus del plano a 'EN PREPARACION'
            planoProyecto.CargarDatos(planoId);
            planoProyecto.Fila().ModificarCelda("estatus", "EN PREPARACION");
            planoProyecto.GuardarDatos();

            return true;
        }

        public void VincularArchivosCacheConPlano(string rutaParcialSinExtension, string nombreArchivoSinExtension, int idPlano, string extensiones=".PNG, .PDF, _MIN.PNG, _REV.PNG, _ISO.PNG")
        {
            foreach (string extension in extensiones.Split(','))
            {
                if (ClienteFtp.FileExists(RaizFtp + rutaParcialSinExtension + extension.Trim()))
                    ClienteFtp.Rename(RaizFtp + rutaParcialSinExtension + extension.Trim(), RaizFtp + rutaParcialSinExtension.Replace(nombreArchivoSinExtension, idPlano + " " + nombreArchivoSinExtension + extension.Trim()));
            }
        }

        public double CalcularVolumenSolido(string rutaParcialSinExtension, SolidWorksAPI sw)
        {
            string rutaParcialSolido = rutaParcialSinExtension + ".SLDPRT";
            string nombreSolidoSinExtension = Path.GetFileNameWithoutExtension(rutaParcialSolido);
            string rutaTemporalSolido = Path.GetTempPath() + nombreSolidoSinExtension + "_TEMP.SLDPRT";
            double volumen = 0;
          
            byte[] datosSolido = null;
            if (ClienteFtp.FileExists(RaizFtp + rutaParcialSolido))
            {
                ClienteFtp.Download(out datosSolido, RaizFtp + rutaParcialSolido);
                File.WriteAllBytes(rutaTemporalSolido, datosSolido);
                volumen = sw.VolumenSolido(rutaTemporalSolido);
            }
            return volumen;
        }

        private void BkgAprobar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatus.AppendText(e.UserState.ToString());
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgAprobar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ModuloAprobado)
            {
                MessageBox.Show("El modulo fue aprobado correctamente.", "Modulo aprobado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Ocurrio un error al aprobar el modulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            Close();
        }

        private void FrmAprobarDisenoModulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SW != null && CerrarSesionSW)
                SW.Terminar();
        }
    }
}
