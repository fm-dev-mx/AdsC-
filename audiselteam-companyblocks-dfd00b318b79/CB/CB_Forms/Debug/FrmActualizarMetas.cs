using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;
using System.IO;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmActualizarMetas : Form
    {
        List<string> MetasNoActualizadas = new List<string>();

        public FrmActualizarMetas()
        {
            InitializeComponent();
        }

        private void FrmActualizarMetas_Load(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = false;
        }

        private void ActualizarMetas()
        {
            string[] metas = TxtMetas.Text.Split(',');

            foreach (string id in metas)
            {
                int idMeta = 0;
                if (int.TryParse(id, out idMeta))
                {
                    try
                    {
                        //Actualizar meta
                        Meta.Modelo().ActualizarAvance(idMeta);

                        //Checar que meta esté en 100
                        Meta meta = new Meta();
                        meta.CargarDatos(idMeta);
                        if (meta.TieneFilas())
                        {
                            if (Convert.ToInt32(meta.Fila().Celda("avance")) < 100)
                                MetasNoActualizadas.Add(idMeta.ToString());
                        }
                        else
                            MetasNoActualizadas.Add(idMeta.ToString());
                    }
                    catch
                    {
                        MetasNoActualizadas.Add(idMeta.ToString());
                    }
                }
                else
                    MetasNoActualizadas.Add(id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarMetas();
            if (MetasNoActualizadas.Count > 0)
            {
                MessageBox.Show("No se pudo actualizar " + MetasNoActualizadas.Count + " metas");

                string cuerpo = string.Empty;
                cuerpo += System.Environment.NewLine;
                cuerpo += "***************************************************************" + System.Environment.NewLine;
                cuerpo += "********* METAS NO ACTUALIZADAS  " + DateTime.Now + "*********" + System.Environment.NewLine;
                cuerpo += "***************************************************************" + System.Environment.NewLine;

                foreach (string meta in MetasNoActualizadas)
                    cuerpo += meta + Environment.NewLine;

                string localPath = Directory.GetCurrentDirectory() + "\\SGC\\REPORTES DEBUG";

                if (!Directory.Exists(localPath))
                    Directory.CreateDirectory(localPath);

                File.AppendAllText(localPath + "\\METAS_NO_ACTUALIZADAS.txt", cuerpo);
                System.Diagnostics.Process.Start(localPath + "\\METAS_NO_ACTUALIZADAS.txt");
            }
            else
                MessageBox.Show("Metas actualizadas");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtMetas_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtMetas.Text.Length > 1);
        }
    }
}
