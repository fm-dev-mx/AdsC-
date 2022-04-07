using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes   
{
    class FechaModulo : ModeloMySql
    {
        public FechaModulo()
        {
            Tabla = "fechas_modulo";
        }

        static public FechaModulo Modelo()
        {
            return new FechaModulo();
        }

        public List<Fila> SeleccionarDatos(decimal proyecto, int subensamble, string etapa)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proyecto=@proyecto AND subensamble=@subensamble AND etapa=@etapa";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@subensamble",subensamble);
            AgregarParametro("@etapa", etapa);
            EjecutarQuery();
            return LeerFilas();
        } 
    }
}
