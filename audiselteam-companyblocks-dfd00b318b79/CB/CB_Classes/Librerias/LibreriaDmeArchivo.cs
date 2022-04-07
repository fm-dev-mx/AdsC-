using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class LibreriaDmeArchivo : ModeloMySql
    {
        public LibreriaDmeArchivo()
        {
            Tabla = "librerias_dme_archivos";
        }

        static public LibreriaDmeArchivo Modelo()
        {
            return new LibreriaDmeArchivo();
        }

        public List<Fila> SeleccionarArchivosDeLibreria(int idLibreria)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE libreria_dme=@idLibreria";

            ConstruirQuery(query);
            AgregarParametro("@idLibreria", idLibreria);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
