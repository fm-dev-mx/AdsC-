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
    public partial class FrmRecibirPiezaTratamiento : Ventana
    {
        List<int> ListaPlano = new List<int>();
        List<int> ListaProceso = new List<int>();
        List<int> Terminado = new List<int>();
        public FrmRecibirPiezaTratamiento()
        {
            InitializeComponent();
        }

        private void CargarValeSalidaItems()
        {
            ListaPlano.Clear();
            DgvRecibirPiezaAluminio.Rows.Clear();
            DgvRecibirPiezasAcero.Rows.Clear();

            ValeSalidaItem valeItems = new ValeSalidaItem();
            valeItems.CargarItemsVale(Convert.ToInt32(NumValeSalida.Value)).ForEach(delegate(Fila f)
            {      
                if (f.Celda("categoria").ToString() == "ALUMINIO")
                    DgvRecibirPiezaAluminio.Rows.Add(false, f.Celda("idVale"), f.Celda("cantidad"), f.Celda("idPlano"), f.Celda("nombre_archivo"), f.Celda("requisicion_compra"), f.Celda("estatus"), f.Celda("proceso") + " - " + f.Celda("tratamientoProceso"));
                else if (f.Celda("categoria").ToString() == "ACERO")
                    DgvRecibirPiezasAcero.Rows.Add(false, f.Celda("idVale"), f.Celda("cantidad"), f.Celda("idPlano"), f.Celda("nombre_archivo"), f.Celda("requisicion_compra"), f.Celda("estatus"), f.Celda("proceso") + " - " + f.Celda("tratamientoProceso"));
            });

            if (DgvRecibirPiezaAluminio.Rows.Count > 0)
                DgvRecibirPiezaAluminio.ClearSelection();
            if (DgvRecibirPiezasAcero.Rows.Count > 0)
                DgvRecibirPiezasAcero.ClearSelection();
        }

        private void FrmRecibirPiezaTratamiento_Load(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = false;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los cambios no serán guardados, ¿Está seguro de salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void NumValeSalida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CargarValeSalidaItems();
        }

        private void DgvRecibirPiezaAluminio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells[0];
            if (chk.Value == chk.TrueValue)
            {
                chk.Value = chk.FalseValue;
                DgvRecibirPiezaAluminio.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                DgvRecibirPiezaAluminio.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                DgvRecibirPiezaAluminio.Rows[e.RowIndex].Selected = false;
                if (ListaPlano.Contains(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["numero_parte_aluminio"].Value)))
                    ListaPlano.Remove(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["numero_parte_aluminio"].Value));
                if (ListaProceso.Contains(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["pza_aluminio_proceso"].Value.ToString().Split('-')[0].Trim())))
                    ListaProceso.Remove(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["pza_aluminio_proceso"].Value.ToString().Split('-')[0].Trim()));
                
            }
            else
            {
                chk.Value = chk.TrueValue;
                DgvRecibirPiezaAluminio.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                DgvRecibirPiezaAluminio.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                if (!Terminado.Contains(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["numero_parte_aluminio"].Value)))
                    ListaPlano.Add(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["numero_parte_aluminio"].Value));
                if (!ListaProceso.Contains(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["pza_aluminio_proceso"].Value.ToString().Split('-')[0].Trim())))
                    ListaProceso.Add(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["pza_aluminio_proceso"].Value.ToString().Split('-')[0].Trim()));
            }

            if (ListaPlano.Count <= 0)
                BtnAceptar.Enabled = false;
            else
                BtnAceptar.Enabled = true;
        }

        private void DgvRecibirPiezasAcero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells[0];
            if (chk.Value == chk.TrueValue)
            {
                chk.Value = chk.FalseValue;
                DgvRecibirPiezasAcero.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                DgvRecibirPiezasAcero.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                DgvRecibirPiezasAcero.Rows[e.RowIndex].Selected = false;
                if (ListaPlano.Contains(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["numero_parte_acero"].Value)))
                    ListaPlano.Remove(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["numero_parte_acero"].Value));
                if (ListaProceso.Contains(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["pza_acero_proceso"].Value.ToString().Split('-')[0].Trim())))
                    ListaProceso.Remove(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["pza_acero_proceso"].Value.ToString().Split('-')[0].Trim()));
            }
            else
            {
                DgvRecibirPiezasAcero.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                chk.Value = chk.TrueValue;
                DgvRecibirPiezasAcero.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                if (!Terminado.Contains(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["numero_parte_acero"].Value)))
                    ListaPlano.Add(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["numero_parte_acero"].Value));
                if (!ListaProceso.Contains(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["pza_acero_proceso"].Value.ToString().Split('-')[0].Trim())))
                    ListaProceso.Add(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["pza_acero_proceso"].Value.ToString().Split('-')[0].Trim()));
            }

            if (ListaPlano.Count <= 0)
                BtnAceptar.Enabled = false;
            else
                BtnAceptar.Enabled = true;
        }

        private void DgvRecibirPiezaAluminio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
                                                                                                      
            if(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["estatus_aluminio"].Value.ToString() != "EN TRATAMIENTO")
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["check"];
                chk.Value = chk.TrueValue;
                Terminado.Add(Convert.ToInt32(DgvRecibirPiezaAluminio.Rows[e.RowIndex].Cells["numero_parte_aluminio"].Value));
                DgvRecibirPiezaAluminio.Rows[e.RowIndex].ReadOnly = true;
            }
        }

        private void DgvRecibirPiezasAcero_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["estatus_acero"].Value.ToString() != "EN TRATAMIENTO")
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells[0];
                chk.Value = chk.TrueValue;
                Terminado.Add(Convert.ToInt32(DgvRecibirPiezasAcero.Rows[e.RowIndex].Cells["numero_parte_acero"].Value));
                DgvRecibirPiezasAcero.Rows[e.RowIndex].ReadOnly = true;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de recibir de tratamiento las piezas seleccionadas?", "Recibir piezas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProyecto planos = new PlanoProyecto();
                PlanoProceso proceso = new PlanoProceso();

                foreach (int idPlano in ListaPlano)
                {
                    planos.CargarDatos(idPlano);
                    if(planos.TieneFilas())
                    {
                        planos.Fila().ModificarCelda("estatus", "RECIBIDO");
                        planos.GuardarDatos();
                    }
                }

                foreach (int idProceso in ListaProceso)
                {
                    proceso.CargarDatos(idProceso);
                    if (proceso.TieneFilas())
                    {
                        proceso.Fila().ModificarCelda("estatus", "TERMINADO");
                        proceso.Fila().ModificarCelda("fecha_termino", DateTime.Now);
                        proceso.GuardarDatos();

                        //Proceso de inspeccion de tratamiento
                        Fila insertarProceso = new Fila();

                        insertarProceso.AgregarCelda("plano", proceso.Fila().Celda("plano"));
                        insertarProceso.AgregarCelda("proceso", "INSPECCION DE TRATAMIENTO");
                        insertarProceso.AgregarCelda("maquina", "LABORATORIO DE CALIDAD");
                        insertarProceso.AgregarCelda("programador", "N/A");
                        insertarProceso.AgregarCelda("operador", "LABORATORIO DE CALIDAD");
                        insertarProceso.AgregarCelda("comentarios", "INSPECCION");
                        insertarProceso.AgregarCelda("proceso_anterior", idProceso);
                        insertarProceso.AgregarCelda("orden", Convert.ToInt32(proceso.Fila().Celda("orden")) + 1);
                        PlanoProceso.Modelo().Insertar(insertarProceso);
                    }
                }

                MessageBox.Show("Coloque las piezas en el rack de piezas recibidas de tratamiento y prepare su inspección", "Piezas recibidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void NumValeSalida_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
