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
using System.IO;

namespace CB
{
    public partial class FrmGenerarValeSalidaFabricacion : Ventana
    {
        List<int> IdPlanos = new List<int>();
        FtpClient ClienteFtp = new FtpClient();
        byte[] DatosValeSalida = null;
        bool ValeGuardado = false;
        bool ErrorFtp = false;
        int IdValeSalida = 0;

        public FrmGenerarValeSalidaFabricacion(List<int> idPlanos)
        {
            InitializeComponent();
            IdPlanos = idPlanos;
        }

        private void FrmGenerarValeSalidaFabricacion_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            TxtPersonaEntrega.Text = Global.UsuarioActual.NombreCompleto();

            Fila insertarValeSalida = new Fila();
            insertarValeSalida.AgregarCelda("tipo", "INSPECCION");
            insertarValeSalida.AgregarCelda("proveedor", "0");
            IdValeSalida = Convert.ToInt32(ValeSalida.Modelo().Insertar(insertarValeSalida).Celda("id"));

            BtnAceptar.Enabled = false;
            BtnImprimir.Enabled = false;
            CmbResponsable.SelectedIndex = 0;
        }

        private void CargarUsuarios()
        {
            CmbResponsable.Items.Clear();
            Usuario usuario = new Usuario();
            CmbResponsable.Items.Add("N/A");
            usuario.Calidad().ForEach(delegate(Fila f)
            {
                CmbResponsable.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });  
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea generar el vale de salida de piezas a inspección?", "Generar vale de salida de piezas a inspección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Progreso.Visible = true;

                for (int i = 0; i < IdPlanos.Count; i++)
                {
                    int id = IdPlanos[i];

                    PlanoProyecto proyecto = new PlanoProyecto();
                    proyecto.CargarDatos(id);

                    if (proyecto.TieneFilas())
                    {
                        proyecto.Fila().ModificarCelda("vale_salida_inspeccion", IdValeSalida);
                        proyecto.Fila().ModificarCelda("estatus", "EN INSPECCION");
                        proyecto.GuardarDatos();
                    }

                    Fila insertarValeSalidaItems = new Fila();
                    insertarValeSalidaItems.AgregarCelda("vale_salida", IdValeSalida);
                    ValeSalidaItem.Modelo().Insertar(insertarValeSalidaItems);
                }

                BkgGuardarVale.RunWorkerAsync();
                BtnAceptar.Enabled = false;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
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

                foreach (var id in IdPlanos)
                {
                    PlanoProyecto proyecto = new PlanoProyecto();
                    proyecto.CargarDatos(Convert.ToInt32(id));

                    if (proyecto.TieneFilas())
                    {
                        proyecto.Fila().ModificarCelda("vale_salida_inspeccion", 0);
                        proyecto.Fila().ModificarCelda("estatus", "FABRICADO");
                        proyecto.GuardarDatos();
                    }
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbResponsable.Text == "N/A")
                return;

            DatosValeSalida = FormatosPDF.BajaPlanoFabricacion(IdPlanos, CmbResponsable.Text.Split('-')[1].TrimStart(), "INSPECCION DE FABRICACION");
            if (DatosValeSalida != null)
            {
                Global.MostrarPDF(DatosValeSalida, "Vale de salida de piezas a tratamiento " + IdValeSalida.ToString().PadLeft(4, '0'), null, VisorPDF);
                BtnAceptar.Enabled = true;
                BtnImprimir.Enabled = true;
            }
            else
            {
                BtnAceptar.Enabled = false;
                BtnImprimir.Enabled = false;
            }
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
                MessageBox.Show("Entregue el vale " + IdValeSalida.ToString().PadLeft(4, '0') + " al área de calidad ", "Vale guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                Progreso.Visible = false;

                foreach (var id in IdPlanos)
                {
                    PlanoProyecto proyecto = new PlanoProyecto();
                    proyecto.CargarDatos(Convert.ToInt32(id));

                    if (proyecto.TieneFilas())
                    {
                        proyecto.Fila().ModificarCelda("vale_salida_inspeccion", 0);
                        proyecto.Fila().ModificarCelda("estatus", "FABRICADO");
                        proyecto.GuardarDatos();
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

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (DatosValeSalida == null)
            {
                MessageBox.Show("Favor de generar el documento pdf", "Generar documento pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Global.MostrarPDFWebBrowser(DatosValeSalida, "VALE_SALIDA_FABRICACION", "ENTREGAR_PIEZAS_CALIDAD");
        }

        private void FrmGenerarValeSalidaFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //BORRAR DESARGAS
            string pathDescargas = Directory.GetCurrentDirectory() + "//IMPRIMIR//VALE_SALIDA_FABRICACION";
            if (Directory.Exists(pathDescargas))
                Directory.Delete(pathDescargas, true);
        }
    }
}
