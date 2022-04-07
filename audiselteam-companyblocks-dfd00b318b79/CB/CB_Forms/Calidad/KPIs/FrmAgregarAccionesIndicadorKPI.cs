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
    public partial class FrmAgregarAccionesIndicadorKPI : Ventana
    {
        int IdAccion = 0;
        public string estatus = string.Empty;
        public string tipoAccion = string.Empty;
        public string Detalles = string.Empty;
        public DateTime FechaPromesa;
        
        string Proceso = string.Empty;
        string Indicador = string.Empty;

        public FrmAgregarAccionesIndicadorKPI(string proceso, string indicador, int idAccion = 0)
        {
            InitializeComponent();
            IdAccion = idAccion;
            Proceso = proceso;
            Indicador = indicador;
        }

        private void FrmAgregarAccionesIndicadorKPI_Load(object sender, EventArgs e)
        {
            TxtProceso.Text = Proceso;
            TxtIndicador.Text = Indicador;

            if (IdAccion != 0)
            {
                LblTitulo.Text = "EDITAR ACCION";
                Accion acciones = new Accion();
                acciones.CargarAccionYTareas(IdAccion);
                if (acciones.TieneFilas())
                {
                    object fechaPromesa = acciones.Fila().Celda("fecha_promesa");

                    CmbTipoAccion.Text = Global.ObjetoATexto(acciones.Fila().Celda("tipo"), "");

                    if (fechaPromesa != null)
                        DTFechaPromesa.Value = Convert.ToDateTime(fechaPromesa);

                    CmbEstatus.Text = Global.ObjetoATexto(acciones.Fila().Celda("estatus"), "");
                    TxtDetalles.Text = Global.ObjetoATexto(acciones.Fila().Celda("descripcion"), "");
                }
            }
            else
            {
                LblTitulo.Text = "NUEVA ACCION";
                CmbEstatus.SelectedIndex = 0;
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
                Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (CmbTipoAccion.Text == "" || CmbEstatus.Text == "")
            {
                MessageBox.Show("Favor de llenar toda la información solicitada", "Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Desea guardar la acción proporcionada?", "Guardar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                estatus = CmbEstatus.Text;
                tipoAccion = CmbTipoAccion.Text;
                FechaPromesa = DTFechaPromesa.Value;
                Detalles = TxtDetalles.Text;
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }
    }
}