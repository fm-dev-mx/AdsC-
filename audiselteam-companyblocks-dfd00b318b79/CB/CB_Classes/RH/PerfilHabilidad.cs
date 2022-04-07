using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PerfilHabilidad : ModeloMySql
    {
        public PerfilHabilidad()
        {
            Tabla = "perfiles_habilidades";
        }

        static public PerfilHabilidad Modelo()
        {
            return new PerfilHabilidad();
        }

        public void BorrarHabilidades(int perfil)
        {
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@perfil", perfil);

            PerfilHabilidad ph = new PerfilHabilidad();
            ph.SeleccionarDatos("perfil=@perfil", parametros);
            ph.BorrarDatos();
        }

        public List<Fila> Habilidades(int perfil)
        {
            ConstruirQuery("SELECT habilidades.id, habilidades.habilidad, habilidades.descripcion_habilidad, habilidades.tipo FROM habilidades, perfiles_habilidades where perfiles_habilidades.habilidad = habilidades.id and perfiles_habilidades.perfil=@perfil");
            AgregarParametro("@perfil", perfil);
            EjecutarQuery();
            return LeerFilas(); 
        }
    }
}
