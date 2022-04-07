using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class DimensionCritica : ModeloMySql
    {

        public DimensionCritica()
        {
            Tabla = "dimensiones_criticas";
        }

        public static DimensionCritica Modelo()
        {
            return new DimensionCritica();
        }

        public List<Fila> SeleccionarPlano(int plano)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", plano);
            return SeleccionarDatos("plano=@plano", parametros);
        }

    }
}
