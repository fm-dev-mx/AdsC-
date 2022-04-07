using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class AccesorioMaterial : ModeloMySql
    {

        public AccesorioMaterial()
        {
            Tabla = "accesorios_material";
        }

        static public AccesorioMaterial Modelo()
        {
            return new AccesorioMaterial();
        }

        public List<Fila> SeleccionarMaterialTipo(int idMaterial, string tipo="TODOS")
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("material", idMaterial);
            parametros.Add("tipo", tipo);

            string filtroTipo = "";
            if (tipo != "TODOS")
                filtroTipo = " AND tipo=@tipo";

            string sql = "SELECT accesorios_material.*, catalogo_material.numero_parte AS accesorio_numero_parte, catalogo_material.descripcion AS accesorio_descripcion FROM " + Tabla + " INNER JOIN catalogo_material ON catalogo_material.id=accesorios_material.accesorio WHERE material=@material" + filtroTipo;
            ConstruirQuery(sql);
            AgregarParametro("material", idMaterial);
            AgregarParametro("tipo", tipo);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> TiposAccesorios(int idMaterial)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("material", idMaterial);
            return SeleccionarDatos("material=@material", parametros, "DISTINCT tipo");
        }

    }
}
