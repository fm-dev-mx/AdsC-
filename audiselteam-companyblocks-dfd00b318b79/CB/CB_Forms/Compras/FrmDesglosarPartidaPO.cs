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
    public partial class FrmDesglosarPartidaPO : Form
    {
        string NumeroParte = "";
        string Proveedor = string.Empty;
        int Po = 0;
        int IdConcepto = 0;
        bool ModoEdicion = false;

        public FrmDesglosarPartidaPO(string numero_parte, int po, bool modoEdicion)
        {
            InitializeComponent();
            NumeroParte = numero_parte;
            Po = po;
            IdConcepto = 0;
            ModoEdicion = modoEdicion;
        }

        private void FrmDesglosarPartidaPO_Load(object sender, EventArgs e)
        {
            BtnModificarCantidad.Visible = ModoEdicion;
            BtnModificarCotizacion.Visible = ModoEdicion;
            BtnEliminar.Visible = ModoEdicion;
            BtnModificarCantidad.Enabled = false;
            BtnModificarCotizacion.Enabled = false;
            CargarDesglose(NumeroParte, Po);
        }

        public void CargarDesglose(string numero_parte, int po)
        {
            PoMaterial pomat = new PoMaterial();
            pomat.CargarDatos(po);

            BtnEliminar.Enabled = (pomat.Fila().Celda("estatus").ToString() != "ENVIADO");

            Proveedor prov = new Proveedor();
            prov.CargarDatos(Convert.ToInt32(pomat.Fila().Celda("proveedor")));

            LblNumeroDeParte.Text = "NUMERO DE PARTE: " + numero_parte;
            LblPO.Text = "PO #" + po.ToString().PadLeft(4,'0') + "-" + prov.Fila().Celda("nombre").ToString();

            DgvDesglose.Rows.Clear();

            PoMaterial.Modelo().DesglosarPartida(numero_parte, po).ForEach(delegate(Fila desg)
            {
                Proyecto prj = new Proyecto();
                prj.CargarDatos(Convert.ToDecimal(desg.Celda("proyecto")));

                Proyecto principal = new Proyecto();
                principal.CargarDatos(Convert.ToDecimal(prj.Fila().Celda("principal")));

                Cliente cli = new Cliente();

                if (!principal.TieneFilas())
                    cli.CargarDatos(Convert.ToInt32(prj.Fila().Celda("cliente")));
                else
                    cli.CargarDatos(Convert.ToInt32(principal.Fila().Celda("cliente")));

                string numeroReq = desg.Celda("id").ToString();
                string proyectoIdNombre = Convert.ToDecimal(desg.Celda("proyecto")).ToString("F2") + " - " + prj.Fila().Celda("nombre").ToString();
                string clienteNombre = cli.Fila().Celda("nombre").ToString();
                string requisitorNombre = desg.Celda("requisitor").ToString();
                int piezas_requeridas = Convert.ToInt32(desg.Celda("piezas_requeridas"));
                string tipo = desg.Celda("tipo_venta").ToString();
                string piezas_paquete = desg.Celda("piezas_paquete").ToString();
                string total = desg.Celda("total").ToString();
                string estatusCompra = desg.Celda("estatus_compra").ToString();

                string comentarios_requisitor = "";
                if (desg.Celda("comentarios_requisitor") != null)
                    comentarios_requisitor = desg.Celda("comentarios_requisitor").ToString();

                string strTotal = "";

                if (tipo == "POR PIEZA")
                    strTotal = total.ToString() + " pieza(s)";
                else if (tipo == "POR PAQUETE")
                    strTotal = total.ToString() + " paquete(s) con " + piezas_paquete + " piezas c/u";

                string precioUnitario = "$" + MaterialProyecto.Modelo().CargarDatos(desg.Celda<int>("id"))[0].Celda("precio_unitario").ToString();

                DgvDesglose.Rows.Add
                (
                    numeroReq,
                    requisitorNombre,
                    proyectoIdNombre,
                    clienteNombre,
                    piezas_requeridas,
                    tipo, strTotal,
                    estatusCompra,
                    comentarios_requisitor,
                    Convert.ToInt32(desg.Celda("piezas_paquete")),
                    total,
                    precioUnitario
                );
            });
            // ==============================================================================  

           /* RfqConcepto Concepto = new RfqConcepto();
            Concepto.SeleccionarUltimoRfqYConceptoParaPieza(NumeroParte, prov.Fila().Celda("nombre").ToString());

            if (Concepto.TieneFilas())
                IdConcepto = Concepto.Fila().Celda<int>("concepto");*/

            BtnModificarCantidad.Enabled = true;
            BtnModificarCotizacion.Enabled = true;
            Proveedor = prov.Fila().Celda("nombre").ToString();

            // ==============================================================================  
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvDesglose.SelectedRows.Count == 0)
                return;

            if (DgvDesglose.SelectedRows[0].Cells["estatus"].Value.ToString() == "ENTREGADO" || DgvDesglose.SelectedRows[0].Cells["estatus"].Value.ToString() == "RECIBIDO")
            {
                MessageBox.Show("No puede modificar una requisición que ya fue entregada o recibida");
                return;
            }

            int IdRequisicion = Convert.ToInt32(DgvDesglose.SelectedRows[0].Cells["numero_requisicion"].Value);

            DialogResult respuesta;
            respuesta = MessageBox.Show("Seguro que deseas eliminar la requisición #" + IdRequisicion.ToString() + " de esta partida?", "Eliminar requisición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(IdRequisicion);
                mat.Fila().ModificarCelda("po", 0);
                mat.Fila().ModificarCelda("precio_unitario", 0);
                mat.Fila().ModificarCelda("tiempo_entrega", 0);
                mat.Fila().ModificarCelda("precio_suma_final", 0);
                mat.Fila().ModificarCelda("estatus_compra", "EN COTIZACION");
                mat.GuardarDatos();

                CargarDesglose(NumeroParte, Po);
            }
        }

        private void DgvDesglose_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDesglose.SelectedRows.Count <= 0)
                return;

            PoMaterial pomat = new PoMaterial();
            pomat.CargarDatos(Po);
            BtnEliminar.Enabled = (pomat.Fila().Celda("estatus").ToString() != "ENVIADO");
            BtnModificarCantidad.Enabled = true;
        }

        private void BtnModificarCantidad_Click(object sender, EventArgs e)
        {
            if( DgvDesglose.SelectedRows.Count <= 0 )
                return;

            if(DgvDesglose.SelectedRows[0].Cells["estatus"].Value.ToString() == "ENTREGADO" ||DgvDesglose.SelectedRows[0].Cells["estatus"].Value.ToString() == "RECIBIDO")
            {
                MessageBox.Show("No puede modificar una requisición que ya fue entregada o recibida");
                return;
            }

            DataGridViewRow fila = new DataGridViewRow();
            fila = DgvDesglose.SelectedRows[0];

            int id_req = Convert.ToInt32( fila.Cells["numero_requisicion"].Value );
            int piezas_requeridas = Convert.ToInt32(fila.Cells["piezas_requeridas"].Value);
            int piezas_paquete = Convert.ToInt32(fila.Cells["piezas_paquete"].Value);
            string tipo_venta = fila.Cells["tipo_venta"].Value.ToString();

            FrmCantidadMaterial cant = new FrmCantidadMaterial(piezas_requeridas, piezas_requeridas, 100000, true);

            if( cant.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                Dictionary<string, int> total_ordenar = MaterialProyecto.Modelo().CalcularTotalOrdenar(cant.Piezas, piezas_paquete, tipo_venta); 
               
                int total = Convert.ToInt32(total_ordenar["total"]);
                int piezas_stock = Convert.ToInt32(total_ordenar["piezas_stock"]);

                MaterialProyecto req = new MaterialProyecto();
                req.CargarDatos(id_req);

                req.Fila().ModificarCelda("piezas_requeridas", cant.Piezas);
                req.Fila().ModificarCelda("total", total);
                req.Fila().ModificarCelda("piezas_stock", piezas_stock);

                req.GuardarDatos();

                CargarDesglose(NumeroParte, Po);
            }
        }

        private void BtnModificarCotizacion_Click(object sender, EventArgs e)
        {
            if (DgvDesglose.SelectedRows.Count == 0)
                return;

            if (DgvDesglose.SelectedRows[0].Cells["estatus"].Value.ToString() == "ENTREGADO" || DgvDesglose.SelectedRows[0].Cells["estatus"].Value.ToString() == "RECIBIDO")
            {
                MessageBox.Show("No puede modificar una requisición que ya fue entregada o recibida");
                return;
            }

            int idreq = Convert.ToInt32(DgvDesglose.SelectedRows[0].Cells["numero_requisicion"].Value);
            MaterialProyecto material = new MaterialProyecto();
            material.CargarDatos(idreq);

            if (material.TieneFilas())
                IdConcepto = Convert.ToInt32(material.Fila().Celda("rfq_concepto"));


            RfqConcepto Concepto = new RfqConcepto();
            Concepto.CargarDatos(IdConcepto);


            FrmCapturarCotizacionMaterial capturar = new FrmCapturarCotizacionMaterial(IdConcepto);
            capturar.PrecioUnitario = Convert.ToDecimal(Concepto.Fila().Celda("precio_unitario"));
            capturar.TiempoEntrega = Convert.ToInt32(Concepto.Fila().Celda("tiempo_entrega"));

            if (capturar.ShowDialog() == DialogResult.OK)
            {
                Concepto.Fila().ModificarCelda("precio_unitario", capturar.PrecioUnitario);
                Concepto.Fila().ModificarCelda("tiempo_entrega", capturar.TiempoEntrega);
                Concepto.Fila().ModificarCelda("moneda", capturar.Moneda);
                Concepto.Fila().ModificarCelda("cantidad_disponible", capturar.CantidadDisponible);
                Concepto.GuardarDatos();

                MaterialProyecto materialTemporal = new MaterialProyecto();

                foreach(DataGridViewRow materialRow in DgvDesglose.Rows)
                {
                    materialTemporal.CargarDatos(Convert.ToInt32(materialRow.Cells[0].Value));
                    
                    if(materialTemporal.TieneFilas())
                    {
                        materialTemporal.Fila().ModificarCelda("precio_unitario", capturar.PrecioUnitario);
                        int cantidad = Convert.ToInt32(materialTemporal.Fila().Celda("total"));
                        materialTemporal.Fila().ModificarCelda("precio_suma_final", (cantidad * capturar.PrecioUnitario));
                        materialTemporal.GuardarDatos();
                    }
                }
            }

            CargarDesglose(NumeroParte, Po);
        }

        private void DgvDesglose_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
