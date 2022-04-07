using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;
using System.IO;

namespace CB
{
    public partial class FrmRegistroProducto : Form
    {
        string TextoNodoPadre = string.Empty;
        string RaizFtp = string.Empty;
        string RutaGuardarDocumento = string.Empty;
        byte[] Datos = null;
        Form Contenido = null;
        BindingSource clientesBinding = new BindingSource();
        BindingSource industriasBinding = new BindingSource();

        public FrmRegistroProducto()
        {
            InitializeComponent();
        }

        private void FrmRegistroProducto_Load(object sender, EventArgs e)
        {
            Cliente clientes = new Cliente();
            clientes.SeleccionarDatos("");

            foreach(Fila cliente in clientes.Filas())
            {
                clientesBinding.Add(new {
                    Text = cliente.Celda("nombre"),
                    Value = cliente.Celda<int>("id")
                });
            }

            CmbCliente.DisplayMember = "Text";
            CmbCliente.ValueMember = "Value";
            CmbCliente.DataSource = clientesBinding;

            CmbCliente.SelectedIndex = 0;
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            industriasBinding.Clear();

            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@cliente", CmbCliente.SelectedValue);

            Cliente industriasCliente = new Cliente();
            industriasCliente.IndustriasDeCliente(Convert.ToInt32(CmbCliente.SelectedValue));
            
            foreach(Fila industria in industriasCliente.Filas())
            {
                industriasBinding.Add(new {
                    Text = industria.Celda("nombre").ToString(),
                    Value = industria.Celda<int>("id")
                });
            }
            CmbIndustria.DisplayMember = "Text";
            CmbIndustria.ValueMember = "Value";
            CmbIndustria.DataSource = industriasBinding;

            if(CmbIndustria.Items.Count > 0)
                CmbIndustria.SelectedIndex = 0;

            CargarInformacionProductos();
        }

        private void CmbIndustria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarInformacionProductos();
        }

        public void CargarInformacionProductos()
        {
            TvProductos.Nodes.Clear();
            if(CmbIndustria.Text == "")
            {
                return;
            }

            TreeNode raizProducto = Global.CrearNodo("raiz-productos", "PRODUCTOS", 0);
            TvProductos.Nodes.Add(
                raizProducto
                );

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@cliente", CmbCliente.SelectedValue);
            parametros.Add("@industria", CmbIndustria.SelectedValue);

            Producto productos = new Producto();
            productos.SeleccionarDatos("cliente = @cliente and industria = @industria", parametros);

            foreach (Fila producto in productos.Filas())
            {
                TreeNode tempNodo = Global.CrearNodo(
                    "producto-" + producto.Celda("id").ToString(),
                    producto.Celda("nombre").ToString()
                    );

                tempNodo.Nodes.AddRange(new TreeNode[] {
                    Global.CrearNodo("productoOpcion-modelos", "MODELOS", 2),
                    Global.CrearNodo("productoOpcion-componentes", "COMPONENTES", 3),
                    Global.CrearNodo("productoOpcion-subensambles", "SUBENSAMBLES", 4)
                });

                tempNodo.Expand();
                raizProducto.Nodes.Add(tempNodo);

                raizProducto.Expand();
            }
        }

