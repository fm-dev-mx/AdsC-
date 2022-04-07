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
    public partial class FrmNuevaJunta : Ventana
    {
        List<string> TipoJunta = new List<string>();
        List<string> IdUsuario = new List<string>();
        List<string> NombreUsuario = new List<string>();
        public List<string> Invitados = new List<string>();

        string Titulo = string.Empty;
        bool Editar = false;
        public string Descripcion = string.Empty;
        public string Nombre = string.Empty;
        public int IdTopico = 0; 
        public string TipoDeJunta = string.Empty;
        public string FechaJunta;
        public DateTime RespaldoHora;

        public FrmNuevaJunta(List<string> tipoJunta, string descripcion, string titulo, string nombre, int idTopico, List<string> idUsuario, List<string> nombreUsuario, bool editar = false, DateTime? fechaMin=null, DateTime? fechaMax=null, int hora = 0)
        {
            InitializeComponent();
            TipoJunta = tipoJunta;
            Descripcion = descripcion;
            Titulo = titulo;
            Nombre = nombre;
            IdTopico = idTopico;
            Editar = editar;
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;

            if(fechaMin != null && fechaMax != null)
            {
                DtpFechaJunta.MinDate = fechaMin.Value;
                DtpFechaJunta.MaxDate = fechaMax.Value;
            }

            if(hora > 0)
            {
                DtpHora.Value = new DateTime(2000, 1, 1, hora, 0, 0);
            }
        }

        private void FrmNuevaJunta_Load(object sender, EventArgs e)
        {
            foreach (string junta in TipoJunta)
            {
                CmbTipoJunta.Items.Add(junta);
            }

            TxtDescripcion.Text = Descripcion;
            TxtNombre.Text = Nombre;

            if (TxtDescripcion.Text != "" && !Editar)
                TxtDescripcion.Enabled = false;
            if (TxtNombre.Text != "" && !Editar)
                TxtNombre.Enabled = false;

            CargarDgvInvitado(null);

        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    eliminarToolStripMenuItem.Enabled = true;
                    MenuOpciones.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void invitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario invitados = new FrmSeleccionarUsuario("", true);
            if (invitados.ShowDialog() == DialogResult.OK)
            {
                CargarDgvInvitado(invitados.UsuariosSeleccionados);
            }

            TxtDescripcion.Text = Descripcion;

        }

        public void CargarDgvInvitado(List<Usuario> listaInvitados)
        {
            List<string> usuario = new List<string>();
            List<string> idUsuario = new List<string>();

            usuario = NombreUsuario;
            idUsuario = IdUsuario;

            if (listaInvitados != null)
            {
                foreach (var invitado in listaInvitados)
                {
                    string nombreInvitado = invitado.NombreCompleto();
                    if(usuario == null || usuario.Find(x=> x.Contains(nombreInvitado)) == null)
                    {
                        if (idUsuario == null)
                            idUsuario = new List<string>();

                        if (usuario == null)
                            usuario = new List<string>();

                        idUsuario.Add(invitado.Fila().Celda("id").ToString());
                        usuario.Add(nombreInvitado);
                    }
                }
            }

            foreach (DataGridViewRow row in DgvInvitados.Rows)
            {
                if (usuario.Find(x=> x.Contains(row.Cells[1].Value.ToString())) == null)
                { 
                    idUsuario.Add(row.Cells[0].Value.ToString());
                    usuario.Add(row.Cells[1].Value.ToString());
                }
            }

            if (usuario == null)
                return;

            DgvInvitados.Rows.Clear();

            for (int i = 0; i < usuario.Count; i++)
                DgvInvitados.Rows.Add(idUsuario[i], usuario[i]);   
        }

        private void DgvInvitados_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvInvitados.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    eliminarToolStripMenuItem.Enabled = false;
                    MenuOpciones.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los datos que son borrados no podrán ser recuperados en el futuro. ¿Desea continuar?", "Borrar seguimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvInvitados.SelectedRows)
                    DgvInvitados.Rows.RemoveAt(row.Index);

                IdUsuario.Clear();
                NombreUsuario.Clear();

                foreach (DataGridViewRow row in DgvInvitados.Rows)
                {
                    IdUsuario.Add(row.Cells[0].Value.ToString());
                    NombreUsuario.Add(row.Cells[1].Value.ToString());
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            TipoDeJunta = CmbTipoJunta.Text;
            Descripcion = TxtDescripcion.Text;
            Nombre = TxtNombre.Text;
            FechaJunta = DtpFechaJunta.Value.ToShortDateString() + " " + DtpHora.Value.ToShortTimeString(); 

            foreach (DataGridViewRow row in DgvInvitados.Rows)
                Invitados.Add(row.Cells[0].Value.ToString());

            if (TxtNombre.Text != string.Empty && TxtDescripcion.Text != string.Empty && DgvInvitados.Rows.Count > 0 && CmbTipoJunta.Text != string.Empty)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Favor de llenar todos los campos", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DtpFechaJunta_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(DtpFechaJunta.Value).Date < DateTime.Now.Date)
            {
                MessageBox.Show("No puede seleccionar una fecha menor a la fecha actual", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DtpFechaJunta.Value = DateTime.Now;
            }
        }

        private void DtpHora_ValueChanged(object sender, EventArgs e)
        {
            if(Convert.ToDateTime(DtpFechaJunta.Value).Date == DateTime.Now.Date && DtpHora.Value.TimeOfDay < DateTime.Now.TimeOfDay)
            {
                MessageBox.Show("No puede seleccionar una hora menor a la hora actual", "Hora incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                DtpFechaJunta.Value = DateTime.Now;
            }
            
            if(ChkTodoElDia.Checked == false && (DtpHora.Value.Hour < 7 || DtpHora.Value.Hour > 18) )
            {
                MessageBox.Show("La hora debe ser entre 7:00 y 18:00", "Hora incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DtpHora.Value = new DateTime(2000, 1, 1, 8, 0, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void ChkTodoElDia_CheckedChanged(object sender, EventArgs e)
        {
            if(ChkTodoElDia.Checked == true)
            {
                RespaldoHora = DtpHora.Value;
                DtpHora.Value = new DateTime(2000, 1, 1, 0, 0, 0);
                DtpHora.Visible = false;
            }
            else
            {
                DtpHora.Value = RespaldoHora;
                DtpHora.Visible = true;
            }
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            Descripcion = TxtDescripcion.Text;
        }

    }
}
