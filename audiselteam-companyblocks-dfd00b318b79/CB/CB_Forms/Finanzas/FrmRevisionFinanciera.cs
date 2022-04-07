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
using System.Globalization;
using LiveCharts.Helpers;

namespace CB
{
    public partial class FrmRevisionFinanciera : Form
    {
        BindingSource ProyectoBinding = new BindingSource();
        BindingSource ProveedoresBinding = new BindingSource();
        bool CambiarIndice = false;
        string Desde = Convert.ToDateTime("2019-08-01").Date.ToString();

        public FrmRevisionFinanciera()
        {
            InitializeComponent();
        }

        private void FrmRevisionFinanciera_Load(object sender, EventArgs e)
        {
            NumLimite.Visible = false;
            LblLimite.Visible = false;
            //BarraProgresoAsignaciones.Visible = true;
            
            DTdesde.Value = Convert.ToDateTime(DateTime.Now.Year + "-01-01");
            DThasta.Value = Convert.ToDateTime(DateTime.Now).AddDays(30);

            PanelDesde.Visible = false;
            CmbEstatus.SelectedIndex = 0;
            CargarProyecto();
            CargarProveedores();
        }

        private void CargarProyecto()
        {
            ProyectoBinding.Clear();

            string estatusFinanciero = string.Empty;
            if (CmbEstatus.Text == null || CmbEstatus.Text == "PENDIENTE" || CmbEstatus.Text == "")
                estatusFinanciero = "PENDIENTE";
            else
                estatusFinanciero = CmbEstatus.Text;

            ProyectoBinding.Add
            (
                new
                {
                    Text = "TODOS",
                    Value = "0"
                }
            );

            Proyecto.Modelo().ProyectosEnRevisionFinanciera(estatusFinanciero).ForEach(delegate(Fila f)
            {
                string strProyecto = Convert.ToDecimal(f.Celda("proyecto")).ToString("F2") + " - " + f.Celda("nombre").ToString();
                ProyectoBinding.Add
                (
                    new
                    {
                        Text = strProyecto,
                        Value = f.Celda("proyecto").ToString()
                    }
                );
            });

            Cmbproyecto.DisplayMember = "Text";
            Cmbproyecto.ValueMember = "Value";
            Cmbproyecto.DataSource = ProyectoBinding;
            Cmbproyecto.Text = "TODOS";
        }

        private void CargarProveedores()
        {
            ProveedoresBinding.Clear();

            string estatusFinanciero = string.Empty;
            if (CmbEstatus.Text == null || CmbEstatus.Text == "PENDIENTE" || CmbEstatus.Text == "")
                estatusFinanciero = "PENDIENTE";
            else
                estatusFinanciero = CmbEstatus.Text;

            ProveedoresBinding.Add
            (
                new
                {
                    Text = "TODOS",
                    Value = "0"
                }
            );

            MaterialProyecto.Modelo().MaterialFinanzasProveedores(estatusFinanciero).ForEach(delegate(Fila f)
            {
                ProveedoresBinding.Add
                (
                    new
                    {
                        Text = f.Celda("proveedor_nombre").ToString(),
                        Value = f.Celda("proveedor").ToString()
                    }
                );
            });

            CmbProveedor.DisplayMember = "Text";
            CmbProveedor.ValueMember = "Value";
            CmbProveedor.DataSource = ProveedoresBinding;
            CmbProveedor.Text = "TODOS";
        }

