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
    public partial class FrmInicio : Form
    {
        List<Fila> Subordinados = new List<Fila>();
        List<Fila> Habilidades = new List<Fila>();
        Fila PerfilCargado = new Fila();
        int IdUsuario = 0;
        bool LiderDeEquipo = false;

        protected Form Contenido = null;

        public FrmInicio(int idUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
        }

        public void MostrarContenido(Form contenido)
        {
            if(!(this.Contenido == null))
            {
                this.Contenido.Close();
            }
            
            Contenido = contenido;
            Contenido.MdiParent = this;
            Contenido.Show();
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;            
            string rol = Global.UsuarioActual.Fila().Celda("rol").ToString();
            int nivel = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("nivel"));

            PerfilCargado = PerfilPuesto.Modelo().Cargar(rol, nivel)[0];
            int idPerfil = Convert.ToInt32(PerfilCargado.Celda("id"));

            Subordinados = PerfilPuesto.Modelo().Subordinados(rol, nivel);
            Habilidades = PerfilHabilidad.Modelo().Habilidades(idPerfil);
            LblNombreEmpleado.Text = Global.UsuarioActual.NombreCompleto();
            LblPuestoEmpleado.Text = rol;
            
            if(nivel > 0)
                LblPuestoEmpleado.Text += " " + nivel;

            PanelInformacion.Visible = true;
            panelWindows.Visible = false;
            CargarEquipo(BuscarEquipo());
        }

        private void TvMenuEmpleado_DoubleClick(object sender, EventArgs e)
        {
            string opcion = "";
            if (TvMenuEmpleado.SelectedNode == null)
                return;

            panelWindows.Visible = false;
            
            if(TvMenuEmpleado.SelectedNode.Parent != null) 
                opcion = TvMenuEmpleado.SelectedNode.Parent.Text;
            else
                opcion = TvMenuEmpleado.SelectedNode.Text;
            
            panelWindows.Controls.Clear();

            switch (opcion.ToUpper())
            {
                case "MI PERFIL DE PUESTO":
                    MostrarPerfilDePuesto();
                    break;
                case "INFORMACIÓN":
                    FrmEditarInformacionEmpleado editarEmpleado = new FrmEditarInformacionEmpleado(IdUsuario);
                    editarEmpleado.WindowState = FormWindowState.Maximized;
                    break;
                case "MI EQUIPO DE CÓMPUTO":
                    panelWindows.Visible = true;
                    FrmEquipoComputoAsignado equipoAsignado = new FrmEquipoComputoAsignado(IdUsuario);
                    equipoAsignado.TopLevel = false;
                    equipoAsignado.AutoScroll = true;
                    this.panelWindows.Controls.Add(equipoAsignado);
                    equipoAsignado.WindowState = FormWindowState.Maximized;
                    equipoAsignado.FormBorderStyle = FormBorderStyle.None;
                    equipoAsignado.Show();
                    break;
                case "MI EQUIPO":

                    break;
                case "MIS EVALUACIONES":
                    panelWindows.Visible = true;
                    FrmEvaluacionesDesempeno desempeno = new FrmEvaluacionesDesempeno(IdUsuario);
                    desempeno.TopLevel = false;
                    desempeno.AutoScroll = true;
                    this.panelWindows.Controls.Add(desempeno);
                    desempeno.WindowState = FormWindowState.Maximized;
                    desempeno.FormBorderStyle = FormBorderStyle.None;
                    desempeno.Show();
                    break;
                    case "MIS ENCUESTAS":
                    panelWindows.Visible = true;
                    FrmConsultarEncuesta encuestas = new FrmConsultarEncuesta();
                    encuestas.TopLevel = false;
                    encuestas.AutoScroll = true;
                    this.panelWindows.Controls.Add(encuestas);
                    encuestas.WindowState = FormWindowState.Maximized;
                    encuestas.FormBorderStyle = FormBorderStyle.None;
                    encuestas.Show();
                    break;
                    case "MIS ACCIONES 5S'S":
                    panelWindows.Visible = true;
                    FrmConsultarAccionesAuditoria auditoria = new FrmConsultarAccionesAuditoria(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
                    auditoria.TopLevel = false;
                    auditoria.AutoScroll = true;
                    this.panelWindows.Controls.Add(auditoria);
                    auditoria.WindowState = FormWindowState.Maximized;
                    auditoria.FormBorderStyle = FormBorderStyle.None;
                    auditoria.Show();
                    break;
                case "MI MONITOR":
                    panelWindows.Visible = true;
                    FrmMiMonitor miMonitor = new FrmMiMonitor();
                    miMonitor.TopLevel = false;
                    miMonitor.AutoScroll = true;
                    this.panelWindows.Controls.Add(miMonitor);
                    miMonitor.WindowState = FormWindowState.Maximized;
                    miMonitor.FormBorderStyle = FormBorderStyle.None;
                    miMonitor.Show();
                    break;
            }
        }

        public void MostrarPerfilDePuesto()
        {
            panelWindows.Visible = true;
            byte[] perfilPuesto = FormatosPDF.PerfilPuesto(PerfilCargado, Subordinados, Habilidades);

            FrmVisorPDF visor = new FrmVisorPDF(perfilPuesto, "PEFIL DE PUESTO");
            visor.TopLevel = false;
            visor.AutoScroll = true;
            this.panelWindows.Controls.Add(visor);
            visor.FormBorderStyle = FormBorderStyle.None;
            visor.Show();
            visor.WindowState = FormWindowState.Maximized;
        }

        public int BuscarEquipo()
        {
            int equipo = 0;
            EquipoTrabajo equipoTrabajo = new EquipoTrabajo();
            EquipoTrabajoIntegrantes integrantesEquipo = new EquipoTrabajoIntegrantes();
            equipoTrabajo.BuscarEquipoPorLider(IdUsuario);
            if (equipoTrabajo.TieneFilas())
            {
                equipo = Convert.ToInt32(equipoTrabajo.Fila().Celda("id"));
                LiderDeEquipo = true;
            }
            else
            {
                integrantesEquipo.BuscarEquipoPorLider(IdUsuario);
                if (integrantesEquipo.TieneFilas())
                    equipo = Convert.ToInt32(integrantesEquipo.Fila().Celda("equipo"));
            }
            return equipo;
        }

        private void CargarEquipo(int idEquipo)
        {
            TreeNode nodoEquipoIntegrantes = null;

            EquipoTrabajo equipoTrabajo = new EquipoTrabajo();
            Usuario usuario = new Usuario();
            EquipoTrabajoIntegrantes integrantesEquipo = new EquipoTrabajoIntegrantes();
            equipoTrabajo.CargarDatos(idEquipo);

            if(equipoTrabajo.TieneFilas())
            {
                TreeNode nodoLider = TvMenuEmpleado.Nodes["Node5"];
                usuario.CargarDatos(Convert.ToInt32(equipoTrabajo.Fila().Celda("lider")));
                string nombre = equipoTrabajo.Fila().Celda("lider") + " - " + Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");
                nodoEquipoIntegrantes = nodoLider.Nodes.Add(nombre);
                nodoEquipoIntegrantes.ImageIndex = 7;
                nodoEquipoIntegrantes.SelectedImageIndex = 7;
            }

            integrantesEquipo.CargarEquipo(idEquipo).ForEach(delegate(Fila filaIntegrantes)
            {
                TreeNode nodoEquipo = TvMenuEmpleado.Nodes["Node5"];
                string nombre = filaIntegrantes.Celda("id").ToString() + " - " + Global.ObjetoATexto(filaIntegrantes.Celda("nombre"), "") + " " + Global.ObjetoATexto(filaIntegrantes.Celda("paterno"), "");
                nodoEquipoIntegrantes = nodoEquipo.Nodes.Add(nombre);
                nodoEquipoIntegrantes.ImageIndex = 8;
                nodoEquipoIntegrantes.SelectedImageIndex = 8;
            });
        }

        private void Evaluar(int idUsuarioAEvaluar)
        {
            int evaluacion = 0;
            Evaluacion evaluaciones = new Evaluacion();
            evaluaciones.VerificarEvaluacionPendiente(idUsuarioAEvaluar, Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));

            if(evaluaciones.TieneFilas())
            {
                evaluacion  = Convert.ToInt32(Global.ObjetoATexto(evaluaciones.Fila().Celda("id"), "0"));

                FrmEvaluarDesempeno evaluar = new FrmEvaluarDesempeno(idUsuarioAEvaluar, evaluacion);
                evaluar.TopLevel = false;
                evaluar.AutoScroll = true;
                this.panelWindows.Controls.Add(evaluar);
                evaluar.WindowState = FormWindowState.Maximized;
                evaluar.FormBorderStyle = FormBorderStyle.None;
                evaluar.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Desea crear una evaluación?", "Nueva evaluación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    FrmEvaluarDesempeno evaluar = new FrmEvaluarDesempeno(idUsuarioAEvaluar, 0);
                    evaluar.TopLevel = false;
                    evaluar.AutoScroll = true;
                    this.panelWindows.Controls.Add(evaluar);
                    evaluar.WindowState = FormWindowState.Maximized;
                    evaluar.FormBorderStyle = FormBorderStyle.None;
                    evaluar.Show();
                }
            }
        }

        private void BtnMantenimientoCorrectivo_Click(object sender, EventArgs e)
        {
            FrmGenerarOrdenMtoEquipoComputo ordenMantenimiento = new FrmGenerarOrdenMtoEquipoComputo();
            ordenMantenimiento.Show();
        }

        private void TvMenuEmpleado_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode tvNodo = TvMenuEmpleado.GetNodeAt(e.X, e.Y);
            if (tvNodo == null)
                return;

            if (tvNodo.Parent == null)
                return;

            if (tvNodo.Parent.Text != "Mi equipo")
                return;
                       
            if (e.Button == MouseButtons.Right)
            {
                evaluarToolStripMenuItem.Visible = true;
                MenuIntegranteEquipo.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void evaluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelWindows.Visible = true;
            if (!TvMenuEmpleado.SelectedNode.Text.Contains("-"))
                return;

            string[] datosSeleccionado = TvMenuEmpleado.SelectedNode.Text.ToString().Split('-');
            int idUsuarioSeleccionado = Convert.ToInt32(datosSeleccionado[0].Trim());

            //Miembros del equipo evaluan a lider
            if (!LiderDeEquipo)
            {
                if (TvMenuEmpleado.SelectedNode.Index == 0)
                    Evaluar(idUsuarioSeleccionado);
            }
            else //Lider evalua a miembros del equipo
            {
                if (idUsuarioSeleccionado != Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")))
                    Evaluar(idUsuarioSeleccionado);
            }
        }

        private void evaluacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelWindows.Visible = true;
            if (!TvMenuEmpleado.SelectedNode.Text.Contains("-"))
                return;

            string[] datosSeleccionado = TvMenuEmpleado.SelectedNode.Text.ToString().Split('-');
            int idUsuarioSeleccionado = Convert.ToInt32(datosSeleccionado[0].Trim());

            FrmEvaluacionesDesempeno evaluaciones = new FrmEvaluacionesDesempeno(idUsuarioSeleccionado);
            evaluaciones.TopLevel = false;
            evaluaciones.AutoScroll = true;
            this.panelWindows.Controls.Add(evaluaciones);
            evaluaciones.WindowState = FormWindowState.Maximized;
            evaluaciones.FormBorderStyle = FormBorderStyle.None;
            evaluaciones.Show();
        }

        private void tiempoExtraPlanificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelWindows.Visible = true;
            if (!TvMenuEmpleado.SelectedNode.Text.Contains("-"))
                return;

            string[] datosSeleccionado = TvMenuEmpleado.SelectedNode.Text.ToString().Split('-');
            int idUsuarioSeleccionado = Convert.ToInt32(datosSeleccionado[0].Trim());

            FrmTiempoExtraEmpleado textra = new FrmTiempoExtraEmpleado(idUsuarioSeleccionado);
            textra.TopLevel = false;
            textra.AutoScroll = true;
            this.panelWindows.Controls.Add(textra);
            textra.WindowState = FormWindowState.Maximized;
            textra.FormBorderStyle = FormBorderStyle.None;
            textra.Show();
        }

        private void FrmInicio_Shown(object sender, EventArgs e)
        {
            TvMenuEmpleado.SelectedNode = TvMenuEmpleado.Nodes.Find("Mi monitor", true)[0];
            TvMenuEmpleado_DoubleClick(this, EventArgs.Empty);
        }
    }
}
