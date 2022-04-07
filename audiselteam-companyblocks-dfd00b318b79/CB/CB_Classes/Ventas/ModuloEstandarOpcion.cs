using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ModuloEstandarOpcion : ModeloMySql
    {
        public ModuloEstandarOpcion()
        {
            Tabla = "modulo_estandar_opciones";
        }

        static public ModuloEstandarOpcion Modelo()
        {
            return new ModuloEstandarOpcion();
        }

        public List<Fila> SeleccionarOpcionesDeCaracteristica(string caracteristica)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE caracteristica=@caracteristica;";
            ConstruirQuery(query);
            AgregarParametro("@caracteristica", caracteristica);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
