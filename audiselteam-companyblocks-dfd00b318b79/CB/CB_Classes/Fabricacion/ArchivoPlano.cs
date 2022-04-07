using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class ArchivoPlano : ModeloMySql
    {

        public ArchivoPlano()
        {
            Tabla = "archivos_planos";
        }

        static public ArchivoPlano Modelo()
        {
            return new ArchivoPlano();
        }

        public void SeleccionarDePlano(int idPlano)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@plano", idPlano);
            SeleccionarDatos("plano=@plano", parametros);
        }
    }
}
