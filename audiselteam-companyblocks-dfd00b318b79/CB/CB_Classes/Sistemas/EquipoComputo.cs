using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    public class EquipoComputo : ModeloMySql
    {
        public EquipoComputo()
        {
            Tabla = "equipos_computo";
        }

        static public EquipoComputo Modelo()
        {
            return new EquipoComputo();
        }

        public List<Fila> BuscarEquipo(string rol)
        {
            string sql = "";

            if (rol != "TODOS")
                sql = "SELECT equipos_computo.id as idEquipo, equipos_computo.fecha_alta, equipos_computo.clase, equipos_computo.descripcion,equipos_computo.marca, equipos_computo.modelo, equipos_computo.numero_serie,equipos_computo.sistema_operativo_marca, equipos_computo.sistema_operativo_tipo,equipos_computo.sistema_operativo_version, equipos_computo.almacenamiento_hdd, equipos_computo.almacenamiento_hdd_descripcion, equipos_computo.almacenamiento_ssd, equipos_computo.almacenamiento_ssd_descripcion, equipos_computo.procesador_marca, equipos_computo.procesador_descripcion, equipos_computo.tarjeta_grafica_marca, equipos_computo.tarjeta_grafica_descripcion, equipos_computo.equipo_contrasena, equipos_computo.equipo_nombre, equipos_computo.equipo_usuario, equipos_computo.direccion_mac, equipos_computo.monitor_pulgadas, equipos_computo.ram_caracteristicas, equipos_computo.accesorio_tipo, equipo_computo_usuarios.id as idUsuarioEquipo, equipo_computo_usuarios.fecha_asignacion, equipo_computo_usuarios.equipo, equipo_computo_usuarios.usuario, usuarios.nombre, usuarios.paterno, usuarios.materno, equipos_computo.razon_social From equipos_computo, equipo_computo_usuarios, usuarios where (equipos_computo.clase=@desktop or equipos_computo.clase=@laptop) and equipos_computo.id = equipo_computo_usuarios.equipo and equipo_computo_usuarios.usuario = usuarios.id and usuarios.rol=@rol";
            else
                sql = "SELECT equipos_computo.id as idEquipo, equipos_computo.fecha_alta, equipos_computo.clase, equipos_computo.descripcion,equipos_computo.marca, equipos_computo.modelo, equipos_computo.numero_serie,equipos_computo.sistema_operativo_marca, equipos_computo.sistema_operativo_tipo,equipos_computo.sistema_operativo_version, equipos_computo.almacenamiento_hdd, equipos_computo.almacenamiento_hdd_descripcion, equipos_computo.almacenamiento_ssd, equipos_computo.almacenamiento_ssd_descripcion, equipos_computo.procesador_marca, equipos_computo.procesador_descripcion, equipos_computo.tarjeta_grafica_marca, equipos_computo.tarjeta_grafica_descripcion, equipos_computo.equipo_contrasena, equipos_computo.equipo_nombre, equipos_computo.equipo_usuario, equipos_computo.direccion_mac, equipos_computo.monitor_pulgadas, equipos_computo.ram_caracteristicas, equipos_computo.accesorio_tipo, equipos_computo.razon_social FROM equipos_computo where equipos_computo.clase=@desktop or equipos_computo.clase=@laptop";

            ConstruirQuery(sql);
            AgregarParametro("@rol", rol);
            AgregarParametro("@desktop", "DESKTOP");
            AgregarParametro("@laptop", "LAPTOP");

            EjecutarQuery();
            return LeerFilas();
        }
        
        public List<Fila> BuscarMonitor(string rol)
        {
            string sql = "";

            if (rol != "TODOS")
                sql = "SELECT equipos_computo.id as idEquipo, equipos_computo.fecha_alta, equipos_computo.clase, equipos_computo.descripcion,equipos_computo.marca, equipos_computo.modelo, equipos_computo.numero_serie,equipos_computo.sistema_operativo_marca, equipos_computo.sistema_operativo_tipo,equipos_computo.sistema_operativo_version, equipos_computo.almacenamiento_hdd, equipos_computo.almacenamiento_hdd_descripcion, equipos_computo.almacenamiento_ssd, equipos_computo.almacenamiento_ssd_descripcion, equipos_computo.procesador_marca, equipos_computo.procesador_descripcion, equipos_computo.tarjeta_grafica_marca, equipos_computo.tarjeta_grafica_descripcion, equipos_computo.equipo_contrasena, equipos_computo.equipo_nombre, equipos_computo.equipo_usuario, equipos_computo.direccion_mac, equipos_computo.monitor_pulgadas, equipos_computo.ram_caracteristicas, equipos_computo.accesorio_tipo, equipo_computo_usuarios.id as idUsuarioEquipo, equipo_computo_usuarios.fecha_asignacion, equipo_computo_usuarios.equipo, equipo_computo_usuarios.usuario, usuarios.nombre, usuarios.paterno, usuarios.materno, equipos_computo.razon_social From equipos_computo, equipo_computo_usuarios, usuarios where equipos_computo.clase=@monitor and equipos_computo.id = equipo_computo_usuarios.equipo and equipo_computo_usuarios.usuario = usuarios.id and usuarios.rol=@rol";
            else
                sql = "SELECT equipos_computo.id as idEquipo, equipos_computo.fecha_alta, equipos_computo.clase, equipos_computo.descripcion,equipos_computo.marca, equipos_computo.modelo, equipos_computo.numero_serie,equipos_computo.sistema_operativo_marca, equipos_computo.sistema_operativo_tipo,equipos_computo.sistema_operativo_version, equipos_computo.almacenamiento_hdd, equipos_computo.almacenamiento_hdd_descripcion, equipos_computo.almacenamiento_ssd, equipos_computo.almacenamiento_ssd_descripcion, equipos_computo.procesador_marca, equipos_computo.procesador_descripcion, equipos_computo.tarjeta_grafica_marca, equipos_computo.tarjeta_grafica_descripcion, equipos_computo.equipo_contrasena, equipos_computo.equipo_nombre, equipos_computo.equipo_usuario, equipos_computo.direccion_mac, equipos_computo.monitor_pulgadas, equipos_computo.ram_caracteristicas, equipos_computo.accesorio_tipo, equipos_computo.razon_social FROM equipos_computo where equipos_computo.clase=@monitor";

            ConstruirQuery(sql);
            AgregarParametro("@rol", rol);
            AgregarParametro("@monitor", "MONITOR");

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> BuscarAccesorio(string rol)
        {
            string sql = "";

            if (rol != "TODOS")
                sql = "SELECT equipos_computo.id as idEquipo, equipos_computo.fecha_alta, equipos_computo.clase, equipos_computo.descripcion,equipos_computo.marca, equipos_computo.modelo, equipos_computo.numero_serie,equipos_computo.sistema_operativo_marca, equipos_computo.sistema_operativo_tipo,equipos_computo.sistema_operativo_version, equipos_computo.almacenamiento_hdd, equipos_computo.almacenamiento_hdd_descripcion, equipos_computo.almacenamiento_ssd, equipos_computo.almacenamiento_ssd_descripcion, equipos_computo.procesador_marca, equipos_computo.procesador_descripcion, equipos_computo.tarjeta_grafica_marca, equipos_computo.tarjeta_grafica_descripcion, equipos_computo.equipo_contrasena, equipos_computo.equipo_nombre, equipos_computo.equipo_usuario, equipos_computo.direccion_mac, equipos_computo.monitor_pulgadas, equipos_computo.ram_caracteristicas, equipos_computo.accesorio_tipo, equipo_computo_usuarios.id as idUsuarioEquipo, equipo_computo_usuarios.fecha_asignacion, equipo_computo_usuarios.equipo, equipo_computo_usuarios.usuario, usuarios.nombre, usuarios.paterno, usuarios.materno, equipos_computo.razon_social From equipos_computo, equipo_computo_usuarios, usuarios where equipos_computo.clase=@accesorio and equipos_computo.id = equipo_computo_usuarios.equipo and equipo_computo_usuarios.usuario = usuarios.id and usuarios.rol=@rol";
            else
                sql = "SELECT equipos_computo.id as idEquipo, equipos_computo.fecha_alta, equipos_computo.clase, equipos_computo.descripcion,equipos_computo.marca, equipos_computo.modelo, equipos_computo.numero_serie,equipos_computo.sistema_operativo_marca, equipos_computo.sistema_operativo_tipo,equipos_computo.sistema_operativo_version, equipos_computo.almacenamiento_hdd, equipos_computo.almacenamiento_hdd_descripcion, equipos_computo.almacenamiento_ssd, equipos_computo.almacenamiento_ssd_descripcion, equipos_computo.procesador_marca, equipos_computo.procesador_descripcion, equipos_computo.tarjeta_grafica_marca, equipos_computo.tarjeta_grafica_descripcion, equipos_computo.equipo_contrasena, equipos_computo.equipo_nombre, equipos_computo.equipo_usuario, equipos_computo.direccion_mac, equipos_computo.monitor_pulgadas, equipos_computo.ram_caracteristicas, equipos_computo.accesorio_tipo, equipos_computo.razon_social FROM equipos_computo where equipos_computo.clase=@accesorio";

            ConstruirQuery(sql);
            AgregarParametro("@rol", rol);
            AgregarParametro("@accesorio", "ACCESORIO");

            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarEquipos(int idEquipo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@equipo", idEquipo);
            parametros.Add("@periodo", 0);
            return SeleccionarDatos("id=@equipo and periodo_mantenimiento != @periodo", parametros);
        }
    }
}
