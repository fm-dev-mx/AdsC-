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
    public partial class FrmMonitorProyecto : Form
    {
        decimal IdProyecto;
        int NumeroModulo;
        int EditarModulo = 0;
        
        public FrmMonitorProyecto()
        {
            InitializeComponent();
        }

        private void CargarProyectos()
        {
            CmbProyecto.Items.Clear();

            Proyecto.Modelo().SeleccionarDatos("activo=1").ForEach(delegate(Fila f)
            {
                CmbProyecto.Items.Add(Convert.ToDecimal(f.Celda("id")).ToString("F2") + " - " + f.Celda("nombre"));
            });
        }

        private void FrmMonitorProyecto_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CargarProyectos();
            CmbEtapa.Enabled = false;
            seguimientToolStripMenuItem.Enabled = false;
        }

        private void CmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] numeroProjecto = CmbProyecto.Text.Split(' ');
            IdProyecto = Convert.ToDecimal(numeroProjecto[0]);
            CmbEtapa.Enabled = true;
            CmbEtapa.Text = "";
            DgvMonitorProyecto.Rows.Clear();
            seguimientToolStripMenuItem.Enabled = false;
        }

        private void seguimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeguimientoEtapa seguimientoEtapa = new FrmSeguimientoEtapa(IdProyecto, CmbEtapa.Text.Trim(),NumeroModulo, EditarModulo);
            if (seguimientoEtapa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                switch (CmbEtapa.Text)
                {
                    case "DOCUMENTACION MECANICA":
                        CargarDatosDocumentacion();
                        break;

                    case "REVISION DE PLANOS":
                        CargarDatosRevision();
                        break;

                    case "TRATAMIENTO DE MATERIALES":
                        CargarDatosTratamiento();
                        break;

                    case "FABRICACION":
                        CargarDatosFabricacion();
                        break;

                    case "ENSAMBLE":
                        CargarDatosEnsamble();
                        break;
                }
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void CmbEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(CmbEtapa.Text)
            {
                case "DOCUMENTACION MECANICA":
                    CargarDatosDocumentacion();
                    break;

                case "REVISION DE PLANOS":
                    CargarDatosRevision();
                    break;

                case "TRATAMIENTO DE MATERIALES":
                    CargarDatosTratamiento();
                    break;

                case "FABRICACION":
                    CargarDatosFabricacion();
                    break;

                case "ENSAMBLE":
                    CargarDatosEnsamble();
                    break;
            }
        }


        public void CargarDatosDocumentacion()
        {
            seguimientToolStripMenuItem.Enabled = false;
   
            FechaModulo fm = new FechaModulo();
            int totalPiezas = 0;
            int planosDocumentados = 0;

            int avance = totalPiezas - planosDocumentados;
            string responsable = "";
            string fechaPromesa = "";

            DgvMonitorProyecto.Rows.Clear();
            //int totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 00).Count;
            //int planosDocumentados = PlanoProyecto.Modelo().PlanosDocumentacionMecanica(IdProyecto, 00).Count;
            //int avance = totalPiezas - planosDocumentados;
            //string responsable = "";
            //string fechaPromesa = "";
            
            //DgvMonitorProyecto.Rows.Add(00.ToString("D2"), "ESTACION COMPLETA");
          

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 01).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, 01).Count;
            string mostrarAvance = planosDocumentados + " / " + totalPiezas.ToString();
            fm.SeleccionarDatos(IdProyecto, 01, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }

            DgvMonitorProyecto.Rows.Add(01.ToString("D2"), "PTR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 02).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, 02).Count;
            mostrarAvance = planosDocumentados + " / " + totalPiezas.ToString();
            fm.SeleccionarDatos(IdProyecto, 02, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(02.ToString("D2"), "PLACA PRINCIPAL", totalPiezas, mostrarAvance,responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 03).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, 03).Count;
            mostrarAvance = planosDocumentados + " / " + totalPiezas.ToString();
            fm.SeleccionarDatos(IdProyecto, 03, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(03.ToString("D2"), "ESTRUCTURA SUPERIOR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            Modulo.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                int numeroSubensamble = Convert.ToInt32(f.Celda("subensamble"));
                totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, numeroSubensamble).Count;
                planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, numeroSubensamble).Count;
                mostrarAvance = planosDocumentados + " / " + totalPiezas.ToString();
                fm.SeleccionarDatos(IdProyecto, numeroSubensamble, CmbEtapa.Text);

                if (fm.TieneFilas())
                {
                    responsable = fm.Fila().Celda("responsable").ToString();
                    fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
                }

                else
                {
                    responsable = "N/A";
                    fechaPromesa = "N/A";
                }
                DgvMonitorProyecto.Rows.Add(f.Celda("subensamble"), f.Celda("nombre"), totalPiezas, mostrarAvance, responsable, fechaPromesa);
            });
        }

        public void CargarDatosRevision()
        {
            seguimientToolStripMenuItem.Enabled = false;

            FechaModulo fm = new FechaModulo();
            int totalPiezas = 0;
            int planosDocumentados = 0;
            int planosRevisados = 0;
            string responsable = "";
            string fechaPromesa = "";

            DgvMonitorProyecto.Rows.Clear();

            //int totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 00).Count;
            //int planosDocumentados = PlanoProyecto.Modelo().PlanosRevisados(IdProyecto, 00).Count;
            //int avance = totalPiezas - planosDocumentados;
            //string responsable = "";
            //string fechaPromesa = "";
            //DgvMonitorProyecto.Rows.Clear();
            //DgvMonitorProyecto.Rows.Add(00.ToString("D2"), "ESTACION COMPLETA");


            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 01).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, 01).Count;
            planosRevisados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, 01).Count;
            string mostrarAvance = planosRevisados.ToString() + " / " + planosDocumentados.ToString();
            fm.SeleccionarDatos(IdProyecto, 01, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }

            DgvMonitorProyecto.Rows.Add(01.ToString("D2"), "PTR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 02).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, 02).Count;
            planosRevisados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, 02).Count;
            mostrarAvance = planosRevisados.ToString() + " / " + planosDocumentados.ToString();
            fm.SeleccionarDatos(IdProyecto, 02, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(02.ToString("D2"), "PLACA PRINCIPAL", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 03).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, 03).Count;
            planosRevisados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, 03).Count;
            mostrarAvance = planosRevisados.ToString() + " / " + planosDocumentados.ToString();
            fm.SeleccionarDatos(IdProyecto, 03, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(03.ToString("D2"), "ESTRUCTURA SUPERIOR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            Modulo.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                int numeroSubensamble = Convert.ToInt32(f.Celda("subensamble"));
                totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, numeroSubensamble).Count;
                planosDocumentados = PlanoProyecto.Modelo().ProcesadosDocumentacionMecanica(IdProyecto, numeroSubensamble).Count;
                planosRevisados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, numeroSubensamble).Count;
                mostrarAvance = planosRevisados.ToString() + " / " + planosDocumentados.ToString();
                fm.SeleccionarDatos(IdProyecto, numeroSubensamble, CmbEtapa.Text);

                if (fm.TieneFilas())
                {
                    responsable = fm.Fila().Celda("responsable").ToString();
                    fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
                }

                else
                {
                    responsable = "N/A";
                    fechaPromesa = "N/A";
                }
                DgvMonitorProyecto.Rows.Add(f.Celda("subensamble"), f.Celda("nombre"), totalPiezas, mostrarAvance, responsable, fechaPromesa);
            });
        }

        public void CargarDatosTratamiento()
        {
            seguimientToolStripMenuItem.Enabled = false;

            FechaModulo fm = new FechaModulo();
            int totalPiezas = 0;
            int totalPiezasFabricadas = 0;
            int avanceTratamiento = 0;
            string responsable = "";
            string fechaPromesa = "";

            DgvMonitorProyecto.Rows.Clear();

            //int totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 00).Count;
            //int planosDocumentados = PlanoProyecto.Modelo().PlanosRevisados(IdProyecto, 00).Count;
            //int avance = totalPiezas - planosDocumentados;
            //string responsable = "";
            //string fechaPromesa = "";
            //DgvMonitorProyecto.Rows.Clear();
            //DgvMonitorProyecto.Rows.Add(00.ToString("D2"), "ESTACION COMPLETA");


            totalPiezas = PlanoProyecto.Modelo().TotalPlanosTratamiento(IdProyecto, 01).Count;
            totalPiezasFabricadas = PlanoProyecto.Modelo().PlanosTratamiento(IdProyecto, 01).Count;
            avanceTratamiento = PlanoProyecto.Modelo().PlanosTratamientoTerminado(IdProyecto, 01).Count;
            string mostrarAvance = avanceTratamiento.ToString() + " / " + totalPiezasFabricadas.ToString();
            fm.SeleccionarDatos(IdProyecto, 01, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }

            DgvMonitorProyecto.Rows.Add(01.ToString("D2"), "PTR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosTratamiento(IdProyecto, 02).Count;
            totalPiezasFabricadas = PlanoProyecto.Modelo().PlanosTratamiento(IdProyecto, 02).Count;
            avanceTratamiento = PlanoProyecto.Modelo().PlanosTratamientoTerminado(IdProyecto, 02).Count;
            mostrarAvance = avanceTratamiento.ToString() + " / " + totalPiezasFabricadas.ToString();

            fm.SeleccionarDatos(IdProyecto, 02, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(02.ToString("D2"), "PLACA PRINCIPAL", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosTratamiento(IdProyecto, 03).Count;
            totalPiezasFabricadas = PlanoProyecto.Modelo().PlanosTratamiento(IdProyecto, 03).Count;
            avanceTratamiento = PlanoProyecto.Modelo().PlanosTratamientoTerminado(IdProyecto, 03).Count;
            mostrarAvance = avanceTratamiento.ToString() + " / " + totalPiezasFabricadas.ToString();

            fm.SeleccionarDatos(IdProyecto, 03, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(03.ToString("D2"), "ESTRUCTURA SUPERIOR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            Modulo.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                int numeroSubensamble = Convert.ToInt32(f.Celda("subensamble"));
                totalPiezas = PlanoProyecto.Modelo().TotalPlanosTratamiento(IdProyecto, numeroSubensamble).Count;
                totalPiezasFabricadas = PlanoProyecto.Modelo().PlanosTratamiento(IdProyecto, numeroSubensamble).Count;
                avanceTratamiento = PlanoProyecto.Modelo().PlanosTratamientoTerminado(IdProyecto, numeroSubensamble).Count;
                mostrarAvance = avanceTratamiento.ToString() + " / " + totalPiezasFabricadas.ToString();
                fm.SeleccionarDatos(IdProyecto, numeroSubensamble, CmbEtapa.Text);

                if (fm.TieneFilas())
                {
                    responsable = fm.Fila().Celda("responsable").ToString();
                    fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
                }

                else
                {
                    responsable = "N/A";
                    fechaPromesa = "N/A";
                }
                DgvMonitorProyecto.Rows.Add(f.Celda("subensamble"), f.Celda("nombre"), totalPiezas, mostrarAvance, responsable, fechaPromesa);
            });
        }

        private void CargarDatosFabricacion()
        {
            seguimientToolStripMenuItem.Enabled = false;

            FechaModulo fm = new FechaModulo();
            int totalPiezas = 0;
            int planosDocumentados = 0;

            int avance = totalPiezas - planosDocumentados;
            string responsable = "";
            string fechaPromesa = "";

            DgvMonitorProyecto.Rows.Clear();
            //int totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 00).Count;
            //int planosDocumentados = PlanoProyecto.Modelo().PlanosDocumentacionMecanica(IdProyecto, 00).Count;
            //int avance = totalPiezas - planosDocumentados;
            //string responsable = "";
            //string fechaPromesa = "";

            //DgvMonitorProyecto.Rows.Add(00.ToString("D2"), "ESTACION COMPLETA");


            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 01).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, 01).Count;
            int avanceFabricacion = PlanoProyecto.Modelo().AvencePlanosFabricados(IdProyecto, 01).Count;
            string mostrarAvance = avanceFabricacion + " / " + planosDocumentados;
            fm.SeleccionarDatos(IdProyecto, 01, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }

            DgvMonitorProyecto.Rows.Add(01.ToString("D2"), "PTR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 02).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, 02).Count;
            avanceFabricacion = PlanoProyecto.Modelo().AvencePlanosFabricados(IdProyecto, 02).Count;
            mostrarAvance = avanceFabricacion + " / " + planosDocumentados;
            fm.SeleccionarDatos(IdProyecto, 02, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(02.ToString("D2"), "PLACA PRINCIPAL", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 03).Count;
            planosDocumentados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, 03).Count;
            avanceFabricacion = PlanoProyecto.Modelo().AvencePlanosFabricados(IdProyecto, 03).Count;
            mostrarAvance = avanceFabricacion + " / " + planosDocumentados;
            fm.SeleccionarDatos(IdProyecto, 03, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(03.ToString("D2"), "ESTRUCTURA SUPERIOR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            Modulo.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                int numeroSubensamble = Convert.ToInt32(f.Celda("subensamble"));
                totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, numeroSubensamble).Count;
                planosDocumentados = PlanoProyecto.Modelo().ProcesadosRevision(IdProyecto, numeroSubensamble).Count;
                avanceFabricacion = PlanoProyecto.Modelo().AvencePlanosFabricados(IdProyecto, numeroSubensamble).Count;
                mostrarAvance = avanceFabricacion + " / " + planosDocumentados;
                fm.SeleccionarDatos(IdProyecto, numeroSubensamble, CmbEtapa.Text);

                if (fm.TieneFilas())
                {
                    responsable = fm.Fila().Celda("responsable").ToString();
                    fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
                }

                else
                {
                    responsable = "N/A";
                    fechaPromesa = "N/A";
                }
                DgvMonitorProyecto.Rows.Add(f.Celda("subensamble"), f.Celda("nombre"), totalPiezas, mostrarAvance, responsable, fechaPromesa);
            });
        }

        private void CargarDatosEnsamble()
        {
            seguimientToolStripMenuItem.Enabled = false;

            FechaModulo fm = new FechaModulo();
            int totalPiezas = 0;
            
            int totalFabricacion=0;
            int avanceEnsamble=0;
            string responsable = "";
            string fechaPromesa = "";

            DgvMonitorProyecto.Rows.Clear();
            //int totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 00).Count;
            //int planosDocumentados = PlanoProyecto.Modelo().PlanosDocumentacionMecanica(IdProyecto, 00).Count;
            //int avance = totalPiezas - planosDocumentados;
            //string responsable = "";
            //string fechaPromesa = "";

            //DgvMonitorProyecto.Rows.Add(00.ToString("D2"), "ESTACION COMPLETA");


            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 01).Count;
            totalFabricacion = PlanoProyecto.Modelo().PiezaListaParaEnsamble(IdProyecto, 01).Count;
            avanceEnsamble = PlanoProyecto.Modelo().AvancePlanosEnsamble(IdProyecto, 01).Count;
            string mostrarAvance = avanceEnsamble + " / " + totalFabricacion;
            fm.SeleccionarDatos(IdProyecto, 01, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }

            DgvMonitorProyecto.Rows.Add(01.ToString("D2"), "PTR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 02).Count;
            totalFabricacion = PlanoProyecto.Modelo().PiezaListaParaEnsamble(IdProyecto, 02).Count;
            avanceEnsamble = PlanoProyecto.Modelo().AvancePlanosEnsamble(IdProyecto, 02).Count;
            mostrarAvance = avanceEnsamble + " / " + totalFabricacion;
            fm.SeleccionarDatos(IdProyecto, 02, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(02.ToString("D2"), "PLACA PRINCIPAL", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, 03).Count;
            totalFabricacion = PlanoProyecto.Modelo().PiezaListaParaEnsamble(IdProyecto, 03).Count;
            avanceEnsamble = PlanoProyecto.Modelo().AvancePlanosEnsamble(IdProyecto, 03).Count;
            mostrarAvance = avanceEnsamble + " / " + totalFabricacion;
            fm.SeleccionarDatos(IdProyecto, 03, CmbEtapa.Text);

            if (fm.TieneFilas())
            {
                responsable = fm.Fila().Celda("responsable").ToString();
                fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
            }

            else
            {
                responsable = "N/A";
                fechaPromesa = "N/A";
            }
            DgvMonitorProyecto.Rows.Add(03.ToString("D2"), "ESTRUCTURA SUPERIOR", totalPiezas, mostrarAvance, responsable, fechaPromesa);

            Modulo.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                int numeroSubensamble = Convert.ToInt32(f.Celda("subensamble"));
                totalPiezas = PlanoProyecto.Modelo().TotalPlanosSubproyecto(IdProyecto, numeroSubensamble).Count;
                totalFabricacion = PlanoProyecto.Modelo().PiezaListaParaEnsamble(IdProyecto, numeroSubensamble).Count;
                avanceEnsamble = PlanoProyecto.Modelo().AvancePlanosEnsamble(IdProyecto, numeroSubensamble).Count;
                mostrarAvance = avanceEnsamble + " / " + totalFabricacion;
                fm.SeleccionarDatos(IdProyecto, numeroSubensamble, CmbEtapa.Text);

                if (fm.TieneFilas())
                {
                    responsable = fm.Fila().Celda("responsable").ToString();
                    fechaPromesa = fm.Fila().Celda("fecha_promesa").ToString();
                }
                else
                {
                    responsable = "N/A";
                    fechaPromesa = "N/A";
                }
                DgvMonitorProyecto.Rows.Add(f.Celda("subensamble"), f.Celda("nombre"), totalPiezas, mostrarAvance, responsable, fechaPromesa);
            });
        }
        

        private void DgvMonitorProyecto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvMonitorProyecto.SelectedRows.Count <= 0)
                return;
            NumeroModulo = Convert.ToInt32(DgvMonitorProyecto.SelectedRows[0].Cells["modulo"].Value);
            string fecha = Convert.ToString(DgvMonitorProyecto.SelectedRows[0].Cells["fecha_promesa"].Value);
            string responsable = Convert.ToString(DgvMonitorProyecto.SelectedRows[0].Cells["responsable"].Value);
            seguimientToolStripMenuItem.Enabled = true;

            if (fecha != "N/A" && responsable != "N/A")
                EditarModulo = 1;

            else
                EditarModulo = 0;
        }
    }
}
