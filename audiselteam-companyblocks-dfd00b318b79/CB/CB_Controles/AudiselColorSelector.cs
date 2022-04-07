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
    public partial class AudiselColorSelector : ToolStripSplitButton
    {
        private Color color = Color.Black;
        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
                RefrescarVistaPreviaColor();

            }
        }

        public AudiselColorSelector()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void RefrescarVistaPreviaColor()
        {
            int width = 16;
            int height = 16;

            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        bmp.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, Color);
                    }
                }
            }

            this.Image = bmp;
        }
    }
}
