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
    public partial class FrmSeguimientoEtapa : Ventana
    {
        string EtapaDelProyecto;
        decimal IdProyecto;
        int Subensamble;
        int IdDatosEdicion = 0;
        int Editar;
        public FrmSeguimientoEtapa(decimal proyecto, string etapa, int subensamble, int editar = 0)
        {
            InitializeComponent();
            EtapaDelProyecto = etapa;
            IdProyecto = proyecto;
            Subensamble = subensamble;
            Editar = editar;
        }

        private void CargarResponsable()
        {
            CmbResponsable.Items.Clear();
            Usuario.Modelo().Todos().ForEach(delegate(Fila f) 
            {
                string nombre = f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString();
                CmbResponsable.Items.Add(nombre);
            });
        }

        private void CargarDatosCierre()
        {
            EtapaProyecto fechas = new EtapaProyecto();
            fechas.FechasProyecto(IdProyecto, EtapaDelProyecto);
            if (fechas.TieneFilas())
            {
                DtFechaCierre.Value = Convert.ToDateTime(fechas.Fila().Celda("cierre"));
                DtFechaCierre.Enabled = false;
            }
            else
            {
                LblInfo.Visible = true;
                LblInfo.Text = " Etapa sin fecha de cierre definida";
                CmbResponsable.Enabled = false;
                DtFechaPromesa.Enabled = false;
                DtFechaCierre.Enabled = false;
                BtnRegistrar.Enabled = false;
            }
        }

        private void CargarDatosEdicion()
        {
            FechaModulo fm = new FechaModulo();
            fm.SeleccionarDatos(IdProyecto, Subensamble, EtapaDelProyecto).ForEach(delegate (Fila f)
            {
                CmbResponsable.Text = f.Celda("responsable").ToString();
                DtFechaPromesa.Value = Convert.ToDateTime(f.Celda("fecha_promesa"));
                IdDatosEdicion = Convert.ToInt32(f.Celda("id"));
                BtnRegistrar.Text = "Editar";
            });
        }

        private void EditarDatos()
        {
            DateTime fechaPromesa = DtFechaPromesa.Value;
            DateTime cierre = DtFechaCierre.Value;
            DateTime actual = DateTime.Now;
            
            if (fechaPromesa >= cierre || fechaPromesa <= actual)
                MessageBox.Show("Ingrese una fecha valida");

            else
            {
                FechaModulo fm = new FechaModulo();
                fm.CargarDatos(IdDatosEdicion);
                fm.Fila().ModificarCelda("responsable", CmbResponsable.Text.Trim());
                fm.Fila().ModificarCelda("fecha_promesa", fechaPromesa);
                fm.GuardarDatos();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void NuevosDatos()
        {
            DateTime fechaPromesa = DtFechaPromesa.Value;
            DateTime cierre = DtFechaCierre.Value;
            DateTime actual = DateTime.Now;

            if (fechaPromesa >= cierre || fechaPromesa <= actual)
                MessageBox.Show("Ingrese una fecha valida");

            else
            {
                Fila alta = new Fila();
                alta.AgregarCelda("proyecto", IdProyecto);
                alta.AgregarCelda("subensamble", Subensamble);
                alta.AgregarCelda("etapa", EtapaDelProyecto);
                alta.AgregarCelda("fecha_promesa", fechaPromesa);
                alta.AgregarCelda("responsable", CmbResponsable.Text);
                FechaModulo.Modelo().Insertar(alta);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmSeguimientoEtapa_Load(object sender, EventArgs e)
        {
            CargarResponsable();
            CargarDatosCierre();

            if (Editar == 1)
                CargarDatosEdicion();

           
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (Editar == 0)
                NuevosDatos();
            else
                EditarDatos();
        }
    }
}