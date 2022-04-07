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
    public partial class FrmSolicitudesRequerimientos : Form
    {
        Proyecto ProyectoCargado = new Proyecto();

        public FrmSolicitudesRequerimientos(Proyecto proyecto)
        {
            InitializeComponent();
            ProyectoCargado = proyecto;
        }

        public void CargarSolicitudes()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", ProyectoCargado.Fila().Celda("id"));
            int fila = Global.GuardarFilaSeleccionada(DgvSolicitudes);

            DgvSolicitudes.Rows.Clear();


            Requerimiento.Modelo().SeleccionarDatos("proyecto=@proyecto AND (estatus='SOLICITUD' OR estatus='RECHAZADO')", parametros).ForEach(delegate(Fila f)
            {
                DgvSolicitudes.Rows.Add(f.Celda("id"), 
                                        f.Celda("nombre"), 
                                        f.Celda("descripcion"), 
                                        f.Celda("usuario_creacion"), 
                                        Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMM dd, yyyy hh:mm:ss tt"), 
                                        f.Celda("estatus"));
            });
            Global.RecuperarFilaSeleccionada(DgvSolicitudes, fila);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmSolicitudesRequerimientos_Load(object sender, EventArgs e)
        {
            LblTitulo.Text = "SOLICITUDES DE REQUERIMIENTOS DEL PROYECTO ";
            LblTitulo.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            LblTitulo.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            CargarSolicitudes();

            BtnNuevo.Enabled = Global.VerificarPrivilegio("PROYECTOS", "SOLICITAR REQUERIMIENTO");
            BtnAceptar.Enabled = Global.VerificarPrivilegio("PROYECTOS", "ACEPTAR REQUERIMIENTO");
            BtnRechazar.Enabled = Global.VerificarPrivilegio("PROYECTOS", "RECHAZAR REQUERIMIENTO");
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoRequerimiento nr = new FrmNuevoRequerimiento( Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")), 0, true);

            if( nr.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarSolicitudes();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (DgvSolicitudes.SelectedRows.Count <= 0)
                return;

            DialogResult resp = MessageBox.Show("Seguro que deseas aceptar la solicitud de requerimiento seleccionada?", "Aceptar solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            int IdReq = Convert.ToInt32(DgvSolicitudes.SelectedRows[0].Cells["id"].Value);

            Requerimiento req = new Requerimiento();
            req.CargarDatos(IdReq);

            if(req.TieneFilas())
            {
                req.Fila().ModificarCelda("estatus", "NO DEFINIDO");
                req.GuardarDatos();

                //string titulo = "Solicitud de requerimiento aceptada";
                //string contenido = Global.UsuarioActual.NombreCompleto() + " aceptó la solicitud de requerimiento #" + IdReq;
                //contenido += " para el proyecto " + Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2") + ".";

                //Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                //Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                //Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR PROGRAMADOR");

                CargarSolicitudes();
            }
        }

        private void BtnRechazar_Click(object sender, EventArgs e)
        {
            if (DgvSolicitudes.SelectedRows.Count <= 0)
                return;

            DialogResult resp = MessageBox.Show("Seguro que deseas rechazar la solicitud de requerimiento seleccionada?", "Rechazar solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            int IdReq = Convert.ToInt32(DgvSolicitudes.SelectedRows[0].Cells["id"].Value);

            Requerimiento req = new Requerimiento();
            req.CargarDatos(IdReq);

            if (req.TieneFilas())
            {
                req.Fila().ModificarCelda("estatus", "RECHAZADO");
                req.GuardarDatos();

                string titulo = "Solicitud de requerimiento rechazada";
                string contenido = Global.UsuarioActual.NombreCompleto() + " rechazó la solicitud de requerimiento #" + IdReq;
                contenido += " para el proyecto " + Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2") + ".";

                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR PROGRAMADOR");

                CargarSolicitudes();
            }
        }
    }
}
