using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MantenimientoTopico : ModeloMySql
    {
        public MantenimientoTopico()
        {
            Tabla = "mantenimiento_topicos";
        }

        static public MantenimientoTopico Modelo()
        {
            return new MantenimientoTopico();
        }

        public List<Fila> SeleccionarTipoMantenimiento(string tipoMantenimiento, string tipoEquipo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tipoMantenimiento", tipoMantenimiento);
            parametros.Add("@tipoEquipo", tipoEquipo);
            return SeleccionarDatos("tipo_mantenimiento=@tipoMantenimiento and tipo_equipo=@tipoEquipo", parametros);
        }

        public List<Fila> SeleccionarTopicosPorClase(int topico, string clase)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@topico", topico);
            parametros.Add("@clase", clase);
            return SeleccionarDatos("id=@topico and clase=@clase", parametros);
        }
    }
}
