using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CB_Base.Classes
{
    class MetaEficiencia : ModeloMySql
    {
        public MetaEficiencia()
        {
            Tabla = "meta_eficiencia";
        }

        static public MetaEficiencia Modelo()
        {
            return new MetaEficiencia();
        }
    }
}
