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
    public partial class FrmInformacionGeneralCotizacion : Form
    {
        BindingSource BindingIndustria = new BindingSource();
        BindingSource BindingContacto = new BindingSource();
        BindingSource BindingContactoCompras = new BindingSource();
        BindingSource BindingProducto = new BindingSource();
        CotizacionClinte Cotizacion = new CotizacionClinte();
        FrmEditarCotizacion2 FormPadre = null;
        int IdCotizacion = 0;
        int IdCliente = 0;

        public FrmInformacionGeneralCotizacion(int idCotizacion, FrmEditarCotizacion2 formPadre)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
            Cotizacion.CargarDatos(idCotizacion);
            FormPadre = formPadre;
        }

        public FrmInformacionGeneralCotizacion(int idCotizacion)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
            
        }

        private void FrmEditarCotizacion2_Load(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        private void CargarInformacion()
        {
            Cotizacion.CargarDatos(IdCotizacion);
            HabilitarControles(false);
            Cotizacion.Filas().ForEach(delegate(Fila f)
            {
                TxtTitulo.Text = f.Celda("nombre_cotizacion").ToString();
                CargarIndustria();
                CargarContactoCompras();
                CargarContactosTecnicos();

                Cliente cliente = new Cliente();
                cliente.CargarDatos(Convert.ToInt32(f.Celda("cliente")));

                if (cliente.TieneFilas())
                {
                    TxtCliente.Text =  cliente.Fila().Celda("nombre").ToString();
                    IdCliente = Convert.ToInt32(cliente.Fila().Celda("id"));
                }

                if (f.Celda("fecha_limite_enviar") != null)
                    DtpFechaLimite.Value = Convert.ToDateTime(f.Celda("fecha_limite_enviar"));
            });

            CargarContactoCompras();
            CargarProducto();
        }

        private void CargarIndustria()
        {
            BindingIndustria.Clear();
            string industriaNombre = string.Empty;
            Cliente clientes = new Cliente();
            clientes.IndustriasDeCliente(Convert.ToInt32(Cotizacion.Fila().Celda("cliente"))).ForEach(delegate(Fila f)
            {
                if (f.Celda("id").Equals(Cotizacion.Fila().Celda("cliente_industria")))
                    industriaNombre = f.Celda("id").ToString().PadLeft(4, '0') + "-" + f.Celda("nombre");

                BindingIndustria.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });
            
            CmbIndustria.DisplayMember = "Text";
            CmbIndustria.ValueMember = "Value";
            CmbIndustria.DataSource = BindingIndustria;
            CmbIndustria.Text = industriaNombre;
        }

        private void CargarContactosTecnicos()
        {
            BindingContacto.Clear();
            string nombreContacto = string.Empty;
            ClienteContacto contacto = new ClienteContacto();
            contacto.SeleccionarDeCliente(Convert.ToInt32(Cotizacion.Fila().Celda("cliente"))).ForEach(delegate(Fila f)
            {
                if (f.Celda("id").Equals(Cotizacion.Fila().Celda("cliente_contacto_tecnico")))
                    nombreContacto = f.Celda("nombre") + " " + f.Celda("apellidos");
               // CmbContacto.Items.Add(f.Celda("id").ToString().PadLeft(4,'0') + "-" + f.Celda("nombre") + " " + f.Celda("apellidos"));
                BindingContacto.Add(new
                {
                    Text = f.Celda("nombre").ToString() + " " + f.Celda("apellidos"),
                    Value = f.Celda<int>("id")
                });
            });

            CmbContacto.DisplayMember = "Text";
            CmbContacto.ValueMember = "Value";
            CmbContacto.DataSource = BindingContacto;
            CmbContacto.Text = nombreContacto;
        }

        private void CargarContactoCompras()
        {
            BindingContactoCompras.Clear();
            string nombreContacto = string.Empty;
            ClienteContacto contacto = new ClienteContacto();
            contacto.SeleccionarDeCliente(Convert.ToInt32(Cotizacion.Fila().Celda("cliente"))).ForEach(delegate(Fila f)
            {
                if(Cotizacion.Fila().Celda("cliente_contacto_compras").Equals(f.Celda("id")))
                    nombreContacto = f.Celda("nombre") + " " + f.Celda("apellidos");

               // ContactoCompras.Items.Add(f.Celda("id").ToString().PadLeft(4,'0') + "-" + f.Celda("nombre") + " " + f.Celda("apellidos"));
                BindingContactoCompras.Add(new
                {
                    Text = f.Celda("nombre").ToString() + " " + f.Celda("apellidos"),
                    Value = f.Celda<int>("id")
                });
            });

            ContactoCompras.DisplayMember = "Text";
            ContactoCompras.ValueMember = "Value";
            ContactoCompras.DataSource = BindingContactoCompras;
            ContactoCompras.Text = nombreContacto;
        }

        private void CargarProducto()
        {
            BindingProducto.Clear();
            string nombreProducto = string.Empty;
            Producto producto = new Producto();
            int cliente = Convert.ToInt32(Cotizacion.Fila().Celda("cliente"));

            producto.SeleccionarProducto(cliente, Convert.ToInt32(Cotizacion.Fila().Celda("cliente_industria"))).ForEach(delegate(Fila f)
            {
                if (f.Celda("id").Equals(Cotizacion.Fila().Celda("producto")))
                    nombreProducto = f.Celda("id").ToString().PadLeft(4, '0') + "-" + f.Celda("nombre");

                BindingProducto.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            CmbProducto.DisplayMember = "Text";
            CmbProducto.ValueMember = "Value";
            CmbProducto.DataSource = BindingProducto;
            CmbProducto.Text = nombreProducto;
        }

        private void HabilitarControles(bool habilitar)
        {
            CmbContacto.Enabled = habilitar;
            CmbIndustria.Enabled = habilitar;
            ContactoCompras.Enabled = habilitar;
            TxtTitulo.Enabled = habilitar;
            CmbProducto.Enabled = habilitar;
            DtpFechaLimite.Enabled = habilitar;
            BtnCrear.Visible = habilitar;
            button2.Visible = habilitar;
            CkbMostrarPartida.Enabled = habilitar;
            CkbDesglosarCosto.Enabled = habilitar;
        }

        private void CkbEditar_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarControles(CkbEditar.Checked);
            if (!CkbEditar.Checked)
                CargarInformacion();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CkbEditar.Checked = false;
            HabilitarControles(false);
        }

        private void BtnCrear_Click_1(object sender, EventArgs e)
        {
            Cotizacion.Fila().ModificarCelda("nombre_cotizacion", TxtTitulo.Text);
            Cotizacion.Fila().ModificarCelda("cliente_industria", CmbIndustria.SelectedValue);
            Cotizacion.Fila().ModificarCelda("cliente_contacto_tecnico", CmbContacto.SelectedValue);
            Cotizacion.Fila().ModificarCelda("fecha_limite_enviar", DtpFechaLimite.Value);

            if (ContactoCompras.Text != "")
                Cotizacion.Fila().ModificarCelda("cliente_contacto_compras", ContactoCompras.SelectedValue);
            if (CmbProducto.Text != "")
                Cotizacion.Fila().ModificarCelda("producto", CmbProducto.SelectedValue);
            Cotizacion.GuardarDatos();

            MessageBox.Show("La cotizacion " + IdCotizacion.ToString().PadLeft(4, '0') + " ha sido actualizado de forma correcta");
           // Cotizacion.CargarDatos(IdCotizacion);
            CkbEditar.Checked = false;
            CargarInformacion();

            if(FormPadre != null)
            {
                FormPadre.RefrescarArbol();
            }
        }
    }
}
