using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class EtapaProyecto : ModeloMySql
    {
        public EtapaProyecto()
        {
            Tabla = "etapas_proyecto";
        }

        static public EtapaProyecto Modelo()
        {
            return new EtapaProyecto();
        }

        public List<Fila> SeleccionarProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            return SeleccionarDatos("proyecto=@proyecto", parametros);
        }


        public List<Fila> FechasProyecto(decimal proyecto, string etapa)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@etapa", etapa);
            return SeleccionarDatos("proyecto=@proyecto AND nombre=@etapa", parametros);
        }
    }
}
