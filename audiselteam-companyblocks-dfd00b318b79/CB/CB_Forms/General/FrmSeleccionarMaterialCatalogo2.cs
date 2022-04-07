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
using CB_Base.Classes;

namespace CB
{
    public partial class FrmSeleccionarMaterialCatalogo2 : Form
    {
        public int IdMaterial = 0;
        public int CantidadMaterial = 0;
        public int Subensamble = 0;

        List<string> FiltrarTipo = new List<string>();
        decimal IdProyecto = 0;
        string CatalogoUri = @"./SGC/CATALOGOMATERIAL/";
        string EstadoValidado = "VALIDADO";
        bool SeleccionarCantidad;
        bool ImagenEncontrada = false;
        bool SeleccionarSubensamble;
        byte[] ImagenByte;

        CatalogoMaterial MaterialSeleccionado = new CatalogoMaterial();

        public FrmSeleccionarMaterialCatalogo2(List<string> filtrarTipo, bool seleccionarCantidad = true, bool seleccionarSubensamble = true, decimal idProyecto = 0 )
        {
            InitializeComponent();
            SeleccionarCantidad = seleccionarCantidad;
            SeleccionarSubensamble = seleccionarSubensamble;
            FiltrarTipo = filtrarTipo;
            IdProyecto = idProyecto;
        }

        private void FrmSeleccionarMaterialCatalogo2_Load(object sender, EventArgs e)
        {
            CargarTipos();
        }

