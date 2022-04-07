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
    public partial class FrmDesvincularProveedorFavorito : Form
    {
        MaterialProyecto Material;
        public FrmDesvincularProveedorFavorito(MaterialProyecto material, string proveedor)
        {
            InitializeComponent();
            Material = material;
            TxtProveedor.Text = proveedor;
            
        }

        private void FrmConsultarCostoEstimadoRfq_Load(object sender, EventArgs e)
        {
            TxtNumeroParte.Text = Material.Fila().Celda("numero_parte").ToString();
            CargarMaterial();
        }

        private void CargarMaterial()
        {
            Material.Filas().ForEach(delegate(Fila f)
            {
                DgvRequisiciones.Rows.Add
                (
                    false,
                    f.Celda("id"),
                    f.Celda("total"),
                    Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                    f.Celda("requisitor"),
                    Global.FechaATexto(f.Celda("fecha_creacion"), true),
                    f.Celda("estatus_compra")
                );
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea desvincular las requisiciones seleccionadas?", "Desvincular requisiciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                int materialDesvinculado = 0;
                foreach (DataGridViewRow row in DgvRequisiciones.Rows)
                {
                    if((bool)row.Cells["seleccionRequisicion"].Value)
                    {
                        MaterialProyecto desvincularMaterial = new MaterialProyecto();
                        desvincularMaterial.CargarDatos(Convert.ToInt32(row.Cells["idRequisicionCompra"].Value));

                        MaterialProyecto.Modelo().SeleccionarProveedorPreferido(desvincularMaterial, 0);
                        materialDesvinculado++;
                    }
                }

                if (materialDesvinculado > 0)
                {
                    MessageBox.Show("Las requisiciones seleccionadas fueron desvinculadas correctamente", "Requisiciones desvinculadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                    MessageBox.Show("Para desvincular un material debe indicar qué requisición desea modificar", "Requisiciones desvinculadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }

        private void BtnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRequisiciones.Rows)
            {
                row.Cells["seleccionRequisicion"].Value = true;             
            }
        }

        private void BtnSeleccionarNada_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvRequisiciones.Rows)
            {
                row.Cells["seleccionRequisicion"].Value = false;
            }
        }
    }
}
