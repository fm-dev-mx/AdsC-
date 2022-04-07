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
    public partial class FrmAdministrarUsuarios : Form
    {
        public Usuario UsuarioCargado = new Usuario();

        public FrmAdministrarUsuarios()
        {
            InitializeComponent();
        }

        private void FrmAdministrarUsuarios_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool ValidarDatos()
        {
            if (TxtNombre.Text == "") return false;
            if (TxtPaterno.Text == "") return false;
            if (TxtCorreo.Text == "") return false;
            if (CmbRol.Text == "") return false;

            return true;
        }

        private void BtnEditarUsuario_Click(object sender, EventArgs e)
        {
            BtnNuevoUsuario.Enabled = false;

            if( BtnEditarUsuario.Text == "Editar")
            {
                BtnEditarUsuario.Text = "Guardar";
                ActivarEdicion();
            }
            else
            {
                if (ValidarDatos())
                {
                    GuardarEdicion();
                    BtnEditarUsuario.Text = "Editar";
                    DesactivarEdicion();
                    LblInfo.Text = "";
                    BtnNuevoUsuario.Enabled = true;
                }
                else
                    LblInfo.Text = "Ingresa todos los datos.";
            }
        }

        void CargarUsuarios(bool mostrarInactivos)
        {
            BtnEditarUsuario.Enabled = false;
            DgvUsuarios.Rows.Clear();

            List<Fila> usuarios = null;

            if (mostrarInactivos)
                usuarios = Usuario.Modelo().Todos();
            else
                usuarios = Usuario.Modelo().Activos();

            usuarios.ForEach(delegate(Fila usr)
            {
                string activo = "";

                if (Convert.ToInt32(usr.Celda("activo")) == 1)
                    activo = "SI";
                else
                    activo = "NO";

                DgvUsuarios.Rows.Add(usr.Celda("id"), usr.Celda("nombre") + " " + usr.Celda("paterno") + " " + usr.Celda("materno"), activo );
            });

            LimpiarDatosUsuario();
        }

        private void FrmAdministrarUsuarios_Shown(object sender, EventArgs e)
        {
            CargarUsuarios(ChkMostrarInactivos.Checked);
            LblInfo.Text = "";
        }

        private void ChkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarUsuarios(ChkMostrarInactivos.Checked);
        }

        public void LimpiarDatosUsuario()
        {
            DatosUsuario.Visible = false;
        }

        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( DgvUsuarios.SelectedRows.Count > 0)
            {
                int IdUsuario = Convert.ToInt32(DgvUsuarios.SelectedRows[0].Cells[0].Value);
                UsuarioCargado.CargarDatos(IdUsuario);
                MostrarDatosUsuario();
            }
        }

        public void MostrarDatosUsuario()
        {
            LblNombreUsuario.Text = UsuarioCargado.Fila().Celda("nombre").ToString() + " " + UsuarioCargado.Fila().Celda("paterno").ToString() + " " + UsuarioCargado.Fila().Celda("materno").ToString();
            DatosUsuario.Visible = true;
            BtnEditarUsuario.Enabled = true;
            BtnNuevoUsuario.Enabled = true;

            TxtNombre.Text = UsuarioCargado.Fila().Celda("nombre").ToString();
            TxtPaterno.Text = UsuarioCargado.Fila().Celda("paterno").ToString();
            TxtMaterno.Text = UsuarioCargado.Fila().Celda("materno").ToString();
            TxtCorreo.Text = UsuarioCargado.Fila().Celda("correo").ToString();
            TxtTelefono.Text = UsuarioCargado.Fila().Celda("tel").ToString();


            CmbRol.Items.Clear();
            Rol.Modelo().Todos().ForEach(delegate(Fila rol)
            {
                CmbRol.Items.Add(rol.Celda("rol"));
            });

            CmbRol.Text = UsuarioCargado.Fila().Celda("rol").ToString();

            if (Convert.ToInt32(UsuarioCargado.Fila().Celda("activo")) == 1)
                ChkUsuarioActivo.Checked = true;
            else
                ChkUsuarioActivo.Checked = false;

            DesactivarEdicion();
            LblInfo.Text = "";
        }

        public void OcultarDatosUsuario()
        {
            LblNombreUsuario.Text = "SELECCIONA UN USUARIO";
            DesactivarEdicion();
            LblInfo.Text = "";
        }

        public void BorrarDatos()
        {
            TxtNombre.Text = "";
            TxtPaterno.Text = "";
            TxtMaterno.Text = "";
            TxtCorreo.Text = "";
            TxtTelefono.Text = "";
         

            CmbRol.Items.Clear();
            Rol.Modelo().Todos().ForEach(delegate(Fila rol)
            {
                CmbRol.Items.Add(rol.Celda("rol"));
            });
            CmbRol.Text = "";
        }

        void ActivarEdicion()
        {
            TxtNombre.ReadOnly = false;
            TxtPaterno.ReadOnly = false;
            TxtMaterno.ReadOnly = false;
            TxtTelefono.ReadOnly = false;
            TxtCorreo.ReadOnly = false;
            ChkUsuarioActivo.Enabled = true;
            CmbRol.Enabled = true;
        }

        void DesactivarEdicion()
        {
            TxtNombre.ReadOnly = true;
            TxtPaterno.ReadOnly = true;
            TxtMaterno.ReadOnly = true;
            TxtTelefono.ReadOnly = true;
            TxtCorreo.ReadOnly = true;
            ChkUsuarioActivo.Enabled = false;
            CmbRol.Enabled = false;

            BtnEditarUsuario.Text = "Editar";
            BtnNuevoUsuario.Text = "Nuevo usuario";
        }

        void GuardarEdicion()
        {
            UsuarioCargado.Fila().ModificarCelda("nombre", TxtNombre.Text);
            UsuarioCargado.Fila().ModificarCelda("paterno", TxtPaterno.Text);
            UsuarioCargado.Fila().ModificarCelda("materno", TxtMaterno.Text);
            UsuarioCargado.Fila().ModificarCelda("correo", TxtCorreo.Text);
            UsuarioCargado.Fila().ModificarCelda("tel", TxtTelefono.Text);
            UsuarioCargado.Fila().ModificarCelda("rol", CmbRol.Text);    
            UsuarioCargado.Fila().ModificarCelda("activo", Convert.ToInt32(ChkUsuarioActivo.Checked));

            if(ChkUsuarioActivo.Checked)
            {
                UsuarioCargado.Fila().ModificarCelda("fecha_baja", null);
                UsuarioCargado.Fila().ModificarCelda("razon_baja",  null);
                UsuarioCargado.Fila().ModificarCelda("comentarios_baja", "");
                UsuarioCargado.Fila().ModificarCelda("usuario_baja", null);
            }

            UsuarioCargado.GuardarDatos();

            LblInfo.Text = "";
        }

        private void BtnNuevoUsuario_Click(object sender, EventArgs e)
        {
            if( BtnNuevoUsuario.Text == "Nuevo usuario")
            {
                ActivarEdicion();
                DatosUsuario.Visible = true;
                BtnNuevoUsuario.Text = "Crear usuario";
                LblNombreUsuario.Text = "INGRESA LOS DATOS DEL NUEVO USUARIO";
                BorrarDatos();
                BtnEditarUsuario.Enabled = false;
            }
            else
            {
                if (ValidarDatos())
                {
                    if (Usuario.Modelo().Existe(TxtCorreo.Text))
                    {
                        MessageBox.Show("Este usuario ya fue registrado anteriormente!");
                    }
                    else
                    {
                        Fila usr = new Fila();

                        usr.AgregarCelda("nombre", TxtNombre.Text);
                        usr.AgregarCelda("paterno", TxtPaterno.Text);
                        usr.AgregarCelda("materno", TxtMaterno.Text);
                        usr.AgregarCelda("correo", TxtCorreo.Text);
                        usr.AgregarCelda("password", Global.CalcularHashMD5(""));
                        usr.AgregarCelda("rol", CmbRol.Text);
                        usr.AgregarCelda("tel", TxtTelefono.Text);
                        usr.AgregarCelda("activo", Convert.ToInt32(ChkUsuarioActivo.Checked));
                        Usuario.Modelo().Insertar(usr);

                        LblInfo.Text = "";
                        BtnNuevoUsuario.Text = "Nuevo usuario";

                        CargarUsuarios(ChkUsuarioActivo.Checked);
                        OcultarDatosUsuario();

                        MessageBox.Show("Usuario creado correctamente!");

                        BtnEditarUsuario.Enabled = true;
                    }
                }
                else
                    LblInfo.Text = "Ingresa todos los datos.";
            }
        }

        private void ChkUsuarioActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkUsuarioActivo.Checked)
            {
                int idUsuario = Convert.ToInt32(UsuarioCargado.Fila().Celda("id"));
                string nombreUsuario = UsuarioCargado.Fila().Celda("nombre") + " " + UsuarioCargado.Fila().Celda("paterno");

                DialogResult result = MessageBox.Show("Está seguro que desea dar de baja al empleado " + idUsuario + " con nombre " + nombreUsuario, "Dar de baja empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result  != System.Windows.Forms.DialogResult.Yes)
                {
                    ChkUsuarioActivo.Checked = true;
                    return;
                }
            
                FrmRazonBajaUsuario razon = new FrmRazonBajaUsuario(Convert.ToInt32(UsuarioCargado.Fila().Celda("id")));
                if (razon.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    UsuarioCargado.Fila().ModificarCelda("fecha_baja", DateTime.Now);
                    UsuarioCargado.Fila().ModificarCelda("razon_baja", razon.IdRazon);
                    UsuarioCargado.Fila().ModificarCelda("comentarios_baja", razon.Comentarios);
                    UsuarioCargado.Fila().ModificarCelda("usuario_baja", Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
                    UsuarioCargado.GuardarDatos();

                    GuardarEdicion();
                    BtnEditarUsuario.Text = "Editar";
                    DesactivarEdicion();
                    LblInfo.Text = "";
                    BtnNuevoUsuario.Enabled = true;
                }
                else
                {
                    ChkUsuarioActivo.Checked = true;
                    return;
                }
            }                
        }
    }
}
