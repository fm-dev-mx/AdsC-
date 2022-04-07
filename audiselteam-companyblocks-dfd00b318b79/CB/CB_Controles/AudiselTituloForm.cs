using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CB_Base.CB_Controles
{
    public partial class AudiselTituloForm : ControlAlturaFija
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();


        [Description("Text"), Category("Data")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        override public string Text
        {
            get { return LblTitulo.Text; }
            set { LblTitulo.Text = value.ToString().ToUpper(); }
        }

        public AudiselTituloForm()
        {
            InitializeComponent();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Control formContenedor = this.TopLevelControl;

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(formContenedor.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
