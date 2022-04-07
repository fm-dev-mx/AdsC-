using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class InstrumentosMedicion  : ModeloMySql
    {
        public InstrumentosMedicion()
        {
            Tabla = "instrumentos_mediciones";
        }

        static public InstrumentosMedicion Modelo()
        {
            return new InstrumentosMedicion();
        }

        public List<Fila> SeleccionarInstrumentos()
        {
            string sql = "SELECT distinct tipo_instrumento FROM " + Tabla + " order by tipo_instrumento asc";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarInstrumentos(string estatus, string instrumento)
        {
            string condicion = string.Empty;

            if (instrumento != "TODOS")
            {
                condicion += "tipo_instrumento=@instrumento";
            }

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@instrumento", instrumento);
            return SeleccionarDatos(condicion, parametros);
        }
    }
}
