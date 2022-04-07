using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class HtmlDoc : HtmlEntity
    {

        public HtmlDoc()
        {
            this.openTag = "<html>";
            this.closeTag = "</html>";
        }

    }
}
