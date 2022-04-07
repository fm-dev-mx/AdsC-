using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class PerfilPuesto : ModeloMySql
    {
        public PerfilPuesto()
        {
            Tabla = "perfiles_puestos";
        }

        static public PerfilPuesto Modelo()
        {
            return new PerfilPuesto();
        }

        public List<Fila> Cargar(string rol, int nivel)
        {
            ConstruirQuery("SELECT * FROM perfiles_puestos WHERE rol=@rol AND nivel=@nivel");
            AgregarParametro("@rol", rol);
            AgregarParametro("@nivel", nivel);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarPuestosOrdenadoPorNivel()
        {
            ConstruirQuery("SELECT * FROM perfiles_puestos order by rol asc, nivel asc");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> Subordinados(string rol, int nivel)
        {
            ConstruirQuery("SELECT * FROM perfiles_puestos WHERE coordinador=@rol AND nivel_coordinador=@nivel ORDER by rol ASC");
            AgregarParametro("@rol", rol);
            AgregarParametro("@nivel", nivel);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<string> Departamentos()
        {
            List<string> departamentos = new List<string>();

            ConstruirQuery("SELECT DISTINCT departamento FROM perfiles_puestos");
            EjecutarQuery();
            LeerFilas().ForEach(delegate(Fila f)
            {
                departamentos.Add(f.Celda("departamento").ToString());
            });
            return departamentos;
        }

        public List<Fila> buscarRolDepartamento(string departamento)
        {
            if (departamento == "TODOS")
                return null;

            ConstruirQuery("SELECT * FROM perfiles_puestos WHERE departamento=@departamento");
            AgregarParametro("@departamento", departamento);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarDepartamentos()
        {
            ConstruirQuery("SELECT distinct perfiles_puestos.departamento FROM perfiles_puestos inner Join roles ON perfiles_puestos.rol=roles.rol where departamento!=''");
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> CargarDepartamentoDeRol(string rol)
        {
            ConstruirQuery("SELECT distinct(departamento) FROM " + Tabla + " where rol=@rol");
            AgregarParametro("@rol", rol);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> TodosLosPuestos()
        {
            ConstruirQuery("SELECT distinct(rol) FROM " + Tabla + " ORDER BY rol ASC");
            EjecutarQuery();
            return LeerFilas();
        }
    }
}
