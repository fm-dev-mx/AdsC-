using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Cotizacion : ModeloMySql
    {

        public Cotizacion()
        {
            Tabla = "cotizaciones";
        }

        static public Cotizacion Modelo()
        {
            return new Cotizacion();
        }

        public List<Fila> Clientes()
        {
            string sql = "SELECT clientes.* FROM cotizaciones INNER JOIN clientes ON cotizaciones.cliente=clientes.id GROUP BY clientes.id";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Vendedores()
        {
            string sql = "SELECT usuarios.* FROM cotizaciones INNER JOIN usuarios ON cotizaciones.usuario_creacion=usuarios.id GROUP BY usuarios.id";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

    }
}
