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
    public partial class FrmCrearEncuesta : Ventana
    {
        int IdUsuario = 0;

        public FrmCrearEncuesta(int idUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
        }

        private void FrmCrearEncuesta_Load(object sender, EventArgs e)
        {
            CargarPlantillas();
            TxtFechaCaducidad.Text = Global.FechaATexto(CalcularCaducidad());
        }

        void CargarPlantillas()
        {
            PlantillaEncuesta plantilla = new PlantillaEncuesta();
            plantilla.SeleccionarPlantillas().ForEach(delegate(Fila f)
            {
                CmbPlantillas.Items.Add(f.Celda("id") + "-" + Global.ObjetoATexto(f.Celda("nombre"), ""));
            });
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario("", true);
            if (usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DgvUsuarios.Rows.Clear();

                foreach (var nombreUsuario in usuario.UsuariosSeleccionados)
                {
                    string nombre = Global.ObjetoATexto(nombreUsuario.Fila().Celda("nombre"), "") + " " +
                                    Global.ObjetoATexto(nombreUsuario.Fila().Celda("paterno"), "");

                    DgvUsuarios.Rows.Add(Global.ObjetoATexto(nombreUsuario.Fila().Celda("id"), ""), nombre);
                }
            }
        }

        private DateTime CalcularCaducidad()
        {
            return DateTime.Now.AddDays(Convert.ToInt32(NumDiasCaducidad.Value));
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if (CmbPlantillas.Text == "" || DgvUsuarios.Rows.Count == 0)
                return;

            DialogResult result = MessageBox.Show("¿Está seguro que desea crear una nueva encuesta con la plantilla " + CmbPlantillas.Text + " con una duración de " + NumDiasCaducidad.Value + " días, finalizando en " + TxtFechaCaducidad.Text + "?", "Crear encuesta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvUsuarios.Rows)
                {
                    Fila insertarNuevaEncuesta = new Fila();
                    insertarNuevaEncuesta.AgregarCelda("plantilla", CmbPlantillas.Text.Split('-')[0].Trim());
                    insertarNuevaEncuesta.AgregarCelda("usuario_encuestado", row.Cells["id"].Value);
                    insertarNuevaEncuesta.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id").ToString());
                    insertarNuevaEncuesta.AgregarCelda("fecha_creacion", DateTime.Now);
                    insertarNuevaEncuesta.AgregarCelda("estatus", "PENDIENTE");
                    insertarNuevaEncuesta.AgregarCelda("caducidad", NumDiasCaducidad.Value);
                    insertarNuevaEncuesta.AgregarCelda("comentarios", TxtComentarios.Text);
                    Encuesta.Modelo().Insertar(insertarNuevaEncuesta);
                }

                MessageBox.Show("La encuesta fue creada correctamente", "Encuesta creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void NumDiasCaducidad_ValueChanged(object sender, EventArgs e)
        {
            TxtFechaCaducidad.Text = Global.FechaATexto(CalcularCaducidad());
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGlobal_Click(object sender, EventArgs e)
        {
            DgvUsuarios.Rows.Clear();

            Usuario usuario = new Usuario();
            usuario.Activos().ForEach(delegate(Fila f)
            {
                string nombre = Global.ObjetoATexto(f.Celda("nombre"), "") + " " +
                                    Global.ObjetoATexto(f.Celda("paterno"), "");

                DgvUsuarios.Rows.Add(Global.ObjetoATexto(f.Celda("id"), ""), nombre);
            });
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            DgvUsuarios.Rows.Clear();
        }

        private void BtnUsuario_MouseHover(object sender, EventArgs e)
        {
           ToolTipGeneral.SetToolTip(BtnUsuario, "Selecciona uno o varios usuarios en específico");
        }

        private void BtnGlobal_MouseHover(object sender, EventArgs e)
        {
            ToolTipGeneral.SetToolTip(BtnGlobal, "Selecciona a todos los empleados actuales");
        }

    }
}
