using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;

namespace CB_Base.CB_Controles
{
    public partial class AudiselComboBox : ControlAlturaFija
    {
        public BindingSource EnlaceInformacion = new BindingSource();

        public AudiselComboBox()
        {
            InitializeComponent();
        }

        void AudiselComboBox_Load(object sender, EventArgs e)
        {
            CmbDatos.SelectedIndex = 0;
        }

        public void CargarInformacion(List<ValoresComboBox> valores)
        {
            EnlaceInformacion.DataSource = valores;
            CmbDatos.DataSource = EnlaceInformacion;
            CmbDatos.DisplayMember = "Texto";
            CmbDatos.ValueMember = "Valor";
        }

    }
}
