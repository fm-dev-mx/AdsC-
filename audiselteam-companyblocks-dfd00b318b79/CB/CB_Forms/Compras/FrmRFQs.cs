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
    public partial class FrmRFQs : Form
    {
        int IdRfq;
        List<Filtro> Filtros = new List<Filtro>(); 

        public FrmRFQs(List<Filtro> filtros = null)
        {
            InitializeComponent();

            if (filtros != null)
                Filtros = filtros;
        }

        private void FrmRFQs_Load(object sender, EventArgs e)
        {
            CmbFiltroEstatus.Text = "SIN ENVIAR";

            CargarUsuarios();
            CmbUsuario.Text = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");

            CargarProveedores();
            CmbProveedor.Text = "TODOS";
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRFQs_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMonitorCompras monitor = new FrmMonitorCompras(Filtros);
            monitor.MdiParent = this.MdiParent;
            monitor.Show();
        }

        public void CargarRFQs(string estatus, string proveedor="TODOS", string usuario="TODOS", int limite=0)
        {
            RfqMaterial rfq = new RfqMaterial();

            string filtroEstatus = "estatus=@estatus";

            string filtroProveedor = "";
            if (proveedor != "TODOS")
                filtroProveedor = " AND proveedores.nombre=@proveedor";
            

            string filtroUsuario = "";
            if(usuario!="TODOS")
                filtroUsuario = " AND usuario=@usuario";
           
            string filtroLimite = "";
            if(limite>0)
                filtroLimite = " LIMIT @limite";
           
            DgvRFQs.Rows.Clear();

            string sql = "SELECT rfq_material.*, proveedores.nombre AS nombre_proveedor FROM rfq_material ";
            sql += " INNER JOIN proveedores ON rfq_material.proveedor=proveedores.id";
            sql += " WHERE " + filtroEstatus + filtroProveedor + filtroUsuario + " ORDER BY id DESC" + filtroLimite;

            rfq.ConstruirQuery(sql);
            rfq.AgregarParametro("@estatus", estatus);
            rfq.AgregarParametro("@proveedor", proveedor);
            rfq.AgregarParametro("@usuario", usuario);
            rfq.AgregarParametro("@limite", limite);
            rfq.EjecutarQuery();
       
            rfq.LeerFilas().ForEach(delegate(Fila f)
            {
                DgvRFQs.Rows.Add(f.Celda("id"), f.Celda("nombre_proveedor"), f.Celda("usuario"), Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMM dd yyyy, hh:mm tt"));
            });
        }

        public void CargarProveedores()
        {
            CmbProveedor.Items.Clear();
            CmbProveedor.Items.Add("TODOS");

            RfqMaterial.Modelo().Proveedores().ForEach(delegate(Fila f)
            {
                CmbProveedor.Items.Add(f.Celda("proveedor_nombre"));
            });
        }

        public void CargarUsuarios()
        {
            CmbUsuario.Items.Clear();
            CmbUsuario.Items.Add("TODOS");

            RfqMaterial.Modelo().Usuarios().ForEach(delegate(Fila f)
            {
                CmbUsuario.Items.Add(f.Celda("usuario"));
            });
        }

        private void CmbFiltroEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(CmbFiltroEstatus.Text)
            {
                case "SIN ENVIAR":
                    BtnOpcionesRfq.ContextMenuStrip = OpcionesRfqSinEnviar;
                    break;

                case "EN LINEA":
                case "ENVIADO":
                    BtnOpcionesRfq.ContextMenuStrip = OpcionesRfqEnviado;
                    break;
            }

            CargarRFQs(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        public void MostrarPartidas(int IdRfq)
        {
            BtnOpcionesRfq.Enabled = true;
            enviarRFQToolStripMenuItem.Enabled = false;

            if (CmbFiltroEstatus.Text == "SIN ENVIAR")
                BtnEliminar.Enabled = true;

            RfqMaterial mat = new RfqMaterial();
            mat.CargarDatos(IdRfq);
            int IdProveedor = Convert.ToInt32(mat.Fila().Celda("proveedor"));

            Proveedor prov = new Proveedor();
            prov.CargarDatos(IdProveedor);

            LblRFQ.Text = "RFQ #" + IdRfq.ToString() + " - " + prov.Fila().Celda("nombre");

            int fila = Global.GuardarFilaSeleccionada(DgvConceptos);

            int partida = 1;
            DgvConceptos.Rows.Clear();
            RfqConcepto.Modelo().SeleccionarRfq(IdRfq).ForEach(delegate(Fila concepto)
            {
                string strPrecioUnitario = "";
                string strTiempoEntrega = "";
                int requisicionesCompra = 0;

                strPrecioUnitario = String.Format("{0:C}", Convert.ToDecimal(concepto.Celda("precio_unitario"))) + " " + concepto.Celda("moneda").ToString();
                requisicionesCompra = Convert.ToInt32(concepto.Celda("requisiciones_compra"));

                if (Convert.ToInt32(concepto.Celda("tiempo_entrega")) == 0)
                    strTiempoEntrega = "?";
                else
                    strTiempoEntrega = concepto.Celda("tiempo_entrega").ToString() + " día(s)";

                DgvConceptos.Rows.Add(concepto.Celda("id"), partida, concepto.Celda("numero_parte"), concepto.Celda("fabricante"), concepto.Celda("descripcion"), concepto.Celda("cantidad_estimada"), concepto.Celda("tipo_venta"), strPrecioUnitario, strTiempoEntrega, concepto.Celda("cantidad_disponible"), requisicionesCompra );

                if(requisicionesCompra > 0 )
                {
                    DataGridViewCell celdaId = DgvConceptos.Rows[DgvConceptos.RowCount - 1].Cells["partida"];
                    celdaId.Style.BackColor = Color.LightYellow;
                }

                partida++;

                enviarRFQToolStripMenuItem.Enabled = true;
            });

            Global.RecuperarFilaSeleccionada(DgvConceptos, fila);
        }

        public void BorrarPartidas()
        {
            BtnOpcionesRfq.Enabled = false;
            BtnEliminar.Enabled = false;
            DgvConceptos.Rows.Clear();
            LblRFQ.Text = "SELECCIONA UN RFQ";
        }

        private void DgvRFQs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( DgvRFQs.SelectedRows.Count > 0 )
            {
                IdRfq = Convert.ToInt32(DgvRFQs.SelectedRows[0].Cells[0].Value);
                MostrarPartidas(IdRfq);
            }
        }

        private void BtnOpcionesRfq_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesRfq.ContextMenuStrip != null)
                BtnOpcionesRfq.ContextMenuStrip.Show(BtnOpcionesRfq, BtnOpcionesRfq.PointToClient(Cursor.Position));
        }

        private void borrarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( DgvConceptos.SelectedRows.Count <= 0 )
                return;

            DialogResult resultado = MessageBox.Show("Seguro que deseas borrar las partidas seleccionadas?", "Borrar partidas", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if( resultado == System.Windows.Forms.DialogResult.Yes )
            {
                foreach(DataGridViewRow row in DgvConceptos.SelectedRows)
                {
                    int idConcepto = Convert.ToInt32(row.Cells[0].Value);
                    RfqConcepto concepto = new RfqConcepto();
                    concepto.CargarDatos(idConcepto);
                    concepto.BorrarDatos();
                }
                MostrarPartidas(IdRfq);
            }
        }

        private void agregarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarPartidaRFQ agregar = new FrmAgregarPartidaRFQ(IdRfq, Filtros);
            
            if( agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                MostrarPartidas(IdRfq);
            }
        }

        private void DgvConceptos_SelectionChanged(object sender, EventArgs e)
        {
            if( DgvConceptos.SelectedRows.Count > 0 )
            {
                borrarPartidaToolStripMenuItem.Enabled = true;
            }
            else
            {
                borrarPartidaToolStripMenuItem.Enabled = false;
            }
        }

        private void enviarRFQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEnviarRFQ enviar = new FrmEnviarRFQ(IdRfq);
           
            if( enviar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                BorrarPartidas();
                CargarRFQs(CmbFiltroEstatus.Text);
            }
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

            if( capturar.ShowDialog() == DialogResult.OK )
            {
                Concepto.Fila().ModificarCelda("precio_unitario", capturar.PrecioUnitario);
                Concepto.Fila().ModificarCelda("tiempo_entrega", capturar.TiempoEntrega);
                Concepto.Fila().ModificarCelda("moneda", capturar.Moneda);
                Concepto.Fila().ModificarCelda("cantidad_disponible", capturar.CantidadDisponible);
                Concepto.GuardarDatos();

                MostrarPartidas(IdRfq);
            }
        }

        private void DgvConceptos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( DgvConceptos.SelectedRows.Count == 0 )
                return;

            string precio = DgvConceptos.SelectedRows[0].Cells[7].Value.ToString();
            string tiempo = DgvConceptos.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProveedor prov = new FrmSeleccionarProveedor();

            if (prov.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila rfq = new Fila();

                rfq.AgregarCelda("fecha_creacion", DateTime.Now);
                rfq.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
                rfq.AgregarCelda("proveedor", prov.IdProveedor);
                rfq.AgregarCelda("contacto", 0);
                rfq.AgregarCelda("estatus", "SIN ENVIAR");

                RfqMaterial.Modelo().Insertar(rfq);

                CargarRFQs(CmbFiltroEstatus.Text);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas eliminar el RFQ seleccionado?", "Eliminar RFQ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@po", IdRfq);

                RfqMaterial rfq = new RfqMaterial();
                rfq.CargarDatos(IdRfq);
                rfq.BorrarDatos();
                BorrarPartidas();
                CargarRFQs(CmbFiltroEstatus.Text);
            }
        }

        private void descargarPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchivoRfq rfqpdf = new ArchivoRfq();
            rfqpdf.SeleccionarRfq(IdRfq);

            if (rfqpdf.TieneFilas())
            {
                byte[] datos = (byte[])rfqpdf.Fila().Celda("archivo");

                FrmVisorPDF visor = new FrmVisorPDF(datos, "AUD-RFQ-" + IdRfq.ToString());
                visor.ShowDialog();
            }
            else
                MessageBox.Show("El archivo PDF correspondiente a este RFQ no fue encontrado.", "PDF no encontrado");
        }

        private void modificarCantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( DgvConceptos.SelectedRows.Count > 0 )
            { 
                int idConcepto = Convert.ToInt32(DgvConceptos.SelectedRows[0].Cells[0].Value);
                RfqConcepto concepto = new RfqConcepto();
                concepto.CargarDatos(idConcepto);

                int cantidadActual = Convert.ToInt32(concepto.Fila().Celda("cantidad_estimada"));

                FrmCantidadMaterial cant = new FrmCantidadMaterial(cantidadActual);

                if (cant.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    concepto.Fila().ModificarCelda("cantidad_estimada", cant.Piezas);
                    concepto.GuardarDatos();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    MostrarPartidas(IdRfq);
                }
            }
        }

        private void DgvRFQs_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvRFQs.SelectedRows.Count > 0)
            {
                IdRfq = Convert.ToInt32(DgvRFQs.SelectedRows[0].Cells[0].Value);
                MostrarPartidas(IdRfq);
            }
        }

        private void incluirEnPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarPartidaPO agregar = new FrmAgregarPartidaPO(0, IdRfq);

            if (agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarPartidas(IdRfq);
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCopiarRFQ copiar = new FrmCopiarRFQ(IdRfq);

            if (copiar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarRFQs(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text);
            }
        }

        private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCopiarRFQ copiar = new FrmCopiarRFQ(IdRfq);

            if (copiar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarRFQs(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text);
            }
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRFQs(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        private void CmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRFQs(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        private void NumLimite_ValueChanged(object sender, EventArgs e)
        {
            CargarRFQs(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        private void OpcionesRfqEnviado_Opening(object sender, CancelEventArgs e)
        {

        }

    }
}
