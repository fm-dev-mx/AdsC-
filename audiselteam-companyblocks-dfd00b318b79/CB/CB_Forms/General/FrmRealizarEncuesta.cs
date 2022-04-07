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
    public partial class FrmRealizarEncuesta : Form
    {
        int IdPlantilla = 0;
        int IdEncuesta = 0;
        bool ConsultarEncuesta = false;

        public FrmRealizarEncuesta(int idPlantilla, int idEncuesta, bool consultarEncuesta = false)
        {
            InitializeComponent();
            IdPlantilla = idPlantilla;
            IdEncuesta = idEncuesta;
            ConsultarEncuesta = consultarEncuesta;
        }

        private void FrmRealizarEncuesta_Load(object sender, EventArgs e)
        {
            if (ConsultarEncuesta)
                BtnFinalizar.Visible = false;

            CargarInformacionGeneral();
            CargarPreguntas();
            CalcularAvance();
        }

        private void CargarInformacionGeneral()
        {
            Encuesta encuesta = new Encuesta();
            encuesta.CargarDatos(IdEncuesta);
            if(encuesta.TieneFilas())
            {
                PlantillaEncuesta plantilla = new PlantillaEncuesta();
                Usuario usuario = new Usuario();

                plantilla.CargarDatos(Convert.ToInt32(encuesta.Fila().Celda("plantilla")));
                usuario.CargarDatos(Convert.ToInt32(encuesta.Fila().Celda("usuario_creacion")));

                TxtEncuesta.Text = Global.ObjetoATexto(plantilla.Fila().Celda("nombre"), "");
                TxtRealizadaPor.Text = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");

                usuario.CargarDatos(Convert.ToInt32(encuesta.Fila().Celda("usuario_encuestado")));
                TxtUsuarioEncuestado.Text = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");

                int diasCaducidad = Convert.ToInt32(encuesta.Fila().Celda("caducidad"));

                DateTime fechaVencimiento = Convert.ToDateTime(encuesta.Fila().Celda("fecha_creacion")).AddDays(diasCaducidad);
                TxtFechaCaducidad.Text = Global.FechaATexto(fechaVencimiento);

                TxttDescripcion.Text = Global.ObjetoATexto(encuesta.Fila().Celda("comentarios"), "");

            }
        }

        private void CargarPreguntas()
        {
            PlantillaEncuestaPregunta preguntas = new PlantillaEncuestaPregunta();
            DataGridViewTextBoxCell TextBoxCell = new DataGridViewTextBoxCell();
            DataGridViewComboBoxCell ComboBoxCell = new DataGridViewComboBoxCell();

            string strRespuesta = string.Empty;
            int rowIndex = 0;
                        
            preguntas.SeleccionarPreguntas(IdPlantilla).ForEach(delegate(Fila f)
            {
                switch (Global.ObjetoATexto(f.Celda("tipo"), ""))
                {
                    case "SI-NO":

                        DgvPreguntas.Rows.Add("");
                       
                        this.DgvPreguntas[0, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[0, rowIndex].Value = f.Celda("id").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[1, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[1, rowIndex].Value = f.Celda("contenido").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[2, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[2, rowIndex].Value = f.Celda("tipo").ToString();

                       
                        ComboBoxCell.Items.AddRange(new string[] { "SELECCIONAR", "SI","NO" });
                        this.DgvPreguntas[3, rowIndex] = ComboBoxCell;
                        this.DgvPreguntas[3, rowIndex].Value = "SELECCIONAR";
                        strRespuesta = "SELECCIONAR";

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[4, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[4, rowIndex].Value = f.Celda("rango_minimo").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[5, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[5, rowIndex].Value = f.Celda("rango_maximo").ToString();

                        break;

                    case "RANGO":

                        DgvPreguntas.Rows.Add("");
                       
                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[0, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[0, rowIndex].Value = f.Celda("id").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[1, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[1, rowIndex].Value = f.Celda("contenido").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[2, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[2, rowIndex].Value = f.Celda("tipo").ToString();

                        List<string> lista = new List<string>();
                        lista.Add("SELECCIONAR");

                        for (int i = Convert.ToInt32(f.Celda("rango_minimo")); i <= Convert.ToInt32(f.Celda("rango_maximo")); i++)
                            lista.Add(i.ToString());

                        ComboBoxCell = new DataGridViewComboBoxCell();
                        ComboBoxCell.DataSource = lista;
                        this.DgvPreguntas[3, rowIndex] = ComboBoxCell;
                        this.DgvPreguntas[3, rowIndex].Value = "SELECCIONAR";
                        strRespuesta = "SELECCIONAR";

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[4, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[4, rowIndex].Value = f.Celda("rango_minimo").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[5, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[5, rowIndex].Value = f.Celda("rango_maximo").ToString();
                        break;

                    case "ABIERTA":

                        DgvPreguntas.Rows.Add("");

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[0, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[0, rowIndex].Value = f.Celda("id").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[1, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[1, rowIndex].Value = f.Celda("contenido").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[2, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[2, rowIndex].Value = f.Celda("tipo").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[3, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[3, rowIndex].Value = "";
                        strRespuesta = "";

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[4, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[4, rowIndex].Value = f.Celda("rango_minimo").ToString();

                        TextBoxCell = new DataGridViewTextBoxCell();
                        this.DgvPreguntas[5, rowIndex] = TextBoxCell;
                        this.DgvPreguntas[5, rowIndex].Value = f.Celda("rango_maximo").ToString();
                        break;

                    default:
                        break;
                }

                if(ConsultarEncuesta)
                {                   
                    EncuestaPregunta respuestas = new EncuestaPregunta();
                    respuestas.SeleccionarRespuestas(Convert.ToInt32(f.Celda("id")), Convert.ToInt32(f.Celda("plantilla")), IdEncuesta);
                    if (respuestas.TieneFilas())
                   
                        DgvPreguntas[3, rowIndex].Value = Global.ObjetoATexto(respuestas.Fila().Celda("respuesta"), strRespuesta);
                    else
                        DgvPreguntas[3, rowIndex].Value = strRespuesta;

                    DgvPreguntas[3, rowIndex].ReadOnly = true;
                    
                }

                rowIndex++;
            });
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de terminar la encuesta?", "Terminar encuesta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvPreguntas.Rows)
                {
                    Fila insertarRespuesta = new Fila();
                    insertarRespuesta.AgregarCelda("plantilla", IdPlantilla);
                    insertarRespuesta.AgregarCelda("encuesta", IdEncuesta);
                    insertarRespuesta.AgregarCelda("plantilla_pregunta_id", row.Cells["id"].Value);
                    insertarRespuesta.AgregarCelda("tipo", row.Cells["tipo"].Value);
                    insertarRespuesta.AgregarCelda("rango_minimo", row.Cells["rango_minimo"].Value);
                    insertarRespuesta.AgregarCelda("rango_maximo", row.Cells["rango_maximo"].Value);
                    insertarRespuesta.AgregarCelda("contenido", row.Cells["pregunta"].Value);
                    insertarRespuesta.AgregarCelda("respuesta", row.Cells["respuesta"].Value);
                    EncuestaPregunta.Modelo().Insertar(insertarRespuesta);
                }

                DialogResult = System.Windows.Forms.DialogResult.Yes;
               // Close();
            }
        }

        private void CalcularAvance()
        {
            int total = DgvPreguntas.Rows.Count;
            int avance = 0;

            if (DgvPreguntas.Rows.Count <= 0)
                return;

            foreach (DataGridViewRow row in DgvPreguntas.Rows)
            {
                if(row.Cells["respuesta"].Value.ToString() != "" &&  row.Cells["respuesta"].Value.ToString() != "SELECCIONAR")
                    avance++;
            }

            if (avance == total)
                BtnFinalizar.Enabled = true;

            LblAvance.Text = avance.ToString() + "/" + total.ToString();

        }

        private void DgvPreguntas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcularAvance();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvPreguntas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvPreguntas.CurrentCell.ColumnIndex == 3)
            {
                if (e.Control is TextBox)
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }
    }
}
