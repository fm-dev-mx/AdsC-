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
    public partial class FrmBuscarRequisicionMiscelaneos : Form
    {
        public FrmBuscarRequisicionMiscelaneos()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmBuscarRequisicionMiscelaneos_Load(object sender, EventArgs e)
        {
            BtnRevisionTecnica.Visible = false;
            CargarMaterial();
        }

        private void CargarMaterial()
        {
            DgvMaterial.Rows.Clear();
            if (NumIdReq.Value <= 0)
                return;

            MaterialProyecto material = new MaterialProyecto();
            material.CargarDatos(Convert.ToInt32(NumIdReq.Value));
            if (!material.TieneFilas())
            {
                MessageBox.Show("No se encontró la requisición");
                return;
            }

            material.Filas().ForEach(delegate (Fila f)
            {
                if (f.Celda("estatus_compra").ToString() == "EN REVISION TECNICA")
                    BtnRevisionTecnica.Visible = true;

                DgvMaterial.Rows.Add
                (
                    f.Celda("id"),
                    f.Celda("numero_parte"),
                    Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                    f.Celda("categoria"),
                    f.Celda("requisitor")
                );
            });
        }

        private void BtnRevisionFinanciera_Click(object sender, EventArgs e)
        {
            FrmRevisionTecnica revision = new FrmRevisionTecnica(Convert.ToInt32(NumIdReq.Value));
            if (revision.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(Convert.ToInt32(NumIdReq.Value));
                mat.Fila().ModificarCelda("estatus_autorizacion", revision.EstatusAutorizacion);
                mat.Fila().ModificarCelda("usuario_autorizacion", Global.UsuarioActual.NombreCompleto());
                mat.Fila().ModificarCelda("fecha_autorizacion", DateTime.Now);
                mat.Fila().ModificarCelda("comentarios_revision_tecnica", revision.Comentarios);
                mat.Fila().ModificarCelda("estatus_compra", revision.EstatusCompra);
                mat.GuardarDatos();

                //si el material pertenece a un proyecto agregar meta
                if (Convert.ToInt32(mat.Fila().Celda("proyecto")) > 0)
                {
                    //  ELIMINAR CODIGO SI NO PRESENTA FALLAS 01/07/2020
                    //    ProyectoProceso proyectoProceso = new ProyectoProceso();
                    //    proyectoProceso.SeleccionarMetaComprasExistente(Convert.ToDecimal(mat.Fila().Celda("proyecto")), 3);

                    //    if (proyectoProceso.TieneFilas())
                    //    {
                    //        DialogResult result = MessageBox.Show("¿Desea colocar una meta de compra?", "Crear una meta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    //        if (result == System.Windows.Forms.DialogResult.Yes)
                    //        {
                    //            if (Convert.ToDateTime(proyectoProceso.Fila().Celda("fecha_fin")).Date > DateTime.Now.Date)
                    //            {
                    //                //Si tiene meta borramos la meta para crear la meta actual
                    //                if (Convert.ToInt32(mat.Fila().Celda("meta")) > 0)
                    //                {
                    //                    mat.Fila().ModificarCelda("meta", 0);
                    //                    mat.Fila().ModificarCelda("fecha_promesa_compras", null);
                    //                    mat.GuardarDatos();
                    //                }

                    //                FrmSeleccionarFechaMetasCompras metasCompras = new FrmSeleccionarFechaMetasCompras(IdMaterialSeleccionado, Convert.ToDecimal(mat.Fila().Celda("proyecto")), DateTime.Today, Convert.ToDateTime(proyectoProceso.Fila().Celda("fecha_fin")).Date);
                    //                metasCompras.ShowDialog();
                    //                BorrarDatosMaterial();
                    //               // CargarMaterial(CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text, FiltroFilatradoCompra);
                    //            }
                    //            else
                    //                MessageBox.Show("La fecha fin del proceso de compras no es vigente, favor de ir a la opción de 'Cronograma' para ajustar la fecha fin del proceso", "Fecha no vigente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //    }
                    //    else
                    //        MessageBox.Show("Debe de crear un proceso de compras para crear una meta, favor de ir a la opción de 'Cronograma' para agregar un proceso de compras", "Sin fecha de proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //
                    FrmSelectorFechaCompra seleccionarFechaCompra = new FrmSelectorFechaCompra(Convert.ToInt32(NumIdReq.Value));
                    if (seleccionarFechaCompra.ShowDialog() == DialogResult.OK)
                        CargarMaterial();
                }
            }

        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            CargarMaterial();
        }

        private void NumIdReq_ValueChanged(object sender, EventArgs e)
        {
            CargarMaterial();
        }
    }
}
