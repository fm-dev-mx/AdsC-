using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class Tetris : ModeloMySql
    {
        public Tetris()
        {
            Tabla = "tetris";
        }

        static public Tetris Modelo()
        {
            return new Tetris();
        }

        public List<Fila> SeleccionarPendientes(decimal proyecto, int modulo, decimal espesor, string material, string alcance)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@pendiente", "PENDIENTE");
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@modulo", modulo);
            parametros.Add("@espesor", espesor);
            parametros.Add("@material", material);
            string sqlCondicion = "";

            if(alcance == "MODULO")
                sqlCondicion  = "proyecto=@proyecto AND modulo=@modulo AND espesor_placa=@espesor AND estatus=@pendiente AND material=@material";
            else if(alcance == "PROYECTO")
                sqlCondicion = "proyecto=@proyecto AND modulo=0 AND espesor_placa=@espesor AND estatus=@pendiente AND material=@material";

            return SeleccionarDatos(sqlCondicion, parametros, "*");
        }
    }
}
