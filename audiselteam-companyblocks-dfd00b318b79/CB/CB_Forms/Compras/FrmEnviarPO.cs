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
using System.Net.Mail;
using System.IO;

namespace CB
{
    public partial class FrmEnviarPO : Form
    {
        int IdContacto = 0;
        int IdProveedor = 0;
        int IdPO = 0;
        int ScrollPosicion = 0;
        int ScrollPosicionAdjuntos = 0;
        int RowIndex = 0;
        int RowIndexAdjuntos = 0;
        bool EnviarCorreo = true;
        public byte[] Archivo = null;
        public byte[] ArchivoReporte = null;


        PoMaterial Po = new PoMaterial();
        List<Tuple<string,string>> CorreoDefault = new List<Tuple<string,string>>();  
        List<string> AdjuntosPorDefault = new List<string>();
        Dictionary<string, byte[]> ArchivosAdjuntos = new Dictionary<string, byte[]>();      

        public FrmEnviarPO(int idPO)
        {
            IdPO = idPO;
            InitializeComponent();
            Po.CargarDatos(IdPO);
        }

        private void FrmEnviarPO_Load(object sender, EventArgs e)
        {
            IdProveedor = Convert.ToInt32(Po.Fila().Celda("proveedor"));
            Proveedor prov = new Proveedor();
            prov.CargarDatos(IdProveedor);

            TxtDe.Text = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();
            TxtProveedor.Text = prov.Fila().Celda("nombre").ToString();

            CmbFormato.Text = "ESTADOS UNIDOS";
            CmbMoneda.Text = Po.Fila().Celda("moneda").ToString();

            CmbContacto.Items.Clear();
            ProveedorContacto.Modelo().CargarDeProveedor(IdProveedor).ForEach(delegate(Fila contacto)
            {
                int IdContacto = Convert.ToInt32(contacto.Celda("id"));
                CmbContacto.Items.Add(IdContacto.ToString() + " - " + contacto.Celda("nombre").ToString() + " " + contacto.Celda("apellidos").ToString());

                DgvContactosCopia.Rows.Add(IdContacto, false, contacto.Celda("nombre").ToString() + " " + contacto.Celda("apellidos").ToString(), contacto.Celda("correo").ToString());
            });

            CmbDireccionEntrega.Items.Clear();
            CmbDireccionFacturacion.Items.Clear();
            Direccion.Modelo().SeleccionarDatos("").ForEach(delegate(Fila f)
            {
                CmbDireccionEntrega.Items.Add(f.Celda("nombre").ToString());
                CmbDireccionFacturacion.Items.Add(f.Celda("nombre").ToString());
            });

            BtnEnviar.Enabled = ValidarDatos();

            CargarAdjuntosRequisicion();
            AdjuntarCorreoDefault();
            MostrarTerminosPago();

            if(DgvTerminoPago.Rows.Count == 0)
            {
                InsertarTerminoDefault();
            }
        }

        public void CargarAdjuntosRequisicion()
        {
            Dictionary<string,object> parametros = new Dictionary<string,object>();
            parametros.Add("@po", Convert.ToInt32(Po.Fila().Celda("id")));

            // por cada requisicion de compra vinculada con la po
            MaterialProyecto.Modelo().SeleccionarDatos("po=@po", parametros).ForEach(delegate(Fila requisicion)
            {
                int idRequisicion = Convert.ToInt32(requisicion.Celda("id"));

                // por cada archivo adjunto en la requisicion de compra actual
                RequisicionAdjunto.Modelo().SeleccionarRequisiciones(idRequisicion).ForEach(delegate(Fila archivoAdjunto)
                {
                    string nombreArchivo = archivoAdjunto.Celda("nombre_archivo").ToString();
                    byte[] datosArchivo = (byte[])archivoAdjunto.Celda("archivo");

                    // agrega el archivo actual al diccionario de archivos adjuntos y a la lista de 
                    // archivos adjuntos por default para que no pueda ser borrado por el usuario
                    if (!ArchivosAdjuntos.ContainsKey(nombreArchivo))
                    {
                        ArchivosAdjuntos.Add(nombreArchivo, datosArchivo);
                        AdjuntosPorDefault.Add(nombreArchivo);
                    }                 
                });
            });

            // actualiza el datagridview de los archivos adjuntos de acuerdo al diccionario
            foreach (KeyValuePair<string, byte[]> archivo in ArchivosAdjuntos)
            {
                DgvAdjuntos.Rows.Add(archivo.Key);
            }
        }
        
