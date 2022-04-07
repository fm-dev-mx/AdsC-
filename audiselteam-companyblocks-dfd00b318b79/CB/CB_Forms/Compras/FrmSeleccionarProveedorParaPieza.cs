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
    public partial class FrmSeleccionarProveedorParaPieza : Form
    {
        int Cantidad = 0;
        string TipoVenta = string.Empty;
        MaterialProyecto Requisiciones = null;
        int IdRequisicionCompraPreseleccionada = 0;
        int IdRfqConceptoPreseleccionado = 0;
        List<int> RequisicionesSeleccionadas = new List<int>();


        public FrmSeleccionarProveedorParaPieza(MaterialProyecto requisiciones, int rfqConceptoPreseleccionado=0, int idRequisicionCompraPreseleccionada=0)
        {
            InitializeComponent();

            if(!requisiciones.TieneFilas())
            {
                MessageBox.Show("Este Form debe recibir al menos una requisición de compra.",
                                "Requisiciones no encontradas",
                                MessageBoxButtons.OK, MessageBoxIcon.Error
                                );
                Close();
            }
            else Requisiciones = requisiciones;

            IdRfqConceptoPreseleccionado = rfqConceptoPreseleccionado;
            IdRequisicionCompraPreseleccionada = idRequisicionCompraPreseleccionada;
        }

        private void FrmSeleccionarProveedorParaPieza_Load(object sender, EventArgs e)
        {
            CargarDatosMaterial();
            CargarRequisicionesCompra();
            CargarConceptosCotizacion();
        }


        private void CargarDatosMaterial()
        {
            if (Requisiciones.Fila().Celda("tipo_venta").ToString() == "POR PIEZA")
                TipoVenta = "PIEZA(S)";
            else
                TipoVenta = "PAQUETE(S) CON " + Requisiciones.Fila().Celda("piezas_paquete").ToString() + " PIEZAS";

            TxtNumeroParte.Text = Requisiciones.Fila().Celda("numero_parte").ToString();
            TxtFabricante.Text = Requisiciones.Fila().Celda("fabricante").ToString();
            TxtDescripcion.Text = Requisiciones.Fila().Celda("descripcion").ToString();

            // si no se paso ningun RfqConcepto en el constructor, tomamos el rfq concepto
            // de la primera requisicion 
            if(IdRfqConceptoPreseleccionado == 0)
                IdRfqConceptoPreseleccionado = Convert.ToInt32(Requisiciones.Fila().Celda("rfq_concepto"));
        }

        private void CargarConceptosCotizacion()
        {
            List<Fila> ultimasCotizaciones = RfqConcepto.Modelo().UltimasCotizaciones(Requisiciones.Fila().Celda("numero_parte").ToString());
            bool ConceptoPreseleccionadoEncontrado = false;


            DgvUltimosConceptos.Rows.Clear();
            ultimasCotizaciones.ForEach(delegate(Fila conceptoCotizacion)
            {
                if(conceptoCotizacion.TieneCelda("id"))
                {
                    if(ConceptoPreseleccionadoEncontrado == false && conceptoCotizacion.Celda("id").ToString() == IdRfqConceptoPreseleccionado.ToString())
                        ConceptoPreseleccionadoEncontrado = true;

                    DgvUltimosConceptos.Rows.Add(
                        conceptoCotizacion.Celda("id").ToString() == IdRfqConceptoPreseleccionado.ToString(),
                        conceptoCotizacion.Celda("rfq"),
                        conceptoCotizacion.Celda("nombre_proveedor"),
                        conceptoCotizacion.Celda("id"),
                        conceptoCotizacion.Celda("precio_unitario"),
                        conceptoCotizacion.Celda("moneda"),
                        conceptoCotizacion.Celda("cantidad_disponible"),
                        conceptoCotizacion.Celda("tiempo_entrega"),
                        Global.FechaATexto(conceptoCotizacion.Celda("fecha_cotizacion"), false)
                        );
                }
            });

            if(IdRfqConceptoPreseleccionado > 0 && !ConceptoPreseleccionadoEncontrado)
            {
                RfqConcepto conceptoSelec = new RfqConcepto();

                string sql = "SELECT rfq_conceptos.*, proveedores.nombre AS nombre_proveedor ";
                sql += "FROM rfq_conceptos ";
                sql += "INNER JOIN rfq_material ON rfq_material.id=rfq_conceptos.rfq ";
                sql += "INNER JOIN proveedores ON proveedores.id=rfq_material.proveedor ";
                sql += "WHERE rfq_conceptos.id=@idConcepto";

                conceptoSelec.ConstruirQuery(sql);
                conceptoSelec.AgregarParametro("idConcepto", IdRfqConceptoPreseleccionado);
                conceptoSelec.EjecutarQuery();
                conceptoSelec.LeerFilas();

                conceptoSelec.Filas().ForEach(delegate(Fila conceptoCotizacion)
                {
                    DgvUltimosConceptos.Rows.Add(
                        conceptoCotizacion.Celda("id").ToString() == IdRfqConceptoPreseleccionado.ToString(),
                        conceptoCotizacion.Celda("rfq"),
                        conceptoCotizacion.Celda("nombre_proveedor"),
                        conceptoCotizacion.Celda("id"),
                        conceptoCotizacion.Celda("precio_unitario"),
                        conceptoCotizacion.Celda("moneda"),
                        conceptoCotizacion.Celda("cantidad_disponible"),
                        conceptoCotizacion.Celda("tiempo_entrega"),
                        Global.FechaATexto(conceptoCotizacion.Celda("fecha_cotizacion"), false)
                    );
                });
            }
        }

        private void CargarRequisicionesCompra()
        {
            DgvRequisiciones.Rows.Clear();
            Requisiciones.Filas().ForEach(delegate(Fila f)
            {
                bool requisicionDebeSeleccionarse = f.Celda("id").ToString() == IdRequisicionCompraPreseleccionada.ToString();

                if (requisicionDebeSeleccionarse && !RequisicionesSeleccionadas.Contains(IdRequisicionCompraPreseleccionada))
                {
                    RequisicionesSeleccionadas.Add(IdRequisicionCompraPreseleccionada);
                    Cantidad += Convert.ToInt32(Requisiciones.Fila().Celda("total"));
                    TxtCantEstimada.Text = Cantidad + " " + TipoVenta;
                    BtnSeleccionarProveedor.Enabled = true;
                }
                else BtnSeleccionarProveedor.Enabled = false;

                DgvRequisiciones.Rows.Add(requisicionDebeSeleccionarse,
                                          f.Celda("id"),
                                          f.Celda("total"),
                                          Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                                          f.Celda("requisitor"),
                                          Global.FechaATexto(f.Celda("fecha_creacion"), true),
                                          f.Celda("estatus_compra")
                                          );
            });
        }


        private void DgvUltimosConceptos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            
            for (int i = 0; i < DgvUltimosConceptos.Rows.Count; i++)
            {
                if (DgvUltimosConceptos.Rows[i].Index != e.RowIndex && (bool)DgvUltimosConceptos.Rows[i].Cells["preferido"].Value == true)
                {
                    DgvUltimosConceptos.Rows[i].Cells["preferido"].Value = false;
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            // Buscar el concepto que esta seleccionado en el datagridview
            int idConceptoSeleccionado = 0;
            decimal precioUnitario = 0;
            string monedaProveedorPreferido = string.Empty;
            string proveedorPreferido = string.Empty;

            for (int i = 0; i < DgvUltimosConceptos.Rows.Count; i++)
            {
                if ((bool)DgvUltimosConceptos.Rows[i].Cells["preferido"].Value == true)
                {
                    idConceptoSeleccionado = Convert.ToInt32(DgvUltimosConceptos.Rows[i].Cells["concepto"].Value);
                    precioUnitario = Convert.ToDecimal(DgvUltimosConceptos.Rows[i].Cells["precio_unitario"].Value);
                    monedaProveedorPreferido = DgvUltimosConceptos.Rows[i].Cells["moneda"].Value.ToString();
                    proveedorPreferido = DgvUltimosConceptos.Rows[i].Cells["proveedor"].Value.ToString();
                    break;
                }
            }

            // Si no encuentra ningun concepto seleccionado, alertar al usuario y abortar
            if(idConceptoSeleccionado == 0)
            {
                DialogResult respuesta  =
                MessageBox.Show("No se ha seleccionado ningún proveedor, ¿está seguro de continuar y devolver las requisiciones seleccionadas a cotización?",
                                "Proveedor sin seleccionar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (respuesta == System.Windows.Forms.DialogResult.No)
                    return;
            }
            // si se encuentra un concepto seleccionado, pero su precio no ha sido capturado, alertar al usuario y aborar
            else if(precioUnitario <= 0)
            {
                MessageBox.Show("La cotización de " + proveedorPreferido + " no ha sido capturada, da clic derecho y utiliza la opción 'Capturar cotización'.",
                                "Cotización sin capturar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }

            // para cada requisicion de compra 
            Requisiciones.Filas().ForEach(delegate(Fila requisicion)
            {
                // si la requisicion de compra fue seleccionada en el dgv
                int idReq = Convert.ToInt32(requisicion.Celda("id"));
                if(RequisicionesSeleccionadas.Contains(idReq))
                {
                    string requisiciones = MaterialProyecto.Modelo().SeleccionarProveedorPreferido(requisicion, idConceptoSeleccionado);
                    if (requisiciones != "")
                        MessageBox.Show("La requisición fue enviada a revisión técnica ya que excedía el límite de costo", "Requisición enviada a revisión técnica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }); 
            Requisiciones.GuardarDatos();

            if(idConceptoSeleccionado > 0)
            {
                MessageBox.Show("Se asignó a " + proveedorPreferido + " como proveedor preferido para las requisiciones seleccionadas.",
                                "Seleccionar proveedor preferido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                MessageBox.Show("Se deshizo la asignación de proveedor preferido y las requisiciones seleccionadas fueron devueltas a cotización.",
                       "Deshacer la selección de proveedor preferido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
            }

            // salir del form solo cuando se selecciono un proveedor del dgv
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private double ObtenerPromedioProveedores(string monedaProveedorPreferido)
        {
            double promedioCotizacion = 0;
            //double sumaCotizacion = 0;

            //foreach (DataGridViewRow row in DgvUltimosConceptos.Rows)
            //{
            //    double moneda = Global.ObtenerTipoCambio(row.Cells["moneda"].Value.ToString(), monedaProveedorPreferido);
            //    double precioUnitario = Convert.ToDouble(row.Cells["precio_unitario"].Value.ToString());
            //    int cantidad = Convert.ToInt32(TxtCantEstimada.Text);
            //    sumaCotizacion = sumaCotizacion + (precioUnitario * cantidad);
            //}

            //promedioCotizacion = sumaCotizacion / DgvUltimosConceptos.Rows.Count;
            return promedioCotizacion;
        }

        private void insertarInformacionKPI(object idConcepto, Fila material, string monedaProveedorFavorito)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idMaterial", Convert.ToInt32(material.Celda("id")));

            MaterialProyectoKpi materialkpi = new MaterialProyectoKpi();
            materialkpi.SeleccionarDatos("id_material_proyecto=@idMaterial", parametros);

            //No se selecciona proveedor
            if (idConcepto == null)
            {
                if (materialkpi.TieneFilas())
                {
                    materialkpi.Fila().ModificarCelda("fecha_proveedor_seleccionado", null);
                    materialkpi.Fila().ModificarCelda("precio_promedio", null);
                    materialkpi.GuardarDatos();
                }
            }
            else //selección de proveedor
            {
                if (materialkpi.TieneFilas())
                {
                    materialkpi.Fila().ModificarCelda("fecha_proveedor_seleccionado", DateTime.Now);
                    materialkpi.Fila().ModificarCelda("precio_promedio", ObtenerPromedioProveedores(monedaProveedorFavorito));
                    materialkpi.GuardarDatos();
                }
                else
                {
                    Fila insertarMaterialKpi = new Fila();
                    insertarMaterialKpi.AgregarCelda("id_material_proyecto", Convert.ToInt32(material.Celda("id")));
                    insertarMaterialKpi.AgregarCelda("fecha_proveedor_seleccionado", DateTime.Now);
                    materialkpi.Fila().ModificarCelda("precio_promedio", ObtenerPromedioProveedores(monedaProveedorFavorito));
                    materialkpi.Insertar(insertarMaterialKpi);
                }
            }
        }

        private void DgvRequisiciones_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // End of edition on each click on column of checkbox
            if (e.ColumnIndex == seleccionRequisicion.Index && e.RowIndex != -1)
            {
                DgvRequisiciones.EndEdit();
            }
        }

        private void DgvRequisiciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == seleccionRequisicion.Index && e.RowIndex != -1)
            {
                int idReq = Convert.ToInt32(DgvRequisiciones[idRequisicionCompra.Index, e.RowIndex].Value);

                if( (bool)DgvRequisiciones[e.ColumnIndex, e.RowIndex].EditedFormattedValue )
                {
                    if (!RequisicionesSeleccionadas.Contains(idReq))
                    {
                        RequisicionesSeleccionadas.Add(idReq);
                        Cantidad += Convert.ToInt32(DgvRequisiciones[cantidadRequisicion.Index, e.RowIndex].Value);
                    }
                }
                else
                {
                    if (RequisicionesSeleccionadas.Contains(idReq))
                    {
                        RequisicionesSeleccionadas.Remove(idReq);
                        Cantidad -= Convert.ToInt32(DgvRequisiciones[cantidadRequisicion.Index, e.RowIndex].Value);
                    }
                }
                TxtCantEstimada.Text = Cantidad + " " + TipoVenta;
                BtnSeleccionarProveedor.Enabled = RequisicionesSeleccionadas.Count > 0;
            }
        }

        private void capturarCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvUltimosConceptos.SelectedRows.Count == 0)
                return;

            int IdConcepto = Convert.ToInt32(DgvUltimosConceptos.SelectedRows[0].Cells["concepto"].Value);

            RfqConcepto Concepto = new RfqConcepto();
            Concepto.CargarDatos(IdConcepto);

            FrmCapturarCotizacionMaterial capturar = new FrmCapturarCotizacionMaterial(IdConcepto);
            capturar.PrecioUnitario = Convert.ToDecimal(Concepto.Fila().Celda("precio_unitario"));
            capturar.TiempoEntrega = Convert.ToInt32(Concepto.Fila().Celda("tiempo_entrega"));

            if (capturar.ShowDialog() == DialogResult.OK)
            {
                RfqConcepto modificarConcepto = new RfqConcepto();
                int idRfq = Convert.ToInt32(DgvUltimosConceptos.SelectedRows[0].Cells["rfq"].Value);
                modificarConcepto.SeleccionarMaterialesDeRFQ(idRfq, TxtNumeroParte.Text).ForEach(delegate(Fila f)
                {
                    f.ModificarCelda("precio_unitario", capturar.PrecioUnitario);
                    f.ModificarCelda("tiempo_entrega", capturar.TiempoEntrega);
                    f.ModificarCelda("moneda", capturar.Moneda);
                    f.ModificarCelda("cantidad_disponible", capturar.CantidadDisponible);
                    f.ModificarCelda("fecha_cotizacion", DateTime.Today);
                });

                modificarConcepto.GuardarDatos();
                CargarConceptosCotizacion();
            }
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow fila in DgvRequisiciones.Rows)
            {
                DataGridViewCheckBoxCell ckB = (DataGridViewCheckBoxCell)fila.Cells[0];

                if (ckB.Value != null && !(bool)ckB.Value) 
                {
                    ckB.Value = true;
                }
            }
        }

        private void seleccionarNadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in DgvRequisiciones.Rows)
            {
                DataGridViewCheckBoxCell ckB = (DataGridViewCheckBoxCell)fila.Cells[0];

                if (ckB.Value != null && (bool)ckB.Value)
                {
                    ckB.Value = false;
                }
            }
        }
    }
}
