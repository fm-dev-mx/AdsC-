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
using CB_Base.CB_Controles;
using CB_Base.CB_Classes;
using OfficeOpenXml;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace CB
{
    public partial class FrmPrincipal : Form
    {
        protected Form Contenido = null;
        protected decimal ProyectoCargado = -3000;

        public FrmPrincipal()
        {
            InitializeComponent();

            this.SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer,
            true);
        }

        public void MostrarContenido(Form contenido)
        {
            if(!(this.Contenido == null))
            {
                this.Contenido.Close();
            }
            
            Contenido = contenido;
            Contenido.MdiParent = this;
            Contenido.Show();
        }

        private void TvArbolProyecto_DoubleClick(object sender, EventArgs e)
        {
            if (TvArbolProyecto.SelectedNode == null || TvArbolProyecto.SelectedNode.Parent == null)
                return;

            try
            {
                string[] s = TvArbolProyecto.SelectedNode.Parent.Text.Split(' ');

                string opcion = TvArbolProyecto.SelectedNode.Text;
                decimal id = Convert.ToDecimal(s[0]);

                LblEstatusPrincipal.Text = "Cargando datos...";
                switch(opcion)
                {
                    case "Resumen":
                        MostrarContenido(new FrmResumenProyecto(id));
                        break;

                    case "Requerimientos":
                        MostrarContenido(new FrmRequerimientosProyecto(id));
                        break;

                    case "Cronograma":
                        MostrarContenido(new FrmCronogramaProyecto(id));
                        break;

                    case "Juntas de sincronización":
                        MostrarContenido(new FrmTopicosProyecto(id));
                        break;

                    case "Tareas":
                        MostrarContenido(new FrmTareas(id));
                        break;

                    case "Módulos":
                        MostrarContenido(new FrmModulosProyecto(id));
                        break;

                    case "Diseño mecánico":
                        MostrarContenido(new FrmDisenoMecanico(id));
                        break;

                    case "Planos":
                        MostrarContenido(new FrmPlanosProyecto(id));
                        break;

                    case "Compras":
                        string[] filtroTipoMaterial = new string[] { "MATERIA PRIMA ESPECIAL", "MATERIA PRIMA COMUN", "SERVICIOS" };
                        MostrarContenido(new FrmMaterialProyecto(id, filtroTipoMaterial, true));
                        break;

                    case "Bugs":
                        MostrarContenido(new FrmBugsProyecto(id));
                        break;

                    case "Cambios de diseño":
                        MostrarContenido(new FrmCambiosDiseno(id));
                        break;

                }
                LblEstatusPrincipal.Text = "";
            }
            catch
            {

            }  
        }

        private void MenuAdministrarProveedores_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmAdministrarProveedores());
            PanelArbolProyecto.Hide();
        }

        private void MenuMonitoresMaquinado_Click(object sender, EventArgs e)
        {
            FrmMonitorFabricacion2 mf = new FrmMonitorFabricacion2();
            mf.Show();
            //MostrarContenido(new FrmMonitorFabricacion());
            //PanelArbolProyecto.Hide();
        }

        public void CargarProyecto(decimal id)
        {
            Proyecto principal = new Proyecto();
            principal.CargarDatos(id);

            List<Fila> subproyectos = Proyecto.Modelo().Subproyectos(id);

            TvArbolProyecto.Nodes.Clear();
            
            TreeNode NodoPrincipal = TvArbolProyecto.Nodes.Add(Convert.ToDecimal(principal.Fila().Celda("id")).ToString("F2") + " - " + principal.Fila().Celda("nombre").ToString());
            
            //NodoPrincipal.Nodes.Add("Resumen");

            TreeNode NodoRequerimientosPrincipal = NodoPrincipal.Nodes.Add("Requerimientos");
            NodoRequerimientosPrincipal.ImageIndex = 5;
            NodoRequerimientosPrincipal.SelectedImageIndex = 5;

            TreeNode NodoCronogramaPrincipal = NodoPrincipal.Nodes.Add("Cronograma");
            NodoCronogramaPrincipal.ImageIndex = 12;
            NodoCronogramaPrincipal.SelectedImageIndex = 12;

            TreeNode NodoSincronizacionPrincipal = NodoPrincipal.Nodes.Add("Juntas de sincronización");
            NodoSincronizacionPrincipal.ImageIndex = 10;
            NodoSincronizacionPrincipal.SelectedImageIndex = 10;

            TreeNode NodoTareasPrincipal = NodoPrincipal.Nodes.Add("Tareas");
            NodoTareasPrincipal.ImageIndex = 13;
            NodoTareasPrincipal.SelectedImageIndex = 13;

            TreeNode NodoModulosPrincipal = NodoPrincipal.Nodes.Add("Módulos");
            NodoModulosPrincipal.ImageIndex = 6;
            NodoModulosPrincipal.SelectedImageIndex = 6;

            TreeNode NodoDisenoMecanico = NodoPrincipal.Nodes.Add("Diseño mecánico");
            NodoDisenoMecanico.ImageIndex = 9;
            NodoDisenoMecanico.SelectedImageIndex = 9;

            TreeNode NodoPlanosPrincipal = NodoPrincipal.Nodes.Add("Planos");
            NodoPlanosPrincipal.ImageIndex = 3;
            NodoPlanosPrincipal.SelectedImageIndex = 3;

            TreeNode NodoMaterialPrincipal = NodoPrincipal.Nodes.Add("Compras");
            NodoMaterialPrincipal.ImageIndex = 4;
            NodoMaterialPrincipal.SelectedImageIndex = 4;

            //TreeNode NodoBugsPrincipal = NodoPrincipal.Nodes.Add("Bugs");
            //NodoBugsPrincipal.ImageIndex = 8;
            //NodoBugsPrincipal.SelectedImageIndex = 8;


            TreeNode NodoCambiosDisenoPrincipal = NodoPrincipal.Nodes.Add("Cambios de diseño");
            NodoCambiosDisenoPrincipal.ImageIndex = 11;
            NodoCambiosDisenoPrincipal.SelectedImageIndex = 11;

            NodoPrincipal.ImageIndex = 0;
            NodoPrincipal.SelectedImageIndex = 0;

            NodoPrincipal.Expand();

            if( subproyectos.Count >= 0 )
            {
                TreeNode NodoSubproyectos = NodoPrincipal.Nodes.Add("Subproyectos");
                NodoSubproyectos.ImageIndex = 1;
                NodoSubproyectos.SelectedImageIndex = 1;
                
                subproyectos.ForEach(delegate(Fila subproyecto)
                {
                    TreeNode NodoSub = NodoSubproyectos.Nodes.Add(Convert.ToDecimal(subproyecto.Celda("id")).ToString("F2") + " - " + subproyecto.Celda("nombre").ToString());
                    NodoSub.ImageIndex = 2;
                    NodoSub.SelectedImageIndex = 2;


                    //NodoSub.Nodes.Add("Resumen");

                    TreeNode NodoRequerimientosSub = NodoSub.Nodes.Add("Requerimientos");
                    NodoRequerimientosSub.ImageIndex = 5;
                    NodoRequerimientosSub.SelectedImageIndex = 5;

                    TreeNode NodoCronogramaSub = NodoSub.Nodes.Add("Cronograma");
                    NodoCronogramaSub.ImageIndex = 12;
                    NodoCronogramaSub.SelectedImageIndex = 12;

                    TreeNode NodoSincronizacionSub = NodoSub.Nodes.Add("Juntas de sincronización");
                    NodoSincronizacionSub.ImageIndex = 10;
                    NodoSincronizacionSub.SelectedImageIndex = 10;

                    TreeNode NodoTareasSub = NodoSub.Nodes.Add("Tareas");
                    NodoTareasSub.ImageIndex = 13;
                    NodoTareasSub.SelectedImageIndex = 13;

                    TreeNode NodoModulosSub = NodoSub.Nodes.Add("Módulos");
                    NodoModulosSub.ImageIndex = 6;
                    NodoModulosSub.SelectedImageIndex = 6;

                    TreeNode NodoDisenoMecanicoSub = NodoSub.Nodes.Add("Diseño mecánico");
                    NodoDisenoMecanicoSub.ImageIndex = 9;
                    NodoDisenoMecanicoSub.SelectedImageIndex = 9;

                    TreeNode NodoPlanosSub = NodoSub.Nodes.Add("Planos");
                    NodoPlanosSub.ImageIndex = 3;
                    NodoPlanosSub.SelectedImageIndex = 3;

                    TreeNode NodoMaterialSub = NodoSub.Nodes.Add("Compras");
                    NodoMaterialSub.ImageIndex = 4;
                    NodoMaterialSub.SelectedImageIndex = 4;

                    //TreeNode NodoBugsSub = NodoSub.Nodes.Add("Bugs");
                    //NodoBugsSub.ImageIndex = 8;
                    //NodoBugsSub.SelectedImageIndex = 8;

                    TreeNode NodoCambiosDisenoSub = NodoSub.Nodes.Add("Cambios de diseño");
                    NodoCambiosDisenoSub.ImageIndex = 11;
                    NodoCambiosDisenoSub.SelectedImageIndex = 11;

                });
                NodoSubproyectos.Expand();
            }

            MostrarContenido(new FrmResumenProyecto(id));
            PanelArbolProyecto.Show();
            ProyectoCargado = id;
        }

        private void MenuProyectoCargar_Click(object sender, EventArgs e)
        {
            FrmCargarProyecto proyectos = new FrmCargarProyecto();

            if( proyectos.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                CargarProyecto(proyectos.ProyectoCargado);
        }

        private void TvArbolProyecto_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            LblEstatusPrincipal.Text = "Has iniciado sesion como ";
            LblEstatusPrincipal.Text += Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno") + ". ";
            ConfigurarMenu();
            MostrarContenido(new FrmInicio(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"))));
            PanelArbolProyecto.Hide();
        }

        public void ConfigurarMenu()
        {
            miscelaneosToolStripMenuItem.Enabled = true;
            clientesToolStripMenuItem.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR CLIENTES");
            MenuAdministrarProveedores.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR PROVEEDORES");
            MenuAdministrarUsuarios.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR USUARIOS");
            puestosToolStripMenuItem.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR USUARIOS");
            competenciasToolStripMenuItem.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR USUARIOS");
            tiempoExtraToolStripMenuItem.Enabled = Global.VerificarPrivilegio("PROYECTOS", "CREAR PROYECTO");
            fabricantesToolStripMenuItem.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR CLIENTES");
            MenuAdministrarRoles.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR ROLES");
            MenuMonitorCompras.Enabled = Global.VerificarPrivilegio("MONITORES", "COMPRAS");
            MenuMonitoresFabricacion.Enabled = Global.VerificarPrivilegio("MONITORES", "FABRICACION");
            MenuNuevoProyecto.Enabled = Global.VerificarPrivilegio("PROYECTOS", "CREAR PROYECTO");
            sistemasToolStripMenuItem.Enabled = Global.VerificarPrivilegio("ADMINISTRAR", "ADMINISTRAR USUARIOS");
            MenuMonitorEnsamble.Enabled = Global.VerificarPrivilegio("MONITORES", "ENSAMBLE");
            MenuMonitorMantenimiento.Enabled = Global.VerificarPrivilegio("MONITORES", "MANTENIMIENTO");
            MenuMonitorRecursosHumanos.Enabled = Global.VerificarPrivilegio("MONITORES", "RECURSOS HUMANOS");
            MenuMonitorServicioCliente.Enabled = Global.VerificarPrivilegio("MONITORES", "SERVICIO AL CLIENTE");
            MenuMonitorCalidad.Enabled = Global.VerificarPrivilegio("MONITORES", "CALIDAD");
            finanzasToolStripMenuItem.Enabled = Global.VerificarPrivilegio("MONITORES", "FINANZAS");
            debugToolStripMenuItem.Enabled = (Global.UsuarioActual.Fila().Celda("rol").ToString() == "SUPERUSER");
            búsquedaDeRequisiciónToolStripMenuItem.Enabled = (Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL"));
            restringirNúmeroDeParteToolStripMenuItem.Enabled = (Global.VerificarPrivilegio("MATERIAL", "AUTORIZAR MATERIAL"));
        }

        private void MenuAdministrarRoles_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmAdministrarRoles());
            PanelArbolProyecto.Hide();
        }

        private void MenuAdministrarUsuarios_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmAdministrarUsuarios());
            PanelArbolProyecto.Hide();
        }

        private void correoElectrónicoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConfigurarCorreo configCorreo = new FrmConfigurarCorreo();
            configCorreo.ShowDialog();
        }

        private void MenuCatalogoMaterial_Click(object sender, EventArgs e)
        {
           
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmMonitorCompras());
            PanelArbolProyecto.Hide();
        }

        private void MenuMonitorEnsamble_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmMonitorEnsamble());
            PanelArbolProyecto.Hide();
        }

        private void cuentasPorPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmCuentasPorPagar());
            PanelArbolProyecto.Hide();
        }

        private void MenuMonitorAlmacen_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmAlmacen());
            PanelArbolProyecto.Hide();
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MostrarContenido(new FrmAdministrarClientes());
            PanelArbolProyecto.Hide();
        }

        public void AbrirSubproyecto(decimal subproyecto, string categoria="")
        {
            string subproyectoNodo = "";

            foreach(TreeNode nodoPrincipal in TvArbolProyecto.Nodes)
            {
                foreach(TreeNode nodoSecundario in nodoPrincipal.Nodes)
                {
                    foreach(TreeNode nodoTercero in nodoSecundario.Nodes)
                    {
                        subproyectoNodo = nodoTercero.Text.Split('-')[0].Trim();

                        if (subproyectoNodo == subproyecto.ToString())
                        {
                            nodoTercero.ExpandAll();

                            foreach (TreeNode nodoCuarto in nodoTercero.Nodes)
                            {
                                if (nodoCuarto.Text == categoria)
                                {
                                    TvArbolProyecto_DoubleClick(nodoCuarto, null);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void resumenDePendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmResumenPendientes pend = new FrmResumenPendientes();
            
            if( pend.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarProyecto(pend.ProyectoPrincipal);
                AbrirSubproyecto(pend.ProyectoSeleccionado, pend.CategoriaSeleccionada);
            }
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoProyecto nuevoProyecto = new FrmNuevoProyecto();
            if (nuevoProyecto.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                if (nuevoProyecto.ProyectoCreado)
                {
                    DialogResult cargarProyecto =  MessageBox.Show(nuevoProyecto.Mensaje, "Proyecto creado de forma exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(cargarProyecto == System.Windows.Forms.DialogResult.Yes)
                        CargarProyecto(Convert.ToDecimal(nuevoProyecto.StrProyecto));
                }                   
                else
                    MessageBox.Show(nuevoProyecto.Mensaje, "Error al crear proyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strSubproyecto = "";
            string[] s = TvArbolProyecto.SelectedNode.Parent.Text.Split(' ');
            decimal id = Convert.ToDecimal(s[0]);

            Proyecto ultimoSubproyecto = new Proyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@principal", id);

            try
            {
                FrmNuevoSubproyecto subproyecto = new FrmNuevoSubproyecto();
                if (subproyecto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ultimoSubproyecto.SeleccionarDatos("principal=FORMAT(@principal,2) order by id DESC limit 1", parametros, "*, FORMAT(id,2) AS sub_decimal");
                    strSubproyecto = ultimoSubproyecto.Fila().Celda("sub_decimal").ToString();

                    Proyecto.Modelo().CargarDatos(Convert.ToDecimal(strSubproyecto)).ForEach(delegate(Fila f)
                    {
                        Fila insertarSubproyecto = new Fila();
                        insertarSubproyecto.AgregarCelda("id", Convert.ToDouble(strSubproyecto) + 0.01);
                        insertarSubproyecto.AgregarCelda("nombre", subproyecto.NombreSubproyecto);
                        insertarSubproyecto.AgregarCelda("tipo", 2);
                        insertarSubproyecto.AgregarCelda("fecha_alta", DateTime.Now);
                        insertarSubproyecto.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("id"));
                        insertarSubproyecto.AgregarCelda("fecha_inicio", ultimoSubproyecto.Fila().Celda("fecha_inicio"));
                        insertarSubproyecto.AgregarCelda("fecha_entrega", ultimoSubproyecto.Fila().Celda("fecha_entrega"));
                        insertarSubproyecto.AgregarCelda("cliente", f.Celda("cliente"));
                        insertarSubproyecto.AgregarCelda("contacto", f.Celda("contacto"));
                        insertarSubproyecto.AgregarCelda("liderproyecto", Convert.ToInt32(f.Celda("liderproyecto")));
                        insertarSubproyecto.AgregarCelda("principal", id);
                        insertarSubproyecto.AgregarCelda("activo", 1);
                        insertarSubproyecto.AgregarCelda("estatus_liberacion", "PENDIENTE");
                        insertarSubproyecto.AgregarCelda("usuario_liberacion", "N/A");
                        insertarSubproyecto.AgregarCelda("evidencia_liberacion", 0);
                        string[] serie = f.Celda("serie").ToString().Split('-');
                        string nuevaSerie = serie[0] + "-" + (Convert.ToDouble(strSubproyecto) + 0.01).ToString() + DateTime.Now.ToString("-MMyy");
                        insertarSubproyecto.AgregarCelda("serie", nuevaSerie);
                        Proyecto.Modelo().Insertar(insertarSubproyecto);
                        CargarProyecto(Convert.ToDecimal(id));

                    });
                }
            }
            catch
            {
                ultimoSubproyecto.SeleccionarDatos("principal=FORMAT(@principal,2) order by id DESC limit 1", parametros, "FORMAT(id,2) AS sub_decimal");
                string sub = ultimoSubproyecto.Fila().Celda("sub_decimal").ToString();

                if ((Convert.ToDouble(strSubproyecto) + 0.01).ToString() != sub)
                    MessageBox.Show("El subproyecto " + strSubproyecto + " no pudo ser creado, contacte al administrador del sistema", "Error a; crear subproyecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    CargarProyecto(Convert.ToDecimal(id));
            }
        }

        private void TvArbolProyecto_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Subproyectos")
            {
                if (e.Button == MouseButtons.Right)
                {
                    TvArbolProyecto.SelectedNode = TvArbolProyecto.GetNodeAt(e.X, e.Y);
                    MenuSubproyectos.Show(TvArbolProyecto, e.Location);
                }
            }
        }

        private void catálogoDePartesEstandarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmPartesEstandar());
            PanelArbolProyecto.Hide();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmConfiguracion());
            PanelArbolProyecto.Hide();
        }


        private void sistemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorSistemas sistema = new FrmMonitorSistemas();
            sistema.Show();
        }

        private void recursosHumanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorRH rh = new FrmMonitorRH();
            rh.Show();
        }

        private void reparadorProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReparadorDiseno rep = new FrmReparadorDiseno();
            rep.Show();
        }

        private void manualDeCalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManualDeCalidad manual = new FrmManualDeCalidad();
            manual.Show();
        }

        private void tiempoExtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiempoExtraEmpleado te = new FrmTiempoExtraEmpleado();
            te.ShowDialog();
        }

        private void tEEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTiempoExtraEmpleado te = new FrmTiempoExtraEmpleado(10005);
            te.Show();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmInicio(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"))));
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorMantenimiento monitor = new FrmMonitorMantenimiento();
            monitor.Show();
        }

        private void calidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorCalidad2 monitor = new FrmMonitorCalidad2();
            monitor.Show();
        }

        private void servicioAlClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorServicio servicio = new FrmMonitorServicio();
            servicio.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelArbolProyecto.Visible = false;
            Contenido.Close();
            ProyectoCargado = -3000;
            MostrarContenido(new FrmInicio(Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"))));
        }

        private void proyectoToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            cerrarToolStripMenuItem.Enabled = ProyectoCargado != -3000;
        }

        private void calendarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCalendario cal = new FrmCalendario();
            cal.ShowDialog();
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministrarPuestos adminPuestos = new FrmAdministrarPuestos();
            adminPuestos.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorVentas ventas = new FrmMonitorVentas();
            ventas.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministrarProductoCliente producto = new FrmAdministrarProductoCliente(200003);
            producto.Show();
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorOperaciones operaciones = new FrmMonitorOperaciones();
            operaciones.Show();
        }

        private void fabricaciónviejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonitorFabricacion monitorfab = new FrmMonitorFabricacion();
            monitorfab.Show();
        }

        private void competenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompetencias competenciasLista = new FrmCompetencias();
            competenciasLista.Show();
        }

        private void catálogoDeMaterialviejoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarContenido(new FrmCatalogoMaterial());
            PanelArbolProyecto.Hide();
        }

        private void catálogoDeMaterialnuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCatalogoMaterial2 cat2 = new FrmCatalogoMaterial2();
            cat2.Show();
            
        }

        private void compras2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnNotificaciones_Click(object sender, EventArgs e)
        {

            if (!System.IO.Directory.Exists(GlobalPaths.PathUtilidades))
            {
                System.IO.Directory.CreateDirectory(GlobalPaths.PathUtilidades);
            }

            if (!System.IO.File.Exists(GlobalPaths.PathUtilidades + GlobalPaths.ArchivoNotificacionesExcluidas))
            {
                System.IO.FileStream excepciones = System.IO.File.Create(GlobalPaths.PathUtilidades + GlobalPaths.ArchivoNotificacionesExcluidas);
                excepciones.Close();
            }

            PnlNotificaciones.Visible = !PnlNotificaciones.Visible;
            PnlNotificaciones.Controls.Clear();

            Evento notificaciones = new Evento();

            if (Global.UsuarioActual.Fila().Celda("rol").ToString() == "SUPERUSER")
            {
                notificaciones.SeleccionarUltimasNotificaciones();//SeleccionarDatos("");                
            }
            else
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@rolDestino", Global.UsuarioActual.Fila().Celda("rol"));

                notificaciones.SeleccionarDatos("rol_destinatario=@rolDestino OR rol_destinatario is null ORDER BY id DESC LIMIT 0,20", parametros);
            }

            List<string> listaExcluidos = new List<string>();

            using (System.IO.StreamReader sr = System.IO.File.OpenText(GlobalPaths.PathUtilidades + GlobalPaths.ArchivoNotificacionesExcluidas))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    listaExcluidos.Add(s);
                }
            }

            notificaciones.Filas().ForEach(delegate(Fila evento) {
                if(!listaExcluidos.Contains(evento.Celda("id").ToString()))
                {
                    AudiselNotification tempNotificacion = new AudiselNotification(
                    Global.FechaATexto(evento.Celda("fecha_creacion"), false),
                    evento.Celda("contenido").ToString(),
                    evento.Celda("titulo").ToString(),
                    evento.Celda<int>("id")
                    );

                    tempNotificacion.Dock = DockStyle.Top;
                    
                    PnlNotificaciones.Controls.Add(tempNotificacion);
                }
            });
        }

        private void comprasdebugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void finanzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRevisionFinanciera fin = new FrmRevisionFinanciera();
            fin.Show();
        }


        // ======= DEBUG ===============================================================

        private void imagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();
                    path = openFileDialog.FileName;
                    if (path.ToLower().EndsWith(".pdf"))
                    {
                        string guardarPath = Directory.GetCurrentDirectory() + @"\img\";
                        if (!Directory.Exists(guardarPath))
                            Directory.CreateDirectory(guardarPath);

                        byte[] img = FormatosPDF.MiniaturaPDF(@path, 264, 264); //264.204 miniatura //6600 2550 noraml
                        string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(path);
                        System.IO.File.WriteAllBytes(guardarPath + nombreArchivoSinExtension + "_MIN.PNG", img);

                        img = FormatosPDF.MiniaturaPDF(@path, 6600, 2550); //264.204 miniatura //6600 2550 noraml
                        System.IO.File.WriteAllBytes(guardarPath + nombreArchivoSinExtension + ".PNG", img);
                        System.IO.File.WriteAllBytes(guardarPath + nombreArchivoSinExtension + "_REV.PNG", img);
                    }
                }
            }
        }

        private void actualizarMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmActualizarMetas actualizar = new FrmActualizarMetas();
            actualizar.Show();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarNuevoProducto prod = new FrmRegistrarNuevoProducto(2);
            prod.Show();
        }

        private void nuevoModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nuevoComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarProductoComponente componente = new FrmRegistrarProductoComponente(200002, 1);
            componente.Show();
        }

        private void subensambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void adminProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistroProducto prod = new FrmRegistroProducto();
            prod.Show();
        }

        private void MenuMonitorCompras_Click(object sender, EventArgs e)
        {
            FrmMonitorCompras2 compras2 = new FrmMonitorCompras2();
            compras2.Show();
        }

        private void conversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MessageBox.Show(Global.ObtenerTipoCambio().ToString());

        }

        private void productoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRegistroProducto producto = new FrmRegistroProducto();
            producto.ShowDialog();
        }

        private void reporteDePOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenerarReportePO reporte = new FrmGenerarReportePO();
            reporte.Show();
        }

        private void monitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void galeríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGaleria fabricante = new FrmGaleria(2);
            fabricante.Show();
        }

        private void fabricantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdministrarFabricantes fab = new FrmAdministrarFabricantes();
            fab.Show();
        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {

           // PDFMakerNovo gestorPdf = new PDFMakerNovo();

          //  gestorPdf.CrearFormatoCotizacion(4);
        }

        private void costosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal dec = 77;
            FrmCostosComprasProyecto costos = new FrmCostosComprasProyecto(dec);
            costos.Show();
        }

        private void ventasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmMonitorVentas2 ventas = new FrmMonitorVentas2();
            ventas.Show();
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EPPlus
            //Creates a blank workbook. Use the using statment, so the package is disposed when we are done.
            using (var p = new ExcelPackage())
            {
                //AGREGAR HOJA DE TRABAJO
                var excelRow = p.Workbook.Worksheets.Add("MySheet");
                //AGREGAR VALOR A LOS RENGLONES DE EXCEL POR MEDIO DE UN INDICE
                excelRow.Cells["A1"].Value = "PROVEEDOR";
                excelRow.Cells["B1"].Value = "COMPETENCIA";
                excelRow.Cells["C1"].Value = "PUNTUACION";
                excelRow.Cells["D1"].Value = "PROMEDIO";
                excelRow.Cells["E1"].Value = "CATEGORIA";

                //estilos por rango o por renglon
                excelRow.Cells["A1:E1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                excelRow.Cells["A1:E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                excelRow.Cells["A1:E1"].Style.Font.Color.SetColor(Color.Black);
                excelRow.Cells["A1:E1"].Style.Font.Bold = true;

                //
                int renglon = 2;
                EvaluacionProveedor.Modelo().SeleccionarEvaluacionDePeriodo("2018-11-20", "2018-11-20").ForEach(delegate(Fila f)
                {
                    int renglonIniciaMerge = renglon;
                    int renglonFinalizaMerge = renglon + 3;

                    excelRow.Cells["A" + renglonIniciaMerge + ":A" + renglonFinalizaMerge].Merge = true;
                    excelRow.Cells["A" + renglon].Value = f.Celda("nombre");
                    excelRow.Cells["A" + renglon].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    excelRow.Cells["A" + renglon].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    EvaluacionHabilidadProveedor.Modelo().SeleccionarHabilidadesPuntuacion(Convert.ToInt32(f.Celda("id"))).ForEach(delegate(Fila filaHabilidad)
                    {
                        //Competencias y puntuación
                        excelRow.Cells["B" + renglon].Value = filaHabilidad.Celda("habilidad").ToString();
                        excelRow.Cells["C" + renglon].Value = filaHabilidad.Celda("puntuacion");
                        renglon++;
                    });

                    //TEXTO DEL MERGE
                    excelRow.Cells["D" + renglonIniciaMerge + ":D" + renglonFinalizaMerge].Merge = true;
                    excelRow.Cells["D" + renglonIniciaMerge].Value = f.Celda("resultado");
                    excelRow.Cells["D" + renglonIniciaMerge].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    excelRow.Cells["D" + renglonIniciaMerge].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    //TEXTO DEL MERGE
                    excelRow.Cells["E" + renglonIniciaMerge + ":E" + renglonFinalizaMerge].Merge = true;
                    excelRow.Cells["E" + renglonIniciaMerge].Value = f.Celda("categoria").ToString();
                    excelRow.Cells["E" + renglonIniciaMerge].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    excelRow.Cells["E" + renglonIniciaMerge].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                });


                excelRow.Cells["A1:E" + renglon].AutoFitColumns();

                //GUARDA EL LIBRO CON UN NOMBRE
                p.SaveAs(new FileInfo(@"C:\Users\Eilean Laborde\Desktop\TEST.xlsx"));
            }
        }

        private void libreriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLibreriasDme librerias = new FrmLibreriasDme();
            librerias.Show();
        }

        private void oAuthToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        public static bool SendAnSMSMessage(string message)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.pennysms.com/jsonrpc");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{installed:{client_id:916916614040-0upc91sdntvlkm966alek4tpsgmpi0up.apps.googleusercontent.com,project_id:companyblocks-266616,auth_uri:https://accounts.google.com/o/oauth2/auth,token_uri:https://oauth2.googleapis.com/token,auth_provider_x509_cert_url:https://www.googleapis.com/oauth2/v1/certs,client_secret:wNdTtY7irYLbnNLGYMQZ5wGe,redirect_uris:[urn:ietf:wg:oauth:2.0:oob,http://localhost]}}";

                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                //Now you have your response.
                //or false depending on information in the response
                return true;
            }
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void búsquedaDeRequisiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarRequisicionMiscelaneos buscarRequi = new FrmBuscarRequisicionMiscelaneos();
            buscarRequi.Show();
        }

        private void fabricaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void configuraciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MostrarContenido(new FrmConfiguracion());
            PanelArbolProyecto.Hide();
        }

        private void horasLaboradasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chromeToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
        }

        private void búsquedaDeNúmeroDeParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscadorNumeroPartePorProyecto numeroParte = new FrmBuscadorNumeroPartePorProyecto();
            numeroParte.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void buscarImagen(string numeroParte, string fabricante)
        {
            string url = "https://www.google.com/search?q=" + numeroParte.Replace(' ', '+') + "+" + fabricante.Replace(' ','+') + "&tbm=isch";
            string data = "";


            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "text/html, application/xhtml+xml, */*";

            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream != null)
                {
                    using (var sr = new StreamReader(dataStream))
                    {
                        data = sr.ReadToEnd();
                    }
                }
                else
                {
                    data = null;
                }
            }

            List<string> urls = GetUrls(data);
        }

        private List<string> GetUrls(string html)
        {
            var urls = new List<string>();

            List<string> imagenesHtml = new List<string>();
            string[] htmlDividido = html.Split('<');
            foreach (string imagen in htmlDividido)
            {
                if (imagen.StartsWith("img class"))
                {
                    //imagenesHtml.Add("<" + imagen);
                    List<string> separarUrls = imagen.Split('\"').ToList();
                    string result = separarUrls.Find(x => x.ToLower().StartsWith("https://"));
                    if(result != null)
                        urls.Add(result);
                }
            }


            return urls;
        }

        private byte[] GetImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000000);

                    return bytes;
                }
            }
        }

        private void restringirNúmeroDeParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRestringirNumeroParte rest = new FrmRestringirNumeroParte();
            rest.Show();
        }
    }
}