using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FluentFTP;
using System.Net;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmAsignarProcesoFabricacion : Ventana
    {
        public int IdProceso = 0;
        public int IdPlano = 0;
        byte[] ImagenPlano = null;

        public double TotalTiempoEstandar = 0;
        public string ComentariosSupervisor = string.Empty;
        public string Proceso = string.Empty;
        public string Herramenstista = string.Empty;
        public string MaquinaHerramienta = string.Empty;
        public string Complejidad = string.Empty;

        public List<Fila> DatosOperacion = new List<Fila>();
        PlanoProyecto Plano = new PlanoProyecto();

        public FrmAsignarProcesoFabricacion(int idProceso = 0, int idPlano = 0)
        {
            InitializeComponent();
            IdPlano = idPlano;
            
            if(idProceso > 0)
            {
                NumProceso.Value = idProceso;
                NumProceso.ReadOnly = true;
                NumProceso.Enabled = false;
                CargarProceso(idProceso);
                ComentariosSupervisor = TxtComentarios.Text;               
            }
        }

        private void FrmActualizarProcesoFabricacion_Load(object sender, EventArgs e)
        {
            Plano.CargarDatos(IdPlano);
            LblTiempoEstimado.Text = "";
            LblTiempoEstimadoTotal.Text = "";
            CmbMaquinas.SelectedIndex = 0;
            CargarOperaciones();
            CargarPlano();
        }

        private void CargarOperaciones()
        {
            ComboBox cmbOperaciones = new ComboBox();
            string proceso = TxtProceso.Text;

            OperacionFabricacion operaciones = new OperacionFabricacion();
            operaciones.SeleccionarOperaciones(proceso).ForEach(delegate(Fila f)
            {
                cmbOperaciones.Items.Add(f.Celda("nombre_operacion"));
            });

            ((DataGridViewComboBoxColumn)DgvOperaciones.Columns["operacion"]).DataSource = cmbOperaciones.Items;
        }

        private void CargarPlano()
        {
            TxtEstatus.Text = "";
            Progreso.Value = 0;
            Progreso.Visible = true;

            if(!BkgDescargarPlano.IsBusy)
                BkgDescargarPlano.RunWorkerAsync(IdPlano);
        }

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Cancel)
                return;

            FtpClient clienteFTP = new FtpClient();
            
            BkgDescargarPlano.ReportProgress(20, "Descargando plano, espere ...");
            if (Plano.TieneFilas())
            {
                string nombreArchivo = Plano.Fila().Celda("nombre_archivo").ToString();
                string strProyecto = Convert.ToDecimal(Plano.Fila().Celda("proyecto")).ToString("F2").PadLeft(6, '0').Replace(".", "_");
                string raizFtp = strProyecto + "/M" + strProyecto + "/";
                string subensamble = Plano.Fila().Celda("subensamble").ToString().PadLeft(2, '0');

                BkgDescargarPlano.ReportProgress(30, "Descargando plano, espere ...");
                if (Global.TipoConexion == "LOCAL")
                {
                    clienteFTP.Host = Global.ConfiguracionActual.FtpServidorLocal;
                    clienteFTP.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                                    Global.UsuarioActual.Fila().Celda("password").ToString());
                }
                else
                {
                    clienteFTP.Host = Global.ConfiguracionActual.FtpServidorRemoto;
                    clienteFTP.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                                    Global.UsuarioActual.Fila().Celda("password").ToString());
                }

                BkgDescargarPlano.ReportProgress(50, "Descargando plano, espere ...");
                // Verificar conexion con servidor FTP
                try
                {
                    clienteFTP.Connect();
                    if (clienteFTP.IsConnected)
                    { // buscamos la imagen del plano en el FTP
                        string pathDirectorio = Path.GetDirectoryName(raizFtp + nombreArchivo)  + "//" + subensamble + "//" + "CP" + "//" + IdPlano + " " + nombreArchivo;
                        if (clienteFTP.FileExists(pathDirectorio + ".PNG"))
                            clienteFTP.Download(out ImagenPlano, pathDirectorio + ".PNG");
                        else 
                        { //El archivo no fue encontrado, buscamos el PDF
                            if (clienteFTP.FileExists(pathDirectorio + ".PDF"))
                                clienteFTP.Download(out ImagenPlano, pathDirectorio + ".PDF");
                            else
                            { // el pdf no fue encontrado, buscamos en la BD
                                ArchivoPlano archivo = new ArchivoPlano();
                                archivo.SeleccionarDePlano(IdPlano);
                                if (archivo.TieneFilas())
                                {
                                    // convertir pdf a imagen
                                    string pathPdfTemp = Path.GetTempFileName();
                                    if (File.Exists(pathPdfTemp))
                                        File.Delete(pathPdfTemp);

                                    File.WriteAllBytes(pathPdfTemp, (byte[])archivo.Fila().Celda("archivo"));
                                    ImagenPlano = FormatosPDF.MiniaturaPDF(pathPdfTemp, 6600, 2550);
                                    File.Delete(pathPdfTemp);
                                }
                            }
                        }
                    }

                    if(ImagenPlano != null)
                        BkgDescargarPlano.ReportProgress(100, "Descargando plano, espere ...");
                    else
                        BkgDescargarPlano.ReportProgress(100, "Error, el plano no fue encontrado");

                }
                catch
                {
                    MessageBox.Show("No se pudo comunicar con el servidor FTP", "Error de conexión con FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BkgDescargarPlano.ReportProgress(100, "Error, no se pudo descargar el plano");
                    return;
                }
            }
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progreso.Visible = false;
            Progreso.Value = 0;

            if (ImagenPlano != null)
            {
                try
                {
                    PicPlano.Image = (Bitmap)((new ImageConverter()).ConvertFrom((byte[])ImagenPlano));
                    TxtEstatus.Text = "Plano descargado correctamente";
                }
                catch
                {
                    TxtEstatus.Text = "El plano no pudo ser descargado";
                }
            }
            else
                TxtEstatus.Text = "El plano no pudo ser descargado";
        }

        public void CargarProceso(int idProceso)
        {
            PlanoProceso proc = new PlanoProceso();
            proc.CargarDatos(idProceso);
            IdProceso = idProceso;

            if(proc.TieneFilas())
            {
                PlanoProceso anterior = new PlanoProceso();
                anterior.CargarDatos(Convert.ToInt32(proc.Fila().Celda("proceso_anterior")));

                int idReq = Convert.ToInt32(proc.Fila().Celda("requisicion_compra"));

                TxtProceso.Text = proc.Fila().Celda("proceso").ToString();
                TxtComentarios.Text = proc.Fila().Celda("comentarios").ToString();

                CargarHerramentistas();
                CmbHerramentista.SelectedItem = CmbHerramentista.FindString(proc.Fila().Celda("operador").ToString());

                Usuario usuario = new Usuario();
                usuario.BuscarPorNombre(proc.Fila().Celda("operador").ToString());
                if (usuario.TieneFilas())
                    CmbHerramentista.Text = usuario.Fila().Celda("id") + " - " + usuario.Fila().Celda("nombre").ToString() + " " + usuario.Fila().Celda("paterno").ToString();
                else
                    CmbHerramentista.Text = "N/A";

                CargarMaquinas(TxtProceso.Text);
                CmbMaquinas.Text = Global.ObjetoATexto(proc.Fila().Celda("maquina"), "N/A");
            }
            else
            {
                TxtProceso.Text = "";
                TxtComentarios.Text = "";

                CmbHerramentista.Items.Clear();
                CmbMaquinas.Items.Clear();

                MessageBox.Show("El proceso de fabricación no existe!", "Imposible cargar proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        public void CargarHerramentistas()
        {
            CmbHerramentista.Items.Clear();
            CmbHerramentista.Items.Add("N/A");
            Usuario.Modelo().SeleccionarDepartamento("FABRICACION").ForEach(delegate(Fila f)
            {
                CmbHerramentista.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
        }

        public void CargarMaquinas(string proceso)
        {
            CmbMaquinas.Items.Clear();
            CmbMaquinas.Items.Add("N/A");

            MaquinaHerramientaProceso.Modelo().TodasDeProceso(proceso).ForEach(delegate(Fila f)
            {
                MaquinaHerramienta mh = new MaquinaHerramienta();
                mh.CargarDatos(Convert.ToInt32(f.Celda("maquina_herramienta")));
                CmbMaquinas.Items.Add(mh.Fila().Celda("nombre"));
            });
        }

        private void CalcularTiempoEstandar()
        {
            OperacionFabricacion operaciones = new OperacionFabricacion();
            TotalTiempoEstandar = 0;
            DatosOperacion.Clear();

            foreach (DataGridViewRow row in DgvOperaciones.Rows)
            {
                if (row.Cells["operacion"].Value == null)
                    break;

                int cantidad = Convert.ToInt32(row.Cells["cantidad_operacion"].Value);
                string operacion = row.Cells["operacion"].Value.ToString();

                operaciones.SeleccionarOperacionNombe(TxtProceso.Text, operacion);
                if (operaciones.TieneFilas())
                {
                    double tiempo = Convert.ToDouble(operaciones.Fila().Celda("tiempo_estandar"));
                    TotalTiempoEstandar += CalcularFactorOperacion(Convert.ToInt32(operaciones.Fila().Celda("id")), tiempo, cantidad);

                    Fila insertarOperaciones = new Fila();
                    insertarOperaciones.AgregarCelda("plano", IdPlano);
                    insertarOperaciones.AgregarCelda("proceso", IdProceso);

                    insertarOperaciones.AgregarCelda("operacion", Convert.ToInt32(operaciones.Fila().Celda("id")));
                    insertarOperaciones.AgregarCelda("tiempo_estandar", (Convert.ToDouble(operaciones.Fila().Celda("tiempo_estandar")) * cantidad));
                    insertarOperaciones.AgregarCelda("cantidad_operaciones", cantidad);
                    insertarOperaciones.AgregarCelda("nivel_complejidad", CmbComplejidad.SelectedIndex +1);
                    insertarOperaciones.AgregarCelda("material", CmbMaterial.Text);
                    insertarOperaciones.AgregarCelda("dimension", CmbDimensiones.Text);
                    insertarOperaciones.AgregarCelda("Presentacion", CmbPresentacion.Text);
                    insertarOperaciones.AgregarCelda("cantidad_piezas", Plano.Fila().Celda("cantidad"));
                    DatosOperacion.Add(insertarOperaciones);
                }
            }
            // tiempo por pieza
            TimeSpan tiempoEstandar = TimeSpan.FromHours(TotalTiempoEstandar);
            LblTiempoEstimado.Text = tiempoEstandar.Days + " días " + tiempoEstandar.Hours + " horas " + tiempoEstandar.Minutes + " minutos " + tiempoEstandar.Seconds + " segundos";
            
            //tiempo total
            int cantidadPiezas = Convert.ToInt32(Plano.Fila().Celda("cantidad"));
            TimeSpan tiempoTotalEstandar = TimeSpan.FromHours((TotalTiempoEstandar * cantidadPiezas));
            LblTiempoEstimadoTotal.Text = tiempoTotalEstandar.Days + " días " + tiempoTotalEstandar.Hours + " horas " + tiempoTotalEstandar.Minutes + " minutos " + tiempoTotalEstandar.Seconds + " segundos";
            
            TotalTiempoEstandar = (double)tiempoTotalEstandar.TotalHours;
        }

        private double CalcularFactorOperacion(int operacion, double tiempo, int cantidad)
        {
            double tiempoFactor = 0;

            FactorOperacionFabricacion factores = new FactorOperacionFabricacion();
            factores.SeleccionarFactor(operacion).ForEach(delegate(Fila f)
            {
                if (CmbMaterial.Text == f.Celda("factor_valor").ToString())
                    tiempoFactor += (Convert.ToDouble(f.Celda("factor_porcentaje")) * tiempo) / 100;
                else if (CmbPresentacion.Text == f.Celda("factor_valor").ToString())
                    tiempoFactor += (Convert.ToDouble(f.Celda("factor_porcentaje")) * tiempo) / 100;
                else if (CmbDimensiones.Text == f.Celda("factor_valor").ToString())
                    tiempoFactor += (Convert.ToDouble(f.Celda("factor_porcentaje")) * tiempo) / 100;
                else if (CmbComplejidad.Text == f.Celda("factor_valor").ToString())
                    tiempoFactor += (Convert.ToDouble(f.Celda("factor_porcentaje")) * tiempo) / 100;
            });

            return ((tiempoFactor + tiempo) * cantidad);
        }

        private void HabilitarBotonAsignar()
        {
            bool cantidadesEnCero = false;

            foreach (DataGridViewRow row in DgvOperaciones.Rows)
	        {
                if(row.Cells["cantidad_operacion"].Value != null)
                {
                    if (row.Cells["cantidad_operacion"].Value.ToString() == "0")
                    {
                        cantidadesEnCero = true;
                        break;
                    }
                }
	        }

            if (DgvOperaciones.Rows.Count == 1)
                cantidadesEnCero = true;

            BtnAsignar.Enabled = (CmbHerramentista.Text != "N/A" && CmbMaquinas.Text != "N/A" && !cantidadesEnCero && CmbComplejidad.Text != "" && CmbDimensiones.Text != "" && CmbMaterial.Text != "" && CmbPresentacion.Text != "");
        }

        private void NumProceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                CargarProceso(Convert.ToInt32(NumProceso.Value));
        }

        private void DgvOperaciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            //se modificó la operacion
            if (e.ColumnIndex == 0)
            {
                DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Value = 0;
                DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Style.BackColor = Color.Crimson;
                DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Style.ForeColor = Color.White;
                DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].ReadOnly = false;
            }

            //se modificó la cantidad
            else if (e.ColumnIndex == 1)
            {
                int cantidad = 0;
                object valorCantidad = DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Value;

                //Verificar que la cantidad sea numérica
                if (valorCantidad == null || !int.TryParse(valorCantidad.ToString(), out cantidad))
                {
                    MessageBox.Show("Solamente se puede indicar la cantidad de forma numérica", "La cantidad no es numérica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Value = 0;
                    return;
                }

                if (cantidad <= 0)
                {
                    DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Style.BackColor = Color.Crimson;
                    DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Style.ForeColor = Color.White;
                }
                else
                {
                    DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Style.BackColor = Color.White;
                    DgvOperaciones.Rows[e.RowIndex].Cells["cantidad_operacion"].Style.ForeColor = Color.Black;
                }

                CalcularTiempoEstandar();
                HabilitarBotonAsignar();
            }
        }

        private void CmbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBotonAsignar();
        }

        private void CmbHerramentista_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBotonAsignar();
        }

        private void LblMaterial_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            ComentariosSupervisor = TxtComentarios.Text; ;
            Proceso = TxtProceso.Text; ;
            Herramenstista = CmbHerramentista.Text;
            MaquinaHerramienta = CmbMaquinas.Text;
            Complejidad = CmbComplejidad.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void MenuOpciones_Opening(object sender, CancelEventArgs e)
        {
            if (DgvOperaciones.SelectedRows.Count <= 0)
                return;

            object operacionSeleccionada = DgvOperaciones.SelectedRows[0].Cells["operacion"].Value;

            eliminarToolStripMenuItem.Enabled = operacionSeleccionada != null;
            ajustarTiemposToolStripMenuItem.Enabled = operacionSeleccionada != null;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvOperaciones.Rows.RemoveAt(DgvOperaciones.SelectedRows[0].Index);
            CalcularTiempoEstandar();
            HabilitarBotonAsignar();
        }

        private void CmbComplejidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTiempoEstandar();
            HabilitarBotonAsignar();
        }

        private void CmbDimensiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTiempoEstandar();
            HabilitarBotonAsignar();
        }

        private void CmbMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTiempoEstandar();
            HabilitarBotonAsignar();
        }

        private void CmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularTiempoEstandar();
            HabilitarBotonAsignar();
        }

        private void ajustarTiemposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvOperaciones.SelectedRows.Count <= 0)
                return;

            object operacionSeleccionada = DgvOperaciones.SelectedRows[0].Cells["operacion"].Value;

            if (operacionSeleccionada == null)
                return;

            FrmAjustarTiemposFabricacion ajustar = new FrmAjustarTiemposFabricacion(TxtProceso.Text, operacionSeleccionada.ToString());
            
            if(ajustar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CalcularTiempoEstandar();
            }
        }

        private void nuevaOperaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaOperacionFabricacion nuevaop = new FrmNuevaOperacionFabricacion(TxtProceso.Text);

            if(nuevaop.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FrmAjustarTiemposFabricacion ajustar = new FrmAjustarTiemposFabricacion(TxtProceso.Text, nuevaop.NombreOperacion);
                if (ajustar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CalcularTiempoEstandar();
                }
                CargarOperaciones();
            }
        }
    }
}
