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
using System.IO;

namespace CB
{
    public partial class FrmDetallesBug : Ventana
    {
        int IdBug;
        Bug BugCargado = new Bug();
        public FrmDetallesBug(int idBug)
        {
            InitializeComponent();
            IdBug = idBug;
            BugCargado.CargarDatos(IdBug);
        }

        public void CargarResponsables()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvResponsables);
            DgvResponsables.Rows.Clear();

            BugResponsable.Modelo().SeleccionarBug(IdBug).ForEach(delegate(Fila f)
            {
                DgvResponsables.Rows.Add(f.Celda("id"), f.Celda("responsable"));
            });

            Global.RecuperarFilaSeleccionada(DgvResponsables, fila);
            editarToolStripMenuItem.Enabled = false;
            borrarToolStripMenuItem.Enabled = false;
        }

        private void CargarBug()
        {
            if (BugCargado.TieneFilas())
            {
                TxtDescripcion.Text = BugCargado.Fila().Celda("descripcion").ToString();
                LblOrigen.Text = BugCargado.Fila().Celda("origen").ToString();
                LblCategoria.Text = BugCargado.Fila().Celda("categoria").ToString();
                LblEstatus.Text = BugCargado.Fila().Celda("estatus").ToString();
            }
        }

        private void CargarNotas()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvNotas);
            DgvNotas.Rows.Clear();
            BugNota.Modelo().SeleccionarBug(IdBug).ForEach(delegate(Fila f) 
            {
                string fecha = Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMM dd yyyy hh:mm:ss tt");
                DgvNotas.Rows.Add(f.Celda("id"),fecha, f.Celda("usuario_creacion"));
            });

            Global.RecuperarFilaSeleccionada(DgvNotas, fila);
            editarToolStripMenuItem.Enabled = false;
            borrarToolStripMenuItem.Enabled = false;
           
        }

        public  void CargarAdjuntos()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvAdjuntos);
            DgvAdjuntos.Rows.Clear();
            BugAdjunto.Modelo().SeleccionarBug(IdBug).ForEach(delegate(Fila f)
            {
                DgvAdjuntos.Rows.Add(f.Celda("id"), f.Celda("usuario_creacion"), Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMMM dd yyyy hh:mm:ss tt"), f.Celda("nombre_archivo"), f.Celda("tipo"));
            });

            Global.RecuperarFilaSeleccionada(DgvAdjuntos, fila);
            editarToolStripMenuItem.Enabled = false;
            borrarToolStripMenuItem.Enabled = false;
            
        }

        private void MostrarNotas(int IdNota)
        {
            if (IdNota == 0)
            {
                TxtNota.Text = "";
                LblNotaSeleccionada.Text = "Selecciona una nota";
                return;
            }

            BugNota nota = new BugNota();
            nota.CargarDatos(IdNota);
            if (nota.TieneFilas())
            {
                LblNotaSeleccionada.Text = nota.Fila().Celda("usuario_creacion").ToString() + " / " + Convert.ToDateTime(nota.Fila().Celda("fecha_creacion")).ToString("MMMM dd yyyy hh:mm:ss tt") + "(SOLO LECTURA)";
                TxtNota.Text = nota.Fila().Celda("nota").ToString();
                TxtNota.ReadOnly = true;
            }
        }

        public void Adjuntar()
        {
            if (SeleccionarAdjunto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                byte[] bytesArchivo = File.ReadAllBytes(SeleccionarAdjunto.FileName);
                int maxMB = Global.MySqlMaxAllowedPackets();

                if (bytesArchivo.Length / (1024 * 1024) > maxMB)
                {
                    MessageBox.Show("El archivo es demasiado grande para Adjuntarlo, debe ser máximo " + maxMB, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Fila adjunto = new Fila();
                adjunto.AgregarCelda("bug", IdBug);
                adjunto.AgregarCelda("nombre_archivo", SeleccionarAdjunto.SafeFileName);
                adjunto.AgregarCelda("tipo", Path.GetExtension(SeleccionarAdjunto.FileName));
                adjunto.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                adjunto.AgregarCelda("fecha_creacion", DateTime.Now);
                adjunto = BugAdjunto.Modelo().Insertar(adjunto);

                Fila archivoAdjunto = new Fila();
                archivoAdjunto.AgregarCelda("adjunto", adjunto.Celda("id"));
                archivoAdjunto.AgregarCelda("archivo", bytesArchivo);
                ArchivoBug.Modelo().Insertar(archivoAdjunto);
                
                CargarAdjuntos();
            }
        }

        public void BorrarResponsable()
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que deseea borrar las personas seleccionadas?", "Borrar Responsable", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach (DataGridViewRow row in DgvResponsables.SelectedRows)
            {
                int idResponsable = Convert.ToInt32(row.Cells["id_responsable"].Value);
                BugResponsable resp = new BugResponsable();
                resp.CargarDatos(idResponsable);
                resp.BorrarDatos();
            }
            CargarResponsables();
        }

        public void BorrarNotas()
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que deseas borrar las notas seleccionadas?", "Borrar notas", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(respuesta != System.Windows.Forms.DialogResult.Yes)
                return;
            foreach(DataGridViewRow row in DgvNotas.SelectedRows)
            {
                int idNota = Convert.ToInt32(row.Cells["id_nota"].Value);
                string usuario = row.Cells["usuario_nota"].Value.ToString();
                if(usuario != Global.UsuarioActual.NombreCompleto().ToString())
                {
                    MessageBox.Show("No eres el dueño de esta nota, no se puede borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                BugNota nota = new BugNota();
                nota.CargarDatos(idNota);
                nota.BorrarDatos();
            }
            CargarNotas();
            MostrarNotas(0);
        }

        public void BorrarAdjunto()
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que deseas borrar los adjuntos seleccionados?", "Borrar adjuntos", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(respuesta != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach(DataGridViewRow row in DgvAdjuntos.SelectedRows)
            {
                int idAdjunto  = Convert.ToInt32(row.Cells["id_adjunto"].Value);

                BugAdjunto adj = new BugAdjunto();
                adj.CargarDatos(idAdjunto);
                adj.BorrarDatos();
            }
            CargarAdjuntos();
        }

        public void MostrarNota(int idNota)
        {
            if (idNota == 0)
            {
                TxtNota.Text = "";
                LblNotaSeleccionada.Text = "SELECIONA UNA NOTA";
                return;
            }

            BugNota nota = new BugNota();
            nota.CargarDatos(idNota);

            if (nota.TieneFilas())
            {
                LblNotaSeleccionada.Text = nota.Fila().Celda("usuario_creacion").ToString() + " / " + Convert.ToDateTime(nota.Fila().Celda("fecha_creacion")).ToString("MMMM dd yy hh:mm:ss tt") + " " + " (SOLO LECTURA)";
                TxtNota.Text = nota.Fila().Celda("nota").ToString();
                TxtNota.ReadOnly = true;
            }
        }

        public void MostrarAdjunto()
        {
            int idAdjunto = Convert.ToInt32(DgvAdjuntos.SelectedRows[0].Cells["id_adjunto"].Value);
            string tipo = DgvAdjuntos.SelectedRows[0].Cells["tipo_adjunto"].Value.ToString();

            BugAdjunto adj = new BugAdjunto();
            adj.CargarDatos(idAdjunto);

            ArchivoBug arch = new ArchivoBug();
            arch.SeleccionarAdjunto(idAdjunto);

            if (!arch.TieneFilas())
            {
                MessageBox.Show("El archivo adjunto no fue encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] bytesArchivo = (byte[])arch.Fila().Celda("archivo");

            switch (tipo)
            {
                case ".pdf":
                case ".PDF":
                    FrmVisorPDF visor = new FrmVisorPDF(bytesArchivo, adj.Fila().Celda("nombre_archivo").ToString());
                    visor.ShowDialog();
                    break;

                default :
                    GuardarAdjunto.DefaultExt = tipo.Replace(".", "");
                    GuardarAdjunto.FileName = adj.Fila().Celda("nombre_archivo").ToString();
                    if (GuardarAdjunto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        File.WriteAllBytes(GuardarAdjunto.FileName, bytesArchivo);

                    break;
            }
        }

        public void NuevoResponsable()
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if (usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila resp = new Fila();
                resp.AgregarCelda("bug", IdBug);
                resp.AgregarCelda("responsable", usuario.UsuarioSeleccionado.NombreCompleto());
                BugResponsable.Modelo().Insertar(resp);
                CargarResponsables();
            }
        }

        public void NuevaNota()
        {
            FrmIngresarComentario comentario = new FrmIngresarComentario();
            if (comentario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if(!String.IsNullOrWhiteSpace(comentario.Comentarios)){
                    Fila nota = new Fila();
                    nota.AgregarCelda("bug", IdBug);
                    nota.AgregarCelda("nota",comentario.Comentarios);
                    nota.AgregarCelda("fecha_creacion", DateTime.Now);
                    nota.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                    BugNota.Modelo().Insertar(nota);
                    CargarNotas();
                }
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmDetallesBug_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CargarResponsables();
            CargarBug();
            TxtDescripcion.ReadOnly = true;
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    CargarBug();
                    break;

                case 1:
                    CargarNotas();
                    break;

                case 2:
                    CargarAdjuntos();
                    break;
            }
        }

        private void DgvNotas_Click(object sender, EventArgs e)
        {
            if (DgvNotas.SelectedRows.Count <= 0)
                return;
            borrarToolStripMenuItem.Enabled = true;
            int idNota = Convert.ToInt32(DgvNotas.SelectedRows[0].Cells["id_nota"].Value);
            MostrarNotas(idNota);
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    BorrarResponsable();
                    break;
                case 1:
                    BorrarNotas();
                    break;
                case 2:
                    BorrarAdjunto();
                    break;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string usuarioNotas = DgvNotas.SelectedRows[0].Cells["usuario_nota"].Value.ToString();

            if (usuarioNotas != Global.UsuarioActual.NombreCompleto())
            {
                MessageBox.Show("No eres el dueño de esta nota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TxtNota.ReadOnly = false;
            LblNotaSeleccionada.Text = LblNotaSeleccionada.Text.Replace("(SOLO LECTURA)", " (EDITANDO)");
        }

        private void DgvNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvNotas.SelectedRows.Count <= 0)
                return;

            int idNota = Convert.ToInt32(DgvNotas.SelectedRows[0].Cells["id_nota"].Value);
            editarToolStripMenuItem.Enabled = true;
            borrarToolStripMenuItem.Enabled = true;
        }

        private void TxtNota_MouseLeave(object sender, EventArgs e)
        {
            if (DgvNotas.SelectedRows.Count <= 0 || TxtNota.ReadOnly)
                return;

            BugNota nota = new BugNota();
            int idNota = 0;
            idNota= Convert.ToInt32(DgvNotas.SelectedRows[0].Cells["id_nota"].Value);
            nota.CargarDatos(idNota);
            if (idNota != 0 && nota.TieneFilas())
                if (!String.IsNullOrWhiteSpace(TxtNota.Text))
                {
                    nota.Fila().ModificarCelda("nota", TxtNota.Text);
                    nota.GuardarDatos();
                }
           }

        private void DgvAdjuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarAdjunto();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    NuevoResponsable();
                    break;
                case 1:
                    NuevaNota();
                    break;
                case 2:
                    Adjuntar();
                    break;
            }
        }

        private void DgvResponsables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvResponsables.SelectedRows.Count <= 0)
                return;
            
            borrarToolStripMenuItem.Enabled = true;
        }

        private void DgvAdjuntos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarToolStripMenuItem.Enabled = true;
        }
    }
}
