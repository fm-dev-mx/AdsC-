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
using System.IO;

namespace CB
{
    public partial class FrmVisorPDF : Form
    {
        byte[] datos;
        string nombre;

        public FrmVisorPDF(byte[] datos, string nombre)
        {
            InitializeComponent();
            this.datos = datos;
            this.nombre = nombre;
        }

        private void FrmVisorPDF_Load(object sender, EventArgs e)
        {
            Global.MostrarPDF(datos, nombre, null, VisorPDF);
            Text = nombre + ".pdf";
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (datos == null)
            {
                MessageBox.Show("Favor de generar el documento pdf", "Generar documento pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Global.MostrarPDFWebBrowser(datos,"GENERAL", nombre);
        }

        private void FrmVisorPDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            //BORRAR DESARGAS
            string pathDescargas = Directory.GetCurrentDirectory() + "//IMPRIMIR//GENERAL";
            if (Directory.Exists(pathDescargas))
                Directory.Delete(pathDescargas, true);
        }
    }
}
