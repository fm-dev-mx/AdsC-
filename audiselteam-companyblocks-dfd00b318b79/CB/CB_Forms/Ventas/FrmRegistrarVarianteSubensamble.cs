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
    public partial class FrmRegistrarVarianteSubensamble : Form
    {
        ProductoSubensamble SubensambleSeleccionado = new ProductoSubensamble();
        BindingSource ModelosSource = new BindingSource();
        int IdSubensamble = 0;
        int IdProducto = 0;

        public FrmRegistrarVarianteSubensamble(int idProducto, int idSubensamble)
        {
            IdSubensamble = idSubensamble;
            IdProducto = idProducto;
            SubensambleSeleccionado.CargarDatos(idSubensamble);
            InitializeComponent();
        }

        private void FrmRegistrarVarianteSubensamble_Load(object sender, EventArgs e)
        {
            if (!SubensambleSeleccionado.TieneFilas())
            {
                Close();
                return;
            }

            ProductoModelo modelos = new ProductoModelo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@producto", IdProducto);
            parametros.Add("@subensamble", IdSubensamble);
            modelos.SeleccionarDatos("producto = @producto and id not in (select id_modelo from prod_subensamble_variante where id_subensamble = @subensamble)", parametros);

            TxtSubensamble.Text = SubensambleSeleccionado.Fila().Celda("nombre").ToString();

            if (!modelos.TieneFilas())
            {
                return;
            }

            modelos.Filas().ForEach(delegate(Fila modelo)
            {
                ModelosSource.Add(new
                {
                    Value = modelo.Celda("id"),
                    Text = modelo.Celda("nombre").ToString()
                });
            });
            CmbModelo.DataSource = ModelosSource;
            CmbModelo.DisplayMember = "Text";
            CmbModelo.ValueMember = "Value";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActivarBoton();
        }

        private void ActivarBoton()
        {
            BtnAceptar.Enabled = CmbModelo.Text.Trim() != "";
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            dynamic d = CmbModelo.SelectedItem;

            Fila variante = new Fila();
            variante.AgregarCelda("id_subensamble", IdSubensamble);
            variante.AgregarCelda("id_modelo", CmbModelo.SelectedValue);
            variante.AgregarCelda("nombre_modelo", d.Text.ToString());
            ProductoSubensambleVariante.Modelo().Insertar(variante);
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
