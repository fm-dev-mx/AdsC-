using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmGenerarReportePO : Form
    {
        public FrmGenerarReportePO()
        {
            InitializeComponent();
        }

        private void FrmGenerarReportePO_Load(object sender, EventArgs e)
        {

        }

        private void CargarReporte()
        {
            DgvReporte.Rows.Clear();
            PoMaterial po = new PoMaterial();
            po.ReporteOrdenesCompra(DtpFechaInicio.Value.Date, DtpFechaFin.Value.Date).ForEach(delegate(Fila f)
            {
                DgvReporte.Rows.Add
                (
                    f.Celda("id"),
                    f.Celda("estatus"),
                    Convert.ToDecimal(f.Celda("sub_total")).ToString("C", CultureInfo.CurrentCulture),
                    f.Celda("moneda")
                );
            });

        }

        private void DtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (DtpFechaInicio.Value > DtpFechaFin.Value)
            {
                MessageBox.Show("La fecha 'A partir del' no puede ser mayor que la fecha 'Hasta'", "Seleccione otra fecha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtpFechaInicio.Value = DtpFechaFin.Value.AddDays(-1);
            }
            else
                CargarReporte();
        }

        private void DtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (DtpFechaFin.Value < DtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha 'Hasta' no puede ser menor que la fecha inicio", "Seleccione otra fecha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DtpFechaFin.Value = DtpFechaInicio.Value.AddDays(1);
            }
            else
                CargarReporte();
        }
    }
}
