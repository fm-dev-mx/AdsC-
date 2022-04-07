using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP_Base.Classes
{
    class ArchivoConcepto : ModeloMySql
    {

        public ArchivoConcepto()
        {
            Tabla = "archivos_conceptos";
        }

        public ArchivoConcepto Modelo()
        {
            return new ArchivoConcepto();
        }

        public Fila CargarDeConcepto(int idConcepto)
        {
            Dictionary<string, Object> parametros = new Dictionary<string, object>();
            parametros.Add("@concepto", idConcepto);

            SeleccionarDatos("concepto=@concepto", parametros);
            return Fila();
        }

    }
}
