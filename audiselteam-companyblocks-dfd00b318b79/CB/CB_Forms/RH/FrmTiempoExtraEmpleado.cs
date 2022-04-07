using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmTiempoExtraEmpleado : Form
    {
        decimal TotalHorasExtra = 0;
        int IdUsuario = 0;

        public FrmTiempoExtraEmpleado(int idUsuario=0)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
        }

        private void FrmTiempoExtraEmpleado_Load(object sender, EventArgs e)
        {
            if(IdUsuario == 0)
            {
                CargarDepartamentos();
                CmbDepartamento.Enabled = true;
                CmbEmpleado.Enabled = true;
                LblEtiquetaEquipo.Visible = true;
                CmbEquipo.Visible = true;
                LblEtiquetaSupervisor.Visible = true;
                TxtNombreSupervisor.Visible = true;
            }
            else
            {
                CmbDepartamento.Enabled = false;
                CmbEmpleado.Enabled = false;
                LblEtiquetaEquipo.Visible = false;
                CmbEquipo.Visible = false;
                LblEtiquetaSupervisor.Visible = false;
                TxtNombreSupervisor.Visible = false;

                Usuario usr = new Usuario();
                PerfilPuesto perfil = new PerfilPuesto();
                EquipoTrabajo equipo = new EquipoTrabajo();
                usr.CargarDatos(IdUsuario);

                if(usr.TieneFilas())
                {
                    perfil.Cargar(usr.Fila().Celda("rol").ToString(), Convert.ToInt32(usr.Fila().Celda("nivel")));
                    CargarDepartamentos();
                    CmbDepartamento.Text = perfil.Fila().Celda("departamento").ToString();

                    CmbEmpleado.Items.Clear();
                    CmbEmpleado.Items.Add(usr.Fila().Celda("id").ToString() + " - " + usr.Fila().Celda("nombre") + " " + usr.Fila().Celda("paterno"));
                    CmbEmpleado.Text = usr.Fila().Celda("id").ToString() + " - " + usr.Fila().Celda("nombre") + " " + usr.Fila().Celda("paterno");
                }

            }
            int numeroSemana = Global.NumeroSemanaYear();
            NumSemanaYear.Value = numeroSemana;
            autorizarToolStripMenuItem.Enabled = Global.VerificarPrivilegio("AUTORIZAR", "AUTORIZAR TIEMPO EXTRA");
        }

        public void CargarDepartamentos()
        {
            CmbDepartamento.Items.Clear();
            PerfilPuesto.Modelo().Departamentos().ForEach(delegate(string depto)
            {
                if(depto.Trim() != string.Empty)
                    CmbDepartamento.Items.Add(depto);
            });
            CmbEquipo.Items.Clear();
            CmbEmpleado.Items.Clear();
            DgvActividades.Rows.Clear();
            TotalHorasExtra = 0;
        }

        public void CargarEquipos()
        {
            CmbEquipo.Items.Clear();
            EquipoTrabajo.Modelo().CargarEquipos(CmbDepartamento.Text, "TODOS").ForEach(delegate(Fila f)
            {
                CmbEquipo.Items.Add(f.Celda("id").ToString().PadLeft(3, '0'));
            });
            CmbEmpleado.Items.Clear();
            DgvActividades.Rows.Clear();
            TotalHorasExtra = 0;
        }

        public void CargarUsuarios()
        {
            int idEquipo = Convert.ToInt32(CmbEquipo.Text);
            EquipoTrabajo equipo = new EquipoTrabajo();
            equipo.CargarDatos(idEquipo);

            Usuario lider = new Usuario();
            lider.CargarDatos(Convert.ToInt32(equipo.Fila().Celda("lider")));
            TxtNombreSupervisor.Text = lider.Fila().Celda("id") + " - " + lider.NombreCompleto();

            CmbEmpleado.Items.Clear();
            CmbEmpleado.Items.Add(TxtNombreSupervisor.Text);
            EquipoTrabajoIntegrantes.Modelo().CargarEquipo(idEquipo).ForEach(delegate(Fila f)
            {
                CmbEmpleado.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
            DgvActividades.Rows.Clear();
            TotalHorasExtra = 0;
        }

        private void CmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEquipos();
        }

        private void CmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CmbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarActividades();
            DateDesde.Enabled = CmbEmpleado.Text != string.Empty;
        }

        public void CargarActividades()
        {
            if (CmbEmpleado.Text.Trim() == string.Empty)
                return;

            int idEmpleado = Convert.ToInt32(CmbEmpleado.Text.Split('-')[0]);

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvActividades);
            DgvActividades.Rows.Clear();
            TotalHorasExtra = 0;
            ActividadesTiempoExtra.Modelo().SeleccionarUsuario(idEmpleado, DateDesde.Value, DateHasta.Value).ForEach(delegate(Fila f)
            {
                string usuarioAutorizacion = "N/A";
                int idUsuarioAutorizacion = Convert.ToInt32(f.Celda("usuario_autorizacion"));

                if(idUsuarioAutorizacion > 0)
                {
                    Usuario usrAuto = new Usuario();
                    usrAuto.CargarDatos(idUsuarioAutorizacion);

                    if (usrAuto.TieneFilas())
                        usuarioAutorizacion = usrAuto.NombreCompleto();
                }
                
                DgvActividades.Rows.Add(f.Celda("id"), Global.FechaATexto(f.Celda("fecha"), false), f.Celda("actividad"),
                                        f.Celda("tiempo_requerido"), f.Celda("estatus_autorizacion"), usuarioAutorizacion,
                                        Global.FechaATexto(f.Celda("fecha_autorizacion"), false),
                                        f.Celda("estatus_cumplimiento"), f.Celda("comentarios_cumplimiento"));

                if(f.Celda("estatus_autorizacion").ToString() == "AUTORIZADO")
                    TotalHorasExtra += Convert.ToDecimal(f.Celda("tiempo_requerido"));
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvActividades);
            LblTotalHorasExtras.Text = TotalHorasExtra.ToString() + " horas";
        }

        private void DateDesde_ValueChanged(object sender, EventArgs e)
        {
            DateHasta.Value = DateDesde.Value.AddDays(6);
            CargarActividades();
        }

        private void DateHasta_ValueChanged(object sender, EventArgs e)
        {
        }

        private void NumSemanaYear_ValueChanged(object sender, EventArgs e)
        {
            DateDesde.Value = Global.FechaIncialSemanaYear(DateTime.Now.Year, (int)NumSemanaYear.Value);
        }

        private void autorizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvActividades.SelectedRows.Count == 0)
                return;

            DialogResult resp = MessageBox.Show("Seguro que quieres autorizar la actividad seleccionada?", "Autorizar tiempo extra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            int idActividad = Convert.ToInt32(DgvActividades.SelectedRows[0].Cells[0].Value);

            ActividadesTiempoExtra act = new ActividadesTiempoExtra();
            act.CargarDatos(idActividad);

            if (act.TieneFilas())
            {
                act.Fila().ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                act.Fila().ModificarCelda("usuario_autorizacion", Global.UsuarioActual.Fila().Celda("id"));
                act.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                act.GuardarDatos();
                CargarActividades();
            }
        }
    }
}
