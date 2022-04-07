using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class HtmlTableRow : HtmlEntity
    {

        public HtmlTableRow()
        {
            this.openTag = "<tr>";
            this.closeTag = "</tr>";
        }

    }
}
