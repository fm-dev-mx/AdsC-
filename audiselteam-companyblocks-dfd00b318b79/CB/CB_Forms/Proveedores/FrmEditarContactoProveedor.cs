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
    public partial class FrmEditarContactoProveedor : Form
    {
        ProveedorContacto NuevoContacto = new ProveedorContacto();
        int proveedor = 0;
        string modicarOAlta = "";
        public FrmEditarContactoProveedor(int idProveedor, string agregarModificarContacto)
        {
            InitializeComponent();
            proveedor = idProveedor;
            modicarOAlta = agregarModificarContacto;
            if (agregarModificarContacto == "Editar contacto")
                CargarDatosContacto(proveedor);
        }

        private bool validarCampos()
        {
            if (String.IsNullOrWhiteSpace(TxtNombreContacto.Text) || String.IsNullOrWhiteSpace(TxtApellidoCantacto.Text) || String.IsNullOrWhiteSpace(TxtNumeroCelular.Text) || String.IsNullOrWhiteSpace(TxtNumeroTelefono.Text)|| String.IsNullOrWhiteSpace(TxtCorreo.Text))
                return true;
            else
                return false;
        }

        private void altaContacto(int idProveedor)
        {
            if (!validarCampos())
            {
                if (ProveedorContacto.Modelo().ExisteCorreo(TxtCorreo.Text.Trim(), idProveedor))
                {
                    MessageBox.Show("El contacto ya existe");
                }
                else
                {
                    DialogResult respuesta = MessageBox.Show("Desea Capturar el nuevo contacto ", "", MessageBoxButtons.YesNo);
                    if (respuesta == System.Windows.Forms.DialogResult.Yes)
                    {
                        Fila contacto = new Fila();
                        contacto.AgregarCelda("proveedor", idProveedor);
                        contacto.AgregarCelda("nombre", TxtNombreContacto.Text.ToUpper().Trim());
                        contacto.AgregarCelda("apellidos", TxtApellidoCantacto.Text.ToUpper().Trim());
                        contacto.AgregarCelda("celular", TxtNumeroCelular.Text.ToUpper().Trim());
                        contacto.AgregarCelda("tel1", TxtNumeroTelefono.Text.ToUpper().Trim());
                        contacto.AgregarCelda("tel2", TxtNumeroTelefono2.Text.ToUpper().Trim());
                        contacto.AgregarCelda("correo", TxtCorreo.Text.Trim());
                        ProveedorContacto.Modelo().Insertar(contacto);

                        this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    }
                }

            }
            else
                MessageBox.Show("Captura Todos los  datos marcados con '*'");
        }
        private void CargarDatosContacto(int idContacto)
        {
            LblTitulo.Text = "EDITAR CONTACTO";
            BtnRegistrar.Text = "Editar";

            NuevoContacto.CargarDatos(idContacto);
            TxtNombreContacto.Text = NuevoContacto.Fila().Celda("nombre").ToString();
            TxtApellidoCantacto.Text = NuevoContacto.Fila().Celda("apellidos").ToString();
            TxtNumeroCelular.Text = NuevoContacto.Fila().Celda("celular").ToString();
            TxtNumeroTelefono.Text = NuevoContacto.Fila().Celda("tel1").ToString();
            TxtNumeroTelefono2.Text = NuevoContacto.Fila().Celda("tel2").ToString();
            TxtCorreo.Text = NuevoContacto.Fila().Celda("correo").ToString();
        }
        private void EditarContacto(int idContacto)
        {
            if (validarCampos())
                MessageBox.Show("Ingrese todos los campos marcados con '*'");
            else
            {
                DialogResult respuesta = MessageBox.Show("Desa Editar este Contacto usuario ", "", MessageBoxButtons.YesNo);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    NuevoContacto.Fila().ModificarCelda("nombre", TxtNombreContacto.Text.ToUpper().Trim());
                    NuevoContacto.Fila().ModificarCelda("apellidos", TxtApellidoCantacto.Text.ToUpper().Trim());
                    NuevoContacto.Fila().ModificarCelda("celular", TxtNumeroCelular.Text.ToUpper().Trim());
                    NuevoContacto.Fila().ModificarCelda("tel1", TxtNumeroTelefono.Text.ToUpper().Trim());
                    NuevoContacto.Fila().ModificarCelda("tel2", TxtNumeroTelefono2.Text.ToUpper().Trim());
                    NuevoContacto.Fila().ModificarCelda("correo", TxtCorreo.Text.Trim());
                    NuevoContacto.GuardarDatos();

                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                }
                
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (modicarOAlta == "Agregar contacto")
                altaContacto(proveedor);
            else if (modicarOAlta == "Editar contacto")
                EditarContacto(proveedor);
        }
    }
}
