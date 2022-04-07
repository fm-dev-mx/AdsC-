using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class ArchivoPlanoDXF : ModeloMySql
    {

        public ArchivoPlanoDXF()
        {
            Tabla = "archivos_planos_dxf";
        }

        public void SeleccionarDePlano(int idPlano)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);
            SeleccionarDatos("plano=@plano", parametros);
        }

    }
}
