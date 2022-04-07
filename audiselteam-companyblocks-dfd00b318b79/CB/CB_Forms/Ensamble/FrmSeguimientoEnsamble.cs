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
    public partial class FrmSeguimientoEnsamble : Ventana
    {
        private int IdActividad = 0;
        private string EstatusActividad = "";
        public string EstatusActual = "";

        public List<Filtro> Filtros = new List<Filtro>();
        ActividadEnsamble Actividad = new ActividadEnsamble();
        ActividadEnsamble BuscadorActividad = new ActividadEnsamble();

        public FrmSeguimientoEnsamble(int idActividad, string estatus, List<Filtro> filtros = null)
        {
            IdActividad = idActividad;
            EstatusActividad = estatus;
            if (filtros != null)
                Filtros = filtros;
            InitializeComponent();
        }

        public bool ValidarInformacion()
        { 
            DateTime promesa = DtFechaPromesa.Value;
            if (CmbEstatusActual.Text == "TERMINADO")
                return true;
            else
                return (CmbEstatusActual.Text != "" && TxtComentarios.Text != "" && promesa > DateTime.Now.AddDays(-1));
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {           
            if (ValidarInformacion())
            {
                if (!BuscadorActividad.ExisteValorColumna("estatus", CmbEstatusActual.Text))
                    Filtros[2] = new Filtro("estatus", "Estatus de actividad", BuscadorActividad.Estatus());

                string fecha = DtFechaPromesa.Value.ToString("MMM dd, yyyy hh:mm:ss tt");
                Actividad.CargarDatos(IdActividad);
                Actividad.Fila().ModificarCelda("estatus", CmbEstatusActual.Text);
                Actividad.Fila().ModificarCelda("comentarios_revision", TxtComentarios.Text);
                Actividad.Fila().ModificarCelda("fecha_promesa", Convert.ToDateTime(fecha));

                if (CmbEstatusActual.Text == "TERMINADO")
                    Actividad.Fila().ModificarCelda("fecha_termino", DateTime.Now);

                Actividad.GuardarDatos();
                EstatusActual = CmbEstatusActual.Text;
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else
            {
                DateTime promesa = DtFechaPromesa.Value;
                
                if(TxtComentarios.Text == "")
                {
                    LblInformacion.Enabled = true;
                    LblInformacion.Visible = true;
                    LblInformacion.Text += "Favor de ingresar los datos completos. ";
                }
                if (promesa < DateTime.Now)
                {
                    LblInformacion.Enabled = true;
                    LblInformacion.Visible = true;
                    LblInformacion.Text = "La fecha promesa debe de ser mayor.\r\n";
                }
            }
        }

        private void FrmSeguimientoEnsamble_Load(object sender, EventArgs e)
        {          
            ActividadEnsamble.Modelo().CargarDatos(IdActividad).ForEach(delegate(Fila f)
            {
                Object descripcion = f.Celda("descripcion_actividad");
                Object responsable = f.Celda("responsable");
                Object fechaPromesa = f.Celda("fecha_promesa");
                Object comentariosRevision = f.Celda("comentarios_revision");

                if (descripcion != null)
                    TxtDescripcion.Text = f.Celda("descripcion_actividad").ToString();
                else
                    TxtDescripcion.Text = "N/A";
                if (responsable != null)
                    TxtTecnicoAsignado.Text = f.Celda("responsable").ToString();
                else
                   TxtTecnicoAsignado.Text = "N/A";

                if (fechaPromesa != null)
                    DtFechaPromesa.Value = Convert.ToDateTime(f.Celda("fecha_promesa"));

                if(comentariosRevision != null)
                    TxtComentarios.Text = f.Celda("comentarios_revision").ToString();
            });

            if (CmbEstatusActual.Items.Contains(EstatusActividad))
                CmbEstatusActual.Text = EstatusActividad;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
