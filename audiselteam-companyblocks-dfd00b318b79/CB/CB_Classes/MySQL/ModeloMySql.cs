/*============================================================================= 
 * Esta clase tiene como objetivo interactuar de forma estandarizada con
 * bases de datos MySQL. Permite abstraer algunas operaciones SQL básicas como:
 * 
 *    INSERT
 *    SELECT
 *    UPDATE
 *    DELETE
 * 
 * @author Sergio Cazares
 * @date   May 11, 2017
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.ComponentModel;

namespace CB_Base.Classes
{
    public class ValoresComboBox
    {
        public object Valor { get; set; }
        public object Texto { get; set; }

        public ValoresComboBox(object valor, object texto)
        {
            Valor = valor;
            Texto = texto;
        }
    }


    public class ModeloMySql
    {
        public List<Filtro> Filtros = new List<Filtro>();
        public string Tabla = "";
        protected List<Fila> ListaFilas = new List<Fila>();
        protected MySqlConnection Conexion;
        protected MySqlCommand Comando;
        public MySqlDataReader Lector;
        public Dictionary<string, object> ParametrosFiltros = new Dictionary<string, object>();
    

        public List<Fila> Filas()
        {
            return ListaFilas;
        }

        ~ModeloMySql()
        {
            Cerrar();
        }

        public bool TieneFilas()
        {
            return ListaFilas.Count > 0;
        }

        public Fila Fila()
        {
            if (ListaFilas.Count <= 0)
            {
                //string errorLectura = "";
                //errorLectura += "Modelo::Datos(): Error al intentar leer datos que no existen. Verifica el siguiente query:" + Environment.NewLine;
                //errorLectura += Environment.NewLine + Comando.CommandText;
                //MessageBox.Show(errorLectura);
                return new Fila();
            }

            try
            {
                return ListaFilas[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return new Fila();
       }

        public void ConstruirQuery(string sql)
        {
            try
            {
                Conexion = new MySqlConnection(Global.ConnectionString);
                Conexion.Open();
                Comando = new MySqlCommand(sql, Conexion);
            }
            catch (Exception ex)
            {
                if(ex!=null)
                {
                    if (ex.InnerException is System.Net.Sockets.SocketException)
                    {
                        MessageBox.Show("No se puede conectar con la base de datos, verifica la configuración. La aplicación se cerrará.", "Sin conexión", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else
                        MessageBox.Show(ex.InnerException.GetType().ToString());
                }
            }
        }

        public List<Fila> SeleccionarDatos(string condiciones, IDictionary<string, Object> parametros = null, string columnas = "*", BackgroundWorker bkg=null)
        {
            int TotalFilas = 0; 
            string condicionesFiltros = CondicionesFiltros();
            string sqlConteo = "SELECT COUNT(*) AS total_filas FROM " + Tabla;
            string sql = "SELECT " + columnas + " FROM " + Tabla;

            if (!condiciones.Equals("") || !condicionesFiltros.Equals(""))
            {
                sql += " WHERE ";
                sqlConteo += " WHERE ";

                if (!condiciones.Equals(""))
                {
                    sql += condiciones;
                    sqlConteo += condiciones;

                    if (!condicionesFiltros.Equals(""))
                    {
                        sql += " AND " + condicionesFiltros;
                        sqlConteo += " AND " + condicionesFiltros;
                    }
                }
                else
                {
                    if (!condicionesFiltros.Equals(""))
                    {
                        sql += condicionesFiltros;
                        sqlConteo += condicionesFiltros;
                    }
                }
            } 
            
            // Construimos y ejecutamos primero el query para contar el total de filas que arrojara MySQL 
            // de acuerdo a las condiciones planteadas
            ConstruirQuery(sqlConteo);

            // Si el usuario pasa parametros, los considera en el query
            if (parametros != null)
            {
                foreach (KeyValuePair<string, Object> param in parametros)
                {
                    AgregarParametro(param.Key, param.Value);
                }
            }

            if (!condicionesFiltros.Equals(""))
            {
                foreach (KeyValuePair<string, object> param in ParametrosFiltros)
                {
                    AgregarParametro(param.Key, param.Value);
                }
            }
            EjecutarQuery();
            List<Fila> Conteo = LeerFilas();

            // Guardamos el conteo de filas
            if(Conteo.Count > 0)
                TotalFilas = Convert.ToInt32(Conteo[0].Celda("total_filas"));

            // Construimos y ejecutamos el query principal
            ConstruirQuery(sql);

            // Si el usuario pasa parametros, los considera en el query
            if (parametros != null)
            {
                foreach (KeyValuePair<string, Object> param in parametros)
                {
                    AgregarParametro(param.Key, param.Value);
                }
            }
            
            if(!condicionesFiltros.Equals(""))
            {
                foreach (KeyValuePair<string, object> param in ParametrosFiltros)
                {
                    AgregarParametro(param.Key, param.Value);
                }
            }
            
            EjecutarQuery();
            return LeerFilas(bkg, TotalFilas);
        }

        public void AgregarParametro(string nombreParametro, Object valor)
        {
            try
            {
                if(Comando != null)
                    if(Comando.Parameters != null)
                        Comando.Parameters.AddWithValue(nombreParametro, valor);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool ContieneParametro(string nombreParametro)
        {
            return Comando.Parameters.Contains(nombreParametro);
        }

        public void BorrarParametros()
        {
            try
            {
                Comando.Parameters.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void EjecutarQuery()
        {
            try
            {
                if(Comando!=null)
                {
                    Comando.CommandTimeout = 200;
                    Lector = Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public List<Fila> LeerFilas(BackgroundWorker bkg=null, int total=0)
        {
            List<Fila> filas = new List<Fila>();   // Guardaremos aqui todas las filas
            Object valorCelda = 0;                 // Valor temporal de cada celda

            try
            {
                if(Lector != null)
                {
                    // Por cada fila en el resultado del query
                    int iteracion = 0;
                    while (Lector.Read())
                    {
                        // Prepara el objeto de la fila
                        Fila filaIteracion = new Fila();

                        // Por cada columna en esta fila
                        for (int i = 0; i < Lector.FieldCount; ++i)
                        {
                            // Obtiene el nombre del tipo de dato
                            string tipoDeDato = Lector.GetDataTypeName(i);

                            // Obtiene el nombre de la columna
                            string nombreColumna = Lector.GetName(i);

                            // Revisa el valor de la celda en la bd y evita leer valores tipo null
                            if (Lector[i] == DBNull.Value)
                            {
                                filaIteracion.AgregarCelda(nombreColumna, null);  // agrega valor tipo null sin leerlo de la bd (evita excepcion)
                                continue;                                         // continua con la siguiente celda
                            }

                            // Si continuamos en este punto estamos listos para leer el valor de la bd
                            // Manda llamar la funcion correspondiente de acuerdo al tipo de dato
                            //
                            // NOTA: es posible que en el futuro se requiera agregar soporte para otros tipos de dato
                            //
                            switch (tipoDeDato)
                            {
                                case "NULL":
                                    valorCelda = null;
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;

                                case "VARCHAR":
                                    valorCelda = Lector.GetString(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;

                                case "TINYINT":
                                    valorCelda = Lector.GetBoolean(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;
                                case "BIT":
                                case "BIGINT":
                                case "INT":
                                    valorCelda = Lector.GetInt32(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;

                                case "DECIMAL":
                                    valorCelda = Lector.GetDouble(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;

                                case "FLOAT": //C. Laborde, Julio 10 2018
                                    valorCelda = Lector.GetFloat(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;

                                case "DOUBLE": //S. Cazares, Abril 01 2019
                                    valorCelda = Lector.GetDouble(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;

                                case "TIME": // c. laborde, Enero 31 2019
                                    valorCelda = Lector.GetTimeSpan(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;
                                case "TIMESTAMP":
                                case "DATE": // S. Cazares, Mayo 19 2017
                                case "DATETIME":
                                    valorCelda = Lector.GetDateTime(i);
                                    filaIteracion.AgregarCelda(nombreColumna, valorCelda);
                                    break;

                                case "BLOB": // S. Cazares, Mayo 19 2017
                                case "LONGBLOB":
                                    byte[] archivo = Lector[nombreColumna] as byte[];
                                    filaIteracion.AgregarCelda(nombreColumna, archivo);
                                    break;
                            }
                        }
                        // agrega esta fila a la lista
                        filas.Add(filaIteracion);

                        iteracion++;

                        // actualiza progreso (si es necesario)
                        if (bkg != null && total > 0)
                        {
                            decimal ratio = ((decimal)iteracion / (decimal)total);
                            decimal progreso = ratio * 100;
                            int iProgreso = (int)Math.Ceiling(progreso);

                            bkg.ReportProgress(iProgreso, filaIteracion);
                        }
                    }
                }
                Cerrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            ListaFilas = filas;
            return filas;
        }

        public void Cerrar()
        {
            try
            {
                if(Lector != null)
                    Lector.Close();

                if(Conexion != null)
                    Conexion.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public Fila BuscarDato(int id)
        {
            Fila datoEncontrado = null;

            foreach(Fila filaActual in ListaFilas)
            {
                if (Convert.ToInt32(filaActual.Celda("id")) == id)
                    datoEncontrado = filaActual;
            }

            return datoEncontrado;
        }
      
        public List<Fila> CargarDatos(int id, string datos = "*")
        {
            try
            {
                string condicionesFiltros = CondicionesFiltros();
                string sql = "SELECT " + datos + " FROM " + Tabla + " WHERE id=@id";

                if (!condicionesFiltros.Equals(""))
                    sql += " AND " + condicionesFiltros;

                ConstruirQuery(sql);

                AgregarParametro("@id", id);

                if(!condicionesFiltros.Equals(""))
                {
                    foreach(KeyValuePair<string, object> param in ParametrosFiltros)
                    {
                        AgregarParametro(param.Key, param.Value);
                    }
                }

                EjecutarQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
              
            return LeerFilas();
        }

        public string GuardarDatos()
        {
            return GuardarDatos("id");
        }

        public string GuardarDatos(string columnaPrimaria)
        {
            object updateId = 0;
            string sql = "";

            try
            {
                foreach(Fila filaActual in ListaFilas)
                {
                    if (!filaActual.FueModificada())
                        continue;

                    updateId = filaActual.Celda(columnaPrimaria);

                    sql = "UPDATE " + Tabla + " SET ";

                    int indice = 1;
                    foreach (KeyValuePair<string, Object> cell in filaActual.Celdas())
                    {
                        sql += cell.Key + "=@" + cell.Key;

                        if ( indice < filaActual.Celdas().Count )
                        {
                            sql += ", ";
                        }
                        indice++;
                    }

                    sql += " WHERE " + columnaPrimaria + "=@" + columnaPrimaria;

                    ConstruirQuery(sql);

                    foreach (KeyValuePair<string, Object> cell in filaActual.Celdas())
                    {
                        AgregarParametro("@" + cell.Key, cell.Value);
                    }

                    EjecutarQuery();
                    Cerrar();

                    filaActual.MarcarModificada(false);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return sql;
        }

        public Fila Insertar(Fila datosInsertar)
        {
            // construye el comando para insertar la fila en bd
            string sql = "INSERT INTO " + Tabla;
            long idInsertado = 0;

            sql += "(";
            foreach(KeyValuePair<string, Object> columna in datosInsertar.Celdas())
            {
                sql += columna.Key;

                if (!columna.Equals(datosInsertar.Celdas().Last()))
                    sql += ", ";
            }
            sql += ") VALUES(";

            foreach (KeyValuePair<string, Object> columna in datosInsertar.Celdas())
            {
                sql += "@" + columna.Key;

                if (!columna.Equals(datosInsertar.Celdas().Last()))
                    sql += ", ";
            }
            sql += ")";

            ConstruirQuery(sql);

            foreach (KeyValuePair<string, Object> columna in datosInsertar.Celdas())
            {
                AgregarParametro("@" + columna.Key, columna.Value);
            }

            EjecutarQuery();
            idInsertado = Comando.LastInsertedId;
            Cerrar();

            // agrega el id a los datos que se insertaron
            datosInsertar.AgregarCelda("id", idInsertado);

            // guarda la fila insertada en la lista local
            ListaFilas.Add(datosInsertar);

            // retorna con los datos que se insertaron incluyendo el id
            return datosInsertar;
        }

        public int BorrarDatos(int id=0)
        {
            // crear una lista donde guardaremos las filas que fueron borradas
            List<Fila> filasBorradas = new List<Fila>();

            // por cada fila en la lista de filas cargadas previamente
            foreach(Fila filaActual in ListaFilas)
            {
                // verifica el id de la fila actual
                int idActual = Convert.ToInt32(filaActual.Celda("id"));

                // si se provee un id en especifico para borrar y el id de la fila actual
                // no corresponde con este, continua a la siguiente iteracion
                if (id != 0 && id != idActual)
                    continue;

                // si continuamos aqui deberemos borrar esta fila en bd, ejecuta el query 
                // correspondiente
                ConstruirQuery("DELETE FROM " + Tabla + " WHERE id=@id");
                BorrarParametros();
                AgregarParametro("@id", idActual);
                EjecutarQuery();
                Cerrar();

                // agrega la fila actual a la lista de filas borradas
                filasBorradas.Add(filaActual);
            }

            // por cada fila borrada
            foreach(Fila borrada in filasBorradas)
            {
                // eliminala de la lista local de filas
                ListaFilas.Remove(borrada);
            }

            // informa cuantas filas fueron borradas
            return filasBorradas.Count;
        }

        public void AgregarFiltro(Filtro f)
        {
            Filtros.Add(f);
        }

        public void AgregarFiltros(List<Filtro> filtros)
        {
            foreach(Filtro f in filtros)
            {
                Filtros.Add(f);
            }
        }

        public void QuitarFiltros()
        {
            Filtros.Clear();
        }

        public string CondicionesFiltros()
        {
            string condicionesFiltros = "";
            int index = 0;
            foreach (Filtro f in Filtros)
            {
                string strFiltro = f.ToString();

                if (index == 0 && !strFiltro.Equals(""))
                {
                    condicionesFiltros += "(" + strFiltro + ")";
                }
                else if (!strFiltro.Equals(""))
                {
                    if (!condicionesFiltros.Equals(""))
                        condicionesFiltros += " AND ";
                    condicionesFiltros += "(" + strFiltro + ")";
                }

                foreach (KeyValuePair<string, object> param in f.Parametros)
                {
                    ParametrosFiltros.Remove(param.Key);
                    ParametrosFiltros.Add(param.Key, param.Value);
                }

                index++;
            }
            return condicionesFiltros;
        }

        public bool ExisteValorColumna(string columna, Object valor)
        {
            string sql = "SELECT * FROM " + Tabla + " WHERE " + columna + "=@valor";
            ConstruirQuery(sql);
            AgregarParametro("@valor", valor);
            EjecutarQuery();
            LeerFilas();
            return (TieneFilas());
        }




        public List<ValoresComboBox> FilasParaComboBox(string columnaValor, string columnaTexto)
        {
            List<ValoresComboBox> valores = new List<ValoresComboBox>();

            foreach (Fila filaActual in Filas())
            {
                ValoresComboBox valoresActuales = new ValoresComboBox(filaActual.Celda(columnaValor), filaActual.Celda(columnaTexto));
                valores.Add(valoresActuales);
            }
            return valores;
        }
    }
}
