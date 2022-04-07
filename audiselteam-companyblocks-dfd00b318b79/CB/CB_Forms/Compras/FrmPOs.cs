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
    public partial class FrmPOs : Form
    {
        int IdPO;
        string NumeroDeParte;
        string NombreProveedor;

        public FrmPOs()
        {
            InitializeComponent();
        }

        private void FrmPOs_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMonitorCompras monitor = new FrmMonitorCompras();
            monitor.MdiParent = this.MdiParent;
            monitor.Show();
        }

        public void CargarOrdenes(string estatus, string proveedor = "TODOS", string usuario = "TODOS", int limite = 0)
        {
            PoMaterial po = new PoMaterial();

            string filtroEstatus = "estatus=@estatus";

            string filtroProveedor = "";
            if (proveedor != "TODOS")
                filtroProveedor = " AND proveedores.nombre=@proveedor";


            string filtroUsuario = "";
            if (usuario != "TODOS")
                filtroUsuario = " AND usuario=@usuario";

            string filtroLimite = "";
            if (limite > 0)
                filtroLimite = " LIMIT @limite";

            DgvPOs.Rows.Clear();

            string sql = "SELECT po_material.*, proveedores.nombre AS nombre_proveedor FROM po_material ";
            sql += " INNER JOIN proveedores ON po_material.proveedor=proveedores.id";
            sql += " WHERE " + filtroEstatus + filtroProveedor + filtroUsuario + " ORDER BY id DESC" + filtroLimite;

            po.ConstruirQuery(sql);
            po.AgregarParametro("@estatus", estatus);
            po.AgregarParametro("@proveedor", proveedor);
            po.AgregarParametro("@usuario", usuario);
            po.AgregarParametro("@limite", limite);
            po.EjecutarQuery();

            po.LeerFilas().ForEach(delegate(Fila f)
            {
                DgvPOs.Rows.Add(f.Celda("id"), f.Celda("nombre_proveedor"), f.Celda("usuario"), Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMM dd yyyy, hh:mm tt"));
            });
            OpcionesPoDesglose.Enabled = false;
        }

        public void CargarProveedores()
        {
            CmbProveedor.Items.Clear();
            CmbProveedor.Items.Add("TODOS");

            PoMaterial.Modelo().Proveedores().ForEach(delegate(Fila f)
            {
                CmbProveedor.Items.Add(f.Celda("proveedor_nombre"));
            });
        }

        public void CargarUsuarios()
        {
            CmbUsuario.Items.Clear();
            CmbUsuario.Items.Add("TODOS");

            PoMaterial.Modelo().Usuarios().ForEach(delegate(Fila f)
            {
                CmbUsuario.Items.Add(f.Celda("usuario"));
            });
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbFiltroEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CmbFiltroEstatus.Text)
            {
                case "SIN ENVIAR":
                    BtnOpcionesPO.ContextMenuStrip = OpcionesPOSinEnviar;
                    break;

                case "ENVIADO":
                    BtnOpcionesPO.ContextMenuStrip = OpcionesPOEnviado;
                    break;
            }

            CargarOrdenes(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        private void FrmPOs_Load(object sender, EventArgs e)
        {
            CmbFiltroEstatus.Text = "SIN ENVIAR";

            CargarUsuarios();
            CmbUsuario.Text = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");

            CargarProveedores();
            CmbProveedor.Text = "TODOS";
        }

        public void MostrarPartidas(int IdPO)
        {
            BtnOpcionesPO.Enabled = true;
            CmbMoneda.Enabled = true;
            enviarPOToolStripMenuItem.Enabled = false;

            if(CmbFiltroEstatus.Text == "SIN ENVIAR")
                BtnEliminar.Enabled = true;

            PoMaterial po = new PoMaterial();
            po.CargarDatos(IdPO);

            int IdProveedor = Convert.ToInt32(po.Fila().Celda("proveedor"));

            Proveedor prov = new Proveedor();
            prov.CargarDatos(IdProveedor);

            LblPO.Text = "PO #" + po.Fila().Celda("id").ToString() + " - " + prov.Fila().Celda("nombre").ToString();
            CmbMoneda.Text = po.Fila().Celda("moneda").ToString();
            
            int revision = Convert.ToInt32(po.Fila().Celda("revision"));
            if (revision > 0)
            {
                LblRevision.Text = "Revisión " + revision.ToString();
                LblRevision.Visible = true;
            }
            else
                LblRevision.Visible = false;


            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvPartidas);
            int partida = 1;
            DgvPartidas.Rows.Clear();
            PoMaterial.Modelo().Conceptos(IdPO).ForEach(delegate(Fila concepto)
            {
                DgvPartidas.Rows.Add(partida, 
                                     concepto.Celda("numero_parte"), 
                                     concepto.Celda("fabricante"), 
                                     concepto.Celda("descripcion"), 
                                     concepto.Celda("texto_cantidad"), 
                                     concepto.Celda("texto_precio_unitario"), 
                                     concepto.Celda("texto_suma"), 
                                     concepto.Celda("texto_tiempo_entrega"));
                partida++;
                CmbMoneda.Enabled = false;
                enviarPOToolStripMenuItem.Enabled = true;
            });
            Global.RecuperarFilaSeleccionada(DgvPartidas, filaSeleccionada);

            desglosarPartidaToolStripMenuItem.Enabled = false;
            desglosarPArtidaEnviadaMenuItem1.Enabled = false;
            borrarPartidaToolStripMenuItem.Enabled = false;
        }

        public void BorrarPartidas()
        {
            BtnOpcionesPO.Enabled = false;
            BtnEliminar.Enabled = false;
            DgvPartidas.Rows.Clear();
            LblPO.Text = "SELECCIONA UNA PO";
            LblRevision.Visible = false;
        }

        private void DgvPOs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPOs.SelectedRows.Count > 0)
            {
                IdPO = Convert.ToInt32(DgvPOs.SelectedRows[0].Cells[0].Value);
                NombreProveedor = DgvPOs.SelectedRows[0].Cells["Proveedor"].Value.ToString();
                MostrarPartidas(IdPO);
                OpcionesPoDesglose.Enabled = true;
            }
        }

        private void BtnOpcionesPO_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesPO.ContextMenuStrip != null)
                BtnOpcionesPO.ContextMenuStrip.Show(BtnOpcionesPO, BtnOpcionesPO.PointToClient(Cursor.Position));
        }

        private void agregarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarPartidaPO agregar = new FrmAgregarPartidaPO(IdPO);

            if( agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                MostrarPartidas(IdPO);
            }
        }

        private void desglosarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDesglosarPartidaPO desglosar = new FrmDesglosarPartidaPO(NumeroDeParte, IdPO, false);
            desglosar.ShowDialog();
            MostrarPartidas(IdPO);
        }

        private void DgvPartidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DgvPartidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPartidas.SelectedRows.Count > 0)
            {
                NumeroDeParte = DgvPartidas.SelectedRows[0].Cells["numero_parte"].Value.ToString();
                desglosarPartidaToolStripMenuItem.Enabled = true;
                desglosarPArtidaEnviadaMenuItem1.Enabled = true;
                borrarPartidaToolStripMenuItem.Enabled = true;
                desglosarPOToolStripMenuItem.Enabled = true;
            }
        }

        private void borrarPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas borrar las partidas seleccionadas?", "Borrar partidas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( respuesta == System.Windows.Forms.DialogResult.Yes )
            {
                foreach(DataGridViewRow row in DgvPartidas.SelectedRows)
                {
                    MaterialProyecto mat = new MaterialProyecto();
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@numero_parte", row.Cells["numero_parte"].Value.ToString());
                    parametros.Add("@po", IdPO);
                    mat.SeleccionarDatos("numero_parte=@numero_parte AND po=@po", parametros);

                    mat.Filas().ForEach(delegate(Fila m)
                    {
                        m.ModificarCelda("po", 0);
                        m.ModificarCelda("precio_unitario", 0);
                        m.ModificarCelda("tiempo_entrega", 0);
                        m.ModificarCelda("precio_suma_final", 0);
                        m.ModificarCelda("precio_moneda", "USD");
                        m.ModificarCelda("estatus_compra", "EN COTIZACION");
                    });
                    mat.GuardarDatos();
                }

                MostrarPartidas(IdPO);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas eliminar la PO seleccionada?", "Eliminar PO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( respuesta == System.Windows.Forms.DialogResult.Yes )
            {
                PoMaterial po = new PoMaterial();
                po.CargarDatos(IdPO);
                int revision = Convert.ToInt32( po.Fila().Celda("revision") );

                if( revision > 0 )
                {
                    po.Fila().ModificarCelda("revision", revision-1);
                    po.Fila().ModificarCelda("estatus", "ENVIADO");
                    po.GuardarDatos();
                    MessageBox.Show("Se ha eliminado la revisión " + revision + ".");
                }
                else
                {
                    po.BorrarDatos();

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@po", IdPO);
                    MaterialProyecto mat = new MaterialProyecto();
                    mat.SeleccionarDatos("po=@po", parametros);
                    mat.Filas().ForEach(delegate(Fila m)
                    {
                        m.ModificarCelda("po", 0);
                        m.ModificarCelda("precio_unitario", 0);
                        m.ModificarCelda("tiempo_entrega", 0);
                        m.ModificarCelda("precio_suma_final", 0);
                        m.ModificarCelda("precio_moneda", "USD");
                        m.ModificarCelda("estatus_compra", "EN COTIZACION");
                    });
                    mat.GuardarDatos();
                }
                BorrarPartidas();
                CargarOrdenes(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProveedor prov = new FrmSeleccionarProveedor();

            if (prov.ShowDialog() == DialogResult.OK)
            {
                Fila po = new Fila();

                po.AgregarCelda("fecha_creacion", DateTime.Now);
                po.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno"));
                po.AgregarCelda("proveedor", prov.IdProveedor);
                po.AgregarCelda("contacto", 0);
                po.AgregarCelda("estatus", "SIN ENVIAR");

                PoMaterial.Modelo().Insertar(po);

                int idPo = Convert.ToInt32(po.Celda("id"));
                int terminoAnterior = 0;
                TerminoPagoProveedor nuevoTermino = new TerminoPagoProveedor();

                //Buscamos si el proveedor tiene terminos por default
                nuevoTermino.CargarDatosPO(0, prov.IdProveedor);

                // si tiene terminos por default hacemos una copia con la po generada.
                if(nuevoTermino.TieneFilas())
                {
                    TerminoPagoProveedor.Modelo().CargarDatosPO(0, prov.IdProveedor).ForEach(delegate(Fila f)
                    {
                        Fila agregarTermino = new Fila();
                        agregarTermino.AgregarCelda("po",idPo);
                        agregarTermino.AgregarCelda("proveedor", prov.IdProveedor);
                        agregarTermino.AgregarCelda("porcentaje", Convert.ToInt32(f.Celda("porcentaje")));
                        agregarTermino.AgregarCelda("terminos", f.Celda("terminos"));
                        agregarTermino.AgregarCelda("anterior", terminoAnterior);
                        TerminoPagoProveedor.Modelo().Insertar(agregarTermino);
                        terminoAnterior++;
                    });
                }
                CargarOrdenes(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            }
        }

        private void enviarPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEnviarPO po = new FrmEnviarPO(IdPO);
            
            if( po.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                BorrarPartidas();
                CargarOrdenes(CmbFiltroEstatus.Text);
            }
        }

        private void verPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArchivoPo popdf = new ArchivoPo();
            popdf.SeleccionarPo(IdPO);

            int archivosEncontrados = popdf.Filas().Count;
            int revision = 0;
            byte[] datos = null;
            string strRevision = "";

            if(archivosEncontrados == 0)
            {
                MessageBox.Show("El archivo PDF correspondiente a esta PO no fue encontrado.", "PDF no encontrado");
            }
            else if(archivosEncontrados > 1)
            {
                FrmSeleccionarRevision rev = new FrmSeleccionarRevision(archivosEncontrados-1);
                if( rev.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                {
                    revision = Convert.ToInt32(rev.RevisionSeleccionada);
                    strRevision = ", REV " + revision.ToString();
                }
                else
                    return;
            }

            foreach (Fila f in popdf.Filas())
            {
                if (Convert.ToInt32(f.Celda("revision")) == revision)
                    datos = (byte[])f.Celda("archivo");
            }

            FrmVisorPDF visor = new FrmVisorPDF(datos, "AUD-PO-" + IdPO.ToString() + strRevision);
            visor.ShowDialog();    
        }

        private void desglosarPArtidaEnviadaMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDesglosarPartidaPO desglosar = new FrmDesglosarPartidaPO(NumeroDeParte, IdPO, false);
            desglosar.ShowDialog();
            MostrarPartidas(IdPO);
        }

        private void CmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbMoneda.Text != "")
            {
                PoMaterial po = new PoMaterial();
                po.CargarDatos(IdPO);
                po.Fila().ModificarCelda("moneda", CmbMoneda.Text);
                po.GuardarDatos();
            }
        }

        private void crearRevisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que deseas crear una revisión de la orden de compra seleccionada?", "Crear revision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == System.Windows.Forms.DialogResult.No)
                return;

            PoMaterial po = new PoMaterial();
            po.CargarDatos(IdPO);

            int revisionActual = Convert.ToInt32(po.Fila().Celda("revision"));
            revisionActual++;

            po.Fila().ModificarCelda("revision", revisionActual);
            po.Fila().ModificarCelda("estatus", "SIN ENVIAR");
            po.GuardarDatos();

            CargarOrdenes(CmbFiltroEstatus.Text);
            MessageBox.Show("Revisión creada correctamente!");
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOrdenes(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        private void CmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOrdenes(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        private void NumLimite_ValueChanged(object sender, EventArgs e)
        {
            CargarOrdenes(CmbFiltroEstatus.Text, CmbProveedor.Text, CmbUsuario.Text, Convert.ToInt32(NumLimite.Value));
            BorrarPartidas();
        }

        private void desglosarPOToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmDesglosarPO desglosarPO = new FrmDesglosarPO(IdPO, NombreProveedor);
            desglosarPO.Show();
        }

        private void DgvPOs_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
               OpcionesPoDesglose.Show(Cursor.Position);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LblRevision_Click(object sender, EventArgs e)
        {

        }

        private void desglosarPOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
}
