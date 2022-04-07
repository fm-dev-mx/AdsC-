using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB_Base.CB_Controles
{
    public partial class AudiselListViewItem : ListViewItem
    {
        public string UriArchivo = "";
        public int IndiceImagen = 0;
        public bool EsImagen = false;

        public AudiselListViewItem()
        {
            InitializeComponent();
        }
    }
}
