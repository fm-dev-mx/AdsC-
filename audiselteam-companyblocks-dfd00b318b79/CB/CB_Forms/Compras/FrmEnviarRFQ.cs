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
    public partial class FrmEnviarRFQ : Form
    {
        public RfqMaterial rfq = new RfqMaterial();
        public byte[] Archivo = null;

        private int IdContacto = 0;
        private int ScrollPosicionAdjuntos = 0;
        private int RowIndexAdjuntos = 0;

        private bool EnviarCorreo = true;
        private List<string> AdjuntosPorDefault = new List<string>();
        private Dictionary<string, byte[]> ArchivosAdjuntos = new Dictionary<string, byte[]>();

        public FrmEnviarRFQ(int idRfq)
        {
            InitializeComponent();
            rfq.CargarDatos(idRfq);
        }

        private void FrmPruebaPDF_Load(object sender, EventArgs e)
        {
            int IdRfq = Convert.ToInt32(rfq.Fila().Celda("id"));
            int IdProveedor = Convert.ToInt32(rfq.Fila().Celda("proveedor"));

            Proveedor prov = new Proveedor();
            prov.CargarDatos(IdProveedor);

            TxtProveedor.Text = prov.Fila().Celda("nombre").ToString();
            int Contacto = Convert.ToInt32(prov.Fila().Celda("contacto"));

            TxtDe.Text = Global.ConfiguracionActual.CorreoUsuario;

            CargarContactos(IdProveedor);
            CargarAdjuntosRequisicion();
            AdjuntarCorreoDefault();
        }

        private void AdjuntarCorreoDefault()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@comprador", "COMPRADOR");
            parametros.Add("@activo", 1);

            Usuario.Modelo().SeleccionarDatos("rol=@comprador AND activo=@activo", parametros).ForEach(delegate(Fila f)
            {
                DgvContactosCopia.Rows.Add(f.Celda("id").ToString(),true,f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString(), f.Celda("correo").ToString());
                DgvContactosCopia.Rows[DgvContactosCopia.RowCount - 1].Cells["seleccion"].ReadOnly = true;
            });
        }

        public void CargarAdjuntosRequisicion()
        {
            // por cada concepto del rfq
            RfqConcepto.Modelo().SeleccionarRfq(Convert.ToInt32(rfq.Fila().Celda("id"))).ForEach(delegate(Fila rfqConcepto)
            {
                int idRfqConcepto = Convert.ToInt32(rfqConcepto.Celda("id"));

                // por cada requisicion de compra vinculada con el concepto del rfq
                RfqConcepto.Modelo().DesglosarPorProyecto(idRfqConcepto).ForEach(delegate(Fila requisicionCompra)
                {
                    int idRequisicionCompra = Convert.ToInt32(requisicionCompra.Celda("id"));

                    // por cada archivo adjunto a la requisicion de compra
                    RequisicionAdjunto.Modelo().SeleccionarRequisiciones(idRequisicionCompra).ForEach(delegate(Fila archivo)
                    {
                        string nombreArchivo = archivo.Celda("nombre_archivo").ToString();
                        byte[] datosArchivo = (byte[])archivo.Celda("archivo");

                        // agrega el archivo actual al diccionario de archivos adjuntos y a la lista de 
                        // archivos adjuntos por default para que no pueda ser borrado por el usuario
                        if(!ArchivosAdjuntos.ContainsKey(nombreArchivo))
                        {
                            ArchivosAdjuntos.Add(nombreArchivo, datosArchivo);
                            AdjuntosPorDefault.Add(nombreArchivo);
                        }
                    });
                });
            });

            // actualiza el datagridview de los archivos adjuntos de acuerdo al diccionario
            foreach (KeyValuePair<string, byte[]> archivo in ArchivosAdjuntos)
            {
                DgvAdjuntos.Rows.Add(archivo.Key);
            }
        }

        public void CargarContactos(int IdProveedor)
        {
            CmbContacto.Items.Clear();
            ProveedorContacto.Modelo().CargarDeProveedor(IdProveedor).ForEach(delegate(Fila contacto)
            {
                int IdContacto = Convert.ToInt32(contacto.Celda("id"));
                CmbContacto.Items.Add(IdContacto.ToString() + " - " + contacto.Celda("nombre").ToString() + " " + contacto.Celda("apellidos").ToString());

                DgvContactosCopia.Rows.Add(IdContacto, false, contacto.Celda("nombre").ToString() + " " + contacto.Celda("apellidos").ToString(), contacto.Celda("correo").ToString());
            });
        }

        public void MostrarRFQ(string formato, int rfq, int contacto)
        {
            int idUsuario = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));
            RfqMaterial material = new RfqMaterial();
            material.CargarDatos(rfq);

            if (formato == "MEXICO")
                Archivo = FormatosPDF.RFQMaterial_MX(idUsuario, contacto, TxtNotas.Text, material);
            else if (formato == "ESTADOS UNIDOS")
                Archivo = FormatosPDF.RFQMaterial_US(idUsuario, contacto, TxtNotas.Text, material);

            Global.MostrarPDF(Archivo, "AUD-RFQ-" + rfq.ToString(), null, VisorPDF);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            MostrarRFQ(CmbFormato.Text, Convert.ToInt32(rfq.Fila().Celda("id")), IdContacto);
        }

        private void CmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnActualizar.Enabled = CmbContacto.Text != "";
            BtnEnviar.Enabled = CmbContacto.Text != "";

            if( CmbContacto.Text != "")
            {
                IdContacto = Convert.ToInt32(CmbContacto.Text.Split('-')[0]);

                ProveedorContacto cont = new ProveedorContacto();
                cont.CargarDatos(IdContacto);

                bool enviarCorreo = cont.Fila().Celda("correo").ToString() != "";

                chkEnviarCorreo.Checked = enviarCorreo;
                chkEnviarCorreo.Enabled = enviarCorreo;

                MostrarRFQ(CmbFormato.Text, Convert.ToInt32(rfq.Fila().Celda("id")), IdContacto);
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            MostrarRFQ(CmbFormato.Text, Convert.ToInt32(rfq.Fila().Celda("id")), IdContacto);

            DialogResult respuesta = MessageBox.Show("Seguro que deseas enviar el RFQ al proveedor?", "Enviar RFQ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( respuesta == System.Windows.Forms.DialogResult.Yes )
            {
                string asunto = "";
                if (CmbFormato.Text == "ESTADOS UNIDOS")
                    asunto = "REQUEST FOR QUOTE #";
                else if (CmbFormato.Text == "MEXICO")
                    asunto = "SOLICITUD DE COTIZACION #";
                asunto += rfq.Fila().Celda("id").ToString();

                string contenido = TxtCuerpoCorreo.Text; 

                ProveedorContacto contacto = new ProveedorContacto();
                contacto.CargarDatos(IdContacto);

                List<Attachment> Adjunto = new List<Attachment>();
                Adjunto.Add( new Attachment( new MemoryStream(Archivo), "AUD-RFQ-" + rfq.Fila().Celda("id").ToString() + ".pdf") );
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
                        MessageBox.Show("RFQ enviado correctamente", "RFQ enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void GuardarDatos()
        {
            Fila archivoPdf = new Fila();
            archivoPdf.AgregarCelda("rfq", rfq.Fila().Celda("id"));
            archivoPdf.AgregarCelda("archivo", Archivo);

            ArchivoRfq.Modelo().Insertar(archivoPdf);

            rfq.Fila().ModificarCelda("estatus", "ENVIADO");
            rfq.Fila().ModificarCelda("fecha_envio", DateTime.Now);
            rfq.GuardarDatos();
        }

        private void CmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFormato.Text == "MEXICO")
                TxtCuerpoCorreo.Text = "Estimado proveedor: Favor de proveer costo unitario, disponibilidad y tiempo de entrega estimado para los números de parte incluidos en la solicitud de cotización adjunta en este correo electrónico.";
            else
                TxtCuerpoCorreo.Text = "Dear supplier: Please provide unit cost, availability and estimated delivery time for the part numbers included in the request for quote attached in this e-mail.";

            if (CmbContacto.Text != "")
            {
                MostrarRFQ(CmbFormato.Text, Convert.ToInt32(rfq.Fila().Celda("id")), IdContacto );
            }
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

        public void MostrarAdjuntos()
        {
            DgvAdjuntos.Rows.Clear();
            BtnBorrarAdjunto.Enabled = false;

            foreach (KeyValuePair<string, byte[]> archivo in ArchivosAdjuntos)
            {
                DgvAdjuntos.Rows.Add(archivo.Key);
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

        private void DgvAdjuntos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int guardarScroll = 0;

                if (DgvAdjuntos.SelectedRows.Count > 0)
                {
                    BtnBorrarAdjunto.Enabled = !AdjuntosPorDefault.Contains(DgvAdjuntos.Rows[e.RowIndex].Cells[0].Value);
                }
                if (DgvAdjuntos.Rows.Count > 0)
                    guardarScroll = DgvAdjuntos.FirstDisplayedCell.RowIndex;

                ScrollPosicionAdjuntos = guardarScroll;
                RowIndexAdjuntos = DgvAdjuntos.CurrentCell.RowIndex;
            }
        }

        private void chkEnviarCorreo_CheckedChanged(object sender, EventArgs e)
        {
            EnviarCorreo =  Convert.ToBoolean(chkEnviarCorreo.Checked);
            
            TxtCuerpoCorreo.Enabled = EnviarCorreo;
            DgvContactosCopia.Enabled = EnviarCorreo;
            DgvAdjuntos.Enabled = EnviarCorreo;
            BtnAdjuntar.Enabled = EnviarCorreo;
        }

        private void DgvAdjuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
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
                DgvAdjuntos.FirstDisplayedScrollingRowIndex = RowIndexAdjuntos;
                DgvAdjuntos.Rows[RowIndexAdjuntos].Selected = true;
            }
        }
    }
}
