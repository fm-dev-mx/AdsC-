using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CB_Base.Classes;

namespace CB
{

    public class OrdenTrabajo : ModeloMySql
    {
        public OrdenTrabajo()
        {
            Tabla = "ordenes_trabajo";
        }

        public List<Fila> SeleccionarOrdenesExternas(double proyecto = 0.0)
        {
            string condicionProyecto = "";

            if (proyecto > 0.0)
                condicionProyecto = "proyecto=@proyecto AND ";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", proyecto);
            parametros.Add("@convencional", "CONVENCIONAL");
            parametros.Add("@cnc", "MAQUINADO CNC");
            parametros.Add("@noAsignado", "NO ASIGNADO");

            SeleccionarDatos(condicionProyecto + "proveedor!=@convencional AND proveedor!=@cnc AND proveedor!=@noAsignado", parametros);
            return Filas();
        }

        public double CostoTotal(int id=0)
        {
            Fila ordenTrabajo; // aqui guardaremos la orden de trabajo sobre la cual calcularemos el costo total

            // si el usuario no provee un id calcularemos el total sobre la primera fila de los
            // datos seleccionados, de lo contrario buscaremos el id indicado en los datos
            // seleccionados
            if (id == 0)
                ordenTrabajo = Fila();
            else
            {
                ordenTrabajo = BuscarDato(id);

                // si no se encuentra la orden de trabajo, se deben cargar primero los datos en base al id
                // proporcionado
                if (ordenTrabajo == null)
                {
                    CargarDatos(id);
                    ordenTrabajo = Fila();
                }
            }


            // obtener el id de la orden y el nombre del proveedor asignado a esta
            string nombreProveedor = ordenTrabajo.Celda("proveedor").ToString();
            int idOrdenTrabajo = Convert.ToInt32(ordenTrabajo.Celda("id"));
                
            // aquí guardaremos el costo total de la orden despues de calcularlo
            double totalOrden = 0.0;

            // cargamos el proveedor de la base de datos de acuerdo al nombre
            Proveedor proveedorOrden = new Proveedor();
            proveedorOrden.SeleccionarPorNombre(nombreProveedor, "id");

            // si encontramos al proveedor...
            if (proveedorOrden.TieneFilas())
            {
                // obtenemos el id del proveedor
                int idProveedor = Convert.ToInt32(proveedorOrden.Fila().Celda("id"));

                // cargamos la cotización (mqr) de la bd, el cual debe estar vinculado con
                // esta orden y con este proveedor
                Mqr cotizacion = new Mqr();
                cotizacion.SeleccionarProveedorOrden(idProveedor, idOrdenTrabajo);

                // si encontramos la cotizacion...
                if (cotizacion.TieneFilas())
                {
                    // obtenemos su id
                    int idCotizacion = Convert.ToInt32(cotizacion.Fila().Celda("id"));

                    // cargamos el concepto de la orden de trabajo desde la bd de acuerdo al id de la orden
                    OrdenConcepto conceptoOrdenTrabajo = new OrdenConcepto();

                    // por cada concepto de la orden de trabajo...
                    foreach (Fila conceptoActual in OrdenConcepto.Modelo().SeleccionarDeOrden(idOrdenTrabajo) )
                    {
                        // obtenemos el id del concepto de la orden de trabajo y la cantidad de piezas
                        int idOrdenConcepto = Convert.ToInt32(conceptoActual.Celda("id"));
                        double cantidadPiezas = Convert.ToDouble(conceptoActual.Celda("cantidad"));

                        // cargamos el concepto del mqr vinculado con el concepto de la orden de trabajo y con el id de la cotizacion
                        MqrConcepto mqr_concepto = new MqrConcepto();
                        mqr_concepto.SeleccionarOrdenConceptoMqr(idOrdenConcepto, idCotizacion);

                        // si encontramos el concepto
                        if (mqr_concepto.TieneFilas())
                        {
                            // calculamos el precio total de este concepto y lo agregamos al total de la orden
                            double precio_final = Convert.ToDouble(mqr_concepto.Fila().Celda("precio_final"));
                            totalOrden += precio_final * cantidadPiezas;
                        }
                    }
                }
            }
            // devolvemos el total calculado...
            return totalOrden;
        }

        public List<Fila> Pendientes()
        {
            Dictionary<string, Object> parametros = new Dictionary<string, object>();
            parametros.Add("@estatus", "PENDIENTE");
            SeleccionarDatos("estatus=@estatus", parametros);
            return Filas();
        }


        static public OrdenTrabajo Modelo()
        {
            return new OrdenTrabajo();
        }
    }
}
