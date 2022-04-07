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
    public partial class FrmReparadorDiseno : Form
    {
        public FrmReparadorDiseno()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if(BuscadorCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtCarpetaSeleccionada.Text = BuscadorCarpeta.SelectedPath;
            }
        }

        private void FrmReparadorDiseno_Load(object sender, EventArgs e)
        {
            CmbNivel.Text = "MODULO";
        }

        private void BtnReparar_Click(object sender, EventArgs e)
        {
            SolidWorksProyecto swp = new SolidWorksProyecto();

            if(CmbNivel.Text == "MODULO")
            {
                swp.SeleccionarProyectoSubensamble(Convert.ToDecimal(NumProyecto.Value), Convert.ToInt32(NumModulo.Value));
            }
            else if(CmbNivel.Text == "PROYECTO")
            {
                swp.SeleccionarProyecto(Convert.ToDecimal(NumProyecto.Value));
            }
            ArchivoSolidWorks archivo = new ArchivoSolidWorks();
            string patharchivoLocal = string.Empty;
            string checksumMd5 = string.Empty;

            swp.Filas().ForEach(delegate(Fila f)
            {
                patharchivoLocal = TxtCarpetaSeleccionada.Text + f.Celda("nombre_archivo").ToString();
                TxtEstatus.AppendText("Reparando archivo '" + patharchivoLocal + "'..." + Environment.NewLine);

                if(File.Exists(patharchivoLocal))
                {
                    if (CmbNivel.Text == "MODULO")
                        archivo.CargarMetadatos(patharchivoLocal, Path.GetDirectoryName(Path.GetDirectoryName(TxtCarpetaSeleccionada.Text)));
                    else
                        archivo.CargarMetadatos(patharchivoLocal, Path.GetDirectoryName(TxtCarpetaSeleccionada.Text));

                    f.ModificarCelda("checksum_md5", archivo.ChecksumMd5);
                }
            });
            swp.GuardarDatos();
        }
    }
}
