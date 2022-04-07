using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class DocumentoSgc : ModeloMySql
    {
        public DocumentoSgc()
        {
            Tabla = "documentos_sgc";
        }

        static public DocumentoSgc Modelo()
        {
            return new DocumentoSgc();
        }

        public List<Fila> Departamentos()
        {
            string sql = "SELECT DISTINCT departamento FROM " + Tabla + " ORDER BY departamento ASC";
            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Documentos(string departamento)
        {
            string sql = string.Empty;

            if(departamento == "TODOS")
                sql = "SELECT * FROM " + Tabla + " order by tipo_archivo, consecutivo ASC";
            else
                sql = "SELECT * FROM " + Tabla + " WHERE departamento=@departamento order by tipo_archivo, consecutivo ASC";
            
            ConstruirQuery(sql);
            AgregarParametro("@departamento", departamento);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SelecionarDepartamento(string departamento)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE departamento=@departamento";
            ConstruirQuery(sql);
            AgregarParametro("@departamento", departamento);
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
