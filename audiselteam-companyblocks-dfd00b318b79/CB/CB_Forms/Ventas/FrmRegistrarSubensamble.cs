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
    public partial class FrmRegistrarSubensamble : Form
    {
        int IdCliente = 0;
        int IdProducto = 0;
        int IdIndustria = 0;
        int CeldasSeleccionadas = 0;
        int IdCotizacion = 0;

        public FrmRegistrarSubensamble(int idProducto, int idCliente, int idIndustria, int idCotizacion)
        {
            InitializeComponent();
            IdCliente = idCliente;
            IdIndustria = idIndustria;
            IdProducto = idProducto;
            IdCotizacion = idCotizacion;

            TxtNombre.Text = "";
        }

        private void FrmSeleccionarComponentes_Load(object sender, EventArgs e)
        {
            CargarIndustria();
            CargarCliente();
            CargarComponentes();
            CargarSubensamble();
        }

        private void CargarIndustria()
        {
            Industria.Modelo().CargarDatos(IdIndustria).ForEach(delegate(Fila f)
            {
                LblIndustria.Text = "Industria: " + f.Celda("nombre").ToString();
            });
        }

        private void CargarCliente()
        {
            Cliente.Modelo().CargarDatos(IdCliente).ForEach(delegate(Fila f)
            {
                LblCliente.Text = "Cliente: " + f.Celda("nombre");
            });
        }

        private void CargarComponentes()
        {
            ProductoComponente componente = new ProductoComponente();
            componente.SeleccionarComponentesParaProducto(IdProducto, IdCotizacion).ForEach(delegate(Fila f)
            {
                DgvComponentes.Rows.Add
                (
                    false,
                    f.Celda<int>("id").ToString().PadLeft(3,'0'),
                    f.Celda("nombre").ToString().TrimStart().TrimEnd(),
                    f.Celda("descripcion").ToString()
                );
            });
        }

        private void CargarSubensamble()
        {
            ProductoSubensamble prodSub = new ProductoSubensamble();
            prodSub.SeleccionarSubensambles(IdProducto, IdCotizacion).ForEach(delegate(Fila f)
            {
                string subensamble = string.Empty;
                {
                    subensamble = "(" + f.Celda("nombre").ToString().TrimStart().TrimEnd() + ") ";
                    DgvSubensamble.Rows.Add
                   (
                       false,
                       f.Celda<int>("id").ToString().PadLeft(3, '0'),
                       subensamble
                   );
                }
            });
        }

        private void DgvComponentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvComponentes.Rows[e.RowIndex].Cells["check"];
            if (chk.Value == chk.TrueValue)
            {
                chk.Value = chk.FalseValue;
                if (CeldasSeleccionadas > 0)
                    CeldasSeleccionadas--;
            }
            else
            {
                chk.Value = chk.TrueValue;
                CeldasSeleccionadas++;
            }

            TxtNombre.Text = calcularNombre();
        }

        private string calcularNombre()
        {
            string nombreSubensmable = string.Empty;

            if (DgvSubensamble.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DgvSubensamble.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["check_subensamble"].Value))
                        nombreSubensmable += row.Cells["subensmable"].Value.ToString() + " + "; 
                }
            }

            foreach (DataGridViewRow row in DgvComponentes.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value))
                    nombreSubensmable += row.Cells["producto"].Value.ToString() + " + ";
            }

            if (nombreSubensmable != "")
                nombreSubensmable = nombreSubensmable.Remove(nombreSubensmable.Length - 2);

            return nombreSubensmable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CeldasSeleccionadas <= 0)
            {
                MessageBox.Show("No se han seleccionado componentes", "No se puede crear el subensamble", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Fila insertarSubensamble = new Fila();
            insertarSubensamble.AgregarCelda("producto", IdProducto);
            insertarSubensamble.AgregarCelda("nombre", calcularNombre());
            insertarSubensamble.AgregarCelda("id_cotizacion", IdCotizacion);
            int idSubensamble = Convert.ToInt32(ProductoSubensamble.Modelo().Insertar(insertarSubensamble).Celda("id"));

            foreach (DataGridViewRow row in DgvComponentes.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value.ToString()))
                {
                    Fila insertarComponentes = new Fila();
                    insertarComponentes.AgregarCelda("id_subensamble", idSubensamble);
                    insertarComponentes.AgregarCelda("id_componente_el", Convert.ToInt32(row.Cells["id"].Value.ToString()));
                    ProductoSubensambleComponente.Modelo().Insertar(insertarComponentes);
                }
            }

            foreach (DataGridViewRow row in DgvSubensamble.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check_subensamble"].Value.ToString()))
                {
                    Fila insertarComponentes = new Fila();
                    insertarComponentes.AgregarCelda("id_subensamble", idSubensamble);
                    insertarComponentes.AgregarCelda("id_subensamble_el", Convert.ToInt32(row.Cells["id_subensamble"].Value.ToString()));
                    ProductoSubensamblesSubensamble.Modelo().Insertar(insertarComponentes);
                }
            }


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void DgvSubensamble_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvSubensamble.Rows[e.RowIndex].Cells["check_subensamble"];
            if (chk.Value == chk.TrueValue)
            {
                chk.Value = chk.FalseValue;
                if (CeldasSeleccionadas > 0)
                    CeldasSeleccionadas--;
            }
            else
            {
                chk.Value = chk.TrueValue;
                CeldasSeleccionadas++;
            }

            TxtNombre.Text = calcularNombre();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
