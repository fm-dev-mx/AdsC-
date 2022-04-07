using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PoliticaCalidad : ModeloMySql
    {
        public PoliticaCalidad()
        {
            Tabla = "politica_calidad";
        }

        static public PoliticaCalidad Modelo()
        {
            return new PoliticaCalidad();
        }

        public List<Fila> SeleccionarPolitica(string politica)
        {
            string sql = "SELECT * FROM " + Tabla + " where politica=@politica";
            ConstruirQuery(sql);
            AgregarParametro("@politica", politica);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ObtenerId(string politica, int revision)
        {
            string sql = "SELECT * FROM " + Tabla + " where politica=@politica && revision=@revision";
            ConstruirQuery(sql);
            AgregarParametro("@politica", politica);
            AgregarParametro("@revision", revision);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BorrarPolitica(int id)
        {
            string sql = "DELETE FROM " + Tabla + " where id=@id";
            ConstruirQuery(sql);
            AgregarParametro("@id", id);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