        public void InsertarTerminoDefault()
        {
            int terminoAnterior = 0;
            TerminoPagoProveedor terminos = new TerminoPagoProveedor();
            terminos.CargarDatosPO(0, IdProveedor);
            if (terminos.TieneFilas())
            {
                terminos.CargarDatosPO(0, IdProveedor).ForEach(delegate(Fila f)
                {
                    Fila agregarTermino = new Fila();
                    agregarTermino.AgregarCelda("po", IdPO);
                    agregarTermino.AgregarCelda("proveedor", IdProveedor);
                    agregarTermino.AgregarCelda("porcentaje", Convert.ToInt32(f.Celda("porcentaje")));
                    agregarTermino.AgregarCelda("terminos", f.Celda("terminos"));
                    agregarTermino.AgregarCelda("anterior", terminoAnterior);
                    TerminoPagoProveedor.Modelo().Insertar(agregarTermino);
                    terminoAnterior++;
                });
            }
            MostrarTerminosPago();
        }

        public void MostrarAdjuntos()
        {
            DgvAdjuntos.Rows.Clear();
            BtnBorrarAdjunto.Enabled = false;

            foreach (KeyValuePair<string, byte[]> archivo in ArchivosAdjuntos)
            {
                DgvAdjuntos.Rows.Add(archivo.Key);
            }
        }

        public void MostrarTerminosPago()
        {
            DgvTerminoPago.Rows.Clear();
            TerminoPagoProveedor terminos = new TerminoPagoProveedor();
            terminos.CargarDatosPO(IdPO, IdProveedor);
            if (terminos.TieneFilas())
            {
                terminos.CargarDatosPO(IdPO, IdProveedor).ForEach(delegate(Fila f)
                {
                    DgvTerminoPago.Rows.Add(Convert.ToInt32(f.Celda("id").ToString()), Convert.ToInt32(f.Celda("porcentaje").ToString()) + " %", f.Celda("terminos").ToString());
                });
            }            
            if (ScrollPosicion != 0 && ScrollPosicion < DgvTerminoPago.Rows.Count)
                DgvTerminoPago.FirstDisplayedScrollingRowIndex = ScrollPosicion;         
        }

        public bool ValidarDatos()
        {
            return CmbFormato.Text != "" && CmbContacto.Text != "" && CmbDireccionEntrega.Text != "" && CmbDireccionFacturacion.Text != "" && !HabilitarPorcentaje();
        }

        public void MostrarPO(string formato, int po, int contacto)
        {
            int idUsuario = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));
            PoMaterial poMat = new PoMaterial();
            poMat.CargarDatos(po);

            switch (formato)
            {
                case "MEXICO":
                    Archivo = FormatosPDF.POMaterial_MX(idUsuario, contacto, CmbDireccionEntrega.Text, CmbDireccionFacturacion.Text, TxtNotas.Text, poMat, NumPorcentajeImpuestos.Value, NumPorcentajeDescuento.Value, NumOtrosCargos.Value, CmbMoneda.Text);
                    break;
                case "ESTADOS UNIDOS":
                    Archivo = FormatosPDF.POMaterial_US(idUsuario, contacto, CmbDireccionEntrega.Text, CmbDireccionFacturacion.Text, TxtNotas.Text, poMat, NumPorcentajeImpuestos.Value, NumPorcentajeDescuento.Value, NumOtrosCargos.Value, CmbMoneda.Text);
                    break;
                case "EUROPA":
                    Archivo = FormatosPDF.POMaterial_EUR(idUsuario, contacto, CmbDireccionEntrega.Text, CmbDireccionFacturacion.Text, TxtNotas.Text, poMat, NumPorcentajeImpuestos.Value, NumPorcentajeDescuento.Value, NumOtrosCargos.Value, CmbMoneda.Text);
                    break;
            }

