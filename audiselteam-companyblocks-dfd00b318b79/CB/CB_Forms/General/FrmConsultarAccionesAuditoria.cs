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
    public partial class FrmConsultarAccionesAuditoria : Form
    {
        int IdUsuario = 0;
        int IdAccionSeleccionada = 0;

        public FrmConsultarAccionesAuditoria(int idUsuario)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
        }

        private void FrmTerminarAccionesAuditoria_Load(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            DgvChecklist5S.Rows.Clear();

            Auditoria5s.Modelo().SeleccionarAuditoria(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"))).ForEach(delegate(Fila f)
            {
                string usuarioResponsable = string.Empty;
                Usuario usuario = new Usuario();
                usuario.CargarDatos(Convert.ToInt32(Global.ObjetoATexto(f.Celda("usuario_responsable"), "0")));
                if (usuario.TieneFilas())
                    usuarioResponsable = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");

                DgvChecklist5S.Rows.Add(f.Celda("id").ToString(),
                                    Global.ObjetoATexto(f.Celda("area"), ""),
                                    f.Celda("punto_inspeccion").ToString(),
                                    Global.ObjetoATexto(f.Celda("etapa"), ""),
                                    Global.ObjetoATexto(f.Celda("resultado"), ""),
                                    Global.ObjetoATexto(f.Celda("notas_auditor"), ""),
                                    usuarioResponsable,
                                    Global.ObjetoATexto(f.Celda("avance"), ""));
                
            });

            if (DgvChecklist5S.Rows.Count > 0)
                DgvChecklist5S.ClearSelection();
        }

        private void terminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("¿Está seguro que desea terminar esta acción?", "Terminar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                Auditoria5s auditoria = new Auditoria5s();
                auditoria.CargarDatos(IdAccionSeleccionada);
                if(auditoria.TieneFilas())
                {
                    auditoria.Fila().ModificarCelda("avance", "TERMINADO");
                    auditoria.Fila().ModificarCelda("fecha_terminado", DateTime.Now);
                    auditoria.GuardarDatos();

                    Fila insertarHistorial = new Fila();
                    insertarHistorial.AgregarCelda("auditoria", IdAccionSeleccionada);
                    insertarHistorial.AgregarCelda("area", auditoria.Fila().Celda("area"));
                    insertarHistorial.AgregarCelda("etapa", auditoria.Fila().Celda("etapa"));
                    insertarHistorial.AgregarCelda("punto_inspeccion", auditoria.Fila().Celda("punto_inspeccion"));
                    insertarHistorial.AgregarCelda("resultado", auditoria.Fila().Celda("resultado"));
                    insertarHistorial.AgregarCelda("notas_auditor", auditoria.Fila().Celda("notas_auditor"));
                    insertarHistorial.AgregarCelda("usuario_auditoria", auditoria.Fila().Celda("usuario_auditoria"));
                    insertarHistorial.AgregarCelda("fecha_auditoria", auditoria.Fila().Celda("fecha_auditoria"));
                    insertarHistorial.AgregarCelda("usuario_creacion", auditoria.Fila().Celda("usuario_creacion"));
                    insertarHistorial.AgregarCelda("fecha_creacion", auditoria.Fila().Celda("fecha_creacion"));
                    insertarHistorial.AgregarCelda("usuario_responsable", auditoria.Fila().Celda("usuario_responsable"));
                    insertarHistorial.AgregarCelda("fecha_terminado", auditoria.Fila().Celda("fecha_terminado"));
                    Auditoria5sHistorial crearHistorial = new Auditoria5sHistorial();
                    crearHistorial.Insertar(insertarHistorial);
                    CargarAuditoria();
                }
            }
        }

        private void DgvChecklist5S_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            IdAccionSeleccionada = Convert.ToInt32(DgvChecklist5S.SelectedRows[0].Cells["id"].Value);
            if (DgvChecklist5S.SelectedRows[0].Cells["avance"].Value.ToString() != "EN PROCESO")
                enProcesoToolStripMenuItem.Enabled = true;
            else
                enProcesoToolStripMenuItem.Enabled = false;
                
        }

        private void DgvChecklist5S_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    terminarToolStripMenuItem.Visible = true;
                    MenuPuntosInspeccion.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvChecklist5S_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvChecklist5S.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    terminarToolStripMenuItem.Visible = false;
                    enProcesoToolStripMenuItem.Visible = false;
                    MenuPuntosInspeccion.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvChecklist5S_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string resultado = DgvChecklist5S.Rows[e.RowIndex].Cells["resultado"].Value.ToString();

            if (resultado == "BIEN")
                DgvChecklist5S.Rows[e.RowIndex].Cells["resultado"].Style.BackColor = Color.LightGreen;

            else if (resultado == "MAL")
                DgvChecklist5S.Rows[e.RowIndex].Cells["resultado"].Style.BackColor = Color.Red;

            string estatus = DgvChecklist5S.Rows[e.RowIndex].Cells["avance"].Value.ToString();

            if (estatus == "EN PROCESO")
                DgvChecklist5S.Rows[e.RowIndex].Cells["avance"].Style.BackColor = Color.Yellow;

            else if (resultado == "TERMINADO")
                DgvChecklist5S.Rows[e.RowIndex].Cells["avance"].Style.BackColor = Color.Red;
        }

        private void enProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cambiar el estatus a 'En proceso'?", "Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Auditoria5s auditoria = new Auditoria5s();
                auditoria.CargarDatos(IdAccionSeleccionada);
                if (auditoria.TieneFilas())
                {
                    auditoria.Fila().ModificarCelda("avance", "EN PROCESO");                    
                    auditoria.GuardarDatos();
                    CargarAuditoria();
                }
            }
        }
    }
}
