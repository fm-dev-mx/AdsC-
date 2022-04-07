using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public class MetaEntregable : ModeloMySql
    {

        public MetaEntregable()
        {
            Tabla = "metas_entregables";
        }

        static public MetaEntregable Modelo()
        {
            return new MetaEntregable();
        }

        public List<Fila> SeleccionarMetas(List<int> idMetas)
        {
            if (idMetas.Count <= 0)
            {
                return new List<Fila>();
            }
            string sql = "select metas_entregables.*,metas.proyecto,metas.fecha_promesa from metas_entregables,metas where metas_entregables.meta = metas.id and metas.id IN (";
            for(int i = 0; i < idMetas.Count; i++)
            {
                sql += idMetas[i].ToString();

                if (i < idMetas.Count - 1)
                {
                    sql += ",";
                }
                
            }
            sql.Remove(sql.Length - 1);
            sql += ")";

            ConstruirQuery(sql);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMeta(int idMeta, bool mostrarProyecto = false)
        {
            string query = "SELECT * FROM metas_entregables WHERE meta=@meta";

            if(mostrarProyecto)
            {
                query = "SELECT metas_entregables.*, metas.proyecto FROM metas_entregables, metas WHERE metas_entregables.meta=@meta AND metas.id = @meta AND metas_entregables.meta = metas.id";
            }

            ConstruirQuery(query);
            AgregarParametro("@meta", idMeta);
            EjecutarQuery();
            return LeerFilas();
        }

        public void BorrarEntregablesMeta(decimal idProyecto, int idMeta)
        {
            PlanoProyecto BuscadorPlanos = new PlanoProyecto();
            Modulo BuscadorModulos = new Modulo();

            // busca los entregables vinculados con la meta actual en la iteracion
            SeleccionarMeta(idMeta).ForEach(delegate(Fila entregable)
            {
                // identificamos el id y el tipo de entregable
                int idEntregable = Convert.ToInt32(entregable.Celda("id_entregable"));
                string tipoEntregable = entregable.Celda("tipo_entregable").ToString();

                // procesamos el entregable acorde a su tipo
                switch (tipoEntregable)
                {
                    case "MODULO FABRICADO":
                        // cargamos el modulo
                        BuscadorModulos.CargarDatos(idEntregable);

                        // si lo encontramos...
                        if (BuscadorModulos.TieneFilas())
                        {
                            // borramos la fecha promesa de fabricacion
                            BuscadorModulos.Fila().ModificarCelda("fecha_promesa_fabricacion", null);
                            BuscadorModulos.GuardarDatos();

                            // ubicamos el subensamble
                            int subensamble = Convert.ToInt32(BuscadorModulos.Fila().Celda("subensamble"));

                            // buscamos los planos vinculados con el modulo y 
                            // borramos la fecha promesa de fabricacion de cada plano encontrado
                            BuscadorPlanos.SeleccionarPlanosDeModulo(idProyecto, subensamble).ForEach(delegate(Fila plano)
                            {
                                plano.ModificarCelda("fecha_promesa_fabricacion", null);
                            });
                            BuscadorPlanos.GuardarDatos();
                        }
                        break;

                    case "PARTE FABRICADA":
                        // cargamos el plano vinculado con la meta (entregable) y le borramos la fecha promesa de fabricacion
                        BuscadorPlanos.CargarDatos(idEntregable).ForEach(delegate(Fila plano)
                        {
                            plano.ModificarCelda("fecha_promesa_fabricacion", null);
                        });
                        BuscadorPlanos.GuardarDatos();
                        break;
                }
            });
            BorrarDatos(); // borramos todos los entregables vinculados con cada meta
        }

        public int BuscarMetaDelEntregable(string tipoEntregable, int idEntregable)
        {
            string sql = "SELECT * FROM metas_entregables WHERE ";
            sql += "tipo_entregable=@tipo_entregable AND id_entregable=@id_entregable";
            ConstruirQuery(sql);
            AgregarParametro("@tipo_entregable", tipoEntregable);
            AgregarParametro("@id_entregable", idEntregable);
            EjecutarQuery();
            LeerFilas();

            if (TieneFilas())
                return Convert.ToInt32(Fila().Celda("meta"));
            else
                return 0;
        }

        public List<Fila> BuscarMetaDeModuloFabricado(string tipoEntregable, int idEntregable)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE tipo_entregable=@tipoEntregable AND id_entregable=@idEntregable";
            ConstruirQuery(sql);
            AgregarParametro("@tipoEntregable", tipoEntregable);
            AgregarParametro("@idEntregable", idEntregable);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarMetasQueContienenPiezasDeFabricante(string fabricante)
        {
            return new List<Fila>();
          /*  string query = "(select distinct metas_entregables.meta from metas_entregables, material_fabricantes where  " +
                            "material_fabricantes.id = metas_entregables.id_entregable and metas_entregables.meta in (SELECT id from metas where proceso = 3 and avance < 100) " +
                            "and tipo_entregable = 'MATERIAL DE FABRICANTE' and material_fabricantes.fabricante = 'MC MASTER') " +
                            "union " +
                            "(select metas_entregables.meta from metas_entregables, material_proyecto where material_proyecto.fabricante = 'MC MASTER' and " +
                            "tipo_entregable = 'MATERIAL DE REQUISICION' and metas_entregables.id_entregable = material_proyecto.id and " +
                            "metas_entregables.id_entregable in (select id from material_proyecto where id in (select id_entregable from metas_entregables))) " +
                            "union " +
                            "(select distinct metas_entregables.meta FROM  metas_entregables " +
                            "inner join modulos ON modulos.id = metas_entregables.id_entregable " +
                            "where metas_entregables.tipo_entregable = 'MATERIAL DE MODULO' and metas_entregables.id_entregable IN (" +
                            "select distinct modulos.id from material_proyecto " +
                            "INNER JOIN modulos ON material_proyecto.subensamble = modulos.subensamble and material_proyecto.proyecto = modulos.proyecto " +
                            "where material_proyecto.fabricante = 'MC MASTER'))";

            ConstruirQuery(sql);
            AgregarParametro("@tipoEntregable", tipoEntregable);
            AgregarParametro("@idEntregable", idEntregable);
            EjecutarQuery();
            return LeerFilas();*/
        }
    }
}
