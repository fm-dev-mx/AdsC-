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
    public partial class FrmMonitorOperaciones : Form
    {
        public FrmMonitorOperaciones()
        {
            InitializeComponent();
        }

        private void FrmMonitorProceso_Load(object sender, EventArgs e)
        {
            DtDesde.Value = new DateTime(DtDesde.Value.Year, DtDesde.Value.Month, 1);
            DtHasta.Value = new DateTime(DtDesde.Value.Year, DtDesde.Value.Month, DateTime.DaysInMonth(DtDesde.Value.Year, DtDesde.Value.Month));
            WindowState = FormWindowState.Maximized;
            CargarEstatusFinalizacion();
            CargarProcesos();
            CmbEstatusAutorizacion.SelectedIndex = 0;
        }

        private void CargarProcesos()
        {
            Proceso proceso = new Proceso();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@bIngles", 0);

            proceso.SeleccionarDatos("ingles=@bIngles", parametros).ForEach(delegate(Fila f)
            {
                CmbProceso.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("nombre").ToString());
            });
        }

        private void CargarEstatusFinalizacion()
        {
            CmbFinalizacion.SelectedIndex = 0;
        }

        private void CargarMetas(int proceso, string estatusAutorizacion, string estatusFinalizacion, DateTime desde, DateTime hasta)
        {
            DgvMetas.Rows.Clear();

            MetaEntregable buscadorEntregables = new MetaEntregable();
            Modulo buscadorModulos = new Modulo();
            PlanoProyecto buscadorPlanos = new PlanoProyecto();
             MaterialProyecto buscadorMaterial = new MaterialProyecto();
            MaterialFabricante buscadorFabricantes = new MaterialFabricante();
            Meta meta = new Meta();

            meta.SeleccionarMetas(proceso, estatusAutorizacion, estatusFinalizacion, DtDesde.Value, DtHasta.Value).ForEach(delegate(Fila f)
            {
                string nombreProyecto = string.Empty;

                Proyecto proyecto = new Proyecto();
                proyecto.CargarDatos(Convert.ToDecimal(f.Celda("proyecto")));
                if (proyecto.TieneFilas())
                    nombreProyecto = Convert.ToDecimal(f.Celda("proyecto")).ToString("F2") + " - " + proyecto.Fila().Celda("nombre").ToString();

                string tipo_entregable = f.Celda("tipo_entregable").ToString();
                string entregables = Environment.NewLine;
                int idMeta = Convert.ToInt32(f.Celda("id"));

                buscadorEntregables.SeleccionarMeta(idMeta).ForEach(delegate(Fila buscador)
                {
                    int idEntregable = Convert.ToInt32(buscador.Celda("id_entregable"));

                    switch(tipo_entregable)
                    {
                        case "MODULO FABRICADO":
                        case "MATERIAL DE MODULO":
                        case "MODULO CONGELADO":
                            buscadorModulos.CargarDatos(idEntregable);
                            if(buscadorModulos.TieneFilas())
                            {
                                entregables += buscadorModulos.Fila().Celda("subensamble").ToString().PadLeft(2, '0') + " ";
                                entregables += buscadorModulos.Fila().Celda("nombre").ToString();
                                entregables += Environment.NewLine;
                            }
                            break;

                        case "PARTE FABRICADA":
                            buscadorPlanos.CargarDatos(idEntregable);
                            if(buscadorPlanos.TieneFilas())
                            {
                                entregables += buscadorPlanos.Fila().Celda("id").ToString().PadLeft(5, '0') + " ";
                                entregables += buscadorPlanos.Fila().Celda("nombre_archivo").ToString();
                                entregables += Environment.NewLine;
                            }
                            break;
                            case "MATERIAL DE REQUISICION":
                            buscadorMaterial.CargarDatos(idEntregable);
                            if(buscadorMaterial.TieneFilas())
                            {
                                entregables += "Req. # " + buscadorMaterial.Fila().Celda("id").ToString().PadLeft(5, '0');
                                entregables += " | " + buscadorMaterial.Fila().Celda("numero_parte").ToString();
                                entregables += " | " + buscadorMaterial.Fila().Celda("fabricante").ToString();
                                entregables += " | " + buscadorMaterial.Fila().Celda("total").ToString();

                                if (buscadorMaterial.Fila().Celda("tipo_venta").ToString() == "POR PIEZA")
                                    entregables += " pieza(s)";
                                else if (buscadorMaterial.Fila().Celda("tipo_venta").ToString() == "POR PAQUETE")
                                    entregables += " paquete(s)";

                                entregables += Environment.NewLine;
                            }
                            break;

                        case "MATERIAL DE FABRICANTE":
                            buscadorFabricantes.CargarDatos(idEntregable);
                            if(buscadorFabricantes.TieneFilas())
                            {
                                entregables += buscadorFabricantes.Fila().Celda("fabricante").ToString();
                                entregables += Environment.NewLine;
                            }
                            break;
                    }
                    
                });

                string fechaTerminacion = "SIN TERMINAR";
                if (f.Celda("fecha_terminacion") != null)
                    fechaTerminacion = Convert.ToDateTime(f.Celda("fecha_terminacion")).ToString("MMM dd, yyyy");               

                DgvMetas.Rows.Add(f.Celda("id").ToString().PadLeft(5,'0'),
                                  nombreProyecto,
                                  f.Celda("tipo_entregable"),
                                  entregables,
                                  Global.ObjetoATexto(Convert.ToDateTime(f.Celda("fecha_solicitud")).ToString("MMM dd, yyyy"), "N/A"),
                                  Global.ObjetoATexto(Convert.ToDateTime(f.Celda("fecha_promesa")).ToString("MMM dd, yyyy"), "N/A"),
                                  ObtenerNombre(Convert.ToInt32(f.Celda("requisitor"))),                                  
                                  ObtenerNombre(Convert.ToInt32(f.Celda("responsable"))),
                                  Global.ObjetoATexto(f.Celda("estatus_autorizacion"), ""),                                                                
                                  f.Celda("avance") + " " + "%",
                                  fechaTerminacion);
            });
        }

        public string ObtenerNombre(int idUsuario)
        {
            string nombre = "";

            Usuario usuario = new Usuario();
            usuario.CargarDatos(idUsuario);
            if (usuario.TieneFilas())
                nombre = usuario.Fila().Celda("nombre").ToString() + " " + usuario.Fila().Celda("paterno").ToString();

            return nombre;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProceso.Text == "")
                return;

            int proceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
            CargarMetas(proceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
        }

        private void CmbProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProceso.Text == "")
                return;

            int proceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
            CargarMetas(proceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aceptarCompromisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea aceptar la meta seleccionada?", "Aceptar meta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells["id"].Value);
                Meta meta = new Meta();
                meta.CargarDatos(idMeta);
                if(meta.TieneFilas())
                {
                    meta.Fila().ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                    meta.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                    meta.GuardarDatos();
                }

                int idProceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
                CargarMetas(idProceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
            }
        }

        private void rechazarCompromisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea rechazar la meta seleccionada?", "Rechazar meta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmIngresarComentario comentario = new FrmIngresarComentario();
                if (comentario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells["id"].Value);
                    Meta meta = new Meta();
                    meta.CargarDatos(idMeta);
                    if (meta.TieneFilas())
                    {
                        meta.Fila().ModificarCelda("estatus_autorizacion", "RECHAZADO");
                        meta.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                        meta.Fila().ModificarCelda("comentarios_autorizacion", comentario.Comentarios);
                        meta.GuardarDatos();
                    }

                    int idProceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
                    CargarMetas(idProceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
                }
            }
        }

        private void MenuMetas_Opening(object sender, CancelEventArgs e)
        {
            string estatus = DgvMetas.SelectedRows[0].Cells["estatus_autorizacion"].Value.ToString();

            switch (estatus)
            {
                case "PENDIENTE":
                    aceptarMetaToolStripMenuItem.Enabled = true;
                    rechazarMetaToolStripMenuItem.Enabled = true;
                    break;
                default:
                     aceptarMetaToolStripMenuItem.Enabled = false;
                    rechazarMetaToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void DgvMetas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string estatusAutorizacion = DgvMetas.Rows[e.RowIndex].Cells["estatus_autorizacion"].Value.ToString();

            if (estatusAutorizacion == "PENDIENTE")
            {
                DgvMetas.Rows[e.RowIndex].Cells["estatus_autorizacion"].Style.ForeColor = Color.Black;
                DgvMetas.Rows[e.RowIndex].Cells["estatus_autorizacion"].Style.BackColor = Color.Yellow;
            }
            else if (estatusAutorizacion == "AUTORIZADO")
            {
                DgvMetas.Rows[e.RowIndex].Cells["estatus_autorizacion"].Style.ForeColor = Color.Black;
                DgvMetas.Rows[e.RowIndex].Cells["estatus_autorizacion"].Style.BackColor = Color.LawnGreen;
            }
            else if (estatusAutorizacion == "RECHAZADO")
            {
                DgvMetas.Rows[e.RowIndex].Cells["estatus_autorizacion"].Style.ForeColor = Color.White;
                DgvMetas.Rows[e.RowIndex].Cells["estatus_autorizacion"].Style.BackColor = Color.Crimson;
            }
        }

        private void NumLimite_ValueChanged(object sender, EventArgs e)
        {
            if (CmbProceso.Text == "")
                return;

            int idProceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
            CargarMetas(idProceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
        }

        private void DtDesde_ValueChanged(object sender, EventArgs e)
        {
            if (CmbProceso.Text == "")
                return;

            int proceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
            CargarMetas(proceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
        }

        private void DtHasta_ValueChanged(object sender, EventArgs e)
        {
            if (CmbProceso.Text == "")
                return;

            int proceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
            CargarMetas(proceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
        }

        private void BtnMantenimientoCorrectivo_Click(object sender, EventArgs e)
        {
            FrmGenerarOrdenMtoEquipoComputo ordenMantenimiento = new FrmGenerarOrdenMtoEquipoComputo("VEHICULO", "");
            ordenMantenimiento.Show();
        }

        private void BtnMantenimientoCorrectivoEdificio_Click(object sender, EventArgs e)
        {
            FrmGenerarOrdenMtoEquipoComputo ordenMantenimientoEdificio = new FrmGenerarOrdenMtoEquipoComputo("EDIFICIO", "");
            ordenMantenimientoEdificio.Show();
        }

        private void CmbFinalizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProceso.Text == "")
                return;

            int proceso = Convert.ToInt32(CmbProceso.Text.Split('-')[0].Trim());
            CargarMetas(proceso, CmbEstatusAutorizacion.Text, CmbFinalizacion.Text, DtDesde.Value, DtHasta.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de generar una orden de mantenimiento correctivo a una máquina?", "Orden de mantenimiento correctivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmGenerarOrdenMtoEquipoComputo ordenMantenimiento = new FrmGenerarOrdenMtoEquipoComputo("MAQUINARIA", "");
                ordenMantenimiento.Show();
            }
        }

        private void BtnMaterial_Click(object sender, EventArgs e)
        {
            string[] filtrarMaterial= new string[]
            {
                "MATERIA PRIMA COMUN",
                "M.R.O.",
                "SERVICIOS"
            };

            FrmMaterialProyecto material = new FrmMaterialProyecto(0, filtrarMaterial, false);
            material.Show();
        }

        private void BtnMantenimientos_Click(object sender, EventArgs e)
        {
            if (BtnMantenimientos.ContextMenuStrip != null)
                BtnMantenimientos.ContextMenuStrip.Show(BtnMantenimientos, BtnMantenimientos.PointToClient(Cursor.Position));
        }
    }
}
