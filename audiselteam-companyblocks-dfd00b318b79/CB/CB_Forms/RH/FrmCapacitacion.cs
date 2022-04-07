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
    public partial class FrmCapacitacion : Form
    {
        public FrmCapacitacion()
        {
            InitializeComponent();
        }


        public void CargarCapacitaciones()
        {
            DateTime fechaInicio = new DateTime(Convert.ToInt32(NumYearPrograma.Value), 01, 01);
            DateTime fechaFin = new DateTime(Convert.ToInt32(NumYearPrograma.Value), 12, 31);

            DgvCapacitaciones.Rows.Clear();
            JuntaEvento.Modelo().SeleccionarRangoFecha(fechaInicio, fechaFin, "CAPACITACION").ForEach(delegate(Fila f)
            {
                DateTime fechaPlanificada;
                DateTime fechaRealizacion;
                string strCumplimiento = "N/A";
                object objFechaPlanificada = f.Celda("fecha");
                object objFechaRealizacion = f.Celda("fecha_realizacion");

                if (objFechaPlanificada != null && objFechaRealizacion != null)
                {
                    fechaPlanificada = Convert.ToDateTime(objFechaPlanificada);
                    fechaRealizacion = Convert.ToDateTime(objFechaRealizacion);

                    if (fechaRealizacion.Date >= fechaPlanificada.Date)
                    {
                        strCumplimiento = "CUMPLIMIENTO CON " + (fechaRealizacion.Date - fechaPlanificada.Date).Days + " DIAS DE RETRASO";
                    }
                }
                else if (objFechaPlanificada != null)
                {
                    fechaPlanificada = Convert.ToDateTime(objFechaPlanificada);

                    if (fechaPlanificada.Date < DateTime.Now.Date)
                        strCumplimiento = "INCUMPLIMIENTO CON " + (DateTime.Now.Date - fechaPlanificada.Date).Days + " DIAS DE RETRASO";
                }

                string responsable = string.Empty;

                Capacitacion capacitacion = new Capacitacion();
                capacitacion.SeleccionarResponsable(Convert.ToInt32(f.Celda("id")));
                if(capacitacion.TieneFilas())
                {
                    responsable = Global.ObjetoATexto(capacitacion.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(capacitacion.Fila().Celda("paterno"), "");
                }

                DgvCapacitaciones.Rows.Add(f.Celda("id"), f.Celda("nombre"), f.Celda("descripcion"), responsable, f.Celda("tipo"), Global.FechaATexto(objFechaPlanificada, false), f.Celda("estatus"), Global.FechaATexto(objFechaRealizacion, false), strCumplimiento);
            });
        }

        private void marcarComoRealizadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvCapacitaciones.SelectedRows.Count == 0)
                return;

            int idCapacitacion = Convert.ToInt32(DgvCapacitaciones.SelectedRows[0].Cells[0].Value);

            FrmSeleccionarFecha fecha = new FrmSeleccionarFecha();

            if (fecha.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                JuntaEvento eventoCapacitacion = new JuntaEvento();
                eventoCapacitacion.CargarDatos(idCapacitacion);

                DialogResult resp = MessageBox.Show("Seguro que quieres marcar esta capacitación como realizada?", "Capacitación realiada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp != System.Windows.Forms.DialogResult.Yes)
                    return;

                if (eventoCapacitacion.TieneFilas())
                {
                    eventoCapacitacion.Fila().ModificarCelda("estatus", "REALIZADO");
                    eventoCapacitacion.Fila().ModificarCelda("fecha_realizacion", fecha.FechaSeleccionada);
                    eventoCapacitacion.GuardarDatos();
                    CargarCapacitaciones();
                }
            }
        }

        private void MenuCapacitacion_Opening(object sender, CancelEventArgs e)
        {
            if (DgvCapacitaciones.SelectedRows.Count == 0)
                return;

            marcarComoRealizadaToolStripMenuItem.Enabled = DgvCapacitaciones.SelectedRows[0].Cells["estatus"].Value.ToString() == "PENDIENTE";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    CargarNecesidadesCapacitacion();
                    break;

                case 1:
                    CargarCapacitaciones();
                    break;

                case 2:
                    CargarplanCapacitaciones();
                    break;
            }
        }

        private void CargarplanCapacitaciones()
        {
            DgvPlanesCapacitacion.Rows.Clear();

            PlanCapacitacion planCapacitacion = new PlanCapacitacion();
            planCapacitacion.SeleccionarDatos("", null).ForEach(delegate(Fila f)
            {
                Usuario usuario = new Usuario();
                usuario.CargarDatos(Convert.ToInt32(f.Celda("usuario_creacion")));

                string usuarioCreacion = string.Empty;
                string usuarioModificacion = string.Empty;

                if(usuario.TieneFilas())
                    usuarioCreacion = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");                

                usuario.CargarDatos(Convert.ToInt32(f.Celda("usuario_modificacion")));
                if(usuario.TieneFilas())
                    usuarioModificacion = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");

                string fechaModificacion = Global.FechaATexto(f.Celda("fecha_modificacion"));

                DgvPlanesCapacitacion.Rows.Add(f.Celda("id"), f.Celda("nombre"), Global.FechaATexto(f.Celda("fecha_creacion")), usuarioCreacion, fechaModificacion, usuarioModificacion);
            });

            if (DgvPlanesCapacitacion.Rows.Count > 0)
                DgvPlanesCapacitacion.ClearSelection();
        }

        private void CmbYear_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        public void CargarNecesidadesCapacitacion()
        {
            int iYear = Convert.ToInt32(NumYearNecesidades.Value);
            DateTime fechaMenor;
            DateTime fechaMayor;

            if (NumEvaluacion.Value == 1)
            {
                fechaMenor = new DateTime(iYear, 01, 01);
                fechaMayor = new DateTime(iYear, 06, 30);
            }
            else
            {
                fechaMenor = new DateTime(iYear, 07, 01);
                fechaMayor = new DateTime(iYear, 12, 31);
            }

            string sql = "SELECT evaluaciones_habilidades.id, evaluaciones_habilidades.habilidad, habilidades.habilidad AS nombre_habilidad, habilidades.tipo AS tipo_habilidad,";
	        sql += "AVG(evaluaciones_habilidades.puntuacion) as promedio_habilidad, usuarios.nombre, usuarios.paterno ";
            sql += "FROM audisel.evaluaciones_habilidades ";
            sql += "INNER JOIN evaluaciones ON evaluaciones_habilidades.evaluacion=evaluaciones.id ";
            sql += "INNER JOIN usuarios ON usuarios.id=evaluaciones.evaluado ";
            sql += "INNER JOIN habilidades ON habilidades.id=evaluaciones_habilidades.habilidad ";
            sql += "WHERE (evaluaciones.fecha BETWEEN @fecha_menor AND @fecha_mayor) ";
            sql += "GROUP BY evaluaciones_habilidades.habilidad ";
            sql += "ORDER BY promedio_habilidad ASC;";

            EvaluacionHabilidad ev = new EvaluacionHabilidad();
            ev.ConstruirQuery(sql);
            ev.AgregarParametro("@fecha_menor", fechaMenor);
            ev.AgregarParametro("@fecha_mayor", fechaMayor);
            ev.EjecutarQuery();

            DgvNecesidadesCapacitacion.Rows.Clear();
            ev.LeerFilas().ForEach(delegate(Fila f)
            {
                string strRecomendacion = "NINGUNA";
                string strCapacitacionesProgramadas = "NINGUNA";

                decimal promedioHabilidad = Convert.ToDecimal(f.Celda("promedio_habilidad"));

                if (promedioHabilidad < 90 && promedioHabilidad >= 80)
                    strRecomendacion = "MONITOREAR";
                else if (promedioHabilidad < 80)
                    strRecomendacion = "DESARROLLAR";

                DgvNecesidadesCapacitacion.Rows.Add(f.Celda("habilidad"), 
                                                    f.Celda("nombre_habilidad"),   
                                                    f.Celda("tipo_habilidad"),
                                                    promedioHabilidad.ToString("F2"), 
                                                    strRecomendacion, 
                                                    strCapacitacionesProgramadas
                                                    );

                DataGridViewRow filaAgregada = DgvNecesidadesCapacitacion.Rows[DgvNecesidadesCapacitacion.Rows.Count - 1];

                DataGridViewCellStyle estiloCeldaRecomentacion = filaAgregada.Cells["recomendacion"].Style;

                switch(strRecomendacion)
                {
                    case "DESARROLLAR":
                        estiloCeldaRecomentacion.BackColor = Color.Red;
                        estiloCeldaRecomentacion.ForeColor = Color.White;
                        break;

                    case "MONITOREAR":
                        estiloCeldaRecomentacion.BackColor = Color.Yellow;
                        estiloCeldaRecomentacion.ForeColor = Color.Black;
                        break;

                    case "NINGUNA":
                        estiloCeldaRecomentacion.BackColor = Color.LightGreen;
                        estiloCeldaRecomentacion.ForeColor = Color.Black;
                        break;
                }

            });
        }

        private void FrmCapacitacion_Load(object sender, EventArgs e)
        {
            NumYearNecesidades.Value = DateTime.Now.Year;
            NumYearPrograma.Value = DateTime.Now.Year;

            if (DateTime.Now.Month > 6)
                NumEvaluacion.Value = 2;

            CargarNecesidadesCapacitacion();
        }

        private void NumYearPrograma_ValueChanged(object sender, EventArgs e)
        {
            CargarCapacitaciones();
        }

        private void NumYearNecesidades_ValueChanged(object sender, EventArgs e)
        {
            CargarNecesidadesCapacitacion();
        }

        private void NumEvaluacion_ValueChanged(object sender, EventArgs e)
        {
            CargarNecesidadesCapacitacion();
        }

        private void crearPlanDeCapacitaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Seguro que quieres crear un plan de capacitación para desarrollar las competencias seleccionadas?", "Crear plan de capacitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            string nombreCapacitacion = string.Empty;
            string idCompetencias = string.Empty;

            //se agarran las competencias seleccionadas
            foreach (DataGridViewRow row in DgvNecesidadesCapacitacion.SelectedRows)
            {
                nombreCapacitacion += row.Cells["competencia"].Value + ",";
                idCompetencias += row.Cells["id"].Value + ",";
            }

            nombreCapacitacion = nombreCapacitacion.TrimEnd(',');
            idCompetencias = idCompetencias.TrimEnd(',');

            //construimos el nombre con las competencias
            if (nombreCapacitacion.Contains(','))
            {
                int indiceUltimaComa = nombreCapacitacion.LastIndexOf(',');
                nombreCapacitacion = nombreCapacitacion.Remove(indiceUltimaComa, 1).Insert(indiceUltimaComa, " Y ").Replace(",", ", ");
            }

            if (!ValidarCompetenciaNoFormeParteEnCapacitacion())
                return;

            // Crear la capacitacion en funcion de las competencias que estan seleccionadas (maximo 3)
            Fila insertarPlanCapacitacion = new Fila();
            insertarPlanCapacitacion.AgregarCelda("nombre", nombreCapacitacion);
            insertarPlanCapacitacion.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
            insertarPlanCapacitacion.AgregarCelda("fecha_creacion", DateTime.Now);
            insertarPlanCapacitacion.AgregarCelda("usuario_modificacion", Global.UsuarioActual.Fila().Celda("id"));
            insertarPlanCapacitacion.AgregarCelda("fecha_modificacion", DateTime.Now);
            int idPlanCapactacion = Convert.ToInt32(PlanCapacitacion.Modelo().Insertar(insertarPlanCapacitacion).Celda("id"));

            //insertamos las competencias
            foreach (string competencia in idCompetencias.Split(','))
            {
                Fila insertarCompetencia = new Fila();
                insertarCompetencia.AgregarCelda("plan_capacitacion", idPlanCapactacion);
                insertarCompetencia.AgregarCelda("competencia", competencia);              
                PlanCapacitacionCompetencia.Modelo().Insertar(insertarCompetencia);
            }

            FrmPlanDeCapacitacion plan = new FrmPlanDeCapacitacion(idPlanCapactacion);
            plan.ShowDialog();
        }

        public bool ValidarCompetenciaNoFormeParteEnCapacitacion()
        {
            //se agarran las competencias seleccionadas
            PlanCapacitacionCompetencia competencia = new PlanCapacitacionCompetencia();
            string competenciasRepetidas = string.Empty;

            foreach (DataGridViewRow row in DgvNecesidadesCapacitacion.SelectedRows)
            {
                competencia.BuscarCompetencia(Convert.ToInt32(row.Cells["id"].Value));
                if (competencia.TieneFilas())
                {
                    Habilidad habilidad = new Habilidad();
                    habilidad.CargarDatos(Convert.ToInt32(row.Cells["id"].Value));
                    competenciasRepetidas += habilidad.Fila().Celda("habilidad") + ", ";
                }
            }
         
            if(competenciasRepetidas != "")
            {
                competenciasRepetidas = competenciasRepetidas.TrimEnd();
                DialogResult res = MessageBox.Show("Las competencias " + competenciasRepetidas + " ya forma parte de otro plan de capacitación, ¿Desea crear un nuevo plan de capacitación?", "Crear plan de capacitación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        private void DgvNecesidadesCapacitacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
        }

        private void DgvNecesidadesCapacitacion_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvNecesidadesCapacitacion.SelectedRows.Count > 0 && DgvNecesidadesCapacitacion.SelectedRows.Count <= 3)
            {
                crearPlanDeCapacitaciToolStripMenuItem.Enabled = true;
                programarCapacitacionToolStripMenuItem.Enabled = true;
            }
            else
            {
                crearPlanDeCapacitaciToolStripMenuItem.Enabled = false;
                programarCapacitacionToolStripMenuItem.Enabled = false;
            }
        }

        private void nuevoPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idPlanCapacitacion = Convert.ToInt32(DgvPlanesCapacitacion.SelectedRows[0].Cells["id_plan_capacitacion"].Value);
            FrmPlanDeCapacitacion verPlanCapacitacion = new FrmPlanDeCapacitacion(idPlanCapacitacion, false);
            verPlanCapacitacion.Show();
        }

        private void MenuPlanesCapacitacion_Opening(object sender, CancelEventArgs e)
        {
            if (DgvPlanesCapacitacion.Rows.Count > 0 && DgvPlanesCapacitacion.SelectedRows.Count == 1)
            {
                nuevoPlanToolStripMenuItem.Visible = true;
                editarPlanToolStripMenuItem.Visible = true;
                eliminarToolStripMenuItem.Visible = true;
            }
            else
            {
                nuevoPlanToolStripMenuItem.Visible = false;
                editarPlanToolStripMenuItem.Visible = false;
                eliminarToolStripMenuItem.Visible = false;
            }
        }

        private void editarPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idPlanCapacitacion = Convert.ToInt32(DgvPlanesCapacitacion.SelectedRows[0].Cells["id_plan_capacitacion"].Value);
            FrmPlanDeCapacitacion verPlanCapacitacion = new FrmPlanDeCapacitacion(idPlanCapacitacion);
            verPlanCapacitacion.Show();
        }

        private void programarCapacitacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Seleccionar de 1-3 competencias
            if (DgvNecesidadesCapacitacion.SelectedRows.Count <= 3 && DgvNecesidadesCapacitacion.SelectedRows.Count > 0)
            {
                 List<int> competenciasSeleccionadas = new List<int>();
                foreach (DataGridViewRow row in DgvNecesidadesCapacitacion.SelectedRows)
                    competenciasSeleccionadas.Add(Convert.ToInt32(row.Cells["id"].Value));

                DateTime fechaDe;
                DateTime fechaHasta;

                if (Convert.ToInt32(NumEvaluacion.Value) == 1)
                {
                    fechaHasta = Convert.ToDateTime(NumYearNecesidades.Value + "-01-01");
                    fechaDe = Convert.ToDateTime(NumYearNecesidades.Value + "-06-30");
                }
                else
                {
                    fechaDe = Convert.ToDateTime(NumYearNecesidades.Value + "-07-01");
                    fechaHasta = Convert.ToDateTime(NumYearNecesidades.Value + "-12-31");
                }

                //deacuerdo a los id seleccionados buscar capacitaciones que concuerden con las capacitaciones (de 1 a 3)
                PlanCapacitacionCompetencia planCapacitacionCompetencia = new PlanCapacitacionCompetencia();                
                List<Fila> planes = planCapacitacionCompetencia.SeleccionarPlanesCapacitacion(competenciasSeleccionadas, fechaDe, fechaHasta);
                if(planes.Count > 0)
                {
                    //llear form de programar capacitacion
                    FrmProgramarCapacitacion programarCapacitacion = new FrmProgramarCapacitacion(planes);
                    programarCapacitacion.Show();
                }
                else
                {
                    MessageBox.Show("No se encontraron capacitaciones enfocadas a desarrollar las competencias seleccionadas", "No existe capacitación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Debe seleccionar entre 1 y 3 competencias", "Seleccionar competencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void programarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProgramarCapacitacion programarCapacitacion = new FrmProgramarCapacitacion();
            programarCapacitacion.Show();
        }

        private void verPlanDeCapacitaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capacitacion eventoCapacitacion = new Capacitacion();
            eventoCapacitacion.BuscarPlanCapacitacion(Convert.ToInt32(DgvCapacitaciones.SelectedRows[0].Cells["id_evento"].Value));
            if(eventoCapacitacion.TieneFilas())
            {
                FrmPlanDeCapacitacion plan = new FrmPlanDeCapacitacion(Convert.ToInt32(eventoCapacitacion.Fila().Celda("plan_capacitacion")), false);
                plan.Show();  
            }
            else
                MessageBox.Show("No se encontró la capacitación seleccionada.", "No existe capacitación", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void MenuCompetencias_Opening(object sender, CancelEventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Está seguro de eliminar el plan de capacitación seleccionado?", "Borrar plan de capacitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != System.Windows.Forms.DialogResult.Yes)
                return;

            int idPlanCapacitacion = Convert.ToInt32(DgvPlanesCapacitacion.SelectedRows[0].Cells["id_plan_capacitacion"].Value);
            PlanCapacitacion eliminarPlanCapacitacion = new PlanCapacitacion();
            eliminarPlanCapacitacion.CargarDatos(idPlanCapacitacion);
            eliminarPlanCapacitacion.BorrarDatos(idPlanCapacitacion);
            eliminarPlanCapacitacion.GuardarDatos();

            PlanCapacitacionCompetencia.Modelo().SeleccionarCompetencias(idPlanCapacitacion).ForEach(delegate(Fila f)
            {
                PlanCapacitacionCompetencia eliminarPlanCompetencias = new PlanCapacitacionCompetencia();
                eliminarPlanCompetencias.CargarDatos(Convert.ToInt32(f.Celda("id")));
                eliminarPlanCompetencias.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                eliminarPlanCompetencias.GuardarDatos();
            });

            Capacitacion cargarCapacitacion = new Capacitacion();
            cargarCapacitacion.BuscarEvento(idPlanCapacitacion);
            if (cargarCapacitacion.TieneFilas())
            {
                int idJuntaEvento = Convert.ToInt32(cargarCapacitacion.Fila().Celda("evento"));
                int idCapacitacion = Convert.ToInt32(cargarCapacitacion.Fila().Celda("id"));

                JuntaInvitado.Modelo().BuscarInvitados(idJuntaEvento).ForEach(delegate(Fila f)
                {
                    JuntaInvitado eliminarInvitados = new JuntaInvitado();
                    eliminarInvitados.CargarDatos(Convert.ToInt32(f.Celda("id")));
                    eliminarInvitados.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                    eliminarInvitados.GuardarDatos();
                });

                CapacitacionParticipante.Modelo().BuscarInvitados(idCapacitacion).ForEach(delegate(Fila f)
                {
                    CapacitacionParticipante eliminarCapacitacionInvitados = new CapacitacionParticipante();
                    eliminarCapacitacionInvitados.CargarDatos(Convert.ToInt32(f.Celda("id")));
                    eliminarCapacitacionInvitados.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                    eliminarCapacitacionInvitados.GuardarDatos();
                });

                Capacitacion eliminarCapacitacion = new Capacitacion();
                eliminarCapacitacion.CargarDatos(Convert.ToInt32(cargarCapacitacion.Fila().Celda("id")));
                eliminarCapacitacion.BorrarDatos(Convert.ToInt32(cargarCapacitacion.Fila().Celda("id")));
                eliminarCapacitacion.GuardarDatos();
            }
        }
    }
}
