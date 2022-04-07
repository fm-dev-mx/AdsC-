using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using System.Net;
using System.IO;
using System.Drawing.Drawing2D;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmProcesosFabricacionAsignados : Form
    {
        public enum Incumplimiento
        {
            Sin_Cerrar,
            No_Inicializado,
        }

        int IdHerramentista = 0;
        int IdProceso = 0;
        int Index = -1;
       
        Decimal Proyecto;
        FtpClient ClienteFtp = null;
        List<Tuple<int, int>> ListaDeProcesos = new List<Tuple<int, int>>();
        const int IntervaloActualizar = 60;
        private int RefrescarContador = IntervaloActualizar;

        string RutaParcialSinExtension = string.Empty;
        string RaizFtp = string.Empty;
        string ProcesoEscanado = string.Empty;
        string EstatusProceso = string.Empty;
        string Subensamble = string.Empty;
        byte[] PlanoImagen;
        bool PlanoDescargado = false;

        public FrmProcesosFabricacionAsignados(int idHerramentista, FtpClient clienteFtp = null)
        {
            InitializeComponent();
            IdHerramentista = idHerramentista;
            ClienteFtp = clienteFtp;

            Usuario herramentista = new Usuario();
            herramentista.CargarDatos(idHerramentista);

            if (herramentista.TieneFilas())
            {
                LblOperador.Text = herramentista.Fila().Celda("id") + " | " + herramentista.NombreCompleto();
            }
            else LblOperador.Text = "ERROR: HERRAMENTISTA DESCONOCIDO";
        }

        private void FrmOpcionesProceso_Load(object sender, EventArgs e)
        {
            ActiveControl = TxtEscanearPlano;
            TxtEscanearPlano.Focus();

            TimerOpciones = new Timer();
            TimerOpciones.Tick += new EventHandler(TimerOpciones_Tick);
            TimerOpciones.Interval = 1000;
            lblTimer.Visible = false;
            TimerOpciones.Start();

            BtnIniciar.Enabled = false;
            BtnDetener.Enabled = false;
            BtnTerminar.Enabled = false;
            CmbProcesos.Enabled = true;
            BtnSalir.Enabled = true;

            splitContainer1.Panel2Collapsed = true;
            splitContainer1.Panel2.Hide();
            CargarProcesos();
        }

        private void CargarProcesos()
        {
            CmbProcesos.Items.Clear();

            PlanoProyecto planoProyecto = new PlanoProyecto();
            PlanoProceso planoProceso = new PlanoProceso();
            planoProceso.CargarProcesosHerramentista(IdHerramentista).ForEach(delegate(Fila f)
            {
                planoProyecto.CargarDatos(Convert.ToInt32(f.Celda("plano")));
                if (planoProyecto.TieneFilas())
                {
                    CmbProcesos.Items.Add(f.Celda("plano") + " - " + planoProyecto.Fila().Celda("nombre_archivo").ToString().Replace("_", " ") + " | " + f.Celda("id") + " - " + f.Celda("proceso") + "|" + f.Celda("estatus"));
                    ListaDeProcesos.Add(new Tuple<int,int>(CmbProcesos.Items.Count - 1, Convert.ToInt32(f.Celda("plano"))));
                }
            });
        }

        private void HabilitarBotones(int idProceso)
        {
            PlanoProceso proceso = new PlanoProceso();
            proceso.CargarDatos(idProceso);
            if(proceso.TieneFilas())
            {
                string estatus = proceso.Fila().Celda("estatus").ToString();
                ActiveControl = TxtEscanearPlano;
                TxtEscanearPlano.Focus();
                switch (estatus)
                {
                    case "ASIGNADO":
                        BtnIniciar.Text = "       Iniciar";
                        BtnIniciar.Enabled = true;
                        BtnDetener.Enabled = false;
                        BtnTerminar.Enabled = false;
                        BtnSalir.Enabled = true;
                        break;
                    case "EN PROCESO":
                        BtnIniciar.Enabled = false;
                        BtnDetener.Enabled = true;
                        BtnTerminar.Enabled = true;
                        BtnSalir.Enabled = true;
                        break;
                    case "DETENIDO":
                        BtnIniciar.Enabled = true;
                        BtnIniciar.Text = "       Continuar";
                        BtnDetener.Enabled = false;
                        BtnTerminar.Enabled = false;
                        BtnSalir.Enabled = true;
                        break;
                    default:
                        break;
                }
            }           
        }

        private void CargarProceso(int idProceso)
        {
            PlanoProceso planoProceso = new PlanoProceso();
            planoProceso.CargarDatos(idProceso);
            if(planoProceso.TieneFilas())
            { 
                LblIdProceso.Text = planoProceso.Fila().Celda("id").ToString() + " | " + planoProceso.Fila().Celda("proceso").ToString();
                TxtComentarios.Text = planoProceso.Fila().Celda("comentarios").ToString();
                LblEstatus.Text = planoProceso.Fila().Celda("estatus").ToString();
                LblTiempoMeta.Text = "Tiempo estimado (meta): " + TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(planoProceso.Fila().Celda("tiempo_trabajo_estimado"), "0"))).ToString("h\\:mm") + " hrs";

                TimeSpan horasFabricacion = TimeSpan.Parse("00:00:00"); 
                string tiempoInicio = Global.FechaATexto(planoProceso.Fila().Celda("fecha_inicio"));

                if (tiempoInicio != "N/A")
                {
                    string tiempoActual = DateTime.Now.ToString();
                    LblFechaInicio.Text = "Hora inicio: " + Global.FechaATexto(tiempoInicio);

                    TiempoFabricacion tiempoFabricacion = new TiempoFabricacion();
                    tiempoFabricacion.CargarTiempoFabricacion(idProceso).ForEach(delegate(Fila f)
                    {
                        DateTime fechaParo;
                        if (Global.ObjetoATexto(f.Celda("fecha_paro"), "N/A") != "N/A")
                            fechaParo = Convert.ToDateTime(f.Celda("fecha_paro").ToString());
                        else
                            fechaParo = DateTime.Now;
                        DateTime fechaInicio = Convert.ToDateTime(f.Celda("fecha_inicio").ToString());

                        TimeSpan diferenciaHoras = fechaParo - fechaInicio;
                        horasFabricacion = horasFabricacion.Add(diferenciaHoras);
                    });

                    TimeSpan totalTiempoMuerto = TimeSpan.Parse("00:00:00");

                    TiempoMuerto tiempoMuerto = new TiempoMuerto();
                    tiempoMuerto.CalcularTiempoMuerto(idProceso).ForEach(delegate(Fila f)
                    {
                        string tiempoMuertoFin = string.Empty;
                        string tiempoMuertoInicio = f.Celda("inicio").ToString();

                        if(Global.ObjetoATexto(f.Celda("fin"), "N/A") != "N/A")
                            tiempoMuertoFin = f.Celda("fin").ToString();
                        else
                            tiempoMuertoFin = DateTime.Now.ToString();

                        TimeSpan diferenciaTiempoMuerto = Convert.ToDateTime(tiempoMuertoFin) - Convert.ToDateTime(tiempoMuertoInicio);
                        //totalTiempoMuerto = totalTiempoMuerto + diferenciaTiempoMuerto;
                        RazonTiempoMuerto razonTiempoMurto = new RazonTiempoMuerto();
                        razonTiempoMurto.CargarDatos(Convert.ToInt32(f.Celda("razon")));
                        if (razonTiempoMurto.TieneFilas())
                        {
                            if (razonTiempoMurto.Fila().Celda("razon").ToString() != "HORA DE COMIDA" && razonTiempoMurto.Fila().Celda("razon").ToString() != "BAÑO")
                                totalTiempoMuerto = totalTiempoMuerto.Add(diferenciaTiempoMuerto);
                            else if (razonTiempoMurto.Fila().Celda("razon").ToString() == "BAÑO" || razonTiempoMurto.Fila().Celda("razon").ToString() == "HORA DE COMIDA")
                            {
                                TimeSpan tiempo = TimeSpan.Parse("00:00:00");

                                if (razonTiempoMurto.Fila().Celda("razon").ToString() == "BAÑO")
                                    tiempo = TimeSpan.Parse("00:10:00");
                                else
                                    tiempo = TimeSpan.Parse("01:0:00"); //HORA DE COMIDA

                                if (tiempo < diferenciaTiempoMuerto)
                                {
                                    TimeSpan tiempoMuertoBanio = diferenciaTiempoMuerto - tiempo;
                                    totalTiempoMuerto = totalTiempoMuerto.Add(tiempoMuertoBanio);
                                }
                            }
                        }
                    });

                    LblTiempoMuerto.Text = "Tiempo muerto: " + totalTiempoMuerto.Days + " días " + totalTiempoMuerto.Hours + " hrs " + totalTiempoMuerto.Minutes + " minutos";
                    TimeSpan totalProduccion = horasFabricacion.Add(totalTiempoMuerto);
                    LblHrsProduccion.Text = "Tiempo de fabricación: " + horasFabricacion.Days + " días " + horasFabricacion.Hours + " hrs " + horasFabricacion.Minutes + " minutos";
                    LblTotalProduccion.Text = "Tiempo total: " + totalProduccion.Days + " días " + totalProduccion.Hours + " hrs " + totalProduccion.Minutes + " minutos";
                }
                else
                {
                    LblFechaInicio.Text = "Hora inicio: ";
                    LblTiempoMuerto.Text = "Tiempo muerto: ";
                    LblHrsProduccion.Text = "Tiempo de fabricación:";
                    LblTotalProduccion.Text = "Tiempo total: ";
                }

                CargarTiempoMuerto(idProceso);
                BkgDescargarPlano.RunWorkerAsync(planoProceso.Fila().Celda("plano"));
            }
        }

        private void CargarTiempoMuerto(int idProceso)
        {
            DgvTiempoMuerto.Rows.Clear();
            TimeSpan tiempoMuerto = TimeSpan.Parse("00:00:00");
            TiempoMuerto tiempoMuertoTbl = new TiempoMuerto();
            tiempoMuertoTbl.CargarTiempoMuerto(idProceso).ForEach(delegate(Fila f)
            {
                RazonTiempoMuerto razonTiempoMurto = new RazonTiempoMuerto();
                razonTiempoMurto.CargarDatos(Convert.ToInt32(f.Celda("razon")));
                if (razonTiempoMurto.TieneFilas())
                {
                    //Si la razón del tiempo extra no coincide con la hora de comida ni el baÑo
                    //1) Se calcula directamente el tiempo de finalización de la actividad menos el tiempo de inicio
                    if (razonTiempoMurto.Fila().Celda("razon").ToString() != "HORA DE COMIDA" && razonTiempoMurto.Fila().Celda("razon").ToString() != "BAÑO")
                    {
                        //Calculamos el tiempo de finalización
                        DateTime fin;
                        if (Global.ObjetoATexto(f.Celda("fin"), "N/A") != "N/A")
                        {
                            fin = Convert.ToDateTime(f.Celda("fin"));
                            TimeSpan diferencia = fin - Convert.ToDateTime(f.Celda("inicio").ToString());

                            DgvTiempoMuerto.Rows.Add(f.Celda("id"),
                                                     Convert.ToDateTime(f.Celda("inicio")).ToString("MMM dd, yyyy hh:mm"),
                                                     fin.ToString("MMM dd, yyyy hh:mm"),
                                                     razonTiempoMurto.Fila().Celda("razon").ToString(),
                                                     diferencia.Days + " días " + diferencia.Hours + " horas " + diferencia.Minutes + " minutos"); //tiempoTotal
                        }
                        else
                        {
                            DgvTiempoMuerto.Rows.Add(f.Celda("id"),
                                                     Convert.ToDateTime(f.Celda("inicio")).ToString("MMM dd, yyyy hh:mm"),
                                                     "N/A",
                                                     razonTiempoMurto.Fila().Celda("razon").ToString(),
                                                     "N/A");
                        }
                    }
                    //Si la razón del tiempo extra coincide con la hora de comida ni el baÑo
                    //1) Se calcula directamente el tiempo de finalización de la actividad menos el tiempo de inicio menos 10 minutos
                    // Sólo se muestra si es mayor a 10 minutos
                    else if (razonTiempoMurto.Fila().Celda("razon").ToString() == "BAÑO" || razonTiempoMurto.Fila().Celda("razon").ToString() == "HORA DE COMIDA")
                    {
                        //Calculamos el tiempo de finalización
                        DateTime fin;
                        TimeSpan tiempo = TimeSpan.Parse("00:00:00");

                        if (razonTiempoMurto.Fila().Celda("razon").ToString() == "BAÑO")
                            tiempo = TimeSpan.Parse("00:10:00");
                        else
                            tiempo = TimeSpan.Parse("01:0:00");

                        if (Global.ObjetoATexto(f.Celda("fin"), "N/A") != "N/A")
                        { 
                            fin = Convert.ToDateTime(f.Celda("fin"));
                            //else
                              //  fin = DateTime.Now;

                            TimeSpan diferencia = fin - Convert.ToDateTime(f.Celda("inicio").ToString());

                            //se valida que sea mayor a 10 minutos en baño
                            //se valida que sea mayor a 1 hra en hora de comida
                            //Sí lo es se muestra el tiempo muerto a partir de 10 minutos
                            //Sí no, no se muestra el tiempo muerto
                            if (tiempo < diferencia) //if (TimeSpan.Parse("00:10:00") < diferencia)
                            {
                                TimeSpan tiempoMuertoBanio = diferencia - tiempo;//TimeSpan.Parse("00:10:00");


                                DgvTiempoMuerto.Rows.Add(f.Celda("id"),
                                                         Convert.ToDateTime(f.Celda("inicio")).ToString("MMM dd, yyyy hh:mm"),
                                                         fin.ToString("MMM dd, yyyy hh:mm"),
                                                         razonTiempoMurto.Fila().Celda("razon").ToString(),
                                                         tiempoMuertoBanio.Days + " días " + tiempoMuertoBanio.Hours + " horas " + tiempoMuertoBanio.Minutes + " minutos");
                            }
                        }
                        else
                        {
                            DgvTiempoMuerto.Rows.Add(f.Celda("id"),
                                                        Convert.ToDateTime(f.Celda("inicio")).ToString("MMM dd, yyyy hh:mm"),
                                                        "N/A",
                                                        razonTiempoMurto.Fila().Celda("razon").ToString(),
                                                        "N/A");
                        }
                    }
                }
            });

            if (DgvTiempoMuerto.Rows.Count > 0)
                DgvTiempoMuerto.ClearSelection();
        }

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ClienteFtp == null || !ClienteFtp.IsConnected)
            {
                 if (Global.TipoConexion == "LOCAL")
                     ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                 else
                     ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

                 ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                                Global.UsuarioActual.Fila().Celda("password").ToString());

                 // Verificar conexion con servidor FTP
                 try
                 {
                     ClienteFtp.Connect();
                     BkgDescargarPlano.ReportProgress(40, "Conectando con servidor FTP... [OK]");

                 }
                 catch //(Exception ex)
                 {
                     BkgDescargarPlano.ReportProgress(100, "Error de conexión con servidor FTP");
                     return;
                 }                
            }

            //BkgDescargarPlano.ReportProgress(50, "Descargando imagen...");

            int idPlano = Convert.ToInt32(e.Argument);
            PlanoProyecto planoProyecto = new PlanoProyecto();
            planoProyecto.CargarDatos(idPlano);

            if (planoProyecto.TieneFilas())
            {
                //crear ruta a partir del proyecto y subensamble

                RutaParcialSinExtension = Path.ChangeExtension(planoProyecto.Fila().Celda("nombre_archivo").ToString(), null);
                Proyecto = Convert.ToDecimal(planoProyecto.Fila().Celda("proyecto"));
                Subensamble = planoProyecto.Fila().Celda("subensamble").ToString();

                BkgDescargarPlano.ReportProgress(60, "Descargando imagen...");
            }

            string strProyecto = Proyecto.ToString("F2").PadLeft(6, '0').Replace(".", "_");
            
            RaizFtp = strProyecto + "/M" + strProyecto + "/";
            BkgDescargarPlano.ReportProgress(80, "Procesando imagen...");

            // Si existe el archivo cache de la imagen, lo descargamos para mostrarlo en el picturebox
            // En caso contrario:
            //    - convertimos a pdf
            //    - convertimos a imagen
            //    - convertimos a imagen miniatura
            // Luego enviamos los archivos a la carpeta ftp

            //string[] subensamble = RutaParcialSinExtension.Split('-');

            if (ClienteFtp.FileExists(RaizFtp + Convert.ToInt32(Subensamble).ToString().PadLeft(2,'0') + "\\CP\\" + idPlano + " " + RutaParcialSinExtension + ".PNG"))
            {
                BkgDescargarPlano.ReportProgress(80, "Descargando imagen...");
                PlanoImagen = null;

                ClienteFtp.Download(out PlanoImagen, RaizFtp + Convert.ToInt32(Subensamble).ToString().PadLeft(2, '0') + "\\CP\\" + idPlano + " " + RutaParcialSinExtension + ".PNG");

                PlanoDescargado = true;
                BkgDescargarPlano.ReportProgress(100, "Procesando imagen");
            }
            else
            {
                ArchivoPlano archivo = new ArchivoPlano();
                archivo.SeleccionarDePlano(Convert.ToInt32(e.Argument));
                if (archivo.TieneFilas())
                {
                    PlanoDescargado = true;
                    PlanoImagen = (byte[])archivo.Fila().Celda("archivo");

                    BkgDescargarPlano.ReportProgress(100, "Procesando imagen");
                }
                else
                {
                    BkgDescargarPlano.ReportProgress(100, "Error al descargar la imagen");
                    PlanoImagen = null;
                    PlanoDescargado = false;
                }
            }
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatusProgreso.Text = (e.UserState.ToString());
            LblEstatusProgreso.Refresh();
            Progreso.Value = e.ProgressPercentage;
            Progreso.Refresh();
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PlanoDescargado)
            {
                if (PlanoImagen == null)
                {
                    PicPlano.Image = CB_Base.Properties.Resources.downloadPdf_gray;
                }
                else
                {
                    if (ImagenValida(PlanoImagen))
                    {
                        MemoryStream ms = new MemoryStream(PlanoImagen);
                        Image img = Image.FromStream(ms);
                        PicPlano.Image = img;
                    }
                    else
                    {
                        PicPlano.Image = CB_Base.Properties.Resources.image_not_found;
                        MessageBox.Show("No fue posible cargar la el plano", "Error al obtener la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                Progreso.Visible = false;
                LblEstatusProgreso.Text = "Imagen procesada correctamente";
                HabilitarBotones(IdProceso);
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
            }
            else
            {
                string msg = "Ocurrió un error al descargar la imagen.";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CmbProcesos.Enabled = true;
            TxtEscanearPlano.Enabled = true;            
            ActiveControl = TxtEscanearPlano;
            TxtEscanearPlano.Focus();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            PlanoProceso planoProceso = new PlanoProceso();
            planoProceso.CargarDatos(IdProceso);
            if (planoProceso.TieneFilas())
            {
                string mensaje = string.Empty;
                string titulo = string.Empty;

                if (planoProceso.Fila().Celda("estatus").ToString() == "ASIGNADO")
                {
                    mensaje = "¿Está seguro de iniciar el proceso?";
                    titulo = "Iniciar proceso";
                }
                else if(planoProceso.Fila().Celda("estatus").ToString() == "DETENIDO")
                {
                    mensaje = "¿Está seguro de continuar con el proceso?";
                    titulo = "Continuar proceso";
                }

                DialogResult result = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == System.Windows.Forms.DialogResult.Yes)
                {
                    //Si el estatus del proceso está como "Asignado" 
                    //1) Tiene proceso anterior: Debe terminar primero el proceso anterior
                    //2) Es el proceso 0: Pasa inmediatamente a EN PROCESO
                    //3) Proceso detenido: ya había sido iniciado y cambió a DETENIDO
                    //4) Cambia ocupacion del usuario
                    Usuario usuario = new Usuario();
                    usuario.CargarDatos(IdHerramentista);
                    if (!usuario.TieneFilas())
                        return;

                    if (planoProceso.Fila().Celda("estatus").ToString() == "ASIGNADO")
                    {
                        PlanoProceso procesoAnterior = new PlanoProceso();
                        procesoAnterior.CargarDatos(Convert.ToInt32(planoProceso.Fila().Celda("proceso_anterior")));
                         
                        //Deshabilitado para trabajar piezas en paralelo
                        /*if (planoProceso.Fila().Celda("proceso").ToString() == "PROGRAMACION CAM")
                        {
                            planoProceso.Fila().ModificarCelda("estatus", "EN PROCESO");
                            planoProceso.Fila().ModificarCelda("fecha_inicio", DateTime.Now);
                            planoProceso.GuardarDatos();
                            LblEstatus.Text = "EN PROCESO";
                            MessageBox.Show("Proceso iniciado");
                        }
                        else if(procesoAnterior.TieneFilas())
                        {
                            //Tiene un proceso anterior, validamos que el proceso anterior tenga estatus TERMINADO
                            //Si el proceso es 'PROGRAMACION CAM'  permite continuar el proceso normalmente
                            if (procesoAnterior.Fila().Celda("estatus").ToString() == "TERMINADO" || procesoAnterior.Fila().Celda("proceso").ToString() == "PROGRAMACION CAM")
                            {
                                planoProceso.Fila().ModificarCelda("estatus", "EN PROCESO");
                                planoProceso.Fila().ModificarCelda("fecha_inicio", DateTime.Now);
                                planoProceso.GuardarDatos();
                                LblEstatus.Text = "EN PROCESO";
                                MessageBox.Show("Proceso iniciado");
                            }
                            else
                            {
                                MessageBox.Show("El proceso anterior " + procesoAnterior.Fila().Celda("id") + 
                                                " - " + procesoAnterior.Fila().Celda("proceso") + 
                                                " asignado a " + Global.ObjetoATexto(procesoAnterior.Fila().Celda("operador"), "N/A") + 
                                                " no ha sido finalizado");
                                return;
                            }
                        }
                        else
                        {
                            //Es el proceso 0: Pasa inmediatamente a EN PROCESO
                            planoProceso.Fila().ModificarCelda("estatus", "EN PROCESO");
                            planoProceso.Fila().ModificarCelda("fecha_inicio", DateTime.Now);
                            planoProceso.GuardarDatos();
                          
                            usuario.Fila().ModificarCelda("estatus_ocupacion", "OCUPADO");
                            usuario.GuardarDatos();

                            Fila insertarOcupacion = new Fila();
                            insertarOcupacion.AgregarCelda("usuario", IdHerramentista);
                            insertarOcupacion.AgregarCelda("fecha_ocupacion", DateTime.Now);
                            OcupacinUsuario.Modelo().Insertar(insertarOcupacion);

                            PlanoProyecto planoProyecto = new PlanoProyecto();
                            planoProyecto.CargarDatos(Convert.ToInt32(planoProceso.Fila().Celda("plano")));
                            if(planoProyecto.TieneFilas())
                            {
                                planoProyecto.Fila().ModificarCelda("estatus", "EN FABRICACION");
                                planoProyecto.GuardarDatos();
                            }
                            LblEstatus.Text = "EN PROCESO";
                            MessageBox.Show("Proceso iniciado");
                        }*/

                        ////Borrar cuando se habilite el código nuevamente
                        planoProceso.Fila().ModificarCelda("estatus", "EN PROCESO");
                        planoProceso.Fila().ModificarCelda("fecha_inicio", DateTime.Now);
                        planoProceso.GuardarDatos();

                        if (usuario.Fila().Celda("estatus_ocupacion").ToString() == "DESOCUPADO")
                        {
                            usuario.Fila().ModificarCelda("estatus_ocupacion", "OCUPADO");
                            Fila insertarOcupacion = new Fila();
                            insertarOcupacion.AgregarCelda("usuario", IdHerramentista);
                            insertarOcupacion.AgregarCelda("fecha_ocupacion", DateTime.Now);
                            OcupacionUsuario.Modelo().Insertar(insertarOcupacion);
                        }

                        usuario.GuardarDatos();

                        PlanoProyecto planoProyecto = new PlanoProyecto();
                        planoProyecto.CargarDatos(Convert.ToInt32(planoProceso.Fila().Celda("plano")));
                        if (planoProyecto.TieneFilas())
                        {
                            if(planoProyecto.Fila().Celda("estatus") != "EN FABRICACION")
                            { 
                                planoProyecto.Fila().ModificarCelda("estatus", "EN FABRICACION");
                                planoProyecto.GuardarDatos();
                            }
                        }
                        
                        LblEstatus.Text = "EN PROCESO";
                        MessageBox.Show("Proceso iniciado");
                        ////

                        //Creamos el registro de los tiempos
                        Fila insertarTiempoFabricacion = new Fila();
                        insertarTiempoFabricacion.AgregarCelda("proceso", IdProceso);
                        insertarTiempoFabricacion.AgregarCelda("fecha_inicio", DateTime.Now);
                        TiempoFabricacion.Modelo().Insertar(insertarTiempoFabricacion);
                        SeleccionarProceso();
                        EstatusProceso = "EN PROCESO";
                        RefrescarComboBox();
                    }
                    //El proceso fue detenido por el operador, ahora recupera el estatus de EN PROCESO
                    else if (planoProceso.Fila().Celda("estatus").ToString() == "DETENIDO")
                    {
                        planoProceso.Fila().ModificarCelda("estatus", "EN PROCESO");
                        planoProceso.GuardarDatos();

                        if (usuario.Fila().Celda("estatus_ocupacion").ToString() == "DESOCUPADO")
                        {
                            Fila insertarOcupacion = new Fila();
                            insertarOcupacion.AgregarCelda("usuario", IdHerramentista);
                            insertarOcupacion.AgregarCelda("fecha_ocupacion", DateTime.Now);
                            OcupacionUsuario.Modelo().Insertar(insertarOcupacion);

                            usuario.Fila().ModificarCelda("estatus_ocupacion", "OCUPADO");
                            usuario.GuardarDatos();
                        }

                        TiempoMuerto tiempoMuerto = new TiempoMuerto();
                        tiempoMuerto.CambiarEstadoTiempoMuerto(IdProceso);
                        if (tiempoMuerto.TieneFilas())
                        {
                            tiempoMuerto.Fila().ModificarCelda("estatus", "INACTIVO");
                            tiempoMuerto.Fila().ModificarCelda("fin", DateTime.Now);
                            tiempoMuerto.GuardarDatos();
                        }
                        LblEstatus.Text = "EN PROCESO";

                        //Creamos el registro de los tiempos
                        Fila insertarTiempoFabricacion = new Fila();
                        insertarTiempoFabricacion.AgregarCelda("proceso", IdProceso);
                        insertarTiempoFabricacion.AgregarCelda("fecha_inicio", DateTime.Now);
                        TiempoFabricacion.Modelo().Insertar(insertarTiempoFabricacion);
                        SeleccionarProceso();
                        EstatusProceso = "EN PROCESO";
                        RefrescarComboBox();
                    }
                }
            }
            PonerFocoEscaneo();
        }

        private void BtnDetener_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.CargarDatos(IdHerramentista);
            if (!usuario.TieneFilas())
                return;

            FrmDetenerProcesoFabricacion razon = new FrmDetenerProcesoFabricacion();
            if (razon.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PlanoProceso planoProceso = new PlanoProceso();
                planoProceso.CargarDatos(IdProceso);
                if (planoProceso.TieneFilas())
                {
                    if (planoProceso.Fila().Celda("estatus").ToString() == "EN PROCESO")
                    {
                        planoProceso.Fila().ModificarCelda("estatus", "DETENIDO");
                        planoProceso.GuardarDatos();

                        Fila insertarTiempoMuerto = new Fila();
                        insertarTiempoMuerto.AgregarCelda("proceso", IdProceso);
                        insertarTiempoMuerto.AgregarCelda("razon", razon.Razon.Split('-')[0].TrimEnd());
                        insertarTiempoMuerto.AgregarCelda("usuario", IdHerramentista);
                        insertarTiempoMuerto.AgregarCelda("inicio", DateTime.Now);
                        insertarTiempoMuerto.AgregarCelda("estatus", "ACTIVO");
                        TiempoMuerto.Modelo().Insertar(insertarTiempoMuerto);

                        TiempoFabricacion tiempoFabricacion = new TiempoFabricacion();
                        tiempoFabricacion.CargarFechaParo(IdProceso);
                        if (tiempoFabricacion.TieneFilas())
                        {
                            tiempoFabricacion.Fila().ModificarCelda("fecha_paro", DateTime.Now);
                            tiempoFabricacion.GuardarDatos();
                        }

                        if (usuario.Fila().Celda("estatus_ocupacion").ToString() == "OCUPADO")
                        {
                            OcupacionUsuario ocupacion = new OcupacionUsuario();
                            ocupacion.SeleccionarDatos(IdHerramentista);
                            if (ocupacion.TieneFilas())
                            {
                                usuario.Fila().ModificarCelda("estatus_ocupacion", "DESOCUPADO");
                                usuario.GuardarDatos();

                                ocupacion.Fila().ModificarCelda("fecha_desocupado", DateTime.Now);
                                ocupacion.GuardarDatos();
                            }
                        }

                        LblEstatus.Text = "DETENIDO";
                        SeleccionarProceso();
                        EstatusProceso = "DETENIDO";
                        RefrescarComboBox();
                    }
                }
            }
            else
                PonerFocoEscaneo();
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.CargarDatos(IdHerramentista);
            if (!usuario.TieneFilas())
                return;

            DialogResult result = MessageBox.Show("¿Está seguro que desea terminar el proceso?", "Terminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProceso planoProceso = new PlanoProceso();
                bool incumplimientoSistema = false;
                int idIncumplimiento = 0;
                string mensaje = string.Empty;
                
                planoProceso.CargarDatos(IdProceso);
                if (planoProceso.TieneFilas())
                {
                    TimeSpan horasFabricacion = TimeSpan.Parse("00:00:00");
                    TiempoFabricacion tiempoFabricacion = new TiempoFabricacion();

                    foreach(Fila f in tiempoFabricacion.CargarTiempoFabricacion(IdProceso))
                    {
                        TimeSpan tiempoTranscurrido = DateTime.Now - Convert.ToDateTime(planoProceso.Fila().Celda("fecha_inicio"));
                        DateTime fechaInicio = Convert.ToDateTime(f.Celda("fecha_inicio").ToString());
                        DateTime fechaParo;
                        double tiempoTotal = (tiempoTranscurrido.TotalHours * 100) / Convert.ToDouble(planoProceso.Fila().Celda("tiempo_trabajo_estimado"));

                        if (Global.ObjetoATexto(f.Celda("fecha_paro"), "N/A") != "N/A")
                            fechaParo = Convert.ToDateTime(f.Celda("fecha_paro").ToString());
                        else
                            fechaParo = DateTime.Now;

                        // SC. 3/31/2019 *******
                        // Si la fecha de paro es mayor que la fecha de inicio entonces el usuario cometio un
                        // incumplimiento al no detener el proceso cuando finalizo el turno el dia anterior
                        if (fechaParo.Date > fechaInicio.Date) //|| incumplimientoSistema
                        {
                            incumplimientoSistema = true;
                            idIncumplimiento = (int)Incumplimiento.Sin_Cerrar + 1;
                            f.ModificarCelda("fecha_paro", fechaParo);
                            mensaje = "INCUMPLIMIENTO OCURRIDO EN EL PROCESO " + f.Celda("proceso").ToString() + " " + planoProceso.Fila().Celda("proceso").ToString() + " CON FECHA DE " + fechaInicio.Date.ToString("MMM dd, yyyy");
                            break;
                        }
                        else if (tiempoTotal < 40)
                        {
                            incumplimientoSistema = true;
                            idIncumplimiento = (int)Incumplimiento.No_Inicializado + 1;
                            f.ModificarCelda("fecha_paro", fechaParo);
                            mensaje = "INCUMPLIMIENTO OCURRIDO EN EL PROCESO: " + f.Celda("proceso").ToString() + " " + planoProceso.Fila().Celda("proceso").ToString() + " CON FECHA DE " + fechaInicio.Date.ToString("MMM dd, yyyy");
                            break;
                        }
                        else
                        {
                            TimeSpan diferenciaHoras = fechaParo - fechaInicio;
                            horasFabricacion = horasFabricacion.Add(diferenciaHoras);
                            f.ModificarCelda("fecha_paro", fechaParo);
                        }
                        //=================================================
                    }

                    tiempoFabricacion.GuardarDatos(); // SC. 

                    // Tiene un incumplimiento al no cerrar una operación, no se realizan cálculos
                    if (incumplimientoSistema)
                    {
                        string proceso = planoProceso.Fila().Celda("proceso").ToString();                                              
                        GenerarIncumplimiento(IdProceso, proceso, idIncumplimiento, mensaje);

                        // poner en ceros los tiempos del proceso
                        planoProceso.Fila().ModificarCelda("tiempo_trabajo_real", 0.00);
                        planoProceso.Fila().ModificarCelda("tiempo_muerto", 0.00);
                        planoProceso.Fila().ModificarCelda("estatus", "TERMINADO");
                        planoProceso.Fila().ModificarCelda("fecha_termino", DateTime.Now);
                        planoProceso.GuardarDatos();

                    }
                    else  // No tiene incumplimiento, se hace el cálculo de los costos
                    {
                        TimeSpan totalTiempoMuerto = CalcularTiempoMuerto(IdProceso);

                        // Calcular costo real fabricacion = tiempoTrabajoReal * sueldoHrDelHerramentistaAsignado
                        Sueldo sueldo = new Sueldo();
                        decimal sueldoHora = 0;

                        sueldo.BuscarSueldo(IdHerramentista);
                        if (sueldo.TieneFilas())
                            sueldoHora = Convert.ToDecimal(sueldo.Fila().Celda("sueldo_hora"));

                        // tiempoTrabajoReal está expresado en horas totales en decimal ej 0.10219117997222221
                        // para calcular las hrs = 0.10219117997222221 * hrs de trabajo del herramentista asignado
                        double CostoRealFabricacion = Convert.ToDouble(horasFabricacion.TotalHours) * Convert.ToDouble(sueldoHora);
                        planoProceso.Fila().ModificarCelda("estatus", "TERMINADO");
                        planoProceso.Fila().ModificarCelda("fecha_termino", DateTime.Now);
                        planoProceso.Fila().ModificarCelda("tiempo_trabajo_real", horasFabricacion.TotalHours);
                        planoProceso.Fila().ModificarCelda("tiempo_muerto", totalTiempoMuerto.TotalHours);
                        planoProceso.Fila().ModificarCelda("costo_real_fabricacion", CostoRealFabricacion.ToString("F2"));
                        planoProceso.GuardarDatos();
                    }

                   /* TiempoFabricacion tiempoFabricacion = new TiempoFabricacion();
                    tiempoFabricacion.CargarFechaParo(IdProceso);
                    if (tiempoFabricacion.TieneFilas())
                    {
                        tiempoFabricacion.Fila().ModificarCelda("fecha_paro", DateTime.Now);
                        tiempoFabricacion.GuardarDatos();
                    }*/

                    PlanoProceso proc = new PlanoProceso();
                    proc.SeleccionarProcesosEnCursoDeUnHerramentista(IdHerramentista);
                    if (!proc.TieneFilas())
                    {
                        OcupacionUsuario ocupacion = new OcupacionUsuario();
                        ocupacion.SeleccionarDatos(IdHerramentista);
                        if (ocupacion.TieneFilas())
                        {
                            usuario.Fila().ModificarCelda("estatus_ocupacion", "DESOCUPADO");
                            usuario.GuardarDatos();

                            ocupacion.Fila().ModificarCelda("fecha_desocupado", DateTime.Now);
                            ocupacion.GuardarDatos();
                        }
                    }

                    LblEstatus.Text = "TERMINADO";
                    splitContainer1.Panel2Collapsed = true;
                    splitContainer1.Panel2.Hide();
                    DgvTiempoMuerto.Rows.Clear();
                    PicPlano.Image = null;
                    CargarProcesos();

                    if (CmbProcesos.Items.Count == 0)
                    {
                        MessageBox.Show("No tiene planos asignados", "Sin planos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                }
            }
            else
                PonerFocoEscaneo();
        }

        private void GenerarIncumplimiento(int idProceso, string nombreProceso, int idIncumplimiento, string mensaje)
        {
            int idUsuarioActual = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));

            // CANCELAMOS EL EVENTO DEL TICK
            TimerOpciones.Tick -= new EventHandler(TimerOpciones_Tick);

            // MOSTRAR EL FORM DE INCUMPLIMIENTO 
            FrmIncumplimientoProceso incumplimiento = new FrmIncumplimientoProceso(nombreProceso, idUsuarioActual, idIncumplimiento, mensaje);
            if (incumplimiento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // REGISTRAR EL INCUMPLIMIENTO
                Fila insertarIncumplimineto = new Fila();
                insertarIncumplimineto.AgregarCelda("lista_incumplimiento", idIncumplimiento);
                insertarIncumplimineto.AgregarCelda("proceso", 1);
                insertarIncumplimineto.AgregarCelda("fecha_creacion", DateTime.Now);
                insertarIncumplimineto.AgregarCelda("usuario_creacion", IdHerramentista);
                insertarIncumplimineto.AgregarCelda("mensaje_incumplimiento", incumplimiento.Mensaje);
                insertarIncumplimineto.AgregarCelda("id_entregable", idProceso);
                insertarIncumplimineto.AgregarCelda("tipo_entregable", "PROCESO DE FABRICACION");
                IncumplimientoProceso.Modelo().Insertar(insertarIncumplimineto);
                TimerOpciones.Tick += new EventHandler(TimerOpciones_Tick);
            }

            // HABILITAMOS EL EVENTO DEL TICK
            TimerOpciones.Tick += new EventHandler(TimerOpciones_Tick);
        }

        private TimeSpan CalcularTiempoMuerto(int idProceso)
        {
            TimeSpan totalTiempoMuerto = TimeSpan.Parse("00:00:00");
            TiempoMuerto tiempoMuerto = new TiempoMuerto();
            tiempoMuerto.CalcularTiempoMuerto(idProceso).ForEach(delegate(Fila f)
            {
                string tiempoMuertoFin = string.Empty;
                string tiempoMuertoInicio = f.Celda("inicio").ToString();

                if (Global.ObjetoATexto(f.Celda("fin"), "N/A") != "N/A")
                    tiempoMuertoFin = f.Celda("fin").ToString();
                else
                    tiempoMuertoFin = DateTime.Now.ToString();

                TimeSpan diferenciaTiempoMuerto = Convert.ToDateTime(tiempoMuertoFin) - Convert.ToDateTime(tiempoMuertoInicio);
                totalTiempoMuerto = totalTiempoMuerto + diferenciaTiempoMuerto;
            });

            return totalTiempoMuerto;
        }


        private void TimerOpciones_Tick(object sender, EventArgs e)
        {                
            RefrescarContador--;
            if (RefrescarContador == 0)
            {
                TimerOpciones.Stop();
                TimerOpciones.Tick -= TimerOpciones_Tick;
                TimerOpciones.Dispose();
                TimerOpciones = null;
                this.Dispose();  

                FrmDetenerProcesoFabricacion seleccionarRazon = (FrmDetenerProcesoFabricacion)Application.OpenForms["FrmSeleccionarRazon"];
                if (seleccionarRazon != null)
                {
                    if (seleccionarRazon.Visible)
                        seleccionarRazon.Close();
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
                if (RefrescarContador < 11)
                {
                    if (!lblTimer.Visible)
                        lblTimer.Visible = true;

                    TimeSpan t = TimeSpan.FromSeconds(RefrescarContador);
                    lblTimer.Text = t.ToString(@"mm\:ss") + " tiempo restante para cerrar automáticamente la ventana";
                }
            }
        }

        private void FrmOpcionesProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmDetenerProcesoFabricacion razon = (FrmDetenerProcesoFabricacion)Application.OpenForms["FrmSeleccionarRazon"];
            if (razon != null)
                razon.Close();

            CmbProcesos.Items.Clear();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
            {
                ActiveControl = TxtEscanearPlano;
                TxtEscanearPlano.Focus();
            }
        }

        private void CmbProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!BkgDescargarPlano.IsBusy)
                SeleccionarProceso();

            ReiniciarContador();
        }

        private void SeleccionarProceso()
        {
            if (CmbProcesos.Text == "")
                return;

            BtnIniciar.Enabled = false;
            BtnDetener.Enabled = false;
            BtnTerminar.Enabled = false;
            BtnSalir.Enabled = false;
            Progreso.Value = 0;
            Progreso.Visible = true;
            PicPlano.Image = null;
            CmbProcesos.Enabled = false;
            TxtEscanearPlano.Enabled = false;
            LblEstatusProgreso.Text = "";
            DgvTiempoMuerto.Rows.Clear();

            IdProceso = Convert.ToInt32(CmbProcesos.Text.Split('|')[1].Split('-')[0].Trim());
            CargarProceso(IdProceso);
        }

        private void LblFechaInicio_MouseMove(object sender, MouseEventArgs e)
        {
            ReiniciarContador();
        }

        private void CmbProcesos_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            
        }

        private void TxtEscanear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtEscanearPlano.Text != "")
             {
                 if (TxtEscanearPlano.Text != ProcesoEscanado && TxtEscanearPlano.Text != "")
                 {
                     ProcesoEscanado = TxtEscanearPlano.Text;
                     Index = 0;
                 }

                 int plano = Convert.ToInt32(TxtEscanearPlano.Text);
                 TxtEscanearPlano.Text = string.Empty;

                //verificamos que la lista de procesos contenga por lo menos un id del plano escaneado
                 List<Tuple<int, int>> ProcesosEnLista = ListaDeProcesos.FindAll(item => item.Item2 == plano);

                 if (ProcesosEnLista.Count > 0)
                 {
                     //obtenemos los últimos elementos de la lista
                     Tuple<int, int> ultimoProcesoEnLista = ProcesosEnLista.Last();

                     //si es el primer escaneo el indice de CmbProcesos será -1                   
                     if (Index < 0)
                     {
                         //Buscamos y seleccionamos la primer ocurrencia 
                         //se agarra el valor del índice y se iguala el CmbProcesos a ese índice
                         Tuple<int, int> item = ListaDeProcesos.Find(elemento => elemento.Item2 == plano);
                         Index = item.Item1;
                         CmbProcesos.SelectedIndex = Index;
                     }
                     else
                     {
                         //Si anteriormente se había escaneado se busca el siguiente elemente
                         // con el index + 1 y se agarra elvalor del índice
                         //En caso que el valor del índice sea mayor a l cantidad de elementos se regresa el valor a 0                        
                         if (Index == ultimoProcesoEnLista.Item1)//ProcesosEnLista.Count - 1)//CmbProcesos.Items.Count - 1)
                         {
                             var item = ListaDeProcesos.Find(elemento => elemento.Item2 == plano);
                             Index = item.Item1;
                         }
                         else
                             Index = ListaDeProcesos.FindIndex(Index + 1, elemento => elemento.Item2 == plano);

                         CmbProcesos.SelectedIndex = Index;
                     }
                 }
                 else
                     MessageBox.Show("No se encontró ningún proceso asignado al plano " + plano.ToString() + ", verifique con el supervisor.", "Proceso no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            ReiniciarContador();
        }

        private void TxtEscanearPlano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && TxtEscanearPlano.Text != "0")
                e.Handled = true;
        }

        private void TxtEscanearPlano_TextChanged(object sender, EventArgs e)
        {
           /* if(TxtEscanearPlano.Text != ProcesoEscanado && TxtEscanearPlano.Text != "")
            {
                ProcesoEscanado = TxtEscanearPlano.Text;
                Index = 0;
            }*/
        }

        private void DgvTiempoMuerto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActiveControl = TxtEscanearPlano;
            TxtEscanearPlano.Focus();
            ReiniciarContador();
        }

        public static bool ImagenValida(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void CmbProcesos_MouseLeave(object sender, EventArgs e)
        {
            PonerFocoEscaneo();
        }

        private void CmbProcesos_DropDownClosed(object sender, EventArgs e)
        {
            PonerFocoEscaneo();
        }

        void PonerFocoEscaneo()
        {
            this.ActiveControl = TxtEscanearPlano;
            TxtEscanearPlano.Focus();
        }

        private void CmbProcesos_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                e.DrawFocusRectangle();

                if (e.Index > -1)
                {
                    Bitmap imagenItem;
                    int indiceSeparador = CmbProcesos.Items[e.Index].ToString().LastIndexOf('|');
                    string estatus = CmbProcesos.Items[e.Index].ToString().Split('|').Last();
                    string CmbTexto = CmbProcesos.Items[e.Index].ToString();
                    int espaciosABorrar = CmbTexto.Length - indiceSeparador;
                    string CmbNuevoTexto = CmbTexto.Remove(indiceSeparador, espaciosABorrar);

                    // dibujar imagen a un lado del texto
                    if (estatus == "EN PROCESO")
                        imagenItem = new Bitmap(ListaImagenesEstatusProcesos.Images[0]);
                    else if (estatus == "DETENIDO")
                        imagenItem = new Bitmap(ListaImagenesEstatusProcesos.Images[1]);
                    else if (estatus == "ASIGNADO")
                        imagenItem = new Bitmap(ListaImagenesEstatusProcesos.Images[2]);
                    else
                        imagenItem = null;

                    if (imagenItem != null)
                    {
                        e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        e.Graphics.DrawImage(imagenItem, new PointF(e.Bounds.X, e.Bounds.Y + 8));
                    }

                    // Mostrar texto
                    e.Graphics.DrawString(CmbNuevoTexto, // texto a mostrar
                                            CmbProcesos.Font, //fuente
                                            System.Drawing.Brushes.Black, //color
                                            new RectangleF(e.Bounds.X + 30, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

                }
            }
            catch
            {
                //evitar error al cerrar form mientras que el cmb esté abierto
            }
        }

        private void ReiniciarContador()
        {
            RefrescarContador = IntervaloActualizar;

            if (lblTimer.Visible)
                lblTimer.Visible = false;
        }

        private void RefrescarComboBox()
        {
            string procesoSeleccionado = CmbProcesos.Text;
            int indiceSeparador = procesoSeleccionado.LastIndexOf('|');
            int caracteresABorrar = procesoSeleccionado.Length - indiceSeparador;

            CargarProcesos();
            int indexCmb = 0;

            if(EstatusProceso == "EN PROCESO")
                indexCmb = CmbProcesos.Items.IndexOf(procesoSeleccionado.Remove(indiceSeparador, caracteresABorrar) + "|EN PROCESO");
            if (EstatusProceso == "DETENIDO")
                indexCmb = CmbProcesos.Items.IndexOf(procesoSeleccionado.Remove(indiceSeparador, caracteresABorrar) + "|DETENIDO");

            CmbProcesos.SelectedIndex = indexCmb;
        }
    }
}
