using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Proyecto : ModeloMySql
    {      
        public Proyecto()
        {
            Tabla = "proyectos";
        }

        public static Proyecto Modelo()
        {
            return new Proyecto();
        }

        public List<Fila> CargarDatos(Decimal id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@id", id);
            return SeleccionarDatos("id=@id", parametros);
        }

        public List<Fila> Subproyectos(Decimal id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id", id);
            return SeleccionarDatos("id!=@id AND principal=@id", parametros);
        }


        public List<Fila> Principales(string filtro="", bool mostrarInactivos=false)
        {
            string sql = "";

            if (!filtro.Equals(""))
            {
                filtro = "%" + filtro + "%";
                sql = "SELECT proyectos.id, proyectos.nombre, proyectos.activo, clientes.nombre as cliente, clientes_contactos.nombre as contacto_nombre, clientes_contactos.apellidos as contacto_apellidos FROM proyectos INNER JOIN clientes ON proyectos.cliente=clientes.id INNER JOIN clientes_contactos ON proyectos.contacto=clientes_contactos.id WHERE proyectos.id LIKE @filtro OR proyectos.nombre LIKE @filtro GROUP BY principal and proyectos.id != 0 order by proyectos.id asc";
            }
            else
                sql = "SELECT proyectos.id, proyectos.nombre, proyectos.activo, clientes.nombre as cliente, clientes_contactos.nombre as contacto_nombre, clientes_contactos.apellidos as contacto_apellidos FROM proyectos INNER JOIN clientes ON proyectos.cliente=clientes.id INNER JOIN clientes_contactos ON proyectos.contacto=clientes_contactos.id where proyectos.id != 0 GROUP BY principal order by proyectos.id asc"; 
            
            ConstruirQuery(sql);
            AgregarParametro("@filtro", filtro);
            EjecutarQuery();
            return LeerFilas();
        }       

        public List<Fila> SeleccionarCostosGeneral(decimal proyecto, string tipoCompra, string categoria, int modulo, string moneda)
        {
            string query = string.Empty;

            if (tipoCompra == "TODOS")
            {
                query = "CALL CostoComprasProyecto(@proyecto, @moneda)";
            }
            else
            {
                if (categoria == "TODOS")
                {
                    query = "CALL CostoComprasPorTipo(@proyecto, @tipoCompra, @moneda)";                    
                }
                else
                {
                    if (modulo == -1)
                    {
                        query = "CALL CostoComprasPorCategoria(@proyecto, @tipoCompra, @categoria, @moneda)";
                    }
                    else if (modulo == -2)
                    {
                        query = "CALL CostoComprasPorCategoriaModuloNull(@proyecto, @tipoCompra, @categoria, @moneda)";
                    }
                    else
                    {
                        query = "CALL CostoComprasPorCategoriaModulo(@proyecto, @tipoCompra, @categoria, @modulo, @moneda)";
                    }
                }
            }


            ConstruirQuery(query);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@tipoCompra", tipoCompra);
            AgregarParametro("@categoria", categoria);
            AgregarParametro("@moneda", moneda);
            AgregarParametro("@modulo", modulo);
            EjecutarQuery();

            return LeerFilas();
        }
    
        public bool ActivarDesactivarProyecto(decimal id, string estatus)
        {
            if (estatus == "TERMINADO")
            {
                string sql = "select * from " + Tabla + " where id=@id";
                ConstruirQuery(sql);
                AgregarParametro("@id", id);
                EjecutarQuery();

                LeerFilas();

                if (TieneFilas())
                {
                    Fila().ModificarCelda("activo", 1);
                }
                GuardarDatos();
                return true;
            }
            else
            {
                string sql = "select * from " + Tabla + " where id=@id";
                ConstruirQuery(sql);
                AgregarParametro("@id", id);
                EjecutarQuery();

                LeerFilas();

                if (TieneFilas())
                {
                    Fila().ModificarCelda("activo", 0);
                }
                GuardarDatos();
                return true;
            }
        }

        public List<Fila> ProyectosEnRevisionFinanciera(string estatusFinanciero)
        {
            string query = string.Empty;
            query += "select distinct material_proyecto.proyecto,proyectos.nombre ";
            query += "from material_proyecto ";
            query += "INNER JOIN proyectos on proyectos.id = material_proyecto.proyecto ";
            query += "where estatus_financiero = @estatusFinanciero ";

            if (estatusFinanciero == "PENDIENTE")
                query += "AND estatus_compra = 'EN REVISION FINANCIERA' ";
            else if (estatusFinanciero == "DETENIDO")
                query += "AND estatus_compra = 'COMPRA DETENIDA'";
            
            query += "order by material_proyecto.proyecto asc;";

            ConstruirQuery(query);
            AgregarParametro("@estatusFinanciero", estatusFinanciero);
            EjecutarQuery();
            return LeerFilas();

        }

        public List<Fila> ProyectosEnMaterial(string proyecto, string estatusFinanciero, string proveedor, DateTime desde, DateTime hasta)
        {
            string query = "";
            query += "DROP TEMPORARY TABLE IF EXISTS material_finanzas;";
            query += "CREATE TEMPORARY TABLE material_finanzas ";
            query += "select ";
            query += "material_proyecto.id, ";
            query += "material_proyecto.proyecto, ";
            query += "proyectos.nombre as nombre_proyecto, ";
	        query += "proveedores.nombre as proveedor_nombre, ";
            query += "material_proyecto.requisitor, ";
            query += "material_proyecto.tipo_venta, ";
            query += "material_proyecto.piezas_paquete, ";
            query += "material_proyecto.total, ";
            query += "material_proyecto.estatus_financiero, ";
	        query += "material_proyecto.fecha_promesa_compras,  ";
            query += "material_proyecto.numero_parte, ";
            query += "material_proyecto.categoria, ";
	        query += "rfq_conceptos.tiempo_entrega, ";
            query += "rfq_conceptos.precio_unitario, ";
            query += "rfq_conceptos.moneda, ";
            query += "material_proyecto.fecha_creacion,  ";
            query += "if(	DATE(material_proyecto.fecha_promesa_compras) IS NULL, ";
	        query += "		date_add(DATE(material_proyecto.fecha_creacion), interval 5 day), ";
            query += "        if(rfq_conceptos.tiempo_entrega IS NULL, ";
	        query += "			date_sub(DATE(material_proyecto.fecha_promesa_compras), interval 3 day), ";
	        query += "			date_sub(DATE(material_proyecto.fecha_promesa_compras), interval rfq_conceptos.tiempo_entrega day) ";
            query += "          ) ";
            query += "   ) as fecha_limite ";
            query += "from proyectos ";
            query += "INNER JOIN ";
	        query += "    material_proyecto ON material_proyecto.proyecto = proyectos.id ";
            query += "INNER JOIN ";
	        query += "    rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto ";
            query += "INNER JOIN ";
	        query += "    rfq_material ON rfq_material.id = rfq_conceptos.rfq ";
            query += "INNER JOIN ";
            query += "    proveedores ON proveedores.id = rfq_material.proveedor ";
            query += "WHERE ";

            if (proyecto != "TODOS" && proyecto != "")
                query += "material_proyecto.proyecto=@proyecto ";
            else
                query += "material_proyecto.proyecto IS NOT NULL ";

            if(estatusFinanciero != "TODOS")
                query += "AND material_proyecto.estatus_financiero = @estatusFinanciero ";
            else
                query += "AND material_proyecto.estatus_financiero IS NOT NULL ";

            if(proveedor != "TODOS" && proveedor != "")
                query += "AND proveedores.nombre = @proveedores ";
            else
                query += "AND proveedores.nombre IS NOT NULL ";

            if (estatusFinanciero == "PENDIENTE")
                query += "AND material_proyecto.estatus_compra = 'EN REVISION FINANCIERA' ";
            else if (estatusFinanciero == "DETENIDO")
                query += "AND material_proyecto.estatus_compra = 'COMPRA DETENIDA'";

            query += ";SELECT * from material_finanzas WHERE DATE(fecha_limite) BETWEEN DATE(@desde) AND DATE(@hasta) ORDER BY fecha_limite desc";

            ConstruirQuery(query);
            AgregarParametro("@proyecto", proyecto.Split(' ')[0].Trim());
            AgregarParametro("@estatusFinanciero", estatusFinanciero);
            AgregarParametro("@proveedores", proveedor);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ProyectosEnMaterialAutorizadoCancelado(string proyecto, string estatusFinanciero, string proveedor, DateTime desde, DateTime hasta, int limit)
        {
            string query = "";
            query += "DROP TEMPORARY TABLE IF EXISTS material_finanzas;";
            query += "CREATE TEMPORARY TABLE material_finanzas ";
            query += "select ";
            query += "material_proyecto.id, ";
            query += "material_proyecto.proyecto, ";
            query += "proyectos.nombre as nombre_proyecto, ";
            query += "proveedores.nombre as proveedor_nombre, ";
            query += "material_proyecto.requisitor, ";
            query += "material_proyecto.tipo_venta, ";
            query += "material_proyecto.piezas_paquete, ";
            query += "material_proyecto.total, ";
            query += "material_proyecto.estatus_financiero, ";
            query += "material_proyecto.fecha_promesa_compras,  ";
            query += "material_proyecto.numero_parte, ";
            query += "material_proyecto.categoria, ";
            query += "rfq_conceptos.tiempo_entrega, ";
            query += "rfq_conceptos.precio_unitario, ";
            query += "rfq_conceptos.moneda, ";
            query += "material_proyecto.fecha_creacion  ";
            query += "from proyectos ";
            query += "INNER JOIN ";
            query += "    material_proyecto ON material_proyecto.proyecto = proyectos.id ";
            query += "INNER JOIN ";
            query += "    rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto ";
            query += "INNER JOIN ";
            query += "    rfq_material ON rfq_material.id = rfq_conceptos.rfq ";
            query += "INNER JOIN ";
            query += "    proveedores ON proveedores.id = rfq_material.proveedor ";
            query += "WHERE ";

            if (proyecto != "TODOS" && proyecto != "")
                query += "material_proyecto.proyecto=@proyecto ";
            else
                query += "material_proyecto.proyecto IS NOT NULL ";

            if (estatusFinanciero != "TODOS")
                query += "AND material_proyecto.estatus_financiero = @estatusFinanciero ";
            else
                query += "AND material_proyecto.estatus_financiero IS NOT NULL ";

            if (proveedor != "TODOS" && proveedor != "")
                query += "AND proveedores.nombre = @proveedores ";
            else
                query += "AND proveedores.nombre IS NOT NULL ";

            if (estatusFinanciero == "PENDIENTE")
                query += "AND material_proyecto.estatus_compra = 'EN REVISION FINANCIERA' ";
            else if (estatusFinanciero == "DETENIDO")
                query += "AND material_proyecto.estatus_compra = 'COMPRA DETENIDA'";

            query += ";SELECT *, fecha_creacion as fecha_limite from material_finanzas WHERE DATE(fecha_creacion) BETWEEN DATE(@desde) AND DATE(@hasta) ORDER BY fecha_creacion desc limit @limit";

            ConstruirQuery(query);
            AgregarParametro("@proyecto", proyecto.Split(' ')[0].Trim());
            AgregarParametro("@estatusFinanciero", estatusFinanciero);
            AgregarParametro("@proveedores", proveedor);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);
            AgregarParametro("@limit", limit);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
