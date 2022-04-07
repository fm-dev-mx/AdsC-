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
using CB_Base.Classes;

namespace CB
{
    public partial class FrmGenerarValeSalidaPendienteTratamiento : Ventana
    {
        List<int> ListaDeProcesos = new List<int>();
        FtpClient ClienteFtp = new FtpClient();
        byte[] DatosValeSalida = null;
        bool ValeGuardado = false;
        bool ErrorFtp = false;
        int IdValeSalida = 0;

        public FrmGenerarValeSalidaPendienteTratamiento(List<int> idProcesos)
        {
            InitializeComponent();
            ListaDeProcesos = idProcesos;
        }

        private void FrmGenerarValeSalidaPendienteTratamiento_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            TxtPersonaEntrega.Text = Global.UsuarioActual.NombreCompleto();

            Fila insertarValeSalida = new Fila();
            insertarValeSalida.AgregarCelda("tipo", "TRATAMIENTO");
            insertarValeSalida.AgregarCelda("proveedor", IdValeSalida);

            IdValeSalida = Convert.ToInt32(ValeSalida.Modelo().Insertar(insertarValeSalida).Celda("id"));
            BtnAceptar.Enabled = false;
            CmbProveedor.SelectedIndex = 0;
        }

        private void CargarProveedores()
        {
            Proveedor proveedores = new Proveedor();

            CmbProveedor.Items.Add("N/A");
            proveedores.SeleccionarDatos("", null, "*").ForEach(delegate(Fila f)
            {
                CmbProveedor.Items.Add(f.Celda("id") + " - " + f.Celda("nombre"));
            });

            if (CmbProveedor.Items.Count > 0)
                CmbProveedor.SelectedIndex = 0;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los cambios que haya realizado no serán guardados, ¿Desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                ValeSalida borrarVale = new ValeSalida();
                borrarVale.CargarDatos(IdValeSalida);
                borrarVale.BorrarDatos(IdValeSalida);
                borrarVale.GuardarDatos();

                ValeSalidaItem borrarValeSalidaItem = new ValeSalidaItem();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@valeSalida", IdValeSalida);

                ValeSalidaItem.Modelo().SeleccionarDatos("vale_salida=@valeSalida").ForEach(delegate(Fila f)
                {
                    borrarValeSalidaItem.CargarDatos(Convert.ToInt32(f.Celda("id")));
                    borrarValeSalidaItem.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                    borrarValeSalidaItem.GuardarDatos();
                });

                foreach (var id in ListaDeProcesos)
                {
                    PlanoProceso proceso = new PlanoProceso();
                    proceso.CargarDatos(id);

                    if (proceso.TieneFilas())
                    {
                        PlanoProyecto proyecto = new PlanoProyecto();
                        proyecto.CargarDatos(Convert.ToInt32(proceso.Fila().Celda("plano")));

                        if (proyecto.TieneFilas())
                        {
                            proyecto.Fila().ModificarCelda("vale_salida_tratamiento", 0);
                            proyecto.Fila().ModificarCelda("estatus", "PENDIENTE DE TRATAMIENTO");
                            proyecto.GuardarDatos();
                        }
                    }
                }
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea generar el vale de salida de las piezas a tratamiento?", "Generar vale de salida de piezas a tratamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                Progreso.Visible = true;

                for (int i = 0; i < ListaDeProcesos.Count; i++)
                {
                    int id = ListaDeProcesos[i];
                    PlanoProceso proceso = new PlanoProceso();
                    proceso.CargarDatos(id);

                    if (proceso.TieneFilas())
                    {
                        proceso.Fila().ModificarCelda("estatus", "EN PROCESO");
                        proceso.GuardarDatos();

                        PlanoProyecto proyecto = new PlanoProyecto();
                        proyecto.CargarDatos(Convert.ToInt32(proceso.Fila().Celda("plano")));

                        if (proyecto.TieneFilas())
                        {
                            proyecto.Fila().ModificarCelda("vale_salida_tratamiento", IdValeSalida);
                            proyecto.Fila().ModificarCelda("estatus", "EN TRATAMIENTO");
                            proyecto.GuardarDatos();
                        }

                        Fila insertarValeSalidaItems = new Fila();
                        insertarValeSalidaItems.AgregarCelda("vale_salida", IdValeSalida);
                        insertarValeSalidaItems.AgregarCelda("proceso", id);
                        ValeSalidaItem.Modelo().Insertar(insertarValeSalidaItems);
                    }
                }

                BkgGuardarVale.RunWorkerAsync();

                BtnAceptar.Enabled = false;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProveedor.Text == "N/A")
                return;

