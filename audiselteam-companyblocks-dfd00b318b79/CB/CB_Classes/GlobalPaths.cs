using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.CB_Classes
{
    public static class GlobalPaths
    {
        public static string PathUtilidades 
        {
            get 
            {
                return System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\funcionamiento\";
            }
        }

        public static string ArchivoNotificacionesExcluidas 
        { 
            get
            {
                return "noti_excluidas.sgpnoti";
            }
        }
    }
}
