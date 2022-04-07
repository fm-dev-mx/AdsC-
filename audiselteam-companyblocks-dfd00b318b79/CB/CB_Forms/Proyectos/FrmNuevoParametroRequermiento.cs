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
    public partial class FrmNuevoParametroRequermiento : Ventana
    {
        int IdRequerimiento = 0;
        int IdParametro = 0;

        public FrmNuevoParametroRequermiento(int idRequerimiento, int idParametro=0)
        {
            InitializeComponent();
            IdParametro = idParametro;
            IdRequerimiento = idRequerimiento;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmNuevoParametroRequermiento_Load(object sender, EventArgs e)
        {
            if( IdParametro > 0 )
            {
                LblTitulo.Text = "EDITAR PARAMETRO";
                BtnRegistrar.Text = "Guardar";

                RequerimientoParametro param = new RequerimientoParametro();
                param.CargarDatos(IdParametro);

                if (param.TieneFilas())
                {
                    TxtNombre.Text = param.Fila().Celda("parametro").ToString();
                    TxtValor.Text = param.Fila().Celda("valor").ToString();
                    TxtComentarios.Text = param.Fila().Celda("comentarios").ToString();
                }
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = TxtNombre.Text != "";
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (TxtValor.Text == "")
                TxtValor.Text = "N/A";

            if(IdParametro == 0)
            {
                Fila param = new Fila();

                param.AgregarCelda("requerimiento", IdRequerimiento);
                param.AgregarCelda("parametro", TxtNombre.Text);
                param.AgregarCelda("valor", TxtValor.Text);
                param.AgregarCelda("comentarios", TxtComentarios.Text);

                RequerimientoParametro.Modelo().Insertar(param);
            }
            else
            {
                RequerimientoParametro param = new RequerimientoParametro();
                param.CargarDatos(IdParametro);

                if(param.TieneFilas())
                {
                    param.Fila().ModificarCelda("parametro", TxtNombre.Text);
                    param.Fila().ModificarCelda("valor", TxtValor.Text);
                    param.Fila().ModificarCelda("comentarios", TxtComentarios.Text);

                    param.GuardarDatos();
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TxtValor_TextChanged(object sender, EventArgs e)
        {
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

    }
}
