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
using System.Text.RegularExpressions;

namespace CB
{
    public partial class FrmAgregarProcesoPlano : Ventana
    {
        private int IdPlano = 0;
        private int IdProceso = 0;
        private int Dependencia = 0;
        private int ProcesoAnterior = 0;
        private bool ProcesoCero = false;

        private bool PrimerProceso = false;     
        
        public FrmAgregarProcesoPlano(int idPlano,bool procesoCero, int idProceso=0)
        {
            InitializeComponent();
            IdPlano = idPlano;
            IdProceso = idProceso;
            ProcesoCero = procesoCero;
            if (IdProceso != 0)
            {
                BtnAgregar.Text = "Guardar";
                LblPlano.Text = "EDITAR PROCESO " + IdProceso;
                MostrarProceso(IdProceso);
                if (procesoCero)
                {
                    if (!ChkDependencia.Checked)
                        EditarProcesoAnterior();
                    else
                        BtnAgregar.Enabled = true;

                    ChkDependencia.Visible = true;
                    ChkDependencia.Enabled = true;
                }
                else
                {
                    EditarProcesoAnterior();
                   
                }

            }
            else
            {
                LblPlano.Text = "NUEVO PROCESO ";
                CargarCategorias();
                if (!CargarProcesoAnterior())
                {
                    PrimerProceso = true;
                    DgvProcesoAnterior.Enabled = false;
                    LblProcesoAnterior.Text = "DEPENDENCIA 0";
                }
            }   
        }

        public void CargarCategorias()
        {
            CmbCategorias.Items.Clear();
            ProcesoFabricacion.Modelo().Categorias().ForEach(delegate(Fila categoria)
            {
                CmbCategorias.Items.Add(categoria.Celda("categoria").ToString());
            });
        }

        public void CargarProcesos(string categoria)
        {
            CmbProcesos.Items.Clear();
            ProcesoFabricacion.Modelo().DeCategoria(categoria).ForEach(delegate(Fila proceso)
            {
                CmbProcesos.Items.Add(proceso.Celda("nombre").ToString());
            });
        }

        //public void CargarMaquinasHerramientas(string proceso)
        //{
        //    CmbAsignacion.Items.Clear();
        //    MaquinaHerramientaProceso.Modelo().TodasDeProceso(proceso).ForEach(delegate(Fila maquina)
        //    {
        //        int idMaquina = Convert.ToInt32(maquina.Celda("maquina_herramienta").ToString());

        //        MaquinaHerramienta mh = new MaquinaHerramienta();
        //        mh.CargarDatos(idMaquina);

        //        CmbAsignacion.Items.Add(mh.Fila().Celda("nombre").ToString());
        //    });
        //}

        public bool CargarProcesoAnterior()
        {
            PlanoProceso proceso = new PlanoProceso();
            proceso.CargarProcesoAnterior(IdPlano);
            if (proceso.TieneFilas())
            {
                PlanoProceso.Modelo().CargarProcesoAnterior(IdPlano,IdProceso).ForEach(delegate(Fila f)
                {
                    if (proceso.TieneFilas())
                        DgvProcesoAnterior.Rows.Add(f.Celda("id"), f.Celda("proceso"), f.Celda("maquina"));
                });
                return true;
            }
            else
                return false;
        }

        public bool EditarProcesoAnterior()
        {
            PlanoProceso proceso = new PlanoProceso();
            proceso.CargarProcesoAnterior(IdPlano);
            if (proceso.TieneFilas())
            {
                PlanoProceso.Modelo().CargarProcesoAnterior(IdPlano, IdProceso).ForEach(delegate(Fila f)
                {
                    if (proceso.TieneFilas())
                        DgvProcesoAnterior.Rows.Add(f.Celda("id"), f.Celda("proceso"), f.Celda("maquina"));
                });
                return true;
            }
            else
                return false;
        }

        private void HabilitarBoton()
        {
            if (DgvProcesoAnterior.Rows.Count > 0 && ProcesoAnterior != 0)
                BtnAgregar.Enabled = !CmbCategorias.Text.Equals("") && !CmbProcesos.Text.Equals("") && !CmbAsignacion.Text.Equals("") && ProcesoAnterior == 0;
            else if (DgvProcesoAnterior.Rows.Count > 0 && ProcesoAnterior == 0)
                BtnAgregar.Enabled = !CmbCategorias.Text.Equals("") && !CmbProcesos.Text.Equals("") && !CmbAsignacion.Text.Equals("") && DgvProcesoAnterior.SelectedRows.Count > 0;
            else if (PrimerProceso)
                BtnAgregar.Enabled = !CmbCategorias.Text.Equals("") && !CmbProcesos.Text.Equals("") && !CmbAsignacion.Text.Equals("");
            else if(DgvProcesoAnterior.Rows.Count == 0)
                BtnAgregar.Enabled = !CmbCategorias.Text.Equals("") && !CmbProcesos.Text.Equals("") && !CmbAsignacion.Text.Equals("");
        }

