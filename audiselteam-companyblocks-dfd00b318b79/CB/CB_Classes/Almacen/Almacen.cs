using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CB_Base.Classes
{
    class Almacen : ModeloMySql
    {
        public Almacen()
        {
            Tabla = "material_proyecto";
        }
        
        static public Almacen Modelo()
        {
            return new Almacen();
        }

        public List<Fila> MaterialRecibido()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "RECIBIDO");
            parametros.Add("@estatusParcial", "PARCIALMENTE ENTREGADA");
            SeleccionarDatos("estatus_almacen = @estatus OR estatus_almacen = @estatusParcial", parametros);
            return Filas();
        }

        public List<Fila> MaterialEntregado()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "ENTREGADO");
            SeleccionarDatos("estatus_almacen = @estatus", parametros);
            return Filas();
        }

        public DataGridViewCellStyle ColorEstatusAlmacen(string estatus)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            switch (estatus)
            {
                case "RECIBIDO":
                    style.BackColor = Color.LightGreen;
                    style.ForeColor = Color.Black;
                    break;
                case "PARCIALMENTE ENTREGADA":
                    style.BackColor = Color.Yellow;
                    style.ForeColor = Color.Black;
                    break;
            }
            return style;
        }
    }

}
