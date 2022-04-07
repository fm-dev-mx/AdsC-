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
    public partial class FrmPlanMantenimientoEquipoComputo : Ventana
    {
        int IdEquipoSeleccionado = 0;

        public FrmPlanMantenimientoEquipoComputo()
        {
            InitializeComponent();
        }

        private void FrmPlanMantenimientoEquipoComputo_Load(object sender, EventArgs e)
        {
            CmbFiltro.SelectedIndex = 0;
            CargarPlanMantenimiento();
        }

        private void CargarPlanMantenimiento()
        {
            DgvMantenimiento.Rows.Clear();
            EquipoComputo equipoComputo = new EquipoComputo();
            equipoComputo.SeleccionarDatos("", null).ForEach(delegate(Fila f)
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

                object objResponsableMantenimiento = f.Celda("responsable_mantenimiento");
                if (objResponsableMantenimiento != null)
                    responsableMantenimiento = objResponsableMantenimiento.ToString();
                else
                    responsableMantenimiento = "N/A";

                fechaMantenimiento = Convert.ToDateTime(ultimoMantenimiento);
                DateTime proximoMantenimiento = ObtenerProximaFecha(fechaMantenimiento.AddMonths(periodoMantenimiento), DayOfWeek.Saturday);
                DateTime FechaProxima = proximoMantenimiento.AddDays(-15);

                if(FechaProxima > DateTime.Now)
                    estatus = "A TIEMPO";
                else if (FechaProxima < DateTime.Now && DateTime.Now < proximoMantenimiento)
                    estatus = "PROXIMO";
                else
                    estatus = "TARDE";

                if(estatus == CmbFiltro.Text)
                    DgvMantenimiento.Rows.Add(f.Celda("id").ToString(), f.Celda("id").ToString() + " - " + f.Celda("numero_serie").ToString(), ultimoMantenimiento, responsableMantenimiento, Global.FechaATexto(proximoMantenimiento), estatus);
                else if(CmbFiltro.Text == "TODOS")
                    DgvMantenimiento.Rows.Add(f.Celda("id").ToString(), f.Celda("id").ToString() + " - " + f.Celda("numero_serie").ToString(), ultimoMantenimiento, responsableMantenimiento, Global.FechaATexto(proximoMantenimiento), estatus); 
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

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanMantenimiento();
        }

        private void DgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex < 0)
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

        private void DgvMantenimiento_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)                  
                    MenuMantenimiento.Show(Cursor.Position.X, Cursor.Position.Y);
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

        private void realizarMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            string equipo = DgvMantenimiento.SelectedRows[0].Cells["equipo"].Value.ToString();
            int idEquipo = Convert.ToInt32(DgvMantenimiento.SelectedRows[0].Cells["equipo"].Value.ToString().Split('-')[0].Trim());

            Mantenimiento mantenimiento = new Mantenimiento();
            mantenimiento.SeleccionarMantenimiento(idEquipo, "EQUIPO DE COMPUTO", "PREVENTIVO");

            if (mantenimiento.TieneFilas())
                mensaje = "Continuar con la revisión del manenimiento preventivo";
            else
                mensaje = "¿Está seguro de crear un plan de mantenimiento para " + equipo;

            DialogResult result = MessageBox.Show(mensaje, "Mantenimiento preventivo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                EquipoComputo equipoComputo = new EquipoComputo();

                FrmRealizarMantenimientoPreventivo mantenimientoPreventivo = new FrmRealizarMantenimientoPreventivo("EQUIPO DE COMPUTO", idEquipo, equipoComputo.CargarDatos(idEquipo), "numero_serie");
                if (mantenimientoPreventivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (mantenimientoPreventivo.Finalizar)
                    {                       
                        EquipoComputo equipoComputoUltimoMantenimiento = new EquipoComputo();
                        equipoComputoUltimoMantenimiento.CargarDatos(idEquipo);
                        equipoComputoUltimoMantenimiento.Fila().ModificarCelda("ultimo_mantenimiento", DateTime.Now);
                        equipoComputoUltimoMantenimiento.Fila().ModificarCelda("responsable_mantenimiento", Global.UsuarioActual.NombreCompleto());
                        equipoComputoUltimoMantenimiento.GuardarDatos();
                    }
                    CargarPlanMantenimiento();
                }
            }
        }

        private void ultimoMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdEquipoSeleccionado <= 0)
                return;

            byte[] archivo = FormatosPDF.ReporteDeMantenimientoPreventivoEquipoComputo(IdEquipoSeleccionado, "EQUIPO DE COMPUTO", "PREVENTIVO", true);
            if (archivo == null)
            {
                MessageBox.Show("El equipo seleccionado no cuenta con un mantenimiento", "El mantenimiento no se ha programado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombrePdf = string.Empty;
            if (DgvMantenimiento.SelectedRows[0].Cells["EQUIPO"].Value.ToString().Contains('/'))
                nombrePdf = DgvMantenimiento.SelectedRows[0].Cells["EQUIPO"].Value.ToString().Replace('/', '_');
            else
                nombrePdf = DgvMantenimiento.SelectedRows[0].Cells["EQUIPO"].Value.ToString();

            FrmVisorPDF pdf = new FrmVisorPDF(archivo, "PLAN DE MANTENIMIENTO PREVENTIVO DE EQUIPO DE COMPUTO " + nombrePdf);
            pdf.ShowDialog();

          
        }

        private void BtnHistorialMantenimiento_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento = new Mantenimiento();
            EquipoComputo equipoComputo = new EquipoComputo();
            EquipoComputoUsuario usuarioEquipo = new EquipoComputoUsuario();
            Usuario usuario = new Usuario();
            List<string> ChecarDuplicados = new List<string>();
            List<Fila> CargarMantenimiento = new List<Fila>();

            mantenimiento.CargarHistorialMantenimiento("EQUIPO DE COMPUTO").ForEach(delegate(Fila f)
            {
                string nombre = "";

                equipoComputo.CargarDatos(Convert.ToInt32(f.Celda("equipo"))).ForEach(delegate(Fila filaEquipo)
                {
                    usuarioEquipo.SeleccionarUsuario(Convert.ToInt32(f.Celda("equipo")));
                    if (usuarioEquipo.TieneFilas())
                    {
                        usuario.CargarDatos(Convert.ToInt32(usuarioEquipo.Fila().Celda("usuario")));
                        if (usuario.TieneFilas())
                            nombre = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");
                    }
                  
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

            FrmHistorialMantenimiento historial = new FrmHistorialMantenimiento(CargarMantenimiento, "EQUIPO DE COMPUTO");
           historial.Show();
        }
    }
}
