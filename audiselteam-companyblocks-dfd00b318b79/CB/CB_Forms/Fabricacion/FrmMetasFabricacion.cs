using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmMetasFabricacion : Ventana
    {
        public FrmMetasFabricacion()
        {
            InitializeComponent();
        }

        private void FrmMetasFabricacion_Load(object sender, EventArgs e)
        {
            CargarMetas();
            CmbEstatusProgreso.SelectedIndex = 1;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaMetaFabricacion nueva = new FrmNuevaMetaFabricacion();

            if(nueva.ShowDialog() == DialogResult.OK)
            {
                CargarMetas();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void CargarMetas()
        {
            Usuario responsable = new Usuario();
            Usuario requisitor = new Usuario();

            DgvMetas.Rows.Clear();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@progreso", CmbEstatusProgreso.Text);

            string query = "1=1 and progreso=@progreso ORDER BY DATE(fecha_promesa) ASC";
            if(CmbEstatusProgreso.Text == "TERMINADO")
                query += " limit " + NumLimite.Value;

            MetaFabricacion.Modelo().SeleccionarDatos(query, parametros).ForEach(delegate(Fila f)
            {
                responsable.CargarDatos(Convert.ToInt32(f.Celda("responsable")));
                requisitor.CargarDatos(Convert.ToInt32(f.Celda("requisitor")));

                DgvMetas.Rows.Add(f.Celda("id"), 
                                  f.Celda("entregable"),
                                  f.Celda("tipo_entregable"), 
                                  Global.FechaATexto(f.Celda("fecha_solicitud"), false),
                                  Global.FechaATexto(f.Celda("fecha_promesa"), false), 
                                  requisitor.NombreCompleto(), 
                                  responsable.NombreCompleto(), 
                                  f.Celda("estatus_compromiso"),
                                  f.Celda("progreso"),
                                  Global.FechaATexto(f.Celda("fecha_respuesta"), false),                                 
                                  f.Celda("comentarios_responsable"),
                                  f.Celda("proyecto"),
                                  f.Celda("subensamble"),
                                  f.Celda("plano")
                                  );
            });
        }

        private void MenuMetas_Opening(object sender, CancelEventArgs e)
        {
            eliminarToolStripMenuItem.Enabled = DgvMetas.SelectedRows.Count > 0;
            aceptarCompromisoToolStripMenuItem.Enabled = DgvMetas.SelectedRows.Count > 0;
            rechazarCompromisoToolStripMenuItem.Enabled = DgvMetas.SelectedRows.Count > 0;
            terminarToolStripMenuItem.Enabled = DgvMetas.SelectedRows.Count > 0;
            reprogramarToolStripMenuItem.Enabled = DgvMetas.SelectedRows.Count > 0;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvMetas.SelectedRows.Count <= 0)
                return;

            int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells["id"].Value);
            MetaFabricacion meta = new MetaFabricacion();
            meta.CargarDatos(idMeta);

            if(!meta.TieneFilas())
            {
                MessageBox.Show("No se encontro la meta!", "Meta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(Convert.ToInt32(meta.Fila().Celda("requisitor")) != Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")) )
            {
                MessageBox.Show("No eres el requisitor de esta meta.", "Imposible eliminar meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resp = MessageBox.Show("¿Seguro que quieres eliminar la meta seleccionada?", "Eliminar meta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            string tipoEntregable = meta.Fila().Celda("tipo_entregable").ToString();
            string entregable = meta.Fila().Celda("entregable").ToString();

            LimpiarFechaPromesa(tipoEntregable, entregable);
            meta.BorrarDatos();
            CargarMetas();
        }

        public void LimpiarFechaPromesa(string tipoEntregable, string entregable)
        {
            PlanoProyecto pp = new PlanoProyecto();
            int subensamble = 0;
            decimal proyecto = 0;
            int idPlano = 0;

            if (tipoEntregable == "MODULO")
            {
                subensamble = Convert.ToInt32(entregable.Split('-')[1]);
                proyecto = Convert.ToDecimal(entregable.Split('-')[0].ToString().Replace("M", "").Replace('_', '.'));

                Modulo mod = new Modulo();

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@proyecto", proyecto);
                parametros.Add("@subensamble", subensamble);

                mod.SeleccionarProyectoSubensamble(proyecto, subensamble);
                pp.SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND estatus!='TERMINADO' AND estatus!='ENTREGADO'", parametros);

                if (mod.TieneFilas())
                {
                    mod.Fila().ModificarCelda("fecha_promesa_fabricacion", null);
                    mod.GuardarDatos();
                }

                pp.Filas().ForEach(delegate(Fila f)
                {
                    f.ModificarCelda("fecha_promesa_fabricacion", null);
                });
                pp.GuardarDatos();
            }
            else if (tipoEntregable == "PLANO")
            {
                idPlano = Convert.ToInt32(entregable.Split('-')[0]);

                pp.CargarDatos(idPlano);

                if (pp.TieneFilas())
                {
                    pp.Fila().ModificarCelda("fecha_promesa_fabricacion", null);
                    pp.GuardarDatos();
                }
            }
        }

        private void rechazarCompromisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvMetas.SelectedRows.Count <= 0)
                return;

            string estatusCompromiso = DgvMetas.SelectedRows[0].Cells["estatus_compromiso"].Value.ToString();

            if(estatusCompromiso == "RECHAZADO")
            {
                MessageBox.Show("Esta meta ya fue rechazada anteriormente.", "Imposible rechazar compromiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(estatusCompromiso == "ACEPTADO")
            {
                MessageBox.Show("Esta meta ya fue aceptada, comunicate con el requisitor.", "Imposible rechazar compromiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmIngresarComentario comentario = new FrmIngresarComentario();

            int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells[0].Value);

            MetaFabricacion meta = new MetaFabricacion();
            meta.CargarDatos(idMeta);

            if (!meta.TieneFilas())
            {
                MessageBox.Show("No se encontro la meta!", "Meta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(meta.Fila().Celda("responsable")) != Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")))
            {
                MessageBox.Show("No eres el responsable de la meta.", "Imposible rechazar meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(comentario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                meta.Fila().ModificarCelda("estatus_compromiso", "RECHAZADO");
                meta.Fila().ModificarCelda("comentarios_responsable", comentario.Comentarios);
                meta.Fila().ModificarCelda("fecha_respuesta", DateTime.Now);
                meta.GuardarDatos();
                LimpiarFechaPromesa(meta.Fila().Celda("tipo_entregable").ToString(), meta.Fila().Celda("entregable").ToString());
                CargarMetas();
            }
        }

        private void aceptarCompromisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvMetas.SelectedRows.Count <= 0)
                return;

            int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells[0].Value);

            MetaFabricacion meta = new MetaFabricacion();
            meta.CargarDatos(idMeta);

            if (!meta.TieneFilas())
                return;

            if (Convert.ToInt32(meta.Fila().Celda("responsable")) != Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")))
            {
                MessageBox.Show("No eres el responsable de la meta.", "Imposible aceptar meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string estatusCompromiso = DgvMetas.SelectedRows[0].Cells["estatus_compromiso"].Value.ToString();

            if (estatusCompromiso == "ACEPTADO")
            {
                MessageBox.Show("Esta meta ya fue aceptada anteriormente.", "Imposible aceptar comprimiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (estatusCompromiso == "RECHAZADO")
            {
                MessageBox.Show("Esta meta ya fue rechazada, comunicate con el requisitor.", "Imposible aceptar compromiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resp = MessageBox.Show("¿Seguro que quieres aceptar el compromiso de la meta seleccionada?", "Aceptar compromiso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            meta.Fila().ModificarCelda("estatus_compromiso", "ACEPTADO");
            meta.Fila().ModificarCelda("fecha_respuesta", DateTime.Now);
            meta.Fila().ModificarCelda("progreso", "EN PROCESO");
            meta.GuardarDatos();
            CargarMetas();
        }

        private void terminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells[0].Value);
            MetaFabricacion meta = new MetaFabricacion();
            meta.CargarDatos(idMeta);

            if (!meta.TieneFilas())
                return;

            if (Convert.ToInt32(meta.Fila().Celda("responsable")) != Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")))
            {
                MessageBox.Show("No eres el responsable de la meta.", "Imposible aceptar meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string progreso = DgvMetas.SelectedRows[0].Cells["progreso"].Value.ToString();

            if (progreso == "TERMINADO")
            {
                MessageBox.Show("La meta ya fue terminada", "Meta terminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (progreso != "EN PROCESO")
            {
                MessageBox.Show("No es posible terminar la meta","Terminar meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea terminar la meta seleccionada?", "Terminar meta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.No)
                return;

            string[] datosEntregable = DgvMetas.SelectedRows[0].Cells["entregable"].Value.ToString().Split('-');
            decimal proyecto = Convert.ToDecimal(DgvMetas.SelectedRows[0].Cells["proyecto"].Value);
            int subensamble = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells["subensamble"].Value);
            int idPlano = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells["id_plano"].Value);

            PlanoProyecto planoProyectos = new PlanoProyecto();

            string tipoEntregable = DgvMetas.SelectedRows[0].Cells["tipo_entregable"].Value.ToString();
            switch (tipoEntregable)
            {
                case "MODULO":   
                    if(proyecto <= 0)
                        proyecto = Convert.ToDecimal(datosEntregable[0].Replace("M", "").Replace("_", ".").Trim());
                    if(subensamble <= 0)
                        subensamble = Convert.ToInt32(datosEntregable[1].Trim());
                    
                    foreach(Fila f in planoProyectos.SeleccionarPlanosDeModulo(proyecto, subensamble))
                    {
                        if (f.Celda("estatus").ToString() == "PENDIENTE" || f.Celda("estatus").ToString() == "EN PREPARACION" || f.Celda("estatus").ToString() == "EN FABRICACION")
                        {
                            MessageBox.Show("No puede terminar la meta, favor de terminar todos los procesos correspondientes al modulo");
                            return;
                        }
                    };
                    
                    if (meta.TieneFilas())
                    {
                        meta.Fila().ModificarCelda("progreso", "TERMINADO");
                        meta.GuardarDatos();
                        CargarMetas();
                    }
                    break;
                case "PLANO":

                    if (idPlano <= 0)
                        idPlano = Convert.ToInt32(datosEntregable[0].TrimEnd());

                    planoProyectos.CargarDatos(Convert.ToInt32(idPlano));
                    if(planoProyectos.TieneFilas())
                    {
                        if (planoProyectos.Fila().Celda("estatus").ToString() == "PENDIENTE" || planoProyectos.Fila().Celda("estatus").ToString() == "EN PREPARACION" || planoProyectos.Fila().Celda("estatus").ToString() == "EN FABRICACION")
                        {
                            MessageBox.Show("No puede terminar la meta, favor de terminar todos los procesos correspondientes al plano");
                            return;
                        }
                    }

                    if (meta.TieneFilas())
                    {
                        meta.Fila().ModificarCelda("progreso", "TERMINADO");
                        meta.GuardarDatos();
                        CargarMetas();
                    }
                    break;
                default:
                    return;
            }
        }

        private void CmbEstatusProgreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEstatusProgreso.Text == "TERMINADO")
                NumLimite.Enabled = true;
            else
                NumLimite.Enabled = false;

            CargarMetas();
        }

        private void reprogramarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells[0].Value);
            MetaFabricacion meta = new MetaFabricacion();
            meta.CargarDatos(idMeta);

            if (!meta.TieneFilas())
                return;

            if (Convert.ToInt32(meta.Fila().Celda("requisitor")) != Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")))
            {
                MessageBox.Show("No eres el requisitor de la meta.", "Imposible reprogramar meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DgvMetas.SelectedRows[0].Cells["progreso"].Value.ToString() == "TERMINADO")
            {
                MessageBox.Show("No es posible reprogramar una meta que ya fue terminada", "Reprogramar meta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            FrmSeleccionarFecha reprogramar = new FrmSeleccionarFecha(false);
            if(reprogramar.ShowDialog() == DialogResult.OK)
            {
                if(meta.TieneFilas())
                {
                    meta.Fila().ModificarCelda("fecha_promesa", reprogramar.FechaSeleccionada);
                    meta.Fila().ModificarCelda("estatus_compromiso", "SIN CONFIRMAR");
                    meta.Fila().ModificarCelda("comentarios_responsable", "");
                    meta.Fila().ModificarCelda("progreso", "PENDIENTE");
                    meta.Fila().ModificarCelda("fecha_respuesta", null);
                    meta.Fila().ModificarCelda("estatus_cumplimiento", "");
                    meta.GuardarDatos();
                    CargarMetas();
                }
            }
        }

        private void NumLimite_ValueChanged(object sender, EventArgs e)
        {
            CargarMetas();
        }
    }
}
