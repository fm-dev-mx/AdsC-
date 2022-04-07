using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ArchivoVariante : ModeloMySql
    {
        public ArchivoVariante()
        {
            Tabla = "archivos_variantes";
        }

        static public ArchivoVariante Modelo()
        {
            return new ArchivoVariante();
        }

        public void SeleccionarVariante(int idVariante)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@variante", idVariante);
            SeleccionarDatos("variante=@variante", parametros);
        }
    }
}
