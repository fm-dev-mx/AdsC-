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
    public partial class FrmAgregarPartidaRFQ : Form
    {
        public int IdRfq = 0;
        public MaterialProyecto BuscadorMaterial = new MaterialProyecto();

        public FrmAgregarPartidaRFQ(int idRfq, List<Filtro> filtros=null)
        {
            InitializeComponent();
            IdRfq = idRfq;

            if (filtros != null)
                BuscadorMaterial.Filtros = filtros;
            else
            {
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_compra", "Estatus compra", BuscadorMaterial.EstatusCompra()));
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_seleccion", "Estatus selección", BuscadorMaterial.EstatusSeleccion()));
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_autorizacion", "Estatus autorización", BuscadorMaterial.EstatusAutorizacion()));
                BuscadorMaterial.Filtros.Add(new Filtro("estatus_almacen", "Estatus almacén", BuscadorMaterial.EstatusAlmacen()));
                BuscadorMaterial.Filtros.Add(new Filtro("requisitor", "Requisitor", BuscadorMaterial.Requisitores()));
                BuscadorMaterial.Filtros.Add(new Filtro("proyecto", "Proyecto", BuscadorMaterial.Proyectos()));
                BuscadorMaterial.Filtros.Add(new Filtro("fabricante", "Fabricante", BuscadorMaterial.Fabricantes())); ;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public void CargarNumerosParte()
        {
            RfqMaterial rfq = new RfqMaterial();
            rfq.CargarDatos(IdRfq);
            int proveedor = Convert.ToInt32(rfq.Fila().Celda("proveedor"));

            Proveedor prov = new Proveedor();
            prov.CargarDatos(proveedor);
            LblRFQ.Text = "RFQ #" + IdRfq.ToString() + " - " + prov.Fila().Celda("nombre").ToString();

            int filaActual = Global.GuardarFilaSeleccionada(DgvNumerosParte);
            DgvNumerosParte.Rows.Clear();
            BuscadorMaterial.EnProcesoDeCompra(DateDesde.Value, DateHasta.Value).ForEach(delegate(Fila material)
            {
                string numero_parte = material.Celda("numero_parte").ToString();
                string estatus_compra = material.Celda("estatus_compra").ToString();
                string estatus_autorizacion = material.Celda("estatus_autorizacion").ToString();

                if ( RfqConcepto.Modelo().ExisteEnRfq(IdRfq, numero_parte) == false && estatus_compra != "ORDENADO" & estatus_autorizacion != "RECHAZADO"  )
                    DgvNumerosParte.Rows.Add(false, numero_parte, material.Celda("fabricante"), material.Celda("descripcion"), material.Celda("suma_total"), material.Celda("tipo_venta") );
            });
            Global.RecuperarFilaSeleccionada(DgvNumerosParte, filaActual);
        }

        private void FrmAgregarPartidaRFQ_Load(object sender, EventArgs e)
        {
            DateDesde.Value = DateTime.Now.AddYears(-1);
            DateHasta.Value = DateTime.Now;
            RfqMaterial rfq = new RfqMaterial();
            rfq.CargarDatos(IdRfq);

            Proveedor prov = new Proveedor();
            prov.CargarDatos(Convert.ToInt32(rfq.Fila().Celda("proveedor")));
            LblRFQ.Text = IdRfq + " - " + prov.Fila().Celda("nombre").ToString();

            CargarNumerosParte();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> filasSeleccionadas = new List<DataGridViewRow>();

            foreach(DataGridViewRow row in DgvNumerosParte.Rows)
            {
                if ( Convert.ToBoolean(row.Cells[0].Value) == true)
                    filasSeleccionadas.Add(row);
            }

            if (filasSeleccionadas.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un número de parte.");
                return;
            }

            filasSeleccionadas.ForEach(delegate(DataGridViewRow row)
            {
                Fila partida = new Fila();

                string numero_parte = row.Cells[1].Value.ToString();
                string fabricante = row.Cells[2].Value.ToString();
                string descripcion = row.Cells[3].Value.ToString();
                int cantidad_estimada = Convert.ToInt32(row.Cells[4].Value);
                string tipo_venta = row.Cells[5].Value.ToString();

                partida.AgregarCelda("rfq", IdRfq);
                partida.AgregarCelda("numero_parte", numero_parte);
                partida.AgregarCelda("fabricante", fabricante);
                partida.AgregarCelda("descripcion", descripcion);
                partida.AgregarCelda("precio_unitario", 0);
                partida.AgregarCelda("tiempo_entrega", 0);
                partida.AgregarCelda("cantidad_estimada", cantidad_estimada);
                partida.AgregarCelda("tipo_venta", tipo_venta);
                int idConcepto = Convert.ToInt32(RfqConcepto.Modelo().Insertar(partida).Celda("id"));


                MaterialProyecto mat = new MaterialProyecto();
                mat.Filtros = BuscadorMaterial.Filtros;
                mat.DesgloseEnProcesoDeCompra(numero_parte);
                mat.Filas().ForEach(delegate(Fila m)
                {
                    if (Convert.ToInt32(m.Celda("po")) == 0 &&
                        m.Celda("estatus_autorizacion").ToString() != "RECHAZADO")
                        m.ModificarCelda("estatus_compra", "EN COTIZACION");
                });
                mat.GuardarDatos();

                Fila insertarRelacion = new Fila();
                insertarRelacion.AgregarCelda("numero_parte", mat.Fila().Celda("numero_parte").ToString());
                insertarRelacion.AgregarCelda("id_rfq", IdRfq);
                insertarRelacion.AgregarCelda("id_material_proyecto", mat.Fila().Celda("id"));
                insertarRelacion.AgregarCelda("id_concepto", idConcepto);
                RelacionMaterialRfq.Modelo().Insertar(insertarRelacion);
            });
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in DgvNumerosParte.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void BtnSeleccionarNada_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvNumerosParte.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void BtnFiltrarDatos_Click(object sender, EventArgs e)
        {
            FrmFiltrarDatos formFiltros = new FrmFiltrarDatos(BuscadorMaterial.Filtros);

            if(formFiltros.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                BuscadorMaterial.Filtros = formFiltros.Filtros;
                CargarNumerosParte();
            }
        }

        private void DateDesde_ValueChanged(object sender, EventArgs e)
        {
            //CargarNumerosParte();
        }

        private void DateHasta_ValueChanged(object sender, EventArgs e)
        {
            //CargarNumerosParte();
        }

        private void DateDesde_Leave(object sender, EventArgs e)
        {
            //CargarNumerosParte();
        }

        private void DateHasta_Leave(object sender, EventArgs e)
        {
            //CargarNumerosParte();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarNumerosParte();
        }
    }
}
