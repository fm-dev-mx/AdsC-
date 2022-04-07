using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class RelacionMaterialRfq  : ModeloMySql
    {
        public RelacionMaterialRfq()
        {
            Tabla = "relaciones_material_rfq";
        }

        static public RelacionMaterialRfq Modelo()
        {
            return new RelacionMaterialRfq();
        }

        public bool  VerificarEnlace(int idMaterial, int idRfq)
        {
            string query = "SELECT if(count(*) > 0, 1, 0) AS existe FROM audisel.relaciones_material_rfq where binary numero_parte = (SELECT binary numero_parte FROM material_proyecto WHERE id=@idMaterial) and id_rfq = @idRfq ";
            query += "and id_material_proyecto = @idMaterial;";

            ConstruirQuery(query);
            AgregarParametro("@idMaterial", idMaterial);
            AgregarParametro("@idRfq", idRfq);
            EjecutarQuery();
            return Convert.ToBoolean(LeerFilas()[0].Celda("existe"));

        }

        public void BorrarRelacion(string numeroParte, int idRfq, int idConcepto)
        {
            string query = "delete from relaciones_material_rfq where numero_parte = @numeroParte AND id_rfq =@rfq";
            query += " and id_concepto=@idConcepto";
            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@rfq", idRfq);
            AgregarParametro("@idConcepto", idConcepto);
            EjecutarQuery();
            LeerFilas();
        }

        public List<Fila> SeleccionarIdRequisicion(string numeroParte, int idConcepto)
        {
            string query = "select * from " + Tabla + " where numero_parte =@numeroParte and id_concepto=@idConcepto";
           
            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@idConcepto", idConcepto);
            EjecutarQuery();
            return LeerFilas();
        }

        public List<Fila> SeleccionarIdRequisiciones(string numeroParte, int idRfq)
        {
            string query = "select * from " + Tabla + " where numero_parte =@numeroParte and id_rfq=@idRfq";

            ConstruirQuery(query);
            AgregarParametro("@numeroParte", numeroParte);
            AgregarParametro("@idRfq", idRfq);
            EjecutarQuery();
            return LeerFilas();
        }
    
        /// <summary>
        /// Asigna los conceptos a las requisiciones contenidas dentro de un rfq.
        /// </summary>
        public void AsignarConceptosARequisiciones(int idRfq, int idMaterial)
        {
            string sql = "set sql_safe_updates = 0;";

            sql += "update material_proyecto " +
                "inner join relaciones_material_rfq on relaciones_material_rfq.id_material_proyecto = material_proyecto.id and " +
                "relaciones_material_rfq.id_rfq = @idRfq and material_proyecto.id = @idMaterial " +
                "inner join rfq_conceptos on rfq_conceptos.id = relaciones_material_rfq.id_concepto and rfq_conceptos.precio_unitario > 0 " +
                "set material_proyecto.rfq_concepto = relaciones_material_rfq.id_concepto;";

            sql += "set sql_safe_updates = 1;";

            ConstruirQuery(sql);
            AgregarParametro("@idRfq", idRfq);
            AgregarParametro("@idMaterial", idMaterial);
            EjecutarQuery();
        }

        public void BorrarRelacionesConRFQ(int idRfq)
        {
            string sql = "set sql_safe_updates = 0;";
            sql += "DELETE FROM " + Tabla + " WHERE id_rfq=@idRfq;";
            sql += "set sql_safe_updates = 1;";
            ConstruirQuery(sql);
            AgregarParametro("@idRfq", idRfq);
            EjecutarQuery();


        }
    }
}
