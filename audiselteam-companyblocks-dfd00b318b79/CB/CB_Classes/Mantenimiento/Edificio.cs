using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Edificio : ModeloMySql
    {
        public Edificio()
        {
            Tabla = "edificios";
        }

        static public Edificio Modelo()
        {
            return new Edificio();
        }

        public List<Fila> CargarEdificios(string responsable)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@responsable", responsable);
            return SeleccionarDatos("", null); //esponsable=@responsable
        }
    
    }
}
