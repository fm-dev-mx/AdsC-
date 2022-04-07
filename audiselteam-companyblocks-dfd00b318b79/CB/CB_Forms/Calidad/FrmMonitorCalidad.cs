using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;
using FluentFTP;
using System.Net;
using System.IO;

namespace CB
{
    public partial class FrmMonitorCalidad : Form
    {
        List<Fila> Auditorias = new List<Fila>();
        List<int> ListaProcesos = new List<int>();
        List<int> ListaPlanos = new List<int>();
        FtpClient ClienteFtp = new FtpClient();
        int AuditoriaSeleccionada = 0;
        int IdProceso = 0;
        int IdHerramientaCalibracion = 0;
        int Plano = 0;
        int IdPlano = 0;
        string Avance = string.Empty;
        string ProcesoFabricacion = string.Empty;
        byte[] DatosImagen = null;

        public FrmMonitorCalidad()
        {
            InitializeComponent();
        }

        private void nuevoPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoPuntoInspeccion5s nuevo = new FrmNuevoPuntoInspeccion5s();
            if(nuevo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila insertarPuntoInspeccion = new Fila();
                insertarPuntoInspeccion.AgregarCelda("area", nuevo.Area);
                insertarPuntoInspeccion.AgregarCelda("etapa", nuevo.Etapa);
                insertarPuntoInspeccion.AgregarCelda("punto_inspeccion", nuevo.PuntoInspeccion);
                insertarPuntoInspeccion.AgregarCelda("usuario_creacion",Global.UsuarioActual.Fila().Celda("id"));
                insertarPuntoInspeccion.AgregarCelda("fecha_creacion", DateTime.Now);
                Auditoria5s.Modelo().Insertar(insertarPuntoInspeccion);
                CargarAreas();

                CmbArea.Text = nuevo.Area;
                CmbEtapa.Text = nuevo.Etapa;

                Auditorias = Auditoria5s.Modelo().SeleccionarDatos("", null);
                CargarAuditoria();
            }
        }

