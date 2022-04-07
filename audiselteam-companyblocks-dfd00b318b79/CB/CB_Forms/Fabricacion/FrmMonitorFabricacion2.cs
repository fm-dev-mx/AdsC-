using CB_Base.Classes;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CB_Base.CB_Forms.Fabricacion;

namespace CB
{
    public partial class FrmMonitorFabricacion2 : Form
    {
        PlanoProyecto BuscadorPlanos = new PlanoProyecto();
        PlanoProceso BuscadorProcesosFabricacion = new PlanoProceso();
        FtpClient ClienteFtp = new FtpClient();
        TreeNode NodoPorDescartar = null;
        TreeNode NodoReparacion = null;
        TreeNode NodoUrgencias = null;
        TreeNode NodoRecientes = null;
        TreeNode NodoRegular = null;
        TreeNode NodoScrap = null;
        Modulo BuscadorModulos = new Modulo();
        string RaizFtp = string.Empty;
        string NombreArchivo = string.Empty;
        byte[] DatosPlano = null;
        byte[] Archivo = null;
        bool PlanoDescargado = false;
        bool PdfDescargado = false;
        Form Contenido = null;

        public FrmMonitorFabricacion2()
        {
            InitializeComponent();
        }

        private void FrmMonitorFabricacion2_Load(object sender, EventArgs e)
        {
            asignarToolStripMenuItem.Visible = false;
            estimarTiempoToolStripMenuItem.Visible = false;


            ActiveControl = BtnBuscar;
            LblEstatusResultado.Visible = false;
            BtnBuscar.Focus();
            NodoRegular = Global.CrearNodo("raiz-regular","FABRICACION REGULAR");
            NodoReparacion = Global.CrearNodo("raiz-reparacion", "REPARACION", 11);
            NodoScrap = Global.CrearNodo("raiz-scrap", "SCRAP", 12);
            NodoPorDescartar = Global.CrearNodo("raiz-porDescartar", "POR DESCARTAR", 19);
            NodoUrgencias = Global.CrearNodo("raiz-urgencias", "URGENCIAS", 20);
            NodoRecientes = Global.CrearNodo("raiz-reciente", "RECIENTES (5 días)", 8);
            TvMetas.Nodes.AddRange(new TreeNode[] { NodoRegular, NodoReparacion, NodoScrap, NodoPorDescartar, NodoUrgencias, NodoRecientes });                   
        }

        private void TvMetas_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNodeCollection raiz = null;

            if (e.Node.Name.StartsWith("raiz"))
                raiz = TvMetas.Nodes;
            else 
                raiz = e.Node.Parent.Nodes;
           

            if(raiz != null)
            {
                foreach (TreeNode nodo in raiz)
                {
                    if (nodo.Name != e.Node.Name)
                        nodo.Collapse();
                }
            }
        }