        private void cargarInformacion(string proy,string estatus, string prov, int limite, DateTime desde, DateTime hasta)
        {
            DgvCotizacion.Rows.Clear();
            string cantidad = string.Empty;

            string estatusFinanciero = string.Empty;
            if (estatus == null || estatus == "PENDIENTE" || estatus == "")
                estatusFinanciero = "PENDIENTE";

            Proyecto materialEnProyectos = new Proyecto();
            materialEnProyectos.ProyectosEnMaterial(proy, estatusFinanciero, prov, desde, hasta).ForEach(delegate(Fila f)
            {
                if (f.Celda("tipo_venta").ToString() == "POR PIEZA")
                    cantidad = f.Celda("total") + " PIEZA(S)";
                else
                    cantidad = f.Celda("total") + " PAQUETE(S) DE " + Convert.ToInt32(f.Celda("piezas_paquete")).ToString() + " PIEZA(S) C/U";

                CultureInfo curr = CultureInfo.GetCultureInfo("en-US");

                switch (f.Celda("moneda").ToString())
                {
                    case "MXN":
                        curr = CultureInfo.GetCultureInfo("es-MX");
                        break;
                    case "USD":
                        curr = CultureInfo.GetCultureInfo("en-US");
                        break;
                    case "EUR":
                        curr = CultureInfo.GetCultureInfo("en-FR");
                        break;
                }

                string fechaLimite = string.Empty;

                if (f.Celda("fecha_limite") != null)
                    fechaLimite = Global.FechaATexto(f.Celda("fecha_limite").ToString(), false);

                DgvCotizacion.Rows.Add
               (
                   f.Celda("id").ToString(),
                   f.Celda("numero_parte").ToString(),
                   f.Celda("categoria").ToString(),
                   Convert.ToDecimal(f.Celda("proyecto")).ToString("F2") + " " + f.Celda("nombre_proyecto").ToString(),
                   f.Celda("proveedor_nombre").ToString(),
                   f.Celda("requisitor").ToString(),
                   cantidad.ToString(),
                   // Convert.ToDecimal(f.Celda("precio_unitario")).ToString("C", CultureInfo.CurrentCulture) + " " + f.Celda("moneda").ToString(),
                   string.Format(curr, "{0:C}", Convert.ToDecimal(f.Celda("precio_unitario"))) + " " + f.Celda("moneda").ToString(),
                   string.Format(curr, "{0:C}", (Convert.ToInt32(f.Celda("total")) * Convert.ToDecimal(f.Celda("precio_unitario")))) + " " + f.Celda("moneda").ToString(),
                   fechaLimite
               );
            });
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            aceptarToolStripMenuItem.Enabled = (CmbEstatus.Text == "PENDIENTE" || CmbEstatus.Text == "DETENIDO");
            rechazarToolStripMenuItem.Enabled = (CmbEstatus.Text == "PENDIENTE");
            rechazarToolStripMenuItem.Visible = (CmbEstatus.Text == "PENDIENTE");
        }

        private void aceptarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idReq = Convert.ToInt32(DgvCotizacion.SelectedRows[0].Cells["id_req"].Value);

            MaterialProyecto mat = new MaterialProyecto();
            mat.CargarDatos(idReq);
            if(mat.TieneFilas())
            {
                mat.Fila().ModificarCelda("estatus_financiero", "AUTORIZADO");
                mat.Fila().ModificarCelda("estatus_compra", "LISTO PARA ORDENAR");
                mat.Fila().ModificarCelda("fecha_revision_financiera", DateTime.Now);
                mat.Fila().ModificarCelda("usuario_aprobacion_financiera", Global.UsuarioActual.Fila().Celda("id"));
                mat.GuardarDatos();

                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@idMaterial", mat.Fila().Celda("id"));

                MaterialProyectoKpi materialkpi = new MaterialProyectoKpi();
                materialkpi.SeleccionarDatos("id_material_proyecto=@idMaterial", parametros);
                if (materialkpi.TieneFilas())
                {
                    materialkpi.Fila().ModificarCelda("fecha_listo_ordenar", DateTime.Now);
                    materialkpi.GuardarDatos();
                }
                else
                {
                    Fila insertaMaterialKpi = new Fila();
                    insertaMaterialKpi.AgregarCelda("id_material_proyecto", mat.Fila().Celda("id"));
                    insertaMaterialKpi.AgregarCelda("fecha_listo_ordenar", DateTime.Now);
                    materialkpi.Insertar(insertaMaterialKpi);
                }
                //cargarInformacion(0);
                DgvCotizacion.Rows.Clear();

                if (PanelDesde.Visible)
                    Desde = DTdesde.Value.ToString();

                string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.Text,
                    CmbProveedor.Text,
                    "0",
                    Desde,
                    DThasta.Value.ToString()
                };

