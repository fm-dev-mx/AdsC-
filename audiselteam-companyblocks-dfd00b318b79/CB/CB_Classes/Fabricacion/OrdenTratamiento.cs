using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class OrdenTratamiento : ModeloMySql
    {

        public OrdenTratamiento()
        {
            Tabla = "ordenes_tratamiento";
        }

        static public OrdenTratamiento Modelo()
        {
            return new OrdenTratamiento();
        }

        public List<Fila> SeleccionarEstatus(string estatus, int limite = 0, string proveedor = "", string usuario = "")
        {
            string filtro = "";
            string filtroLimite = "";

            if (proveedor != "" && proveedor !="TODOS")
                filtro += " && proveedor=@proveedor";

            if (usuario != "" && usuario != "TODOS")
                filtro += " && usuario=@usuario";

            if (limite > 0)
                filtroLimite = " LIMIT @limite";

            string sql = "SELECT * FROM " + Tabla + " WHERE estatus=@estatus" + filtro + filtroLimite;
            ConstruirQuery(sql);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@usuario", usuario);
            AgregarParametro("@limite", limite);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Proveedores()
        {
            string sql = "SELECT DISTINCT proveedores.nombre AS proveedor_nombre FROM " + Tabla + " INNER JOIN proveedores ON (ordenes_tratamiento.proveedor COLLATE utf8_spanish_ci =proveedores.nombre COLLATE utf8_spanish_ci )  ORDER BY proveedores.nombre ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarOrdenes(int idTratamiento = 0)
        {
            string filtro = "";

            if (idTratamiento > 0)
                filtro += " WHERE id=@id";

            string sql = "SELECT * FROM " + Tabla + filtro;
            ConstruirQuery(sql);
            AgregarParametro("@id", idTratamiento);
            EjecutarQuery();
            return LeerFilas();
        }


        internal void GuardarDatos()
        {
            throw new NotImplementedException();
        }
    }
}
