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
    public partial class FrmSeleccionarFechaMetasCompras : Form
    {
        int IdReq = 0;
        decimal IdProyecto = 0;
        DateTime FechaInicio;
        DateTime FechaFin;
        Proceso ProcesoMeta = new Proceso();  
        Proceso Proceso = new Proceso();
           

        public FrmSeleccionarFechaMetasCompras(int idReq, decimal idProyecto, DateTime fechaInicio, DateTime fechaFin)
        {
            InitializeComponent();
            IdReq = idReq;
            IdProyecto = idProyecto;
            try
            {
                FechaInicio = fechaInicio;
                FechaFin = fechaFin;
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un problema con las fechas del proceso de compras, porfavor verifica que la fecha fin y fecha inicio sea vigentes");
                Close();
            }
            BtnAceptar.Enabled = false;
        }

        private void FrmSeleccionarFechaMetasCompras_Load(object sender, EventArgs e)
        {
            Proceso.SeleccionarNombre("COMPRAS");
            if (!Proceso.TieneFilas())
                Close();

            ProcesoMeta.CargarDatos(Convert.ToInt32(Proceso.Fila().Celda("id")));

            CargarResponsables();
            CargarCoordinadores();
            CargarEntregable();

            TxtProceso.Text = ProcesoMeta.Fila().Celda("id").ToString().PadLeft(3, '0') + " - " + ProcesoMeta.Fila().Celda("nombre").ToString();
            TxtFechaSolicitud.Text = Global.FechaATexto(DateTime.Now, false);
            LblMensaje.Text = "Es necesario colocar una meta de compra para la requisición #" + IdReq.ToString().PadLeft(6, '0');
            TxtFechaPromesa.Text = Global.FechaATexto(DtpFechaMeta.Value.Date, false);
            DtpFechaMeta.MinDate = FechaInicio;
            DtpFechaMeta.MaxDate = FechaFin;
        }

        public void CargarResponsables()
        {
            Rol puestoResponsable = new Rol();
            puestoResponsable.CargarDatos(Convert.ToInt32(ProcesoMeta.Fila().Celda("puesto_responsable")));

            CmbResponsable.Items.Clear();
            Usuario.Modelo().SeleccionarUsuariosDeRolConAlmacen(puestoResponsable.Fila().Celda("rol").ToString(),
            Convert.ToInt32(ProcesoMeta.Fila().Celda("nivel_responsable"))).ForEach(delegate(Fila f)
            {
                CmbResponsable.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
        }

        public void CargarCoordinadores()
        {
            CmbCoordinador.Items.Clear();
            Usuario.Modelo().SeleccionarRolActivos("COORDINADOR DE OPERACIONES").ForEach(delegate(Fila f)
            {
                CmbCoordinador.Items.Add(f.Celda("id") + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
        }

        public void CargarEntregable()
        {
            MaterialProyecto mat = new MaterialProyecto();

            mat.CargarDatos(IdReq).ForEach(delegate(Fila f)
            {
                string strEntr = "Req. " + f.Celda("id").ToString().PadLeft(5, '0');
                strEntr += " | " + f.Celda("fabricante").ToString();
                strEntr += " | " + f.Celda("numero_parte").ToString();
                strEntr += " | " + f.Celda("total").ToString();

                if (f.Celda("tipo_venta").ToString() == "POR PIEZA")
                    strEntr += " pieza(s)";
                else
                    strEntr += " paquete(s)";

                DgvEntregables.Rows.Add(f.Celda("id"), strEntr);
            });
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if(Proceso.TieneFilas())
            {
                int idMeta = 0;
                string msg = string.Empty;
                DateTime fechaMeta = DtpFechaMeta.Value;
                Meta meta = new Meta();
                meta.BuscarMetaEnMetaCompra(IdProyecto, Proceso.Fila().Celda<int>("id"), DtpFechaMeta.Value.Date);
                if (!meta.TieneFilas())
                {
                    //crear meta
                    Fila nuevaMeta = new Fila();
                    nuevaMeta.AgregarCelda("proyecto", IdProyecto);
                    nuevaMeta.AgregarCelda("proceso", Proceso.Fila().Celda("id"));
                    nuevaMeta.AgregarCelda("tipo_entregable", "MATERIAL DE REQUISICION");
                    nuevaMeta.AgregarCelda("requisitor", Global.UsuarioActual.Fila().Celda("id"));
                    nuevaMeta.AgregarCelda("coordinador", Convert.ToInt32(CmbCoordinador.Text.Split('-')[0]));
                    nuevaMeta.AgregarCelda("responsable", Convert.ToInt32(CmbResponsable.Text.Split('-')[0]));
                    nuevaMeta.AgregarCelda("fecha_solicitud", DateTime.Now);
                    nuevaMeta.AgregarCelda("fecha_promesa", DtpFechaMeta.Value.Date);
                    nuevaMeta.AgregarCelda("fecha_autorizacion", DateTime.Now);
                    nuevaMeta.AgregarCelda("estatus_autorizacion", "AUTORIZADO");
                    Fila obj = Meta.Modelo().Insertar(nuevaMeta);

                    idMeta = Convert.ToInt32(obj.Celda("id"));
                    msg = "Se ha creado la meta " + idMeta.ToString().PadLeft(6, '0') + " para la requisicion #" + IdReq.ToString().PadLeft(6, '0');
                }
                else
                {
                    idMeta = meta.Fila().Celda<int>("id");
                    msg = "La requisicion #" + IdReq.ToString().PadLeft(6, '0') + " ha sido añadida a la meta " + idMeta.ToString().PadLeft(6, '0');
                }

                MaterialProyecto material = new MaterialProyecto();
                material.CargarDatos(IdReq);
                if (material.TieneFilas())
                {
                    material.Filas().ForEach(delegate(Fila f)
                    {
                        f.ModificarCelda("meta", idMeta);
                        f.ModificarCelda("fecha_promesa_compras", DtpFechaMeta.Value);
                        f.ModificarCelda("estatus_compra", "EN REVISION FINANCIERA");

                        // deshabilitado SC. Nov 23... este codigo no debe llamarse aqui
                        //f.ModificarCelda("estatus_autorizacion", "AUTORIZADO");
                        //f.ModificarCelda("fecha_autorizacion", DateTime.Now);

                        DateTime fechaLimiteParaOrdenar = (DtpFechaMeta.Value.AddDays(-Convert.ToInt32(f.Celda("tiempo_entrega")))).AddDays(-3);
                        Dictionary<string, object> parametros = new Dictionary<string,object>();
                        parametros.Add("@idMaterial", f.Celda("id"));

                        MaterialProyectoKpi materialkpi = new MaterialProyectoKpi();
                        materialkpi.SeleccionarDatos("id_material_proyecto=@idMaterial", parametros);
                        if(materialkpi.TieneFilas())
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
                    material.GuardarDatos();
                }

                //agregar entregable
                Fila insertarEntregable = new Fila();
                insertarEntregable.AgregarCelda("meta", idMeta);
                insertarEntregable.AgregarCelda("tipo_entregable", "MATERIAL DE REQUISICION");
                insertarEntregable.AgregarCelda("id_entregable", IdReq);
                MetaEntregable.Modelo().Insertar(insertarEntregable);
                Meta.Modelo().ActualizarAvance(idMeta);

                MessageBox.Show(msg);
                Close();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DtpFechaMeta_ValueChanged(object sender, EventArgs e)
        {
            TxtFechaPromesa.Text = Global.FechaATexto(DtpFechaMeta.Value.Date, false);
        }

        private void CmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = (CmbCoordinador.Text != "" && CmbResponsable.Text != "");
        }
    }
}
