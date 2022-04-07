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
    public partial class FrmNuevoPasoModulo : Ventana
    {
        public int IdModulo = 0;

        public  FrmNuevoPasoModulo(int idModulo)
        {
            InitializeComponent();
            IdModulo = idModulo;
        }

        public void CargarElementos()
        {
            DgvElementos.Rows.Clear();
            Elemento.Modelo().SeleccionarModulo(IdModulo).ForEach(delegate(Fila f)
            {
                DgvElementos.Rows.Add(f.Celda("id"), f.Celda("nombre"));
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmNuevoPasoModulo_Load(object sender, EventArgs e)
        {
            CargarElementos();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (DgvElementos.SelectedRows.Count < 0)
                return;

            Fila f = new Fila();
            f.AgregarCelda("modulo", IdModulo);
            f.AgregarCelda("paso", 0);
            f.AgregarCelda("elemento", Convert.ToInt32(DgvElementos.SelectedRows[0].Cells["id_elemento"].Value));
            f.AgregarCelda("accion", TxtAccion.Text);
            ModuloPaso.Modelo().Insertar(f);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void TxtAccion_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = DgvElementos.SelectedRows.Count > 0 && TxtAccion.Text != "";
        }
    }
}
