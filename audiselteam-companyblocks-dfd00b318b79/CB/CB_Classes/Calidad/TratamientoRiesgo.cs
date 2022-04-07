using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class TratamientoRiesgo : ModeloMySql
    {
        public TratamientoRiesgo()
        {
            Tabla = "tratamiento_riesgos";
        }

        static public TratamientoRiesgo Modelo()
        {
            return new TratamientoRiesgo();
        }

        public List<Fila> SeleccionarImpacto(int impacto)
        {
            ConstruirQuery("SELECT * FROM tratamiento_riesgos WHERE impacto=@impacto");
            AgregarParametro("@impacto", impacto);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
