using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CB_Base.Classes
{
    public class MaterialProyecto : ModeloMySql
    {

        public MaterialProyecto()
        {
            Tabla = "material_proyecto";
        }

        static public MaterialProyecto Modelo()
        {
            return new MaterialProyecto();
        }

        public List<Fila> Filtrar(decimal proyecto, string seleccion = "PRELIMINAR", string autorizacion = "TODOS", string compra = "TODOS", string requisitor = "TODOS", 
            string categoria = "TODOS", string fabricante = "TODOS", string[] tiposCompras = null, string modulo = "TODOS", bool mostrarCancelados = false)
        {
            if(tiposCompras == null)
            {
                tiposCompras = new string[0];
            }

            string filtroSeleccion = "";
            if (seleccion != "TODOS")
                filtroSeleccion = " AND estatus_seleccion=@estatus_seleccion";

            string filtroAutorizacion = "";
            if (autorizacion != "TODOS")
            {
                if (mostrarCancelados)
                    filtroAutorizacion = " AND material_proyecto.estatus_autorizacion IN ('" + autorizacion + "', 'CANCELADO') ";
                else
                    filtroAutorizacion = " AND material_proyecto.estatus_autorizacion=@estatus_autorizacion";
            }
            
            string filtroCompra = "";
            if (compra != "TODOS")
            {
                if (mostrarCancelados)
                    filtroCompra = " AND material_proyecto.estatus_compra IN ('" + compra + "', 'CANCELADO') ";
                else
                    filtroCompra = " AND material_proyecto.estatus_compra=@estatus_compra";
            }

           /* if (mostrarCancelados)
                filtroAutorizacion = "AND material_proyecto.estatus_compra IN ('@estatus_compra', 'CANCELADO')";*/

            string filtroRequisitor = "";
            if (requisitor != "TODOS")
                filtroRequisitor = " AND material_proyecto.requisitor=@requisitor";

            string filtroCategoria = "";
            if (categoria != "TODOS")
                filtroCategoria = " AND material_proyecto.subcategoria IN (SELECT id from categorias_sub_material where categoria IN (SELECT id from categorias_material WHERE categoria = @categoria))";

            string filtroFabricante = "";
            if(fabricante != "TODOS")
                filtroFabricante = " AND material_proyecto.fabricante=@fabricante";

            string filtroTipoCompra = "";
            if (tiposCompras.Length != 0 && tiposCompras[0].Trim() != "")
            {
                filtroTipoCompra = " AND material_proyecto.subcategoria in (select id from categorias_sub_material where categoria in (select id from categorias_material where tipo_compra in (select id from compras_tipos where nombre in (";
                foreach(string tipoCompra in tiposCompras)
                {
                    filtroTipoCompra += "'" + tipoCompra + "',";
                }
                filtroTipoCompra = filtroTipoCompra.Remove(filtroTipoCompra.Length - 1);
                filtroTipoCompra += "))))";
            }

            string filtroModulo = "";
            if (modulo != "TODOS")
                filtroModulo = " AND material_proyecto.subensamble=@modulo";

            string sql = "SELECT material_proyecto.*, categorias_material.categoria as categoria_real, ";
            sql += "(SELECT MAX(rfq_conceptos.tiempo_entrega) FROM rfq_conceptos WHERE material_proyecto.numero_parte=rfq_conceptos.numero_parte) AS tiempo_entrega_estimado "; 
            sql += "FROM material_proyecto ";
            sql += "left join categorias_sub_material on material_proyecto.subcategoria = categorias_sub_material.id ";
            sql += "left join categorias_material on categorias_sub_material.categoria = categorias_material.id ";
            sql += "WHERE proyecto=@proyecto " + filtroSeleccion + filtroAutorizacion + filtroCompra + filtroRequisitor + filtroCategoria + filtroFabricante + 
                filtroTipoCompra + filtroModulo + " ";
            sql += "ORDER BY material_proyecto.id desc";

            ConstruirQuery(sql);

            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@estatus_seleccion", seleccion);
            AgregarParametro("@estatus_autorizacion", autorizacion);
            AgregarParametro("@estatus_compra", compra);
            AgregarParametro("@requisitor", requisitor);
            AgregarParametro("@categoria", categoria);
            AgregarParametro("@fabricante", fabricante);
            AgregarParametro("@modulo", modulo);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Filtrar2(decimal idProyecto, string categoria = "TODOS", string[] tiposCompras = null)
        {
            string condicionesFiltros = CondicionesFiltros();

            if (condicionesFiltros.Equals(""))
                return new List<Fila>();

            if (tiposCompras == null)
            {
                tiposCompras = new string[0];
            }

            string filtroTipoCompra = "";
            if (tiposCompras.Length != 0 && tiposCompras[0].Trim() != "")
            {
                filtroTipoCompra = " AND material_proyecto.subcategoria in (select id from categorias_sub_material where categoria in (select id from categorias_material where tipo_compra in (select id from compras_tipos where nombre in (";
                foreach (string tipoCompra in tiposCompras)
                {
                    filtroTipoCompra += "'" + tipoCompra + "',";
                }
                filtroTipoCompra = filtroTipoCompra.Remove(filtroTipoCompra.Length - 1);
                filtroTipoCompra += "))))";
            }

            string filtroCategoria = "";
            if (categoria != "TODOS")
                filtroCategoria = " AND material_proyecto.subcategoria IN (SELECT id from categorias_sub_material where categoria IN (SELECT id from categorias_material WHERE categoria = @categoria))";

            string sql = "SELECT material_proyecto.*, categorias_material.categoria as categoria_real, ";
            sql += "(SELECT MAX(rfq_conceptos.tiempo_entrega) FROM rfq_conceptos WHERE material_proyecto.numero_parte=rfq_conceptos.numero_parte) AS tiempo_entrega_estimado ";
            sql += "FROM material_proyecto ";
            sql += "left join categorias_sub_material on material_proyecto.subcategoria = categorias_sub_material.id ";
            sql += "left join categorias_material on categorias_sub_material.categoria = categorias_material.id ";
            sql += "WHERE " + condicionesFiltros + filtroCategoria + filtroTipoCompra + " AND proyecto=@idProyecto";
            sql += " ORDER BY material_proyecto.id desc";

            ConstruirQuery(sql);
            AgregarParametro("@idProyecto", idProyecto);
            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
            {
                AgregarParametro(param.Key, param.Value);
            }
            EjecutarQuery();
            return LeerFilas();
        }


        public List<Fila> Preliminares(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus_seleccion", "PRELIMINAR");
            parametros.Add("@proyecto", proyecto);
            return SeleccionarDatos("estatus_seleccion=@estatus_seleccion AND proyecto=@proyecto ORDER BY categoria ASC", parametros);
        }

        public List<Fila> Definidos(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus_seleccion", "DEFINIDO");
            parametros.Add("@proyecto", proyecto);
            return SeleccionarDatos("estatus_seleccion=@estatus_seleccion AND proyecto=@proyecto ORDER BY categoria ASC", parametros);
        }

        public List<Fila> EnProcesoDeCompra(DateTime desde, DateTime hasta)
        {
            string condicionesFiltros = CondicionesFiltros();

            if (condicionesFiltros.Equals(""))
                return new List<Fila>();

            string sql = "SELECT id, requisitor, proyecto, numero_parte, fabricante, descripcion, tipo_venta, piezas_paquete,";
            sql += " estatus_seleccion, estatus_compra, estatus_autorizacion, fecha_autorizacion, comentarios_requisitor, SUM(piezas_requeridas) AS suma_piezas_requeridas, SUM(total) AS suma_total, MIN(fecha_creacion) AS fecha_creacion, fecha_promesa_ensamble,";
            sql += " (SELECT MAX(rfq_conceptos.tiempo_entrega) FROM rfq_conceptos WHERE rfq_conceptos.numero_parte=material_proyecto.numero_parte) AS tiempo_entrega_estimado";
            sql += " FROM material_proyecto";
            sql += " WHERE " + condicionesFiltros;
            sql += " AND ((fecha_creacion>=@desde AND fecha_creacion<=@hasta) OR fecha_creacion IS NULL)";
            sql += " GROUP BY numero_parte, fabricante ORDER BY tiempo_entrega_estimado DESC, fecha_autorizacion ASC";

            ConstruirQuery(sql);
            AgregarParametro("@desde", desde);
            AgregarParametro("@hasta", hasta);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
            {
                AgregarParametro(param.Key, param.Value);
            }

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EnProcesoDeCompra(string idMaterial, bool numeroParte)
        {
            string query = "SELECT id, requisitor, proyecto, numero_parte, fabricante, descripcion, tipo_venta, piezas_paquete, " +
                           "estatus_seleccion, estatus_compra, estatus_autorizacion, fecha_autorizacion, comentarios_requisitor, SUM(piezas_requeridas) AS suma_piezas_requeridas, SUM(total) AS suma_total, MIN(fecha_creacion) AS fecha_creacion, fecha_promesa_ensamble, " +
                           "(SELECT MAX(rfq_conceptos.tiempo_entrega) FROM rfq_conceptos WHERE rfq_conceptos.numero_parte=material_proyecto.numero_parte) AS tiempo_entrega_estimado " +
                           "FROM material_proyecto " +
                           "WHERE  material_proyecto.id IN ("+ idMaterial +") and estatus_compra NOT IN ('RECIBIDO', 'ORDENADO', 'CANCELADO', 'ORDEN ASIGNADA') ";
            if (numeroParte)
                query += "and material_proyecto.id NOT IN (SELECT id_material_proyecto FROM relaciones_material_rfq where binary numero_parte= binary material_proyecto.numero_parte) ";

            query += "GROUP BY numero_parte, fabricante ORDER BY tiempo_entrega_estimado DESC, fecha_autorizacion ASC ";

            ConstruirQuery(query);
            AgregarParametro("@idMaterial", idMaterial);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
            {
                AgregarParametro(param.Key, param.Value);
            }

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> DesgloseEnProcesoDeCompra(string numeroDeParte) 
        {
            string condicionesFiltros = CondicionesFiltros();

            if (condicionesFiltros.Equals(""))
                return new List<Fila>();

            string sql = "SELECT * FROM " + Tabla + " WHERE numero_parte=@numero_parte AND " + condicionesFiltros;
            
            ConstruirQuery(sql);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
            {
                AgregarParametro(param.Key, param.Value);
            }
            AgregarParametro("@numero_parte", numeroDeParte);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> DesgloseEnProcesoDeCompraPorNumeroParte(string numeroDeParte)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE numero_parte=@numero_parte";

            ConstruirQuery(sql);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
            {
                AgregarParametro(param.Key, param.Value);
            }
            AgregarParametro("@numero_parte", numeroDeParte);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> MaterialRecibidoAlmacen()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "RECIBIDO");
            parametros.Add("@estatusParcial", "ENTREGADO PARCIALMENTE");
            parametros.Add("@estatusParcialRecibido", "RECIBIDO PARCIALMENTE");
            parametros.Add("@estatusStock", "STOCK");

            SeleccionarDatos("estatus_almacen = @estatus OR estatus_almacen = @estatusParcial OR estatus_almacen=@estatusParcialRecibido OR estatus_almacen = @estatusStock", parametros);
            return Filas();
        }

        public List<Fila> MaterialEntregadoAlmacen()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "ENTREGADO");
            SeleccionarDatos("estatus_almacen = @estatus", parametros);
            return Filas();
        }

        public DataGridViewCellStyle ColorEstatusAlmacen(string estatus)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            switch (estatus)
            {
                case "RECIBIDO":
                    style.BackColor = Color.LightGreen;
                    style.ForeColor = Color.Black;
                    break;
                case "PARCIALMENTE ENTREGADA":
                    style.BackColor = Color.Yellow;
                    style.ForeColor = Color.Black;
                    break;
                case "STOCK":
                    style.BackColor = Color.LightGreen;
                    style.ForeColor = Color.Black;
                    break;
            }
            return style;
        }

        public List<Fila> Categorias()
        {
            string sql = "SELECT DISTINCT categoria FROM " + this.Tabla;
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EnProcesoPago()
        {
            string sql = "Select material_proyecto.* ,proveedores.nombre From material_proyecto inner join po_material on material_proyecto.po = po_material.id inner join proveedores on po_material.proveedor = proveedores.id where material_proyecto.estatus_finanzas != 'NO FACTURABLE' AND material_proyecto.estatus_finanzas != 'PAGADA'";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public void ActualizarDatosFinanzas()
        {
            MaterialProyecto ActualizarDatos = new MaterialProyecto();
            ActualizarDatos.SeleccionarDatos("estatus_almacen!= 'PENDIENTE' AND estatus_finanzas = 'NO FACTURABLE'");

            ActualizarDatos.Filas().ForEach(delegate(Fila f)
            {
                f.ModificarCelda("estatus_finanzas", "FACTURABLE");
            });
            ActualizarDatos.GuardarDatos();
        }

        public List<Fila> Pagadas()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "PAGADA");
            SeleccionarDatos("estatus_finanzas = @estatus", parametros);
            return Filas();
        }

        public Dictionary<string, int> CalcularTotalOrdenar(int piezas_requeridas, int piezas_paquete, string tipo_venta)
        {
            Dictionary<string, int> resultados = new Dictionary<string, int>();
            int total = 0;
            int piezasStock = 0;

            if (tipo_venta == "POR PAQUETE")
            {
                decimal piezasEntrePaquete = (decimal)piezas_requeridas / (decimal)piezas_paquete;
                total = (int)Math.Ceiling(piezasEntrePaquete);
                piezasStock = (total * piezas_paquete) - piezas_requeridas;
            }
            else
            {
                total = piezas_requeridas;
            }

            resultados.Add("total", total);
            resultados.Add("piezas_stock", total);
            return resultados;
        }

        public string TextoTotalOrdenar(int total, int piezas_paquete, string tipo_venta, string formato="MEXICO")
        {
            string textoTotal = "";

            if( tipo_venta == "POR PIEZA" )
            {
                switch(formato)
                {
                    case "MEXICO": textoTotal = total + " pieza(s)"; break;
                    case "ESTADOS UNIDOS": textoTotal = total + " part(s)"; break;
                    case "EUROPA": textoTotal = total + " part(s)"; break;
                }
            }
            else if( tipo_venta == "POR PAQUETE" )
            {
                switch (formato)
                {
                    case "MEXICO": textoTotal = total + " paquete(s) con " + piezas_paquete + " pieza(s) c/u"; break;
                    case "ESTADOS UNIDOS": textoTotal = total + " pack(s) with " + piezas_paquete + " part(s) each"; break;
                    case "EUROPA": textoTotal = total + " pack(s) with " + piezas_paquete + " part(s) each"; break;
                }
            }
            return textoTotal;
        }


        public DataGridViewCellStyle ColorEstatusEnsamble(string estatus)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            switch (estatus)
            {
                case "ENSAMBLADO":
                    style.BackColor = Color.LightGreen;
                    style.ForeColor = Color.Black;
                    break;

                case "RECIBIDO":
                    style.BackColor = Color.Yellow;
                    style.ForeColor = Color.Black;
                    break;

                case "PERDIDO":
                    style.BackColor = Color.Red;
                    style.ForeColor = Color.White;
                    break;

                case "RETRABAJO":
                    style.BackColor = Color.Blue;
                    style.ForeColor = Color.White;
                    break;
            }
            return style;
        }

        public List<Fila> Accesorios(int requisicion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@accesorio_para", requisicion);
            return SeleccionarDatos("accesorio_para=@accesorio_para", parametros);
        }

        public List<Fila> Requisitores(decimal proyecto=-1)
        {
            string sql = "SELECT DISTINCT requisitor FROM " + Tabla;
            if (proyecto != -1)
                sql += " WHERE proyecto=" + proyecto;

            sql += " ORDER BY requisitor ASC";

            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Fabricantes(decimal proyecto=-1)
        {
            string sql = "SELECT DISTINCT fabricante FROM " + Tabla;
            if (proyecto != -1)
                sql += " WHERE proyecto=" + proyecto;

            sql += " ORDER BY fabricante ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Proyectos()
        {
            string sql = "SELECT DISTINCT FORMAT(material_proyecto.proyecto, 2) AS proyecto, proyectos.nombre, proyectos.activo FROM material_proyecto INNER JOIN proyectos ON material_proyecto.proyecto=proyectos.id WHERE proyectos.activo=1 ORDER BY material_proyecto.proyecto";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusCompra()
        {
            string sql = "SELECT DISTINCT estatus_compra FROM " + Tabla + " ORDER BY estatus_compra ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ModulosDeProyecto(decimal idProyecto)
        {
            string sql = "SELECT DISTINCT subensamble FROM " + Tabla + " WHERE proyecto=@idProyecto ORDER BY subensamble ASC";
            ConstruirQuery(sql);
            AgregarParametro("@idProyecto", idProyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CategoriasDeMaterialPorProyecto(decimal idProyecto)
        {
            string sql = "SELECT * FROM categorias_sub_material WHERE id in (SELECT DISTINCT subcategoria FROM " + Tabla + " WHERE proyecto=@idProyecto) ORDER BY nombre";
            ConstruirQuery(sql);
            AgregarParametro("@idProyecto", idProyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> TipoDeCompraDeMaterialPorProyecto(decimal idProyecto)
        {
            string sql = "SELECT * FROM compras_tipos where id in(SELECT DISTINCT tipo_compra FROM categorias_material WHERE id in (SELECT DISTINCT subcategoria FROM " + Tabla + " WHERE proyecto=@idProyecto)) ORDER BY nombre";
            ConstruirQuery(sql);
            AgregarParametro("@idProyecto", idProyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusSeleccion()
        {
            string sql = "SELECT DISTINCT estatus_seleccion FROM " + Tabla + " ORDER BY estatus_seleccion ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusAutorizacion()
        {
            string sql = "SELECT DISTINCT estatus_autorizacion FROM " + Tabla + " ORDER BY estatus_autorizacion ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusAlmacen()
        {
            string sql = "SELECT DISTINCT estatus_almacen FROM " + Tabla + " ORDER BY estatus_almacen ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }


        public List<Fila> NumeroParte()
        {
            string sql = "SELECT DISTINCT numero_parte FROM " + Tabla + " ORDER BY numero_parte ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusEnsamble()
        {
            string sql = "SELECT DISTINCT estatus_ensamble FROM " + Tabla + " ORDER BY estatus_ensamble ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> DesgosarPO(int po, bool porRequiscion = false)
        {
            string sql = string.Empty;

            if(porRequiscion)
                sql = "SELECT * FROM material_proyecto where po =@po group by id;";
            else
                sql = "SELECT proyecto, sum(precio_suma_final) as suma_proyecto FROM audisel.material_proyecto where po =@po group by proyecto;";
            
            ConstruirQuery(sql);
            AgregarParametro("@po", po);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialMantenimiento(int mantenimiento, string moneda)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@mantenimientoId", mantenimiento);
            parametros.Add("@moneda", moneda);
            return SeleccionarDatos("mantenimiento=@mantenimientoId and precio_moneda=@moneda", parametros);
        }

        public List<Fila> RequisicionesSinMetaDeCompras(decimal idProyecto)
        {
            string sql = "SELECT id, fabricante, numero_parte, total, tipo_venta, proyecto FROM material_proyecto ";
            sql += "WHERE proyecto=@proyecto AND estatus_seleccion='DEFINIDO' AND estatus_autorizacion='AUTORIZADO' AND estatus_compra = 'EN PLANIFICACION' AND fecha_promesa_compras IS NULL";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", idProyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> FabricantesSinMetaDeCompras(decimal idProyecto)
        {
            string sql = "SELECT DISTINCT fabricante FROM material_proyecto WHERE "; 
            sql += "proyecto=@proyecto AND estatus_seleccion='DEFINIDO' AND estatus_autorizacion='AUTORIZADO' AND estatus_compra='EN PLANIFICACION' AND fecha_promesa_compras IS NULL ORDER BY fabricante ASC";

            ConstruirQuery(sql);
            AgregarParametro("@proyecto", idProyecto);
            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> ModulosSinMetaDeCompras(decimal idProyecto)
        {
            string sql = "SELECT DISTINCT material_proyecto.subensamble, modulos.id, modulos.nombre FROM material_proyecto ";
            sql += "INNER JOIN modulos ON modulos.proyecto=@proyecto AND modulos.subensamble=material_proyecto.subensamble ";
            sql += "WHERE material_proyecto.proyecto=@proyecto AND estatus_seleccion='DEFINIDO' AND estatus_autorizacion='AUTORIZADO' AND estatus_compra = 'EN PLANIFICACION' AND modulos.fecha_promesa_compras IS NULL ORDER BY material_proyecto.subensamble ASC";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", idProyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialDefinidoAutorizadoDeModulo(decimal idProyecto, int subensamble)
        {
            string sql = "SELECT * FROM material_proyecto WHERE proyecto=@proyecto AND subensamble=@subensamble ";
            sql += "AND estatus_seleccion='DEFINIDO' AND estatus_autorizacion='AUTORIZADO'";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", idProyecto);
            AgregarParametro("@subensamble", subensamble);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialDefinidoAutorizadoDeFabricante(decimal idProyecto, string fabricante)
        {
            string sql = "SELECT * ";
            sql += "FROM material_proyecto WHERE proyecto=@proyecto AND fabricante=@fabricante ";
            sql += "AND estatus_seleccion='DEFINIDO' AND estatus_autorizacion='AUTORIZADO'";
            ConstruirQuery(sql);
            AgregarParametro("@proyecto", idProyecto);
            AgregarParametro("@fabricante", fabricante);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialNoAutorizadoPorProveedor(string proveedor, string estatusCompra)
        {
            /*string query = "SELECT material_proyecto.id AS id_requisicion, rfq_material.id AS rfq, rfq_conceptos.numero_parte, rfq_conceptos.precio_unitario, proveedores.nombre AS nombre_proveedor " +
                      "FROM rfq_material " +
                      "INNER JOIN rfq_conceptos ON rfq_conceptos.rfq = rfq_material.id " +
                      "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                      "INNER JOIN  material_proyecto ON material_proyecto.numero_parte = rfq_conceptos.numero_parte " +
                      "WHERE rfq_material.vigente = 1 " +
                      //"AND material_proyecto.estatus_autorizacion 'AUTORIZADO' " +
                      //"AND estatus_financiero='PENDIENTE' " +
                      "AND material_proyecto.estatus_compra=@estatusCompra " +
                      "AND rfq_conceptos.id IN (SELECT MAX(id) FROM rfq_conceptos WHERE numero_parte = rfq_conceptos.numero_parte) " +
                      "AND proveedores.nombre LIKE '%" + proveedor + "%'" +
                      "GROUP BY rfq_conceptos.numero_parte";*/

            string query = "SELECT material_proyecto.id AS id_requisicion, rfq_material.id AS rfq, rfq_conceptos.numero_parte, rfq_conceptos.precio_unitario, proveedores.nombre AS nombre_proveedor " +
                            "from material_proyecto " +
                            "INNER join rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto " +
                            "INNER join rfq_material ON rfq_material.id = rfq_conceptos.rfq " +
                            "Inner join proveedores ON proveedores.id = rfq_material.proveedor " +
                            "where material_proyecto.estatus_compra=@estatusCompra " +
                            "AND proveedores.nombre LIKE '%" + proveedor + "%'";
   
            ConstruirQuery(query);
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@estatusCompra", estatusCompra);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialCotizadoPorProveedor(string proveedor, string tipoMoneda, int rfq = -1)
        {
            string query = "select material_proyecto.id as id_requisicion, material_proyecto.numero_parte, material_proyecto.proyecto, material_proyecto.requisitor, rfq_conceptos.precio_unitario, material_proyecto.rfq_concepto, " +
                    "proveedores.nombre as nombre_proveedor, rfq_conceptos.id as id_concepto, " +
                    "rfq_conceptos.rfq " +
                    "from material_proyecto " +
                    "INNER JOIN rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto " +
                    "INNER JOIN rfq_material ON rfq_material.id = rfq_conceptos.rfq " +
                    "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                    "where " +
                   // "material_proyecto.estatus_autorizacion IN ('AUTORIZADO', 'N/A') AND " +
                    "material_proyecto.estatus_seleccion = 'DEFINIDO'  " +
                    "AND material_proyecto.estatus_compra = 'LISTO PARA ORDENAR'  " +
                    "AND material_proyecto.estatus_financiero='AUTORIZADO' " +
                    "AND rfq_conceptos.moneda = @tipoMoneda " +
                    "AND proveedores.nombre LIKE '%" + proveedor + "%' ";

            if(rfq > 0)
            {
                query += "AND rfq_material.id = @rfq ";
            }
            ConstruirQuery(query);
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@tipoMoneda", tipoMoneda);
            AgregarParametro("@rfq", rfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRequisicionesParaPartesPo(string proveedor, string numeroParte, string tipoMoneda)
        {
            string query = "select material_proyecto.id as id_requisicion, material_proyecto.numero_parte, material_proyecto.proyecto, material_proyecto.requisitor, rfq_conceptos.precio_unitario, material_proyecto.rfq_concepto, " +
                           "proveedores.nombre as nombre_proveedor, rfq_conceptos.id as id_concepto, " +
                           "rfq_conceptos.rfq " +
                           "from material_proyecto " +
                           "INNER JOIN rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto " +
                           "INNER JOIN rfq_material ON rfq_material.id = rfq_conceptos.rfq " +
                           "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                           "where material_proyecto.estatus_autorizacion IN ('AUTORIZADO')  " +
                           "AND material_proyecto.estatus_seleccion = 'DEFINIDO'  " +
                           "AND material_proyecto.estatus_compra = 'LISTO PARA ORDENAR'  " +
                           "AND material_proyecto.estatus_financiero='AUTORIZADO' " +
                           "AND rfq_conceptos.moneda = @tipoMoneda " +
                           "AND proveedores.nombre LIKE '%" + proveedor + "%' " +
                           "AND material_proyecto.numero_parte = @numeroParte";


               // query += "AND rfq_material.id = @rfq ";
            
            //"GROUP BY material_proyecto.numero_parte";

            ConstruirQuery(query);
            AgregarParametro("@autorizado", "AUTORIZADO");
            AgregarParametro("@definido", "DEFINIDO");
            AgregarParametro("@cotizacion", "AUTORIZADO");
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@tipoMoneda", tipoMoneda);
           // AgregarParametro("@rfq", rfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRequisicionesParaPartes(string proveedor, string numeroParte, string tipoMoneda, int rfq = -1)
        {
            string query = "select material_proyecto.id as id_requisicion, material_proyecto.numero_parte, material_proyecto.proyecto, material_proyecto.requisitor, rfq_conceptos.precio_unitario, material_proyecto.rfq_concepto, " +
                           "proveedores.nombre as nombre_proveedor, rfq_conceptos.id as id_concepto, " +
                           "rfq_conceptos.rfq " +
                           "from material_proyecto " +
                           "INNER JOIN rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto " +
                           "INNER JOIN rfq_material ON rfq_material.id = rfq_conceptos.rfq " +
                           "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                           "where material_proyecto.estatus_autorizacion IN ('AUTORIZADO', 'N/A')  " +
                           "AND material_proyecto.estatus_seleccion = 'DEFINIDO'  " +
                           "AND material_proyecto.estatus_compra = 'LISTO PARA ORDENAR'  " +
                           "AND material_proyecto.estatus_financiero='AUTORIZADO' " +
                           "AND rfq_conceptos.moneda = @tipoMoneda " +
                           "AND proveedores.nombre LIKE '%" + proveedor + "%' ";

            if(rfq > 0)
            {
                query += "AND rfq_material.id = @rfq ";
            }
                           //"GROUP BY material_proyecto.numero_parte";

            ConstruirQuery(query);
            AgregarParametro("@autorizado", "AUTORIZADO");
            AgregarParametro("@definido", "DEFINIDO");
            AgregarParametro("@cotizacion", "AUTORIZADO");
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@tipoMoneda", tipoMoneda);
            AgregarParametro("@rfq", rfq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRequisicionesNoDisponiblesParaPartes(string proveedor, string numeroParte)
        {

           /* string query = "SELECT  rfq_conceptos.id as id_concepto, material_proyecto.id as id_requisicion, rfq_material.id as rfq, rfq_conceptos.numero_parte, rfq_conceptos.precio_unitario, proveedores.nombre, material_proyecto.proyecto, material_proyecto.requisitor " +
                           "FROM rfq_material " +
                           "INNER JOIN rfq_conceptos ON rfq_conceptos.rfq = rfq_material.id " +
                           "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                           "INNER JOIN  material_proyecto ON material_proyecto.numero_parte = rfq_conceptos.numero_parte " +
                           "WHERE rfq_material.vigente = 1 " +
                           "AND material_proyecto.estatus_autorizacion='PENDIENTE' " +
                           "AND rfq_conceptos.id IN (SELECT MAX(id) FROM rfq_conceptos WHERE numero_parte = rfq_conceptos.numero_parte) " +
                           "AND rfq_conceptos.numero_parte =@numeroParte " +
                           "AND proveedores.nombre LIKE '%" + proveedor + "%'";*/

            string query = "select material_proyecto.id as id_requisicion, material_proyecto.numero_parte, material_proyecto.proyecto, material_proyecto.requisitor, rfq_conceptos.precio_unitario, material_proyecto.rfq_concepto, " +
                           "proveedores.nombre as nombre_proveedor, rfq_conceptos.id as id_concepto, " +
                           "rfq_conceptos.rfq " +
                           "from material_proyecto " +
                           "INNER JOIN rfq_conceptos ON rfq_conceptos.id = material_proyecto.rfq_concepto " +
                           "INNER JOIN rfq_material ON rfq_material.id = rfq_conceptos.rfq " +
                           "INNER JOIN proveedores ON proveedores.id = rfq_material.proveedor " +
                           "where material_proyecto.estatus_autorizacion='AUTORIZADO'  " +
                           "AND material_proyecto.estatus_seleccion = 'DEFINIDO'  " +
                           "AND material_proyecto.estatus_compra = 'LISTO PARA ORDENAR'  " +
                           "AND material_proyecto.estatus_financiero='PENDIENTE' " +
                           "AND rfq_conceptos.moneda = @tipoMoneda " +
                           "AND proveedores.nombre LIKE '%" + proveedor + "%' ";

            ConstruirQuery(query);
            AgregarParametro("@autorizado", "PENDIENTE");
            AgregarParametro("@proveedor", proveedor);
            AgregarParametro("@numeroParte", numeroParte);
            EjecutarQuery();
            return LeerFilas();
        }

        public bool VerificarEnlaceAPo (int idRequisicion)
        {
            string query = "select if(estatus_compra in ('ORDEN ASIGNADA', 'ORDENADO'), 1, 0) as enlazado from material_proyecto  where id= @idRequisicion";
            ConstruirQuery(query);
            AgregarParametro("@idRequisicion", idRequisicion);
            EjecutarQuery();

             return Convert.ToBoolean(LeerFilas()[0].Celda("enlazado"));

        }

        public List<Fila> SeleccionarMaterialPorTipoCompra(int idTipoCompra)
        {
           /* string query = "SELECT *, piezas_requeridas as piezas_totales FROM " + Tabla + " WHERE subcategoria IN (select id from categorias_sub_material where categoria IN (select id from categorias_material where tipo_compra = @idTipoCompra)) ";
            query += " AND estatus_autorizacion in('AUTORIZADO','PENDIENTE') and estatus_compra NOT IN ('ORDENADO', 'CANCELADO') GROUP by fabricante ORDER BY fabricante ASC";*/

            string condicionesFiltros = CondicionesFiltros();

            if (condicionesFiltros == "")
                condicionesFiltros = "estatus_autorizacion in('AUTORIZADO','PENDIENTE') and estatus_compra NOT IN ('ORDENADO', 'CANCELADO')";

            string query = "SELECT *, piezas_requeridas as piezas_totales FROM " + Tabla;
            query +=" WHERE subcategoria IN (select id from categorias_sub_material where categoria IN (select id from categorias_material where tipo_compra = @idTipoCompra)) AND ";
            query += condicionesFiltros + " GROUP by fabricante ORDER BY fabricante ASC";

            ConstruirQuery(query);
            AgregarParametro("@idTipoCompra", idTipoCompra);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
                AgregarParametro(param.Key, param.Value);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialPorTipoCompraYNumeroDeParte(int idTipoCompra)
        {
            string condicionesFiltros = CondicionesFiltros();
            if (condicionesFiltros == "")
                condicionesFiltros = "estatus_compra NOT IN ('ORDENADO', 'CANCELADO')";
            
            string query = "SELECT *, SUM(piezas_requeridas) as piezas_totales FROM material_proyecto ";
            query += "WHERE subcategoria IN (select id from categorias_sub_material where categoria IN (select id from categorias_material where tipo_compra = @idTipoCompra)) AND";
            query += condicionesFiltros + " ";
            query += "GROUP BY numero_parte ORDER BY numero_parte ASC"; //AND estatus_autorizacion in('AUTORIZADO','PENDIENTE') and estatus_compra NOT IN ('ORDENADO', 'CANCELADO')

            ConstruirQuery(query);
            AgregarParametro("@idTipoCompra", idTipoCompra);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
                AgregarParametro(param.Key, param.Value);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRequisicionesDeNumeroParte(string numeroParte, int idTipoCompra, string condicionesFiltros = "", bool ignorarFiltros = false)
        {
            if(condicionesFiltros == "")
            { 
                condicionesFiltros = CondicionesFiltros();
            }

            if (condicionesFiltros == "")
                condicionesFiltros = "estatus_autorizacion in('AUTORIZADO','PENDIENTE') and estatus_compra NOT IN ('ORDENADO', 'CANCELADO')";

            string query = "SELECT * FROM material_proyecto ";
            query += "WHERE subcategoria IN (select id from categorias_sub_material where categoria IN (select id from categorias_material where tipo_compra = @idTipoCompra)) ";
            query += "AND numero_parte=@numeroParte ";
            
            if(!ignorarFiltros)
            { 
                query += " AND " + condicionesFiltros;
            }

            query += " ORDER BY id ASC";

            ConstruirQuery(query);
            AgregarParametro("@idTipoCompra", idTipoCompra);
            AgregarParametro("@numeroParte", numeroParte);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
                AgregarParametro(param.Key, param.Value);

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarRequisicionesDeNumeroParteParaFabricante(int idTipoCompra, string fabricante)
        {
            string condicionesFiltros = CondicionesFiltros();
            if (condicionesFiltros == "")
                condicionesFiltros = "estatus_autorizacion in('AUTORIZADO','PENDIENTE') and estatus_compra NOT IN ('ORDENADO', 'CANCELADO')";

            string query = "SELECT *, sum(piezas_requeridas) as total_piezas_requeridas FROM material_proyecto ";
            query += "WHERE subcategoria IN (select id from categorias_sub_material where categoria IN (select id from categorias_material where tipo_compra = @idTipoCompra)) ";
            query += "AND " +  condicionesFiltros + " AND fabricante=@fabricante GROUP BY numero_parte ORDER BY numero_parte ASC";

            ConstruirQuery(query);
            AgregarParametro("@idTipoCompra", idTipoCompra);
            AgregarParametro("@fabricante", fabricante);

            foreach (KeyValuePair<string, object> param in ParametrosFiltros)
                AgregarParametro(param.Key, param.Value);

            EjecutarQuery();

            return LeerFilas();
        }

        public enum TablaMaterialRequisicion
        {
            MaterialMaquinado,
            ProcesoPlano
        }

        public int CrearRequisicionCompraFabricacion(PlanoProyecto plano, string categoriaProceso, TablaMaterialRequisicion tablaMaterial, string numeroParte, string descripcion, bool cantidadSegunElPlano = true, int nuevaCantidad = 0, byte[] datosPlano=null)
        {
            int cantidad = 0;
            int IdPlano = plano.Fila().Celda<int>("id");
            Fila f = new Fila();
            ArchivoPlanoDXF archivoDXF = new ArchivoPlanoDXF();
            MaterialProyecto material = new MaterialProyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            int requisicionId = 0;

            if (cantidadSegunElPlano)
                cantidad = Convert.ToInt32(plano.Fila().Celda("cantidad"));
            else
                cantidad = nuevaCantidad;

            decimal proyecto = Convert.ToDecimal(plano.Fila().Celda("proyecto").ToString());

            // inserta la entidad en la tabla planos_proyectos
            f.AgregarCelda("requisitor", Global.UsuarioActual.NombreCompleto());
            f.AgregarCelda("proyecto", proyecto);
            f.AgregarCelda("categoria", "PROCESO DE FABRICACION");
            f.AgregarCelda("numero_parte", numeroParte);
            f.AgregarCelda("fabricante", "LOCAL");
            f.AgregarCelda("descripcion", descripcion);
            f.AgregarCelda("piezas_requeridas", cantidad);
            f.AgregarCelda("piezas_stock", 0);
            f.AgregarCelda("total", cantidad);
            f.AgregarCelda("tipo_venta", "POR PIEZA");
            f.AgregarCelda("piezas_paquete", 0);
            f.AgregarCelda("estatus_seleccion", "DEFINIDO");
           
            f.AgregarCelda("estatus_autorizacion", "PENDIENTE");
            f.AgregarCelda("usuario_autorizacion", "N/A");
            f.AgregarCelda("fecha_autorizacion", null);
            f.AgregarCelda("comentarios_autorizacion", null);
            f.AgregarCelda("plano", IdPlano);
            f.AgregarCelda("fecha_creacion", DateTime.Now);

            int subcategoria = 0;
            switch (tablaMaterial)
            {
                case TablaMaterialRequisicion.MaterialMaquinado:
                    subcategoria = CategoriaSubMaterial.Modelo().SeleccionarIdSubCategoriaDeMaterialMaquinado(
                        categoriaProceso
                        );
                    break;
                case TablaMaterialRequisicion.ProcesoPlano:
                    subcategoria = CategoriaSubMaterial.Modelo().SeleccionarIdSubCategoriaDeProcesoPlano(
                        categoriaProceso
                        );
                    break;
                default:
                    break;
            }

            f.AgregarCelda("subcategoria", subcategoria);

            f = MaterialProyecto.Modelo().Insertar(f);

            requisicionId = Convert.ToInt32(f.Celda("id"));


            // crear el adjunto de la requisicion con los bytes del plano (PNG) como contenido
            if(datosPlano != null)
            {
                f = new Fila();
                f.AgregarCelda("requisicion_compra", requisicionId);
                f.AgregarCelda("nombre_archivo", "Plano " + IdPlano + ".pdf");
                f.AgregarCelda("archivo", datosPlano);
                f = RequisicionAdjunto.Modelo().Insertar(f);
            }

            // busca archivo dxf en base de datos (si existe)
            // crear el adjunto de la requisicion con los bytes del plano (DXF) como contenido
            byte[] archivoPlanoDXF = null;     
            
            archivoDXF.SeleccionarDatos("plano=@plano", parametros, "archivo");

            if (archivoDXF.TieneFilas())
                archivoPlanoDXF = (byte[])archivoDXF.Fila().Celda("archivo");

            if (archivoPlanoDXF != null)
            {
                f = new Fila();
                f.AgregarCelda("requisicion_compra", requisicionId);
                f.AgregarCelda("nombre_archivo", plano.Fila().Celda("nombre_archivo").ToString() + ".dxf");
                f.AgregarCelda("archivo", archivoPlanoDXF);
                f = RequisicionAdjunto.Modelo().Insertar(f);
            }
            return requisicionId;
        }

        public static string CrearNNumeroParteProceso(int idPlano, string nombreProceso, int idProceso)
        {
            return nombreProceso.Replace(' ', '-') + "-ID" + idPlano.ToString().PadLeft(7, '0') + "-" + "PROC" + idProceso;                          
        }

        public List<Fila> SeleccionarMaterialDeFabricacionDePlano(int idPlano)
        {
            List<Fila> resultadosRequisiciones = new List<Classes.Fila>();
            List<Fila> resultados = new List<Classes.Fila>();
            List<Fila> RequisicionesParaMaterial = new List<Classes.Fila>();
            
            //Cargamos todos los procesos del plano que tenga una requisicion
            string query = "SELECT * FROM " + Tabla + " WHERE plano =@idPlano";
            ConstruirQuery(query);
            AgregarParametro("@idPlano", idPlano);
            EjecutarQuery();
            resultadosRequisiciones = LeerFilas();

            foreach (Fila f in resultadosRequisiciones)
            {
                int subcategoria = Convert.ToInt32(f.Celda("subcategoria"));

                //cargamos las subcategorias de cada requisición
                query = "SELECT * FROM categorias_sub_material WHERE id = @idSubcategoria";
                ConstruirQuery(query);
                AgregarParametro("@idSubcategoria", subcategoria);
                EjecutarQuery();
                resultados = LeerFilas();

                if (resultados.Count > 0)
                {
                    int categoria = Convert.ToInt32(resultados[0].Celda("categoria"));

                    query = "SELECT * FROM categorias_material WHERE id = @idCategoria";
                    ConstruirQuery(query);
                    AgregarParametro("@idCategoria", categoria);
                    EjecutarQuery();
                    resultados = LeerFilas();

                    if (resultados.Count > 0)
                    {
                        string strCategoria = resultados[0].Celda("categoria").ToString();

                        if (strCategoria == "MATERIAL PARA FABRICACION")
                            RequisicionesParaMaterial.Add(f);
                    }
                }
            }
            return RequisicionesParaMaterial;
        }

        public List<Fila> SeleccionarRequisicionRFQ(string idReq)
        {
            string query = "SELECT *, piezas_requeridas as suma_total FROM " + Tabla + " where id IN (" + idReq + ")";

            ConstruirQuery(query);
            AgregarParametro("@idReq", idReq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialRequisitadoEnFechaActual(string numeroParte, string fabricante = "")
        {
            string query = "select count(id) as total from material_proyecto where numero_parte =@numeroParte and date(fecha_creacion) = date(curdate())";
            if (fabricante != "")
                query += " and fabricante =@fabricante";
            
            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@fabricante", fabricante);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarProveedorMaterialRequisitadoEnFechaActual(string fabricante)
        {
            string query = "select count(id) as total from material_proyecto where date(fecha_creacion) = date(curdate()) and fabricante =@fabricante";

            ConstruirQuery(query);
            AgregarParametro("@fabricante", fabricante);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialEnRevisionFinanciera(string estatusFinanciero, string estatusCompra, int limite)
        {
            string query = string.Empty;

            if(limite > 0)
                query = "SELECT * FROM " + Tabla + " WHERE estatus_financiero =@estatusFinanciero  AND id > 0 limit " + limite;
            else 
                query = "SELECT * FROM " + Tabla + " WHERE estatus_compra =@revisionFinanciera AND estatus_financiero =@estatusFinanciero AND id > 0";

            ConstruirQuery(query);
            AgregarParametro("@revisionFinanciera", estatusCompra);
            AgregarParametro("@estatusFinanciero", estatusFinanciero);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMaterialMetasPorEstatus()
        {
            string query = "select material_proyecto.*, proveedores.nombre as proveedor, rfq_conceptos.tiempo_entrega as tiempo_entrega_cotizacion, " +
                "IF((SELECT tiempo_entrega_cotizacion)>0, DATE_SUB(material_proyecto.fecha_promesa_compras, INTERVAL (SELECT(tiempo_entrega_cotizacion) + 3) DAY), NULL) AS fecha_limite_ordenar " +
                "from material_proyecto " +
                "left join rfq_conceptos on material_proyecto.rfq_concepto = rfq_conceptos.id " +
                "left join rfq_material on rfq_conceptos.rfq = rfq_material.id " +
                "left join proveedores on rfq_material.proveedor = proveedores.id " +
                " where material_proyecto.id != 0";
            
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarDatosConProveedor(int idReq)
        {
            string query = "select material_proyecto.*, proveedores.nombre as proveedor, rfq_conceptos.tiempo_entrega as tiempo_entrega_cotizacion, " +
                "IF((SELECT tiempo_entrega_cotizacion)>0, DATE_SUB(material_proyecto.fecha_promesa_compras, INTERVAL (SELECT(tiempo_entrega_cotizacion) + 3) DAY), NULL) AS fecha_limite_ordenar " +
                "from material_proyecto " +
                "left join rfq_conceptos on material_proyecto.rfq_concepto = rfq_conceptos.id " +
                "left join rfq_material on rfq_conceptos.rfq = rfq_material.id " +
                "left join proveedores on rfq_material.proveedor = proveedores.id " +
                " where material_proyecto.id = @id_requisicion";

            ConstruirQuery(query);
            AgregarParametro("@id_requisicion", idReq);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> RequisicionesSinProveedorSeleccionado(string numeroParte, decimal proyecto = 0)
        {
            // para evitar bugs con versiones anteriores del software, solo se consideraran las requisiciones de compra creadas a partir de Sep de 2019
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Clear();
            parametros.Add("@numeroParte", numeroParte);
            parametros.Add("@proyecto", proyecto);

            string condiciones = "(estatus_compra='PENDIENTE' OR estatus_compra='EN COTIZACION' OR estatus_compra='COMPRA DETENIDA' OR estatus_compra='COMPRA RECHAZADA') ";
            condiciones += "AND numero_parte=@numeroParte AND (rfq_concepto = 0 OR rfq_concepto is null) AND fecha_creacion >= '2019-07-01' ";
            if (proyecto > 0)
                condiciones += "AND proyecto=@proyecto";

            SeleccionarDatos(condiciones, parametros);
            return Filas();
        }

        public List<Fila> RequisicionesVinculadasARfq(string numeroParte, decimal proyecto = 0)
        {
            // para evitar bugs con versiones anteriores del software, solo se consideraran las requisiciones de compra creadas a partir de Sep de 2019
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Clear();
            parametros.Add("@numeroParte", numeroParte);
            parametros.Add("@proyecto", proyecto);

            string condiciones = "estatus_compra IN ('PENDIENTE','EN COTIZACION', 'COMPRA DETENIDA', 'COMPRA RECHAZADA', 'LISTO PARA ORDENAR') ";
            condiciones += "AND numero_parte=@numeroParte AND fecha_creacion >= '2019-07-01' ";
            if (proyecto > 0)
                condiciones += "AND proyecto=@proyecto";

            SeleccionarDatos(condiciones, parametros);
            return Filas();
        }

        public List<Fila> ProyectosSinProveedorSeleccionado(string numeroParte)
        {
            string query = " SELECT proyecto FROM " + Tabla;
            query += " WHERE estatus_compra IN ('PENDIENTE','EN COTIZACION', 'COMPRA DETENIDA', 'COMPRA RECHAZADA') ";
            query += "AND numero_parte=@numeroParte AND DATE(fecha_creacion) >= DATE('2019-07-01') AND (rfq_concepto = 0 OR rfq_concepto is null) GROUP BY proyecto";
            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            EjecutarQuery();

            return LeerFilas();
        }

        //public List<Fila> RequisicionesSinProveedorSeleccionado(string numeroParte, decimal proyecto = 0)
        //{
        //    string query = " SELECT * FROM " + Tabla;
        //    query += " WHERE estatus_compra IN ('PENDIENTE','EN COTIZACION', 'COMPRA DETENIDA', 'COMPRA RECHAZADA') ";
        //    query += "AND numero_parte=@numeroParte AND DATE(fecha_creacion) >= DATE('2019-09-01') AND rfq_concepto = 0 ";
        //    if (proyecto > 0)
        //        query += "AND proyecto=@proyecto";

        //    ConstruirQuery(query);
        //    AgregarParametro("@numeroParte", numeroParte);
        //    AgregarParametro("@proyecto", proyecto);
        //    EjecutarQuery();

        //    return LeerFilas();
        //}

        public string SeleccionarProveedorPreferido(MaterialProyecto requisiciones, int idConceptoSeleccionado)
        {
            string requisicionesExcedidas = string.Empty;
            requisiciones.Filas().ForEach(delegate(Fila requisicion)
            {
                requisicionesExcedidas = SeleccionarProveedorPreferido(requisicion, idConceptoSeleccionado);
            });
            requisiciones.GuardarDatos();
            return requisicionesExcedidas;
        }

        public string SeleccionarProveedorPreferido(Fila requisicion, int idConceptoSeleccionado)
        {
            string requisicionesExcedidas = string.Empty;
            // obtiene la categoria y subcategoria del material 
            string nombreCategoriaMaterial = string.Empty;
            int idCategoria = 0;
            int idReq = Convert.ToInt32(requisicion.Celda("id"));
            int idSubcategoria = Convert.ToInt32(requisicion.Celda("subcategoria"));

            CategoriaMaterial cat = new CategoriaMaterial();
            CategoriaSubMaterial subcat = new CategoriaSubMaterial();
            subcat.CargarDatos(idSubcategoria);

            if (subcat.TieneFilas())
            {
                idCategoria = Convert.ToInt32(subcat.Fila().Celda("categoria"));
                cat.CargarDatos(idCategoria);

                if (cat.TieneFilas())
                    nombreCategoriaMaterial = cat.Fila().Celda("categoria").ToString().Trim();
            }
         
            EliminarProveedorPreferido(requisicion);

            // si el usuario selecciono un proveedor del dgv
            if (idConceptoSeleccionado > 0)
            {
                requisicion.ModificarCelda("rfq_concepto", idConceptoSeleccionado);

                // si el usuario SI selecciono un proveedor entonces debemos actualizar el estatus de compra
                // acorde al flujo del proceso de compras (procesar acorde a su categoria)
                switch (nombreCategoriaMaterial)
                {
                    // estas categorias no llevan revision tecnica y por lo tanto se autorizan automaticamente por sistema
                    case "PROCESOS DE FABRICACION":
                    case "MATERIAL PARA FABRICACION":

                        RfqConcepto concepto = new RfqConcepto();
                        concepto.CargarDatos(idConceptoSeleccionado);

                        switch (concepto.Fila().Celda("moneda").ToString())
	                    {
                            case "USD":
                                if(Convert.ToDecimal(concepto.Fila().Celda("precio_unitario")) <= 25)
                                {
                                    requisicion.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");
                                    requisicion.ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                                    requisicion.ModificarCelda("usuario_autorizacion", "SISTEMA");
                                    requisicion.ModificarCelda("fecha_autorizacion", DateTime.Now);
                                }
                                else
                                {
                                    requisicion.ModificarCelda("estatus_compra", "EN REVISION TECNICA");
                                    requisicion.ModificarCelda("estatus_autorizacion", "PENDIENTE");
                                    requisicionesExcedidas += requisicion.Celda("id") + ", "; 
                                }
                                break;
                            case "MXN":

                                if (Convert.ToDecimal(concepto.Fila().Celda("precio_unitario")) <= 500)
                                {
                                    requisicion.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");
                                    requisicion.ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                                    requisicion.ModificarCelda("usuario_autorizacion", "SISTEMA");
                                    requisicion.ModificarCelda("fecha_autorizacion", DateTime.Now);
                                }
                                else
                                {
                                    requisicion.ModificarCelda("estatus_compra", "EN REVISION TECNICA");
                                    requisicion.ModificarCelda("estatus_autorizacion", "PENDIENTE");
                                    requisicionesExcedidas += requisicion.Celda("id") + ", "; 
                                }
                                break;
		                    default:
                                break;
	                    }
                        // autorizacion automatica
                       // requisicion.ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                       // requisicion.ModificarCelda("usuario_autorizacion", "SISTEMA");
                       // requisicion.ModificarCelda("fecha_autorizacion", DateTime.Now);

                        // siguiente paso en el flujo del proceso de compras es revision financiera 
                        //requisicion.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");
                        break;

                    // cualquier compra de otra categoria debe pasar por revision tecnica
                    default:

                        // siguiente paso en el flujo del proceso de compras es revision tecnica
                        requisicion.ModificarCelda("estatus_compra", "EN REVISION TECNICA");
                        break;
                }
            }
            return requisicionesExcedidas;
        }

        public void EliminarProveedorPreferido(Fila requisicion)
        {
            requisicion.ModificarCelda("rfq_concepto", 0);
            requisicion.ModificarCelda("estatus_autorizacion", "PENDIENTE");
            requisicion.ModificarCelda("fecha_autorizacion", null);
            requisicion.ModificarCelda("usuario_autorizacion", "N/A");
            requisicion.ModificarCelda("estatus_financiero", "PENDIENTE");
            requisicion.ModificarCelda("fecha_revision_financiera", null);
            requisicion.ModificarCelda("usuario_aprobacion_financiera", null);
            requisicion.ModificarCelda("estatus_compra", "EN COTIZACION");
        }

        public List<Fila> AccesorioPara(int idRequisicion)
        {
            string sql = "SELECT id FROM " + Tabla + " WHERE accesorio_para=@idRequisicion ORDER BY id ASC";
            ConstruirQuery(sql);
            AgregarParametro("@idRequisicion", idRequisicion);
            EjecutarQuery();
            return LeerFilas();
        }

        public void CancelarRequisicionRegistro(int id, int id_usuario, string usuario, DateTime fecha, string numeroParte, string descripcion, decimal proyecto, string usuarioRequisitor, bool estatus=true)
        {
            //se agrega el registro de la cancelacion a la trabla -material_proyecto_cancelaciones-
            string sql = "INSERT INTO material_proyecto_cancelaciones(usuario_cancela, fecha, estatus, id_material_proyecto, id_usuario, numero_parte, descripcion, proyecto, usuario_requisitor) " +
                "VALUES(@usuario, @fecha, @estatus, @id, @idUsuario, @numeroParte, @descripcion, @proyecto, @usuarioRequisitor)";
            ConstruirQuery(sql);
            AgregarParametro("@usuario", usuario);
            AgregarParametro("@fecha", fecha);
            AgregarParametro("@estatus", estatus);
            AgregarParametro("@id", id);
            AgregarParametro("@idUsuario", id_usuario);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@descripcion", descripcion);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@usuarioRequisitor", usuarioRequisitor);
            EjecutarQuery();

            //se obtiene el ultimo numero de id
            string sqlId = "SELECT max(id) FROM material_proyecto_cancelaciones";
            ConstruirQuery(sqlId);
            EjecutarQuery();
            int idCancelacion = Convert.ToInt32(LeerFilas()[0].Celda("max(id)"));

           /* //se agrega el id de la cancelacion a la tabla -material_proyecto-
            string sqlMatProy = "UPDATE material_proyecto SET id_cancelacion=@idCancelacion where id=@id";
            ConstruirQuery(sqlMatProy);
            AgregarParametro("@idCancelacion", idCancelacion);
            AgregarParametro("@id", id);
            EjecutarQuery();*/
        }

        public List<Fila> MaterialFinanzasProveedores(string estatusFinanciero)
        {
            string query = string.Empty;
            query += "SELECT distinct rfq_material.proveedor, proveedores.nombre as proveedor_nombre ";
            query += "FROM material_proyecto ";
            query += "INNER JOIN rfq_conceptos on rfq_conceptos.id = material_proyecto.rfq_concepto ";
            query += "INNER JOIN rfq_material on rfq_material.id = rfq_conceptos.rfq ";
            query += "INNER JOIN proveedores on proveedores.id = rfq_material.proveedor ";
            query += "WHERE estatus_financiero = @estatusFinanciero ";

            if (estatusFinanciero == "PENDIENTE")
                query += "AND estatus_compra = 'EN REVISION FINANCIERA' ";
            else if (estatusFinanciero == "DETENIDO")
                query += "AND estatus_compra = 'COMPRA DETENIDA'";

            query += "ORDER BY proveedores.nombre asc;";

            ConstruirQuery(query);
            AgregarParametro("@estatusFinanciero", estatusFinanciero);
            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> CalcularEstatusCompraPorProyecto(decimal proyecto)
        {
            string query = string.Empty;

            query = "select " +
               "     mat1.estatus_compra, " +
               "     count(mat1.estatus_compra) as totales, " +
               "     mat2.filasTotales, " +
               "     (count(mat1.estatus_compra) * 100) / mat2.filasTotales as promedio " +
               " from " +
               "     material_proyecto as mat1 " +
               " JOIN " +
               " (" +
               "     select estatus_compra, count(*) as filasTotales " +
               "     from material_proyecto " +
               "     inner join categorias_sub_material on categorias_sub_material.id = material_proyecto.subcategoria " +
               "     inner join categorias_material on categorias_material.id = categorias_sub_material.categoria " +
               "     where proyecto = 114.04 and categorias_material.categoria not in ('PROCESOS DE FABRICACION', 'MATERIAL PARA FABRICACION') " +
               " ) as mat2 " +
               " inner join " +
               "     categorias_sub_material " +
               " on " +
               "     categorias_sub_material.id = mat1.subcategoria " +
               " inner join " +
               "     categorias_material " +
               " on " +
               "     categorias_material.id = categorias_sub_material.categoria " +
               " where " +
               "     mat1.proyecto =@proyecto " +
               "     and categorias_material.categoria not in ('PROCESOS DE FABRICACION', 'MATERIAL PARA FABRICACION') " +
               " group by " +
               "     mat1.estatus_compra " +
               " order by " +
               "     promedio asc; ";

            ConstruirQuery(query);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();

            return LeerFilas();

        }

        public List<Fila> MaterialDeCompraPorProyectoSinCategorias(decimal proyecto, List<string> categorias)
        {
            string strCategoria = string.Empty;
            foreach (string cat in categorias)
            {
                strCategoria += "'" + cat + "',";
            }

            strCategoria = strCategoria.TrimEnd(',');

            string query = string.Empty;
            query = "SELECT material_proyecto.* FROM " + Tabla;
            query += " inner join categorias_sub_material on categorias_sub_material.id = material_proyecto.subcategoria ";
            query += " inner join categorias_material on categorias_material.id = categorias_sub_material.categoria ";
            query += " WHERE proyecto = @proy and categorias_material.categoria not in ("+ strCategoria + ");";
            ConstruirQuery(query);
            AgregarParametro("@proy", proyecto);
            EjecutarQuery();

            return LeerFilas();
        }

        public List<Fila> BuscarMaterialPorNumeroParte(string numeroParte)
        {
            string sql = "SELECT material_proyecto.*, categorias_material.categoria as categoria_real, ";
            sql += "(SELECT MAX(rfq_conceptos.tiempo_entrega) FROM rfq_conceptos WHERE material_proyecto.numero_parte=rfq_conceptos.numero_parte) AS tiempo_entrega_estimado ";
            sql += "FROM material_proyecto ";
            sql += "left join categorias_sub_material on material_proyecto.subcategoria = categorias_sub_material.id ";
            sql += "left join categorias_material on categorias_sub_material.categoria = categorias_material.id ";
            sql += "WHERE numero_parte=@numeroParte ";
            sql += "ORDER BY proyecto ASC";

            ConstruirQuery(sql);
            AgregarParametro("@numeroParte", numeroParte);
            EjecutarQuery();

            return LeerFilas();
        }
    }
}
