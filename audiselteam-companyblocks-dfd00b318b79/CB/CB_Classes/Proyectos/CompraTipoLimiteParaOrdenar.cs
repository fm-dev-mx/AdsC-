using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CompraTipoLimiteParaOrdenar  : ModeloMySql
    {
        public CompraTipoLimiteParaOrdenar()
        {
            Tabla = "compras_tipos_limite_para_ordenar";
        }

        static public CompraTipoLimiteParaOrdenar Modelo()
        {
            return new CompraTipoLimiteParaOrdenar();
        }

        public List<Fila> SeleccionarDias(int tipoMaterial)
        {
            string query = "SELECT * FROM " + Tabla + " WHERE tipo_material=@tipoMaterial";
            ConstruirQuery(query);
            AgregarParametro("@tipoMaterial", tipoMaterial);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
