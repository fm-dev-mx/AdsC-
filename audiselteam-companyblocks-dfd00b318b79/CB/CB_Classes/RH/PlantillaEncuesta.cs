using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PlantillaEncuesta : ModeloMySql
    {
        public PlantillaEncuesta()
        {
            Tabla = "plantillas_encuestas";
        }

        static public PlantillaEncuesta Modelo()
        {
            return new PlantillaEncuesta();
        }

        public List<Fila> SeleccionarPlantillas()
        {
            return SeleccionarDatos("", null);
        }
    }
}
