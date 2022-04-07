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
    public partial class FrmAgregarProcesoPlano2 : Form
    {
        public string CategoriaProceso = "";
        public string TipoAsignacion ="";
        public string TipoProceso = "";
        public string Comentarios = "";
        public int IdPlano = -1;
        public int NuevoOrden = 0;
        public int ProcesoAnterior = 0;
        public byte[] DatosPlano = null;

        int IdProcesoInsertado = 0;
        Fila ProcesoInsertado = null;
        string NumeroDeParteProceso = string.Empty;
        string DescripcionProceso = string.Empty;
        int IdRequisicionCreada = 0;
        PlanoProyecto planoProyecto = new PlanoProyecto();

        string rutaPlanoFtp = string.Empty;

        public FrmAgregarProcesoPlano2(int idPlano, int nuevoOrden, int procesoAnterior, byte[] datosPlano)
        {
            InitializeComponent();
            IdPlano = idPlano;
            NuevoOrden = nuevoOrden;
            ProcesoAnterior = procesoAnterior;
            DatosPlano = datosPlano;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            BtnAgregar.Enabled = false;
            BtnCancelar.Enabled = false;
            CategoriaProceso = CmbCategorias.Text;
            TipoProceso = CmbProcesos.Text;
            TipoAsignacion = CmbAsignacion.Text;
            Comentarios = TxtComentarios.Text;

            // ======================

            Fila nuevoProceso = new Fila();
            nuevoProceso.AgregarCelda("plano", IdPlano);
            nuevoProceso.AgregarCelda("proceso", TipoProceso);
            nuevoProceso.AgregarCelda("maquina", "N/A");
            nuevoProceso.AgregarCelda("programador", "N/A");
            nuevoProceso.AgregarCelda("operador", "N/A");
            nuevoProceso.AgregarCelda("comentarios", Comentarios);
            nuevoProceso.AgregarCelda("estatus", "PENDIENTE");
            nuevoProceso.AgregarCelda("proceso_anterior", ProcesoAnterior);
            nuevoProceso.AgregarCelda("requisicion_compra", 0);
            nuevoProceso.AgregarCelda("herramentista", 0);
            nuevoProceso.AgregarCelda("orden", NuevoOrden);

            ProcesoInsertado = PlanoProceso.Modelo().Insertar(nuevoProceso);
            IdProcesoInsertado = Convert.ToInt32(ProcesoInsertado.Celda("id"));
            PlanoProceso.Modelo().ReordenarProcesos(IdPlano);
            planoProyecto.CargarDatos(IdPlano);

            // La asignación se hace con proveedr
            // Se crea una requisición de compra
            if (TipoAsignacion == "PROVEEDOR")
            {
                LblStatus.Text = "Descargando plano...";
                LblStatus.Visible = true;
                Progreso.Value = 0;
                Progreso.Visible = true;
                BkgCrearRequisicionCompra.RunWorkerAsync();
            }
            else // cierra el dialogo solo cuando se trate de asignacion local, de otro modo cierra en el complete del backgroundworker
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FrmAgregarProcesoPlano2_Load(object sender, EventArgs e)
        {
            CargarCategorias();
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

        private void CmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProcesos(CmbCategorias.Text);
        }

        private void CmbProcesos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void CmbAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAgregar.Enabled = CmbCategorias.Text != string.Empty && CmbProcesos.Text != string.Empty && CmbAsignacion.Text != string.Empty;
        }

        private void BkgCrearRequisicionCompra_DoWork(object sender, DoWorkEventArgs e)
        {
            NumeroDeParteProceso = MaterialProyecto.CrearNNumeroParteProceso(IdPlano, CategoriaProceso, IdProcesoInsertado);
            DescripcionProceso = ProcesoInsertado.Celda("proceso").ToString() + " ACORDE AL PLANO #" + IdPlano + ". " + Comentarios;
            DatosPlano = ServidorFtp.DescargarPlano(IdPlano, FormatoArchivo.Pdf, BkgCrearRequisicionCompra, out rutaPlanoFtp);

            if(DatosPlano == null)
            {
                ArchivoPlano plano = new ArchivoPlano();
                plano.SeleccionarDePlano(IdPlano);

                if(plano.TieneFilas())
                    DatosPlano = (byte[])plano.Fila().Celda("archivo");
            }

            BkgCrearRequisicionCompra.ReportProgress(50, "Creando requisicion de compra...");
            IdRequisicionCreada = 
                MaterialProyecto
                .Modelo()
                .CrearRequisicionCompraFabricacion(planoProyecto, 
                                                   CategoriaProceso, 
                                                   MaterialProyecto.TablaMaterialRequisicion.ProcesoPlano, 
                                                   NumeroDeParteProceso, 
                                                   DescripcionProceso, true, 0, DatosPlano);

            // vincular el proceso de fabricacion con la requisicion de compra creada
            PlanoProceso proc = new PlanoProceso();
            proc.CargarDatos(IdProcesoInsertado);

            if (proc.TieneFilas())
            {
                proc.Fila().ModificarCelda("requisicion_compra", IdRequisicionCreada);
                proc.GuardarDatos();
            }
            BkgCrearRequisicionCompra.ReportProgress(100, "Requisicion creada correctamente!");
        }

        private void BkgCrearRequisicionCompra_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IdRequisicionCreada > 0)
            {
                MaterialProyecto mat = new MaterialProyecto();
                mat.CargarDatos(IdRequisicionCreada);

                string msg = "Se creó la requisición de compra #" + IdRequisicionCreada.ToString();
                msg += " con el número de parte " + ProcesoInsertado.Celda("proceso").ToString().Replace(' ', '-') + "-" + "ID" +
                ProcesoInsertado.Celda("plano").ToString().PadLeft(7, '0') + "-" +
                "PROC" + ProcesoInsertado.Celda("id");
                msg += ", comunícate con compras para dar seguimiento.";
                MessageBox.Show(msg);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void BkgCrearRequisicionCompra_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progreso.Value = e.ProgressPercentage;
            LblStatus.Text = e.UserState.ToString();
        }
    }
}
