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
    public partial class FrmSeleccionarCompetencia : Ventana
    {
        int CompetenciasMaximas = 0;
        public List<int> HabilidadesSeleccionadas = new List<int>();

        public FrmSeleccionarCompetencia(int competenciasMaximas =0)
        {
            InitializeComponent();
            CompetenciasMaximas = competenciasMaximas;
        }

        private void SeleccionarCompetencia_Load(object sender, EventArgs e)
        {
            CargarHabilidades();
        }

        public void CargarHabilidades()
        {
            DgvHabilidadesPersonales.Rows.Clear();
            DgvHabilidadesTecnicas.Rows.Clear();

            Habilidad.Modelo().SeleccionarTipo("PERSONAL").ForEach(delegate(Fila f)
            {
                int idHabilidad = Convert.ToInt32(f.Celda("id"));
                DgvHabilidadesPersonales.Rows.Add(idHabilidad, false, f.Celda("habilidad").ToString());
            });

            Habilidad.Modelo().SeleccionarTipo("TECNICA").ForEach(delegate(Fila f)
            {
                int idHabilidad = Convert.ToInt32(f.Celda("id"));
                DgvHabilidadesTecnicas.Rows.Add(idHabilidad, false, f.Celda("habilidad").ToString());
            });
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            int competenciasSeleccionadas = 0;
            HabilidadesSeleccionadas.Clear();

            foreach (DataGridViewRow row in DgvHabilidadesPersonales.Rows)
	        {
                if (Convert.ToBoolean(row.Cells["seleccion"].Value.ToString()))
                {
                    if (!HabilidadesSeleccionadas.Contains(Convert.ToInt32(row.Cells["id"].Value)))
                        HabilidadesSeleccionadas.Add(Convert.ToInt32(row.Cells["id"].Value));
                    competenciasSeleccionadas++;
                }
	        }

            foreach (DataGridViewRow row in DgvHabilidadesTecnicas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["seleccion_tecnicas"].Value.ToString()))
                {
                    if (!HabilidadesSeleccionadas.Contains(Convert.ToInt32(row.Cells["id_habilidad_tecnica"].Value)))
                        HabilidadesSeleccionadas.Add(Convert.ToInt32(row.Cells["id_habilidad_tecnica"].Value));
                    competenciasSeleccionadas++;
                }
            }
            
            if(competenciasSeleccionadas > CompetenciasMaximas)
            {
                MessageBox.Show("Seleccione solamente " + CompetenciasMaximas + " competencias", "Máximo " + CompetenciasMaximas + " competencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (competenciasSeleccionadas <= 0)
            {
                MessageBox.Show("Seleccione por lo menos 1 competencia", "Mínimo 1 competencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblPlanoCargado_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }      
    }
}
