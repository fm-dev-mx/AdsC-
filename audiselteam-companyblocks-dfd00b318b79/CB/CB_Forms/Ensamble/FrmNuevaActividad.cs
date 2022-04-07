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
    public partial class FrmNuevaActividad : Ventana
    {
        private int IdActividad = 0;
        private string TipoActividad = "";

        public List<Filtro> Filtros = new List<Filtro>();
        ActividadEnsamble BuscadorActividad = new ActividadEnsamble();
        ActividadEnsamble NuevaActividad = new ActividadEnsamble();

        public FrmNuevaActividad(int actividad = 0, string tipo = "", List<Filtro> filtros = null)
        {
           // wrap
            IdActividad = actividad;
            TipoActividad = tipo;
            if (filtros != null)
                Filtros = filtros;
            InitializeComponent();
        }

        private void FrmNuevaActividad_Load_1(object sender, EventArgs e)
        {
            CargarProyecto();
            LlenarCmbTipo();
            if(IdActividad != 0)
            {
                if (CmbTipoActividad.Items.Contains(TipoActividad))
                    CmbTipoActividad.Text = TipoActividad;
            }
        }

        public bool ValidarDatosActividad()
        {
            return CmbTipoActividad.Text != "" && CmbNumProyecto.Text != "" && CmbNumProyecto.Text != "0" && CmbNumProyecto.Text != "0.00" && TxtDescripcionActividad.Text != "";
        }

        private void LlenarCmbTipo()
        {
            CmbTipoActividad.Items.Clear();
            TipoActividadEnsamble.Modelo().CargarDatos().ForEach(delegate(Fila f)
            {
                CmbTipoActividad.Items.Add(f.Celda("tipo"));
            });  

            if(IdActividad != 0)
            {
                BtnRegistrar.Text = "Guardar";
                ActividadEnsamble.Modelo().CargarDatos(IdActividad).ForEach(delegate(Fila f)
                {
                    string proyecto = f.Celda("proyecto").ToString();
                    Object descripcion = f.Celda("descripcion_actividad");

                    CmbNumProyecto.Text = proyecto;
                    CmbNumProyecto.Enabled = false;
                    if (descripcion != null)
                        TxtDescripcionActividad.Text = f.Celda("descripcion_actividad").ToString();
                    else
                        TxtDescripcionActividad.Text = "N/A";
                }); 
            }
        }

        private void CargarProyecto()
        {
            CmbNumProyecto.Items.Clear();
            Proyecto.Modelo().SeleccionarDatos("activo=1").ForEach(delegate(Fila f)
            {
                string proyecto = Convert.ToDecimal(f.Celda("id")).ToString("F2");
                string nombreProyecto = f.Celda("nombre").ToString();
                CmbNumProyecto.Items.Add(proyecto + " - " + nombreProyecto);
            });
            CmbNumProyecto.SelectedIndex = 0;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (IdActividad == 0)
            {
                if (ValidarDatosActividad())
                {
                    if (!NuevaActividad.TieneFilas())
                    {
                        if (!BuscadorActividad.ExisteValorColumna("proyecto", CmbNumProyecto.Text))
                             Filtros[0].ModificarFiltro(CmbNumProyecto.Text, true);
                             
                        if (!BuscadorActividad.ExisteValorColumna("tipo", CmbTipoActividad .Text))
                            Filtros[1].ModificarFiltro(CmbTipoActividad.Text, true);

                        if (!BuscadorActividad.ExisteValorColumna("estatus", "SIN ASIGNAR"))
                            Filtros[2].ModificarFiltro("SIN ASIGNAR", true);

                        if (!BuscadorActividad.ExisteValorColumna("estatus_revision", "PENDIENTE"))
                            Filtros[3].ModificarFiltro("PENDIENTE", true);

                        string[] spCmbProyecto = CmbNumProyecto.Text.Split(' ');
                        Fila actividad = new Fila();
                        actividad.AgregarCelda("proyecto", spCmbProyecto[0]);
                        actividad.AgregarCelda("tipo", CmbTipoActividad.Text);
                        actividad.AgregarCelda("descripcion_actividad", TxtDescripcionActividad.Text);
                        actividad.AgregarCelda("estatus", "SIN ASIGNAR");
                        ActividadEnsamble.Modelo().Insertar(actividad);
                        Filtros[0] = new Filtro("proyecto", "Proyecto", BuscadorActividad.Proyecto());
                        Filtros[1] = new Filtro("tipo", "Tipo de actividad", BuscadorActividad.TipoActividad());
                        Filtros[2] = new Filtro("estatus", "Estatus de actividad", BuscadorActividad.Estatus());
                        Filtros[3] = new Filtro("estatus_revision", "Estatus de revisión de actividad", BuscadorActividad.EstatusRevision());
                        DialogResult = System.Windows.Forms.DialogResult.Yes;                       
                    }
                }
                else
                {
                    LblInformacion.Visible = true;
                    LblInformacion.Text = "Favor de llenar todos los campos";
                }
            }
            else
            {
                if (!BuscadorActividad.ExisteValorColumna("tipo", CmbNumProyecto.Text))
                    Filtros[1] = new Filtro("tipo", "Tipo de actividad", BuscadorActividad.TipoActividad());
                NuevaActividad.CargarDatos(IdActividad);
                NuevaActividad.Fila().ModificarCelda("tipo", CmbTipoActividad.Text);
                NuevaActividad.Fila().ModificarCelda("descripcion_actividad", TxtDescripcionActividad.Text);
                NuevaActividad.GuardarDatos();
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        } 
    }
}
