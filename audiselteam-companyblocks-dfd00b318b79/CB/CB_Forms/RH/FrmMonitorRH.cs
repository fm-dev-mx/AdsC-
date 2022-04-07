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

    public partial class FrmMonitorRH : Form
    {
        List<Fila> Subordinados = new List<Fila>();
        List<Fila> Habilidades = new List<Fila>();
        Fila PerfilCargado = new Fila();
        Usuario UsuarioCargado = new Usuario();
        protected Form Contenido = null;

        public FrmMonitorRH()
        {
            InitializeComponent();
        }

        private void BtnPuestos_Click(object sender, EventArgs e)
        {
            FrmAdministrarPuestos puestos = new FrmAdministrarPuestos();
            puestos.Show();
        }

        public void CargarPuestos()
        {
            PanelInformacion.Visible = false;
            CmbPuestos.Items.Clear();
            Rol.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbPuestos.Items.Add(f.Celda("rol"));
            });
            CargarEmpleados(CmbPuestos.Text);
        }

        void CargarEmpleados(string puesto)
        {
            CmbEmpleados.Items.Clear();
            Usuario.Modelo().SeleccionarRol(puesto).ForEach(delegate(Fila f)
            {
                if( Convert.ToBoolean(f.Celda("activo")) == true )
                    CmbEmpleados.Items.Add(f.Celda("id") + " - " + f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString());
            });
        }

        private void FrmMonitorRH_Load(object sender, EventArgs e)
        {
            CargarPuestos();
        }

        private void CmbPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Contenido != null)
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("Seguro que quieres seleccionar otro puesto?", "Seleccionar puesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    Contenido.Close();
                    Contenido = null;
                }
                else return;
            }
            PanelInformacion.Visible = false;
            CargarEmpleados(CmbPuestos.Text);
        }

        private void CmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idUsuario = 0;
            string[] partesIdUsuario = CmbEmpleados.Text.Split('-');

            if(partesIdUsuario.Count() > 0)
            {
                idUsuario = Convert.ToInt32(partesIdUsuario[0]);
                CargarPerfilUsuario(idUsuario);
            }
        }

        void CargarPerfilUsuario(int idUsuario)
        {
            if (Contenido != null)
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("Seguro que quieres cargar el perfil del usuario seleccionado?", "Cargar perfil de usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    Contenido.Close();
                    Contenido = null;
                }
                else return;
            }

            string rol = string.Empty;
            int nivel = 0;
            int idPerfil = 0;

            UsuarioCargado.CargarDatos(idUsuario);

            if (!UsuarioCargado.TieneFilas())
            {
                MessageBox.Show("El usuario no fue encontrado!", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            rol = UsuarioCargado.Fila().Celda("rol").ToString();
            nivel = Convert.ToInt32(UsuarioCargado.Fila().Celda("nivel"));

            PerfilCargado = PerfilPuesto.Modelo().Cargar(rol, nivel)[0];
            idPerfil = Convert.ToInt32(PerfilCargado.Celda("id"));

            Subordinados = PerfilPuesto.Modelo().Subordinados(rol, nivel);
            Habilidades = PerfilHabilidad.Modelo().Habilidades(idPerfil);

            PanelInformacion.Visible = true;
            LblNombreEmpleado.Text = UsuarioCargado.NombreCompleto();

            LblPuestoEmpleado.Text = UsuarioCargado.Fila().Celda("rol").ToString();           

            if (nivel > 0)
                LblPuestoEmpleado.Text += " " + nivel;
        }

        public void MostrarContenido(Form contenido)
        {
            if (!(this.Contenido == null))
            {
                this.Contenido.Close();
            }

            this.Contenido = contenido;
            this.Contenido.MdiParent = this;
            this.Contenido.Show();
        }

        private void TvMenuEmpleado_DoubleClick(object sender, EventArgs e)
        {
            if (TvMenuEmpleado.SelectedNode == null)
                return;

            string opcion = TvMenuEmpleado.SelectedNode.Text;

            switch(opcion.ToUpper())
            {
                case "PERFIL DE PUESTO":
                    MostrarPerfilDePuesto();
                    break;
                case "INFORMACIÓN":
                    FrmEditarInformacionEmpleado editarEmpleado = new FrmEditarInformacionEmpleado(Convert.ToInt32(UsuarioCargado.Fila().Celda("id")));
                    MostrarContenido(editarEmpleado);                   
                    editarEmpleado.WindowState = FormWindowState.Maximized;
                    editarEmpleado._Puesto += editarEmpleado__Puesto;
                    editarEmpleado._ActualizarNombre += editarEmpleado__ActualizarNombre;
                    break;
                case "EQUIPO DE CÓMPUTO ASIGNADO":
                    FrmEquipoComputoAsignado equipoAsignado = new FrmEquipoComputoAsignado(Convert.ToInt32(UsuarioCargado.Fila().Celda("id")));
                    MostrarContenido(equipoAsignado);
                    equipoAsignado.WindowState = FormWindowState.Maximized;
                    break;
                case "EVALUACIONES DE DESEMPEÑO":
                    FrmEvaluacionesDesempeno desempeno = new FrmEvaluacionesDesempeno(Convert.ToInt32(UsuarioCargado.Fila().Celda("id")));
                    MostrarContenido(desempeno);
                    desempeno.WindowState = FormWindowState.Maximized;
                    break;
            }
        }

        void editarEmpleado__Puesto(string puesto)
        {
            if (puesto != null || puesto != "")
            {
                CmbPuestos.SelectedItem = puesto;
                CargarEmpleados(CmbPuestos.Text);
            }
        }

        void editarEmpleado__ActualizarNombre(string nombre)
        {
            if (nombre != null || nombre != "")
            {
                CmbEmpleados.SelectedItem = Convert.ToInt32(UsuarioCargado.Fila().Celda("id")).ToString() + " - " + nombre;
            }
        }

        public void MostrarPerfilDePuesto()
        {
            byte[] perfilPuesto = FormatosPDF.PerfilPuesto(PerfilCargado, Subordinados, Habilidades);

            FrmVisorPDF visor = new FrmVisorPDF(perfilPuesto, "PEFIL DE PUESTO");
            MostrarContenido(visor);
            visor.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAltaEmpleado alta = new FrmAltaEmpleado();
            if(alta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string materno = "N/A";
                string telefono = "N/A";
                Fila insertarUsuario = new Fila();
                insertarUsuario.AgregarCelda("nombre", alta.NombreUsuario);
                insertarUsuario.AgregarCelda("paterno", alta.Paterno);

                if (alta.Materno != "")
                    materno = alta.Materno;

                if (alta.Telefono != "")
                    telefono = alta.Telefono;
                try
                {
                    insertarUsuario.AgregarCelda("materno", materno);
                    insertarUsuario.AgregarCelda("correo", alta.Correo);
                    insertarUsuario.AgregarCelda("tel", telefono);
                    insertarUsuario.AgregarCelda("rol", alta.Puesto);
                    insertarUsuario.AgregarCelda("nivel", alta.nivel);
                    insertarUsuario.AgregarCelda("password", Global.CalcularHashMD5(alta.Contrasena));
                    insertarUsuario.AgregarCelda("fecha_alta", DateTime.Now);
                    insertarUsuario.AgregarCelda("activo", 1);

                    if(alta.Apodo != "")
                        insertarUsuario.AgregarCelda("nick_name", alta.Apodo);

                    Usuario.Modelo().Insertar(insertarUsuario);
                    CargarPuestos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ocurrió un problema mientras se guardaba la información, verifique que el usuario no esté duplicado. Si el problema continúa contacte al personal de sistemas.\r\nError: \r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TvMenuEmpleado_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void BtnProduccion_Click(object sender, EventArgs e)
        {
            FrmEquipoTrabajo equipo = new FrmEquipoTrabajo();
            equipo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMonitorearEncuestas encuestas = new FrmMonitorearEncuestas();
            encuestas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmVacante vacante = new FrmVacante();
            vacante.Show();
        }

        private void BtnCapacitacion_Click(object sender, EventArgs e)
        {
            FrmCapacitacion capacitacion = new FrmCapacitacion();
            capacitacion.Show();
        }
    }
}
