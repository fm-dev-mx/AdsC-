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
    public partial class FrmEvaluarTopicosHabilidad : Form
    {
        int IdHabilidad = 0;
        int IdEvaluacion = 0;
        int PuntuacionActual = 0;
        int TotalHabilidades = 0;
        int TotalHabilidadesEvaluadas = 0;
        public int Puntuacionfinal = 0;
        List<Fila> TopicoHabilidad = new List<Fila>();
        Dictionary<int, int> ResultadosHabilidades = new Dictionary<int, int>();       

        public FrmEvaluarTopicosHabilidad(int idHabilidad, int evaluacion)
        {
            InitializeComponent();
            IdHabilidad = idHabilidad;
            IdEvaluacion = evaluacion;
        }

        private void FrmEvaluarTopicosHabilidad_Load(object sender, EventArgs e)
        {
            TopicoHabilidad topicoHabilidad = new TopicoHabilidad();
            Habilidad habilidades = new Habilidad();

            habilidades.CargarDatos(IdHabilidad);
            TopicoHabilidad = topicoHabilidad.CargarTopicosHabilidad(IdHabilidad);

            TxtHabilidad.Text = Global.ObjetoATexto(habilidades.Fila().Celda("habilidad"), "");
            TxtTipoHabilidad.Text = Global.ObjetoATexto(habilidades.Fila().Celda("tipo"), "");
            
            TotalHabilidades = TopicoHabilidad.Count;
            LblAvance.Text = "0/" + TotalHabilidades;

            CargarHabilidades(TopicoHabilidad);
        }

        private void CargarHabilidades(List<Fila> topicosHabilidad)
        {
            //Si no hay topicos a evaluar
            if (topicosHabilidad.Count == 0)
                return;

            EvaluacionHabilidad evaluacionHabilidades = new EvaluacionHabilidad();
            TopicoHabilidad topicoHabilidad = new TopicoHabilidad();
            List<Fila> evaluaciones = evaluacionHabilidades.SeleccionarHabilidadesId(IdEvaluacion, IdHabilidad);

            //cargar topicos
            topicosHabilidad.ForEach(delegate(Fila filaTopico)
            {
                string comentarios = "";
                string puntosHabilidad = "";
                int puntuacion = 0;

                evaluacionHabilidades.SeleccionarHabilidadesTopico(IdEvaluacion, IdHabilidad, Convert.ToInt32(filaTopico.Celda("id").ToString()));
                if (evaluacionHabilidades.TieneFilas())
                {
                    comentarios = Global.ObjetoATexto(evaluacionHabilidades.Fila().Celda("habilidad_topico_comentarios"), "");
                    puntuacion = Convert.ToInt32(Global.ObjetoATexto(evaluacionHabilidades.Fila().Celda("puntuacion"), "0"));
                }

                puntosHabilidad = puntuacion.ToString();
                //switch (puntuacion)
                //{
                //    case 20:
                //        puntosHabilidad = "MUY MALO";
                //        break;
                //    case 40:
                //        puntosHabilidad = "MALO";
                //        break;
                //    case 60:
                //        puntosHabilidad = "REGULAR";
                //        break;
                //    case 80:
                //        puntosHabilidad = "BUENO";
                //        break;
                //    case 100:
                //        puntosHabilidad = "MUY BUENO";
                //        break;
                //    default:
                //        break;
                //}

                DgvHabilidades.Rows.Add(filaTopico.Celda("id").ToString(), filaTopico.Celda("topico").ToString(), filaTopico.Celda("descripcion").ToString(), comentarios, puntosHabilidad);
                if(puntosHabilidad != "0")
                    ResultadosHabilidades.Add(Convert.ToInt32(filaTopico.Celda("id").ToString()), puntuacion);
            });

            int porcentajeDesempenoHabilidad = 0;
            foreach (DataGridViewRow item in DgvHabilidades.Rows)
            {
                if(Convert.ToInt32(item.Cells[4].Value) != 0)
                {
                    porcentajeDesempenoHabilidad += PorcentajeDesempenoHabilidad(item.Cells[4].Value.ToString());
                    TotalHabilidadesEvaluadas++;
                }
                
            }
            PuntuacionActual = porcentajeDesempenoHabilidad / TotalHabilidades;

            MostrarPuntuacion();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvHabilidades_CellValueChangeds(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 3)
            {
                return;
            }

            int idHabilidadEvaluada = Convert.ToInt32(DgvHabilidades.Rows[e.RowIndex].Cells[0].Value);
            int porcentajeDesempenoHabilidad = PorcentajeDesempenoHabilidad(DgvHabilidades.Rows[e.RowIndex].Cells[4].Value.ToString());

            if (ResultadosHabilidades.ContainsKey(idHabilidadEvaluada))
            {
                ResultadosHabilidades[idHabilidadEvaluada] = porcentajeDesempenoHabilidad;
            }
            else
            {
                ResultadosHabilidades.Add(idHabilidadEvaluada, porcentajeDesempenoHabilidad);
                TotalHabilidadesEvaluadas++;
            }


            MostrarPuntuacion();
        }

        public int PorcentajeDesempenoHabilidad(string desempeno)
        {
            int porcentaje = 0;
            int.TryParse(desempeno, out porcentaje);
            return porcentaje;
            //switch (desempeno)
            //{
            //    case "MUY MALO":
            //        return 20;

            //    case "MALO":
            //        return 40;

            //    case "REGULAR":
            //        return 60;

            //    case "BUENO":
            //        return 80;

            //    case "MUY BUENO":
            //        return 100;

            //    default:
            //        return 0;
            //}
        }

        public void MostrarPuntuacion()
        {
            LblAvance.Text =  TotalHabilidadesEvaluadas + "/" + TotalHabilidades;
            PuntuacionActual = CalcularPuntuacion();
            LblPuntuacion.Text = PuntuacionActual.ToString() + "%";
            BtnFinalizar.Enabled = TotalHabilidadesEvaluadas == TotalHabilidades;

            if (PuntuacionActual < 70)
                LblPuntuacion.ForeColor = Color.Red;
            else
                LblPuntuacion.ForeColor = Color.Green;
        }

        public int CalcularPuntuacion()
        {
            int puntuacion = 0;

            foreach (KeyValuePair<int, int> kvp in ResultadosHabilidades)
            {
                puntuacion += kvp.Value;
            }

            return puntuacion / (TotalHabilidades); //ResultadosHabilidades.Count + 
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de terminar la evaluación de la habilidad " + TxtHabilidad.Text + "?", "Terminar evaluación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                Puntuacionfinal = CalcularPuntuacion();
                //Modifica el registro existente
                    
                foreach (DataGridViewRow item in DgvHabilidades.Rows)
                {
                    EvaluacionHabilidad evaluacionHabilidades = new EvaluacionHabilidad();
                    evaluacionHabilidades.SeleccionarHabilidadesTopico(IdEvaluacion, IdHabilidad, Convert.ToInt32(item.Cells["id_habilidad_personal"].Value));

                    if (evaluacionHabilidades.TieneFilas())
                    {
                        int idEvaluacionHabilidad = Convert.ToInt32(item.Cells["id_habilidad_personal"].Value);
                        int puntuacion = PorcentajeDesempenoHabilidad(item.Cells["nivel_habilidad_personal"].Value.ToString());
                        int idTopico = Convert.ToInt32(item.Cells["id_habilidad_personal"].Value);

                        evaluacionHabilidades.Fila().ModificarCelda("evaluacion", IdEvaluacion);
                        evaluacionHabilidades.Fila().ModificarCelda("habilidad", IdHabilidad);
                        evaluacionHabilidades.Fila().ModificarCelda("puntuacion", puntuacion);
                        evaluacionHabilidades.Fila().ModificarCelda("habilidad_topico", idTopico);
                        evaluacionHabilidades.Fila().ModificarCelda("habilidad_topico_comentarios", item.Cells["comentarios_habilidad_personal"].Value);
                        evaluacionHabilidades.GuardarDatos();
                    }
                    else
                    {
                        //crea uno nuevo
                        Fila insertarHabilidad = new Fila();
                        insertarHabilidad.AgregarCelda("evaluacion", IdEvaluacion);
                        insertarHabilidad.AgregarCelda("habilidad", IdHabilidad);
                        insertarHabilidad.AgregarCelda("puntuacion", PorcentajeDesempenoHabilidad(item.Cells["nivel_habilidad_personal"].Value.ToString()));
                        insertarHabilidad.AgregarCelda("habilidad_topico", item.Cells["id_habilidad_personal"].Value);
                        insertarHabilidad.AgregarCelda("habilidad_topico_comentarios", item.Cells["comentarios_habilidad_personal"].Value);
                        EvaluacionHabilidad.Modelo().Insertar(insertarHabilidad);
                    }
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void DgvHabilidades_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvHabilidades.CurrentCell.ColumnIndex == 0 || DgvHabilidades.CurrentCell.ColumnIndex == 3)
            {
                if (e.Control is TextBox)
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }
    }
}
