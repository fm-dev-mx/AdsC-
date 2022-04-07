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
    public partial class FrmNuevoElemento : Ventana
    {
        int IdModulo = 0;
        Elemento ElementoCargado = new Elemento();

        public FrmNuevoElemento(int idModulo, int idElemento=0, bool editarElemento = false)
        {
            InitializeComponent();
            IdModulo = idModulo;
            
            if(idElemento > 0)
                ElementoCargado.CargarDatos(idElemento);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
        
        bool ValidarDatos()
        {
            return CmbTipo.Text != "" && TxtNombre.Text != "";
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if( !ValidarDatos() )
            {
                LblInfo.Text = "Ingresa toda la información requerida";
                LblInfo.Visible = true;
                return;
            }

            if( !ElementoCargado.TieneFilas() )
            {
                Fila elem = new Fila();
                elem.AgregarCelda("modulo", IdModulo);
                elem.AgregarCelda("tipo", CmbTipo.Text);
                elem.AgregarCelda("nombre", TxtNombre.Text);
                elem.AgregarCelda("descripcion", TxtDescripcion.Text);

                Elemento.Modelo().Insertar(elem);
            }
            else
            {
                ElementoCargado.Fila().ModificarCelda("tipo", CmbTipo.Text);
                ElementoCargado.Fila().ModificarCelda("nombre", TxtNombre.Text);
                ElementoCargado.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                ElementoCargado.GuardarDatos();
            }
          
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmNuevoElemento_Load(object sender, EventArgs e)
        {
            CargarTiposElemento();
            if(ElementoCargado.TieneFilas())
            {
                LblTitulo.Text = "EDITAR ELEMENTO";

                CmbTipo.Text = ElementoCargado.Fila().Celda("tipo").ToString();
                TxtNombre.Text = ElementoCargado.Fila().Celda("nombre").ToString();
                TxtDescripcion.Text = ElementoCargado.Fila().Celda("descripcion").ToString();

                BtnRegistrar.Text = "Guardar";
            }
                
        }

        public void CargarTiposElemento()
        {
            CmbTipo.Items.Clear();
            ElementoTipo.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbTipo.Items.Add(f.Celda("tipo"));
            });
        }
    }
}
