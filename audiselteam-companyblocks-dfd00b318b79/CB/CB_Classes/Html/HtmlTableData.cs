using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class HtmlTableData : HtmlEntity
    {
        protected int colSpan = 0;
        protected string alignText = string.Empty;
        protected string bgColor = string.Empty;

        public HtmlTableData()
        {
            this.openTag = "<td>";
            this.closeTag = "</td>";
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
                this.openTag = "<td colspan=" + colSpan.ToString() + ">";
            }
            else this.openTag = "<td>";
        }

        public string getAlignText()
        {
            return alignText;
        }

        public void setAlignText(string align)
        {
            alignText = align.ToLower();

            if (alignText == "right" || alignText== "left" || alignText == "center")
            {
                this.openTag = "<td align=" + alignText + ">";
            }
            else this.openTag = "<td>";
        }
        
        public string getBgColor()
        {
            return bgColor;
        }

        public void setBgColor(string color)
        {
            bgColor = color;

            if (bgColor != "")
            {
                this.openTag = "<td bgcolor=" + bgColor + ">";
            }
            else this.openTag = "<td>";
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
