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
    public partial class FrmMonitorCompras2 : Form
    {
        MaterialProyecto BuscadorMaterial = new MaterialProyecto();
        BindingSource TiposCompraSource = new BindingSource();
        FrmAgregarRfq AgregarRfq = null;
        FrmAgregarPo agregarPo = null;
        bool PuedeCargarRequisiciones = false;
        bool IgnorarFiltros = false;
        bool CargarTipos = true;
        bool CargarEstatusRfq = true;
        bool CargarEstatusPo = true;
        Form Contenido = null;

        public FrmAgregarPo AgregarPo
        {
            get { return agregarPo; }
            set
            { 
                agregarPo = value;
                panel1.Visible = (value == null);   
            }
        }

        private void FrmMonitorCompras2_Load(object sender, EventArgs e)
        {
            CargarNodosIniciales();
        }

        private void CargarNodosIniciales()
        {
            IgnorarFiltros = false;
            PuedeCargarRequisiciones = false;
            TvMetas.Nodes.Clear();
            CargarTipoCompra();
            CmbTipoRfq.SelectedIndex = 0;
            CmbTipoPo.SelectedIndex = 0;
        }

        public FrmMonitorCompras2(List<Filtro> filtros = null)
        {
            InitializeComponent();

            if (filtros != null)
                BuscadorMaterial.Filtros = filtros;
            else
            {
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_compra", "Estatus compra", BuscadorMaterial.EstatusCompra()));
                BuscadorMaterial.Filtros[0].DesactivarTodos();
                BuscadorMaterial.Filtros[0].ModificarFiltro("EN COTIZACION", true);
                BuscadorMaterial.Filtros[0].ModificarFiltro("EN PLANIFICACION", true);
                BuscadorMaterial.Filtros[0].ModificarFiltro("EN REVISION FINANCIERA", true);
                BuscadorMaterial.Filtros[0].ModificarFiltro("EN REVISION TECNICA", true);
                BuscadorMaterial.Filtros[0].ModificarFiltro("LISTO PARA ORDENAR", true);
                BuscadorMaterial.Filtros[0].ModificarFiltro("PENDIENTE", true); 
                BuscadorMaterial.Filtros[0].ModificarFiltro("COMPRA DETENIDA", true);
                BuscadorMaterial.Filtros[0].ModificarFiltro("COMPRA RECHAZADA", true);

                BuscadorMaterial.Filtros.Add(new Filtro("estatus_seleccion", "Estatus selección", BuscadorMaterial.EstatusSeleccion()));
                BuscadorMaterial.Filtros[1].DesactivarTodos();
                BuscadorMaterial.Filtros[1].ModificarFiltro("DEFINIDO", true);
                BuscadorMaterial.Filtros[1].ModificarFiltro("PRELIMINAR", true);

                BuscadorMaterial.Filtros.Add(new Filtro("estatus_autorizacion", "Estatus autorización", BuscadorMaterial.EstatusAutorizacion()));
                BuscadorMaterial.Filtros[2].DesactivarTodos();
                BuscadorMaterial.Filtros[2].ModificarFiltro("AUTORIZADO", true);
                BuscadorMaterial.Filtros[2].ModificarFiltro("PENDIENTE", true);
                BuscadorMaterial.Filtros[2].ModificarFiltro("N/A", true);

                BuscadorMaterial.Filtros.Add(new Filtro("estatus_almacen", "Estatus almacén", BuscadorMaterial.EstatusAlmacen()));
                BuscadorMaterial.Filtros[3].DesactivarTodos();
                BuscadorMaterial.Filtros[3].ModificarFiltro("N/A", true);
                BuscadorMaterial.Filtros.Add(new Filtro("requisitor", "Requisitor", BuscadorMaterial.Requisitores()));
                BuscadorMaterial.Filtros.Add(new Filtro("proyecto", "Proyecto", BuscadorMaterial.Proyectos()));
                BuscadorMaterial.Filtros.Add(new Filtro("fabricante", "Fabricante", BuscadorMaterial.Fabricantes()));
            }
        }

        private void CargarTipoCompra()
        {
            TiposCompraSource.Clear();
            
            ComprasTipos tipo = new ComprasTipos();
            tipo.SeleccionarTiposMaterial().ForEach(delegate(Fila f)
            {
                TiposCompraSource.Add(new {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id").ToString()
                });
            });

            CmbTipoCompra.DataSource = TiposCompraSource;
            CmbTipoCompra.DisplayMember = "Text";
            CmbTipoCompra.ValueMember = "Value";

            CmbTipoCompra.SelectedIndex = -1;
            PuedeCargarRequisiciones = true;

            if (TiposCompraSource.Count > 0)
            { 
                CmbTipoCompra.SelectedIndex = 0;
            }
        }

        private void CargarRequisicionesDeTipo()
        {
            IgnorarFiltros = false;
            if(!PuedeCargarRequisiciones)
            {
                return;
            }
            TvMetas.Nodes.Clear();
            ComprasTipos tipo = new ComprasTipos();
            tipo.SeleccionarTipoDeCompra(CmbTipoCompra.Text);

            if (!tipo.TieneFilas())
                return;

            MaterialProyecto material = new MaterialProyecto();
            if (CkbAgrupar.Checked)
            {
                //Ordenar por fabricante
                BuscadorMaterial.SeleccionarMaterialPorTipoCompra(tipo.Fila().Celda<int>("id")).ForEach(delegate(Fila f)
                {
                    CrearNodoNumeroParte(f, false);
                });
            }
            else
            {
                //ordenar por numero de parte
                BuscadorMaterial.SeleccionarMaterialPorTipoCompraYNumeroDeParte(tipo.Fila().Celda<int>("id")).ForEach(delegate(Fila f)
                {
                    CrearNodoNumeroParte(f, false);
                });
            }
        }
    
        private void RefrescarNodoMaterial(TreeNode nodoPadre)
        {
            try 
            {
                string[] nombreDividido = nodoPadre.Name.ToString().Split(new char[] { '-' }, 2);

                switch (nombreDividido[0].ToString())
                {   
                    case "raiz":
                        CargarRequisicionesDeTipo();
                        break;
                    case "meta":
                       // CargarInformacionParaMeta(nodoPadre, Convert.ToInt32(nombreDividido[1]));
                        break;
                    case "modulo":
                        /*TreeNode nodoMeta = nodoPadre.Parent;
                        string[] nombreMetaDividido = nodoMeta.Name.ToString().Split('-');
                        CrearMaterialesParaModulo(Convert.ToInt32(nombreMetaDividido[1]), nodoPadre);*/
                        break;
                    case "requisicion":
                        new FrmDetallesMaterialProyecto(Convert.ToInt32(nombreDividido[1])).ShowDialog();
                        break;
                    case "numeroParte":
                        CargarRequisicionesPorNumeroParte(nodoPadre, nodoPadre.Text.ToString().Split('|')[0].TrimEnd().ToString());
                        break;
                    case "fabricante":
                        crearNododeNumeroParteParaFabricante(nodoPadre, nombreDividido[1].ToString());
                        break;
                    default:
                        break;
                }
            }
            catch{}
        }

        #region CargarTipos

        private void CmbTipoCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CargarTipos)
                CargarRequisicionesDeTipo();
        }

        private void RefrescarNodosAbiertos(TreeNodeCollection coleccionNodos)
        {
            foreach (TreeNode nodoActual in coleccionNodos)            
                RefrescarNodoMaterial(nodoActual); 
        }
        #endregion /CargarTipos

        #region Fabricante
        private void CrearNodoFabricante(Fila filaMaterial, bool organizarPorProyecto = false)
        {
            string tooltip = string.Empty;
            string nodoTexto = string.Empty;
            TreeNode fabricanteTemp = Global.CrearNodo(
                    "fabricante-" + filaMaterial.Celda<string>("fabricante"),
                    filaMaterial.Celda<string>("fabricante").ToUpper(),
                    1
                );
            MaterialProyecto mat = new MaterialProyecto();
            mat.SeleccionarProveedorMaterialRequisitadoEnFechaActual(filaMaterial.Celda("fabricante").ToString());
                    
            if (mat.TieneFilas() && mat.Fila().Celda<int>("total") > 0)
                fabricanteTemp.BackColor = Color.Yellow;

            TvMetas.Nodes.Add(fabricanteTemp);    
        }

        private void crearNododeNumeroParteParaFabricante(TreeNode nodoPadre, string fabricante)
        {
            string a = string.Empty;
            if (fabricante == "LOCAL")
                a = "b";

            nodoPadre.Nodes.Clear();

            ComprasTipos tipoCompras = new ComprasTipos();
            tipoCompras.SeleccionarTipoDeCompra(CmbTipoCompra.Text);

            if (tipoCompras.TieneFilas())
            { 
                BuscadorMaterial.SeleccionarRequisicionesDeNumeroParteParaFabricante(tipoCompras.Fila().Celda<int>("id"), fabricante).ForEach(delegate(Fila f)
                {
                    TreeNode numeroParteTemp = Global.CrearNodo(
                            "numeroParte-" + f.Celda("numero_parte").ToString(),
                            f.Celda("numero_parte").ToString().ToUpper() + " | " + f.Celda("total_piezas_requeridas").ToString() + " PIEZAS",
                            1
                        );

                    MaterialProyecto mat = new MaterialProyecto();
                    mat.SeleccionarMaterialRequisitadoEnFechaActual(f.Celda("numero_parte").ToString(), f.Celda("fabricante").ToString());
                    if (mat.TieneFilas() && mat.Fila().Celda<int>("total") > 0)
                        numeroParteTemp.BackColor = Color.Yellow;

                    nodoPadre.Nodes.Add(numeroParteTemp);
                });
                nodoPadre.Expand();
            }
        }

        
