using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CB_Base.Classes;

namespace CB
{

    public partial class FrmEditarCotizacion2 : Form
    {
        int IdCotizacion = 0;
        byte[] Datos = null;
        string TextoNodoPadre = string.Empty;
        string RutaGuardarDocumento = string.Empty;
        string PathServidor = "SGC\\COTIZACIONES\\CLIENTES\\";
        Form Contenido = null;
        CotizacionClinte Cotizacion = new CotizacionClinte();
        
        public FrmEditarCotizacion2(int idCotizacion)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
        }

        private void FrmEditarCotizacion2_Load(object sender, EventArgs e)
        {
            Progreso.Visible = false;
            LblEstatus.Text = string.Empty;
            Cotizacion.CargarDatos(IdCotizacion);
            RefrescarNodo(CargarNodoCotizacion());
        }

        private TreeNode CargarNodoCotizacion()
        {
            Cotizacion.CargarDatos(IdCotizacion);
            TvCotizacion.Nodes.Clear();
            TreeNode tempNode =  Global.CrearNodo
            (
                "cotizacion-" + IdCotizacion,
                IdCotizacion.ToString().PadLeft(4, '0') + " - " + Cotizacion.Fila().Celda("nombre_cotizacion").ToString(),
                0
            );

           TvCotizacion.Nodes.Add(tempNode);
           tempNode.Expand();
           return tempNode;
        }

        #region Creacion de nodos principales
        private TreeNode CargarNodoInformacionGeneral(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
            (
                "informacion-" + IdCotizacion.ToString(),
                "Información General",
                1
            );

            nodoPadre.Nodes.Add(nodoTemp);
            return nodoTemp;
        }

