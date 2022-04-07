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
    public partial class FrmAgregarRfq : Form
    {
        FrmMonitorCompras2 FrmCompras = null;
        bool AgruparPartidas = true;
        bool RfqEnviado = false;
        int IdReqInicial = -1;
        int IdRfq = 0;
        string StrProveedorSeleccionado = string.Empty;

        public string ProveedorSeleccionado {
            get {
                return LblRFQ.Text.Split(new char[] { '-' }, 2)[1].TrimEnd().TrimStart();
            }
        }

        public FrmAgregarRfq(FrmMonitorCompras2 frmCompras)
        {
            InitializeComponent();
            FrmCompras = frmCompras;
        }

        public FrmAgregarRfq(FrmMonitorCompras2 frmCompras, int idRfq, bool agruparPartidas, int idReqInicial = -1):this(frmCompras)
        {
            IdRfq = idRfq;
            RfqEnviado = EstatusRfqPo.RfqEstatus;
            MostrarPartidas(IdRfq);
            AgruparPartidas = agruparPartidas;
            IdReqInicial = idReqInicial;
        }

        private void FrmAgregarRfq_Load(object sender, EventArgs e)
        {
            if(RfqEnviado)
            {
                BtnNuevo.Enabled = false;
                BtnNuevo.Visible = false;
                BtnAgregarMaterial.Visible = false;
                BtnQuitarMaterial.Visible = false;
            }
            else
            {
                BtnAsignarConceptos.Visible = false;
                if (IdReqInicial > 0)
                {
                    AgregarRequisiciones(new List<int> { IdReqInicial }, true);
                }
            }
        }

        public void ActivarBotonAgregarMaterial(bool activar)
        {
            if (!RfqEnviado)
                BtnAgregarMaterial.Enabled = activar;
        }

        private void BtnAgregarMaterial_Click(object sender, EventArgs e)
        {
            AgregarRequisiciones();
        }

        public void AgregarRequisiciones()
        {
            List<int> resultado = (FrmCompras).CargarPartidas().Distinct().ToList();
            bool agrupar = (FrmCompras).AgruparPartidas();
            AgregarRequisiciones(resultado, agrupar);            
        }

        public void AgregarRequisiciones(List<int> resultado, bool agrupar)
        {
            string materialNoAgregado = string.Empty;
            BtnAgregarMaterial.Enabled = false;
            bool ban = false;

            if (RfqEnviado)
                return;

            MaterialProyecto mat = new MaterialProyecto();
            string idMateriales = string.Empty;
            string materialRepetido = string.Empty;

            foreach (var idMaterial in resultado)
            {
                if (RelacionMaterialRfq.Modelo().VerificarEnlace(idMaterial, IdRfq))
                    materialRepetido += "REQ #" + idMaterial + Environment.NewLine;
                else
                    idMateriales += idMaterial + ",";
            }

            if(idMateriales == "")
            {
                MessageBox.Show("Las siguientes requisiciones ya existe en este RFQ." + Environment.NewLine + materialRepetido, "Requisición existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            idMateriales = idMateriales.Remove(idMateriales.Length - 1, 1);

            if (agrupar)
                mat.EnProcesoDeCompra(idMateriales, agrupar);
            else
                mat.SeleccionarRequisicionRFQ(idMateriales);

            mat.Filas().ForEach(delegate(Fila f)
            {
                if ((f.Celda("estatus_autorizacion").ToString() == "RECHAZADO" || f.Celda("estatus_autorizacion").ToString() == "CANCELADO" || f.Celda("estatus_compra").ToString() == "CANCELADO") 
                && (f.Celda("estatus_almacen").ToString() != "ENTREGADO") && (f.Celda("estatus_seleccion").ToString()) != "DEFINIDO")
                {
                    materialNoAgregado = "1REQ #" + f.Celda<int>("id").ToString() + ", Número de parte: " + f.Celda<string>("numero_parte").ToString() + ", Estatus autorización: " + f.Celda("estatus_autorizacion").ToString()
                    + ", Estatus compra: " + f.Celda("estatus_compra").ToString() + Environment.NewLine;
                }                    
                else
                {
                    List<string> ListaRequisiciones = new List<string>();

                    mat.DesgloseEnProcesoDeCompraPorNumeroParte(f.Celda("numero_parte").ToString());
                    mat.Filas().ForEach(delegate(Fila m)
                    {
                        if (Convert.ToInt32(m.Celda("po")) == 0 && m.Celda("estatus_autorizacion").ToString() != "RECHAZADO" && f.Celda("estatus_compra").ToString() != "CANCELADO")
                        {
                            m.ModificarCelda("estatus_compra", "EN COTIZACION");

                            foreach (string idMaterial in idMateriales.Split(','))
                            {
                                string idEncontrado = ListaRequisiciones.Find(x => x.Equals(idMaterial));
                                if (idEncontrado == null)
                                {
                                    MaterialProyecto material = new MaterialProyecto();
                                    material.CargarDatos(Convert.ToInt32(idMaterial));
                                    if (material.TieneFilas())
                                    {
                                        string numero_parte = material.Fila().Celda("numero_parte").ToString();
                                        string fabricante = material.Fila().Celda("fabricante").ToString();
                                        string descripcion = material.Fila().Celda("descripcion").ToString();
                                        string cantidad_estimada = material.Fila().Celda("piezas_requeridas").ToString();
                                        string tipo_venta = material.Fila().Celda("tipo_venta").ToString();

                                        Fila partida = new Fila();
                                        RfqConcepto concepto = new RfqConcepto();
                                        partida.AgregarCelda("rfq", IdRfq);
                                        partida.AgregarCelda("numero_parte", numero_parte);
                                        partida.AgregarCelda("fabricante", fabricante);
                                        partida.AgregarCelda("descripcion", descripcion);
                                        partida.AgregarCelda("precio_unitario", 0);
                                        partida.AgregarCelda("tiempo_entrega", 0);

                                        if (tipo_venta == "POR PAQUETE")
                                            partida.AgregarCelda("cantidad_estimada", material.Fila().Celda("total").ToString());
                                        else
                                            partida.AgregarCelda("cantidad_estimada", cantidad_estimada);

                                        partida.AgregarCelda("tipo_venta", tipo_venta);
                                        int idConcepto = Convert.ToInt32(concepto.Insertar(partida).Celda("id"));

                                        Fila insertarRelacion = new Fila();
                                        insertarRelacion.AgregarCelda("numero_parte", material.Fila().Celda("numero_parte").ToString());
                                        insertarRelacion.AgregarCelda("id_rfq", IdRfq);
                                        insertarRelacion.AgregarCelda("id_material_proyecto", material.Fila().Celda("id"));
                                        insertarRelacion.AgregarCelda("id_concepto", idConcepto);
                                        RelacionMaterialRfq.Modelo().Insertar(insertarRelacion);
                                        ban = true;

                                        ListaRequisiciones.Add(material.Fila().Celda("id").ToString());

                                    }
                                }
                            }
                        }
                        else
                        {
                            materialNoAgregado = "2REQ #" + f.Celda<int>("id").ToString() + ", Número de parte: " + f.Celda<string>("numero_parte").ToString() + ", Estatus autorización: " + f.Celda("estatus_autorizacion").ToString()
                            + ", Estatus compra: " + f.Celda("estatus_compra").ToString() + Environment.NewLine;
                        }                            

                    });

                    mat.GuardarDatos();
                    if (!agrupar)
                        mat.SeleccionarRequisicionRFQ(idMateriales);
                }
            });                                 

            if (materialNoAgregado != "" && ban==false)
                MessageBox.Show("El siguiente material no puede ser añadido a un RFQ " + Environment.NewLine + materialNoAgregado, "Material no añadido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(materialRepetido != "")
                MessageBox.Show("Las siguientes requisiciones ya existe en este RFQ." + Environment.NewLine + materialRepetido, "Requisición existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            MostrarPartidas(IdRfq);
            BtnAgregarMaterial.Enabled = true;
        }

        public void MostrarPartidas(int idRfq)
        {
            RfqMaterial mat = new RfqMaterial();
            mat.CargarDatos(idRfq);
            int IdProveedor = Convert.ToInt32(mat.Fila().Celda("proveedor"));

            //habilitar btnCamion si tienen alguna partida sin proveedor asignado


            Proveedor prov = new Proveedor();
            prov.CargarDatos(IdProveedor);

            LblRFQ.Text = "RFQ #" + idRfq.ToString() + " - " + prov.Fila().Celda("nombre");
            StrProveedorSeleccionado = prov.Fila().Celda("nombre").ToString();

            int fila = Global.GuardarFilaSeleccionada(DgvConceptos);           

            MaterialProyecto requisicionesEnCotizacion = new MaterialProyecto(); 
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            int partida = 1;
            DgvConceptos.Rows.Clear();
            bool requisicionesPendientes = false;
            RfqConcepto.Modelo().SeleccionarRfqAgruparPorNumeroParte(idRfq).ForEach(delegate(Fila concepto)
            {
                string strPrecioUnitario = "";
                string strTiempoEntrega = "";
                int requisicionesCompraPorProcesar = 0;
                
                strPrecioUnitario = String.Format("{0:C}", Convert.ToDecimal(concepto.Celda("precio_unitario"))) + " " + concepto.Celda("moneda").ToString();

                // cuenta las requisiciones de compra vinculadas con este numero de parte y que aun no tienen proveedor seleccionado
                requisicionesCompraPorProcesar 
                    = MaterialProyecto.Modelo().RequisicionesSinProveedorSeleccionado(concepto.Celda<string>("numero_parte")).Count();

                if (Convert.ToInt32(concepto.Celda("tiempo_entrega")) == 0)
                    strTiempoEntrega = "?";
                else
                    strTiempoEntrega = concepto.Celda("tiempo_entrega").ToString() + " día(s)";

                DgvConceptos.Rows.Add(
                    concepto.Celda("id"), 
                    partida, concepto.Celda("numero_parte"), 
                    concepto.Celda("fabricante"), 
                    concepto.Celda("descripcion"),
                    concepto.Celda("cantidad_total"),
                    concepto.Celda("tipo_venta"), 
                    strPrecioUnitario, 
                    strTiempoEntrega, 
                    concepto.Celda("cantidad_disponible"), 
                    requisicionesCompraPorProcesar,
                    requisicionesCompraPorProcesar
                    );

                if (requisicionesCompraPorProcesar > 0)
                {
                    DataGridViewCell celdaId = DgvConceptos.Rows[DgvConceptos.RowCount - 1].Cells["partida"];
                    celdaId.Style.BackColor = Color.Yellow;
                    requisicionesPendientes = true;
                }

                partida++;
            });

            Global.RecuperarFilaSeleccionada(DgvConceptos, fila);

            LblEstatus.Text = "Estatus: " + mat.Fila().Celda("estatus").ToString();
            LblFechaCreacion.Text =  "Fecha de creación: " + Global.FechaATexto(mat.Fila().Celda("fecha_creacion"));
            LblRequisitor.Text = "Requisitor: " + mat.Fila().Celda("usuario").ToString();

            MostrarCosto(IdRfq);
        }

        public void MostrarCosto(int idRfq)
        {
            //Valida si seleccionan alguna de las opciones de tipo de cambio
            //para hacer la conversión necesaria
            if (radioMxn.Checked == true || radioUsd.Checked == true)
            {
                //Convierte el tipo de cambio a MXN
                if (radioMxn.Checked == true)
                {
                    // Muestra la información agrupada por número de parte
                    if (radioNumPart.Checked == true)
                    {
                        DgvCostos.Rows.Clear();
                        RfqConcepto.Modelo().SeleccionarCostosRfqPorNumeroParte(idRfq).ForEach(delegate (Fila concepto)
                        {
                            string strCostoTotal = string.Empty;
                            strCostoTotal = Convertir_Moneda("UsMx", Convert.ToDecimal(concepto.Celda("costo_total")), Convert.ToString(concepto.Celda("moneda")));

                            MostrarCostoDgv("num_part", Convert.ToString(concepto.Celda("numero_parte")), "", strCostoTotal);
                        });
                    }
                    //Muestra la información agrupada por proyecto
                    else
                    {
                        DgvCostos.Rows.Clear();
                        RfqConcepto.Modelo().SeleccionarCostosRfqPorProyecto(idRfq).ForEach(delegate (Fila concepto)
                        {
                            string strCostoTotal = string.Empty;
                            strCostoTotal = Convertir_Moneda("UsMx", Convert.ToDecimal(concepto.Celda("costo_total")), Convert.ToString(concepto.Celda("moneda")));
                            MostrarCostoDgv("proyecto", Convert.ToString(concepto.Celda("proyecto")), Convert.ToString(concepto.Celda("nombre")), strCostoTotal);
                        });
                    }
                }
                //Convierte el tipo de cambio a USD
                else
                {
                    // Muestra la información agrupada por número de parte
                    if (radioNumPart.Checked == true)
                    {
                        DgvCostos.Rows.Clear();
                        RfqConcepto.Modelo().SeleccionarCostosRfqPorNumeroParte(idRfq).ForEach(delegate (Fila concepto)
                        {
                            string strCostoTotal = string.Empty;
                            strCostoTotal = Convertir_Moneda("MxUs", Convert.ToDecimal(concepto.Celda("costo_total")), Convert.ToString(concepto.Celda("moneda")));
                            MostrarCostoDgv("num_part", Convert.ToString(concepto.Celda("numero_parte")), "", strCostoTotal);
                        });
                    }
                    //Muestra la información agrupada por proyecto
                    else
                    {
                        DgvCostos.Rows.Clear();
                        RfqConcepto.Modelo().SeleccionarCostosRfqPorProyecto(idRfq).ForEach(delegate (Fila concepto)
                        {
                            string strCostoTotal = string.Empty;
                            strCostoTotal = Convertir_Moneda("MxUs", Convert.ToDecimal(concepto.Celda("costo_total")), Convert.ToString(concepto.Celda("moneda")));
                            MostrarCostoDgv("proyecto", Convert.ToString(concepto.Celda("proyecto")), Convert.ToString(concepto.Celda("nombre")), strCostoTotal);
                        });
                    }
                }
            }
            //Si no se selecciona ninguna lo agrupara por proyecto o núm. de parte según sea el caso
            //y se agrupara por el tipo de cambio seleccionado en la base de datos
            else
            {
                // Muestra la información agrupada por número de parte
                if (radioNumPart.Checked == true)
                {
                    DgvCostos.Rows.Clear();
                    RfqConcepto.Modelo().SeleccionarCostosRfqPorNumeroParte(idRfq).ForEach(delegate (Fila concepto)
                    {
                        string strCostoTotal = string.Empty;

                        strCostoTotal = String.Format("{0:C}", Convert.ToDecimal(concepto.Celda("costo_total"))) + " " + concepto.Celda("moneda").ToString();
                        MostrarCostoDgv("num_part", Convert.ToString(concepto.Celda("numero_parte")), "", strCostoTotal);
                    });
                }
                //Muestra la información agrupada por proyecto
                else
                {
                    DgvCostos.Rows.Clear();
                    RfqConcepto.Modelo().SeleccionarCostosRfqPorProyecto(idRfq).ForEach(delegate (Fila concepto)
                    {
                        string strCostoTotal = string.Empty;
                        strCostoTotal = String.Format("{0:C}", Convert.ToDecimal(concepto.Celda("costo_total"))) + " " + concepto.Celda("moneda").ToString();
                        MostrarCostoDgv("proyecto", Convert.ToString(concepto.Celda("proyecto")), Convert.ToString(concepto.Celda("nombre")), strCostoTotal);
                    });
                }
            }
        }        

        public void MostrarCostoDgv(string tipo, string valor, string proyecto, string costo)
        {
            DataGridViewColumn columnNumPart = DgvCostos.Columns[0];
            DataGridViewColumn columnProyecto = DgvCostos.Columns[1];
            DataGridViewColumn columnDescProyecto = DgvCostos.Columns[2];

            switch (tipo)
            {
                case "proyecto":
                    columnNumPart.Visible = false;
                    columnProyecto.Visible = true;
                    columnDescProyecto.Visible = true;

                    DgvCostos.Rows.Add(
                            "",
                            valor,
                            proyecto,
                            costo
                            );

                    break;
                case "num_part":
                    columnNumPart.Visible = true;
                    columnProyecto.Visible = false;
                    columnDescProyecto.Visible = false;

                    DgvCostos.Rows.Add(
                            valor,
                            "",
                            "",
                            costo
                            );
                    break;
            }            
        }

        private string Convertir_Moneda(string tipo, decimal costoOriginal, string moneda)
        {
            decimal valorUsd = 0.0m;
            if (Global.ObtenerTipoCambio("USD")==0)
                valorUsd = Convert.ToDecimal(Global.ObtenerTipoCambio("USD"));
            else
                valorUsd = 19.0m;

            string strCostoTotal = string.Empty;           
            decimal costoConvertido = 0.0m;

            switch (tipo)
            {
                case "MxUs":
                    if (moneda == "MXN")
                    {
                        costoConvertido = costoOriginal / valorUsd;
                        strCostoTotal = String.Format("{0:C}", costoConvertido) + " USD";
                    }
                    else
                        strCostoTotal = String.Format("{0:C}", costoOriginal) + " USD";
                    break;
                case "UsMx":
                    if (moneda == "MXN")
                        strCostoTotal = String.Format("{0:C}", costoOriginal) + " MXN";
                    else
                    {
                        costoConvertido = costoOriginal * valorUsd;
                        strCostoTotal = String.Format("{0:C}", costoConvertido) + " MXN";
                    }                    
                    break;
            }
            return strCostoTotal;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmEnviarRFQ enviar = new FrmEnviarRFQ(IdRfq);

            if (enviar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FrmCompras.CargarRFQPorUsuario();
                FrmCompras.CerrarContenido();
            }
        }

        private void BtnQuitarMaterial_Click(object sender, EventArgs e)
        {
            if (DgvConceptos.SelectedRows.Count <= 0)
                return;

            DialogResult resultado = MessageBox.Show("Seguro que deseas borrar las partidas seleccionadas?", "Borrar partidas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvConceptos.SelectedRows)
                {
                    RelacionMaterialRfq.Modelo().SeleccionarIdRequisiciones(row.Cells["numero_parte"].Value.ToString(), IdRfq).ForEach(delegate(Fila f)
                    {
                       /* Dictionary<string, object> parametros = new Dictionary<string, object>();
                        parametros.Add("@numero_parte", f.Celda("numero_parte").ToString());
                        parametros.Add("@idRfq", IdRfq);

                        RfqConcepto concepto = new RfqConcepto();
                        concepto.SeleccionarDatos("numero_parte=@numeroParte and rfq=@idRfq"); //idConcepto
                        concepto.BorrarDatos();
                        concepto.GuardarDatos();*/

                        RelacionMaterialRfq relacion = new RelacionMaterialRfq();
                        relacion.BorrarRelacion(f.Celda("numero_parte").ToString(),IdRfq, f.Celda<int>("id_concepto"));
                        relacion.GuardarDatos();
                    });

                    RfqConcepto.Modelo().BorrarPartidaRfq(row.Cells["numero_parte"].Value.ToString(), IdRfq);
                }
                MostrarPartidas(IdRfq);
            }
        }

        private void DgvConceptos_SelectionChanged(object sender, EventArgs e)
        {
            BtnQuitarMaterial.Enabled = !RfqEnviado && (DgvConceptos.SelectedRows.Count > 0 && DgvConceptos.SelectedRows[0].Cells.Count > 0);
        }

        private void capturarCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvConceptos.SelectedRows.Count == 0)
                return;

            int IdConcepto = Convert.ToInt32(DgvConceptos.SelectedRows[0].Cells[0].Value);

            RfqConcepto Concepto = new RfqConcepto();
            Concepto.CargarDatos(IdConcepto);

            FrmCapturarCotizacionMaterial capturar = new FrmCapturarCotizacionMaterial(IdConcepto);
            capturar.PrecioUnitario = Convert.ToDecimal(Concepto.Fila().Celda("precio_unitario"));
            capturar.TiempoEntrega = Convert.ToInt32(Concepto.Fila().Celda("tiempo_entrega"));

            if (capturar.ShowDialog() == DialogResult.OK)
            {
                RfqConcepto modificarConcepto = new RfqConcepto();
                modificarConcepto.SeleccionarMaterialesDeRFQ(IdRfq, DgvConceptos.SelectedRows[0].Cells["numero_parte"].Value.ToString()).ForEach(delegate(Fila f)
                {
                    f.ModificarCelda("precio_unitario", capturar.PrecioUnitario);
                    f.ModificarCelda("tiempo_entrega", capturar.TiempoEntrega);
                    f.ModificarCelda("moneda", capturar.Moneda);
                    f.ModificarCelda("cantidad_disponible", capturar.CantidadDisponible);
                    f.ModificarCelda("fecha_cotizacion", DateTime.Today);
                });

                modificarConcepto.GuardarDatos();

                /*MaterialProyecto material = new MaterialProyecto();
                material.CargarDatos(IdRfq);

                if (material.TieneFilas())
                {
                    material.Fila().ModificarCelda("precio_unitario", capturar.PrecioUnitario);
                    int cantidad = Convert.ToInt32(material.Fila().Celda("total"));
                    material.Fila().ModificarCelda("precio_suma_final", (cantidad * capturar.PrecioUnitario));
                    material.GuardarDatos();
                }*/

                MostrarPartidas(IdRfq);
                MostrarCosto(IdRfq);
            }
        }

        private void OpcionesRfqEnviado_Opening(object sender, CancelEventArgs e)
        {
            // Toolstrip después de enviar
            capturarCotizaciónToolStripMenuItem.Visible = (EstatusRfqPo.RfqEstatus && DgvConceptos.Rows.Count > 0); 
            seleccionarCotizacionToolStripMenuItem.Visible = (EstatusRfqPo.RfqEstatus && DgvConceptos.Rows.Count > 0);
            
            // Toolstrip antes de enviar
            modificarCantidadToolStripMenuItem.Visible = (!EstatusRfqPo.RfqEstatus && DgvConceptos.SelectedRows.Count > 0);
        }

        private void modificarCantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool requiereDefinicion = false;
            if (DgvConceptos.SelectedRows.Count > 0)
            {
                int idConcepto = Convert.ToInt32(DgvConceptos.SelectedRows[0].Cells[0].Value);
                RfqConcepto concepto = new RfqConcepto();
                concepto.CargarDatos(idConcepto);

                int cantidadActual = Convert.ToInt32(concepto.Fila().Celda("cantidad_estimada"));
                FrmCantidadMaterial cant = new FrmCantidadMaterial(cantidadActual);
                if (cant.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //resta
                    int count = 0;

                    RelacionMaterialRfq relaciones = new RelacionMaterialRfq();
                    relaciones.SeleccionarIdRequisiciones(DgvConceptos.SelectedRows[0].Cells["numero_parte"].Value.ToString(), IdRfq).ForEach(delegate(Fila f)
                    {
                        RfqConcepto modificarConcepto = new RfqConcepto();
                        modificarConcepto.CargarDatos(f.Celda<int>("id_concepto"));

                        MaterialProyecto material = new MaterialProyecto();
                        material.CargarDatos(f.Celda<int>("id_material_proyecto"));

                        if (material.TieneFilas())
                        {
                            if (count == 0)
                            {
                                material.Fila().ModificarCelda("piezas_requeridas", cant.Piezas);
                                material.Fila().ModificarCelda("total", cant.Piezas);
                                modificarConcepto.Fila().ModificarCelda("cantidad_estimada", cant.Piezas);
                                modificarConcepto.GuardarDatos();
                            }
                            else
                            {
                                material.Fila().ModificarCelda("piezas_requeridas", 0);
                                material.Fila().ModificarCelda("total", 0);
                                modificarConcepto.Fila().ModificarCelda("cantidad_estimada", 0);
                                modificarConcepto.GuardarDatos();
                            }

                            material.Fila().ModificarCelda("estatus_seleccion", "PRELIMINAR");
                            material.GuardarDatos();

                            Usuario usuario = new Usuario();
                            usuario.BuscarPorNombre(material.Fila().Celda("requisitor").ToString());
                            if (usuario.TieneFilas())
                            {
                                requiereDefinicion = true;

                                Evento.Modelo().Crear
                                (
                                    "Cantidad modificada",
                                     Global.UsuarioActual.NombreCompleto() + " modificó las piezas requeridas del proyecto " + material.Fila().Celda("proyecto").ToString() + " del número de parte " + DgvConceptos.SelectedRows[0].Cells["numero_parte"].Value.ToString() + ". Requiere definición.",
                                    usuario.Fila().Celda("rol").ToString()
                                );
                            }
                        }
                        count++;
                    });
                }

                MostrarPartidas(IdRfq);
                if (requiereDefinicion)
                    MessageBox.Show("Se requiere que el usuario defina nuevamente la requisición");

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void BtnAsignarConceptos_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProveedorMultiplesRequisiciones nuevo = new FrmSeleccionarProveedorMultiplesRequisiciones(IdRfq, StrProveedorSeleccionado);
            if(nuevo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarPartidas(IdRfq);
            }
        }

        private void seleccionarCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvConceptos.SelectedRows.Count <= 0) return;

            // obtiene datos de la cotizacion seleccionada
            int idRfqConcepto = Convert.ToInt32(DgvConceptos.SelectedRows[0].Cells["id_concepto"].Value);
            string numeroParte = DgvConceptos.SelectedRows[0].Cells["numero_parte"].Value.ToString();
            RfqConcepto concepto = new RfqConcepto();
            concepto.CargarDatos(idRfqConcepto);

            decimal precioUnitario = 0;
            if(concepto.TieneFilas())
                precioUnitario = Convert.ToDecimal(concepto.Fila().Celda("precio_unitario"));

            // la cotizacion debe estar capturada, si no lo esta avisa al usuario y aborta
            if(precioUnitario <= 0)
            {
                DialogResult resp =
                    MessageBox.Show("Esta cotización no ha sido capturada, ¿quieres capturarla ahora?", 
                                    "Cotización sin capturar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == System.Windows.Forms.DialogResult.Yes)
                    capturarCotizaciónToolStripMenuItem_Click(sender, e);
                return;
            }

            // buscar requisiciones en proceso de cotizacion
            MaterialProyecto requisicionesEnCotizacion = new MaterialProyecto();
            requisicionesEnCotizacion.RequisicionesSinProveedorSeleccionado(numeroParte);

            // Si no se encuentran requisiciones disponibles para vincularse con la cotizacion seleccionada, alerta al usuario
            // en caso contrario muestra el form para seleccionar cotizacion para requisicion
            if(requisicionesEnCotizacion.Filas().Count == 0)
            {
                MessageBox.Show("No se encontraron requisiciones de compra sin proveedor seleccionado con el número de parte " + numeroParte + ".",
                                "Imposible seleccionar cotización.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmSeleccionarProveedorParaPieza frmSelec = new FrmSeleccionarProveedorParaPieza(requisicionesEnCotizacion, idRfqConcepto, 0);
                
                if(frmSelec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MostrarPartidas(IdRfq);
                }
            }
        }

        private void audiselBotonSalida1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void desvincularCotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //obtenemos los rfq conceptos que corresponde a ese numero de parte de ese rfq
            RfqConcepto conceptos = new RfqConcepto();
            conceptos.SeleccionarMaterialesDeRFQ(IdRfq, DgvConceptos.SelectedRows[0].Cells["numero_parte"].Value.ToString());
            
            if(conceptos.TieneFilas())
            {
                string strIdConceptos = string.Empty;
                conceptos.Filas().ForEach(delegate(Fila f)
                {
                    strIdConceptos += f.Celda("id") + ",";
                });

                strIdConceptos = "(" + strIdConceptos.Remove(strIdConceptos.Length -1) + ")";

                //obtenemos los materiales que corresponden con los rfq_conceptos de la partida seleccionada
                //puede ser 1 rfq_concepto en una partida hasta n
                MaterialProyecto material = new MaterialProyecto();
                material.SeleccionarDatos("rfq_concepto IN " + strIdConceptos, null);

                if(material.TieneFilas())
                {
                    FrmDesvincularProveedorFavorito desvincular = new FrmDesvincularProveedorFavorito(material, StrProveedorSeleccionado);
                    if(desvincular.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        MostrarPartidas(IdRfq);
                }
                else
                {
                    MessageBox.Show("No existen requisiciones vinculadas", "Desvincular requisiciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void radioNumPart_CheckedChanged(object sender, EventArgs e)
        {
            MostrarCosto(IdRfq);
        }

        private void radioMxn_CheckedChanged(object sender, EventArgs e)
        {
            MostrarCosto(IdRfq);
        }

        private void radioUsd_CheckedChanged(object sender, EventArgs e)
        {
            MostrarCosto(IdRfq);
        }
        
        private void desglosarCostorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarDesgloseDeCostosToolStripMenuItem.Visible = true;
            desglosarCostorToolStripMenuItem.Visible = false;
            panelCostos.Visible = true;
            DgvConceptos.Dock = DockStyle.Top;            
        }

        private void ocultarDesgloseDeCostosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desglosarCostorToolStripMenuItem.Visible = true;
            ocultarDesgloseDeCostosToolStripMenuItem.Visible = false;
            panelCostos.Visible = false;
            DgvConceptos.Dock = DockStyle.Fill;            
        }

        private void vincularRequisicionesARFQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvConceptos.SelectedRows.Count > 0)
            {      
                string num_parte = Convert.ToString(DgvConceptos.SelectedRows[0].Cells[2].Value);

                FrmVincularRequisicionesRfq frmVincularReqaRfq = new FrmVincularRequisicionesRfq();
                frmVincularReqaRfq.MostrarVincularRquisicionRfq(num_parte);
                frmVincularReqaRfq.ShowDialog();
            }            
        }
    }
}
