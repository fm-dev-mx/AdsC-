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
    public partial class FrmAjustarFechasProyecto : Ventana
    {
        decimal IdProyecto = 0;
        public int IdRazon = 0;
        public int DiasNaturales = 0;
        public int IdResponsable = 0;

        public DateTime FechaActual = DateTime.Now;
        public DateTime NuevaFechaAjuste = DateTime.Now;
        public string TipoAjuste = string.Empty;
        string Proyecto = string.Empty;

        public FrmAjustarFechasProyecto(decimal idProyecto)
        {
            InitializeComponent();
            IdProyecto = idProyecto;
        }

        private void FrmAjustarFechasProyecto_Load(object sender, EventArgs e)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.CargarDatos(IdProyecto);

            if(proyecto.TieneFilas())
            {
                FechaInicio.Value = Convert.ToDateTime(proyecto.Fila().Celda("fecha_inicio")).Date;
                FechaEntrega.Value = Convert.ToDateTime(proyecto.Fila().Celda("fecha_entrega")).Date;
                NuevaFechaEntrega.Value = DateTime.Now.Date;
                Proyecto = IdProyecto + " " + proyecto.Fila().Celda("nombre").ToString();
            }

            TxtTipoAjuste.Text = string.Empty;
            NuevaFechaEntrega.MinDate = Convert.ToDateTime(proyecto.Fila().Celda("fecha_entrega")).Date;
            NuevaFechaEntrega.Value = Convert.ToDateTime(proyecto.Fila().Celda("fecha_entrega")).Date;
            CargarRazones();
        }

        private void CargarRazones()
        {
            RazonAjusteFecha razonesAjustes = new RazonAjusteFecha();
            razonesAjustes.SeleccionarRazones().ForEach(delegate(Fila f)
            {
                CmbRazonAjuste.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("razon").ToString());
            });

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea ajustar la fecha de entrega del proyecto " + Proyecto + "?", "Ajustar fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                IdRazon = Convert.ToInt32(CmbRazonAjuste.Text.Split('-')[0].Trim());
                DiasNaturales = Global.CalcularDiasNaturales(FechaEntrega.Value, NuevaFechaEntrega.Value);
                IdResponsable = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));

                FechaActual = FechaEntrega.Value;
                NuevaFechaAjuste = NuevaFechaEntrega.Value;
                TipoAjuste = TxtTipoAjuste.Text;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void NuevaFechaEntrega_ValueChanged(object sender, EventArgs e)
        {
            int diasNaturales = Global.CalcularDiasNaturales(FechaEntrega.Value, NuevaFechaEntrega.Value);

            if (FechaEntrega.Value < NuevaFechaEntrega.Value)
                TxtTipoAjuste.Text = "RETRASO DE " + diasNaturales + " DIAS NATURALES";
            else if (FechaEntrega.Value < NuevaFechaEntrega.Value)
                TxtTipoAjuste.Text = "ADELANTO DE " + diasNaturales + " DIAS NATURALES";
            else if (FechaEntrega.Value == NuevaFechaEntrega.Value)
                TxtTipoAjuste.Text = string.Empty;

            HabilitarBoton();
        }

        private void HabilitarBoton()
        {
            BtnRegistrar.Enabled = (FechaEntrega.Value != NuevaFechaEntrega.Value && CmbRazonAjuste.Text != "");
        }

        private void CmbRazonAjuste_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBoton();
        }
    }
}
