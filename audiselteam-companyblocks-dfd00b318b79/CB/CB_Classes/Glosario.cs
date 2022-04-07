using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class Glosario
    {
        public static string DescripcionEtapa(int etapa)
        {
            switch (etapa)
            {
                case 0:
                    return "Concepto";

                case 1:
                    return "Diseño";

                case 2:
                    return "Material y planos";

                case 3:
                    return "Compras y maquinado";

                case 4:
                    return "Programacion, ensamble e integracion";

                case 5:
                    return "Validacion";

                case 6:
                    return "Entrega";

                default:
                    return "";
            }
        }

        public static string TipoOrden(int tipo)
        {
            switch(tipo)
            {
                case 0:
                    return "REGULAR";
                case 1:
                    return "WATER JET";
                case 2:
                    return "REWORK";
                case 3:
                    return "EXTRA WORK";
            }
            return "DESCONOCIDO";
        }
    }
}
