using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB_Base.Classes
{
    public partial class FrmResumenPendientes : Form
    {
        public Decimal ProyectoPrincipal = 0;
        public Decimal ProyectoSeleccionado = 0;
        public string CategoriaSeleccionada = "";

        public FrmResumenPendientes()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmResumenPendientes_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CargarProyectos();
            CargarRequerimientos();
        }

        void CargarProyectos()
        {
            CmbProyecto.Items.Clear();
            CmbProyecto.Items.Add("TODOS");

            Proyecto.Modelo().SeleccionarDatos("activo=1").ForEach(delegate(Fila f)
            {
                CmbProyecto.Items.Add(Convert.ToDecimal(f.Celda("id")).ToString("F2") + " - " + f.Celda("nombre"));
            });

            CmbProyecto.Text = "TODOS";
        }

        void CargarRequerimientos()
        {
            if (CmbEstatusRequerimiento.Text == "")
                CmbEstatusRequerimiento.Text = "SOLICITUDES";

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", ProyectoSeleccionado);
            string filtroEstatus = "";

            switch(CmbEstatusRequerimiento.Text)
            {
                case "SOLICITUDES":
                    filtroEstatus = "estatus='SOLICITUD'";
                    break;

                case "NO DEFINIDOS":
                    filtroEstatus = "estatus='NO DEFINIDO'";
                    break;

                case "EN EVALUACION":
                    filtroEstatus = "estatus='EN EVALUACION'";
                    break;

                case "SIN REVISAR":
                    filtroEstatus = "estatus='DEFINIDO' AND estatus_revision='PENDIENTE'";
                    break;

                case "SIN CUMPLIR":
                    filtroEstatus = "estatus='DEFINIDO' AND estatus_revision='NO CUMPLE'";
                    break;
            }




            string filtroProyecto = "";
            if (ProyectoSeleccionado > 0)
                filtroProyecto = "proyecto=@proyecto AND ";
            else
                filtroProyecto = "proyecto>0 AND ";

            int fila = Global.GuardarFilaSeleccionada(DgvRequerimientos);
            DgvRequerimientos.Rows.Clear();

            Requerimiento.Modelo().SeleccionarDatos(filtroProyecto + filtroEstatus + " ORDER BY proyecto ASC", parametros).ForEach(delegate(Fila f)
            {
                DgvRequerimientos.Rows.Add(f.Celda("id"),
                                           Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                                           f.Celda("nombre"),
                                           f.Celda("descripcion"),
                                           f.Celda("origen"),
                                           f.Celda("estatus"),
                                           f.Celda("nivel_revision"),
                                           f.Celda("estatus_revision"));
            });

            Global.RecuperarFilaSeleccionada(DgvRequerimientos, fila);
        }

        private void CmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbProyecto.Text == "TODOS")
            {
                ProyectoSeleccionado = 0;
            }
            else
            {
                ProyectoSeleccionado = Convert.ToDecimal(CmbProyecto.Text.Split('-')[0].Trim());
            }

            switch(Tabs.SelectedIndex)
            {
                case 0:
                    CargarRequerimientos();
                    break;
            }
        }

        private void CmbEstatusRequerimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRequerimientos();
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(Tabs.SelectedIndex)
            {
                case 0:
                    CargarRequerimientos();
                    CategoriaSeleccionada = "Requerimientos";
                    break;
            }
        }

        private void DgvRequerimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProyectoSeleccionado == 0)
            {
                ProyectoSeleccionado = Convert.ToDecimal(DgvRequerimientos.SelectedRows[0].Cells["req_proyecto"].Value);
                ProyectoPrincipal = Math.Floor(ProyectoSeleccionado);
                CategoriaSeleccionada = "Requerimientos";
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

     
        
    }
}
