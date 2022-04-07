using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TratamientoMaterial : ModeloMySql
    {

        public TratamientoMaterial()
        {
            Tabla = "tratamientos_material";
        }

        static public TratamientoMaterial Modelo()
        {
            return new TratamientoMaterial();
        }

        public List<Fila> SeleccionarPorNombre(string nombre)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", nombre);
            return SeleccionarDatos("nombre=@nombre", parametros);
        }

        public List<Fila> TratamientosDeCategoria(string categoria)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@categoria", categoria);
            return SeleccionarDatos("categoria=@categoria", parametros);
        }

        public List<Fila> Categorias()
        {
            return SeleccionarDatos("", null, "DISTINCT categoria");
        }

    }
}
