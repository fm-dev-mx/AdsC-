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
    public partial class FrmCatalogoMaterial : Form
    {
        public CatalogoMaterial MaterialSeleccionado = new CatalogoMaterial();

        public FrmCatalogoMaterial()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmCatalogoMaterial_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarFabricantes();
            verDetallesDeCotizacionesToolStripMenuItem.Enabled = Global.VerificarPrivilegio("GENERAL", "VISUALIZAR COSTOS");
        }

        void CargarMaterial(string categoria="TODOS", string subcategoria="TODOS", string fabricante="TODOS", string filtro="")
        {
            int fila = Global.GuardarFilaSeleccionada(DgvMaterial);

            DgvMaterial.Rows.Clear();
            CatalogoMaterial.Modelo().Seleccionar(categoria, subcategoria, fabricante, filtro).ForEach(delegate(Fila material)
            {
                DgvMaterial.Rows.Add(material.Celda("id"), material.Celda("numero_parte"), material.Celda("fabricante"));
            });

            Global.RecuperarFilaSeleccionada(DgvMaterial, fila);
            verAccesoriosToolStripMenuItem.Enabled = false;
        }

        void CargarCategorias()
        {
            CmbFiltroCategoria.Items.Clear();
            CmbFiltroCategoria.Items.Add("TODOS");
            CategoriaMaterial.Modelo().Todas().ForEach(delegate(Fila categoria)
            {
                CmbFiltroCategoria.Items.Add(categoria.Celda("categoria").ToString());
            });
            CmbFiltroCategoria.Text = "TODOS";
        }

        void CargarFabricantes()
        {
            CmbFiltroFabricante.Items.Clear();
            CmbFiltroFabricante.Items.Add("TODOS");
            CatalogoMaterial.Modelo().Fabricantes().ForEach(delegate(Fila fabricante)
            {
                CmbFiltroFabricante.Items.Add(fabricante.Celda("fabricante").ToString());
            });
            CmbFiltroFabricante.Text = "TODOS";
        }

        void CargarSubcategorias(string categoria)
        {
            CmbFiltroSubcategoria.Items.Clear();
            CmbFiltroSubcategoria.Items.Add("TODOS");
            SubcategoriaMaterial.Modelo().SeleccionarCategoria(categoria).ForEach(delegate(Fila subcategoria)
            {
                CmbFiltroSubcategoria.Items.Add(subcategoria.Celda("subcategoria").ToString());
            });
            CmbFiltroSubcategoria.Text = "TODOS";
        }

        private void CmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFiltro.Text = "";
            CargarSubcategorias(CmbFiltroCategoria.Text);
            CargarMaterial(CmbFiltroCategoria.Text, CmbFiltroSubcategoria.Text, CmbFiltroFabricante.Text);
            BorrarDetallesMaterial();

            BtnRegistrarMaterial.Enabled = !CmbFiltroSubcategoria.Text.Equals("TODOS") && !CmbFiltroCategoria.Text.Equals("TODOS");
        }

        private void CmbFiltroSubcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFiltro.Text = "";
            CargarMaterial(CmbFiltroCategoria.Text, CmbFiltroSubcategoria.Text, CmbFiltroFabricante.Text);
            BorrarDetallesMaterial();

            BtnRegistrarMaterial.Enabled = !CmbFiltroSubcategoria.Text.Equals("TODOS") && !CmbFiltroCategoria.Text.Equals("TODOS");
        }

        void MostrarDetallesMaterial(int id)
        {
            CatalogoMaterial material = new CatalogoMaterial(); 
            material.CargarDatos(id);

            Detalles.Visible = true;
            LblNumeroParte.Text = material.Fila().Celda("numero_parte").ToString();
            TxtNumeroParte.Text = LblNumeroParte.Text;
            TxtFabricante.Text = material.Fila().Celda("fabricante").ToString();
            CmbUnidades.Text = material.Fila().Celda("tipo_venta").ToString();
            TxtEnlace.Text = material.Fila().Celda("link").ToString();
            TxtDescripcion.Text = material.Fila().Celda("descripcion").ToString();

            if (CmbUnidades.Text == "POR PAQUETE")
            {
                NumPiezasPaquete.Value = Convert.ToInt32(material.Fila().Celda("piezas_paquete"));
                LblEtiquetaPiezasPorPaquete.Visible = true;
                NumPiezasPaquete.Visible = true;
            }
            else
            {
                LblEtiquetaPiezasPorPaquete.Visible = false;
                NumPiezasPaquete.Visible = false;
            }

            BtnOpcionesMaterial.Enabled = true;
        }

        void BorrarDetallesMaterial()
        {
            LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";
            Detalles.Visible = false;


            TxtNumeroParte.Text = "";
            TxtFabricante.Text = "";
            CmbUnidades.Text = "POR PIEZA";
            NumPiezasPaquete.Value = 1;
            LblEtiquetaPiezasPorPaquete.Visible = false;
            NumPiezasPaquete.Visible = false;

            TxtEnlace.Text = "";
            TxtDescripcion.Text = "";
            LblInfo.Text = "";

            BtnOpcionesMaterial.Enabled = false;
            BtnElegirImagen.Enabled = false;
        }

        private void DgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count > 0)
            {
                int idmaterial = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells[0].Value);
                MaterialSeleccionado.CargarDatos(idmaterial);
                MostrarDetallesMaterial(idmaterial);

                verAccesoriosToolStripMenuItem.Enabled = MaterialSeleccionado.Fila().Celda("tipo_venta").ToString() == "POR PIEZA";
            }
        }

        void SoloLectura(bool modo)
        {
            TxtNumeroParte.ReadOnly = !modo;
            TxtFabricante.ReadOnly = !modo;
            TxtDescripcion.ReadOnly = !modo;
            TxtEnlace.ReadOnly = !modo;
            CmbUnidades.Enabled = modo;
            NumPiezasPaquete.Enabled = modo;
        }

        private void EditarMaterial()
        {
            if( editarToolStripMenuItem.Text == "Editar")
            {
                editarToolStripMenuItem.Text = "Guardar";
                SoloLectura(true);
            }
            else
            {
                if (ValidarInformacion())
                {
                    editarToolStripMenuItem.Text = "Editar";
                    GuardarInformacion();
                    SoloLectura(false);
                    LblInfo.Text = "";
                }
                else
                    LblInfo.Text = "Ingresa todos los datos necesarios";
            }
        }

        void GuardarInformacion()
        {
            if (!MaterialSeleccionado.TieneFilas())
                return;

            if( DgvMaterial.SelectedRows.Count > 0)
            {
                LblNumeroParte.Text = TxtNumeroParte.Text.Trim();
                DgvMaterial.SelectedRows[0].Cells[1].Value = TxtNumeroParte.Text.Trim();
                DgvMaterial.SelectedRows[0].Cells[2].Value = TxtFabricante.Text.Trim();
            }

            MaterialSeleccionado.Fila().ModificarCelda("numero_parte", TxtNumeroParte.Text.Trim());
            MaterialSeleccionado.Fila().ModificarCelda("fabricante", TxtFabricante.Text.Trim());
            MaterialSeleccionado.Fila().ModificarCelda("descripcion", TxtDescripcion.Text.Trim());
            MaterialSeleccionado.Fila().ModificarCelda("link", TxtEnlace.Text.Trim());
            MaterialSeleccionado.Fila().ModificarCelda("tipo_venta", CmbUnidades.Text.Trim());
            MaterialSeleccionado.Fila().ModificarCelda("piezas_paquete", NumPiezasPaquete.Value);

            MaterialSeleccionado.GuardarDatos();
        }

        bool ValidarInformacion()
        {
            if (TxtNumeroParte.Text == "")
                return false;
            if (TxtFabricante.Text == "")
                return false;
            if (TxtDescripcion.Text == "")
                return false;
            if (NumPiezasPaquete.Value < 1)
                return false;
            if (CmbUnidades.Text == "")
                return false;
            return true;
        }

        private void CmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbUnidades.Text == "POR PIEZA")
            {
                NumPiezasPaquete.Visible = false;
                LblEtiquetaPiezasPorPaquete.Visible = false;
            }
            else
            {
                NumPiezasPaquete.Visible = true;
                LblEtiquetaPiezasPorPaquete.Visible = true;
            }
        }

        private void EliminarMaterial()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas eliminar el material seleccionado?", "Eliminar material", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        
            if( respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                MaterialSeleccionado.BorrarDatos();
                BorrarDetallesMaterial();
                CargarMaterial(CmbFiltroCategoria.Text, CmbFiltroSubcategoria.Text, CmbFiltroFabricante.Text);
            }
        
        }

        private void BtnRegistrarMaterial_Click(object sender, EventArgs e)
        {
            FrmRegistrarMaterial registrar = new FrmRegistrarMaterial();

            registrar.CategoriaSeleccionada = CmbFiltroCategoria.Text;
            registrar.SubcategoriaSeleccionada = CmbFiltroSubcategoria.Text;

            if( registrar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarMaterial(CmbFiltroCategoria.Text, CmbFiltroSubcategoria.Text, CmbFiltroFabricante.Text);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarMaterial();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarMaterial();
        }

        private void BtnOpcionesMaterial_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesMaterial.ContextMenuStrip != null)
                BtnOpcionesMaterial.ContextMenuStrip.Show(BtnOpcionesMaterial, BtnOpcionesMaterial.PointToClient(Cursor.Position));
        }

        private void verAccesoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(MaterialSeleccionado.Fila().Celda("id"));

            FrmAccesoriosMaterial accesorios = new FrmAccesoriosMaterial(id);
            accesorios.ShowDialog();
        }

        private void CmbFiltroFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFiltro.Text = "";
            CargarMaterial(CmbFiltroCategoria.Text, CmbFiltroSubcategoria.Text, CmbFiltroFabricante.Text);
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            BorrarDetallesMaterial();
            CargarMaterial(CmbFiltroCategoria.Text, CmbFiltroSubcategoria.Text, CmbFiltroFabricante.Text, TxtFiltro.Text);
        }

        private void DgvMaterial_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count > 0)
            {
                int idmaterial = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells[0].Value);
                MaterialSeleccionado.CargarDatos(idmaterial);
                MostrarDetallesMaterial(idmaterial);
            }
        }

        private void verDetallesDeCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerCotizacionesMaterial material = new FrmVerCotizacionesMaterial(DgvMaterial.SelectedRows[0].Cells["pn"].Value.ToString());
            material.ShowDialog();
        }

        private void solidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int materialId = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["id"].Value);
            FrmSolidosMaterial solido = new FrmSolidosMaterial(materialId);
            solido.ShowDialog();
        }

        private void verEstadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstadisticasMaterial estadisticas =  new FrmEstadisticasMaterial(DgvMaterial.SelectedRows[0].Cells["pn"].Value.ToString());
            estadisticas.Show();
        }

    }
}
