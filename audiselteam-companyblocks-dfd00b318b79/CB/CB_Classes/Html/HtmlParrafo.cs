using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class HtmlParrafo : HtmlEntity
    {
        protected string align = string.Empty;
        public HtmlParrafo()
        {
            this.openTag = "<p>";
            this.closeTag = "</p>";
        }

        public void setAlign(string alinear)
        {
            align = alinear;
            string opcion = string.Empty;

            if (align.ToLower() == "right" || align.ToLower() == "left" || align.ToLower() == "center")
            {
                opcion = " align=" + align.ToString();
            }

            this.openTag = "<p" + opcion + ">";
        }
    }
}
