using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ModuloPaso : ModeloMySql
    {

        public ModuloPaso()
        {
            Tabla = "modulo_pasos";
        }

        static public ModuloPaso Modelo()
        {
            return new ModuloPaso();
        }

        public List<Fila> SeleccionarModulo(int idModulo)
        {
            string sql = "SELECT modulo_pasos.*, elementos.nombre AS elemento_nombre FROM modulo_pasos INNER JOIN elementos ON elementos.id=modulo_pasos.elemento WHERE modulo_pasos.modulo=@modulo ORDER BY paso ASC";
            ConstruirQuery(sql);
            AgregarParametro("@modulo", idModulo);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
