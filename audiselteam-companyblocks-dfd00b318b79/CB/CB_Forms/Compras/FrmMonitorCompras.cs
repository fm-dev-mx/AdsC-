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
    public partial class FrmMonitorCompras : Form
    {
        string NumeroDeParteSeleccionado;
        int RequisicionSeleccionada;
        MaterialProyecto BuscadorMaterial = new MaterialProyecto();

        public FrmMonitorCompras(List<Filtro> filtros=null)
        {
            InitializeComponent();

            if (filtros != null)
                BuscadorMaterial.Filtros = filtros;
            else
            {
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_compra", "Estatus compra", BuscadorMaterial.EstatusCompra()));
                BuscadorMaterial.Filtros[0].DesactivarTodos();
                BuscadorMaterial.Filtros[0].ModificarFiltro("PENDIENTE", true);
                BuscadorMaterial.Filtros[0].ModificarFiltro("EN COTIZACION", true);

                BuscadorMaterial.Filtros.Add(new Filtro("estatus_seleccion", "Estatus selección", BuscadorMaterial.EstatusSeleccion()));
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_autorizacion", "Estatus autorización", BuscadorMaterial.EstatusAutorizacion()));
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_almacen", "Estatus almacén", BuscadorMaterial.EstatusAlmacen()));
                BuscadorMaterial.Filtros.Add(new Filtro("requisitor", "Requisitor", BuscadorMaterial.Requisitores()));
                BuscadorMaterial.Filtros.Add(new Filtro("proyecto", "Proyecto", BuscadorMaterial.Proyectos()));
                BuscadorMaterial.Filtros.Add(new Filtro("fabricante", "Fabricante", BuscadorMaterial.Fabricantes()));
            }
        }

        public void CargarMaterial()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvMaterial);
            DgvMaterial.Rows.Clear();
            BuscadorMaterial.EnProcesoDeCompra(DateDesde.Value, DateHasta.Value).ForEach(delegate(Fila material)
            {
                string tipo_venta = material.Celda("tipo_venta").ToString();
                string strTotal = material.Celda("suma_total").ToString();

                if (tipo_venta == "POR PIEZA")
                    strTotal += " pieza(s)";
                else if (tipo_venta == "POR PAQUETE")
                    strTotal += " paquete(s) con " + material.Celda("piezas_paquete").ToString() + " pieza(s) c/u";

                object objFecha = material.Celda("fecha_creacion");
                DateTime dtFecha = DateTime.Now.AddDays(1);
                string fecha = "N/A";
                if (objFecha != null)
                {
                    dtFecha = Convert.ToDateTime(objFecha);
                    fecha = dtFecha.ToString("MMM dd, yyyy hh:mm:ss tt");
                }

                object te = material.Celda("tiempo_entrega_estimado");
                int iTiempoEntregaEstimado = 0;
                string tiempoEntregaEstimado = "N/A";
                
                if( te != null )
                {
                    iTiempoEntregaEstimado = Convert.ToInt32(te);

                    if(iTiempoEntregaEstimado > 0)
                        tiempoEntregaEstimado = iTiempoEntregaEstimado.ToString() + " día(s)";
                }

                object objFechaAutorizacion = material.Celda("fecha_autorizacion");
                object objFechaPromesaFabricacion = material.Celda("fecha_promesa_ensamble");
                string fechaLimiteParaOrdenar = "N/A";

                //if( objFechaPromesaEnsamble != null && iTiempoEntregaEstimado > 0 )
                //{
                //    DateTime fechaPromesaEnsamble = Convert.ToDateTime(objFechaPromesaEnsamble);
                //    DateTime fechaLimite = fechaPromesaEnsamble.AddDays(iTiempoEntregaEstimado*(-1));
                //    fechaLimiteParaOrdenar = fechaLimite.ToString("MMM dd, yyyy");
                //}
                if(objFechaAutorizacion != null)
                {
                    DateTime fechaAutorizacion = Convert.ToDateTime(objFechaAutorizacion);
                    
                    if(fechaAutorizacion > new DateTime(2018, 8, 28))
                        fechaLimiteParaOrdenar = fechaAutorizacion.AddDays(1).ToString("MMM dd, yyyy");
                }



                DgvMaterial.Rows.Add(material.Celda("numero_parte"), material.Celda("fabricante"), fecha, strTotal, tiempoEntregaEstimado, fechaLimiteParaOrdenar);

                if (dtFecha.Date == DateTime.Now.Date)
                {
                    DataGridViewCell cell = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["fecha"];
                    cell.Style.BackColor = Color.Yellow;
                }
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvMaterial);
            LblUltimaActualizacion.Text = "Ultima actualización: " + DateTime.Now.ToString("MMM dd yyyy, hh:mm:ss tt");
            BorrarDatosMaterial();
        }

        private void FrmMonitorCompras_Load(object sender, EventArgs e)
        {
            DateDesde.Value = DateTime.Now.AddYears(-1);
            DateHasta.Value = DateTime.Now;
            this.WindowState = FormWindowState.Maximized;
            CargarMaterial();
        }

        private void DgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( DgvMaterial.SelectedRows.Count > 0 )
            {
                NumeroDeParteSeleccionado = DgvMaterial.SelectedRows[0].Cells[0].Value.ToString();
                string fabricante = DgvMaterial.SelectedRows[0].Cells[1].Value.ToString();
                MostrarDatosMaterial(NumeroDeParteSeleccionado, fabricante);
                verDetalles.Enabled = false;
                verCotizaciones.Enabled = false;
            }
        }
    
        public void MostrarDatosMaterial(string numeroDeParte, string fabricante = "")
        {
            DatosMaterial.Visible = true;
            BtnOpcionesMaterial.Enabled = true;

            MaterialProyecto material = new MaterialProyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numero_parte", numeroDeParte);
            parametros.Add("@fabricante", fabricante);
            material.SeleccionarDatos("numero_parte=@numero_parte AND fabricante=@fabricante", parametros);

            if(material.TieneFilas())
            {
                TxtDescripcion.Text = material.Fila().Celda("descripcion").ToString();
                LblNumeroParte.Text = numeroDeParte + " / " + material.Fila().Celda("fabricante").ToString();
            }

            DgvRequisiciones.Rows.Clear();
            BuscadorMaterial.DesgloseEnProcesoDeCompra(numeroDeParte).ForEach(delegate(Fila requisicion){

            string tipo_venta = requisicion.Celda("tipo_venta").ToString();
            string strTotal = requisicion.Celda("total").ToString();

            if (tipo_venta == "POR PIEZA")
                strTotal += " pieza(s)";
            else if (tipo_venta == "POR PAQUETE")
                strTotal += " paquete(s) con " + requisicion.Celda("piezas_paquete").ToString() + " pieza(s) c/u";

            object objFecha = requisicion.Celda("fecha_creacion");
            DateTime dtFecha = DateTime.Now.AddDays(1);
            string fecha = "N/A";
            if (objFecha != null)
            {
                dtFecha = Convert.ToDateTime(objFecha);
                fecha = dtFecha.ToString("MMM dd, yyyy hh:mm:ss tt");
            }

            DgvRequisiciones.Rows.Add( requisicion.Celda("id"), 
                                        fecha,
                                        requisicion.Celda("requisitor"), 
                                        Convert.ToDecimal(requisicion.Celda("proyecto")).ToString("F2"),
                                        requisicion.Celda("piezas_requeridas"),
                                        strTotal,
                                        requisicion.Celda("estatus_seleccion"),
                                        requisicion.Celda("estatus_autorizacion"),
                                        requisicion.Celda("estatus_compra"),
                                        requisicion.Celda("estatus_almacen")
                                        );

                if (dtFecha.Date == DateTime.Now.Date)
                {
                    DataGridViewCell cell = DgvRequisiciones.Rows[DgvRequisiciones.RowCount - 1].Cells["fecha_requisicion"];
                    cell.Style.BackColor = Color.Yellow;
                }
            });
        }

        public void BorrarDatosMaterial()
        {
            LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";
            DatosMaterial.Visible = false;
            BtnOpcionesMaterial.Enabled = false;
        }

        private void BtnOpcionesMaterial_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesMaterial.ContextMenuStrip != null)
                BtnOpcionesMaterial.ContextMenuStrip.Show(BtnOpcionesMaterial, BtnOpcionesMaterial.PointToClient(Cursor.Position));
        }

        private void verCotizaciones_Click(object sender, EventArgs e)
        {
            FrmVerCotizacionesMaterial coti = new FrmVerCotizacionesMaterial(NumeroDeParteSeleccionado);
            coti.ShowDialog();
        }

        private void BtnRFQs_Click(object sender, EventArgs e)
        {
            FrmRFQs rfq = new FrmRFQs(BuscadorMaterial.Filtros);
            rfq.MdiParent = this.MdiParent;
            rfq.Show();
            this.Close();
        }

        private void BtnPOs_Click(object sender, EventArgs e)
        {
            FrmPOs po = new FrmPOs();
            po.MdiParent = this.MdiParent;
            po.Show();
            this.Close();
        }

        private void verDetalles_Click(object sender, EventArgs e)
        {
            FrmDetallesMaterialProyecto det = new FrmDetallesMaterialProyecto(RequisicionSeleccionada);
            det.ShowDialog();
        }

        private void DgvRequisiciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( DgvRequisiciones.SelectedRows.Count > 0 )
            {
                RequisicionSeleccionada = Convert.ToInt32(DgvRequisiciones.SelectedRows[0].Cells[0].Value);
                verDetalles.Enabled = true;
                verCotizaciones.Enabled = true;
            }
        }

        private void DgvMaterial_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvMaterial.SelectedRows.Count > 0 && DgvMaterial.Rows.Count > 0)
            {
                NumeroDeParteSeleccionado = DgvMaterial.SelectedRows[0].Cells[0].Value.ToString();
                MostrarDatosMaterial(NumeroDeParteSeleccionado);
                verDetalles.Enabled = false;
                verCotizaciones.Enabled = false;
            }
        }

        private void BtnFiltrarDatos_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos filtrar = new FrmFiltrarDatos(BuscadorMaterial.Filtros);

            if( filtrar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                BuscadorMaterial.Filtros = filtrar.Filtros;
                CargarMaterial();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarMaterial();
        }

        private void reciclarRFQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialProyecto mat = new MaterialProyecto();
            mat.CargarDatos(RequisicionSeleccionada);

            if(!mat.TieneFilas())
            {
                MessageBox.Show("La requisición no fue encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmSeleccionarRFQ sel = new FrmSeleccionarRFQ();

            if( sel.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                bool fueCotizado = false;

                RfqConcepto conceptos = new RfqConcepto();
                foreach(Fila f in conceptos.SeleccionarRfq(sel.RfqSeleccionado))
                {
                    if (NumeroDeParteSeleccionado == f.Celda("numero_parte").ToString())
                    {
                        fueCotizado = true;
                        break;
                    }
                }

                if(fueCotizado)
                {
                    mat.Fila().ModificarCelda("estatus_compra", "EN COTIZACION");
                    mat.GuardarDatos();
                    MessageBox.Show("RFQ reciclado correctamente!", "RFQ reciclado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDatosMaterial(NumeroDeParteSeleccionado);
                }
                else
                {
                    MessageBox.Show("El RFQ seleccionado no contiene el número de parte.", "Error al reciclar RFQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void NumRequisicion_ValueChanged(object sender, EventArgs e)
        {
 
        }

        private void NumRequisicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( Convert.ToInt32(e.KeyChar) == 13 )
            {
                int idMaterial = Convert.ToInt32(NumRequisicion.Value);

                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(idMaterial);

                if (mat.TieneFilas())
                {
                    FrmDetallesMaterialProyecto det = new FrmDetallesMaterialProyecto(idMaterial);
                    det.ShowDialog();
                }
                else
                {
                    MessageBox.Show("La requisición no fue encontrada!", "Requisición no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DateHasta_ValueChanged(object sender, EventArgs e)
        {
            //CargarMaterial();
        }

        private void DateDesde_ValueChanged(object sender, EventArgs e)
        {
            //CargarMaterial();
        }

        private void BtnMetas_Click(object sender, EventArgs e)
        {
            FrmMetasCompras metas = new FrmMetasCompras();
            metas.Show();
        }

        private void BtnKpis_Click(object sender, EventArgs e)
        {
            Proceso proceso = new Proceso();
            proceso.SeleccionarNombre("COMPRAS");
            if(proceso.TieneFilas())
            {
                FrmBuscadorKPIs kpis = new FrmBuscadorKPIs(Convert.ToInt32(proceso.Fila().Celda("id")));
                kpis.Show();
            }
        }
    }
}
