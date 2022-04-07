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
    public partial class FrmBuscadorMaterialDescripcion2 : Form
    {
        public string IdMaterial;

        public FrmBuscadorMaterialDescripcion2()
        {
            InitializeComponent();
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarMaterial("TODOS", "TODOS", "TODOS", TxtFiltro.Text);
        }

        void CargarMaterial(string categoria = "TODOS", string subcategoria = "TODOS", string fabricante = "TODOS", string filtro = "")
        {
            int fila = Global.GuardarFilaSeleccionada(DgvMaterial);

            DgvMaterial.Rows.Clear();
            CatalogoMaterial.Modelo().Seleccionar(categoria, subcategoria, fabricante, filtro).ForEach(delegate(Fila material)
            {
                DgvMaterial.Rows.Add(material.Celda("id"), Global.CrearNumeroParteAudisel(Convert.ToInt32(material.Celda("id"))), material.Celda("numero_parte"), material.Celda("fabricante"), material.Celda("descripcion"));
            });

            Global.RecuperarFilaSeleccionada(DgvMaterial, fila);
        }

        private void DgvMaterial_SelectionChanged(object sender, EventArgs e)
        {
            if(DgvMaterial.SelectedRows.Count > 0 && DgvMaterial.SelectedRows[0] != null)
            {
                BtnBuscar.Enabled = true;
            }
            else 
            {
                BtnBuscar.Enabled = false;                
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            IdMaterial = (DgvMaterial.SelectedRows[0].Cells["id"].Value.ToString());
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
