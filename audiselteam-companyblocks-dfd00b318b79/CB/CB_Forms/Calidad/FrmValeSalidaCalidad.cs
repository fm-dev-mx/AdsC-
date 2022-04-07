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
    public partial class FrmValeSalidaCalidad : Ventana
    {
        PlanoProyecto plano = new PlanoProyecto();
        List<int> IdPlanos = new List<int>();
        FtpClient ClienteFtp = new FtpClient();
        byte[] Archivo = null;
        bool ValeGuardado = false;
        bool ErrorFtp = false;
        int IdValeSalida = 0;

        public FrmValeSalidaCalidad(List<int> idPlanos)
        {
            InitializeComponent();
            CargarUsuarios();
            IdPlanos = idPlanos;
        }

        public void CargarUsuarios()
        {
            CmbUsuarios.Items.Clear();
            Usuario.Modelo().RolActivo("TECNICO ELECTROMECANICO", "COMPRADOR", "LIDER DE PROYECTO", "COORDINADOR DE OPERACIONES", "RESPONSABLE DE ALMACEN").ForEach(delegate(Fila usuario)
            {
                CmbUsuarios.Items.Add(usuario.Celda("id").ToString() + " - " + usuario.Celda("nombre").ToString() + " " + usuario.Celda("paterno").ToString() );
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnEntregar_Click(object sender, EventArgs e)
        {
            //ValeSalidaPieza vale = new ValeSalidaPieza();

            Fila nuevoVale = new Fila();
            //nuevoVale.AgregarCelda("archivo_vale", archivo);
            nuevoVale.AgregarCelda("tipo", "ENTREGA DE PIEZAS");
            nuevoVale.AgregarCelda("proveedor", "0");
            IdValeSalida = Convert.ToInt32(ValeSalida.Modelo().Insertar(nuevoVale).Celda("id"));


            foreach (int filaActual in IdPlanos)
            {
                plano.CargarDatos(filaActual);
                plano.Fila().ModificarCelda("estatus", "ENTREGADO");
               // plano.Fila().ModificarCelda("folio_entrega", idArchivo);
                plano.Fila().ModificarCelda("vale_salida_entrega", IdValeSalida);
                plano.Fila().ModificarCelda("usuario_entrega", CmbUsuarios.Text.Split('-')[1].TrimStart());
                plano.Fila().ModificarCelda("fecha_entrega", DateTime.Now);
                plano.Fila().ModificarCelda("estatus_ensamble", "SIN RECIBIR");
                plano.GuardarDatos();
            }
            BkgGuardarVale.RunWorkerAsync();                  
        }

        public void MostrarPDF(List<int> idMateriales, string nombreSolicitante)
        {
            Archivo = FormatosPDF.BajaPlanoFabricacion(idMateriales, nombreSolicitante, "ENSAMBLE");
            Global.MostrarPDF(Archivo, "BAJA_ALMACEN", null, VisorPDF);
        }

        private void CmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbUsuarios.Text != "")
            {
                BtnEntregar.Enabled = true;
                MostrarPDF(IdPlanos, CmbUsuarios.Text.Split('-')[1].TrimStart());
            }
        }

        private void FrmEntregarPiezasFabricacion_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
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
            ClienteFtp.Upload(Archivo, "SGC\\VALES_SALIDA\\" + IdValeSalida + ".pdf", FtpExists.Overwrite);
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
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                        proyecto.Fila().ModificarCelda("vale_salida_entrega", 0);
                        proyecto.Fila().ModificarCelda("estatus", "PENDIENTE DE TRATAMIENTO");
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

                
                if (ErrorFtp)
                    MessageBox.Show("Ha ocurrido un problema al momento de guardar el vale de salida " + IdValeSalida.ToString().PadLeft(4, '0') + ". Verifique su conexión y vuelva a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnEntregar.Enabled = true;
            }
        }
    }
}
