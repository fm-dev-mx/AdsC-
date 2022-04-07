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
using System.Threading;

namespace CB
{
    public partial class FrmOrdenarCarpetasSolid : Form
    {
        SolidWorksAPI SW;
        public FrmOrdenarCarpetasSolid()
        {
            InitializeComponent();
        }

        private void FrmOrdenarCarpetasSolid_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal proytecto = Convert.ToDecimal("39.02");
            string proyectoPath = string.Empty;
            List<int> subensamble = new List<int>();

            if (SW == null)
                SW = new SolidWorksAPI();

            //Pedimos al usuario que seleccione el directorio para agarra el path
            if (FolderBrowserProyecto.ShowDialog() == DialogResult.OK)
                proyectoPath = FolderBrowserProyecto.SelectedPath;
            else
                return;

            
            subensamble = SW.EnlistarSubensambles(proyectoPath);
            string subensamblePath = SW.CrearCarpetasSubensamble(subensamble, "C:\\Users\\Eilean Laborde\\Desktop\\M039_02-PGO", proytecto);
            foreach (string carpeta in "PP, MP, CP".Split(','))
            {
                SW.copiarArchivos("C:\\Users\\Eilean Laborde\\Desktop\\M039_02-PGO", subensamblePath, carpeta);
            }
            
            string[] archivosEnDirectorio = Directory.GetFiles(subensamblePath);
            string pathOriginalEnsamble = Array.Find(archivosEnDirectorio, archivo => archivo.ToUpper().EndsWith("SLDASM") && Path.GetFileName(archivo).Count(x => x == '-') == 1 && archivo.Contains("-00."));
            string[] listaSbsensambleDirectorios = Directory.GetDirectories(subensamblePath);
            BuscarArchivos(proyectoPath, subensamblePath);
           
        }

        public void BuscarArchivos(string pathOriginalEnsamble, string pathDirectorioSubensamble)
        {
            string[] archivosEnDirectorio = Directory.GetFiles(pathDirectorioSubensamble);
            string pathEnsamble = Array.Find(archivosEnDirectorio, archivo => archivo.ToUpper().EndsWith("SLDASM") && 
                Path.GetFileName(archivo).Count(x => x == '-') == 1 && archivo.Contains("-00."));
            string pathEnsambleOriginal = pathOriginalEnsamble + "\\" + Path.GetFileName(pathEnsamble);
            string[] ListaDeSubensambleS = Directory.GetDirectories(pathDirectorioSubensamble);
            var modelo = SW.CargarModelo(pathEnsamble);
            List<string> subensambleSub = new List<string>();

            if (modelo == null)
                return;

            foreach (string subensamblePath in ListaDeSubensambleS)
            {
                string[] archivosSubensamble = Directory.GetFiles(subensamblePath);
                foreach (string subensamble in archivosSubensamble)
                    SW.testReemplazarComponente(modelo, pathEnsamble, Path.GetFileName(subensamble), subensamble);               
            }
            SW.cerrarModelo(modelo);

            foreach (string subensamblePath in ListaDeSubensambleS)
            {
                if (SW == null)
                    SW = new SolidWorksAPI();

                string[] archivosSubensamble = Directory.GetFiles(subensamblePath);
                string subensamblePrincipal = Array.Find(archivosSubensamble, subensamble => subensamble.ToUpper().EndsWith("SLDASM"));
                var modeloPartes = SW.CargarModelo(subensamblePrincipal);

                if (modeloPartes != null)
                {
                    SW.partesTestReemplazarComponente(modeloPartes, subensamblePrincipal, subensamblePath);
                    SW.cerrarModelo(modeloPartes);
                }               
            }
        }
    }
}
