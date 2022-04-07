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
    public partial class FrmEditarCotizacion : Form
    {
        Cotizacion CotizacionActual = new Cotizacion();

        public FrmEditarCotizacion(int idCotizacion)
        {
            InitializeComponent();
            CotizacionActual.CargarDatos(idCotizacion);
        }
    }
}
