using CB_Base.Classes;
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
using System.Runtime.InteropServices;

namespace CB
{
    public partial class FrmCatalogoMaterial2 : Form
    {
        string CatalogoUri = @"./SGC/CATALOGOMATERIAL/";
        byte[] ImagenByte;
        bool PuedeCambiarImagen = false;
        bool ImagenEncontrada = false;
        TreeNode NodoPadreActual = null;
        TreeNode PortaPapeles = null;
        List<string> FiltroTipos = new List<string>()
            {
                "MATERIA PRIMA COMUN",
                "MATERIA PRIMA ESPECIAL",
                "M.R.O.",
                "SERVICIOS",
                "SIN DETERMINAR"
            };

        Dictionary<TabPage, TreeView> diccionarioTreeViews = new Dictionary<TabPage, TreeView>();

        public FrmCatalogoMaterial2()
        {
            InitializeComponent();
        }

        private void FrmCatalogoMaterial2_Load(object sender, EventArgs e)
        {

            CmbValidado.SelectedIndex = 0;
            CargarTipos();
        } 

        public void CargarTipos()
        {
            TvMaterial.Nodes.Clear();

            ComprasTipos catalogo = new ComprasTipos();
            catalogo.SeleccionarTiposMaterial(FiltroTipos, CmbValidado.Text).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                        "tipo-" + f.Celda<int>("id"),
                        f.Celda<string>("nombre"),
                        0,
                        MenuTipo
                        );
                Global.AgregarConteoMaterialNodo(nodoTemporal, f.Celda<int>("total"));

