using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class FactorOperacionFabricacion : ModeloMySql
    {
        public FactorOperacionFabricacion()
        {
            Tabla = "factores_operaciones_fabricacion";
        }

        static public FactorOperacionFabricacion Modelo()
        {
            return new FactorOperacionFabricacion();
        }

        public List<Fila> SeleccionarFactor(int operacion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Clear();
            parametros.Add("@operacion", operacion);
            return SeleccionarDatos("operacion=@operacion", parametros);
        }

        public List<Fila> SeleccionarOperacionFactorValor(int operacion, string factor, string valor)
        {
            List<Fila> datosFactor = new List<Fila>();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Clear();
            parametros.Add("@operacion", operacion);
            parametros.Add("@factor", factor);
            parametros.Add("@valor", valor);
            return SeleccionarDatos("operacion=@operacion AND factor=@factor AND factor_valor=@valor", parametros);
        }

        public decimal PorcentajeDelFactor(int operacion, string factor, string valor)
        {
            List<Fila> datosFactor = new List<Fila>();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Clear();
            parametros.Add("@operacion", operacion);
            parametros.Add("@factor", factor);
            parametros.Add("@valor", valor);
            datosFactor = SeleccionarDatos("operacion=@operacion AND factor=@factor AND factor_valor=@valor", parametros);

            if (datosFactor.Count > 0)
            {
                return Convert.ToDecimal(datosFactor[0].Celda("factor_porcentaje"));
            }
            else return 0;
        }
    
    }
}
