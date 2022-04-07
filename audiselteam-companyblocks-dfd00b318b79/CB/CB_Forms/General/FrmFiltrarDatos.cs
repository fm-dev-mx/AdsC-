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
    public partial class FrmFiltrarDatos : Ventana
    {
        public List<Filtro> 
            Filtros = new List<Filtro>();

        public FrmFiltrarDatos(List<Filtro> filtros)
        {
            InitializeComponent();
            Filtros = filtros;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void CargarColumnas()
        {
            CmbColumnas.Items.Clear();

            Filtros.ForEach(delegate(Filtro f)
            {
                CmbColumnas.Items.Add(f.AliasColumna);
            });
        }

        public Filtro SeleccionarFiltro(string aliasColumna)
        {
            Filtro seleccionado = null;

            Filtros.ForEach(delegate(Filtro f)
            {
                if (f.AliasColumna == aliasColumna)
                    seleccionado = f;
            });
            return seleccionado;
        }

        private void CmbColumnas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtro filtro = SeleccionarFiltro(CmbColumnas.Text);

            DgvValores.Rows.Clear();
            foreach(KeyValuePair<object, bool> val in filtro.Valores)
            {
                DgvValores.Rows.Add(Convert.ToBoolean(val.Value), val.Key);
            }
        }

        private void DgvValores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Object valor = DgvValores.Rows[e.RowIndex].Cells["valor"].Value;
            Boolean filtro = Convert.ToBoolean(DgvValores.Rows[e.RowIndex].Cells["filtro"].EditedFormattedValue);

            SeleccionarFiltro(CmbColumnas.Text).ModificarFiltro(valor, filtro);
        }

        private void FrmFiltrarDatos_Load(object sender, EventArgs e)
        {
            CargarColumnas();
        }
        private void LblTituloComponente_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in DgvValores.Rows)
            {
                row.Cells["filtro"].Value = true;
                SeleccionarFiltro(CmbColumnas.Text).ModificarFiltro(row.Cells["valor"].Value, true);
            }
        }

        private void BtnSeleccionarNada_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvValores.Rows)
            {
                row.Cells["filtro"].Value = false;
                SeleccionarFiltro(CmbColumnas.Text).ModificarFiltro(row.Cells["valor"].Value, false);
            }
        }
    }
}
