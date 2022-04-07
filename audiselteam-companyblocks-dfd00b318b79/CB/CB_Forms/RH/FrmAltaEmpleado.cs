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
    public partial class FrmAltaEmpleado : Ventana
    {
        public string NombreUsuario = string.Empty;
        public string Paterno = string.Empty;
        public string Materno = string.Empty;
        public string Correo = string.Empty;
        public string Telefono = string.Empty;
        public string Puesto = string.Empty;
        public string Contrasena = string.Empty;
        public string Apodo = string.Empty;
        public int nivel = 0;
       
        List<Fila> Puestos = new List<Fila>();
        Rol RolesUsuario = new Rol();
        
        public FrmAltaEmpleado()
        {
            InitializeComponent();
            Rol rol = new Rol();

            Puestos = rol.Roles();
        }

        private void FrmAltaEmpleado_Load(object sender, EventArgs e)
        {
            CargarPuesto();
            BtnGuardar.Enabled = false;
            LblContrasena.Visible = false;
            
        }

        void CargarPuesto()
        {
            CmbPuesto.Items.Clear();
            Puestos.ForEach(delegate(Fila f)
            {
                CmbPuesto.Items.Add(f.Celda("rol").ToString());
            });
        }

        private void CmbPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);

            if(e.KeyChar == (char)Keys.Enter)
            {
                object BuscarPuesto = null;
                BuscarPuesto = Puestos.Find(x => x.Celda("rol").ToString() == CmbPuesto.Text);

                if(BuscarPuesto == null)
                {
                    DialogResult result = MessageBox.Show("El puesto " + CmbPuesto.Text + " no existe, ¿Desea agregarlo?", "El puesto no existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if(result == System.Windows.Forms.DialogResult.OK)
                    {
                        Fila agregarRol = new Fila();
                        agregarRol.AgregarCelda("rol", CmbPuesto.Text);
                        agregarRol.AgregarCelda("nivel_maximo", 0);
                        Rol.Modelo().Insertar(agregarRol);

                        Puestos.Clear();

                        Puestos = Rol.Modelo().Roles();
                        CargarPuesto();
                    }
                    else
                    {
                        CmbPuesto.Text = "";
                    }
                }
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if(TxtNombre.Text == "" || TxtPaterno.Text == "" || TxtCorreo.Text == "" || CmbPuesto.Text == "" || TxtContrasena.Text == "" && TxtContrasena.Text == TxtConfirmacionContrasena.Text)
            {
                MessageBox.Show("Favor de llenar todos los campos que se encuentran marcados con '*'", "Favor de llenar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            NombreUsuario = TxtNombre.Text;
            Paterno = TxtPaterno.Text;
            Materno = TxtMaterno.Text;
            Correo = TxtCorreo.Text;
            Telefono = TxtTelefono.Text;
            Puesto = CmbPuesto.Text;
            Contrasena = TxtContrasena.Text;
            Apodo = TxtApodo.Text;
            nivel = Convert.ToInt32(NumNivel.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtConfirmacionContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtConfirmacionContrasena.Text != TxtContrasena.Text)
            {
                LblContrasena.Visible = true;
                BtnGuardar.Enabled = false;
                LblContrasena.Text = "La contraseña no coincide";
                LblContrasena.ForeColor = Color.Red;
            }
            else if (TxtConfirmacionContrasena.Text == "" && TxtContrasena.Text == "")
            {
                LblContrasena.Visible = false;
                BtnGuardar.Enabled = false;
            }
            else
            {
                LblContrasena.Visible = false;
                BtnGuardar.Enabled = true;
            }
        }

        private void TxtConfirmacionContrasena_TextChanged(object sender, EventArgs e)
        {
            if(TxtConfirmacionContrasena.Text == "")
            {
                LblContrasena.Visible = false;
                BtnGuardar.Enabled = false;
            }
            else if (TxtConfirmacionContrasena.Text == "" && TxtContrasena.Text == "")
            {
                LblContrasena.Visible = false;
                BtnGuardar.Enabled = false;
            }
        }

        private void CmbPuesto_Leave(object sender, EventArgs e)
        {
            if (CmbPuesto.Text == "")
                return;

            object BuscarPuesto = null;
            BuscarPuesto = Puestos.Find(x => x.Celda("rol").ToString() == CmbPuesto.Text);

            if (BuscarPuesto == null)
            {
                DialogResult result = MessageBox.Show("El puesto " + CmbPuesto.Text + " no existe, ¿Desea agregarlo?", "El puesto no existe", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Fila agregarRol = new Fila();
                    agregarRol.AgregarCelda("rol", CmbPuesto.Text);
                    agregarRol.AgregarCelda("nivel_maximo", 0);
                    Rol.Modelo().Insertar(agregarRol);

                    Puestos.Clear();

                    Puestos = Rol.Modelo().Roles();
                    CargarPuesto();
                }
                else
                {
                    CmbPuesto.Text = "";
                }
            }
        }

        private void TxtContrasena_TextChanged(object sender, EventArgs e)
        {
            if (TxtContrasena.Text == "" && TxtConfirmacionContrasena.Text != "")
            {
                LblContrasena.Visible = true;
                BtnGuardar.Enabled = false;
            }
            else if(TxtContrasena.Text == "" && TxtConfirmacionContrasena.Text == "")
            {
                LblContrasena.Visible = false;
                BtnGuardar.Enabled = false;
            }
        }

        private void CmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rol", CmbPuesto.Text);

            RolesUsuario.SeleccionarDatos("rol=@rol", parametros);
            if (RolesUsuario.TieneFilas())
            {
                if (Convert.ToInt32(RolesUsuario.Fila().Celda("nivel_maximo")) > 0)
                {
                    NumNivel.Visible = true;
                    LblNivel.Visible = true;
                }
                else
                {
                    NumNivel.Visible = false;
                    LblNivel.Visible = false;
                    NumNivel.Value = 0;
                }
            }
        }
    }
}
