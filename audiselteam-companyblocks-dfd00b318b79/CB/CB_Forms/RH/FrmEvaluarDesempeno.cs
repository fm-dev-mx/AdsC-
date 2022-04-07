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
    public partial class FrmEvaluarDesempeno : Form
    {
        int PuntuacionActual = 0;
        int TotalHabilidades = 0;
        int TotalHabilidadesEvaluadas = 0;
        int Nivel = 0;
        int IdEmpleado = 0;
        int IdEvaluacion = 0;
        string Puesto = string.Empty;

        Usuario BajoEvaluacion = new Usuario();
        PerfilPuesto Perfil = new PerfilPuesto();
        Dictionary<int, int> resultadosHabilidadesPersonales = new Dictionary<int, int>();
        Dictionary<int, int> resultadosHabilidadesTecnicas = new Dictionary<int, int>();

        public FrmEvaluarDesempeno(int idEmpleado, int idEvaluacion = 0)
        {
            InitializeComponent();
            IdEvaluacion = idEvaluacion;
            IdEmpleado = idEmpleado;
            BajoEvaluacion.CargarDatos(idEmpleado);
            Puesto = BajoEvaluacion.Fila().Celda("rol").ToString();
            Nivel = Convert.ToInt32(BajoEvaluacion.Fila().Celda("nivel"));
            Perfil.Cargar(Puesto, Nivel);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult salir = MessageBox.Show("Seguro que quieres salir sin terminar la evaluación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(salir == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
                Close();
            }
        }

        private void FrmEvaluarEmpleado_Load(object sender, EventArgs e)
        {
            CargarDatosEmpleadoHabilidades();
            if(IdEvaluacion == 0)
            {
                if(IdEvaluacion == 0)
                {
                    Fila insertarNuevoMantenimiento = new Fila();
                    insertarNuevoMantenimiento.AgregarCelda("evaluador", Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
                    insertarNuevoMantenimiento.AgregarCelda("evaluado", IdEmpleado);
                    IdEvaluacion = Convert.ToInt32(Evaluacion.Modelo().Insertar(insertarNuevoMantenimiento).Celda("id"));

                    int evaluadorId = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));
                    int evaluadoId = IdEmpleado;

                    //Crear nuevo
                    CrearHabilidadEvaluacion(DgvHabilidadesPersonales, "id_habilidad_personal", "comentarios_habilidad_personal", "nivel_habilidad_personal", IdEvaluacion);
                    CrearHabilidadEvaluacion(DgvHabilidadesTecnicas, "id_habilidad_tecnica", "comentarios_habilidad_tecnica", "nivel_habilidad_tecnica", IdEvaluacion);
                }
            }
        }

        void CargarDatosEmpleadoHabilidades()
        {
            TxtNombre.Text = BajoEvaluacion.NombreCompleto();
            TxtPuestoBajoEvaluacion.Text = Puesto + " " + Nivel;

            TxtEvaluador.Text = Global.UsuarioActual.NombreCompleto();
            TxtPuestoEvaluador.Text = Global.UsuarioActual.Fila().Celda("rol").ToString();
            
            
            int nivelEvaluador = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("nivel"));
            if (nivelEvaluador > 0)
                TxtPuestoEvaluador.Text += " " + nivelEvaluador;

            int idPerfil = Convert.ToInt32(Global.ObjetoATexto(Perfil.Fila().Celda("id"),"0"));

            DgvHabilidadesPersonales.Rows.Clear();
            PerfilHabilidad.Modelo().Habilidades(idPerfil).ForEach(delegate(Fila f)
            {
                Object objDescripcionHabilidad = f.Celda("descripcion_habilidad");
                string descripcionHabilidad = string.Empty;

                if (objDescripcionHabilidad != null)
                    descripcionHabilidad = objDescripcionHabilidad.ToString();

                EvaluacionHabilidad evaluacionHabilidad = new EvaluacionHabilidad();
                evaluacionHabilidad.SeleccionarHabilidadesId(IdEvaluacion, Convert.ToInt32(f.Celda("id")));

                string puntosHabilidad = "";
                string comentarios = "";
                if (evaluacionHabilidad.TieneFilas())
                {
                    puntosHabilidad = Global.ObjetoATexto(evaluacionHabilidad.Fila().Celda("puntuacion"), "");
                    comentarios = Global.ObjetoATexto(evaluacionHabilidad.Fila().Celda("comentarios"), "");

                    if(puntosHabilidad == "0")
                        puntosHabilidad = "";
                    else if (puntosHabilidad != "")
                        puntosHabilidad += "%";
                }

                if (f.Celda("tipo").ToString() == "PERSONAL")
                {
                    DgvHabilidadesPersonales.Rows.Add(f.Celda("id"), f.Celda("habilidad"), descripcionHabilidad, comentarios, puntosHabilidad);
                    if (puntosHabilidad != "")
                    {
                        resultadosHabilidadesPersonales.Add(Convert.ToInt32(f.Celda("id")), Convert.ToInt32(puntosHabilidad.TrimEnd('%')));
                        TotalHabilidadesEvaluadas++;
                    }
                }
                else if (f.Celda("tipo").ToString() == "TECNICA")
                {
                    DgvHabilidadesTecnicas.Rows.Add(f.Celda("id"), f.Celda("habilidad"), descripcionHabilidad, comentarios, puntosHabilidad);
                    if (puntosHabilidad != "")
                    {
                        resultadosHabilidadesTecnicas.Add(Convert.ToInt32(f.Celda("id")), Convert.ToInt32(puntosHabilidad.TrimEnd('%')));
                        TotalHabilidadesEvaluadas++;
                    }
                }

            });
            TotalHabilidades = DgvHabilidadesPersonales.RowCount + DgvHabilidadesTecnicas.RowCount;
            LblAvance.Text = TotalHabilidadesEvaluadas + "/" + TotalHabilidades;
            MostrarPuntuacion();
        }

        public int PorcentajeDesempenoHabilidad(string desempeno)
        {
            switch(desempeno)
            {
                case "MUY MALO":
                    return 20;

                case "MALO":
                    return 40;

                case "REGULAR":
                    return 60;

                case "BUENO":
                    return 80;

                case "MUY BUENO":
                    return 100;

                default:
                    return 0;
            }
        }

        public int CalcularPuntuacion()
        {
            int puntuacion = 0;

            foreach(KeyValuePair<int, int> kvp in resultadosHabilidadesPersonales)
            {
                puntuacion += kvp.Value;
            }

            foreach(KeyValuePair<int, int> kvp in resultadosHabilidadesTecnicas)
            {
                puntuacion += kvp.Value;
            }

            if (resultadosHabilidadesPersonales.Count == 0 && resultadosHabilidadesTecnicas.Count == 0)
                return 0;

            return puntuacion / (resultadosHabilidadesPersonales.Count + resultadosHabilidadesTecnicas.Count);
        }

        public void MostrarPuntuacion()
        {
            LblAvance.Text = TotalHabilidadesEvaluadas + "/" + TotalHabilidades;
            PuntuacionActual = CalcularPuntuacion();
            LblPuntuacion.Text = PuntuacionActual.ToString() + "%";
            BtnFinalizar.Enabled = TotalHabilidadesEvaluadas == TotalHabilidades;

            if (PuntuacionActual < 70)
                LblPuntuacion.ForeColor = Color.Red;
            else
                LblPuntuacion.ForeColor = Color.Green;
        }


        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea finalizar la evaluación?", "Finalizar evaluación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                //Terminar evaluacion
                Evaluacion evaluacion = new Evaluacion();
                evaluacion.CargarDatos(IdEvaluacion);
                evaluacion.Fila().ModificarCelda("fecha", DateTime.Now);
                evaluacion.Fila().ModificarCelda("resultado", LblPuntuacion.Text.TrimEnd('%'));
                evaluacion.GuardarDatos();

                //guardamos los comentarios
                foreach (DataGridViewRow row in DgvHabilidadesPersonales.Rows)
                {
                    int id = 0;
                    EvaluacionHabilidad evaluacionHabilidades = new EvaluacionHabilidad();
                    evaluacionHabilidades.SeleccionarHabilidad(IdEvaluacion, Convert.ToInt32(row.Cells["id_habilidad_personal"].Value));                  
                    if (evaluacionHabilidades.TieneFilas())
                    {
                        id = Convert.ToInt32(evaluacionHabilidades.Fila().Celda("id"));
                        evaluacionHabilidades.CargarDatos(id);
                        evaluacionHabilidades.Fila().ModificarCelda("puntuacion", Convert.ToInt32(row.Cells["nivel_habilidad_personal"].Value.ToString().TrimEnd('%')));
                        evaluacionHabilidades.Fila().ModificarCelda("comentarios", row.Cells["comentarios_habilidad_personal"].Value.ToString());
                        evaluacionHabilidades.GuardarDatos();
                    }
                    else
                    {
                        Fila insertaHabilidadEvaluacion = new Fila();
                        insertaHabilidadEvaluacion.AgregarCelda("evaluacion", IdEvaluacion);
                        insertaHabilidadEvaluacion.AgregarCelda("habilidad", Convert.ToInt32(row.Cells["id_habilidad_personal"].Value));
                        insertaHabilidadEvaluacion.AgregarCelda("puntuacion", Convert.ToInt32(row.Cells["nivel_habilidad_tecnica"].Value.ToString().TrimEnd('%')));
                        insertaHabilidadEvaluacion.AgregarCelda("comentarios", row.Cells["comentarios_habilidad_tecnica"].Value.ToString());
                        EvaluacionHabilidad.Modelo().Insertar(insertaHabilidadEvaluacion);
                    }
                }

                foreach (DataGridViewRow row in DgvHabilidadesTecnicas.Rows)
                {
                    int id = 0;
                    EvaluacionHabilidad evaluacionHabilidades = new EvaluacionHabilidad();
                    evaluacionHabilidades.SeleccionarHabilidad(IdEvaluacion, Convert.ToInt32(row.Cells["id_habilidad_tecnica"].Value));                    
                    if (evaluacionHabilidades.TieneFilas())
                    {
                        id = Convert.ToInt32(evaluacionHabilidades.Fila().Celda("id"));
                        evaluacionHabilidades.CargarDatos(id);
                        evaluacionHabilidades.Fila().ModificarCelda("puntuacion", Convert.ToInt32(row.Cells["nivel_habilidad_tecnica"].Value.ToString().TrimEnd('%')));
                        evaluacionHabilidades.Fila().ModificarCelda("comentarios", row.Cells["comentarios_habilidad_tecnica"].Value.ToString());
                        evaluacionHabilidades.GuardarDatos();
                    }
                    else
                    {
                        Fila insertaHabilidadEvaluacion = new Fila();
                        insertaHabilidadEvaluacion.AgregarCelda("evaluacion", IdEvaluacion);
                        insertaHabilidadEvaluacion.AgregarCelda("habilidad", Convert.ToInt32(row.Cells["id_habilidad_tecnica"].Value));
                        insertaHabilidadEvaluacion.AgregarCelda("puntuacion", Convert.ToInt32(row.Cells["nivel_habilidad_tecnica"].Value.ToString().TrimEnd('%')));
                        insertaHabilidadEvaluacion.AgregarCelda("comentarios", row.Cells["comentarios_habilidad_tecnica"].Value.ToString());
                        EvaluacionHabilidad.Modelo().Insertar(insertaHabilidadEvaluacion);
                    }
                }
                MessageBox.Show("Evaluación guardada de forma correcta.", "Evaluación terminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void CrearHabilidadEvaluacion(DataGridView Dgv, string rowIdHabilidad, string rowComentarios, string rowPuntuacion, int idEvaluacion)
        {
            foreach (DataGridViewRow row in Dgv.Rows)
            {
                int idHabilidad = Convert.ToInt32(row.Cells[rowIdHabilidad].Value);              

                Fila insertaHabilidadEvaluacion = new Fila();
                insertaHabilidadEvaluacion.AgregarCelda("evaluacion", idEvaluacion);
                insertaHabilidadEvaluacion.AgregarCelda("habilidad", idHabilidad);
                insertaHabilidadEvaluacion.AgregarCelda("puntuacion", 0);
                insertaHabilidadEvaluacion.AgregarCelda("comentarios", "");
                EvaluacionHabilidad.Modelo().Insertar(insertaHabilidadEvaluacion);
            }
        }

        private void ActualizarHabilidadEvaluacion(DataGridView Dgv, string rowIdHabilidad, string rowComentarios, string rowPuntuacion, int idEvaluacion, DataGridViewRow row)
        {
            EvaluacionHabilidad evaluacionHabilidades = new EvaluacionHabilidad();

            int idHabilidad = Convert.ToInt32(row.Cells[rowIdHabilidad].Value);
            string puntuacion = rowPuntuacion;
            int id = 0;

            evaluacionHabilidades.SeleccionarHabilidad(IdEvaluacion, idHabilidad);
            if (evaluacionHabilidades.TieneFilas())
            {
                id = Convert.ToInt32(evaluacionHabilidades.Fila().Celda("id"));
                evaluacionHabilidades.CargarDatos(id);
                evaluacionHabilidades.Fila().ModificarCelda("puntuacion", puntuacion);
                evaluacionHabilidades.Fila().ModificarCelda("comentarios", rowComentarios);
                evaluacionHabilidades.GuardarDatos();
            }
        }

        private void evaluarHabilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int habilidadSeleccionada = Convert.ToInt32(DgvHabilidadesPersonales.SelectedRows[0].Cells["id_habilidad_personal"].Value);
            
            FrmEvaluarTopicosHabilidad topicoHabilidad = new FrmEvaluarTopicosHabilidad(habilidadSeleccionada, IdEvaluacion);
            if(topicoHabilidad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DgvHabilidadesPersonales.SelectedRows[0].Cells["nivel_habilidad_personal"].Value = topicoHabilidad.Puntuacionfinal + "%";                

                int total = 0;
                TotalHabilidadesEvaluadas = 0;
                foreach (DataGridViewRow item in DgvHabilidadesPersonales.Rows)
                {
                    string comentarios = "";
                    string datos = Global.ObjetoATexto(item.Cells["nivel_habilidad_personal"].Value, "");
                    if(datos != "")
                    {
                        total +=  Convert.ToInt32(datos.TrimEnd('%'));

                        if (item.Cells["comentarios_habilidad_personal"].Value != null)
                            comentarios = item.Cells["comentarios_habilidad_personal"].Value.ToString();

                        ActualizarHabilidadEvaluacion(DgvHabilidadesPersonales, "id_habilidad_personal", comentarios, datos.TrimEnd('%'), IdEvaluacion, item);
                        TotalHabilidadesEvaluadas++;
                    } 
                }

                foreach (DataGridViewRow item in DgvHabilidadesTecnicas.Rows)
                {
                    string datos = Global.ObjetoATexto(item.Cells["nivel_habilidad_tecnica"].Value, "");

                    if(datos != "")
                    {
                        total +=  Convert.ToInt32(datos.TrimEnd('%'));                      
                        TotalHabilidadesEvaluadas++;
                    } 
                }
                LblPuntuacion.Text = (total / TotalHabilidades) + "%";
                LblAvance.Text = TotalHabilidadesEvaluadas + "/" + TotalHabilidades;

                if (Convert.ToInt32(LblPuntuacion.Text.TrimEnd('%')) < 70)
                    LblPuntuacion.ForeColor = Color.Red;
                else
                    LblPuntuacion.ForeColor = Color.Green;

                if (TotalHabilidadesEvaluadas == TotalHabilidades)
                    BtnFinalizar.Enabled = true;
                else
                    BtnFinalizar.Enabled = false;
            }
        }

        private void evaluarHabilidadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int habilidadSeleccionada = Convert.ToInt32(DgvHabilidadesTecnicas.SelectedRows[0].Cells["id_habilidad_tecnica"].Value);
            FrmEvaluarTopicosHabilidad topicoHabilidad = new FrmEvaluarTopicosHabilidad(habilidadSeleccionada, IdEvaluacion);
            if (topicoHabilidad.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DgvHabilidadesTecnicas.SelectedRows[0].Cells["nivel_habilidad_tecnica"].Value = topicoHabilidad.Puntuacionfinal + "%";

                int total = 0;
                TotalHabilidadesEvaluadas = 0;
                foreach (DataGridViewRow item in DgvHabilidadesTecnicas.Rows)
                {
                    string datos = Global.ObjetoATexto(item.Cells["nivel_habilidad_tecnica"].Value, "");
                    if (datos != "")
                    {
                        total += Convert.ToInt32(datos.TrimEnd('%'));
                        ActualizarHabilidadEvaluacion(DgvHabilidadesTecnicas, "id_habilidad_tecnica", item.Cells["comentarios_habilidad_tecnica"].Value.ToString().ToUpper(), datos.TrimEnd('%'), IdEvaluacion, item);
                        TotalHabilidadesEvaluadas++;
                    }
                }

                foreach (DataGridViewRow item in DgvHabilidadesPersonales.Rows)
                {
                    string datos = Global.ObjetoATexto(item.Cells["nivel_habilidad_personal"].Value, "");

                    if (datos != "")
                    {
                        total += Convert.ToInt32(datos.TrimEnd('%'));
                        TotalHabilidadesEvaluadas++;
                    }
                }
                LblPuntuacion.Text = (total / TotalHabilidades) + "%";
                LblAvance.Text = TotalHabilidadesEvaluadas + "/" + TotalHabilidades;

                if (Convert.ToInt32(LblPuntuacion.Text.TrimEnd('%')) < 70)
                    LblPuntuacion.ForeColor = Color.Red;
                else
                    LblPuntuacion.ForeColor = Color.Green;

                if (TotalHabilidadesEvaluadas == TotalHabilidades)
                    BtnFinalizar.Enabled = true;
                else
                    BtnFinalizar.Enabled = false;
            }
        }

        private void DgvHabilidadesPersonales_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvHabilidadesPersonales.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    evaluarHabilidadToolStripMenuItem.Visible = false;
                    evaluarHabilidadToolStripMenuItem1.Visible = false;
                    MenuEvaluarHabilidad.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvHabilidadesPersonales_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    evaluarHabilidadToolStripMenuItem.Visible = true;
                    evaluarHabilidadToolStripMenuItem1.Visible = false;
                    MenuEvaluarHabilidad.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvHabilidadesTecnicas_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvHabilidadesTecnicas.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    evaluarHabilidadToolStripMenuItem.Visible = false;
                    evaluarHabilidadToolStripMenuItem1.Visible = false;
                    MenuEvaluarHabilidad.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvHabilidadesTecnicas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    evaluarHabilidadToolStripMenuItem.Visible = false;
                    evaluarHabilidadToolStripMenuItem1.Visible = true;
                    MenuEvaluarHabilidad.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvHabilidadesPersonales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Convertimos a upper case lo que el usuario haya tecleado dentro de la celda
            if (DgvHabilidadesPersonales.CurrentCell.ColumnIndex == 0 || DgvHabilidadesPersonales.CurrentCell.ColumnIndex == 3)
            {
                if (e.Control is TextBox)
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void DgvHabilidadesTecnicas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvHabilidadesTecnicas.CurrentCell.ColumnIndex == 0 || DgvHabilidadesTecnicas.CurrentCell.ColumnIndex == 3)
            {
                if (e.Control is TextBox)
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

       
