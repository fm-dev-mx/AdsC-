using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Auditoria5s : ModeloMySql
    {
        public Auditoria5s()
        {
            Tabla = "auditoria_5s";
        }

        static public Auditoria5s Modelo()
        {
            return new Auditoria5s();
        }

        public List<Fila> SeleccionarAreas()
        {
            string sql = "SELECT distinct area FROM " + Tabla + " order by area asc";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarAuditoria(int usuario)
        {
            string condition = string.Empty;

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", usuario);
            return SeleccionarDatos("usuario_responsable=@usuario and avance!='TERMINADO'", parametros);
        }
    }
}
