using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RazonTiempoMuerto : ModeloMySql
    {
        public RazonTiempoMuerto()
        {
            Tabla = "razones_tiempo_muerto";
        }

        static public RazonTiempoMuerto Modelo()
        {
            return new RazonTiempoMuerto();
        }
    }
}
