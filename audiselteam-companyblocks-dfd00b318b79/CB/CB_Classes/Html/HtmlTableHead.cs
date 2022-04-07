using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class HtmlTableHead : HtmlEntity
    {
        protected int colSpan = 0;
        protected string bgColor = string.Empty;
        protected string alignText = string.Empty;

        public HtmlTableHead()
        {
            this.openTag = "<th>";
            this.closeTag = "</th>";
        }
        public int getColSpan()
        {
            return colSpan;
        }

        public void setColSpan(int cs)
        {
            colSpan = cs;

            if (colSpan > 0)
            {
                this.openTag = "<th colspan=" + colSpan.ToString() + ">";
            }
            else this.openTag = "<th>";
        }

        public string getBgColor()
        {
            return bgColor;
        }

        public void setOptions(int cs, string align, string color)
        {
            colSpan = cs;
            alignText = align;
            bgColor = color;

            string opcion = string.Empty;

             if (colSpan > 0)
                opcion = "colspan=" + colSpan.ToString();

             if (alignText == "right" || alignText == "left" || alignText == "center")
             {
                 if (opcion != "")
                     opcion += " ";
                 opcion += "align=" + alignText;
             }

             if (bgColor != "")
            {
                if (opcion != "")
                    opcion += " ";
                opcion += "bgcolor=" + bgColor;
            }

            this.openTag = "<td " + opcion + ">";
        }
    }
}
