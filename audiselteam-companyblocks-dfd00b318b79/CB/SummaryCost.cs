using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    class CotizacionScopeRecursos
    {
        public string Proceso = "";
        public List<string> AlcanceTrabajo = new List<string>();
        public int Personas = 0;
        public double Horas = 0f;

        public string AlcanceTrabajoString {
            get {
                string temp = "";

                if(AlcanceTrabajo.Count > 1)
                {
                    for(int i = 0; i < AlcanceTrabajo.Count - 1; i++)
                    {
                        temp += AlcanceTrabajo[i] + " + ";
                    }
                }

                if(temp != "")
                    temp += AlcanceTrabajo[AlcanceTrabajo.Count - 1];

                return temp;
            }
        }

        public CotizacionScopeRecursos(string proceso, int personas, double horas, List<string> alcanceTrabajo)
        {
            Proceso = proceso;
            Personas = personas;
            Horas = horas;
            AlcanceTrabajo = alcanceTrabajo;
        }

    }

    class CotizacionPokaYokes
    {
        public string Target = "";
        public string Alcance = "";
        public string Metodo = "";

        public CotizacionPokaYokes(string target, string alcance, string metodo)
        {
            Target = target;
            Alcance = alcance;
            Metodo = metodo;
        }
    }

    class CotizacionProveedor
    { 
        public byte[] Imagen = null;
        public string Nombre = "";
        public string NumeroParte = "";
        public string Descripcion = "";

        public string DescripcionCorta {
            get {
                string temp = "";

                if (Descripcion.Length >= 50)
                {
                    temp = Descripcion.Substring(0, 50);
                    if(Descripcion.Length > 50)
                    {
                        temp += "...";
                    }
                }
                else
                {
                    temp = Descripcion;
                }

                return temp;
            }
        }

        public string InfoDespliegue
        { 
            get {
                return Nombre + "\n" + NumeroParte + "\n" + DescripcionCorta; 
            }
        }

        public CotizacionProveedor(string nombre, string numeroParte, string descripcion, byte[] imagen = null)
        {
            Nombre = nombre;
            NumeroParte = numeroParte;
            Descripcion = descripcion;

            Imagen = imagen;
        }
    }

    // =============================

    class ResumenCostoDesglose
    {
        public List<ResumenCostoCotizacion> cotizaciones = new List<ResumenCostoCotizacion>();
        public float descuento = 0f;

        public float SubTotal {
            get {
                
                float acumPrecio = 0f;
                
                foreach(ResumenCostoCotizacion cotizacion in cotizaciones)
                {
                    acumPrecio += cotizacion.PrecioTotal;
                }

                return acumPrecio;
            }
        }

        public float PrecioTotal {
            get {

                return this.SubTotal * (1 - this.descuento);

            }
        }

        public ResumenCostoDesglose(List<ResumenCostoCotizacion> cotizaciones, float descuento = 0f)
        {
            this.cotizaciones = cotizaciones;
            this.descuento = descuento;
        }
    }
    
    class ResumenCostoCotizacion
    {
        public List<ResumenCostoCategoria> categorias = new List<ResumenCostoCategoria>();
        public string nombre = "";
        public int tiempoEntrega = 0;

        public float PrecioTotal {
            get {

                float acumPrecio = 0f;

                for(int i = 0; i < this.categorias.Count; i++)
                {
                    acumPrecio += this.categorias[i].PrecioTotal;
                }

                return acumPrecio;
            }
        }

        public int TotalConceptos {
            get {
                int contConceptos = 0;

                foreach(ResumenCostoCategoria cat in categorias)
                { 
                    foreach(ResumenCostoConcepto con in cat.conceptos)
                    {
                        contConceptos++;
                    }
                }

                return contConceptos;
            }
        }

        public ResumenCostoCotizacion(string nombre, int tiempoEntrega, List<ResumenCostoCategoria> categorias)
        {
            this.tiempoEntrega = tiempoEntrega;
            this.categorias = categorias;
            this.nombre = nombre;
        }
    }

    class ResumenCostoCategoria
    {
        public List<ResumenCostoConcepto> conceptos = new List<ResumenCostoConcepto>();
        public string nombre = "";

        public float PrecioTotal {
            get {

                float acumPrecio = 0f;

                for(int i = 0; i < this.conceptos.Count; i++)
                {
                    acumPrecio += this.conceptos[i].PrecioTotal;
                }

                return acumPrecio;
            }
        }
    }

    class ResumenCostoConcepto
    {
        public string nombre = "";
        public float precioUnidad = 0f;
        public int qty = 1;

        public float PrecioTotal {
            get {
                return this.precioUnidad * this.qty;
            }
        }

        public ResumenCostoConcepto(string nombre, float precioUnidad, int qty)
        {
            this.nombre = nombre;
            this.precioUnidad = precioUnidad;
            this.qty = qty;
        }
    }
}
