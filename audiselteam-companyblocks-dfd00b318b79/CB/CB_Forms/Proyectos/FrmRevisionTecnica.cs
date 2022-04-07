using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using FluentFTP;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmRevisionTecnica : Form
    {
        decimal IdProyecto = 0;
        int IdMaterial = 0;
        byte[] ImagenByte = null;
        int RfqConceptoSeleccionado = 0;
        string CatalogoUri = @"./SGC/CATALOGOMATERIAL/";
        public string Comentarios = string.Empty;
        public string EstatusAutorizacion = string.Empty;
        public string EstatusCompra = string.Empty;

        public FrmRevisionTecnica(int idMaterial)
        {
            InitializeComponent();
            IdMaterial = idMaterial;
        }

        private void FrmRevisionTecnica_Load(object sender, EventArgs e)
        {
            CargarInformacion();
        }

        private void CargarInformacion()
        {
            BtnAceptar.Enabled = false;
            BtnRechazar.Enabled = false;

            MaterialProyecto material = new MaterialProyecto();
            material.CargarDatos(IdMaterial);

            if(material.TieneFilas())
            {
                IdProyecto = Convert.ToDecimal(material.Fila().Celda("proyecto"));
            
                Proyecto proyecto = new Proyecto();
                proyecto.CargarDatos(Convert.ToDecimal(material.Fila().Celda("proyecto")));
                if (proyecto.TieneFilas())
                {
                    int cantidad= 0;
                    string tipoVenta = material.Fila().Celda("tipo_venta").ToString();
                    TxtProyecto.Text = material.Fila().Celda("proyecto").ToString() + " " + proyecto.Fila().Celda("nombre").ToString();
                    TxtRequisitor.Text = material.Fila().Celda("requisitor").ToString();
                    TxtNumeroParte.Text = material.Fila().Celda("numero_parte").ToString();
                    TxtFabricante.Text = material.Fila().Celda("fabricante").ToString();
                    TxtDescripcion.Text = material.Fila().Celda("descripcion").ToString();
                    RfqConceptoSeleccionado = material.Fila().Celda<int>("rfq_concepto"); 

                    if(RfqConceptoSeleccionado == 0)
                    {
                        string msg = "No es posible realizar la revisión técnica de este material ya que no cuenta con un proveedor seleccionado." + Environment.NewLine + Environment.NewLine;
                        msg += "Esto probablemente se deba a un error pasado en el sistema que actualmente ya fue corregido, el material tomará el estatus correcto automáticamente." + Environment.NewLine;
                        msg += "Por favor avise al departamento de compras para que den seguimiento a la requisición (ID " + IdMaterial + ")." + Environment.NewLine + Environment.NewLine;
                        msg += "Una disculpa por el inconveniente, en caso de que se presenten mayores problemas por favor reportarlos al departamento de sistemas, gracias.";

                        MessageBox.Show(msg, "Error de sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if(material.Fila().Celda("fecha_compra") != null)
                            material.Fila().ModificarCelda("estatus_compra", "ORDENADO");
                        else
                        {
                            material.Fila().ModificarCelda("estatus_autorizacion", "PENDIENTE");
                            material.Fila().ModificarCelda("fecha_autorizacion", null);
                            material.Fila().ModificarCelda("usuario_autorizacion", "N/A");
                            material.Fila().ModificarCelda("estatus_financiero", "PENDIENTE");
                            material.Fila().ModificarCelda("fecha_revision_financiera", null);
                            material.Fila().ModificarCelda("usuario_aprobacion_financiera", null);
                            material.Fila().ModificarCelda("estatus_compra", "EN COTIZACION");
                        }

                        material.GuardarDatos();
                        EstatusCompra = material.Fila().Celda("estatus_compra").ToString();
                        EstatusAutorizacion = material.Fila().Celda("estatus_autorizacion").ToString(); 
                        DialogResult = System.Windows.Forms.DialogResult.No;
                        Close();
                    }

                    if (tipoVenta == "POR PAQUETE")
                        cantidad = material.Fila().Celda<int>("total");
                    else
                        cantidad = material.Fila().Celda<int>("piezas_requeridas");

                    CatalogoMaterial catalogoMaterial = new CatalogoMaterial();
                    catalogoMaterial.SeleccionarNumeroDeParte(material.Fila().Celda("numero_parte").ToString());

                    if (catalogoMaterial.TieneFilas())
                    {
                        BtnAceptar.Enabled = false;
                        BtnRechazar.Enabled = false;
                        TxtNumeroParteInterno.Text = Global.CrearNumeroParteAudisel(Convert.ToInt32(catalogoMaterial.Fila().Celda("id")));
                        linkLabelInformacion.Text = catalogoMaterial.Fila().Celda("link").ToString();
                        BkgDescargarImagen.RunWorkerAsync(catalogoMaterial.Fila().Celda("id"));
                    }

                    // Cargar conceptos
                    List<Fila> ultimasCotizaciones 
                        = RfqConcepto.Modelo().UltimasCotizaciones(material.Fila().Celda("numero_parte").ToString());

                    bool conceptoSeleccionadoEncontrado = false;

                    ultimasCotizaciones.ForEach(delegate(Fila conceptoCotizacion)
                    {
                        int idConceptoCoti = Convert.ToInt32(conceptoCotizacion.Celda("id").ToString());

                        if (idConceptoCoti == RfqConceptoSeleccionado && !conceptoSeleccionadoEncontrado)
                            conceptoSeleccionadoEncontrado = true;

                        CultureInfo curr = CultureInfo.GetCultureInfo("en-US");

                        switch (conceptoCotizacion.Celda("moneda").ToString())
                        {
                            case "MXN":
                                curr = CultureInfo.GetCultureInfo("es-MX");
                                break;
                            case "USD":
                                curr = CultureInfo.GetCultureInfo("en-US");
                                break;
                            case "EUR":
                                curr = CultureInfo.GetCultureInfo("en-FR");
                                break;
                        }

                        if(conceptoCotizacion.TieneCelda("id"))
                        {
                            DgvCotizacion.Rows.Add(
                            idConceptoCoti,
                            conceptoCotizacion.Celda("nombre_proveedor"),
                            cantidad + " " + tipoVenta,
                            //Convert.ToDouble(conceptoCotizacion.Celda("precio_unitario")).ToString("C2", System.Globalization.CultureInfo.CurrentCulture) + " " + conceptoCotizacion.Celda("moneda").ToString(),
                            //(Convert.ToDouble(conceptoCotizacion.Celda("precio_unitario")) * cantidad).ToString("C2", System.Globalization.CultureInfo.CurrentCulture) + " " + conceptoCotizacion.Celda("moneda").ToString(),
                            string.Format(curr, "{0:C}", Convert.ToDouble(conceptoCotizacion.Celda("precio_unitario"))) + " " + conceptoCotizacion.Celda("moneda").ToString(),
                            string.Format(curr, "{0:C}", (Convert.ToDouble(conceptoCotizacion.Celda("precio_unitario")) * cantidad)) + " " + conceptoCotizacion.Celda("moneda").ToString(),
                            conceptoCotizacion.Celda("tiempo_entrega") + " DIA(S)"
                            );
                        }
                    });

                    // En ocasiones puede darse el caso que la cotizacion seleccionada no se encuentre dentro de las ultimas cotizaciones, por ejemplo si
                    // recientemente se volvio a cotizar el numero de parte. Esto podria ocasionar que la cotizacion seleccionada no aparezca en el datagridview.
                    // En este caso es necesario cargarla por separado con el siguiente codigo
                    if (!conceptoSeleccionadoEncontrado)
                        CargarCotizacionSeleccionada(tipoVenta, cantidad);
                }
            }
        }

        public void CargarCotizacionSeleccionada(string tipoVenta, int cantidad)
        {
            RfqConcepto conceptoSelec = new RfqConcepto();

            string sql = "SELECT rfq_conceptos.*, proveedores.nombre AS nombre_proveedor ";
            sql += "FROM rfq_conceptos ";
            sql += "INNER JOIN rfq_material ON rfq_material.id=rfq_conceptos.rfq ";
            sql += "INNER JOIN proveedores ON proveedores.id=rfq_material.proveedor ";
            sql += "WHERE rfq_conceptos.id=@idConcepto";

            conceptoSelec.ConstruirQuery(sql);
            conceptoSelec.AgregarParametro("idConcepto", RfqConceptoSeleccionado);
            conceptoSelec.EjecutarQuery();
            conceptoSelec.LeerFilas();

            conceptoSelec.Filas().ForEach(delegate(Fila conceptoCotizacion)
            {
                DgvCotizacion.Rows.Add(
                RfqConceptoSeleccionado,
                conceptoCotizacion.Celda("nombre_proveedor"),
                cantidad + " " + tipoVenta,
                Convert.ToDouble(conceptoCotizacion.Celda("precio_unitario")).ToString("C2", System.Globalization.CultureInfo.CurrentCulture) + " " + conceptoCotizacion.Celda("moneda").ToString(),
                (Convert.ToDouble(conceptoCotizacion.Celda("precio_unitario")) * cantidad).ToString("C2", System.Globalization.CultureInfo.CurrentCulture) + " " + conceptoCotizacion.Celda("moneda").ToString(),
                conceptoCotizacion.Celda("tiempo_entrega") + " DIA(S)"
                );
            });
        }

        private void BkgDescargarImagen_DoWork(object sender, DoWorkEventArgs e)
        {
            int id = Convert.ToInt32(e.Argument);
            BkgDescargarImagen.ReportProgress(10, "Descargando imagen");
            CatalogoMaterial materialSeleccionado = new CatalogoMaterial();
            materialSeleccionado = new CatalogoMaterial();
            materialSeleccionado.CargarDatos(id);

            if (materialSeleccionado.Fila().Celda<int>("imagen_servidor") > 0)
            {
                FtpClient clienteFtp = new FtpClient();
                Global.CrearConexionFTP(clienteFtp);

                if (clienteFtp.IsConnected)
                {
                    BkgDescargarImagen.ReportProgress(60, "Descargando imagen");
                    try
                    { 
                        if (clienteFtp.FileExists(CatalogoUri + "/" + id + ".PNG"))
                            clienteFtp.Download(out ImagenByte, CatalogoUri + "/" + id + ".PNG");
                    }
                    catch { }
                }
            }
            BkgDescargarImagen.ReportProgress(100, "Descargando imagen, espere un momento...");
        }

        private void BkgDescargarImagen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progress.Value = e.ProgressPercentage;          
        }

        private void BkgDescargarImagen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ImagenByte != null)
                ImagenMaterial.Image = Global.ByteAImagen(ImagenByte);

            Progress.Visible = false;
            LblEstatus.Text = "Imagen descargada";
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = System.Windows.Forms.DialogResult.Ignore;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            EstatusAutorizacion = "AUTORIZADO";

            // Acorde al flujo del proceso de compras:
            // las compras vinculadas con un proyecto pasan a planificacion despues de ser autorizadas en la revision tecnica
            if(IdProyecto > 0)
                EstatusCompra = "EN PLANIFICACION";
            else
            // las compras NO vinculadas con un proyecto pasan directo a revision financiera sin planeacion (es decir, MRO y algunos servicios)
                EstatusCompra = "EN REVISION FINANCIERA";
            
            Comentarios = TxtComentarios.Text;
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            Close();
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != "");
            BtnRechazar.Enabled = (TxtComentarios.Text != "");
            BtnCancelar.Enabled = (TxtComentarios.Text != "");
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea rechazar el material?", "Rechazar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                EstatusAutorizacion = "RECHAZADO";
                EstatusCompra = "COMPRA RECHAZADA";
                Comentarios = TxtComentarios.Text;
                DialogResult = System.Windows.Forms.DialogResult.Yes;
                Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar el material?", "Cancelar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                EstatusAutorizacion = "CANCELADO";
                EstatusCompra = "CANCELADO";
                Comentarios = TxtComentarios.Text;
                DialogResult = System.Windows.Forms.DialogResult.Yes;
                Close();
            }
        }

        private void DgvCotizacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int idConcepto = Convert.ToInt32(DgvCotizacion.Rows[e.RowIndex].Cells["id"].Value);

            if (idConcepto == RfqConceptoSeleccionado)
            {
                DgvCotizacion.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                LblInformacionCotizacion.Text = "INFORMACION DE COTIZACION (" + DgvCotizacion.Rows[e.RowIndex].Cells["proveedor"].Value.ToString() +")";
            }
        }

        private void DgvCotizacion_SelectionChanged(object sender, EventArgs e)
        {
            DgvCotizacion.ClearSelection(); 
        }
    }
}
