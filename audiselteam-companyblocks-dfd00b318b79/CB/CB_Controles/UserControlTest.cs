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
    public partial class UserControlTest : AudiselComboBox
    {        
        public UserControlTest()
        {
            InitializeComponent();
        }

        new private void UserControlTest_Load(object sender, EventArgs e)
        {
            EnlaceInformacion = new BindingSource();
            Usuario usuarios = new Usuario();
            usuarios.SeleccionarDatos("", null, "id, CONCAT(nombre, ' ', paterno) as nombre order by nombre");
            CargarInformacion(usuarios.FilasParaComboBox("id", "nombre"));
        }
    }
}
