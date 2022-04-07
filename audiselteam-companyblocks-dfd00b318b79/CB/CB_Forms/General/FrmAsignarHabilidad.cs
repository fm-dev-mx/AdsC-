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
    public partial class FrmAsignarHabilidad : Form
    {
        public int HabilidadSeleccionada = 0;
        public FrmAsignarHabilidad()
        {
            InitializeComponent();
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            if (DgvPrivilegios.SelectedRows.Count > 0)
                HabilidadSeleccionada = Convert.ToInt32(DgvPrivilegios.SelectedRows[0].Cells[0].Value);

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void CargarHabilidades(string categoria)
        {
            DgvPrivilegios.Rows.Clear();
            Habilidad.Modelo().SeleccionarTipo(categoria).ForEach(delegate(Fila habilidad)
            {
                DgvPrivilegios.Rows.Add(Convert.ToInt32(habilidad.Celda("id")), habilidad.Celda("habilidad"));
            });
        }

        public void CargarCategorias()
        {
            LblTitulo.Text = "Asignar Privilegio";
            CmbCategorias.Items.Clear();

            Privilegio.Modelo().Categorias().ForEach(delegate(Fila categoria)
            {
                CmbCategorias.Items.Add(categoria.Celda("categoria").ToString());
            });
        }

        private void FrmAsignarHabilidad_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHabilidades(CmbCategorias.Text);
            BtnAsignar.Enabled = false;
            
        }

        private void DgvPrivilegios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAsignar.Enabled = true;
        }
    }
}
