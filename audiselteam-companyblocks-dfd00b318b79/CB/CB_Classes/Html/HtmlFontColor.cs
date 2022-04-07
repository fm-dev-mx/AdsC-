using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class HtmlFontColor : HtmlEntity
    {
        protected string fontColor = string.Empty;

        public HtmlFontColor(string fColor)
        {
            fontColor = fColor;

            this.openTag = "<font color=" + fontColor + ">";
            this.closeTag = "</font>";
        }
    
    }
}
