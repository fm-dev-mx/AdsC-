using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class RfqMaterial : ModeloMySql
    {

        public RfqMaterial()
        {
            Tabla = "rfq_material";
        }

        public static RfqMaterial Modelo()
        {
            return new RfqMaterial();
        }

        public List<Fila> SeleccionarEstatus(string estatus)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", estatus);
            SeleccionarDatos("estatus=@estatus ORDER BY id DESC", parametros);
            return Filas();
        }

        public List<Fila> Usuarios()
        {
            string sql = "SELECT DISTINCT usuario FROM " + Tabla + " ORDER BY usuario ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> seleccionarUsuarios(string estatus)
        {
            string sql = "SELECT DISTINCT usuario FROM " + Tabla + " WHERE estatus=@estatus ORDER BY usuario ASC";
            ConstruirQuery(sql);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Proveedores()
        {
            string sql = "SELECT DISTINCT proveedores.nombre AS proveedor_nombre FROM rfq_material INNER JOIN proveedores ON rfq_material.proveedor=proveedores.id  ORDER BY proveedores.nombre ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarTodosLosRfqs(string estatus, string proveedor, string usuario)
        {
            string sql = "SELECT rfq_material.*, proveedores.nombre as nombre_proveedor FROM rfq_material " +
                   "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                   "WHERE estatus=@estatus and usuario =@usuario and proveedores.nombre =@proveedor ORDER BY id DESC";

            ConstruirQuery(sql);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@usuario", usuario);
            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> SeleccionarRFQPorUsuarioEstatus(string usuario, string estatus)
        {
            string sql = "select rfq_material.id, rfq_material.usuario, rfq_material.estatus, count(rfq_material.id) as total, proveedores.nombre as nombre_proveedor from rfq_material " +
                         "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                         "WHERE usuario =@usuario AND estatus =@estatus GROUP BY proveedores.nombre order by proveedores.nombre asc;";
            
            ConstruirQuery(sql);
            AgregarParametro("@usuario", usuario);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRFQsParaPo(string proveedor, string tipoMoneda)
        {
            string query =  "select rfq_material.* " +
                            "from material_proyecto " +
                            "INNER JOIN rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto " +
                            "INNER JOIN rfq_material ON rfq_material.id = rfq_conceptos.rfq " +
                            "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                            "where material_proyecto.estatus_compra = 'LISTO PARA ORDENAR' " +
                            "AND rfq_conceptos.moneda = @tipoMoneda " +
                            "AND proveedores.nombre LIKE '%" + proveedor + "%' " +
                            "GROUP BY rfq_material.id";

            ConstruirQuery(query);
            AgregarParametro("@tipoMoneda", tipoMoneda);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarUltimoRfqDeProveedor(int idProveedor)
        {
            string query = "select * from rfq_material where proveedor = @idProveedor and estatus = 'SIN ENVIAR' order by id desc limit 1;";

            ConstruirQuery(query);
            AgregarParametro("@idProveedor", idProveedor);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarUltimoRfqDeProveedor(string nombreProveedor)
        {
            string query = "select * from rfq_material where proveedor = (select id from proveedores where nombre = @nombreProveedor) and estatus = 'SIN ENVIAR' order by id desc limit 1;";

            ConstruirQuery(query);
            AgregarParametro("@nombreProveedor", nombreProveedor);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRfqDeMaterial(int idMaterial)
        {
            string query =
                "select rfq_material.*, rfq_conceptos.moneda, proveedores.nombre as proveedor_nombre from rfq_material " +
                "left join rfq_conceptos on rfq_conceptos.rfq = rfq_material.id " +
                "left join proveedores on rfq_material.proveedor = proveedores.id " +
                "where rfq_conceptos.id in (select rfq_concepto from material_proyecto where id = @idMaterial);";

            ConstruirQuery(query);
            AgregarParametro("@idMaterial", idMaterial);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