        public void RefrescarNodo(TreeNode nodoPadre)
        {
            try
            {
                string[] nombreDividido = nodoPadre.Name.ToString().Split('-');
                switch(nombreDividido[0])
                { 
                    case "productoOpcion":
                        switch(nombreDividido[1])
                        { 
                            case "modelos":
                                CargarModelosParaProducto(nodoPadre, Convert.ToInt32(nodoPadre.Parent.Name.Split('-')[1]));
                                break;
                            case "componentes":
                                CargarComponentesParaProducto(nodoPadre, Convert.ToInt32(nodoPadre.Parent.Name.Split('-')[1]));
                                break;
                            case "subensambles":
                                CargarSubensamblesParaProducto(nodoPadre, Convert.ToInt32(nodoPadre.Parent.Name.Split('-')[1]));
                                break;
                        }
                        break;
                    case "componente":
                        CargarVariantesParaComponente(nodoPadre, Convert.ToInt32(nombreDividido[1]));
                        break;
                    case "geometria":
                        CargarVariantesParaComponente(nodoPadre, Convert.ToInt32(nodoPadre.Parent.Name.Split('-')[1]), Convert.ToInt32(nombreDividido[1]));
                        break;
                    case "varianteSubensamble":
                    case "variante":
                        int idVariante = Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]);
                        CargarNodosDocumentos(nodoPadre, idVariante);
                        break;
                    case "plano":
                        if (Convert.ToInt32(nombreDividido[1]) > 0)
                        {
                            LblEstatus.Text = string.Empty;
                            LblEstatusResultado.BackColor = Color.Transparent;
                            LblEstatus.Visible = true;
                            TvProductos.Enabled = false;
                            string[] informacionPlano;

                            if(nodoPadre.Parent.Parent.Parent.Text == "SUBENSAMBLES")
                                informacionPlano = new string[] { "plano", nombreDividido[1], "SGC\\VARIANTES\\SUBENSAMBLES\\PLANOS\\" };
                            else
                                informacionPlano = new string[] { "plano", nombreDividido[1], "SGC\\VARIANTES\\COMPONENTES\\PLANOS\\" };

                            BkgMostrarContenido.RunWorkerAsync(informacionPlano);
                        }
                        else
                            OcultarContenido();
                        break;
                    case "solido":
                        if (Convert.ToInt32(nombreDividido[1]) > 0)
                        {
                            LblEstatus.Text = string.Empty;
                            LblEstatusResultado.BackColor = Color.Transparent;
                            LblEstatus.Visible = true;
                            TvProductos.Enabled = false;
                            string[] informacion = new string[] { "plano", nombreDividido[1], "SGC\\VARIANTES\\PLANOS\\" };
                            BkgMostrarContenido.RunWorkerAsync(informacion);
                        }
                        else
                            OcultarContenido();
                        break;
                    case "subensamble":
                        CargarVariantesParaSubensamble(nodoPadre, Convert.ToInt32(nodoPadre.Name.Split('-')[1]));
                        break;
                }
            }
            catch
            { }
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
                    7
                    );

                nodoPadre.Nodes.Add(nodoTemp);
            });

            nodoPadre.Expand();
        }

        private void CargarModelosParaProducto(TreeNode nodoPadre, int idProducto)
        {
            nodoPadre.Nodes.Clear();

            ProductoModelo modelos = new ProductoModelo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@producto", idProducto);
            modelos.SeleccionarDatos("producto = @producto", parametros);
            modelos.Filas().ForEach(delegate(Fila mod)
            {
                TreeNode nodoTemp = Global.CrearNodo(
                    "modelo-" + mod.Celda("id").ToString(),
                    mod.Celda("nombre").ToString(),
                    5
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
            subensambles.SeleccionarDatos("producto = @producto", parametros);
            subensambles.Filas().ForEach(delegate(Fila suben) {
                TreeNode nodoTemp = Global.CrearNodo("subensamble-" + suben.Celda("id").ToString(), Global.ObjetoATexto(suben.Celda("nombre").ToString(),"N/A"), 5);

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
            componentes.SeleccionarDatos("producto = @producto", parametros);
            componentes.Filas().ForEach(delegate(Fila comp) {
                TreeNode nodoTemp = Global.CrearNodo(
                    "componente-" + comp.Celda("id").ToString(),
                    comp.Celda("nombre").ToString(),
                    6
                    );

                nodoPadre.Nodes.Add(nodoTemp);
            });

            nodoPadre.Expand();
        }

        private void CargarVariantesParaComponente(TreeNode nodoPadre, int idComponente, int idGeometria = 0)
        {
            nodoPadre.Nodes.Clear();

            ProductoVariante variantes = new ProductoVariante();

            if(idGeometria == 0)
            { 
                variantes.SeleccionarGeometrias(idComponente);
                variantes.Filas().ForEach(delegate (Fila vari)
                {
                    TreeNode nodoTemp = Global.CrearNodo(
                        "geometria-" + vari.Celda("grupo_geometria").ToString(),
                        "GEOMETRIA " + vari.Celda("grupo_geometria").ToString()
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
                    7
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
            string varianteSolidoTexto =  "SOLIDO";
            int imagenIndicePlano = 5;
            int imagenIndiceSolido = 5;

            switch (nodoPadre.Parent.Parent.Text)
            {
                case "SUBENSAMBLES":
                    ProductoSubensambleVariante varianteSubensamble = new ProductoSubensambleVariante();
                    varianteSubensamble.CargarDatos(idVariante);

                    if (varianteSubensamble.TieneFilas())
                    {
                        if (Convert.ToInt32(varianteSubensamble.Fila().Celda("plano_en_ftp")) > 0)
                        {
                            variantePlanoNombre = "plano-"+ idVariante;
                            variantePlanoTexto = "PLANO";
                            imagenIndicePlano = 9;
                        }
                        if (Convert.ToInt32(varianteSubensamble.Fila().Celda("solido_en_ftp")) > 0)
                        {
                            varianteSolidoNombre = "solido-" + idVariante;
                            varianteSolidoTexto = "SOLIDO";
                            imagenIndiceSolido = 10;
                        }
                    }
                    break;
                default:
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(idVariante);

                    if(variante.TieneFilas())
                    {
                        if (Convert.ToInt32(variante.Fila().Celda("plano_en_ftp")) > 0)
                        {
                            variantePlanoNombre = "plano-"+ idVariante;
                            variantePlanoTexto = "PLANO";
                            imagenIndicePlano = 9;
                        }
                            if(Convert.ToInt32(variante.Fila().Celda("solido_en_ftp")) > 0)
                        {
                            varianteSolidoNombre = "solido-" + idVariante;
                            varianteSolidoTexto = "SOLIDO";
                            imagenIndiceSolido = 10;
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

        private void TvProductos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodo(e.Node);
        }

        private void TvProductos_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TvProductos.SelectedNode = e.Node;
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                string[] nombreDividido = e.Node.Name.Split('-');
                switch(nombreDividido[0])
                { 
                    case "productoOpcion":
                        switch(nombreDividido[1])
                        {
                            case "modelos":
                                MenuModelos.Show(TvProductos, e.Location);                                
                                break;
                            case "componentes":
                                MenuComponentes.Show(TvProductos, e.Location);
                                break;
                            case "subensambles":
                                MenuSubensamble.Show(TvProductos, e.Location);
                                break;
                        }
                        break;
                    case "raiz":
                    case "producto":
                        MenuProductos.Show(TvProductos, e.Location);
                        break;
                    case "modelo":
                        MenuModelos.Show(TvProductos, e.Location);
                        break;
                    case "variante":
                    case "componente":
                        MenuComponentes.Show(TvProductos, e.Location);
                        break;
                    case "subensamble":
                        MenuSubensamble.Show(TvProductos, e.Location);
                        break;
                    case "geometria":
                        MenuGeometria.Show(TvProductos, e.Location);
                        break;
                }
            }
        }

        private void MenuProductos_Opening(object sender, CancelEventArgs e)
        {
            bool sobreNodoProducto = TvProductos.SelectedNode.Name.Split('-')[0].StartsWith("producto");

            agregarNuevoProductoToolStripMenuItem.Visible = !sobreNodoProducto;
            eliminarProductoToolStripMenuItem.Visible = sobreNodoProducto;
        }

        private void MenuModelos_Opening(object sender, CancelEventArgs e)
        {
            bool sobreNodoModelo = TvProductos.SelectedNode.Name.Split('-')[0].StartsWith("modelo");

            agregarModeloToolStripMenuItem.Visible = !sobreNodoModelo;
            eliminarModeloToolStripMenuItem.Visible = sobreNodoModelo;
        }

        private void MenuComponentes_Opening(object sender, CancelEventArgs e)
        {
            bool sobreNodoRaizComponente = TvProductos.SelectedNode.Name.Split('-')[0].StartsWith("productoOpcion");
            bool sobreNodoComponente = TvProductos.SelectedNode.Name.Split('-')[0].StartsWith("componente");
            bool sobreNodoVariante = TvProductos.SelectedNode.Name.Split('-')[0].StartsWith("variante");

            agregarComponenteToolStripMenuItem.Visible = sobreNodoRaizComponente;
            eliminarComponenteToolStripMenuItem.Visible = sobreNodoComponente;
            agregarVarianteToolStripMenuItem.Visible = sobreNodoComponente;
            eliminarVarianteToolStripMenuItem.Visible = sobreNodoVariante;

            bool test = sobreNodoVariante && TvProductos.SelectedNode.Parent.Name.Contains("geometria");
            removerDeGrupoDeGeometriaToolStripMenuItem.Visible = test;
        }

        private void MenuSubensamble_Opening(object sender, CancelEventArgs e)
        {
            bool sobreNodoSubensamble = TvProductos.SelectedNode.Name.Split('-')[0].StartsWith("subensamble");

            agregarSubensambleToolStripMenuItem.Visible = !sobreNodoSubensamble;
            eliminarSubensambleToolStripMenuItem.Visible = sobreNodoSubensamble;
            agregarVarianteSubToolStripMenuItem.Visible = sobreNodoSubensamble;
        }

        private void agregarSubensambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarSubensamble sub = new FrmRegistrarSubensamble(Convert.ToInt32(TvProductos.SelectedNode.Parent.Name.Split('-')[1]), Convert.ToInt32(CmbCliente.SelectedValue), Convert.ToInt32(CmbIndustria.SelectedValue), 0);
            sub.ShowDialog();
            RefrescarNodo(TvProductos.SelectedNode);
        }

        private void agregarComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarProductoComponente componente = new FrmRegistrarProductoComponente(Convert.ToInt32(CmbCliente.SelectedValue), Convert.ToInt32(TvProductos.SelectedNode.Parent.Name.Split('-')[1]));
            componente.ShowDialog();
            RefrescarNodo(TvProductos.SelectedNode);
        }

        private void agregarModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*FrmRegistrarModeloProducto modelo = new FrmRegistrarModeloProducto(Convert.ToInt32(CmbCliente.SelectedValue), Convert.ToInt32(CmbIndustria.SelectedValue), Convert.ToInt32(TvProductos.SelectedNode.Parent.Name.Split('-')[1]));
            modelo.ShowDialog();
            RefrescarNodo(TvProductos.SelectedNode);*/
        }

        private void agregarNuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarNuevoProducto producto = new FrmRegistrarNuevoProducto(0, Convert.ToInt32(CmbCliente.SelectedValue), Convert.ToInt32(CmbIndustria.SelectedValue));
            producto.ShowDialog();
            CargarInformacionProductos();
        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea borrar el producto " + TvProductos.SelectedNode.Text + "?", "Borrar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idProducto = Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]);
                ProductoModelo modelos = new ProductoModelo();
                List<string> informacion = new List<string>();
                modelos.SeleccionarModelosDeProducto(idProducto,0).ForEach(delegate(Fila f)
                {                 
                    informacion.Add(f.Celda("id").ToString());
                });

                Producto.Modelo().BorrarProducto(Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]), informacion);
                CargarInformacionProductos();

                TvProductos.Enabled = false;
                LblEstatus.Text = string.Empty;
                LblEstatusResultado.BackColor = Color.Transparent;
                LblEstatus.Visible = true;
                BkgEliminarVariantes.RunWorkerAsync(informacion.ToArray());
            }
        }

        private void eliminarModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea borrar el modelo " + TvProductos.SelectedNode.Text + "?", "Borrar modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idModelo = Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]);
                ProductoVariante variante = new ProductoVariante();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idModelo", idModelo);
                List<string> informacion = new List<string>();
                variante.SeleccionarDatos("modelo_variante=@idModelo", parametros).ForEach(delegate(Fila f)
                {
                    informacion.Add(f.Celda("id").ToString());
                });

                ProductoModelo.Modelo().BorrarModelo(Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]));
                TreeNode[] buscarNodo = TvProductos.SelectedNode.Nodes.Find("componentes", true);
                RefrescarNodo(TvProductos.SelectedNode.Parent);
                RefrescarNodo(TvProductos.SelectedNode.NextNode);

                TvProductos.Enabled = false;
                LblEstatus.Text = string.Empty;
                LblEstatusResultado.BackColor = Color.Transparent;
                LblEstatus.Visible = true;
                BkgEliminarVariantes.RunWorkerAsync(informacion.ToArray());
            }
        }

        private void eliminarComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("¿Seguro que desea borrar el componente " + TvProductos.SelectedNode.Text + "?", "Borrar componente", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 int idComponente = Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]);
                 ProductoVariante variante = new ProductoVariante();
                 Dictionary<string, object> parametros = new Dictionary<string, object>();
                 parametros.Add("@idComponente", idComponente);
                 List<string> informacion = new List<string>();
                 variante.SeleccionarDatos("componente=@idComponente", parametros).ForEach(delegate(Fila f)
                 {
                     informacion.Add(f.Celda("id").ToString());
                 });

                 ProductoSubensamble.Modelo().BorrarComponente(Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]));
                 
                 TreeNode nodo = TvProductos.SelectedNode.Parent.Parent.Nodes[2];
                 RefrescarNodo(TvProductos.SelectedNode.Parent);
                 RefrescarNodo(nodo);

                 TvProductos.Enabled = false;
                 LblEstatus.Text = string.Empty;
                 LblEstatusResultado.BackColor = Color.Transparent;
                 LblEstatus.Visible = true;
                 BkgEliminarVariantes.RunWorkerAsync(informacion.ToArray());
             }
        }

        private void eliminarSubensambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que desea borrar el subensamble " + TvProductos.SelectedNode.Text + "?", "Borrar subensamble", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idSubensamble = Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]);
                TextoNodoPadre = "SUBENSAMBLES";
                List<string> idVariante = new List<string>();
                ProductoSubensamble.Modelo().BorrarSubensamble(idSubensamble);
                ProductoSubensambleVariante variante = new ProductoSubensambleVariante();
                variante.SeleccionarVariantesSubensamble(idSubensamble).ForEach(delegate(Fila f)
                {
                    idVariante.Add(f.Celda("id").ToString());
                });
                
                BkgEliminarVariantes.RunWorkerAsync(idVariante.ToArray());
                //RefrescarNodo(TvProductos.SelectedNode.Parent);
            }
        }

        private void agregarVarianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarVariante nuevaVariante = new FrmRegistrarVariante(Convert.ToInt32(TvProductos.SelectedNode.Parent.Parent.Name.Split('-')[1]), Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]));
            if(nuevaVariante.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefrescarNodo(TvProductos.SelectedNode);
            }
        }

        private void TvProductos_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string[] nombreDividido = e.Node.Name.Split('-');
            switch(nombreDividido[0])
            {
                case "producto":
                    TvProductos.CollapseAll();
                    foreach(TreeNode nodoHijo in TvProductos.Nodes)
                    {
                        nodoHijo.Expand();
                    }
                    break;
            }
        }

        private void TvProductos_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            string[] nombreDividido = e.Node.Name.Split('-');
            switch (nombreDividido[0])
            {
                case "productoOpcion":
                case "modelo":
                case "variante":
                case "componente":
                case "subensamble":
                    e.Node.Nodes.Clear();
                    break;
            }
        }

        #region DragDrop

        private void TvProducto_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!(e.Item is TreeNode))
            {
                return;
            }

            TreeNode nodoSeleccionado = e.Item as TreeNode;

            if(!nodoSeleccionado.Name.StartsWith("variante"))
            {
                return;
            }

            DoDragDrop(e.Item, DragDropEffects.Move);

        }

        private void TvProducto_DragEnter(object sender, DragEventArgs e)
        {
            // Set the visual effect
            e.Effect = DragDropEffects.Move;
        }

        private void TvProducto_DragDrop(object sender, DragEventArgs e)
        {
            // e contains the data of the dragged items. See if has a

            // node data structure in it.

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", true))
            {

                // node exists in drag data payload
                Point pt = this.TvProductos.PointToClient(new Point(e.X, e.Y));

                // Get a handle to the destination node. This will become
                // the parent of our new node.

                TreeNode nodoDestino = this.TvProductos.GetNodeAt(pt);

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

        #endregion /DragDrop

        private void CambiarGeometria(TreeNode nodoSeleccionado, TreeNode nodoDestino)
        {
            int geometriaDestino = 0;
            ProductoVariante buscadorVariante = new ProductoVariante();
            
            if(nodoDestino.Name.StartsWith("variante"))
            {
                buscadorVariante.CargarDatos(Convert.ToInt32(nodoDestino.Name.Split('-')[1]));

                geometriaDestino = Convert.ToInt32(buscadorVariante.Fila().Celda("grupo_geometria"));

                // Agrupar en una nueva geometría en caso de no encontrarse en alguna
                if(geometriaDestino == 0)
                {
                    int idComponente = Convert.ToInt32(nodoDestino.Parent.Name.Split('-')[1]);
                
                    geometriaDestino = Convert.ToInt32(ProductoVariante.Modelo().SeleccionarUltimaGeometria(idComponente)[0].Celda("grupo_geometria")) + 1;
                    buscadorVariante.Fila().ModificarCelda("grupo_geometria", geometriaDestino);
                    buscadorVariante.GuardarDatos();
                }
            }

            if(nodoDestino.Name.StartsWith("geometria"))
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
                
                if(nodoComponente.Name.StartsWith("componente"))
                {
                    RefrescarNodo(nodoComponente);
                }

            } while (nodoComponente.Parent != null && nodoComponente.Name.StartsWith("componente"));

            RefrescarNodo(TvProductos.SelectedNode.Parent);
        }

        private void removerDeGrupoDeGeometriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoVariante buscadorVariante = new ProductoVariante();
            buscadorVariante.CargarDatos(Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]));

            buscadorVariante.Fila().ModificarCelda("grupo_geometria", 0);
            buscadorVariante.GuardarDatos();

            MessageBox.Show("Se ha eliminado esta variante de el grupo de geometría.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarNodo(TvProductos.SelectedNode.Parent.Parent);
        }

        private void eliminarGeometriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductoVariante buscadorVariante = new ProductoVariante();
            Dictionary<string, object> parametros = new Dictionary<string,object>();
            parametros.Add("@geometria", Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]));
            parametros.Add("@componente", Convert.ToInt32(TvProductos.SelectedNode.Parent.Name.Split('-')[1]));

            buscadorVariante.SeleccionarDatos("grupo_geometria = @geometria AND componente = @componente", parametros);

            buscadorVariante.Filas().ForEach(delegate(Fila variante) {
                variante.ModificarCelda("grupo_geometria", 0);
            });

            buscadorVariante.GuardarDatos();

            MessageBox.Show("Se ha eliminado el grupo de geometría. Se han transferido las variantes fuera de los demás grupos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefrescarNodo(TvProductos.SelectedNode.Parent);
        }

        private void eliminarVarianteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de borrar la variante seleccionada?", "Borrar variante", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                TvProductos.Enabled = false;
                LblEstatus.Text = string.Empty;
                LblEstatusResultado.BackColor = Color.Transparent;
                LblEstatus.Visible = true;
                int idVariante = Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]);
                BkgEliminarVariantes.RunWorkerAsync(idVariante.ToString());
            }
        }

        private void MenuVariantes_Opening(object sender, CancelEventArgs e)
        {
            string nombreSeleccionado = TvProductos.SelectedNode.Name.Split('-')[0];

            subirPlanoToolStripMenuItem.Visible = (nombreSeleccionado == "plano");
            descargarPlanoToolStripMenuItem.Visible = (nombreSeleccionado == "plano");
            subirSólidoToolStripMenuItem.Visible = (nombreSeleccionado == "solido");
            descargarSólidoToolStripMenuItem.Visible = (nombreSeleccionado == "solido");
        }

        private void InicializarBarrasEstadosDocumentos(string estatus)
        {
            Progress.Value = 0;
            LblEstatus.Text = estatus;
            LblEstatusResultado.BackColor = Color.Transparent;
            LblEstatus.Visible = true;
            LblEstatusResultado.Visible = true;
            Progress.Visible = true;
            TvProductos.Enabled = false;
        }

        private void FinalizarBarraEstado()
        {
            Progress.Visible = false;
            TvProductos.Enabled = true;
            Progress.Value = 0;
            Datos = null;
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
                InicializarBarrasEstadosDocumentos("Subiendo documento");
                Datos =  File.ReadAllBytes(OFDSubirArchivo.FileName);
                if(TvProductos.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\PLANOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\PLANOS\\";

                string[] informacion = new string[] { TvProductos.SelectedNode.Parent.Name.ToString().Split('-')[1], rutaFtp, "plano"};
                BkgSubirArchivo.RunWorkerAsync(informacion);
            }
        }

        private void descargarPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar documento";
            saveFileDialog1.FileName = "variante_" + TvProductos.SelectedNode.Parent.Name.Split('-')[1].ToString().PadLeft(4,'0') + ".PDF";
            if(saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InicializarBarrasEstadosDocumentos("Descargando documento");
                string rutaFtp = string.Empty;
                if (TvProductos.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\PLANOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\PLANOS\\";
                string[] informacion = new string[] {TvProductos.SelectedNode.Parent.Name.Split('-')[1], rutaFtp, saveFileDialog1.FileName, "plano"};

                BkgDescargarDocumento.RunWorkerAsync(informacion);
            }
        }

        private void subirSólidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OFDSubirArchivo.Filter = "archivos step|*.step";
            OFDSubirArchivo.DefaultExt = "step";
            OFDSubirArchivo.Title = "Seleccionar documento";
            OFDSubirArchivo.FileName = string.Empty;
            if (OFDSubirArchivo.ShowDialog() == DialogResult.OK)
            {
                InicializarBarrasEstadosDocumentos("Subiendo documento");
                string rutaFtp = string.Empty;
                if (TvProductos.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\SOLIDOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\SOLIDOS\\";
                Datos = File.ReadAllBytes(OFDSubirArchivo.FileName);
                string[] informacion = new string[] { TvProductos.SelectedNode.Parent.Name.ToString().Split('-')[1], rutaFtp, "solido" };
                BkgSubirArchivo.RunWorkerAsync(informacion);
            }
        }

        private void descargarSólidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar documento";
            saveFileDialog1.FileName = "variante_" + TvProductos.SelectedNode.Parent.Name.Split('-')[1].ToString().PadLeft(4, '0') + ".step";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InicializarBarrasEstadosDocumentos("Descargando documento");

                string rutaFtp = string.Empty;
                if (TvProductos.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                    rutaFtp = "SGC\\VARIANTES\\COMPONENTES\\SOLIDOS\\";
                else
                    rutaFtp = "SGC\\VARIANTES\\SUBENSAMBLES\\SOLIDOS\\";

                string[] informacion = new string[] { TvProductos.SelectedNode.Parent.Name.Split('-')[1], rutaFtp, saveFileDialog1.FileName, "solido" };
                BkgDescargarDocumento.RunWorkerAsync(informacion);
            }
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
            LblEstatus.Visible = false;
            LblEstatusResultado.Visible = false;
            LblEstatusResultado.BackColor = Color.Transparent;
        }

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
                        variante.CargarDatos(Convert.ToInt32(TvProductos.SelectedNode.Parent.Name.Split('-')[1]));
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
                        varianteSubensamble.CargarDatos(Convert.ToInt32(TvProductos.SelectedNode.Parent.Name.Split('-')[1]));
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

        private void BkgDescargarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] informacion = (string[])e.Argument;
            RutaGuardarDocumento = informacion[2];
            string formato = informacion[3];
            string rutaFtp = informacion[1];
            int idDocumento = Convert.ToInt32(informacion[0]);
            FormatoArchivo formatoDocumento;
            BkgDescargarDocumento.ReportProgress(20, "Procesando documento");

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

            BkgDescargarDocumento.ReportProgress(60, "Procesando documento");
            Datos = ServidorFtp.DescargarArchivo(Convert.ToInt32(idDocumento), formatoDocumento, rutaFtp);

            if (Datos != null)
            {
                e.Result = true;
                BkgDescargarDocumento.ReportProgress(100, "Procesando documento");
            }
            else
            {
                e.Result = false;
                BkgDescargarDocumento.ReportProgress(100, "Error al descargar documento");
            } 
        }

        private void BkgDescargarDocumento_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!BkgDescargarDocumento.IsBusy)
            {
                LblEstatus.Text = e.UserState.ToString();
                Progress.Value = e.ProgressPercentage;
            }
        }

        private void BkgDescargarDocumento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
            {
                string nombrePlano = "variante_" + TvProductos.SelectedNode.Name.Split('-')[1].ToString().PadLeft(4, '0');
                File.WriteAllBytes(RutaGuardarDocumento, Datos);

                if (TvProductos.SelectedNode.Name.Split('-')[0] == "plano")
                {
                    FrmVisorPDF visor = new FrmVisorPDF(Datos, nombrePlano);
                    visor.WindowState = FormWindowState.Maximized;
                    MostrarContenido(visor);
                }

                LblEstatus.Text = "Documento descargado";
                LblEstatusResultado.Text = " OK ";
                LblEstatusResultado.Visible = true;
                LblEstatusResultado.BackColor = Color.Lime;               
            }
            else
            {
                OcultarContenido();
                LblEstatus.Text = "Documento descargado";
                LblEstatusResultado.Text = " [ERROR] ";
                LblEstatusResultado.BackColor = Color.Coral;              
            }
           
            RutaGuardarDocumento = string.Empty;
            FinalizarBarraEstado();
        }

        private void BkgSubirArchivo_DoWork(object sender, DoWorkEventArgs e)
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

        private void BkgSubirArchivo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progress.Value = e.ProgressPercentage;
        }

        private void BkgSubirArchivo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string nombrePlano = "variante_" + TvProductos.SelectedNode.Parent.Name.Split('-')[1].ToString().PadLeft(4, '0');
            int idVariante = Convert.ToInt32(TvProductos.SelectedNode.Parent.Name.Split('-')[1]);
            if ((bool)e.Result)
            {
                if(TvProductos.SelectedNode.Parent.Parent.Parent.Text == "SUBENSAMBLES")
                {
                    ProductoSubensambleVariante variante = new ProductoSubensambleVariante();
                    variante.CargarDatos(idVariante);
                    ActualizarTablaVariante(nombrePlano, "SUBENSAMBLES", TvProductos.SelectedNode.Name.Split('-')[0].ToString(), idVariante);
                }
                else
                {
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(idVariante);
                    ActualizarTablaVariante(nombrePlano, "COMPONENTES", TvProductos.SelectedNode.Name.Split('-')[0].ToString(), idVariante);
                }
                
                LblEstatus.Visible = true;
                LblEstatus.Text = "Documento almacenado";
                LblEstatusResultado.Text = " OK ";
                LblEstatusResultado.Visible = true;
                LblEstatusResultado.BackColor = Color.Lime;               
            }
            else
            {
                OcultarContenido();
                LblEstatus.Text = "Documento almacenado";
                LblEstatusResultado.Text = " [ERROR] ";
                LblEstatusResultado.Visible = true;
                LblEstatusResultado.BackColor = Color.Coral;
            }

            FinalizarBarraEstado();
            TreeNode nodoPadre = TvProductos.SelectedNode.Parent;
            RefrescarNodo(nodoPadre);
            CargarNodosDocumentos(nodoPadre, idVariante);
        }

        private void BkgMostrarContenido_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] informacion = (string[])e.Argument;
            string formato = informacion[0];
            string rutaFtp = informacion[2];
            int idDocumento = Convert.ToInt32(informacion[1]);
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

            BkgMostrarContenido.ReportProgress(40, "Procesando documento");
            Datos = ServidorFtp.DescargarArchivo(idDocumento, formatoDocumento, rutaFtp);

            if (Datos != null)
            {
                e.Result = true;
                BkgMostrarContenido.ReportProgress(100, "Procesando documento");
            }
            else
            {
                e.Result = false;
                BkgMostrarContenido.ReportProgress(100, "Error al descargar documento");
            } 
        }

        private void BkgMostrarContenido_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatus.Text = e.UserState.ToString();
            Progress.Value = e.ProgressPercentage;
        }

        private void BkgMostrarContenido_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] nombreDividido = TvProductos.SelectedNode.Name.Split('-');
            //si descargo archivo
            if ((bool)e.Result)
            {
                //tipo de docimento plano
                if(nombreDividido[0].ToString() == "plano")
                {
                    string nombrePlano = "variante_" + TvProductos.SelectedNode.Name.Split('-')[1].ToString().PadLeft(4, '0');
                    FrmVisorPDF visor = new FrmVisorPDF(Datos, nombrePlano);
                    visor.WindowState = FormWindowState.Maximized;
                    MostrarContenido(visor);
                    LblEstatus.Text = "Documento procesado";
                    LblEstatusResultado.Text = " OK ";
                    LblEstatusResultado.Visible = true;
                    LblEstatusResultado.BackColor = Color.Lime;
                }
                else
                {
                    //tipo documento step
                    OcultarContenido();
                }
            }
            else
            {
                OcultarContenido();
                LblEstatus.Visible = true;
                LblEstatus.Text = "No se pudo mostrar el documento";
                LblEstatusResultado.Text = " [ERROR] ";
                LblEstatusResultado.Visible = true;
                LblEstatusResultado.BackColor = Color.Coral;               
            }

            FinalizarBarraEstado();
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]) <= 0)
                return;

            DialogResult result = MessageBox.Show("Si remueve el documento no podrá ser recuperado, ¿Está seguro que desea remover el documento seleccionado?", "Remover documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string formato = string.Empty;
                string rutaFtp = string.Empty;

                InicializarBarrasEstadosDocumentos("Removiendo documento...");

                if (TvProductos.SelectedNode.Parent.Name.ToString().StartsWith("variante-"))
                {
                    if(TvProductos.SelectedNode.Name.Split('-')[0] == "plano")
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
                    if(TvProductos.SelectedNode.Name.Split('-')[0] == "plano")
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
                
                string[] informacion = new string[] { TvProductos.SelectedNode.Name.Split('-')[1], formato, rutaFtp };
                BkgRemoverDocumento.RunWorkerAsync(informacion);
            }
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
            Progress.Value = e.ProgressPercentage;
        }

        private void BkgRemoverDocumento_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] nombreDividido = TvProductos.SelectedNode.Name.Split('-');
            switch (TvProductos.SelectedNode.Parent.Parent.Parent.Text)
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
            LblEstatus.Visible = true;
            LblEstatus.Text = "Documento removido";
            LblEstatusResultado.Text = " OK ";
            LblEstatusResultado.Visible = true;
            LblEstatusResultado.BackColor = Color.Lime;
            FinalizarBarraEstado();
            RefrescarNodo(TvProductos.SelectedNode.Parent);
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
            Progress.Value = e.ProgressPercentage;
        }

        private void BkgEliminarVariantes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OcultarContenido();            
            LblEstatus.Visible = true;
            LblEstatus.Text = "Documento removido";
            LblEstatusResultado.Text = " OK ";
            LblEstatusResultado.Visible = true;
            LblEstatusResultado.BackColor = Color.Lime;
            FinalizarBarraEstado();
            if (TvProductos.SelectedNode == null)
                return;

            if (TvProductos.SelectedNode.Name.ToString().StartsWith("variante"))
            {
                if (TextoNodoPadre == "SUBENSAMBLES")
                {
                    ProductoSubensambleVariante variante = new ProductoSubensambleVariante();
                    variante.SeleccionarVariantesSubensamble(Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1])).ForEach(delegate(Fila f)
                    {
                        ProductoSubensambleVariante borrarVariante = new ProductoSubensambleVariante();
                        borrarVariante.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        borrarVariante.BorrarDatos();
                        borrarVariante.GuardarDatos();
                    });
                }
                else
                {
                    int idVariante = Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]);
                    ProductoVariante variante = new ProductoVariante();
                    variante.CargarDatos(idVariante);
                    variante.BorrarDatos();
                    variante.GuardarDatos();
                }
            }
            TextoNodoPadre = string.Empty;
            RefrescarNodo(TvProductos.SelectedNode.Parent);
        }

        private void agregarVarianteSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarVarianteSubensamble nuevaVariante = new FrmRegistrarVarianteSubensamble(Convert.ToInt32(TvProductos.SelectedNode.Parent.Parent.Name.Split('-')[1]), Convert.ToInt32(TvProductos.SelectedNode.Name.Split('-')[1]));
            if (nuevaVariante.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefrescarNodo(TvProductos.SelectedNode);
            }
        }
    }
}
