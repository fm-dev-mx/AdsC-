using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmNuevoPuntoInspeccion5s : Ventana
    {
        public string Area = string.Empty;
        public string Etapa = string.Empty;
        public string PuntoInspeccion = string.Empty;

        public FrmNuevoPuntoInspeccion5s()
        {
            InitializeComponent();
        }

        private void CargarAreas()
        {
            Auditoria5s.Modelo().SeleccionarAreas().ForEach(delegate(Fila f)
            {
                CmbArea.Items.Add(f.Celda("area").ToString());
            });

            if (CmbArea.Items.Count > 0)
                CmbArea.SelectedIndex = 0;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea crear un nuevo punto de inspección en el área " + CmbArea.Text + " en la etapa " + CmbEtapa.Text + "?", "Crear nuevo punto de inspección", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Area = CmbArea.Text;
                Etapa = CmbEtapa.Text;
                PuntoInspeccion = TxtPuntoInspeccion.Text;

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void TxtPuntoInspeccion_TextChanged(object sender, EventArgs e)
        {
            HabilitarBotonFinalizar();
        }

        public void HabilitarBotonFinalizar()
        {
            BtnFinalizar.Enabled = (TxtPuntoInspeccion.Text != string.Empty && CmbArea.Text != string.Empty && CmbEtapa.Text != string.Empty);
        }

        private void CmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBotonFinalizar();
        }

        private void CmbEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBotonFinalizar();
        }

        private void CmbArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void FrmNuevoPuntoInspeccion5s_Load(object sender, EventArgs e)
        {
            CargarAreas();
        }
    }
}
