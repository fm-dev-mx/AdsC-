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
    public partial class FrmConfigurarAccesoriosMaterial : Ventana
    {
        int idMaterial = 0;
        CatalogoMaterial Material = new CatalogoMaterial();
        int cantidadMaterialPrincipal = 0;
        public List<Fila> Accesorios = new List<Fila>();

        public FrmConfigurarAccesoriosMaterial(int idCatalogo, int cantidad)
        {
            InitializeComponent();
            this.idMaterial = idCatalogo;
            Material.CargarDatos(idCatalogo);
            cantidadMaterialPrincipal = cantidad;
        }

        public void CargarAccesorios()
        {
            DgvOpciones.Rows.Clear();

            AccesorioMaterial.Modelo().TiposAccesorios(idMaterial).ForEach(delegate(Fila f)
            {
                List<string> opcionesNumerosParte = new List<string>();
                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();

                opcionesNumerosParte.Add("NINGUNO");
                AccesorioMaterial.Modelo().SeleccionarMaterialTipo(idMaterial, f.Celda("tipo").ToString()).ForEach(delegate(Fila pnAccesorio){
                    opcionesNumerosParte.Add(pnAccesorio.Celda("accesorio_numero_parte").ToString());
                });

                combo.DataSource = opcionesNumerosParte;

                DgvOpciones.Rows.Add(f.Celda("tipo"), "", "?", 0, "?", 0, 0);
                DgvOpciones.Rows[DgvOpciones.RowCount-1].Cells[1] = combo;
            });
        }

        public void CargarDatosMaterialPrincipal()
        {
            if (!Material.TieneFilas())
                return;

            LblNumeroDeParte.Text = Material.Fila().Celda("numero_parte").ToString();
            LblFabricante.Text = Material.Fila().Celda("fabricante").ToString();
            LblDescripcion.Text = Material.Fila().Celda("descripcion").ToString();
            LblCantidad.Text = cantidadMaterialPrincipal.ToString() + " pieza(s)";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            int sinConfigurar = 0;
            Accesorios.Clear();

            foreach (DataGridViewRow row in DgvOpciones.Rows)
            {
                int id_accesorio = Convert.ToInt32(row.Cells["id_accesorio"].Value);
                int piezas_requeridas_accesorio = Convert.ToInt32(row.Cells["piezas_requeridas"].Value);

                if( id_accesorio == 0 )
                {
                    sinConfigurar++;
                }
                else
                {
                    Fila f = new Fila();
                    f.AgregarCelda("id_accesorio", id_accesorio);
                    f.AgregarCelda("piezas_requeridas_accesorio", piezas_requeridas_accesorio);
                    f.AgregarCelda("total", total);

                    Accesorios.Add(f);
                }
            }

            if( sinConfigurar > 0 )
            {
                DialogResult respuesta = MessageBox.Show("Hay " + sinConfigurar + " accesorios sin configurar, seguro que quieres continuar?", "Continuar sin configurar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (respuesta == System.Windows.Forms.DialogResult.No)
                    return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmConfigurarAccesoriosMaterial_Load(object sender, EventArgs e)
        {
            CargarDatosMaterialPrincipal();
            CargarAccesorios();
        }

        private void DgvOpciones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0 && DgvOpciones.Rows[e.RowIndex].Cells["numero_parte"] != null )
            {
                // identifica el tipo de accesorio y el numero de parte seleccionado en el combobox 
                string tipo = DgvOpciones.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
                string numeroDeParteSeleccionado = DgvOpciones.Rows[e.RowIndex].Cells["numero_parte"].Value.ToString();

                if( numeroDeParteSeleccionado == "NINGUNO" )
                {
                    DgvOpciones.Rows[e.RowIndex].Cells["descripcion"].Value = "?";
                    DgvOpciones.Rows[e.RowIndex].Cells["piezas_requeridas"].Value = 0;
                    DgvOpciones.Rows[e.RowIndex].Cells["total"].Value = "?";
                    DgvOpciones.Rows[e.RowIndex].Cells["id_accesorio"].Value = 0;
                    return;
                }
                
                // carga los datos del accesorio desde el catalogo de material
                CatalogoMaterial materialAccesorio = new CatalogoMaterial();
                materialAccesorio.SeleccionarNumeroDeParte(numeroDeParteSeleccionado);
                int idAccesorio = Convert.ToInt32(materialAccesorio.Fila().Celda("id"));
                int piezas_requeridas = 0;

                // carga los datos del accesorio para identificar las partes requeridas
                AccesorioMaterial acc = new AccesorioMaterial();

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@material", idMaterial);
                parametros.Add("@tipo", tipo);
                parametros.Add("@accesorio", idAccesorio);

                acc.SeleccionarDatos("material=@material AND tipo=@tipo AND accesorio=@accesorio", parametros);

                // Muestra los datos encontrados
                if (acc.TieneFilas())
                {
                    piezas_requeridas = Convert.ToInt32( acc.Fila().Celda("piezas_requeridas") );
                    DgvOpciones.Rows[e.RowIndex].Cells["piezas_requeridas"].Value = piezas_requeridas;
                }
                else
                    DgvOpciones.Rows[e.RowIndex].Cells["piezas_requeridas"].Value = 0;

                if (materialAccesorio.TieneFilas())
                {
                    DgvOpciones.Rows[e.RowIndex].Cells["descripcion"].Value = materialAccesorio.Fila().Celda("descripcion");

                    int piezas_paquete = Convert.ToInt32(materialAccesorio.Fila().Celda("piezas_paquete"));
                    string tipo_venta = materialAccesorio.Fila().Celda("tipo_venta").ToString();
                    int total = MaterialProyecto.Modelo().CalcularTotalOrdenar(piezas_requeridas*cantidadMaterialPrincipal, piezas_paquete, tipo_venta)["total"];

                    DgvOpciones.Rows[e.RowIndex].Cells["total"].Value = MaterialProyecto.Modelo().TextoTotalOrdenar(total, piezas_paquete, tipo_venta);
                    DgvOpciones.Rows[e.RowIndex].Cells["id_accesorio"].Value = idAccesorio;
                }
                else
                {
                    DgvOpciones.Rows[e.RowIndex].Cells["descripcion"].Value = "?";
                    DgvOpciones.Rows[e.RowIndex].Cells["total"].Value = "?";
                    DgvOpciones.Rows[e.RowIndex].Cells["id_accesorio"].Value = 0;
                    DgvOpciones.Rows[e.RowIndex].Cells["piezas_requeridas"].Value = 0;
                }
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
