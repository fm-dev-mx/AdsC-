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
    public partial class FrmEvaluarDesempenoProveedores : Form
    {
        string TipoHabilidad = string.Empty;
        List<Fila> EvaluacionProveedor = new  List<Fila>();
        int TotalHabilidades = 0;
        int HabilidadesEvaluadas = 0;
        int Puntuacion = 0;
        int IdEvaluacion = 0; 

        Dictionary<int, string> ValidarHabilidadesEvaluadas = new Dictionary<int, string>();

        public FrmEvaluarDesempenoProveedores(List<Fila> evaluacionProveedor, string tipoHabilidad)
        {
            InitializeComponent();
            EvaluacionProveedor = evaluacionProveedor;
            TipoHabilidad = tipoHabilidad;
            
        }

        private void FrmEvaluarDesempenoProveedores_Load(object sender, EventArgs e)
        {
            CargarInformacionGeneral();
            CargarPuntosEvaluacion();
            
        }

        private void CargarPuntosEvaluacion()
        {
            EvaluacionHabilidadProveedor evaluaciones = new EvaluacionHabilidadProveedor();
            Habilidad habilidaddesProveedor = new Habilidad();
            habilidaddesProveedor.SeleccionarTipo(TipoHabilidad).ForEach(delegate(Fila f)
            {
                int idHabilidad = Convert.ToInt32(Global.ObjetoATexto(f.Celda("id"), "0"));
                evaluaciones.SeleccionarEvaluaciones(IdEvaluacion, idHabilidad);
                if (evaluaciones.TieneFilas())
                    DgvHabilidadesProveedor.Rows.Add(f.Celda("id").ToString(), f.Celda("habilidad").ToString(), Global.ObjetoATexto(f.Celda("descripcion_habilidad"), ""), Global.ObjetoATexto(evaluaciones.Fila().Celda("comentarios"),""), Global.ObjetoATexto(evaluaciones.Fila().Celda("puntuacion"), ""));
                else
                    DgvHabilidadesProveedor.Rows.Add(f.Celda("id").ToString(), f.Celda("habilidad").ToString(), Global.ObjetoATexto(f.Celda("descripcion_habilidad"), ""));
            });

            if (DgvHabilidadesProveedor.Rows.Count > 0)
                DgvHabilidadesProveedor.ClearSelection();

            CalcularPuntuacion();
        }

        private void CalcularPuntuacion()
        {
            TotalHabilidades = 0;
            HabilidadesEvaluadas = 0;
            Puntuacion = 0;

            foreach (DataGridViewRow item in DgvHabilidadesProveedor.Rows)
            {
                if (item.Cells["nivel_habilidad"].Value != null)
                {
                    Puntuacion += Convert.ToInt32(item.Cells["nivel_habilidad"].Value);
                    HabilidadesEvaluadas++; 
                }

                TotalHabilidades++;
            }
            
            if (TotalHabilidades > 0)
            {
                LblAvance.Text = HabilidadesEvaluadas + "/" + TotalHabilidades;
                LblPuntuacion.Text = (Puntuacion / TotalHabilidades).ToString() + "%";
                BtnFinalizar.Enabled = (HabilidadesEvaluadas == TotalHabilidades);

                if ((Puntuacion / TotalHabilidades) > 69)
                    LblPuntuacion.ForeColor = Color.Green;
                else
                    LblPuntuacion.ForeColor = Color.Red;
            }
            else
            {
                LblAvance.Text = "N/A"; 
            }
        }

        private void CargarInformacionGeneral()
        {
            EvaluacionProveedor.ForEach(delegate(Fila f)
            {
                Proveedor.Modelo().CargarDatos(Convert.ToInt32(f.Celda("proveedor"))).ForEach(delegate(Fila filaProveedor)
                {
                    TxtProveedor.Text = Global.ObjetoATexto(filaProveedor.Celda("nombre"), "No se pudo cargar correctamente");
                });
                Usuario usuario = new Usuario();
                usuario.CargarDatos(Convert.ToInt32(f.Celda("evaluador")));
                TxtEvaluador.Text = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");
                TxtPuestoEvaluador.Text = Global.ObjetoATexto(usuario.Fila().Celda("rol"), "");
                IdEvaluacion = Convert.ToInt32(Global.ObjetoATexto(f.Celda("id"), "0"));
            });
        }

        private void DgvHabilidadesProveedor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void DgvHabilidadesProveedor_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    evaluarToolStripMenuItem.Visible = true;
                    MenuEvaluar.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvHabilidadesProveedor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvHabilidadesProveedor.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    evaluarHabilidadToolStripMenuItem.Visible = false;
                    MenuEvaluar.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void evaluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string habilidad = DgvHabilidadesProveedor.SelectedRows[0].Cells["habilidad"].Value.ToString();
            string comentario = Global.ObjetoATexto(DgvHabilidadesProveedor.SelectedRows[0].Cells["comentarios_habilidad"].Value, "");
            int puntuacion = Convert.ToInt32(Global.ObjetoATexto(DgvHabilidadesProveedor.SelectedRows[0].Cells["nivel_habilidad"].Value, "0").TrimEnd('%'));

            FrmEvaluarHabilidadProveedor evaluar = new FrmEvaluarHabilidadProveedor(habilidad, comentario, puntuacion);
            if(evaluar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DgvHabilidadesProveedor.SelectedRows[0].Cells["nivel_habilidad"].Value = evaluar.Calificacion;
                DgvHabilidadesProveedor.SelectedRows[0].Cells["comentarios_habilidad"].Value = evaluar.Comentarios;

                //Crea uno nuevo
                if (puntuacion == 0)
                {
                    Fila insertarHabilidad = new Fila();
                    insertarHabilidad.AgregarCelda("evaluacion", IdEvaluacion);
                    insertarHabilidad.AgregarCelda("habilidad", DgvHabilidadesProveedor.SelectedRows[0].Cells["id_habilidad"].Value);
                    insertarHabilidad.AgregarCelda("puntuacion", evaluar.Calificacion);
                    insertarHabilidad.AgregarCelda("comentarios", evaluar.Comentarios);
                    EvaluacionHabilidadProveedor.Modelo().Insertar(insertarHabilidad);
                }
                else //modifica el existente
                {
                    int idHabilidad = Convert.ToInt32(DgvHabilidadesProveedor.SelectedRows[0].Cells["id_habilidad"].Value);
                    EvaluacionHabilidadProveedor evaluaciones = new EvaluacionHabilidadProveedor();
                    evaluaciones.SeleccionarEvaluaciones(IdEvaluacion, idHabilidad);
                    evaluaciones.Fila().ModificarCelda("evaluacion", IdEvaluacion);
                    evaluaciones.Fila().ModificarCelda("habilidad", DgvHabilidadesProveedor.SelectedRows[0].Cells["id_habilidad"].Value);
                    evaluaciones.Fila().ModificarCelda("puntuacion", evaluar.Calificacion);
                    evaluaciones.Fila().ModificarCelda("comentarios", evaluar.Comentarios);
                    evaluaciones.GuardarDatos();
                }

                CalcularPuntuacion();
            }
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("¿Está seguro de finalizar la evaluación al proveedor " + TxtProveedor.Text + "?", "Finalizar evaluación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 EvaluacionProveedor evaluarProveedor = new EvaluacionProveedor();
                 evaluarProveedor.CargarDatos(IdEvaluacion);
                 evaluarProveedor.Fila().ModificarCelda("fecha", DateTime.Now);
                 evaluarProveedor.Fila().ModificarCelda("resultado", LblPuntuacion.Text.TrimEnd('%'));
                 evaluarProveedor.GuardarDatos();

                 MessageBox.Show("La evaluación al proveedor " + TxtProveedor.Text + " ha finalizado correctamente", "Evaluación finalizada");
                 DialogResult = System.Windows.Forms.DialogResult.OK;
                // Close();
             }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Su información ha sido guardada automaticamente, sin embargo, para finalizar la evaluación debe dar click en 'Finalizar', ¿Está seguro que desea salir?", "Salir de la evaluación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
                Close();
        }
    }
}
