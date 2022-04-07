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
    public partial class FrmCrearNuevoDefecto : Ventana
    {
        public int CantidadOk = 0;
        public int CantidadNoOk = 0;
        public string Comentarios = string.Empty;
        public string TipoDefecto = string.Empty;
        public string ProcesoConDefecto = string.Empty;
        int IdPlano = 0;
        BindingSource ProcesoBinding = new BindingSource();
        BindingSource TiposBinding = new BindingSource();

        public FrmCrearNuevoDefecto(int plano, int cantidadNoOk = 1, string comentarios = "")
        {
            InitializeComponent();
            TxtComentarios.Text = comentarios;
            NumNOK.Value = Convert.ToDecimal(cantidadNoOk);
            IdPlano = plano;
        }

        private void FrmAgregarProcesoNoConforme_Load(object sender, EventArgs e)
        {
            CargarProcesos();
            CargarTipoDefecto();
        }

        private void CargarProcesos()
        {
            ProcesoBinding.Clear();
            PlanoProceso.Modelo().CargarDePlano(IdPlano).ForEach(delegate(Fila f)
            {
                ProcesoBinding.Add
                (
                     new
                    {
                        Text = f.Celda("proceso").ToString(),
                        Value = f.Celda("id")
                    }
                );
            });

            CmbProceso.DisplayMember = "Text";
            CmbProceso.ValueMember = "Value";
            CmbProceso.DataSource = ProcesoBinding;
        }

        private void CargarTipoDefecto()
        {
            TiposBinding.Clear();
            TipoDefecto defectos = new TipoDefecto();
            defectos.SeleccionarTipos().ForEach(delegate(Fila f)
            {
                TiposBinding.Add
                (
                     new
                     {
                         Text = f.Celda("tipos").ToString(),
                         Value = f.Celda("id")
                     }
                );
            });

            CmbTipoDefecto.DisplayMember = "Text";
            CmbTipoDefecto.ValueMember = "Value";
            CmbTipoDefecto.DataSource = TiposBinding;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            CantidadOk = Convert.ToInt32(NumOK.Value);
            CantidadNoOk = Convert.ToInt32(NumNOK.Value);
            Comentarios = TxtComentarios.Text;
            TipoDefecto = CmbTipoDefecto.SelectedValue.ToString();
            ProcesoConDefecto = CmbProceso.SelectedValue.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TxTCantidadNoOk_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != string.Empty);
        }

        private void TxTCantidadOk_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != string.Empty);
        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (TxtComentarios.Text != string.Empty);
        }
    }
}
