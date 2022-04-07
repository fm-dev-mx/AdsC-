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
    public partial class FrmRegistrarFabricante : Form
    {
        byte[] Datos = null;
        string PathString = "SGC\\FABRICANTES\\";
        string PathLocal = Directory.GetCurrentDirectory() + "\\" + "SGC\\FABRICANTES\\";
        int IdFabricante = 0;

        public string NombreFabricante = string.Empty;

        public FrmRegistrarFabricante(int idFabricante = 0)
        {
            InitializeComponent();
            IdFabricante = idFabricante;
        }

        private void FrmRegistrarFabricante_Load(object sender, EventArgs e)
        {
            lblSubiendoArchivo.Visible = false;
            //btnSubir.Enabled = true;
            btnAceptar.Enabled = false;
            if(IdFabricante > 0)
            {
                Fabricante fabricante = new Fabricante();
                fabricante.CargarDatos(IdFabricante);
                if(fabricante.TieneFilas())
                    TxtNombre.Text = fabricante.Fila().Celda("nombre").ToString();

                if (File.Exists(PathLocal + IdFabricante + ".PNG"))
                    PBImage.Image = Global.ByteAImagen(File.ReadAllBytes(PathLocal + IdFabricante + ".PNG"));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg = "El fabricante " + TxtNombre.Text;
            NombreFabricante = TxtNombre.Text;
            int idFabricante = IdFabricante;

            if (IdFabricante == 0)
            {
                Fila nuevoFabricante = new Fila();
                nuevoFabricante.AgregarCelda("nombre", TxtNombre.Text);
                nuevoFabricante.AgregarCelda("logo_en_servidor", (PBImage.Image != null));
                nuevoFabricante.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
                nuevoFabricante.AgregarCelda("fecha_creacion", DateTime.Now);
                idFabricante = Convert.ToInt32(Fabricante.Modelo().Insertar(nuevoFabricante).Celda("id"));
                msg += " se ha creado de forma correcta";
            }
            else
            {
                Fabricante fabricante = new Fabricante();
                fabricante.CargarDatos(idFabricante);

                if(fabricante.TieneFilas())
                {
                    fabricante.Fila().ModificarCelda("nombre", TxtNombre.Text);
                    fabricante.Fila().ModificarCelda("logo_en_servidor", (PBImage.Image != null));
                    fabricante.GuardarDatos();
                    msg += " se ha actualizado de forma correcta";
                }
            }

            // SUBIR IMAGEN
            if (PBImage.Image != null)
            {
                if (!ValidarTamanoLogo(PBImage.Image, 64, 32))
                {
                    Bitmap imagen = new Bitmap(PBImage.Image);
                    Datos = Global.CambiarTamanoImagen(imagen, new Size(64, 32));
                }
                else
                    Datos = Global.ImagenByte(PBImage.Image);

                if (!Directory.Exists(PathLocal))
                    Directory.CreateDirectory(PathLocal);

                if (File.Exists(PathLocal + idFabricante + ".PNG"))
                    File.Delete(PathLocal + idFabricante + ".PNG");

                File.WriteAllBytes(PathLocal + idFabricante + ".PNG", Datos);

                lblSubiendoArchivo.Enabled = true;
                btnAceptar.Enabled = false;
               // btnSubir.Enabled = false;

                BkgSubirArchivo.RunWorkerAsync(idFabricante.ToString());
            }

            MessageBox.Show(msg);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                PBImage.Image = null;
                PBImage.Image = Clipboard.GetImage();
            }
            else
            {
                PBImage.Image = CB_Base.Properties.Resources.image_not_found;
                MessageBox.Show("El elemento que intenta pegar no es una imagen", "Seleccione una imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarTamanoLogo(Image archivo, int limiteW, int limiteH)
        {
            using (var img = new Bitmap(archivo))
            {
                if (img.Width > limiteW || img.Height > limiteH) 
                    return false;
            }

            return true;
        }

        private void BkgSubirArchivo_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgSubirArchivo.ReportProgress(10, "Subiendo archivo...");
            string informacion = (string)e.Argument;
            int idFabricante = Convert.ToInt32(informacion);
            BkgSubirArchivo.ReportProgress(20, "Subiendo archivo...");
            e.Result = ServidorFtp.SubirDocumento(Datos, idFabricante, FormatoArchivo.Png, PathString);
            BkgSubirArchivo.ReportProgress(100, "Subiendo archivo...");
        }

        private void BkgSubirArchivo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblSubiendoArchivo.Text = e.UserState + " " + e.ProgressPercentage;
        }

        private void BkgSubirArchivo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblSubiendoArchivo.Enabled = false;
            btnAceptar.Enabled = true;
            //btnSubir.Enabled = true;
            Datos = null;
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            //btnSubir.Enabled = (TxtNombre.Text != "");
            btnAceptar.Enabled = (TxtNombre.Text != "");
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                PBImage.Image = null;
                PBImage.Image = Clipboard.GetImage();
            }
            else
            {
                PBImage.Image = CB_Base.Properties.Resources.image_not_found;
                MessageBox.Show("El elemento que intenta pegar no es una imagen", "Seleccione una imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
