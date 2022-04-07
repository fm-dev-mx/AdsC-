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
    public partial class FrmMovimientosAlmacen : Form
    {
        int Id = 0;
        MovimientoAlmacen Movimientos = new MovimientoAlmacen();
        public FrmMovimientosAlmacen()
        {
            InitializeComponent();
        }

        private void FrmMovimientosAlmacen_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            BtnCambiarEstatus.Enabled = false;
            CmbMovimientosAlmacen.Text = "PENDIENTE";
            listarContenido(CmbMovimientosAlmacen.Text);
        }

        public void listarContenido(string filtro)
        {
            switch (filtro)
            {
                case "PENDIENTE":
                    listarPendiente();
                    break;
                case "REALIZADO":
                    BtnCambiarEstatus.Enabled = false;
                    listarRealizado();
                    break;
            }
        }

        public void listarPendiente()
        {
            DgvMovimeintosAlmacen.Rows.Clear();
            MovimientoAlmacen.Modelo().MovimientosPendientes().ForEach(delegate(Fila pendiente)
            {
                DgvMovimeintosAlmacen.Rows.Add(pendiente.Celda("id"), pendiente.Celda("origen"), pendiente.Celda("destino"), pendiente.Celda("proyecto"), pendiente.Celda("estatus"), pendiente.Celda("comentarios"), pendiente.Celda("numero_parte"), pendiente.Celda("cantidad"), pendiente.Celda("usuario_creacion"), pendiente.Celda("usuario_movimiento"));
            });
        }

        public void listarRealizado()
        {
            DgvMovimeintosAlmacen.Rows.Clear();
            MovimientoAlmacen.Modelo().MovimientosRealizados().ForEach(delegate(Fila realizado)
            {
                DgvMovimeintosAlmacen.Rows.Add(realizado.Celda("id"), realizado.Celda("origen"), realizado.Celda("destino"), realizado.Celda("proyecto"), realizado.Celda("estatus"), realizado.Celda("comentarios"), realizado.Celda("numero_parte"), realizado.Celda("cantidad"), realizado.Celda("usuario_creacion"), realizado.Celda("usuario_movimiento"));
            });
        }

        private void CmbMovimientosAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarContenido(CmbMovimientosAlmacen.Text);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
           
        private void DgvMovimeintosAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvMovimeintosAlmacen.SelectedRows.Count <= 0)
                return;

            Id = Convert.ToInt32(DgvMovimeintosAlmacen.SelectedRows[0].Cells["ID"].Value);
            BtnCambiarEstatus.Enabled = true;
        }

        private void ActualizarMaterialStock()
        {
            string origen = DgvMovimeintosAlmacen.SelectedRows[0].Cells["ORIGEN"].Value.ToString();
            int cantidadMaterial = Convert.ToInt32(DgvMovimeintosAlmacen.SelectedRows[0].Cells["CANTIDAD"].Value);
            string numeroParte = DgvMovimeintosAlmacen.SelectedRows[0].Cells["NUMERO_PARTE"].Value.ToString();
            MaterialStock materialStock = new MaterialStock();
            
            if (origen == "PROYECTO")
            {
                List<Fila> datosCargados = materialStock.MaterialAltaStock(numeroParte);
                if (datosCargados.Count == 1)
                {
                    int cantidadActual = Convert.ToInt32(materialStock.Fila().Celda("cantidad_disponible"));
                    int nuevoTotal = cantidadActual + cantidadMaterial;

                    materialStock.Fila().ModificarCelda("cantidad_disponible", nuevoTotal);
                    materialStock.GuardarDatos();
                }

                else if (datosCargados.Count == 0)
                {
                    CatalogoMaterial catalogo = new CatalogoMaterial();
                    catalogo.SeleccionarNumeroDeParte(numeroParte);

                    string categoriaCatalogo = catalogo.Fila().Celda("categoria").ToString();
                    string numeroParteCatalogo = catalogo.Fila().Celda("numero_parte").ToString();
                    string fabricanteCatalogo = catalogo.Fila().Celda("fabricante").ToString();
                    string descripcionCatalogo = catalogo.Fila().Celda("descripcion").ToString();

                    Fila nuevaAlta = new Fila();

                    nuevaAlta.AgregarCelda("categoria", categoriaCatalogo);
                    nuevaAlta.AgregarCelda("numero_parte", numeroParteCatalogo);
                    nuevaAlta.AgregarCelda("fabricante", fabricanteCatalogo);
                    nuevaAlta.AgregarCelda("descripcion", descripcionCatalogo);
                    nuevaAlta.AgregarCelda("cantidad_disponible", cantidadMaterial);

                    MaterialStock.Modelo().Insertar(nuevaAlta);
                    materialStock.GuardarDatos();
                }
            }
        }

        private void BtnCambiarEstatus_Click(object sender, EventArgs e)
        {
            if (DgvMovimeintosAlmacen.SelectedRows.Count <= 0)
                return;

            Movimientos.CargarDatos(Id);
            if (CmbMovimientosAlmacen.Text == "PENDIENTE")
            {
                ActualizarMaterialStock();
                Movimientos.Fila().ModificarCelda("estatus", "REALIZADO");
                string usuario_movimiento = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");
                Movimientos.Fila().ModificarCelda("usuario_movimiento", usuario_movimiento);
                Movimientos.GuardarDatos();
            }
            
            listarContenido(CmbMovimientosAlmacen.Text);
        }
    }
}