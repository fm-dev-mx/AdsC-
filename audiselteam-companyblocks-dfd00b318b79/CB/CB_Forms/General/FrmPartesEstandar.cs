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
    public partial class FrmPartesEstandar : Ventana
    {
        List<Fila> Subensamble = new List<Fila>();
        List<Fila> Partes = new List<Fila>();
        List<int> IdParteLista = new List<int>();
        List<int> IdSubensambleLista = new List<int>();

        OpenFileDialog SubirEnsamble = new OpenFileDialog();
        FolderBrowserDialog FolderDir = new FolderBrowserDialog();
        Dictionary<string, byte[]> Archivos = new Dictionary<string, byte[]>();

        string[] NombresArchivosPorSubir;
        string Descripcion = "";
        string ArchivosDuplicados = "";
        string Msg = "";
        bool ArchivoExistente = false;
        bool ErrorExportar = false;
        bool EditarSubensamble = false;
        double InicioCarga;
        int IdSubensamble;
        int TotalSolidosSeleccionados = 0;

        public FrmPartesEstandar()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            
        }

        private void FrmPartesEstandar_Load(object sender, EventArgs e)
        {
            ProgresoDescarga.Visible = true;
            InicioCarga = Global.MillisegundosEpoch();
            BkgDescargarSubensamble.RunWorkerAsync();
        }

        private void BkgDescargarSubensamble_DoWork(object sender, DoWorkEventArgs e)
        {
            Subensamble = SubensambleEstandar.Modelo().SeleccionarDatos("", null, "*", BkgDescargarSubensamble);
        }

        private void BkgDescargarSubensamble_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int alto = 40;
            int largo = 40;

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvSubensamble);
            DgvSubensamble.Rows.Clear();
            int rowIndex = 0;
            Subensamble.ForEach(delegate(Fila f)
            {
                Image img = null;
                ImageConverter converter = new ImageConverter();
                byte[] imagenArchivo = null;

                if (f.Celda("nombre_archivo").ToString().ToLower().EndsWith(".sldasm"))
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
                string strDescripcion = "";
                Object objDescripcion = f.Celda("descripcion");
                if(objDescripcion != null)
                    strDescripcion= f.Celda("descripcion").ToString();

                DgvSubensamble.Rows.Add(img, f.Celda("id").ToString(), f.Celda("nombre_archivo").ToString(), strDescripcion);
                DataGridViewCell cell = DgvSubensamble.Rows[rowIndex].Cells[3];
                cell.ToolTipText = "Doble click para editar descripción";
                rowIndex++;
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvSubensamble);

            ProgresoDescarga.Visible = false;
            double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
            LblEstatus.Text = Subensamble.Count + " subensambles descargados en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
        }

        private void BkgDescargarSubensamble_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Descargando subensambles... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void subirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubirEnsamble.Multiselect = true;
            Msg = "";
            ArchivoExistente = false;
            SubirEnsamble.Filter = "SolidWorks Assembly|*.sldasm;";
            if (SubirEnsamble.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NombresArchivosPorSubir = SubirEnsamble.FileNames;
                ProgresoDescarga.Visible = true;
                InicioCarga = Global.MillisegundosEpoch();
                BkgSubirEnsamble.RunWorkerAsync();
            }        
        }

        private void DgvSubensamble_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvSubensamble = DgvSubensamble.HitTest(e.X, e.Y);

            if (clickDgvSubensamble.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    borrarToolStripMenuItem.Enabled = false;
                    exportarSubensambleToolStripMenuItem.Enabled = false;

                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;
                    MenuSubensamble.Show(mouseX, mouseY);
                }
            }
        }

        private void DgvSubensamble_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right && DgvSubensamble.SelectedRows.Count != 0)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    MenuSubensamble.Show(mouseX, mouseY);
                    if (DgvSubensamble.SelectedRows.Count > 0)
                    {
                        borrarToolStripMenuItem.Enabled = true;
                        exportarSubensambleToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        private void DgvPartes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right && DgvPartes.SelectedRows.Count != 0)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    MenuPartes.Show(mouseX, mouseY);
                    if (DgvPartes.SelectedRows.Count > 0)
                    {
                        borrarToolStripMenuItem1.Enabled = true;
                        exportarPartesToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        borrarToolStripMenuItem1.Enabled = false;
                        exportarPartesToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }

        private void DgvPartes_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvPartes = DgvPartes.HitTest(e.X, e.Y);

            if (clickDgvPartes.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    borrarToolStripMenuItem1.Enabled = false;
                    exportarPartesToolStripMenuItem.Enabled = false;

                    if (DgvSubensamble.SelectedRows.Count <= 0)
                        subirPartes.Enabled = false;
                    else
                        subirPartes.Enabled = true;

                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;
                    MenuPartes.Show(mouseX, mouseY);
                }
            }
        }

        private void BkgSubirEnsamble_DoWork(object sender, DoWorkEventArgs e)
        {
            SubensambleEstandar subensamble = new SubensambleEstandar();

            int indice = 0;
            foreach (string nombreArchivo in NombresArchivosPorSubir)
            {
                string fileName = nombreArchivo;
                string onlyFileName = System.IO.Path.GetFileName(fileName);
                string tempPath = Path.Combine(Path.GetTempPath(), onlyFileName);
                //checa si existe temporal, si existe lo borra
                if (File.Exists(tempPath))
                    File.Delete(tempPath);

                File.Copy(fileName, tempPath);
                byte[] datos = File.ReadAllBytes(tempPath);

                long archivoTamano = new System.IO.FileInfo(tempPath).Length;

                if (Archivos.ContainsKey(onlyFileName))
                {
                    Msg += onlyFileName + "\r\n";
                    if (!ArchivoExistente)
                        ArchivoExistente = true;
                }
                else
                {
                    Archivos.Add(onlyFileName, datos);

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@nombre", onlyFileName);
                    subensamble.SeleccionarDatos("nombre_archivo=@nombre", parametros);
                    if (subensamble.TieneFilas())
                    {
                        Msg += onlyFileName + "\r\n";
                        if (!ArchivoExistente)
                            ArchivoExistente = true;
                    }
                    else
                    {
                        Fila insertarSubensamble = new Fila();
                        insertarSubensamble.AgregarCelda("nombre_archivo", onlyFileName);
                        insertarSubensamble.AgregarCelda("tamano", archivoTamano);
                        insertarSubensamble.AgregarCelda("archivo", datos);
                        subensamble.Insertar(insertarSubensamble);
                    }
                }
                if (File.Exists(tempPath))
                    File.Delete(tempPath);

                indice++;
                BkgSubirEnsamble.ReportProgress(Global.CalcularPorcentaje(indice, NombresArchivosPorSubir.Count()));               
            }
        }

        private void BkgSubirEnsamble_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Subiendo subensamble... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgSubirEnsamble_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Subida completa!";
            Archivos.Clear();
            BkgDescargarSubensamble.RunWorkerAsync();
            if (ArchivoExistente)
                MessageBox.Show("Los siguientes archivos no fueron subidos ya que existen en la base de datos, favor de renombrarlos o consulte al administrador del sistema:\r\n" + Msg, "Archivos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void subirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Msg = "";
            ArchivoExistente = false;
            SubirEnsamble.Multiselect = true;
            SubirEnsamble.Filter = "SolidWorks Parts|*.sldprt;";
            if (SubirEnsamble.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NombresArchivosPorSubir = SubirEnsamble.FileNames;
                ProgresoDescarga.Visible = true;
                InicioCarga = Global.MillisegundosEpoch();
                BkgSubirPartes.RunWorkerAsync();
            }
        }

        private void BkgSubirPartes_DoWork(object sender, DoWorkEventArgs e)
        {
            ParteEstandar partes = new ParteEstandar();

            int indice = 0;
            foreach (string nombreArchivo in NombresArchivosPorSubir)
            {
                string fileName = nombreArchivo;
                string onlyFileName = System.IO.Path.GetFileName(fileName);
                string tempPath = Path.Combine(Path.GetTempPath(), onlyFileName);
                //checa si existe temporal, si existe lo borra
                if (File.Exists(tempPath))
                    File.Delete(tempPath);

                File.Copy(fileName, tempPath);

                byte[] datos = File.ReadAllBytes(tempPath);

                long archivoTamano = new System.IO.FileInfo(tempPath).Length;

                if (Archivos.ContainsKey(onlyFileName))
                {
                    Msg += onlyFileName + "\r\n";
                    if (!ArchivoExistente)
                        ArchivoExistente = true;
                }
                else
                {
                    Archivos.Add(onlyFileName, datos);

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@nombre", onlyFileName);
                    parametros.Add("@subensamble",DgvSubensamble.SelectedRows[0].Cells["ID"].Value);
                    partes.SeleccionarDatos("nombre_archivo=@nombre AND subensamble=@subensamble", parametros);
                    if (partes.TieneFilas())
                    {
                        Msg += onlyFileName + "\r\n";
                        if (!ArchivoExistente)
                            ArchivoExistente = true;
                    }
                    else
                    {
                        Fila insertarSubensamble = new Fila();
                        insertarSubensamble.AgregarCelda("subensamble", IdSubensamble);
                        insertarSubensamble.AgregarCelda("nombre_archivo", onlyFileName);
                        insertarSubensamble.AgregarCelda("tamano", archivoTamano);
                        insertarSubensamble.AgregarCelda("archivo", datos);
                        partes.Insertar(insertarSubensamble);
                    }
                }
                indice++;
                BkgSubirPartes.ReportProgress(Global.CalcularPorcentaje(indice, NombresArchivosPorSubir.Count()));
                //borramos temporal
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        private void BkgSubirPartes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Subiendo partes... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgSubirPartes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Subida completa!";
            Archivos.Clear();
            BkgDescargarPartes.RunWorkerAsync();
            if (ArchivoExistente)
                MessageBox.Show("Los siguientes archivos no fueron subidos ya que existen en la base de datos, favor de renombrarlos o consulte al administrador del sistema:\r\n" + Msg, "Archivos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BkgDescargarPartes_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", IdSubensamble);
            Partes = ParteEstandar.Modelo().SeleccionarDatos("subensamble=@subensamble", parametros, "*", BkgDescargarPartes);
        }

        private void BkgDescargarPartes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Descargando partes... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgDescargarPartes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int alto = 40;
            int largo = 40;

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvPartes);
            DgvPartes.Rows.Clear();
            int rowIndex = 0;
            Partes.ForEach(delegate(Fila f)
            {
                Image img = null;
                ImageConverter converter = new ImageConverter();
                byte[] imagenArchivo = null;

                if (f.Celda("nombre_archivo").ToString().ToLower().EndsWith(".sldprt"))
                    imagenArchivo = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.solid_parts, typeof(byte[]));
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

                Object objDescripcion = f.Celda("descripcion");
                string strDescripcion = "";
                if(objDescripcion != null)
                    strDescripcion = f.Celda("descripcion").ToString();

                DgvPartes.Rows.Add(false,img, f.Celda("id"),  f.Celda("nombre_archivo").ToString(), strDescripcion);
                DataGridViewCell cell = DgvPartes.Rows[rowIndex].Cells[3];
                cell.ToolTipText = "Doble click para editar descripción";
                rowIndex++;
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvPartes);

            ProgresoDescarga.Visible = false;
            double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
            LblEstatus.Text = Partes.Count + " partes descargadas en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
        }

        private void BkgBorrarSubensamble_DoWork(object sender, DoWorkEventArgs e)
        {
            SubensambleEstandar subensamble = new SubensambleEstandar();
            ParteEstandar partes = new ParteEstandar();
            int indice = 0;
            foreach (DataGridViewRow row in DgvSubensamble.SelectedRows)
            {
                int subensambleId = Convert.ToInt32(row.Cells["id"].Value);
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@subensamble", subensambleId);
                subensamble.CargarDatos(subensambleId);
                if (subensamble.TieneFilas())
                {
                    subensamble.BorrarDatos(subensambleId);
                    subensamble.GuardarDatos();
                    ParteEstandar.Modelo().SeleccionarDatos("subensamble=@subensamble", parametros).ForEach(delegate(Fila f)
                    {
                        partes.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        if(partes.TieneFilas())
                        {
                            partes.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                            partes.GuardarDatos();
                        }
                    });
                }
                indice++;
                BkgBorrarSubensamble.ReportProgress(Global.CalcularPorcentaje(indice, TotalSolidosSeleccionados));
            }
        }

        private void BkgBorrarSubensamble_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Borrando subensambles... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgBorrarSubensamble_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Subensambles borrados!";
            BkgDescargarSubensamble.RunWorkerAsync();
            DgvPartes.Rows.Clear();            
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los subensambles que sean borrados no podrán ser recuperados, ¿Está seguro que desea borrar los subensambles?", "Borrar subensambles", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                ProgresoDescarga.Visible = true;
                InicioCarga = Global.MillisegundosEpoch();
                TotalSolidosSeleccionados = DgvSubensamble.SelectedRows.Count;
                BkgBorrarSubensamble.RunWorkerAsync();
            }
        }

        private void borrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Las partes estandar que sean borradas no podrán ser recuperadas, ¿Está seguro que desea borrar las partes estandar?", "Borrar partes estandar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                ProgresoDescarga.Visible = true;
                InicioCarga = Global.MillisegundosEpoch();
                TotalSolidosSeleccionados = DgvPartes.SelectedRows.Count;
                BkgBorrarPartes.RunWorkerAsync();
            }
        } 

        private void BkgBorrarPartes_DoWork(object sender, DoWorkEventArgs e)
        {
            ParteEstandar partes = new ParteEstandar();
            int indice = 0;
            foreach (DataGridViewRow row in DgvPartes.SelectedRows)
            {
                int partesId = Convert.ToInt32(row.Cells["id_partes"].Value);
                partes.CargarDatos(partesId);
                if (partes.TieneFilas())
                {
                    partes.BorrarDatos(partesId);
                    partes.GuardarDatos();
                }
                indice++;
                BkgBorrarPartes.ReportProgress(Global.CalcularPorcentaje(indice, TotalSolidosSeleccionados));
            }
        }

        private void BkgBorrarPartes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Borrando partes estandar... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgBorrarPartes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Partes estandar borrados!";
            BkgDescargarPartes.RunWorkerAsync();
        }

        private void BkgEditarParte_DoWork(object sender, DoWorkEventArgs e)
        {
            int partesId = Convert.ToInt32(DgvPartes.SelectedRows[0].Cells["id_partes"].Value);
            ParteEstandar partes = new ParteEstandar();
            Dictionary<string,object> parametros = new Dictionary<string, object>();
            parametros.Add("@partes",partesId);
            partes.SeleccionarDatos("id=@partes", parametros, "*", BkgEditarParte);
            if(partes.TieneFilas())
            {
                partes.Fila().ModificarCelda("descripcion",Descripcion);
                partes.GuardarDatos();
            }
        }

        private void BkgEditarParte_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Actualizando descripción... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgEditarParte_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Actualización completa!";
            Archivos.Clear();
            BkgDescargarPartes.RunWorkerAsync();
        }

        private void DgvPartes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmElementoModoFalla descripcion = new FrmElementoModoFalla("DESCRIPCION",DgvPartes.SelectedRows[0].Cells["descripcion_partes"].Value.ToString());
            if(descripcion.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                ProgresoDescarga.Visible = true;
                Descripcion = descripcion.Descripcion;
                InicioCarga = Global.MillisegundosEpoch();
                BkgEditarParte.RunWorkerAsync();
            }
        }

        private void DgvSubensamble_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmElementoModoFalla descripcion = new FrmElementoModoFalla("DESCRIPCION", DgvSubensamble.SelectedRows[0].Cells["descripcion_subensamble"].Value.ToString());
            if (descripcion.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                ProgresoDescarga.Visible = true;
                Descripcion = descripcion.Descripcion;
                InicioCarga = Global.MillisegundosEpoch();
                BkgEditarSubensamble.RunWorkerAsync();               
            }
        }

        private void BkgEditarSubensamble_DoWork(object sender, DoWorkEventArgs e)
        {
            int subensambleId = Convert.ToInt32(DgvSubensamble.SelectedRows[0].Cells["ID"].Value);
            SubensambleEstandar subensamble = new SubensambleEstandar();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subensamble", subensambleId);
            subensamble.SeleccionarDatos("id=@subensamble", parametros, "*", BkgEditarSubensamble);
            if (subensamble.TieneFilas())
            {
                subensamble.Fila().ModificarCelda("descripcion", Descripcion);
                subensamble.GuardarDatos();
            }
        }

        private void BkgEditarSubensamble_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Actualizando descripción... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgEditarSubensamble_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Actualización completa!";
            Archivos.Clear();
            EditarSubensamble = true;
            BkgDescargarSubensamble.RunWorkerAsync();         
        }

        private void DgvSubensamble_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvSubensamble.SelectedRows.Count > 0)
            {
                IdSubensamble = Convert.ToInt32(DgvSubensamble.SelectedRows[0].Cells["id"].Value);
                if(!EditarSubensamble)
                    BkgDescargarPartes.RunWorkerAsync();
                else
                    EditarSubensamble = false;  
            }
        }

        private void DgvPartes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
                check = (DataGridViewCheckBoxCell)DgvPartes.Rows[e.RowIndex].Cells["check"];

                switch (check.Value.ToString())
                {
                    case "True":
                        check.Value = false;
                        IdParteLista.Remove(Convert.ToInt32(DgvPartes.Rows[e.RowIndex].Cells["id_partes"].Value));
                        break;
                    case "False":
                        check.Value = true;
                        IdParteLista.Add(Convert.ToInt32(DgvPartes.Rows[e.RowIndex].Cells["id_partes"].Value));
                        break;
                }
                DgvPartes.EndEdit();
            }
        }

        private void exportarPartesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(IdParteLista.Count > 0)
            {
                ErrorExportar = false;
                ArchivosDuplicados = "";

                if(FolderDir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BkgExportarParte.RunWorkerAsync();
                    ProgresoDescarga.Visible = true;
                    InicioCarga = Global.MillisegundosEpoch();
                }
            }
            else
                MessageBox.Show("Debe seleccionar una parte estandar", "No seleccionó parte estandar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BkgExportarParte_DoWork(object sender, DoWorkEventArgs e)
        {
            string directorio = FolderDir.SelectedPath;
            if (!directorio.EndsWith(@"\MP"))
            {
                MessageBox.Show("Debe seleccionar la carpeta MP para poder exportar las partes estandar", "Se requiere la carpeta MP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ErrorExportar = true;
                return;
            }

            ParteEstandar parteEstandar = new ParteEstandar();
            int indice = 0;
            foreach (int item in IdParteLista)
            {
                string[] buscarCarpetas = Directory.GetDirectories(directorio).ToArray();
                if (!Array.Exists(buscarCarpetas, x => x == (@"\" + IdSubensamble.ToString().PadLeft(4, '0'))))
                    Directory.CreateDirectory(directorio + @"\" + "MP-" + IdSubensamble.ToString().PadLeft(4, '0'));
                
                parteEstandar.CargarDatos(item);
                if (parteEstandar.TieneFilas())
                {
                    string nombreArchivo = directorio + @"\" + "MP-" + IdSubensamble.ToString().PadLeft(4, '0');
                    if (!Directory.Exists(nombreArchivo))
                        Directory.CreateDirectory(nombreArchivo);

                    string newPath = nombreArchivo + @"\" + parteEstandar.Fila().Celda("nombre_archivo");
                    if (!File.Exists(newPath))
                        File.WriteAllBytes(newPath, (byte[])parteEstandar.Fila().Celda("archivo"));
                    else
                        ArchivosDuplicados += parteEstandar.Fila().Celda("nombre_archivo").ToString() + "\r\n";
                }
                indice++;
                BkgExportarParte.ReportProgress(Global.CalcularPorcentaje(indice, IdParteLista.Count));
            }    
        }

        private void BkgExportarParte_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Exportando partes estandar... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgExportarParte_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Partes estandar exportadas!";
            IdParteLista.Clear();

            if (ArchivosDuplicados != "")
                MessageBox.Show("Los siguientes archivos ya existen:\r\n" + ArchivosDuplicados, "Archivos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            for (int i = 0; i < DgvPartes.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)DgvPartes.Rows[i].Cells["check"];

                cell.Value = false;
            }
        }

        private void BkgExportarSub_DoWork(object sender, DoWorkEventArgs e)
        {
            string directorio = FolderDir.SelectedPath;
            string subensambleRepetido = "";
            string partesRepetidas = "";

            int indice = 0;
            SubensambleEstandar SubensambleEstandar = new SubensambleEstandar();
            ParteEstandar parte = new ParteEstandar();

            foreach (DataGridViewRow item in DgvSubensamble.SelectedRows)
            {               
                string[] buscarCarpetas = Directory.GetDirectories(directorio).ToArray();
                if (!Array.Exists(buscarCarpetas, x => x == (@"\" + (item.Cells["ID"].Value).ToString().PadLeft(4, '0'))))
                    Directory.CreateDirectory(directorio + @"\" + "MP-" + (item.Cells["ID"].Value).ToString().PadLeft(4, '0'));
                 
                SubensambleEstandar.CargarDatos(Convert.ToInt32(item.Cells["ID"].Value));

                if (SubensambleEstandar.TieneFilas())
                {
                    // se crea la carpeta con el id del subensamble
                    string nombreSubensamble = directorio + @"\" + "MP-" + (item.Cells["ID"].Value).ToString().PadLeft(4, '0');
                    if (!Directory.Exists(nombreSubensamble))
                        Directory.CreateDirectory(nombreSubensamble);

                    //se guarda el subensamble
                    if (!File.Exists(nombreSubensamble + @"\" + SubensambleEstandar.Fila().Celda("nombre_archivo").ToString()))
                        File.WriteAllBytes(nombreSubensamble + @"\" + SubensambleEstandar.Fila().Celda("nombre_archivo").ToString(), (byte[])SubensambleEstandar.Fila().Celda("archivo"));
                    else
                        subensambleRepetido += SubensambleEstandar.Fila().Celda("nombre_archivo").ToString() + "\r\n";
                    
                    Dictionary<string, object> parametrosParte = new Dictionary<string, object>();
                    parametrosParte.Add("@subensamble", item.Cells["ID"].Value);

                    //partes del subensamble
                    ParteEstandar.Modelo().SeleccionarDatos("subensamble=@subensamble", parametrosParte).ForEach(delegate(Fila partes)
                    {
                        string nombreArchivo = directorio + @"\" + "MP-" + (item.Cells["ID"].Value).ToString().PadLeft(4, '0');
                        if (!Directory.Exists(nombreArchivo))
                            Directory.CreateDirectory(nombreArchivo);

                        string newPath = nombreArchivo + @"\" + partes.Celda("nombre_archivo");
                        if (!File.Exists(newPath))
                            File.WriteAllBytes(newPath, (byte[])partes.Celda("archivo"));
                        else
                            partesRepetidas += partes.Celda("nombre_archivo").ToString() + "\r\n";
                    });
                    
                    indice++;
                    if (subensambleRepetido != "")
                        ArchivosDuplicados = "Ensamble(s):\r\n" + subensambleRepetido;
                    if (partesRepetidas != "")
                        ArchivosDuplicados += "Parte(s):\r\n" + partesRepetidas;

                    BkgExportarSub.ReportProgress(Global.CalcularPorcentaje(indice, DgvSubensamble.SelectedRows.Count));
                }
            }   
        }

        private void BkgExportarSub_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Exportando partes estandar... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgExportarSub_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            LblEstatus.Text = "Partes estandar exportadas!";

            if (ArchivosDuplicados != "")
                MessageBox.Show("Los siguientes archivos ya existen:\r\n" + ArchivosDuplicados, "Archivos duplicados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportarSubensambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorExportar = false;
            ArchivosDuplicados = "";

            if (FolderDir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string directorio = FolderDir.SelectedPath;
                if (!directorio.EndsWith(@"\MP"))
                {
                    MessageBox.Show("Debe seleccionar la carpeta MP.", "Se requiere la carpeta MP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ErrorExportar = true;
                    return;
                }
                else
                {
                    BkgExportarSub.RunWorkerAsync();
                    ProgresoDescarga.Visible = true;
                    InicioCarga = Global.MillisegundosEpoch();
                }
            }
        }
    }
}
