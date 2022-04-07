using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class PoMaterial : ModeloMySql
    {

        public PoMaterial()
        {
            Tabla = "po_material";
        }

        static public PoMaterial Modelo()
        {
            return new PoMaterial();
        }

        public List<Fila> SeleccionarEstatus(string estatus, string usuario, string proveedor, DateTime fechaCreacion)
        {
            string sql = "SELECT po_material.*, proveedores.nombre AS nombre_proveedor FROM po_material ";
            sql += " INNER JOIN proveedores ON po_material.proveedor=proveedores.id ";
            sql += " WHERE estatus = @estatus AND usuario=@usuario AND proveedores.nombre =@proveedor AND DATE(po_material.fecha_creacion)=DATE(@fechaCreacion) ORDER BY id DESC";

            ConstruirQuery(sql);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@usuario", usuario);
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@fechaCreacion", fechaCreacion);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Conceptos(int po, bool mostrarNombreProveedor = false, bool seleccionarPoCanceladas = false, string formato = "MEXICO")
        {
            PoMaterial pomat = new PoMaterial();
            pomat.CargarDatos(po);

            List<Fila> Conceptos = new List<Fila>();
            string sql = string.Empty;

            if(seleccionarPoCanceladas)
            {
               sql = "select material_proyecto.id, material_proyecto.requisitor, material_proyecto.proyecto, material_proyecto.categoria, material_proyecto.numero_parte, material_proyecto.fabricante, " +
                    "material_proyecto.descripcion, po_cancelados.piezas_requeridas, po_cancelados.piezas_requeridas as total, material_proyecto.tipo_venta, material_proyecto.piezas_paquete, po_cancelados.id_po, " +
                    "material_proyecto.estatus_seleccion, material_proyecto.estatus_compra, material_proyecto.comentarios_requisitor, material_proyecto.estatus_autorizacion, material_proyecto.comentarios_autorizacion, " +
                    "material_proyecto.accesorio_para, material_proyecto.usuario_recibido_almacen, material_proyecto.usuario_entrega_ensamble, material_proyecto.usuario_recibido_ensamble, " +
                    "material_proyecto.fecha_recibido_almacen, material_proyecto.fecha_entregado_ensamble, material_proyecto.estatus_almacen, material_proyecto.cantidad_almacen, material_proyecto.usuario_autorizacion, " +
                    "material_proyecto.fecha_autorizacion, po_cancelados.precio_unitario, (po_cancelados.precio_unitario * po_cancelados.piezas_requeridas) as precio_suma_final, " +
                    "po_cancelados.precio_moneda, material_proyecto.facha_ensamblado, material_proyecto.fecha_perdido, material_proyecto.usuario_perdido, material_proyecto.comentarios_ensamble, material_proyecto.comentarios_revision, " +
                    "material_proyecto.estatus_ensamble, material_proyecto.plano, material_proyecto.subensamble, material_proyecto.fecha_creacion, material_proyecto.eta, material_proyecto.fecha_promesa_ensamble, " +
                    "material_proyecto.cantidad_recibida, material_proyecto.cantidad_entregada, material_proyecto.mantenimiento, material_proyecto.calibracion, material_proyecto.fecha_compra, material_proyecto.ahorro_cotizaciones, " +
                    "material_proyecto.fecha_promesa_compras, material_proyecto.meta, material_proyecto.tiempo_entrega," +
                    "sum(total) as suma_total, sum(po_cancelados.piezas_requeridas) as suma_piezas_requeridas " +
                    "from material_proyecto, po_cancelados " +
                    "where po_cancelados.id_material = material_proyecto.id and po_cancelados.id_po = @po " +
                    "group by numero_parte ORDER BY material_proyecto.id ASC";
            }
            else
            {
                sql = "SELECT material_proyecto.*, sum(total) as suma_total, sum(piezas_requeridas) as suma_piezas_requeridas ";
                
                if (mostrarNombreProveedor)
                    sql += ", fabricante as proveedor ";

                sql += "FROM material_proyecto ";
                sql += "WHERE po=@po ";
                sql += "GROUP BY numero_parte ORDER BY id ASC";
            }
            
            ConstruirQuery(sql);
            AgregarParametro("@po", po);
            EjecutarQuery();
            
            LeerFilas().ForEach(delegate(Fila f)
            {
                decimal precio_unitario = 0;
                int cantidad = 0;
                int tiempo_entrega = 0;
                int piezas_paquete = Convert.ToInt32(f.Celda("piezas_paquete"));
                string str_precio_unitario = "?";
                string str_tiempo_entrega = "?";
                string str_suma = "?";
                string str_cantidad = "?";
                cantidad = Convert.ToInt32(f.Celda("suma_total"));

                str_cantidad = MaterialProyecto.Modelo().TextoTotalOrdenar(cantidad, piezas_paquete, f.Celda("tipo_venta").ToString(), formato);

                precio_unitario = Convert.ToDecimal(f.Celda("precio_unitario"));
                tiempo_entrega = Convert.ToInt32(f.Celda("tiempo_entrega"));

                switch (formato)
                {
                    case "MEXICO":
                    case "ESTADOS UNIDOS":
                        str_precio_unitario = String.Format("{0:C}", precio_unitario);
                        str_suma = string.Format("{0:C}", precio_unitario * cantidad);
                        break;
                    case "EUROPA":
                        str_precio_unitario = String.Format("€{0:N2}", precio_unitario);
                        str_suma = string.Format("€{0:N2}", precio_unitario * cantidad);
                        break;

                }
                //str_precio_unitario = String.Format("{0:C}", precio_unitario);
                //str_suma = string.Format("{0:C}", precio_unitario * cantidad);
                str_tiempo_entrega = tiempo_entrega.ToString() + " día(s)";

                Fila filaConPrecios = f;
                filaConPrecios.AgregarCelda("suma", precio_unitario * cantidad);

                filaConPrecios.AgregarCelda("texto_cantidad", str_cantidad);
                filaConPrecios.AgregarCelda("texto_precio_unitario", str_precio_unitario);
                filaConPrecios.AgregarCelda("texto_suma", str_suma);
                filaConPrecios.AgregarCelda("texto_tiempo_entrega", str_tiempo_entrega);

                Conceptos.Add(f);
            });

            return Conceptos;
        }


        public List<Fila> ConceptosRecibidosEntregados(int po, string estatus)
        {
            PoMaterial pomat = new PoMaterial();
            pomat.CargarDatos(po);

            List<Fila> Conceptos = new List<Fila>();
            string sql = string.Empty;

            sql = "SELECT material_proyecto.*, sum(total) as suma_total, sum(piezas_requeridas) as suma_piezas_requeridas ";
            sql += "FROM material_proyecto ";
            sql += "WHERE po=@po ";

            if (estatus != "ENVIADO")
                sql += "and estatus_compra !='RECIBIDO' AND estatus_compra != 'ENTREGADO' ";

            sql += "GROUP BY numero_parte ORDER BY id ASC";

            ConstruirQuery(sql);
            AgregarParametro("@po", po);
            EjecutarQuery();

            LeerFilas().ForEach(delegate(Fila f)
            {
                decimal precio_unitario = 0;
                int cantidad = 0;
                int tiempo_entrega = 0;
                int piezas_paquete = Convert.ToInt32(f.Celda("piezas_paquete"));
                string str_precio_unitario = "?";
                string str_tiempo_entrega = "?";
                string str_suma = "?";
                string str_cantidad = "?";
                cantidad = Convert.ToInt32(f.Celda("suma_total"));

                str_cantidad = MaterialProyecto.Modelo().TextoTotalOrdenar(cantidad, piezas_paquete, f.Celda("tipo_venta").ToString(), "MXN");

                precio_unitario = Convert.ToDecimal(f.Celda("precio_unitario"));
                tiempo_entrega = Convert.ToInt32(f.Celda("tiempo_entrega"));
                str_precio_unitario = String.Format("{0:C}", precio_unitario);
                str_suma = string.Format("{0:C}", precio_unitario * cantidad);
                str_tiempo_entrega = tiempo_entrega.ToString() + " día(s)";

                Fila filaConPrecios = f;
                filaConPrecios.AgregarCelda("suma", precio_unitario * cantidad);

                filaConPrecios.AgregarCelda("texto_cantidad", str_cantidad);
                filaConPrecios.AgregarCelda("texto_precio_unitario", str_precio_unitario);
                filaConPrecios.AgregarCelda("texto_suma", str_suma);
                filaConPrecios.AgregarCelda("texto_tiempo_entrega", str_tiempo_entrega);

                Conceptos.Add(f);
            });

            return Conceptos;
        }



        public List<Fila> DesglosarPartida(string numero_parte, int po)
        {
            string sql = "SELECT * FROM material_proyecto WHERE po=@po AND numero_parte=@numero_parte";
            ConstruirQuery(sql);
            AgregarParametro("@po", po);
            AgregarParametro("@numero_parte", numero_parte);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Usuarios()
        {
            string sql = "SELECT DISTINCT usuario FROM " + Tabla + " ORDER BY usuario ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> UsuariosEstatusPo(string estatus)
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

        public List<Fila> SeleccionarTodasLasPO()
        {
            string sql = "SELECT po_material.*, proveedores.nombre AS nombre_proveedor FROM po_material ";
            sql += " INNER JOIN proveedores ON po_material.proveedor=proveedores.id  ORDER BY id DESC";

            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPo(int idOrdenCompra)
        {
            string sql = "SELECT po_material.*, proveedores.nombre AS nombre_proveedor FROM po_material ";
            sql += " INNER JOIN proveedores ON po_material.proveedor=proveedores.id ORDER BY id DESC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public void CancelarPo (int idPo)
        {
            string sql = "call PoMaterial_CancelarOrden(@idPo)";
            ConstruirQuery(sql);
            AgregarParametro("@idPo", idPo);
            EjecutarQuery();
        }

        public List<Fila> SeleccionarPoPorUsuarioEstatus(string usuario, string estatus, DateTime fecha)
        {
            string sql = "SELECT po_material.*, proveedores.nombre as nombre_proveedor, count(po_material.id) as total FROM po_material " +
                         "INNER JOIN proveedores  ON proveedores.id = po_material.proveedor " +
                         "WHERE usuario =@usuario AND estatus =@estatus AND DATE(po_material.fecha_creacion) =DATE(@fechaCreacion) GROUP BY proveedores.nombre;";

            ConstruirQuery(sql);
            AgregarParametro("@usuario", usuario);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@fechaCreacion", fecha);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPoFechaPorUsuarioPorEstatus(string usuario, string estatus)
        {
            string sql = "SELECT po_material.*, proveedores.nombre as nombre_proveedor, count(po_material.id) as total FROM po_material " +
                         "INNER JOIN proveedores  ON proveedores.id = po_material.proveedor " +
                         "WHERE usuario =@usuario AND estatus =@estatus GROUP BY DATE(po_material.fecha_creacion) order by  DATE(po_material.fecha_creacion) DESC;";

            ConstruirQuery(sql);
            AgregarParametro("@usuario", usuario);
            AgregarParametro("@estatus", estatus);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarUltimaPoDeProveedor(int idProveedor, string moneda)
        {
            string query = "select * from po_material where estatus = 'SIN ENVIAR' and proveedor = @idProveedor and moneda = @moneda order by id desc limit 1;";

            ConstruirQuery(query);
            AgregarParametro("@idProveedor", idProveedor);
            AgregarParametro("@moneda", moneda);

            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> ReporteOrdenesCompra(DateTime fechaInicio, DateTime fechaFin)
        {
            string query = "select po_material.id, po_material.fecha_creacion, po_material.estatus, sum(material_proyecto.total * rfq_conceptos.precio_unitario) as sub_total, po_material.moneda from rfq_conceptos ";
            query += "left join material_proyecto on material_proyecto.rfq_concepto = rfq_conceptos.id ";
            query += "left join po_material on po_material.id = material_proyecto.po ";
            query += "where po_material.estatus in ('ENVIADO', 'RECIBIDO', 'RECIBIDO PARCIALMENTE') AND DATE(po_material.fecha_creacion) >= DATE(@fechaInicio) AND DATE(po_material.fecha_creacion) <= DATE(@fechaFin) ";
            query += "group by po_material.id;";

            ConstruirQuery(query);
            AgregarParametro("@fechaInicio", fechaInicio);
            AgregarParametro("@fechaFin", fechaFin);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
