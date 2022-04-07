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
    public partial class FrmNuevaParteSubensamble : Ventana
    {
        decimal proyecto = 0;
        int subEnsamble = 0;
        int idNuevaParte = 0;

        public FrmNuevaParteSubensamble(decimal Proyecto, int SubEnsamble)
        {
            InitializeComponent();
            proyecto = Proyecto;
            subEnsamble = SubEnsamble;
        }

        private void CargarComponentes()
        {
            int seleccionarFila = Global.GuardarFilaSeleccionada(DgvNuevaParte);
            DgvNuevaParte.Rows.Clear();

            ComponentesProyecto.Modelo().CargarComponentes(proyecto).ForEach(delegate(Fila f)
            {
                decimal pro = Convert.ToDecimal(f.Celda("proyecto"));
                DgvNuevaParte.Rows.Add(f.Celda("id"), pro.ToString("F2"), f.Celda("nombre"));
            });
            Global.RecuperarFilaSeleccionada(DgvNuevaParte, seleccionarFila);
        }

        private void NuevaParteSubensamble()
        {
            Fila nuevoComponente = new Fila();
            nuevoComponente.AgregarCelda("subensamble", subEnsamble);
            nuevoComponente.AgregarCelda("parte", idNuevaParte);
            nuevoComponente.AgregarCelda("tipo", CmbTipo.Text.Trim());
            SubensambleParte.Modelo().Insertar(nuevoComponente);
        }

        private void CargarSubensambles()
        {
            int seleccionarFila = Global.GuardarFilaSeleccionada(DgvNuevaParte);
            DgvNuevaParte.Rows.Clear();

            SubensambleProyecto.Modelo().CargarSubEnsambles(proyecto).ForEach(delegate(Fila f)
            {
                decimal pro = Convert.ToDecimal(f.Celda("proyecto"));
                DgvNuevaParte.Rows.Add(f.Celda("id"), pro.ToString("F2"), f.Celda("nombre"));
            });

            Global.RecuperarFilaSeleccionada(DgvNuevaParte, seleccionarFila);
       }
        
         private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
         {
             Mover(sender, e);
         }

         private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
         {
             BtnRegistrar.Enabled = false;

             switch(CmbTipo.Text)
             {
                 case "COMPONENTE":
                     CargarComponentes();
                     DgvNuevaParte.Columns["componente"].HeaderText = "Componentes";
                     if (DgvNuevaParte.Rows.Count > 0)
                         DgvNuevaParte.Rows[0].Selected = false;    
                 break;

                 case "SUBENSAMBLE":
                     CargarSubensambles();
                     DgvNuevaParte.Columns["componente"].HeaderText = "Subensambles";

                     if (DgvNuevaParte.Rows.Count > 0)
                         DgvNuevaParte.Rows[0].Selected = false;
                 break;
             }
         }

         private void FrmNuevaParteSubensamble_Load(object sender, EventArgs e)
         {
             CmbTipo.Text = "COMPONENTE";
             CargarComponentes();
             BtnRegistrar.Enabled = false;

             if (DgvNuevaParte.Rows.Count > 0)
                 DgvNuevaParte.Rows[0].Selected = false;
         }

         private void BtnCancelar_Click(object sender, EventArgs e)
         {
             Close();
         }

         private void DgvNuevaParte_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             if (DgvNuevaParte.SelectedRows.Count <= 0)
                 return;

             idNuevaParte = Convert.ToInt32(DgvNuevaParte.SelectedRows[0].Cells["id_elemento"].Value);
             BtnRegistrar.Enabled = true;   
         }

         private void BtnRegistrar_Click(object sender, EventArgs e)
         {
             NuevaParteSubensamble();
             this.DialogResult = System.Windows.Forms.DialogResult.OK;
         }
    }
}
