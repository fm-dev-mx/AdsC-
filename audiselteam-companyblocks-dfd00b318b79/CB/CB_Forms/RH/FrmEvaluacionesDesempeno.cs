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
    public partial class FrmEvaluacionesDesempeno : Form
    {
        string Puesto = string.Empty;
        int Nivel = 0;
        int IdEmpleado = 0;
        
        Usuario BajoEvaluacion = new Usuario();
        Rol RolUsuarios = new Rol();
        PerfilPuesto Perfil = new PerfilPuesto();
        
        public FrmEvaluacionesDesempeno(int idEmpleado)
        {
            InitializeComponent();
            IdEmpleado = idEmpleado; 
        }

        private void FrmEvaluacionesDesempeno_Load(object sender, EventArgs e)
        {
            BajoEvaluacion.CargarDatos(IdEmpleado);
            Puesto = BajoEvaluacion.Fila().Celda("rol").ToString();
            Nivel = Convert.ToInt32(BajoEvaluacion.Fila().Celda("nivel"));
            Perfil.Cargar(Puesto, Nivel);
            CargarDatosEmpleado();
            splitContainer1.Panel2.Hide();
        }

        void CargarDatosEmpleado()
        {
            BajoEvaluacion.CargarDatos(IdEmpleado);

            if(BajoEvaluacion.TieneFilas())
            {
                string nombre = string.Empty;
                string puesto = string.Empty;

                object objNombre = BajoEvaluacion.Fila().Celda("nombre");
                if(objNombre != null)
                    nombre = objNombre.ToString();

                object objPaterno = BajoEvaluacion.Fila().Celda("paterno");
                if(objPaterno != null)
                    nombre += " " + objPaterno.ToString();

                object objMaterno = BajoEvaluacion.Fila().Celda("materno");
                if(objMaterno != null)
                    nombre += " " + objMaterno.ToString();

                TxtNombre.Text = nombre;
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@rol", Puesto);

                TxtPuestoBajoEvaluacion.Text = Puesto;
                RolUsuarios.SeleccionarDatos("rol=@rol", parametros);
                if (RolUsuarios.TieneFilas())
                {
                    if (Convert.ToInt32(RolUsuarios.Fila().Celda("nivel_maximo")) > 0)
                    {
                         TxtPuestoBajoEvaluacion.Text += " " + Nivel;
                    }
                }
                

                Evaluacion evaluacion = new Evaluacion();
                evaluacion.PromedioEvaluaciones(IdEmpleado);

                if (evaluacion.TieneFilas())
                {
                    int promedio = Convert.ToInt32(evaluacion.Fila().Celda("promedio_resultado"));
                    LblPuntuacion.Text = promedio.ToString();
                    EstiloLabel(LblPuntuacion, promedio);

                    if (LblPuntuacion.Text != "N/A")
                    {
                        CmbEvaluaciones.Enabled = true;
                        evaluacion.Evaluaciones(IdEmpleado).ForEach(delegate(Fila f)
                        {
                            if (Global.ObjetoATexto(f.Celda("fecha"), "") != "")
                                CmbEvaluaciones.Items.Add(f.Celda("id").ToString() + " - " + Convert.ToDateTime(f.Celda("fecha")).ToString("MMM dd, yyyy"));
                        });
                    }
                    else
                    {
                        CmbEvaluaciones.Enabled = false;
                    }
                }
            } 
        }

        private void CmbEvaluaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEvaluaciones.Text == "")
            {
                splitContainer1.Panel2.Hide();
                return;
            }

            int idEvaluacion = Convert.ToInt32(CmbEvaluaciones.Text.Split('-')[0].TrimEnd());
            CargarResultadosDeEvaluacion(idEvaluacion);
            CargarInformacionFinal(idEvaluacion);
            splitContainer1.Panel2.Show();
        }

        void CargarResultadosDeEvaluacion(int idEvaluacion)
        {
            DgvHabilidadesPersonales.Rows.Clear();
            DgvHabilidadesTecnicas.Rows.Clear();

            EvaluacionHabilidad evaluacionHabilidad = new EvaluacionHabilidad();
            evaluacionHabilidad.SeleccionarHabilidades(idEvaluacion).ForEach(delegate(Fila f)
            {
                int idHabilidad = Convert.ToInt32(f.Celda("habilidad"));
                Habilidad.Modelo().CargarDatos(idHabilidad).ForEach(delegate(Fila habilidad)
                {
                    string strHabilidad = "N/A";
                    object objHabilidad = habilidad.Celda("habilidad");
                    if(objHabilidad != null)
                        strHabilidad = objHabilidad.ToString().ToUpper();

                    string strTipoHabilidad = "N/A";
                    object objTipoHabilidad = habilidad.Celda("tipo");
                    if(objTipoHabilidad != null)
                        strTipoHabilidad = objTipoHabilidad.ToString().ToUpper();

                    string strDescripcionHabilidad = "N/A";
                    object objDescripcionHabilidad = habilidad.Celda("descripcion_habilidad");
                    if(objDescripcionHabilidad != null)
                        strDescripcionHabilidad = objDescripcionHabilidad.ToString().ToUpper();

                    string strComentario = "N/A";
                    object objComentario= f.Celda("comentarios");
                    if (objComentario != null)
                        strComentario = objComentario.ToString().ToUpper();

                    int puntuacion = 0;
                    string strPuntuacion = "N/A";
                    object objPuntuacion = f.Celda("puntuacion");
                    if (objPuntuacion != null)
                        puntuacion = Convert.ToInt32(objPuntuacion);

                    strPuntuacion = puntuacion.ToString();

                    if (strTipoHabilidad == "PERSONAL")
                        DgvHabilidadesPersonales.Rows.Add(habilidad.Celda("id").ToString(), strHabilidad, strDescripcionHabilidad, strComentario, strPuntuacion);
                    else if (strTipoHabilidad == "TECNICA")
                        DgvHabilidadesTecnicas.Rows.Add(habilidad.Celda("id").ToString(), strHabilidad, strDescripcionHabilidad, strComentario, strPuntuacion);
                });
            });
        }

        void CargarInformacionFinal(int idEvaluacion)
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.CargarDatos(idEvaluacion);

            //sacamos la informacion de la tabla evaluacion de acuerdo al id
            if(evaluacion.TieneFilas())
            {
                int idEvaluador = 0;
                string puesto = "N/A";
                int iNivel = 0;
                string nombreEvaluador = "N/A";
                object objEvaluador = evaluacion.Fila().Celda("evaluador");
                if (objEvaluador != null)
                    idEvaluador = Convert.ToInt32(objEvaluador.ToString());

                //sacamos el nombre que corresponde al id del evaluador
                Usuario.Modelo().CargarDatos(idEvaluador).ForEach(delegate(Fila usuario)
                {
                    object nombre = usuario.Celda("nombre");
                    if (nombre != null)
                        nombreEvaluador = nombre.ToString();

                    object paterno = usuario.Celda("paterno");
                    if (paterno != null)
                        nombreEvaluador += " " + paterno.ToString();

                    object materno = usuario.Celda("materno");
                    if (materno != null)
                        nombreEvaluador += " " + materno.ToString();

                    object rol = usuario.Celda("rol");
                    if (rol != null)
                        puesto = rol.ToString();

                    object nivel = usuario.Celda("nivel");
                    if(nivel != null)
                        iNivel = Convert.ToInt32(nivel);

                });

                int resultado = 0;
                object objResultado = evaluacion.Fila().Celda("resultado");
                if (objResultado != null)
                    resultado = Convert.ToInt32(objResultado.ToString());

                //llenamos los controles con la informacion del evaluador y el resultado de la evaluacion 
                TxtEvaluador.Text = nombreEvaluador;
                TxtPuestoEvaluador.Text = puesto + " " + iNivel;
                EstiloLabel(LblPuntuacionEvaluacion, resultado);
                LblPuntuacionEvaluacion.Text = resultado.ToString();

            }
        }

        private void DgvHabilidadesPersonales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            EstiloCelda(DgvHabilidadesPersonales, e);
        }

        private void DgvHabilidadesTecnicas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            EstiloCelda(DgvHabilidadesTecnicas, e);
        }

        void EstiloCelda(DataGridView Dgv, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell nivelDesempeno = Dgv.Rows[e.RowIndex].Cells[4];
            int iNivelDesempeno = Convert.ToInt32(nivelDesempeno.Value);

            if(iNivelDesempeno < 80)
            {
                nivelDesempeno.Style.BackColor = Color.Red;
                nivelDesempeno.Style.ForeColor = Color.White;
            }
            else if(iNivelDesempeno >=80 && iNivelDesempeno <=90)
            {
                nivelDesempeno.Style.BackColor = Color.Yellow;
                nivelDesempeno.Style.ForeColor = Color.Black;
            }
            else
            {
                nivelDesempeno.Style.BackColor = Color.LightGreen;
                nivelDesempeno.Style.ForeColor = Color.Black;
            }
        }

        void EstiloLabel(Label lbl, int puntuacion)
        {
            if (puntuacion == 0)
            {
                lbl.Text = "N/A";
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.Black;
            }
            if (puntuacion < 80)
            {
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.Red;
            }
            else if (puntuacion >= 80 && puntuacion <= 90)
            {
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.Yellow;
            }
            else
            {
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.LightGreen;
            }
        }
    }
}
