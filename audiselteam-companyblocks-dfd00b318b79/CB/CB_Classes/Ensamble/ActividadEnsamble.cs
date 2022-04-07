using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CB_Base.Classes
{
    class ActividadEnsamble : ModeloMySql
    {
        public ActividadEnsamble()
        {
            Tabla = "actividades_ensamble";
        }

        static public ActividadEnsamble Modelo()
        {
            return new ActividadEnsamble();
        }

        public List<Fila> CargarDatos(Decimal id)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id", id);
            return SeleccionarDatos("id=@id", parametros);
        }

        public List<Fila> Estatus()
        {
            string sql = "SELECT DISTINCT estatus FROM " + Tabla + " ORDER BY estatus ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> EstatusRevision()
        {
            string sql = "SELECT DISTINCT estatus_revision FROM " + Tabla + " ORDER BY estatus_revision ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Responsable(decimal proyecto)
        {
            string sql = "SELECT DISTINCT responsable FROM " + Tabla + " WHERE responsable!=@responsable AND estatus!=@estatus AND estatus!='N/A' ORDER by responsable ASC";
            ConstruirQuery(sql);
            AgregarParametro("@responsable", "N/A");
            AgregarParametro("@estatus", "SIN ASIGNAR");
            AgregarParametro("@proyecto", proyecto);
            EjecutarQuery();
            return LeerFilas();
        }

        public DataGridViewCellStyle ColorEstatusActividad(string estatus)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            switch (estatus)
            {
                case "TERMINADO":
                    style.BackColor = Color.LightGreen;
                    style.ForeColor = Color.Black;
                    break;

                case "EN PROCESO":
                    style.BackColor = Color.Yellow;
                    style.ForeColor = Color.Black;
                    break;

                case "DETENIDO":
                    style.BackColor = Color.OrangeRed;
                    style.ForeColor = Color.White;
                    break;

            }
            return style;
        }

        public DataGridViewCellStyle ColorEstatusRevision(string estatus)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();

            switch (estatus)
            {
                case "CUMPLE":
                    style.BackColor = Color.LightGreen;
                    style.ForeColor = Color.Black;
                    break;

                case "NO CUMPLE":
                    style.BackColor = Color.Red;
                    style.ForeColor = Color.White;
                    break;

                case "NO APLICA":
                    style.BackColor = Color.Yellow;
                    style.ForeColor = Color.Black;
                    break;

            }
            return style;
        }

        public List<Fila> TipoActividad()
        {
            string sql = "SELECT DISTINCT tipo FROM " + Tabla + " ORDER BY tipo ASC";          
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Proyecto()
        {
            string sql = "SELECT DISTINCT FORMAT(actividades_ensamble.proyecto, 2) AS proyecto FROM " + Tabla + " ORDER BY actividades_ensamble.proyecto ASC";
            ConstruirQuery(sql);
            EjecutarQuery();           
            return LeerFilas();
        }

        public List<Fila> ProyectoFiltro()
        {
            string sql = "SELECT DISTINCT FORMAT(actividades_ensamble.proyecto, 2) AS proyecto FROM " + Tabla + " WHERE estatus!=@estatus ORDER BY actividades_ensamble.proyecto ASC";
            ConstruirQuery(sql);
            AgregarParametro("@estatus", "TERMINADO");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ProyectoActividad(string responsable)
        {
            string sql = "SELECT DISTINCT FORMAT(actividades_ensamble.proyecto, 2) AS proyecto FROM " + Tabla + " WHERE actividades_ensamble.responsable=@responsable AND actividades_ensamble.estatus!=@estatus AND actividades_ensamble.estatus!='N/A' ORDER BY actividades_ensamble.proyecto ASC";
            ConstruirQuery(sql);
            AgregarParametro("@responsable", responsable);
            AgregarParametro("@estatus", "SIN ASIGNAR");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> ResponsableActividad(string responsable, decimal proyecto = 0)
        {        
            string sql = "SELECT * FROM " + Tabla + " WHERE responsable=@responsable AND (estatus!='TERMINADO' AND estatus!='SIN ASIGNAR') ORDER by fecha_promesa ASC";
            ConstruirQuery(sql);
            AgregarParametro("@responsable", responsable);
            AgregarParametro("@proyecto", proyecto);
            AgregarParametro("@estatus", "SIN ASIGNAR");
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
