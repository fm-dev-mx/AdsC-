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
    public partial class FrmRegistrarVariante : Form
    {
        ProductoComponente ComponenteSeleccionado = new ProductoComponente();
        BindingSource ModelosSource = new BindingSource();
        string NombreAnterior = "";
        int IdComponente = 0;
        int IdProducto = 0;

        public FrmRegistrarVariante(int idProducto, int idComponente)
        {
            IdComponente = idComponente;
            IdProducto = idProducto;
            ComponenteSeleccionado.CargarDatos(idComponente);
            InitializeComponent();
        }

        private void FrmRegistrarVariante_Load(object sender, EventArgs e)
        {
            if(!ComponenteSeleccionado.TieneFilas())
            {
                Close();
                return;
            }
            TxtComponente.Text = ComponenteSeleccionado.Fila().Celda("nombre").ToString();

            ProductoModelo modelos = new ProductoModelo();
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@producto", IdProducto);
            parametros.Add("@componente", IdComponente);
            modelos.SeleccionarDatos("producto = @producto and id not in (select modelo_variante from producto_variantes where componente = @componente)", parametros);
            
            if(!modelos.TieneFilas())
            {
                return;
            }

            modelos.Filas().ForEach(delegate(Fila modelo) {
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

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Fila variante = new Fila();
            variante.AgregarCelda("numero_parte_variante", TxtNombre.Text);
            variante.AgregarCelda("modelo_variante", CmbModelo.SelectedValue);
            variante.AgregarCelda("componente", IdComponente);
            variante.AgregarCelda("grupo_geometria", 0);
            ProductoVariante.Modelo().Insertar(variante);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CmbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularNuevoNombre();
            ActivarBoton();
        }

        private void CalcularNuevoNombre()
        {
            dynamic d = CmbModelo.SelectedItem;

            string nuevoNombre = TxtComponente.Text + "-" + d.Text.ToString();
            if(TxtNombre.Text.Trim() == "" || TxtNombre.Text.TrimStart().TrimEnd() == NombreAnterior.TrimStart().TrimEnd())
            {
                TxtNombre.Text = nuevoNombre;
            }
            NombreAnterior = nuevoNombre;
            this.ActiveControl = TxtNombre;
            TxtNombre.Focus();
        }

        private void ActivarBoton()
        {
            BtnAceptar.Enabled = CmbModelo.Text.Trim() != "" && TxtNombre.Text.Trim() != "";
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ActivarBoton();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
