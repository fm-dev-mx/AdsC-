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
    public partial class FrmReportarRequerimientos : Form
    {
        int IdContacto = 0;
        string nombreArchivo = "";
        Proyecto ProyectoCargado = new Proyecto();
        public byte[] archivo = null;
        Dictionary<string, byte[]> ArchivosAdjuntos = new Dictionary<string, byte[]>();

        public FrmReportarRequerimientos(Proyecto proyectoCargado)
        {
            InitializeComponent();
            ProyectoCargado = proyectoCargado;
        }

        private void FrmReportarRequerimientos_Load(object sender, EventArgs e)
        {
            CargarContactos((int)ProyectoCargado.Fila().Celda("cliente"));
            TxtGeneradoPor.Text = Global.UsuarioActual.NombreCompleto();
        }

        void CargarContactos(int idCliente)
        {
            ClienteContacto.Modelo().SeleccionarDeCliente(idCliente).ForEach(delegate(Fila contacto)
            {
                int idContacto = Convert.ToInt32(contacto.Celda("id"));
                DgvContactosCopia.Rows.Add(idContacto, false, contacto.Celda("nombre").ToString() + " " + contacto.Celda("apellidos").ToString(), contacto.Celda("correo").ToString());
            });

            ClienteContacto cont = new ClienteContacto();
            cont.CargarDatos((int)ProyectoCargado.Fila().Celda("contacto"));

            string strContacto = cont.Fila().Celda("id").ToString() + " - " + cont.Fila().Celda("nombre").ToString() + " " + cont.Fila().Celda("apellidos").ToString();
            CmbContacto.Items.Clear();
            CmbContacto.Items.Add(strContacto);
            CmbContacto.Text = strContacto;
        }

        void ActualizarPDF()
        {
            archivo = FormatosPDF.AnalisisDeRequerimientos(ProyectoCargado, DateFiltro.Value, TxtNotas.Text, ChkIncluirInternos.Checked);
            nombreArchivo = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            nombreArchivo += " REQ. " + DateTime.Now.ToString("MMM dd, yyyy");
            Global.MostrarPDF(archivo, nombreArchivo, null, VisorPDF);
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPDF();
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas reportar el análisis de requerimientos al cliente?", "Reportar requerimientos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                ActualizarPDF();

                string asunto = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2"); 
                asunto += " / ANALISIS DE REQUERIMIENTOS / " + DateTime.Now.ToString("MMM dd, yyyy").ToUpper();

                string contenido = TxtCuerpoCorreo.Text + "<br><br>";
                contenido += Global.UsuarioActual.NombreCompleto();

                ClienteContacto contacto = new ClienteContacto();
                contacto.CargarDatos(IdContacto);

                List<Attachment> adjunto = new List<Attachment>();
                adjunto.Add(new Attachment(new MemoryStream(archivo), nombreArchivo + ".pdf"));
                foreach (KeyValuePair<string, byte[]> archivoAdjunto in ArchivosAdjuntos)
                {
                    adjunto.Add(new Attachment(new MemoryStream(archivoAdjunto.Value), archivoAdjunto.Key));
                }

                List<string> copias = new List<string>();
                foreach (DataGridViewRow cont in DgvContactosCopia.Rows)
                {
                    if (Convert.ToBoolean(cont.Cells["seleccion"].Value) == true)
                    {
                        copias.Add(cont.Cells["correo"].Value.ToString());
                    }
                }
                copias.Add(Global.UsuarioActual.Fila().Celda("correo").ToString());

                try
                {
                    Global.EnviarCorreo(asunto, contenido, contacto.Fila().Celda("correo").ToString(), copias, adjunto);
                    //MessageBox.Show("Reporte enviado correctamente", "Reporte enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void CmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnActualizar.Enabled = CmbContacto.Text != "";
            BtnEnviar.Enabled = CmbContacto.Text != "";

            if (CmbContacto.Text != "")
            {
                IdContacto = Convert.ToInt32(CmbContacto.Text.Split('-')[0]);
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
                ArchivosAdjuntos.Add(SeleccionarAdjunto.SafeFileName, datos);
                MostrarAdjuntos();
            }
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

        private void DateFiltro_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPDF();
        }

        private void ChkIncluirInternos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarPDF();
        }

    }
}
