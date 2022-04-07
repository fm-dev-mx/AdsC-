using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaquinaHerramientaProceso : ModeloMySql
    {
        public MaquinaHerramientaProceso()
        {
            Tabla = "maquinas_herramientas_procesos";
        }

        static public MaquinaHerramientaProceso Modelo()
        {
            return new MaquinaHerramientaProceso();
        }

        public List<Fila> TodasDeProceso(string proceso)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@proceso", proceso);
            return SeleccionarDatos("proceso_fabricacion=@proceso", parametros);
        }

        
    }
}
