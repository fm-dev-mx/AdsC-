using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Fabricante : ModeloMySql
    {
        public Fabricante()
        {
            Tabla = "fabricantes";
        }

        static public Fabricante Modelo()
        {
            return new Fabricante();
        }

        public List<Fila> SeleccionarFabricanteAlfabeticamente()
        {
            string query = "SELECT * FROM " + Tabla + " ORDER BY nombre DESC";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }
    
    }
}
