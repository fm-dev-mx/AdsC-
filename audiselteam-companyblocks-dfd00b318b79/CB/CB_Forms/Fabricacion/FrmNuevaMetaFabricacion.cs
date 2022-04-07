using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmNuevaMetaFabricacion : Ventana
    {
        decimal IdProyectoSeleccionado = 0;
        int IdResponsableSeleccionado = 0;
        int SubensambleSeleccionado = 0;
        int IdPlanoSeleccionado = 0;

        public FrmNuevaMetaFabricacion()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            PlanoProyecto pp = new PlanoProyecto();
            Fila meta = new Fila();
            meta.AgregarCelda("tipo_entregable", CmbTipoEntregable.Text);
            meta.AgregarCelda("entregable", CmbEntregable.Text);
            meta.AgregarCelda("fecha_promesa", DateFechaPromesa.Value);
            meta.AgregarCelda("fecha_solicitud", DateTime.Now);
            meta.AgregarCelda("requisitor", Global.UsuarioActual.Fila().Celda("id"));
            meta.AgregarCelda("responsable", IdResponsableSeleccionado);
            meta.AgregarCelda("estatus_compromiso", "SIN CONFIRMAR");
            meta.AgregarCelda("estatus_cumplimiento", "");
            meta.AgregarCelda("comentarios_responsable", "");
            int idMeta = Convert.ToInt32(MetaFabricacion.Modelo().Insertar(meta).Celda("id"));

            if (CmbTipoEntregable.Text == "MODULO")
            {
                Modulo mod = new Modulo();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@proyecto", IdProyectoSeleccionado);
                parametros.Add("@subensamble", SubensambleSeleccionado);

                mod.SeleccionarProyectoSubensamble(IdProyectoSeleccionado, SubensambleSeleccionado);
                pp.SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND estatus!='TERMINADO' AND estatus!='ENTREGADO'", parametros);

                if(mod.TieneFilas())
                {
                    mod.Fila().ModificarCelda("fecha_promesa_fabricacion", DateFechaPromesa.Value);                  
                    mod.GuardarDatos();
                }

                pp.Filas().ForEach(delegate(Fila f)
                {
                    f.ModificarCelda("fecha_promesa_fabricacion", DateFechaPromesa.Value);
                });
                pp.GuardarDatos();
            }
            else if (CmbTipoEntregable.Text == "PLANO")
            {
                SubensambleSeleccionado = 0;
                IdPlanoSeleccionado = Convert.ToInt32(CmbEntregable.Text.Split('-')[0]);

                pp.CargarDatos(IdPlanoSeleccionado);

                if(pp.TieneFilas())
                {
                    pp.Fila().ModificarCelda("fecha_promesa_fabricacion", DateFechaPromesa.Value);
                    pp.GuardarDatos();
                }
            }

            MetaFabricacion modificarMeta = new MetaFabricacion();
            modificarMeta.CargarDatos(idMeta);
            if (modificarMeta.TieneFilas())
            {
                modificarMeta.Fila().ModificarCelda("proyecto", IdProyectoSeleccionado);
                modificarMeta.Fila().ModificarCelda("subensamble", SubensambleSeleccionado);
                modificarMeta.Fila().ModificarCelda("plano", IdPlanoSeleccionado);
                modificarMeta.GuardarDatos();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void FrmNuevaMetaFabricacion_Load(object sender, EventArgs e)
        {
            CargarProyectos();
            CargarResponsables();
            DateFechaPromesa.MinDate = DateTime.Now;
        }

        public void CargarProyectos()
        {
            CmbProyecto.Items.Clear();
            Proyecto.Modelo().SeleccionarDatos("activo=1 ORDER BY id DESC").ForEach(delegate(Fila f)
            {
                CmbProyecto.Items.Add(Convert.ToDecimal(f.Celda("id")).ToString("F2").PadLeft(3, '0') + " - " + f.Celda("nombre"));
            });
        }

        private void CmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProyecto.Text != string.Empty)
            {
                IdProyectoSeleccionado = Convert.ToDecimal(CmbProyecto.Text.Split('-')[0]);
                CargarEntregables(CmbTipoEntregable.Text);
            }
            else IdProyectoSeleccionado = 0;
            ValidarDatos();
        }

        private void CmbTipoEntregable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEntregables(CmbTipoEntregable.Text);
            ValidarDatos();
        }

        public void CargarEntregables(string tipo)
        {
            switch(tipo)
            {
                case "MODULO":
                    CargarModulos(IdProyectoSeleccionado);
                    break;

                case "PLANO":
                    CargarPlanos(IdProyectoSeleccionado);
                    break;
            }
        }
        
        public void CargarModulos(decimal idProyecto)
        {
            Modulo mod = new Modulo();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", idProyecto);

            CmbEntregable.Items.Clear();
            mod.SeleccionarDatos("proyecto=@proyecto AND estatus_aprobacion='APROBADO'", parametros).ForEach(delegate(Fila f)
            {
                CmbEntregable.Items.Add("M" + idProyecto.ToString("F2").Replace('.', '_').PadLeft(6, '0') + "-" + f.Celda("subensamble").ToString().PadLeft(2, '0') + " - " + f.Celda("nombre"));
            });
        }

        public void CargarPlanos(decimal idProyecto)
        {
            string condiciones = string.Empty;
            condiciones += "estatus != 'TERMINADO' AND estatus != 'ENTREGADO' AND proyecto=@proyecto ORDER BY id ASC";
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", idProyecto);

            CmbEntregable.Items.Clear();
            PlanoProyecto.Modelo().SeleccionarDatos(condiciones, parametros).ForEach(delegate(Fila f)
            {
                CmbEntregable.Items.Add(f.Celda("id") + " - " + f.Celda("nombre_archivo"));
            });
        }

        public void CargarResponsables()
        {
            CmbResponsable.Items.Clear();
            Usuario.Modelo().SeleccionarRol("SUPERVISOR DE TOOL ROOM").ForEach(delegate(Fila f)
            {
                CmbResponsable.Items.Add(f.Celda("id").ToString().PadLeft(3, '0') + " - " + f.Celda("nombre") + " " + f.Celda("paterno"));
            });
        }

        public void ValidarDatos()
        {
            BtnCrear.Enabled = CmbProyecto.Text != string.Empty && CmbTipoEntregable.Text != string.Empty && CmbEntregable.Text != string.Empty && CmbResponsable.Text != string.Empty;
        }

        private void CmbEntregable_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
            if (CmbEntregable.Text == string.Empty)
                return;

            if (CmbTipoEntregable.Text == "MODULO")
            {
                SubensambleSeleccionado = Convert.ToInt32(CmbEntregable.Text.Split('-')[1]);
                IdPlanoSeleccionado = 0;
            }
            else if (CmbTipoEntregable.Text == "PLANO")
            {
                SubensambleSeleccionado = 0;
                IdPlanoSeleccionado = Convert.ToInt32(CmbEntregable.Text.Split('-')[0]);
            }
        }

        private void CmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbResponsable.Text != string.Empty)
            {
                IdResponsableSeleccionado = Convert.ToInt32(CmbResponsable.Text.Split('-')[0]);
            }
            ValidarDatos();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