        private void CargarNodoElementosEntrada(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "elementos-" + IdCotizacion.ToString(),
               "Elementos de entrada",
               6
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoAlcanceProyecto(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "alcance-" + IdCotizacion.ToString(),
               "Alcance del proyecto",
               2
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoProcesoManufactura(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "procesos-" + IdCotizacion.ToString(),
               "Proceso de manufactura",
               3
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodosPokayokes(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
            (
                "pokayokes-" + IdCotizacion.ToString(),
                "Lista de poka-yokes",
                3
            );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoModuloEstandar(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "modulos-" + IdCotizacion.ToString(),
               "Módulos estándar",
               4
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoSistemaPersonalizado(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "sistema-" + IdCotizacion.ToString(),
               "Sistemas personalizados",
               5
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoResumenCosto(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "resumen-" + IdCotizacion.ToString(),
               "Resumen de costos",
               14
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoSubProyecto(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "subproyecto-" + IdCotizacion.ToString(),
               "Subproyectos",
               9
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoSecuenciaDeOperaciones(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "secuenciaOperaciones-" + IdCotizacion.ToString(),
               "Secuencia de operaciones",
               22
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoDescripcionDeOperaciones(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
           (
               "descripcionProceso-" + IdCotizacion.ToString(),
               "Descripción del proceso",
               23
           );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        #endregion

        #region Crear subnodos
        private void CargarRfq(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
          (
              "rfq-" + IdCotizacion,
              "RFQ",
              13,
              MenuRfq
          );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoInformacionProducto(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
         (
             "informacionProducto-" + IdCotizacion,
             "Información del producto",
             15
         );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoModelos(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
         (
             "modeloPrincipal-" + IdCotizacion,
             "Modelos",
             17,
             MenuModelos
         );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoComponente(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
             (
                 "componentePrincipal-" + IdCotizacion,
                 "Componentes",
                 16,
                 MenuComponentes
             );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarNodoSubensamble(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
             (
                 "subensamblePrincipal-" + IdCotizacion,
                 "Subensambles",
                 20,
                 MenuSubensamble
             );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        private void CargarOtrosDocumentos(TreeNode nodoPadre)
        {
            TreeNode nodoTemp = Global.CrearNodo
          (
              "archivos-",
              "Archivos",
              12
          );

            nodoPadre.Nodes.Add(nodoTemp);
        }

        #endregion

        #region Crear nodos de información producto
        private void CargarModelosParaProducto(TreeNode nodoPadre, int idProducto)
        {
            nodoPadre.Nodes.Clear();

            ProductoModelo modelos = new ProductoModelo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@producto", idProducto);
            parametros.Add("@idCotizacion", IdCotizacion);
            modelos.SeleccionarDatos("producto = @producto and id_cotizacion=@idCotizacion", parametros);
            modelos.Filas().ForEach(delegate(Fila mod)
            {
                TreeNode nodoTemp = Global.CrearNodo(
                    "modelo-" + mod.Celda("id").ToString(),
                    mod.Celda("nombre").ToString(),
                    19,
                    MenuModelos
                    );

                nodoPadre.Nodes.Add(nodoTemp);
            });

            nodoPadre.Expand();
        }

        private void CargarComponentesParaProducto(TreeNode nodoPadre, int idProducto)
        {
            nodoPadre.Nodes.Clear();

            ProductoComponente componentes = new ProductoComponente();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@producto", idProducto);
            parametros.Add("@idCotizacion", IdCotizacion);

            componentes.SeleccionarDatos("producto = @producto and id_cotizacion=@idCotizacion", parametros);
            componentes.Filas().ForEach(delegate(Fila comp)
            {
                TreeNode nodoTemp = Global.CrearNodo(
                    "componente-" + comp.Celda("id").ToString(),
                    comp.Celda("nombre").ToString(),
                    21,
                    MenuComponentes
                    );

                nodoPadre.Nodes.Add(nodoTemp);
            });

            nodoPadre.Expand();
        }

        private void CargarVariantesParaComponente(TreeNode nodoPadre, int idComponente, int idGeometria = 0)
        {
            nodoPadre.Nodes.Clear();

            ProductoVariante variantes = new ProductoVariante();

            if (idGeometria == 0)
            {
                variantes.SeleccionarGeometrias(idComponente);
                variantes.Filas().ForEach(delegate(Fila vari)
                {
                    TreeNode nodoTemp = Global.CrearNodo(
                        "geometria-" + vari.Celda("grupo_geometria").ToString(),
                        "GEOMETRIA " + vari.Celda("grupo_geometria").ToString(),
                        6,
                        MenuGeometria
                        );

                    nodoPadre.Nodes.Add(nodoTemp);
                });
            }
            variantes.SeleccionarProductosVarianteYModelos(idComponente, idGeometria);
            variantes.Filas().ForEach(delegate(Fila vari)
            {
                TreeNode nodoTemp = Global.CrearNodo(
                    "variante-" + vari.Celda("id").ToString(),
                    vari.Celda("numero_parte_variante").ToString() + " | " + vari.Celda("nombre_modelo").ToString(),
                    18,
                    MenuComponentes
                    );

                nodoPadre.Nodes.Add(nodoTemp);
            });

            nodoPadre.Expand();
        }

        private void CargarVariantesParaSubensamble(TreeNode nodoPadre, int idSubensamble)
        {
            nodoPadre.Nodes.Clear();

            ProductoSubensambleVariante variantes = new ProductoSubensambleVariante();

            variantes.SeleccionarVariantesSubensamble(idSubensamble);
            variantes.Filas().ForEach(delegate(Fila vari)
            {
                TreeNode nodoTemp = Global.CrearNodo(
                    "varianteSubensamble-" + vari.Celda("id").ToString(),
                    vari.Celda("nombre_modelo").ToString(),
                    18
                    );

                nodoPadre.Nodes.Add(nodoTemp);
            });

            nodoPadre.Expand();
        }

        private void CargarSubensamblesParaProducto(TreeNode nodoPadre, int idProducto)
        {
            nodoPadre.Nodes.Clear();

            ProductoSubensamble subensambles = new ProductoSubensamble();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@producto", idProducto);
            parametros.Add("@idCotizacion", IdCotizacion);
            subensambles.SeleccionarDatos("producto = @producto and id_cotizacion=@idCotizacion", parametros);
            subensambles.Filas().ForEach(delegate(Fila suben)
            {
                TreeNode nodoTemp = Global.CrearNodo
                (
                    "subensamble-" + suben.Celda("id").ToString(),
                    Global.ObjetoATexto(suben.Celda("nombre").ToString(), "N/A"),
                    19,
                    MenuSubensamble
                );

                nodoPadre.Nodes.Add(nodoTemp);
            });

            nodoPadre.Expand();
        }

        private void CargarNodosDocumentos(TreeNode nodoPadre, int idVariante)
        {
            nodoPadre.Nodes.Clear();

            string variantePlanoNombre = "plano-0";
            string variantePlanoTexto = "PLANO";
            string varianteSolidoNombre = "solido-0";
            string varianteSolidoTexto = "SOLIDO";
            int imagenIndicePlano = 19;
            int imagenIndiceSolido = 19;

            switch (nodoPadre.Parent.Parent.Text)
            {
                case "SUBENSAMBLES":
                    ProductoSubensambleVariante varianteSubensamble = new ProductoSubensambleVariante();
                    varianteSubensamble.CargarDatos(idVariante);

                    if (varianteSubensamble.TieneFilas())
                    {
                        if (Convert.ToInt32(varianteSubensamble.Fila().Celda("plano_en_ftp")) > 0)
                        {
                            variantePlanoNombre = "plano-" + idVariante;
                            variantePlanoTexto = "PLANO";
                            imagenIndicePlano = 8;
                        }
                        if (Convert.ToInt32(varianteSubensamble.Fila().Celda("solido_en_ftp")) > 0)
                        {
                            varianteSolidoNombre = "solido-" + idVariante;
                            varianteSolidoTexto = "SOLIDO";
                            imagenIndiceSolido = 7;
                        }
                    }
                    break;
                default:
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(idVariante);

                    if (variante.TieneFilas())
                    {
                        if (Convert.ToInt32(variante.Fila().Celda("plano_en_ftp")) > 0)
                        {
                            variantePlanoNombre = "plano-" + idVariante;
                            variantePlanoTexto = "PLANO";
                            imagenIndicePlano = 8;
                        }
                        if (Convert.ToInt32(variante.Fila().Celda("solido_en_ftp")) > 0)
                        {
                            varianteSolidoNombre = "solido-" + idVariante;
                            varianteSolidoTexto = "SOLIDO";
                            imagenIndiceSolido = 7;
                        }
                    }
                    break;
            }



            TreeNode nodoTempPlano = Global.CrearNodo(
                variantePlanoNombre,
                variantePlanoTexto,
                imagenIndicePlano,
                MenuVariantes
                );

            TreeNode nodoTempSolido = Global.CrearNodo(
                varianteSolidoNombre,
                varianteSolidoTexto,
                imagenIndiceSolido,
                MenuVariantes
                );

            nodoPadre.Nodes.Add(nodoTempPlano);
            nodoPadre.Nodes.Add(nodoTempSolido);
            nodoPadre.Expand();

        }

        #endregion

        #region DragDrop

        private void TvCotizacion_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!(e.Item is TreeNode))
            {
                return;
            }

            TreeNode nodoSeleccionado = e.Item as TreeNode;

            if (!nodoSeleccionado.Name.StartsWith("variante"))
            {
                return;
            }

            DoDragDrop(e.Item, DragDropEffects.Move);

        }

        private void TvCotizacion_DragEnter(object sender, DragEventArgs e)
        {
            // Set the visual effect
            e.Effect = DragDropEffects.Move;
        }

        private void TvCotizacion_DragDrop(object sender, DragEventArgs e)
        {
            // e contains the data of the dragged items. See if has a

            // node data structure in it.

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {

                // node exists in drag data payload
                Point pt = this.TvCotizacion.PointToClient(new Point(e.X, e.Y));

                // Get a handle to the destination node. This will become
                // the parent of our new node.

                TreeNode nodoDestino = this.TvCotizacion.GetNodeAt(pt);

                // Create the new node based on the dragged node
                TreeNode nodoSeleccionado = (TreeNode)
                e.Data.GetData("System.Windows.Forms.TreeNode");

                // Check destination mode
                if (!(nodoDestino == nodoSeleccionado))
                {
                    switch (nodoDestino.Name.Split('-')[0])
                    {
                        case "geometria":
                        case "variante":
                            CambiarGeometria(nodoSeleccionado, nodoDestino);
                            break;
                    }
                }
            }
        }

        private void CambiarGeometria(TreeNode nodoSeleccionado, TreeNode nodoDestino)
        {
            int geometriaDestino = 0;
            ProductoVariante buscadorVariante = new ProductoVariante();

            if (nodoDestino.Name.StartsWith("variante"))
            {
                buscadorVariante.CargarDatos(Convert.ToInt32(nodoDestino.Name.Split('-')[1]));

                geometriaDestino = Convert.ToInt32(buscadorVariante.Fila().Celda("grupo_geometria"));

                // Agrupar en una nueva geometría en caso de no encontrarse en alguna
                if (geometriaDestino == 0)
                {
                    int idComponente = Convert.ToInt32(nodoDestino.Parent.Name.Split('-')[1]);

                    geometriaDestino = Convert.ToInt32(ProductoVariante.Modelo().SeleccionarUltimaGeometria(idComponente)[0].Celda("grupo_geometria")) + 1;
                    buscadorVariante.Fila().ModificarCelda("grupo_geometria", geometriaDestino);
                    buscadorVariante.GuardarDatos();
                }
            }

            if (nodoDestino.Name.StartsWith("geometria"))
            {
                geometriaDestino = Convert.ToInt32(Convert.ToInt32(nodoDestino.Name.Split('-')[1]));
            }

            buscadorVariante.CargarDatos(Convert.ToInt32(nodoSeleccionado.Name.Split('-')[1]));

            buscadorVariante.Fila().ModificarCelda("grupo_geometria", geometriaDestino);
            buscadorVariante.GuardarDatos();

            MessageBox.Show("Se han agrupado las variantes dentro de un grupo de geometría.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TreeNode nodoComponente = nodoDestino;
            do
            {

                if (nodoComponente.Name.StartsWith("componente"))
                {
                    RefrescarNodo(nodoComponente);
                }

            } while (nodoComponente.Parent != null && nodoComponente.Name.StartsWith("componente"));

            RefrescarNodo(TvCotizacion.SelectedNode.Parent);
        }
        #endregion /DragDrop

        private void ActualizarTablaVariante(string nombrePlano, string tipoPadre, string tipoSeleccionado, int idVariante)
        {
            switch (tipoPadre.ToUpper())
            {
                case "COMPONENTES":
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(idVariante);
                    if (tipoSeleccionado == "plano")
                    {
                        nombrePlano += ".PDF";
                        FrmVisorPDF visor = new FrmVisorPDF(Datos, nombrePlano);
                        visor.WindowState = FormWindowState.Maximized;
                        MostrarContenido(visor);
                        if (variante.TieneFilas())
                        {
                            variante.Fila().ModificarCelda("plano_en_ftp", 1);
                            variante.Fila().ModificarCelda("fecha_plano_subido", DateTime.Now);
                            variante.Fila().ModificarCelda("usuario_creacion_plano", Global.UsuarioActual.Fila().Celda("id"));
                            variante.GuardarDatos();
                        }
                    }
                    else
                    {
                        //step
                        OcultarContenido();
                        nombrePlano += ".STEP";
                        variante.CargarDatos(Convert.ToInt32(TvCotizacion.SelectedNode.Parent.Name.Split('-')[1]));
                        if (variante.TieneFilas())
                        {
                            variante.Fila().ModificarCelda("solido_en_ftp", 1);
                            variante.Fila().ModificarCelda("fecha_solido_subido", DateTime.Now);
                            variante.Fila().ModificarCelda("usuario_creacion_solido", Global.UsuarioActual.Fila().Celda("id"));
                            variante.GuardarDatos();
                        }
                    }
                    break;
                case "SUBENSAMBLES":
                    ProductoSubensambleVariante varianteSubensamble = new ProductoSubensambleVariante();
                    varianteSubensamble.CargarDatos(idVariante);
                    if (tipoSeleccionado == "plano")
                    {
                        nombrePlano += ".PDF";
                        FrmVisorPDF visor = new FrmVisorPDF(Datos, nombrePlano);
                        visor.WindowState = FormWindowState.Maximized;
                        MostrarContenido(visor);
                        if (varianteSubensamble.TieneFilas())
                        {
                            varianteSubensamble.Fila().ModificarCelda("plano_en_ftp", 1);
                            varianteSubensamble.Fila().ModificarCelda("fecha_plano_subido", DateTime.Now);
                            varianteSubensamble.Fila().ModificarCelda("usuario_creacion_plano", Global.UsuarioActual.Fila().Celda("id"));
                            varianteSubensamble.GuardarDatos();
                        }
                    }
                    else
                    {
                        //step
                        OcultarContenido();
                        nombrePlano += ".STEP";
                        varianteSubensamble.CargarDatos(Convert.ToInt32(TvCotizacion.SelectedNode.Parent.Name.Split('-')[1]));
                        if (varianteSubensamble.TieneFilas())
                        {
                            varianteSubensamble.Fila().ModificarCelda("solido_en_ftp", 1);
                            varianteSubensamble.Fila().ModificarCelda("fecha_solido_subido", DateTime.Now);
                            varianteSubensamble.Fila().ModificarCelda("usuario_creacion_solido", Global.UsuarioActual.Fila().Celda("id"));
                            varianteSubensamble.GuardarDatos();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void RefrescarArbol()
        {
            RefrescarNodo(CargarNodoCotizacion());
        }

        public void HabilitarTreeview(bool habilitar)
        {
            TvCotizacion.Enabled = habilitar;
        }

        private void RefrescarNodo(TreeNode nodoPadre)
        {
            string[] nombreDividido = nodoPadre.Name.Split('-');
            switch (nombreDividido[0])
            {
                case "alcance":
                    FrmAlcanceProyecto alcance = new FrmAlcanceProyecto(IdCotizacion);
                    alcance.WindowState = FormWindowState.Maximized;
                    MostrarContenido(alcance);
                    break;
                case "archivos":
                    FrmGaleria galeria = new FrmGaleria(IdCotizacion);
                    galeria.WindowState = FormWindowState.Maximized;
                    MostrarContenido(galeria);
                    break;
                case "componente":
                    CargarVariantesParaComponente(nodoPadre, Convert.ToInt32(nombreDividido[1]));
                    break;
                case "componentePrincipal":
                    CargarComponentesParaProducto(nodoPadre, Convert.ToInt32(Cotizacion.Fila().Celda("producto")));
                    break;
                case "cotizacion":
                    nodoPadre.Nodes.Clear();
                    CargarNodoInformacionGeneral(nodoPadre);
                    CargarNodoElementosEntrada(nodoPadre);
                    CargarNodoAlcanceProyecto(nodoPadre);
                    CargarNodoProcesoManufactura(nodoPadre);
                   // CargarNodoDescripcionDeOperaciones(nodoPadre);
                    CargarNodoSecuenciaDeOperaciones(nodoPadre);
                    CargarNodosPokayokes(nodoPadre);
                    CargarNodoModuloEstandar(nodoPadre);
                    CargarNodoSistemaPersonalizado(nodoPadre);
                    CargarNodoResumenCosto(nodoPadre);
                    CargarNodoSubProyecto(nodoPadre);
                    nodoPadre.Expand();
                    break;
                case "descripcionProceso":

                    break;
                case "elementos":
                    nodoPadre.Nodes.Clear();
                    CargarRfq(nodoPadre);
                    CargarNodoInformacionProducto(nodoPadre);
                    CargarOtrosDocumentos(nodoPadre);
                    nodoPadre.Expand();
                    break;
                case "geometria":
                    CargarVariantesParaComponente(nodoPadre, Convert.ToInt32(TvCotizacion.SelectedNode.Parent.Name.Split('-')[1]), Convert.ToInt32(nombreDividido[1]));
                    break;
                case "informacion":
                    FrmInformacionGeneralCotizacion informacion = new FrmInformacionGeneralCotizacion(IdCotizacion, this);
                    informacion.WindowState = FormWindowState.Maximized;
                    MostrarContenido(informacion);
                    break;
                case "informacionProducto":
                    OcultarContenido();
                    nodoPadre.Nodes.Clear();
                    CargarNodoModelos(nodoPadre);
                    CargarNodoComponente(nodoPadre);
                    CargarNodoSubensamble(nodoPadre);
                    nodoPadre.Expand();
                    break;
                case "modeloPrincipal":
                    if (Cotizacion.Fila().Celda("producto") == null)
                    {
                        MessageBox.Show("Debe seleccionar un producto para la cotización", "No ha registrado productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    CargarModelosParaProducto(nodoPadre, Cotizacion.Fila().Celda<int>("producto"));
                    break;
                case "modulos":
                    FrmModulosEstandarCotizacion modulosEstandarCotizacion = new FrmModulosEstandarCotizacion(IdCotizacion);
                    modulosEstandarCotizacion.WindowState= FormWindowState.Maximized;
                    MostrarContenido(modulosEstandarCotizacion);
                    break;
                case "pokayokes":
                    FrmListaPokayoke pokayoke = new FrmListaPokayoke(IdCotizacion);
                    pokayoke.WindowState = FormWindowState.Maximized;
                    MostrarContenido(pokayoke);
                    break;
                case "procesos":
                    FrmProcesoManufactura2 procesos = new FrmProcesoManufactura2(Convert.ToInt32(Cotizacion.Fila().Celda("producto")), Convert.ToInt32(Cotizacion.Fila().Celda("id")), "SGC\\COTIZACIONES\\SECUENCIAOPERACIONES\\", this);
                    procesos.WindowState = FormWindowState.Maximized;
                    MostrarContenido(procesos);
                    break;
                case "secuenciaOperaciones":
                    OcultarContenido();
                    FrmRTF rtf = new FrmRTF(IdCotizacion, "SGC\\COTIZACIONES\\SECUENCIAOPERACIONES\\", this);
                    rtf.WindowState = FormWindowState.Maximized;
                    MostrarContenido(rtf);
                    break;
                case "subensamble":
                    CargarVariantesParaSubensamble(nodoPadre, Convert.ToInt32(nodoPadre.Name.Split('-')[1]));
                    break;
                case "subensamblePrincipal":
                    CargarSubensamblesParaProducto(nodoPadre, Convert.ToInt32(Cotizacion.Fila().Celda("producto")));
                    break;
                case "varianteSubensamble":
                case "variante":
                    int idVariante = Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]);
                    CargarNodosDocumentos(nodoPadre, idVariante);
                    break;
                case "rfq":
                    if(Convert.ToInt32(Cotizacion.Fila().Celda("cotizacion_en_servidor")) <= 0)
                    {
                        DialogResult result = MessageBox.Show("Actualmente no se ha cargado un RFQ, ¿Desea cargar el documento ahora?", "Cargar RFQ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(result == System.Windows.Forms.DialogResult.Yes)
                        {
                            OfdSeleccionarArchivo.InitialDirectory = "c:\\";
                            OfdSeleccionarArchivo.Filter = "PDF files (*.PDF)|*.pdf";
                            OfdSeleccionarArchivo.RestoreDirectory = true;

                            if (OfdSeleccionarArchivo.ShowDialog() == DialogResult.OK)
                            {
                                TvCotizacion.Enabled = false;
                                Progreso.Visible = true;
                                Datos = File.ReadAllBytes(OfdSeleccionarArchivo.FileName);
                                BkgSubirArchivos.RunWorkerAsync(nombreDividido[1]);
                            }
                        }
                    }
                    else
                    {
                        BkgMostrarDocumento.RunWorkerAsync(nombreDividido[1]);
                    }
                    break;
                default:
                    break;
            }
        }

        private void TvCotizacion_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodo(e.Node);
        }

        public void MostrarContenido(Form ventana)
        {
            if (Contenido != null)
                Contenido.Close();

            Contenido = ventana;
            ventana.MdiParent = this;
            ventana.Show();
        }

        public void OcultarContenido()
        {
            if (Contenido != null)
            {
                if (Contenido.Visible)
                    Contenido.Close();
            }
        }

        #region menu opciones
        private void subirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] nombreDividido = TvCotizacion.SelectedNode.Name.Split('-');
            OfdSeleccionarArchivo.InitialDirectory = "c:\\";
            OfdSeleccionarArchivo.Filter = "PDF files (*.PDF)|*.pdf";
            OfdSeleccionarArchivo.RestoreDirectory = true;

            if (OfdSeleccionarArchivo.ShowDialog() == DialogResult.OK)
            {
                TvCotizacion.Enabled = false;
                Progreso.Visible = true;
                Datos = File.ReadAllBytes(OfdSeleccionarArchivo.FileName);
                BkgSubirArchivos.RunWorkerAsync(nombreDividido[1]);
            }
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BkgDescargarDocumento.RunWorkerAsync("SGC\\COTIZACIONES\\CLIENTES\\RFQ\\");
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el documento seleccionado?", "Eliminar documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                BkgEliminarDocumento.RunWorkerAsync(PathServidor + "RFQ\\");
            }
        }

        private void agregarModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Cotizacion.Fila().Celda("producto") == null)
            {
                MessageBox.Show("Debe seleccionar un producto para la cotización", "No ha registrado productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FrmRegistrarModeloProducto modelo = new FrmRegistrarModeloProducto(Cotizacion.Fila().Celda<int>("cliente"), IdCotizacion, Cotizacion.Fila().Celda<int>("cliente_industria"), Cotizacion.Fila().Celda<int>("producto"));
            modelo.ShowDialog();
            RefrescarNodo(TvCotizacion.SelectedNode);
        }

        private void agregarComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarProductoComponente componente = new FrmRegistrarProductoComponente(Convert.ToInt32(Cotizacion.Fila().Celda("cliente")), IdCotizacion, Convert.ToInt32(Cotizacion.Fila().Celda("producto")));
            componente.ShowDialog();
            RefrescarNodo(TvCotizacion.SelectedNode);
        }

        private void agregarVarianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarVariante nuevaVariante = new FrmRegistrarVariante(Convert.ToInt32(Cotizacion.Fila().Celda("producto")), Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]));
            if (nuevaVariante.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefrescarNodo(TvCotizacion.SelectedNode);
            }
        }

        private void eliminarComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea borrar el componente " + TvCotizacion.SelectedNode.Text + "?", "Borrar componente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idComponente = Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]);
                ProductoVariante variante = new ProductoVariante();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idComponente", idComponente);
                List<string> informacion = new List<string>();
                variante.SeleccionarDatos("componente=@idComponente", parametros).ForEach(delegate(Fila f)
                {
                    informacion.Add(f.Celda("id").ToString());
                });

                ProductoSubensamble.Modelo().BorrarComponente(Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]));

                TreeNode nodo = TvCotizacion.SelectedNode.Parent.Parent.Nodes[2];
                RefrescarNodo(TvCotizacion.SelectedNode.Parent);
                RefrescarNodo(nodo);

                TvCotizacion.Enabled = false;
                LblEstatus.Text = string.Empty;
                LblEstatus.Visible = true;
                BkgEliminarVariantes.RunWorkerAsync(informacion.ToArray());
            }
        }

        private void eliminarModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea borrar el modelo " + TvCotizacion.SelectedNode.Text + "?", "Borrar modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idModelo = Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]);
                ProductoVariante variante = new ProductoVariante();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idModelo", idModelo);
                List<string> informacion = new List<string>();
                variante.SeleccionarDatos("modelo_variante=@idModelo", parametros).ForEach(delegate(Fila f)
                {
                    informacion.Add(f.Celda("id").ToString());
                });

                ProductoModelo.Modelo().BorrarModelo(Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]));
                TreeNode[] buscarNodo = TvCotizacion.SelectedNode.Nodes.Find("componentes", true);
                RefrescarNodo(TvCotizacion.SelectedNode.Parent);
                RefrescarNodo(TvCotizacion.SelectedNode.NextNode);

                TvCotizacion.Enabled = false;
                LblEstatus.Text = string.Empty;
                LblEstatus.Visible = true;
                BkgEliminarVariantes.RunWorkerAsync(informacion.ToArray());
            }
        }

        private void eliminarVarianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de borrar la variante seleccionada?", "Borrar variante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                TvCotizacion.Enabled = false;
                LblEstatus.Text = string.Empty;
                LblEstatus.Visible = true;
                int idVariante = Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]);
                string[] informacion = new string[] { idVariante.ToString() };
                BkgEliminarVariantes.RunWorkerAsync(informacion);
            }
        }

        private void removerDeGrupoDeGeometriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoVariante buscadorVariante = new ProductoVariante();
            buscadorVariante.CargarDatos(Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]));

            buscadorVariante.Fila().ModificarCelda("grupo_geometria", 0);
            buscadorVariante.GuardarDatos();

            MessageBox.Show("Se ha eliminado esta variante de el grupo de geometría.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarNodo(TvCotizacion.SelectedNode.Parent.Parent);
        }

        private void eliminarGeometriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoVariante buscadorVariante = new ProductoVariante();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@geometria", Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]));
            parametros.Add("@componente", Convert.ToInt32(TvCotizacion.SelectedNode.Parent.Name.Split('-')[1]));

            buscadorVariante.SeleccionarDatos("grupo_geometria = @geometria AND componente = @componente", parametros);

            buscadorVariante.Filas().ForEach(delegate(Fila variante)
            {
                variante.ModificarCelda("grupo_geometria", 0);
            });

            buscadorVariante.GuardarDatos();

            MessageBox.Show("Se ha eliminado el grupo de geometría. Se han transferido las variantes fuera de los demás grupos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarNodo(TvCotizacion.SelectedNode.Parent);
        }

        private void agregarSubensambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarSubensamble sub = new FrmRegistrarSubensamble(Convert.ToInt32(Cotizacion.Fila().Celda("producto")), Convert.ToInt32(Cotizacion.Fila().Celda("cliente")), Convert.ToInt32(Cotizacion.Fila().Celda("cliente_industria")), IdCotizacion);
            sub.ShowDialog();
            RefrescarNodo(TvCotizacion.SelectedNode);
        }

        private void agregarVarianteSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarVarianteSubensamble nuevaVariante = new FrmRegistrarVarianteSubensamble(Convert.ToInt32(Cotizacion.Fila().Celda("producto")), Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]));
            if (nuevaVariante.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefrescarNodo(TvCotizacion.SelectedNode);
            }
        }

        private void eliminarSubensambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea borrar el subensamble " + TvCotizacion.SelectedNode.Text + "?", "Borrar subensamble", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idSubensamble = Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]);
                TextoNodoPadre = "SUBENSAMBLES";
                List<string> idVariante = new List<string>();
                ProductoSubensamble.Modelo().BorrarSubensamble(idSubensamble);
                ProductoSubensambleVariante variante = new ProductoSubensambleVariante();
                variante.SeleccionarVariantesSubensamble(idSubensamble).ForEach(delegate(Fila f)
                {
                    idVariante.Add(f.Celda("id").ToString());
                });

                BkgEliminarVariantes.RunWorkerAsync(idVariante.ToArray());
            }
        }

        private void subirPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFDSubirArchivo.Filter = "archivos pdf|*.pdf";
            OFDSubirArchivo.DefaultExt = "pdf";
            OFDSubirArchivo.Title = "Seleccionar documento";
            OFDSubirArchivo.FileName = string.Empty;
            string rutaFtp = string.Empty;

            if (OFDSubirArchivo.ShowDialog() == DialogResult.OK)
            {
                LblEstatus.Text = "Subiendo documento";
                Progreso.Value = 0;
                Progreso.Visible = true;
                TvCotizacion.Enabled = false;
                Datos = File.ReadAllBytes(OFDSubirArchivo.FileName);
                if (TvCotizacion.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\PLANOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\PLANOS\\";

                string[] informacion = new string[] { TvCotizacion.SelectedNode.Parent.Name.ToString().Split('-')[1], rutaFtp, "plano" };
                BkgSubirDocumentosVariantes.RunWorkerAsync(informacion);
            }
        }

        private void descargarPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar documento";
            saveFileDialog1.FileName = "variante_" + TvCotizacion.SelectedNode.Parent.Name.Split('-')[1].ToString().PadLeft(4,'0') + ".PDF";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LblEstatus.Text = "Subiendo documento";
                Progreso.Value = 0;
                Progreso.Visible = true;
                TvCotizacion.Enabled = false;
                string rutaFtp = string.Empty;
                if (TvCotizacion.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\PLANOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\PLANOS\\";
                string[] informacion = new string[] { TvCotizacion.SelectedNode.Parent.Name.Split('-')[1], rutaFtp, saveFileDialog1.FileName, "plano" };

                BkgDescargarDocumentosVariantes.RunWorkerAsync(informacion);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OFDSubirArchivo.Filter = "archivos step|*.step";
            OFDSubirArchivo.DefaultExt = "step";
            OFDSubirArchivo.Title = "Seleccionar documento";
            OFDSubirArchivo.FileName = string.Empty;
            if (OFDSubirArchivo.ShowDialog() == DialogResult.OK)
            {
                LblEstatus.Text = "Subiendo documento";
                Progreso.Value = 0;
                Progreso.Visible = true;
                TvCotizacion.Enabled = false;
                string rutaFtp = string.Empty;
                if (TvCotizacion.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\SOLIDOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\SOLIDOS\\";
                Datos = File.ReadAllBytes(OFDSubirArchivo.FileName);
                string[] informacion = new string[] { TvCotizacion.SelectedNode.Parent.Name.ToString().Split('-')[1], rutaFtp, "solido" };
                BkgSubirDocumentosVariantes.RunWorkerAsync(informacion);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar documento";
            saveFileDialog1.FileName = "variante_" + TvCotizacion.SelectedNode.Parent.Name.Split('-')[1].ToString().PadLeft(4, '0') + ".step";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LblEstatus.Text = "Subiendo documento";
                Progreso.Value = 0;
                Progreso.Visible = true;
                TvCotizacion.Enabled = false;

                string rutaFtp = string.Empty;
                if (TvCotizacion.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\SOLIDOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\SOLIDOS\\";

                string[] informacion = new string[] { TvCotizacion.SelectedNode.Parent.Name.Split('-')[1], rutaFtp, saveFileDialog1.FileName, "solido" };
                BkgDescargarDocumentosVariantes.RunWorkerAsync(informacion);
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]) <= 0)
                return;

            DialogResult result = MessageBox.Show("Si remueve el documento no podrá ser recuperado, ¿Está seguro que desea remover el documento seleccionado?", "Remover documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string formato = string.Empty;
                string rutaFtp = string.Empty;

                LblEstatus.Text = "Subiendo documento";
                Progreso.Value = 0;
                Progreso.Visible = true;
                TvCotizacion.Enabled = false;

                if (TvCotizacion.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                {
                    if (TvCotizacion.SelectedNode.Name.Split('-')[0] == "plano")
                    {
                        formato = "plano";
                        rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\PLANOS\\";
                    }
                    else
                    {
                        formato = "solido";
                        rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\SOLIDOS\\";
                    }
                }
                else
                {
                    if (TvCotizacion.SelectedNode.Name.Split('-')[0] == "plano")
                    {
                        formato = "plano";
                        rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\PLANOS\\";
                    }
                    else
                    {
                        formato = "solido";
                        rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\SOLIDOS\\";
                    }
                }

                string[] informacion = new string[] { TvCotizacion.SelectedNode.Name.Split('-')[1], formato, rutaFtp };
                BkgRemoverDocumento.RunWorkerAsync(informacion);
            }
        }

        #endregion

        #region menus
        private void MenuSubensamble_Opening(object sender, CancelEventArgs e)
        {
            bool sobreNodoSubensamble = TvCotizacion.SelectedNode.Name.Split('-')[0].StartsWith("subensamblePrincipal");

            agregarSubensambleToolStripMenuItem.Visible = sobreNodoSubensamble;
            eliminarSubensambleToolStripMenuItem.Visible = !sobreNodoSubensamble;
            agregarVarianteSubToolStripMenuItem.Visible = !sobreNodoSubensamble;
        }

        private void MenuVariantes_Opening(object sender, CancelEventArgs e)
        {
            string nombreSeleccionado = TvCotizacion.SelectedNode.Name.Split('-')[0];

            subirPlanoToolStripMenuItem.Visible = (nombreSeleccionado == "plano");
            descargarPlanoToolStripMenuItem.Visible = (nombreSeleccionado == "plano");
            subirSólidoToolStripMenuItem.Visible = (nombreSeleccionado == "solido");
            descargarSólidoToolStripMenuItem.Visible = (nombreSeleccionado == "solido");
        }

        private void MenuComponentes_Opening(object sender, CancelEventArgs e)
        {
            bool sobreNodoRaizComponente = TvCotizacion.SelectedNode.Name.Split('-')[0].StartsWith("componentePrincipal");
            bool sobreNodoComponente = TvCotizacion.SelectedNode.Name.StartsWith("componente-");
            bool sobreNodoVariante = TvCotizacion.SelectedNode.Name.Split('-')[0].StartsWith("variante");

            agregarComponenteToolStripMenuItem.Visible = sobreNodoRaizComponente;
            eliminarComponenteToolStripMenuItem.Visible = sobreNodoComponente;
            agregarVarianteToolStripMenuItem.Visible = sobreNodoComponente;
            eliminarVarianteToolStripMenuItem.Visible = sobreNodoVariante;

            bool test = sobreNodoVariante && TvCotizacion.SelectedNode.Parent.Name.Contains("geometria");
            removerDeGrupoDeGeometriaToolStripMenuItem.Visible = test;
        }

        private void MenuModelos_Opening(object sender, CancelEventArgs e)
        {
            bool sobreNodoModelo = TvCotizacion.SelectedNode.Name.Split('-')[0].StartsWith("modeloPrincipal");

            agregarModeloToolStripMenuItem.Visible = sobreNodoModelo;
            eliminarModeloToolStripMenuItem.Visible = !sobreNodoModelo;
        }

        #endregion

        #region Hilos

        private void BkgSubirArchivos_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgSubirArchivos.ReportProgress(30, "Subiendo documento...");
            byte[] datosRFQ = Datos;
            string path = PathServidor + "\\RFQ\\";
            int idDocumento = Convert.ToInt32(e.Argument);
            FormatoArchivo formato = FormatoArchivo.Pdf;
            

            BkgSubirArchivos.ReportProgress(60, "Subiendo documento...");
            bool archivoSubido = ServidorFtp.SubirDocumento(datosRFQ, idDocumento, formato, path);

            if (archivoSubido)
            {
                BkgSubirArchivos.ReportProgress(80, "Actualizando información...");

                Cotizacion.Fila().ModificarCelda("cotizacion_en_servidor", 1);
                Cotizacion.GuardarDatos();
                Cotizacion.CargarDatos(IdCotizacion);
                e.Result = true;
                BkgSubirArchivos.ReportProgress(100, "Documento almacenado");
            }
            else
            {
                e.Result = true;
                BkgSubirArchivos.ReportProgress(100, "Error al subir el documento");
            }
        }

        private void BkgSubirArchivos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgSubirArchivos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TvCotizacion.Enabled = true;
            Progreso.Visible = false;
            Progreso.Value = 0;

            if ((bool)e.Result)
            {
                FrmVisorPDF visor = new FrmVisorPDF(Datos, "Cotizacion " + IdCotizacion + ".pdf");
                visor.WindowState = FormWindowState.Maximized;
                MostrarContenido(visor);
            }
            else
                MessageBox.Show("No fue posible subir su documento");

            LblEstatus.Text = string.Empty;
            Datos = null;
        }

        private void BkgMostrarDocumento_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgMostrarDocumento.ReportProgress(30, "Descargando documento...");
            Datos = null;
            string path = PathServidor + "\\RFQ\\";
            int idDocumento = Convert.ToInt32(e.Argument);
            FormatoArchivo formato = FormatoArchivo.Pdf;

            BkgMostrarDocumento.ReportProgress(30, "Descargando documento...");
            Datos = ServidorFtp.DescargarArchivo(idDocumento, formato, path);

            if (Datos != null)
            {
                e.Result = true;
                BkgMostrarDocumento.ReportProgress(100, "Mostrando documento");
            }
            else
            {
                e.Result = false;
                BkgMostrarDocumento.ReportProgress(100, "Error al descargar archivo");
            }
        }

        private void BkgMostrarDocumento_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgMostrarDocumento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TvCotizacion.Enabled = true;
            Progreso.Visible = false;
            Progreso.Value = 0;

            if((bool)e.Result)
            {
                FrmVisorPDF visor = new FrmVisorPDF(Datos, "Cotizacion " + IdCotizacion + ".pdf");
                visor.WindowState = FormWindowState.Maximized;
                MostrarContenido(visor);
                LblEstatus.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("No fue posible mostrar el documento");
                LblEstatus.Text = string.Empty;
            }
            Datos = null;
        }

        private void BkgDescargarDocumento_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgDescargarDocumento.ReportProgress(30, "Descargando documento...");
            Datos = null;
            string path = e.Argument.ToString();
            int idDocumento = IdCotizacion;
            FormatoArchivo formato = FormatoArchivo.Pdf;

            BkgDescargarDocumento.ReportProgress(30, "Descargando documento...");
            Datos = ServidorFtp.DescargarArchivo(idDocumento, formato, path);

            if (Datos != null)
            {
                e.Result = true;
                BkgDescargarDocumento.ReportProgress(100, "Mostrando documento");
            }
            else
            {
                e.Result = false;
                BkgDescargarDocumento.ReportProgress(100, "Error al descargar archivo");
            }
        }

        private void BkgDescargarDocumento_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgDescargarDocumento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TvCotizacion.Enabled = true;
            Progreso.Visible = false;
            Progreso.Value = 0;

            if ((bool)e.Result)
            {
                SfdGuardarArchivo.Filter = "pdf files (*.pdf)|*.pdf";
                SfdGuardarArchivo.RestoreDirectory = true;

                if (SfdGuardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(SfdGuardarArchivo.FileName, Datos);
                    FrmVisorPDF visor = new FrmVisorPDF(Datos, "Cotizacion " + IdCotizacion + ".pdf");
                    visor.WindowState = FormWindowState.Maximized;
                    MostrarContenido(visor);

                    LblEstatus.Text = SfdGuardarArchivo.FileName.ToString();
                }
            }
            else
            {
                MessageBox.Show("No fue posible mostrar el documento");
            }
            Datos = null;
        }

        private void BkgEliminarDocumento_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] informacion = (string[])e.Argument;
            BkgEliminarDocumento.ReportProgress(30, "Eliminando documento...");
            Datos = null;
            string path = e.Argument.ToString();
            int idDocumento = IdCotizacion;
            FormatoArchivo formato = FormatoArchivo.Pdf;

            BkgEliminarDocumento.ReportProgress(30, "Eliminando documento...");
            bool documentoEliminado = ServidorFtp.RemoverArchivo(idDocumento, formato, path);

            if (documentoEliminado)
            {
                Cotizacion.Fila().ModificarCelda("cotizacion_en_servidor", 0);
                Cotizacion.GuardarDatos();
                Cotizacion.CargarDatos(IdCotizacion);

                e.Result = true;
                BkgEliminarDocumento.ReportProgress(100, "Documento eliminado");
            }
            else
            {
                e.Result = false;
                BkgEliminarDocumento.ReportProgress(100, "Error al eliminar el documento");
            }
        }

        private void BkgEliminarDocumento_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgEliminarDocumento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TvCotizacion.Enabled = true;
            Progreso.Visible = false;
            Progreso.Value = 0;
            LblEstatus.Text = string.Empty;

            if((bool)e.Result)
                MessageBox.Show("Documento eliminado correctamente");
            else
                MessageBox.Show("El documento seleccionado no pudo ser eliminado");
        }

        private void BkgEliminarVariantes_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] informacion = (string[])e.Argument;
            BkgEliminarVariantes.ReportProgress(30, "Removiendo documento ...");
            foreach (string idVariable in informacion)
            {
                if (TextoNodoPadre == "SUBENSAMBLES")
                {
                    ServidorFtp.RemoverArchivo(Convert.ToInt32(idVariable), FormatoArchivo.Pdf, "SGC\\VARIANTES\\SUBENSAMBLES\\PLANOS\\");
                    ServidorFtp.RemoverArchivo(Convert.ToInt32(idVariable), FormatoArchivo.Step, "SGC\\VARIANTES\\SUBENSAMBLES\\SOLIDOS\\");
                }
                else
                {
                    ServidorFtp.RemoverArchivo(Convert.ToInt32(idVariable), FormatoArchivo.Pdf, "SGC\\VARIANTES\\COMPONENTES\\PLANOS\\");
                    ServidorFtp.RemoverArchivo(Convert.ToInt32(idVariable), FormatoArchivo.Step, "SGC\\VARIANTES\\COMPONENTES\\SOLIDOS\\");
                }
            }

            BkgEliminarVariantes.ReportProgress(100, "Removiendo documento ...");
        }

        private void BkgEliminarVariantes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgEliminarVariantes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OcultarContenido();
            LblEstatus.Visible = true;
            LblEstatus.Text = "Documento removido";

            if (TvCotizacion.SelectedNode == null)
                return;

            if (TvCotizacion.SelectedNode.Name.ToString().StartsWith("variante"))
            {
                if (TextoNodoPadre == "SUBENSAMBLES")
                {
                    ProductoSubensambleVariante variante = new ProductoSubensambleVariante();
                    variante.SeleccionarVariantesSubensamble(Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1])).ForEach(delegate(Fila f)
                    {
                        ProductoSubensambleVariante borrarVariante = new ProductoSubensambleVariante();
                        borrarVariante.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        borrarVariante.BorrarDatos();
                        borrarVariante.GuardarDatos();
                    });
                }
                else
                {
                    int idVariante = Convert.ToInt32(TvCotizacion.SelectedNode.Name.Split('-')[1]);
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(idVariante);
                    variante.BorrarDatos();
                    variante.GuardarDatos();
                }
            }
            TextoNodoPadre = string.Empty;
            TvCotizacion.Enabled = true;
            RefrescarNodo(TvCotizacion.SelectedNode.Parent);
        }

        private void BkgSubirDocumentosVariantes_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] informacion = (string[])e.Argument;
            string formato = informacion[2];
            string rutaFtp = informacion[1];
            int idDocumento = Convert.ToInt32(informacion[0]);
            FormatoArchivo formatoDocumento;

            switch (formato)
            {
                case "plano":
                    formatoDocumento = FormatoArchivo.Pdf;
                    break;
                case "solido":
                    formatoDocumento = FormatoArchivo.Step;
                    break;
                default:
                    formatoDocumento = FormatoArchivo.Pdf;
                    break;
            }
            bool documentoSubido = ServidorFtp.SubirDocumento(Datos, Convert.ToInt32(informacion[0]), formatoDocumento, rutaFtp);
            e.Result = documentoSubido;
        }

        private void BkgSubirDocumentosVariantes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgSubirDocumentosVariantes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string nombrePlano = "variante_" + TvCotizacion.SelectedNode.Parent.Name.Split('-')[1].ToString().PadLeft(4, '0');
            int idVariante = Convert.ToInt32(TvCotizacion.SelectedNode.Parent.Name.Split('-')[1]);
            if ((bool)e.Result)
            {
                if (TvCotizacion.SelectedNode.Parent.Parent.Parent.Text == "SUBENSAMBLES")
                {
                    ProductoSubensambleVariante variante = new ProductoSubensambleVariante();
                    variante.CargarDatos(idVariante);
                    ActualizarTablaVariante(nombrePlano, "SUBENSAMBLES", TvCotizacion.SelectedNode.Name.Split('-')[0].ToString(), idVariante);
                }
                else
                {
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(idVariante);
                    ActualizarTablaVariante(nombrePlano, "COMPONENTES", TvCotizacion.SelectedNode.Name.Split('-')[0].ToString(), idVariante);
                }

                LblEstatus.Visible = true;
                LblEstatus.Text = "Documento almacenado";
            }
            else
            {
                OcultarContenido();
                LblEstatus.Text = "Documento almacenado";
            }

            Progreso.Value = 0;
            Progreso.Visible = false;
            TvCotizacion.Enabled = true;
            TreeNode nodoPadre = TvCotizacion.SelectedNode.Parent;
            RefrescarNodo(nodoPadre);
            CargarNodosDocumentos(nodoPadre, idVariante);
        }

        private void BkgDescargarDocumentosVariantes_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] informacion = (string[])e.Argument;
            RutaGuardarDocumento = informacion[2];
            string formato = informacion[3];
            string rutaFtp = informacion[1];
            int idDocumento = Convert.ToInt32(informacion[0]);
            FormatoArchivo formatoDocumento;
            BkgDescargarDocumentosVariantes.ReportProgress(20, "Procesando documento");

            switch (formato)
            {
                case "plano":
                    formatoDocumento = FormatoArchivo.Pdf;
                    break;
                case "solido":
                    formatoDocumento = FormatoArchivo.Step;
                    break;
                default:
                    formatoDocumento = FormatoArchivo.Pdf;
                    break;
            }

            BkgDescargarDocumentosVariantes.ReportProgress(60, "Procesando documento");
            Datos = ServidorFtp.DescargarArchivo(Convert.ToInt32(idDocumento), formatoDocumento, rutaFtp);

            if (Datos != null)
            {
                e.Result = true;
                BkgDescargarDocumentosVariantes.ReportProgress(100, "Procesando documento");
            }
            else
            {
                e.Result = false;
                BkgDescargarDocumentosVariantes.ReportProgress(100, "Error al descargar documento");
            } 
        }

        private void BkgDescargarDocumentosVariantes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgDescargarDocumentosVariantes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                string nombrePlano = "variante_" + TvCotizacion.SelectedNode.Name.Split('-')[1].ToString().PadLeft(4, '0');
                File.WriteAllBytes(RutaGuardarDocumento, Datos);

                if (TvCotizacion.SelectedNode.Name.Split('-')[0] == "plano")
                {
                    FrmVisorPDF visor = new FrmVisorPDF(Datos, nombrePlano);
                    visor.WindowState = FormWindowState.Maximized;
                    MostrarContenido(visor);
                }

                LblEstatus.Text = "Documento descargado";
            }
            else
            {
                OcultarContenido();
                LblEstatus.Text = "Documento descargado";
            }

            RutaGuardarDocumento = string.Empty;
            Progreso.Value = 0;
            Progreso.Visible = false;
            TvCotizacion.Enabled = true;
        }

        private void BkgRemoverDocumento_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] informacion = (string[])e.Argument;
            FormatoArchivo formato;
            switch (informacion[1])
            {
                case "plano":
                    formato = FormatoArchivo.Pdf;
                    break;
                case "solido":
                    formato = FormatoArchivo.Step;
                    break;
                default:
                    formato = FormatoArchivo.Pdf;
                    break;
            }
            BkgRemoverDocumento.ReportProgress(60, "Removiendo documento ...");
            e.Result = ServidorFtp.RemoverArchivo(Convert.ToInt32(informacion[0]), formato, informacion[2]);
            BkgRemoverDocumento.ReportProgress(100, "Removiendo documento ...");
        }

        private void BkgRemoverDocumento_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgRemoverDocumento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] nombreDividido = TvCotizacion.SelectedNode.Name.Split('-');
            switch (TvCotizacion.SelectedNode.Parent.Parent.Parent.Text)
            {
                case "SUBENSAMBLES":
                    ProductoSubensambleVariante varianteSubensamble = new ProductoSubensambleVariante();
                    varianteSubensamble.CargarDatos(Convert.ToInt32(nombreDividido[1]));
                    if (varianteSubensamble.TieneFilas())
                    {
                        if (nombreDividido[0] == "plano")
                        {
                            varianteSubensamble.Fila().ModificarCelda("plano_en_ftp", 0);
                            varianteSubensamble.Fila().ModificarCelda("fecha_plano_subido", null);
                            varianteSubensamble.Fila().ModificarCelda("usuario_creacion_plano", 0);
                            varianteSubensamble.GuardarDatos();
                        }
                        else
                        {
                            varianteSubensamble.Fila().ModificarCelda("solido_en_ftp", 0);
                            varianteSubensamble.Fila().ModificarCelda("fecha_solido_subido", null);
                            varianteSubensamble.Fila().ModificarCelda("usuario_creacion_solido", 0);
                            varianteSubensamble.GuardarDatos();
                        }
                    }
                    break;
                default:
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(Convert.ToInt32(nombreDividido[1]));
                    if (variante.TieneFilas())
                    {
                        if (nombreDividido[0] == "plano")
                        {
                            variante.Fila().ModificarCelda("plano_en_ftp", 0);
                            variante.Fila().ModificarCelda("fecha_plano_subido", null);
                            variante.Fila().ModificarCelda("usuario_creacion_plano", 0);
                            variante.GuardarDatos();
                        }
                        else
                        {
                            variante.Fila().ModificarCelda("solido_en_ftp", 0);
                            variante.Fila().ModificarCelda("fecha_solido_subido", null);
                            variante.Fila().ModificarCelda("usuario_creacion_solido", 0);
                            variante.GuardarDatos();
                        }
                    }
                    break;
            }

            OcultarContenido();
            LblEstatus.Text = "Documento removido";

            Progreso.Value = 0;
            Progreso.Visible = false;
            TvCotizacion.Enabled = true;
            RefrescarNodo(TvCotizacion.SelectedNode.Parent);
        }

        #endregion
    }
}
