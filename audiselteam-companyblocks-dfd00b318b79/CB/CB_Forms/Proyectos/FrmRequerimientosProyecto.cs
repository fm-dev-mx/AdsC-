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
    public partial class FrmRequerimientosProyecto : Ventana
    {
        decimal idProyecto = 0;
        Proyecto ProyectoCargado = new Proyecto();

        public FrmRequerimientosProyecto(decimal proyecto)
        {
            InitializeComponent();
            idProyecto = proyecto;
            ProyectoCargado.CargarDatos(proyecto);
        }

        private void FrmRequerimientos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LblTitulo.Text = "REQUERIMIENTOS DEL PROYECTO ";
            LblTitulo.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            LblTitulo.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            CargarRequerimientos(idProyecto);

            CmbFiltroEstatus.Text = "TODOS";
            CmbFiltroOrigen.Text = "TODOS";
            CmbFiltroNivelRevision.Text = "TODOS";

            LblUltimaActualizacion.Text = "";
        }

        public void CargarRequerimientos(decimal proyecto)
        {
            List<Fila> requerimientos = Requerimiento.Modelo().FiltrarOficiales(proyecto, CmbFiltroEstatus.Text, CmbFiltroEstatus.Text, CmbFiltroOrigen.Text, CmbFiltroNivelRevision.Text);

            int fila = Global.GuardarFilaSeleccionada(DgvRequerimientos);
            int scroll = DgvRequerimientos.FirstDisplayedScrollingRowIndex;
            DgvRequerimientos.Rows.Clear();

            requerimientos.ForEach(delegate(Fila f)
            {
                int idRequerimiento = Convert.ToInt32(f.Celda("id"));
                 ImageConverter converter = new ImageConverter();

                RequerimientoParametro req = new RequerimientoParametro();
                byte[] parametros = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                req.SeleccionarRequerimiento(idRequerimiento);
                if (req.TieneFilas())
                     parametros = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.details, typeof(byte[]));


                RequerimientoKeyitem key = new RequerimientoKeyitem();
                byte[] keyItem = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                key.SeleccionarRequerimiento(idRequerimiento);
                if (key.TieneFilas())
                    keyItem = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.important_icon_16, typeof(byte[]));

                RequerimientoRestriccion rest = new RequerimientoRestriccion();
                byte[] restriccion = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                rest.SeleccionarRequerimiento(idRequerimiento);
                if (rest.TieneFilas())
                    restriccion = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.Block_icon, typeof(byte[]));

                RequerimientoNota notas = new RequerimientoNota();
                byte[] notaImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                notas.SeleccionarRequerimiento(idRequerimiento);
                if (notas.TieneFilas())
                    notaImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.Nota, typeof(byte[]));

                RequerimientoAdjunto adjuntos = new RequerimientoAdjunto();
                byte[] adjuntoImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                adjuntos.SeleccionarRequerimiento(idRequerimiento);
                if (adjuntos.TieneFilas())
                    adjuntoImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.adjunto, typeof(byte[]));



                DgvRequerimientos.Rows.Add(f.Celda("id"), f.Celda("nombre"), f.Celda("descripcion"), f.Celda("origen"), f.Celda("estatus"), f.Celda("nivel_revision"), f.Celda("estatus_revision"),parametros, keyItem, restriccion, notaImagen, adjuntoImagen);

                DataGridViewCell celdaEstatus = DgvRequerimientos.Rows[DgvRequerimientos.RowCount - 1].Cells["estatus_revision"];

                switch(celdaEstatus.Value.ToString())
                {
                    case "PENDIENTE":
                        break;

                    case "CUMPLE":
                        celdaEstatus.Style.ForeColor = Color.Black;
                        celdaEstatus.Style.BackColor = Color.LightGreen;
                        break;

                    case "NO CUMPLE":
                        celdaEstatus.Style.ForeColor = Color.White;
                        celdaEstatus.Style.BackColor = Color.Red;
                        break;

                    case "NO APLICA":
                        celdaEstatus.Style.ForeColor = Color.Black;
                        celdaEstatus.Style.BackColor = Color.LightGray;
                        break;
                }
            });

            Global.RecuperarFilaSeleccionada(DgvRequerimientos, fila);

            try
            {
                DgvRequerimientos.FirstDisplayedScrollingRowIndex = scroll;
            }
            catch(Exception ex)
            {}

            LblUltimaActualizacion.Text = "Ultima actualización: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");

            nuevoToolStripMenuItem.Enabled = Global.VerificarPrivilegio("PROYECTOS", "REGISTRAR REQUERIMIENTO");
            borrarToolStripMenuItem.Enabled = false;
            editarToolStripMenuItem.Enabled = false;
            detallesToolStripMenuItem.Enabled = false;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoRequerimiento nr = new FrmNuevoRequerimiento(idProyecto);

            if( nr.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarRequerimientos(idProyecto);
            }
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void CmbFiltroCategoría_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRequerimientos(idProyecto);
        }

        private void CmbFiltroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRequerimientos(idProyecto);
        }

        private void CmbFiltroOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRequerimientos(idProyecto);
        }

        private void CmbFiltroNivelRevision_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRequerimientos(idProyecto);
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que deseas borrar los requerimientos seleccionados?", "Borrar requerimientos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != DialogResult.Yes)
                return;

            foreach(DataGridViewRow row in DgvRequerimientos.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells["id"].Value);

                Requerimiento r = new Requerimiento();
                r.CargarDatos(id);
                
                if(r.TieneFilas())
                {
                    r.Fila().ModificarCelda("proyecto", 0);
                    r.GuardarDatos();
                }
            }
            CargarRequerimientos(idProyecto);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvRequerimientos.SelectedRows.Count <= 0 )
                return;

            int idRequerimiento = Convert.ToInt32(DgvRequerimientos.SelectedRows[0].Cells["id"].Value);

            FrmNuevoRequerimiento editar = new FrmNuevoRequerimiento(0, idRequerimiento);

            if( editar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarRequerimientos(idProyecto);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarRequerimientos(idProyecto);
        }

        private void DgvRequerimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarToolStripMenuItem.Enabled = DgvRequerimientos.SelectedRows.Count > 0 && Global.VerificarPrivilegio("PROYECTOS", "BORRAR REQUERIMIENTO");
            editarToolStripMenuItem.Enabled = DgvRequerimientos.SelectedRows.Count > 0 && Global.VerificarPrivilegio("PROYECTOS", "EDITAR REQUERIMIENTO");
            detallesToolStripMenuItem.Enabled = DgvRequerimientos.SelectedRows.Count > 0;
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarDetalles();
        }

        private void DgvRequerimientos_DoubleClick(object sender, EventArgs e)
        {
            MostrarDetalles();
        }

        public void MostrarDetalles()
        {
            if (DgvRequerimientos.SelectedRows.Count <= 0) return;

            int idRequerimiento = (int)DgvRequerimientos.SelectedRows[0].Cells["id"].Value;

            FrmDetallesRequerimiento dtr = new FrmDetallesRequerimiento(idRequerimiento);
            dtr.ShowDialog();
            CargarRequerimientos(idProyecto);
        }

        private void reportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportarRequerimientos rep = new FrmReportarRequerimientos(ProyectoCargado);

            if( rep.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {

            }
        }

        private void solicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSolicitudesRequerimientos sol = new FrmSolicitudesRequerimientos(ProyectoCargado);
            sol.ShowDialog();
            CargarRequerimientos(Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")));
        }
    }
}
