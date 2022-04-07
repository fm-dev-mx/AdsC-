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
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace CB
{
    public partial class FrmSelectorFechaCompra : Form
    {
        string NombreProceso = string.Empty;
        int IdReq = 0;
        MaterialProyecto Material = new MaterialProyecto();
        

        public FrmSelectorFechaCompra(int idReq, string nombreProceso = "COMPRAS")
        {
            InitializeComponent();
            NombreProceso = nombreProceso;
            IdReq = idReq;
            Material.CargarDatos(IdReq);
        }

        private void FrmSelectorFechaCompra_Load(object sender, EventArgs e)
        {
            DtpFechaMeta.MinDate = DateTime.Now;

            Proceso proceso = new Proceso();
            proceso.SeleccionarNombre(NombreProceso);
            if (!proceso.TieneFilas())
                Close();

            Proceso procesoMeta = new Proceso();
            procesoMeta.CargarDatos(Convert.ToInt32(proceso.Fila().Celda("id")));

            TxtProceso.Text = procesoMeta.Fila().Celda("id").ToString().PadLeft(3, '0') + " - " + procesoMeta.Fila().Celda("nombre").ToString();
            TxtFechaSolicitud.Text = Global.FechaATexto(DateTime.Now, false);
        }

        private void DtpFechaMeta_ValueChanged(object sender, EventArgs e)
        {
            TxtFechaPromesa.Text = Global.FechaATexto(DtpFechaMeta.Value.Date, false);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            int idMeta = 0;
            string msg = string.Empty;
            DateTime fechaMeta = DtpFechaMeta.Value;

            Material.Filas().ForEach(delegate (Fila f)
            {
                f.ModificarCelda("meta", idMeta);
                f.ModificarCelda("fecha_promesa_compras", DtpFechaMeta.Value);
                f.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");

                DateTime fechaLimiteParaOrdenar = (DtpFechaMeta.Value.AddDays(-Convert.ToInt32(f.Celda("tiempo_entrega")))).AddDays(-3);
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idMaterial", f.Celda("id"));

                MaterialProyectoKpi materialkpi = new MaterialProyectoKpi();
                materialkpi.SeleccionarDatos("id_material_proyecto=@idMaterial", parametros);
                if (materialkpi.TieneFilas())
                {
                    materialkpi.Fila().ModificarCelda("fecha_meta_colocada", DateTime.Now);
                    materialkpi.Fila().ModificarCelda("fecha_limite_ordenar", fechaLimiteParaOrdenar);
                    materialkpi.GuardarDatos();
                }
                else
                {
                    Fila insertaMaterialKpi = new Fila();
                    insertaMaterialKpi.AgregarCelda("id_material_proyecto", f.Celda("id"));
                    insertaMaterialKpi.AgregarCelda("fecha_meta_colocada", DateTime.Now);
                    materialkpi.Fila().ModificarCelda("fecha_limite_ordenar", fechaLimiteParaOrdenar);
                    materialkpi.Insertar(insertaMaterialKpi);
                }
            });

            Material.GuardarDatos();

            MessageBox.Show("Se ha actualizado la fecha promesa de compra para el día " + TxtFechaPromesa.Text + " para la requisición " + IdReq + "");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Material.Filas().ForEach(delegate (Fila f)
            {
                f.ModificarCelda("meta", 0);
                f.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");
            });

            Material.GuardarDatos();
            DialogResult = DialogResult.OK;
            Close();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
