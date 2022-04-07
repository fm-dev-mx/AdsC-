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
using System.Text.RegularExpressions;

namespace CB
{
    public partial class FrmSeleccionarMaterialCatalogo : Ventana
    {
        public int idMaterial = 0;
        public int CantidadMaterial = 0;
        public int Subensamble = 0;
        bool SeleccionarCantidad;
        bool SeleccionarSubensamble;
        double InicioCarga;

        CatalogoMaterial CargarDatosMaterial = new CatalogoMaterial();
        List<Fila> Material = new List<Fila>();
        List<Fila> MaterialEncontrado = new List<Fila>();

        public FrmSeleccionarMaterialCatalogo(bool seleccionarCantidad = true, bool seleccionarSubensamble = true)
        {
            InitializeComponent();
            SeleccionarCantidad = seleccionarCantidad;
            SeleccionarSubensamble = seleccionarSubensamble;
        }

        private void FrmSeleccionarMaterialCatalogo_Load(object sender, EventArgs e)
        {
            ProgresoDescarga.Visible = true;
            InicioCarga = Global.MillisegundosEpoch();
            BkgDescargarMaterial.RunWorkerAsync();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            MaterialEncontrado.Clear();
            DgvMaterial.Rows.Clear();
            BuscarEnLista(TxtFiltro.Text, Material);
        }

        public void BuscarEnLista(string busqueda, List<Fila> ListaMaterial)
        {
            InicioCarga = Global.MillisegundosEpoch();
            LblEstatus.Text = "Buscando material ...";
            int indice = 0;

            ListaMaterial.ForEach(delegate(Fila f)
            {
                string buscarEnListaMaterial = @"(^|\s)" + busqueda.ToUpper() + @"(\s|$)";
                string listaMaterialId = f.Celda("id").ToString();
                string listaMaterialCategoria = Global.ObjetoATexto(f.Celda("categoria"), "N/A");
                string listaMaterialSubcategoria = Global.ObjetoATexto(f.Celda("subcategoria"), "N/A");
                string listaMaterialNumeroParte = Global.ObjetoATexto(f.Celda("numero_parte"), "N/A");
                string listaMaterialFabricante = f.Celda("fabricante").ToString();
                string listaMaterialDescripcion = f.Celda("descripcion").ToString();

                if (listaMaterialId == busqueda || Regex.IsMatch(listaMaterialCategoria, buscarEnListaMaterial) ||
                    Regex.IsMatch(listaMaterialSubcategoria, buscarEnListaMaterial) || Regex.IsMatch(listaMaterialNumeroParte, busqueda.ToUpper()) ||
                    Regex.IsMatch(listaMaterialFabricante, busqueda.ToUpper()) || Regex.IsMatch(listaMaterialDescripcion, busqueda.ToUpper()))
                {
                    indice++;
                    DgvMaterial.Rows.Add(f.Celda("id").ToString(),
                        listaMaterialCategoria, listaMaterialSubcategoria,
                        f.Celda("numero_parte").ToString(),
                        f.Celda("fabricante").ToString(),
                        f.Celda("descripcion").ToString());
                }
            });

            if (busqueda != "")
                LblEstatus.Text = indice + " resultados encontrados para " + busqueda + " en " + ((Global.MillisegundosEpoch() - InicioCarga) / 1000.0).ToString("F2") + " segundos";
            else
                LblEstatus.Text = indice + " materiales encontrados en " + ((Global.MillisegundosEpoch() - InicioCarga) / 1000.0).ToString("F2") + " segundos";
        }

        private void DgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idMaterial = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells["ID"].Value.ToString());
            if(SeleccionarCantidad == true)
            {
                FrmCantidadMaterial altaMaterialAlmacen = new FrmCantidadMaterial(1);
                if (altaMaterialAlmacen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CantidadMaterial = altaMaterialAlmacen.Piezas;
                    DialogResult = System.Windows.Forms.DialogResult.OK;

                    if(SeleccionarSubensamble)
                    {
                        FrmIngresarSubEnsamble frmSubassy = new FrmIngresarSubEnsamble();
                        if(frmSubassy.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BkgDescargarMaterial_DoWork(object sender, DoWorkEventArgs e)
        {
            string query = "id LIKE @filtro OR categoria LIKE @filtro OR subcategoria LIKE @filtro OR numero_parte LIKE @filtro OR fabricante LIKE @filtro OR descripcion LIKE @filtro ORDER BY categoria ASC";
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@filtro", "%" + TxtFiltro.Text + "%");
            Material = CargarDatosMaterial.SeleccionarDatos(query, parametros, "*", BkgDescargarMaterial);
        }

        private void BkgDescargarMaterial_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDescarga.Value = e.ProgressPercentage;
            LblEstatus.Text = "Descargando lista de materiales... [" + e.ProgressPercentage + "%]";
            LblEstatus.Refresh();
        }

        private void BkgDescargarMaterial_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgresoDescarga.Visible = false;
            DgvMaterial.Enabled = false;
            LblEstatus.Text = "Mostrando lista de materiales, espere...";

            DgvMaterial.Rows.Clear();
            Material.ForEach(delegate(Fila material)
            {
                DgvMaterial.Rows.Add(material.Celda("id"), material.Celda("categoria"), material.Celda("subcategoria"), material.Celda("numero_parte"), material.Celda("fabricante"), material.Celda("descripcion"));
            });

            DgvMaterial.Enabled = true;
            LblEstatus.Text = Material.Count + " materiales encontrados en " + ((Global.MillisegundosEpoch() - InicioCarga) / 1000.0).ToString("F2") + " segundos";
        }

        private void DgvMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
