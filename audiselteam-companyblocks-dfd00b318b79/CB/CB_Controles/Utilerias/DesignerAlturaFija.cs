using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace CB_Base.CB_Controles
{
    class DesignerAlturaFija : ControlDesigner
    {
        DesignerAlturaFija()
        {
            base.AutoResizeHandles = true;
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable;
            }
        }
    }
}
