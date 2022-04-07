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
    public partial class FrmSeleccionarRequerimiento : Ventana
    {
        int Modulo = 0;
        bool Desvincular = false;
        public List<int> RequerimientosId = new List<int>();
        public FrmSeleccionarRequerimiento(int idModulo, bool desvincular = false)
        {
            InitializeComponent();
            Modulo = idModulo;
            Desvincular = desvincular;
            if (Desvincular)
                LblTitulo.Text = "DESVINCULAR REQUERIMIENTOS DEL MODULO";
        }

        private void FrmSeleccionarRequerimiento_Load(object sender, EventArgs e)
        {
            CargarRequerimientos();
            HabilitarMenuRequerimiento();
        }

        private void CargarRequerimientos()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvRequerimientos);
            DgvRequerimientos.ClearSelection();
            Modulo modulo = new Modulo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", Modulo);

            modulo.SeleccionarDatos("id=@modulo", parametros);
            if (modulo.TieneFilas())
            {
                Dictionary<string, object> parametrosModulo = new Dictionary<string, object>();
                parametrosModulo.Add("@proyecto", Convert.ToDecimal(modulo.Fila().Celda("proyecto").ToString()));

                Requerimiento requerimiento = new Requerimiento();
                string query = "";
                if (!Desvincular)
                    query = "proyecto=@proyecto AND modulo=0";
                else
                {
                    parametrosModulo.Add("@modulo", Modulo);
                    query = "proyecto=@proyecto AND modulo=@modulo";
                }

                requerimiento.SeleccionarDatos(query, parametrosModulo).ForEach(delegate(Fila f)
                {
                    DgvRequerimientos.Rows.Add(false,f.Celda("id").ToString(), f.Celda("nombre").ToString(), f.Celda("descripcion").ToString(), f.Celda("origen").ToString(), f.Celda("estatus").ToString(), f.Celda("nivel_revision").ToString(), f.Celda("estatus_revision").ToString());
                });
            }
            ConfiguracionDataGridView.Recuperar(cfg, DgvRequerimientos);
        }

        private bool HabilitarSeleccionarTodos()
        {
            bool habilitar = true;
            foreach (DataGridViewRow row in DgvRequerimientos.Rows)
            {
                if (row.Cells[0].Value.ToString().ToLower() != "true")
                {
                    habilitar = true;
                    return habilitar;
                }
            }

            if (DgvRequerimientos.Rows.Count > 0)
                return false;
            else
                return false;
        }

        private bool HabilitarSeleccionarNada()
        {
            bool habilitar = true;
            foreach (DataGridViewRow row in DgvRequerimientos.Rows)
            {
                if (row.Cells[0].Value.ToString().ToLower() != "false")
                {
                    habilitar = true;
                    return habilitar;
                }
            }

            if (DgvRequerimientos.Rows.Count > 0)
                return false;
            else
                return false;
        }

        private void HabilitarMenuRequerimiento()
        {
            seleccionarTodoToolStripMenuItem.Enabled = HabilitarSeleccionarTodos();
            seleccionarTodoToolStripMenuItem.Visible = HabilitarSeleccionarTodos();
            seleccionarNadaToolStripMenuItem.Enabled = HabilitarSeleccionarNada();
            seleccionarNadaToolStripMenuItem.Visible = HabilitarSeleccionarNada();
        }

        private void DgvRequerimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
                check = (DataGridViewCheckBoxCell)DgvRequerimientos.Rows[e.RowIndex].Cells[0]; 

                if (check.Value == null)
                    check.Value = false;
                switch (check.Value.ToString())
                {
                    case "True":
                        check.Value = false;
                        if (RequerimientosId.Count > 0)
                            RequerimientosId.Remove(Convert.ToInt32(DgvRequerimientos.Rows[e.RowIndex].Cells[1].Value));
                        break;
                    case "False":
                        check.Value = true;
                        RequerimientosId.Add(Convert.ToInt32(DgvRequerimientos.Rows[e.RowIndex].Cells[1].Value));
                        break;
                }
                DgvRequerimientos.EndEdit();
                HabilitarMenuRequerimiento();
            }                      
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRequerimientos.Rows)
            {
                row.Cells[0].Value = true;
                if (!RequerimientosId.Exists(x => x == Convert.ToInt32(Convert.ToInt32(row.Cells[1].Value))))
                    RequerimientosId.Add(Convert.ToInt32(row.Cells[1].Value));
            }
        }

        private void seleccionarNadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRequerimientos.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = false;
                if (RequerimientosId.Exists(x => x == Convert.ToInt32(Convert.ToInt32(row.Cells[1].Value))))
                    RequerimientosId.Remove(Convert.ToInt32(row.Cells[1].Value));
            }
        }

        private void DgvRequerimientos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;
                    HabilitarMenuRequerimiento();
                    MenuSeleccion.Show(mouseX, mouseY);
                    
                }
            }
        }

        private void DgvRequerimientos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int mouseX = Cursor.Position.X;
                int mouseY = Cursor.Position.Y;
                HabilitarMenuRequerimiento();
                MenuSeleccion.Show(mouseX, mouseY);
            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (RequerimientosId.Count <= 0)
                MessageBox.Show("Debe seleccionar por lo menos un requerimiento", "No se han seleccionado requerimirntos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (RequerimientosId.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("Los requerimientos seleccionados no se guardarán, ¿Desea guardar los requerimientos seleccionados?", "Requerimientos no guardados", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (respuesta == DialogResult.Yes)
                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                if (respuesta == DialogResult.No)
                    DialogResult = System.Windows.Forms.DialogResult.No;
            }
            else
                DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void DgvRequerimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmDetallesRequerimiento detalles = new FrmDetallesRequerimiento(Convert.ToInt32(DgvRequerimientos.SelectedRows[0].Cells[0].Value));
            detalles.ShowDialog();

        }


    }
}