#endregion 

        #region CargaMetas

        private void CrearNodoNumeroParte(Fila filaMaterial, bool organizarPorProyecto = false)
        {
            if (!CkbAgrupar.Checked)
            {
                //AGRUPAR POR NUMERO DE PARTE
                TreeNode numeroParteTemp = Global.CrearNodo(
                            "numeroParte-" + filaMaterial.Celda("numero_parte").ToString(),
                            filaMaterial.Celda("numero_parte").ToString().ToUpper() + " | " + filaMaterial.Celda("piezas_totales").ToString() + " PIEZAS",
                            1
                        );

                MaterialProyecto mat = new MaterialProyecto();
                mat.SeleccionarMaterialRequisitadoEnFechaActual(filaMaterial.Celda("numero_parte").ToString());
                if (mat.TieneFilas() && mat.Fila().Celda<int>("total") > 0)
                    numeroParteTemp.BackColor = Color.Yellow;

                TvMetas.Nodes.Add(numeroParteTemp);               
            }
            else
            {
                CrearNodoFabricante(filaMaterial);
            }            
        }

        private void CargarRequisicionesPorNumeroParte(TreeNode nodoPadre, string numeroParte)
        {
            nodoPadre.Nodes.Clear();

            ComprasTipos tipoCompras = new ComprasTipos();
            tipoCompras.SeleccionarTipoDeCompra(CmbTipoCompra.Text);

            if (tipoCompras.TieneFilas())
            {
                BuscadorMaterial.SeleccionarRequisicionesDeNumeroParte(numeroParte, tipoCompras.Fila().Celda<int>("id"), "", IgnorarFiltros).ForEach(delegate(Fila f)
                {
                    string nodoTexto = "REQ " + f.Celda<int>("id").ToString().PadLeft(6, '0') + " | " + f.Celda<int>("piezas_requeridas").ToString() + " PIEZAS";
                    string tooltip = string.Empty;

                    if(Convert.ToDecimal(f.Celda("proyecto")) > 0)
                    {
                        string[] proyecto = Convert.ToDecimal(f.Celda("proyecto")).ToString("F2").Split('.');
                        tooltip = proyecto[0].PadLeft(3, '0') + "." + proyecto[1] + " - " + f.Celda("requisitor").ToString();
                    }
                    else
                        tooltip = f.Celda("requisitor").ToString();
                    
                    TreeNode nodoTemp = Global.CrearNodo(
                        "requisicion-" + f.Celda<int>("id").ToString(),
                        nodoTexto,
                        EstadoAIndiceDeIcono(f.Celda("estatus_compra").ToString()),
                        MenuRequisicion,
                        tooltip
                        );

                    if (Convert.ToDateTime(f.Celda("fecha_creacion")).Date == DateTime.Now.Date)
                        nodoTemp.BackColor = Color.Yellow;

                    nodoPadre.Nodes.Add(nodoTemp);
                });

                nodoPadre.Expand();
            }
        }

        #endregion /CargaMetas

        #region CargaRFQ

        private void CmbTipoRfq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargarEstatusRfq)
            {
                CargarRFQPorUsuario();
                EstatusRfqPo.RfqEstatus = (CmbTipoRfq.Text == "ENVIADO");
            }
        }

        public void CargarRFQPorUsuario()
        {
            TvRFQs.Nodes.Clear();

            RfqMaterial rfqMaterial = new RfqMaterial();
            rfqMaterial.seleccionarUsuarios(CmbTipoRfq.Text).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemp = Global.CrearNodo("usuario-" + f.Celda("usuario").ToString(),
                    f.Celda("usuario").ToString(),
                    1);
                TvRFQs.Nodes.Add(nodoTemp);
            });
        }

        private void CargarFabricanteRFQ(TreeNode nodoPadre, string usuario, string estatus)
        {
            nodoPadre.Nodes.Clear();
            RfqMaterial rfq = new RfqMaterial();
            rfq.SeleccionarRFQPorUsuarioEstatus(usuario, estatus).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemp = Global.CrearNodo("proveedor-" + f.Celda("nombre_proveedor").ToString().Replace('-','<'),
                    f.Celda("nombre_proveedor").ToString() + " | " + f.Celda<int>("total").ToString() + " RFQ's",
                    1);
                nodoPadre.Nodes.Add(nodoTemp);
            });
        }

        public void CargarRFQsPorEnvio(TreeNode nodoPadre, string estatus, string proveedor, string usuario)
        {
            RfqMaterial rfq = new RfqMaterial();
            
            rfq.SeleccionarTodosLosRfqs(estatus, proveedor.Replace('<','-'), usuario);
            rfq.Filas().ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                                "rfq-" + f.Celda<int>("id").ToString(),
                                f.Celda<int>("id").ToString().PadLeft(4, '0') + " " + f.Celda("nombre_proveedor").ToString(),
                                5
                                );
                nodoPadre.Nodes.Add(nodoTemporal);
            });
        }

        private void RefrescarNodoRfq(TreeNode nodoPadre)
        {
            string[] nombreDividido = nodoPadre.Name.ToString().Split('-');

            switch (nombreDividido[0].ToString())
            {
                case "rfq":
                    bool agrupar = true;
                    if (CkbAgrupar.Checked)
                        agrupar = false;

                    MostrarContenido(new FrmAgregarRfq(this,
                        Convert.ToInt32(TvRFQs.SelectedNode.Name.Split('-')[1]),
                        agrupar
                        ));
                    break;
                case "proveedor":
                    CargarRFQsPorEnvio(nodoPadre, CmbTipoRfq.Text, nombreDividido[1].ToString(), nodoPadre.Parent.Name.Split('-')[1].ToString().Replace('<', '-'));
                    break;
                case "usuario":
                    CargarFabricanteRFQ(nodoPadre, nombreDividido[1].ToString(), CmbTipoRfq.Text);
                    break;
                default:
                    break;
            }
           
            nodoPadre.Expand();
        }

        #endregion /CargaRFQ

        #region CargarPOs
        private void CmbTipoPo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargarEstatusPo)
            {
                CargarPOporUsuario();
                EstatusRfqPo.PoEstatusEnviadoRecibido = (CmbTipoPo.Text == "ENVIADO" || CmbTipoPo.Text == "RECIBIDO PARCIALMENTE" || CmbTipoPo.Text == "RECIBIDO");
            }
        }

        public void CargarPOporUsuario()
        {
            TvPOs.Nodes.Clear();

            PoMaterial poMaterial = new PoMaterial();
            poMaterial.UsuariosEstatusPo(CmbTipoPo.Text).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemp = Global.CrearNodo("usuario-" + f.Celda("usuario").ToString(),
                    f.Celda("usuario").ToString(),
                    1);
                TvPOs.Nodes.Add(nodoTemp);
            });
        }

        private TreeNode CargarProveedorPo(TreeNode nodoPadre, string usuario, string estatus, DateTime fecha)
        {
            nodoPadre.Nodes.Clear();
            TreeNode nodoTemp = null;
            PoMaterial po = new PoMaterial();
            po.SeleccionarPoPorUsuarioEstatus(usuario, estatus, fecha).ForEach(delegate(Fila f)
            {
                nodoTemp = Global.CrearNodo("proveedor-" + f.Celda("nombre_proveedor").ToString().Replace('-','<'),
                    f.Celda("nombre_proveedor").ToString() + " | " + f.Celda("total") + " PO's",
                    1);
                nodoPadre.Nodes.Add(nodoTemp);
            });

            return nodoTemp;
        }

        private TreeNode CargarFechas(TreeNode nodoPadre, string usuario, string estatus)
        {
            nodoPadre.Nodes.Clear();
            TreeNode nodoTemp = null;
            PoMaterial po = new PoMaterial();
            po.SeleccionarPoFechaPorUsuarioPorEstatus(usuario, estatus).ForEach(delegate(Fila f)
            {
                nodoTemp = Global.CrearNodo("fecha-" + f.Celda("fecha_creacion").ToString(),
                    Global.FechaATexto(f.Celda("fecha_creacion"), false),
                    1);
                nodoPadre.Nodes.Add(nodoTemp);
            });
            return nodoTemp;
        }

        public void CargarPoConEstatus(TreeNode nodoPadre, string estatus, string usuario, string proveedor, DateTime fechaCreacion)
        {
            nodoPadre.Nodes.Clear();
            PoMaterial po = new PoMaterial();
            po.SeleccionarEstatus(estatus, usuario, proveedor.Replace('<','-'), fechaCreacion);
            po.Filas().ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                                "po-" + f.Celda<int>("id").ToString(),
                                f.Celda<int>("id").ToString().PadLeft(4, '0') + " | " + f.Celda("nombre_proveedor").ToString(),
                                5
                                );
                nodoPadre.Nodes.Add(nodoTemporal);
            });
        }

        private int EstadoAIndiceDeIcono(string estado)
        {
            switch (estado)
            {
                case "EN COTIZACION":
                    return 2;
                case "PENDIENTE":
                    return 3;
                case "ORDEN ASIGNADA":
                    return 4;
                default:
                    return 5;
            }
        }

        private void RefrescarNodoPo(TreeNode nodoPadre)
        {
            string[] nombreDividido = nodoPadre.Name.ToString().Split('-');

            switch (nombreDividido[0].ToString())
            {
                case "proveedor":
                    CargarPoConEstatus(nodoPadre, CmbTipoPo.Text, nodoPadre.Parent.Parent.Name.Split('-')[1].ToString(), nombreDividido[1].ToString(), Convert.ToDateTime(nodoPadre.Parent.Name.Split('-')[1]));
                    break;
                case "po":

                    EstatusRfqPo.PoEstatusEnviadoRecibido = (CmbTipoPo.Text == "ENVIADO" || CmbTipoPo.Text == "RECIBIDO PARCIALMENTE" || CmbTipoPo.Text == "RECIBIDO");
                    EstatusRfqPo.PoEstatusCancelado = (CmbTipoPo.Text == "CANCELADO");
                    EstatusRfqPo.PoEstatus = CmbTipoPo.Text;

                    MostrarContenido
                    (
                        new FrmAgregarPo(this,
                        Convert.ToInt32(nombreDividido[1]),
                        -1
                    ));
                    
                    break;
                case "usuario":
                    CargarFechas(nodoPadre, nombreDividido[1].ToString(), CmbTipoPo.Text);
                    break;
                case "fecha":
                    CargarProveedorPo(nodoPadre, nodoPadre.Parent.Name.ToString().Split('-')[1], CmbTipoPo.Text, Convert.ToDateTime(nombreDividido[1]));
                    break;
                default:
                    break;
            }

            nodoPadre.Expand();
        }

        #endregion /CargarPOs

        #region EventosTreeView
        private void TvMetas_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodoMaterial(e.Node);
        }

        private void TvRFQs_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodoRfq(e.Node);
        }

        private void TvPOs_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodoPo(e.Node);
        }
        #endregion /EventosTreeView

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarNodosIniciales();
        }

        private void CrearRFQ(int idProveedor, int idReqInicial = -1)
        {
            Fila rfq = new Fila();

            rfq.AgregarCelda("fecha_creacion", DateTime.Now);
            rfq.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
            rfq.AgregarCelda("proveedor", idProveedor);
            rfq.AgregarCelda("contacto", 0);
            rfq.AgregarCelda("estatus", "SIN ENVIAR");

            int idRfq = Convert.ToInt32(RfqMaterial.Modelo().Insertar(rfq).Celda("id"));

            bool agrupar = true;
            if (CkbAgrupar.Checked)
                agrupar = false;

            EstatusRfqPo.RfqEstatus = false;

            FrmAgregarRfq agregarRfq = new FrmAgregarRfq(this, idRfq, agrupar, idReqInicial);
            MostrarContenido(agregarRfq);

            if(TvRFQs.SelectedNode != null)
            { 
                string[] nombreDividido = TvRFQs.SelectedNode.Name.Split('-');
                switch (TvRFQs.SelectedNode.Name.Split('-')[0])
                {
                    case "proveedor":
                        CargarRFQsPorEnvio(TvRFQs.SelectedNode.Parent, CmbTipoRfq.Text, nombreDividido[1].ToString(), TvRFQs.SelectedNode.Parent.Name.Split('-')[1].ToString());
                        break;
                    case "usuario":
                        CargarFabricanteRFQ(TvRFQs.SelectedNode, nombreDividido[1].ToString(), CmbTipoRfq.Text);
                        break;
                }
            }

            if (CmbTipoRfq.SelectedIndex != 0)
                CmbTipoRfq.SelectedIndex = 0;
            else
                CargarRFQPorUsuario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProveedor selProv = new FrmSeleccionarProveedor();
            if (selProv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CrearRFQ(selProv.IdProveedor);
            }  
        }

        public void CerrarContenido()
        {
            if (Contenido != null)
            {
                Contenido.Close();
                if (Contenido is FrmAgregarRfq)
                    AgregarRfq = null;
                if (Contenido is FrmAgregarPo)
                    AgregarPo = null;
            }
        }

        public void MostrarContenido(Form ventana)
        {
            CerrarContenido();

            if(ventana is FrmAgregarRfq)
            {
                AgregarRfq = ventana as FrmAgregarRfq;
            }
            if(ventana is FrmAgregarPo)
            {
                AgregarPo = ventana as FrmAgregarPo;
            }

            Contenido = ventana;
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void TvMetas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (AgregarRfq != null)
            {
                if (e.Node.Name.StartsWith("requisicion") || e.Node.Name.StartsWith("numeroParte"))
                {
                    AgregarRfq.ActivarBotonAgregarMaterial(true);
                }
                else
                    AgregarRfq.ActivarBotonAgregarMaterial(false);
            }
        }
       
        public List<int> CargarPartidas()
        {
            List<int> resultado = new List<int>();
            string[] NombreDividido = TvMetas.SelectedNode.Name.ToString().Split('-');
            if (NombreDividido[0].StartsWith("numeroParte"))
            {
                foreach (TreeNode nodo in TvMetas.SelectedNode.Nodes)
                    resultado.Add(Convert.ToInt32(nodo.Name.Split('-')[1]));
            }
            else
                resultado.Add(Convert.ToInt32(NombreDividido[1]));
                //return (Convert.ToInt32(TvMetas.SelectedNode.Nodes[0].Name.Split('-')[1]));

            return resultado;
        }

        public bool AgruparPartidas()
        {
            string[] NombreDividido = TvMetas.SelectedNode.Name.ToString().Split('-');
            if (NombreDividido[0].StartsWith("numeroParte"))
                return true;

            return false;
        }

        void CrearPO(int idProveedor, int idReqInicial = -1)
        {
            Fila po = new Fila();

            po.AgregarCelda("fecha_creacion", DateTime.Now);
            po.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno"));
            po.AgregarCelda("proveedor", idProveedor);
            po.AgregarCelda("contacto", 0);
            po.AgregarCelda("estatus", "SIN ENVIAR");

            PoMaterial.Modelo().Insertar(po);

            int idPo = Convert.ToInt32(po.Celda("id"));
            int terminoAnterior = 0;
            TerminoPagoProveedor nuevoTermino = new TerminoPagoProveedor();

            //Buscamos si el proveedor tiene terminos por default
            nuevoTermino.CargarDatosPO(0, idProveedor);

            // si tiene terminos por default hacemos una copia con la po generada.
            if (nuevoTermino.TieneFilas())
            {
                TerminoPagoProveedor.Modelo().CargarDatosPO(0, idProveedor).ForEach(delegate(Fila f)
                {
                    Fila agregarTermino = new Fila();
                    agregarTermino.AgregarCelda("po", idPo);
                    agregarTermino.AgregarCelda("proveedor", idProveedor);
                    agregarTermino.AgregarCelda("porcentaje", Convert.ToInt32(f.Celda("porcentaje")));
                    agregarTermino.AgregarCelda("terminos", f.Celda("terminos"));
                    agregarTermino.AgregarCelda("anterior", terminoAnterior);
                    TerminoPagoProveedor.Modelo().Insertar(agregarTermino);
                    terminoAnterior++;
                });
            }

            Proveedor proveedor = new Proveedor();
            proveedor.CargarDatos(idProveedor);

            string nombreProveedor = proveedor.Fila().Celda("nombre").ToString();
            string[] nombreDividido = ("usuario-" + Global.UsuarioActual.NombreCompleto()).Split('-');
            CargarPOporUsuario();

            EstatusRfqPo.PoEstatusCancelado = false;
            EstatusRfqPo.PoEstatusEnviadoRecibido = false;
            EstatusRfqPo.PoEstatus = CmbTipoPo.Text;

            MostrarContenido(new FrmAgregarPo(this, idPo, idReqInicial));
        }

        private void BtnNuevaPo_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProveedor prov = new FrmSeleccionarProveedor();

            if (prov.ShowDialog() == DialogResult.OK)
            {
                CrearPO(prov.IdProveedor);
            }
        }

        private void BtnKpis_Click(object sender, EventArgs e)
        {
            Proceso proceso = new Proceso();
            proceso.SeleccionarNombre("COMPRAS");
            if (proceso.TieneFilas())
            {
                FrmBuscadorKPIs kpis = new FrmBuscadorKPIs(Convert.ToInt32(proceso.Fila().Celda("id")));
                kpis.Show();
            }
        }

        private void BtnMetas_Click(object sender, EventArgs e)
        {
            FrmMetasCompras metas = new FrmMetasCompras();
            if(metas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscarNodoRequisicion(metas.IdRequisicion);                
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas eliminar el RFQ seleccionado?", "Eliminar RFQ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                string[] nombreDividido = TvRFQs.SelectedNode.Name.Split('-');
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@po", Convert.ToInt32(nombreDividido[1]));

                RelacionMaterialRfq relaciones = new RelacionMaterialRfq();
                relaciones.BorrarRelacionesConRFQ(Convert.ToInt32(nombreDividido[1]));

                RfqMaterial rfq = new RfqMaterial();
                rfq.CargarDatos(Convert.ToInt32(nombreDividido[1]));
                rfq.BorrarDatos();
                rfq.GuardarDatos();
                CerrarContenido();

                MessageBox.Show("El rfq " + nombreDividido[1].ToString() + " ha sido eliminado correctamente", "RFQ eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                switch (TvRFQs.SelectedNode.Name.Split('-')[0])
                {
                    case "rfq":
                        CargarFabricanteRFQ(TvRFQs.SelectedNode.Parent.Parent, TvRFQs.SelectedNode.Parent.Parent.Name.Split('-')[1], CmbTipoRfq.Text);
                        break;
                }
            }
        }

        private void CancelarOrdenCompra(bool enviarCorreo)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la PO?", "Cancelar PO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmCancelarPo cancelarPo = new FrmCancelarPo(Convert.ToInt32(TvPOs.SelectedNode.Name.Split('-')[1]));
                if (cancelarPo.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    PoMaterial po = new PoMaterial();
                    po.CancelarPo(Convert.ToInt32(TvPOs.SelectedNode.Name.Split('-')[1]));

                    if (enviarCorreo)
                    {
                        string[] parametros = new string[]
                        {
                            Convert.ToInt32(TvPOs.SelectedNode.Name.Split('-')[1]).ToString(),
                            cancelarPo.Razon,
                            cancelarPo.Correo,
                            Global.UsuarioActual.Fila().Celda("correo").ToString()
                        };

                        BkgEnviarCorreo.RunWorkerAsync(parametros);
                    }                        
                }
            }
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switch (CmbTipoPo.Text)
            {
                case "ENVIADOS":
                    CancelarOrdenCompra(true);
                    break;
                case "SIN ENVIAR":
                    CancelarOrdenCompra(false);
                    break;
                default:
                    break;
            }

            CancelarOrdenCompra(true);
            CargarProveedorPo(
                TvPOs.SelectedNode.Parent.Parent,
                TvPOs.SelectedNode.Parent.Parent.Parent.Name.Split('-')[1],
                CmbTipoPo.Text,
                Convert.ToDateTime(TvPOs.SelectedNode.Parent.Parent.Name.Split('-')[1]));
        }

        private void MenuRFQ_Opening(object sender, CancelEventArgs e)
        {
            crearNuevoToolStripMenuItem.Enabled = true; //(TvRFQs.SelectedNode.Name.StartsWith("proveedor") || TvRFQs.SelectedNode.Name.StartsWith("usuario"));

            bool mostrarOpcionesAdicionales = TvRFQs.SelectedNode != null;
            eliminarToolStripMenuItem.Visible = mostrarOpcionesAdicionales;
            descargarPDFToolStripMenuItem.Visible = mostrarOpcionesAdicionales;
            copiarToolStripMenuItem1.Visible = mostrarOpcionesAdicionales;

            if (TvRFQs.SelectedNode != null)
            {
                eliminarToolStripMenuItem.Enabled = (TvRFQs.SelectedNode.Name.StartsWith("rfq") && CmbTipoRfq.Text != "ENVIADO");
                descargarPDFToolStripMenuItem.Visible = (TvRFQs.SelectedNode.Name.StartsWith("rfq")  && CmbTipoRfq.Text == "SIN ENVIAR");
                copiarToolStripMenuItem1.Visible = (TvRFQs.SelectedNode.Name.StartsWith("rfq"));
            }
        }

        private void MenuPo_Opening(object sender, CancelEventArgs e)
        {
            crearNuevaToolStripMenuItem.Enabled = true; //(TvPOs.SelectedNode.Name.StartsWith("proveedor") || TvPOs.SelectedNode.Name.StartsWith("usuario"));
            eliminarToolStripMenuItem1.Visible = TvPOs.SelectedNode != null;
            
            if(TvPOs.SelectedNode != null)
            {
                eliminarToolStripMenuItem1.Enabled = (TvPOs.SelectedNode.Name.StartsWith("po"));// && !TvPOs.SelectedNode.Parent.Name.Split('-')[1].StartsWith("enviados"));
            }
        }

        private void Tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.TreeView.SelectedNode = e.Node;
        }

        private void TvMetas_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TvMetas.SelectedNode = e.Node;
        }

        private void TvPOs_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            string[] nombreDividido = e.Node.Name.Split('-');

            if(nombreDividido[0] != "fabricante")
                e.Node.Nodes.Clear();
        }

        private void BkgEnviarCorreo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string[] parametros = (string[])e.Argument;
                List<string> copias = new List<string>();
                copias.Add(parametros[3]);
                Global.EnviarCorreo("CANCELACION DE ORDEN DE COMPRA # " + parametros[0], parametros[1], parametros[2], copias);
            }
            catch(Exception ex)
            {
                e.Result = ex;
            }
        }

        private void BkgEnviarCorreo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
                MessageBox.Show("Error al enviar el correo electrónico." + Environment.NewLine + "Error: " + e.Result.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idRfq", Convert.ToInt32(TvRFQs.SelectedNode.Name.Split('-')[1]));
            RelacionMaterialRfq relacionesRFQ = new RelacionMaterialRfq();
            relacionesRFQ.SeleccionarDatos("id_rfq=@idRfq", parametros);
            if(relacionesRFQ.TieneFilas())
                CopiarRFQ(Convert.ToInt32(TvRFQs.SelectedNode.Name.Split('-')[1]));
            else
            {
                MessageBox.Show("La versión de este RFQ es incompatible con el nuevo sistema de compras, no se puede copiar el RFQ");
            }
        }

        public void CopiarRFQ(int idRfqOrigen)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres copiar el RFQ seleccionado a otro RFQ?", "Copiar partidas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == System.Windows.Forms.DialogResult.No)
                return;

            int idRfqDestino = 0;

            FrmSeleccionarProveedor selProv = new FrmSeleccionarProveedor();
            if (selProv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila rfq = new Fila();
                rfq.AgregarCelda("fecha_creacion", DateTime.Now);
                rfq.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno"));
                rfq.AgregarCelda("proveedor", selProv.IdProveedor);
                rfq.AgregarCelda("contacto", 0);
                rfq.AgregarCelda("fecha_envio", DateTime.Now);
                rfq.AgregarCelda("estatus", "SIN ENVIAR");

                rfq = RfqMaterial.Modelo().Insertar(rfq);

                idRfqDestino = Convert.ToInt32(rfq.Celda("id"));

                RfqConcepto.Modelo().SeleccionarRfqAgruparPorNumeroParte(idRfqOrigen).ForEach(delegate(Fila concepto)
                {
                    Fila f = new Fila();
                    f.AgregarCelda("rfq", idRfqDestino);
                    f.AgregarCelda("numero_parte", concepto.Celda("numero_parte"));
                    f.AgregarCelda("fabricante", concepto.Celda("fabricante"));
                    f.AgregarCelda("descripcion", concepto.Celda("descripcion"));
                    f.AgregarCelda("precio_unitario", 0);
                    f.AgregarCelda("tiempo_entrega", 0);
                    f.AgregarCelda("moneda", "");
                    f.AgregarCelda("cantidad_disponible", 0);
                    f.AgregarCelda("cantidad_estimada", concepto.Celda("cantidad_estimada"));
                    f.AgregarCelda("tipo_venta", concepto.Celda("tipo_venta"));

                    RfqConcepto.Modelo().Insertar(f);

                    RelacionMaterialRfq relacionesRfq = new RelacionMaterialRfq();
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@rfqOrigen", idRfqOrigen);
                    parametros.Add("@numeroParte", concepto.Celda("numero_parte"));
                    relacionesRfq.SeleccionarDatos("id_rfq=@rfqOrigen and numero_parte=@numeroParte", parametros);

                    Fila insertarRelacion = new Fila();
                    insertarRelacion.AgregarCelda("numero_parte", concepto.Celda("numero_parte"));
                    insertarRelacion.AgregarCelda("id_rfq", idRfqDestino);
                    insertarRelacion.AgregarCelda("id_material_proyecto", relacionesRfq.Fila().Celda("id_material_proyecto"));
                    insertarRelacion.AgregarCelda("id_concepto", concepto.Celda("id"));
                    RelacionMaterialRfq.Modelo().Insertar(insertarRelacion);

                });

                MessageBox.Show("Se ha copiado el RFQ #" + idRfqOrigen.ToString().PadLeft(4, '0') + " y se ha creado el RFQ #" + idRfqDestino.ToString().ToString().PadLeft(4, '0'));
            }

            BuscadorNodoRfq(idRfqDestino);
        }

        private void descargarPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchivoRfq rfqpdf = new ArchivoRfq();
            rfqpdf.SeleccionarRfq(Convert.ToInt32(TvRFQs.SelectedNode.Name.Split('-')[1]));

            if (rfqpdf.TieneFilas())
            {
                byte[] datos = (byte[])rfqpdf.Fila().Celda("archivo");

                FrmVisorPDF visor = new FrmVisorPDF(datos, "AUD-RFQ-" + Convert.ToInt32(TvRFQs.SelectedNode.Name.Split('-')[1]).ToString());
                visor.ShowDialog();
            }
            else
                MessageBox.Show("El archivo PDF correspondiente a este RFQ no fue encontrado.", "PDF no encontrado");
        }

        private void BtnFiltrarDatos_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos filtrar = new FrmFiltrarDatos(BuscadorMaterial.Filtros);

            if (filtrar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscadorMaterial.Filtros = filtrar.Filtros;
                CargarRequisicionesDeTipo();
            }
        }

        private void CkbAgrupar_CheckedChanged(object sender, EventArgs e)
        {
            ComprasTipos tipos = new ComprasTipos();
            tipos.SeleccionarTipoDeCompra(CmbTipoCompra.Text);
            if(tipos.TieneFilas())
                CargarRequisicionesDeTipo();

        }

        private void proveedorPreferidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idRequisicionSeleccionada = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            MaterialProyecto requisicionSeleccionada = new MaterialProyecto();
            requisicionSeleccionada.CargarDatos(idRequisicionSeleccionada);

            if(requisicionSeleccionada.TieneFilas())
            {
                switch(requisicionSeleccionada.Fila().Celda("estatus_compra").ToString())
                {
                    case "PENDIENTE":
                    case "EN COTIZACION":
                    case "EN REVISION TECNICA":
                    case "COMPRA RECHAZADA":
                    case "COMPRA DETENIDA":

                        FrmSeleccionarProveedorParaPieza proveedorParaPieza = new FrmSeleccionarProveedorParaPieza(requisicionSeleccionada, 0, idRequisicionSeleccionada);
                        if (proveedorParaPieza.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            //no es necesario refrescar el nodo, en caso de requerirlo habilitar las 2 líneas de abajo
                            TreeNode nodoPadre = TvMetas.SelectedNode.Parent;
                            RefrescarNodoMaterial(nodoPadre);
                        }
                        break;

                    default:
                        MessageBox.Show("Esta requisición ya fue procesada en otros departamentos y no puede modificarse, verifique estatus de compra.",
                                        "Imposible modificar requisición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmDetallesMaterialProyecto(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1])).ShowDialog();
        }

        private void BuscarNodoRequisicion(int idReq)
        {
            bool tienePoAsignada = true;
            IgnorarFiltros = true;
            CargarTipos = false;
            TvMetas.Nodes.Clear();
            MaterialProyecto material = new MaterialProyecto();
            Dictionary<string,object> parametros = new Dictionary<string,object>();
            parametros.Add("@idReq", idReq);
            material.SeleccionarDatos("id=@idReq", parametros, "*, piezas_requeridas as piezas_totales");

            if (!material.TieneFilas())
            {
                MessageBox.Show("No se encontró la requisición");
                CargarTipos = true;
                return;
            }

            if(Convert.ToInt32(material.Fila().Celda("po")) > 0)
            {
                FrmDetallesMaterialProyecto detalles = new FrmDetallesMaterialProyecto(idReq);
                detalles.Show();
                CargarTipos = true;
                return;
            }
            else
            {
                tienePoAsignada = false;
            }

            ComprasTipos tipo = new ComprasTipos();
            object nombreTipoCompra = tipo.BuscarTipoCompraPorReq(idReq);

            if (nombreTipoCompra != null)
            {
                CmbTipoCompra.Text = nombreTipoCompra.ToString();
                if (CkbAgrupar.Checked)
                {
                    //Por fabricante
                    TreeNode fabricanteTemp = Global.CrearNodo
                    (
                        "fabricante-" + material.Fila().Celda<string>("fabricante"),
                        material.Fila().Celda<string>("fabricante").ToUpper(),
                        1
                    );

                    TvMetas.Nodes.Add(fabricanteTemp);
                    crearNododeNumeroParteParaFabricante(fabricanteTemp, material.Fila().Celda<string>("fabricante").ToString());
                    TreeNode[] nodoPadre = fabricanteTemp.Nodes.Find("numeroParte-" + material.Fila().Celda("numero_parte").ToString(), false);
                    if (nodoPadre[0].Name != null)
                        RefrescarNodoMaterial(nodoPadre[0]);
                }
                else
                {
                     //ordenar por numero de parte
                     CrearNodoNumeroParte(material.Fila(), false);
                     string nodoKey1 = "numeroParte-" + material.Fila().Celda("numero_parte").ToString();
                     TreeNode[] nodoPadre = TvMetas.Nodes.Find(nodoKey1, false);
                     if (nodoPadre[0].Name != null)
                        RefrescarNodoMaterial(nodoPadre[0]);
                }                   
            }
            CargarTipos = true;
            if(!tienePoAsignada)
            {
                MessageBox.Show("La requisición no tiene PO asignada");
            }
        }

        private void BuscadorNodoRfq(int idRfq)
        {
            IgnorarFiltros = true;
            CargarEstatusRfq = false;
            TvRFQs.Nodes.Clear();
            RfqMaterial rfqMaterial = new RfqMaterial();

            rfqMaterial.CargarDatos(idRfq);
            if(rfqMaterial.TieneFilas())
            {
                string proveedor = string.Empty;
                CmbTipoRfq.Text = rfqMaterial.Fila().Celda("estatus").ToString();

                Proveedor prov = new Proveedor();
                prov.CargarDatos(Convert.ToInt32(rfqMaterial.Fila().Celda("proveedor")));

                if (prov.TieneFilas())
                    proveedor = prov.Fila().Celda("nombre").ToString();

                //Crear nodo raiz
                TreeNode nodoPadreRaiz = Global.CrearNodo
                    (
                        "usuario-" + rfqMaterial.Fila().Celda("usuario").ToString(),
                        rfqMaterial.Fila().Celda("usuario").ToString(),
                        1
                    );

                TvRFQs.Nodes.Add(nodoPadreRaiz);
                nodoPadreRaiz.Expand();
                CargarFabricanteRFQ(nodoPadreRaiz, rfqMaterial.Fila().Celda("usuario").ToString(), rfqMaterial.Fila().Celda("estatus").ToString());
                TreeNode[] nodoPadre = nodoPadreRaiz.Nodes.Find("proveedor-" +proveedor, false);
                RefrescarNodoRfq(nodoPadre[0]);

                TreeNode[] nodoPrincipal = TvRFQs.Nodes.Find("usuario-" + rfqMaterial.Fila().Celda("usuario").ToString(), false);
                nodoPrincipal[0].Expand();

                //Mostrar rfq
                bool agrupar = true;
                if (CkbAgrupar.Checked)
                    agrupar = false;

                EstatusRfqPo.RfqEstatus = (CmbTipoRfq.Text == "ENVIADO");

                MostrarContenido(new FrmAgregarRfq(this,
                        Convert.ToInt32(idRfq),
                        agrupar
                        ));
            }

            CargarEstatusRfq = true;
        }

        private void BuscadorNodoPo(int idPo)
        {
            IgnorarFiltros = true;
            CargarEstatusPo = false;
            TvPOs.Nodes.Clear();
            PoMaterial poMaterial = new PoMaterial();

            poMaterial.CargarDatos(idPo);
            if (poMaterial.TieneFilas())
            {
                string proveedor = string.Empty;
                CmbTipoPo.Text = poMaterial.Fila().Celda("estatus").ToString();

                Proveedor prov = new Proveedor();
                prov.CargarDatos(Convert.ToInt32(poMaterial.Fila().Celda("proveedor")));

                if (prov.TieneFilas())
                    proveedor = prov.Fila().Celda("nombre").ToString();

                //Crear nodo raiz
                TreeNode nodoPadreRaiz = Global.CrearNodo
                    (
                        "usuario-" + poMaterial.Fila().Celda("usuario").ToString(),
                        poMaterial.Fila().Celda("usuario").ToString(),
                        1
                    );

                TvPOs.Nodes.Add(nodoPadreRaiz);
                TreeNode nodoFecha = CargarFechas(nodoPadreRaiz, poMaterial.Fila().Celda("usuario").ToString(), poMaterial.Fila().Celda("estatus").ToString());
                TreeNode nodoProveedor = CargarProveedorPo(nodoFecha, poMaterial.Fila().Celda("usuario").ToString(), poMaterial.Fila().Celda("estatus").ToString(), Convert.ToDateTime(poMaterial.Fila().Celda("fecha_creacion")));
                nodoProveedor.ExpandAll();
                RefrescarNodoPo(nodoProveedor);

                TreeNode[] nodoPrincipal = TvPOs.Nodes.Find("usuario-" + poMaterial.Fila().Celda("usuario").ToString(), false);
                nodoPrincipal[0].ExpandAll(); ;

                //mostrar po
                EstatusRfqPo.PoEstatusEnviadoRecibido = (CmbTipoPo.Text == "ENVIADO" || CmbTipoPo.Text == "RECIBIDO PARCIALMENTE" || CmbTipoPo.Text == "RECIBIDO");
                EstatusRfqPo.PoEstatusCancelado = (CmbTipoPo.Text == "CANCELADO");
                EstatusRfqPo.PoEstatus = CmbTipoPo.Text;

                MostrarContenido
                (
                    new FrmAgregarPo(this,
                    Convert.ToInt32(idPo),
                    -1
                ));
            }

            CargarEstatusPo = true;
        }

        private void BtnBuscarMaterial_Click(object sender, EventArgs e)
        {
            if (MenuBusquedas != null)
                MenuBusquedas.Show(BtnBuscarMaterial, BtnBuscarMaterial.PointToClient(Cursor.Position));
        }

        private void buscarNúmeroDeParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarDocumentoCompras buscador = new FrmBuscarDocumentoCompras(true);
            if (buscador.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch (buscador.Tipo)
                {
                    case "RBRequisicion":
                        BuscarNodoRequisicion(Convert.ToInt32(buscador.IdRequisicion));
                        break;
                    case "RBRfq":
                        BuscadorNodoRfq(buscador.IdRequisicion);
                        break;
                    case "RBPo":
                        BuscadorNodoPo(buscador.IdRequisicion);
                        break;
                    default:
                        break;
                }
            }
        }

        private void buscarDescripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarRequisicionesDeTipo();
        }

        private void cotizarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProveedor selProv = new FrmSeleccionarProveedor();
            if (selProv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RfqMaterial buscadorUltimoRfq = new RfqMaterial();
                buscadorUltimoRfq.SeleccionarUltimoRfqDeProveedor(selProv.IdProveedor);

                if(buscadorUltimoRfq.TieneFilas())
                {
                    MostrarContenido(new FrmAgregarRfq(this,
                        Convert.ToInt32(buscadorUltimoRfq.Fila().Celda("id")),
                        false,
                        Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1])
                        ));
                }
                else
                { 
                    CrearRFQ(selProv.IdProveedor, Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]));
                }
            }  
        }

        private void ordenarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialProyecto materialSeleccionado = new MaterialProyecto();
            materialSeleccionado.CargarDatos(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]));

            if(!materialSeleccionado.TieneFilas())
            {
                return;
            }

            if(materialSeleccionado.Fila().Celda("estatus_compra").ToString() != "LISTO PARA ORDENAR" &&
                Global.ObjetoATexto(materialSeleccionado.Fila().Celda("rfq_concepto"), "null") != "null")
            {
                MessageBox.Show("No fue posible agregar la requisición a una orden.\nEl estatus de la requisición es \"" + materialSeleccionado.Fila().Celda("estatus_compra").ToString() + "\". Verifique que la requisición se encuentre en estatus LISTO PARA ORDENAR.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RfqMaterial rfq = new RfqMaterial();
            rfq.SeleccionarRfqDeMaterial(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]));

            if(MessageBox.Show("Se agregará esta requisición a una PO del proveedor: " + rfq.Fila().Celda("proveedor_nombre").ToString() + "\n¿Desea continuar?", "¡Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            PoMaterial buscadorUltimoPo = new PoMaterial();
            buscadorUltimoPo.SeleccionarUltimaPoDeProveedor(Convert.ToInt32(rfq.Fila().Celda("proveedor")), rfq.Fila().Celda("moneda").ToString());

            if(buscadorUltimoPo.TieneFilas())
            {
                EstatusRfqPo.PoEstatus = CmbTipoPo.Text;
                MostrarContenido(new FrmAgregarPo(this, Convert.ToInt32(buscadorUltimoPo.Fila().Celda("id")),
                Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1])));
            }
            else
            { 
                CrearPO(Convert.ToInt32(rfq.Fila().Celda("proveedor")), Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]));
            }
        }

        private void MenuBusquedas_Opening(object sender, CancelEventArgs e)
        {

        }
    }

    public static class EstatusRfqPo
    {
        public static bool RfqEstatus { get; set; }
        public static bool PoEstatusEnviadoRecibido { get; set; }
        public static bool PoEstatusCancelado { get; set; }

        public static string PoEstatus { get; set; }
    }
}
