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
using FluentFTP;
using System.Net;
using System.IO;

namespace CB
{
    public partial class FrmEntregarPiezaFabricada : Form
    {
        int valeId = 0;
        int ValeSalidaPzaFabricada = 0;
        int ValeSalidaPzaTratamiento = 0;
        int ValeSalidaPzaEntregada = 0;

        List<int> ListaPlano = new List<int>();
        FtpClient ClienteFtp = new FtpClient();
        public FrmEntregarPiezaFabricada()
        {
            InitializeComponent();
        }

        private void FrmEntregarPiezaFabricada_Load(object sender, EventArgs e)
        {
            BtnValeSalida.Enabled = false;
            LblEstatusDescargar.Text = "";
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;
            CargarPiezas();
        }

        private void CargarPiezas()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvPiezasFabricadas);
            DgvPiezasFabricadas.Rows.Clear();
            PlanoProyecto planoProyecto = new PlanoProyecto();
            planoProyecto.PiezasFabricadas().ForEach(delegate(Fila f)
            {
                DgvPiezasFabricadas.Rows.Add(false, f.Celda("id") + " | " + f.Celda("nombre_archivo"), f.Celda("proyecto"), f.Celda("material"), f.Celda("size"), f.Celda("estatus"));
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvPiezasFabricadas);
        }

        private void DgvPiezasFabricadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvPiezasFabricadas.Rows[e.RowIndex].Cells[0];
            if (chk.Value == chk.TrueValue)
            {
                chk.Value = chk.FalseValue;
                DgvPiezasFabricadas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                DgvPiezasFabricadas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                DgvPiezasFabricadas.Rows[e.RowIndex].Selected = false;
                if (ListaPlano.Contains(Convert.ToInt32(DgvPiezasFabricadas.Rows[e.RowIndex].Cells["plano"].Value.ToString().Split('|')[0].TrimEnd())))
                    ListaPlano.Remove(Convert.ToInt32(DgvPiezasFabricadas.Rows[e.RowIndex].Cells["plano"].Value.ToString().Split('|')[0].TrimEnd()));
            }
            else
            {
                DgvPiezasFabricadas.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                chk.Value = chk.TrueValue;
                DgvPiezasFabricadas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                if (!ListaPlano.Contains(Convert.ToInt32(DgvPiezasFabricadas.Rows[e.RowIndex].Cells["plano"].Value.ToString().Split('|')[0].TrimEnd())))
                    ListaPlano.Add(Convert.ToInt32(DgvPiezasFabricadas.Rows[e.RowIndex].Cells["plano"].Value.ToString().Split('|')[0].TrimEnd()));
            }

