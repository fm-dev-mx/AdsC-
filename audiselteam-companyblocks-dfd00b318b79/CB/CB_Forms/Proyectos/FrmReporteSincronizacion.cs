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
    public partial class FrmReporteSincronizacion : Form
    {
        decimal IdProyecto = 0;
        TareasTopico Tarea = new TareasTopico();
        bool IncluirPrincipal = false;
        byte[] PdfDatos = null;
        string TituloPdf = "";
        public FrmReporteSincronizacion(decimal idProyecto)
        {
            InitializeComponent();
            IdProyecto = idProyecto;
            if (Convert.ToDecimal(IdProyecto).ToString("F2").Contains(".00"))
                CkbIncluir.Visible = true;
            else
                CkbIncluir.Visible = false;
        }

        private void FrmReporteSincronizacion_Load(object sender, EventArgs e)
        {
            CmbEstatus.SelectedIndex = 0;
            TituloPdf = "REPORTE_DE_SINCRONIZACION_DEL_PROYECTO_" + IdProyecto;
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* byte[] datos = FormatosPDF.ReporteSincronizacion(IdProyecto, CmbEstatus.Text, DtpDesde.Value, DtpHasta.Value, IncluirPrincipal);
            Global.MostrarPDF(datos, TituloPdf, null, VisorPDF);*/
            CmbEstatus.Enabled = false;
            DtpDesde.Enabled = false;
            DtpHasta.Enabled = false;
            CkbIncluir.Enabled = false;

            List<object> arguments = new List<object>();
            arguments.Add(CmbEstatus.Text);
            arguments.Add(DtpDesde.Value);
            arguments.Add(DtpHasta.Value);
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;
            BtnGuardar.Enabled = false;

            BkgCargarPdf.RunWorkerAsync(arguments);
        }

        private void DtpDesde_ValueChanged(object sender, EventArgs e)
        {
            /* byte[] datos = FormatosPDF.ReporteSincronizacion(IdProyecto, CmbEstatus.Text, DtpDesde.Value, DtpHasta.Value, IncluirPrincipal);
            Global.MostrarPDF(datos, TituloPdf, null, VisorPDF);*/
            CmbEstatus.Enabled = false;
            DtpDesde.Enabled = false;
            DtpHasta.Enabled = false;
            CkbIncluir.Enabled = false;

            List<object> arguments = new List<object>();
            arguments.Add(CmbEstatus.Text);
            arguments.Add(DtpDesde.Value);
            arguments.Add(DtpHasta.Value);
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;
            BtnGuardar.Enabled = false;

            BkgCargarPdf.RunWorkerAsync(arguments);
        }

        private void DtpHasta_ValueChanged(object sender, EventArgs e)
        {
            /* byte[] datos = FormatosPDF.ReporteSincronizacion(IdProyecto, CmbEstatus.Text, DtpDesde.Value, DtpHasta.Value, IncluirPrincipal);
            Global.MostrarPDF(datos, TituloPdf, null, VisorPDF);*/
            CmbEstatus.Enabled = false;
            DtpDesde.Enabled = false;
            DtpHasta.Enabled = false;
            CkbIncluir.Enabled = false;

            List<object> arguments = new List<object>();
            arguments.Add(CmbEstatus.Text);
            arguments.Add(DtpDesde.Value);
            arguments.Add(DtpHasta.Value);
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;
            BtnGuardar.Enabled = false;

            BkgCargarPdf.RunWorkerAsync(arguments);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (PdfDatos == null)
            {
                MessageBox.Show("Favor de generar primero el PDF", "Generar PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF|*.pdf";
            saveFileDialog1.Title = "Guardar reporte de sincronización";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName == "")
                    return;
                File.WriteAllBytes(saveFileDialog1.FileName, PdfDatos);
            }
        }

        private void CkbIncluir_CheckedChanged(object sender, EventArgs e)
        {
            if (CkbIncluir.Checked)
                IncluirPrincipal = true;
            else
                IncluirPrincipal = false;

            CmbEstatus.Enabled = false;
            DtpDesde.Enabled = false;
            DtpHasta.Enabled = false;
            CkbIncluir.Enabled = false;
            BtnGuardar.Enabled = false;

            List<object> arguments = new List<object>();
            arguments.Add(CmbEstatus.Text);
            arguments.Add(DtpDesde.Value);
            arguments.Add(DtpHasta.Value);
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;

            BkgCargarPdf.RunWorkerAsync(arguments);
        }

        private void BkgCargarPdf_DoWork(object sender, DoWorkEventArgs e)
        {
           
                List<object> argumentos = e.Argument as List<object>;
                string estatus = (string)argumentos[0].ToString();
                DateTime desde = Convert.ToDateTime(argumentos[1]);
                DateTime hasta = Convert.ToDateTime(argumentos[2]);

                PdfDatos = FormatosPDF.ReporteSincronizacion(IdProyecto, estatus, desde, hasta, IncluirPrincipal, BkgCargarPdf);
        }

        private void BkgCargarPdf_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatusBkg.Text = "Descargando planos... [" + e.ProgressPercentage + "%]";
        }

        private void BkgCargarPdf_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CmbEstatus.Enabled = true;
                DtpDesde.Enabled = true;
                DtpHasta.Enabled = true;
                CkbIncluir.Enabled = true;
                ProgresoDescarga.Visible = false;
                BtnGuardar.Enabled = true;
                LblEstatusBkg.Text = "Pdf  creado!";
                Global.MostrarPDF(PdfDatos, TituloPdf, null, VisorPDF);
            }
            catch { /* Si se cierra el form antes de terminar el hilo*/}
        }
    }
}
