using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CB_Base.Classes;
using System.Net.Mail;
using System.Windows.Forms.DataVisualization.Charting;

namespace CB
{ 
    public partial class FrmReporteFabricacion : Form
    {
        List<string> ListaCorreo = new List<string>();
        string Tabla = string.Empty;
        string Comentarios = string.Empty;

        public FrmReporteFabricacion()
        {
            InitializeComponent();
        }

        private void FrmReporteFabricacion_Load(object sender, EventArgs e)
        {
            NumObjetivo.Value = 28;
            NumSemana.Value = Global.NumeroSemanaYear();
            NumAnio.Value = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            CmbMes.Text = MesActual(mes);
            CmbTipoReporte.SelectedIndex = CmbTipoReporte.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario("", true);
            if(usuario.ShowDialog() == DialogResult.OK)
            {
                foreach (var correo in usuario.UsuariosSeleccionados)
                {
                    if (TxtCorreo.Text == "")
                        TxtCorreo.Text = correo.Fila().Celda("correo").ToString();
                    else
                        TxtCorreo.Text += "," + correo.Fila().Celda("correo").ToString();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        private string MesActual(int mes)
        {
            string nombreMes = string.Empty;
            switch (mes)
            {
                case 1:
                    nombreMes = "Enero";
                    break;
                case 2:
                    nombreMes = "Febrero";
                    break;
                case 3:
                    nombreMes = "Marzo";
                    break;
                case 4:
                    nombreMes = "Abril";
                    break;
                case 5:
                    nombreMes = "Mayo";
                    break;
                case 6:
                    nombreMes = "Junio";
                    break;
                case 7:
                    nombreMes = "Julio";
                    break;
                case 8:
                    nombreMes = "Agosto";
                    break;
                case 9:
                    nombreMes = "Septiembre";
                    break;
                case 10:
                    nombreMes = "Octubre";
                    break;
                case 11:
                    nombreMes = "Noviembre";
                    break;
                case 12:
                    nombreMes = "Diciembre";
                    break;  
            }
            return nombreMes;
        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            PlanoProyecto planos = new PlanoProyecto();
            PlanoFueraSistema fueraDeSistema = new PlanoFueraSistema();

            DateTime desde = DateTime.Now;
            DateTime hasta = DateTime.Now;

            int planosFabricados = 0;
            int planosFueraSistema = 0;
            int planosTotales = 0;
            int PlanosFaltantes = 0;
            int piezasTotalesFabricadas = 0;
            int eficiencia = 0;
          
            webBrowser2.DocumentText = Tabla;


            switch (CmbTipoReporte.Text.ToLower())
            {
                case "por día":

                    LblTipoSeleccion.Text = "Seleccione el día:";
                    CmbMes.Visible = false;
                    NumSemana.Visible = false;
                    NumAnio.Visible = false;
                    LblTipoSeleccion.Visible = true;
                    DtDia.Location = new Point(399, 89);
                    DtDia.Visible = true;

                    desde = DtDia.Value;
                    hasta = DtDia.Value;

                    //fabricados dentro del sistema
                    planos.PlanosRealizadosPorDia(desde, hasta);

                    //fabricados por fuera del sistema
                    fueraDeSistema.PlanosFabricadosFueraDeSistema(desde, hasta);

                    planosFabricados = planos.Filas().Count;
                    planosFueraSistema = fueraDeSistema.Filas().Count;
                    planosTotales = planosFabricados + planosFueraSistema;
                    PlanosFaltantes = 0;
                    piezasTotalesFabricadas = 0;
                    eficiencia = 0;
                    

                    if(planosFabricados > 0)
                        eficiencia = (planosTotales * 100) / (int)NumObjetivo.Value;
                           
                    if (planosFabricados < (int)NumObjetivo.Value)
                        PlanosFaltantes = (int)NumObjetivo.Value - planosTotales;

                    //cantidad de piezas
                    planos.Filas().ForEach(delegate (Fila f)
                    {
                        piezasTotalesFabricadas += (int)f.Celda("cantidad");
                    });

                    //grafica
                    var graficaMaquinado = chart1.Series.Add("Maquinado N");
                    var graficaFueraDeSistema = chart1.Series.Add("Fuera de sistema");
                    var graficaTotal = chart1.Series.Add("Total");

                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

                    graficaMaquinado.Points.AddXY(DtDia.Value.Date.ToString("MMM dd/yy"), planosFabricados);
                    graficaFueraDeSistema.Points.AddXY(DtDia.Value.Date.ToString("MMM dd/yy"), planosFueraSistema);
                    graficaTotal.Points.AddXY(DtDia.Value.Date.ToString("MMM dd/yy"), planosTotales);

                    //detalles
                   /* Comentarios = "<h1>Indicadores de maquinado del " + DtDia.Value.Date.ToString("MMM dd/yy") + "<h1><br><br> ";
                    Comentarios += planosTotales + " planos totales fabricados de los cuales:<br>";
                    Comentarios += planosFabricados + " planos fueron registrados en el sistema.<br>";
                    Comentarios += planosFueraSistema + " planos fabricados fuera del sistema.<br>";
                    Comentarios += PlanosFaltantes + " planos faltantes para objetivo. <br>";
                    Comentarios += "Eficiencia del día " + eficiencia + "%<br>";*/

                    Tabla = "<html>";
                    Tabla += "<table border = 1 >";
                    Tabla += "<tr><th>Día</th>";
                    Tabla += "<th>Objetivo</th>";
                    Tabla += "<th>Maquinado N.</th>";
                    Tabla += "<th>Maquinado F.S.</th>";
                    Tabla += "<th>Planos faltantes para objetivo</th>";
                    Tabla += "<th>Piezas maquinadas por plano</th>";
                    Tabla += "<th>Maquinados en total</th>";
                    Tabla += "<th>Fuera de sistema</th>";
                    Tabla += "<th>Eficiencia</th></tr>";
                    Tabla += "<td align=center>" + DtDia.Value.ToString("MMM dd/yy") + "</td>";
                    Tabla += "<td align=center>" + NumObjetivo.Value + "</td>";
                    Tabla += "<td align=center>" + planosFabricados + "</td>";
                    Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                    Tabla += "<td align=center>" + PlanosFaltantes + "</td>";
                    Tabla += "<td align=center>" + piezasTotalesFabricadas + "</td>";
                    Tabla += "<td align=center>" + planosTotales + "</td>";
                    Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                    Tabla += "<td align=center>" + eficiencia + " %</td>";
                    Tabla += "</table></html>";
                    webBrowser2.DocumentText = Tabla;


                    break;
                case "por semana":
                    LblTipoSeleccion.Text = "Seleccione la semana:";
                    CmbMes.Visible = false;
                    DtDia.Visible = false;
                    NumAnio.Visible = false;
                    LblTipoSeleccion.Visible = true;
                    NumSemana.Location = new Point(399, 89);
                    NumSemana.Maximum = 52;
                    NumSemana.Visible = true;

                    CultureInfo ciCurr = CultureInfo.CurrentCulture;
                    // int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    int weekNum = (int)NumSemana.Value;

                    //grafica series
                    var graficaMaquinadoSemana = chart1.Series.Add("Maquinado N");
                    var graficaFueraDeSistemaSemana = chart1.Series.Add("Fuera de sistema");
                    var graficaTotalSemana = chart1.Series.Add("Total");

                    Tabla = "<html>";
                    Tabla += "<table border = 1 >";
                    Tabla += "<tr><th>Día</th>";
                    Tabla += "<th>Objetivo</th>";
                    Tabla += "<th>Maquinado N.</th>";
                    Tabla += "<th>Maquinado F.S.</th>";
                    Tabla += "<th>Planos faltantes para objetivo</th>";
                    Tabla += "<th>Piezas maquinadas por plano</th>";
                    Tabla += "<th>Maquinados en total</th>";
                    Tabla += "<th>Fuera de sistema</th>";
                    Tabla += "<th>Eficiencia</th></tr>";

                    DateTime inicioSemana = Global.FechaIncialSemanaYear(DtDia.Value.Year, weekNum);
                    planos.PlanosFabricadosPorSemanaIncluyendoFueraDeSistema(inicioSemana, inicioSemana.AddDays(6)).ForEach(delegate (Fila f)
                    {
                        chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

                        //planos fuera del sistea
                        fueraDeSistema.PlanosFabricadosFueraDeSistema(Convert.ToDateTime(f.Celda("fecha_fabricacion_terminada")), Convert.ToDateTime(f.Celda("fecha_fabricacion_terminada")));

                        PlanosFaltantes = 0;
                        eficiencia = 0;
                        planosFabricados = (int)f.Celda("planos_fabricados");
                        planosFueraSistema = fueraDeSistema.Filas().Count;
                        planosTotales = planosFabricados + planosFueraSistema;
                        object piezasFabricadas = f.Celda("piezas_totales");
                                               
                        if (planosFabricados > 0)
                            eficiencia = (planosFabricados * 100) / (int)NumObjetivo.Value;

                        if (planosFabricados < (int)NumObjetivo.Value)
                            PlanosFaltantes = (int)NumObjetivo.Value - planosFabricados;

                        graficaMaquinadoSemana.Points.AddXY(f.Celda("x").ToString(), planosFabricados);
                        graficaFueraDeSistemaSemana.Points.AddXY(f.Celda("x").ToString(), planosFueraSistema);
                        graficaTotalSemana.Points.AddXY(f.Celda("x").ToString(), planosTotales);

                        //detalles
                        Tabla += "<tr><td align=center>" + f.Celda("x") + "</td>";
                        Tabla += "<td align=center>" + NumObjetivo.Value + "</td>";
                        Tabla += "<td align=center>" + planosFabricados + "</td>";
                        Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                        Tabla += "<td align=center>" + PlanosFaltantes + "</td>";
                        Tabla += "<td align=center>" + piezasFabricadas + "</td>";
                        Tabla += "<td align=center>" + planosTotales + "</td>";
                        Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                        Tabla += "<td align=center>" + eficiencia + " %</td></tr>";
                    });

                    Tabla += "</table></html>";
                    webBrowser2.DocumentText = Tabla;

                    break;
                case "por mes":
                    LblTipoSeleccion.Text = "Seleccione el mes:";
                    NumSemana.Visible = false;
                    DtDia.Visible = false;
                    NumAnio.Visible = false;
                    LblTipoSeleccion.Visible = true;
                    CmbMes.Location = new Point(399, 89);
                    CmbMes.Visible = true;

                    int mes = CmbMes.SelectedIndex + 1;
                    DateTime inicioMes = Convert.ToDateTime(DateTime.Now.Year + "-" + mes + "-01");
                    DateTime ultimoDiaMes = Convert.ToDateTime(DateTime.Now.Year + "-" + mes + "-" + DateTime.DaysInMonth(DateTime.Now.Year, mes));


                    //grafica series
                    var graficaMaquinadoMes= chart1.Series.Add("Maquinado N");
                    var graficaFueraDeSistemaMes = chart1.Series.Add("Fuera de sistema");
                    var graficaTotalMes = chart1.Series.Add("Total");

                    Tabla = "<html>";
                    Tabla += "<table border = 1 >";
                    Tabla += "<tr><th>Día</th>";
                    Tabla += "<th>Objetivo</th>";
                    Tabla += "<th>Maquinado N.</th>";
                    Tabla += "<th>Maquinado F.S.</th>";
                    Tabla += "<th>Planos faltantes para objetivo</th>";
                    Tabla += "<th>Piezas maquinadas por plano</th>";
                    Tabla += "<th>Maquinados en total</th>";
                    Tabla += "<th>Fuera de sistema</th>";
                    Tabla += "<th>Eficiencia</th></tr>";

                    planos.PlanosFabricadosPorMesIncluyenfoFueraDeSistema(inicioMes, ultimoDiaMes).ForEach(delegate (Fila f)
                    {
                        chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

                        //planos fuera del sistea
                        DateTime inicioSem = Global.FechaIncialSemanaYear(DateTime.Now.Year, Convert.ToInt32(f.Celda("x")));
                        DateTime finSem = inicioSem.AddDays(6);
                        fueraDeSistema.PlanosFabricadosFueraDeSistema(inicioSem, finSem);

                        PlanosFaltantes = 0;
                        eficiencia = 0;
                        planosFabricados = (int)f.Celda("planos_fabricados");
                        planosFueraSistema = fueraDeSistema.Filas().Count;
                        planosTotales = planosFabricados + planosFueraSistema;
                        object piezasFabricadas = f.Celda("piezas_totales");

                        if (planosFabricados > 0)
                            eficiencia = (planosFabricados * 100) / (int)NumObjetivo.Value;

                        if (planosFabricados < (int)NumObjetivo.Value)
                            PlanosFaltantes = (int)NumObjetivo.Value - planosFabricados;

                        graficaMaquinadoMes.Points.AddXY(f.Celda("x").ToString(), planosFabricados);
                        graficaFueraDeSistemaMes.Points.AddXY(f.Celda("x").ToString(), planosFueraSistema);
                        graficaTotalMes.Points.AddXY(f.Celda("x").ToString(), planosTotales);

                        //detalles
                        Tabla += "<tr><td align=center> Semana " + f.Celda("x") + "</td>";
                        Tabla += "<td align=center>" + NumObjetivo.Value + "</td>";
                        Tabla += "<td align=center>" + planosFabricados + "</td>";
                        Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                        Tabla += "<td align=center>" + PlanosFaltantes + "</td>";
                        Tabla += "<td align=center>" + piezasFabricadas + "</td>";
                        Tabla += "<td align=center>" + planosTotales + "</td>";
                        Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                        Tabla += "<td align=center>" + eficiencia + " %</td></tr>";
                    });

                    Tabla += "</table></html>";
                    webBrowser2.DocumentText = Tabla;

                    break;
                case "por año":
                    LblTipoSeleccion.Text = "Seleccione el año";
                    CmbMes.Visible = false;
                    DtDia.Visible = false;
                    NumSemana.Visible = false;
                    LblTipoSeleccion.Visible = true;
                    NumAnio.Location = new Point(399, 89);
                    NumAnio.Visible = true;

                    DateTime inicioAnio= Convert.ToDateTime(NumAnio.Value + "-01-01");
                    DateTime ultimoDiaAnio = Convert.ToDateTime(NumAnio.Value + "-12-31");


                    //grafica series
                    var graficaMaquinadoAnio = chart1.Series.Add("Maquinado N");
                    var graficaFueraDeSistemaAnio = chart1.Series.Add("Fuera de sistema");
                    var graficaTotalAnio = chart1.Series.Add("Total");

                    Tabla = "<html>";
                    Tabla += "<table border = 1 >";
                    Tabla += "<tr><th>Día</th>";
                    Tabla += "<th>Objetivo</th>";
                    Tabla += "<th>Maquinado N.</th>";
                    Tabla += "<th>Maquinado F.S.</th>";
                    Tabla += "<th>Planos faltantes para objetivo</th>";
                    Tabla += "<th>Piezas maquinadas por plano</th>";
                    Tabla += "<th>Maquinados en total</th>";
                    Tabla += "<th>Fuera de sistema</th>";
                    Tabla += "<th>Eficiencia</th></tr>";

                    planos.PlanosFabricadosPorAnioIncluyenfoFueraDeSistema(inicioAnio, ultimoDiaAnio).ForEach(delegate (Fila f)
                    {
                        chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                        chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;

                        //planos fuera del sistema
                        int fechaMes = Convert.ToDateTime(f.Celda("fecha_fabricacion_terminada")).Month;
                        int fechaAnio = Convert.ToDateTime(f.Celda("fecha_fabricacion_terminada")).Year;
                        DateTime iniMes = Convert.ToDateTime(fechaAnio + "-" + fechaMes + "-01");
                        DateTime finMes = Convert.ToDateTime(fechaAnio + "-" + fechaMes + "-" + DateTime.DaysInMonth(fechaAnio, fechaMes));
                        fueraDeSistema.PlanosFabricadosFueraDeSistema(iniMes, finMes);


                        PlanosFaltantes = 0;
                        eficiencia = 0;
                        planosFabricados = (int)f.Celda("planos_fabricados");
                        planosFueraSistema = fueraDeSistema.Filas().Count;
                        planosTotales = planosFabricados + planosFueraSistema;
                        object piezasFabricadas = f.Celda("piezas_totales");

                        if (planosFabricados > 0)
                            eficiencia = (planosFabricados * 100) / (int)NumObjetivo.Value;

                        if (planosFabricados < (int)NumObjetivo.Value)
                            PlanosFaltantes = (int)NumObjetivo.Value - planosFabricados;

                        graficaMaquinadoAnio.Points.AddXY(f.Celda("x").ToString(), planosFabricados);
                        graficaFueraDeSistemaAnio.Points.AddXY(f.Celda("x").ToString(), planosFueraSistema);
                        graficaTotalAnio.Points.AddXY(f.Celda("x").ToString(), planosTotales);

                        //detalles
                        Tabla += "<tr><td align=center>" + f.Celda("x") + "</td>";
                        Tabla += "<td align=center>" + NumObjetivo.Value + "</td>";
                        Tabla += "<td align=center>" + planosFabricados + "</td>";
                        Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                        Tabla += "<td align=center>" + PlanosFaltantes + "</td>";
                        Tabla += "<td align=center>" + piezasFabricadas + "</td>";
                        Tabla += "<td align=center>" + planosTotales + "</td>";
                        Tabla += "<td align=center>" + planosFueraSistema + "</td>";
                        Tabla += "<td align=center>" + eficiencia + " %</td></tr>";
                    });

                    Tabla += "</table></html>";
                    webBrowser2.DocumentText = Tabla;

                    break;
                default:
                    LblTipoSeleccion.Visible = false;
                    CmbMes.Visible = false;
                    NumSemana.Visible = false;
                    DtDia.Visible = false;
                    NumAnio.Visible = false;
                    break;
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (webBrowser2.DocumentText == null || webBrowser2.DocumentText == "" || TxtCorreo.Text == "")
            {
                MessageBox.Show("Favor de generar el reporte primero", "Generar reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ListaCorreo = TxtCorreo.Text.Split(',').ToList();

            //guardar imagen de grafica
            string path = Directory.GetCurrentDirectory() + "temporal_fabricacion";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            chart1.SaveImage(path + "//grafica_fabricacion.png", ChartImageFormat.Png);
            byte[] archivo = File.ReadAllBytes(path + "//grafica_fabricacion.png");


            List<Attachment> Adjunto = new List<Attachment>();
            Adjunto.Add(new Attachment(new MemoryStream(archivo), "grafica_fabricacion.png"));

            bool mensajeEnviado = Global.EnviarCorreo("Reporte de fabricación " + DateTime.Now.Date, 
                "Reporte " + CmbTipoReporte.Text.ToLower() + "<br><br><br>" + TxtComentarios.Text + "<br><br>" + Tabla,
                Global.UsuarioActual.Fila().Celda("correo").ToString(),
                ListaCorreo,
                Adjunto);

            if (mensajeEnviado)
                Close();
        }
    }
}
