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
    public partial class FrmRazonBajaUsuario : Ventana
    {
        int IdEmpleado = 0;
        string NombreEmpleado = string.Empty;
        public int IdRazon = 0;
        public string Comentarios = string.Empty;

        public FrmRazonBajaUsuario(int idEmpleado)
        {
            InitializeComponent();
            IdEmpleado = idEmpleado;
            ActiveControl = TxtComentariosBaja;
            TxtComentariosBaja.Focus();
        }

        private void FrmRazonBajaUsuario_Load(object sender, EventArgs e)
        {
            CargarRazones();
            Usuario.Modelo().CargarDatos(IdEmpleado).ForEach(delegate(Fila f)
            {
                NombreEmpleado = IdEmpleado + " - " + f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString();               
            });

            LblUsuarioBaja.Text +=  NombreEmpleado;
            HabilitarBotonAceptar();
        }

        private void CargarRazones()
        {
            RazonBajaUsuario razones = new RazonBajaUsuario();
            razones.SeleccionarRazones().ForEach(delegate(Fila f)
            {
                CmbRazonBaja.Items.Add(f.Celda("id") + " - " + f.Celda("razon"));
            });

            if (CmbRazonBaja.Items.Count > 0)
                CmbRazonBaja.SelectedIndex = 0;
        }


        private void CargarDescripcion(int id)
        {
            RazonBajaUsuario razon = new RazonBajaUsuario();
            razon.CargarDatos(id);
            if(razon.TieneFilas())
                TxtDetalles.Text = Global.ObjetoATexto(razon.Fila().Celda("descripcion"), "");
        }
        private void HabilitarBotonAceptar()
        {
            BtnAsignar.Enabled = (CmbRazonBaja.Text != "" && TxtComentariosBaja.Text != "");
        }

        private void LblMaterial_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {           
            Comentarios = TxtComentariosBaja.Text;
            IdRazon = Convert.ToInt32(CmbRazonBaja.Text.Split('-')[0].Trim());
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void CmbRazonBaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbRazonBaja.Text != "")
                CargarDescripcion(Convert.ToInt32(CmbRazonBaja.Text.Split('-')[0].Trim()));

            HabilitarBotonAceptar();
        }

        private void TxtComentariosBaja_TextChanged(object sender, EventArgs e)
        {           
            HabilitarBotonAceptar();
        }
    }
}
