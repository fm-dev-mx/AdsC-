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
    public partial class FrmSolidosMaterial : Ventana
    {
        int IdMaterial = 0;
        double InicioCarga;   
        string ConfiguracionValor = "";
        string ValorDefault = "";
        bool ErrorExportar = false;
        string[] NombresArchivosPorSubir;
        int TotalSolidosSeleccionados = 0;
        List<Fila> Solidos = new List<Fila>();
        string Categoria = "";

        OpenFileDialog SubirArchivo = new OpenFileDialog();
        FolderBrowserDialog FolderDir = new FolderBrowserDialog();
        List<int> ListaIdMateriales = new List<int>();

        Dictionary<string, byte[]> Archivos = new Dictionary<string, byte[]>();
        public FrmSolidosMaterial(int idMaterial)
        {
            InitializeComponent();
            IdMaterial = idMaterial;
        }

        public void CargarConfiguracion()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@material", IdMaterial);
            SolidoMaterial.Modelo().SeleccionarDatos("material=@material", parametros, "distinct(configuracion)").ForEach(delegate(Fila f)
            {
                CmbCategoria.Items.Add(f.Celda("configuracion").ToString().ToUpper());
            });
        }

        private void FrmSolidosMaterial_Load(object sender, EventArgs e)
        {
            string defaultValor = "";
            CatalogoMaterial.Modelo().CargarDatos(IdMaterial).ForEach(delegate(Fila f)
            {
                TxtNumeroParte.Text = f.Celda("numero_parte").ToString();
                TxtFabricante.Text = f.Celda("fabricante").ToString();
                TxtDescripcion.Text = f.Celda("descripcion").ToString();
            });

            CargarConfiguracion();
            CatalogoMaterial.Modelo().CargarDatos(IdMaterial).ForEach(delegate(Fila f)
            {
                defaultValor = f.Celda("numero_parte").ToString();
                if (!CmbCategoria.Items.Contains(f.Celda("numero_parte").ToString()))
                    CmbCategoria.Items.Add(f.Celda("numero_parte").ToString().ToUpper());
            });
            ValorDefault = defaultValor;
            int indexDeCategoria = CmbCategoria.FindStringExact(defaultValor);
            CmbCategoria.SelectedIndex = indexDeCategoria;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void DgvSolido_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvSolido = DgvSolido.HitTest(e.X, e.Y);

            if (clickDgvSolido.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    DgvSolido.ClearSelection();
                    borrarToolStripMenuItem.Enabled = false;

                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;
                    MenuOpciones.Show(mouseX, mouseY);
                }
            }
        }

        private void DgvSolido_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right && DgvSolido.SelectedRows.Count != 0)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    MenuOpciones.Show(mouseX, mouseY);
                    if (DgvSolido.SelectedRows.Count > 0)
                        borrarToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void subirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubirArchivo.Multiselect = true;
            SubirArchivo.Filter = "SolidWorks files(*.sldasm, *.sldprt)|*.sldasm;*.sldprt;)";
            if (SubirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NombresArchivosPorSubir = SubirArchivo.FileNames;
                ProgresoDescarga.Visible = true;
                ConfiguracionValor = CmbCategoria.Text;
                InicioCarga = Global.MillisegundosEpoch();
                BkgSubirSolido.RunWorkerAsync();
            }
        }

        private void BkgSubirSolido_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Subiendo sólidos... [" + e.ProgressPercentage + "%]";
        }

        private void BkgSubirSolido_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Subida completa!";
            Archivos.Clear();
            string CmbValor = CmbCategoria.Text;
            CmbCategoria.Items.Clear();
            CargarConfiguracion();
            int indexDeCategoria = CmbCategoria.FindStringExact(CmbValor);
            CmbCategoria.SelectedIndex = indexDeCategoria;

            if (!CmbCategoria.Items.Contains(ValorDefault))
                CmbCategoria.Items.Add(ValorDefault.ToUpper());
        }

        private void BkgSubirSolido_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = "";
            int indice = 0;

            SolidoMaterial solidoMaterial = new SolidoMaterial();
           
            foreach (string nombreArchivo in NombresArchivosPorSubir)
            {
                string fileName = nombreArchivo;
                string onlyFileName = System.IO.Path.GetFileName(fileName);
                //crear temporal
                string tempPath = Path.Combine(Path.GetTempPath(), onlyFileName);
                //checa si existe temporal, si existe lo borra
                if (File.Exists(tempPath))
                    File.Delete(tempPath);

                File.Copy(fileName, tempPath);
                byte[] datos = File.ReadAllBytes(tempPath);

                long archivoTamano = new System.IO.FileInfo(tempPath).Length;

                if (Archivos.ContainsKey(onlyFileName))
                    msg += onlyFileName + "\r\n";                
                else
                {
                    Archivos.Add(onlyFileName, datos);

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@material", IdMaterial);
                    parametros.Add("@nombre", onlyFileName);
                    parametros.Add("@configuracion", ConfiguracionValor);
                    solidoMaterial.SeleccionarDatos("material=@material AND nombre_solido=@nombre AND configuracion=@configuracion", parametros);
                    if (solidoMaterial.TieneFilas())  
                        msg += onlyFileName + "\r\n";  
                    else
                    {
                        Fila insertarSolido = new Fila();
                        insertarSolido.AgregarCelda("material", IdMaterial);
                        insertarSolido.AgregarCelda("solido", datos);
                        insertarSolido.AgregarCelda("nombre_solido", onlyFileName);
                        insertarSolido.AgregarCelda("archivo_tamano", archivoTamano);
                        insertarSolido.AgregarCelda("configuracion", ConfiguracionValor);
                        solidoMaterial.Insertar(insertarSolido);
                    }
                }
                indice++;
                BkgSubirSolido.ReportProgress(Global.CalcularPorcentaje(indice, NombresArchivosPorSubir.Count()));
                //borramos temporal
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
            if(msg != "")
                MessageBox.Show("Los siguientes archivos no fueron subidos ya que existen en la base de datos, favor de renombrarlos o consulte al administrador del sistema:\r\n" + msg, "Archivos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BkgBorrar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Borrando sólidos... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgBorrar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Sólidos borrados!";
            CmbCategoria.Enabled = false;
            BkgDescargarSolidos.RunWorkerAsync();
        }

        private void BkgBorrar_DoWork(object sender, DoWorkEventArgs e)
        {
            SolidoMaterial solidoMaterial = new SolidoMaterial();
            int indice = 0;
            foreach (DataGridViewRow row in DgvSolido.SelectedRows)
            {
                int solidoId = Convert.ToInt32(row.Cells["id"].Value);
                solidoMaterial.CargarDatos(solidoId);
                if(solidoMaterial.TieneFilas())
                {
                    solidoMaterial.BorrarDatos(solidoId);
                    solidoMaterial.GuardarDatos();
                }
                indice++;
                BkgBorrar.ReportProgress(Global.CalcularPorcentaje(indice, TotalSolidosSeleccionados));
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("Los sólidos que sean borrados no podrán ser recuperados, ¿Está seguro que desea borrar sólidos?", "Borrar Sólidos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                ProgresoDescarga.Visible = true;
                InicioCarga = Global.MillisegundosEpoch();
                TotalSolidosSeleccionados = DgvSolido.SelectedRows.Count;
                BkgBorrar.RunWorkerAsync();
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            ListaIdMateriales.Clear();

            foreach (DataGridViewRow row in DgvSolido.Rows)
            {
                ListaIdMateriales.Add(Convert.ToInt32(row.Cells["id"].Value));
            }

            if (ListaIdMateriales.Count > 0)
            {
                if(FolderDir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ProgresoDescarga.Value = 0;
                    ProgresoDescarga.Visible = true;
                    InicioCarga = Global.MillisegundosEpoch();
                    BkgExportar.RunWorkerAsync();
                }
            }
            else
                MessageBox.Show("Debe subir un archivo antes de exportar","No contiene archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BkgExportar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Exportando sólidos... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgExportar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!ErrorExportar)
            {
                ProgresoDescarga.Visible = false;
                LblEstatus.Text = "Sólidos exportados!";
            }
            else
            {
                LblEstatus.Text = "Estatus...";
            }
        }

        private void BkgExportar_DoWork(object sender, DoWorkEventArgs e)
        {
            ErrorExportar = false;
            string archivosDuplicados = ""; 
            string directorio = FolderDir.SelectedPath;
            if (!directorio.EndsWith(@"\PP"))
            {
                MessageBox.Show("Debe seleccionar la carpeta PP para poder exportar los sólidos", "Se requiere la carpeta PP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorExportar = true;
                return;
            }
            string[] buscarCarpetas = Directory.GetDirectories(directorio).ToArray();
            if(!Array.Exists(buscarCarpetas, x => x.EndsWith(@"\" + LimpiarPath(TxtFabricante.Text))))
            {
                Directory.CreateDirectory(directorio + @"\" +  LimpiarPath((TxtFabricante.Text)));
            }
            SolidoMaterial solidoMaterial = new SolidoMaterial();
            int indice = 0;
            foreach (int item in ListaIdMateriales)
            {
                solidoMaterial.CargarDatos(item);
                if(solidoMaterial.TieneFilas())
                {
                    string categoriaPath = directorio + @"\" + LimpiarPath((TxtFabricante.Text)) + @"\" + LimpiarPath(solidoMaterial.Fila().Celda("configuracion").ToString());
                    if (!Directory.Exists(categoriaPath))
                    {
                        Directory.CreateDirectory(categoriaPath);
                    }
                    string newPath = directorio + @"\" + LimpiarPath(TxtFabricante.Text) + @"\" + LimpiarPath(solidoMaterial.Fila().Celda("configuracion").ToString()) + @"\" + solidoMaterial.Fila().Celda("nombre_solido").ToString();
                    if (!File.Exists(newPath))
                        File.WriteAllBytes(newPath, (byte[])solidoMaterial.Fila().Celda("solido"));
                    else
                        archivosDuplicados += solidoMaterial.Fila().Celda("nombre_solido").ToString() + "\r\n"; 
                } 
                indice++;

                BkgExportar.ReportProgress( Global.CalcularPorcentaje(indice, ListaIdMateriales.Count) );
            }
            if (archivosDuplicados != "")
                MessageBox.Show("Los siguientes archivos ya existen:\r\n" + archivosDuplicados, "Archivos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string LimpiarPath(string path)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            foreach (char c in invalid)
            {
                path = path.Replace(c.ToString(), "-");
            }
            return path;
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoria = CmbCategoria.Text;
            ProgresoDescarga.Visible = true;
            InicioCarga = Global.MillisegundosEpoch();
            CmbCategoria.Enabled = false;
            BkgDescargarSolidos.RunWorkerAsync();
        }

        private void CmbCategoria_TextChanged(object sender, EventArgs e)
        {
            DgvSolido.Rows.Clear();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
          //  Mover(sender, e);
        }

        private void CmbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str = e.KeyChar.ToString().ToUpper();
            char[] ch = str.ToCharArray();
            e.KeyChar = ch[0];
        }

        private void BkgDescargarSolidos_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@material", IdMaterial);
            parametros.Add("@configuracion", Categoria);
            string query = "material=@material AND configuracion=@configuracion";

            Solidos = SolidoMaterial.Modelo().SeleccionarDatos(query, parametros, "*", BkgDescargarSolidos);
        }

        private void BkgDescargarSolidos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int alto = 40;
            int largo = 40;

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvSolido);
            DgvSolido.Rows.Clear();

            Solidos.ForEach(delegate(Fila f)
            {
                Image img = null;
                ImageConverter converter = new ImageConverter();
                byte[] imagenArchivo = null;

                if (f.Celda("nombre_solido").ToString().ToLower().EndsWith(".sldprt"))
                    imagenArchivo = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.solid_parts, typeof(byte[]));
                else if (f.Celda("nombre_solido").ToString().ToLower().EndsWith(".sldasm"))
                    imagenArchivo = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.solid_assembly, typeof(byte[]));
                else
                    imagenArchivo = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.image_not_found, typeof(byte[]));

                ImageConverter ic = new ImageConverter();
                img = (Image)(ic.ConvertFrom(imagenArchivo));

                if (img.Width > alto | img.Height > largo)
                {
                    Bitmap bitmap = new Bitmap(alto, largo);
                    using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                        graphics.DrawImage(img, 0, 0, alto, largo);
                    img = bitmap;
                }
                double bytesToKb = Convert.ToDouble(f.Celda("archivo_tamano").ToString()) / 1000;

                DgvSolido.Rows.Add(f.Celda("id"), img, f.Celda("nombre_solido"), bytesToKb + " Kb");
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvSolido);

            ProgresoDescarga.Visible = false;
            CmbCategoria.Enabled = true;
            double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
            LblEstatus.Text = Solidos.Count + " solidos descargados en " + (TiempoTranscurrido/1000.0).ToString("F2") + " segundos.";
        }

        private void BkgDescargarSolidos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Descargando sólidos... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }    
    }
}
