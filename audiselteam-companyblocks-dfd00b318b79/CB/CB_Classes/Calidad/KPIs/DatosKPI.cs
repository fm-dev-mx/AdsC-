using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_Base.Classes
{
    public enum IntervaloKPI
    {
        Desconocido,
        Dia,
        Semana,
        Mes,
        Anio
    }

    public class DatosKPI
    {
        public ModeloMySql InterfaceBd = new ModeloMySql();

        public IndicadorProceso Indicador = new IndicadorProceso();
        public Proceso ProcesoDelIndicador = new Proceso();
        public Rol RolResponsableProceso = new Rol();

        public List<EstadisticaKPI> Estadisticas = new List<EstadisticaKPI>();
        public List<string> PuntosGrafica = new List<string>();
        public IntervaloKPI Intervalo = IntervaloKPI.Desconocido;
        public Decimal ValorIndicador = 0;

        public DateTime FechaInicio;
        public DateTime FechaFin;

        public DatosKPI(int idIndicador, DateTime fechaInicio, DateTime fechaFin)
        {
            // cargamos la informacion del indicador, del proceso correspondiente y del puesto responsable
            Indicador.CargarDatos(idIndicador);

            int idProceso = Convert.ToInt32(Indicador.Fila().Celda("proceso"));
            ProcesoDelIndicador.CargarDatos(idProceso);

            RolResponsableProceso.CargarDatos(Convert.ToInt32(ProcesoDelIndicador.Fila().Celda("puesto_responsable")));

            // configuramos el intervalo de evaluacion del indicador
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            CalcularIntervalo();

            // evaluamos, cargamos puntos de la grafica y obtenemos estadisticas
            EvaluarIndicador();
            CargarPuntosGrafica();
            CargarEstadisticas();
        }

        public void CalcularIntervalo()
        {
            if (FechaInicio == null || FechaFin == null)
            {
                Intervalo = IntervaloKPI.Desconocido;
                return;
            }

            if(FechaInicio == FechaFin)
                Intervalo = IntervaloKPI.Dia;
            else if(FechaInicio.AddDays(6) == FechaFin)
                Intervalo = IntervaloKPI.Semana;
            else if(FechaInicio.AddMonths(1) >= FechaFin.AddDays(-1))
                Intervalo = IntervaloKPI.Mes;
            else if(FechaInicio.AddMonths(12) >= FechaFin.AddDays(-1))
                Intervalo = IntervaloKPI.Anio;
            else
                Intervalo = IntervaloKPI.Desconocido;
        }

        public void EvaluarIndicador()
        {
            string sql = "CALL " + Indicador.Fila().Celda("formula_valor").ToString() + "(@fechaInicio, @fechaFin, @intervalo)";
            InterfaceBd.ConstruirQuery(sql);
            InterfaceBd.AgregarParametro("@fechaInicio", FechaInicio.Date);
            InterfaceBd.AgregarParametro("@fechaFin", FechaFin.Date);
            InterfaceBd.AgregarParametro("@intervalo", TextoIntervalo());
            InterfaceBd.EjecutarQuery();
            InterfaceBd.LeerFilas();

            if (InterfaceBd.TieneFilas())
            {
                object objValorIndicador = InterfaceBd.Fila().Celda("valor_indicador");

                if(objValorIndicador != null)
                    ValorIndicador = Convert.ToDecimal(objValorIndicador);

                Dictionary<string, object> estadisticaValorIndicador = new Dictionary<string, object>();
                estadisticaValorIndicador.Add("Valor del indicador:", (ValorIndicador.ToString("F2") + " " + Indicador.Fila().Celda("unidades").ToString()).Trim());

                Estadisticas.Add(new EstadisticaKPI(estadisticaValorIndicador));
            }
            else ValorIndicador = 0;
        }

        public void CargarPuntosGrafica()
        { 
            PuntosGrafica.Clear();

            string sql = "CALL " + Indicador.Fila().Celda("formula_grafica").ToString() + "(@fechaInicio, @fechaFin, @intervalo)";
            InterfaceBd.ConstruirQuery(sql);
            InterfaceBd.AgregarParametro("@fechaInicio", FechaInicio.Date);
            InterfaceBd.AgregarParametro("@fechaFin", FechaFin.Date);
            InterfaceBd.AgregarParametro("@intervalo", TextoIntervalo());
            InterfaceBd.EjecutarQuery();

            InterfaceBd.LeerFilas().ForEach(delegate(Fila f)
            {
                string datoEjeX = Global.ObjetoATexto(f.Celda("x"), "");
                decimal datoEjeY = Convert.ToDecimal(f.Celda("y"));
                PuntosGrafica.Add(datoEjeX + "|" + datoEjeY.ToString("F2"));
            });
        }

        public void CargarEstadisticas()
        {
            string nombreEstadistica = string.Empty;
            object valorEstadistica = null;
            string strValorEstadistica = string.Empty;
            string sql = string.Empty;

            IndicadorEstadistica.Modelo().SeleccionarIndicador(Convert.ToInt32(Indicador.Fila().Celda("id"))).ForEach(delegate(Fila f)
            {
                Dictionary<string, object> valoresEstadistica = new Dictionary<string, object>();

                sql = "CALL " + f.Celda("formula").ToString() + "(@fechaInicio, @fechaFin, @intervalo)";
                InterfaceBd.ConstruirQuery(sql);
                InterfaceBd.AgregarParametro("@fechaInicio", FechaInicio.Date);
                InterfaceBd.AgregarParametro("@fechaFin", FechaFin.Date);
                InterfaceBd.AgregarParametro("@intervalo", TextoIntervalo());
                InterfaceBd.EjecutarQuery();

                InterfaceBd.LeerFilas().ForEach(delegate(Fila resultadoFormula)
                {
                    nombreEstadistica = resultadoFormula.Celda("nombre_estadistica").ToString();
                    valorEstadistica = resultadoFormula.Celda("valor_estadistica");

                    if(valorEstadistica != null)
                    {
                        strValorEstadistica = valorEstadistica.ToString();

                        switch(f.Celda("formato").ToString())
                        {
                            case "MONEDA":
                                Decimal d = Convert.ToDecimal(strValorEstadistica);
                                strValorEstadistica = String.Format("{0:C}", d);
                                break;
                        }
                        strValorEstadistica = f.Celda("prefijo").ToString() + " " + strValorEstadistica + " " + f.Celda("unidades").ToString();
                    }

                    valoresEstadistica.Add(nombreEstadistica, strValorEstadistica);
                });

                Estadisticas.Add(new EstadisticaKPI(valoresEstadistica, f.Celda("categoria").ToString()));
            });
        }

        public string TextoIntervalo()
        {
            switch(Intervalo)
            {
                case IntervaloKPI.Dia:
                    return "DIA";

                case IntervaloKPI.Semana:
                    return "SEMANA";

                case IntervaloKPI.Mes:
                    return "MES";

                case IntervaloKPI.Anio:
                    return "AÑO";
            }
            return "DESCONOCIDO";
        }

        public string TituloGrafica()
        {
            string titulo = Indicador.Fila().Celda("nombre").ToString() + " POR " + TextoIntervalo();

            string unidades = Indicador.Fila().Celda("unidades").ToString().Trim();

            if (unidades != string.Empty)
                titulo += " (" + unidades + ")";

            return titulo;
        }

        public string TituloSeriePrincipal()
        {
            string titulo = Indicador.Fila().Celda("nombre").ToString();
            string unidades = Indicador.Fila().Celda("unidades").ToString().Trim();

            if (unidades != string.Empty)
                titulo += " (" + unidades + ")";

            return titulo;
        }

        public string TituloEjeX()
        {
            switch(Intervalo)
            {
                case IntervaloKPI.Dia:
                    return "HORAS";

                case IntervaloKPI.Semana:
                    return "DIAS";

                case IntervaloKPI.Mes:
                    return "SEMANAS";

                case IntervaloKPI.Anio:
                    return "MESES";
            }
            return "N/A";
        }

        public string TituloEjeY()
        {
            string titulo = Indicador.Fila().Celda("nombre").ToString();
            string unidades = Indicador.Fila().Celda("unidades").ToString().Trim();

            if (unidades != string.Empty)
                titulo += " (" + unidades + ")";

            return titulo;
        }
    }
}
