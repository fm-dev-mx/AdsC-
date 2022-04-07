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
    public partial class FrmNuevaOperacionFabricacion : Ventana
    {
        string NombreProceso = string.Empty;
        public string NombreOperacion = string.Empty;

        public FrmNuevaOperacionFabricacion(string nombreProceso)
        {
            InitializeComponent();
            NombreProceso = nombreProceso;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmNuevaOperacionFabricacion_Load(object sender, EventArgs e)
        {
            TxtProceso.Text = NombreProceso;
            ActiveControl = TxtNombreOperacion;
            TxtNombreOperacion.Focus();
        }

        private void TxtNombreOperacion_TextChanged(object sender, EventArgs e)
        {
            NombreOperacion = TxtNombreOperacion.Text;
            BtnCrear.Enabled = TxtNombreOperacion.Text != string.Empty;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            Fila nuevaOperacion = new Fila();
            nuevaOperacion.AgregarCelda("nombre_proceso", NombreProceso);
            nuevaOperacion.AgregarCelda("nombre_operacion", NombreOperacion);
            nuevaOperacion.AgregarCelda("tiempo_estandar", 1.0d / 60.0d);
            OperacionFabricacion.Modelo().Insertar(nuevaOperacion);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