                TvMaterial.Nodes.Add(
                    nodoTemporal
                    );
            });
        }

        private void CargarCategoriasParaTipo(TreeNode nodoPadre, int idTipo)
        {
            nodoPadre.Nodes.Clear();

            CategoriaMaterial categoriaMaterial = new CategoriaMaterial();
            categoriaMaterial.SeleccionarCategoriasMaterial(idTipo, CmbValidado.Text).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                            "categoria-" + f.Celda<int>("id").ToString(),
                            f.Celda("categoria").ToString(),
                            0,
                            MenuCategoria
                        );
                Global.AgregarConteoMaterialNodo(nodoTemporal, f.Celda<int>("total"));

                nodoPadre.Nodes.Add(nodoTemporal);
            });

            nodoPadre.Expand();
        }

        private void CargarSubcategoriasParaCategoria(TreeNode nodoPadre, int idCategoria)
        {
            nodoPadre.Nodes.Clear();

            CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
            subcategoria.SeleccionarSubCategoriasDeCategoria(idCategoria, CmbValidado.Text).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                            "subcategoria-" + f.Celda<int>("id").ToString(),
                            f.Celda("nombre").ToString(),
                            0,
                            MenuSubcategoria
                        );
                Global.AgregarConteoMaterialNodo(nodoTemporal, f.Celda<int>("total"));

                nodoPadre.Nodes.Add(nodoTemporal);
            });

            nodoPadre.Expand();
        }
        
        public void CargarFabricantes(int idTipo, int idCategoria, int idSubcategoria, TreeNode nodoPadre, bool borrarContenidoDeFabricantes = true)
        {
            TvMaterial.Enabled = false;
            // if(borrarContenidoDeFabricantes)
            nodoPadre.Nodes.Clear();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
             parametros.Add("@idTipo", idTipo);
            parametros.Add("@idCategoria", idCategoria);
            parametros.Add("@idSubcategoria", idSubcategoria);

            List<Fila> fabricantes = CatalogoMaterial.Modelo().SeleccionarFabricantesDeMaterialDeTipoDeCategoriaDeSubcategoria(idTipo, idCategoria, idSubcategoria, CmbValidado.Text);

            fabricantes.ForEach(delegate(Fila fab)
            {
                TreeNode nodoTemp = Global.CrearNodo(
                        "fabricante-" + fab.Celda("fabricante").ToString().TrimEnd(),
                        fab.Celda("fabricante").ToString()
                    );

                Global.AgregarConteoMaterialNodo(nodoTemp, fab.Celda<int>("total"));
                nodoPadre.Nodes.Add(nodoTemp);
            });
            nodoPadre.ExpandAll();
            TvMaterial.Enabled = true;
        }

        public void CargarNumerosDeParte(int idTipo, int idCategoria, int idSubcategoria, string fabricante, int idMaterial, TreeNode nodoPadre, System.Predicate<TreeNode> criterioParaImprimir)
        {
            TvMaterial.Enabled = false;
            nodoPadre.Nodes.Clear();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idCategoria", idCategoria);
            parametros.Add("@idSubcategoria", idSubcategoria);
            parametros.Add("@fabricante", fabricante);

            List<Fila> numerosDeParte = CatalogoMaterial.Modelo().SeleccionarMaterialDeTipoDeCategoriaDeSubcategoriaDeFabricante(idTipo, idCategoria, idSubcategoria, fabricante, CmbValidado.Text);

            numerosDeParte.ForEach(delegate(Fila pn)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                    "material-" + pn.Celda("id").ToString(),
                    pn.Celda("numero_parte").ToString(),
                    2,
                    MenuOpcionesMaterial
                    );
                nodoPadre.Nodes.Add(nodoTemporal);

                if(criterioParaImprimir != null && criterioParaImprimir(nodoTemporal))
                {
                    if(!BkgCargarInformacion.IsBusy)
                    {
                        TvMaterial.SelectedNode = nodoTemporal; 
                        MostrarDetallesMaterial(idMaterial);
                    }
                }
            });
            nodoPadre.ExpandAll();
            TvMaterial.Enabled = true;
        }

        void LimpiarDetallesMaterial()
        {
            SoloLectura(false);

            LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";

            TxtNumeroParte.Text = "";
            TxtFabricante.Text = "";
            CmbUnidades.Text = "POR PIEZA";
            NumPiezasPaquete.Value = 1;
            LblEtiquetaPiezasPorPaquete.Visible = false;
            NumPiezasPaquete.Visible = false;
            ImagenMaterial.Image = CB_Base.Properties.Resources.manu_prod;

            TxtEnlace.Text = "";
            TxtDescripcion.Text = "";
            BtnElegirImagen.Enabled = false;
            PnlMinMax.Visible = false;

            TxtAudiselParte.Text = "";

            NodoPadreActual = null;
        }

        private void TvMaterial_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TvMaterial.SelectedNode = e.Node;
                string nombreNodo = e.Node.Name.Split('-')[0];

                if (nombreNodo != "material")
                    LimpiarDetallesMaterial();
            }
        }

        private void TvMaterial_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNodeCollection raiz = null;

            if (e.Node.Name.StartsWith("portada"))
                raiz = TvMaterial.Nodes;
            else if (e.Node.Name.StartsWith("categoria") || e.Node.Name.StartsWith("subcategoria") || e.Node.Name.StartsWith("fabricante"))
                raiz = e.Node.Parent.Nodes;

            if (raiz != null)
            {
                /* foreach (TreeNode nodo in raiz)
                {
                    if (nodo.Name != e.Node.Name)
                        nodo.Collapse();
                } */
            }
        }

        private void RefrescarNombresNodos(TreeNode nodoPartida)
        {
            switch (nodoPartida.Name.Split('-')[0])
            {
                case "tipo":
                    ComprasTipos tiposCompras = new ComprasTipos();
                    tiposCompras.SeleccionarTiposMaterial(FiltroTipos, CmbValidado.Text, Convert.ToInt32(nodoPartida.Name.Split(new char[] {'-'} , 2)[1]));

                    nodoPartida.Text = tiposCompras.Fila().Celda("nombre").ToString();
                    Global.AgregarConteoMaterialNodo(nodoPartida, tiposCompras.Fila().Celda<int>("total"));

                    break;
                case "categoria":
                    CategoriaMaterial categoriaMaterial = new CategoriaMaterial();
                    categoriaMaterial.SeleccionarCategoriasMaterial(
                        Convert.ToInt32(nodoPartida.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                        CmbValidado.Text,
                        Convert.ToInt32(nodoPartida.Name.Split(new char[] {'-'} , 2)[1])
                        );


                    nodoPartida.Text = categoriaMaterial.Fila().Celda("categoria").ToString();
                    Global.AgregarConteoMaterialNodo(nodoPartida, categoriaMaterial.Fila().Celda<int>("total"));

                    break;
                case "subcategoria":
                    CategoriaSubMaterial subcategoriaMaterial = new CategoriaSubMaterial();
                    subcategoriaMaterial.SeleccionarSubCategoriasDeCategoria(
                        Convert.ToInt32(nodoPartida.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                        CmbValidado.Text,
                        Convert.ToInt32(nodoPartida.Name.Split(new char[] {'-'} , 2)[1])
                        );

                    nodoPartida.Text = subcategoriaMaterial.Fila().Celda("nombre").ToString();
                    Global.AgregarConteoMaterialNodo(nodoPartida, subcategoriaMaterial.Fila().Celda<int>("total"));

                    break;

                case "fabricante":
                    break;
            }
            if (nodoPartida.Parent == null)
            {
                return;
            }

            RefrescarNombresNodos(nodoPartida.Parent);
        }

        private void RefrescarNodo(TreeNode nodoPadre)
        {
            switch (nodoPadre.Name.Split('-')[0])
            {
                case "tipo":
                    CargarCategoriasParaTipo(nodoPadre, Convert.ToInt32(nodoPadre.Name.Split(new char[] {'-'} , 2)[1]));
                    break;
                case "categoria":
                    CargarSubcategoriasParaCategoria(
                        nodoPadre,
                        Convert.ToInt32(nodoPadre.Name.Split(new char[] {'-'} , 2)[1])
                        );
                    break;
                case "subcategoria":
                    CargarFabricantes(
                        Convert.ToInt32(nodoPadre.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                        Convert.ToInt32(nodoPadre.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                        Convert.ToInt32(nodoPadre.Name.Split(new char[] {'-'} , 2)[1]),
                        nodoPadre
                        );
                    break;

                case "fabricante":
                    string coleccion = nodoPadre.Name.Split(new char[] { '-' }, 2)[1];

                    CargarNumerosDeParte(
                        Convert.ToInt32(nodoPadre.Parent.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                        Convert.ToInt32(nodoPadre.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                        Convert.ToInt32(nodoPadre.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                        nodoPadre.Name.Split(new char[] {'-'} , 2)[1],
                        0,
                        nodoPadre,
                        null
                        );
                    break;
                case "material":
                    int idmaterial = Convert.ToInt32(nodoPadre.Name.Split(new char[] {'-'} , 2)[1]);
                    if (!BkgCargarInformacion.IsBusy)
                        MostrarDetallesMaterial(idmaterial);
                    break;
            }
            RefrescarNombresNodos(nodoPadre);
        }

        private void TvMaterial_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodo(e.Node);
        }

        void MostrarDetallesMaterial(int id)
        {
            ImagenEncontrada = false;
            ImagenByte = null;
            BtnSalir.Enabled = false;
            BtnBuscar.Enabled = true;
            BarraProgresoAsignaciones.Visible = true;
            TvMaterial.Enabled = false;
            SoloLectura(false);      
            LimpiarDetallesMaterial();
            BkgCargarInformacion.RunWorkerAsync(id.ToString());

            if (TvMaterial.SelectedNode.Parent != null)
            { 
                NodoPadreActual = TvMaterial.SelectedNode.Parent;
            }
            TvMaterial.Focus();
        }

        private void TvMaterial_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name.Split('-')[0])
            {
                case "fabricante":
                    e.Node.Nodes.Clear();
                    break;
            }
            if (e.Node.Parent != null)
                LblRuta.Text = "\\" + e.Node.Parent.FullPath;
            else
                LblRuta.Text = "\\";
        }

        private void TvMaterial_AfterExpand(object sender, TreeViewEventArgs e)
        {
            LblRuta.Text = "\\" + e.Node.FullPath;
        }

        #region Drag&Drop
        
        private void TvMaterial_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if(!(e.Item is TreeNode))
            {
                return;
            }
            
            TreeNode nodoSeleccionado = e.Item as TreeNode;

            // Evita arrastrar nodos de materiales o procesos de fabricación
            if (nodoSeleccionado.Name.Contains("subcategoria") &&
                (nodoSeleccionado.Parent.Text.Contains("PROCESOS DE FABRICACION") || nodoSeleccionado.Parent.Text.Contains("MATERIAL PARA FABRICACION")))
            {
                return;
            }

            if (nodoSeleccionado.Text.Contains("PROCESOS DE FABRICACION") || nodoSeleccionado.Text.Contains("MATERIAL PARA FABRICACION"))
            {
                return;
            }

            if (nodoSeleccionado.Name.Contains("material") &&
                (nodoSeleccionado.Parent.Parent.Parent.Text.Contains("PROCESOS DE FABRICACION") || nodoSeleccionado.Parent.Parent.Parent.Text.Contains("MATERIAL PARA FABRICACION")))
            {
                return;
            }

            if (nodoSeleccionado.Name.Contains("fabricante") &&
                (nodoSeleccionado.Parent.Parent.Text.Contains("PROCESOS DE FABRICACION") || nodoSeleccionado.Parent.Parent.Text.Contains("MATERIAL PARA FABRICACION")))
            {
                return;
            }


            // Initiate drag/drop
            // Arrastrar en cualquier sección si el rol es de Compras
            if(Global.VerificarPrivilegio("COMPRAS", "VALIDAR CATALOGO"))
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
            else if(CmbValidado.Text != "VALIDADO")
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }


        private void TvMaterial_DragEnter(object sender, DragEventArgs e)
        {
            // Set the visual effect
            e.Effect = DragDropEffects.Move;
        }

        private void TvMaterial_DragDrop(object sender, DragEventArgs e)
        {
            // e contains the data of the dragged items. See if has a

            // node data structure in it.

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {

                // node exists in drag data payload
                Point pt = this.TvMaterial.PointToClient(new Point(e.X, e.Y));

                // Get a handle to the destination node. This will become
                // the parent of our new node.

                TreeNode nodoDestino = this.TvMaterial.GetNodeAt(pt);

                // Create the new node based on the dragged node
                TreeNode nodoSeleccionado = (TreeNode)
                e.Data.GetData("System.Windows.Forms.TreeNode");

                // No mover nodos de categorías ni subcategorías si no es Comprador
                if (!Global.VerificarPrivilegio("COMPRAS", "VALIDAR CATALOGO") && !(nodoSeleccionado.Name.StartsWith("material") && nodoSeleccionado.Name.StartsWith("fabricante")))
                {
                    MessageBox.Show("No tiene permisos para mover este nodo, por favor, intente con un material o fabricante.", "Nodo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check destination mode
                if (!(nodoDestino == nodoSeleccionado))
                {
                    TreeNode nodoPadreTemporal = nodoSeleccionado.Parent;

                    switch (nodoDestino.Name.Split('-')[0])
                    {
                        case "subcategoria":
                            switch (nodoSeleccionado.Name.Split('-')[0])
                            {
                                case "material":
                                    CambiarSubcategoriaAMaterial(nodoDestino, nodoSeleccionado);
                                    break;
                                case "fabricante":
                                    CambiarSubcategoriaAFabricanteDeSubcategoria(nodoDestino, nodoSeleccionado);
                                    break;
                                default:
                                    MessageBox.Show("No se puede arrastrar el nodo seleccionado a este nodo, por favor, intente de nuevo.", "Nodo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }

                            break;
                        case "fabricante":
                            if (nodoSeleccionado.Name.Split('-')[0] == "material")
                            {
                                CatalogoMaterial material = new CatalogoMaterial();
                                material.CargarDatos(Convert.ToInt32(nodoSeleccionado.Name.Split(new char[] { '-' }, 2)[1]));

                                material.Fila().ModificarCelda("subcategoria_ref", Convert.ToInt32(nodoDestino.Parent.Name.Split(new char[] { '-' }, 2)[1]));
                                material.GuardarDatos();
                                RefrescarNodoDragAndDrop(nodoSeleccionado.Parent, nodoDestino.Parent);
                            }
                            else
                                MessageBox.Show("No se puede arrastrar el nodo seleccionado a este nodo, por favor, intente de nuevo.", "Nodo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        case "categoria":
                            if (nodoSeleccionado.Name.Split('-')[0] == "subcategoria")
                            {
                                CambiarCategoriaASubcategoria(nodoDestino, nodoSeleccionado);
                            }
                            else
                                MessageBox.Show("No se puede arrastrar el nodo seleccionado a este nodo, por favor, intente de nuevo.", "Nodo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                        case "tipo":
                            if (nodoSeleccionado.Name.Split('-')[0] == "categoria")
                            {
                                CambiarTipoACategoria(nodoDestino, nodoSeleccionado);
                            }
                            else
                                MessageBox.Show("No se puede arrastrar el nodo seleccionado a este nodo, por favor, intente de nuevo.", "Nodo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            break;
                    }
                    RefrescarNombresNodos(nodoDestino);
                    RefrescarNombresNodos(nodoPadreTemporal);
                }
            }
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.  
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node,   
            // call the ContainsNode method recursively using the parent of   
            // the second node.  
            return ContainsNode(node1, node2.Parent);
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void TvMaterial_DragOver(object sender, DragEventArgs e)
        {
            // Set a constant to define the autoscroll region
            const Single scrollRegion = 20;

            // See where the cursor is
            Point pt = TvMaterial.PointToClient(Cursor.Position);

            // See if we need to scroll up or down
            if ((pt.Y + scrollRegion) > TvMaterial.Height)
            {
                // Call the API to scroll down
                SendMessage(TvMaterial.Handle, (int)277, (int)1, 0);
            }
            else if (pt.Y < (TvMaterial.Top + scrollRegion))
            {
                // Call thje API to scroll up
                SendMessage(TvMaterial.Handle, (int)277, (int)0, 0);
            }
        }

        #region Reacomodo

        private void CambiarSubcategoriaAMaterial(TreeNode DestinationNode, TreeNode newNode)
        {
            CatalogoMaterial material = new CatalogoMaterial();
            material.CargarDatos(Convert.ToInt32(newNode.Name.Split(new char[] {'-'} , 2)[1]));

            material.Fila().ModificarCelda("subcategoria_ref", Convert.ToInt32(DestinationNode.Name.Split(new char[] {'-'} , 2)[1]));
            material.GuardarDatos();
            RefrescarNodoDragAndDrop(newNode.Parent, DestinationNode);
        }

        private void CambiarCategoriaASubcategoria(TreeNode DestinationNode, TreeNode newNode)
        {
            CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
            subcategoria.CargarDatos(Convert.ToInt32(newNode.Name.Split(new char[] {'-'} , 2)[1]));

            subcategoria.MoverSubcategoria(Convert.ToInt32(newNode.Name.Split(new char[] {'-'} , 2)[1]), Convert.ToInt32(DestinationNode.Name.Split(new char[] {'-'} , 2)[1]), subcategoria.Fila().Celda("nombre").ToString());

            // subcategoria.Fila().ModificarCelda("categoria", Convert.ToInt32(DestinationNode.Name.Split(new char[] {'-'} , 2)[1]));
            //subcategoria.GuardarDatos();

            RefrescarNodoDragAndDrop(newNode.Parent, DestinationNode);
            TvMaterial.SelectedNode = DestinationNode;
        }

        private void CambiarTipoACategoria(TreeNode DestinationNode, TreeNode newNode)
        {
            CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.CargarDatos(Convert.ToInt32(newNode.Name.Split(new char[] {'-'} , 2)[1]));

            categoria.MoverCategoria(Convert.ToInt32(newNode.Name.Split(new char[] {'-'} , 2)[1]), Convert.ToInt32(DestinationNode.Name.Split(new char[] {'-'} , 2)[1]), categoria.Fila().Celda("categoria").ToString());
            //categoria.Fila().ModificarCelda("tipo_compra", Convert.ToInt32(DestinationNode.Name.Split(new char[] {'-'} , 2)[1]));
            //categoria.GuardarDatos();

            RefrescarNodoDragAndDrop(newNode.Parent, DestinationNode);
            TvMaterial.SelectedNode = DestinationNode;
        }

        private void CambiarSubcategoriaAFabricanteDeSubcategoria(TreeNode DestinationNode, TreeNode newNode)
        {
            CatalogoMaterial materiales = new CatalogoMaterial();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@subcategoria", newNode.Parent.Name.Split(new char[] {'-'} , 2)[1]);
            parametros.Add("@fabricante", newNode.Name.Split(new char[] {'-'} , 2)[1]);
            materiales.SeleccionarDatos("subcategoria_ref=@subcategoria and fabricante=@fabricante", parametros);

            materiales.Filas().ForEach(delegate(Fila materialAModificar)
            {
                materialAModificar.ModificarCelda("subcategoria_ref", Convert.ToInt32(DestinationNode.Name.Split(new char[] {'-'} , 2)[1]));
            });

            materiales.GuardarDatos();
            RefrescarNodoDragAndDrop(newNode, DestinationNode);
        }

        #endregion /Reacomodo
        
        #endregion Drag&Drop

        private void SubirImagen(byte[] bytesImagen, string archivoNombre = "")
        {
            FtpClient clienteFtp = new FtpClient();
            Global.CrearConexionFTP(clienteFtp);

            int idMaterial = Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]);

            if (clienteFtp.IsConnected)
            {
                if (bytesImagen != null)
                {
                    if (!clienteFtp.DirectoryExists(CatalogoUri))
                        clienteFtp.CreateDirectory(CatalogoUri);

                    clienteFtp.Upload(bytesImagen, CatalogoUri + idMaterial + ".PNG");

                    ImagenMaterial.Image = Global.ByteAImagen(bytesImagen);
                    CatalogoMaterial mat = new CatalogoMaterial();
                    mat.CargarDatos(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
                    if (mat.TieneFilas())
                    {
                        mat.Fila().ModificarCelda("imagen_servidor", 1);
                        mat.GuardarDatos();
                    }
                }
            }
        }

        private void BtnElegirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "Imagen (*.jpg, *.png, *.jpeg, *.bmp, *.gif)|*.jpg; *.png;*.jpeg; *.bmp; *.gif";

            if (archivo.ShowDialog() == DialogResult.OK)
            {
                SubirImagen(File.ReadAllBytes(archivo.FileName), archivo.FileName);
            }
        }

        private void registrarMaterial_Click(object sender, EventArgs e)
        {
            FrmRegistrarMaterial agregarMaterial = new FrmRegistrarMaterial
            (
                Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]),
                Convert.ToInt32(TvMaterial.SelectedNode.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                true
            );

            CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.CargarDatos(Convert.ToInt32(TvMaterial.SelectedNode.Parent.Name.Split(new char[] {'-'} , 2)[1]));

            CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
            subcategoria.CargarDatos(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));

            if (!categoria.TieneFilas() || !subcategoria.TieneFilas())
            {
                MessageBox.Show("El material no puede ser dado de alta, verifica la categoría y subcategoría", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            agregarMaterial.CategoriaSeleccionada = categoria.Fila().Celda("categoria").ToString();
            agregarMaterial.SubcategoriaSeleccionada = subcategoria.Fila().Celda("nombre").ToString();

            if(agregarMaterial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefrescarNodo(TvMaterial.SelectedNode);

                MessageBox.Show("El material fue registrado con éxito pero deberá ser validado por el departamento de compras antes de poder ser utilizado para generar una requisición.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbValidado.SelectedIndex = 1;
            }

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarMaterial(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
        }

        private void EditarMaterial(int materialId)
        {
            MostrarDetallesMaterial(materialId);
            SoloLectura(true);
        }

        void SoloLectura(bool modo)
        {
            TxtNumeroParte.ReadOnly = !modo;
            TxtFabricante.ReadOnly = !modo;
            TxtDescripcion.ReadOnly = !modo;
            TxtEnlace.ReadOnly = !modo;
            CmbUnidades.Enabled = modo;
            NumPiezasPaquete.Enabled = modo;
            BtnGuardar.Visible = modo;
            BtnGuardar.Enabled = modo;
            NumMinimo.Enabled = modo;
            NumMaximo.Enabled = modo;
            NumMinimo.ReadOnly = !modo;
            NumMaximo.ReadOnly = !modo;
            PuedeCambiarImagen = modo;
            BtnElegirImagen.Enabled = modo;
            ChkIva.Enabled = modo;
        }

        void GuardarInformacion()
        {
            CatalogoMaterial materialSeleccionado = new CatalogoMaterial();
            materialSeleccionado.CargarDatos(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
            if (!materialSeleccionado.TieneFilas())
                return;

            int aplicariva = 1;
            if(!ChkIva.Checked)
                aplicariva = 0;

            materialSeleccionado.Fila().ModificarCelda("numero_parte", TxtNumeroParte.Text.Trim());
            materialSeleccionado.Fila().ModificarCelda("fabricante", TxtFabricante.Text.Trim());
            materialSeleccionado.Fila().ModificarCelda("descripcion", TxtDescripcion.Text.Trim());
            materialSeleccionado.Fila().ModificarCelda("link", TxtEnlace.Text.Trim());
            materialSeleccionado.Fila().ModificarCelda("tipo_venta", CmbUnidades.Text.Trim());
            materialSeleccionado.Fila().ModificarCelda("piezas_paquete", NumPiezasPaquete.Value);
            materialSeleccionado.Fila().ModificarCelda("max", NumMaximo.Value);
            materialSeleccionado.Fila().ModificarCelda("min", NumMinimo.Value);
            materialSeleccionado.Fila().ModificarCelda("aplicar_iva", aplicariva);
            materialSeleccionado.GuardarDatos();
        }

        bool ValidarInformacion()
        {
            if (TxtNumeroParte.Text == "")
                return false;
            if (TxtFabricante.Text == "")
                return false;
            if (TxtDescripcion.Text == "")
                return false;
            if (NumPiezasPaquete.Value < 1)
                return false;
            if (CmbUnidades.Text == "")
                return false;
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarInformacion())
            {
                GuardarInformacion();
                SoloLectura(false);

                if(NodoPadreActual != null && NodoPadreActual.IsExpanded)
                {
                    string nodoNombre = NodoPadreActual.Name;
                    TreeNode nodoAbuelo = NodoPadreActual.Parent;

                    if (nodoAbuelo != null)
                        RefrescarNodo(NodoPadreActual.Parent);

                    if (nodoAbuelo.Nodes.Find(nodoNombre, false).Count() > 0)
                    {
                        RefrescarNodo(nodoAbuelo.Nodes.Find(nodoNombre, false)[0]);
                    }
                }
            }
        }

        private void nuevaCategoria_Click(object sender, EventArgs e)
        {
            FrmNuevaCategoria categoria = new FrmNuevaCategoria(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]), SystemEnums.TipoCategoria.Categoria);
            if (categoria.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarCategoriasParaTipo(TvMaterial.SelectedNode, Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
        }

        private void nuevaSubcategoria_Click(object sender, EventArgs e)
        {
            FrmNuevaCategoria categoria = new FrmNuevaCategoria(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]), SystemEnums.TipoCategoria.Subcategoria);
            if (categoria.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarSubcategoriasParaCategoria(TvMaterial.SelectedNode, Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas eliminar el material seleccionado?", "Eliminar material", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                TreeNode nodoSubcategoria = TvMaterial.SelectedNode.Parent.Parent;
                string nombrePadre = TvMaterial.SelectedNode.Parent.Name;

                CatalogoMaterial borrarMaterial = new CatalogoMaterial();
                borrarMaterial.CargarDatos(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
                borrarMaterial.BorrarDatos(borrarMaterial.Fila().Celda<int>("id"));
                borrarMaterial.GuardarDatos();

                CargarFabricantes
                    (
                    Convert.ToInt32(TvMaterial.SelectedNode.Parent.Parent.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                    Convert.ToInt32(TvMaterial.SelectedNode.Parent.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                    Convert.ToInt32(TvMaterial.SelectedNode.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                    TvMaterial.SelectedNode.Parent.Parent
                );

                if(nodoSubcategoria.Nodes.Find(nombrePadre, false).Length > 0)
                {
                    RefrescarNodo(nodoSubcategoria.Nodes.Find(nombrePadre, false)[0]);
                }
                LimpiarDetallesMaterial();
            }
        }

        private void eliminarCategoria_Click(object sender, EventArgs e)
        {
            
        }

        private void eliminarSubcategoria_Click(object sender, EventArgs e)
        {
            string strCategoria = "SIN DETERMINAR";

            CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.CargarDatos(0);
            if (categoria.TieneFilas())
                strCategoria = categoria.Fila().Celda("categoria").ToString();

            DialogResult result = MessageBox.Show("Los elementos que elimine estarán dentro de '" + strCategoria + "', tendrá que volver a clasificarlos, ¿está seguro de eliminar la subcategoría seleccionada?", "Eliminar subcategoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CategoriaSubMaterial.Modelo().EliminarSubCategoria(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
                CargarSubcategoriasParaCategoria(TvMaterial.SelectedNode.Parent, Convert.ToInt32(TvMaterial.SelectedNode.Parent.Name.Split(new char[] {'-'} , 2)[1]));
            }
        }

        private void verDetallesDeCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVerCotizacionesMaterial material = new FrmVerCotizacionesMaterial(TvMaterial.SelectedNode.Text);
            material.ShowDialog();
        }

        private void solidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int materialId = Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]);
            FrmSolidosMaterial solido = new FrmSolidosMaterial(materialId);
            solido.ShowDialog();
        }

        private void verEstadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstadisticasMaterial estadisticas = new FrmEstadisticasMaterial(TvMaterial.SelectedNode.Text);
            estadisticas.Show();
        }

        private void verAccesoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogoMaterial materialSeleccionado = new CatalogoMaterial();
            int id = Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]);

            FrmAccesoriosMaterial accesorios = new FrmAccesoriosMaterial(id);
            accesorios.ShowDialog();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnValesSalida_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (BtnBuscar.ContextMenuStrip != null)
                BtnBuscar.ContextMenuStrip.Show(BtnBuscar, BtnBuscar.PointToClient(Cursor.Position));
        }

        private void NumMaximo_ValueChanged(object sender, EventArgs e)
        {
            if(NumMinimo.Value > NumMaximo.Value)
            {
                NumMinimo.Value = NumMaximo.Value;
            }
        }

        private void NumMinimo_ValueChanged(object sender, EventArgs e)
        {
            if (NumMaximo.Value < NumMinimo.Value)
            {
                NumMaximo.Value = NumMinimo.Value;
            }
        }

        private void ImagenMaterial_Click(object sender, EventArgs e)
        {
            if(PuedeCambiarImagen && Clipboard.ContainsImage())
            {
                ImageConverter converter = new ImageConverter();
                SubirImagen( (byte[])converter.ConvertTo(Clipboard.GetImage(), typeof(byte[])) );
            }
        }

        private void editarCategoria_Click(object sender, EventArgs e)
        {
            FrmNuevaCategoria categoria = new FrmNuevaCategoria(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]), SystemEnums.TipoCategoria.Categoria, true);
            if (categoria.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarCategoriasParaTipo(TvMaterial.SelectedNode.Parent, Convert.ToInt32(TvMaterial.SelectedNode.Parent.Name.Split(new char[] {'-'} , 2)[1]));
        }

        private void editarSubcategoria_Click(object sender, EventArgs e)
        {
            FrmNuevaCategoria categoria = new FrmNuevaCategoria(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]), SystemEnums.TipoCategoria.Subcategoria, true);
            if (categoria.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarSubcategoriasParaCategoria(TvMaterial.SelectedNode.Parent, Convert.ToInt32(TvMaterial.SelectedNode.Parent.Name.Split(new char[] {'-'} , 2)[1]));
        }

        private void eliminarCategoria_Click_1(object sender, EventArgs e)
        {
            string strCategoria = "SIN DETERMINAR";
            string strSubcategoria = "SIN SUBCATEGORIA";

            CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.CargarDatos(0);
            if (categoria.TieneFilas())
                strCategoria = categoria.Fila().Celda("categoria").ToString();

            CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
            subcategoria.CargarDatos(0);
            if (subcategoria.TieneFilas())
                strSubcategoria = subcategoria.Fila().Celda("nombre").ToString();

            DialogResult result = MessageBox.Show("Los elementos que elimine estarán dentro de '" + strCategoria +"' y '" + strSubcategoria + "', tendrá que volver a clasificarlos, ¿está seguro de eliminar la categoría seleccionada?", "Eliminar categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CategoriaMaterial.Modelo().EliminarCategoria(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
                CargarSubcategoriasParaCategoria(TvMaterial.SelectedNode.Parent, Convert.ToInt32(TvMaterial.SelectedNode.Parent.Name.Split(new char[] {'-'} , 2)[1]));
            }
        }

        private void RefrescarNodoDragAndDrop(TreeNode nodoPadreOrigen, TreeNode nodoPadreDestino)
        {
            string[] nombreDivididoOrigen = nodoPadreOrigen.Name.ToString().Split('-');
            string[] nombreDivididoDestino= nodoPadreDestino.Name.ToString().Split('-');

            switch (nombreDivididoOrigen[0].ToString())
            {
                case "subcategoria":
                    //actualizar origen
                    CargarSubcategoriasParaCategoria(nodoPadreOrigen, Convert.ToInt32(nombreDivididoOrigen[1]));

                    //actualizar destino
                    CargarSubcategoriasParaCategoria(nodoPadreDestino, Convert.ToInt32(nombreDivididoDestino[1]));
                    break;
                case "categoria":
                    //actualizar origen
                    CargarSubcategoriasParaCategoria(nodoPadreOrigen, Convert.ToInt32(nombreDivididoOrigen[1]));

                    //actualizar destino
                    CargarCategoriasParaTipo(nodoPadreDestino, Convert.ToInt32(nombreDivididoDestino[1]));
                    CargarSubcategoriasParaCategoria(nodoPadreDestino, Convert.ToInt32(nombreDivididoDestino[1]));
                    break;
                case "tipo":
                    //actualizar origen
                    CargarCategoriasParaTipo(nodoPadreOrigen, Convert.ToInt32(nombreDivididoOrigen[1]));

                    //actualizar destino
                    CargarCategoriasParaTipo(nodoPadreDestino, Convert.ToInt32(nombreDivididoDestino[1]));
                    break;
                case "fabricante":
                    int idTipoOrigen= Convert.ToInt32(nodoPadreOrigen.Parent.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]);
                    int idCategoriaOrigen = Convert.ToInt32(nodoPadreOrigen.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]);
                    int idSubcategoriaOrigen = Convert.ToInt32(nodoPadreOrigen.Parent.Name.ToString().Split(new char[] {'-'} , 2)[1]);
                    //actualizar origen
                    CargarFabricantes(idTipoOrigen, idCategoriaOrigen, idSubcategoriaOrigen, nodoPadreOrigen.Parent);

                    //actualizar destino
                     int idTipoDestino = Convert.ToInt32(nodoPadreDestino.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]);
                    int idCategoriaDestino = Convert.ToInt32(nodoPadreDestino.Parent.Name.Split(new char[] {'-'} , 2)[1]);
                    int idSubcategoriaDestino = Convert.ToInt32(nombreDivididoDestino[1]);
                    CargarFabricantes(idTipoDestino, idCategoriaDestino, idSubcategoriaDestino, nodoPadreDestino);
                    break;
            }
        }

        private void BkgCargarInformacion_DoWork(object sender, DoWorkEventArgs e)
        {
            int id = Convert.ToInt32(e.Argument);

            BkgCargarInformacion.ReportProgress(10, "Descargando imagen, espere un momento...");
            CatalogoMaterial materialSeleccionado = new CatalogoMaterial();
            materialSeleccionado = new CatalogoMaterial();
            materialSeleccionado.CargarDatos(id);

            if (materialSeleccionado.Fila().Celda<int>("imagen_servidor") > 0)
            {
                FtpClient clienteFtp = new FtpClient();
                Global.CrearConexionFTP(clienteFtp);

                if (clienteFtp.IsConnected)
                {
                    BkgCargarInformacion.ReportProgress(60, "Descargando imagen, espere un momento...");
                    if (clienteFtp.FileExists(CatalogoUri + "/" + id + ".PNG"))
                    {
                        clienteFtp.Download(out ImagenByte, CatalogoUri + "/" + id + ".PNG");
                        ImagenEncontrada = true;
                    }
                    else
                    {
                        ImagenEncontrada = false;
                        ImagenByte = null;
                    }
                }
            }

            e.Result = materialSeleccionado.Fila();
            BkgCargarInformacion.ReportProgress(100, "Descargando imagen, espere un momento...");
        }

        private void BkgCargarInformacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fila materialSeleccionado = (Fila) e.Result;

            verAccesoriosToolStripMenuItem.Enabled = materialSeleccionado.Celda("tipo_venta").ToString() == "POR PIEZA";

            LblNumeroParte.Text = materialSeleccionado.Celda("numero_parte").ToString();
            TxtNumeroParte.Text = LblNumeroParte.Text;
            TxtFabricante.Text = materialSeleccionado.Celda("fabricante").ToString();
            CmbUnidades.Text = materialSeleccionado.Celda("tipo_venta").ToString();
            TxtEnlace.Text = materialSeleccionado.Celda("link").ToString();
            TxtDescripcion.Text = materialSeleccionado.Celda("descripcion").ToString();
            NumMinimo.Value = Convert.ToInt32(materialSeleccionado.Celda("min"));
            NumMaximo.Value = Convert.ToInt32(materialSeleccionado.Celda("max"));
            TxtAudiselParte.Text = Global.CrearNumeroParteAudisel(Convert.ToInt32(materialSeleccionado.Celda("id").ToString().PadLeft(6, '0')));
            ChkIva.Checked = (Convert.ToInt32(materialSeleccionado.Celda("aplicar_iva")) == 1);

            try
            {
                bool mostrarCantidades = new string[] { "1", "3" }.Contains(TvMaterial.SelectedNode.Parent.Parent.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]);
                PnlMinMax.Visible = mostrarCantidades;
            }
            catch
            {

            }
            if (CmbUnidades.Text == "POR PAQUETE")
            {
                NumPiezasPaquete.Value = Convert.ToInt32(materialSeleccionado.Celda("piezas_paquete"));
                LblEtiquetaPiezasPorPaquete.Visible = true;
                NumPiezasPaquete.Visible = true;
            }
            else
            {
                LblEtiquetaPiezasPorPaquete.Visible = false;
                NumPiezasPaquete.Visible = false;
            }

            if (ImagenEncontrada)
            {
                LblEstatusAsignaciones.Text = "Imagen descargada correctamente";
                ImagenMaterial.Image = Global.ByteAImagen(ImagenByte);

            }
            else
            {
                ImagenMaterial.Image = CB_Base.Properties.Resources.manu_prod;
                LblEstatusAsignaciones.Text = "El material no contiene una imagen";
            }
            
            BarraProgresoAsignaciones.Visible = false;
            BarraProgresoAsignaciones.Value = 0;
            TvMaterial.Enabled = true;
            BtnBuscar.Enabled = true;
            BtnSalir.Enabled = true;
            ImagenEncontrada = false;
            ImagenByte = null;

            TvMaterial.Focus();
        }

        private void BkgCargarInformacion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatusAsignaciones.Text = e.UserState.ToString();
            BarraProgresoAsignaciones.Value = e.ProgressPercentage;
        }

        private void CmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumPiezasPaquete.Visible = CmbUnidades.Text == "POR PAQUETE";
            NumPiezasPaquete.Enabled = CmbUnidades.Text == "POR PAQUETE";
        }

        private void seleccionarCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PortaPapeles = TvMaterial.SelectedNode;
        }

        private void MenuCategoria_Opening(object sender, CancelEventArgs e)
        {
            pegarSubcategoríaToolStripMenuItem.Enabled = (PortaPapeles != null && PortaPapeles.Name.StartsWith("subcategoria"));
        }

        private void MenuTipo_Opening(object sender, CancelEventArgs e)
        {
            pegarCategoríaToolStripMenuItem.Enabled = (PortaPapeles != null && PortaPapeles.Name.StartsWith("categoria"));
        }

        private void MenuSubcategoria_Opening(object sender, CancelEventArgs e)
        {
            pegarMaterialToolStripMenuItem.Enabled = (PortaPapeles != null && (PortaPapeles.Name.StartsWith("material") || PortaPapeles.Name.StartsWith("fabricante")));
        }

        private void pegarSubcategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarCategoriaASubcategoria(TvMaterial.SelectedNode, PortaPapeles);
            PortaPapeles = null;
        }

        private void pegarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarTipoACategoria(TvMaterial.SelectedNode, PortaPapeles);
            PortaPapeles = null;
        }

        private void pegarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((PortaPapeles.Name.StartsWith("material")))
                CambiarSubcategoriaAMaterial(TvMaterial.SelectedNode, PortaPapeles);
            else if (PortaPapeles.Name.StartsWith("fabricante"))
                CambiarSubcategoriaAFabricanteDeSubcategoria(TvMaterial.SelectedNode, PortaPapeles);

            PortaPapeles = null;
        }

        private void buscarNúmeroDeParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarMaterial buscarMaterial = new FrmBuscarMaterial();
            if (buscarMaterial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscarYDesplegarMaterial(buscarMaterial.EsParteInterna, buscarMaterial.MaterialABuscar);
            }
        }

        private void buscarDescripciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscadorMaterialDescripcion2 frmBuscar = new FrmBuscadorMaterialDescripcion2();
            if (frmBuscar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BuscarYDesplegarMaterial(true, frmBuscar.IdMaterial);                
            }
        }

        private void BuscarYDesplegarMaterial(bool esId, string terminoABuscar)
        {
            CatalogoMaterial catalogo = new CatalogoMaterial();

            if (!esId)
                catalogo.SeleccionarNumeroDeParte(terminoABuscar);
            else
                catalogo.CargarDatos(Convert.ToInt32(terminoABuscar));

            if (!catalogo.TieneFilas())
            {
                MessageBox.Show("El número de parte no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            { 
                if(catalogo.Fila().Celda("estatus_validacion").ToString() != CmbValidado.Text)
                {
                    for(int i = 0; i < CmbValidado.Items.Count; i++)
                    {
                        if (CmbValidado.Items[i].ToString() == catalogo.Fila().Celda("estatus_validacion").ToString())
                        {
                            CmbValidado.SelectedIndex = i;
                            break;
                        }
                    }
                    // MessageBox.Show("La pieza no se encuentra en este apartado. Revise el apartado de \"" + catalogo.Fila().Celda("estatus_validacion") + "\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // return;
                }
            }

            int subcategoriaId = catalogo.Fila().Celda<int>("subcategoria_ref");

            CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
            subcategoria.CargarDatos(subcategoriaId);
            int categoriaId = subcategoria.Fila().Celda<int>("categoria");

            CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.CargarDatos(categoriaId);

            int tipoId = categoria.Fila().Celda<int>("tipo_compra");

            string fabricante = catalogo.Fila().Celda("fabricante").ToString();

            CargarTipos();

            TreeNode nodoTipo = TvMaterial.Nodes.Find("tipo-" + tipoId.ToString(), false)[0];
            CargarCategoriasParaTipo(nodoTipo, tipoId);

            TreeNode nodoCategoria = nodoTipo.Nodes.Find("categoria-" + categoriaId.ToString(), false)[0];
            CargarSubcategoriasParaCategoria(nodoCategoria, categoriaId);

            TreeNode nodoSubcategoria = nodoCategoria.Nodes.Find("subcategoria-" + subcategoriaId.ToString(), false)[0];
            CargarFabricantes(tipoId, categoriaId, subcategoriaId, nodoSubcategoria);

           
            TreeNode nodoFabricante = nodoSubcategoria.Nodes.Find("fabricante-" + fabricante.ToString().TrimEnd(), false)[0];


            Predicate<TreeNode> criterio;

            if (esId)
                criterio = (nodo) =>
                {
                    return nodo.Name.Contains(terminoABuscar);
                };
            else
                criterio = (nodo) =>
                {
                    return nodo.Text.Contains(terminoABuscar);
                };
            CargarNumerosDeParte(tipoId, categoriaId, subcategoriaId, fabricante, catalogo.Fila().Celda<int>("id"), nodoFabricante, criterio);
        }

        private void CmbValidado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RefrescarNodosAbiertos(TvMaterial.Nodes);
            CargarTipos();
        }

        private void validarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea validar el material seleccionado?", "Validar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            CambiarValidacionMaterial(
                "VALIDADO",
                "Comentarios sobre validación",
                "Material de catálogo validado", 
                "Se ha validado el material " + TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1] + " por " + Global.UsuarioActual.NombreCompleto(),
                "El material fue validado con éxito. Se ha transferido el material a la sección \"VALIDADO\"."
                );
        }

        private void rechazarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea rechazar el material seleccionado?", "Rechazar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            CambiarValidacionMaterial(
                "RECHAZADO",
                "Comentarios sobre rechazo",
                "Material de catálogo rechazado", 
                "Se ha rechazado el número de parte " + TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1] + " por " + Global.UsuarioActual.NombreCompleto(),
                "El material seleccionado ha sido rechazado. Se ha transferido el material a la sección \"RECHAZADO\"."
                );
        }

        private void someterAEvaluaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea someter a validación el material seleccionado?", "Someter a validadción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            CambiarValidacionMaterial(
                "SIN VALIDAR", 
                "Comentarios para reevaluación", 
                "Reevaluación de material solicitada", 
                "Se ha solicitado una reevaluación para el número de parte " + TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1] + " por " + Global.UsuarioActual.NombreCompleto(),
                "El material seleccionado se ha sometido a reevaluación. Será notificado en caso de rechazarse o validarse el material.",
                "COMPRADOR");
        }

        private void CambiarValidacionMaterial(string estadoValidacion, string tituloFrmComentarios, string tituloNotificacion, string contenidoNotificacion, string contenidoFrmConfirmacion, string rolDestino = "")
        {
            FrmIngresarComentario comentario = new FrmIngresarComentario(tituloFrmComentarios, 300);

            if (comentario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CatalogoMaterial.Modelo().CambiarEstadoValidacion(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]), estadoValidacion, comentario.Comentarios);

                Evento.Modelo().Crear(tituloNotificacion, contenidoNotificacion, "COMPRADOR", rolDestino);
                MessageBox.Show(contenidoFrmConfirmacion, "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NodoPadreActual = TvMaterial.SelectedNode.Parent;

                if (NodoPadreActual != null && NodoPadreActual.IsExpanded)
                {
                    string nodoNombre = NodoPadreActual.Name;
                    TreeNode nodoAbuelo = NodoPadreActual.Parent;

                    if (nodoAbuelo != null)
                        RefrescarNodo(NodoPadreActual.Parent);

                    if (nodoAbuelo.Nodes.Find(nodoNombre, false).Count() > 0)
                    {
                        RefrescarNodo(nodoAbuelo.Nodes.Find(nodoNombre, false)[0]);
                    }
                }
            }
        }

        private void RefrescarNodosAbiertos(TreeNodeCollection coleccionNodos)
        { 
            foreach(TreeNode nodoActual in coleccionNodos)
            { 
                if(nodoActual.IsExpanded)
                {
                    if (nodoActual.Name.StartsWith("subcategoria"))
                    { 
                        RefrescarNodo(nodoActual);
                    }
                    else
                    {
                        RefrescarNodosAbiertos(nodoActual.Nodes);
                    }
                }
            }
        }

        private void MenuOpcionesMaterial_Opening(object sender, CancelEventArgs e)
        {
            bool categoriaSinValidar = CmbValidado.Text == "SIN VALIDAR" && Global.VerificarPrivilegio("COMPRAS", "VALIDAR CATALOGO");
            bool categoriaRechazada = CmbValidado.Text == "RECHAZADO";

            rechazarMaterialToolStripMenuItem.Visible = categoriaSinValidar;
            validarMaterialToolStripMenuItem.Visible = categoriaSinValidar;

            someterAEvaluaciónToolStripMenuItem.Visible = categoriaRechazada;

            toolStripSeparator1.Visible = categoriaSinValidar || categoriaRechazada;
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetallesMaterialCatalogo detalles = new FrmDetallesMaterialCatalogo(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));

            detalles.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
