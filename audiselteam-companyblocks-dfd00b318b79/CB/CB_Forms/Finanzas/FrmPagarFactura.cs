using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmPagarFactura : Form
    {
        PlanoProyecto plano = new PlanoProyecto();
        PlanoCotizacion planoCotizacion = new PlanoCotizacion();
        MaterialProyecto material = new MaterialProyecto();

        int cargarID = 0;
        string material_plano = "";

        public FrmPagarFactura(int idPlano, string materialOPlano)
        {
            InitializeComponent();
            cargarID = idPlano;
            material_plano = materialOPlano;
            CargarDatosPlano(idPlano);
        }

        public void CargarDatosPlano(int idPlano)
        {
            if (material_plano == "PARTES FABRICADAS")
            {
                plano.CargarDatos(idPlano);

                int idCotizacion = Convert.ToInt32(plano.Fila().Celda("cotizacion_final"));
                planoCotizacion.CargarDatos(idCotizacion);

                string cotizacion_final = Convert.ToInt32(planoCotizacion.Fila().Celda("precio_final")).ToString("C");

                ListViewItem id = new ListViewItem("ID: ");
                id.SubItems.Add(plano.Fila().Celda("id").ToString());

                ListViewItem proveedorMaquinado = new ListViewItem("Proveedor: ");
                proveedorMaquinado.SubItems.Add(plano.Fila().Celda("proveedor_maquinado").ToString());

                ListViewItem nombre = new ListViewItem("Nombre archivo: ");
                nombre.SubItems.Add(plano.Fila().Celda("nombre_archivo").ToString());

                ListViewItem cantidad = new ListViewItem("Cantidad piezas: ");
                cantidad.SubItems.Add(plano.Fila().Celda("cantidad").ToString());

                ListViewItem recibidas = new ListViewItem("Piezas recibidas: ");

                recibidas.SubItems.Add(plano.Fila().Celda("recibido").ToString());

                ListViewItem cotizacion = new ListViewItem("Cotizacion final: ");
                cotizacion.SubItems.Add(cotizacion_final);

                ListViewItem numeroFactura = new ListViewItem("Numero de factura: ");
                numeroFactura.SubItems.Add(plano.Fila().Celda("numero_factura").ToString());

                ListViewItem fechaParaPagar = new ListViewItem("Fecha de pago");
                DateTime fecha = Convert.ToDateTime(plano.Fila().Celda("fecha_para_pagar"));
                string fechaPago = fecha.ToString("MMM/dd/yyyy");
                fechaParaPagar.SubItems.Add(fechaPago);

                LvInfoPieza.Items.Add(id);
                LvInfoPieza.Items.Add(proveedorMaquinado);
                LvInfoPieza.Items.Add(nombre);
                LvInfoPieza.Items.Add(cantidad);
                LvInfoPieza.Items.Add(recibidas);
                LvInfoPieza.Items.Add(cotizacion);
                LvInfoPieza.Items.Add(numeroFactura);
                LvInfoPieza.Items.Add(fechaParaPagar);
            }
            else if (material_plano == "PARTES COMPRADAS")
            {
                material.CargarDatos(idPlano);
                ListViewItem id = new ListViewItem("ID: ");
                id.SubItems.Add(material.Fila().Celda("id").ToString());

                ListViewItem fabricante = new ListViewItem("Fabricante ");
                fabricante.SubItems.Add(material.Fila().Celda("fabricante").ToString());

                ListViewItem numeroParte = new ListViewItem("Numero de parte: ");
                numeroParte.SubItems.Add(material.Fila().Celda("numero_parte").ToString());

                ListViewItem total = new ListViewItem("Total: ");
                total.SubItems.Add(material.Fila().Celda("total").ToString());

                ListViewItem tipoVenta = new ListViewItem("Tipo de venta: ");
                tipoVenta.SubItems.Add(material.Fila().Celda("tipo_venta").ToString());

                ListViewItem numeroFactura = new ListViewItem("Numero de factura: ");
                numeroFactura.SubItems.Add(material.Fila().Celda("numero_factura").ToString());

                ListViewItem fechaParaPagar = new ListViewItem("Fecha de pago");
                DateTime fecha = Convert.ToDateTime(material.Fila().Celda("fecha_para_pagar"));
                string fechaPago = fecha.ToString("MMM/dd/yyyy");
                fechaParaPagar.SubItems.Add(fechaPago);

                LvInfoPieza.Items.Add(id);
                LvInfoPieza.Items.Add(fabricante);
                LvInfoPieza.Items.Add(numeroParte);
                LvInfoPieza.Items.Add(total);
                LvInfoPieza.Items.Add(tipoVenta);
                LvInfoPieza.Items.Add(numeroFactura);
                LvInfoPieza.Items.Add(fechaParaPagar);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void BtnRecibir_Click(object sender, EventArgs e)
        {
            FrmCuentasPorPagar Pagar = new FrmCuentasPorPagar();
            var fechaHora = DateTime.Now;
            var Fecha = fechaHora.Date;
            string validar = TxbReferencia.Text;
            string usuario_pago = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");

            if (RbtnTransaccion.Checked == false && RbtnCheque.Checked == false || String.IsNullOrWhiteSpace(validar))
            {
                MessageBox.Show("Capture los datos completos");
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("Desa Capturar el pago de esta Factura ", "", MessageBoxButtons.YesNo);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    if (material_plano == "PARTES FABRICADAS")
                    {
                        plano.Fila().ModificarCelda("estatus_finanzas", "PAGADA");
                        plano.Fila().ModificarCelda("fecha_pagado", Fecha);
                        plano.Fila().ModificarCelda("usuario_pago", usuario_pago);
                        if (RbtnCheque.Checked == true)
                            plano.Fila().ModificarCelda("modo_pago", "CHEQUE");
                        
                        else if (RbtnTransaccion.Checked == true)
                            plano.Fila().ModificarCelda("modo_pago", "TRANSFERENCIA");
                        
                        plano.Fila().ModificarCelda("referencia_pago", TxbReferencia.Text);
                        plano.GuardarDatos();
                        this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    }
                   
                    else if (material_plano == "PARTES COMPRADAS")
                    {
                        material.Fila().ModificarCelda("estatus_finanzas", "PAGADA");
                        material.Fila().ModificarCelda("fecha_pagado", Fecha);
                        material.Fila().ModificarCelda("usuario_pago", usuario_pago);
                        if (RbtnCheque.Checked == true)
                            material.Fila().ModificarCelda("modo_pago", "CHEQUE");
                    
                        else if (RbtnTransaccion.Checked == true)
                            material.Fila().ModificarCelda("modo_pago", "TRANSFERENCIA");
                        
                        material.Fila().ModificarCelda("referencia_pago", TxbReferencia.Text);
                        material.GuardarDatos();
                        this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    }
                }
            }
        }
    }
}
