using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class FactorProcesoFabricacion : ModeloMySql
    {
        public FactorProcesoFabricacion()
        {
            Tabla = "factores_procesos_fabricacion";
        }

        static public FactorProcesoFabricacion Modelo()
        {
            return new FactorProcesoFabricacion();
        }

        public List<Fila> CargarFactores(string proceso)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@proceso";
            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarDiferentesFactores(string proceso)
        {
            string sql = "SELECT DISTINCT(factor), proceso FROM " + Tabla + " WHERE proceso=@proceso";
            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPorFactorProceso(string proceso, string factor)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE proceso=@proceso and factor=@factor";
            ConstruirQuery(sql);
            AgregarParametro("@proceso", proceso);
            AgregarParametro("@factor", factor);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
