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
    public partial class FrmMonitorMantenimiento : Form
    {
        int IdEquipoSeleccionado = 0;
        string TipoObjetoMantenimiento = string.Empty;
        string NumeroSerie = string.Empty;

        public FrmMonitorMantenimiento()
        {
            InitializeComponent();
        }

        private void FrmMonitorMantenimiento_Load(object sender, EventArgs e)
        {
            CmbTipoMantenimiento.SelectedIndex = 0;
            CmbFiltro.SelectedIndex = 0;
            SeleccionarModeloMantenimiento();
        }

        public void SeleccionarModeloMantenimiento()
        {
            switch (CmbTipoMantenimiento.Text)
            {
                case "EDIFICIO":
                    NumeroSerie = "clave_catastral";
                    TipoObjetoMantenimiento = "EDIFICIO";                  
                    CargarPlanMantenimiento(Edificio.Modelo().SeleccionarDatos("", null), NumeroSerie);
                    break;
                case "VEHICULOS":
                    NumeroSerie = "numero_serie";
                    TipoObjetoMantenimiento = "VEHICULO";
                    CargarPlanMantenimiento(Vehiculo.Modelo().SeleccionarDatos("", null), NumeroSerie);
                    break;
                case "MAQUINARIA":
                    NumeroSerie = "serie";
                    TipoObjetoMantenimiento = "MAQUINARIA";
                    CargarPlanMantenimiento(MaquinaHerramienta.Modelo().SeleccionarDatos("", null), NumeroSerie);
                    break;
            }
        }

        private void CargarPlanMantenimiento(List<Fila> claseModeloMysq, string numeroDeIdentificacion)
        {
            DgvMantenimiento.Rows.Clear();
            claseModeloMysq.ForEach(delegate(Fila f)
            {
                string responsableMantenimiento = string.Empty;
                string ultimoMantenimiento = string.Empty;
                string estatus = string.Empty;

                DateTime fechaMantenimiento;

                int periodoMantenimiento = Convert.ToInt32(f.Celda("periodo_mantenimiento"));

                //No permite agregar a la lista equipos con periodo 0
                if (periodoMantenimiento == 0)
                    return;

                object objFechaMantenimiento = f.Celda("ultimo_mantenimiento");
                if (objFechaMantenimiento != null)
                    ultimoMantenimiento = Global.FechaATexto(objFechaMantenimiento);
                else
                    ultimoMantenimiento = Global.FechaATexto(f.Celda("fecha_alta"));

                DateTime temp;
                if (!DateTime.TryParse(ultimoMantenimiento, out temp))
                    return;
                
                fechaMantenimiento = Convert.ToDateTime(ultimoMantenimiento);
                DateTime proximoMantenimiento = ObtenerProximaFecha(fechaMantenimiento.AddMonths(periodoMantenimiento), DayOfWeek.Saturday);
                DateTime FechaProxima = proximoMantenimiento.AddDays(-15);

                object objResponsableMantenimiento = f.Celda("responsable_mantenimiento");
                if (objResponsableMantenimiento != null)
                    responsableMantenimiento = objResponsableMantenimiento.ToString();
                else
                    responsableMantenimiento = "N/A";

                if (FechaProxima > DateTime.Now)
                    estatus = "A TIEMPO";
                else if (FechaProxima < DateTime.Now && DateTime.Now < proximoMantenimiento )
                    estatus = "PROXIMO";
                else
                    estatus = "TARDE";

                if (estatus == CmbFiltro.Text)
                    DgvMantenimiento.Rows.Add(f.Celda("id").ToString(), f.Celda("id").ToString() + " - " + f.Celda(numeroDeIdentificacion).ToString(), ultimoMantenimiento, responsableMantenimiento, Global.FechaATexto(proximoMantenimiento), estatus);
                else if (CmbFiltro.Text == "TODOS")
                    DgvMantenimiento.Rows.Add(f.Celda("id").ToString(), f.Celda("id").ToString() + " - " + f.Celda(numeroDeIdentificacion).ToString(), ultimoMantenimiento, responsableMantenimiento, Global.FechaATexto(proximoMantenimiento), estatus);
            });

            if (DgvMantenimiento.Rows.Count > 0)
                DgvMantenimiento.ClearSelection();
        }

        public static DateTime ObtenerProximaFecha(DateTime start, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        private void DgvMantenimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvMantenimiento.Rows[e.RowIndex].Cells["estatus"].Value.ToString();
            switch (estatus)
            {
                case "TARDE":
                    DgvMantenimiento.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.Red;
                    break;
                case "PROXIMO":
                    DgvMantenimiento.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.Yellow;
                    break;

                default:
                    break;
            }
        }

        private void CmbTipoMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarModeloMantenimiento();
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarModeloMantenimiento();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string estatus = DgvMantenimiento.SelectedRows[0].Cells["estatus"].Value.ToString();
            string[] equipo = (DgvMantenimiento.SelectedRows[0].Cells["equipo"].Value.ToString()).Split('-');
            IdEquipoSeleccionado = Convert.ToInt32(equipo[0].Trim());

            if (estatus == "PROXIMO" || estatus == "TARDE")
            {
                realizarMantenimientoToolStripMenuItem.Visible = true;
                ultimoMantenimientoToolStripMenuItem.Visible = false;
            }
            else
            {
                realizarMantenimientoToolStripMenuItem.Visible = false;
                ultimoMantenimientoToolStripMenuItem.Visible = true;
            }
        }

        private void DgvMantenimiento_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvMantenimiento.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    realizarMantenimientoToolStripMenuItem.Enabled = false;
                    ultimoMantenimientoToolStripMenuItem.Visible = false;
                    MenuMantenimiento.Show(Cursor.Position.X, Cursor.Position.Y);
                    
                }
            }    
        }

        private void DgvMantenimiento_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (DgvMantenimiento.SelectedRows.Count > 0)
                {
                    if (e.Button == MouseButtons.Right)
                        MenuMantenimiento.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void realizarMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            string equipo = DgvMantenimiento.SelectedRows[0].Cells["equipo"].Value.ToString();
            int idEquipo = Convert.ToInt32(DgvMantenimiento.SelectedRows[0].Cells["equipo"].Value.ToString().Split('-')[0].Trim());

            Mantenimiento mantenimiento = new Mantenimiento();
            mantenimiento.SeleccionarMantenimiento(idEquipo, TipoObjetoMantenimiento, "PREVENTIVO");

            if (mantenimiento.TieneFilas())
                mensaje = "Continuar con la revisión del manenimiento preventivo";
            else
                mensaje = "¿Está seguro de crear un plan de mantenimiento para el equipo " + equipo;

            DialogResult result = MessageBox.Show(mensaje, "Mantenimiento preventivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FrmRealizarMantenimientoPreventivo mantenimientoPreventivo;
                switch (CmbTipoMantenimiento.Text)
                {
                    case "EDIFICIO":
                        Edificio edificio = new Edificio();
                        mantenimientoPreventivo = new FrmRealizarMantenimientoPreventivo(TipoObjetoMantenimiento, idEquipo, edificio.CargarDatos(idEquipo), NumeroSerie);
                        if (mantenimientoPreventivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (mantenimientoPreventivo.Finalizar)
                            {
                                edificio.CargarDatos(idEquipo);
                                edificio.Fila().ModificarCelda("ultimo_mantenimiento", DateTime.Now);
                                edificio.Fila().ModificarCelda("responsable_mantenimiento", Global.UsuarioActual.NombreCompleto());
                                edificio.GuardarDatos();
                            }
                            SeleccionarModeloMantenimiento();
                        }
                        break;
                    case "VEHICULOS":
                        Vehiculo vehiculo = new Vehiculo();
                         mantenimientoPreventivo = new FrmRealizarMantenimientoPreventivo(TipoObjetoMantenimiento, idEquipo, vehiculo.CargarDatos(idEquipo),  NumeroSerie);;
                         if (mantenimientoPreventivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                         {
                             if (mantenimientoPreventivo.Finalizar)
                             {
                                 vehiculo.CargarDatos(idEquipo);
                                 vehiculo.Fila().ModificarCelda("ultimo_mantenimiento", DateTime.Now);
                                 vehiculo.Fila().ModificarCelda("responsable_mantenimiento", Global.UsuarioActual.NombreCompleto());
                                 vehiculo.GuardarDatos();
                             }
                             SeleccionarModeloMantenimiento();
                         }
                         break;
                    case "MAQUINARIA":
                        MaquinaHerramienta maquinaria = new MaquinaHerramienta();
                        mantenimientoPreventivo = new FrmRealizarMantenimientoPreventivo(TipoObjetoMantenimiento, idEquipo, maquinaria.CargarDatos(idEquipo), NumeroSerie);
                        if (mantenimientoPreventivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (mantenimientoPreventivo.Finalizar)
                            {
                                maquinaria.CargarDatos(idEquipo);
                                maquinaria.Fila().ModificarCelda("ultimo_mantenimiento", DateTime.Now);
                                maquinaria.Fila().ModificarCelda("responsable_mantenimiento", Global.UsuarioActual.NombreCompleto());
                                maquinaria.GuardarDatos();
                            }
                            SeleccionarModeloMantenimiento();
                        }
                        break;
                }
            }
        }

        private void ultimoMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdEquipoSeleccionado <= 0)
                return;

            byte[] archivo = null;
            List<Fila> ListaObjetoAMantenimiento = new List<Fila>();

            switch (CmbTipoMantenimiento.Text)
            {
                case "EDIFICIO":

                    Edificio edificio = new Edificio();

                    edificio.CargarDatos(IdEquipoSeleccionado).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEdificios = new Fila();
                        nuevaFilaEdificios.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEdificios.AgregarCelda("numero_serie", f.Celda("clave_catastral"));
                        nuevaFilaEdificios.AgregarCelda("fecha_alta", f.Celda("fecha_alta"));
                        nuevaFilaEdificios.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        ListaObjetoAMantenimiento.Add(nuevaFilaEdificios);
                    });
                    archivo = FormatosPDF.ReporteDeMantenimientoPreventivo(IdEquipoSeleccionado, "EDIFICIO", "PREVENTIVO", ListaObjetoAMantenimiento);
                    break;
                case "VEHICULOS":

                    Vehiculo vehiculo = new Vehiculo();

                    ListaObjetoAMantenimiento = vehiculo.CargarDatos(IdEquipoSeleccionado);
                    archivo = FormatosPDF.ReporteDeMantenimientoPreventivo(IdEquipoSeleccionado, "VEHICULO", "PREVENTIVO", ListaObjetoAMantenimiento);

                    break;
                case "MAQUINARIA":
                    MaquinaHerramienta maquinaria = new MaquinaHerramienta();
                    maquinaria.CargarDatos(IdEquipoSeleccionado).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEdificios = new Fila();
                        nuevaFilaEdificios.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEdificios.AgregarCelda("numero_serie", f.Celda("serie"));
                        nuevaFilaEdificios.AgregarCelda("fecha_alta", f.Celda("fecha_alta"));
                        nuevaFilaEdificios.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        ListaObjetoAMantenimiento.Add(nuevaFilaEdificios);
                    });
                    archivo = FormatosPDF.ReporteDeMantenimientoPreventivo(IdEquipoSeleccionado, "MAQUINARIA", "PREVENTIVO", ListaObjetoAMantenimiento);
                    break;
            }

            if (archivo == null)
            {
                MessageBox.Show("El equipo seleccionado no cuenta con un mantenimiento", "El mantenimiento no se ha programado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombrePdf = string.Empty;
            if(DgvMantenimiento.SelectedRows[0].Cells["EQUIPO"].Value.ToString().Contains('/'))
                nombrePdf = DgvMantenimiento.SelectedRows[0].Cells["EQUIPO"].Value.ToString().Replace('/','_');
            else
                 nombrePdf = DgvMantenimiento.SelectedRows[0].Cells["EQUIPO"].Value.ToString();

            FrmVisorPDF pdfEdificio = new FrmVisorPDF(archivo, "PLAN DE MANTENIMIENTO PREVENTIVO DE " + CmbTipoMantenimiento.Text + " " + nombrePdf);
            pdfEdificio.ShowDialog();
        }

        private void BtnHistorialMantenimiento_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento = new Mantenimiento();
            List<Fila> CargarMantenimiento = new List<Fila>();
            List<Fila> CargarModeloMantenimiento = new List<Fila>();

            mantenimiento.CargarHistorialMantenimiento(TipoObjetoMantenimiento).ForEach(delegate(Fila f)
            {
                if (TipoObjetoMantenimiento == "EDIFICIO")
                    CargarModeloMantenimiento = Edificio.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                else if (TipoObjetoMantenimiento == "VEHICULO")
                    CargarModeloMantenimiento = Vehiculo.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                else if (TipoObjetoMantenimiento == "MAQUINARIA")
                    CargarModeloMantenimiento = MaquinaHerramienta.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));

                CargarModeloMantenimiento.ForEach(delegate(Fila filaEquipo)
                {
                    string duplicado = f.Celda("equipo").ToString() + " " + f.Celda("tipo_mantenimiento").ToString() + " " + f.Celda("tipo_equipo").ToString();
                    Fila nuevaFila = new Fila();
                    nuevaFila.AgregarCelda("id", Global.ObjetoATexto(f.Celda("id"), ""));
                    nuevaFila.AgregarCelda("tipo_mantenimiento",  Global.ObjetoATexto(f.Celda("tipo_mantenimiento"), ""));
                    nuevaFila.AgregarCelda("tipo_equipo",  Global.ObjetoATexto(f.Celda("tipo_equipo"), ""));
                    nuevaFila.AgregarCelda("idEquipo",  Global.ObjetoATexto(filaEquipo.Celda("id"), ""));
                    nuevaFila.AgregarCelda("numero_serie",  Global.ObjetoATexto(filaEquipo.Celda(NumeroSerie), ""));
                    nuevaFila.AgregarCelda("nombre", Global.ObjetoATexto(filaEquipo.Celda("responsable"), ""));
                    nuevaFila.AgregarCelda("clase", Global.ObjetoATexto(filaEquipo.Celda("clase"), ""));
                    CargarMantenimiento.Add(nuevaFila);
                });
            });

            FrmHistorialMantenimiento historial = new FrmHistorialMantenimiento(CargarMantenimiento, TipoObjetoMantenimiento);
            historial.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Fila> CargarFilasOrdenDeTrabajo = new List<Fila>();
            List<Fila> CargarModeloMantenimiento = new List<Fila>();

            OrdenTrabajoMantenimiento ordenTrabajo = new OrdenTrabajoMantenimiento();
            ordenTrabajo.CargarOrdenMantenimiento().ForEach(delegate(Fila f)
            {
                if (TipoObjetoMantenimiento == "EDIFICIO")
                    CargarModeloMantenimiento = Edificio.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                else if (TipoObjetoMantenimiento == "VEHICULO")
                    CargarModeloMantenimiento = Vehiculo.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                else if (TipoObjetoMantenimiento == "MAQUINARIA")
                    CargarModeloMantenimiento = MaquinaHerramienta.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));

                CargarModeloMantenimiento.ForEach(delegate(Fila filaModelo)
                {
                    if (f.Celda("tipo_equipo").ToString() == TipoObjetoMantenimiento)
                    {
                        Fila equipoDeComputo = new Fila();
                        equipoDeComputo.AgregarCelda("id", Global.ObjetoATexto(f.Celda("id"), "0").PadLeft(4, '0'));
                        equipoDeComputo.AgregarCelda("equipoId", Global.ObjetoATexto(filaModelo.Celda("id"), ""));
                        equipoDeComputo.AgregarCelda("numero_serie", Global.ObjetoATexto(filaModelo.Celda(NumeroSerie), ""));
                        equipoDeComputo.AgregarCelda("solicitado_por", Global.ObjetoATexto(f.Celda("solicitado_por"), "0"));
                        equipoDeComputo.AgregarCelda("fecha_registro", Convert.ToDateTime(f.Celda("fecha_registro").ToString()));
                        equipoDeComputo.AgregarCelda("estatus", Global.ObjetoATexto(f.Celda("estatus"), ""));
                        CargarFilasOrdenDeTrabajo.Add(equipoDeComputo);
                    }
                });
            });
            FrmSeleccionOrdenTrabajo orden = new FrmSeleccionOrdenTrabajo(TipoObjetoMantenimiento, CargarFilasOrdenDeTrabajo);
            orden.Show();
        }
    }
}