                if (!BkgCargarInformacion.IsBusy)
                {
                    DgvCotizacion.Rows.Clear();
                    BkgCargarInformacion.RunWorkerAsync(argumentos);
                }
            }
        }

        private void rechazarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idReq = Convert.ToInt32(DgvCotizacion.SelectedRows[0].Cells["id_req"].Value);

            MaterialProyecto mat = new MaterialProyecto();
            mat.CargarDatos(idReq);
            if (mat.TieneFilas())
            {
                Fila filaInformacion = new Fila();
                mat.Fila().ModificarCelda("estatus_financiero", "DETENIDO");
                mat.Fila().ModificarCelda("estatus_compra", "COMPRA DETENIDA");
                mat.Fila().ModificarCelda("fecha_revision_financiera", DateTime.Now);
                mat.Fila().ModificarCelda("usuario_aprobacion_financiera", Global.UsuarioActual.Fila().Celda("id"));
                Usuario usuario = new Usuario();
                usuario.BuscarPorNombre(mat.Fila().Celda("requisitor").ToString());
                if (usuario.TieneFilas())
                {
                    filaInformacion.AgregarCelda("requisitor_id", usuario.Fila().Celda<int>("id"));
                    filaInformacion.AgregarCelda("nombre_requisitor", mat.Fila().Celda("requisitor"));
                    filaInformacion.AgregarCelda("numero_parte", mat.Fila().Celda("numero_parte"));
                    filaInformacion.AgregarCelda("correo", usuario.Fila().Celda("correo"));
                    Proyecto proyecto = new Proyecto();
                    proyecto.CargarDatos(Convert.ToDecimal(mat.Fila().Celda("proyecto")));
                    if (proyecto.TieneFilas() && proyecto.Fila().Celda("liderproyecto") != null)
                    {
                        usuario.CargarDatos(proyecto.Fila().Celda<int>("liderproyecto"));
                        filaInformacion.AgregarCelda("lider", usuario.NombreCompleto());
                        filaInformacion.AgregarCelda("lider_correo", usuario.Fila().Celda("correo"));
                    }
                    else
                    {
                        filaInformacion.AgregarCelda("lider","N/A");
                        filaInformacion.AgregarCelda("lider_correo", "N/A");
                    }

                    RfqConcepto concepto = new RfqConcepto();
                    concepto.SeleccionarRequisitorDeRfq(mat.Fila().Celda("numero_parte").ToString(), mat.Fila().Celda<int>("rfq_concepto"));
                    if(concepto.TieneFilas())
                    {
                        usuario.BuscarPorNombre(concepto.Fila().Celda("usuario").ToString());
                        filaInformacion.AgregarCelda("requisitor", concepto.Fila().Celda("usuario").ToString());
                        filaInformacion.AgregarCelda("requisitor_correo", usuario.Fila().Celda("correo"));
                    }
                    else
                    {
                        filaInformacion.AgregarCelda("requisitor", "N/A");
                        filaInformacion.AgregarCelda("requisitor_correo", "N/A");
                    }

                    CmbEstatus.Enabled = false;

                    BkgEnviarCorreo.RunWorkerAsync(filaInformacion);
                }
                mat.GuardarDatos();
                CmbEstatus.Text = "DETENIDO";

                DgvCotizacion.Rows.Clear();
               /* BarraProgresoAsignaciones.Value =0;
                BarraProgresoAsignaciones.Visible = true;*/
                LblEstatusAsignaciones.Text = "Descargando información...";

                if (PanelDesde.Visible)
                    Desde = DTdesde.Value.ToString();

                string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.Text,
                    CmbProveedor.Text,
                    "0",
                    Desde,
                    DThasta.Value.ToString()
                };

                if (!BkgCargarInformacion.IsBusy)
                {
                    DgvCotizacion.Rows.Clear();
                    BkgCargarInformacion.RunWorkerAsync(argumentos);
                }
            }
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int limite = 0;

            NumLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");
            LblLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");

            if (CmbEstatus.Text != "PENDIENTE")
                limite = Convert.ToInt32(NumLimite.Value);

            /*BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = true;*/
            LblEstatusAsignaciones.Text = "Descargando información...";
            DgvCotizacion.Columns["fecha_limite_para_ordenar"].Visible = (CmbEstatus.Text == "PENDIENTE");

            CmbEstatus.Enabled = false;
            Cmbproyecto.Enabled = false;
            CmbProveedor.Enabled = false;
            DThasta.Enabled = false;
            BtnSalir.Enabled = false;
            NumLimite.Enabled = false;

            CargarProyecto();
            CargarProveedores();
            DgvCotizacion.Rows.Clear();

            if (PanelDesde.Visible)
                Desde = DTdesde.Value.ToString();

            string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.Text,
                    CmbProveedor.Text,
                    limite.ToString(),
                    Desde,
                    DThasta.Value.ToString()
                };

            if (!BkgCargarInformacion.IsBusy)
            {
                DgvCotizacion.Rows.Clear();
                BkgCargarInformacion.RunWorkerAsync(argumentos);
            }
            else
                BkgCargarInformacion.CancelAsync();
        }

        private void DgvCotizacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DateTime fechaLimite;
            try
            {
                fechaLimite = Convert.ToDateTime(DgvCotizacion.Rows[e.RowIndex].Cells["fecha_limite_para_ordenar"].Value);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error con fecha codigo 3 " + ex.ToString());
                return;
            }

            if (fechaLimite < DateTime.Now.Date)
            {
                DgvCotizacion.Rows[e.RowIndex].Cells["fecha_limite_para_ordenar"].Style.BackColor = Color.Red;
                DgvCotizacion.Rows[e.RowIndex].Cells["fecha_limite_para_ordenar"].Style.ForeColor = Color.White;
            }
            else
            {
                if(fechaLimite.AddDays(-1) == DateTime.Now.Date || fechaLimite.AddDays(-2) == DateTime.Now.Date || fechaLimite.AddDays(-3) == DateTime.Now.Date || DateTime.Now.Date == fechaLimite)
                {
                    DgvCotizacion.Rows[e.RowIndex].Cells["fecha_limite_para_ordenar"].Style.BackColor = Color.Yellow;
                    DgvCotizacion.Rows[e.RowIndex].Cells["fecha_limite_para_ordenar"].Style.ForeColor = Color.Black;
                }
            }
        }

        private void NumLimite_ValueChanged(object sender, EventArgs e)
        {
            if (!CambiarIndice)
                return;

            if (PanelDesde.Visible)
                Desde = DTdesde.Value.ToString();

            //cargarInformacion(Convert.ToInt32(NumLimite.Value));
            string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.Text,
                    CmbProveedor.Text,
                    NumLimite.Value.ToString(),
                    Desde,
                    DThasta.Value.ToString()
                };

            if (!BkgCargarInformacion.IsBusy)
            {
                DgvCotizacion.Rows.Clear();
                BkgCargarInformacion.RunWorkerAsync(argumentos);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BkgEnviarCorreo_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Fila informacion = (Fila)e.Argument;
                List<string> copias = new List<string>();

                if(informacion.Celda("lider").ToString() != "N/A")
                    copias.Add(informacion.Celda("lider_correo").ToString());

                if(informacion.Celda("requisitor").ToString() != "N/A")
                    copias.Add(informacion.Celda("requisitor_correo").ToString());
            
                Global.EnviarCorreo
                (
                    "Material detenido por finanzas",
                    "El material " + informacion.Celda("numero_parte") + " ha sido detenido, finanzas trabajará para asignar presupuesto para la compra.",
                    informacion.Celda("correo").ToString(),
                    copias
                );

                e.Result = null;
            }
            catch
            {
                e.Result = "Ha ocurrido un error, el correo no pudo ser enviado.";
            }
        }

        private void BkgEnviarCorreo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Result != null)
                MessageBox.Show(e.Result.ToString());

            CmbEstatus.Enabled = true;            
        }

        private void DgvCotizacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmDetallesMaterialProyecto detallesMaterial = new FrmDetallesMaterialProyecto(Convert.ToInt32(DgvCotizacion.Rows[e.RowIndex].Cells["id_req"].Value));
            detallesMaterial.ShowDialog();
        }

        private void BkgCargarInformacion_DoWork(object sender, DoWorkEventArgs e)
        {
            Application.DoEvents();
            string[] argumentos = (string[])e.Argument;
            string estatus = argumentos[0];
            string proyecto = argumentos[1];
            string proveedor = argumentos[2];
            int limite = Convert.ToInt32(argumentos[3]);
            DateTime desde;
            DateTime hasta;

            try
            {
                desde = Convert.ToDateTime(argumentos[4]);
                hasta = Convert.ToDateTime(argumentos[5]);
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Error con fecha " + ex);
                return;
            }
           
            
            string cantidad = string.Empty;

            string estatusFinanciero = string.Empty;
            if (estatus == null || estatus == "PENDIENTE" || estatus == "")
                estatusFinanciero = "PENDIENTE";
            else
                estatusFinanciero = estatus;

            int avance = 0;
            Proyecto materialEnProyectos = new Proyecto();

            switch (estatus)
            {
                case "PENDIENTE":
                    materialEnProyectos.ProyectosEnMaterial(proyecto, estatusFinanciero, proveedor, desde, hasta);
                    break;
                default:
                    materialEnProyectos.ProyectosEnMaterialAutorizadoCancelado(proyecto, estatusFinanciero, proveedor, desde, hasta, limite);
                    break;
            }

            materialEnProyectos.Filas().ForEach(delegate(Fila f)
            {
                avance++;
                int porcentaje = Global.CalcularPorcentaje(avance, materialEnProyectos.Filas().Count);
                BkgCargarInformacion.ReportProgress(porcentaje, f);
            });
        }

        private void BkgCargarInformacion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Fila f = (Fila)e.UserState;
            string cantidad = string.Empty;

            if (f.Celda("tipo_venta").ToString() == "POR PIEZA")
                cantidad = f.Celda("total") + " PIEZA(S)";
            else
                cantidad = f.Celda("total") + " PAQUETE(S) DE " + Convert.ToInt32(f.Celda("piezas_paquete")).ToString() + " PIEZA(S) C/U";

            CultureInfo curr = CultureInfo.GetCultureInfo("en-US");

            switch (f.Celda("moneda").ToString())
            {
                case "MXN":
                    curr = CultureInfo.GetCultureInfo("es-MX");
                    break;
                case "USD":
                    curr = CultureInfo.GetCultureInfo("en-US");
                    break;
                case "EUR":
                    curr = CultureInfo.GetCultureInfo("en-FR");
                    break;
            }

            string fechaLimite = string.Empty;
            if (f.Celda("fecha_limite").ToString() != null)
                fechaLimite = Global.FechaATexto(f.Celda("fecha_limite").ToString(), false);

            DgvCotizacion.Rows.Add
            (
                f.Celda("id").ToString(),
                f.Celda("numero_parte").ToString(),
                f.Celda("categoria").ToString(),
                f.Celda("proyecto") + " " + f.Celda("nombre_proyecto").ToString(),
                f.Celda("proveedor_nombre").ToString(),
                f.Celda("requisitor").ToString(),
                cantidad.ToString(),
                //Convert.ToDecimal(f.Celda("precio_unitario")).ToString("C", CultureInfo.CurrentCulture) + " " + f.Celda("moneda").ToString(),
                string.Format(curr,"{0:C}",Convert.ToDecimal(f.Celda("precio_unitario"))) + " " + f.Celda("moneda").ToString(),
                //(Convert.ToInt32(f.Celda("total")) * Convert.ToDecimal(f.Celda("precio_unitario"))).ToString("C", CultureInfo.CurrentCulture) + " " + f.Celda("moneda").ToString(),
                string.Format(curr, "{0:C}", (Convert.ToInt32(f.Celda("total")) * Convert.ToDecimal(f.Celda("precio_unitario")))) + " " + f.Celda("moneda").ToString(),
                fechaLimite
            );

            LblEstatusAsignaciones.Text = "Descargando información...[" + e.ProgressPercentage + "]";
            LblEstatusAsignaciones.Update();
        }


        private void BkgCargarInformacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CmbEstatus.Enabled = true;
            Cmbproyecto.Enabled = true;
            CmbProveedor.Enabled = true;
            DThasta.Enabled = true;
            BtnSalir.Enabled = true;
            NumLimite.Enabled = true;
            LblEstatusAsignaciones.Text = "Datos descargados";

            if (!CambiarIndice)
                CambiarIndice = true;

            LblRegistros.Text = DgvCotizacion.RowCount.ToString();

        }

        private void Cmbproyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CambiarIndice)
                return;

            int limite = 0;

            NumLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");
            LblLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");
            PanelDesde.Visible = !(CmbEstatus.Text == "PENDIENTE");

            if (CmbEstatus.Text != "PENDIENTE")
                limite = Convert.ToInt32(NumLimite.Value);

            /*BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = true;*/
            LblEstatusAsignaciones.Text = "Descargando información...";

            CmbEstatus.Enabled = false;
            Cmbproyecto.Enabled = false;
            CmbProveedor.Enabled = false;
            DThasta.Enabled = false;
            BtnSalir.Enabled = false;
            NumLimite.Enabled = false;

            CargarProveedores();

            if (PanelDesde.Visible)
                Desde = DTdesde.Value.ToString();

            //cargarInformacion(limite);
            string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.SelectedText.ToString(),
                    CmbProveedor.SelectedText.ToString(),
                    limite.ToString(),
                    Desde,
                    DThasta.Value.ToString()
                };

            if (!BkgCargarInformacion.IsBusy)
            {
                DgvCotizacion.Rows.Clear();
                BkgCargarInformacion.RunWorkerAsync(argumentos);
            }
        }

        private void CmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!CambiarIndice)
                return;

            int limite = 0;

            NumLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");
            LblLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");
            PanelDesde.Visible = !(CmbEstatus.Text == "PENDIENTE");

            /*BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = true;*/
            LblEstatusAsignaciones.Text = "Descargando información...";

            if (CmbEstatus.Text != "PENDIENTE")
                limite = Convert.ToInt32(NumLimite.Value);

            CmbEstatus.Enabled = false;
            Cmbproyecto.Enabled = false;
            CmbProveedor.Enabled = false;
            DThasta.Enabled = false;
            BtnSalir.Enabled = false;
            NumLimite.Enabled = false;

            DgvCotizacion.Rows.Clear();
            
            if (PanelDesde.Visible)
                Desde = DTdesde.Value.ToString();
            else
                Desde = "1-8-2019";

            if (PanelDesde.Visible)
                Desde = DTdesde.Value.ToString();

            //cargarInformacion(limite);
            string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.Text,
                    CmbProveedor.Text,
                    limite.ToString(),
                    Desde,
                    DThasta.Value.ToString()
                };

            if (!BkgCargarInformacion.IsBusy)
            {
                DgvCotizacion.Rows.Clear();
                BkgCargarInformacion.RunWorkerAsync(argumentos);
            }
        }

        private void DTdesde_ValueChanged(object sender, EventArgs e)
        {
            if (!CambiarIndice)
                return;

            int limite = 0;

            NumLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");
            LblLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");

            if (CmbEstatus.Text != "PENDIENTE")
                limite = Convert.ToInt32(NumLimite.Value);

            /*BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = true;*/
            LblEstatusAsignaciones.Text = "Descargando información...";

            CmbEstatus.Enabled = false;
            Cmbproyecto.Enabled = false;
            CmbProveedor.Enabled = false;
            DThasta.Enabled = false;
            BtnSalir.Enabled = false;
            NumLimite.Enabled = false;

            DgvCotizacion.Rows.Clear();

            if (PanelDesde.Visible)
                Desde = DTdesde.Value.ToString();

            //cargarInformacion(limite);
            string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.Text,
                    CmbProveedor.Text,
                    limite.ToString(),
                    Desde,
                    DThasta.Value.ToString()
                };

            if (!BkgCargarInformacion.IsBusy)
            {
                DgvCotizacion.Rows.Clear();
                BkgCargarInformacion.RunWorkerAsync(argumentos);                
            }
        }

        private void DThasta_ValueChanged(object sender, EventArgs e)
        {
            if (!CambiarIndice)
                return;

            int limite = 0;

            NumLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");
            LblLimite.Visible = !(CmbEstatus.Text == "PENDIENTE");

            if (CmbEstatus.Text != "PENDIENTE")
                limite = Convert.ToInt32(NumLimite.Value);

            /*BarraProgresoAsignaciones.Value = 0;
            BarraProgresoAsignaciones.Visible = true;*/
            LblEstatusAsignaciones.Text = "Descargando información...";

            CmbEstatus.Enabled = false;
            Cmbproyecto.Enabled = false;
            CmbProveedor.Enabled = false;
            DThasta.Enabled = false;
            BtnSalir.Enabled = false;
            NumLimite.Enabled = false;

            DgvCotizacion.Rows.Clear();

            if (PanelDesde.Visible)
                Desde = DTdesde.Value.ToString();

            //cargarInformacion(limite);
            string[] argumentos = new string[]{
                    CmbEstatus.Text,
                    Cmbproyecto.Text,
                    CmbProveedor.Text,
                    limite.ToString(),
                    Desde,
                    DThasta.Value.ToString()
                };

            if (!BkgCargarInformacion.IsBusy)
            {
                DgvCotizacion.Rows.Clear();
                BkgCargarInformacion.RunWorkerAsync(argumentos);
            }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CmbEstatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PanelDesde.Visible = !(CmbEstatus.Text == "PENDIENTE");
        }
    }
}
