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
    public partial class FrmAlmacen : Form
    {
        MaterialStock AltaStock = new MaterialStock();
        CatalogoMaterial CargarDatosMaterial = new CatalogoMaterial();
        List<int> Cantidad = new List<int>();
        int idMaterialCargado = 0;
        int idMaterialStock = 0;
       
        public FrmAlmacen()
        {
            InitializeComponent(); 
            BtnEliminar.Enabled = false;
        }

        private void FrmAlmacen_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CmbFiltroAlmacen.Text = "MATERIAL PROYECTOS";
            EnlistarContenido(CmbFiltroAlmacen.Text);
        }

        public void EnlistarContenido(string filtro)
        {
            switch (filtro)
            {
                case "MATERIAL PROYECTOS":
                    EnlistarMaterialProyecto();
                    break;

                case "MATERIAL STOCK":
                    EnlistarStock();
                    break;
            }
        }

        public void EnlistarMaterialProyecto()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvMateriales);
            DgvMateriales.Rows.Clear();

            MaterialProyecto.Modelo().MaterialRecibidoAlmacen().ForEach(delegate(Fila material)
            {
                string valor = material.Celda("estatus_almacen").ToString();               
                DgvMateriales.Rows.Add(false, material.Celda("id"), material.Celda("categoria"), material.Celda("numero_parte"), material.Celda("fabricante"), material.Celda("descripcion"), Convert.ToDouble(material.Celda("proyecto")).ToString("F2"), material.Celda("requisitor"), material.Celda("estatus_almacen"), material.Celda("cantidad_almacen"));
                DataGridViewCell cell = DgvMateriales.Rows[DgvMateriales.RowCount - 1].Cells["estatus_almacen"];
                cell.Style = MaterialProyecto.Modelo().ColorEstatusAlmacen(valor);
            });

            ConfiguracionDataGridView.Recuperar(cfg, DgvMateriales);
            contextMenuSeleccionar.Enabled = true;
        }

        public void EnlistarStock()
        {
            BtnEliminar.Enabled = false;

            int fila = Global.GuardarFilaSeleccionada(DgvMateriales);
            DgvMateriales.Rows.Clear();
           
            MaterialStock.Modelo().SeleccionarDatos("").ForEach(delegate(Fila materialStock)
            {
                int mayorCero = Convert.ToInt32(materialStock.Celda("cantidad_disponible"));
                if(mayorCero > 0)
                    DgvMateriales.Rows.Add(false, materialStock.Celda("id"), materialStock.Celda("categoria"), materialStock.Celda("numero_parte"), materialStock.Celda("fabricante"), materialStock.Celda("descripcion"), "N/A", "N/A", "STOCK", materialStock.Celda("cantidad_disponible"), materialStock.Celda("id"));    
            });

            Global.RecuperarFilaSeleccionada(DgvMateriales, fila);
        }

        private void ALtaMaterialStock()
        {
            List<string> filtro = new List<string>()
            {
                "MATERIA PRIMA COMUN",
                "MATERIA PRIMA ESPECIAL",
                "M.R.O."
            };

            FrmSeleccionarMaterialCatalogo2 Catalogo = new FrmSeleccionarMaterialCatalogo2(filtro,true,false);
           // FrmSeleccionarMaterialCatalogo Catalogo = new FrmSeleccionarMaterialCatalogo();
            if (Catalogo.ShowDialog() == DialogResult.OK)
            {
                idMaterialStock = Catalogo.IdMaterial;
                CargarDatosMaterial.CargarDatos(idMaterialStock); 

                string numeroDeParte = CargarDatosMaterial.Fila().Celda("numero_parte").ToString();
                string fabricanteAlta = CargarDatosMaterial.Fila().Celda("fabricante").ToString();
                string descripcionAlta = CargarDatosMaterial.Fila().Celda("descripcion").ToString();
                string categoriaAlta = CargarDatosMaterial.Fila().Celda("categoria").ToString();

                List<Fila> datosCargados = AltaStock.MaterialAltaStock(numeroDeParte);

                int cantidadAlta = 0;
                switch (datosCargados.Count)
                {
                    case 1:
                        int cantidadActual = (int)AltaStock.Fila().Celda("cantidad_disponible");
                        cantidadAlta = Catalogo.CantidadMaterial;
                        int nuevoTotal = cantidadActual + cantidadAlta;

                        AltaStock.Fila().ModificarCelda("cantidad_disponible", nuevoTotal);
                        AltaStock.GuardarDatos();
                        break;

                    case 0:
                        cantidadAlta = Catalogo.CantidadMaterial;
                        Fila nuevaAlta = new Fila();

                        nuevaAlta.AgregarCelda("numero_parte", numeroDeParte);
                        nuevaAlta.AgregarCelda("fabricante", fabricanteAlta);
                        nuevaAlta.AgregarCelda("descripcion", descripcionAlta);
                        nuevaAlta.AgregarCelda("cantidad_disponible", cantidadAlta);
                        nuevaAlta.AgregarCelda("categoria", categoriaAlta);
                        MaterialStock.Modelo().Insertar(nuevaAlta);

                        AltaStock.GuardarDatos();
                        break;
                }

                EnlistarStock();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            BtnAlta.ContextMenuStrip = contextMenuAlta;

            if (BtnAlta.ContextMenuStrip != null)
                BtnAlta.ContextMenuStrip.Show(BtnAlta, BtnAlta.PointToClient(Cursor.Position));
        }

        private void CmbFiltroAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
           EnlistarContenido(CmbFiltroAlmacen.Text);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            BtnEliminar.ContextMenuStrip = contextMenuBaja;

            if (BtnEliminar.ContextMenuStrip != null)
                BtnEliminar.ContextMenuStrip.Show(BtnEliminar, BtnEliminar.PointToClient(Cursor.Position));
        }

        private void bajaMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> idMateriales = new List<int>();
            idMateriales = SeleccionarMaterial();
            FrmBajaAlmacen bajaAlmacen = new FrmBajaAlmacen(idMateriales, CmbFiltroAlmacen.Text, Cantidad);
            if (bajaAlmacen.ShowDialog() == DialogResult.OK)
            {
                switch (CmbFiltroAlmacen.Text)
                {
                    case "MATERIAL PROYECTOS":
                        EnlistarMaterialProyecto();
                        DgvMateriales.ClearSelection();
                        break;

                    case "MATERIAL STOCK":
                        EnlistarStock();
                        DgvMateriales.ClearSelection();
                        break;
                }
            }
        }

        private void toolStripMenuDesdePO_Click(object sender, EventArgs e)
        {
            FrmAltaAlmacenDesdePO AltaPO = new FrmAltaAlmacenDesdePO();
            if (AltaPO.ShowDialog() == DialogResult.OK)
            {
                EnlistarMaterialProyecto(); 
                DgvMateriales.ClearSelection();
            }
        }

        private void DgvMateriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (Convert.ToInt32(DgvMateriales.SelectedRows[0].Cells["CANTIDAD_ALMACEN"].Value) > 0)
                BtnEliminar.Enabled = true;
            else
                BtnEliminar.Enabled = false;

            if (CmbFiltroAlmacen.Text == "MATERIAL PROYECTOS" && DgvMateriales.SelectedRows.Count > 0)
                idMaterialCargado = Convert.ToInt32(DgvMateriales.SelectedRows[0].Cells["ID"].Value);

            else if (CmbFiltroAlmacen.Text == "MATERIAL STOCK" && DgvMateriales.SelectedRows.Count > 0)
                idMaterialCargado = Convert.ToInt32(DgvMateriales.SelectedRows[0].Cells["ID_STOCK"].Value);
        }

        private void toolStripMenuSinPO1_Click(object sender, EventArgs e)
        {
            ALtaMaterialStock();
        }

        private void BtnMovimientos_Click(object sender, EventArgs e)
        {
            FrmMovimientosAlmacen almacenMovimientos = new FrmMovimientosAlmacen();
            almacenMovimientos.Show();
        }

        public  List<int> SeleccionarMaterial()
        {
            List<int> filasSeleccionadas = new List<int>();
            Cantidad.Clear();

            foreach (DataGridViewRow row in DgvMateriales.Rows)
            {
                if (Convert.ToBoolean(row.Cells["seleccionar_requisicion"].Value) == true)
                {
                    filasSeleccionadas.Add(Convert.ToInt32(row.Cells["ID"].Value));
                    Cantidad.Add(Convert.ToInt32(row.Cells["CANTIDAD_ALMACEN"].Value));
                }
            }
            return filasSeleccionadas;
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvMateriales.Rows)
                row.Cells["seleccionar_requisicion"].Value = true;
        }

        private void DgvMateriales_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuSeleccionar.Show(Cursor.Position);
        }

        private void seleccionarNadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvMateriales.Rows)
                row.Cells["seleccionar_requisicion"].Value = false;
        }

        private void BtnSeleccionarMaterial_Click(object sender, EventArgs e)
        {
            string[] filtrarMaterial = new string[]
            {
                "M.R.O.",
                "MATERIA PRIMA COMUN",
                "SERVICIOS"
            };

            FrmMaterialProyecto material = new FrmMaterialProyecto(0, filtrarMaterial, false);
            material.Show();
        }
    }
}