        private void auditarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAuditar5S auditar = new FrmAuditar5S(AuditoriaSeleccionada);
            if(auditar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Auditoria5s auditoria = new Auditoria5s();
                auditoria.CargarDatos(AuditoriaSeleccionada);
                if(auditoria.TieneFilas())
                {
                    auditoria.Fila().ModificarCelda("resultado", auditar.Resultado);
                    auditoria.Fila().ModificarCelda("notas_auditor", auditar.NotasAuditor);
                    auditoria.Fila().ModificarCelda("usuario_auditoria", Global.UsuarioActual.Fila().Celda("id"));
                    auditoria.Fila().ModificarCelda("fecha_auditoria", DateTime.Now);
                    auditoria.Fila().ModificarCelda("usuario_responsable", auditar.IdResponsable);
                    auditoria.Fila().ModificarCelda("avance", auditar.Avance);
                    auditoria.GuardarDatos();

                    Auditorias = Auditoria5s.Modelo().SeleccionarDatos("", null);
                    CargarAuditoria();
                }
            }
        }

        private void FrmMonitorCalidad_Load(object sender, EventArgs e)
        {
            CmbFiltroProceso.Text = "INSPECCION DE FABRICACION";
            CmbFiltroEstatus.Text = "PENDIENTE";
            CargarProcesosPorInspeccionar();
        }

        private void CargarProcesosPorInspeccionar()
        {
            DgvProcesosInspeccion.Rows.Clear();

            switch(CmbFiltroProceso.Text)
            {
                case "INSPECCION DE FABRICACION":
                case "INSPECCION DE TRATAMIENTO":
                    CargarProcesosFabricacion();
                    break;

                case "INSPECCION DE ENSAMBLE":
                    CargarModulos();
                    break;
            }

            if (DgvProcesosInspeccion.Rows.Count > 0)
                DgvProcesosInspeccion.ClearSelection();
        }

        public void CargarProcesosFabricacion()
        {
            DgvProcesosInspeccion.Columns[0].HeaderText = "ID Proceso";
            DgvProcesosInspeccion.Columns[1].HeaderText = "Plano";
            DgvProcesosInspeccion.Columns[2].HeaderText = "Proceso";
            DgvProcesosInspeccion.Columns[3].HeaderText = "Estatus";

            string estatusPlano = string.Empty;

            if (CmbFiltroProceso.Text == "INSPECCION DE FABRICACION")
                estatusPlano = "EN INSPECCION";
            else
                estatusPlano = "RECIBIDO";


            PlanoProceso planoproceso = new PlanoProceso();
            planoproceso.CargarProcesosInspeccion(CmbFiltroProceso.Text, CmbFiltroEstatus.Text).ForEach(delegate(Fila f)
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(Convert.ToInt32(f.Celda("plano")));
                //if (plano.TieneFilas())
                if (plano.TieneFilas() && plano.Fila().Celda("estatus").ToString() == estatusPlano)
                {
                    DgvProcesosInspeccion.Rows.Add(f.Celda("id"),
                                                    f.Celda("plano") + " | " + plano.Fila().Celda("nombre_archivo"),
                                                    f.Celda("proceso"),
                                                    f.Celda("estatus"));
                }
            });
        }

        public void CargarModulos()
        {
            DgvProcesosInspeccion.Columns[0].HeaderText = "ID Módulo";
            DgvProcesosInspeccion.Columns[1].HeaderText = "Nombre del módulo";
            DgvProcesosInspeccion.Columns[2].HeaderText = "Proyecto";
            DgvProcesosInspeccion.Columns[3].HeaderText = "Estatus";

            Modulo.Modelo().SeleccionarInspeccionPendiente().ForEach(delegate(Fila f)
            {
                DgvProcesosInspeccion.Rows.Add(f.Celda("id"),
                                                       Convert.ToDecimal(f.Celda("subensamble")).ToString().PadLeft(2, '0') + " - " + f.Celda("nombre"),
                                                       Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                                                       f.Celda("estatus_inspeccion"));
            });
        }

        private void Calcularpuntuacion()
        {
            int total = DgvChecklist5S.Rows.Count;
            int avance = 0;
            double puntuacion = 0.0;

            foreach (DataGridViewRow row in DgvChecklist5S.Rows)
            {
                if (row.Cells["resultado"].Value.ToString() == "BIEN" || row.Cells["resultado"].Value.ToString() == "NO APLICA")
                    avance++;
            }

            if (total > 0 && avance > 0)
                puntuacion = (Convert.ToDouble(avance) / Convert.ToDouble(total)) * 100;

            LblPuntuacion5S.Text = Convert.ToInt32(puntuacion).ToString() + "%";
        }

        private void CargarAuditoria()
        {
            if (CmbArea.Text == "" || CmbEtapa.Text == "")
                return;

            DgvChecklist5S.Rows.Clear();

            Auditorias.ForEach(delegate(Fila f)
            {
                if ((f.Celda("area").ToString() == CmbArea.Text || CmbArea.Text == "TODAS")  && (f.Celda("etapa").ToString() == CmbEtapa.Text || CmbEtapa.Text == "TODAS"))
                {
                    string usuarioResponsable = string.Empty;
                    Usuario usuario = new Usuario();
                    usuario.CargarDatos(Convert.ToInt32(Global.ObjetoATexto(f.Celda("usuario_responsable"), "0")));
                    if (usuario.TieneFilas())
                        usuarioResponsable = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");

                    DgvChecklist5S.Rows.Add(f.Celda("id").ToString(),
                                        f.Celda("punto_inspeccion").ToString(),
                                        Global.ObjetoATexto(f.Celda("resultado"), ""),
                                        Global.ObjetoATexto(f.Celda("notas_auditor"), ""),
                                        usuarioResponsable,
                                        Global.ObjetoATexto(f.Celda("avance"), ""));
                }
            });

            if (DgvChecklist5S.Rows.Count > 0)
                DgvChecklist5S.ClearSelection();

            Calcularpuntuacion();
        }

        private void CargarAreas()
        {
            CmbArea.Items.Clear();

            CmbArea.Items.Add("TODAS");

            Auditoria5s.Modelo().SeleccionarAreas().ForEach(delegate(Fila f)
            {
                CmbArea.Items.Add(f.Celda("area").ToString());
            });

            CmbArea.SelectedIndex = 0;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 3: // NC Externas
                    CmbTipoNcExterna.Text = "CLIENTE";
                    CmbEstatusAnalisisNcExterna.Text = "PENDIENTE";
                    CargarNcExternas(CmbTipoNcExterna.Text, CmbEstatusAnalisisNcExterna.Text);
                    break;
                case 4: // NC Internas
                    CmbEstatusNcInterna.Text = "SIN LIBERAR";
                    CmbEstatusAnalisisNcInterna.Text = "PENDIENTE";
                    CargarNcInternas();
                    CmbProcesoNcInterna.SelectedIndex = 0;
                    break;
                case 5: //Auditoria 5's
                    CargarAreas();
                    Auditorias = Auditorias = Auditoria5s.Modelo().SeleccionarDatos("", null);
                    CmbEtapa.SelectedIndex = 0;
                    CargarAuditoria();
                    break;
                case 6: //Calibracion
                    CmbEstatus.SelectedText = "TODOS";
                    CargarInstrumentos();
                    CmbEstatus.SelectedIndex = 0;
                    break;
                case 1://Tratamiento de materiales
                    CmbEstatusTratamiento.SelectedIndex = 0;
                    BtnValeSalida.Enabled = false;
                    break;
                case 2: //Piezas terminadas
                    if (CmbPiezaTerminada.Text != "TERMINADO")
                        CmbPiezaTerminada.SelectedIndex = 0;
                    else
                        CargarPiezasTerminadas();
                    break;
                default:
                    break;
            }
        }

        public void CargarNcInternas()
        {
            NoConformidad nc = new NoConformidad();

            DgvNcInternas.Rows.Clear();
            nc.SeleccionarPlanoDistinto(CmbEstatusNcInterna.Text, "INTERNA", CmbProcesoNcInterna.Text, CmbEstatusAnalisisNcInterna.Text).ForEach(delegate(Fila f) 
            {
                int idNc = Convert.ToInt32(f.Celda("id"));

                //PROCESO DE FABRICACION
                if (CmbProcesoNcInterna.Text == "FABRICACION" && Convert.ToInt32(Global.ObjetoATexto(f.Celda("cambio_diseno"), "0")) == 0)
                {
                    int idPlano = Convert.ToInt32(f.Celda("plano"));
                    PlanoProyecto plano = new PlanoProyecto();
                    plano.CargarDatos(idPlano);
                    DgvNcInternas.Rows.Add(idNc.ToString().PadLeft(4, '0'), idPlano, idPlano.ToString() + " | " + plano.Fila().Celda("nombre_archivo"), f.Celda("comentarios"), f.Celda("cantidad_nok"), f.Celda("estatus"), Global.ObjetoATexto(f.Celda("disposicion"), "N/A"), f.Celda("estatus_analisis")); 
                }
                // CAMBIOS DE DISEÑO
                else if (CmbProcesoNcInterna.Text == "DISEÑO MECANICO")
                {
                    CambioDiseno cambioDiseno = new CambioDiseno();
                    cambioDiseno.SeleccionarNoConformidad(Convert.ToInt32(nc.Fila().Celda("id")));

                    //si el cambio de diseño existe
                    if(cambioDiseno.TieneFilas())
                    {
                        string  cadenaModulo = (Global.ObjetoATexto(cambioDiseno.Fila().Celda("modulos_afectados"), "00"));
                        decimal proyecto = Convert.ToDecimal(Global.ObjetoATexto(cambioDiseno.Fila().Celda("proyecto"), "0"));
                        string strModulo = string.Empty;

                        int modulosDetectados = cadenaModulo.Length / 2;

                        //separamos los modulos de 2 en 2 (formato 02), y obtenemos los nombres de cada modulo
                        int indiceCadena = 0;
                        for (int i = 0; i < modulosDetectados; i++)
                        {
                            strModulo += cadenaModulo.Substring(indiceCadena, 2) + " | ";
                            int subensamble = Convert.ToInt32(cadenaModulo.Substring(indiceCadena, 2));
                            indiceCadena += 2;

                            Modulo modulos = new Modulo();
                            modulos.SeleccionarProyectoSubensamble(proyecto, Convert.ToInt32(subensamble));

                            if (modulos.TieneFilas())
                            {
                                strModulo += modulos.Fila().Celda("nombre").ToString() + Environment.NewLine;
                            }
                        }

                        //mostramos la informacion en el DGV
                        DgvNcInternas.Rows.Add(idNc.ToString().PadLeft(4, '0'), strModulo, strModulo.TrimEnd(), f.Celda("comentarios"), f.Celda("cantidad_nok"), f.Celda("estatus"), Global.ObjetoATexto(f.Celda("disposicion"), "N/A"), f.Celda("estatus_analisis"));
                    }
                }
            });

            if (DgvNcInternas.Rows.Count > 0)
                DgvNcInternas.ClearSelection();
        }

        public void CargarNcExternas(string tipo, string estatusAnalisis)
        {
            NoConformidad nc = new NoConformidad();

            DgvNcExternas.Rows.Clear();
            nc.SeleccionarTipo(CmbTipoNcExterna.Text, CmbEstatusAnalisisNcExterna.Text).ForEach(delegate(Fila f)
            {
                string strDetalles = string.Empty;

                if(CmbTipoNcExterna.Text == "CLIENTE")
                {
                    strDetalles += Convert.ToDecimal(f.Celda("id_proyecto")).ToString("F2").PadLeft(6, '0') + " - " + f.Celda("nombre_proyecto") + Environment.NewLine;
                    strDetalles += f.Celda("nombre_contacto") + " " + f.Celda("apellidos_contacto") + Environment.NewLine + Environment.NewLine;
                    strDetalles += f.Celda("comentarios");
                }

                DgvNcExternas.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), strDetalles);
            });
        }

        private void DgvChecklist5S_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            AuditoriaSeleccionada = Convert.ToInt32(DgvChecklist5S.SelectedRows[0].Cells["id"].Value);
            Avance = DgvChecklist5S.SelectedRows[0].Cells["estatus"].Value.ToString();

        }

        private void CmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void CmbEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void CargarInstrumentos()
        {
            CmbInstrumentos.Items.Clear();

            CmbInstrumentos.Items.Add("TODOS");
            InstrumentosMedicion instrumentos = new InstrumentosMedicion();
            instrumentos.SeleccionarInstrumentos().ForEach(delegate(Fila f)
            {
                CmbInstrumentos.Items.Add(f.Celda("tipo_instrumento"));
            });

            if (CmbInstrumentos.Items.Count > 0)
                CmbInstrumentos.SelectedIndex = 0;
        }

        private void Instrumentos()
        {
            if (CmbEstatus.Text == "" || CmbInstrumentos.Text == "")
                return;

            DgvCalibracion.Rows.Clear();

            InstrumentosMedicion.Modelo().CargarInstrumentos(CmbEstatus.Text, CmbInstrumentos.Text).ForEach(delegate(Fila f)
            {
                DateTime fechaUltimaCalibracion = Convert.ToDateTime(f.Celda("fecha_calibracion"));
                DateTime proximoMantenimiento = ObtenerProximaFecha(Convert.ToDateTime(fechaUltimaCalibracion).AddMonths(Convert.ToInt32(f.Celda("periodo_calibracion"))), DayOfWeek.Saturday);
                DateTime FechaProxima = proximoMantenimiento.AddDays(-15);
                string estatus = "";

                if (f.Celda("tipo_uso").ToString() != "REFERENCIA")
                {
                    if (FechaProxima > DateTime.Now)
                        estatus = "NO REQUERIDA";
                    else if (FechaProxima < DateTime.Now && DateTime.Now < proximoMantenimiento)
                        estatus = "PROXIMO";
                    else
                        estatus = "REQUERIDA";
                }
                else
                    estatus = "N/A";                

                 if (CmbEstatus.Text == estatus || CmbEstatus.Text == "TODOS")
                     DgvCalibracion.Rows.Add(f.Celda("id"), f.Celda("numero_serie"), f.Celda("tipo_instrumento"), Global.FechaATexto(fechaUltimaCalibracion), Global.FechaATexto(proximoMantenimiento), f.Celda("tipo_uso"), estatus);
            });

            if (DgvCalibracion.Rows.Count > 0)
                DgvCalibracion.ClearSelection();
        }

        public static DateTime ObtenerProximaFecha(DateTime inicio, DayOfWeek dia)
        {
            int daysToAdd = ((int)dia - (int)inicio.DayOfWeek + 7) % 7;
            return inicio.AddDays(daysToAdd);
        }

        private void DgvChecklist5S_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    nuevoPuntoToolStripMenuItem.Visible = false;
                    auditarToolStripMenuItem.Visible = true;
                    MenuPuntosInspeccion.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvChecklist5S_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvChecklist5S.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    nuevoPuntoToolStripMenuItem.Visible = true;
                    auditarToolStripMenuItem.Visible = false;
                    MenuPuntosInspeccion.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvChecklist5S_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string resultado = DgvChecklist5S.Rows[e.RowIndex].Cells["resultado"].Value.ToString();

            if (resultado == "BIEN")
                DgvChecklist5S.Rows[e.RowIndex].Cells["resultado"].Style.BackColor = Color.LightGreen;

            else if (resultado == "MAL")
                DgvChecklist5S.Rows[e.RowIndex].Cells["resultado"].Style.BackColor = Color.Red;

            string estatus = DgvChecklist5S.Rows[e.RowIndex].Cells["estatus"].Value.ToString();
            
            if (estatus == "EN PROCESO")
                DgvChecklist5S.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.Yellow;

            else if (estatus == "TERMINADO")
                DgvChecklist5S.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.LightGreen;
        }

        private void CmbInstrumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instrumentos();
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instrumentos();
        }

        private void crearRequisiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> filtro = new List<string>()
            {
                "M.R.O.",
                "SERVICIOS"
            };

            FrmSeleccionarMaterialCatalogo2 selec = new FrmSeleccionarMaterialCatalogo2(filtro, true, false);
            //FrmSeleccionarMaterialCatalogo selec = new FrmSeleccionarMaterialCatalogo(true, false);

            if (selec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CrearRequisicionMaterial(selec.IdMaterial, selec.CantidadMaterial);
        }

        public void CargarMaterial()
        {
            DgvMaterial.Rows.Clear();

            if (TxtCalibracion.Text == "")
                return;

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@calibracion", Convert.ToInt32(TxtCalibracion.Text));

            int fila = Global.GuardarFilaSeleccionada(DgvMaterial);

            MaterialProyecto.Modelo().SeleccionarDatos("calibracion=@calibracion", parametros).ForEach(delegate(Fila f)
            {
                DgvMaterial.Rows.Add(f.Celda("id"), f.Celda("requisitor"), f.Celda("numero_parte"), f.Celda("descripcion"), f.Celda("piezas_requeridas"), f.Celda("estatus_compra"), f.Celda("estatus_almacen"));
            });

            Global.RecuperarFilaSeleccionada(DgvMaterial, fila);
        }

        public int CrearRequisicionMaterial(int idCatalogo, int cantidad)
        {
            CatalogoMaterial material = new CatalogoMaterial();
            material.CargarDatos(idCatalogo);

            int total = 0;
            int piezasPaquete = Convert.ToInt32(material.Fila().Celda("piezas_paquete"));
            int piezasStock = 0;

            if (material.Fila().Celda("tipo_venta").ToString() == "POR PAQUETE")
            {
                decimal piezasEntrePaquete = (decimal)cantidad / (decimal)piezasPaquete;
                total = (int)Math.Ceiling(piezasEntrePaquete);
                piezasStock = (total * piezasPaquete) - cantidad;
            }
            else
            {
                total = cantidad;
            }

            Fila matProyecto = new Fila();

            string requisitor = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();
            string numeroSerie = DgvCalibracion.SelectedRows[0].Cells["numero_serie"].Value.ToString();

            matProyecto.AgregarCelda("requisitor", requisitor);
            matProyecto.AgregarCelda("proyecto", 0);
            matProyecto.AgregarCelda("calibracion", IdHerramientaCalibracion);
            matProyecto.AgregarCelda("categoria", material.Fila().Celda("categoria"));
            matProyecto.AgregarCelda("numero_parte", material.Fila().Celda("numero_parte"));
            matProyecto.AgregarCelda("fabricante", material.Fila().Celda("fabricante"));
            matProyecto.AgregarCelda("descripcion", material.Fila().Celda("descripcion"));
            matProyecto.AgregarCelda("piezas_requeridas", cantidad);
            matProyecto.AgregarCelda("piezas_stock", piezasStock);
            matProyecto.AgregarCelda("total", total);
            matProyecto.AgregarCelda("tipo_venta", material.Fila().Celda("tipo_venta"));
            matProyecto.AgregarCelda("piezas_paquete", material.Fila().Celda("piezas_paquete"));
            matProyecto.AgregarCelda("po", 0);
            matProyecto.AgregarCelda("estatus_seleccion", "DEFINIDO");
            matProyecto.AgregarCelda("estatus_compra", "PENDIENTE");
            matProyecto.AgregarCelda("accesorio_para", 0);
            matProyecto.AgregarCelda("fecha_creacion", DateTime.Now);
            matProyecto.AgregarCelda("estatus_autorizacion", "AUTORIZADO");
            matProyecto.AgregarCelda("comentarios_autorizacion", "AUTORIZACION AUTOMATICA DE MATERIAL PARA MAQUINADO");
            matProyecto.AgregarCelda("usuario_autorizacion", "SISTEMA");
            matProyecto.AgregarCelda("fecha_autorizacion", DateTime.Now);

            matProyecto = MaterialProyecto.Modelo().Insertar(matProyecto);

            string titulo = "Nueva requisición de material";
            string contenido = "";
            contenido += Global.UsuarioActual.NombreCompleto();
            contenido += " creó la requisición de material #" + matProyecto.Celda("id").ToString() + " para el instrumento " + numeroSerie;

            Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");

            return Convert.ToInt32(matProyecto.Celda("id"));
        }

        private void DgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
        }

        private void DgvCalibracion_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                    MenuCalibracion.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void DgvCalibracion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            IdHerramientaCalibracion = Convert.ToInt32(DgvCalibracion.SelectedRows[0].Cells["id_calibracion"].Value);
            string estatus = DgvCalibracion.SelectedRows[0].Cells["estatus_calibracion"].Value.ToString();

            if (estatus != "TODOS" && estatus != "N/A")
            {
                if(estatus == "NO REQUERIDA")
                {
                    crearRequisiciónToolStripMenuItem.Visible = false;
                    registrarCertificadoToolStripMenuItem.Visible = false;
                }
                    else
                {
                    crearRequisiciónToolStripMenuItem.Visible = true;
                    registrarCertificadoToolStripMenuItem.Visible = true;
                }
               
                descargarCertificadoToolStripMenuItem.Visible = true;
                verCertificadoToolStripMenuItem.Visible = true;
            }
            else
            {
                crearRequisiciónToolStripMenuItem.Visible = false;
                registrarCertificadoToolStripMenuItem.Visible = false;
                descargarCertificadoToolStripMenuItem.Visible = false;
                verCertificadoToolStripMenuItem.Visible = false;
            }
        }

        private void registrarCertificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CertificadoCalibracion certificado = new CertificadoCalibracion();
            certificado.SeleccionarCertificadoCalibracion(IdHerramientaCalibracion);
            if(certificado.TieneFilas())
            {
                DialogResult result = MessageBox.Show("La herramienta seleccionada actualmente cuenta con un certificado de calibración, ¿Desea reemplazarlo?", "Reemplazar archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == System.Windows.Forms.DialogResult.Yes)
                {
                    OpenfileArchivo.FileName = "";
                    if(OpenfileArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string nombreArchivo = OpenfileArchivo.SafeFileName;
                        byte[] datos = File.ReadAllBytes(OpenfileArchivo.FileName);

                        try
                        {
                            certificado.Fila().ModificarCelda("archivo", datos);
                            certificado.Fila().ModificarCelda("nombre_archivo", nombreArchivo);
                            certificado.GuardarDatos();

                            MessageBox.Show("El certificado de calibración se actualizó de forma correcta");
                        }
                        catch
                        {
                            MessageBox.Show("Ocurrió un problema, favor de intentarlo de nuevo");
                        }
                    }
                }
            }
            else
            {
                OpenfileArchivo.FileName = "";
                if (OpenfileArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string nombreArchivo = OpenfileArchivo.SafeFileName;
                    byte[] datos = File.ReadAllBytes(OpenfileArchivo.FileName);

                    try
                    {
                        Fila insertarCertificado = new Fila();
                        insertarCertificado.AgregarCelda("archivo", datos);
                        insertarCertificado.AgregarCelda("calibracion", IdHerramientaCalibracion);
                        insertarCertificado.AgregarCelda("nombre_archivo", nombreArchivo);
                        CertificadoCalibracion.Modelo().Insertar(insertarCertificado);
                    
                         MessageBox.Show("El certificado de calibración se creó de forma correcta");
                    }
                    catch
                    {
                        MessageBox.Show("Ocurrió un problema, favor de intentarlo de nuevo");
                    }
                }
            }
        }

        private void verCertificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CertificadoCalibracion certificado = new CertificadoCalibracion();
            certificado.SeleccionarCertificadoCalibracion(IdHerramientaCalibracion);
            if (certificado.TieneFilas())
            {
                byte[] datos = (byte[])certificado.Fila().Celda("archivo");
                string nombreArchivo = certificado.Fila().Celda("nombre_archivo").ToString();

                FrmVisorPDF visor = new FrmVisorPDF(datos, nombreArchivo);
                visor.Show();
            }
            else
                MessageBox.Show("No es posible visualizar el certificado ya que no existe");
        }

        private void descargarCertificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CertificadoCalibracion certificado = new CertificadoCalibracion();
            certificado.SeleccionarCertificadoCalibracion(IdHerramientaCalibracion);
            if (certificado.TieneFilas())
            {
                SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
                SaveFileDialog1.FileName = certificado.Fila().Celda("nombre_archivo").ToString();
                SaveFileDialog1.DefaultExt = "pdf";
                SaveFileDialog1.Filter = "pdf (*.pdf)|*.pdf";
                if(SaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    byte[] archivo = (byte[])certificado.Fila().Celda("archivo");
                    File.WriteAllBytes(SaveFileDialog1.FileName.ToString(), archivo);
                }
            }
            else
                MessageBox.Show("No es posible descargar el certificado ya que no existe");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                CargarMaterial();
        }

        private void TxtCalibracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void DgvCalibracion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvCalibracion.Rows[e.RowIndex].Cells["estatus_calibracion"].Value.ToString();
            if (estatus == "PROXIMO")
                DgvCalibracion.Rows[e.RowIndex].Cells["estatus_calibracion"].Style.BackColor = Color.Yellow;
            if (estatus == "REQUERIDA")
                DgvCalibracion.Rows[e.RowIndex].Cells["estatus_calibracion"].Style.BackColor = Color.Red;
        }

        private void CmbFiltroProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProcesosPorInspeccionar();
        }

        private void CmbFiltroEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProcesosPorInspeccionar();
        }

        private void DgvProcesosFabricacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvProcesosInspeccion.SelectedRows.Count == 0) return;

            string estatus = DgvProcesosInspeccion.SelectedRows[0].Cells["status"].Value.ToString();
            Plano = Convert.ToInt32(DgvProcesosInspeccion.SelectedRows[0].Cells["plano_nombre"].Value.ToString().Split(' ')[0].Trim());
            ProcesoFabricacion = DgvProcesosInspeccion.SelectedRows[0].Cells["proceso"].Value.ToString();
            IdProceso = Convert.ToInt32(DgvProcesosInspeccion.SelectedRows[0].Cells["id_proceso"].Value);

            if (estatus == "PENDIENTE")
            {
                inspeccionarToolStripMenuItem.Visible = true;
                verResultadoDeInspeccionToolStripMenuItem.Visible = false;
            }
            else if (estatus == "EN PROCESO")
            {
                inspeccionarToolStripMenuItem.Visible = true;
                verResultadoDeInspeccionToolStripMenuItem.Visible = false;
            }
            else if (estatus == "TERMINADO")
            {
                inspeccionarToolStripMenuItem.Visible = false;
                verResultadoDeInspeccionToolStripMenuItem.Visible = true;
            }
        }

        private void DgvProcesosFabricacion_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                    MenuInspeccionar.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void DgvProcesosFabricacion_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvChecklist5S.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    inspeccionarToolStripMenuItem.Visible = false;
                    verResultadoDeInspeccionToolStripMenuItem.Visible = false;
                    MenuInspeccionar.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void inspeccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(CmbFiltroProceso.Text)
            {
                case "INSPECCION DE FABRICACION":
                case "INSPECCION DE TRATAMIENTO":
                    InspeccionarProcesoFabricacion();
                    break;

                case "INSPECCION DE ENSAMBLE":
                    InspeccionarEnsambleModulo();
                    break;
            }
        }

        public void InspeccionarProcesoFabricacion()
        {
            FrmInspeccionPiezaFabricada2 inspeccionar = new FrmInspeccionPiezaFabricada2(Plano, ProcesoFabricacion, IdProceso);
            if (inspeccionar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<Fila> NoConformidades = inspeccionar.NoConformidades;
                string comentarios = inspeccionar.Comentarios;
                DatosImagen = inspeccionar.ImagenBytes;

                if (inspeccionar.RechazarPlano) // hubo un rechazo
                {
                    foreach (Fila fila in NoConformidades)
                    {
                        Fila insertarNoConformidad = new Fila();
                        insertarNoConformidad.AgregarCelda("tipo", fila.Celda("tipo"));
                        insertarNoConformidad.AgregarCelda("comentarios", fila.Celda("comentarios"));
                        insertarNoConformidad.AgregarCelda("fecha_creacion", DateTime.Now);
                        insertarNoConformidad.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
                        insertarNoConformidad.AgregarCelda("cantidad_ok", fila.Celda("cantidad_ok"));
                        insertarNoConformidad.AgregarCelda("cantidad_nok", fila.Celda("cantidad_nok"));
                        insertarNoConformidad.AgregarCelda("plano", inspeccionar.IdPlano);
                        insertarNoConformidad.AgregarCelda("proceso_fabricacion_rechazado", fila.Celda("proceso"));
                        insertarNoConformidad.AgregarCelda("proceso_fabricacion", IdProceso);
                        if (inspeccionar.Proceso == "INSPECCION DE FABRICACION")
                            insertarNoConformidad.AgregarCelda("proceso_origen", "FABRICACION");
                        else
                            insertarNoConformidad.AgregarCelda("proceso_origen", "PROVEEDOR");

                        insertarNoConformidad.AgregarCelda("usuario_liberacion", 0);
                        insertarNoConformidad.AgregarCelda("fecha_liberacion", null);
                        NoConformidad.Modelo().Insertar(insertarNoConformidad);

                        // Quitar el estatus de "BIEN A LA PRIMERA (CALIDAD FTT)"  del proceso
                        PlanoProceso proceso = new PlanoProceso();
                        proceso.CargarDatos(Convert.ToInt32(fila.Celda("proceso")));
                        if (proceso.TieneFilas())
                        {
                            proceso.Fila().ModificarCelda("bien_primera_vez", 0);
                            proceso.GuardarDatos();
                        }
                    }

                    DialogResult resp = MessageBox.Show("Quieres liberar ahora las no conformidades?", "Liberar no conformidades", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resp == System.Windows.Forms.DialogResult.Yes)
                    {
                        FrmLiberarNoConformidad liberar = new FrmLiberarNoConformidad(inspeccionar.IdPlano);

                        if (liberar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            switch (liberar.Disposicion)
                            {
                                case "SCRAP":
                                    MessageBox.Show("Coloca el producto no conforme en contenedor de scrap", "Producto liberado como scrap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;

                                case "REPARACION":
                                    MessageBox.Show("Entrega el producto no conforme al Supervisor de tool room para que sea reparado. Asegúrate de que tenga la etiqueta roja con el ID de trazabilidad.", "Producto liberado para reparación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;

                                case "DESVIACION":
                                    MessageBox.Show("Selecciona el siguiente proceso", "Proceso siguiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    FrmPlanTrabajoPlano planTrabajo = new FrmPlanTrabajoPlano(inspeccionar.IdPlano);
                                    planTrabajo.Show();
                                    break;
                            }
                            CargarNcInternas();
                        }
                        else
                            MessageBox.Show("Coloca el producto no conforme en el rack de no conformidades", "Producto no conforme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Coloca la pieza en el rack de no conformidades", "Pieza rechazada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Selecciona el siguiente proceso", "Proceso siguiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmPlanTrabajoPlano planTrabajo = new FrmPlanTrabajoPlano(inspeccionar.IdPlano);
                    planTrabajo.Show();
                }

                PlanoProceso procesos = new PlanoProceso();
                procesos.CargarDatos(IdProceso);
                if (procesos.TieneFilas())
                {
                    procesos.Fila().ModificarCelda("comentarios", comentarios);
                    procesos.Fila().ModificarCelda("estatus", "TERMINADO");
                    procesos.Fila().ModificarCelda("maquina", "LABORATORIO DE CALIDAD");
                    procesos.Fila().ModificarCelda("operador", Global.UsuarioActual.NombreCompleto());
                    procesos.Fila().ModificarCelda("fecha_inicio", DateTime.Now);
                    procesos.Fila().ModificarCelda("fecha_termino", DateTime.Now);
                    procesos.GuardarDatos();
                }

                //BkgSubirPlano.RunWorkerAsync(new string[] { inspeccionar.RaizFtp, inspeccionar.RutaParcialSinExtension, inspeccionar.IdPlano.ToString(), });
                CargarProcesosPorInspeccionar();
            }
        }

        private void Rechazarpieza()
        {

        }

        private void AceptarPieza()
        {

        }

        public void InspeccionarEnsambleModulo()
        {
            FrmInspeccionarEnsambleModulo inspeccionModulo = new FrmInspeccionarEnsambleModulo();

            if(inspeccionModulo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarProcesosPorInspeccionar();
            }
        }

        private void BkgSubirPlano_DoWork(object sender, DoWorkEventArgs e)
        {
           /* string[] parametros = (string[])e.Argument;
            string raizFtp = parametros[0];
            string rutaParcialSinExtension = parametros[1];
            int idPlano = Convert.ToInt32(parametros[2]);
            byte[] datosImagen = DatosImagen;

            BkgSubirPlano.ReportProgress(0, "Conectando con servidor FTP... ");
            if (Global.TipoConexion == "LOCAL")
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
            else
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

            ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                           Global.UsuarioActual.Fila().Celda("password").ToString());

            //Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Connect();
                BkgSubirPlano.ReportProgress(40, "Conectando con servidor FTP... [OK]");

            }
            catch //(Exception ex)
            {
                BkgSubirPlano.ReportProgress(100, "Error de conexión con servidor FTP");
                return;
            }

           // string[] subensamble = rutaParcialSinExtension.Split('-');
            string rutaRemotaImagenRevision = raizFtp +  subensamble + "\\CP\\" + idPlano + " " + rutaParcialSinExtension + "_INS.PNG";
            
            if (ClienteFtp.DirectoryExists(raizFtp + subensamble + "\\CP"))
            {
                ClienteFtp.Upload((byte[])datosImagen, rutaRemotaImagenRevision, FtpExists.Overwrite);
            }
            else
            {
                ClienteFtp.CreateDirectory(raizFtp + subensamble + "\\CP");
                ClienteFtp.Upload((byte[])datosImagen, rutaRemotaImagenRevision, FtpExists.Overwrite);
            }
             */
        }

        private void verResultadoDeInspeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResultadosInspeccion noConformidad = new FrmResultadosInspeccion(Plano, IdProceso);
            noConformidad.Show();

        }

        private void CmbFiltroEstatusNcInterna_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNcInternas();
        }

        private void liberarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvNcInternas.SelectedRows.Count == 0) return;

            int idPlano = Convert.ToInt32(DgvNcInternas.SelectedRows[0].Cells["id_plano"].Value);

            FrmLiberarNoConformidad nc = new FrmLiberarNoConformidad(idPlano);

            if(nc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch(nc.Disposicion)
                {
                    case "SCRAP":
                        MessageBox.Show("Coloca el producto no conforme en contenedor de scrap", "Producto liberado como scrap", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "REPARACION":
                        MessageBox.Show("Entrega el producto no conforme al Supervisor de tool room para que sea reparado. Asegúrate de que tenga la etiqueta roja con el ID de trazabilidad.", "Producto liberado para reparación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                CargarNcInternas();
            }
            else
            {
                MessageBox.Show("Coloca el producto no conforme en el rack de no conformidades.", "Liberar no conformidad interna", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmEscanearPlano scan = new FrmEscanearPlano();
            if (scan.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int idPlano = scan.Id; 
                FrmPlanTrabajoPlano plan = new FrmPlanTrabajoPlano(idPlano, true);
                plan.ShowDialog();
            }
        }

        private void MenuNcInternas_Opening(object sender, CancelEventArgs e)
        {
            liberarToolStripMenuItem.Enabled = CmbEstatusNcInterna.Text == "SIN LIBERAR";
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoConformidad nCInterna = new NoConformidad();

            if (IdPlano != 0)
                nCInterna.SeleccionarPlano(IdPlano);
            else
                nCInterna.CargarDatos(Convert.ToInt32(DgvNcInternas.SelectedRows[0].Cells["idNcI"].Value));
           
            FrmAnalisisNcInterna analisisNc = new FrmAnalisisNcInterna(nCInterna.Filas());
            if(analisisNc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarNcInternas();
            }
        }

        private void DgvNcInternas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (CmbProcesoNcInterna.Text == "FABRICACION")
                IdPlano = Convert.ToInt32(DgvNcInternas.SelectedRows[0].Cells["id_plano"].Value);
            else
            {
                IdPlano = 0;
            }

            string estatusAnalisis = (string)DgvNcInternas.SelectedRows[0].Cells["analisis"].Value.ToString();
            if (estatusAnalisis == "PENDIENTE")
            {
                accionesToolStripMenuItem.Visible = true;
                consultarToolStripMenuItem.Visible = false;
            }
            else
            {
                accionesToolStripMenuItem.Visible = false;
                consultarToolStripMenuItem.Visible = true;
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoConformidad nCInterna = new NoConformidad();

            FrmAnalisisNcInterna analisisNc = new FrmAnalisisNcInterna(nCInterna.SeleccionarPlano(IdPlano), true);
            analisisNc.Show();
        }

        private void CmbProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbProcesoNcInterna.Text == "DISEÑO MECANICO")
            {
                DgvNcInternas.Columns["detalles_nc_interna"].Visible = true;
                DgvNcInternas.Columns["nombre_plano"].HeaderText = "Módulos afectados";
            }
            else if (CmbProcesoNcInterna.Text == "FABRICACION")
            {
                DgvNcInternas.Columns["detalles_nc_interna"].Visible = false;
                DgvNcInternas.Columns["nombre_plano"].HeaderText = "Plano";
            }

            CargarNcInternas();
        }

        private void DgvNcInternas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string celdaEstatus = DgvNcInternas.Rows[e.RowIndex].Cells["estatus_ncinterna"].Value.ToString();
            string estatusAnalisis = DgvNcInternas.Rows[e.RowIndex].Cells["analisis"].Value.ToString();

            if (celdaEstatus == "LIBERADO")
                DgvNcInternas.Rows[e.RowIndex].Cells["estatus_ncinterna"].Style.BackColor = Color.LightGreen;
            else if(celdaEstatus == "SIN LIBERAR")
                DgvNcInternas.Rows[e.RowIndex].Cells["estatus_ncinterna"].Style.BackColor = Color.Yellow;

            if(estatusAnalisis == "PENDIENTE")
                DgvNcInternas.Rows[e.RowIndex].Cells["analisis"].Style.BackColor = Color.Yellow;
            else if (estatusAnalisis == "FINALIZADO")
                DgvNcInternas.Rows[e.RowIndex].Cells["analisis"].Style.BackColor = Color.LightGreen;
        }

        private void CmbOrigenNcExterna_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNcExternas(CmbTipoNcExterna.Text, CmbEstatusAnalisisNcExterna.Text);
        }

        private void CmbEstatusAnalisisNcExterna_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNcExternas(CmbTipoNcExterna.Text, CmbEstatusAnalisisNcExterna.Text);
        }

        private void CmbEstatusAnalisisNcInterna_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNcInternas();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvNcExternas.SelectedRows.Count == 0)
                return;

            int idNcExterna = Convert.ToInt32(DgvNcExternas.SelectedRows[0].Cells["IdNcE"].Value);

            if(CmbTipoNcExterna.Text == "CLIENTE")
            {
                FrmAnalisisNcCliente ncc = new FrmAnalisisNcCliente(idNcExterna);
                ncc.Show();
            }
        }

        private void CargarTratamientos(string estatusTratamiento, string estatusProceso)
        {
            PlanoProyecto planoProyecto = new PlanoProyecto();
            DgvTratamientoMateriales.Rows.Clear();

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvTratamientoMateriales);

            planoProyecto.PiezasTratamientoEstatus(estatusTratamiento, estatusProceso).ForEach(delegate(Fila f)
            {                
                if(planoProyecto.TieneFilas())
                    DgvTratamientoMateriales.Rows.Add(false, f.Celda("idProceso"), f.Celda("id") + " | " + f.Celda("nombre_archivo"), f.Celda("proceso"), f.Celda("operador"), f.Celda("estatus"), f.Celda("vale_salida_tratamiento"));            
            });

            ConfiguracionDataGridView.Recuperar(cfg, DgvTratamientoMateriales);

            if (DgvTratamientoMateriales.Rows.Count > 0)
                DgvTratamientoMateriales.ClearSelection();
        }

        private void CmbEstatusTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEstatusTratamiento.Text == "PENDIENTE DE TRATAMIENTO")
            {
                DgvTratamientoMateriales.Columns[0].Visible = true;
                BtnValeSalida.Enabled = true;
                if (ListaPlanos.Count > 0)
                    BtnValeSalida.Enabled = true;
                else
                    BtnValeSalida.Enabled = false;
                CargarTratamientos(CmbEstatusTratamiento.Text, "PENDIENTE");
            }
            else
            {
                DgvTratamientoMateriales.Columns[0].Visible = false;
                BtnValeSalida.Enabled = false;
                CargarTratamientos(CmbEstatusTratamiento.Text, "EN PROCESO");
            }
        }

        private void DgvTratamientoMateriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (CmbEstatusTratamiento.Text == "PENDIENTE DE TRATAMIENTO")
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvTratamientoMateriales.Rows[e.RowIndex].Cells[0];
                if (chk.Value == chk.TrueValue)
                {
                    chk.Value = chk.FalseValue;
                    DgvTratamientoMateriales.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    DgvTratamientoMateriales.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    DgvTratamientoMateriales.Rows[e.RowIndex].Selected = false;
                    ListaProcesos.Remove(Convert.ToInt32(DgvTratamientoMateriales.Rows[e.RowIndex].Cells["id_proceso_tratamiento"].Value));
                }
                else
                {
                    chk.Value = chk.TrueValue;
                    DgvTratamientoMateriales.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                    DgvTratamientoMateriales.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    ListaProcesos.Add(Convert.ToInt32(DgvTratamientoMateriales.Rows[e.RowIndex].Cells["id_proceso_tratamiento"].Value));
                }

                if (ListaProcesos.Count > 0)
                    BtnValeSalida.Enabled = true;
                else
                    BtnValeSalida.Enabled = false;
            }
        }

        private void BtnValeSalida_Click(object sender, EventArgs e)
        {
            FrmGenerarValeSalidaPendienteTratamiento valeSalida = new FrmGenerarValeSalidaPendienteTratamiento(ListaProcesos);
            if(valeSalida.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (CmbEstatusTratamiento.Text == "PENDIENTE DE TRATAMIENTO")
                {
                    DgvTratamientoMateriales.Columns[0].Visible = true;
                    BtnValeSalida.Enabled = true;
                    ListaProcesos.Clear();
                    if (ListaProcesos.Count > 0)
                        BtnValeSalida.Enabled = true;
                    else
                        BtnValeSalida.Enabled = false;
                    CmbEstatusTratamiento.SelectedIndex = 1;
                }
                else
                {
                    DgvTratamientoMateriales.Columns[0].Visible = false;
                    BtnValeSalida.Enabled = false;
                    CargarTratamientos(CmbEstatusTratamiento.Text, "");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmRecibirPiezaTratamiento recibir = new FrmRecibirPiezaTratamiento();
            if(recibir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DgvTratamientoMateriales.Columns[0].Visible = false;
                BtnValeSalida.Enabled = false;
                CargarTratamientos(CmbEstatusTratamiento.Text, "EN PROCESO"); 
            }

            ListaProcesos.Clear();
        }

        private void CargarPiezasTerminadas()
        {
            DgvPiezasTerminadas.Rows.Clear();

            PlanoProyecto planoProyecto = new PlanoProyecto();
            planoProyecto.FabricacionTerminado().ForEach(delegate(Fila f)
            {
                if (planoProyecto.TieneFilas())
                    DgvPiezasTerminadas.Rows.Add(false, f.Celda("id") + " | " + f.Celda("nombre_archivo"), f.Celda("proyecto"), f.Celda("tratamiento"), "", f.Celda("estatus"));               
            });
        }

        private void CargarPiezasEntregadas()
        {
            DgvPiezasTerminadas.Rows.Clear();

            PlanoProyecto planoProyecto = new PlanoProyecto();
            planoProyecto.FabricacionEntregado(Convert.ToDateTime(DtpDel.Value), Convert.ToDateTime(DtpHasta.Value), Convert.ToInt32(NumLimite.Value)).ForEach(delegate(Fila f)
            {
                if (planoProyecto.TieneFilas())
                {
                    string usuarioEntrega = f.Celda("usuario_entrega").ToString();
                    if (usuarioEntrega.Contains('-'))
                        usuarioEntrega = usuarioEntrega.Split('-')[1].TrimStart();
                    string valeSalidaEntregado = string.Empty;

                    if (Convert.ToInt32(f.Celda("vale_salida_entrega")) > 0)
                        valeSalidaEntregado =  f.Celda("vale_salida_entrega").ToString().PadLeft(4,'0') + " | " + usuarioEntrega;
                    else
                        valeSalidaEntregado = usuarioEntrega;

                    DgvPiezasTerminadas.Rows.Add(false, f.Celda("id") + " | " + f.Celda("nombre_archivo"), f.Celda("proyecto"), f.Celda("tratamiento"), valeSalidaEntregado, f.Celda("estatus"));
                }
            });
        }

        private void BtnEntregarPiezas_Click(object sender, EventArgs e)
        {
            FrmValeSalidaCalidad entregar = new FrmValeSalidaCalidad(ListaPlanos);
            if (entregar.ShowDialog() == DialogResult.OK)
            {
                ListaPlanos.Clear();
                CargarPiezasTerminadas();
            }
        }

        private void DgvPiezasTerminadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (CmbPiezaTerminada.Text == "TERMINADO")
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvPiezasTerminadas.Rows[e.RowIndex].Cells[0];
                if (chk.Value == chk.TrueValue)
                {
                    chk.Value = chk.FalseValue;
                    DgvPiezasTerminadas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    DgvPiezasTerminadas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    DgvPiezasTerminadas.Rows[e.RowIndex].Selected = false;
                    ListaPlanos.Remove(Convert.ToInt32(DgvPiezasTerminadas.Rows[e.RowIndex].Cells["pz_entregada_plano"].Value.ToString().Split('|')[0].Trim()));
                }
                else
                {
                    chk.Value = chk.TrueValue;
                    DgvPiezasTerminadas.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                    DgvPiezasTerminadas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    ListaPlanos.Add(Convert.ToInt32(DgvPiezasTerminadas.Rows[e.RowIndex].Cells["pz_entregada_plano"].Value.ToString().Split('|')[0].Trim()));
                }
                BtnEntregarPiezas.Enabled = (ListaPlanos.Count > 0);
            }
        }

        private void CmbPiezaTerminada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbPiezaTerminada.Text == "TERMINADO")
            {
                DgvPiezasTerminadas.Columns[0].Visible = true;
                DgvPiezasTerminadas.Columns[4].Visible = false;
                BtnEntregarPiezas.Enabled = (ListaPlanos.Count > 0);
                DtpDel.Enabled = false;
                DtpHasta.Enabled = false;
                NumLimite.Enabled = false;
                CargarPiezasTerminadas();
            }
            else if (CmbPiezaTerminada.Text == "ENTREGADO")
            {
                DgvPiezasTerminadas.Columns[0].Visible = false;
                DgvPiezasTerminadas.Columns[4].Visible = true;
                BtnEntregarPiezas.Enabled = false;
                DtpDel.Enabled = true;
                DtpHasta.Enabled = true;
                NumLimite.Enabled = true;
                CargarPiezasEntregadas();
            }
        }

        private void MenuTratamiento_Opening(object sender, CancelEventArgs e)
        {
            int valeSalida = Convert.ToInt32(DgvTratamientoMateriales.SelectedRows[0].Cells["vale_salida"].Value);

            if (CmbEstatusTratamiento.Text == "EN TRATAMIENTO" && valeSalida > 0)
                valeDeSalidaToolStripMenuItem.Visible = true;
            else
                valeDeSalidaToolStripMenuItem.Visible = false;
        }

        private void valeDeSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] valeDatos = null;
            int valeSalida = Convert.ToInt32(DgvTratamientoMateriales.SelectedRows[0].Cells["vale_salida"].Value);

            if (!ClienteFtp.IsConnected)
            {
                if (Global.TipoConexion == "LOCAL")
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                else
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());

                // Verificar conexion con servidor FTP
                try
                {
                    ClienteFtp.Connect();
                }
                catch
                {
                    return;
                }
            }

                ClienteFtp.Download(out valeDatos, "SGC\\VALES_SALIDA\\" + valeSalida.ToString() + ".pdf");
                FrmVisorPDF visor = new FrmVisorPDF(valeDatos, "Vale de salida " + valeSalida.ToString());
                if (valeDatos != null)
                    visor.Show();
            
        }

        private void DtpDel_ValueChanged(object sender, EventArgs e)
        {
            if (CmbPiezaTerminada.Text == "ENTREGADO")
            {
                DgvPiezasTerminadas.Columns[0].Visible = false;
                BtnEntregarPiezas.Enabled = false;
                DtpDel.Enabled = true;
                DtpHasta.Enabled = true;
                NumLimite.Enabled = true;
                CargarPiezasEntregadas();
            }
        }

        private void DtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (CmbPiezaTerminada.Text == "ENTREGADO")
            {
                DgvPiezasTerminadas.Columns[0].Visible = false;
                BtnEntregarPiezas.Enabled = false;
                DtpDel.Enabled = true;
                DtpHasta.Enabled = true;
                NumLimite.Enabled = true;
                CargarPiezasEntregadas();
            }
        }

        private void NumLimite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbPiezaTerminada.Text == "ENTREGADO")
                {
                    DgvPiezasTerminadas.Columns[0].Visible = false;
                    BtnEntregarPiezas.Enabled = false;
                    DtpDel.Enabled = true;
                    DtpHasta.Enabled = true;
                    NumLimite.Enabled = true;
                    CargarPiezasEntregadas();
                }
            }
        }

        private void DtpDel_Validating(object sender, CancelEventArgs e)
        {

        }

        private void verValeDeSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] valeDatos = null;
            int valeSalida = Convert.ToInt32(DgvPiezasTerminadas.SelectedRows[0].Cells["vale_entrega"].Value.ToString().Split('|')[0].TrimEnd());

            if (!ClienteFtp.IsConnected)
            {
                if (Global.TipoConexion == "LOCAL")
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                else
                    ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
                ClienteFtp.Connect();
            }
            // Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Download(out valeDatos, "SGC\\VALES_SALIDA\\" + valeSalida.ToString() + ".pdf");
                FrmVisorPDF visor = new FrmVisorPDF(valeDatos, "Vale de entrega de piezas  " + valeSalida.ToString());
                if (valeDatos != null)
                    visor.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error mientras se descargaba el vale de entrega de piezas terminadas." + Environment.NewLine + "Error: " + ex.ToString(), "Ocurrió un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void MenuValeEntrega_Opening(object sender, CancelEventArgs e)
        {
            if (CmbPiezaTerminada.Text != "ENTREGADO")
            {
                verValeDeSalidaToolStripMenuItem.Visible = false;
                return;
            }

            if (DgvPiezasTerminadas.SelectedRows[0].Cells["vale_entrega"].Value.ToString().Contains("|"))
                verValeDeSalidaToolStripMenuItem.Visible = true;
            else
                verValeDeSalidaToolStripMenuItem.Visible = false;
        }

        private void BtnKpis_Click(object sender, EventArgs e)
        {
            FrmBuscadorKPIs kpis = new FrmBuscadorKPIs();
            kpis.Show();
        }
    }
}
