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
    public partial class FrmNuevoRequerimiento : Ventana
    {
        bool Solicitud = false;
        public decimal Proyecto = 0;
        public int IdRequerimiento = 0;
        public int IdModulo = 0;

        public FrmNuevoRequerimiento(decimal proyecto, int idRequerimiento=0, bool solicitud=false, int idModulo = 0)
        {
            InitializeComponent();
            Proyecto = proyecto;
            IdRequerimiento = idRequerimiento;
            Solicitud = solicitud;
            IdModulo = idModulo;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public bool ValidarInformacion()
        {
            return CmbEstatus.Text != "" && CmbOrigen.Text != "" && CmbNivelRevision.Text != "" && TxtNombre.Text != "";
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarInformacion())
            {
                if(IdRequerimiento == 0)
                {
                    Fila req = new Fila();
                    req.AgregarCelda("nombre", TxtNombre.Text);
                    req.AgregarCelda("estatus", CmbEstatus.Text);
                    req.AgregarCelda("proyecto", Proyecto);
                    req.AgregarCelda("descripcion", TxtDescripcion.Text);
                    req.AgregarCelda("origen", CmbOrigen.Text);
                    req.AgregarCelda("nivel_revision", CmbNivelRevision.Text);
                    req.AgregarCelda("fecha_creacion", DateTime.Now);
                    req.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
                    req.AgregarCelda("estatus_revision", "PENDIENTE");
                    req.AgregarCelda("comentarios_revision", "");
                    req.AgregarCelda("usuario_revision", "N/A");
                    req.AgregarCelda("modulo", IdModulo);

                    req = Requerimiento.Modelo().Insertar(req);
                    IdRequerimiento = Convert.ToInt32(req.Celda("id"));

                    string titulo = "";
                    string contenido = "";

                    if(!Solicitud)
                    {
                        //titulo = "Nuevo requerimiento";
                        //contenido = Global.UsuarioActual.NombreCompleto() + " ha registrado el requerimiento #" + IdRequerimiento;
                        //contenido += " para el proyecto " + Proyecto.ToString("F2") + ".";
                    }
                    else
                    {
                        titulo = "Solicitud de requerimiento";
                        contenido = Global.UsuarioActual.NombreCompleto() + " ha solicitado el requerimiento #" + IdRequerimiento;
                        contenido += " para el proyecto " + Proyecto.ToString("F2") + ".";

                        Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                        Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                        Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR PROGRAMADOR");
                    }
                }
                else
                {
                    Requerimiento req = new Requerimiento();
                    req.CargarDatos(IdRequerimiento);

                    if(req.TieneFilas())
                    {
                        req.Fila().ModificarCelda("estatus", CmbEstatus.Text);
                        req.Fila().ModificarCelda("origen", CmbOrigen.Text);
                        req.Fila().ModificarCelda("nivel_revision", CmbNivelRevision.Text);
                        req.Fila().ModificarCelda("nombre", TxtNombre.Text);
                        req.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);

                        req.GuardarDatos();

                        //string titulo = "Requerimiento editado";
                        //string contenido = Global.UsuarioActual.NombreCompleto() + " modificó el requerimiento #" + IdRequerimiento;
                        //contenido += " para el proyecto " + Proyecto.ToString("F2") + ".";

                        //Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR MECANICO");
                        //Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR ELECTRICO");
                        //Evento.Modelo().Crear(titulo, contenido, "DISEÑADOR PROGRAMADOR");
                    }
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                LblInfo.Text = "Ingresa todos los datos requeridos";
        }

        private void FrmNuevoRequerimiento_Load(object sender, EventArgs e)
        {
            LblInfo.Text = "";
            
            if( IdRequerimiento > 0 )
            {
                LblTitulo.Text = "EDITAR REQUERIMIENTO";
                BtnRegistrar.Text = "Guardar";

                Requerimiento req = new Requerimiento();
                req.CargarDatos(IdRequerimiento);

                if(req.TieneFilas())
                {
                    CmbEstatus.Text = req.Fila().Celda("estatus").ToString();
                    CmbOrigen.Text = req.Fila().Celda("origen").ToString();
                    CmbNivelRevision.Text = req.Fila().Celda("nivel_revision").ToString();
                    TxtNombre.Text = req.Fila().Celda("nombre").ToString();
                    TxtDescripcion.Text = req.Fila().Celda("descripcion").ToString();
                }
            }

            if( Solicitud )
            {
                CmbEstatus.Items.Clear();
                CmbEstatus.Items.Add("SOLICITUD");
                CmbEstatus.Text = "SOLICITUD";
                CmbEstatus.Enabled = false;

                CmbOrigen.Items.Clear();
                CmbOrigen.Items.Add("N/A");
                CmbOrigen.Text = "N/A";
                CmbOrigen.Enabled = false;

                CmbNivelRevision.Items.Clear();
                CmbNivelRevision.Items.Add("N/A");
                CmbNivelRevision.Text = "N/A";
                CmbNivelRevision.Enabled = false;
            }
        }
    }
}
