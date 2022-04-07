using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB_Base.CB_Controles
{
    [Designer(typeof(DesignerAlturaFija))]
    public class ControlAlturaFija : UserControl
    {
        int alturaFija = 23;

        [Description("Altura fija"), Category("Data")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int AlturaFija 
        { 
            get
            {
                return alturaFija;
            }
            set
            {
                alturaFija = value;
            }
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            // Set a fixed height for the control.
            base.SetBoundsCore(x, y, width, alturaFija, specified);
        }
    }
}