            if (ListaPlano.Count <= 0)
                BtnEnviarInspeccion.Enabled = false;
            else
                BtnEnviarInspeccion.Enabled = true;
        }

        private void BtnEntregar_Click(object sender, EventArgs e)
        {
            FrmGenerarValeSalidaFabricacion valeSalida = new FrmGenerarValeSalidaFabricacion(ListaPlano);
            if (valeSalida.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarPiezas();

            ListaPlano.Clear();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RealizarEscaneo();
        }

        private void RealizarEscaneo()
        {
            DgvProcesos.Rows.Clear();
            PlanoProyecto buscadorPlano = new PlanoProyecto();
            buscadorPlano.CargarDatos(Convert.ToInt32(NumIdPlano.Value));
            if (buscadorPlano.TieneFilas())
            {              
                ValeSalidaPzaFabricada = Convert.ToInt32(buscadorPlano.Fila().Celda("vale_salida_inspeccion"));
                ValeSalidaPzaTratamiento = Convert.ToInt32(buscadorPlano.Fila().Celda("vale_salida_tratamiento"));
                ValeSalidaPzaEntregada = Convert.ToInt32(buscadorPlano.Fila().Celda("vale_salida_entrega"));
                CargarProcesos();
                BtnValeSalida.Enabled = true;
            }
            else
            {
                ValeSalidaPzaFabricada = 0;
                ValeSalidaPzaTratamiento = 0;
                ValeSalidaPzaEntregada = 0;
                BtnValeSalida.Enabled = false;
            }
        }

        public void CargarProcesos()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvProcesos);            

            PlanoProceso buscarProcesos = new PlanoProceso();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", NumIdPlano.Value);

            buscarProcesos.SeleccionarDatos("plano=@plano ORDER BY proceso_anterior ASC", parametros, "*").ForEach(delegate(Fila proceso)
            {
                object objFechaInicio = proceso.Celda("fecha_inicio");
                object objFechaTermino = proceso.Celda("fecha_termino");

                string fechaInicio = "N/A";
                if (objFechaInicio != null)
                    fechaInicio = Convert.ToDateTime(objFechaInicio).ToString("MMM dd, yyyy hh:mm:ss tt");

                string fechaTermino = "N/A";
                if (objFechaTermino != null)
                    fechaTermino = Convert.ToDateTime(objFechaTermino).ToString("MMM dd, yyyy hh:mm:ss tt");

                string categoria = string.Empty;
                ProcesoFabricacion procesoFabricacion = new ProcesoFabricacion();
                procesoFabricacion.BuscarCategoria(Global.ObjetoATexto(proceso.Celda("proceso"), ""));
                if (procesoFabricacion.TieneFilas())
                    categoria = Global.ObjetoATexto(procesoFabricacion.Fila().Celda("categoria"), "");

                string tiempoTotal = string.Empty;

                //Calcular el tiempo muerto
                string tiempoMuerto = string.Empty;
                if (Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "") != "" && Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00") != "0.00")
                    tiempoMuerto = TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00"))).ToString("h\\:mm") + " hrs";
                else
                    tiempoMuerto = "N/A";

                //calcular tiempo fabricacion
                string tiempoTrabajoReal = string.Empty;
                if (Global.ObjetoATexto(proceso.Celda("tiempo_trabajo_real"), "") != "" && Global.ObjetoATexto(proceso.Celda("tiempo_trabajo_real"), "0.00") != "0.00")
                    tiempoTrabajoReal = TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(proceso.Celda("tiempo_trabajo_real"), "0.00"))).ToString("h\\:mm") + " hrs";
                else
                    tiempoTrabajoReal = "N/A";

                //calcular tiempo total
                if (Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "") != "" && Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00") != "0.00")
                    tiempoTotal = (TimeSpan.FromHours(Convert.ToDouble(Global.ObjetoATexto(proceso.Celda("tiempo_muerto"), "0.00"))).Add(TimeSpan.FromHours(Convert.ToDouble(proceso.Celda("tiempo_trabajo_real"))))).ToString("h\\:mm") + " hrs";
                else
                    tiempoTotal = "N/A";

                //generar id a partir de nombre completo
                string idOperador = "";
                Usuario usuarios = new Usuario();
                usuarios.BuscarPorNombre(proceso.Celda("operador").ToString());
                if (usuarios.TieneFilas())
                    idOperador = usuarios.Fila().Celda("id").ToString() + " - ";

                DgvProcesos.Rows.Add(proceso.Celda("id"),
                                     proceso.Celda("proceso"),
                                     proceso.Celda("maquina"),
                                     proceso.Celda("programador"),
                                     idOperador + proceso.Celda("operador"),
                                     proceso.Celda("estatus"),
                                     fechaInicio,
                                     fechaTermino,
                                     proceso.Celda("comentarios"),
                                     proceso.Celda("proceso_anterior"),
                                     categoria,
                                     proceso.Celda("requisicion_compra"),
                                     tiempoMuerto,
                                     tiempoTrabajoReal,
                                     tiempoTotal);
            });
        }

        private void piezaFabricadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!BkgDescargarVales.IsBusy)
            {
                IniciarHilo();
                BkgDescargarVales.RunWorkerAsync(ValeSalidaPzaFabricada);
            }
        }

        private void tratamientoDeMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!BkgDescargarVales.IsBusy)
            {
                IniciarHilo();
                BkgDescargarVales.RunWorkerAsync(ValeSalidaPzaTratamiento);
            }
        }

        private void piezasEntregadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!BkgDescargarVales.IsBusy)
            {
                IniciarHilo();
                BkgDescargarVales.RunWorkerAsync(ValeSalidaPzaEntregada);
            }
        }

        private void IniciarHilo()
        {
            LblEstatusDescargar.Text = "";
            ProgresoDescarga.Value = 0;
            ProgresoDescarga.Visible = true;
            BtnValeSalida.Enabled = false;
        }

        private void BkgDescargarVales_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] datosVale = null;
            BkgDescargarVales.ReportProgress(10, "Descargando vale de salida");

            Global.CrearConexionFTP(ClienteFtp);
            BkgDescargarVales.ReportProgress(50, "Descargando vale de salida");

            if (ClienteFtp.IsConnected)
            {
                valeId = Convert.ToInt32(e.Argument);
                if (ClienteFtp.FileExists("SGC\\VALES_SALIDA\\" + valeId + ".pdf"))
                {
                    // enviar archivos a carpeta ftp
                    ClienteFtp.Download(out datosVale, "SGC\\VALES_SALIDA\\" + valeId + ".pdf");
                    e.Result = datosVale;
                    BkgDescargarVales.ReportProgress(80, "Descargando vale de salida");
                }
                else
                {
                    e.Result = null;
                    BkgDescargarVales.ReportProgress(100, "Error al descargar el plano");
                }
            }
        }

        private void BkgDescargarVales_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result != null)
            {
                FrmVisorPDF visorPdf = new FrmVisorPDF((byte[])e.Result, "Vale de salida " + valeId.ToString().PadLeft(4,'0'));
                visorPdf.Show();

                LblEstatusDescargar.Text = "Vale de salida descargado";
            }
            else
                LblEstatusDescargar.Text = "Error al descargar el vale de salida";

            ProgresoDescarga.Visible = false;
            BtnValeSalida.Enabled = true;
            
        }

        private void BkgDescargarVales_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatusDescargar.Text = e.UserState + "[" + e.ProgressPercentage + "%]";
            LblEstatusDescargar.Refresh();
        }

        private void MenuValeSalida_Opening(object sender, CancelEventArgs e)
        {
            piezaFabricadaToolStripMenuItem.Enabled = false;
            tratamientoDeMaterialesToolStripMenuItem.Enabled = false;
            piezasEntregadasToolStripMenuItem.Enabled = false;

            if (ValeSalidaPzaFabricada > 0)
                piezaFabricadaToolStripMenuItem.Enabled = true;
            if (ValeSalidaPzaTratamiento > 0)
                tratamientoDeMaterialesToolStripMenuItem.Enabled = true;
            if (ValeSalidaPzaEntregada > 0)
                piezasEntregadasToolStripMenuItem.Enabled = true;
        }

        private void BtnValeSalida_Click(object sender, EventArgs e)
        {
            MenuValeSalida.Show(BtnValeSalida, BtnValeSalida.PointToClient(Cursor.Position));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
