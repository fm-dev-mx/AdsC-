using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Filtro
    {
        public string NombreColumna;
        public string AliasColumna;
        public Dictionary<object, bool> Valores = new Dictionary<object, bool>();
        public Dictionary<string, object> Parametros = new Dictionary<string, object>();
 

        public Filtro(string nombreColumna, string aliasColumna, List<Fila> valores)
        {
            try
            {
                NombreColumna = nombreColumna;
                AliasColumna = aliasColumna;

                valores.ForEach(delegate (Fila f)
                {
                    Valores.Add(f.Celda(NombreColumna), true);
                });
            }
            catch
            {

            }
        }

        public void ModificarFiltro(Object valor, bool filtro)
        {
            Valores[valor] = filtro;
        }

        public void DesactivarTodos()
        {
            List<object> llaves = Valores.Keys.ToList();

            foreach(object llave in llaves)
            {
                Valores[llave] = false;
            }
        }

        public void ActivarTodos()
        {
            List<object> llaves = Valores.Keys.ToList();

            foreach (object llave in llaves)
            {
                Valores[llave] = true;
            }
        }

        override public string ToString()
        {
            string equivalente = "";
            string nombreParametro = "";

            int index = 0;
            foreach(KeyValuePair<object, bool> val in Valores)
            {
                nombreParametro = "@" + NombreColumna + index.ToString();

                if ( index==0 && val.Value)
                {
                    equivalente += NombreColumna + "=" + nombreParametro;
                    Parametros.Remove(nombreParametro);
                    Parametros.Add(nombreParametro, val.Key);
                    index++;
                }
                else if(val.Value)
                {
                    equivalente += " OR " + NombreColumna + "=" + nombreParametro;
                    Parametros.Remove(nombreParametro);
                    Parametros.Add(nombreParametro, val.Key);
                    index++;
                }
            }

            if (equivalente.Equals(""))
                equivalente = NombreColumna + "=NULL"; 

            return equivalente;
        }
    }
}
