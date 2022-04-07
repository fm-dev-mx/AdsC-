using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class RfqConcepto : ModeloMySql
    {

        public RfqConcepto()
        {
            Tabla = "rfq_conceptos";
        }

        static public RfqConcepto Modelo()
        {
            return new RfqConcepto();
        }

        public List<Fila> SeleccionarRfq(int IdRfq)
        {
            string sql = "SELECT rfq_conceptos.*, SUM(rfq_conceptos.cantidad_estimada) as total_estimada, (SELECT COUNT(*) FROM material_proyecto WHERE " +
                "material_proyecto.numero_parte=rfq_conceptos.numero_parte AND material_proyecto.estatus_seleccion='DEFINIDO' AND " +
                "material_proyecto.estatus_autorizacion='AUTORIZADO' AND material_proyecto.po=0) AS requisiciones_compra FROM rfq_conceptos WHERE " +
                "rfq=@rfq group by numero_parte, tipo_venta ORDER BY id ASC";
            ConstruirQuery(sql);
            AgregarParametro("@rfq", IdRfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRfqAgruparPorNumeroParte(int IdRfq)
        {
            string sql = "SELECT rfq_conceptos.*, SUM(cantidad_estimada) as cantidad_total, (SELECT COUNT(*) FROM material_proyecto " +
                "WHERE material_proyecto.numero_parte=rfq_conceptos.numero_parte AND material_proyecto.estatus_seleccion='DEFINIDO' " +
                "AND material_proyecto.estatus_autorizacion='AUTORIZADO' AND material_proyecto.po=0) AS requisiciones_compra FROM rfq_conceptos " +
                "WHERE rfq=@rfq GROUP BY numero_parte ORDER BY id ASC";
            ConstruirQuery(sql);
            AgregarParametro("@rfq", IdRfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarCostosRfqPorNumeroParte(int IdRfq)
        {
            string sql = "SELECT numero_parte, SUM(precio_unitario) as costo_total, moneda FROM rfq_conceptos " +
                "WHERE rfq = @rfq GROUP BY numero_parte, moneda ORDER BY numero_parte ASC";
            ConstruirQuery(sql);
            AgregarParametro("@rfq", IdRfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarCostosRfqPorProyecto(int IdRfq)
        {
            string sql = "SELECT material_proyecto.proyecto, sum(rfq_conceptos.precio_unitario) as costo_total, rfq_conceptos.moneda, proyectos.nombre " +
                "FROM relaciones_material_rfq, material_proyecto, rfq_conceptos, proyectos " +
                "WHERE relaciones_material_rfq.id_rfq = @rfq " +
                "AND material_proyecto.id = relaciones_material_rfq.id_material_proyecto " +
                "AND material_proyecto.rfq_concepto = rfq_conceptos.id " +
                "AND material_proyecto.proyecto = proyectos.id " +
                "GROUP BY material_proyecto.proyecto, rfq_conceptos.moneda " +
                "ORDER BY material_proyecto.proyecto";
            ConstruirQuery(sql);
            AgregarParametro("@rfq", IdRfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public bool ExisteEnRfq(int IdRfq, string NumeroParte)
        {
            string sql = "SELECT COUNT(*) FROM " + Tabla + " WHERE rfq=@rfq AND numero_parte=@numero_parte";
            ConstruirQuery(sql);
            AgregarParametro("@rfq", IdRfq);
            AgregarParametro("@numero_parte", NumeroParte);
            EjecutarQuery();
            LeerFilas();
            if( TieneFilas() )
            {
                return Convert.ToInt32(Fila().Celda("COUNT(*)")) > 0;
            }
            return false;
        }
           
        public List<Fila> SeleccionarNumeroDeParte(string numero_parte)
        {
            string sql = "SELECT rfq_conceptos.*, proveedores.nombre AS nombre_proveedor, rfq_material.estatus FROM audisel.rfq_conceptos INNER JOIN rfq_material ON rfq_conceptos.rfq=rfq_material.id INNER JOIN proveedores ON rfq_material.proveedor=proveedores.id WHERE numero_parte=@numero_parte AND rfq_material.vigente=1 ORDER BY rfq_material.fecha_creacion DESC";
            ConstruirQuery(sql);
            AgregarParametro("@numero_parte", numero_parte);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CotizacionesVigentes(int idProveedor, string numero_parte="")
        {
            string sql = "";
            if(numero_parte == "")
                sql = "SELECT rfq_conceptos.* FROM rfq_conceptos INNER JOIN rfq_material ON rfq_material.id=rfq_conceptos.rfq AND rfq_conceptos.tiempo_entrega>0 AND rfq_material.proveedor=@proveedor ORDER BY rfq_conceptos.id DESC";
            else
                sql = "SELECT rfq_conceptos.* FROM rfq_conceptos INNER JOIN rfq_material ON rfq_material.id=rfq_conceptos.rfq AND rfq_conceptos.tiempo_entrega>0 AND rfq_material.proveedor=@proveedor AND rfq_conceptos.numero_parte=@numero_parte ORDER BY rfq_conceptos.id DESC";
            ConstruirQuery(sql);
            AgregarParametro("@proveedor", idProveedor);
            AgregarParametro("@numero_parte", numero_parte);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> DesglosarPorProyecto(int idConcepto)
        {
            RfqConcepto concepto = new RfqConcepto();
            concepto.CargarDatos(idConcepto);
            string numero_parte = concepto.Fila().Celda("numero_parte").ToString();

            string sql = "SELECT material_proyecto.* FROM material_proyecto WHERE numero_parte=@numero_parte AND po=0";
            ConstruirQuery(sql);
            AgregarParametro("@numero_parte", numero_parte);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarUltimoRfqYConceptoParaPieza(string numeroParte, string proveedor = null)
        {
            string query = "DROP TEMPORARY TABLE IF EXISTS TempConceptos; " +
                           "CREATE TEMPORARY TABLE TempConceptos " +
                           "select rfq_conceptos.id, material_proyecto.fabricante, rfq_material.id as rfq, rfq_conceptos.numero_parte, rfq_conceptos.precio_unitario, rfq_conceptos.cantidad_disponible, proveedores.nombre as nombre_proveedor, rfq_conceptos.moneda, rfq_conceptos.tiempo_entrega, rfq_conceptos.fecha_cotizacion " +
                           "from rfq_material " +
                           "INNER JOIN rfq_conceptos ON rfq_conceptos.rfq = rfq_material.id " +
                           "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                           "INNER JOIN material_proyecto ON material_proyecto.numero_parte = rfq_conceptos.numero_parte " +
                           "WHERE rfq_material.vigente = 1 " +
                           "AND material_proyecto.estatus_seleccion = 'DEFINIDO' " +
                           "and material_proyecto.numero_parte = @numeroParte " +
                           "and rfq_conceptos.precio_unitario > 0 ";


            if (proveedor != null)
                query += "and proveedores.nombre = @proveedor ";
                            
            query += "order by rfq_material.id desc;" +
                     "SELECT * FROM (SELECT id as concepto, numero_parte, fabricante, precio_unitario, nombre_proveedor, rfq, cantidad_disponible, moneda, tiempo_entrega, fecha_cotizacion FROM TempConceptos group by nombre_proveedor, numero_parte) as prefiltro WHERE precio_unitario > 0;";

            ConstruirQuery(query);
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@numeroParte", numeroParte);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProveedoresCotizados(string numeroParte)
        {
            string query = string.Empty;

            query += "SELECT DISTINCT proveedores.id AS id_proveedor, proveedores.nombre AS nombre_proveedor FROM rfq_conceptos ";
            query += "INNER JOIN rfq_material ON rfq_conceptos.rfq=rfq_material.id ";
            query += "INNER JOIN proveedores ON rfq_material.proveedor=proveedores.id ";
            query += "WHERE rfq_conceptos.numero_parte=@numeroParte ";

            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            EjecutarQuery();
            return LeerFilas();
        }


        public List<Fila> UltimasCotizaciones(string numeroParte, int diasAntiguedad=90)
        {
            List<Fila> proveedoresCotizados = SeleccionarProveedoresCotizados(numeroParte);
            List<Fila> ultimasCotizaciones = new List<Fila>();

            proveedoresCotizados.ForEach(delegate(Fila proveedor)
            {
                string query = string.Empty;
                query += "SELECT rfq_conceptos.*, proveedores.nombre AS nombre_proveedor FROM rfq_conceptos ";
                query += "INNER JOIN rfq_material ON rfq_conceptos.rfq=rfq_material.id ";
                query += "INNER JOIN proveedores ON rfq_material.proveedor=proveedores.id ";
                query += "WHERE rfq_conceptos.numero_parte=@numeroParte AND proveedores.id=@proveedor ";
                //query += "rfq_material.fecha_creacion >= DATE_SUB(NOW(), INTERVAL @diasAntiguedad DAY) ";
                query += "ORDER BY rfq_conceptos.id DESC ";
                query += "LIMIT 1";

                RfqConcepto buscador = new RfqConcepto();
                buscador.ConstruirQuery(query);
                buscador.AgregarParametro("@proveedor", proveedor.Celda("id_proveedor"));
                buscador.AgregarParametro("@numeroParte", numeroParte);
                buscador.AgregarParametro("@diasAntiguedad", diasAntiguedad);
                buscador.EjecutarQuery();
                buscador.LeerFilas();
                ultimasCotizaciones.Add(buscador.Fila());
            });
            return ultimasCotizaciones;


            //string query = string.Empty;

            //query += "SELECT rfq_conceptos.*, proveedores.nombre AS nombre_proveedor FROM rfq_conceptos ";
            //query += "INNER JOIN rfq_material ON rfq_conceptos.rfq=rfq_material.id ";
            //query += "INNER JOIN proveedores ON rfq_material.proveedor=proveedores.id ";
            //query += "WHERE rfq_conceptos.numero_parte=@numeroParte ";
            //query += "GROUP BY rfq_material.proveedor ";
            //query += "ORDER BY rfq_conceptos.id DESC ";
            //query += "LIMIT 1";


            ////string query = "DROP TEMPORARY TABLE IF EXISTS TempConceptos; " +
            ////               "CREATE TEMPORARY TABLE TempConceptos " +
            ////               "select rfq_conceptos.id, material_proyecto.fabricante, rfq_material.id as rfq, rfq_conceptos.numero_parte, rfq_conceptos.precio_unitario, rfq_conceptos.cantidad_disponible, proveedores.nombre as nombre_proveedor, rfq_conceptos.moneda, rfq_conceptos.tiempo_entrega, rfq_conceptos.fecha_cotizacion " +
            ////               "from rfq_material " +
            ////               "INNER JOIN rfq_conceptos ON rfq_conceptos.rfq = rfq_material.id " +
            ////               "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
            ////               "INNER JOIN material_proyecto ON material_proyecto.numero_parte = rfq_conceptos.numero_parte " +
            ////               "WHERE rfq_material.vigente = 1 " +
            ////               "AND material_proyecto.estatus_seleccion = 'DEFINIDO' " +
            ////               "and material_proyecto.numero_parte = @numeroParte " +
            ////               "order by rfq_material.id desc;";

            ////query += "DROP TEMPORARY TABLE IF EXISTS TempConceptosAgrupados;" +
            ////         "CREATE TEMPORARY TABLE TempConceptosAgrupados " +
            ////         "SELECT * FROM (SELECT id as concepto, numero_parte, fabricante, precio_unitario, nombre_proveedor, rfq, cantidad_disponible, moneda, tiempo_entrega, fecha_cotizacion " +
            ////         "FROM TempConceptos group by nombre_proveedor, numero_parte) as prefiltro WHERE precio_unitario > 0;";

            ////query += "(select * from TempConceptosAgrupados) " +
            ////         "union " +
            ////         "(SELECT id as concepto, numero_parte, fabricante, precio_unitario, nombre_proveedor, rfq, cantidad_disponible, moneda, tiempo_entrega, fecha_cotizacion " +
            ////         "FROM TempConceptos WHERE id = (select rfq_concepto from material_proyecto where id = @idRequisicion) group by id);";


            //ConstruirQuery(query);
            //AgregarParametro("@idRequisicion", idRequisicion);
            //AgregarParametro("@numeroParte", numeroParte);
            //EjecutarQuery();
            //return LeerFilas();
        }

        public List<Fila> SeleccionarUltimoRfqYConceptoParaPiezas(List<string> numeroParte, string proveedor = null)
        {

            if (numeroParte.Count == 0)
                return new List<Fila>();

            string partes = "(";
            foreach(string parte in numeroParte)
            {
                partes += "'" + parte + "',";
            }

            partes = partes.Remove(partes.Length - 1);
            partes += ")";

            string query = "DROP TEMPORARY TABLE IF EXISTS TempConceptos; " +
                           "CREATE TEMPORARY TABLE TempConceptos " +
                           "select rfq_conceptos.id, material_proyecto.fabricante, rfq_material.id as rfq, rfq_conceptos.numero_parte, rfq_conceptos.precio_unitario, rfq_conceptos.cantidad_disponible, proveedores.nombre as nombre_proveedor, rfq_conceptos.moneda, rfq_conceptos.tiempo_entrega, rfq_conceptos.fecha_cotizacion " +
                           "from rfq_material " +
                           "INNER JOIN rfq_conceptos ON rfq_conceptos.rfq = rfq_material.id " +
                           "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                           "INNER JOIN material_proyecto ON material_proyecto.numero_parte = rfq_conceptos.numero_parte " +
                           "WHERE rfq_material.vigente = 1 " +
                           "AND material_proyecto.estatus_seleccion = 'DEFINIDO' " +
                           "and material_proyecto.numero_parte in " + partes + " ";

            if (proveedor != null)
                query += "and proveedores.nombre = @proveedor ";

            query += "order by rfq_material.id desc;" +
                     "SELECT * FROM (SELECT id as concepto, numero_parte, fabricante, precio_unitario, nombre_proveedor, rfq, cantidad_disponible, moneda, tiempo_entrega, fecha_cotizacion FROM TempConceptos group by nombre_proveedor, numero_parte) as prefiltro WHERE precio_unitario > 0;";

            ConstruirQuery(query);
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@numeroParte", numeroParte);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialesDeRFQ(int IdRfq, string NumeroParte)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE rfq=@rfq AND numero_parte=@numero_parte";
            ConstruirQuery(sql);
            AgregarParametro("@rfq", IdRfq);
            AgregarParametro("@numero_parte", NumeroParte);
            EjecutarQuery();
            return LeerFilas();                       
        }

        public List<Fila> SeleccionarPartidasRfq(int idRfq)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE rfq =@idRfq";

            ConstruirQuery(query);
            AgregarParametro("@idRfq", idRfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRequisitorDeRfq(string numeroParte, int rfqConcepto)
        {
            string query = "SELECT rfq_material.usuario from rfq_material " +
                           "INNER JOIN rfq_conceptos ON rfq_conceptos.rfq = rfq_material.id " +
                           "INNER JOIN material_proyecto ON material_proyecto.numero_parte = rfq_conceptos.numero_parte " +
                           "WHERE rfq_conceptos.numero_parte =@numeroParte " +
                           "AND rfq_material.estatus = 'ENVIADO' " +
                           "AND rfq_material.proveedor = (select proveedor from rfq_material where id = (SELECT rfq FROM rfq_conceptos where id =@rfqConcepto)) " +
                           "group by rfq_material.id;";

            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@rfqConcepto", rfqConcepto);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarPartidaRfq(string numeroParte, int idRfq)
        {
            string query = "SET SQL_SAFE_UPDATES=0; ";
            query += "DELETE FROM " + Tabla + " WHERE numero_parte=@numeroParte and rfq=@idRfq; ";
            query += "SET SQL_SAFE_UPDATES=1;";
            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@idRfq", idRfq);
            EjecutarQuery();
        }
        /*
        /// <summary>
        /// Devuelve una lista de los conceptos rfq que representen las últimas cotizaciones para un número parte dentro de un determinado ese proveedor.
        /// </summary>
        /// <returns></returns>
        public List<Fila> ObtenerUltimosConceptosDeUnProveedorDentroDeRfq(int idRfq)
        {
        } */

        public List<Fila> SeleccionarRfqConceptoDeRfq(int idRfq)
        {
            string query = "SELECT * ";
            query += "FROM rfq_conceptos ";          
            query += "WHERE rfq = @idRfq ";
            query += "AND rfq_conceptos.precio_unitario >0 ";
            query += "group by rfq_conceptos.numero_parte;";

            ConstruirQuery(query);
            AgregarParametro("@idRfq", idRfq);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
