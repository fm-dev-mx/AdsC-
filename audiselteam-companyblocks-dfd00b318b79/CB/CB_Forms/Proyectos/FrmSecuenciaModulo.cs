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
    public partial class FrmSecuenciaModulo : Ventana
    {
        Modulo ModuloCargado = new Modulo();

        public FrmSecuenciaModulo(int idModulo)
        {
            InitializeComponent();
            ModuloCargado.CargarDatos(idModulo);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        public void CargarPasos()
        {
            
        }

        private void FrmSecuenciaModulo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if (ModuloCargado.TieneFilas())
            {
                LblNombre.Text = ModuloCargado.Fila().Celda("nombre").ToString();
                LblCategoria.Text = ModuloCargado.Fila().Celda("categoria").ToString();
                LblDescripcion.Text = ModuloCargado.Fila().Celda("descripcion").ToString();

                CargarPasos();
            }
            else
            {
                MessageBox.Show("El modulo no existe!");
                Close();
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
