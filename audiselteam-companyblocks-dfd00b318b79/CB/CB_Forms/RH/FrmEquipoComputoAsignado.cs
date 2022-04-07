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
    public partial class FrmEquipoComputoAsignado : Ventana
    {
        int IdEmpleado = 0;
        public FrmEquipoComputoAsignado(int idEmpleado)
        {
            InitializeComponent();
            IdEmpleado = idEmpleado;
        }

        private void FrmEquipoComputoAsignado_Load(object sender, EventArgs e)
        {
            CargarComputadoras();
            CargarMonitores();
            CargarAccesorios();
        }

        void CargarComputadoras()
        {
            EquipoComputo computo = new EquipoComputo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", IdEmpleado);

            EquipoComputoUsuario.Modelo().SeleccionarDatos("usuario=@usuario", parametros).ForEach(delegate(Fila equipoUsuario)
            {
                int id = Convert.ToInt32(equipoUsuario.Celda("equipo"));
                computo.CargarDatos(id).ForEach(delegate(Fila f)
                {
                    if (f.Celda("clase").ToString() != "DESKTOP" && f.Celda("clase").ToString() != "LAPTOP")
                        return;

                    string almacenamientoHdd = "N/A";
                    object objHdd = f.Celda("almacenamiento_hdd_descripcion");
                    if (objHdd != null)
                        almacenamientoHdd = objHdd.ToString();

                    string almacenamientoSsd = "N/A";
                    object objSsd = f.Celda("almacenamiento_ssd_descripcion");
                    if (objSsd != null)
                        almacenamientoSsd = objSsd.ToString();

                    string ram = "N/A";
                    object objRam = f.Celda("ram_caracteristicas");
                    if (objRam != null)
                        ram = objRam.ToString();

                    string fechaAlta = "N/A";
                    string fechaAsignacion = "N/A";

                    object objFechaAlta = f.Celda("fecha_alta");
                    if (objRam != null)
                        fechaAlta = Convert.ToDateTime(objFechaAlta).ToString("MMM dd, yyyy");

                    object objFechaAsignacion = equipoUsuario.Celda("fecha_asignacion");
                    if (objFechaAsignacion != null)
                        fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");

                    DgvComputadora.Rows.Add(f.Celda("id").ToString(),
                                                f.Celda("descripcion").ToString(),
                                                f.Celda("marca").ToString(),
                                                f.Celda("modelo").ToString(),
                                                f.Celda("numero_serie").ToString(),
                                                f.Celda("equipo_nombre").ToString(),
                                                f.Celda("equipo_usuario").ToString(),
                                                f.Celda("equipo_contrasena").ToString(),
                                                f.Celda("direccion_mac").ToString(),
                                                f.Celda("sistema_operativo_marca").ToString(),
                                                f.Celda("sistema_operativo_version").ToString(),
                                                f.Celda("sistema_operativo_tipo").ToString(),
                                                almacenamientoHdd,
                                                almacenamientoSsd,
                                                f.Celda("procesador_marca").ToString(),
                                                f.Celda("procesador_descripcion").ToString(),
                                                f.Celda("tarjeta_grafica_marca").ToString(),
                                                f.Celda("tarjeta_grafica_descripcion").ToString(),
                                                ram,
                                                fechaAlta,
                                                fechaAsignacion,
                                                Global.ObjetoATexto(f.Celda("razon_social"), "SIN DEFINIR"));
                });
            });
            DgvComputadora.ClearSelection();
        }

        void CargarMonitores()
        {
            EquipoComputo computo = new EquipoComputo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", IdEmpleado);
            parametros.Add("@monitor", "MONITOR");

            EquipoComputoUsuario.Modelo().SeleccionarDatos("usuario=@usuario", parametros).ForEach(delegate(Fila equipoUsuario)
            {
                computo.CargarDatos(Convert.ToInt32(equipoUsuario.Celda("equipo"))).ForEach(delegate(Fila f)
                {
                    if (f.Celda("clase").ToString() != "MONITOR")
                        return;

                    string fechaAlta = "N/A";
                    string fechaAsignacion = "N/A";

                    object objFechaAlta = f.Celda("fecha_alta");
                    if (objFechaAlta != null)
                        fechaAlta = Convert.ToDateTime(objFechaAlta).ToString("MMM dd, yyyy");

                    object objFechaAsignacion = equipoUsuario.Celda("fecha_asignacion");
                    if (objFechaAsignacion != null)
                        fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");

                    DgvMonitor.Rows.Add(f.Celda("id").ToString(),
                                         f.Celda("descripcion").ToString(),
                                         f.Celda("marca").ToString(),
                                         f.Celda("monitor_pulgadas").ToString(),
                                         f.Celda("modelo").ToString(),
                                         f.Celda("numero_serie").ToString(),
                                         fechaAlta,
                                         fechaAsignacion,
                                         Global.ObjetoATexto(f.Celda("razon_social"), "SIN DEFINIR"));
                });
            });
            DgvComputadora.ClearSelection();
        }

        void CargarAccesorios()
        {
            EquipoComputo computo = new EquipoComputo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", IdEmpleado);
            parametros.Add("@accesorio", "ACCESORIO");

            EquipoComputoUsuario.Modelo().SeleccionarDatos("usuario=@usuario", parametros).ForEach(delegate(Fila equipoUsuario)
            {
                computo.CargarDatos(Convert.ToInt32(equipoUsuario.Celda("equipo"))).ForEach(delegate(Fila f)
                {
                    if (f.Celda("clase").ToString() != "ACCESORIO")
                        return;

                    string fechaAlta = "N/A";
                    string fechaAsignacion = "N/A";

                    object objFechaAlta = f.Celda("fecha_alta");
                    if (objFechaAlta != null)
                        fechaAlta = Convert.ToDateTime(objFechaAlta).ToString("MMM dd, yyyy");

                    object objFechaAsignacion = equipoUsuario.Celda("fecha_asignacion");
                    if (objFechaAsignacion != null)
                        fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");

                    DgvAccesorios.Rows.Add(f.Celda("id").ToString(),
                                        f.Celda("accesorio_tipo").ToString(),
                                        f.Celda("descripcion").ToString(),
                                        f.Celda("marca").ToString(),
                                        f.Celda("modelo").ToString(),
                                        f.Celda("numero_serie").ToString(),
                                        fechaAlta,
                                        fechaAsignacion,
                                        Global.ObjetoATexto(f.Celda("razon_social"), "SIN DEFINIR"));
                });
            });
            DgvComputadora.ClearSelection();
        }

        private void DgvComputadora_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                ordenDeMantenimientoToolStripMenuItem.Enabled = false;
                if (e.Button == MouseButtons.Right)
                {
                    ordenDeMantenimientoToolStripMenuItem.Enabled = true;
                    MenuComputadora.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvComputadora_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvComputadora.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ordenDeMantenimientoToolStripMenuItem.Enabled = true;

                    MenuComputadora.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void ordenDeMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string equipo = "";
            string tipoEquipo = "";
            if (DgvComputadora.SelectedRows.Count > 0)
            {
                equipo = DgvComputadora.SelectedRows[0].Cells["id_computadora"].Value.ToString() + " - " + DgvComputadora.SelectedRows[0].Cells["numero_serie"].Value.ToString();
                tipoEquipo = "EQUIPO DE COMPUTO";
            }
            FrmGenerarOrdenMtoEquipoComputo ordenMantenimiento = new FrmGenerarOrdenMtoEquipoComputo(tipoEquipo, equipo);
            ordenMantenimiento.Show();
        }
    }
}
