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
using CB_Base.Classes;

namespace CB
{
    public partial class FrmRestringirNumeroParte : Form
    {
        string CatalogoUri = @"./SGC/CATALOGOMATERIAL/";
        byte[] ImagenByte;
        bool MaterialRestringido = false;
        bool ImagenEncontrada = false;
        bool CargarMaterial = false;
        public FrmRestringirNumeroParte()
        {
            InitializeComponent();
        }

        private void FrmRestringirNumeroParte_Load(object sender, EventArgs e)
        {
            ChkRestringit.Enabled = false;
        }

        private void CargarInformacion(string numeroParte)
        {
            TxtAudiselParte.Text = "";
            TxtFabricante.Text = "";
            TxtDescripcion.Text = "";
            ChkRestringit.Enabled = false;
            ChkRestringit.Checked = false;
            LblEstatusAsignaciones.Text = "Estatus...";
            CargarMaterial = true;


            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numeroParte", numeroParte);

            CatalogoMaterial cat = new CatalogoMaterial();
            cat.SeleccionarDatos("numero_parte=@numeroParte", parametros);

            if(cat.TieneFilas())
            {
                if (Convert.ToBoolean(cat.Fila().Celda("imagen_servidor")))
                {
                    TxtNumeroParte.Enabled = false;
                    BarraProgresoAsignaciones.Value = 0;
                    BarraProgresoAsignaciones.Visible = true;
                    BkgDescargarImagen.RunWorkerAsync(cat.Fila().Celda("id"));
                }
                else
                {
                    ChkRestringit.Enabled = true;
                    ImagenMaterial.Image = CB_Base.Properties.Resources.manu_prod;
                    LblEstatusAsignaciones.Text = "El material no contiene una imagen";
                }

                TxtAudiselParte.Text = Global.CrearNumeroParteAudisel(Convert.ToInt32(cat.Fila().Celda("id").ToString().PadLeft(6, '0')));
                TxtFabricante.Text = cat.Fila().Celda("fabricante").ToString();
                TxtDescripcion.Text = cat.Fila().Celda("descripcion").ToString();
                ChkRestringit.Checked = Convert.ToBoolean(cat.Fila().Celda("material_restringido"));
                MaterialRestringido = ChkRestringit.Checked;
                CargarMaterial = false;
            }
            else
            {
                MessageBox.Show
                (
                    "No se encontró el material solicitado",
                    "Material no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

        }

        private void TxtNumeroParte_KeyDown(object sender, KeyEventArgs e)
        {
            if (TxtNumeroParte.Text == "")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                CargarInformacion(TxtNumeroParte.Text);
            }
        }

        private void ChkRestringit_CheckedChanged(object sender, EventArgs e)
        {
            if (CargarMaterial)
                return;

            if (TxtNumeroParte.Text == "" || TxtAudiselParte.Text == "")
                return;

            CatalogoMaterial mat = new CatalogoMaterial();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numeroParte", TxtNumeroParte.Text);

            CatalogoMaterial cat = new CatalogoMaterial();
            cat.SeleccionarDatos("numero_parte=@numeroParte", parametros);

            if (ChkRestringit.Checked)
            {
                //Guardamos la restriccion
                DialogResult result = MessageBox.Show("¿Desea restringir la compra de éste material?", "Restringir material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    cat.Fila().ModificarCelda("material_restringido", 1);
                    cat.GuardarDatos();
                    MaterialRestringido = true;
                }
                else
                {
                    ChkRestringit.Checked = MaterialRestringido;
                }
            }
            else
            {
                //se quita la restriuccion
                cat.Fila().ModificarCelda("material_restringido", 0);
                cat.GuardarDatos();
                MaterialRestringido = false;
                MessageBox.Show("El material se encuentra disponible para ser solicitado", "Material disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DescargarImagen_DoWork(object sender, DoWorkEventArgs e)
        {
            FtpClient clienteFtp = new FtpClient();
            Global.CrearConexionFTP(clienteFtp);

            int id = Convert.ToInt32(e.Argument);

            if (clienteFtp.IsConnected)
            {
                BkgDescargarImagen.ReportProgress(60, "Descargando imagen, espere un momento...");
                if (clienteFtp.FileExists(CatalogoUri + "/" + id + ".PNG"))
                {
                    clienteFtp.Download(out ImagenByte, CatalogoUri + "/" + id + ".PNG");
                    ImagenEncontrada = true;
                }
                else
                {
                    ImagenEncontrada = false;
                    ImagenByte = null;
                }
            }
        }

        private void BkgDescargarImagen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatusAsignaciones.Text = e.UserState.ToString();
            BarraProgresoAsignaciones.Value = e.ProgressPercentage;
        }

        private void BkgDescargarImagen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ChkRestringit.Enabled = true;
            TxtNumeroParte.Enabled = true;
            BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = false;

            if (ImagenEncontrada)
            {
                LblEstatusAsignaciones.Text = "Imagen descargada correctamente";
                ImagenMaterial.Image = Global.ByteAImagen(ImagenByte);

            }
            else
            {
                ImagenMaterial.Image = CB_Base.Properties.Resources.manu_prod;
                LblEstatusAsignaciones.Text = "El material no contiene una imagen";
            }
            
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
