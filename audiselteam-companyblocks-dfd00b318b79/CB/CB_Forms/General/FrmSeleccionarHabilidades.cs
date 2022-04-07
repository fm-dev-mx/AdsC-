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

namespace CB
{
    public partial class FrmSeleccionarHabilidades : Ventana
    {
        string Tipo = string.Empty;
        public List<int> HabilidadesSeleccionadas = new List<int>();

        public FrmSeleccionarHabilidades(string tipo, List<int> habilidadesSeleccionadas=null)
        {
            InitializeComponent();
            Tipo = tipo;

            if(habilidadesSeleccionadas != null)
                HabilidadesSeleccionadas = habilidadesSeleccionadas;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void CargarHabilidades()
        {
            DgvHabilidades.Rows.Clear();
            Habilidad.Modelo().SeleccionarTipo(Tipo).ForEach(delegate(Fila f)
            {
                int idHabilidad = Convert.ToInt32(f.Celda("id"));
                bool habilidadSeleccionada = false;
                
                if(HabilidadesSeleccionadas != null)
                    habilidadSeleccionada = HabilidadesSeleccionadas.Contains(idHabilidad);

                DgvHabilidades.Rows.Add(idHabilidad, habilidadSeleccionada, f.Celda("habilidad").ToString());
            });
        }

        private void LblPlanoCargado_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmSeleccionarHabilidades_Load(object sender, EventArgs e)
        {
            CargarHabilidades();
        }

        private void DgvHabilidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Object valor = DgvHabilidades.Rows[e.RowIndex].Cells["seleccion"].Value;
            int idHabilidad = Convert.ToInt32(DgvHabilidades.Rows[e.RowIndex].Cells["id"].Value);
            Boolean seleccionHabilidad = Convert.ToBoolean(DgvHabilidades.Rows[e.RowIndex].Cells["seleccion"].EditedFormattedValue);

            if(seleccionHabilidad)
            {
                if(!HabilidadesSeleccionadas.Contains(idHabilidad))
                {
                    HabilidadesSeleccionadas.Add(idHabilidad);
                }
            }
            else if(HabilidadesSeleccionadas.Contains(idHabilidad))
            {
                HabilidadesSeleccionadas.Remove(idHabilidad);
            }
        }
    }
}
