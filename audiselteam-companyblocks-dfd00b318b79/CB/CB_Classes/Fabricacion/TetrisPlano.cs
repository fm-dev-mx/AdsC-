using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class TetrisPlano : ModeloMySql
    {
        public TetrisPlano()
        {
            Tabla = "tetris_planos";
        }

        static public TetrisPlano Modelo()
        {
            return new TetrisPlano();
        }

        public List<Fila> SeleccionarTetris(int idTetris)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tetris", idTetris);
            return SeleccionarDatos("tetris=@tetris", parametros);
        }
    }
}
