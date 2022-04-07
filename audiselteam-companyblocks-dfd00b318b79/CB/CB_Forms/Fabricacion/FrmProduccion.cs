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
    public partial class FrmProduccion : Ventana
    {
        List<Fila> Herramentista = new List<Fila>();
        List<Fila> Proceso = new List<Fila>();
        List<Fila> PiezasTerminadas = new List<Fila>();
        List<Fila> PiezasEntregadas = new List<Fila>();
        List<Fila> ProcesoEnCurso = new List<Fila>();

        string NombreHerramentista = "";
        int IdFila = 0;
        double InicioCarga;

        public FrmProduccion()
        {
            InitializeComponent();
        }

        private void FrmProduccion_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            chkVistaPrevia.Checked = false;
            InicioCarga = Global.MillisegundosEpoch();
        }

        private void BkgDescargarHerramentista_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "TERMINADO");
            Herramentista = PlanoProceso.Modelo().SeleccionarDatos("estatus=@estatus", parametros, "distinct(operador)", BkgDescargarHerramentista);
        }

        private void BkgDescargarHerramentista_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarProcesos.Value = e.ProgressPercentage;
            LblProcesosEstatus.Text = "Descargando nombre(s) de herramentista(s)... [" + e.ProgressPercentage + "%]";
            LblProcesosEstatus.Refresh();
        }

        private void BkgDescargarHerramentista_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
            progressBarProcesos.Visible = false;
            LblProcesosEstatus.Text = CmbHerramentista.Items.Count + " nombre(s) de Herramentista(s) descargado(s) en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
            DateFechaSeleccionada.Enabled = true;
            MostrarHerramentista();
        }

        public void MostrarHerramentista()
        {
            Application.DoEvents();
            Herramentista.ForEach(delegate(Fila f)
            {
                CmbHerramentista.Items.Add(f.Celda("operador").ToString());
            });

            CmbHerramentista.Items.Add("TODOS");
            CmbHerramentista.SelectedIndex = CmbHerramentista.Items.Count - 1;
        }

        private void TbCntrlElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateFechaSeleccionada.Enabled = false;
            InicioCarga = Global.MillisegundosEpoch();

            switch (TbCntrlElementos.SelectedIndex)
            {
                case 0:
                    ProgressProcesoEnCurso.Value = 0;
                    ProgressProcesoEnCurso.Visible = true;

                    if (BkgDescargarProcesoEnCurso.IsBusy)
                    {
                        BkgDescargarProcesoEnCurso.WorkerSupportsCancellation = true;
                        BkgDescargarProcesoEnCurso.CancelAsync();
                    }
                    else
                    {
                        DateFechaSeleccionada.Enabled = false;
                        BkgDescargarProcesoEnCurso.RunWorkerAsync();
                    }

                    break;
                case 1:
                    progressBarProcesos.Value = 0;
                    progressBarProcesos.Visible = true;
                    
                    CmbHerramentista.Items.Clear();

                    if (BkgDescargarHerramentista.IsBusy)
                    {
                        BkgDescargarHerramentista.WorkerSupportsCancellation = true;
                        BkgDescargarHerramentista.CancelAsync();
                    }
                    else
                    {
                        DateFechaSeleccionada.Enabled = false;
                        BkgDescargarHerramentista.RunWorkerAsync();
                    }
                   
                    if (BkgDescargarPlano.IsBusy)
                    {
                        BkgDescargarPlano.WorkerSupportsCancellation = true;
                        BkgDescargarPlano.CancelAsync();
                    }

                    break;
                case 2:
                    ProgresoTerminado.Value = 0;
                     ProgresoTerminado.Visible = true;

                     if (BkgPiezaTerminada.IsBusy)
                     {
                         BkgPiezaTerminada.WorkerSupportsCancellation = true;
                         BkgPiezaTerminada.CancelAsync();
                     }
                     else
                     {
                         DateFechaSeleccionada.Enabled = false;
                         BkgPiezaTerminada.RunWorkerAsync();
                     }
                    
                    break;
                case 3:
                     ProgresoEntregado.Value = 0;
                     ProgresoEntregado.Visible = true;


                     if (BkgPiezaEntregada.IsBusy)
                     {
                         BkgPiezaEntregada.WorkerSupportsCancellation = true;
                         BkgPiezaEntregada.CancelAsync();
                     }
                     else
                     {
                         DateFechaSeleccionada.Enabled = false;
                         BkgPiezaEntregada.RunWorkerAsync();
                     }
                    break;
                
                default:
                    break;
            }
        }

        private void DateFechaSeleccionada_ValueChanged(object sender, EventArgs e)
        {
            CmbHerramentista.Enabled = false;
            DateFechaSeleccionada.Enabled = false;            
            InicioCarga = Global.MillisegundosEpoch();

            switch (TbCntrlElementos.SelectedIndex)
            {
                case 0:
                    DateFechaSeleccionada.Enabled = false;
                    ProgressProcesoEnCurso.Visible = true;
                    if (!BkgDescargarProcesoEnCurso.IsBusy)
                        BkgDescargarProcesoEnCurso.RunWorkerAsync();
                    else
                        BkgDescargarProcesoEnCurso.CancelAsync();
                    break;
                case 1:
                    progressBarProcesos.Visible = true;                   
                    NombreHerramentista = CmbHerramentista.Text;
                    BkgDescargarPlano.RunWorkerAsync();
                    break;
                case 2:
                    ProgresoTerminado.Visible = true;
                    DgvPiezaTerminada.Columns["miniatura_piezaTerminada"].Visible = chkVistaPrevia.Checked;
                    BkgPiezaTerminada.RunWorkerAsync();
                    break;
                case 3:
                    ProgresoEntregado.Visible = true;
                    DgvPiezaEntregada.Columns["miniatura_entregado"].Visible = chkVistaPrevia.Checked;
                    BkgPiezaEntregada.RunWorkerAsync();
                    break;
                default:
                    break;
            }
        }

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel)
            {
                string fecha = Convert.ToDateTime(DateFechaSeleccionada.Text).ToString("yyyy-MM-dd");
                Proceso = PlanoProceso.Modelo().PoblarProduccion(NombreHerramentista, fecha, NombreHerramentista, BkgDescargarPlano);
            }
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarProcesos.Value = e.ProgressPercentage;
            LblProcesosEstatus.Text = "Descargando proceso(s)... [" + e.ProgressPercentage + "%]";
            LblProcesosEstatus.Refresh();
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
                progressBarProcesos.Visible = false;
                LblProcesosEstatus.Text = Proceso.Count + " proceso(S) descargado(S) en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
                DateFechaSeleccionada.Enabled = true;  
                MostrarPlano();
            }
        }

        public void MostrarPlano()
        {
            Application.DoEvents();
            DgvProcesosTerminados.Rows.Clear();
            Proceso.ForEach(delegate(Fila f)
            {
                Object objMiniatura = f.Celda("miniatura");

                ImageConverter converter = new ImageConverter();
                byte[] miniatura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                if (objMiniatura != null)
                    miniatura = (byte[])objMiniatura;

                Image img = (Image)(converter.ConvertFrom(miniatura));
                Bitmap bitmap = new Bitmap(150, 150);
                using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                    graphics.DrawImage(img, 0, 0, 150, 150);
                img = bitmap;

                DgvProcesosTerminados.Rows.Add(f.Celda("id"), f.Celda("archivo"), Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"), f.Celda("proceso"), f.Celda("herramentista"), Convert.ToDateTime(f.Celda("fechaInicio")).ToString("MMM dd, yyyy hh:mm:ss"), Convert.ToDateTime(f.Celda("fechaFin")).ToString("MMM dd, yyyy hh:mm:ss"), img);
            });

            CmbHerramentista.Enabled = true;
            DateFechaSeleccionada.Enabled = true;
        }

        private void CmbHerramentista_SelectedIndexChanged(object sender, EventArgs e)
        {
            NombreHerramentista = CmbHerramentista.Text;
            InicioCarga = Global.MillisegundosEpoch();
            DgvProcesosTerminados.Columns["herramentista_produccion"].Visible = (CmbHerramentista.Text == "TODOS");

            CmbHerramentista.Enabled = false;
            DateFechaSeleccionada.Enabled = false;
            progressBarProcesos.Value = 0;
            progressBarProcesos.Visible = true;

            if (BkgDescargarPlano.IsBusy)
            {
                BkgDescargarPlano.WorkerSupportsCancellation = true;
                BkgDescargarPlano.CancelAsync();
            }
            else
            {
                DateFechaSeleccionada.Enabled = false;  
                BkgDescargarPlano.RunWorkerAsync();
            }
        }

        private void chkVistaPrevia_CheckedChanged(object sender, EventArgs e)
        {
            DgvProcesosTerminados.Columns["miniatura"].Visible = chkVistaPrevia.Checked;
            DgvPiezaTerminada.Columns["miniatura_piezaTerminada"].Visible = chkVistaPrevia.Checked;
            DgvPiezaEntregada.Columns["miniatura_entregado"].Visible = chkVistaPrevia.Checked;
            DgvProcesoEnCurso.Columns["miniatura_enProceso"].Visible = chkVistaPrevia.Checked;
        }

        private void DgvProcesosTerminados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdFila = Convert.ToInt32(DgvProcesosTerminados.SelectedRows[0].Cells["id_produccion"].Value);
            Proceso.ForEach(delegate(Fila f)
            {
                if(Convert.ToInt32(f.Celda("id")) == IdFila)
                {
                    FrmVisorPDF pdf = new FrmVisorPDF((byte[])f.Celda("plano"), f.Celda("archivo").ToString());
                    pdf.ShowDialog();
                    return;
                }
            });
        }

        private void BkgPiezaTerminada_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel)
            {
                string fecha = Convert.ToDateTime(DateFechaSeleccionada.Text).ToString("yyyy-MM-dd");
                PiezasTerminadas = PlanoProceso.Modelo().PiezasTerminadas(fecha, BkgPiezaTerminada);
            }
        }

        private void BkgPiezaTerminada_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoTerminado.Value = e.ProgressPercentage;
            LblEstatusTerminado.Text = "Descargando piezas terminadas... [" + e.ProgressPercentage + "%]";
            LblEstatusTerminado.Refresh();
        }

        private void BkgPiezaTerminada_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
                ProgresoTerminado.Visible = false;
                LblEstatusTerminado.Text = PiezasTerminadas.Count + " pieza(S) descargada(S) en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
                DateFechaSeleccionada.Enabled = true;  
                MostrarPiezaTerminada();
            }
        }

        public void MostrarPiezaTerminada()
        {
            Application.DoEvents();
            DgvPiezaTerminada.Rows.Clear();
            PiezasTerminadas.ForEach(delegate(Fila f)
            {
                Object objMiniatura = f.Celda("miniatura");

                ImageConverter converter = new ImageConverter();
                byte[] miniatura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                if (objMiniatura != null)
                    miniatura = (byte[])objMiniatura;

                Image img = (Image)(converter.ConvertFrom(miniatura));
                Bitmap bitmap = new Bitmap(150, 150);
                using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                    graphics.DrawImage(img, 0, 0, 150, 150);
                img = bitmap;

                DgvPiezaTerminada.Rows.Add(f.Celda("id"), f.Celda("archivo"), Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"), f.Celda("cantidad"), Convert.ToDateTime(f.Celda("fechaInicio")).ToString("yyyy-MM-dd hh:mm:ss"), Convert.ToDateTime(f.Celda("fechaFin")).ToString("yyyy-MM-dd hh:mm:ss"), img);
            });

            CmbHerramentista.Enabled = true;
            DateFechaSeleccionada.Enabled = true;
            
        }

        private void DgvPiezaTerminada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdFila = Convert.ToInt32(DgvPiezaTerminada.SelectedRows[0].Cells["id_terminado"].Value);
            PiezasTerminadas.ForEach(delegate(Fila f)
            {
                if (Convert.ToInt32(f.Celda("id")) == IdFila)
                {
                    FrmVisorPDF pdf = new FrmVisorPDF((byte[])f.Celda("plano"), f.Celda("archivo").ToString());
                    pdf.ShowDialog();
                    return;
                }
            });
        }

        private void BkgPiezaEntregada_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel) 
            {
                string fecha = Convert.ToDateTime(DateFechaSeleccionada.Text).ToString("yyyy-MM-dd");
                PiezasEntregadas = PlanoProceso.Modelo().PiezasEntregadas(fecha, BkgPiezaEntregada);
            }
        }

        private void BkgPiezaEntregada_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoEntregado.Value = e.ProgressPercentage;
            LblEstatusEntregado.Text = "Descargando piezas entregadas... [" + e.ProgressPercentage + "%]";
            LblEstatusEntregado.Refresh();
        }

        private void BkgPiezaEntregada_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
                ProgresoEntregado.Visible = false;
                LblEstatusEntregado.Text = PiezasEntregadas.Count + " pieza(S) descargada(S) en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
                DateFechaSeleccionada.Enabled = false;
                MostrarPiezaEntregada();
            }              
        }

        public void MostrarPiezaEntregada()
        {
            Application.DoEvents();
            DgvPiezaEntregada.Rows.Clear();
            PiezasEntregadas.ForEach(delegate(Fila f)
            {
                Object objMiniatura = f.Celda("miniatura");

                ImageConverter converter = new ImageConverter();
                byte[] miniatura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                if (objMiniatura != null)
                    miniatura = (byte[])objMiniatura;

                Image img = (Image)(converter.ConvertFrom(miniatura));
                Bitmap bitmap = new Bitmap(150, 150);
                using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                    graphics.DrawImage(img, 0, 0, 150, 150);
                img = bitmap;
                DgvPiezaEntregada.Rows.Add(f.Celda("id"), f.Celda("archivo"), Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"), f.Celda("cantidad"), Convert.ToDateTime(f.Celda("fechaInicio")).ToString("yyyy-MM-dd hh:mm:ss"), Convert.ToDateTime(f.Celda("fechaFin")).ToString("yyyy-MM-dd hh:mm:ss"), img);
            });

            CmbHerramentista.Enabled = true;
            DateFechaSeleccionada.Enabled = true;            
        }

        private void DgvPiezaEntregada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdFila = Convert.ToInt32(DgvPiezaEntregada.SelectedRows[0].Cells["id_entregado"].Value);
            PiezasEntregadas.ForEach(delegate(Fila f)
            {
                if (Convert.ToInt32(f.Celda("id")) == IdFila)
                {
                    FrmVisorPDF pdf = new FrmVisorPDF((byte[])f.Celda("plano"), f.Celda("archivo").ToString());
                    pdf.ShowDialog();
                    return;
                }
            });
        }

        private void BkgDescargarProcesoEnCurso_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!e.Cancel)
            {
                string fecha = Convert.ToDateTime(DateFechaSeleccionada.Text).ToString("yyyy-MM-dd");
                ProcesoEnCurso = PlanoProceso.Modelo().ProduccionEnProceso(fecha, BkgDescargarProcesoEnCurso);
            }
        }

        private void BkgDescargarProcesoEnCurso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressProcesoEnCurso.Value = e.ProgressPercentage;
            LblEstatusProcesoEnCurso.Text = "Descargando proceso(s) en curso... [" + e.ProgressPercentage + "%]";
            LblEstatusProcesoEnCurso.Refresh();
        }

        private void BkgDescargarProcesoEnCurso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(!e.Cancelled)
            {
                double TiempoTranscurrido = Global.MillisegundosEpoch() - InicioCarga;
                ProgressProcesoEnCurso.Visible = false;
                LblEstatusProcesoEnCurso.Text = ProcesoEnCurso.Count + " proceso(S) en curso descargado(s) en " + (TiempoTranscurrido / 1000.0).ToString("F2") + " segundos.";
                DateFechaSeleccionada.Enabled = true;
                MostrarProcesosEnCurso();
            }
        }

        public void MostrarProcesosEnCurso()
        {
            DgvProcesoEnCurso.Rows.Clear();
            ProcesoEnCurso.ForEach(delegate(Fila f)
            {
                Object objMiniatura = f.Celda("miniatura");

                ImageConverter converter = new ImageConverter();
                byte[] miniatura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                if (objMiniatura != null)
                    miniatura = (byte[])objMiniatura;

                Image img = (Image)(converter.ConvertFrom(miniatura));
                Bitmap bitmap = new Bitmap(150, 150);
                using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                    graphics.DrawImage(img, 0, 0, 150, 150);
                img = bitmap;

                DgvProcesoEnCurso.Rows.Add(f.Celda("id"), f.Celda("archivo"), Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"), f.Celda("proceso"), f.Celda("herramentista"), Convert.ToDateTime(f.Celda("fechaInicio")).ToString("MMM dd, yyyy hh:mm:ss"), Convert.ToDateTime(f.Celda("fechaFin")).ToString("MMM dd, yyyy hh:mm:ss"), img);
            });

            DateFechaSeleccionada.Enabled = true;
        }

        private void FrmProduccion_Shown(object sender, EventArgs e)
        {
            DateFechaSeleccionada.Enabled = false;
            BkgDescargarProcesoEnCurso.RunWorkerAsync();
        }

        private void DgvProcesoEnCurso_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdFila = Convert.ToInt32(DgvProcesoEnCurso.SelectedRows[0].Cells["id_enProceso"].Value);
            ProcesoEnCurso.ForEach(delegate(Fila f)
            {
                if (Convert.ToInt32(f.Celda("id")) == IdFila)
                {
                    FrmVisorPDF pdf = new FrmVisorPDF((byte[])f.Celda("plano"), f.Celda("archivo").ToString());
                    pdf.ShowDialog();
                    return;
                }
            });
        }
    }
}
