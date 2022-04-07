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
    public partial class FrmNuevaCotizacion2 : Form
    {
        int CotizacionPrincipal = 0;
        string IdCotizacion = string.Empty;
        BindingSource ProductoBinding = new BindingSource();
        BindingSource ClienteBinding = new BindingSource();
        BindingSource IndustriaBinding = new BindingSource();
        BindingSource ContactosBinding = new BindingSource();
        BindingSource ContactosComprasBinding = new BindingSource();

        public FrmNuevaCotizacion2(int cotizacionPrincipal = 0)
        {
            InitializeComponent();
            CargarClientes();
            CotizacionPrincipal = cotizacionPrincipal;
        }

        private void FrmNuevaCotizacion2_Load(object sender, EventArgs e)
        {
            BtnCrear.Enabled = false;

            if(CotizacionPrincipal == 0)
            {
                CotizacionClinte cotizacion = new CotizacionClinte();
                cotizacion.SeleccionarDatos("id=format(id,00) order by id DESC limit 1", null, "id");
                if (cotizacion.TieneFilas())
                    IdCotizacion = (Convert.ToDecimal(cotizacion.Fila().Celda("id")) + 1).ToString("f2");
                else
                    IdCotizacion = Convert.ToDecimal("1.00").ToString("f2");
            }
        }

        private void CargarClientes()
        {
            ClienteBinding.Add(new
            {
                Text = "",
                Value = 0
            });
            Cliente clientes = new Cliente();
            clientes.Todos().ForEach(delegate(Fila f)
            {
                ClienteBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            CmbClientes.DisplayMember = "Text";
            CmbClientes.ValueMember = "Value";
            CmbClientes.DataSource = ClienteBinding;
            if(CmbClientes.Items.Count > 0)
                CmbClientes.SelectedIndex = 0;
        }

        private void CargarIndustria()
        {
            IndustriaBinding.Clear();
            Cliente clientes = new Cliente();
            clientes.IndustriasDeCliente(Convert.ToInt32(CmbClientes.SelectedValue)).ForEach(delegate(Fila f)
            {
                IndustriaBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            CmbIndustria.DisplayMember = "Text";
            CmbIndustria.ValueMember = "Value";
            CmbIndustria.DataSource = IndustriaBinding;
            if(CmbIndustria.Items.Count > 0)
                CmbIndustria.SelectedIndex = 0;
        }

        private void CargarContactosTecnicos()
        {
            ContactosBinding.Clear();
            ContactosBinding.Add(new
            {
                Text = "",
                Value = 0
            });
            ClienteContacto contacto = new ClienteContacto();
            contacto.SeleccionarDeCliente(Convert.ToInt32(CmbClientes.SelectedValue)).ForEach(delegate(Fila f)
            {
                ContactosBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString() + " " + f.Celda("apellidos").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            CmbContacto.DisplayMember = "Text";
            CmbContacto.ValueMember = "Value";
            CmbContacto.DataSource = ContactosBinding;
        }

        private void CargarContactoCompras(int idCliente)
        {
            ContactosComprasBinding.Clear();
            ContactosComprasBinding.Add(new
            {
                Text = "",
                Value = 0
            });

            ClienteContacto contacto = new ClienteContacto();
            contacto.SeleccionarDeCliente(idCliente).ForEach(delegate(Fila f)
            {
                //ContactoCompras.Items.Add(f.Celda("id") + "-" + f.Celda("nombre") + " " + f.Celda("apellidos"));
                ContactosComprasBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString() + " " + f.Celda("apellidos").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            ContactoCompras.DisplayMember = "Text";
            ContactoCompras.ValueMember = "Value";
            ContactoCompras.DataSource = ContactosComprasBinding;
            if(ContactoCompras.Items.Count > 0)
                ContactoCompras.SelectedIndex = 0;
        }

        private void CargarProducto()
        {
            ProductoBinding.Clear();
            ProductoBinding.Add(new
            {
                Text = "",
                Value = 0
            });
            Producto producto = new Producto();
            producto.SeleccionarProducto(Convert.ToInt32(CmbClientes.SelectedValue), Convert.ToInt32(CmbIndustria.SelectedValue)).ForEach(delegate(Fila f)
            {
                ProductoBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            CmbProducto.DisplayMember = "Text";
            CmbProducto.ValueMember = "Value";
            CmbProducto.DataSource = ProductoBinding;
            if(CmbProducto.Items.Count > 0)
                CmbProducto.SelectedIndex = 0;
        }

        private void HabilitarBoton()
        {
            BtnCrear.Enabled = 
            (
                TxtTitulo.Text != "" &&
                CmbClientes.Text != "" &&
                CmbIndustria.Text != "" &&
                CmbContacto.Text != "" &&
                DtpFechaLimite.Value.Date > DateTime.Now
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            try
            {
                Fila insertarCotizacion = new Fila();

                insertarCotizacion.AgregarCelda("id", IdCotizacion);
                insertarCotizacion.AgregarCelda("cotizacion_principal", CotizacionPrincipal);
                insertarCotizacion.AgregarCelda("nombre_cotizacion", TxtTitulo.Text);
                insertarCotizacion.AgregarCelda("cliente", Convert.ToInt32(CmbClientes.SelectedValue));
                insertarCotizacion.AgregarCelda("cliente_industria", Convert.ToInt32(CmbIndustria.SelectedValue));
                insertarCotizacion.AgregarCelda("cliente_contacto_tecnico", Convert.ToInt32(CmbContacto.SelectedValue));
                insertarCotizacion.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
                insertarCotizacion.AgregarCelda("estatus_cotizacion", "PENDIENTE");
                insertarCotizacion.AgregarCelda("estatus_evaluacion", "PENDIENTE");
                insertarCotizacion.AgregarCelda("fecha_creacion", DateTime.Now);
                insertarCotizacion.AgregarCelda("fecha_limite_enviar", DtpFechaLimite.Value.Date);

                if (ContactoCompras.Text != "")
                    insertarCotizacion.AgregarCelda("cliente_contacto_compras", Convert.ToInt32(ContactoCompras.SelectedValue));
                if (CmbProducto.Text != "")
                    insertarCotizacion.AgregarCelda("producto", Convert.ToInt32(CmbProducto.SelectedValue));

                CotizacionClinte.Modelo().Insertar(insertarCotizacion);
            }
            catch
            {
                CotizacionClinte cotizacion = new CotizacionClinte();
                cotizacion.SeleccionarDatos("id=format(id,00) order by id DESC limit 1", null, "id");
                string idComprobar = (Convert.ToDecimal(cotizacion.Fila().Celda("id").ToString())).ToString("F2");
                if (IdCotizacion == idComprobar)
                {
                     MessageBox.Show("Se ha creado de forma exitosa la cotización:\r\n#" + IdCotizacion + "-" + TxtTitulo.Text);
                     DialogResult = System.Windows.Forms.DialogResult.OK;
                     Close();
                }
                else
                   MessageBox.Show("No ha sido posible crear la cotización #" + IdCotizacion + "-" + TxtTitulo.Text + "\r\nContacte a sistemas.");                                      
            }
        }

        private void CmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbClientes.Text == "" || CmbClientes.Text == "N/A")
                return;

            CargarIndustria();
            CargarContactosTecnicos();
            CargarContactoCompras(Convert.ToInt32(CmbClientes.SelectedValue));

            HabilitarBoton();
        }

        private void CmbIndustria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProducto();
            HabilitarBoton();
        }

        private void TxtTitulo_TextChanged(object sender, EventArgs e)
        {
            HabilitarBoton();
        }

        private void CmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBoton();
        }
    }
}
