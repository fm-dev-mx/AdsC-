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

namespace CB
{
    public partial class FrmAgregarMaterial : Form
    {
        public decimal Proyecto = 0;

        public FrmAgregarMaterial(Decimal proyecto)
        {
            InitializeComponent();
            Proyecto = proyecto;
            LblTitulo.Text = "AGREGAR MATERIAL AL PROYECTO " + proyecto.ToString("F2");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAgregarMaterial_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FrmMaterialProyecto material = new FrmMaterialProyecto(Proyecto);
            //material.MdiParent = this.MdiParent;
            //material.Show();
        }

        void CargarMaterial(string filtro)
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvMaterial);
            DgvMaterial.Rows.Clear();

            CatalogoMaterial.Modelo().Buscar(TxtFiltro.Text).ForEach(delegate(Fila material)
            {
                DgvMaterial.Rows.Add(material.Celda("id"), material.Celda("categoria"), material.Celda("subcategoria"), material.Celda("numero_parte"), material.Celda("fabricante"), material.Celda("descripcion"));
            });

            Global.RecuperarFilaSeleccionada(DgvMaterial, filaSeleccionada);
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarMaterial(TxtFiltro.Text);
        }

        private void DgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if( DgvMaterial.SelectedRows.Count > 0 )
            {
                int id = Convert.ToInt32(DgvMaterial.SelectedRows[0].Cells[0].Value);

                FrmCantidadMaterial ingresarCantidad = new FrmCantidadMaterial(1);

                if( ingresarCantidad.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                {
                    CatalogoMaterial material = new CatalogoMaterial();
                    material.CargarDatos(id);

                    int piezasPaquete = Convert.ToInt32(material.Fila().Celda("piezas_paquete"));
                    string tipoVenta = material.Fila().Celda("tipo_venta").ToString();

                    int total = MaterialProyecto.Modelo().CalcularTotalOrdenar(ingresarCantidad.Piezas, piezasPaquete, tipoVenta)["total"];
                    int piezasStock = MaterialProyecto.Modelo().CalcularTotalOrdenar(ingresarCantidad.Piezas, piezasPaquete, tipoVenta)["piezas_stock"];

                    /*
                    if(  == "POR PAQUETE" )
                    {
                        decimal piezasEntrePaquete = (decimal)ingresarCantidad.Piezas / (decimal)piezasPaquete;
                        total = (int)Math.Ceiling(piezasEntrePaquete);
                        piezasStock = (total * piezasPaquete) - ingresarCantidad.Piezas;
                    }
                    else
                    {
                        total = ingresarCantidad.Piezas;
                    }*/

                    Fila matProyecto = new Fila();

                    string requisitor = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();

                    matProyecto.AgregarCelda("requisitor", requisitor);
                    matProyecto.AgregarCelda("proyecto", Proyecto.ToString("F2"));
                    matProyecto.AgregarCelda("categoria", material.Fila().Celda("categoria"));
                    matProyecto.AgregarCelda("numero_parte", material.Fila().Celda("numero_parte"));
                    matProyecto.AgregarCelda("fabricante", material.Fila().Celda("fabricante"));
                    matProyecto.AgregarCelda("descripcion", material.Fila().Celda("descripcion"));
                    matProyecto.AgregarCelda("piezas_requeridas", ingresarCantidad.Piezas);
                    matProyecto.AgregarCelda("piezas_stock", piezasStock);
                    matProyecto.AgregarCelda("total", total);
                    matProyecto.AgregarCelda("tipo_venta", material.Fila().Celda("tipo_venta"));
                    matProyecto.AgregarCelda("piezas_paquete", material.Fila().Celda("piezas_paquete"));
                    matProyecto.AgregarCelda("po", 0);
                    matProyecto.AgregarCelda("estatus_seleccion", "PRELIMINAR");
                    matProyecto.AgregarCelda("estatus_compra", "PENDIENTE");

                    MaterialProyecto.Modelo().Insertar(matProyecto);

                    this.Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void FrmAgregarMaterial_Load(object sender, EventArgs e)
        {
            CargarMaterial("");
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void DgvMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
