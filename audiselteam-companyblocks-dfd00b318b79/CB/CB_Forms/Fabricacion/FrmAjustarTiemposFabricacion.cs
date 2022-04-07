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
    public partial class FrmAjustarTiemposFabricacion : Ventana
    {
        OperacionFabricacion Operacion = new OperacionFabricacion();
        int IdOperacion = 0;
        double TiempoEstandarOperacion = 0;

        public FrmAjustarTiemposFabricacion(string proceso, string operacion)
        {
            InitializeComponent();
            TxtProceso.Text = proceso;
            TxtOperacion.Text = operacion;
            Operacion.SeleccionarOperacionNombe(proceso, operacion);

            if (Operacion.TieneFilas())
            {
                IdOperacion = Convert.ToInt32(Operacion.Fila().Celda("id"));
                TiempoEstandarOperacion = Convert.ToDouble(Operacion.Fila().Celda("tiempo_estandar"));
            }
        }

        private void FrmAjustarTiemposFabricacion_Load(object sender, EventArgs e)
        {
            double tiempoEstandarHoras = Convert.ToDouble(Operacion.Fila().Celda("tiempo_estandar"));
            NumTiempoEstandarMinutos.Value = Convert.ToDecimal(tiempoEstandarHoras * 60);
        }

        private void NumTiempoEstandarMinutos_ValueChanged(object sender, EventArgs e)
        {
            double tiempoEstandarHoras = Convert.ToDouble(NumTiempoEstandarMinutos.Value) / 60.0d;
            Operacion.Fila().ModificarCelda("tiempo_estandar", tiempoEstandarHoras);
            Operacion.GuardarDatos();
            CargarOpcionesFactores(CmbFactor.Text);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CmbFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOpcionesFactores(CmbFactor.Text);
        }

        public void CargarOpcionesFactores(string factor)
        {
            string valorFactor = string.Empty;

            OperacionFabricacion op = new OperacionFabricacion();
            op.SeleccionarOperacionNombe(TxtProceso.Text, TxtOperacion.Text);

            if(!op.TieneFilas())
            {
                MessageBox.Show("No se encontró la operación!", "Operación no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idOperacion = Convert.ToInt32(op.Fila().Celda("id"));
            double tiempoEstandar = Convert.ToDouble(op.Fila().Celda("tiempo_estandar"));

            DgvPorcentajes.Rows.Clear();
            switch(factor)
            {
                case "COMPLEJIDAD":
                    AgregarFilaOpcionFactor(factor, "NADA COMPLEJA", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "POCO COMPLEJA", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "COMPLEJA", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "MUY COMPLEJA", tiempoEstandar);
                    break;

                case "MATERIAL":
                    AgregarFilaOpcionFactor(factor, "ACERO", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "ALUMINIO", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "PLASTICO", tiempoEstandar);
                    break;

                case "PRESENTACION":
                    AgregarFilaOpcionFactor(factor, "PRISMA", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "PLACA", tiempoEstandar);
                    break;

                case "DIMENSIONES":
                    AgregarFilaOpcionFactor(factor, "CHICA", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "MEDIANA", tiempoEstandar);
                    AgregarFilaOpcionFactor(factor, "GRANDE", tiempoEstandar);
                    break;
            }
        }

        public void AgregarFilaOpcionFactor(string factor, string valorFactor, double tiempoEstandar)
        {
            FactorOperacionFabricacion factores = new FactorOperacionFabricacion();
            double tiempoAdicional = 0;
            decimal porcentaje = factores.PorcentajeDelFactor(IdOperacion, factor, valorFactor);
            tiempoAdicional = (tiempoEstandar * (double)porcentaje / 100.00) * 60;
            DgvPorcentajes.Rows.Add(valorFactor, porcentaje, tiempoAdicional);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void DgvPorcentajes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;

            string factorValor = DgvPorcentajes.Rows[e.RowIndex].Cells[0].Value.ToString();
            decimal factorPorcentaje = Convert.ToDecimal(DgvPorcentajes.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue);

            FactorOperacionFabricacion f = new FactorOperacionFabricacion();
            f.SeleccionarOperacionFactorValor(IdOperacion, CmbFactor.Text, factorValor);
            
            if(f.TieneFilas())
            {
                f.Fila().ModificarCelda("factor_porcentaje", factorPorcentaje);
                f.GuardarDatos();
            }
            else
            {
                Fila datosFactor = new Fila();
                datosFactor.AgregarCelda("operacion", IdOperacion);
                datosFactor.AgregarCelda("factor", CmbFactor.Text);
                datosFactor.AgregarCelda("factor_valor", factorValor);
                datosFactor.AgregarCelda("factor_porcentaje", factorPorcentaje);
                f.Insertar(datosFactor);
            }
            DgvPorcentajes.Rows[e.RowIndex].Cells[2].Value = (TiempoEstandarOperacion * (double)factorPorcentaje / 100.0) * 60.0;
        }

        private void DgvPorcentajes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;

            int porcentaje = 0;
            string valorCelda = e.FormattedValue.ToString();
            bool esNumero = int.TryParse(valorCelda, out porcentaje);
            bool enRango = porcentaje >= 0 && porcentaje <= 100;

            if(!esNumero || !enRango)
            {
                MessageBox.Show("Ingresa un número entre 0 y 100!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void DgvPorcentajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
