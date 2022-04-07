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
    public partial class FrmAdministrarRoles : Form
    {
        public FrmAdministrarRoles()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdministrarRoles_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CargarRoles();
        }

        void CargarRoles()
        {
            CmbRoles.Items.Clear();

            Rol.Modelo().Todos().ForEach(delegate(Fila rol)
            {
                CmbRoles.Items.Add(rol.Celda("rol").ToString());
            });
        }
        private void AsignarPrivilegio()
        {
            FrmAsignarPrivilegio asignar = new FrmAsignarPrivilegio();
            int rolSeleccionado = 0;
            List<Fila> roles = Rol.Modelo().SeleccionarRol(CmbRoles.Text);

            if (roles.Count > 0)
                rolSeleccionado = Convert.ToInt32(roles[0].Celda("id"));

            if (asignar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila rolPrivilegio = new Fila();
                rolPrivilegio.AgregarCelda("rol", rolSeleccionado);
                rolPrivilegio.AgregarCelda("privilegio", asignar.PrivilegioSeleccionado);

                if (RolPrivilegio.Modelo().SeleccionarRolPrivilegio(rolSeleccionado, asignar.PrivilegioSeleccionado).Count > 0)
                {
                    MessageBox.Show("Este privilegio ya fue asignado anteriormente!");
                }
                else
                {
                    RolPrivilegio.Modelo().Insertar(rolPrivilegio);
                    CargarPrivilegios(CmbRoles.Text);
                }
            }
        }
        public void AsignarHabilidad()
        {
            FrmAsignarHabilidad asignarHabilidad = new FrmAsignarHabilidad();
            int rolSeleccionado = 0;
            List<Fila> roles = Rol.Modelo().SeleccionarRol(CmbRoles.Text);

            if (roles.Count > 0)
                rolSeleccionado = Convert.ToInt32(roles[0].Celda("id"));
            if (asignarHabilidad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila rolHabilidad = new Fila();
                rolHabilidad.AgregarCelda("rol", rolSeleccionado);
                rolHabilidad.AgregarCelda("habilidad", asignarHabilidad.HabilidadSeleccionada);

                if (RolHabilidad.Modelo().SeleccionarRolHabilidad(rolSeleccionado, asignarHabilidad.HabilidadSeleccionada).Count > 0)
                {
                    MessageBox.Show("Esta habilidad ya fue asignada anteriormente!");
                }
                else
                {
                    RolHabilidad.Modelo().Insertar(rolHabilidad);
                    CargarHabilidades(CmbRoles.Text);
                }
            }
        }
        
        private void BtnAsignarPrivilegio_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPrivilegios)
                AsignarPrivilegio();
            
            else if (tabControl1.SelectedTab == tabHabilidades)
                AsignarHabilidad();
        }

        private void CmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPrivilegios)
            {
                BtnAsignarPrivilegio.Enabled = true;
                CargarPrivilegios(CmbRoles.Text);
            }
            else if (tabControl1.SelectedTab == tabHabilidades)
            {
                CargarHabilidades(CmbRoles.Text);
                BtnAsignarPrivilegio.Enabled = true;
            }
        }

        public void CargarPrivilegios(string rol)
        {
            DgvPrivilegios.Rows.Clear();

            List<Fila> roles = Rol.Modelo().SeleccionarRol(rol);
            int IdRol = 0;

            if( roles.Count > 0)
                IdRol = Convert.ToInt32(roles[0].Celda("id"));

            RolPrivilegio.Modelo().SeleccionarRol(IdRol).ForEach(delegate(Fila rolp)
            {
                Privilegio priv = new Privilegio();
                priv.CargarDatos( Convert.ToInt32(rolp.Celda("privilegio")));
                DgvPrivilegios.Rows.Add(priv.Fila().Celda("id"), priv.Fila().Celda("categoria"), priv.Fila().Celda("privilegio") );
            });
        }

        public void CargarHabilidades(string rol)
        {
            DgvHabilidades.Rows.Clear();

            List<Fila> habilidades = Rol.Modelo().SeleccionarRol(rol);
            int IdRol = 0;

            if (habilidades.Count > 0)
                IdRol = Convert.ToInt32(habilidades[0].Celda("id"));

            RolHabilidad.Modelo().SeleccionarHabilidad(IdRol).ForEach(delegate(Fila rolh)
            {
                Habilidad hab = new Habilidad();
                hab.CargarDatos(Convert.ToInt32(rolh.Celda("habilidad")));
                DgvHabilidades.Rows.Add(hab.Fila().Celda("id"),hab.Fila().Celda("categoria").ToString(), hab.Fila().Celda("habilidad").ToString(), hab.Fila().Celda("descripcion_habilidad").ToString(), hab.Fila().Celda("nivel").ToString());
            });
       
        }
        private void BorrarPrivilegio()
        {
            int PrivilegioSeleccionado = Convert.ToInt32(DgvPrivilegios.SelectedRows[0].Cells["id"].Value);

            Rol rolSeleccionado = new Rol();
            rolSeleccionado.SeleccionarRol(CmbRoles.Text);

            RolPrivilegio rolpriv = new RolPrivilegio();

            rolpriv.SeleccionarRolPrivilegio(Convert.ToInt32(rolSeleccionado.Fila().Celda("id")), PrivilegioSeleccionado);
            rolpriv.BorrarDatos();

            CargarPrivilegios(CmbRoles.Text);
        }
        private void BorrarHabilidad()
        {
            int habilidadSeleccionada = Convert.ToInt32(DgvHabilidades.SelectedRows[0].Cells["ID_HABILIDAD"].Value);
            Rol RolSeleccionado = new Rol();
            RolSeleccionado.SeleccionarRol(CmbRoles.Text);

            RolHabilidad rolhab = new RolHabilidad();

            rolhab.SeleccionarRolHabilidad(Convert.ToInt32(RolSeleccionado.Fila().Celda("id")), habilidadSeleccionada);
            rolhab.BorrarDatos();

            CargarHabilidades(CmbRoles.Text);
        }

        private void BorrarRol(string rol)
        {
            Rol seleccionado = new Rol();
            List<Fila> roles = Rol.Modelo().SeleccionarRol(rol);
            int IdRol = 0;

            if (roles.Count > 0)
                IdRol = Convert.ToInt32(roles[0].Celda("id"));

            seleccionado.CargarDatos(IdRol);
            seleccionado.BorrarDatos();
            CargarRoles();

            if (tabControl1.SelectedTab == tabPrivilegios)
                CargarPrivilegios(CmbRoles.Text);

            else if (tabControl1.SelectedTab == tabHabilidades)
                CargarHabilidades(CmbRoles.Text);
        }

        private void DgvPrivilegios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnQuitarPrivilegio.Enabled = true;
        }

        private void BtnQuitarPrivilegio_Click(object sender, EventArgs e)
        {
            if( DgvPrivilegios.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabPrivilegios )
            {
                BorrarPrivilegio();
            }

            else if (DgvHabilidades.SelectedRows.Count > 0 && tabControl1.SelectedTab == tabHabilidades)
            {
                BorrarHabilidad();
            }
        }

        private void BtnNuevoRol_Click(object sender, EventArgs e)
        {
            FrmNuevoRol nuevo = new FrmNuevoRol();
            
            if( nuevo.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                CargarRoles();
        }

        private void BtnEliminarRol_Click(object sender, EventArgs e)
        {
            BorrarRol(CmbRoles.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabHabilidades)
                CargarHabilidades(CmbRoles.Text);

            else if (tabControl1.SelectedTab == tabPrivilegios)
                CargarPrivilegios(CmbRoles.Text);
        }
    }
}
