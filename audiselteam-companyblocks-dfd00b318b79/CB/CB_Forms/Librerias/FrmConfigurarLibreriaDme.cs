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
using SolidWorks.Interop.sldworks;
using System.IO;
using SolidWorks.Interop.swconst;


namespace CB
{
    public partial class FrmConfigurarLibreriaDme : Form
    {
        string PathModelo = string.Empty;//System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\LIBRERIAS\\GUIDED ACTUATORS\\SMC\\MXS8\\MXS8-LIB.sldasm";
        ModelDoc2 Modelo = null;
        SolidWorksAPI SW = null;
        bool CerraForm = false;
        string ConfiguracionSeleccionada = string.Empty;
        swDocumentTypes_e TipoDocumento = swDocumentTypes_e.swDocNONE;
        public List<System.Management.ManagementObject> ProcesosSolidWorks { get; set; }


        public FrmConfigurarLibreriaDme(string @pathModelo)
        {
            InitializeComponent();
            ContenedorPrincipal.Panel1Collapsed = true;
            Size = new Size(400, 611);
            PathModelo = @pathModelo;
        }

        private void FrmLibreriasDisenoMecanico_Load(object sender, EventArgs e)
        {
            // busca procesos que ya esten abiertos
            ProcesosSolidWorks = Global.BuscarProcesos("sldworks");

            if (ProcesosSolidWorks.Count == 0)
            {
                MessageBox.Show("SolidWorks debe estar corriendo para poder usar las librerias de diseño mecánico.", "SolidWorks no está corriendo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CerraForm = true;
                return;
            }
            else
                BkgCargarSolidWorks.RunWorkerAsync();
        }

        public bool CargarModelo()
        {
            Modelo = SW.CargarModelo(PathModelo, true);
            if (Modelo == null)
                return false;
            else
                return true;
        }

        private void BkgCargarSolidWorks_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgCargarSolidWorks.ReportProgress(0, "Conectando con SolidWorks...");
            SW = new SolidWorksAPI();
            BkgCargarSolidWorks.ReportProgress(100, " [OK]" + System.Environment.NewLine);
        }

        private void BkgCargarSolidWorks_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtTerminal.Text += e.UserState.ToString();
        }

