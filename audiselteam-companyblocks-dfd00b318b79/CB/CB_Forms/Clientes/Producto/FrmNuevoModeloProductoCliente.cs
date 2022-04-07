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
    public partial class FrmNuevoModeloProductoCliente : Ventana
    {
        int IdProducto = 0;
        int IdModelo = 0;
        ClienteProductoModelo Modelo = new ClienteProductoModelo();

        public FrmNuevoModeloProductoCliente(int idProducto, int idModelo=0)
        {
            InitializeComponent();
            IdProducto = idProducto;
            IdModelo = idModelo;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmNuevoModeloProductoCliente_Load(object sender, EventArgs e)
        {
            CargarFamilias();
            if(IdModelo > 0)
            {
                LblTitulo.Text = "EDITAR MODELO";
                Modelo.CargarDatos(IdModelo);
                CmbFamilia.Text = Global.ObjetoATexto(Modelo.Fila().Celda("familia"), "N/A");
                TxtNombre.Text = Global.ObjetoATexto(Modelo.Fila().Celda("modelo"), "N/A");
                BtnCrear.Text = "Guardar";
            }
        }

        public void CargarFamilias()
        {
            CmbFamilia.Items.Clear();
            ClienteProductoModelo.Modelo().Familias(IdProducto).ForEach(delegate(Fila f)
            {
                CmbFamilia.Items.Add(f.Celda("familia"));
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            if(Modelo.TieneFilas())
            {
                Modelo.Fila().ModificarCelda("familia", CmbFamilia.Text);
                Modelo.Fila().ModificarCelda("modelo", TxtNombre.Text);
                Modelo.GuardarDatos();
            }
            else
            {
                if (ClienteProductoModelo.Modelo().Existe(IdProducto, CmbFamilia.Text, TxtNombre.Text))
                {
                    MessageBox.Show("El modelo ya fue registrado anteriormente.", "Modelo ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                InsertarNuevoModelo();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void InsertarNuevoModelo()
        {
            Fila f = new Fila();
            f.AgregarCelda("producto", IdProducto);
            f.AgregarCelda("familia", CmbFamilia.Text);
            f.AgregarCelda("modelo", TxtNombre.Text);
            ClienteProductoModelo.Modelo().Insertar(f);
        }

        private void CmbFamilia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        public void ValidarDatos()
        {
            BtnCrear.Enabled = CmbFamilia.Text != string.Empty && TxtNombre.Text != string.Empty;
        }

        private void CmbFamilia_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

    }
}
