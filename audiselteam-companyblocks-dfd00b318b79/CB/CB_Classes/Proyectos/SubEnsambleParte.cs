using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class SubensambleParte: ModeloMySql
    {
        public SubensambleParte()
        {
            Tabla = "subensambles_partes";
        }

        static public SubensambleParte Modelo()
        {
            return new SubensambleParte();
        }

        public List<Fila> SeleccionarComponentes(int idSubensamble)
        {
            string sql = "SELECT subensambles_partes.*, componente_proyecto.nombre FROM subensambles_partes INNER JOIN componente_proyecto WHERE subensambles_partes.subensamble=@id_subensamble AND componente_proyecto.id=subensambles_partes.parte AND subensambles_partes.tipo='COMPONENTE'";
            ConstruirQuery(sql);
            AgregarParametro("@id_subensamble", idSubensamble);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarSubensambles(int idSubensamble)
        {
            string sql = "SELECT subensambles_partes.*, subensambles_proyectos.nombre FROM subensambles_partes INNER JOIN subensambles_proyectos WHERE subensambles_partes.subensamble=@id_subensamble AND subensambles_proyectos.id=subensambles_partes.parte AND subensambles_partes.tipo='SUBENSAMBLE'";
            ConstruirQuery(sql);
            AgregarParametro("@id_subensamble", idSubensamble);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
