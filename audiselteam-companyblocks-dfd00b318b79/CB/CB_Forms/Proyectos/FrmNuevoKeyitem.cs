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
    public partial class FrmNuevoKeyitem : Ventana
    {
        int IdRequerimiento = 0;

        public FrmNuevoKeyitem(int idRequerimiento)
        {
            InitializeComponent();
            IdRequerimiento = idRequerimiento;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CmbTipo.Text)
            {
                case "COMPRADO":

                    List<string> filtro = new List<string>()
                    {
                        "MATERIA PRIMA ESPECIAL"
                    };
                    FrmSeleccionarMaterialCatalogo2 sm = new FrmSeleccionarMaterialCatalogo2(filtro);
                    //FrmSeleccionarMaterialCatalogo sm = new FrmSeleccionarMaterialCatalogo();

                    if (sm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        CatalogoMaterial mat = new CatalogoMaterial();
                        mat.CargarDatos(sm.IdMaterial);

                        if( mat.TieneFilas() )
                        {
                            TxtNumeroParte.Text = mat.Fila().Celda("numero_parte").ToString();
                            TxtFabricante.Text = mat.Fila().Celda("fabricante").ToString();
                            TxtDescripcion.Text = mat.Fila().Celda("descripcion").ToString();
                            NumPiezas.Value = sm.CantidadMaterial;

                            TxtDescripcion.ReadOnly = true;
                            NumPiezas.ReadOnly = true;
                            BtnRegistrar.Enabled = true;
                        }
                    }
                    else
                    {
                        CmbTipo.Text = "";
                        TxtNumeroParte.Text = "";
                        TxtFabricante.Text = "";
                        TxtDescripcion.Text = "";
                        NumPiezas.Value = 1;
                        BtnRegistrar.Enabled = false;
                    }
                break;


                case "FABRICADO":
                    TxtNumeroParte.Text = "N/A";
                    TxtFabricante.Text = "AUDISEL";
                    TxtDescripcion.Text = "";
                    TxtDescripcion.ReadOnly = false;
                    NumPiezas.ReadOnly = false;
                break;

            }
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = CmbTipo.Text != "" && TxtDescripcion.Text != "";
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Fila ki = new Fila();

            ki.AgregarCelda("requerimiento", IdRequerimiento);
            ki.AgregarCelda("tipo", CmbTipo.Text);
            ki.AgregarCelda("numero_parte", TxtNumeroParte.Text);
            ki.AgregarCelda("fabricante", TxtFabricante.Text);
            ki.AgregarCelda("descripcion", TxtDescripcion.Text);
            ki.AgregarCelda("piezas_requeridas", NumPiezas.Value);

            RequerimientoKeyitem.Modelo().Insertar(ki);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