        private void BkgCargarSolidWorks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ContenedorPrincipal.Panel1Collapsed = false;
            BkgCargarModelo.RunWorkerAsync();
        }

        private void FrmLibreriasDisenoMecanico_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SW != null)
            {
                TxtTerminal.Text += "Cerrando modelo...";
                SW.Aplicacion.QuitDoc(Path.GetFileName(PathModelo));
                TxtTerminal.Text += " [OK]";
                MessageBox.Show("SolidWorks continuará corriendo, asegúrate de cerrarlo cuando ya no vayas a usarlo.", "Salir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BkgCargarModelo_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgCargarModelo.ReportProgress(0, "Cargando modelo...");
            if (!CargarModelo())
            {
                BkgCargarModelo.ReportProgress(100, " [ERROR]" + System.Environment.NewLine);
                e.Result = false;
            }
            else
            {
                BkgCargarModelo.ReportProgress(100, " [OK]" + System.Environment.NewLine);
                e.Result = true;
            }
        }

        private void BkgCargarModelo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtTerminal.Text += e.UserState.ToString();
        }

        private void BkgCargarModelo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                CargarConfiguraciones();
                MostrarVistaPrevia(swStandardViews_e.swIsometricView);
                string extensionDocumento = Path.GetExtension(PathModelo).ToUpper();

                if (extensionDocumento == ".SLDASM")
                    TipoDocumento = swDocumentTypes_e.swDocASSEMBLY;
                else if (extensionDocumento == ".SLDPRT")
                    TipoDocumento = swDocumentTypes_e.swDocPART;
            }
        }

        private void FrmLibreriasDisenoMecanico_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public void MostrarVistaPrevia(swStandardViews_e tipoVista)
        {
            byte[] vistaPrevia = null;
            SW.VistaPrevia(Modelo, out vistaPrevia, tipoVista);
            var ms = new MemoryStream(vistaPrevia);
            PicVistaPrevia.Image = Image.FromStream(ms);
        }

        private void isometricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaPrevia(swStandardViews_e.swIsometricView);
        }

        private void frontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaPrevia(swStandardViews_e.swFrontView);
        }

        private void inferiorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaPrevia(swStandardViews_e.swBottomView);
        }

        private void superiorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaPrevia(swStandardViews_e.swTopView);
        }

        private void posteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaPrevia(swStandardViews_e.swBackView);
        }

        private void izquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaPrevia(swStandardViews_e.swLeftView);
        }

        private void derechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaPrevia(swStandardViews_e.swRightView);
        }

        public void CargarConfiguraciones()
        {
            string[] configuraciones = null;

            configuraciones = (string[])Modelo.GetConfigurationNames();

            CmbConfiguracion.Items.Clear();
            for (int i = 0; i<configuraciones.Length; i++)
            {
                CmbConfiguracion.Items.Add((string)configuraciones[i]);
            }
            CmbConfiguracion.Enabled = true;
            DgvTipoAccesorio.Rows.Clear();
        }

        private void CmbConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbConfiguracion.Enabled = false;
            ConfiguracionSeleccionada = CmbConfiguracion.Text;
            BkgMostrarConfiguracion.RunWorkerAsync();
        }

        private void BkgMostrarConfiguracion_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgMostrarConfiguracion.ReportProgress(0, "Cargando configuracion '" + ConfiguracionSeleccionada + "'... ");
            Modelo.ShowConfiguration(ConfiguracionSeleccionada);
            MostrarVistaPrevia(swStandardViews_e.swIsometricView);
            BkgMostrarConfiguracion.ReportProgress(100, " [OK]" + System.Environment.NewLine);
        }

        private void BkgMostrarConfiguracion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtTerminal.Text += e.UserState.ToString();
        }

        private void BkgMostrarConfiguracion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbConfiguracion.Enabled = true;

            if (TipoDocumento == swDocumentTypes_e.swDocASSEMBLY)
            {
                CargarTiposAccesorios();
            }
        }

        public void CargarTiposAccesorios()
        {
            // buscamos la carpeta de accesorios, si no existe abortamos...
            AssemblyDoc ensamble = (AssemblyDoc)Modelo;
            Feature feature = ensamble.FeatureByName("ACCESSORIES");

            if (feature == null)
                return;
            
            // cambiamos el tamanio del form para que se vea la lista de accesorios
            Size = new Size(800, 611);

            // creamos un objeto para el folder de accesorios
            FeatureFolder folderAccesorios = feature.GetSpecificFeature2();

            object[] foldersTiposAccesorios = (object[])folderAccesorios.GetFeatures();

            CmbTipoAccesorio.Items.Clear();
            foreach (Feature tipoAccesorio in foldersTiposAccesorios)
            {
                CmbTipoAccesorio.Items.Add(tipoAccesorio.Name);
            }
            CmbTipoAccesorio.Enabled = true;
        }

        private void CmbTipoAccesorio_SelectedIndexChanged(object sender, EventArgs e)
        {  
            // buscamos la carpeta de accesorios, si no existe abortamos...
            AssemblyDoc ensamble = (AssemblyDoc)Modelo;
            Feature feature = ensamble.FeatureByName(CmbTipoAccesorio.Text);
        

            // creamos un objeto para el folder
            FeatureFolder folder = feature.GetSpecificFeature2();

            object[] accesorios = (object[])folder.GetFeatures();

            DgvTipoAccesorio.Rows.Clear();
            foreach (Feature accesorio in accesorios)
            {
                accesorio.Select(false);
                Modelo.EditSuppress2();
                DgvTipoAccesorio.Rows.Add(accesorio, false, accesorio.Name);
            }
            MostrarVistaPrevia(swStandardViews_e.swIsometricView);
        }

        private void DgvTipoAccesorio_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == seleccionAccesorio.Index && e.RowIndex != -1)
            {
                DgvTipoAccesorio.EndEdit();
            }
        }

        private void DgvTipoAccesorio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Feature componenteSeleccionado = null;

            if (e.ColumnIndex == seleccionAccesorio.Index && e.RowIndex != -1)
            {
                componenteSeleccionado = (Feature)(DgvTipoAccesorio[idAccesorio.Index, e.RowIndex].Value);
                componenteSeleccionado.Select(false);

                if ((bool)DgvTipoAccesorio[e.ColumnIndex, e.RowIndex].EditedFormattedValue)
                {
                    Modelo.EditUnsuppress2();
                }
                else
                {
                    Modelo.EditSuppress2();
                }
                MostrarVistaPrevia(swStandardViews_e.swIsometricView);
            }
        }

        private void FrmConfigurarLibreriaDme_Shown(object sender, EventArgs e)
        {
            if (CerraForm)
                Close();
        }
    }
}
