using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CB_Base.Classes
{
    class RequerimientoNota : ModeloMySql
    {

        public RequerimientoNota()
        {
            Tabla = "requerimientos_notas";
        }

        static public RequerimientoNota Modelo()
        {
            return new RequerimientoNota();
        }

        public List<Fila> SeleccionarRequerimiento(int idRequerimiento)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@requerimiento", idRequerimiento);
            return SeleccionarDatos("requerimiento=@requerimiento", parametros);
        }
    }
}