        private void TvMetas_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TvMetas.SelectedNode = e.Node;

            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.Node.Name.StartsWith("plano"))
                {
                    if(e.Node.Parent != NodoPorDescartar)
                    {
                        // Nodos urgencia
                        if (e.Node.Parent.Parent != null && e.Node.Parent.Parent.Name.Contains("raiz-urgencias"))
                        {
                            if(e.Node.Parent.Name.Contains("PENDIENTE"))
                                MenuPlanosUrgencias.Show(TvMetas, e.Location);
                            else if(e.Node.Parent.Name.Contains("AUTORIZADO"))
                                MenuPlanos.Show(TvMetas, e.Location);
                            else if (e.Node.Parent.Name.Contains("RECHAZADO"))
                                MenuPlanosUrgencias.Show(TvMetas, e.Location);
                        }
                        else
                        { 
                            MenuPlanos.Show(TvMetas, e.Location);
                        }
                    }
                    else
                    {
                        MenuDescartar.Show(TvMetas, e.Location);
                    }
                }
                else if (e.Node.Name.StartsWith("proceso"))
                    MenuProcesos.Show(TvMetas, e.Location);
                else if (e.Node.Name.StartsWith("proveedor"))
                    MenuProveedor.Show(TvMetas, e.Location);
                else if (e.Node.Name.StartsWith("meta"))
                    MenuMeta.Show(TvMetas, e.Location);
                else if (e.Node.Name.StartsWith("modulo"))
                   MenuModulo.Show(TvMetas, e.Location);
            }
        }

        private void agregarProcesoInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);

            FrmAgregarProcesoPlano2 agregar = new FrmAgregarProcesoPlano2(idPlano, 0, 0, DatosPlano);
            
            if(agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PlanoProceso.Modelo().ReordenarProcesos(idPlano);
                CargarProcesosPlano(TvMetas.SelectedNode, idPlano);
                TvMetas.SelectedNode.ExpandAll();
                PlanoEnPreparacion(idPlano);
            }
        }

        private void PlanoEnPreparacion(int idPlano)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlano);

            if (plano.TieneFilas())
            {
                if (plano.Fila().Celda("estatus").ToString() == "PENDIENTE")
                {
                    plano.Fila().ModificarCelda("estatus", "EN PREPARACION");
                    LblEstatus.Text = "EN PREPARACION";
                    plano.GuardarDatos();
                    MessageBox.Show("El plano fue colocado EN PREPARACION.",
                                    "Plano en preparación.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AgregarSiguienteProceso()
        {
            int idPlano = 0;
            int idProcesoSeleccionado = Convert.ToInt32(TvMetas.SelectedNode.Text.Split(' ')[0]); ;

            PlanoProceso procesoAnterior = new PlanoProceso();
            procesoAnterior.CargarDatos(idProcesoSeleccionado);

            if (procesoAnterior.TieneFilas())
                idPlano = Convert.ToInt32(procesoAnterior.Fila().Celda("plano"));

            FrmAgregarProcesoPlano2 agregar = new FrmAgregarProcesoPlano2(idPlano, Convert.ToInt32(procesoAnterior.Fila().Celda("orden")) + 5, Convert.ToInt32(procesoAnterior.Fila().Celda("id")), DatosPlano);

            if (agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarProcesosPlano(TvMetas.SelectedNode.Parent, idPlano);
            }
        }

        private void agregarSiguienteProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarSiguienteProceso();
        }

        private void eliminarProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idPlano = 0;
            DialogResult resp = MessageBox.Show("¿Seguro que quieres eliminar el proceso seleccionado?", "Eliminar proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            int idProcesoSeleccionado = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            BuscadorProcesosFabricacion.CargarDatos(idProcesoSeleccionado);

            if (BuscadorProcesosFabricacion.TieneFilas())
                idPlano = Convert.ToInt32(BuscadorProcesosFabricacion.Fila().Celda("plano"));

            BuscadorProcesosFabricacion.BorrarDatos();
            PlanoProceso.Modelo().ReordenarProcesos(idPlano);
            ActualizarNombrePlano(idPlano, TvMetas.SelectedNode);
            CargarProcesosPlano(TvMetas.SelectedNode.Parent, idPlano);
        }

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            int idPlano = Convert.ToInt32(e.Argument);
            string rutaPlanoFtp = string.Empty;

            DatosPlano = ServidorFtp.DescargarPlano(idPlano, FormatoArchivo.Png, BkgDescargarPlano, out rutaPlanoFtp);

            if (DatosPlano != null)
            {
                PlanoDescargado = true;
                BkgDescargarPlano.ReportProgress(100, "Procesando plano");
                e.Result = Path.GetFileNameWithoutExtension(rutaPlanoFtp);
            }
            else
            {
                PlanoDescargado = false;
                BkgDescargarPlano.ReportProgress(100, "Error al descargar plano");
                e.Result = string.Empty;
            } 
        }

        private void BkgDescargarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PlanoDescargado)
            {
                string nombrePlano = e.Result.ToString(); 
                FrmVisorImagen visor = new FrmVisorImagen(DatosPlano, nombrePlano);
                visor.WindowState = FormWindowState.Maximized;
                MostrarContenido(visor);
                LblEstatus.Text = "Plano descargado";
                Progress.Visible = false;
                LblEstatusResultado.Text = " OK ";
                LblEstatusResultado.BackColor = Color.Lime;
                LblEstatusResultado.Visible = true;
                Progress.Value = 0;
            }
            else
            {
                OcultarContenido();
                LblEstatus.Text = "Error al descargar el plano";
                Progress.Visible = false;
                LblEstatusResultado.Text = " ERROR ";
                LblEstatusResultado.BackColor = Color.Crimson;
                LblEstatusResultado.Visible = true;
                Progress.Value = 0;
            }
            TvMetas.Enabled = true;
        }

        public void OcultarContenido()
        {
            if(Contenido != null)
            {
                if (Contenido.Visible)
                    Contenido.Close();
            }
        }

        private void BkgDescargarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progress.Value = e.ProgressPercentage;
        }

        public void MostrarContenido(Form ventana)
        {
            if(Contenido != null)
                Contenido.Close();

            Contenido = ventana;
            ventana.MdiParent = this;
            ventana.Show();
        }

        private void TvMetas_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodo(e.Node);
        }

        private void RefrescarNodo(TreeNode nodoPadre)
        {
            string[] nombreDividido = nodoPadre.Name.ToString().Split('-');

            switch (nombreDividido[0].ToString())
            {
                case "meta":
                    CargarInformacionParaMeta(nodoPadre, Convert.ToInt32(nombreDividido[1]));
                    break;
                case "modulo":
                    CargarPlanosParaModulos(nodoPadre, Convert.ToInt32(nombreDividido[1]), true);
                    break;
                case "plano":
                    if (nodoPadre.Parent != NodoPorDescartar)
                    {
                        CargarCarpetasPlanos(nodoPadre);
                    }
                    else
                    {
                        DescartarPlano(Convert.ToInt32(nodoPadre.Name.Split('-')[1]));
                    }
                    break;
                case "planoprocesos":
                    CargarProcesosPlano(nodoPadre, Convert.ToInt32(nombreDividido[1]));
                    break;
                case "planomateriales":
                    CargarMaterialesPlano(nodoPadre, Convert.ToInt32(nombreDividido[1]));
                    break;
                case "material":
                    MostrarContenido(new FrmDetallesMaterialProyecto(Convert.ToInt32(nombreDividido[1])));
                    break;
                case "raiz":
                    if (nodoPadre == NodoRegular)
                        CargarMetas();
                    else if (nodoPadre == NodoReparacion)
                        CargarReparaciones();
                    else if (nodoPadre == NodoScrap)
                        CargarScrap();
                    else if (nodoPadre == NodoPorDescartar)
                        CargarPorDescartar();
                    else if (nodoPadre == NodoUrgencias)
                        CargarCarpetasUrgencias();
                    else if (nodoPadre == NodoRecientes)
                        CargarPlanosRecientes();
                    break;
                case "urgenciaRaiz":
                    CargarPlanosUrgencia(nodoPadre, nodoPadre.Name.Split('-')[1]);
                    break;
                default:
                    break;
            } 
        }

        public void CargarPlanosUrgencia(TreeNode nodoPadre, string estatusUrgencia)
        {
            nodoPadre.Nodes.Clear();

            PlanoProyecto planosUrgencias = new PlanoProyecto();
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@estatusUrgencia", estatusUrgencia);

            planosUrgencias.SeleccionarDatos("estatus_urgencia=@estatusUrgencia", parametros, "id");

            planosUrgencias.Filas().ForEach(delegate(Fila plano) { 
               
                CargarPlanoParaNodo(nodoPadre, plano.Celda<int>("id"));
            
            });

            nodoPadre.Expand();
        }

        public void CargarCarpetasUrgencias()
        {
            NodoUrgencias.Nodes.Clear();
            TreeNode[] carpetasUrgencias = new TreeNode[]
            {
                Global.CrearNodo("urgenciaRaiz-PENDIENTE","PENDIENTES"),
                Global.CrearNodo("urgenciaRaiz-RECHAZADO","RECHAZADOS"),
                Global.CrearNodo("urgenciaRaiz-AUTORIZADO","AUTORIZADOS")
            };

            NodoUrgencias.Nodes.AddRange(carpetasUrgencias);
            NodoUrgencias.Expand();
        }

        public void CargarMetas()
        {
            NodoRegular.Nodes.Clear();
            Meta BuscadorMetas = new Meta();

            BuscadorMetas.SeleccionarAutorizadasProceso(1, "ASC").ForEach(delegate(Fila meta)
            {
                if (Convert.ToDecimal(meta.Celda("avance")) < 100)
                {
                    TreeNode nodoTemp = CrearNodoMetaFabricacion(meta);

                    switch(meta.Celda("tipo_entregable").ToString())
                    {
                        case "MODULO FABRICADO":
                        case "MODULO CONGELADO":
                            if (Meta.Modelo().MetaDeModulosContieneUrgencia(meta.Celda<int>("id")))
                                nodoTemp.BackColor = Color.LightPink;
                            break;
                        case "PARTE FABRICADA":
                            if (Meta.Modelo().MetaDePlanoContieneUrgencia(meta.Celda<int>("id")))
                                nodoTemp.BackColor = Color.LightPink;
                            break;
                    }


                    NodoRegular.Nodes.Add(nodoTemp);
                }
            });

            NodoRegular.Expand();
        }

        public void CargarReparaciones()
        {
            NodoReparacion.Nodes.Clear();
            PlanoProyecto planos = new PlanoProyecto();
            planos.SeleccionarPlanosPorEstadoFabricacion("REPARACION");

            planos.Filas().ForEach(delegate(Fila f)
            {
                CargarPlanoParaNodo(NodoReparacion, f.Celda<int>("id"));
            });           
        }

        public void CargarPlanosRecientes()
        {
            NodoRecientes.Nodes.Clear();
            PlanoProyecto planos = new PlanoProyecto();
            planos.SeleccionarPlanosRecientes();

            planos.Filas().ForEach(delegate(Fila f) 
            {
                CargarPlanoParaNodo(NodoRecientes, f.Celda<int>("id"));
            });
        }

        private void CargarScrap()
        {
            NodoScrap.Nodes.Clear();
            PlanoProyecto planos = new PlanoProyecto();
            planos.SeleccionarPlanosPorEstadoFabricacion("SCRAP").ForEach(delegate(Fila f)
            {
                CargarPlanoParaNodo(NodoScrap, f.Celda<int>("id"));
            });   
        }

        private void CargarPorDescartar()
        {
            NodoPorDescartar.Nodes.Clear();
            PlanoProyecto planos = new PlanoProyecto();
            planos.SeleccionarPlanosPorEstadoFabricacion("POR DESCARTAR").ForEach(delegate(Fila f)
            {
                CargarPlanoParaNodo(NodoPorDescartar, f.Celda<int>("id"));
            }); 
        }

        TreeNode CrearNodoMetaFabricacion(Fila meta)
        {
            return Global.CrearNodo(
                "meta-" + meta.Celda("id").ToString(),
                 meta.Celda("id").ToString().PadLeft(4, '0') + " | " + Convert.ToDecimal(meta.Celda("proyecto")).ToString("F2") + " | " + Global.FechaATexto(meta.Celda("fecha_promesa"), false) + " [" + Convert.ToDecimal(meta.Celda("avance")).ToString("F2") + "%]",
                 0
                 );
        }

        private void CargarInformacionParaMeta(TreeNode nodoPadre, int idMeta)
        {
            MetaEntregable entregables = new MetaEntregable();
            entregables.SeleccionarMeta(idMeta);
            string tipoEntregable = entregables.Fila().Celda<string>("tipo_entregable");
            

            switch (tipoEntregable)
            {
                case "MODULO FABRICADO":
                    CargarModulosParaMeta(nodoPadre, idMeta);
                    break;
                case "PARTE FABRICADA":
                    nodoPadre.Nodes.Clear();
                    entregables.Filas().ForEach(delegate(Fila f)
                    {
                        int idEntregable = f.Celda<int>("id_entregable");
                        CargarPlanoParaNodo(nodoPadre, idEntregable, true);
                    });
                    
                    break;
                default:
                    break;
            }
        }

        private void CargarPlanosParaModulos(TreeNode nodoPadre, int idModulo, bool noMostrarFinalizados = false)
        {
            nodoPadre.Nodes.Clear();
            Modulo modulo = new Modulo();
            modulo.CargarDatos(idModulo);
            if (modulo.TieneFilas())
            {
                decimal proyecto = Convert.ToDecimal(modulo.Fila().Celda("proyecto"));
                int subensamble = modulo.Fila().Celda<int>("subensamble");

                PlanoProyecto planos = new PlanoProyecto();
                planos.SeleccionarPlanosDeModulo(proyecto, subensamble, noMostrarFinalizados).ForEach(delegate(Fila f)
                {
                    CargarPlanoParaNodo(nodoPadre, f.Celda<int>("id"), noMostrarFinalizados);
                });
            }
        }

        private void CargarMaterialesPlano(TreeNode nodoPadre, int p)
        {
            MaterialProyecto material = new MaterialProyecto();
            material.SeleccionarMaterialDeFabricacionDePlano(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1])).ForEach(delegate(Fila f)
            {
                nodoPadre.Nodes.Add(
                    Global.CrearNodo(
                        "material-" + f.Celda<int>("id"),
                        f.Celda("id").ToString() + " | " + f.Celda("estatus_compra"),
                        EstadoAIndiceDeIcono(f.Celda("estatus_compra").ToString())
                    )
                );
            });

            /*nodoPadre.Nodes.Clear();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", TvMetas.SelectedNode.Parent.Name.Split('-')[1]);
            MaterialProyecto.Modelo().SeleccionarDatos("plano = @plano", parametros).ForEach(delegate(Fila f)
            {
                nodoPadre.Nodes.Add(
                    Global.CrearNodo(
                        "material-" + f.Celda<int>("id"),
                        f.Celda("id").ToString() + " | " + f.Celda("estatus_compra"),
                        EstadoAIndiceDeIcono(f.Celda("estatus_compra").ToString())
                    )
                );
            });*/

            nodoPadre.Expand();
        }

        private int EstadoAIndiceDeIcono(string estado)
        {
            switch (estado)
            {
                case "EN COTIZACION":
                    return 14;
                case "PENDIENTE":
                    return 13;
                case "ORDEN ASIGNADA":
                    return 15;
                default:
                    return 16;
            }
        }

        private void CargarModulosParaMeta(TreeNode nodoPadre, int idMeta)
        {
            nodoPadre.Nodes.Clear();
            MetaEntregable entregable = new MetaEntregable();
            entregable.SeleccionarMeta(idMeta).ForEach(delegate(Fila f)
            {
                Modulo modulo = new Modulo();
                modulo.CargarDatos(f.Celda<int>("id_entregable"));

                TreeNode nodoTemp = Global.CrearNodo(
                        "modulo-" + f.Celda("id_entregable").ToString(),
                        modulo.Fila().Celda("subensamble").ToString().PadLeft(2, '0') + " " + modulo.Fila().Celda("nombre").ToString(),
                        1
                        );

                nodoPadre.Nodes.Add(nodoTemp);
                nodoPadre.Expand();
            });
        }

        private void CargarPlanoParaNodo(TreeNode nodoPadre, int idPlano, bool noMostrarTerminados = false, ContextMenuStrip ctxMenu = null)
        {
            TreeNode nodoModulo = nodoPadre;
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlano);

            if (noMostrarTerminados && !new string[] { "PRELIMINAR", "EN FABRICACION", "PENDIENTE", "EN PREPARACION", "PENDIENTE DE TRATAMIENTO" }.Contains(plano.Fila().Celda<string>("estatus")))
                return;

            int indiceImagen = 0;
            string estatus = plano.Fila().Celda("estatus").ToString();
            string nodoTexto = idPlano + " " + plano.Fila().Celda("nombre_archivo").ToString();

            TimeSpan tiempoTrabajoEstimado = PlanoProyecto.Modelo().TiempoTrabajoEstimado(idPlano);

            /*if (tiempoTrabajoEstimado.TotalSeconds > 0)
                nodoTexto += " [" + tiempoTrabajoEstimado.ToString("h\\:mm") + " hrs]";
             else
            {
                //verificar si el plano esta con fabricante
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@plano", idPlano);

                PlanoProceso procesos = new PlanoProceso();
                procesos.SeleccionarDatos("plano=@plano and requisicion_compra > 0", parametros);

                if(procesos.TieneFilas())
                    nodoTexto += " [PROVEEDOR]";
            }
*/
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);

            string estatusPlano = "'EN PROCESO', 'PENDIENTE', 'TIEMPO ESTIMADO', 'ASIGNADO'";
            PlanoProceso procesos = new PlanoProceso();
            procesos.SeleccionarDatos("plano = @plano and estatus in (" + estatusPlano + ") and requisicion_compra = 0 ", parametros);
            if(procesos.TieneFilas())
            {
                nodoTexto += " [EN PROCESO]";
            }
            else
            {
                //verificar si el plano esta con fabricante
                parametros.Clear();
                parametros.Add("@plano", idPlano);

                procesos = new PlanoProceso();
                procesos.SeleccionarDatos("plano=@plano and requisicion_compra > 0", parametros);

                if(procesos.TieneFilas())
                    nodoTexto += " [PROVEEDOR]";
            }

            switch (estatus)
            {
                case "PENDIENTE":
                case "EN PREPARACION":
                case "EN FABRICACION":
                case "DESCARTADO":
                    indiceImagen = 2;
                    break;
                case "REPARACION":
                case "SCRAP":
                case "POR DESCARTAR":
                    indiceImagen = 18;
                    break;
                default:
                     indiceImagen = 10;
                    break;
            }

            TreeNode nodoTemp = Global.CrearNodo(
                "plano-" + idPlano,
                nodoTexto,
                indiceImagen
                );

            string estatusUrgencia = Global.ObjetoATexto(plano.Fila().Celda("estatus_urgencia"), "N/A");

            if(plano.TieneFilas() && (estatusUrgencia == "AUTORIZADO" || estatusUrgencia == "PENDIENTE"))
            { 
                nodoTemp.BackColor = Color.LightPink;            
            }

            if(ctxMenu != null)
            {
                nodoTemp.ContextMenuStrip = ctxMenu;
            }

            nodoPadre.Nodes.Add(nodoTemp);
            nodoPadre.Expand();          
        }

        private void CargarCarpetasPlanos(TreeNode nodoPadre)
        {
            if (nodoPadre.Parent.Name.Contains("urgenciaRaiz") && !nodoPadre.Parent.Name.Contains("AUTORIZADO"))
            {
                int idPlano = Convert.ToInt32(nodoPadre.Name.Split('-')[1]);
                MostrarPlano(idPlano);
                return;
            }
            nodoPadre.Nodes.Clear();
            nodoPadre.Nodes.Add(
                Global.CrearNodo(
                    "planoprocesos-" + nodoPadre.Name.Split('-')[1],
                    "PROCESOS",
                    17,
                    MenuProcesosPlanos
                    )
                );

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]));
            int imagen = 3;
            string textoNodo = "MATERIAL SIN UBICAR";

            switch (plano.Fila().Celda("estatus_material").ToString())
            {
                case "N/A":
                    imagen = 3;
                    textoNodo = "MATERIAL SIN UBICAR";
                    break;
                case "EN STOCK":
                    textoNodo = "MATERIAL [" + plano.Fila().Celda("estatus_material").ToString() + "]";
                    imagen = 7;
                    break;
            }

            MaterialProyecto materialFabricacion = new MaterialProyecto();
            materialFabricacion.SeleccionarMaterialDeFabricacionDePlano(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1])).ForEach(delegate(Fila f)
            {
                if(plano.Fila().Celda("estatus_material").ToString() == "SOLICITADO")
                {
                    textoNodo = "MATERIAL [" + plano.Fila().Celda("estatus_material").ToString() + "]";
                    imagen = 7;
                }
            });

            nodoPadre.Nodes.Add(
                Global.CrearNodo(
                    "planomateriales-" + nodoPadre.Name.Split('-')[1],
                    textoNodo,
                    imagen,
                    MenuMaterial
                    )
                );

            nodoPadre.Expand();
        }

        public void CargarProcesosPlano(TreeNode nodoBase, int idPlano)
        {
            nodoBase.Nodes.Clear();
            PlanoProceso pp = new PlanoProceso();
            pp.CargarDePlano(idPlano).ForEach(delegate(Fila proc)
            {
                TreeNode nodoProc = new TreeNode();
                nodoProc.SelectedImageIndex = 0;
                nodoProc.ImageIndex = 0;

                // Proceso local
                if (Convert.ToInt32(proc.Celda("requisicion_compra")) <= 0)
                {
                    nodoProc.Name = "proceso-" + proc.Celda("id").ToString();
                    ActualizarImagenNodos(proc.Celda("estatus").ToString(), nodoProc);
                }
                else // Proceso con proveedor
                {
                    nodoProc.Name = "proveedor-" + proc.Celda("requisicion_compra").ToString();
                    ActualizarImagenNodos("PROVEEDOR", nodoProc);
                }

                if (Global.ObjetoATexto(proc.Celda("operador"), "N/A") != "N/A")
                    nodoProc.ToolTipText = "ASIGNADO A " + proc.Celda("operador").ToString();

                string strTiempoEstimado = string.Empty;
                object tiempoEstimado = proc.Celda("tiempo_trabajo_estimado");

                if (tiempoEstimado != null)
                    strTiempoEstimado = " " + "[" + TimeSpan.FromHours(Convert.ToDouble(tiempoEstimado)).ToString("h\\:mm").ToString() + " hrs]";

                nodoProc.Text = proc.Celda("id").ToString().PadLeft(5, '0') + " " + proc.Celda("proceso").ToString() + strTiempoEstimado;
                nodoBase.Nodes.Add(nodoProc);
                
            });
            nodoBase.Expand();
            if (!pp.TieneFilas())
                MostrarPlano(idPlano);
        }

        private void TvMetas_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string tipoNodo = e.Node.Name.Split('-')[0];

            if(tipoNodo == "plano")
            {
                int idPlano = Convert.ToInt32(e.Node.Name.Split('-')[1]);
                MostrarPlano(idPlano);
            }
        }

        private void MostrarPlano(int idPlano)
        {
            LblEstatusResultado.Visible = false;

            TvMetas.Enabled = false;
            if (!BkgDescargarPlano.IsBusy)
                BkgDescargarPlano.RunWorkerAsync(idPlano);
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idProceso = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]);

            FrmAsignarProcesoFabricacion2 asignar = new FrmAsignarProcesoFabricacion2(idProceso, idPlano);
            if (asignar.ShowDialog() == DialogResult.OK)
            {
                PlanoProceso proc = new PlanoProceso();
                proc.CargarDatos(idProceso);

                //Modificar proceso
                if (proc.TieneFilas())
                {
                    string[] datosOperador = asignar.Herramenstista.Split('-');
                    string operador = datosOperador[1].TrimStart();
                    int idHerramentista = Convert.ToInt32(datosOperador[0].TrimEnd());

                    proc.Fila().ModificarCelda("maquina", asignar.MaquinaHerramienta);
                    proc.Fila().ModificarCelda("programador", asignar.MaquinaHerramienta);
                    proc.Fila().ModificarCelda("operador", operador);
                    proc.Fila().ModificarCelda("herramentista", idHerramentista);
                    proc.Fila().ModificarCelda("comentarios", asignar.ComentariosSupervisor);

                    //if (proc.Fila().Celda("estatus").ToString() == "PENDIENTE")
                    proc.Fila().ModificarCelda("estatus", "ASIGNADO");

                    proc.Fila().ModificarCelda("fecha_asignacion", DateTime.Now);
                    proc.GuardarDatos();

                    TvMetas.SelectedNode.ToolTipText = operador;
                }

                ActualizarImagenNodos("ASIGNADO", TvMetas.SelectedNode);
            }
        }

        public void ActualizarImagenNodos(string estatus, TreeNode nodoSeleccionado)
        {
            switch (estatus)
            {
                case "PENDIENTE":
                    nodoSeleccionado.ImageIndex = 3;
                    nodoSeleccionado.SelectedImageIndex = 3;
                    break;
                case "ASIGNADO":
                    nodoSeleccionado.ImageIndex = 4;
                    nodoSeleccionado.SelectedImageIndex = 4;
                    break;
                case "EN PROCESO":
                    nodoSeleccionado.ImageIndex = 5;
                    nodoSeleccionado.SelectedImageIndex = 5;
                    break;
                case "DETENIDO":
                    nodoSeleccionado.ImageIndex = 6;
                    nodoSeleccionado.SelectedImageIndex = 6;
                    break;
                case "TERMINADO":
                    nodoSeleccionado.ImageIndex = 7;
                    nodoSeleccionado.SelectedImageIndex = 7;
                    break;
                case "TIEMPO ESTIMADO":
                    nodoSeleccionado.ImageIndex = 8;
                    nodoSeleccionado.SelectedImageIndex = 8;
                    break;
                case "PROVEEDOR":
                    nodoSeleccionado.ImageIndex = 9;
                    nodoSeleccionado.SelectedImageIndex = 9;                                        
                    break;
            }
        }

        private void estimarTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idProceso = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]);

            FrmEstimarTiempoFabricacion estimarTiempo = new FrmEstimarTiempoFabricacion(idProceso, idPlano);
            if (estimarTiempo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PlanoProceso proc = new PlanoProceso();
                proc.CargarDatos(idProceso);

                //Modificar proceso
                if (proc.TieneFilas())
                {
                    double costoEstandar = 0;

                    //Calcular costoEstimadoFabricación = CostoHrEstandar * TiempoEstimado
                    ProcesoFabricacion procesoFabricacion = new ProcesoFabricacion();
                    procesoFabricacion.BuscarProceso(estimarTiempo.Proceso);

                    if (procesoFabricacion.TieneFilas())
                        costoEstandar = Convert.ToDouble(procesoFabricacion.Fila().Celda("costo_estandar"));

                    double costoEstimadoFabricación = costoEstandar * estimarTiempo.TotalTiempoEstandar;

                    // if (proc.Fila().Celda("estatus").ToString() == "PENDIENTE")
                    proc.Fila().ModificarCelda("estatus", "TIEMPO ESTIMADO");
                    proc.Fila().ModificarCelda("tiempo_trabajo_estimado", estimarTiempo.TotalTiempoEstandar);
                    proc.Fila().ModificarCelda("costo_estimado_fabricacion", costoEstimadoFabricación);
                    int complejidad = 0;

                    switch (estimarTiempo.Complejidad)
                    {
                        case "NADA COMPLEJA":
                            complejidad = 1;
                            break;
                        case "POCO COMPLEJA":
                            complejidad = 2;
                            break;
                        case "COMPLEJA":
                            complejidad = 3;
                            break;
                        case "MUY COMPLEJA":
                            complejidad = 4;
                            break;
                        default:
                            break;
                    }
                    proc.Fila().ModificarCelda("nivel_complejidad", complejidad);

                    proc.GuardarDatos();

                    //guardar operaciones
                    foreach (Fila item in estimarTiempo.DatosOperacion)
                    {
                        PlanoOperacion.Modelo().Insertar(item);
                    }
                }

                ActualizarImagenNodos("TIEMPO ESTIMADO", TvMetas.SelectedNode);
                ActualizarNombrePlano(idPlano, TvMetas.SelectedNode);
            }
        }

        public void ActualizarNombrePlano(int idPlano, TreeNode nodoProceso)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlano);

            if(plano.TieneFilas())
            {
                nodoProceso.Parent.Text = idPlano + " " + plano.Fila().Celda("nombre_archivo");

                TimeSpan tiempoTrabajoEstimado = plano.TiempoTrabajoEstimado(idPlano);

                if (tiempoTrabajoEstimado.TotalSeconds > 0)
                    nodoProceso.Parent.Text += " [" + tiempoTrabajoEstimado.ToString("h\\:mm") + " hrs]";
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmEscanearPlano scan = new FrmEscanearPlano();
            if (scan.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscarNodoPlano(scan.Id);
            }
        }

        private void BuscarNodoPlano(int idPlano)
        {
            if (idPlano == 0)
            {
                return;
            }

            PlanoProyecto planos = new PlanoProyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", idPlano);

            planos.SeleccionarDatos("id =@plano and estatus NOT IN ('ENTREGADO', 'DESCARTADO', 'RECHAZADO', 'CANCELADO')", parametros);

            if (!planos.TieneFilas())
            {
                MessageBox.Show("El plano no fue encontrado", "Plano no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string estatusPlano = planos.Fila().Celda<string>("estatus");
            if (estatusPlano == "SCRAP")
            {
                CargarScrap();
                NodoScrap.Expand();
                NodoScrap.Nodes.Find("plano-" + idPlano, false)[0].Expand();
                TvMetas.SelectedNode = NodoScrap.Nodes.Find("plano-" + idPlano, false)[0];
            }
            else if (estatusPlano == "REPARACION")
            {
                CargarReparaciones();
                NodoReparacion.Expand();
                NodoReparacion.Nodes.Find("plano-" + idPlano, false)[0].Expand();
                TvMetas.SelectedNode = NodoReparacion.Nodes.Find("plano-" + idPlano, false)[0];
            }
            else if (estatusPlano == "POR DESCARTAR")
            {
                DescartarPlano(idPlano);
            }
            else
            {
                MetaEntregable metaEntregable = new MetaEntregable();
                metaEntregable.BuscarMetaDelEntregable("PARTE FABRICADA", idPlano);
                CargarMetas();

                bool planoEsEntregableDirecto = metaEntregable.TieneFilas();
                
                try {
                    // Verificar si el ID corresponde a una pieza.
                    if (planoEsEntregableDirecto)
                    {
                        TreeNode nodoMeta = NodoRegular.Nodes.Find("meta-" + metaEntregable.Fila().Celda<int>("meta"), false)[0];
                        CargarInformacionParaMeta(nodoMeta, metaEntregable.Fila().Celda<int>("meta"));
                        if (nodoMeta.Nodes.Find("plano-" + idPlano, false).Count() > 0)
                        {
                            TreeNode nodoPlano = nodoMeta.Nodes.Find("plano-" + idPlano, false)[0];
                            CargarProcesosPlano(nodoPlano, idPlano);
                        }
                    }
                }
                catch 
                {
                    planoEsEntregableDirecto = false;
                }

                // Caso en el que el ID corresponde a un módulo.
                if (!planoEsEntregableDirecto)
                {
                    PlanoProyecto plano = new PlanoProyecto();
                    Modulo modulo = new Modulo();

                    plano.CargarDatos(idPlano, "subensamble, proyecto");

                    if (!plano.TieneFilas())
                        return;

                    parametros = new Dictionary<string, Object>();

                    parametros.Add("@subensamble", plano.Fila().Celda("subensamble"));
                    parametros.Add("@proyecto", plano.Fila().Celda("proyecto"));
                    modulo.SeleccionarDatos("subensamble=@subensamble and proyecto=@proyecto", parametros, "id");

                    if (!modulo.TieneFilas())
                        return;

                    metaEntregable.BuscarMetaDelEntregable("MODULO FABRICADO", Convert.ToInt32(modulo.Fila().Celda("id").ToString()));

                    if (!metaEntregable.TieneFilas())
                        return;

                    TreeNode nodoMeta = NodoRegular.Nodes.Find("meta-" + metaEntregable.Fila().Celda<int>("meta"), false)[0];
                    CargarInformacionParaMeta(nodoMeta, metaEntregable.Fila().Celda<int>("meta"));
                    TreeNode nodoModulo = nodoMeta.Nodes.Find("modulo-" + metaEntregable.Fila().Celda<int>("id_entregable"), false)[0];
                    CargarPlanosParaModulos(nodoModulo, modulo.Fila().Celda<int>("id"), true);
                    if (nodoMeta.Nodes.Find("modulo-" + metaEntregable.Fila().Celda<int>("id_entregable"), false).Count() > 0)
                    {
                        TreeNode nodoPlano = nodoModulo.Nodes.Find("plano-" + idPlano, false)[0];
                        CargarProcesosPlano(nodoPlano, idPlano);
                    }
                }
            }
        }

        private void BtnValesSalida_Click(object sender, EventArgs e)
        {
            FrmEntregarPiezaFabricada vales = new FrmEntregarPiezaFabricada();
            vales.ShowDialog();
        }

        private void BtnProduccion_Click(object sender, EventArgs e)
        {
            FrmProduccion prod = new FrmProduccion();
            prod.Show();
        }

        private void BtnMantenimientoCorrectivo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de generar una orden de mantenimiento correctivo a una máquina?", "Orden de mantenimiento correctivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmGenerarOrdenMtoEquipoComputo ordenMantenimiento = new FrmGenerarOrdenMtoEquipoComputo("MAQUINARIA", "");
                ordenMantenimiento.Show();
            }
        }

        private void BtnKpis_Click(object sender, EventArgs e)
        {
            Proceso proceso = new Proceso();
            proceso.SeleccionarNombre("FABRICACION");
            int idProceso = 0;

            if (proceso.TieneFilas())
                idProceso = Convert.ToInt32(proceso.Fila().Celda("id"));

            FrmBuscadorKPIs kpis = new FrmBuscadorKPIs(idProceso);
            kpis.Show();
        }

        private void BtnTerminal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea entrar a la terminal de producción?, para salir de éste modo deberá ingresar su contraseña", "Modo terminal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                FrmTerminalFabricacion terminal = new FrmTerminalFabricacion();
                terminal.ShowDialog();
            }
        }

        private void MenuPlanos_Opening(object sender, CancelEventArgs e)
        {
            ubicarPlanoToolStripMenuItem.Visible = TvMetas.SelectedNode.Parent != null && TvMetas.SelectedNode.Parent == NodoRecientes;

            PlanoProyecto plano = new PlanoProyecto();
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            plano.CargarDatos(idPlano);

            if(plano.TieneFilas())
            {
                if (plano.Fila().Celda("estatus").ToString() == "FABRICADO")
                    fabricacionTerminadaToolStripMenuItem.Enabled = false;
                else
                {
                    PlanoProceso proceso = new PlanoProceso();
                    proceso.CargarDePlano(Convert.ToInt32(plano.Fila().Celda("id")));
                    if(proceso.TieneFilas())
                        fabricacionTerminadaToolStripMenuItem.Enabled = true;
                    else
                        fabricacionTerminadaToolStripMenuItem.Enabled = false;
                }
            }

            solicitarUrgenciaToolStripMenuItem.Visible = !TvMetas.SelectedNode.Parent.Name.Contains("urgenciaRaiz");
        }

        private void MenuProcesosPlanos_Opening(object sender, CancelEventArgs e)
        {
            PlanoProceso procesos = new PlanoProceso();
            procesos.CargarDePlano(Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]));

            AgregarProceso.Enabled = !(procesos.TieneFilas());
        }

        private void MenuProcesos_Opening(object sender, CancelEventArgs e)
        {
            int idProceso = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            PlanoProceso proceso = new PlanoProceso();
            proceso.CargarDatos(idProceso);

            resultadosDeInspecciónToolStripMenuItem.Enabled = TvMetas.SelectedNode.Text.Contains("INSPECCION");
            
            if (!proceso.TieneFilas() || proceso.Fila().Celda("proceso").ToString() == "INSPECCION DE FABRICACION" || proceso.Fila().Celda("proceso").ToString() == "TRATAMIENTO")
            {
                agregarSiguienteProcesoToolStripMenuItem.Enabled = (TvMetas.SelectedNode.Parent.Parent == NodoReparacion || TvMetas.SelectedNode.Parent.Parent == NodoScrap);
                eliminarProcesoToolStripMenuItem.Enabled = false;
                estimarTiempoToolStripMenuItem.Enabled = false;
                // Opcion para reasignar herramentista en caso de no haber comenzado el proyecto
                asignarToolStripMenuItem.Enabled = false;
                tiempoDeFabricaciónToolStripMenuItem.Enabled = false;

                return;
            }


            switch (proceso.Fila().Celda("estatus").ToString())
            {
                case "PENDIENTE":
                    agregarSiguienteProcesoToolStripMenuItem.Enabled = true;
                    eliminarProcesoToolStripMenuItem.Enabled = true;
                    asignarToolStripMenuItem.Enabled = false;
                    estimarTiempoToolStripMenuItem.Enabled = true;
                    tiempoDeFabricaciónToolStripMenuItem.Enabled = true;
                    break;
                case "TIEMPO ESTIMADO":
                    agregarSiguienteProcesoToolStripMenuItem.Enabled = true;
                    eliminarProcesoToolStripMenuItem.Enabled = true;
                    asignarToolStripMenuItem.Enabled = true;
                    estimarTiempoToolStripMenuItem.Enabled = false;
                    tiempoDeFabricaciónToolStripMenuItem.Enabled = true;
                    break;
                case "TERMINADO":
                    agregarSiguienteProcesoToolStripMenuItem.Enabled = true;
                    eliminarProcesoToolStripMenuItem.Enabled = true;
                    eliminarProcesoToolStripMenuItem.Enabled = false;
                    estimarTiempoToolStripMenuItem.Enabled = false;
                    asignarToolStripMenuItem.Enabled = false;
                    tiempoDeFabricaciónToolStripMenuItem.Enabled = false;
                    break;
                case "ASIGNADO":
                    asignarToolStripMenuItem.Enabled = true;
                    tiempoDeFabricaciónToolStripMenuItem.Enabled = true;
                    break;
                default:
                    estimarTiempoToolStripMenuItem.Enabled = false;
                    asignarToolStripMenuItem.Enabled = false;
                    tiempoDeFabricaciónToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
             string tipoNodo =  TvMetas.SelectedNode.Name.Split('-')[0];

             if (tipoNodo == "plano")
             {
                 int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
                 LblEstatusResultado.Visible = false;

                 if (!BkgDescargarPlano.IsBusy)
                 {
                     TvMetas.Enabled = false;
                     Progress.Visible = true;
                     BkgDescargarPlano.RunWorkerAsync(idPlano);
                 }
             }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            string mensaje = "¿Está seguro de imprimir el plano?";

            PlanoProyecto proyecto = new PlanoProyecto();
            proyecto.CargarDatos(idPlano);

            if (!proyecto.TieneFilas())
                return;

            int numeroImpresiones = Convert.ToInt32(proyecto.Fila().Celda("total_impresiones"));
            string impresoPor = Global.ObjetoATexto(proyecto.Fila().Celda("impreso_por"), "");           

            if (numeroImpresiones > 0)
                mensaje = "Este plano tiene un total de " + numeroImpresiones + " impresiones, la última impresión fue realizada por " + impresoPor + ". ¿Desea imprimir el plano?";

            DialogResult result = MessageBox.Show(mensaje, "Impresión de plano", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                proyecto.Fila().ModificarCelda("total_impresiones", numeroImpresiones + 1);
                proyecto.Fila().ModificarCelda("impreso_por", Global.UsuarioActual.NombreCompleto());
                proyecto.GuardarDatos();
                
                if(!BkgImprimirPlano.IsBusy)
                    BkgImprimirPlano.RunWorkerAsync(idPlano);
            }
        }

        private void BkgImprimirPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            int idPlano = Convert.ToInt32(e.Argument);
            Archivo = null;

            string rutaPlanoFtp = string.Empty;

            Archivo = ServidorFtp.DescargarPlano(idPlano, FormatoArchivo.Pdf, BkgImprimirPlano, out rutaPlanoFtp);

            if (Archivo != null)
            {
                PdfDescargado = true;
                BkgImprimirPlano.ReportProgress(100, "Procesando plano");
                NombreArchivo = idPlano + " " + Path.GetFileNameWithoutExtension(rutaPlanoFtp);
            }
            else
            {
                PdfDescargado = false;
                BkgImprimirPlano.ReportProgress(100, "Error al descargar plano");
                e.Result = string.Empty;
            }
        }

        private void BkgImprimirPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (PdfDescargado)
            {
                NombreArchivo += DateTime.Now.ToString("MMM dd, yyyy");
                FrmVisorPDF pdf = new FrmVisorPDF(Archivo, NombreArchivo);
                pdf.Show();
            }
            else
                MessageBox.Show("El plano no fue encontrado", "Plano no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefrescarNodo(TvMetas.SelectedNode);
        }

        private void agregarSiguienteProcesoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarSiguienteProceso();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de cancelar la requisición #" + TvMetas.SelectedNode.Name.Split('-')[1].ToString() + "?", "Borrar requisición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            int idReq = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            int idProceso = Convert.ToInt32(TvMetas.SelectedNode.Text.Split(' ')[0]);
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]);

            MaterialProyecto materiales = new MaterialProyecto();
            materiales.CargarDatos(idReq);

            if(materiales.TieneFilas())
            {
                if (materiales.Fila().Celda("estatus_compra").ToString() == "PENDIENTE" || materiales.Fila().Celda("estatus_compra").ToString() == "EN COTIZACION")
                {
                    // Cancelar req.   
                    materiales.Fila().ModificarCelda("estatus_compra", "CANCELADO");
                    materiales.GuardarDatos();

                    PlanoProceso proceso = new PlanoProceso();
                    proceso.CargarDatos(idProceso);
                    if (proceso.TieneFilas())
                    {
                        // Borrar proceso
                        proceso.BorrarDatos(Convert.ToInt32(proceso.Fila().Celda("id")));
                        proceso.GuardarDatos();
                    }
                    CargarProcesosPlano(TvMetas.SelectedNode.Parent, idPlano);
                }
                else // La req. Tiene otro estatus
                    MessageBox.Show("La requisición " + TvMetas.SelectedNode.Name.Split('-')[1].ToString() + " no puede ser cancelada, favor de comunicarse con compras para solucionarlo", "Cancelar requisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // No existe información de la req.
                MessageBox.Show("La requisición " + TvMetas.SelectedNode.Name.Split('-')[1].ToString() + " no pudo ser encontrada, favor de comunicarse con sistemas para resolver el problema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idReq = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            FrmDetallesMaterialProyecto detalles = new FrmDetallesMaterialProyecto(idReq);
            detalles.ShowDialog();
        }

        private void fabricaciónTerminadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            int idMeta = 0;

            DialogResult resp = MessageBox.Show("¿Seguro que quieres colocar esta plano como FABRICADO?", "Terminar pieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProceso proc = new PlanoProceso();
                proc.SeleccionarProcesosLocalesNoTerminados(idPlano);

                if (proc.TieneFilas())
                {
                    MessageBox.Show("Antes de marcar el plano como FABRICADO todos los procesos deben estar terminados.",
                                    "No es posible realizar acción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PlanoProyecto planoProyecto = new PlanoProyecto();
                planoProyecto.CargarDatos(idPlano);
                if (planoProyecto.TieneFilas())
                {
                    if(planoProyecto.Fila().Celda("estatus").ToString() == "FABRICADO")
                    {
                        MessageBox.Show("Esta acción no es posible, el plano anteriormente fue colocado como FABRICADO", "Plano fabricado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    planoProyecto.Fila().ModificarCelda("estatus", "FABRICADO");
                    planoProyecto.Fila().ModificarCelda("fecha_fabricacion_terminada", DateTime.Now);
                    planoProyecto.GuardarDatos();

                    // SE crea un proceso de inspeccion
                    InsertarProcesoInspeccion(idPlano);

                    TvMetas.SelectedNode.ImageIndex = 10;
                    TvMetas.SelectedNode.SelectedImageIndex = 10;

                    DialogResult result = MessageBox.Show("El plano fue colocado como FABRICADO, ¿Desea entregar la(s) pieza(s) a inspección?.",
                                       "Plano fabricado.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        FrmEntregarPiezaFabricada entregarPieza = new FrmEntregarPiezaFabricada();
                        entregarPieza.Show();
                    }
                }

                // busca el id de la meta correspondiente con el plano que estamos marcando como fabricado
                TreeNode nodoPadre = TvMetas.SelectedNode.Parent;
                while (nodoPadre != null)
                {
                    if (nodoPadre.Name.StartsWith("meta"))
                    {
                        idMeta = Convert.ToInt32(nodoPadre.Name.Split('-')[1]);
                        break;
                    }
                    else nodoPadre = nodoPadre.Parent;
                }

                if (idMeta > 0)
                {
                    if (Meta.Modelo().ActualizarAvance(idMeta) == 100)
                    {
                        CargarMetas();
                    }
                }

                //Guardar calcular eficiencia en avance
                CalcularEficienciaAvance(idMeta);
            }
        }

        private void CalcularEficienciaAvance(int idMeta)
        {
            Meta meta = new Meta();
            meta.CargarDatos(idMeta);

            if (meta.TieneFilas())
            {
                int tiempoTranscurrido = 0;
                decimal eficiencia = 0;
                DateTime fechaAutorizacion = Convert.ToDateTime(meta.Fila().Celda("fecha_autorizacion"));
                DateTime fechaPromesa = Convert.ToDateTime(meta.Fila().Celda("fecha_promesa"));
                decimal avance = Convert.ToDecimal(meta.Fila().Celda("avance"));

                TimeSpan diferenciaTranscurrida = DateTime.Now.Date - fechaAutorizacion.Date;
                TimeSpan diferenciaAutorizacionPromesa = fechaPromesa.Date - fechaAutorizacion.Date;
                int diasTranscurridos = diferenciaTranscurrida.Days;
                int diasDelProyecto = diferenciaAutorizacionPromesa.Days;
                if (diasDelProyecto > 0)
                    tiempoTranscurrido = (diasTranscurridos * 100) / diasDelProyecto;
                else
                    tiempoTranscurrido = (diasTranscurridos * 100);

                if(tiempoTranscurrido > 0)
                    eficiencia = (avance/tiempoTranscurrido) * 100;
                else
                    eficiencia = (avance) * 100;

                Fila insertarMetaEficiencia = new Fila();
                insertarMetaEficiencia.AgregarCelda("meta", idMeta);
                insertarMetaEficiencia.AgregarCelda("avance", avance);
                insertarMetaEficiencia.AgregarCelda("fecha", DateTime.Now);
                insertarMetaEficiencia.AgregarCelda("tiempo_transcurrido", tiempoTranscurrido);
                insertarMetaEficiencia.AgregarCelda("eficiencia", eficiencia);

                MetaEficiencia.Modelo().Insertar(insertarMetaEficiencia);
            }
        }

        private void InsertarProcesoInspeccion(int idPlano)
        {
            PlanoProceso proceso = new PlanoProceso();

            Usuario usuario = new Usuario();
            usuario.SeleccionarRol("INSPECTOR DE CALIDAD");

            Dictionary<string,object> parametros = new Dictionary<string,object>();
            parametros.Add("@plano", idPlano);

            proceso.SeleccionarDatos("plano=@plano ORDER BY orden DESC limit 1", parametros);

            Fila insertarProcesoInspeccion = new Fila();
            insertarProcesoInspeccion.AgregarCelda("plano", idPlano);
            insertarProcesoInspeccion.AgregarCelda("proceso", "INSPECCION DE FABRICACION");
            insertarProcesoInspeccion.AgregarCelda("maquina", "LABORATORIO DE CALIDAD");
            insertarProcesoInspeccion.AgregarCelda("programador", "N/A");
            insertarProcesoInspeccion.AgregarCelda("operador", usuario.Fila().Celda("nombre").ToString() + " " + usuario.Fila().Celda("paterno").ToString());
            insertarProcesoInspeccion.AgregarCelda("estatus", "PENDIENTE");
            insertarProcesoInspeccion.AgregarCelda("proceso_anterior", proceso.Fila().Celda("id"));
            insertarProcesoInspeccion.AgregarCelda("herramentista", usuario.Fila().Celda("id"));
            insertarProcesoInspeccion.AgregarCelda("orden", Convert.ToInt32(proceso.Fila().Celda("id")) + 10);
            proceso.Insertar(insertarProcesoInspeccion);

            CargarProcesosPlano(TvMetas.SelectedNode, idPlano);
        }

        private void MenuProveedor_Opening(object sender, CancelEventArgs e)
        {
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]);

            PlanoProyecto proyecto = new PlanoProyecto();
            proyecto.CargarDatos(idPlano);

            if(proyecto.TieneFilas())
            {
                if(proyecto.Fila().Celda("estatus").ToString() == "FABRICADO")
                {
                    agregarSiguienteProcesoToolStripMenuItem1.Enabled = false;
                    eliminarToolStripMenuItem.Enabled = false;
                }               
            }
        }

        private void actualizarMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefrescarNodo(TvMetas.SelectedNode);
        }

        private void actualizarModuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActualizarModulo();
        }

        private void ActualizarModulo()
        {
            RefrescarNodo(TvMetas.SelectedNode);
        }

        private void asignarMultiplesProcesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idModulo = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);

            Modulo modulo = new Modulo();
            modulo.CargarDatos(idModulo);
            if(modulo.TieneFilas())
            {
                decimal idProyecto = Convert.ToDecimal(modulo.Fila().Celda("proyecto"));
                int subensamble = Convert.ToInt32(modulo.Fila().Celda("subensamble"));

                FrmAsignarMultiplesProcesosFabricacion asignar = new FrmAsignarMultiplesProcesosFabricacion(idProyecto, subensamble);
                if(asignar.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    ActualizarModulo();
                }
            }
        }

        private void BtnAsignaciones_Click(object sender, EventArgs e)
        {
            FrmAsignacionesFabricacion asignaciones = new FrmAsignacionesFabricacion();
            asignaciones.Show();
        }

        private void TvMetas_AfterCollapse(object sender, TreeViewEventArgs e)
        {          
             e.Node.Nodes.Clear();
        }

        private void resultadosDeInspecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResultadosInspeccion2 noConformidad = new FrmResultadosInspeccion2(
                Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]),
                Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1])
                );
            MostrarContenido(noConformidad);
        }

        private void MenuMaterial_Opening(object sender, CancelEventArgs e)
        {
            seleccionarMaterialToolStripMenuItem.Enabled = (TvMetas.SelectedNode.Name.Split('-')[0] == "planomateriales");
            MaterialProyecto material = new MaterialProyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@plano", Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]));
            material.SeleccionarDatos("plano=@plano", parametros);

            enStockToolStripMenuItem.Visible = !material.TieneFilas();

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]));

            seleccionarMaterialToolStripMenuItem.Visible = (plano.Fila().Celda("estatus_material").ToString() != "EN STOCK");
            enStockToolStripMenuItem.Checked = (plano.Fila().Celda("estatus_material").ToString() == "EN STOCK");
        }

        private void seleccionarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarMaterialFabricacion material = new FrmSeleccionarMaterialFabricacion(Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]));
            if(material.ShowDialog() == DialogResult.OK)
            {
                CargarMaterialesPlano(TvMetas.SelectedNode, Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]));
                CrearMetaParaMaterialFabricacion(material.IdRequisicion);
            }
            RefrescarNodo(TvMetas.SelectedNode.Parent);
        }

        private void CrearMetaParaMaterialFabricacion(int idReq)
        {
            Meta meta = new Meta();
            DateTime fechaPromesa = new DateTime();
            TreeNode nodoMeta = TvMetas.SelectedNode;
            MaterialProyecto material = new MaterialProyecto();

            material.CargarDatos(idReq);
            if (!material.TieneFilas())
                return;

            while (!nodoMeta.Name.StartsWith("meta-"))
            {
                nodoMeta = nodoMeta.Parent;
            }

            int idMeta = Convert.ToInt32(nodoMeta.Name.Split('-')[1]);
            meta.CargarDatos(idMeta);
            
            if(!meta.TieneFilas())
                return;

            fechaPromesa = Convert.ToDateTime(meta.Fila().Celda("fecha_promesa")).AddDays(-3);
            Fila crearMeta = new Fila();

            Proceso proceso = new Proceso();
            proceso.SeleccionarNombre("COMPRAS");
            if(proceso.TieneFilas())
            {
                int coordinador = 0;
                int responsable = 0;
                Usuario usuario = new Usuario();
                usuario.SeleccionarRolActivos("COORDINADOR DE OPERACIONES");
                if (usuario.TieneFilas())
                    coordinador = usuario.Fila().Celda<int>("id");
                usuario.SeleccionarRolActivos("COMPRADOR");
                if (usuario.TieneFilas())
                    responsable = usuario.Fila().Celda<int>("id");

                crearMeta.AgregarCelda("proyecto", material.Fila().Celda("proyecto"));
                crearMeta.AgregarCelda("proceso", proceso.Fila().Celda("id"));
                crearMeta.AgregarCelda("tipo_entregable", "MATERIAL DE REQUISICION");
                crearMeta.AgregarCelda("requisitor", Global.UsuarioActual.Fila().Celda<int>("id"));
                crearMeta.AgregarCelda("coordinador", 0);
                crearMeta.AgregarCelda("responsable", 0);
                crearMeta.AgregarCelda("fecha_solicitud", DateTime.Now);
                crearMeta.AgregarCelda("fecha_promesa", fechaPromesa.Date);
                crearMeta.AgregarCelda("fecha_autorizacion", DateTime.Now);
                crearMeta.AgregarCelda("estatus_autorizacion", "AUTORIZADO");
                crearMeta.AgregarCelda("comentarios_autorizacion", "AUTORIZADO POR SISTEMA");
                int nuevaMeta = Convert.ToInt32(meta.Insertar(crearMeta).Celda("id"));

                Fila crearEntregable = new Fila();
                crearEntregable.AgregarCelda("meta", nuevaMeta);
                crearEntregable.AgregarCelda("tipo_entregable", "MATERIAL DE REQUISICION");
                crearEntregable.AgregarCelda("id_entregable", idReq);
                MetaEntregable.Modelo().Insertar(crearEntregable);

                material.Fila().ModificarCelda("meta", idMeta);
                material.Fila().ModificarCelda("fecha_promesa_compras", fechaPromesa.Date);
                material.GuardarDatos();
            }
        }

        private void enStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto p = new PlanoProyecto();
            p.CargarDatos(Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]));

            if (p.TieneFilas())
            {
                if (p.Fila().Celda("estatus_material").ToString() == "N/A")
                    p.Fila().ModificarCelda("estatus_material", "EN STOCK");
                else
                    p.Fila().ModificarCelda("estatus_material", "N/A");

                p.GuardarDatos();
            }

            RefrescarNodo(TvMetas.SelectedNode.Parent);
        }

        private void descartarPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescartarPlano(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]));
        }

        private void DescartarPlano(int idPlano)
        {
            DialogResult resp = MessageBox.Show("Este plano debe ser descartado, presiona OK para descartarlo ahora.", "Descartar plano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (resp == System.Windows.Forms.DialogResult.OK)
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(idPlano);

                if (plano.TieneFilas())
                {
                    plano.Fila().ModificarCelda("estatus", "DESCARTADO");
                    plano.Fila().ModificarCelda("estatus_ensamble", "DESCARTADO");

                    // determinar id de la meta
                    Meta meta = new Meta();
                    meta.DeterminarIdMeta(Convert.ToDecimal(plano.Fila().Celda("proyecto")), idPlano, plano.Fila().Celda<int>("subensamble"));
                    MessageBox.Show("El plano fue descartado correctamente.", "Plano descartado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    plano.GuardarDatos();
                    if(NodoPorDescartar.IsExpanded)
                    {
                        RefrescarNodo(NodoPorDescartar);
                    }
                }
            }
        }

        private void solicitarUrgenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlanoUrgencia formUrgencia = new FrmPlanoUrgencia(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]));
            if (formUrgencia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefrescarNodo(NodoRegular);
            };
        }

        private void autorizarUrgenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarEstatusUrgencia(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]), "AUTORIZADO");
            RefrescarNodo(TvMetas.SelectedNode.Parent);
            if(NodoRegular.IsExpanded)
            {
                RefrescarNodo(NodoRegular);
            }
        }

        private void rechazarUrgenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarEstatusUrgencia(Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]), "RECHAZADO");
            RefrescarNodo(TvMetas.SelectedNode.Parent);
            if (NodoRegular.IsExpanded)
            {
                RefrescarNodo(NodoRegular);
            }
        }

        private void CambiarEstatusUrgencia(int idPlano, string estatusUrgencia)
        {
            PlanoProyecto planoSeleccionado = new PlanoProyecto();
            planoSeleccionado.CargarDatos(idPlano);

            if (planoSeleccionado.TieneFilas())
            {
                planoSeleccionado.Fila().ModificarCelda("estatus_urgencia", estatusUrgencia);
                planoSeleccionado.GuardarDatos();
            }
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            FrmDetallesPlanoFabricacion detalles = new FrmDetallesPlanoFabricacion(idPlano);
            detalles.Show();
        }

        private void MenuPlanosUrgencias_Opening(object sender, CancelEventArgs e)
        {
            if (!TvMetas.SelectedNode.Parent.Name.StartsWith("urgenciaRaiz"))
                return;
            autorizarUrgenciaToolStripMenuItem.Visible = (TvMetas.SelectedNode.Parent.Name.Split('-')[1].ToString() != "RECHAZADO");
            rechazarUrgenciaToolStripMenuItem.Visible = (TvMetas.SelectedNode.Parent.Name.Split('-')[1].ToString() != "RECHAZADO");
            detallesToolStripMenuItem.Enabled = true;
        }

        private void ubicarPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarNodoPlano(Convert.ToInt32(TvMetas.SelectedNode.Name.Split(new char[] {'-'})[1]));
        }

        private void tiempoDeFabricaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idProceso = Convert.ToInt32(TvMetas.SelectedNode.Name.Split('-')[1]);
            int idPlano = Convert.ToInt32(TvMetas.SelectedNode.Parent.Name.Split('-')[1]);

            FrmTiempoFabricacion agregarTiempo = new FrmTiempoFabricacion(idProceso);
            if (agregarTiempo.ShowDialog() == DialogResult.OK)
            {
                ActualizarImagenNodos("TERMINADO", TvMetas.SelectedNode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegistrarPlanoFueraDelSistema plano = new FrmRegistrarPlanoFueraDelSistema();
            plano.Show();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            FrmReporteFabricacion reporte = new FrmReporteFabricacion();
            reporte.Show();
        }
    }
}
