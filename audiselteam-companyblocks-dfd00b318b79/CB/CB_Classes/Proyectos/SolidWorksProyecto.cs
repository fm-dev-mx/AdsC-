using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CB_Base.Classes
{
    class SolidWorksProyecto : ModeloMySql
    {

        public SolidWorksProyecto()
        {
            Tabla = "solidworks_proyecto";
        }

        static public SolidWorksProyecto Modelo()
        {
            return new SolidWorksProyecto();
        }

        public List<Fila> SeleccionarPorAprobar(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@estatus_revision", "ACEPTADO");
            parametros.Add("@estatus_aprobacion", "PENDIENTE");
            parametros.Add("@subensamble", subensamble);
            //parametros.Add("@CP", "\\CP\\");
            //parametros.Add("@MP", "\\MP\\");

            string sql = "proyecto=@proyecto AND ";
            sql += "subensamble=@subensamble AND ";
            sql += "estatus_aprobacion=@estatus_aprobacion AND ";
            sql += "estatus_revision=@estatus_revision";
            //sql += "(LOCATE(@CP, nombre_archivo) > 0 OR LOCATE(@MP, nombre_archivo) > 0)";

            return SeleccionarDatos(sql, parametros);
        }

        public List<Fila> ExisteRegistro(decimal proyecto, int subensamble, ArchivoSolidWorks archivo)
        {
            List<Fila> registros = new List<Fila>();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@nombre_archivo", archivo.RutaParcial);
            SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND nombre_archivo=@nombre_archivo", parametros);

            //checar si existe
            Filas().ForEach(delegate (Fila f)
            {
                registros.Add(f);
            });

            return registros;
        }

        public void RegistrarArchivo(decimal proyecto, int subensamble, ArchivoSolidWorks archivo)
        {
            //Registrar uno nuevo
            Fila f = new Fila();
            f.AgregarCelda("proyecto", proyecto);
            f.AgregarCelda("subensamble", subensamble);
            f.AgregarCelda("nombre_archivo", archivo.RutaParcial);
            f.AgregarCelda("checksum_md5", archivo.ChecksumMd5);
            f.AgregarCelda("kilobytes", archivo.Kilobytes());

            if (Path.GetExtension(archivo.Nombre.ToUpper()) == ".SLDDRW" &&
                (archivo.RutaParcial.Contains("\\CP\\") || archivo.RutaParcial.Contains("\\MP\\")))
            {
                f.AgregarCelda("estatus_revision", "PENDIENTE");
                f.AgregarCelda("estatus_aprobacion", "PENDIENTE");
            }
            else
            {
                f.AgregarCelda("estatus_revision", "N/A");
                f.AgregarCelda("estatus_aprobacion", "N/A");
            }

            f.AgregarCelda("comentarios_revision", "");
            f.AgregarCelda("estatus_sincronizacion", "NUEVO");

            Modelo().Insertar(f);
        }

        public void ActualizarArchivo(decimal proyecto, int subensamble, string nombreArchivo, ArchivoSolidWorks archivo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@nombre_archivo", nombreArchivo);
            SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND nombre_archivo=@nombre_archivo", parametros);

            if(TieneFilas())
            {
                Fila().ModificarCelda("checksum_md5", archivo.ChecksumMd5);
                Fila().ModificarCelda("kilobytes", archivo.Kilobytes());

                if (Path.GetExtension(archivo.Nombre.ToUpper()) == ".SLDDRW")
                {
                    Fila().ModificarCelda("estatus_revision", "PENDIENTE");
                    Fila().ModificarCelda("estatus_aprobacion", "PENDIENTE");
                }
                else
                {
                    Fila().ModificarCelda("estatus_revision", "N/A");
                    Fila().ModificarCelda("estatus_aprobacion", "N/A");

                    // modificar estatus del drawing
                    SolidWorksProyecto drw = new SolidWorksProyecto();
                    parametros.Clear();
                    parametros.Add("@nombre_archivo", Regex.Replace(nombreArchivo, ".SLDPRT", ".SLDDRW", RegexOptions.IgnoreCase));

                    drw.SeleccionarDatos("nombre_archivo=@nombre_archivo", parametros);

                    if(drw.TieneFilas())
                    {
                        drw.Fila().ModificarCelda("estatus_revision", "PENDIENTE");
                        drw.Fila().ModificarCelda("estatus_aprobacion", "PENDIENTE");

                        drw.GuardarDatos();
                    }
                    Fila().ModificarCelda("estatus_sincronizacion", "MODIFICADO");
                }
                GuardarDatos();
            }
        }

        public void BorrarArchivo(decimal proyecto, int subensamble, string nombreArchivo)
        {
            string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(nombreArchivo);
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@nombre_archivo", nombreArchivo);
            SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND nombre_archivo=@nombre_archivo", parametros);

            PlanoProyecto planos = new PlanoProyecto();
            parametros.Clear();
            parametros.Add("@nombre_archivo", nombreArchivoSinExtension);
            planos.SeleccionarDatos("nombre_archivo=@nombre_archivo", parametros);

            planos.Filas().ForEach(delegate(Fila f)
            {
                f.ModificarCelda("estatus", "POR DESCARTAR");
                f.ModificarCelda("estatus_ensamble", "DESCARTADO");
                f.ModificarCelda("usuario_descartado", Global.UsuarioActual.NombreCompleto());
                f.ModificarCelda("fecha_descartado", DateTime.Now);
            });
            planos.GuardarDatos();

            BorrarDatos();
        }

        public List<Fila> BuscarArchivo(decimal proyecto, int subensamble, string nombreArchivo)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@nombre_archivo", nombreArchivo);
            return SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND nombre_archivo=@nombre_archivo", parametros);
        }

        public List<Fila> SeleccionarProyectoSubensamble(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            return SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble ORDER BY nombre_archivo ASC", parametros);
        }

        public List<Fila> SeleccionarProyecto(decimal proyecto)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            return SeleccionarDatos("proyecto=@proyecto ORDER BY nombre_archivo ASC", parametros);
        }

        public List<Fila> SeleccionarProyectoSubensambleArchivosPendientes(decimal proyecto, int subensamble)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@subensamble", subensamble);
            parametros.Add("@estatus", "PENDIENTE");
            return SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND estatus_revision=@estatus ORDER BY nombre_archivo ASC", parametros);
        }

        public string RutaFtpPlano(int idPlano)
        {
            PlanoProyecto p = new PlanoProyecto();
            p.CargarDatos(idPlano);

            if (p.TieneFilas())
            {
                decimal idProyecto = Convert.ToDecimal(p.Fila().Celda("proyecto"));
                string strProyecto = idProyecto.ToString("F2").PadLeft(6, '0').Replace(".", "_");
                string raizFtp = strProyecto + "/M" + strProyecto;

                ConstruirQuery("SELECT * FROM solidworks_proyecto WHERE nombre_archivo LIKE '%" + p.Fila().Celda("nombre_archivo").ToString() + ".sldprt'");
                EjecutarQuery();
                LeerFilas();

                if (TieneFilas())
                    return raizFtp + Path.GetDirectoryName(Fila().Celda("nombre_archivo").ToString()) + "\\" + idPlano.ToString() + " " + p.Fila().Celda("nombre_archivo").ToString();
                else
                    return string.Empty;
            }
            else return string.Empty;
        }
    }
}
