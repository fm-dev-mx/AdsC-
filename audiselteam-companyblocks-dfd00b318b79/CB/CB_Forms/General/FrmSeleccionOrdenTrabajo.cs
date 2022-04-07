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
    public partial class FrmSeleccionOrdenTrabajo : Ventana
    {
        string TipoEquipo = string.Empty;
        List<Fila> FilasOrdenesDeTrabajoMantenimiento = new List<Fila>();

        public FrmSeleccionOrdenTrabajo(string tipoEquipo, List<Fila> ordenes)
        {
            InitializeComponent();
            FilasOrdenesDeTrabajoMantenimiento = ordenes;
            TipoEquipo = tipoEquipo;
            LblTitulo.Text += " " + tipoEquipo;
        }

        private void FrmSeleccionOrdenTrabajo_Load(object sender, EventArgs e)
        {
            CargarOrdenesTrabajo();
        }

        private void CargarOrdenesTrabajo()
        {
            int pendiente = 0;
            int enProceso = 0;
            DgvMantenimientoCorrectivoRealizado.Rows.Clear();
            DgvOrdenTrabajoPendiente.Rows.Clear();
            DgvOrdenTrabajoProceso.Rows.Clear();

            FilasOrdenesDeTrabajoMantenimiento.ForEach(delegate(Fila f)
            {
                string estatus = "PENDIENTE";
                object objEstatus = f.Celda("estatus");
                if (objEstatus != null)
                    estatus = objEstatus.ToString();

                if (estatus == "PENDIENTE")
                    pendiente++;
                else if (estatus == "EN PROCESO")
                    enProceso++;

                if (estatus == "PENDIENTE")
                    DgvOrdenTrabajoPendiente.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), f.Celda("equipoId").ToString() + " - " + f.Celda("numero_serie").ToString(), f.Celda("solicitado_por").ToString(), Convert.ToDateTime(f.Celda("fecha_registro").ToString()), estatus);
                else if (estatus == "EN PROCESO")
                    DgvOrdenTrabajoProceso.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), f.Celda("equipoId").ToString() + " - " + f.Celda("numero_serie").ToString(), f.Celda("solicitado_por").ToString(), Convert.ToDateTime(f.Celda("fecha_registro").ToString()), estatus);
                else if (estatus == "TERMINADO")
                    DgvMantenimientoCorrectivoRealizado.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), f.Celda("equipoId").ToString() + " - " + f.Celda("numero_serie").ToString(), f.Celda("solicitado_por").ToString(), Convert.ToDateTime(f.Celda("fecha_registro").ToString()), estatus);
            });

            LblPendiente.Text = pendiente.ToString();
            if(Convert.ToInt32(pendiente) > 0)
                LblPendiente.BackColor = Color.Red;
            else
                LblPendiente.BackColor = Color.LightGreen;

            LblEnProceso.Text = enProceso.ToString();
            LblEnProceso.BackColor = Color.LightGreen;
        }

        private void DgvOrdenTrabajo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string mensaje = "";
            string[] datosEquipo = DgvOrdenTrabajoPendiente.SelectedRows[0].Cells["equipo"].Value.ToString().Split('-');

            Mantenimiento mantenimiento = new Mantenimiento();
            mantenimiento.SeleccionarMantenimiento(Convert.ToInt32(datosEquipo[0]), TipoEquipo, "CORRECTIVO");

            if (mantenimiento.TieneFilas())
                mensaje = "Continuar con la revisión del manenimiento preventivo";
            else
                mensaje = "¿Está seguro de crear un plan de mantenimiento para " + DgvOrdenTrabajoPendiente.SelectedRows[0].Cells["equipo"].Value;

            DialogResult result = MessageBox.Show(mensaje, "Manteniemto preventivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                FrmRealizarMantenimientoCorrectivo correctivo = new FrmRealizarMantenimientoCorrectivo(Convert.ToInt32(datosEquipo[0].Trim()), TipoEquipo, Convert.ToInt32(DgvOrdenTrabajoPendiente.SelectedRows[0].Cells["id"].Value));
                correctivo.ShowDialog();
                CargarMantenimientos();
                
            }
        }

        private void CargarMantenimientos()
        {
            string numeroSerie = string.Empty;
            FilasOrdenesDeTrabajoMantenimiento.Clear();
            List<Fila> CargarModeloMantenimiento = new List<Fila>();

            OrdenTrabajoMantenimiento ordenTrabajo = new OrdenTrabajoMantenimiento();
            ordenTrabajo.CargarOrdenMantenimiento().ForEach(delegate(Fila f)
            {
                string tipoEquipo = f.Celda("tipo_equipo").ToString();
                switch (tipoEquipo)
                {
                    case "EDIFICIO":
                        if (TipoEquipo != tipoEquipo)
                            break;

                        CargarModeloMantenimiento = Edificio.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                        numeroSerie = "clave_catastral";
                        break;
                    case "VEHICULO":
                        if (TipoEquipo != tipoEquipo)
                            break;

                        CargarModeloMantenimiento = Vehiculo.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                        numeroSerie = "numero_serie";
                        break;
                    case "MAQUINARIA":
                        if (TipoEquipo != tipoEquipo)
                            break;

                        CargarModeloMantenimiento = MaquinaHerramienta.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                        numeroSerie = "serie";
                        break;
                    case "EQUIPO DE COMPUTO":
                        if (TipoEquipo != tipoEquipo)
                            break;

                        CargarModeloMantenimiento = EquipoComputo.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                        numeroSerie = "numero_serie";
                        break;
                    default:
                        break;
                }

                CargarModeloMantenimiento.ForEach(delegate(Fila filaModelo)
                {
                    if (f.Celda("tipo_equipo").ToString() == TipoEquipo)
                    {
                        Fila equipoDeComputo = new Fila();
                        equipoDeComputo.AgregarCelda("id", Global.ObjetoATexto(f.Celda("id"), "0").PadLeft(4, '0'));
                        equipoDeComputo.AgregarCelda("equipoId", Global.ObjetoATexto(filaModelo.Celda("id"), ""));
                        equipoDeComputo.AgregarCelda("numero_serie", Global.ObjetoATexto(filaModelo.Celda(numeroSerie), ""));
                        equipoDeComputo.AgregarCelda("solicitado_por", Global.ObjetoATexto(f.Celda("solicitado_por"), "0"));
                        equipoDeComputo.AgregarCelda("fecha_registro", Convert.ToDateTime(f.Celda("fecha_registro").ToString()));
                        equipoDeComputo.AgregarCelda("estatus", Global.ObjetoATexto(f.Celda("estatus"), ""));
                        FilasOrdenesDeTrabajoMantenimiento.Add(equipoDeComputo);
                    }
                });
            });
            CargarOrdenesTrabajo();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvOrdenTrabajoProceso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string mensaje = "";
            string[] datosEquipo = DgvOrdenTrabajoProceso.SelectedRows[0].Cells["equipo_en_proceso"].Value.ToString().Split('-');

            Mantenimiento mantenimiento = new Mantenimiento();
            mantenimiento.SeleccionarMantenimiento(Convert.ToInt32(datosEquipo[0]), TipoEquipo, "CORRECTIVO");

            if (mantenimiento.TieneFilas())
                mensaje = "Continuar con la revisión del manenimiento preventivo";
            else
                mensaje = "¿Está seguro de crear un plan de mantenimiento para el " + DgvOrdenTrabajoProceso.SelectedRows[0].Cells["equipo_en_proceso"].Value.ToString();

            DialogResult result = MessageBox.Show(mensaje, "Manteniemto preventivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FrmRealizarMantenimientoCorrectivo correctivo = new FrmRealizarMantenimientoCorrectivo(Convert.ToInt32(datosEquipo[0].Trim()), TipoEquipo, Convert.ToInt32(DgvOrdenTrabajoProceso.SelectedRows[0].Cells["id_en_proceso"].Value));
                correctivo.ShowDialog();
                CargarMantenimientos();
                
            }
        }

        private void DgvMantenimientoCorrectivoRealizado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string[] datosCelda = DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["equipo_realizado"].Value.ToString().Split('-');
             FrmVisorPDF pdf  = null;

             byte[] archivo = null;

            switch (TipoEquipo)
            {
                case "EQUIPO DE COMPUTO":
                    EquipoComputo equipoComputo = new EquipoComputo();
                    EquipoComputoUsuario equipoUsuario = new EquipoComputoUsuario();
 
                    archivo = FormatosPDF.ReporteDeMantenimientoCorrectivo(Convert.ToInt32(datosCelda[0].Trim()), "EQUIPO DE COMPUTO", "CORRECTIVO", Convert.ToInt32(DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["id_realizado"].Value), equipoComputo.CargarDatos(Convert.ToInt32(datosCelda[0].Trim())));                   
                    break;
                case "EDIFICIO":
                    Edificio edificio = new Edificio();
                    List<Fila> filaEdificios = new List<Fila>();
                    edificio.CargarDatos(Convert.ToInt32(datosCelda[0].Trim())).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEdificios = new Fila();
                        nuevaFilaEdificios.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEdificios.AgregarCelda("numero_serie", f.Celda("clave_catastral"));
                        nuevaFilaEdificios.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        filaEdificios.Add(nuevaFilaEdificios);
                    });

                    archivo = FormatosPDF.ReporteDeMantenimientoCorrectivo(Convert.ToInt32(datosCelda[0].Trim()), "EDIFICIO", "CORRECTIVO", Convert.ToInt32(DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["id_realizado"].Value), filaEdificios);
                    break;
                  case "VEHICULO":
                    Vehiculo vehiculo = new Vehiculo();
                    List<Fila> filaVehiculos = new List<Fila>();
                    vehiculo.CargarDatos(Convert.ToInt32(datosCelda[0].Trim())).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEdificios = new Fila();
                        nuevaFilaEdificios.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEdificios.AgregarCelda("numero_serie", f.Celda("numero_serie"));
                        nuevaFilaEdificios.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        filaVehiculos.Add(nuevaFilaEdificios);
                    });

                    archivo = FormatosPDF.ReporteDeMantenimientoCorrectivo(Convert.ToInt32(datosCelda[0].Trim()), "VEHICULO", "CORRECTIVO", Convert.ToInt32(DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["id_realizado"].Value), filaVehiculos);
                    break;
                case "MAQUINARIA":
                    MaquinaHerramienta maquinaria = new MaquinaHerramienta();
                    List<Fila> filaMaquinaria = new List<Fila>();
                    maquinaria.CargarDatos(Convert.ToInt32(datosCelda[0].Trim())).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEdificios = new Fila();
                        nuevaFilaEdificios.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEdificios.AgregarCelda("numero_serie", f.Celda("serie"));
                        nuevaFilaEdificios.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        filaMaquinaria.Add(nuevaFilaEdificios);
                    });

                    archivo = FormatosPDF.ReporteDeMantenimientoCorrectivo(Convert.ToInt32(datosCelda[0].Trim()), "MAQUINARIA", "CORRECTIVO", Convert.ToInt32(DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["id_realizado"].Value), filaMaquinaria);
                    break;
                default:
                    break;
            }

            if (archivo == null)
            {
                MessageBox.Show("El equipo seleccionado no cuenta con un mantenimiento", "El mantenimiento no se ha programado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombrePdf = string.Empty;
            if (DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["equipo_realizado"].Value.ToString().Contains('/'))
                nombrePdf = DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["equipo_realizado"].Value.ToString().Replace('/', '_');
            else
                nombrePdf = DgvMantenimientoCorrectivoRealizado.SelectedRows[0].Cells["equipo_realizado"].Value.ToString();

            pdf = new FrmVisorPDF(archivo, "PLAN DE MANTENIMIENTO PREVENTIVO DE " + TipoEquipo + " " + nombrePdf);
            pdf.ShowDialog();
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnHistorialMantenimiento_Click(object sender, EventArgs e)
        {
            List<Fila> CargarModeloMantenimiento = new List<Fila>();
            Mantenimiento mantenimiento = new Mantenimiento();
            EquipoComputo equipoComputo = new EquipoComputo();
            EquipoComputoUsuario usuarioEquipo = new EquipoComputoUsuario();
            Usuario usuario = new Usuario();
            List<string> ChecarDuplicados = new List<string>();
            List<Fila> CargarMantenimiento = new List<Fila>();

            mantenimiento.CargarHistorialMantenimiento(TipoEquipo).ForEach(delegate(Fila f)
            {
                if (TipoEquipo == "EQUIPO DE COMPUTO")
                    CargarModeloMantenimiento = equipoComputo.CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                else if (TipoEquipo == "EDIFICIO")
                    CargarModeloMantenimiento = Edificio.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                else if (TipoEquipo == "VEHICULO")
                    CargarModeloMantenimiento = Vehiculo.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));
                else if (TipoEquipo == "MAQUINARIA")
                    CargarModeloMantenimiento = MaquinaHerramienta.Modelo().CargarDatos(Convert.ToInt32(f.Celda("equipo")));

                string nombre = "";

                CargarModeloMantenimiento.ForEach(delegate(Fila filaEquipo)
                {
                    if (TipoEquipo == "EQUIPO DE COMPUTO")
                    {
                        usuarioEquipo.SeleccionarUsuario(Convert.ToInt32(f.Celda("equipo")));
                        if (usuarioEquipo.TieneFilas())
                        {
                            usuario.CargarDatos(Convert.ToInt32(usuarioEquipo.Fila().Celda("usuario")));
                            if (usuario.TieneFilas())
                                nombre = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");
                        }
                    }
                    else
                        nombre = Global.ObjetoATexto(filaEquipo.Celda("responsable"), "");

                    string duplicado = f.Celda("equipo").ToString() + " " + f.Celda("tipo_mantenimiento").ToString() + " " + f.Celda("tipo_equipo").ToString();

                    if (!ChecarDuplicados.Contains(duplicado))
                    {
                        Fila nuevaFila = new Fila();
                        nuevaFila.AgregarCelda("id", Global.ObjetoATexto(f.Celda("id"), ""));
                        nuevaFila.AgregarCelda("tipo_mantenimiento", Global.ObjetoATexto(f.Celda("tipo_mantenimiento"), ""));
                        nuevaFila.AgregarCelda("tipo_equipo", Global.ObjetoATexto(f.Celda("tipo_equipo"), ""));
                        nuevaFila.AgregarCelda("idEquipo", Global.ObjetoATexto(filaEquipo.Celda("id"), ""));
                        nuevaFila.AgregarCelda("numero_serie", Global.ObjetoATexto(filaEquipo.Celda("numero_serie"), ""));
                        nuevaFila.AgregarCelda("clase", Global.ObjetoATexto(filaEquipo.Celda("clase"), ""));
                        nuevaFila.AgregarCelda("nombre", nombre);
                        CargarMantenimiento.Add(nuevaFila);
                        ChecarDuplicados.Add(duplicado);
                    }
                });
            });

            FrmHistorialMantenimiento historial = new FrmHistorialMantenimiento(CargarMantenimiento, TipoEquipo);
            historial.Show();
        }
    }
}
