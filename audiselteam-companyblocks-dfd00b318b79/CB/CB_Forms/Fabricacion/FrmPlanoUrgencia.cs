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
using FluentFTP;
using System.Net;
using SolidWorks.Interop.swconst;

namespace CB
{
    public partial class FrmPlanoUrgencia : Form
    {
        SolidWorksProyecto ListaParteYDrawing = new SolidWorksProyecto();
        PlanoProyecto PlanoSeleccionado = new PlanoProyecto();
        SolidWorksAPI SW = null;
        List<byte[]> ListaImagenes = new List<byte[]>();
        FtpClient ClienteFtp = new FtpClient();
        string PathDrawingCarpetaTemporal = string.Empty;
        string PathParteCarpetaTemporal = string.Empty;
        string RutaParcialSinExtension = "";
        string NombreArchivo = string.Empty;
        string RaizFtp = string.Empty;
        byte[] PlanoImagen;
        byte[] DatosPlano = null;
        bool PlanoDescargado = false;

        public FrmPlanoUrgencia()
        {
            InitializeComponent();
        }

        public FrmPlanoUrgencia(int IdPlano)
        {
            PlanoSeleccionado.CargarDatos(IdPlano);
            InitializeComponent();
        }

        private void FrmPlanoUrgencia_Load(object sender, EventArgs e)
        {
            if(PlanoSeleccionado.TieneFilas())
            {
                TxtId.Text = PlanoSeleccionado.Fila().Celda("id").ToString();
                TxtEstatus.Text = PlanoSeleccionado.Fila().Celda("estatus").ToString();
                TxtNombreArchivo.Text = PlanoSeleccionado.Fila().Celda("nombre_archivo").ToString();

            }

            DateUrgencia.MinDate = DateTime.Today;

            // Cargar otros planos autorizados para urgencia
            PlanoProyecto planosAutorizados = new PlanoProyecto();
            planosAutorizados.SeleccionarDatos("estatus_urgencia=\'AUTORIZADO\'");

            planosAutorizados.Filas().ForEach(delegate(Fila plano) {
                DgvAutorizados.Rows.Add(plano.Celda("id"), plano.Celda("nombre_archivo"), plano.Celda("usuario_solicitud_urgencia"), Global.FechaATexto(plano.Celda("fecha_solicitud_urgencia"), false));
            });

            DescargarPlano();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if(PlanoSeleccionado.TieneFilas())
            {
                PlanoSeleccionado.Fila().ModificarCelda("fecha_promesa_urgencia", DateUrgencia.Value);
                PlanoSeleccionado.Fila().ModificarCelda("fecha_solicitud_urgencia", DateTime.Now);
                PlanoSeleccionado.Fila().ModificarCelda("estatus_urgencia", "PENDIENTE");
                PlanoSeleccionado.Fila().ModificarCelda("usuario_solicitud_urgencia", Global.UsuarioActual.NombreCompleto());
                PlanoSeleccionado.GuardarDatos();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void DescargarPlano()
        {
            BkgDescargarPlano.RunWorkerAsync();
        }

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            int idPlano = Convert.ToInt32(e.Argument);
            string rutaPlanoFtp = string.Empty;

            DatosPlano = ServidorFtp.DescargarPlano(PlanoSeleccionado.Fila().Celda<int>("id"), FormatoArchivo.Png, BkgDescargarPlano, out rutaPlanoFtp);

            if (DatosPlano != null)
            {
                PlanoDescargado = true;
                BkgDescargarPlano.ReportProgress(100, "Procesando plano");
                e.Result = Path.GetFileNameWithoutExtension(rutaPlanoFtp);
            }
            else
            {
                PlanoDescargado = false;
                BkgDescargarPlano.ReportProgress(100, "Error al descargar plano");
                e.Result = string.Empty;
            };
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PlanoDescargado)
            {
                using (var ms = new MemoryStream(DatosPlano))
                {
                    PicPlano.Image = Image.FromStream(ms);
                }
            }
            else
            {

            }
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void DateUrgencia_ValueChanged(object sender, EventArgs e)
        {
            BtnConfirmar.Enabled = DateUrgencia.Value > DateTime.Today;
        } 
    }
}
