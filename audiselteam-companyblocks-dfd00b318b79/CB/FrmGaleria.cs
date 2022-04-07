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
using CB_Base.CB_Controles;

namespace CB
{
    public partial class FrmGaleria : Form
    {
        int IdProducto = -1;

        string URL {
            get { 
                return "/cotizaciones/clientes/producto/" + IdProducto + "/imagenes/";
            }
        }

        public FrmGaleria(int idProducto)
        {
            InitializeComponent();
            IdProducto = idProducto;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnDescargarArchivo.Enabled = listView1.SelectedItems.Count > 0;

            if(listView1.SelectedItems.Count > 0)
            {
                AudiselListViewItem itemSeleccionado = (AudiselListViewItem) (listView1.SelectedItems[0]);

                List<byte[]> imagenes = ServidorFtp.DescargarArchivos(new List<string>() { itemSeleccionado.UriArchivo });
                
                if(itemSeleccionado.EsImagen)
                { 
                    if(imagenes.Count > 0)
                    {
                        pictureBox1.Image = Global.ByteAImagen(imagenes[0]);
                    }
                }
                else
                {
                    pictureBox1.Image = CB_Base.Properties.Resources.video_icon;
                }

                toolStripStatusLabel1.Text = "Nombre archivo: " + System.IO.Path.GetFileName(itemSeleccionado.UriArchivo);
            }
        }

        private void FrmGaleria_Load(object sender, EventArgs e)
        {
            CmbFiltroArchivos.SelectedIndex = 0;
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog seleccionArchivo = new OpenFileDialog();

            if(seleccionArchivo.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            byte[] archivoSubir = System.IO.File.ReadAllBytes(seleccionArchivo.FileName);

            string nombreArchivo = System.IO.Path.GetFileName(seleccionArchivo.FileName);

            if(ServidorFtp.SubirImagen(archivoSubir, URL, nombreArchivo))
            {
                MessageBox.Show("La operación se ha realizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RefrescarItems();
            }
        }

        private void RefrescarItems()
        {
            LiiPrueba.Images.Clear();
            listView1.Items.Clear();

            Dictionary<string, byte[]> archivos;
            
            switch(CmbFiltroArchivos.Text)
            {
                case "IMAGENES":
                    archivos = ServidorFtp.DescargarImagenesVideosEnDirectorio(URL, TipoArchivo.Imagen);
                    break;
                case "VIDEOS":
                    archivos = ServidorFtp.DescargarImagenesVideosEnDirectorio(URL, TipoArchivo.Video);
                    break;
                case "DOCUMENTOS":
                    archivos = ServidorFtp.DescargarImagenesVideosEnDirectorio(URL, TipoArchivo.Documento);
                    break;
                default:
                    archivos = ServidorFtp.DescargarImagenesVideosEnDirectorio(URL);
                    break;
            }
            
            // MessageBox.Show(archivos.Count.ToString());
            // CB_Base.Properties.Resources.video_icon;

            foreach(KeyValuePair<string, byte[]> archivo in archivos)
            {
                if(archivo.Value.Length > 0)
                { 
                    LiiPrueba.Images.Add(
                        Global.ByteAImagen(archivo.Value)
                        );
                }
                else
                {
                    LiiPrueba.Images.Add(
                        CB_Base.Properties.Resources.video_icon_dark
                        );
                }
            }

            int i = 0;

            foreach (KeyValuePair<string, byte[]> archivo in archivos)
            {
                bool esImagen = new List<string> { ".png", ".jpg", ".jpeg" }.Contains(System.IO.Path.GetExtension(archivo.Key.ToLower()));
                listView1.Items.Add(
                    new AudiselListViewItem
                    {
                        ImageIndex = i,
                        IndiceImagen = i,
                        UriArchivo = archivo.Key,
                        EsImagen = esImagen,
                        Text = System.IO.Path.GetFileName(archivo.Key)
                    });
                i++;
            }
        }

        private void BtnDescargarArchivo_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count < 1)
            {
                return;
            }

            SaveFileDialog ventanaGuardado = new SaveFileDialog();
            AudiselListViewItem itemSeleccionado = (AudiselListViewItem) (listView1.SelectedItems[0]);
            
            ventanaGuardado.FileName = System.IO.Path.GetFileName(itemSeleccionado.UriArchivo);

            if(ventanaGuardado.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { 

                List<byte[]> archivosDescargados = ServidorFtp.DescargarArchivos(
                    new List<string>() { 
                        itemSeleccionado.UriArchivo
                    });

                string path = ventanaGuardado.FileName;
                System.IO.File.WriteAllBytes(path, archivosDescargados[0]);
            }
        }

        private void CmbFiltroArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarItems();
        }
    }
}