            ArchivoReporte = FormatosPDF.ReporteCompra_Material(idUsuario, contacto, CmbDireccionEntrega.Text, CmbDireccionFacturacion.Text, TxtNotas.Text, poMat, NumPorcentajeImpuestos.Value, NumPorcentajeDescuento.Value, NumOtrosCargos.Value, CmbMoneda.Text);

            Global.MostrarPDF(Archivo, "AUD-PO-" + po.ToString(), null, VisorPDF);
        }

        private void AdjuntarCorreoDefault()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@superUser", "SUPERUSER");
            parametros.Add("@liderProyecto", "LIDER DE PROYECTO");
            parametros.Add("@auxiliarFinanzas", "AUXILIAR DE FINANZAS");
            parametros.Add("@comprador", "COMPRADOR");
            parametros.Add("@coordinadorFinanzas", "COORDINADOR DE FINANZAS");
            parametros.Add("@coordinadorOperaciones", "COORDINADOR DE OPERACIONES");
            parametros.Add("@activo", 1);

            //OR rol=@liderProyecto
            Usuario.Modelo().SeleccionarDatos("(rol=@superUser OR rol=@auxiliarFinanzas OR rol=@comprador OR rol=@coordinadorFinanzas OR rol= @coordinadorOperaciones) AND activo=@activo", parametros).ForEach(delegate(Fila f)
            {
                DgvContactosCopia.Rows.Add(f.Celda("id").ToString(), true, f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString(), f.Celda("correo").ToString());
                DgvContactosCopia.Rows[DgvContactosCopia.RowCount - 1].Cells["seleccion"].ReadOnly = true;
            });
        }

        public void HabilitarMenuTerminPago()
        {
            TerminoPagoProveedor termino = new TerminoPagoProveedor();
            termino.CargarDatosPO(0, IdProveedor);

            agregarToolStripMenuItem.Enabled = HabilitarPorcentaje();

            if (DgvTerminoPago.SelectedRows.Count > 1)
                editarToolStripMenuItem.Enabled = false;
            else
                editarToolStripMenuItem.Enabled = true;

            borrarToolStripMenuItem.Enabled = true;
            volverADefaultToolStripMenuItem.Enabled = termino.TieneFilas();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            DialogResult respuesa = MessageBox.Show("Seguro que deseas enviar la PO al proveedor?", "Enviar PO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (respuesa == System.Windows.Forms.DialogResult.Yes)
            {
                string asunto = "";
                if (CmbFormato.Text == "ESTADOS UNIDOS" || CmbFormato.Text == "EUROPA")
                    asunto = "PURCHASE ORDER #";
                else if (CmbFormato.Text == "MEXICO")
                    asunto = "ORDEN DE COMPRA # ";

                asunto += Po.Fila().Celda("id").ToString();

                string nombreArchivo = "AUD-PO-" + Po.Fila().Celda("id").ToString() + ".pdf";

                int revision = Convert.ToInt32(Po.Fila().Celda("revision"));
                if (revision > 0)
                {
                    asunto += ", REV. " + revision.ToString();
                    nombreArchivo = "AUD-PO-" + Po.Fila().Celda("id").ToString() + ", REV " + revision.ToString() + ".pdf";
                }

                string contenido = TxtCuerpoCorreo.Text;

                ProveedorContacto contacto = new ProveedorContacto();
                contacto.CargarDatos(IdContacto);

                List<Attachment> Adjunto = new List<Attachment>();
                Adjunto.Add(new Attachment(new MemoryStream(Archivo), nombreArchivo));
                foreach (KeyValuePair<string, byte[]> archivoAdjunto in ArchivosAdjuntos)
                {
                    Adjunto.Add(new Attachment(new MemoryStream(archivoAdjunto.Value), archivoAdjunto.Key));
                }

                List<string> copias = new List<string>();
                List<string> copiaProveedor = new List<string>();
                string verificarCorreo = "";

                foreach (DataGridViewRow cont in DgvContactosCopia.Rows)
                {
                    if (Convert.ToBoolean(cont.Cells["seleccion"].Value) == true)
                    {
                        verificarCorreo = cont.Cells["correo"].Value.ToString();
                        if (verificarCorreo.Contains("@audisel"))
                            copiaProveedor.Add(verificarCorreo);
                        else
                            copias.Add(verificarCorreo);
                    }
                }
                try
                {
                    //enviar po
                    if (EnviarCorreo)
                    {
                        if(Global.EnviarCorreo(asunto, contenido, contacto.Fila().Celda("correo").ToString(), copias, Adjunto, copiaProveedor))
                        {
                            GuardarDatos();
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                    }
                    else
                    {
                        GuardarDatos();
                         MessageBox.Show("PO enviada correctamente", "PO enviada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }

                    MessageBox.Show("Se enviará un reporte de compra a los líderes de proyecto");

                    PoMaterial poMat = new PoMaterial();
                    poMat.CargarDatos(Convert.ToInt32(Po.Fila().Celda("id")));
                    int idUsuario = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));
                    bool primer = true;
                    string para = string.Empty;
                    copias.Clear();
                    asunto = "REPORTE DE COMPRA: PO";
                    asunto += Po.Fila().Celda("id").ToString();
                    contenido = "Reporte generado por " + Global.UsuarioActual.NombreCompleto() + " el día " + DateTime.Today.Date;
                    nombreArchivo = "REPORTE DE COMPRA PO-" + Po.Fila().Celda("id").ToString() + ".pdf";

                    Adjunto.Clear();
                    Adjunto.Add(new Attachment(new MemoryStream(ArchivoReporte), nombreArchivo));

                    Usuario lideres = new Usuario();
                    lideres.SeleccionarRolActivos("LIDER DE PROYECTO").ForEach(delegate (Fila f)
                    {
                        if (primer)
                        {
                            para = f.Celda("correo").ToString();
                            primer = false;
                        }
                        else
                            copias.Add(f.Celda("correo").ToString());
                        
                    });

                    //enviar reporte de compras
                    try
                    {
                        Global.EnviarCorreo(asunto, contenido, para, copias, Adjunto, null);
                    }
                    catch
                    {
                        //evitar errores
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void GuardarDatos()
        {
            Fila archivoPdf = new Fila();
            archivoPdf.AgregarCelda("po", Po.Fila().Celda("id"));
            archivoPdf.AgregarCelda("archivo", Archivo);
            archivoPdf.AgregarCelda("revision", Po.Fila().Celda("revision"));
            ArchivoPo.Modelo().Insertar(archivoPdf);

            MaterialProyecto mat = new MaterialProyecto();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("po", Po.Fila().Celda("id"));
            mat.SeleccionarDatos("po=@po", parametros);
            mat.Filas().ForEach(delegate(Fila f)
            {
                int tiempoDeEntrega = Convert.ToInt32(f.Celda("tiempo_entrega"));
                DateTime eta = DateTime.Now.AddDays(tiempoDeEntrega);

                if (eta.DayOfWeek == DayOfWeek.Saturday || eta.DayOfWeek == DayOfWeek.Sunday)
                    Global.SiguienteDiaSemana(eta, DayOfWeek.Monday).AddDays(2);
                else
                    eta.AddDays(2);

                if (f.Celda("estatus_compra").ToString() != "RECIBIDO" && f.Celda("estatus_compra").ToString() != "ENTREGADO")
                {
                    f.ModificarCelda("estatus_compra", "ORDENADO");
                    f.ModificarCelda("estatus_almacen", "SIN RECIBIR");
                    f.ModificarCelda("eta", eta);
                    f.ModificarCelda("fecha_compra", DateTime.Now);
                }
            });
            mat.GuardarDatos();

            Po.Fila().ModificarCelda("estatus", "ENVIADO");
            Po.GuardarDatos();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
        }   

        private void CmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbContacto.Text != "")
            {
                IdContacto = Convert.ToInt32(CmbContacto.Text.Split('-')[0]);

                ProveedorContacto cont = new ProveedorContacto();
                cont.CargarDatos(IdContacto);

                bool enviarCorreo = cont.Fila().Celda("correo").ToString() != "";

                chkEnviarCorreo.Checked = enviarCorreo;
                chkEnviarCorreo.Enabled = enviarCorreo;

                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
            BtnEnviar.Enabled = ValidarDatos();
        }

        private void CmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFormato.Text == "MEXICO")
            {
                NumPorcentajeImpuestos.Value = 16;
                TxtCuerpoCorreo.Text = "Estimado proveedor, favor de procesar la orden de compra adjunta en este correo electrónico.";
            }
            else if (CmbFormato.Text == "ESTADOS UNIDOS")
            {
                NumPorcentajeImpuestos.Value = 6.25M;
                TxtCuerpoCorreo.Text = "Dear supplier, please process the purchase order attached in this e-mail.";
            }
            else if (CmbFormato.Text == "EUROPA")
            {
                NumPorcentajeImpuestos.Value = 21.48M;
                TxtCuerpoCorreo.Text = "Dear supplier, please process the purchase order attached in this e-mail.";
            }

            if (CmbContacto.Text != "")
            {
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
            BtnEnviar.Enabled = ValidarDatos();
        }

        private void CmbDireccionEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbContacto.Text != "")
            {
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
            BtnEnviar.Enabled = ValidarDatos();
        }

        private void CmbDireccionFacturacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbContacto.Text != "")
            {
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
            BtnEnviar.Enabled = ValidarDatos();
        }

        private void CmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbContacto.Text != "")
            {
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
            BtnEnviar.Enabled = ValidarDatos();
        }

        private void BtnAdjuntar_Click(object sender, EventArgs e)
        {
            if (SeleccionarAdjunto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = SeleccionarAdjunto.FileName;
                byte[] datos = File.ReadAllBytes(fileName);

                if (ArchivosAdjuntos.ContainsKey(SeleccionarAdjunto.SafeFileName))
                {
                    MessageBox.Show("Este archivo ya fue incluido anteriormente!");
                    return;
                }
                ArchivosAdjuntos.Add(BuscarIdPlano(SeleccionarAdjunto.SafeFileName.ToString()), datos);
                MostrarAdjuntos();
                DgvAdjuntos.ClearSelection();
                DgvAdjuntos.FirstDisplayedScrollingRowIndex = DgvAdjuntos.Rows.Count - 1;
                DgvAdjuntos.Rows[DgvAdjuntos.Rows.Count - 1].Selected = true;
            }
        }

        private string BuscarIdPlano(string nombreArchivo)
        {
            string extension = Path.GetExtension(nombreArchivo);
            string nombrePlano = Path.GetFileNameWithoutExtension(nombreArchivo);

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombrePlano", nombrePlano);

            PlanoProyecto plano = new PlanoProyecto();
            plano.SeleccionarDatos("nombre_archivo=@nombrePlano", parametros);

            if (plano.TieneFilas())
                return "ID-" + plano.Fila().Celda("id").ToString().PadLeft(6, '0') + extension;
            else
                return nombrePlano;
        }

        private void DgvAdjuntos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int guardarScroll = 0;

                if (DgvAdjuntos.SelectedRows.Count > 0)
                {
                    if (!AdjuntosPorDefault.Contains(DgvAdjuntos.Rows[e.RowIndex].Cells[0].Value))
                        BtnBorrarAdjunto.Enabled = true;
                    else
                        BtnBorrarAdjunto.Enabled = false; 
                }

                if (DgvAdjuntos.Rows.Count > 0)
                    guardarScroll = DgvAdjuntos.FirstDisplayedCell.RowIndex;

                ScrollPosicionAdjuntos = guardarScroll;
                RowIndexAdjuntos = DgvAdjuntos.CurrentCell.RowIndex;
            }
        }

        private void BtnBorrarAdjunto_Click(object sender, EventArgs e)
        {
            string archivo = "";

            if (DgvAdjuntos.SelectedRows.Count > 0)
            {
                archivo = DgvAdjuntos.SelectedRows[0].Cells["nombre_archivo"].Value.ToString();

                if (ArchivosAdjuntos.ContainsKey(archivo))
                    ArchivosAdjuntos.Remove(archivo);
            }
            MostrarAdjuntos();
        }

        private void chkEnviarCorreo_CheckedChanged(object sender, EventArgs e)
        {
            EnviarCorreo = Convert.ToBoolean(chkEnviarCorreo.Checked);

            TxtCuerpoCorreo.Enabled = EnviarCorreo;
            DgvContactosCopia.Enabled = EnviarCorreo;
            DgvAdjuntos.Enabled = EnviarCorreo;
            BtnAdjuntar.Enabled = EnviarCorreo;
        }

        private void DgvAdjuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                string nombreArchivo = ArchivosAdjuntos.ElementAt(e.RowIndex).Key;
                byte[] datosArchivo = ArchivosAdjuntos.ElementAt(e.RowIndex).Value;

                string[] partesNombre = nombreArchivo.Split('.');
                string extension = partesNombre[partesNombre.Count() - 1];

                if (extension.ToUpper() == "PDF")
                {
                    FrmVisorPDF pdf = new FrmVisorPDF(datosArchivo, nombreArchivo);
                    pdf.ShowDialog();
                }
                else
                {
                    SaveFileDialog guardarArchivo = new SaveFileDialog();

                    guardarArchivo.Title = "Guardar archivo " + nombreArchivo;
                    guardarArchivo.FilterIndex = 2;
                    guardarArchivo.RestoreDirectory = true;
                    guardarArchivo.FileName = nombreArchivo;
                    guardarArchivo.Filter = "All files (*.*)|*.*";

                    if (guardarArchivo.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(guardarArchivo.FileName, datosArchivo);
                    }
                }
                DgvAdjuntos.ClearSelection();
                DgvAdjuntos.FirstDisplayedScrollingRowIndex = RowIndexAdjuntos;
                DgvAdjuntos.Rows[RowIndexAdjuntos].Selected = true;
            }
        }

        private void DgvTerminoPago_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvTerminoPago = DgvTerminoPago.HitTest(e.X, e.Y);
            TerminoPagoProveedor termino = new TerminoPagoProveedor();
            termino.CargarDatosPO(0, IdProveedor);

            if (clickDgvTerminoPago.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    agregarToolStripMenuItem.Enabled = HabilitarPorcentaje();
                    editarToolStripMenuItem.Enabled = false;
                    borrarToolStripMenuItem.Enabled = false;
                    volverADefaultToolStripMenuItem.Enabled = termino.TieneFilas();
                    MenuTerminosPago.Show(mouseX, mouseY);
                }
                DgvTerminoPago.ClearSelection();
            }                     
        }


        private void DgvTerminoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int guardarScroll = 0;

                HabilitarMenuTerminPago();

                if (DgvTerminoPago.Rows.Count > 0)
                    guardarScroll = DgvTerminoPago.FirstDisplayedCell.RowIndex;

                ScrollPosicion = guardarScroll;
                RowIndex = DgvTerminoPago.CurrentCell.RowIndex;
            }
        }

        private void DgvTerminoPago_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right && DgvTerminoPago.SelectedRows.Count != 0)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    HabilitarMenuTerminPago();
                    MenuTerminosPago.Show(mouseX, mouseY);
                }
            }
        }

        public bool HabilitarPorcentaje()
        {
            int porcentaje = 0;
            TerminoPagoProveedor termino = new TerminoPagoProveedor();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@po", IdPO);
            parametros.Add("@proveedor", IdProveedor);

            termino.SeleccionarDatos("po=@po AND @proveedor=@proveedor", parametros,"SUM(porcentaje) AS suma").ForEach(delegate(Fila f)
            {
                if (f.Celda("suma") != null)
                    porcentaje = Convert.ToInt32(f.Celda("suma").ToString());
            });

            if (porcentaje >= 100)
                return false;
            else
                return true;
        }

        public int ObtenerPorcentajeMaximo()
        {
            TerminoPagoProveedor termino = new TerminoPagoProveedor();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@po", IdPO);
            parametros.Add("@proveedor", IdProveedor);

            termino.SeleccionarDatos("po=@po and @proveedor=@proveedor", parametros, "SUM(porcentaje) AS suma");
            if (termino.TieneFilas())
            {
                if (termino.Fila().Celda("suma") != null)
                {
                    if (Convert.ToInt32(termino.Fila().Celda("suma").ToString()) > 0)
                    {
                        return 100 - Convert.ToInt32(termino.Fila().Celda("suma").ToString());
                    }
                }
            }
            return 0;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarTerminoPago terminoPago = new FrmAgregarTerminoPago(IdPO,IdProveedor);
            if(terminoPago.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarTerminosPago();
                DgvTerminoPago.ClearSelection();
                DgvTerminoPago.FirstDisplayedScrollingRowIndex = DgvTerminoPago.Rows.Count - 1;
                DgvTerminoPago.Rows[DgvTerminoPago.Rows.Count - 1].Selected = true;
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
                BtnEnviar.Enabled = ValidarDatos();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(DgvTerminoPago.SelectedRows[0].Cells["id_termino"].Value);
            FrmAgregarTerminoPago terminoPago = new FrmAgregarTerminoPago(IdPO, IdProveedor, Convert.ToInt32(DgvTerminoPago.SelectedRows[0].Cells["id_termino"].Value));
            if (terminoPago.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarTerminosPago();
                DgvTerminoPago.ClearSelection();
                DgvTerminoPago.FirstDisplayedScrollingRowIndex = RowIndex;
                DgvTerminoPago.Rows[RowIndex].Selected = true;
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
        }

        private void DgvTerminoPago_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            BtnEnviar.Enabled = ValidarDatos();
        }

        private void volverADefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerminoPagoProveedor terminos = new TerminoPagoProveedor();
            DialogResult volverADefault = MessageBox.Show("Al volver a la configuración por defecto, los términos que haya agregado serán borrados y no podrá recuperarlos, ¿Está seguro que desea cargar los términos por defecto?", "Volver a términos por defecto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (volverADefault == System.Windows.Forms.DialogResult.Yes)
            {
                terminos.CargarDatosPO(IdPO, IdProveedor);
                if (terminos.TieneFilas())
                {
                    TerminoPagoProveedor.Modelo().CargarDatosPO(IdPO, IdProveedor).ForEach(delegate(Fila f)
                    {
                        terminos.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                        terminos.GuardarDatos();
                    });                
                }
                DgvTerminoPago.Rows.Clear();
                InsertarTerminoDefault();
                MostrarTerminosPago();
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
        }


        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string terminosPago = "";
            string texto = "";

            int actividades = 0;
            int rowCount = 0;
            int terminoAnterior = 0;

            TerminoPagoProveedor terminos = new TerminoPagoProveedor();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            foreach (DataGridViewRow row in DgvTerminoPago.SelectedRows)
            {
                terminosPago += "Término: " + row.Cells["termino"].Value.ToString() + " " + row.Cells["porcentaje"].Value.ToString() + "\r\n";
                actividades++;
            }

            if (actividades > 1)
                texto = "¿Seguro que desea borrar estos términos de pago?\r\n";
            else
                texto = "¿Seguro que desea borrar este término de pago?\r\n";

            DialogResult respuesta = MessageBox.Show(texto + terminosPago, "Eliminar actividad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                if (respuesta != DialogResult.Yes)
                    return;

                foreach (DataGridViewRow row in DgvTerminoPago.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["id_termino"].Value);
                    terminos.CargarDatos(id);
                    if (terminos.TieneFilas())
                    {
                        terminos.BorrarDatos(id);
                        terminos.GuardarDatos();
                    }
                    rowCount++;
                }

                parametros.Add("@po", IdPO);
                parametros.Add("@proveedor", IdProveedor);
                terminos.SeleccionarDatos("po=@po AND proveedor=@proveedor ORDER by id asc", parametros);
                if (terminos.TieneFilas())
                {
                    terminos.SeleccionarDatos("po=@po AND proveedor=@proveedor ORDER by id asc", parametros).ForEach(delegate(Fila f)
                    {
                        f.ModificarCelda("anterior", terminoAnterior);
                        terminos.GuardarDatos();
                        terminoAnterior = Convert.ToInt32(f.Celda("id"));
                    });
                }
                MostrarTerminosPago();
                DgvTerminoPago.ClearSelection();
                MostrarPO(CmbFormato.Text, Convert.ToInt32(Po.Fila().Celda("id")), IdContacto);
            }
        }
    }
}
