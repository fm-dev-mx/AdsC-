using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ArchivoPo : ModeloMySql
    {

        public ArchivoPo()
        {
            Tabla = "archivos_pos";
        }
        static public ArchivoPo Modelo()
        {
            return new ArchivoPo();
        }
        public List<Fila> SeleccionarPo(int po)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("po", po);
            return SeleccionarDatos("po=@po", parametros);
        }
    }
}
