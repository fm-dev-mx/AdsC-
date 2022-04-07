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
    public partial class FrmSelecProveedoresFabricacion : Form
    {
        public List<Fila> Proveedores = new List<Fila>();
        public bool Recotizar = false;

        public FrmSelecProveedoresFabricacion(string titulo="SELECCIONAR PROVEEDORES DE FABRICACION")
        {
            InitializeComponent();
            LblTitulo.Text = titulo;
            CargarProveedores();
        }

        public void CargarProveedores()
        {
            DgvProveedores.Rows.Clear();
            Proveedor.Modelo().Fabricacion().ForEach(delegate(Fila prov)
            {
                DgvProveedores.Rows.Add(false, prov.Celda("id"), prov.Celda("nombre"));
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCotizar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selec in DgvProveedores.Rows)
            {
                if (Convert.ToBoolean(selec.Cells["seleccion"].Value) == true)
                {
                    int id = Convert.ToInt32(selec.Cells["id_proveedor"].Value);

                    Proveedor prov = new Proveedor();
                    prov.CargarDatos(id);
                    Proveedores.Add(prov.Fila());
                }
            }

            if (Proveedores.Count == 0)
            {
                LblError.Visible = true;
                LblError.Text = "Selecciona al menos 1 proveedor.";
            }
            else
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("Continuar con los proveedores seleccionados?", "Seleccionar proveedores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    Proveedores.Clear();
            } 
        }

    }
}
