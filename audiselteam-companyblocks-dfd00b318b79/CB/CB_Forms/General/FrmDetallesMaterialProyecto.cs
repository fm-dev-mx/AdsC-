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
using System.Globalization;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmDetallesMaterialProyecto : Ventana
    {
        private int Id = 0;
        private int ScrollPosicion = 0;
        private int ArchivosActaules = 0;
        public FrmDetallesMaterialProyecto(int id)
        {
            InitializeComponent();
            Id = id;
            CargarDatosMaterial(Id);
            CargarArchivos();
            BarraProgresoAsignaciones.Visible = false;
        }

        public void CargarDatosMaterial(int id)
        {
            MaterialProyecto mat = new MaterialProyecto();
            mat.CargarDatosConProveedor(id);

            object numero_parte = mat.Fila().Celda("numero_parte");
            object fabricante = mat.Fila().Celda("fabricante");
            object descripcion = mat.Fila().Celda("descripcion");
            object requisicion = mat.Fila().Celda("id");
            object requisitor = mat.Fila().Celda("requisitor");
            object comentarios_requisitor = mat.Fila().Celda("comentarios_requisitor");
            object tipo_venta = mat.Fila().Celda("tipo_venta");
            object piezas_paquete = mat.Fila().Celda("piezas_paquete");
            object piezas_requeridas = mat.Fila().Celda("piezas_requeridas");
            object total = mat.Fila().Celda("total");
            object estatus_autorizacion = mat.Fila().Celda("estatus_autorizacion");
            object usuario_autorizacion = mat.Fila().Celda("usuario_autorizacion");
            object fecha_autorizacion = mat.Fila().Celda("fecha_autorizacion");
            object comentarios_autorizacion = mat.Fila().Celda("comentarios_autorizacion");
            object po = mat.Fila().Celda("po");
            object estatusAlmacen = mat.Fila().Celda("estatus_almacen");
            object recibio = mat.Fila().Celda("usuario_recibido_almacen");
            object fechaRecibidoAlmacen = mat.Fila().Celda("fecha_recibido_almacen");
            int idOrdenMantenimiento = mat.Fila().Celda<int>("mantenimiento");
            object estatus_financiero = mat.Fila().Celda("estatus_financiero");
            object usuario_autorizacion_finanzas = mat.Fila().Celda("usuario_aprobacion_financiera");
            object fecha_autorizacion_finanzas = mat.Fila().Celda("fecha_revision_financiera");
            object proy = mat.Fila().Celda("proyecto");
            object fechaCreacionRequisicion = mat.Fila().Celda("fecha_creacion");
            object fechaCompra = mat.Fila().Celda("fecha_compra");
            //object metaCompra = mat.Fila().Celda("fecha_promesa_compras");
            string fechaEstimadaEntrega = "N/A";
            object eta = mat.Fila().Celda("eta");
            if (eta != null)
                fechaEstimadaEntrega = Convert.ToDateTime(eta).ToString("MMM dd, yyyy");
            object meta = mat.Fila().Celda("meta");
            object definicion = mat.Fila().Celda("estatus_seleccion");
            object proveedorSeleccionado = mat.Fila().Celda("proveedor");

            if (Convert.ToDecimal(proy) <= 0)
                proy = "N/A";
            else
            {
                 Proyecto proyectoTbl = new Proyecto();
                 proyectoTbl.CargarDatos(Convert.ToDecimal(proy));
                 if (proyectoTbl.TieneFilas())
                     proy = Convert.ToDecimal(proy).ToString("f2") + " - " + proyectoTbl.Fila().Celda("nombre");
            }

            // Número de parte
            ListViewItem  proyecto = new ListViewItem("Proyecto: ");
            proyecto.SubItems.Add(proy.ToString());
            proyecto.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(proyecto);

            // Número de parte
            ListViewItem numeroDeParte = new ListViewItem("Número de parte: ");
            numeroDeParte.SubItems.Add( numero_parte.ToString() );
            numeroDeParte.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(numeroDeParte);

            // Fabricante
            ListViewItem fab = new ListViewItem("Fabricante: ");
            fab.SubItems.Add(fabricante.ToString() );
            fab.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(fab);

            // Descripcion
            ListViewItem desc = new ListViewItem("Descripción: ");
            desc.SubItems.Add( descripcion.ToString() );
            desc.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(desc);

            // Unidades
            ListViewItem unidades = new ListViewItem("Unidades: ");
            unidades.SubItems.Add( tipo_venta.ToString() );
            unidades.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(unidades);

            //=================================================================

            // Requisicion
            ListViewItem req = new ListViewItem("Número de requisición: ");
            req.SubItems.Add( requisicion.ToString() );
            req.Group = LvInfoMaterial.Groups["Requisicion"];
            LvInfoMaterial.Items.Add(req);

            // Estado de definición
            ListViewItem def = new ListViewItem("Estatus de definción: ");
            def.SubItems.Add(definicion.ToString());
            def.Group = LvInfoMaterial.Groups["Requisicion"];
            LvInfoMaterial.Items.Add(def);

            // Requisitor
            ListViewItem reqr = new ListViewItem("Requisitor: ");
            reqr.SubItems.Add( requisitor.ToString() );
            reqr.Group = LvInfoMaterial.Groups["Requisicion"];
            LvInfoMaterial.Items.Add(reqr);
            
            //fecha creacion
            ListViewItem fcreacionReq = new ListViewItem("Fecha creación: ");
            fcreacionReq.SubItems.Add(Global.FechaATexto(fechaCreacionRequisicion, false));
            fcreacionReq.Group = LvInfoMaterial.Groups["Requisicion"];
            LvInfoMaterial.Items.Add(fcreacionReq);

            // Piezas requeridas
            ListViewItem preq = new ListViewItem("Piezas requeridas: ");
            preq.SubItems.Add(piezas_requeridas.ToString());
            preq.Group = LvInfoMaterial.Groups["Requisicion"];
            LvInfoMaterial.Items.Add(preq);

            // Total a ordenar
            string strTotal = total.ToString();
            ListViewItem ptot = new ListViewItem("Total a ordenar: ");

            if (tipo_venta.ToString() == "POR PIEZA")
                strTotal += " pieza(s)";
            else
                strTotal += " paquetes con " + piezas_paquete.ToString() + " pieza(s) c/u";

            ptot.SubItems.Add(strTotal);
            ptot.Group = LvInfoMaterial.Groups["Requisicion"];
            LvInfoMaterial.Items.Add(ptot);

            // Plano
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(Convert.ToInt32(mat.Fila().Celda("plano")));

            if(plano.TieneFilas())
            {
                ListViewItem p = new ListViewItem("Plano: ");
                p.SubItems.Add(plano.Fila().Celda("id") + " | " + plano.Fila().Celda("nombre_archivo").ToString());
                p.Group = LvInfoMaterial.Groups["Requisicion"];
                LvInfoMaterial.Items.Add(p);
            }

            //===== Autorizacion =======================================================

            // Estatus autorizacion
            ListViewItem aut = new ListViewItem("Revisión técnica: ");
            aut.SubItems.Add(estatus_autorizacion.ToString());
            aut.Group = LvInfoMaterial.Groups["Autorizacion"];
            LvInfoMaterial.Items.Add(aut);

            // Usuario autorizacion
            ListViewItem uaut = new ListViewItem("Usuario autorización: ");
            uaut.SubItems.Add(usuario_autorizacion.ToString());
            uaut.Group = LvInfoMaterial.Groups["Autorizacion"];
            LvInfoMaterial.Items.Add(uaut);

            // Fecha autorizacion
            ListViewItem faut = new ListViewItem("Fecha autorización: ");
            if (fecha_autorizacion != null)
                faut.SubItems.Add(fecha_autorizacion.ToString());
            else
                faut.SubItems.Add("N/A");
            faut.Group = LvInfoMaterial.Groups["Autorizacion"];
            LvInfoMaterial.Items.Add(faut);

            //===== Compra =======================================================

            // Estatus
            ListViewItem estatusCompra = new ListViewItem("Estatus: ");
            estatusCompra.SubItems.Add(mat.Fila().Celda("estatus_compra").ToString());
            estatusCompra.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(estatusCompra);

            // Proveedor preferido
            int numPo = Convert.ToInt32(po);
            if ( numPo <= 0)
            { 
                ListViewItem proveedorPreferidoItem = new ListViewItem("Proveedor seleccionado: ");
                proveedorPreferidoItem.SubItems.Add(Global.ObjetoATexto(proveedorSeleccionado, "N/A"));
                proveedorPreferidoItem.Group = LvInfoMaterial.Groups["Compra"];
                LvInfoMaterial.Items.Add(proveedorPreferidoItem);
            }

            string tiempoDeEntrega = "N/A";
            string precioUnitario = "N/A";
            string precioTotalMaterial = "N/A";
            object rfqConcepto = mat.Fila().Celda("rfq_concepto");
            object objPrecioTotal = mat.Fila().Celda("precio_suma_final");

           



            if (mat.Fila().Celda("rfq_concepto") != null)
            {
                if ( Convert.ToInt32(mat.Fila().Celda("rfq_concepto")) > 0)
                {
                    RfqConcepto cargarConcepto = new RfqConcepto();
                    cargarConcepto.CargarDatos(Convert.ToInt32(mat.Fila().Celda("rfq_concepto")));

                    if (cargarConcepto.TieneFilas())
                    {
                        CultureInfo curr = CultureInfo.GetCultureInfo("en-US");

                        switch (cargarConcepto.Fila().Celda("moneda").ToString())
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

                        tiempoDeEntrega = cargarConcepto.Fila().Celda("tiempo_entrega").ToString() + " DIA(S)";
                        precioUnitario = string.Format(curr, "{0:C}", Convert.ToDecimal(cargarConcepto.Fila().Celda("precio_unitario"))) + " " + cargarConcepto.Fila().Celda("moneda") ;

                        if (objPrecioTotal != null)
                        {
                            if (Convert.ToDouble(objPrecioTotal) > 0)
                            {
                                precioTotalMaterial = string.Format(curr, "{0:C}", Convert.ToDecimal(objPrecioTotal)) + " " + mat.Fila().Celda("precio_moneda").ToString();
                            }
                        }
                    }
                }
            }

            //Precio unitario
            ListViewItem PrecioUnitarioItem = new ListViewItem("Precio unitario: ");
            PrecioUnitarioItem.SubItems.Add(precioUnitario);
            PrecioUnitarioItem.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(PrecioUnitarioItem);

            //Precio total
            ListViewItem PrecioTotalItem = new ListViewItem("Precio total: ");
            PrecioTotalItem.SubItems.Add(precioTotalMaterial);
            PrecioTotalItem.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(PrecioTotalItem);

            //Tiempo de entrega
            ListViewItem proveedorTiempoDeEntrega = new ListViewItem("Tiempo de entrega: ");
            proveedorTiempoDeEntrega.SubItems.Add(Global.ObjetoATexto(tiempoDeEntrega, "N/A"));
            proveedorTiempoDeEntrega.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(proveedorTiempoDeEntrega);

            //Fecha compra
            ListViewItem fechaDeCompra = new ListViewItem("Fecha de compra: ");
            fechaDeCompra.SubItems.Add(Global.FechaATexto(fechaCompra, false));
            fechaDeCompra.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(fechaDeCompra);

            //fecha promesa
            ListViewItem fechaPromesa = new ListViewItem("Fecha de entrega estimada: ");
            fechaPromesa.SubItems.Add(Global.FechaATexto(fechaEstimadaEntrega, false));
            fechaPromesa.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(fechaPromesa);

            //meta
            ListViewItem metas = new ListViewItem("Meta: ");
            string strmeta = "N/A";
            if (Convert.ToInt32(meta) > 0)
                strmeta = meta.ToString().PadLeft(4, '0');
            metas.SubItems.Add(strmeta);
            metas.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(metas);

            // PO
            ListViewItem ordenc = new ListViewItem("Orden de compra: ");
            int idProveedor = 0;
            if ( numPo > 0)
                ordenc.SubItems.Add(po.ToString());
            else
                ordenc.SubItems.Add("N/A");
            ordenc.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(ordenc);

            // Comprador
            PoMaterial pomat = new PoMaterial();
            pomat.CargarDatos(numPo);
            ListViewItem comprador = new ListViewItem("Comprador: ");
            if (pomat.TieneFilas()) {
                comprador.SubItems.Add( pomat.Fila().Celda("usuario").ToString() );
                idProveedor = Convert.ToInt32(pomat.Fila().Celda("proveedor"));
            }
            else
                comprador.SubItems.Add("N/A");
            comprador.Group = LvInfoMaterial.Groups["Compra"];
            LvInfoMaterial.Items.Add(comprador);

            // Proveedor
            if ( numPo > 0)
            {
                Proveedor prov = new Proveedor();
                prov.CargarDatos(idProveedor);

                ListViewItem proveedor = new ListViewItem("Proveedor: ");
                if (prov.TieneFilas())
                {
                    proveedor.SubItems.Add(prov.Fila().Celda("nombre").ToString());
                }
                else
                    proveedor.SubItems.Add("N/A");
                proveedor.Group = LvInfoMaterial.Groups["Compra"];
                LvInfoMaterial.Items.Add(proveedor);
            }
            //===== Revisión financiera =======================================================

            // Revisión financiera
            ListViewItem finanzas = new ListViewItem("Revisión financiera: ");
            finanzas.SubItems.Add(Global.ObjetoATexto(estatus_financiero, "N/A"));
            finanzas.Group = LvInfoMaterial.Groups["Finanzas"];
            LvInfoMaterial.Items.Add(finanzas);

            // Usuario autorizacion
            finanzas = new ListViewItem("Usuario autorización: ");
            finanzas.SubItems.Add(Global.ObjetoATexto(usuario_autorizacion_finanzas, "N/A"));
            finanzas.Group = LvInfoMaterial.Groups["Finanzas"];
            LvInfoMaterial.Items.Add(finanzas);

            // Fecha autorizacion
            finanzas = new ListViewItem("Fecha de revisión financiera: ");
            if (fecha_autorizacion != null)
                finanzas.SubItems.Add(Global.FechaATexto(fecha_autorizacion_finanzas));
            else
                finanzas.SubItems.Add("N/A");
            finanzas.Group = LvInfoMaterial.Groups["Finanzas"];
            LvInfoMaterial.Items.Add(finanzas);

            //===== Almacén =======================================================
            // Estatus
            ListViewItem estatusAlmacenItem = new ListViewItem("Estatus: ");
            estatusAlmacenItem.SubItems.Add(Global.ObjetoATexto(estatusAlmacen, "N/A"));
            estatusAlmacenItem.Group = LvInfoMaterial.Groups["Almacen"];
            LvInfoMaterial.Items.Add(estatusAlmacenItem);

            //Recibió
            if (estatusAlmacen.ToString() == "ENTREGADO")
            {
                ListViewItem recibioAlmacen = new ListViewItem("Recibió: ");
                recibioAlmacen.SubItems.Add(Global.ObjetoATexto(recibio, "N/A"));
                recibioAlmacen.Group = LvInfoMaterial.Groups["Almacen"];
                LvInfoMaterial.Items.Add(recibioAlmacen);

                ListViewItem fechaRecibidoAlmacenItem = new ListViewItem("Fecha recibido en almacén: ");
                fechaRecibidoAlmacenItem.SubItems.Add(Global.FechaATexto(fechaRecibidoAlmacen));
                fechaRecibidoAlmacenItem.Group = LvInfoMaterial.Groups["Almacen"];
                LvInfoMaterial.Items.Add(fechaRecibidoAlmacenItem);
            }

            //===== Mantenimiento =======================================================
            ListViewItem estatusMantenimiento = new ListViewItem("Estatus: ");
            if(idOrdenMantenimiento == 0)
            {
                estatusMantenimiento.SubItems.Add("N/A");
                estatusMantenimiento.Group = LvInfoMaterial.Groups["Mantenimiento"];
                LvInfoMaterial.Items.Add(estatusMantenimiento);
            } 

            OrdenTrabajoMantenimiento ordenesMantenimiento = new OrdenTrabajoMantenimiento();
            ordenesMantenimiento.CargarDatos(idOrdenMantenimiento);
            if (ordenesMantenimiento.TieneFilas())
            {
                estatusMantenimiento.SubItems.Add(Global.ObjetoATexto(ordenesMantenimiento.Fila().Celda("estatus"), "N/A"));
                estatusMantenimiento.Group = LvInfoMaterial.Groups["Mantenimiento"];
                LvInfoMaterial.Items.Add(estatusMantenimiento);

                ListViewItem descripcionMantenimiento = new ListViewItem("Descripción: ");
                descripcionMantenimiento.SubItems.Add(ordenesMantenimiento.Fila().Celda<string>("puntos_reparacion"));
                descripcionMantenimiento.Group = LvInfoMaterial.Groups["Mantenimiento"];
                LvInfoMaterial.Items.Add(descripcionMantenimiento);

                ListViewItem solicitadoMantenimiento = new ListViewItem("Requisitor: ");
                solicitadoMantenimiento.SubItems.Add(ordenesMantenimiento.Fila().Celda<string>("solicitado_por"));
                solicitadoMantenimiento.Group = LvInfoMaterial.Groups["Mantenimiento"];
                LvInfoMaterial.Items.Add(solicitadoMantenimiento);

                ListViewItem fechaRegistroMantenimiento = new ListViewItem("Fecha de registro: ");
                fechaRegistroMantenimiento.SubItems.Add(Global.FechaATexto(ordenesMantenimiento.Fila().Celda("fecha_registro")));
                fechaRegistroMantenimiento.Group = LvInfoMaterial.Groups["Mantenimiento"];
                LvInfoMaterial.Items.Add(fechaRegistroMantenimiento);

                ListViewItem fechaTerminoMantenimiento = new ListViewItem("Fecha de terminación: ");
                fechaTerminoMantenimiento.SubItems.Add(Global.FechaATexto(ordenesMantenimiento.Fila().Celda("fecha_terminado")));
                fechaTerminoMantenimiento.Group = LvInfoMaterial.Groups["Mantenimiento"];
                LvInfoMaterial.Items.Add(fechaTerminoMantenimiento);
            }

            if (comentarios_autorizacion != null)
                TxtComentariosAutorizacion.Text = comentarios_autorizacion.ToString();
            else
                TxtComentariosAutorizacion.Text = "";

            if (comentarios_requisitor != null)
                TxtComentariosRequisitor.Text = comentarios_requisitor.ToString();
            else
                TxtComentariosRequisitor.Text = "";
        }

        private void CargarArchivos()
        {
            ArchivosActaules = 0;
            string nombreArchivo = "";
            DgvArchivos.Rows.Clear();
            RequisicionAdjunto requisiciones = new RequisicionAdjunto();
            requisiciones.SeleccionarRequisiciones(Id).ForEach(delegate(Fila f)
            {
                ImageConverter converter = new ImageConverter();
                byte[] miniatura = null;

                if (f.Celda("nombre_archivo").ToString().ToLower().Contains(".pdf"))
                {
                    nombreArchivo = f.Celda("nombre_archivo").ToString();
                    object objMiniatura = f.Celda("archivo");

                    if (objMiniatura != null)
                    {
                        miniatura = (byte[])objMiniatura;
                        Image imagenOriginal = Global.ByteAImagen(FormatosPDF.MiniaturaPDFByte(miniatura));//Global.ByteAImagen(miniatura);
                        miniatura = Global.CambiarTamanoImagen(imagenOriginal, new Size(90, 90));
                    }
                    else
                        miniatura = Global.CambiarTamanoImagen(CB_Base.Properties.Resources.downloadPdf_gray, new Size(90, 90));
                }
                else
                {
                    nombreArchivo = f.Celda("nombre_archivo").ToString();
                    miniatura = Global.CambiarTamanoImagen(CB_Base.Properties.Resources.activities, new Size(90,90));
                }

                DgvArchivos.Rows.Add(f.Celda("id"), nombreArchivo, miniatura);
                ArchivosActaules++;
            });
        }

        private void HabilitarMenu()
        {
            int mouseX = Cursor.Position.X;
            int mouseY = Cursor.Position.Y;
            MenuOpciones.Show(mouseX,mouseY);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string archivos = "";
            string texto = "";

            int numeroArchivos = 0;
            int rowCount = 0;

            RequisicionAdjunto requisiciones = new RequisicionAdjunto();

            foreach (DataGridViewRow row in DgvArchivos.SelectedRows)
            {
                archivos +=  row.Cells["nombre_archivo"].Value.ToString() + "\r\n";
                numeroArchivos++;
            }

            if (numeroArchivos > 1)
                texto = "¿Seguro que desea borrar los siguientes archivos?\r\n";
            else
                texto = "¿Seguro que desea borrar el siguiente archivo?\r\n";

            DialogResult respuesta = MessageBox.Show(texto + archivos, "Eliminar actividad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                if (respuesta != DialogResult.Yes)
                    return;

                foreach (DataGridViewRow row in DgvArchivos.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["id_archivo"].Value);
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("id", id);
                    requisiciones.SeleccionarDatos(" id=@id",parametros);
                    if (requisiciones.TieneFilas())
                    {
                        requisiciones.BorrarDatos(id);
                        requisiciones.GuardarDatos();
                    }
                    rowCount++;
                }
                CargarArchivos();
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* byte[] datosArchivo;
             int archivoContador = 0;
             int nuevosArchivos = 0;

             string archivosRepeditos = "";
             string msg = "El siguiente archivo ya existe:\r\n";

             RequisicionAdjunto requisicion = new RequisicionAdjunto();*/
            BtnSalir.Enabled = false;
            BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = true;
            OpenFileDialog subirArchivo = new OpenFileDialog();
            subirArchivo.Multiselect = true;
            subirArchivo.Filter = "Todos (*.*)|*.*";

            if (subirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BkgSubirArchivo.RunWorkerAsync(subirArchivo.FileNames);
               /* foreach (string nombreArchivo in subirArchivo.SafeFileNames) 
                {                    
                    requisicion.ExisteArchivo(Id, nombreArchivo);

                    if (!requisicion.TieneFilas())
                    {
                        datosArchivo = File.ReadAllBytes(nombreArchivo);
                        
                        Fila archivo = new Fila();
                        archivo.AgregarCelda("requisicion_compra", Id);
                        archivo.AgregarCelda("nombre_archivo", nombreArchivo);
                        archivo.AgregarCelda("archivo", datosArchivo);
                        RequisicionAdjunto.Modelo().Insertar(archivo);
                        nuevosArchivos++;
                    }
                   else
                    {
                        archivosRepeditos += nombreArchivo + "\r\n";
                        archivoContador++; 
                    }
                }   
                
                if(archivosRepeditos != "")
                {
                    if (archivoContador > 1)
                        msg = "Los siguientes archivos ya existen:\r\n";

                    MessageBox.Show(msg + archivosRepeditos, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                int actual = ArchivosActaules;

                CargarArchivos();

                if (ScrollPosicion != 0 && ScrollPosicion < DgvArchivos.Rows.Count)
                    DgvArchivos.FirstDisplayedScrollingRowIndex = ScrollPosicion;

                DgvArchivos.Rows[0].Selected = false;
                for(int i = actual ; i < DgvArchivos.Rows.Count; i++)
                {
                    DgvArchivos.Rows[i].Selected = true;
                }*/
            }
            else
            {
                BtnSalir.Enabled = true;
            }
        }

        private void DgvArchivos_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvActividades = DgvArchivos.HitTest(e.X, e.Y);

            if (DgvArchivos.SelectedRows.Count <= 0 || clickDgvActividades.Type == DataGridViewHitTestType.None)
           {
               if (e.Button == MouseButtons.Right)
               {
                   borrarToolStripMenuItem.Enabled = false;
                   if (clickDgvActividades.Type == DataGridViewHitTestType.None)
                       DgvArchivos.ClearSelection();          
                   HabilitarMenu();
               }
               else if (e.Button == MouseButtons.Left || clickDgvActividades.Type == DataGridViewHitTestType.None)
               {
                   DgvArchivos.ClearSelection();
                   borrarToolStripMenuItem.Enabled = false;
               }
           }
        }

        private void DgvArchivos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    HabilitarMenu();   
                }
            }
        }

        private void DgvArchivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int guardarScroll = 0;
                if (DgvArchivos.Rows.Count > 0)
                    guardarScroll = DgvArchivos.FirstDisplayedCell.RowIndex;

                ScrollPosicion = guardarScroll;
                borrarToolStripMenuItem.Enabled = true;
            }
        }

        private void DgvArchivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int id = Convert.ToInt32(DgvArchivos.SelectedRows[0].Cells[0].Value);
                RequisicionAdjunto requisiciones = new RequisicionAdjunto();

                requisiciones.CargarDatos(id);
                if (requisiciones.Fila().Celda("nombre_archivo").ToString().ToLower().EndsWith(".pdf"))
                {
                    FrmVisorPDF pdf = new FrmVisorPDF((byte[])requisiciones.Fila().Celda("archivo"), requisiciones.Fila().Celda("nombre_archivo").ToString().Split('.')[0]);
                    pdf.ShowDialog();
                }
                else
                {
                    SaveFileDialog guardarArchivo = new SaveFileDialog();
                    string nombreArchivo = requisiciones.Fila().Celda("nombre_archivo").ToString();
                    string[] spArchivo = nombreArchivo.Split('.');
                    string extension = spArchivo[spArchivo.Count() - 1];

                    guardarArchivo.Title = "Guardar archivo " + nombreArchivo;
                    guardarArchivo.FilterIndex = 2;
                    guardarArchivo.RestoreDirectory = true;
                    guardarArchivo.FileName = nombreArchivo + "." + extension;
                    guardarArchivo.Filter = "All files (*.*)|*.*";

                    if (guardarArchivo.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(guardarArchivo.FileName, (byte[])requisiciones.Fila().Celda("archivo"));
                    }
                }
            }
        }

        private void BkgSubirArchivo_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] datosArchivo;
            string[] archivos = (string[])e.Argument;
            int archivoContador = 0;
            int nuevosArchivos = 0;
            int avance = 0;

            string archivosRepeditos = "";
            RequisicionAdjunto requisicion = new RequisicionAdjunto();
            

            foreach (string nombreArchivo in archivos)
            {
                requisicion.ExisteArchivo(Id, nombreArchivo);

                if (!requisicion.TieneFilas())
                {
                    datosArchivo = File.ReadAllBytes(nombreArchivo);

                    Fila archivo = new Fila();
                    archivo.AgregarCelda("requisicion_compra", Id);
                    archivo.AgregarCelda("nombre_archivo", Path.GetFileName(nombreArchivo));
                    archivo.AgregarCelda("archivo", datosArchivo);
                    RequisicionAdjunto.Modelo().Insertar(archivo);
                    nuevosArchivos++;
                }
                else
                {
                    archivosRepeditos += nombreArchivo + "\r";
                    archivoContador++;
                }
                avance++;
                BkgSubirArchivo.ReportProgress(Global.CalcularPorcentaje(avance, archivos.Count()), "Subiendo archivo...");
            }

            e.Result = archivosRepeditos;
            
        }

        private void BkgSubirArchivo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatusAsignaciones.Text = e.UserState.ToString();
            BarraProgresoAsignaciones.Value = e.ProgressPercentage;
        }


        private void BkgSubirArchivo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string msg = "El siguiente archivo ya existe:\r\n";
            string archivosRepeditos = e.Result.ToString();


            if (archivosRepeditos != "")
            {
                int archivoContador = archivosRepeditos.Split('\r').Count();
                if (archivoContador > 1)
                    msg = "Los siguientes archivos ya existen:\r\n";

                MessageBox.Show(msg + archivosRepeditos, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            int actual = ArchivosActaules;

            CargarArchivos();

            if (ScrollPosicion != 0 && ScrollPosicion < DgvArchivos.Rows.Count)
                DgvArchivos.FirstDisplayedScrollingRowIndex = ScrollPosicion;

            DgvArchivos.Rows[0].Selected = false;
            for (int i = actual; i < DgvArchivos.Rows.Count; i++)
            {
                DgvArchivos.Rows[i].Selected = true;
            }

            BtnSalir.Enabled = true;
            BarraProgresoAsignaciones.Visible = false;
            LblEstatusAsignaciones.Text = "Archivos adjuntados";
        }
    }
}