        public void MostrarProceso(int idProceso)
        {
            PlanoProceso proceso = new PlanoProceso();
            proceso.CargarDatos(idProceso);
            CargarCategorias();

            if (proceso.TieneFilas())
            {
                string categoria = ProcesoFabricacion.Modelo().BuscarCategoria(proceso.Fila().Celda("proceso").ToString());
                string nombreProceso = proceso.Fila().Celda("proceso").ToString();
                string maquina = proceso.Fila().Celda("maquina").ToString();
                string comentarios = proceso.Fila().Celda("comentarios").ToString();
                Object procesoAnterior = proceso.Fila().Celda("proceso_anterior");

                if (!CmbCategorias.Items.Contains(categoria))
                    CmbCategorias.Items.Add(categoria);
                CmbCategorias.Text = categoria;

                if (!CmbProcesos.Items.Contains(nombreProceso))
                    CmbProcesos.Items.Add(nombreProceso);
                CmbProcesos.Text = nombreProceso;

                if (!CmbAsignacion.Items.Contains(maquina))
                    CmbAsignacion.Items.Add(maquina);
                CmbAsignacion.Text = maquina;

                TxtComentarios.Text = comentarios;

                if (procesoAnterior != null)
                {
                    Dependencia = Convert.ToInt32(proceso.Fila().Celda("proceso_anterior"));
                    LblProcesoAnterior.Text = "EDITAR DEPENDENCIA " + Dependencia;
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            MaquinaHerramienta maquina = new MaquinaHerramienta();
            maquina.SeleccionarNombre(CmbAsignacion.Text);

            if( CmbCategorias.Text == "TRATAMIENTO" && CmbAsignacion.Text == "PROVEEDOR" )
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@plano", IdPlano);
                parametros.Add("@terminado", "TERMINADO");

                List<Fila> sinTerminar = PlanoProceso.Modelo().SeleccionarDatos("plano=@plano AND estatus!=@terminado", parametros);

                if( sinTerminar.Count > 0 )
                {
                    MessageBox.Show("Para agregar procesos de tratamiento asignados a PROVEEDOR todos los procesos de fabricación deben estar terminados.",
                                    "Imposible agregar proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            if (IdProceso != 0 && !ProcesoCero)
            {
                modificarInformacion();              
            }
            else if(IdProceso == 0 && !ProcesoCero)
            {
                Fila proceso = new Fila(); 
             
                proceso.AgregarCelda("plano", IdPlano);
                proceso.AgregarCelda("proceso", CmbProcesos.Text);
                proceso.AgregarCelda("maquina", "N/A");
                proceso.AgregarCelda("programador", "N/A");
                proceso.AgregarCelda("operador", "N/A");
                proceso.AgregarCelda("comentarios", TxtComentarios.Text);
                proceso.AgregarCelda("proceso_anterior", ProcesoAnterior);
                proceso.AgregarCelda("orden", 5);
                proceso.AgregarCelda("fecha_inicio", DateTime.Today);

                PlanoProyecto p = new PlanoProyecto();               
                p.CargarDatos(IdPlano);

                Fila procesoInsertado = PlanoProceso.Modelo().Insertar(proceso);

                if(CmbAsignacion.Text == "PROVEEDOR")
                {
                    int idProceso = Convert.ToInt32(procesoInsertado.Celda("id"));
                    string nombreProceso = CmbProcesos.Text;

                    string numeroParte = MaterialProyecto.CrearNNumeroParteProceso(IdPlano, nombreProceso, idProceso);
                    string descripcion = procesoInsertado.Celda("proceso").ToString() + " " + numeroParte;
                    string rutaPlanoFtp = string.Empty;

                    byte[] datosPlano = null;

                    if (datosPlano == null)
                    {
                        ArchivoPlano plano = new ArchivoPlano();
                        plano.SeleccionarDePlano(IdPlano);

                        if (plano.TieneFilas())
                            datosPlano = (byte[])plano.Fila().Celda("archivo");
                    }

                    int idReq = MaterialProyecto.Modelo().CrearRequisicionCompraFabricacion(p, CmbCategorias.Text, MaterialProyecto.TablaMaterialRequisicion.ProcesoPlano, numeroParte, descripcion, true, 0, datosPlano);

                    if(idReq > 0)
                    {
                        PlanoProceso planoProceso = new PlanoProceso();
                        planoProceso.CargarDatos(idProceso);

                        if (planoProceso.TieneFilas())
                        {
                            planoProceso.Fila().ModificarCelda("requisicion_compra", idReq);
                            planoProceso.GuardarDatos();
                        }

                        MaterialProyecto mat = new MaterialProyecto();
                        mat.CargarDatos(idReq);

                        string msg = "Se creó la requisición de compra #" + idReq.ToString();
                        msg += " con el número de parte " +  procesoInsertado.Celda("proceso").ToString().Replace(' ','-') + "-" + "ID" + 
                        procesoInsertado.Celda("plano").ToString().PadLeft(7,'0') + "-" +
                        "PROC" + procesoInsertado.Celda("id");
                        msg += ", comunícate con compras para dar seguimiento.";
                        MessageBox.Show(msg);
                    }
                }

                if(CmbCategorias.Text == "TRATAMIENTO")
                {
                    p.Fila().ModificarCelda("estatus", "PENDIENTE DE TRATAMIENTO");
                    p.Fila().ModificarCelda("fecha_terminado", DateTime.Now);
                    p.GuardarDatos();
                }
            }

            if (!ProcesoCero)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                if (ChkDependencia.Enabled && !ChkDependencia.Checked)
                {

                }
                else
                {
                    modificarInformacion();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }

            //Cambiar estatus a "FABRICADO" si la categoria es inspeccion y el proceso es inspeccion de fabricacion
            if (CmbCategorias.Text == "INSPECCION" && CmbProcesos.Text == "INSPECCION DE FABRICACION")
            {
                PlanoProyecto planoProyecto = new PlanoProyecto();
                planoProyecto.CargarDatos(IdPlano);
                if (planoProyecto.TieneFilas())
                {
                    planoProyecto.Fila().ModificarCelda("estatus", "FABRICADO");
                    planoProyecto.Fila().ModificarCelda("fecha_fabricacion_terminada", DateTime.Now);
                    planoProyecto.GuardarDatos();

                }
            }
        }        

        public void modificarInformacion()
        {
            MaquinaHerramienta maquina = new MaquinaHerramienta();
            maquina.SeleccionarNombre(CmbAsignacion.Text);
            PlanoProceso procesoPlano = new PlanoProceso();

            procesoPlano.CargarProceso(IdProceso);
            procesoPlano.Fila().ModificarCelda("proceso", CmbProcesos.Text);
            procesoPlano.Fila().ModificarCelda("maquina", CmbAsignacion.Text);

            if (maquina.TieneFilas())
            {
                procesoPlano.Fila().ModificarCelda("programador", maquina.Fila().Celda("programador"));
                procesoPlano.Fila().ModificarCelda("operador", maquina.Fila().Celda("operador"));
            }

            if (ChkDependencia.Enabled && ChkDependencia.Checked)
                ProcesoAnterior = 0;

            procesoPlano.Fila().ModificarCelda("comentarios", TxtComentarios.Text);
            procesoPlano.Fila().ModificarCelda("proceso_anterior", ProcesoAnterior);

            procesoPlano.GuardarDatos();
        }

        private void CmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProcesos(CmbCategorias.Text);
            HabilitarBoton();
            //if(IdProceso != 0)
            if(DgvProcesoAnterior.Rows.Count > 0)
                LblProcesoAnterior.Text = "SELECCIONE EL PROCESO ANTERIOR";
            DgvProcesoAnterior.ClearSelection();
        }

        private void CmbProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CargarMaquinasHerramientas(CmbProcesos.Text);
            HabilitarBoton();
            //if (IdProceso != 0)
            if (DgvProcesoAnterior.Rows.Count > 0)
                LblProcesoAnterior.Text = "SELECCIONE EL PROCESO ANTERIOR";
            DgvProcesoAnterior.ClearSelection();           
        }
       
        private void CmbMaquinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarBoton();
           // if (IdProceso != 0)
            if (DgvProcesoAnterior.Rows.Count > 0)
                LblProcesoAnterior.Text = "SELECCIONE EL PROCESO ANTERIOR";
            DgvProcesoAnterior.ClearSelection();
          
        }      

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);   
        }

        private void DgvProcesoAnterior_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                ProcesoAnterior = Convert.ToInt32(DgvProcesoAnterior.SelectedRows[0].Cells["id"].Value);
                LblProcesoAnterior.Text = "PROCESO ANTERIOR " + ProcesoAnterior.ToString();
                BtnAgregar.Enabled = !CmbCategorias.Text.Equals("") && !CmbProcesos.Text.Equals("") && !CmbAsignacion.Text.Equals("");
            }
        }

        private void ChkDependencia_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkDependencia.Checked)
            {
                DgvProcesoAnterior.Enabled = true;
                DgvProcesoAnterior.Rows.Clear();
                DgvProcesoAnterior.Refresh();
                CargarProcesoAnterior();
                LblProcesoAnterior.Text = "SELECCIONE EL PROCESO ANTERIOR";
                BtnAgregar.Enabled = false;
            }
            else
            {
                DgvProcesoAnterior.Rows.Clear();
                DgvProcesoAnterior.Refresh();
                DgvProcesoAnterior.Enabled = false;
                LblProcesoAnterior.Text = "EDITAR DEPENDENCIA 0";
                BtnAgregar.Enabled = true;
            }
        }   
    }
}
