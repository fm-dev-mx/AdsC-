using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class MaterialProyectoCancelacion : ModeloMySql
    {
        public MaterialProyectoCancelacion()
        {
            Tabla = "material_proyecto_cancelaciones";
        }

        static public MaterialProyectoCancelacion Modelo()
        {
            return new MaterialProyectoCancelacion();
        }

        public List<Fila> SeleccionarMaterialCanceladoDeProyecto(decimal proyecto)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE proyecto =@proyecto";
            ConstruirQuery(query);
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
