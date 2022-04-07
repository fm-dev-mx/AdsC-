using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace CB_Base.Classes
{
    public class Archivo 
    {
        public string Nombre = string.Empty;
        public string NombreSinExtension = string.Empty;
        public string Raiz = string.Empty;
        public string RutaCompleta = string.Empty;
        public string RutaParcial = string.Empty;
        public string RutaParcialSinExtension = string.Empty;
        public string Tipo = string.Empty;
        public byte[] Datos = null;
        public string ChecksumMd5 = string.Empty;
        public float TamanoKilos = 0.0f;
        public long TamanoBytes = 0;

        public void CargarMetadatos(string ruta, string raiz)
        {
            // limpia los datos del archivo
            Nombre = string.Empty;
            NombreSinExtension = string.Empty;
            Raiz = string.Empty;
            RutaCompleta = string.Empty;
            RutaParcial = string.Empty;
            RutaParcialSinExtension = string.Empty;
            Tipo = string.Empty;
            Datos = null;
            ChecksumMd5 = string.Empty;

            // extraemos la info necesaria
            Nombre = Path.GetFileName(ruta);
            NombreSinExtension = Path.GetFileNameWithoutExtension(ruta);
            Raiz = raiz;
            RutaCompleta = ruta;
            RutaParcial = ruta.Replace(Raiz, string.Empty);
            RutaParcialSinExtension = Path.ChangeExtension(RutaParcial, null);
            Tipo = Path.GetExtension(ruta).Replace(".", string.Empty).ToUpper();
  
            try
            {
                // calcula el checksum 
                if(File.Exists(RutaCompleta))
                {
                    TamanoBytes = new System.IO.FileInfo(RutaCompleta).Length;
                    TamanoKilos = TamanoBytes / 1024.0f;
                    FileStream fs = File.Open(RutaCompleta, FileMode.Open, FileAccess.Read);
                    MD5CryptoServiceProvider sp = new MD5CryptoServiceProvider();
                    ChecksumMd5 = BitConverter.ToString(sp.ComputeHash(fs)).Replace("-", string.Empty).ToLower();
                    fs.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string Kilobytes()
        {
            //float tamanoKilos = 0;
            
            //if(Datos!= null)
            //    tamanoKilos = Datos.Length / 1024;

            return TamanoKilos.ToString("F2") + " KB";
        }

        public void SoloLectura(bool valor)
        {
            var attr = File.GetAttributes(RutaCompleta);

            if (valor)
                attr = attr | FileAttributes.ReadOnly;
            else
                attr = attr & ~FileAttributes.ReadOnly;
            File.SetAttributes(RutaCompleta, attr);
        }
        
    }
}