        public void CargarTipos()
        {
            TvMaterial.Nodes.Clear();

            ComprasTipos catalogo = new ComprasTipos();
            catalogo.SeleccionarTiposMaterial(FiltrarTipo, EstadoValidado).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                        "tipo-" + f.Celda<int>("id"),
                        f.Celda<string>("nombre"),
                        0
                        );
                Global.AgregarConteoMaterialNodo(nodoTemporal, f.Celda<int>("total"));
                TvMaterial.Nodes.Add(
                    nodoTemporal
                    );
            });
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarMaterial buscarMaterial = new FrmBuscarMaterial();
            if (buscarMaterial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CatalogoMaterial catalogo = new CatalogoMaterial();

                if (!buscarMaterial.EsParteInterna)
                    catalogo.SeleccionarNumeroDeParte(buscarMaterial.MaterialABuscar);
                else
                    catalogo.CargarDatos(Convert.ToInt32(buscarMaterial.MaterialABuscar));

                if (!catalogo.TieneFilas())
                {
                    MessageBox.Show("El número de parte no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<Fila> subcategoriasTemp = CategoriaSubMaterial.Modelo().SeleccionarTipoDeSubcategoria(Convert.ToInt32(catalogo.Fila().Celda("subcategoria_ref")));

                    if (subcategoriasTemp.Count <= 0 || catalogo.Fila().Celda("estatus_validacion").ToString() != EstadoValidado || !FiltrarTipo.Contains(subcategoriasTemp[0].Celda("nombre").ToString()))
                    {
                        MessageBox.Show("El número de parte no ha sido validado o se encuentra definido como otro tipo de material.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
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

                TreeNode nodoFabricante = nodoSubcategoria.Nodes.Find("fabricante-" + fabricante.ToString(), false)[0];

                Predicate<TreeNode> criterio;

                if (buscarMaterial.EsParteInterna)
                    criterio = (nodo) =>
                    {
                        return nodo.Name.Contains(buscarMaterial.MaterialABuscar);
                    };
                else
                    criterio = (nodo) =>
                    {
                        return nodo.Text.Contains(buscarMaterial.MaterialABuscar);
                    };
                CargarNumerosDeParte(tipoId, categoriaId, subcategoriaId, fabricante, catalogo.Fila().Celda<int>("id"), nodoFabricante, criterio);

                TvMaterial.Focus();
            }
        }

        private void CargarCategoriasParaTipo(TreeNode nodoPadre, int idTipo)
        {
            nodoPadre.Nodes.Clear();

            CategoriaMaterial categoriaMaterial = new CategoriaMaterial();
            categoriaMaterial.SeleccionarCategoriasMaterial(idTipo, EstadoValidado).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                            "categoria-" + f.Celda<int>("id").ToString(),
                            f.Celda("categoria").ToString(),
                            0
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
            subcategoria.SeleccionarSubCategoriasDeCategoria(idCategoria, EstadoValidado).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                            "subcategoria-" + f.Celda<int>("id").ToString(),
                            f.Celda("nombre").ToString(),
                            0
                        );
                Global.AgregarConteoMaterialNodo(nodoTemporal, f.Celda<int>("total"));
                nodoPadre.Nodes.Add(nodoTemporal);
            });

            nodoPadre.Expand();
        }

        public void CargarFabricantes(int idTipo, int idCategoria, int idSubcategoria, TreeNode nodoPadre)
        {
            TvMaterial.Enabled = false;
            nodoPadre.Nodes.Clear();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idTipo", idTipo);
            parametros.Add("@idCategoria", idCategoria);
            parametros.Add("@idSubcategoria", idSubcategoria);

            List<Fila> fabricantes = CatalogoMaterial.Modelo().SeleccionarFabricantesDeMaterialDeTipoDeCategoriaDeSubcategoria(idTipo, idCategoria, idSubcategoria, EstadoValidado);

            fabricantes.ForEach(delegate(Fila fab)
            {
                TreeNode nodoTemp = Global.CrearNodo(
                        "fabricante-" + fab.Celda("fabricante").ToString(),
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

            List<Fila> numerosDeParte = CatalogoMaterial.Modelo().SeleccionarMaterialDeTipoDeCategoriaDeSubcategoriaDeFabricante(idTipo, idCategoria, idSubcategoria, fabricante, EstadoValidado);

            numerosDeParte.ForEach(delegate(Fila pn)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                    "material-" + pn.Celda("id").ToString(),
                    pn.Celda("numero_parte").ToString(),
                    2
                    );
                nodoPadre.Nodes.Add(nodoTemporal);

                if (criterioParaImprimir != null && criterioParaImprimir(nodoTemporal))
                {
                    if (!BkgCargarInformacion.IsBusy)
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
            BtnSeleccionarMaterial.Enabled = false;

            LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";

            TxtNumeroParte.Text = "";
            TxtFabricante.Text = "";
            TxtTipoVenta.Text = "POR PIEZA";
            ImagenMaterial.Image = CB_Base.Properties.Resources.manu_prod;

            TxtEnlace.Text = "";
            TxtDescripcion.Text = "";

            TxtParteAudisel.Text = "";
        }

        void MostrarDetallesMaterial(int id)
        {
            ImagenEncontrada = false;
            ImagenByte = null;
            BtnValesSalida.Enabled = false;
            BtnBuscar.Enabled = true;
            BarraProgresoAsignaciones.Visible = true;
            TvMaterial.Enabled = false;
            LimpiarDetallesMaterial();
            IdMaterial = id;
            BkgCargarInformacion.RunWorkerAsync(id.ToString());
            TvMaterial.Focus();

        }

        private void TvMaterial_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                switch (e.Node.Name.Split('-')[0])
                {
                    case "tipo":
                        CargarCategoriasParaTipo(e.Node, Convert.ToInt32(e.Node.Name.Split(new char[] {'-'} , 2)[1]));
                        break;
                    case "categoria":
                        CargarSubcategoriasParaCategoria(
                            e.Node,
                            Convert.ToInt32(e.Node.Name.Split(new char[] {'-'} , 2)[1])
                            );
                        break;
                    case "subcategoria":
                        CargarFabricantes(
                            Convert.ToInt32(e.Node.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                            Convert.ToInt32(e.Node.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                            Convert.ToInt32(e.Node.Name.Split(new char[] {'-'} , 2)[1]),
                            e.Node
                            );
                        break;

                    case "fabricante":
                        CargarNumerosDeParte(
                            Convert.ToInt32(e.Node.Parent.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                            Convert.ToInt32(e.Node.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                            Convert.ToInt32(e.Node.Parent.Name.Split(new char[] {'-'} , 2)[1]),
                            e.Node.Name.Split(new char[] {'-'} , 2)[1],
                            0,
                            e.Node,
                            null
                            );
                        break;
                    case "material":
                        int idmaterial = Convert.ToInt32(e.Node.Name.Split(new char[] {'-'} , 2)[1]);
                        if (!BkgCargarInformacion.IsBusy)
                            MostrarDetallesMaterial(idmaterial);
                        break;
                }
            }
        }

        private void TvMaterial_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TvMaterial.SelectedNode = e.Node;
            string nombreNodo = e.Node.Name.Split('-')[0];

            if (nombreNodo != "material")
            {
                LimpiarDetallesMaterial();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                switch (nombreNodo)
                {
                    case "material":
                        MostrarDetallesMaterial(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split(new char[] {'-'} , 2)[1]));
                        break;
                }
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
                foreach (TreeNode nodo in raiz)
                {
                    if (nodo.Name != e.Node.Name)
                        nodo.Collapse();
                }
            }
        }

        private void TvMaterial_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name.Split('-')[0])
            {
                case "fabricante":
                    e.Node.Nodes.Clear();
                    break;
            }
        }

        private void BtnValesSalida_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSeleccionarMaterial_Click(object sender, EventArgs e)
        {
            if (SeleccionarCantidad == true)
            {
                FrmCantidadMaterial altaMaterialAlmacen = new FrmCantidadMaterial(1);
                if (altaMaterialAlmacen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CantidadMaterial = altaMaterialAlmacen.Piezas;
                    DialogResult = System.Windows.Forms.DialogResult.OK;

                    if (SeleccionarSubensamble)
                    {
                        FrmIngresarSubensamble2 frmSubassy = new FrmIngresarSubensamble2(IdProyecto);
                        if (frmSubassy.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            Subensamble = frmSubassy.Subensamble;
                        else
                            DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    }
                }
                else
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            else
                DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void BkgCargarInformacion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblEstatusAsignaciones.Text = e.UserState.ToString();
            BarraProgresoAsignaciones.Value = e.ProgressPercentage;
        }

        private void BkgCargarInformacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Fila materialSeleccionado = (Fila)e.Result;

            LblNumeroParte.Text = materialSeleccionado.Celda("numero_parte").ToString();
            TxtNumeroParte.Text = LblNumeroParte.Text;
            TxtFabricante.Text = materialSeleccionado.Celda("fabricante").ToString();
            TxtEnlace.Text = materialSeleccionado.Celda("link").ToString();
            TxtDescripcion.Text = materialSeleccionado.Celda("descripcion").ToString();
            TxtTipoVenta.Text = materialSeleccionado.Celda("tipo_venta").ToString();
            TxtParteAudisel.Text = Global.CrearNumeroParteAudisel(Convert.ToInt32(materialSeleccionado.Celda("id").ToString().PadLeft(6, '0')));

            try
            {
                bool mostrarCantidades = new string[] { "1", "3" }.Contains(TvMaterial.SelectedNode.Parent.Parent.Parent.Parent.Name.Split(new char[] {'-'} , 2)[1]);
            }
            catch
            {

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
            BtnValesSalida.Enabled = true;
            ImagenEncontrada = false;
            ImagenByte = null;

            BtnSeleccionarMaterial.Enabled = true;

            TvMaterial.Focus();
        }
    }
}
