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
    public partial class FrmProgramarCapacitacion : Ventana
    {
        List<Fila> ListaPlanCapacitaciones = new List<Fila>();
        string ListaCompetencias = string.Empty;
        string NombreCapacitacion = string.Empty;

        public FrmProgramarCapacitacion(List<Fila>listaPlanCapacitaciones = null)
        {
            InitializeComponent();
            ListaPlanCapacitaciones = listaPlanCapacitaciones;
        }

        private void FrmProgramarCapacitacion_Load(object sender, EventArgs e)
        {
            if (ListaPlanCapacitaciones != null)
            {
                CargarPlanesCapacitacion();
                CmbTipo.SelectedIndex = 0;
            }
            else
            {
                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.SeleccionarDatos("", null).ForEach(delegate(Fila f)
                {
                    CmbPlanCapacitacion.Items.Add(f.Celda("id") + " - " + f.Celda("nombre"));
                });

                if (CmbPlanCapacitacion.Items.Count > 0)
                    CmbPlanCapacitacion.SelectedIndex = 0;
                CmbTipo.SelectedIndex = 0;
            }
        }

        private void CargarPlanesCapacitacion()
        {
            CmbPlanCapacitacion.Items.Clear();

            List<string> capacitaciones = new List<string>();
            if (ListaPlanCapacitaciones.Count > 0)
            {
                foreach (Fila f in ListaPlanCapacitaciones)
                {
                    string capacitacion = f.Celda("id").ToString() + " - " + f.Celda("nombre").ToString();
                    if (!capacitaciones.Contains(capacitacion))
                    {
                        CmbPlanCapacitacion.Items.Add(capacitacion);
                        capacitaciones.Add(capacitacion);
                    }
                }

                if (CmbPlanCapacitacion.Items.Count > 0)
                    CmbPlanCapacitacion.SelectedIndex = 0;
            }
        }

        private void CargarResponsable()
        {
            if(CmbPlanCapacitacion.Text == "")
                return;

            CmbResponsable.Items.Clear();

            Usuario usuario = new Usuario();
            usuario.SeleccionarDatos("activo=1 order by nombre asc", null).ForEach(delegate(Fila f)
            {
                CmbResponsable.Items.Add(Global.ObjetoATexto(f.Celda("id"), "") + " - " + Global.ObjetoATexto(f.Celda("nombre"), "") + " " + Global.ObjetoATexto(f.Celda("paterno"), ""));
            });

            if (CmbResponsable.Items.Count > 0)
                CmbResponsable.SelectedIndex = 0;
        }

        private void CargarParticipantes()
        {
            List<int> idParticipante = new List<int>();
            DgvParticipantes.Rows.Clear();
             //Sacamos los datos de los id de las competencias seleccionadas y buscamos
            //las evaluaciones que las contenga
            PlanCapacitacion planCapacitacion = new PlanCapacitacion();
            planCapacitacion.CargarDatos(Convert.ToInt32(CmbPlanCapacitacion.Text.Split('-')[0].TrimEnd()));
            if (planCapacitacion.TieneFilas())
            {
                ListaCompetencias = planCapacitacion.Fila().Celda("nombre").ToString().Replace(" Y ", ", ").Replace(", ", ",");
                foreach (string strCompetencia in ListaCompetencias.Split(','))
                {
                    Evaluacion evaluacion = new Evaluacion();
                    Habilidad habilidad = new Habilidad();
                    habilidad.SeleccionarHabilidad(strCompetencia);
                    if (habilidad.TieneFilas())
                    {
                        //Sacamos el id de la competencia
                        int idHabilidad = Convert.ToInt32(habilidad.Fila().Celda("id"));
                        //seleccionamos a los posibles responsables que hayan sacado > 80 en puntuacion 
                        //en la ultima evaluacion del periodo
                        evaluacion.SeleccionarParticipantesCapacitacion(DateTime.Now.Date, idHabilidad).ForEach(delegate(Fila f)
                        {
                            if (!idParticipante.Contains(Convert.ToInt32(f.Celda("evaluado"))))
                            {
                                DgvParticipantes.Rows.Add(true, Global.ObjetoATexto(f.Celda("evaluado"), ""), Global.ObjetoATexto(f.Celda("nombre"), "") + " " + Global.ObjetoATexto(f.Celda("paterno"), ""));
                                idParticipante.Add(Convert.ToInt32(f.Celda("evaluado")));
                            }

                        });
                    }
                }
            }
        }

        private void CargarDetalles()
        {
            PlanCapacitacion planCapacitacion = new PlanCapacitacion();
            planCapacitacion.CargarDatos(Convert.ToInt32(CmbPlanCapacitacion.Text.Split('-')[0].TrimEnd()));
            if (planCapacitacion.TieneFilas())
                TxtDetalles.Text = Global.ObjetoATexto(planCapacitacion.Fila().Celda("descripcion"),"");
        }

        private void CmbPlanCapacitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDetalles();
            CargarResponsable();
            CargarParticipantes();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario seleccionarUsuario = new FrmSeleccionarUsuario("", true);
            if(seleccionarUsuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<int> listaParticipantes = new List<int>();

                foreach (DataGridViewRow row in DgvParticipantes.Rows)
                    listaParticipantes.Add(Convert.ToInt32(row.Cells["id_usuario"].Value));

                foreach (var usuario in seleccionarUsuario.UsuariosSeleccionados)
                {
                    if(!listaParticipantes.Contains(Convert.ToInt32(usuario.Fila().Celda("id"))))
                        DgvParticipantes.Rows.Add(true, usuario.Fila().Celda("id"), usuario.Fila().Celda("nombre") + " " + usuario.Fila().Celda("paterno"));
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            bool participanteSeleccionado = false;
            foreach (DataGridViewRow row in DgvParticipantes.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value))
                    participanteSeleccionado = true;
            }

            if(!participanteSeleccionado)
            {
                MessageBox.Show("Debe seleccionar por lo menos a un participante", "No se seleccionaron participantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PlanCapacitacion planCapacitacion = new PlanCapacitacion();
            planCapacitacion.CargarDatos(Convert.ToInt32(CmbPlanCapacitacion.Text.Split('-')[0].TrimEnd()));
            if( planCapacitacion.TieneFilas())
            {
                Fila insertarEvento = new Fila();
                insertarEvento.AgregarCelda("nombre", "CAPACITACION " + planCapacitacion.Fila().Celda("nombre"));
                insertarEvento.AgregarCelda("descripcion",  planCapacitacion.Fila().Celda("nombre"));
                insertarEvento.AgregarCelda("tipo", "CAPACITACION");
                insertarEvento.AgregarCelda("fecha", Convert.ToDateTime(DtpFecha.Value.ToShortDateString().ToString() + " " + DtpHora.Value.ToShortTimeString().ToString()));
                insertarEvento.AgregarCelda("topico", 0);
                int idJunta  = Convert.ToInt32(JuntaEvento.Modelo().Insertar(insertarEvento).Celda("id"));

                Fila insertarCapacitacion = new Fila();
                insertarCapacitacion.AgregarCelda("plan_capacitacion", CmbPlanCapacitacion.Text.Split('-')[0].TrimEnd());
                insertarCapacitacion.AgregarCelda("evento", idJunta);
                insertarCapacitacion.AgregarCelda("responsable", CmbResponsable.Text.Split('-')[0].TrimEnd());
                insertarCapacitacion.AgregarCelda("tipo", CmbTipo.Text);
                int idCapacitacion = Convert.ToInt32(Capacitacion.Modelo().Insertar(insertarCapacitacion).Celda("id"));

                //insertar participantes
                foreach (DataGridViewRow row in DgvParticipantes.Rows)
	            {
                    if (Convert.ToBoolean(row.Cells["check"].Value))
                    {
                        Fila insertarInvitados = new Fila();
                        insertarInvitados.AgregarCelda("evento", idJunta);
                        insertarInvitados.AgregarCelda("usuario", row.Cells["id_usuario"].Value);
                        JuntaInvitado.Modelo().Insertar(insertarInvitados);

                        Fila insertarCapacitacionInvitados = new Fila();
                        insertarCapacitacionInvitados.AgregarCelda("capacitacion", idCapacitacion);
                        insertarCapacitacionInvitados.AgregarCelda("usuario", row.Cells["id_usuario"].Value);
                        CapacitacionParticipante.Modelo().Insertar(insertarCapacitacionInvitados);
                    }
	            }

                //insertar responsable
                Fila insertarResponsable = new Fila();
                insertarResponsable.AgregarCelda("evento", idJunta);
                insertarResponsable.AgregarCelda("usuario", CmbResponsable.Text.Split('-')[0].TrimEnd());
                JuntaInvitado.Modelo().Insertar(insertarResponsable);
            }
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTipo.Text == "EXTERNA")
            {
                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.CargarDatos(Convert.ToInt32(CmbPlanCapacitacion.Text.Split('-')[0].TrimEnd()));
                if(Convert.ToInt32(Global.ObjetoATexto(planCapacitacion.Fila().Celda("catalogo_material"), "0")) == 0)
                {
                    MessageBox.Show("El plan que seleccionó no tiene configurado un número de parte, edite el plan de capacitación y configure un número de parte", "Configure un número de parte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbTipo.SelectedIndex = 0;
                }
            }
        }
    }
}
