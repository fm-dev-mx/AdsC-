using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.CB_Controles;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmCancelarPo : Form
    {
        public string Razon = string.Empty;
        public string Correo = string.Empty; 
       
        int IdPo = 0;

        public FrmCancelarPo(int idPo)
        {
            InitializeComponent();
            IdPo = idPo;
            LblPo.Text = "PO: #" + idPo.ToString();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            Razon = TxtRazon.Text;
            Correo = CmbProveedorContacto.Text;
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
            Close();
        }

        private void FrmCancelarPo_Load(object sender, EventArgs e)
        {
            PoMaterial po = new PoMaterial();
            po.CargarDatos(IdPo);

            ProveedorContacto contactos = new ProveedorContacto();
            contactos.CargarDeProveedor(po.Fila().Celda<int>("proveedor"));

            contactos.Filas().ForEach(delegate(Fila contactoProveedor) {
                CmbProveedorContacto.Items.Add(contactoProveedor.Celda("correo").ToString());
            });

            if(contactos.TieneFilas())
            {
                CmbProveedorContacto.SelectedIndex = 0;
            }
        }
    }
}
