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
    public partial class FrmSeleccionarMaterialFabricacion : Form
    {
        public int IdMaterial = 0;
        public int IdRequisicion = 0;
        int IdPlano = 0;

        MaterialMaquinado MaterialSeleccionado = new MaterialMaquinado();

        public FrmSeleccionarMaterialFabricacion(int idPlano)
        {
            InitializeComponent();
            IdPlano = idPlano;
        }

        private bool MedidasEstandarDefinidas {
            get {
                if(!MaterialSeleccionado.TieneFilas())
                {
                    return false;
                }
                else
                { 
                    return Global.ObjetoATexto(MaterialSeleccionado.Fila().Celda("medida_estandar"), "null") != "null";
                }
            }
        }

        private bool EsCilindro {
            get {
                return CmbPresentaciones.Text == "CILINDRO";
            }
        }

        private void FrmSeleccionarMaterialCatalogo2_Load(object sender, EventArgs e)
        {
            CargarCategorias();

            List<string> medidas = new List<string>()
            {   
                "",
                "1/16\"",
                "1/8\"",
                "1/4\"",
                "3/8\"",
                "1/2\"",
                "5/16\"",
                "5/8\"",
                "3/16\"",
                "3/4\"",
                "7/8\"",
                "\"",
                "mm",
                "m"
            };

            medidas.ForEach(delegate(string medida)
            {
                CmbTamLargo.Items.Add(medida);
                CmbTamEspesor.Items.Add(medida);
                CmbTamAncho.Items.Add(medida);
            });

            NumCantidad.Enabled = false;
        }

        public void CargarCategorias()
        {
            TvMaterial.Nodes.Clear();

            MaterialMaquinado materialMaquinado = new MaterialMaquinado();
            materialMaquinado.Categorias().ForEach(delegate(Fila categoria)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                        "categoria-" + categoria.Celda("categoria"),
                        categoria.Celda("categoria").ToString(),
                        0
                        );

                TvMaterial.Nodes.Add(
                    nodoTemporal
                    );
            });
        }

        private void CargarMaterialDeCategoria(TreeNode nodoPadre, string categoria)
        {
            nodoPadre.Nodes.Clear();

            MaterialMaquinado material = new MaterialMaquinado();
            material.MaterialDeCategoria(categoria).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemporal = Global.CrearNodo(
                            "material-" + f.Celda("id").ToString(),
                            f.Celda("nombre").ToString(),
                            2
                        );
                nodoPadre.Nodes.Add(nodoTemporal);
            });

            nodoPadre.Expand();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarMaterial buscarMaterial = new FrmBuscarMaterial();
            if (buscarMaterial.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MaterialMaquinado categoria = new MaterialMaquinado();
                categoria.SeleccionarNombre(buscarMaterial.MaterialABuscar);
                int categoriaId = categoria.Fila().Celda<int>("id");

                CargarCategorias();

                TreeNode nodoCategoria = TvMaterial.Nodes.Find("categoria-" + categoriaId.ToString(), false)[0];
                CargarMaterialDeCategoria(nodoCategoria, categoria.Fila().Celda<string>("nombre"));

                TreeNode nodoFabricante = nodoCategoria.Nodes.Find("material-" + buscarMaterial, false)[0];
                TvMaterial.Focus();
            }
        }

        void LimpiarDetallesMaterial()
        {
            SoloLectura(true);
            BtnSeleccionarMaterial.Enabled = false;

            LblNumeroParte.Text = "SELECCIONA UN NUMERO DE PARTE";

            TxtNumeroParte.Text = string.Empty;
            TxtFabricante.Text = string.Empty;
            TxtCategoriaMaterial.Text = string.Empty;
            CmbTamLargo.SelectedIndex = 0;
            CmbTamEspesor.SelectedIndex = 0;
            CmbTamAncho.SelectedIndex = 0;
            NumTamLargo.Value = 0;
            NumTamEspesor.Value = 0;
            NumTamAncho.Value = 0;
            ChkOversize.Checked = false;
            NumCantidad.Value = 1;
        }

        void MostrarDetallesMaterial(int id)
        {
            IdMaterial = id;

            MaterialSeleccionado = new MaterialMaquinado();
            MaterialSeleccionado.CargarDatos(id);

            if (!MaterialSeleccionado.TieneFilas())
            {
                MessageBox.Show("El material no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(IdPlano);
            if(plano.TieneFilas())
            {
                NumCantidad.Value = Convert.ToInt32(plano.Fila().Celda("cantidad"));
            }

            LblNumeroParte.Text = MaterialSeleccionado.Fila().Celda("nombre").ToString();
            TxtNumeroParte.Text = LblNumeroParte.Text;
            TxtCategoriaMaterial.Text = MaterialSeleccionado.Fila().Celda("categoria").ToString();
            

            CmbPresentaciones.Items.Clear();

            MaterialPresentacion.Modelo().SeleccionarDatos("").ForEach(delegate(Fila presentacion)
            {
                CmbPresentaciones.Items.Add(presentacion.Celda("nombre").ToString());
            });

            CmbPresentaciones.SelectedIndex = 0;
            TxtFabricante.Text = "LOCAL";
            SoloLectura(false);
            
            // Inhabilitar definición de medidas
            PanelPulgadas.Visible = !MedidasEstandarDefinidas;
            PanelMedidaEstandar.Visible = MedidasEstandarDefinidas;

            if(MedidasEstandarDefinidas)
            {
                LblMedidaEstandar.Text = MaterialSeleccionado.Fila().Celda("medida_estandar").ToString();
            }

            HabilitarSeleccionDeMaterial();

            TvMaterial.Focus();
        }
        
        private void TvMaterial_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                switch (e.Node.Name.Split('-')[0])
                {
                    case "categoria":
                        CargarMaterialDeCategoria(
                            e.Node,
                            e.Node.Name.Split('-')[1]
                            );
                        break;
                    case "material":
                        int idmaterial = Convert.ToInt32(e.Node.Name.Split('-')[1]);
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
                        MostrarDetallesMaterial(Convert.ToInt32(TvMaterial.SelectedNode.Name.Split('-')[1]));
                        break;
                }
            }
        }

        private void TvMaterial_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNodeCollection raiz = null;

            if (e.Node.Name.StartsWith("categoria"))
                raiz = TvMaterial.Nodes;
            else
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
            e.Node.Nodes.Clear();
        }

        private void BtnValesSalida_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSeleccionarMaterial_Click(object sender, EventArgs e)
        {
            string nombreMaterial = TxtNumeroParte.Text.TrimEnd().TrimStart() + ": ";

            // No se ha definido una medida estándar
            if(!MedidasEstandarDefinidas)
            {
                string espesor = string.Empty;
                string largo = string.Empty;
                string ancho = string.Empty;
                espesor = ((NumTamEspesor.Value == 0) ? "" : NumTamEspesor.Value.ToString());
                if (espesor != "")
                {
                    if (CmbTamEspesor.Text.Trim() != "" )
                    {
                        if (CmbTamEspesor.Text.Trim() != "\"" && CmbTamEspesor.Text.Trim() != "mm" && CmbTamEspesor.Text.Trim() != "m")
                            espesor += "-";
                        else if (CmbTamEspesor.Text.Trim() != "mm" && CmbTamEspesor.Text.Trim() != "m" && CmbTamEspesor.Text.Trim() != "\"")
                            espesor += "\"";
                    }
                }
                espesor += (CmbTamEspesor.Text.Trim());
            
                ancho = ((NumTamAncho.Value == 0) ? "" : NumTamAncho.Value.ToString());
                if (ancho != "")
                {
                    if (CmbTamAncho.Text.Trim() != "")
                    {
                        if (CmbTamAncho.Text.Trim() != "\"" && CmbTamAncho.Text.Trim() != "mm" && CmbTamAncho.Text.Trim() != "m")
                            ancho += "-";
                        else if (CmbTamAncho.Text.Trim() != "mm" && CmbTamAncho.Text.Trim() != "m" && CmbTamAncho.Text.Trim() != "\"")
                            ancho += "\"";
                    }                                              
                }
                ancho += (CmbTamAncho.Text.Trim());
            
                largo = ((NumTamLargo.Value == 0) ? "" : NumTamLargo.Value.ToString());
                if (largo != "")
                {
                    if (CmbTamLargo.Text.Trim() != "")
                    {
                        if (CmbTamLargo.Text.Trim() != "\"" && CmbTamLargo.Text.Trim() != "mm" && CmbTamLargo.Text.Trim() != "m")
                            largo += "-";
                        else if (CmbTamLargo.Text.Trim() != "mm" && CmbTamLargo.Text.Trim() != "m" && CmbTamLargo.Text.Trim() != "\"")
                            largo += "\"";
                    }                  
                }
                largo += (CmbTamLargo.Text.Trim());

                nombreMaterial += espesor;


                if(!EsCilindro)
                {
                    nombreMaterial += " X " + ancho;
                }

                nombreMaterial += " X " + largo;
            }
            else // Medidas estándar definidas
            {
                nombreMaterial += MaterialSeleccionado.Fila().Celda("medida_estandar").ToString();
            }

            nombreMaterial += ((ChkOversize.Checked) ? "_OVERSIZE" : "");

            string descripcion = CmbPresentaciones.Text + " " + nombreMaterial;
            if (txtComentarios.Text != "")
                descripcion += descripcion + System.Environment.NewLine + " " + txtComentarios.Text;

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(IdPlano);

            IdRequisicion = MaterialProyecto.Modelo().CrearRequisicionCompraFabricacion(plano, TvMaterial.SelectedNode.Parent.Name.Split('-')[1].ToString(), MaterialProyecto.TablaMaterialRequisicion.MaterialMaquinado, nombreMaterial, descripcion + " PLANO: #" + IdPlano, ChkCantidad.Checked, Convert.ToInt32(NumCantidad.Value));
            if(IdRequisicion > 0)
            {
                plano.Fila().ModificarCelda("estatus_material", "SOLICITADO");
                plano.GuardarDatos();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CmbTamLargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarSeleccionDeMaterial();
        }

        private void HabilitarSeleccionDeMaterial()
        {
            bool espesor = (((NumTamEspesor.Value == 0) ? "" : NumTamEspesor.Value.ToString()) + CmbTamEspesor.Text).Trim() != string.Empty;
            bool ancho = (((NumTamAncho.Value == 0) ? "" : NumTamAncho.Value.ToString()) + CmbTamAncho.Text).Trim() != string.Empty;
            bool largo = (((NumTamLargo.Value == 0) ? "" : NumTamLargo.Value.ToString()) + CmbTamLargo.Text).Trim() != string.Empty;

            BtnSeleccionarMaterial.Enabled = MedidasEstandarDefinidas || (espesor && largo && (EsCilindro || ancho));            
        }

        void SoloLectura(bool modo)
        {
            splitContainer1.Panel2.Enabled = !modo;
        }

        private void CmbPresentaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            PnlAncho.Visible = !EsCilindro;
            label10.Visible = !EsCilindro;

            if(EsCilindro)
            {
                LblEspesorRadio.Text = "Radio";
            }
            else
            {
                LblEspesorRadio.Text = "Espesor";
            }
        }

        private void ChkCantidad_CheckedChanged(object sender, EventArgs e)
        {
            NumCantidad.Enabled = (!ChkCantidad.Checked);
            if(ChkCantidad.Checked)
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(IdPlano);
                if (plano.TieneFilas())
                {
                    NumCantidad.Value = Convert.ToInt32(plano.Fila().Celda("cantidad"));
                }
            }
        }

        private void TxtNumeroParte_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
