using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class HtmlImagen : HtmlEntity
    {
        protected string Src = string.Empty;
        protected string Align = string.Empty;
        protected int Width = 0;
        protected int Height = 0;

        public HtmlImagen(string src, string align, int width, int height)
        {
            string opcion = string.Empty;
            Src = src;
            Align = align;
            Width = width;
            Height = height;

            opcion = "src=" + Src;

            if (align.ToLower() == "right" || align.ToLower() == "left" || align.ToLower() == "center")
                opcion += " align=" + Align;
            if(Width > 0)
                opcion += " width=" + Width;
            if (Width > 0)
                opcion += " height=" + Height;

            this.openTag = "<img " + opcion +">";
            //this.closeTag = "</img>";
        }
    
    }
}
