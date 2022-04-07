using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TipoDocumentoUsuario : ModeloMySql
    {
        public TipoDocumentoUsuario()
        {
            Tabla = "tipos_documentos_usuarios";
        }

        static public TipoDocumentoUsuario Modelo()
        {
            return new TipoDocumentoUsuario();
        }

        public List<Fila> SeleccionarTiposDocumentos()
        {
            string sql = "SELECT distinct(tipo) FROM " + Tabla ;
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarDocumento(int usuario)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@usuario", usuario);
            return SeleccionarDatos("usuario=@usuario", parametros);
        }
    }
}
