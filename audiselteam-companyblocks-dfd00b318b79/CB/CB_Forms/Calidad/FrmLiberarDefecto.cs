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
    public partial class FrmLiberarDefecto : Ventana
    {
        public PlanoProyecto Plano = new PlanoProyecto();
        public string Disposicion = string.Empty;

        public FrmLiberarDefecto(int idPlano)
        {
            InitializeComponent();
            Plano.CargarDatos(idPlano);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CmbDisposicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnLiberar.Enabled = CmbDisposicion.Text != string.Empty;
            Disposicion = CmbDisposicion.Text;
        }

        private void FrmLiberarNoConformidad_Load(object sender, EventArgs e)
        {
          /*  switch(NC.Fila().Celda("proceso_origen").ToString())
            {
                case "FABRICACION":*/
                    LblDetallesNC.Text = Plano.Fila().Celda("id") + " | " + Plano.Fila().Celda("nombre_archivo") + " | " + Plano.Fila().Celda("cantidad") + " PIEZA(S)" + Environment.NewLine;
                    //LblDetallesNC.Text += NC.Filas().Count + " PROCESO(S) CON DEFECTOS.";
                  /*  break;
            }*/
        }

        private void BtnLiberar_Click(object sender, EventArgs e)
        {
            Plano.Fila().ModificarCelda("estatus", Disposicion);
            Plano.GuardarDatos();

            DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }
    }
}
