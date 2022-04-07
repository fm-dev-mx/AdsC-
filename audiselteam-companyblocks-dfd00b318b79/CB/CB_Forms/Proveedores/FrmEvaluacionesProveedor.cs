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
    public partial class FrmEvaluacionesProveedor : Form
    {
        int IdProveedor = 0;
        public FrmEvaluacionesProveedor(int idProveedor)
        {
            InitializeComponent();
            IdProveedor = idProveedor;
        }

        private void FrmEvaluacionesProveedor_Load(object sender, EventArgs e)
        {
            EvaluacionProveedor evaluaciones = new EvaluacionProveedor();
            Proveedor proveedor = new Proveedor();
            Usuario usuario = new Usuario();

            proveedor.CargarDatos(IdProveedor);
            TxtNombre.Text = proveedor.Fila().Celda("nombre").ToString();
            CargarDatosEmpleado();
        }

        void CargarDatosEmpleado()
        {
            EvaluacionProveedor  evaluacion = new EvaluacionProveedor ();
            evaluacion.PromedioEvaluaciones(IdProveedor);

            if (evaluacion.TieneFilas())
            {
                int promedio = Convert.ToInt32(evaluacion.Fila().Celda("promedio_resultado"));
                LblPuntuacion.Text = promedio.ToString() + "%";
                EstiloLabel(LblPuntuacion, promedio);

                if (LblPuntuacion.Text != "N/A")
                {
                    CmbEvaluaciones.Enabled = true;
                    evaluacion.Evaluaciones(IdProveedor).ForEach(delegate(Fila f)
                    {
                        if(Global.ObjetoATexto(f.Celda("fecha"), "") != "")
                            CmbEvaluaciones.Items.Add(f.Celda("id").ToString() + " - " + Convert.ToDateTime(f.Celda("fecha")).ToString("MMM dd, yyyy"));
                    });
                }
                else
                    CmbEvaluaciones.Enabled = false;
            }
        }

        private void CmbEvaluaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEvaluaciones.Text == "")
            {
                DgvHabilidadesPersonales.Visible = false;
                return;
            }

            int idEvaluacion = Convert.ToInt32(CmbEvaluaciones.Text.Split('-')[0].TrimEnd());
            CargarResultadosDeEvaluacion(idEvaluacion);
            CargarInformacionFinal(idEvaluacion);
            DgvHabilidadesPersonales.Visible = true;
        }

        void CargarResultadosDeEvaluacion(int idEvaluacion)
        {
            DgvHabilidadesPersonales.Rows.Clear();

            EvaluacionHabilidadProveedor evaluacionHabilidad = new EvaluacionHabilidadProveedor();
            evaluacionHabilidad.SeleccionarHabilidades(idEvaluacion).ForEach(delegate(Fila f)
            {
                int idHabilidad = Convert.ToInt32(f.Celda("habilidad"));
                Habilidad.Modelo().CargarDatos(idHabilidad).ForEach(delegate(Fila habilidad)
                {
                    string strHabilidad = Global.ObjetoATexto(habilidad.Celda("habilidad"),"N/A").ToUpper();
                    string strTipoHabilidad = Global.ObjetoATexto(habilidad.Celda("tipo"), "N/A").ToUpper();
                    string strDescripcionHabilidad = Global.ObjetoATexto(habilidad.Celda("descripcion_habilidad"), "N/A").ToUpper();
                    string strComentario = Global.ObjetoATexto(f.Celda("comentarios"), "N/A");
                    int puntuacion = 0;
                    string strPuntuacion = Global.ObjetoATexto(f.Celda("puntuacion"), "0");
                    if (Convert.ToInt32(strPuntuacion) > 0)
                        puntuacion = Convert.ToInt32(strPuntuacion);

                    if (strTipoHabilidad == "PROVEEDOR")
                        DgvHabilidadesPersonales.Rows.Add(habilidad.Celda("id").ToString(), strHabilidad, strDescripcionHabilidad, strComentario, strPuntuacion);
                   
                });
            });
        }

        void CargarInformacionFinal(int idEvaluacion)
        {
            EvaluacionProveedor evaluacion = new EvaluacionProveedor();
            evaluacion.CargarDatos(idEvaluacion);

            //sacamos la informacion de la tabla evaluacion de acuerdo al id
            if (evaluacion.TieneFilas())
            {
                string puesto = "N/A";
                string nombreEvaluador = "N/A";
                int idEvaluador = Convert.ToInt32(Global.ObjetoATexto(evaluacion.Fila().Celda("evaluador"), "0"));

                //sacamos el nombre que corresponde al id del evaluador
                Usuario.Modelo().CargarDatos(idEvaluador).ForEach(delegate(Fila usuario)
                {
                    nombreEvaluador = Global.ObjetoATexto( usuario.Celda("nombre"), "") + Global.ObjetoATexto(usuario.Celda("paterno"), "") + Global.ObjetoATexto(usuario.Celda("materno"), "");
                    puesto = Global.ObjetoATexto(usuario.Celda("rol"), "");
                });

                int resultado = Convert.ToInt32(Global.ObjetoATexto(evaluacion.Fila().Celda("resultado"), "0"));

                //llenamos los controles con la informacion del evaluador y el resultado de la evaluacion 
                TxtEvaluador.Text = nombreEvaluador;
                TxtPuestoEvaluador.Text = puesto;
                EstiloLabel(LblPuntuacionEvaluacion, resultado);
                LblPuntuacionEvaluacion.Text = resultado.ToString() + "%";

            }
        }

        void EstiloLabel(Label lbl, int puntuacion)
        {
            if (puntuacion == 0)
            {
                lbl.Text = "N/A";
                lbl.ForeColor = Color.Black;
            }
            if (puntuacion < 70)
                lbl.ForeColor = Color.Red;
            else if (puntuacion >= 70)
                lbl.ForeColor = Color.Green;

        }
    }
}
