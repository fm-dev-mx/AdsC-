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
    public partial class FrmAccesoriosMaterial : Ventana
    {
        CatalogoMaterial material = new CatalogoMaterial();
        int accesorioSeleccionado = 0;

        public FrmAccesoriosMaterial(int idMaterial)
        {
            InitializeComponent();
            material.CargarDatos(idMaterial);

            if (!material.TieneFilas())
            {
                MessageBox.Show("El material no existe en el cátalogo");
                Close();
            }
        }

        public void CargarAccesorios(string filtroTipo="TODOS")
        {
            DgvOpciones.Rows.Clear();
            
            int idMaterial = Convert.ToInt32(material.Fila().Celda("id"));

            AccesorioMaterial.Modelo().SeleccionarMaterialTipo(idMaterial, filtroTipo).ForEach( delegate(Fila f) {

                int idAccesorio = Convert.ToInt32(f.Celda("accesorio"));

                CatalogoMaterial matAcc = new CatalogoMaterial();
                matAcc.CargarDatos(idAccesorio);

                DgvOpciones.Rows.Add(f.Celda("id"), f.Celda("tipo"), matAcc.Fila().Celda("numero_parte"), matAcc.Fila().Celda("descripcion"), f.Celda("piezas_requeridas") );
           
            });

            eliminarToolStripMenuItem.Enabled = false;
        }

        public void CargarTipos()
        {
            int idMaterial = Convert.ToInt32(material.Fila().Celda("id"));

            CmbTipoAccesorio.Items.Clear();
            CmbTipoAccesorio.Items.Add("TODOS");

            AccesorioMaterial.Modelo().TiposAccesorios(idMaterial).ForEach( delegate(Fila f) {
                CmbTipoAccesorio.Items.Add( f.Celda("tipo") );
            });

            CmbTipoAccesorio.Text = "TODOS";
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CmbTipoAccesorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbTipoAccesorio.Text != "")
                CargarAccesorios(CmbTipoAccesorio.Text);
        }

        private void CmbTipoAccesorio_TextChanged(object sender, EventArgs e)
        {
            agregarOpciónToolStripMenuItem.Enabled = CmbTipoAccesorio.Text != "" && CmbTipoAccesorio.Text != "TODOS";
        }

        private void FrmAccesoriosMaterial_Load(object sender, EventArgs e)
        {
            LblNumeroDeParte.Text = material.Fila().Celda("numero_parte").ToString();
            LblFabricante.Text = material.Fila().Celda("fabricante").ToString();
            LblDescripcion.Text = material.Fila().Celda("descripcion").ToString();

            CargarTipos();
        }

        private void agregarOpciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> filtro = new List<string>()
            {
                "MATERIA PRIMA COMUN",
                "MATERIA PRIMA ESPECIAL"
            };

            FrmSeleccionarMaterialCatalogo2 selMat = new FrmSeleccionarMaterialCatalogo2(filtro, true, false);
            //FrmSeleccionarMaterialCatalogo selMat = new FrmSeleccionarMaterialCatalogo( true, false);
            if( selMat.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                Fila f = new Fila();
                f.AgregarCelda("material", material.Fila().Celda("id") );
                f.AgregarCelda("tipo", CmbTipoAccesorio.Text);
                f.AgregarCelda("accesorio", selMat.IdMaterial);
                f.AgregarCelda("piezas_requeridas", selMat.CantidadMaterial);

                AccesorioMaterial.Modelo().Insertar(f);

                CargarTipos();
                CargarAccesorios(CmbTipoAccesorio.Text);
            }           
        }

        private void DgvOpciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if(DgvOpciones.SelectedRows.Count > 0)
            {
                eliminarToolStripMenuItem.Enabled = true;
                accesorioSeleccionado = Convert.ToInt32(DgvOpciones.SelectedRows[0].Cells["id"].Value);
            }*/
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quieres eliminar el accesorio seleccionado?", "Eliminar accesorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == System.Windows.Forms.DialogResult.No)
                return;

            AccesorioMaterial accesorio = new AccesorioMaterial();
            accesorio.CargarDatos(accesorioSeleccionado);
            accesorio.BorrarDatos();
            CargarAccesorios(CmbTipoAccesorio.Text);
        }

        private void CmbTipoAccesorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( Char.IsLetter(e.KeyChar) )
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void DgvOpciones_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvOpciones.SelectedRows.Count > 0)
            {
                eliminarToolStripMenuItem.Enabled = true;
                accesorioSeleccionado = Convert.ToInt32(DgvOpciones.SelectedRows[0].Cells["id"].Value);
            }
        }
    }

}
