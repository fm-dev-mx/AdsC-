using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlanoCotizacion : ModeloMySql
    {
        public PlanoCotizacion()
        {
            Tabla = "planos_cotizaciones";
        }

        static public PlanoCotizacion Modelo()
        {
            return new PlanoCotizacion();
        }

        public List<Fila> TodasDePlano(int idPlano)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);
            SeleccionarDatos("plano=@plano", parametros);
            return Filas();
        }

        public Fila SeleccionarPlanoProveedor(int idPlano, int idProveedor)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);
            parametros.Add("@proveedor", idProveedor);
            SeleccionarDatos("plano=@plano AND proveedor=@proveedor", parametros);
            return Fila();
        }
    }
}
