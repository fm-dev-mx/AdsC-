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
    public partial class FrmMetasCompras : Ventana
    {
        public int IdRequisicion = -1;

        MaterialFabricante BuscadorFabricantes = new MaterialFabricante();
        MaterialProyecto BuscadorMaterial = new MaterialProyecto();
        MetaEntregable BuscadorEntregables = new MetaEntregable();
        List<Fila> MaterialesMetas = new List<Fila>();
        Modulo BuscadorModulos = new Modulo();
        Meta BuscadorMetas = new Meta();

        public FrmMetasCompras()
        {
            InitializeComponent();
        }

        private void FrmMetasCompras_Load(object sender, EventArgs e)
        {
            CargarProyectos();
            CargarFabricante();
            CargarMetas();
            //CargarEstatusCompra();
            CargarEstatusCompra();
            CmbFiltroOrdenado.SelectedIndex = 0;


            DgvMetas.Rows.Clear();           
        }

        private void CargarEstatusCompra()
        {
            CmbFiltroOrdenado.Items.Clear();

            CmbFiltroOrdenado.Items.AddRange(new string[]{
                "SIN ORDENAR",
                "PENDIENTE",
                "EN COTIZACION",
                "EN REVISIÓN TÉCNICA",
                "EN PLANIFICACION",
                "COMPRA RECHAZADA",
                "EN REVISION FINANCIERA",
                "COMPRA DETENIDA",
                "LISTO PARA ORDENAR",
                "ORDEN ASIGNADA",
                "ORDENADO"
            });

            CmbFiltroOrdenado.SelectedIndex = 0;    

        }

        private void CargarProyectos()
        {
            CmbFiltroProyecto.Items.Add("TODOS");
            Proyecto proyecto = new Proyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@activo", "1");
            proyecto.SeleccionarDatos("activo=@activo ORDER BY id DESC", parametros).ForEach(delegate(Fila f)
            {
                CmbFiltroProyecto.Items.Add(Convert.ToDecimal(f.Celda("id")).ToString("F2") + " - " + f.Celda("nombre"));
            });
            CmbFiltroProyecto.SelectedIndex = 0;
        }

        private void CargarFabricante()
        {
            CmbFiltroFabricante.Items.Add("TODOS");
            CatalogoMaterial material = new CatalogoMaterial();
            material.Fabricantes().ForEach(delegate(Fila f)
            {
                CmbFiltroFabricante.Items.Add(f.Celda("fabricante"));
            });
            CmbFiltroFabricante.SelectedIndex = 0;
        }

        private void CargarMetas() 
        {
            CmbFiltroMetas.Items.Add("TODOS");
            Meta meta = new Meta();
            meta.SeleccionarMetasCompras().ForEach(delegate(Fila f)
            {
                CmbFiltroMetas.Items.Add(f.Celda("id"));
            });
            CmbFiltroMetas.SelectedIndex = 0;
        }

        private void MostrarMetas()
        {
            if (!BkgCargarMetas.IsBusy)
            {
                LblEstatusDescargar.Text = string.Empty;
                ProgresoDescarga.Value = 0;
                DgvMetas.Rows.Clear();
                CmbFiltroFabricante.Enabled = false;
                CmbFiltroProyecto.Enabled = false;
                CmbFiltroMetas.Enabled = false;
                CmbFiltroOrdenado.Enabled = false;
                ProgresoDescarga.Visible = true;
                BkgCargarMetas.RunWorkerAsync(
                    new string[] { 
                        CmbFiltroProyecto.Text,
                        CmbFiltroMetas.Text
                    }
                    );
            }
        }

        private void CmbFiltroProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMetas();
        }

        private void CmbFiltroFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMetas();
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvMetas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Object objFechaLimite = DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Value;
            Object estadoDeCompra = DgvMetas.Rows[e.RowIndex].Cells["estatus_compra"].Value;

            if (estadoDeCompra != null) 
            { 
                switch (estadoDeCompra.ToString())
                { 
                    case "ORDENADO":
                        DgvMetas.Rows[e.RowIndex].Cells["estatus_compra"].Style.ForeColor = Color.Green;
                        break;
                    case "N/A":
                        break;
                    case "CANCELADO":
                        DgvMetas.Rows[e.RowIndex].Cells["estatus_compra"].Style.ForeColor = Color.Red;                    
                        break;
                    case "EN COTIZACION":
                        DgvMetas.Rows[e.RowIndex].Cells["estatus_compra"].Style.ForeColor = Color.Orange;
                        break;
                    case "PENDIENTE":
                        break;
                    case "ORDEN ASIGNADA":
                        break;
                    case "RECIBIDO":
                        break;
                }
            }

            if (objFechaLimite.ToString() == "N/A")
            {
                DgvMetas.Rows[e.RowIndex].Cells["tiempo_entrega_cotizacion"].Style.ForeColor = Color.Red;
                DgvMetas.Rows[e.RowIndex].Cells["tiempo_entrega_cotizacion"].Style.Font = new Font(DgvMetas.Font, FontStyle.Bold);

                // DgvMetas.Rows[e.RowIndex].Cells["tiempo_entrega_cotizacion"].Style.ForeColor = Color.White;
            }
            else
            {
                DateTime fechaLimite = Convert.ToDateTime(DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Value);

                if (fechaLimite.Date > DateTime.Now.Date && DateTime.Now.AddDays(-3).Date > fechaLimite.Date)
                {
                    DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.ForeColor = Color.Lime;
                    DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.Font = new Font(DgvMetas.Font, FontStyle.Bold);
                    // DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.ForeColor = Color.Black;
                }
                else if (fechaLimite.Date > DateTime.Now.Date && DateTime.Now.AddDays(-3).Date <= fechaLimite.Date)
                {
                    DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.ForeColor = Color.Gold;
                    DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.Font = new Font(DgvMetas.Font, FontStyle.Bold);
                    // DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.ForeColor = Color.Black;
                }
                else if (fechaLimite.Date < DateTime.Now.Date)
                {
                    DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.ForeColor = Color.Crimson;
                    DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.Font = new Font(DgvMetas.Font, FontStyle.Bold);
                    // DgvMetas.Rows[e.RowIndex].Cells["fecha_limite"].Style.ForeColor = Color.White;
                }
            }
        }

        private void BkgCargarMetas_DoWork(object sender, DoWorkEventArgs e)
        {
            Proceso procCompras = new Proceso();
            procCompras.SeleccionarNombre("COMPRAS");
            BkgCargarMetas.ReportProgress(10,"Descargando metas...");
            if (procCompras.TieneFilas())
            {
                int idProcesoCompras = Convert.ToInt32(procCompras.Fila().Celda("id"));

                if (((string[])e.Argument)[0].ToString() != "TODOS")
                    e.Result = Convert.ToDecimal(((string[])e.Argument)[0].ToString().Split('-')[0]);

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@proceso", idProcesoCompras);
                parametros.Add("@estatus_autorizacion","AUTORIZADO");

                string query = " proceso=@proceso AND estatus_autorizacion=@estatus_autorizacion";
                if (((string[])e.Argument)[1].ToString() != "TODOS" && ((string[])e.Argument)[1].ToString() != string.Empty) 
                {
                    parametros.Add("@idmeta", int.Parse(((string[])e.Argument)[1].ToString()));
                    query += " AND id = @idmeta";
                }

                MaterialesMetas = BuscadorMetas.SeleccionarDatos(query, parametros, "id,avance", BkgCargarMetas);
            }
        }

        private void BkgCargarMetas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatusDescargar.Text = "Descargando metas...";
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatusDescargar.Refresh();
        }
        // public void CargarMaterialRequisicion(int idMeta)

        private void AgregarFilaMaterial(Fila infoMaterial)
        {
            if (infoMaterial.Celdas().Count <= 0)
                return;

            bool estadoOrdenado = false;

            if (CmbFiltroOrdenado.Text == "ORDENADO" || CmbFiltroOrdenado.Text == "SIN ORDENAR")
            { 
                estadoOrdenado = ((CmbFiltroOrdenado.Text == "ORDENADO") ? infoMaterial.Celda("estatus_compra").ToString() == "ORDENADO" : (!new List<string>() { "ORDENADO", "RECIBIDO", "CANCELADO" }.Contains(infoMaterial.Celda("estatus_compra").ToString())))
                                && !new List<string>() { "ORDENADO", "CANCELADO", "ENTREGADO" }.Contains(infoMaterial.Celda("estatus_almacen").ToString());
            }
            else
            {
                estadoOrdenado = infoMaterial.Celda("estatus_compra").ToString() == CmbFiltroOrdenado.Text;
            }

            if ((CmbFiltroFabricante.Text == "TODOS" || infoMaterial.Celda("fabricante").ToString() == CmbFiltroFabricante.Text)
                && (CmbFiltroProyecto.Text.Split('-')[0].Trim() == "TODOS" || Convert.ToDecimal(infoMaterial.Celda("proyecto")) == Convert.ToDecimal(CmbFiltroProyecto.Text.Split('-')[0].Trim()))
                && estadoOrdenado
                )
            {
                DgvMetas.Rows.Add(
                        infoMaterial.Celda("id"),
                        Convert.ToDecimal(infoMaterial.Celda("proyecto")).ToString("f2"),
                        infoMaterial.Celda("numero_parte"),
                        infoMaterial.Celda("fabricante"),
                        infoMaterial.Celda("meta").ToString().PadLeft(4, '0'),
                        infoMaterial.Celda("fecha_promesa_compras") == null ? "N/A" : Convert.ToDateTime(infoMaterial.Celda("fecha_promesa_compras")).Date.ToString("MMM dd, yyyy"),
                        Global.ObjetoATexto(infoMaterial.Celda("tiempo_entrega_cotizacion"),"N/A"),
                        infoMaterial.Celda("fecha_limite_ordenar") == null? "N/A":Convert.ToDateTime(infoMaterial.Celda("fecha_limite_ordenar")).Date.ToString("MMM dd, yyyy"),
                        Global.ObjetoATexto(infoMaterial.Celda("estatus_compra"),"N/A"),
                        Global.ObjetoATexto(infoMaterial.Celda("proveedor"),"N/A")
                        );
            }
        }

        private void BkgCargarMetas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.DoEvents();
            List<int> metasAMostrar = new List<int>();

            MaterialesMetas.ForEach(delegate(Fila meta)
            {
                if (Convert.ToDecimal(meta.Celda("avance")) < 100)
                {
                    metasAMostrar.Add(Convert.ToInt32(meta.Celda("id")));
                }
            });

            BuscadorMaterial.SeleccionarMaterialMetasPorEstatus();
            BuscadorMaterial.Filas().ForEach(delegate(Fila material) {
                AgregarFilaMaterial(material);
            });
       
            CmbFiltroFabricante.Enabled = true;
            CmbFiltroProyecto.Enabled = true;
            CmbFiltroMetas.Enabled = true;
            CmbFiltroOrdenado.Enabled = true;
            LblEstatusDescargar.Text = "¡Descarga completa!";
            ProgresoDescarga.Visible = false;
        }

        private void CmbFiltroMetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMetas();
        }

        private void CmbFiltroOrdenado_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMetas();
        }

        private void DgvMetas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdRequisicion = Convert.ToInt32(DgvMetas.Rows[e.RowIndex].Cells["id_requisicion"].Value);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
