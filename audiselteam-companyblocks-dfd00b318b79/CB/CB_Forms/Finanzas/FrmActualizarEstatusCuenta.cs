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
using System.IO;

namespace CB
{
    public partial class FrmActualizarEstarusCuenta : Form
    {
        PlanoProyecto plano = new PlanoProyecto();
        MaterialProyecto PO = new MaterialProyecto();
        PlanoCotizacion CotizacionPlano = new PlanoCotizacion();

        byte[] DatosPlanoPDF = null;
        byte[] DatosPlanoXML = null;
        int cargarID = 0;
        string material_plano = "";
               
        public FrmActualizarEstarusCuenta(int idPlano, string materialOPlano)
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

                if (NumDias.Value == 0)
                    BtnRecibir.Enabled = false;

                int idCotizacion = (int)plano.Fila().Celda("cotizacion_final");
                CotizacionPlano.CargarDatos(idCotizacion);

                string cotizacion_final = Convert.ToInt32(CotizacionPlano.Fila().Celda("precio_final")).ToString("C");

                ListViewItem id = new ListViewItem("ID: ");
                id.SubItems.Add(plano.Fila().Celda("id").ToString());

                ListViewItem proveedorMaquinado = new ListViewItem("Preveedor: ");
                proveedorMaquinado.SubItems.Add(plano.Fila().Celda("proveedor_maquinado").ToString());

                ListViewItem nombre = new ListViewItem("Nombre archivo: ");
                nombre.SubItems.Add(plano.Fila().Celda("nombre_archivo").ToString());

                ListViewItem cantidad = new ListViewItem("Cantidad Piezas: ");
                cantidad.SubItems.Add(plano.Fila().Celda("cantidad").ToString());

                ListViewItem recibidas = new ListViewItem("Piezas Recibidas: ");
                recibidas.SubItems.Add(plano.Fila().Celda("recibido").ToString());

                ListViewItem cotizacion = new ListViewItem("Cotizacion Final: ");
                cotizacion.SubItems.Add(cotizacion_final);

                LvInfoPieza.Items.Add(id);
                LvInfoPieza.Items.Add(proveedorMaquinado);
                LvInfoPieza.Items.Add(nombre);
                LvInfoPieza.Items.Add(cantidad);
                LvInfoPieza.Items.Add(recibidas);
                LvInfoPieza.Items.Add(cotizacion);
            }

