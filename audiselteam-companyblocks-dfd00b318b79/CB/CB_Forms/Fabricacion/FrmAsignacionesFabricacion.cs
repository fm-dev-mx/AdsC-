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
    public partial class FrmAsignacionesFabricacion : Ventana
    {
        public FrmAsignacionesFabricacion()
        {
            InitializeComponent();
        }

        private void FrmAsignacionesFabricacion_Load(object sender, EventArgs e)
        {
            CargarAsignaciones();
        }

        private void CargarAsignaciones()
        {
            DgvAsignaciones.Rows.Clear();
            PlanoProceso procesos = new PlanoProceso();
            procesos.SeleccionarTiempoDeAsignaciones();
            
            procesos.Filas().ForEach(delegate(Fila f)
            {
                TimeSpan tiempoEstimado = TimeSpan.FromHours(Convert.ToDouble(f.Celda("suma_tiempo_estimado")));
                DgvAsignaciones.Rows.Add(
                    f.Celda("id").ToString().PadLeft(3, '0') + " - " + f.Celda("nombre") + " " + f.Celda("paterno"),
                    tiempoEstimado.Days + " días " + tiempoEstimado.Hours + ":" + tiempoEstimado.Minutes + " hr",
                    f.Celda("estatus_ocupacion"));
            });
        }

        private void LblMaterial_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvAsignaciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvAsignaciones.Rows[e.RowIndex].Cells["ocupacion"].Value.ToString();

            if (estatus == "DESOCUPADO")
                DgvAsignaciones.Rows[e.RowIndex].Cells["ocupacion"].Style.BackColor = Color.Gold;
        }
    }
}
