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
    public partial class FrmAgregarPartidaPO : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        int IdPO = 0;
        int IdRFQ = 0;
        PoMaterial PO = new PoMaterial();
        RfqMaterial RFQ = new RfqMaterial();

        public FrmAgregarPartidaPO(int IdPO=0, int IdRFQ=0)
        {
            InitializeComponent();
            this.IdPO = IdPO;
            this.IdRFQ = IdRFQ;
        }

        private void FrmAgregarPartidaPO_Load(object sender, EventArgs e)
        {
            if( IdPO > 0 )
            {
                NumPO.Value = Convert.ToDecimal(IdPO);
                NumPO.Enabled = false;
                BtnBuscarPO.Enabled = false;
            }

            if( IdRFQ > 0 )
            {
                NumRFQ.Value = Convert.ToDecimal(IdRFQ);
                NumRFQ.Enabled = false;
                BtnBuscarRFQ.Enabled = false;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres agregar las requisiciones seleccionadas a la orden de compra?", "Agregar partidas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( resp == System.Windows.Forms.DialogResult.Yes )
            {
                AgregarPartidas();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        public void AgregarPartidas()
        {
            int PartidasOmitidas = 0;
            foreach (TreeNode nodoConcepto in TvRequisiciones.Nodes)
            {
                RfqConcepto concepto = new RfqConcepto();
                concepto.CargarDatos(Convert.ToInt32(nodoConcepto.Name));

                int OrdenDeCompra = Convert.ToInt32(PO.Fila().Celda("id"));
                decimal PrecioUnitario = Convert.ToDecimal(concepto.Fila().Celda("precio_unitario"));
                int TiempoDeEntrega = Convert.ToInt32(concepto.Fila().Celda("tiempo_entrega"));
                string Moneda = concepto.Fila().Celda("moneda").ToString();
                
                if (Moneda == PO.Fila().Celda("moneda").ToString())
                {
                    foreach (TreeNode nodoRequisicion in nodoConcepto.Nodes)
                    {
                        if (nodoRequisicion.Checked == true)
                        {
                            int id_requisicion = Convert.ToInt32(nodoRequisicion.Name);

                            MaterialProyecto mat = new MaterialProyecto();
                            mat.CargarDatos(id_requisicion);
                            int CantidadRequerida = Convert.ToInt32(mat.Fila().Celda("total"));

                            mat.Fila().ModificarCelda("po", OrdenDeCompra);
                            mat.Fila().ModificarCelda("precio_unitario", PrecioUnitario);
                            mat.Fila().ModificarCelda("tiempo_entrega", TiempoDeEntrega);
                            mat.Fila().ModificarCelda("precio_suma_final", CantidadRequerida * PrecioUnitario);
                            mat.Fila().ModificarCelda("precio_moneda", concepto.Fila().Celda("moneda"));
                            mat.Fila().ModificarCelda("estatus_compra", "ORDEN ASIGNADA");
                            mat.GuardarDatos();
                        }
                    }
                }
                else if(nodoConcepto.Checked == true)
                    PartidasOmitidas++;
            }
            if (PartidasOmitidas > 0)
                MessageBox.Show("Se han omitido " + PartidasOmitidas + " partidas debido a que la moneda de la cotización no coincide con la de la orden de compra.");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void NumRFQ_ValueChanged(object sender, EventArgs e)
        {
            IdRFQ = Convert.ToInt32(NumRFQ.Value);
            CargarDesgloseRequisiciones(IdRFQ);
            BtnAgregar.Enabled = NumPO.Value > 0 && NumRFQ.Value > 0;
        }

        public void CargarDesgloseRequisiciones(int idRfq)
        {
            TvRequisiciones.Nodes.Clear();
            TxtDetalles.Text = "";

            RFQ.CargarDatos(idRfq);

            if (!RFQ.TieneFilas())
            {
                LblUsuarioRFQ.Text = "EL RFQ NO EXISTE";
                return;
            }
            else 
            {
                if (RFQ.Fila().Celda("estatus").ToString() == "SIN ENVIAR")
                {
                    LblUsuarioRFQ.Text = "EL RFQ NO HA SIDO ENVIADO";
                    return;
                }

                if( PO.TieneFilas() && Convert.ToInt32(RFQ.Fila().Celda("proveedor")) != Convert.ToInt32(PO.Fila().Celda("proveedor")) )
                {
                    LblUsuarioRFQ.Text = "EL RFQ ES DE OTRO PROVEEDOR";
                    return;
                }
            }

            LblUsuarioRFQ.Text = RFQ.Fila().Celda("usuario").ToString();

            RfqConcepto.Modelo().SeleccionarRfq( Convert.ToInt32(RFQ.Fila().Celda("id"))).ForEach(delegate(Fila concepto) 
            {
                int idConcepto = Convert.ToInt32(concepto.Celda("id"));

                string claveNodoPrincipal = idConcepto.ToString();
                string textoNodoPrincipal = concepto.Celda("numero_parte").ToString() + " / " + concepto.Celda("fabricante").ToString();

                TvRequisiciones.Nodes.Add(claveNodoPrincipal, textoNodoPrincipal);
                TvRequisiciones.Nodes[claveNodoPrincipal].Checked = true;

                RfqConcepto.Modelo().DesglosarPorProyecto(idConcepto).ForEach(delegate(Fila requisicion)
                {
                    string claveNodoHijo = requisicion.Celda("id").ToString();
                    string textoNodoHijo = "Req. #" + requisicion.Celda("id").ToString() + " / " + Convert.ToDecimal(requisicion.Celda("proyecto")).ToString("F2") + " / " + requisicion.Celda("requisitor").ToString();

                    TvRequisiciones.Nodes[claveNodoPrincipal].Nodes.Add(claveNodoHijo, textoNodoHijo);

                    if (requisicion.Celda("estatus_seleccion").ToString() != "DEFINIDO" || 
                        requisicion.Celda("estatus_autorizacion").ToString() != "AUTORIZADO" || 
                        requisicion.Celda("estatus_compra").ToString() == "CANCELADO")
                    {
                        TvRequisiciones.Nodes[claveNodoPrincipal].Nodes[claveNodoHijo].ForeColor = Color.Gray;
                    }
                    else
                        TvRequisiciones.Nodes[claveNodoPrincipal].Nodes[claveNodoHijo].Checked = true;

                });
            });

            TvRequisiciones.ExpandAll();
        }

        private void TvRequisiciones_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                RfqConcepto concepto = new RfqConcepto();
                concepto.CargarDatos(Convert.ToInt32(e.Node.Name));

                LblElementoSeleccionado.Text = concepto.Fila().Celda("numero_parte").ToString();
                TxtDetalles.Text = "Fabricante: " + concepto.Fila().Celda("fabricante") + Environment.NewLine;
                TxtDetalles.Text += "Descripción: " + concepto.Fila().Celda("descripcion") + Environment.NewLine;
                TxtDetalles.Text += "Precio unitario: " + String.Format("{0:C}", Convert.ToDecimal(concepto.Fila().Celda("precio_unitario"))) + " " + concepto.Fila().Celda("moneda") + Environment.NewLine;
                TxtDetalles.Text += "Tiempo de entrega: " + concepto.Fila().Celda("tiempo_entrega") + " día(s)" + Environment.NewLine;
            }
            else
            {
                MaterialProyecto requisicion = new MaterialProyecto();
                requisicion.CargarDatos(Convert.ToInt32(e.Node.Name));

                LblElementoSeleccionado.Text = "Req. #" + requisicion.Fila().Celda("id");
                TxtDetalles.Text = "Proyecto: " + Convert.ToDecimal(requisicion.Fila().Celda("proyecto")).ToString("F2") + Environment.NewLine;
                TxtDetalles.Text += "Requisitor: " + requisicion.Fila().Celda("requisitor") + Environment.NewLine;

                string unidades = "";
                if (requisicion.Fila().Celda("tipo_venta").ToString() == "POR PIEZA")
                    unidades = "pieza(s)";
                else
                    unidades = "paquete(s) con " + requisicion.Fila().Celda("piezas_paquete") + " pieza(s) c/u";

                TxtDetalles.Text += "Total: " + requisicion.Fila().Celda("total") + " " + unidades + Environment.NewLine;
                TxtDetalles.Text += "Selección: " + requisicion.Fila().Celda("estatus_seleccion") + Environment.NewLine;
                TxtDetalles.Text += "Autorización: " + requisicion.Fila().Celda("estatus_autorizacion") + Environment.NewLine;
            }
        }

        private void TvRequisiciones_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Parent == null)
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    int idRequisicion = Convert.ToInt32(node.Name);

                    MaterialProyecto mat = new MaterialProyecto();
                    mat.CargarDatos(idRequisicion);

                    bool definido = mat.Fila().Celda("estatus_seleccion").ToString() == "DEFINIDO";
                    bool autorizado = mat.Fila().Celda("estatus_autorizacion").ToString() == "AUTORIZADO";

                    if ( definido && autorizado )
                        node.Checked = e.Node.Checked;
                }
            }
        }

        private void TvRequisiciones_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                int idRequisicion = Convert.ToInt32(e.Node.Name);
                int idConcepto = Convert.ToInt32(e.Node.Parent.Name);

                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(idRequisicion);

                RfqConcepto concepto = new RfqConcepto();
                concepto.CargarDatos(idConcepto);

                bool definido = mat.Fila().Celda("estatus_seleccion").ToString() == "DEFINIDO";
                bool autorizado = mat.Fila().Celda("estatus_autorizacion").ToString() == "AUTORIZADO";
                bool monedaCorrecta = false;

                if(PO.TieneFilas())
                    monedaCorrecta = concepto.Fila().Celda("moneda").ToString() == PO.Fila().Celda("moneda").ToString();

                if ( !definido || !autorizado )
                {
                    MessageBox.Show("No es posible ordenar la requisición #" + idRequisicion + ", verificar estatus de selección y autorización", "No es posible ordenar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

                /*
                if( !monedaCorrecta )
                {
                    MessageBox.Show("No es posible incluir la requisicion #" + idRequisicion + " en esta PO, verificar moneda", "No es posible ordenar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }*/
            }
            else
            {

            }
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesSeleccion.ContextMenuStrip != null)
                BtnOpcionesSeleccion.ContextMenuStrip.Show(BtnOpcionesSeleccion, BtnOpcionesSeleccion.PointToClient(Cursor.Position));
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(TreeNode node in TvRequisiciones.Nodes)
            {
                node.Checked = true;
            }
        }

        private void seleccionarNadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in TvRequisiciones.Nodes)
            {
                node.Checked = false;
            }
        }

        private void NumPO_ValueChanged(object sender, EventArgs e)
        {
            IdPO = Convert.ToInt32(NumPO.Value);
            CargarPO(IdPO);
            BtnAgregar.Enabled = NumPO.Value > 0 && NumRFQ.Value > 0;
        }

        public void CargarPO(int idPo)
        {
            PO.CargarDatos(idPo);
            
            Proveedor prov = new Proveedor();

            if( PO.TieneFilas() )
                prov.CargarDatos(Convert.ToInt32(PO.Fila().Celda("proveedor")));

            int idProveedorPO = 0;
            if(prov.TieneFilas())
                idProveedorPO = Convert.ToInt32(prov.Fila().Celda("id"));

            int idProveedorRFQ = 0;
            if(RFQ.TieneFilas())
                idProveedorRFQ = Convert.ToInt32(RFQ.Fila().Celda("proveedor"));

            if (idProveedorRFQ > 0 && (idProveedorPO != idProveedorRFQ))
            {
                LblProveedorPO.Text = "PO INVALIDA";
                return;
            }
    
            LblProveedorPO.Text = prov.Fila().Celda("nombre").ToString();
        }

        private void BtnBuscarRFQ_Click(object sender, EventArgs e)
        {
            Proveedor proveedorPO = new Proveedor();
            proveedorPO.CargarDatos(Convert.ToInt32(PO.Fila().Celda("proveedor")));

            FrmSeleccionarRFQ selRfq = new FrmSeleccionarRFQ(proveedorPO.Fila().Celda("nombre").ToString(), "ENVIADO");

            if( selRfq.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                NumRFQ.Value = Convert.ToDecimal(selRfq.RfqSeleccionado);
            }
        }

        private void BtnBuscarPO_Click(object sender, EventArgs e)
        {
            Proveedor proveedorPO = new Proveedor();
            proveedorPO.CargarDatos(Convert.ToInt32(RFQ.Fila().Celda("proveedor")));

            FrmSeleccionarPO selPo = new FrmSeleccionarPO(proveedorPO.Fila().Celda("nombre").ToString(), "SIN ENVIAR");

            if (selPo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NumPO.Value = Convert.ToDecimal(selPo.PoSeleccionado);
                CargarDesgloseRequisiciones(IdRFQ);
            }
        }

        private void expandirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TvRequisiciones.ExpandAll();
        }

        private void colapsarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TvRequisiciones.CollapseAll();
        }

        private void LblUsuarioRFQ_Click(object sender, EventArgs e)
        {

        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    }
}