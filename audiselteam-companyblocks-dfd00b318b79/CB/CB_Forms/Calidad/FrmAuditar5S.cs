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
    public partial class FrmAuditar5S : Ventana
    {
        int IdAuditoria = 0;
        public int IdResponsable = 0;
        public string Resultado = string.Empty;
        public string NotasAuditor = string.Empty;
        public string Avance = string.Empty;

        public FrmAuditar5S(int idAuditoria)
        {
            InitializeComponent();
            IdAuditoria = idAuditoria;
        }

        private void CargarUditoria()
        {
            Auditoria5s auditoria = new Auditoria5s();
            auditoria.CargarDatos(IdAuditoria);
            if (auditoria.TieneFilas())
            {
                TxtArea.Text = Global.ObjetoATexto(auditoria.Fila().Celda("area"), "");
                TxtEtapa.Text = Global.ObjetoATexto(auditoria.Fila().Celda("etapa"), "");
                TxtPuntoInspeccion.Text = Global.ObjetoATexto(auditoria.Fila().Celda("punto_inspeccion"), "");
            }
        }
        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Está seguro que desea terminar la auditoría del punto " + TxtEtapa.Text.ToLower() + " al área de" + TxtArea.Text.ToLower() + "?", "Terminar auditoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Resultado = CmbResultado.Text;
                NotasAuditor = TxtComentariosAuditor.Text;
                Avance = "PENDIENTE";
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if(usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtResponsable.Text = Global.ObjetoATexto(usuario.UsuarioSeleccionado.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.UsuarioSeleccionado.Fila().Celda("paterno"), "");
                IdResponsable = Convert.ToInt32(Global.ObjetoATexto(usuario.UsuarioSeleccionado.Fila().Celda("id"), ""));
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAuditar5S_Load(object sender, EventArgs e)
        {
            CargarUditoria();
        }

        private void TxtComentariosAuditor_TextChanged(object sender, EventArgs e)
        {
            BtnFinalizar.Enabled = (CmbResultado.Text != "" && TxtResponsable.Text != "" && TxtComentariosAuditor.Text != "");
        }

        private void CmbResultado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnFinalizar.Enabled = (CmbResultado.Text != "" && TxtResponsable.Text != "" && TxtComentariosAuditor.Text != "");
        }

        private void TxtResponsable_TextChanged(object sender, EventArgs e)
        {
            BtnFinalizar.Enabled = (CmbResultado.Text != "" && TxtResponsable.Text != "" && TxtComentariosAuditor.Text != "");
        }
    }
}
