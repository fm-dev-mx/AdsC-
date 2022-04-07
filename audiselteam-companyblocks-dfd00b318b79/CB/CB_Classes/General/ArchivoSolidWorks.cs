using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FluentFTP;
using System.Windows.Forms;

namespace CB_Base.Classes
{
    public class ArchivoSolidWorks : Archivo
    {
        public string Categoria;
        public string EstatusServidor;
        public ConflictoSolidworks Conflicto = null;
        public FtpClient ClienteFtp = null;
        public decimal Proyecto = 0;
        public int Subensamble = 0;

        public string DeterminarEstatusServidor(decimal proyecto, int subensamble)
        {
            Proyecto = proyecto;
            Subensamble = subensamble;
            SolidWorksProyecto buscadorIndice = new SolidWorksProyecto();
            List<Fila> indiceServidor = buscadorIndice.BuscarArchivo(proyecto, subensamble, RutaParcial);

            List<Fila> ModuloDelArchivo = Modulo.Modelo().SeleccionarProyectoSubensamble(Proyecto, Subensamble);

            if (ModuloDelArchivo.Count > 0)
            {
                if (ModuloDelArchivo[0].Celda("estatus_aprobacion").ToString() == "APROBADO")
                {
                    EstatusServidor = "CONGELADO";
                    buscadorIndice = null;
                    indiceServidor = null;
                    return EstatusServidor;
                }
            } 

            if (indiceServidor.Count == 0)
            {
                EstatusServidor = "NUEVO";
            }
            else if (ChecksumMd5 != indiceServidor[0].Celda("checksum_md5").ToString())
            {
                if ((Tipo == "SLDPRT" || Tipo == "SLDDRW") && (RutaCompleta.Contains("CP") || RutaCompleta.Contains("MP")))
                    DeterminarConflicto();

                if (Conflicto == null)
                    EstatusServidor = "MODIFICADO";
                else
                    EstatusServidor = "EN CONFLICTO";
            }
            else if (ChecksumMd5 == indiceServidor[0].Celda("checksum_md5").ToString())
            {
                EstatusServidor = "SINCRONIZADO";
            }
            buscadorIndice = null;
            indiceServidor = null;
            return EstatusServidor;
        }

        public void DeterminarConflicto()
        {
            Conflicto = null;
            Modulo mod = new Modulo();
            mod.SeleccionarProyectoSubensamble(Proyecto, Subensamble);

            if(!mod.TieneFilas())
                return;

            int revisionModulo = Convert.ToInt32(mod.Fila().Celda("revision"));
            string strRevisionModulo = "-R" + (revisionModulo + 1).ToString().PadLeft(2, '0');

            PlanoProyecto pp = new PlanoProyecto();
            pp.ConstruirQuery("SELECT * FROM planos_proyectos WHERE nombre_archivo LIKE '" + NombreSinExtension + "%'");
            pp.EjecutarQuery();
            pp.LeerFilas();

            if(pp.TieneFilas() && !NombreSinExtension.EndsWith(strRevisionModulo))
            {
                Conflicto = new ConflictoSolidworks(TipoConflictoSolidworks.NUEVA_REVISION_REQUERIDA, revisionModulo+1, 0, Nombre);
            }
        }

        public void BorrarArchivosCache(string raizFtp, string extensiones=".PDF, .PNG, _MIN.PNG, _REV.PNG")
        {
            if (ClienteFtp == null)
                return;
            else if (!ClienteFtp.IsConnected)
                return;

            string rutaParcialSinExtension = Path.ChangeExtension(RutaParcial, null);

            foreach (string ext in extensiones.Split(','))
            {
                if (ClienteFtp.FileExists(raizFtp + rutaParcialSinExtension + ext.Trim()))
                    ClienteFtp.DeleteFile(raizFtp + rutaParcialSinExtension + ext.Trim());
            }
        }

        public void VincularArchivosCacheConPlano(string raizFtp, int idPlano, string extensiones = ".PDF, .PNG, _MIN.PNG, _REV.PNG")
        {
            if (ClienteFtp == null)
                return;
            else if (!ClienteFtp.IsConnected)
                return;

            string rutaParcialSinExtension = Path.ChangeExtension(RutaParcial, null);
            
            foreach (string extension in extensiones.Split(','))
            {
                if (ClienteFtp.FileExists(raizFtp + rutaParcialSinExtension + extension.Trim()))
                    ClienteFtp.Rename(raizFtp + rutaParcialSinExtension + extension.Trim(), raizFtp + rutaParcialSinExtension.Replace(NombreSinExtension, idPlano + " " + NombreSinExtension + extension.Trim()));
            }
        }

    }


    public enum TipoConflictoSolidworks {
        NINGUNO,
        NUEVA_REVISION_REQUERIDA
    };

    public class ConflictoSolidworks
    {
        protected TipoConflictoSolidworks Tipo = TipoConflictoSolidworks.NINGUNO;
        string NombreArchivo = string.Empty;
        int IdPlano = 0;
        int Revision = 0;
        private TipoConflictoSolidworks tipoConflictoSolidworks;

        public ConflictoSolidworks(TipoConflictoSolidworks tipo, int revision=0, int idPlano=0, string nombreArchivo="")
        {
            Tipo = tipo;
            IdPlano = idPlano;
            Revision = revision;
            NombreArchivo = nombreArchivo;
        }

        public ConflictoSolidworks(TipoConflictoSolidworks tipoConflictoSolidworks)
        {
            // TODO: Complete member initialization
            this.tipoConflictoSolidworks = tipoConflictoSolidworks;
        }

        public override string ToString()
        {
            string msg = "Conflicto desconocido";
            
            switch(Tipo)
            {
                case TipoConflictoSolidworks.NUEVA_REVISION_REQUERIDA:
                    msg = string.Empty;
                    msg += "El archivo requiere una nueva revisión. Renómbralo mediante SolidWorks explorer " + Environment.NewLine;
                    msg += "como '" + Path.GetFileNameWithoutExtension(NombreArchivo) + "-R" + Revision.ToString().PadLeft(2, '0') + Path.GetExtension(NombreArchivo) + "'";
                    break;
            }
            return msg;
        }
    }

}
