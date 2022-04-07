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
    public partial class FrmAsignarPrivilegio : Form
    {

        public int PrivilegioSeleccionado = 0;

        public FrmAsignarPrivilegio()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            if (DgvPrivilegios.SelectedRows.Count > 0)
                PrivilegioSeleccionado = Convert.ToInt32(DgvPrivilegios.SelectedRows[0].Cells[0].Value);

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void CargarCategorias()
        {
            CmbCategorias.Items.Clear();

            Privilegio.Modelo().Categorias().ForEach(delegate(Fila categoria)
            {
                CmbCategorias.Items.Add(categoria.Celda("categoria").ToString());
            });
        }

        public void CargarPrivilegios(string categoria)
        {
            DgvPrivilegios.Rows.Clear();

            Privilegio.Modelo().SeleccionarDeCategoria(categoria).ForEach(delegate(Fila privilegio)
            {
                DgvPrivilegios.Rows.Add( Convert.ToInt32(privilegio.Celda("id")), privilegio.Celda("privilegio").ToString() );
            });
        }

        private void FrmAsignarPrivilegio_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
                CargarPrivilegios(CmbCategorias.Text);
                BtnAsignar.Enabled = false;
        }

        private void DgvPrivilegios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAsignar.Enabled = true;
        }
    }
}