            DatosValeSalida = FormatosPDF.ValeSalidaPiezasATratamiento(ListaDeProcesos, CmbProveedor.Text, IdValeSalida);
            if (DatosValeSalida != null)
            {
                Global.MostrarPDF(DatosValeSalida, "Vale de salida de piezas a tratamiento " + IdValeSalida.ToString().PadLeft(4, '0'), null, VisorPDF);
                BtnAceptar.Enabled = true;
            }
            else
                BtnAceptar.Enabled = false;
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BkgGuardarVale_DoWork(object sender, DoWorkEventArgs e)
        {
            ErrorFtp = false;
            BkgGuardarVale.ReportProgress(20, "Conectando con servidor FTP... ");

            if (!ClienteFtp.IsConnected)
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
                    BkgGuardarVale.ReportProgress(40, "Conectando con servidor FTP... [OK]");
                }
                catch
                {
                    BkgGuardarVale.ReportProgress(100, "Error de conexión con servidor FTP");
                    ErrorFtp = true;
                    return;
                }
            }
            BkgGuardarVale.ReportProgress(50, "Guardando vale de salida...");

            //Guardar documento en FTP
            //Verificamos si existe el directorio, sino lo creamos
            if (!ClienteFtp.DirectoryExists("SGC\\VALES_SALIDA"))
                ClienteFtp.CreateDirectory("SGC\\VALES_SALIDA");

            // enviar archivos a carpeta ftp
            ClienteFtp.Upload(DatosValeSalida, "SGC\\VALES_SALIDA\\" + IdValeSalida + ".pdf", FtpExists.Overwrite);
            ValeGuardado = true;
            BkgGuardarVale.ReportProgress(100, "Guardando vale de salida...[OK]");
        }

        private void BkgGuardarVale_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatus.Text = (e.UserState.ToString());
            Progreso.Value = e.ProgressPercentage;
            Progreso.Refresh();
        }

        private void BkgGuardarVale_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ValeGuardado)
            {
                MessageBox.Show("El vale de salida " + IdValeSalida.ToString().PadLeft(4, '0') + " ha sido guardado correctamente", "Vale guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                Progreso.Visible = false;

                foreach (var id in ListaDeProcesos)
                {
                    PlanoProceso proceso = new PlanoProceso();
                    proceso.CargarDatos(id);

                    if (proceso.TieneFilas())
                    {
                        PlanoProyecto proyecto = new PlanoProyecto();
                        proyecto.CargarDatos(Convert.ToInt32(proceso.Fila().Celda("plano")));

                        if (proyecto.TieneFilas())
                        {
                            proyecto.Fila().ModificarCelda("vale_salida_tratamiento", 0);
                            proyecto.Fila().ModificarCelda("estatus", "PENDIENTE DE TRATAMIENTO");
                            proyecto.GuardarDatos();
                        }
                    }
                }

                ValeSalidaItem borrarValeSalidaItem = new ValeSalidaItem();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@valeSalida", IdValeSalida);

                ValeSalidaItem.Modelo().SeleccionarDatos("vale_salida=@valeSalida", parametros).ForEach(delegate(Fila f)
                {
                    borrarValeSalidaItem.CargarDatos(Convert.ToInt32(f.Celda("id")));
                    borrarValeSalidaItem.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                    borrarValeSalidaItem.GuardarDatos();
                });

                if(ErrorFtp)
                    MessageBox.Show("Ha ocurrido un problema al momento de guardar el vale de salida " + IdValeSalida.ToString().PadLeft(4, '0') + ". Verifique su conexión y vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                BtnAceptar.Enabled = true;
            }
        }

    }
}
