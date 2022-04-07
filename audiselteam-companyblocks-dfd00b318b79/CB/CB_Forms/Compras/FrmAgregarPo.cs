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
    public partial class FrmAgregarPo : Form
    {
        FrmMonitorCompras2 FrmCompras = null;
        PoMaterial PoSeleccionado = new PoMaterial();
            
        string Estatus = string.Empty;
        bool PoCancelado = false;
        bool PoEnviado = false;
        int IdReqInicial = -1;
        int IdPo = 0;

        public FrmAgregarPo(FrmMonitorCompras2 frmCompras, int idReqInicial = -1)
        {
            FrmCompras = frmCompras;
            IdReqInicial = idReqInicial;
            InitializeComponent();
        }

        public FrmAgregarPo(FrmMonitorCompras2 frmCompras, int idPo, int idReqInicial)
            : this(frmCompras, idReqInicial)
        {
            IdPo = idPo;
            PoEnviado = EstatusRfqPo.PoEstatusEnviadoRecibido;
            PoCancelado = EstatusRfqPo.PoEstatusCancelado;
            Estatus = EstatusRfqPo.PoEstatus;
        }

        private void FrmAgregarPo_Load(object sender, EventArgs e)
        {
            PoSeleccionado.CargarDatos(IdPo);
            MostrarDetallesPo(IdPo);

            if (PoEnviado || PoCancelado)
            {
                BtnNuevo.Enabled = false;

                panel3.Visible = false;
                BtnNuevo.Visible = false;

                if(PoCancelado)
                {
                    BtnBorrar.Visible = false;
                }
            }
            else
            { 
                if(IdReqInicial > 0)
                { 
                    MaterialProyecto materialSeleccionado = new MaterialProyecto();

                    Dictionary<string, object> parametros = new Dictionary<string,object>();
                    parametros.Add("@po", IdPo);
                    materialSeleccionado.SeleccionarDatos("po = @po", parametros, "id");

                    // Verificar que no existan materiales en la PO antes de agregar el nuevo material
                    bool puedeModificarMoneda = !materialSeleccionado.TieneFilas();
                    materialSeleccionado.CargarDatos(IdReqInicial);
                    
                    if (puedeModificarMoneda)
                    {
                        RfqConcepto concepto = new RfqConcepto();
                        concepto.CargarDatos(materialSeleccionado.Fila().Celda<int>("rfq_concepto"));

                        PoSeleccionado.Fila().ModificarCelda("moneda", concepto.Fila().Celda("moneda").ToString());
                        PoSeleccionado.GuardarDatos();
                    }

                    if (materialSeleccionado.TieneFilas() && materialSeleccionado.Fila().Celda("po").ToString() == "0")
                        AgregarPartidasPorRequisicion(materialSeleccionado.Fila().Celda<int>("rfq_concepto"), IdReqInicial);
                }
            }

            CmbAutorizacion.SelectedIndex = 0;
            CmbMoneda.Enabled = !(DgvPartidasPo.Rows.Count > 0);

           if (PoSeleccionado.TieneFilas())
               CmbMoneda.SelectedItem = PoSeleccionado.Fila().Celda<string>("moneda");


           MostrarPartidas(IdPo);
        }

        private void MostrarDetallesPo(int IdPO)
        {
            int IdProveedor = Convert.ToInt32(PoSeleccionado.Fila().Celda("proveedor"));

            Proveedor prov = new Proveedor();
            prov.CargarDatos(IdProveedor);

            LblPO.Text = "PO #" + PoSeleccionado.Fila().Celda("id").ToString() + " - " + prov.Fila().Celda("nombre").ToString();
            int revision = Convert.ToInt32(PoSeleccionado.Fila().Celda("revision"));


            if (revision > 0)
            {
                LblRevision.Text = "Revisión " + revision.ToString();
                LblRevision.Visible = true;
            }
            else
                LblRevision.Visible = false;
        }

        public void MostrarPartidas(int IdPO)
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvPartidasPo);
            int partida = 1;
            
             DgvPartidasPo.Rows.Clear();

             PoMaterial.Modelo().Conceptos(IdPO, false, PoCancelado).ForEach(delegate(Fila concepto)            
             {
                 DgvPartidasPo.Rows.Add(partida,
                                         concepto.Celda("numero_parte"),
                                         concepto.Celda("fabricante"),
                                         concepto.Celda("descripcion"),
                                         concepto.Celda("texto_cantidad"),
                                         concepto.Celda("texto_precio_unitario"),
                                         concepto.Celda("texto_suma"),
                                         concepto.Celda("texto_tiempo_entrega"));
                 partida++;
             });
            Global.RecuperarFilaSeleccionada(DgvPartidasPo, filaSeleccionada);

            LblEstatus.Text = "Estatus: " + PoSeleccionado.Fila().Celda("estatus").ToString();
            LblFechaCreacion.Text = "Fecha creación: " + Global.FechaATexto(PoSeleccionado.Fila().Celda("fecha_creacion"));
            LblRequisitor.Text = "Requisitor: " + PoSeleccionado.Fila().Celda("usuario").ToString();
        }

        public void ActivarBotonAgregarMaterial(bool activar)
        {
            if (!PoEnviado)
                BtnAgregarMaterial.Enabled = activar;          
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmEnviarPO enviar = new FrmEnviarPO(IdPo);

            if (enviar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FrmCompras.CargarPOporUsuario();
                FrmCompras.CerrarContenido();
            }
        }

        private void BtnQuitarMaterial_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvPartidasPo.SelectedRows)
            {
                MaterialProyecto mat = new MaterialProyecto();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@numero_parte", row.Cells["numero_parte"].Value.ToString());
                parametros.Add("@po", IdPo);
                mat.SeleccionarDatos("numero_parte=@numero_parte AND po=@po", parametros);

                if (mat.Fila().Celda("estatus_compra").ToString() == "RECIBIDO" || mat.Fila().Celda("estatus_compra").ToString() == "ENTREGADO")
                {
                    MessageBox.Show("No puede modificar materiales que ya fueron recibidos o entregados");
                    return;
                }

                mat.Filas().ForEach(delegate(Fila m)
                {
                    m.ModificarCelda("po", 0);
                    m.ModificarCelda("precio_unitario", 0);
                    m.ModificarCelda("tiempo_entrega", 0);
                    m.ModificarCelda("precio_suma_final", 0);
                    m.ModificarCelda("estatus_compra", "LISTO PARA ORDENAR");
                });
                mat.GuardarDatos();
            }

            if (!PoEnviado)
               CargarRfqs();

            MostrarPartidas(IdPo);
            BtnAgregarMaterial.Enabled = false;
            BtnRemoverPartida.Enabled = false;
        }

        private void DgvPartidasPo_SelectionChanged(object sender, EventArgs e)
        {
            BtnRemoverPartida. Enabled = !PoEnviado && (DgvPartidasPo.SelectedRows.Count > 0 && DgvPartidasPo.SelectedRows[0].Cells.Count > 0);
        }

        private void BtnAgregarMaterial_Click(object sender, EventArgs e)
        {
            //int rfq = -1;

            if (TvMaterial.SelectedNode.Name.StartsWith("material"))
            {
                //rfq = Convert.ToInt32(TvMaterial.SelectedNode.Parent.Name.Split('-')[1]);

                string[] nombreDividido = LblPO.Text.Split('-');
                string numeroParte = TvMaterial.SelectedNode.Text.Split('|')[0];

                MaterialProyecto.Modelo().SeleccionarRequisicionesParaPartes(nombreDividido[1].TrimStart().TrimEnd(), numeroParte, CmbMoneda.Text).ForEach(delegate(Fila f)
                {
                    AgregarPartidasPorRequisicion(f.Celda<int>("id_concepto"), f.Celda<int>("id_requisicion"));
                });


                foreach (TreeNode nodo in TvMaterial.SelectedNode.Nodes)
                {
                    AgregarPartidasPorRequisicion(Convert.ToInt32(nodo.Name.Split('-')[2]), Convert.ToInt32(nodo.Name.Split('-')[1]));
                }
            }
            else
            {
                //rfq = Convert.ToInt32(TvMaterial.SelectedNode.Parent.Parent.Name.Split('-')[1]);
                AgregarPartidasPorRequisicion(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split('-')[2]), Convert.ToInt32(TvMaterial.SelectedNode.Name.Split('-')[1]));
            }
            BtnAgregarMaterial.Enabled = false;        
        }

        public void AgregarPartidasPorRequisicion(int idConcepto, int idRequisicion)
        {
            if (MaterialProyecto.Modelo().VerificarEnlaceAPo(idRequisicion))
            {
                MessageBox.Show("La requisición seleccionada ya se encuentra enlazada con una PO", "Requisición enlazada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           

            RfqConcepto concepto = new RfqConcepto();
            concepto.CargarDatos(idConcepto);

            int OrdenDeCompra = Convert.ToInt32(PoSeleccionado.Fila().Celda("id"));
            decimal PrecioUnitario = Convert.ToDecimal(concepto.Fila().Celda("precio_unitario"));
            int TiempoDeEntrega = Convert.ToInt32(concepto.Fila().Celda("tiempo_entrega"));
            string Moneda = concepto.Fila().Celda("moneda").ToString();

            if (Moneda == PoSeleccionado.Fila().Celda("moneda").ToString())
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(idRequisicion);

                int CantidadRequerida = Convert.ToInt32(mat.Fila().Celda("total"));

                mat.Fila().ModificarCelda("po", OrdenDeCompra);
                mat.Fila().ModificarCelda("precio_unitario", PrecioUnitario);
                mat.Fila().ModificarCelda("tiempo_entrega", TiempoDeEntrega);
                mat.Fila().ModificarCelda("precio_suma_final", CantidadRequerida * PrecioUnitario);
                mat.Fila().ModificarCelda("precio_moneda", concepto.Fila().Celda("moneda"));
                mat.Fila().ModificarCelda("estatus_compra", "ORDEN ASIGNADA");
                mat.GuardarDatos();

                if(TvMaterial.SelectedNode != null)
                { 
                    TreeNode nodoPadre = TvMaterial.SelectedNode.Parent;
                    if (TvMaterial.SelectedNode.Name.StartsWith("material"))
                        nodoPadre = TvMaterial.SelectedNode;
                    CargarRequisiciones(nodoPadre, mat.Fila().Celda<string>("numero_parte"));
                }
            }
            else
            {
               
            }

            MostrarPartidas(IdPo);
        }

        private void CargarNumerosDePartePorEstatus(TreeNode nodoPadre, int rfq)
        {
            nodoPadre.Nodes.Clear();

            if (CmbMoneda.Text == "")
                return;

            string[] nombreDividido = LblPO.Text.Split(new char[] {'-'}, 2);
            MaterialProyecto material = new MaterialProyecto();
            material.SeleccionarMaterialCotizadoPorProveedor(nombreDividido[1].TrimStart().TrimEnd(), CmbMoneda.Text, rfq).ForEach(delegate(Fila f)
            {
                nodoPadre.Nodes.Add(
                    Global.CrearNodo(
                        "material-" + f.Celda<string>("numero_parte").Replace('-', '$'),
                         f.Celda<string>("numero_parte") + " | " + f.Celda<string>("nombre_proveedor"),
                        1
                    ));
            });

            nodoPadre.Expand();
        }

        private void CargarRfqs()
        {
            TvMaterial.Nodes.Clear();
            string[] nombreDividido = LblPO.Text.Split(new char[]{'-'}, 2);
            
            RfqMaterial.Modelo().SeleccionarRFQsParaPo(nombreDividido[1].TrimStart().TrimEnd(), CmbMoneda.Text).ForEach(delegate(Fila f)
            {
                TvMaterial.Nodes.Add(
                        Global.CrearNodo(
                            "rfq-" + f.Celda<int>("id").ToString(),
                            "RFQ #" + f.Celda<int>("id").ToString(),
                            1
                        ));
            });
        }

        private void CargarRequisiciones(TreeNode nodoPadre, string numeroParte)
        {
           nodoPadre.Nodes.Clear();

            string[] nombreDividido = LblPO.Text.Split('-');
            numeroParte = numeroParte.Replace('$', '-');

            MaterialProyecto.Modelo().SeleccionarRequisicionesParaPartesPo( nombreDividido[1].TrimStart().TrimEnd(), numeroParte, CmbMoneda.Text).ForEach(delegate(Fila f)
            {
                nodoPadre.Nodes.Add(
                        Global.CrearNodo(
                            "requisicion-" + f.Celda<int>("id_requisicion") + "-" + f.Celda<int>("id_concepto"),
                            "REQ #" + f.Celda<int>("id_requisicion").ToString() + " | " 
                            + Convert.ToDecimal(f.Celda("proyecto")).ToString("F2") + " | " 
                            + f.Celda<string>("requisitor"),
                            2
                        ));
            });

            nodoPadre.Expand();
        }

        private void CargarRequisicionesNoDisponibles(TreeNode nodoPadre, string numeroParte)
        {
            nodoPadre.Nodes.Clear();
            string[] nombreDividido = LblPO.Text.Split('-');
            numeroParte = numeroParte.Replace('$', '-');

            MaterialProyecto.Modelo().SeleccionarRequisicionesNoDisponiblesParaPartes(nombreDividido[1].TrimStart().TrimEnd(), numeroParte).ForEach(delegate(Fila f)
            {
                nodoPadre.Nodes.Add(
                        Global.CrearNodo(
                            "pendienterequisicion-" + f.Celda<int>("id_requisicion") + "-" + f.Celda<int>("id_concepto"),
                            "REQ #" + f.Celda<int>("id_requisicion").ToString() + " | "
                            + Convert.ToDecimal(f.Celda("proyecto")).ToString("F2") + " | "
                            + f.Celda<string>("requisitor"),
                            2
                        ));
            });

            nodoPadre.Expand();
        }

        private void TvMaterial_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] nombreDividido = e.Node.Name.Split('-');
            switch (nombreDividido[0])
            {
                case "material":
                    CargarRequisiciones(e.Node, e.Node.Name.Split('-')[1].ToString());
                    break;
                case "requisicion":
                    AgregarPartidasPorRequisicion(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split('-')[2]), Convert.ToInt32(TvMaterial.SelectedNode.Name.Split('-')[1]));
                    break;

                case "materialpendiente":
                    CargarRequisicionesNoDisponibles(e.Node, e.Node.Name.Split('-')[1].ToString());
                    break;
                case "rfq":
                    CargarNumerosDePartePorEstatus(e.Node, Convert.ToInt32(e.Node.Name.Split('-')[1]));
                    break;
                default:
                    break;
            }
        }

        private void TvMaterial_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool enableBool = (e.Node.Name.StartsWith("requisicion") || e.Node.Name.StartsWith("material")) && !PoEnviado && (CmbAutorizacion.Text == "AUTORIZADO" || CmbAutorizacion.Text == "LISTO PARA ORDENAR");
            BtnAgregarMaterial.Enabled = enableBool;
        }

        private void CmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbMoneda.Text != "")
            {
                PoSeleccionado.Fila().ModificarCelda("moneda", CmbMoneda.Text);
                PoSeleccionado.GuardarDatos();
            }
            CargarRfqs();
        }

        private void desglosarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string numeroParte = DgvPartidasPo.SelectedRows[0].Cells["numero_parte"].Value.ToString();
            bool modoEdicion = ((PoSeleccionado.Fila().Celda<int>("revision") > 0 && Estatus == "SIN ENVIAR") ||  Estatus == "SIN ENVIAR");

            FrmDesglosarPartidaPO desglosar = new FrmDesglosarPartidaPO(numeroParte, IdPo, modoEdicion);
            desglosar.ShowDialog();
            if (!PoEnviado)
                CargarRfqs();
            MostrarPartidas(IdPo);
        }

        private void OpcionesPOSinEnviar_Opening(object sender, CancelEventArgs e)
        {
            //desglosarPartidaToolStripMenuItem.Visible = (!PoEnviado) && (DgvPartidasPo.SelectedRows.Count > 0) && Estatus != "RECIBIDO PARCIALMENTE";
            //desglosarPOToolStripMenuItem.Visible = !(!PoEnviado) && Estatus != "RECIBIDO PARCIALMENTE";
            crearRevisiónToolStripMenuItem.Visible = (PoEnviado) || Estatus == "RECIBIDO PARCIALMENTE";
            verPDFToolStripMenuItem.Visible = (PoEnviado) || Estatus == "RECIBIDO PARCIALMENTE";
            /*desglosarPartidaToolStripMenuItem.Visible = (Estatus != "SIN ENVIAR");
            desglosarPartidaToolStripMenuItem.Enabled = (Estatus != "SIN ENVIAR");*/

        }

        private void desglosarPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] nombreDividido = LblPO.Text.Split('-');
            FrmDesglosarPO desglosarPO = new FrmDesglosarPO(IdPo, nombreDividido[1]);
            desglosarPO.Show();
        }

        private void crearRevisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que deseas crear una revisión de la orden de compra seleccionada?", "Crear revision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == System.Windows.Forms.DialogResult.No)
                return;

            int revisionActual = Convert.ToInt32(PoSeleccionado.Fila().Celda("revision"));
            revisionActual++;

            PoSeleccionado.Fila().ModificarCelda("revision", revisionActual);
            PoSeleccionado.Fila().ModificarCelda("estatus", "SIN ENVIAR");
            PoSeleccionado.GuardarDatos();

            MessageBox.Show("Revisión " + revisionActual.ToString().PadLeft(3,'0') + " creada correctamente!");
            FrmCompras.CargarPOporUsuario();
            Close();
        }

        private void verPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchivoPo popdf = new ArchivoPo();
            popdf.SeleccionarPo(IdPo);

            int archivosEncontrados = popdf.Filas().Count;
            int revision = 0;
            byte[] datos = null;
            string strRevision = "";

            if (archivosEncontrados == 0)
            {
                MessageBox.Show("El archivo PDF correspondiente a esta PO no fue encontrado.", "PDF no encontrado");
            }
            else if (archivosEncontrados > 1)
            {
                FrmSeleccionarRevision rev = new FrmSeleccionarRevision(archivosEncontrados - 1);
                if (rev.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    revision = Convert.ToInt32(rev.RevisionSeleccionada);
                    strRevision = ", REV " + revision.ToString();
                }
                else
                    return;
            }

            string versiones = string.Empty;

            foreach (Fila f in popdf.Filas())
            {
                versiones = f.Celda("revision") + ",";

                if (Convert.ToInt32(f.Celda("revision")) == revision)
                    datos = (byte[])f.Celda("archivo");
            }

            if (datos == null)
            {
                versiones = versiones.Remove(versiones.Length - 1);
                MessageBox.Show("La revisión " + revision + " no fue encontrada en la base de datos, se sugiere consultar las siguientes revisiones (" + versiones + ")");
            }
            else
            {
                FrmVisorPDF visor = new FrmVisorPDF(datos, "AUD-PO-" + IdPo.ToString() + strRevision);
                visor.ShowDialog();
            }
        }

        private void FrmAgregarPo_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmCompras.AgregarPo = null;
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            CancelarOrdenCompra();
        }

        private void CancelarOrdenCompra()
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la PO?", "Cancelar PO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmCancelarPo cancelarPo = new FrmCancelarPo(IdPo);
                if (cancelarPo.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    PoSeleccionado.CancelarPo(IdPo);

                    FrmCompras.CargarPOporUsuario();
                    FrmCompras.CerrarContenido();
                    string[] parametros = new string[] { cancelarPo.Correo, cancelarPo.Razon, Global.UsuarioActual.Fila().Celda("correo").ToString()};
                    BkgEnviarCorreo.RunWorkerAsync(parametros);
                }
            }
        }

        private void BkgEnviarCorreo_DoWork(object sender, DoWorkEventArgs e)
        {
            try 
            { 
                string[] parametros = (string[])e.Argument;
                List<string> copias = new List<string>();
                copias.Add(parametros[2]);
                Global.EnviarCorreo("CANCELACION DE ORDEN DE COMPRA # " + IdPo.ToString(), parametros[1], parametros[0], copias);
                e.Result = parametros[0];
            }
            catch(Exception ex)
            {
                e.Result = null;
            }
        }

        private void BkgEnviarCorreo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
                MessageBox.Show("Error al enviar el correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Correo enviado." + Environment.NewLine + "Razón: " + e.Result.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CmbAutorizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAgregarMaterial.Enabled = false;

            if (CmbAutorizacion.Text == "LISTO PARA ORDENAR")
                CargarRfqs();
            else
                CargarMaterialNoAutorizado();
        }

        private void CargarMaterialNoAutorizado()
        {
            TvMaterial.Nodes.Clear();

            string[] nombreDividido = LblPO.Text.Split('-');
            MaterialProyecto material = new MaterialProyecto();

            material.SeleccionarMaterialNoAutorizadoPorProveedor(nombreDividido[1].TrimStart().TrimEnd(), CmbAutorizacion.Text).ForEach(delegate(Fila f)
            {
                TvMaterial.Nodes.Add(
                         Global.CrearNodo(
                        "materialpendiente-" + f.Celda<string>("numero_parte").Replace('-', '$'),
                        f.Celda<string>("numero_parte") + " | " + f.Celda<string>("nombre_proveedor"),
                        1
                    ));
            });
        }

        private void BtnRemoverPartida_Leave(object sender, EventArgs e)
        {
            BtnRemoverPartida.Enabled = false;
        }

        private void DgvPartidasPo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnRemoverPartida.Enabled = !PoEnviado && (DgvPartidasPo.SelectedRows.Count > 0 && DgvPartidasPo.SelectedRows[0].Cells.Count > 0);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
