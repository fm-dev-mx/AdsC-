using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CB_Base.Classes
{
    public partial class Ventana : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public void Mover(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void LlenarDataGridView(List<Fila> filas, DataGridView dgv, bool borrarDatos=true)
        {
            int fila = Global.GuardarFilaSeleccionada(dgv);

            if (borrarDatos)
                dgv.Rows.Clear();

            filas.ForEach(delegate(Fila f)
            {
                int rowIndex = dgv.Rows.Add();
                var row = dgv.Rows[rowIndex];

                foreach(KeyValuePair<string, object> c in f.Celdas())
                {
                    if(dgv.Columns.Contains(c.Key))
                        row.Cells[c.Key].Value = c.Value;
                }
            });

            Global.RecuperarFilaSeleccionada(dgv, fila);
        }

        // Save the current scale value
        // ScaleControl() is called during the Form's constructor
        protected SizeF scale = new SizeF(1.0f, 1.0f);
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            scale = new SizeF(scale.Width * factor.Width, scale.Height * factor.Height);
            base.ScaleControl(factor, specified);
        }

        // Recursively search for SplitContainer controls
        protected void Fix(Control c)
        {
            foreach (Control child in c.Controls)
            {
                if (child is SplitContainer)
                {
                    SplitContainer sp = (SplitContainer)child;
                    Fix(sp);
                    Fix(sp.Panel1);
                    Fix(sp.Panel2);
                }
                else
                {
                    Fix(child);
                }
            }
        }

        protected void Fix(SplitContainer sp)
        {
            // Scale factor depends on orientation
            float sc = (sp.Orientation == Orientation.Vertical) ? scale.Width : scale.Height;
            if (sp.FixedPanel == FixedPanel.Panel1)
            {
                sp.SplitterDistance = (int)Math.Round((float)sp.SplitterDistance * sc);
            }
            else if (sp.FixedPanel == FixedPanel.Panel2)
            {
                int cs = (sp.Orientation == Orientation.Vertical) ? sp.Panel2.ClientSize.Width : sp.Panel2.ClientSize.Height;
                int newcs = (int)((float)cs * sc);
                sp.SplitterDistance -= (newcs - cs);
            }
        }
    }
}
