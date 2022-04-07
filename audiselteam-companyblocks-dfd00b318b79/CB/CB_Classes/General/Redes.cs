using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CB_Base.Classes
{
    static class Redes
    {

        public static bool ExisteConexionInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ExisteConexion(string url)
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(url);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
