/*============================================================================= 
 * Esta clase tiene como objetivo representar una Fila dentro de una tabla.
 * A los datos guardados en la fila se les llamará Celdas
 * 
 * @author Sergio Cazares
 * @date   May 11, 2017
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB_Base.Classes
{
    public class Fila
    {
        // Esta propiedad sirve para identificar cuando la celda fue modificada
        // Se pone a -true- de forma automática al llamar el metodo ModificarCelda()
        protected bool Modificada = false;     

        // Aqui guardaremos la relación columna-valor para representar las celdas
        // de esta fila
        public IDictionary<string, Object> DiccionarioCeldas = new Dictionary<string, Object>();


        /*=====================================================================
         * Retorna la propiedad -Modificada- de esta fila
         *=====================================================================*/
        public bool FueModificada()
        {
            return Modificada;
        }

        /*=====================================================================
         * Marca la propiedad -Modificada- de esta fila en true/false
         *=====================================================================*/
        public void MarcarModificada(bool iModificada)
        {
            Modificada = iModificada;
        }

        /*=====================================================================
         * Verifica si esta fila contiene una celda con el nombre de columna 
         * especificado
         *=====================================================================*/
        public bool TieneCelda(string nombreColumna)
        {
            return DiccionarioCeldas.ContainsKey(nombreColumna);
        }

        /*=====================================================================
         * Lee el valor de la celda indicada por el nombre de la columna y 
         * devuelve el objeto correspondiente.
         *=====================================================================*/
        public Object Celda(string nombreColumna)
        {
            Object result = 0;

            if(!TieneCelda(nombreColumna))
            {
                MessageBox.Show("Fila::Celda(string nombreColumna): Error al intentar leer una celda que no existe [" + nombreColumna + "].");
                return result;
            }

            try
            {
                result = DiccionarioCeldas[nombreColumna];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        public T Celda<T>(string nombreColumna)
        {
            T result = default(T);

            if (!TieneCelda(nombreColumna))
            {

                MessageBox.Show("Fila::Celda(string nombreColumna): Error al intentar leer una celda que no existe [" + nombreColumna + "].");              
                return result;
            }

            try
            {
                result = (T)DiccionarioCeldas[nombreColumna];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }

        /*=====================================================================
         * Retorna una lista de llaves-valores correspondientes a las celdas
         * de esta fila
         *=====================================================================*/
        public IDictionary<string, Object> Celdas()
        {
            return DiccionarioCeldas;
        }

        /*===================================================================== 
         * Agrega una celda a la lista
         *=====================================================================*/
        public void AgregarCelda(string nombreColumna, Object valor)
        {
            DiccionarioCeldas.Add(nombreColumna, valor);
        }

        /*=====================================================================
         * Modifica una la celda especificada asignandole el valor proporcionado 
         *=====================================================================*/
        public void ModificarCelda(string nombreColumna, Object valor)
        {
            try
            {
                DiccionarioCeldas[nombreColumna] = valor;
                Modificada = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public override String ToString()
        {
            string stringEquivalente = "";

            foreach(KeyValuePair<string, Object> celda in DiccionarioCeldas)
            {
                stringEquivalente += celda.Key + "=" + celda.Value;

                if (!celda.Equals(DiccionarioCeldas.Last()))
                {
                    stringEquivalente += ", ";
                }
            }
            return stringEquivalente;
        }
    }
}
