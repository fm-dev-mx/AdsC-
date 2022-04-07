using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionClinte : ModeloMySql
    {
        public CotizacionClinte()
        {
            Tabla = "cotizaciones_clientes";
        }

        static public CotizacionClinte Modelo()
        {
            return new CotizacionClinte();
        }

        public List<Fila> SeleccionarFechaCreacion()
        {
            string query = "SELECT distinct DATE(fecha_creacion) as fecha FROM " + Tabla + " order by fecha";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarFechaLimiteEnviar()
        {
            string query = "SELECT distinct DATE(fecha_limite_enviar) as fecha_limite FROM " + Tabla + " order by fecha_limite";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarUsuariosCreacion()
        {
            string query = "SELECT DISTINCT cotizaciones_clientes.usuario_creacion as id, usuarios.nombre, usuarios.paterno FROM " + Tabla;
            query += " INNER JOIN usuarios ON usuarios.id = cotizaciones_clientes.usuario_creacion";
            ConstruirQuery(query);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarCotizaciones(Fila Filtros)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE cliente=@cliente AND estatus_cotizacion=@estatusCotizacion";

            if (Filtros.Celda("cliente_contacto_tecnico").ToString() != "TODOS")
                query += " AND cliente_contacto_tecnico=@ClienteContactoTecnico";
            
            if (Filtros.Celda("usuario_creacion").ToString() != "TODOS")
                query += " AND usuario_creacion=@usuarioCreacion";

            if (Filtros.Celda("fecha_creacion").ToString() != "TODAS")
                query += " AND DATE(fecha_creacion)=DATE(@fechaCreacion)";

            if (Filtros.Celda("fecha_limite_enviar").ToString() != "TODAS")
                query += " AND DATE(fecha_limite_enviar)=DATE(@fechaLimiteEnviar)";

            ConstruirQuery(query);
            AgregarParametro("@cliente", Filtros.Celda("cliente").ToString());
            AgregarParametro("@ClienteContactoTecnico", Filtros.Celda("cliente_contacto_tecnico").ToString());
            AgregarParametro("@estatusCotizacion", Filtros.Celda("estatus_cotizacion").ToString());
            AgregarParametro("@usuarioCreacion", Filtros.Celda("usuario_creacion").ToString());

            if (Filtros.Celda("fecha_creacion").ToString() != "TODAS")
                AgregarParametro("@fechaCreacion", Convert.ToDateTime(Filtros.Celda("fecha_creacion").ToString()).Date);
            
            if (Filtros.Celda("fecha_limite_enviar").ToString() != "TODAS")
                AgregarParametro("@fechaLimiteEnviar", Convert.ToDateTime(Filtros.Celda("fecha_limite_enviar").ToString()).Date);
           
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
