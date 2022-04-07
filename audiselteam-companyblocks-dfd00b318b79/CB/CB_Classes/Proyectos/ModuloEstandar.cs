using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ModuloEstandar : ModeloMySql
    {
        public ModuloEstandar()
        {
            Tabla = "modulos_estandar";
        }

        public static ModuloEstandar Modelo()
        {
            return new ModuloEstandar();
        }

        public List<Fila> SeleccionarModuloPorId(int id)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE id=@id;";
            ConstruirQuery(query);
            AgregarParametro("@id", id);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}
