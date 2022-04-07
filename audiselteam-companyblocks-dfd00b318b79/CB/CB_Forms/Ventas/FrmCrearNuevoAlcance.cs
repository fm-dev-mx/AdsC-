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
    public partial class FrmCrearNuevoAlcance : Form
    {
        int IdCotizacion = 0;
        int CeldasSeleccionadas = 0;
        BindingSource ProcesoBinding = new BindingSource();

        public FrmCrearNuevoAlcance(int idCotizacion)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
        }

        private void FrmCrearNuevoAlcance_Load(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = false;
            CargarProcesos();
        }

        private void CargarProcesos()
        {
            ProcesoBinding.Clear();
            string industriaNombre = string.Empty;
            Proceso procesos = new Proceso();
            procesos.SeleccionarProcesosEnformato(1).ForEach(delegate(Fila f)
            {
                ProcesoBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });

            CmbProcesos.DisplayMember = "Text";
            CmbProcesos.ValueMember = "Value";
            CmbProcesos.DataSource = ProcesoBinding;
            CmbProcesos.Text = industriaNombre;
        }

        private void CargarAlcances()
        {
            DgvAlcance.Rows.Clear();

            ProcesoAlcance procesoAlcance = new ProcesoAlcance();
            procesoAlcance.CargarAlcancesDeProceso(Convert.ToInt32(CmbProcesos.SelectedValue)).ForEach(delegate(Fila f)
            {
                DgvAlcance.Rows.Add
                (
                    f.Celda("id"),
                    false,
                    f.Celda("alcance")
                );
            });
        }

        private void CmbProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAlcances();
            TxtAlcance.Text = string.Empty;
            CeldasSeleccionadas = 0;
            HabilitarBotonAceptar();
        }

        private void HabilitarBotonAceptar()
        {
            BtnAceptar.Enabled = (CeldasSeleccionadas > 0 && NumHoras.Value > 0);
        }

        private void DgvAlcance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvAlcance.Rows[e.RowIndex].Cells["chk"];
            if (chk.Value == chk.TrueValue)
            {
                chk.Value = chk.FalseValue;
                if (CeldasSeleccionadas > 0)
                    CeldasSeleccionadas--;
            }
            else
            {
                chk.Value = chk.TrueValue;
                CeldasSeleccionadas++;
            }

            TxtAlcance.Text = calcularNombre();
            HabilitarBotonAceptar();
        }

        private string calcularNombre()
        {
            string nombreAlcance = string.Empty;

            if (DgvAlcance.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in DgvAlcance.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["chk"].Value))
                        nombreAlcance += row.Cells["alcance"].Value.ToString() + " + ";
                }
            }

            if (nombreAlcance != "")
                nombreAlcance = nombreAlcance.Remove(nombreAlcance.Length - 2);

            return nombreAlcance;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Fila insertarNuevoAlcance = new Fila();
            insertarNuevoAlcance.AgregarCelda("cotizacion", IdCotizacion);
            insertarNuevoAlcance.AgregarCelda("proceso", Convert.ToInt32(CmbProcesos.SelectedValue));
            insertarNuevoAlcance.AgregarCelda("alcance", TxtAlcance.Text);
            insertarNuevoAlcance.AgregarCelda("personas", NumPersonas.Value);
            insertarNuevoAlcance.AgregarCelda("horas", NumHoras.Value);
            CotizacionAlcance.Modelo().Insertar(insertarNuevoAlcance);

            MessageBox.Show("El alcance " + CmbProcesos.SelectedText + " - " + TxtAlcance.Text + " ha sido creado correctamente.", "Alcance creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NumHoras_ValueChanged(object sender, EventArgs e)
        {
            HabilitarBotonAceptar();
        }
    }
}
