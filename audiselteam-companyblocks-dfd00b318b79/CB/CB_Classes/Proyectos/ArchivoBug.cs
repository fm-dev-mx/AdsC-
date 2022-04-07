using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB_Base.Classes
{
    class ArchivoBug : ModeloMySql
    {
        public ArchivoBug()
        {
            Tabla = "archivos_bugs";
        }

        static public ArchivoBug Modelo()
        {
            return new ArchivoBug();
        }

        public List<Fila> SeleccionarAdjunto(int idAdjunto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@adjunto", idAdjunto);
            return SeleccionarDatos("adjunto=@adjunto", parametros);
        }
    }
}
