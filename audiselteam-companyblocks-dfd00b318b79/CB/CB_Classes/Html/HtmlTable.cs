using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class HtmlTable : HtmlEntity
    {
        protected int border = 0;

        public HtmlTable()
        {
            this.openTag = "<table>";
            this.closeTag = "</table>";
        }

        public int getBorder()
        {
            return border;
        }

        public void setBorder(int cs)
        {
            border = cs;

            if (border > 0)
            {
                this.openTag = "<table border=" + border.ToString() + ">";
            }
            else this.openTag = "<table>";
        }
    }
}
