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
    public partial class FrmAjustarFactoresProcesoFabricacion : Ventana
    {
        string Proceso = string.Empty;

        public FrmAjustarFactoresProcesoFabricacion(string nombreProceso)
        {
            InitializeComponent();
            ProcesoFabricacion procesoFabricacion = new ProcesoFabricacion();
            procesoFabricacion.BuscarProceso(nombreProceso);

            if (procesoFabricacion.TieneFilas())
                Proceso = procesoFabricacion.Fila().Celda("categoria").ToString();
        }

        private void FrmAjustarFactoresProcesoFabricacion_Load(object sender, EventArgs e)
        {
            TxtProceso.Text = Proceso;
            CargarFactores();
        }

        private void CargarFactores()
        {
            CmbFactor.Items.Clear();
            DgvPorcentajes.Rows.Clear();

            FactorProcesoFabricacion factores = new FactorProcesoFabricacion();
            factores.CargarDiferentesFactores(TxtProceso.Text).ForEach(delegate(Fila f)
            {
                CmbFactor.Items.Add(f.Celda("factor"));
            });
        }

        private void CargarValorDelFactor()
        {
            DgvPorcentajes.Rows.Clear();

            FactorProcesoFabricacion valorFactor = new FactorProcesoFabricacion();
            valorFactor.SeleccionarPorFactorProceso(Proceso, CmbFactor.Text).ForEach(delegate(Fila f)
            {
                DgvPorcentajes.Rows.Add(f.Celda("id"), f.Celda("factor_valor"), f.Celda("factor_porcentaje"));
            });
        }

        private void TxtProceso_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void MenuFactor_Opening(object sender, CancelEventArgs e)
        {
            if (CmbFactor.Text != "" && CmbFactor.Text != "N/A")
            {
                editarFactorToolStripMenuItem1.Enabled = true;
                eliminarFactorToolStripMenuItem.Enabled = true;
            }
            else
            {
                editarFactorToolStripMenuItem1.Enabled = false;
                eliminarFactorToolStripMenuItem.Enabled = false;
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoFactor nuevo = new FrmNuevoFactor(TxtProceso.Text);
            if(nuevo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FactorProcesoFabricacion buscarFactor = new FactorProcesoFabricacion();
                buscarFactor.SeleccionarPorFactorProceso(TxtProceso.Text, nuevo.NombreFactor);
                if (buscarFactor.TieneFilas())
                {
                    MessageBox.Show("El factor que desea agregar ya existe", "Factor existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Fila insertarFactor = new Fila();
                insertarFactor.AgregarCelda("proceso", TxtProceso.Text);
                insertarFactor.AgregarCelda("factor", nuevo.NombreFactor);
                int idFactor = Convert.ToInt32(FactorProcesoFabricacion.Modelo().Insertar(insertarFactor).Celda("id"));

                FrmNuevoFactorValor valorFactor = new FrmNuevoFactorValor(nuevo.NombreFactor, idFactor);
                if (valorFactor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FactorProcesoFabricacion editarFactor = new FactorProcesoFabricacion();
                    editarFactor.CargarDatos(idFactor);
                    if (editarFactor.TieneFilas())
                    {
                        editarFactor.Fila().ModificarCelda("factor_valor", valorFactor.ValorFactor);
                        editarFactor.Fila().ModificarCelda("factor_porcentaje", valorFactor.Porcentaje);
                        editarFactor.GuardarDatos();
                    }
                }
                CargarFactores();
            }
        }

        private void editarFactorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNuevoFactor editar = new FrmNuevoFactor(TxtProceso.Text, CmbFactor.Text);
            if (editar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FactorProcesoFabricacion factores = new FactorProcesoFabricacion();
                factores.SeleccionarPorFactorProceso(TxtProceso.Text, CmbFactor.Text).ForEach(delegate(Fila f)
                {
                    f.ModificarCelda("factor", editar.NombreFactor);
                });

                factores.GuardarDatos();
            }
        }

        private void CmbFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFactor.Text != "")
                CargarValorDelFactor();
            else
                DgvPorcentajes.Rows.Clear();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void DgvPorcentajes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNuevoFactorValor valorFactor = new FrmNuevoFactorValor(CmbFactor.Text);
            if (valorFactor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila insertarFactor = new Fila();
                insertarFactor.AgregarCelda("proceso", Proceso);
                insertarFactor.AgregarCelda("factor", CmbFactor.Text);
                insertarFactor.AgregarCelda("factor_valor", valorFactor.ValorFactor);
                insertarFactor.AgregarCelda("factor_porcentaje", valorFactor.Porcentaje);
                FactorProcesoFabricacion.Modelo().Insertar(insertarFactor);

                CargarValorDelFactor();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int idFactor = Convert.ToInt32(DgvPorcentajes.SelectedRows[0].Cells["id"].Value);

             FrmNuevoFactorValor valorFactor = new FrmNuevoFactorValor(CmbFactor.Text, idFactor);
             if (valorFactor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                 FactorProcesoFabricacion editarFactor = new FactorProcesoFabricacion();
                 editarFactor.CargarDatos(idFactor);
                 if(editarFactor.TieneFilas())
                 {
                     editarFactor.Fila().ModificarCelda("factor_valor", valorFactor.ValorFactor);
                     editarFactor.Fila().ModificarCelda("factor_porcentaje", valorFactor.Porcentaje);
                     editarFactor.GuardarDatos();
                     CargarValorDelFactor();
                 }
             }
        }

        private void MenuOpcionProceso_Opening(object sender, CancelEventArgs e)
        {
            nuevoToolStripMenuItem1.Enabled = (CmbFactor.Text != "");
            editarToolStripMenuItem.Enabled = (DgvPorcentajes.SelectedRows.Count > 0);
            eliminarToolStripMenuItem.Enabled = (DgvPorcentajes.SelectedRows.Count > 0);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los datos que sean borrados no podrán ser recuperados, ¿Desea borrar el valor del factor seleccionado?", "Borrar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            int idFactor = Convert.ToInt32(DgvPorcentajes.SelectedRows[0].Cells["id"].Value);

            FactorProcesoFabricacion eliminarFactor = new FactorProcesoFabricacion();
            eliminarFactor.CargarDatos(idFactor);
            eliminarFactor.BorrarDatos(idFactor);
            eliminarFactor.GuardarDatos();
            CargarValorDelFactor();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void eliminarFactorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los datos que sean borrados no podrán ser recuperados, ¿Desea borrar el factor seleccionado?", "Borrar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            FactorProcesoFabricacion.Modelo().SeleccionarPorFactorProceso(Proceso, CmbFactor.Text).ForEach(delegate(Fila f)
            {
                FactorProcesoFabricacion eliminarFactor = new FactorProcesoFabricacion();
                eliminarFactor.CargarDatos(Convert.ToInt32(f.Celda("id")));
                eliminarFactor.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                eliminarFactor.GuardarDatos();
            });

            CargarFactores();
            DgvPorcentajes.Rows.Clear();
        }
    }
}
