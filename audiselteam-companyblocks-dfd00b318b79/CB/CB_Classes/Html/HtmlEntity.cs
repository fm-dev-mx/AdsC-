using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class HtmlEntity
    {
        protected string openTag = "";
        protected string closeTag= "";

        public List<HtmlEntity> elements = new List<HtmlEntity>();
        public string content = "";


        public override string ToString()
        {
 	        string entity = "";
            entity = openTag + Environment.NewLine;

            if(!content.Equals("")) 
            {
                entity += content + Environment.NewLine;
            }

            foreach(HtmlEntity el in elements)
            {
                entity += el.ToString() + Environment.NewLine;
            }
            entity += closeTag;
            return entity;
        }

        public HtmlEntity addElement(HtmlEntity element)
        {
            this.elements.Add(element);
            return element;
        }
        public HtmlEntity insertElement(HtmlEntity element, int index)
        {
            this.elements.Insert(index, element);
            return element;
        }
 

    }
}
