using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CB_Base.Classes
{
    class ArchivoRequerimiento : ModeloMySql
    {
        public ArchivoRequerimiento()
        {
            Tabla = "archivos_requerimientos";
        }

        static public ArchivoRequerimiento Modelo()
        {
            return new ArchivoRequerimiento();
        }

        public List<Fila> SeleccionarAdjunto(int idAdjunto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@adjunto", idAdjunto);
            return SeleccionarDatos("adjunto=@adjunto", parametros);
        }

    }
}
