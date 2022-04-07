using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Direccion : ModeloMySql
    {

        public Direccion()
        {
            Tabla = "direcciones";
        }

        static public Direccion Modelo()
        {
            return new Direccion();
        }

        public List<Fila> SeleccionarNombre(string nombre)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("nombre", nombre);
            return SeleccionarDatos("nombre=@nombre", parametros);
        }

        public string EnTexto(string formato="MX")
        {
            string str = "";
            
            if( TieneFilas() )
            {
                if( formato == "MX")
                {
                    str += Fila().Celda("calle").ToString() + ", " + Fila().Celda("numero").ToString() + Environment.NewLine;
                    str += "CP. " + Fila().Celda("cp").ToString() + Environment.NewLine;
                    str += Fila().Celda("ciudad").ToString() + ", " + Fila().Celda("estado").ToString() + ". " + Fila().Celda("pais").ToString();
                }
                else if( formato == "US" )
                {
                    str += Fila().Celda("numero").ToString() + " " + Fila().Celda("calle").ToString() + Environment.NewLine;
                    str += "ZIP CODE " + Fila().Celda("cp").ToString() + Environment.NewLine;
                    str += Fila().Celda("ciudad").ToString() + ", " + Fila().Celda("estado").ToString() + ". " + Fila().Celda("pais").ToString();
                }
            }
            return str;
        }
    }
}
