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
    public partial class FrmSubirPlanoDXF : Form
    {
        public string NombrePlano;
        public byte[] DatosPlanoDXF;

        public FrmSubirPlanoDXF()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            abrirArchivo.DefaultExt = ".pdf";
            abrirArchivo.Filter = "Archivos DXF (.dxf)|*.dxf";

            if (abrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NombrePlano = abrirArchivo.SafeFileName.Replace(".dxf", "").Replace(".DXF", "");
                DatosPlanoDXF = File.ReadAllBytes(abrirArchivo.FileName);
                TxtArchivo.Text = NombrePlano;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnSubir_Click(object sender, EventArgs e)
        {
            if (TxtArchivo.Text != "")
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                LblInfo.Text = "Selecciona un archivo...";
                LblInfo.Visible = true;
            }
        }
    }
}
