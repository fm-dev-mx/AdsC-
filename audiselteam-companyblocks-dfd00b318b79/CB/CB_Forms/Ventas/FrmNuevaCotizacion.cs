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
    public partial class FrmNuevaCotizacion : Ventana
    {
        public Fila FilaCotizacion = new Fila();

        public FrmNuevaCotizacion()
        {
            InitializeComponent();
        }

        private void FrmNuevaCotizacion_Load(object sender, EventArgs e)
        {
            CargarTiposProyectos();
            CargarClientes();
        }

        public void CargarClientes()
        {
            CmbCliente.Items.Clear();
            Cliente.Modelo().SeleccionarDatos("").ForEach(delegate(Fila f)
            {
                CmbCliente.Items.Add(f.Celda("id") + " - " + f.Celda("nombre").ToString());
            });
        }

        public void CargarContactos(int idCliente)
        {
            CmbContacto.Items.Clear();
            ClienteContacto.Modelo().SeleccionarDeCliente(idCliente).ForEach(delegate(Fila f)
            {
                CmbContacto.Items.Add(f.Celda("id") + " - " + f.Celda("nombre").ToString() + " " + f.Celda("apellidos").ToString() );
            });
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCliente = Convert.ToInt32(CmbCliente.Text.Split('-')[0]);
            CargarContactos(idCliente);
            ValidarDatos();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        public void CargarTiposProyectos()
        {
            CmbTipoProyecto.Items.Clear();
            TipoProyecto.Modelo().SeleccionarDatos("").ForEach(delegate(Fila f){
                CmbTipoProyecto.Items.Add(f.Celda("tipo"));
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        void ValidarDatos()
        {
            BtnCrear.Enabled = CmbCliente.Text != string.Empty && CmbContacto.Text != string.Empty &&
                               TxtTitulo.Text != string.Empty && CmbTipoProyecto.Text != string.Empty;
        }

        private void CmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void TxtTitulo_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void CmbTipoProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            FilaCotizacion.AgregarCelda("titulo", TxtTitulo.Text);
            FilaCotizacion.AgregarCelda("cliente", Convert.ToInt32(CmbCliente.Text.Split('-')[0]));
            FilaCotizacion.AgregarCelda("contacto", Convert.ToInt32(CmbContacto.Text.Split('-')[0]));
            FilaCotizacion.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
            FilaCotizacion.AgregarCelda("fecha_creacion", DateTime.Now);
            FilaCotizacion.AgregarCelda("ultima_modificacion", DateTime.Now);
            FilaCotizacion.AgregarCelda("fecha_limite", DateFechaLimite.Value);
            Cotizacion.Modelo().Insertar(FilaCotizacion);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
