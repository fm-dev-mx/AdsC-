using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CertificadoCalibracion  : ModeloMySql
    {
        public CertificadoCalibracion()
        {
            Tabla = "certificados_calibraciones";
        }

        static public CertificadoCalibracion Modelo()
        {
            return new CertificadoCalibracion();
        }

        public List<Fila> SeleccionarCertificadoCalibracion(int idCalibracion)
        {
            string condition = string.Empty;

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@calibracion", idCalibracion);
            return SeleccionarDatos("calibracion=@calibracion", parametros);
        }
    }
}
