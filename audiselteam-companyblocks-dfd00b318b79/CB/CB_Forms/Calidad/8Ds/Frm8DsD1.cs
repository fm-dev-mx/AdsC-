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
    public partial class Frm8DsD1 : Form
    {
        int IdProblemaPlanteado = 0;
        Problema ProblemaPlanteado = new Problema();
        ProblemaGrupo Grupo = new ProblemaGrupo();
        List<int> Integrantes = new List<int>();

        public Frm8DsD1(int idProblemaPlanteado)
        {
            InitializeComponent();
            IdProblemaPlanteado = idProblemaPlanteado;
        }

        private void Frm8DsD1_Load(object sender, EventArgs e)
        {
            MostrarAyuda();
            CargarRoles();
            ProblemaPlanteado.CargarDatos(IdProblemaPlanteado);
            CargarIntegrantes();
        }

        public void CargarIntegrantes()
        {
            Grupo.SeleccionarProblema(IdProblemaPlanteado);

            DgvEquipo.Rows.Clear();
            Grupo.Filas().ForEach(delegate(Fila f)
            {
                DgvEquipo.Rows.Add(f.Celda("id_usuario"), f.Celda("rol_usuario"), f.Celda("nombre_usuario") + " " + f.Celda("paterno_usuario"));
                Integrantes.Add(Convert.ToInt32(f.Celda("id_usuario")));
            });
        }

        public void CargarRoles()
        {
            CmbRol.Items.Clear();
            Rol.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbRol.Items.Add(f.Celda("rol"));
            });
        }

        public void CargarUsuarios(string rol)
        {
            BtnAgregar.Enabled = false;
            CmbUsuario.Items.Clear();

            Usuario.Modelo().SeleccionarRolActivos(rol).ForEach(delegate(Fila f)
            {
                if (!Integrantes.Contains(Convert.ToInt32(f.Celda("id"))))
                {
                    CmbUsuario.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString());
                }
            });
        }


        public void MostrarAyuda()
        {
            string mensajeAyuda = Environment.NewLine;
            mensajeAyuda += "Selecciona a los líderes de cada disciplina, quienes deberán trabajar en equipo usando sus conocimientos y experiencia para ayudarte a analizar y resolver el problema.";
            TooltipAyuda.Show(mensajeAyuda, this, 200, 200, 10000);
        }

        private void DgvEquipo_MouseDown(object sender, MouseEventArgs e)
        {
            TooltipAyuda.Hide(this);
        }

        private void CmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUsuarios(CmbRol.Text);
        }

        private void CmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAgregar.Enabled = CmbUsuario.Text != string.Empty;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(CmbUsuario.Text.Split('-')[0]);
            string nombreUsuario = CmbUsuario.Text.Split('-')[1].Trim();

            Integrantes.Add(idUsuario);

            Fila integrante = new Fila();
            integrante.AgregarCelda("problema", IdProblemaPlanteado);
            integrante.AgregarCelda("integrante", idUsuario);
            ProblemaGrupo.Modelo().Insertar(integrante);

            DgvEquipo.Rows.Add(idUsuario, CmbRol.Text, nombreUsuario);
            CmbUsuario.Items.Remove(CmbUsuario.Text);
            BtnAgregar.Enabled = false;
        }

        private void MenuEquipo_Opening(object sender, CancelEventArgs e)
        {
            quitarIntegranteToolStripMenuItem.Enabled = DgvEquipo.SelectedRows.Count > 0;
        }

        private void quitarIntegranteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(DgvEquipo.SelectedRows[0].Cells[0].Value);

            int idUsuarioRegistroProblema = Convert.ToInt32(ProblemaPlanteado.Fila().Celda("usuario_registro"));

            if(idUsuario == idUsuarioRegistroProblema)
            {
                MessageBox.Show("No es posible quitar del grupo a la persona que registró el problema", "Quitar integrante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult resp = MessageBox.Show("¿Seguro que quieres quitar el integrante seleccionado?", "Quitar integrante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            ProblemaGrupo pg = new ProblemaGrupo();
            pg.SeleccionarIntegrante(IdProblemaPlanteado, idUsuario);

            if (pg.TieneFilas())
                pg.BorrarDatos();

            Integrantes.Remove(idUsuario);
            DgvEquipo.Rows.RemoveAt(DgvEquipo.SelectedRows[0].Index);
            CargarUsuarios(CmbRol.Text);
        }
    }
}
