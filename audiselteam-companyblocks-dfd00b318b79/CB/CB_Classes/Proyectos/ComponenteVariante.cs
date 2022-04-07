using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CB_Base.Classes
{
    class ComponenteVariante : ModeloMySql
    {
        public ComponenteVariante()
        {
            Tabla = "componente_variante";
        }

        static public ComponenteVariante Modelo()
        {
            return new ComponenteVariante();
        }

       

        public List<Fila> CargarVariantesModelos(int idComponente)
        {
            string sql = "select componente_variante.nombre, componente_variante.id, modelo_proyecto.nombre AS modelo FROM componente_variante inner join modelo_proyecto where componente_variante.componente =@id_componente and modelo_proyecto.id = componente_variante.modelo;";
            ConstruirQuery(sql);
            AgregarParametro("@id_componente", idComponente);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Filtrar(string filtro = "")
        {
            filtro = "%" + filtro + "%";
            string sql = "SELECT * FROM " + Tabla + " WHERE id LIKE @filtro OR nombre LIKE @filtro ORDER BY id ASC";

            ConstruirQuery(sql);
            AgregarParametro("@filtro", filtro);
            EjecutarQuery();
            return LeerFilas();
        }

 
    }
}
