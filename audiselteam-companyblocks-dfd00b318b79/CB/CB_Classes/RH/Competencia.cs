using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Competencia : ModeloMySql
    {
        public Competencia()
        {
            Tabla = "habilidades";
        }

        public static Competencia Modelo()
        {
            return new Competencia();
        }

        public List<Fila> CargarDatos(string datos = "*") 
        { 
            try
            {
                string condicionesFiltros = CondicionesFiltros();
                string sql = "SELECT " + datos + " FROM " + Tabla;

                if (!condicionesFiltros.Equals(""))
                    sql += " AND " + condicionesFiltros;

                ConstruirQuery(sql);

                if(!condicionesFiltros.Equals(""))
                {
                    foreach(KeyValuePair<string, object> param in ParametrosFiltros)
                    {
                        AgregarParametro(param.Key, param.Value);
                    }
                }

                EjecutarQuery();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
              
            return LeerFilas();
        }

        public List<Fila> SeleccionarTiposHabilidades() 
        { 
            string sql = "select distinct(tipo) from audisel.habilidades";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarHabilidadesDeTipo(string tipo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tipo", tipo);
            return SeleccionarDatos("tipo=@tipo ORDER BY habilidad", parametros);
        }
    }
}
