using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RequisicionAdjunto : ModeloMySql
    {
        public RequisicionAdjunto()
        {
            Tabla = "requisiciones_adjuntos";
        }

        static public RequisicionAdjunto Modelo()
        {
            return new RequisicionAdjunto();
        }

        public List<Fila> SeleccionarRequisiciones(int requisicion)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@requisicion", requisicion);
            List<Fila> listaIdArchivos = SeleccionarDatos("requisicion_compra=@requisicion", parametros, "id");
            List<Fila> resultados = new List<Fila>();

            listaIdArchivos.ForEach(delegate(Fila f)
            {
                resultados.AddRange( CargarDatos(f.Celda<int>("id")));
            });

            return resultados;
        }

        public List<Fila> ExisteArchivo(int idRequisicion, string archivo)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE requisicion_compra=@idRequisicion AND nombre_archivo=@archivo";
            ConstruirQuery(sql);
            AgregarParametro("@idRequisicion", idRequisicion);
            AgregarParametro("@archivo", archivo);
            EjecutarQuery();

            return LeerFilas();
        }
    }

}
