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
    public partial class FrmCargarProyecto : Form
    {
        public decimal ProyectoCargado;

        public FrmCargarProyecto()
        {
            InitializeComponent();
        }

        public void CargarPrincipales(string filtro, bool mostrarInactivos=false)
        {
            DgvProyectos.Rows.Clear();

            Proyecto prj = new Proyecto();

            foreach(Fila proyecto in prj.Principales(filtro, mostrarInactivos))
            {
                try
                {
                    decimal id = Convert.ToDecimal(proyecto.Celda("id"));
                    string nombre_proyecto = proyecto.Celda("nombre").ToString();
                    string cliente = proyecto.Celda("cliente").ToString();
                    string nombre_contacto = proyecto.Celda("contacto_nombre") + " " + proyecto.Celda("contacto_apellidos");
                    string estatus = "";

                    if (Convert.ToInt32(proyecto.Celda("activo")) == 0)
                        estatus = "TERMINADO";
                    else
                        estatus = "ACTIVO";

                    if (estatus == "ACTIVO" || (estatus == "TERMINADO" && mostrarInactivos))
                        DgvProyectos.Rows.Add(id.ToString("F2"), nombre_proyecto, cliente, nombre_contacto, estatus);
                }
                catch { } 
            }
        }

        private void TxtFiltroProyecto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarPrincipales(TxtFiltroProyecto.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DgvProyectos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProyectoCargado = Convert.ToDecimal(DgvProyectos.SelectedRows[0].Cells[0].Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmAdministrarProyectos_Shown(object sender, EventArgs e)
        {
            CargarPrincipales(TxtFiltroProyecto.Text);
            WindowState = FormWindowState.Maximized;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void ChkMostrarInactivos_CheckStateChanged(object sender, EventArgs e)
        {
            CargarPrincipales(TxtFiltroProyecto.Text, ChkMostrarInactivos.Checked);
        }

        private void ChkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarPrincipales(TxtFiltroProyecto.Text, ChkMostrarInactivos.Checked);
        }

        


        private void menuActivar_Opening(object sender, CancelEventArgs e)
        {
            if (Global.VerificarPrivilegio("PROYECTOS", "ACTIVAR/DESACTIVAR"))
            {
                if ((DgvProyectos.SelectedRows[0].Cells[4].Value).ToString() == "TERMINADO")
                {
                    activarProyectoToolStripMenuItem.Visible = true;
                    desactivarProyectoToolStripMenuItem.Visible = false;
                }
                else
                {
                    activarProyectoToolStripMenuItem.Visible = false;
                    desactivarProyectoToolStripMenuItem.Visible = true;
                }
            }
            else
            {

                if ((DgvProyectos.SelectedRows[0].Cells[4].Value).ToString() == "TERMINADO")
                {
                    activarProyectoToolStripMenuItem.Visible = true;
                    desactivarProyectoToolStripMenuItem.Visible = false;
                    activarProyectoToolStripMenuItem.Enabled = false;
                }
                else
                {
                    activarProyectoToolStripMenuItem.Visible = false;
                    desactivarProyectoToolStripMenuItem.Visible = true;
                    desactivarProyectoToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void activarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvProyectos.SelectedRows.Count <= 0)
                return;
            
            var result = MessageBox.Show("Desea activar este proyecto?", "Activar proyecto",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                decimal idProyecto = Convert.ToDecimal(DgvProyectos.SelectedRows[0].Cells[0].Value);
                string estatus = DgvProyectos.SelectedRows[0].Cells[4].Value.ToString();

                Proyecto prj = new Proyecto();

                if (prj.ActivarDesactivarProyecto(idProyecto, estatus))
                {
                    MessageBox.Show("El proyecto ha sido activado correctamente!!", "Activar proyecto");
                    if (ChkMostrarInactivos.Checked)
                        CargarPrincipales(TxtFiltroProyecto.Text, true);
                    else
                        CargarPrincipales(TxtFiltroProyecto.Text, false);
                }
            }            
        }

        private void desactivarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvProyectos.SelectedRows.Count <= 0)
                return;

            var result = MessageBox.Show("Desea desactivar este proyecto?", "Desactivar proyecto",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                decimal idProyecto = Convert.ToDecimal(DgvProyectos.SelectedRows[0].Cells[0].Value);
                string estatus = DgvProyectos.SelectedRows[0].Cells[4].Value.ToString();

                Proyecto prj = new Proyecto();

                if (prj.ActivarDesactivarProyecto(idProyecto, estatus))
                {
                    MessageBox.Show("El proyecto ha sido desactivado correctamente!!", "Desactivar proyecto");
                    if (ChkMostrarInactivos.Checked)
                        CargarPrincipales(TxtFiltroProyecto.Text, true);
                    else
                        CargarPrincipales(TxtFiltroProyecto.Text, false);
                }                
            }
        }
    }
}
