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
    public partial class FrmAsignarMultiplesProcesosFabricacion : Ventana
    {
        decimal IdProyecto = 0;
        int Subensamble = 0;

        Proyecto BuscadorProyecto = new Proyecto();
        PlanoProyecto BuscadorPlanos = new PlanoProyecto();
        PlanoProceso BuscarProcesos = new PlanoProceso();
        Modulo BuscadorModulo = new Modulo();

        public FrmAsignarMultiplesProcesosFabricacion(decimal proyecto, int subensamble)
        {
            InitializeComponent();
            IdProyecto = proyecto;
            Subensamble = subensamble;
        }

        private void FrmAsignarMultiplesProcesosFabricacion_Load(object sender, EventArgs e)
        {
            BuscadorProyecto.CargarDatos(IdProyecto);
            if (BuscadorProyecto.TieneFilas())
            {
                BuscadorModulo.SeleccionarProyectoSubensamble(IdProyecto, Subensamble);

                LblProyecto.Text = "Proyecto: " + BuscadorProyecto.Fila().Celda("nombre").ToString() + Environment.NewLine;
                if(BuscadorModulo.TieneFilas())
                {
                    LblProyecto.Text += "Subensamble: " + BuscadorModulo.Fila().Celda("subensamble").ToString().PadLeft(2, '0') + " ";
                    LblProyecto.Text += BuscadorModulo.Fila().Celda("nombre");
                }
            }
            CargarProcesos();
        }

        private void CargarProcesos()
        {
            int row = 0;
            List<string> listaProcesos = new List<string>();
            List<string> listaMaquinaria = new List<string>();
            ComboBox cmbHerramentista = new ComboBox();            

            //Se llena los items del Combo box
            Usuario.Modelo().SeleccionarDepartamento("FABRICACION").ForEach(delegate(Fila filaHerramentista)
            {
                cmbHerramentista.Items.Add(filaHerramentista.Celda("id") + " - " + filaHerramentista.Celda("nombre") + " " + filaHerramentista.Celda("paterno"));
            });

            BuscadorPlanos.BuscarPlanosDeUnProyecto(IdProyecto, Subensamble, "EN PREPARACION").ForEach(delegate(Fila f)
            {
                BuscarProcesos.SeleccionarProcesosPorPlano(Convert.ToInt32(f.Celda("id")), "TIEMPO ESTIMADO").ForEach(delegate(Fila filaProceso)
                {
                    string estatus = Global.ObjetoATexto(filaProceso.Celda("estatus"), "");
                    if (estatus == "TIEMPO ESTIMADO")
                    {
                        string strProceso = filaProceso.Celda("proceso").ToString();
                        if(!listaProcesos.Contains(strProceso) && !strProceso.Contains("INSPECCION"))
                        {
                            listaProcesos.Add(strProceso);
                            DgvProceso.Rows.Add(strProceso);
                            ((DataGridViewComboBoxColumn)DgvProceso.Columns["herramentista"]).DataSource = cmbHerramentista.Items;

                            ComboBox CmbMaquinas = new ComboBox();
                            MaquinaHerramientaProceso.Modelo().TodasDeProceso(strProceso).ForEach(delegate(Fila filaHerramienta)
                            {
                                MaquinaHerramienta mh = new MaquinaHerramienta();
                                mh.CargarDatos(Convert.ToInt32(filaHerramienta.Celda("maquina_herramienta")));
                                CmbMaquinas.Items.Add(mh.Fila().Celda("nombre").ToString());
                            });

                            DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)DgvProceso.Rows[row].Cells["maquina"];
                            cell.DataSource = CmbMaquinas.Items;
                            row++;
                        }
                    }
                });
            });
        }

        private void DgvProceso_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void BtnAsignar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea asignar los procesos?", "Asignar multiples procesos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in DgvProceso.Rows)
            {
                string strProceso = row.Cells["proceso"].Value.ToString();
                string[] herramentista = row.Cells["herramentista"].Value.ToString().Split('-');
                string maquina = row.Cells["maquina"].Value.ToString();

                BuscadorPlanos.BuscarPlanosDeUnProyecto(IdProyecto, Subensamble, "EN PREPARACION").ForEach(delegate(Fila f)
                {
                    BuscarProcesos.SeleccionarProcesosDeUnPlano(Convert.ToInt32(f.Celda("id")), "TIEMPO ESTIMADO", strProceso).ForEach(delegate(Fila filaProceso)
                    {
                        BuscarProcesos.Fila().ModificarCelda("maquina", maquina);
                        BuscarProcesos.Fila().ModificarCelda("programador", maquina);
                        BuscarProcesos.Fila().ModificarCelda("operador", herramentista[1]);
                        BuscarProcesos.Fila().ModificarCelda("herramentista", herramentista[0]);
                        BuscarProcesos.Fila().ModificarCelda("estatus", "ASIGNADO");
                        BuscarProcesos.Fila().ModificarCelda("fecha_asignacion", DateTime.Now);
                        BuscarProcesos.GuardarDatos();
                    });
                });
            }

           
            DialogResult = System.Windows.Forms.DialogResult.Yes;
            Close();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
