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
    public partial class FrmBugsProyecto : Ventana
    {
        decimal IdProyecto = 0;
        int IdBug = 0;
        Proyecto ProyectoCargado = new Proyecto();

        public FrmBugsProyecto(decimal proyecto )
        {
            IdProyecto = proyecto; 
            InitializeComponent();
            ProyectoCargado.CargarDatos(IdProyecto);
        }

        private void FrmBugsProyecto_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            LblTitulo.Text = "BUGS DEL PROYECTO ";
            LblTitulo.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            LblTitulo.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();

            CmbFiltroEstatus.Text = "TODOS";
            CmbFiltroOrigen.Text = "TODOS";
            CmbCategoria.Text = "TODOS";
            LblUltimaActualizacion.Text = "";
            CargarBugs(IdProyecto);
            
        }

        private void CargarBugs(decimal proyecto)
        {
            DgvBugs.Columns["fecha"].DefaultCellStyle.Format = "MMM dd yyy  hh mm tt";
            int filaSeleccion = Global.GuardarFilaSeleccionada(DgvBugs);

            DgvBugs.Rows.Clear();

            Bug.Modelo().Filtrar(proyecto,CmbCategoria.Text, CmbFiltroEstatus.Text, CmbFiltroOrigen.Text).ForEach(delegate(Fila f)
            {

                int idBug = Convert.ToInt32(f.Celda("id"));
                ImageConverter converter = new ImageConverter();
                BugNota bug = new BugNota();
                byte[] bugImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                bug.SeleccionarBug(idBug);
                if (bug.TieneFilas())
                    bugImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.Nota, typeof(byte[]));


                BugAdjunto adjunto = new BugAdjunto();
                byte[] bugAdjunto = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                adjunto.SeleccionarBug(idBug);
                if (adjunto.TieneFilas())
                    bugAdjunto = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.adjunto, typeof(byte[]));
                
                DgvBugs.Rows.Add(f.Celda("id"), f.Celda("categoria"),f.Celda("descripcion"), f.Celda("origen"), f.Celda("perpetuada_por"), f.Celda("fecha_reporte"), f.Celda("estatus"), bugImagen, bugAdjunto);
                DataGridViewCell celdaEstatus = DgvBugs.Rows[DgvBugs.RowCount - 1].Cells["estatus"];

                switch (celdaEstatus.Value.ToString())
                {
                    case "SIN RESOLVER":
                        celdaEstatus.Style.ForeColor = Color.Black;
                        celdaEstatus.Style.BackColor = Color.Red;
                        break;

                    case "RESUELTO":
                        celdaEstatus.Style.ForeColor = Color.Black;
                        celdaEstatus.Style.BackColor = Color.LightGreen;
                        break;

                    case "DESCARTADO":
                        celdaEstatus.Style.ForeColor = Color.Black;
                        celdaEstatus.Style.BackColor = Color.Yellow;
                        break;
                }
            });

            Global.RecuperarFilaSeleccionada(DgvBugs, filaSeleccion);
            borrarToolStripMenuItem.Enabled = false;
            editarToolStripMenuItem.Enabled = false;
            detallesToolStripMenuItem.Enabled = false;

            LblUltimaActualizacion.Text = "Ultima actualización: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");

        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarBugs(IdProyecto);
        }

        private void CmbFiltroEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarBugs(IdProyecto);
        }

        private void CmbFiltroOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarBugs(IdProyecto);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarBugs(IdProyecto);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoBug nuevoBug = new FrmNuevoBug(IdProyecto);
            if (nuevoBug.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                CargarBugs(IdProyecto);
        }

        private void DgvBugs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvBugs.SelectedRows.Count > 0)
            {
                IdBug = Convert.ToInt32(DgvBugs.SelectedRows[0].Cells["id"].Value);
                editarToolStripMenuItem.Enabled = true;
                borrarToolStripMenuItem.Enabled = true;
                detallesToolStripMenuItem.Enabled = true;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoBug editarBug = new FrmNuevoBug(IdProyecto, IdBug);
            if (editarBug.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                CargarBugs(IdProyecto);
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdBug != 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Seguro que desea borrar este bug?", "Eliminar bug", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    Bug BorrarBug = new Bug();
                    BorrarBug.CargarDatos(IdBug);
                    BorrarBug.BorrarDatos();
                    CargarBugs(IdProyecto);
                }
                
            }
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetallesBug DetallesBug = new FrmDetallesBug(IdBug);
            if (DetallesBug.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarBugs(IdProyecto);
            }
        }
    }
}
