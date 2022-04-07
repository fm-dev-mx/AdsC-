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
    public partial class FrmAdministrarFabricantes : Form
    {
        string PathRemoto = "SGC\\FABRICANTES\\";
        string PathLocal = Directory.GetCurrentDirectory() +"\\" + "SGC\\FABRICANTES\\";
        List<Fila> Fabricantes = new List<Fila>();

        public FrmAdministrarFabricantes()
        {
            InitializeComponent();
        }

        private void FrmAdministrarFabricantes_Load(object sender, EventArgs e)
        {
            
        }

        private void FrmAdministrarFabricantes_Shown(object sender, EventArgs e)
        {
            CargarFabricantes();
        }

        private void CargarFabricantes()
        {
            BtnActualizar.Enabled = false;
            BtnSalir.Enabled = false;
            DgvFabricantes.Rows.Clear();
            MenuArchivos.Enabled = false;
            if (!BkgDescargarFabricante.IsBusy)
                BkgDescargarFabricante.RunWorkerAsync();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(PathLocal))
            {
                string[] files = Directory.GetFiles(PathLocal);    
                foreach (string file in files)    
                {    
                    File.Delete(file);     
                }
            }

            CargarFabricantes();
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarFabricante registrar = new FrmRegistrarFabricante();
            if(registrar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarFabricantes();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de borrar la información del fabrincate " + DgvFabricantes.SelectedRows[0].Cells["nombre"].Value.ToString() + "?", "Eliminar fabricante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                BtnSalir.Enabled = false;
                string[] informacion = new string[] { DgvFabricantes.SelectedRows[0].Cells["id"].Value.ToString(), "SGC\\FABRICANTES\\" };
                BkgRemoverDocumento.RunWorkerAsync(informacion);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarFabricante registrar = new FrmRegistrarFabricante(Convert.ToInt32(DgvFabricantes.SelectedRows[0].Cells["id"].Value));
            if(registrar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarFabricantes();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuArchivos_Opening(object sender, CancelEventArgs e)
        {
            editarToolStripMenuItem.Enabled = (DgvFabricantes.SelectedRows.Count > 0);
            eliminarToolStripMenuItem.Enabled = (DgvFabricantes.SelectedRows.Count > 0);
        }

        private void BkgDescargarFabricante_DoWork(object sender, DoWorkEventArgs e)
        {
            Fabricante fabricante = new Fabricante();
            Fabricantes = fabricante.SeleccionarDatos("id != 0 order by nombre asc", null, "*");
            int total = Fabricantes.Count;
            int avance = 1;
            Fabricantes.ForEach(delegate(Fila f)
            {
                Fila filaInformacion = new Fila();
                byte[] miniatura = null;

                if (Convert.ToInt32(f.Celda("logo_en_servidor")) > 0)
                {
                    if (File.Exists(PathLocal + f.Celda("id") + ".PNG"))
                        miniatura = File.ReadAllBytes(PathLocal + f.Celda("id") + ".PNG");
                    else
                    {
                        miniatura = ServidorFtp.DescargarArchivo(Convert.ToInt32(f.Celda("id")), FormatoArchivo.Png, PathRemoto);
                        if (!Directory.Exists(PathLocal))
                            Directory.CreateDirectory(PathLocal);

                        File.WriteAllBytes(PathLocal + f.Celda("id") + ".PNG", miniatura);
                    }
                }
                
                filaInformacion.AgregarCelda("id", f.Celda("id").ToString().PadLeft(4, '0'));
                filaInformacion.AgregarCelda("nombre", f.Celda("nombre"));
                filaInformacion.AgregarCelda("miniatura", miniatura);
                filaInformacion.AgregarCelda("logo_en_servidor", f.Celda("logo_en_servidor"));

                double progreso = (avance * 100)/total;
                BkgDescargarFabricante.ReportProgress(Convert.ToInt32(progreso), filaInformacion);
                avance ++;
            });
        }

        private void BkgDescargarFabricante_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Descargando fabricantes... [" + e.ProgressPercentage + "%]";

            Fila f = (Fila)e.UserState;
            byte[] miniatura = (byte[])f.Celda("miniatura");
            if (miniatura == null)
            {
                ImageConverter converter = new ImageConverter();
                miniatura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.image_not_found_32, typeof(byte[]));
            }

            DgvFabricantes.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), f.Celda("nombre"), miniatura, f.Celda("logo_en_servidor"));
        }

        private void BkgDescargarFabricante_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Descarga completa!";
            BtnSalir.Enabled = true;
            BtnActualizar.Enabled = true;
            MenuArchivos.Enabled = true;
        }

        private void BkgRemoverDocumento_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgRemoverDocumento.ReportProgress(30, "Removiendo fabricante...");
            string[] informacion = (string[])e.Argument;
            ServidorFtp.RemoverArchivo(Convert.ToInt32(informacion[0]), FormatoArchivo.Png, informacion[1].ToString());
            BkgRemoverDocumento.ReportProgress(100, "Removiendo fabricante...");
        }

        private void BkgRemoverDocumento_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Removiendo fabricantes... [" + e.ProgressPercentage + "%]";
        }

        private void BkgRemoverDocumento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fabricante fabricante = new Fabricante();
            fabricante.CargarDatos(Convert.ToInt32(DgvFabricantes.SelectedRows[0].Cells["id"].Value.ToString()));
            fabricante.BorrarDatos();
            fabricante.GuardarDatos();

            if (File.Exists(PathLocal + Convert.ToInt32(DgvFabricantes.SelectedRows[0].Cells["id"].Value.ToString()) + ".PNG"))
                File.Delete(PathLocal + Convert.ToInt32(DgvFabricantes.SelectedRows[0].Cells["id"].Value.ToString()) + ".PNG");

            MessageBox.Show("El fabricante seleccionado ha sido eliminado correctamente", "Fabricante eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnSalir.Enabled = true;
            BtnActualizar.Enabled = true;
            MenuArchivos.Enabled = true;
            CargarFabricantes();
        }
    }
}