            else if (material_plano == "PARTES COMPRADAS")
            {
                PO.CargarDatos(idPlano);
                if (NumDias.Value == 0)
                    BtnRecibir.Enabled = false;

                ListViewItem id = new ListViewItem("ID: ");
                id.SubItems.Add(PO.Fila().Celda("id").ToString());

                ListViewItem fabricante = new ListViewItem("Fabricante: ");
                fabricante.SubItems.Add(PO.Fila().Celda("fabricante").ToString());

                ListViewItem nombre = new ListViewItem("Numero de parte: ");
                nombre.SubItems.Add(PO.Fila().Celda("numero_parte").ToString());

                ListViewItem proyecto = new ListViewItem("Proyecto: ");
                proyecto.SubItems.Add(PO.Fila().Celda("proyecto").ToString());

                ListViewItem total = new ListViewItem("Total piezas: ");
                total.SubItems.Add(PO.Fila().Celda("total").ToString());

                ListViewItem tipoVenta = new ListViewItem("Tipo de venta: ");
                tipoVenta.SubItems.Add(PO.Fila().Celda("tipo_venta").ToString());

                LvInfoPieza.Items.Add(id);
                LvInfoPieza.Items.Add(fabricante);
                LvInfoPieza.Items.Add(nombre);
                LvInfoPieza.Items.Add(proyecto);
                LvInfoPieza.Items.Add(total);
                LvInfoPieza.Items.Add(tipoVenta);
            }
        }

        public void subirPlanoPDF()
        {
            FacturasFabricacion facturas = new FacturasFabricacion();
            Fila filaArchivoPdf = new Fila();
            switch (material_plano)
            {
                case "PARTES FABRICADAS":
                    filaArchivoPdf.AgregarCelda("id_plano", cargarID);
                    filaArchivoPdf.AgregarCelda("archivo", DatosPlanoPDF);
                    filaArchivoPdf.AgregarCelda("tipo", "PDF");
                    filaArchivoPdf.AgregarCelda("nombre_Archivo", TxtArchivoPdf.Text);
                    facturas.Insertar(filaArchivoPdf);
                    break;

                case "PARTES COMPRADAS":
                    filaArchivoPdf.AgregarCelda("id_requisicion", cargarID);
                    filaArchivoPdf.AgregarCelda("archivo", DatosPlanoPDF);
                    filaArchivoPdf.AgregarCelda("tipo", "PDF");
                    filaArchivoPdf.AgregarCelda("nombre_Archivo", TxtArchivoPdf.Text);
                    facturas.Insertar(filaArchivoPdf);
                    break;
            }
        }

        public void subirPlanoXml()
        {
            FacturasFabricacion facturas = new FacturasFabricacion();
            Fila filaArchivoXml = new Fila();
            switch (material_plano)
            {
                case "PARTES FABRICADAS":
                    filaArchivoXml.AgregarCelda("id_plano", cargarID);
                    filaArchivoXml.AgregarCelda("archivo", DatosPlanoXML);
                    filaArchivoXml.AgregarCelda("tipo", "XML");
                    filaArchivoXml.AgregarCelda("nombre_Archivo", TxtArchivoXml.Text);
                    facturas.Insertar(filaArchivoXml);
                    break;

                case "PARTES COMPRADAS":
                    filaArchivoXml.AgregarCelda("id_requisicion", cargarID);
                    filaArchivoXml.AgregarCelda("archivo", DatosPlanoXML);
                    filaArchivoXml.AgregarCelda("tipo", "XML");
                    filaArchivoXml.AgregarCelda("nombre_Archivo", TxtArchivoXml.Text);
                    facturas.Insertar(filaArchivoXml);
                    break;
            }
        }

        private void BtnBuscarPDF_Click(object sender, EventArgs e)
        {
            OFDBuscarArchivo.DefaultExt = ".pdf";
            OFDBuscarArchivo.Filter = "Archivos PDF (.pdf)|*.pdf";

            if (OFDBuscarArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string nombreFactura = OFDBuscarArchivo.SafeFileName.Replace(".pdf", "").Replace(".PDF", "");

                DatosPlanoPDF = File.ReadAllBytes(OFDBuscarArchivo.FileName);
                TxtArchivoPdf.Text = nombreFactura;
            }
        }

        private void BtnBuscarXml_Click(object sender, EventArgs e)
        {
            OFDBuscarArchivo.DefaultExt = ".xml";
            OFDBuscarArchivo.Filter = "Archivos XML (.xml)|*.xml";

            if (OFDBuscarArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string nombreFactura = OFDBuscarArchivo.SafeFileName.Replace(".xml", "").Replace(".XML", "");

                DatosPlanoXML = File.ReadAllBytes(OFDBuscarArchivo.FileName);
                TxtArchivoXml.Text = nombreFactura;
            }
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        private void NumDias_ValueChanged(object sender, EventArgs e)
        {
            if (NumDias.Value == 0)
                BtnRecibir.Enabled = false;
         
            else
                BtnRecibir.Enabled = true;
        }

        private void BtnRecibir_Click(object sender, EventArgs e)
        {
            string usuario_facturacion = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");

            FrmCuentasPorPagar actualizar = new FrmCuentasPorPagar();
            DateTime fechayhora = DateTime.Now;
            DateTime fechaFacturacion = fechayhora.Date;
            DateTime fechaDePago = fechayhora.Date;
            double dias_plazo = double.Parse(NumDias.Value.ToString());
            fechaDePago = fechaDePago.AddDays(dias_plazo);

            int validarFecha = (int) fechaDePago.DayOfWeek;

            switch (validarFecha)
            {
                case 0:
                    fechaDePago = fechaDePago.AddDays(1);
                    break;
                case 6:
                    fechaDePago = fechaDePago.AddDays(2);
                    break;
            }

            string validarNumeroFactura = TxbNumeroFactura.Text;

            if (String.IsNullOrWhiteSpace(validarNumeroFactura) || String.IsNullOrWhiteSpace(TxtArchivoPdf.Text) || String.IsNullOrWhiteSpace(TxtArchivoXml.Text) || DatosPlanoPDF == null || DatosPlanoXML == null)
                MessageBox.Show("Ingrese los datos completos");

            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea capturar los datos de factura? ", "", MessageBoxButtons.YesNo);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    switch (material_plano)
                    {
                        case "PARTES FABRICADAS":
                            plano.Fila().ModificarCelda("estatus_finanzas", "PAGO PENDIENTE");
                            plano.Fila().ModificarCelda("fecha_facturacion", fechaFacturacion);
                            plano.Fila().ModificarCelda("fecha_para_pagar", fechaDePago);
                            plano.Fila().ModificarCelda("numero_factura", TxbNumeroFactura.Text);
                            plano.Fila().ModificarCelda("usuario_facturacion", usuario_facturacion);
                            plano.GuardarDatos();
                            subirPlanoPDF();
                            subirPlanoXml();
                            break;
                        
                        case "PARTES COMPRADAS":
                            PO.Fila().ModificarCelda("estatus_finanzas", "PAGO PENDIENTE");
                            PO.Fila().ModificarCelda("fecha_facturacion", fechaFacturacion);
                            PO.Fila().ModificarCelda("fecha_para_pagar", fechaDePago);
                            PO.Fila().ModificarCelda("numero_factura", TxbNumeroFactura.Text);
                            PO.Fila().ModificarCelda("usuario_facturacion", usuario_facturacion);
                            PO.GuardarDatos();
                            subirPlanoPDF();
                            subirPlanoXml();
                            break;
                    }

                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                }
            }
        }
    }
}