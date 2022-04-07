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
    public partial class FrmSeleccionarUsuario : Ventana
    {
        string FiltroRol = "";
        bool MultiSeleccion = false;
        public Usuario UsuarioSeleccionado = new Usuario();
        public List<Usuario> UsuariosSeleccionados = new List<Usuario>();

        public FrmSeleccionarUsuario(string rol="", bool multiSeleccion = false)
        {
            InitializeComponent();
            FiltroRol = rol;
            MultiSeleccion = multiSeleccion;
        }

        private void MultiUsuario()
        {
            foreach (DataGridViewRow row in DgvUsuarios.Rows)
            {
                int seleccion = Convert.ToInt32(row.Cells["seleccionar_usuario"].Value);
                if (Convert.ToBoolean(seleccion))
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    Usuario usr = new Usuario();
                    usr.CargarDatos(id);
                    if (usr.TieneFilas())
                        UsuariosSeleccionados.Add(usr);
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SeleccionarUsuario()
        {
            int IdUsuario = Convert.ToInt32(DgvUsuarios.SelectedRows[0].Cells["id"].Value);
            UsuarioSeleccionado.CargarDatos(IdUsuario);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvUsuarios.SelectedRows.Count <= 0 || MultiSeleccion)
                return;
            
            SeleccionarUsuario();
        }

        private void FrmSeleccionarUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios(TxtFiltro.Text, FiltroRol);

            if (!MultiSeleccion)
                DgvUsuarios.Columns["seleccionar_usuario"].Visible = false;
        }

        public void CargarUsuarios(string filtro, string rol="")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            filtro = "%" + filtro + "%";
            parametros.Add("@filtro", filtro);
            parametros.Add("@rol", rol);

            string condiciones = "activo=1 AND (nombre LIKE @filtro OR paterno LIKE @filtro OR materno LIKE @filtro)";

            if (rol != "")
                condiciones += " AND rol=@rol";

            LlenarDataGridView(Usuario.Modelo().SeleccionarDatos(condiciones, parametros), DgvUsuarios);
            BtnSeleccionar.Enabled = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios(TxtFiltro.Text, FiltroRol);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (DgvUsuarios.SelectedRows.Count <= 0)
                return;

            if (!MultiSeleccion)
                SeleccionarUsuario();

            else
                MultiUsuario();
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnSeleccionar.Enabled = true;
        }
    }
}
