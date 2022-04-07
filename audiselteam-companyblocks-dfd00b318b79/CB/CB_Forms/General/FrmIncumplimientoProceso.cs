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

    public partial class FrmIncumplimientoProceso : Ventana
    {
        int IdIncumplimiento;
        string Proceso = string.Empty;
        string Texto = string.Empty;
        public string Mensaje = string.Empty;

        public FrmIncumplimientoProceso(string proceso, int idUsuario, int incumplimiento, string texto)
        {
            InitializeComponent();
            Proceso = proceso;
            Texto = texto;
            this.IdIncumplimiento = incumplimiento;
        }

        private void FrmIncumplimientoProceso_Load(object sender, EventArgs e)
        {
            TxtProceso.Text = Proceso;
            TxtUsuario.Text = Global.UsuarioActual.NombreCompleto();

            ListaIncumplimiento incumplimiento = new ListaIncumplimiento();
            incumplimiento.CargarDatos(IdIncumplimiento);
            if(incumplimiento.TieneFilas())
            {
                TxtCodigoIncumplimiento.Text = incumplimiento.Fila().Celda("id").ToString().PadLeft(3, '0') + " - " + incumplimiento.Fila().Celda("nombre_incumplimiento");
                TxtDetalles.Text = Global.ObjetoATexto(incumplimiento.Fila().Celda("detalles"), "") + Environment.NewLine + Texto.ToUpper();
            }
        }

        private void LblMaterial_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            Mensaje = TxtDetalles.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

    }
}
