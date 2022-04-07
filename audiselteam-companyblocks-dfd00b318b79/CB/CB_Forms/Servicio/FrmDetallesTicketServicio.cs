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
    public partial class FrmDetallesTicketServicio : Form
    {
        Form FormContenido = null;
        Decimal IdProyecto = 0;
        int IdCliente = 0;
        int IdContacto = 0;
        int IdTicket = 0;
        int IdProblemaPlanteado = 0;
        Problema ProblemaPlanteado = new Problema();

        TicketServicio Ticket = new TicketServicio();
        Proyecto ProyectoTicket = new Proyecto();
        Cliente ClienteTicket = new Cliente();
        ClienteContacto ContactoTicket = new ClienteContacto();

        public FrmDetallesTicketServicio(int idTicket)
        {
            InitializeComponent();
            IdTicket = idTicket;
            Ticket.CargarDatos(idTicket);

            IdProyecto = Convert.ToDecimal(Ticket.Fila().Celda("proyecto"));
            ProyectoTicket.CargarDatos(IdProyecto);

            IdCliente = Convert.ToInt32(ProyectoTicket.Fila().Celda("cliente"));
            ClienteTicket.CargarDatos(IdCliente);

            IdContacto = Convert.ToInt32(Ticket.Fila().Celda("contacto"));
            ContactoTicket.CargarDatos(IdContacto);

            ProblemaPlanteado.SeleccionarTicketServicio(IdTicket);
            
            if(ProblemaPlanteado.TieneFilas())
                IdProblemaPlanteado = Convert.ToInt32(ProblemaPlanteado.Fila().Celda("id"));
        }

        private void FrmDetallesTicketServicio_Load(object sender, EventArgs e)
        {
            TxtID.Text = Ticket.Fila().Celda("id").ToString().PadLeft(4, '0');
            TxtCliente.Text = ClienteTicket.Fila().Celda("nombre").ToString();
            TxtContacto.Text = ContactoTicket.Fila().Celda("nombre") + " " + ContactoTicket.Fila().Celda("apellidos");
            TxtProyecto.Text = Convert.ToDecimal(ProyectoTicket.Fila().Celda("id")).ToString("F2").PadLeft(5, '0') + " - " + ProyectoTicket.Fila().Celda("nombre");
            TxtDetalles.Text = Ticket.Fila().Celda("detalles").ToString();
            LblEstatusTicket.Text = Ticket.Fila().Celda("estatus").ToString();
            TxtTipo.Text = Ticket.Fila().Celda("tipo").ToString();
            string fechaUltimoReporte = Global.ObjetoATexto(Global.FechaATexto(Ticket.Fila().Celda("fecha_ultimo_reporte")), "SIN REPORTAR");
            LblUltimoReporte.Text = "Ultimo reporte: " + fechaUltimoReporte;

           

            switch(TxtTipo.Text)
            {
                case "INCIDENTE DE CALIDAD":
                    CmbMetodologia.Items.Add("8D");

                    // A continuacion se podrian agregar otras metodologias, por ejemplo:
                    // CmbMetodologia.Items.Add("OTRO METODO");
                    PicTipoTicket.Image = CB_Base.Properties.Resources.incidente_calidad_48;
                    break;

                case "RECLAMO OFICIAL":
                    CmbMetodologia.Items.Add("8D");

                    // A continuacion se podrian agregar otras metodologias, por ejemplo:
                    // CmbMetodologia.Items.Add("OTRO METODO");
                    PicTipoTicket.Image = CB_Base.Properties.Resources.reclamo_oficial_48;
                    break;

                case "SEGUIMIENTO DE GARANTIA":
                    CmbMetodologia.Items.Add("ACCIONES CORRECTIVAS");
                    PicTipoTicket.Image = CB_Base.Properties.Resources.about_icon_48;
                    break;
            }

            CargarMetodologia();
        }

        public void CargarMetodologia()
        {
            if (ProblemaPlanteado.TieneFilas())
            {
                string metodologiaProblema = ProblemaPlanteado.Fila().Celda("metodologia").ToString();
                int etapaProblema = Convert.ToInt32(ProblemaPlanteado.Fila().Celda("etapa"));

                switch (metodologiaProblema)
                {
                    case "8D":
                        CmbMetodologia.Text = metodologiaProblema;

                        CmbEtapa.Items.Clear();
                        CmbEtapa.Items.Add("D1- ESTABLECER UN GRUPO PARA SOLUCIONAR EL PROBLEMA");
                        CmbEtapa.Items.Add("D2- DESCRIBIR DETALLADAMENTE EL PROBLEMA");
                        CmbEtapa.Items.Add("D3- DESARROLLAR UNA SOLUCION TEMPORAL");
                        CmbEtapa.Items.Add("D4- IDENTIFICAR LA CAUSA RAIZ DEL PROBLEMA");
                        CmbEtapa.Items.Add("D5- DESARROLLAR SOLUCIONES PERMANENTES");
                        CmbEtapa.Items.Add("D6- IMPLEMENTAR Y VALIDAR SOLUCIONES");
                        CmbEtapa.Items.Add("D7- PREVENIR LA RECURRENCIA");
                        CmbEtapa.Items.Add("D8- CERRAR EL PROBLEMA Y RECONOCER CONTRIBUCIONES");
                        break;

                    // A continuacion se podrian agregar las etapas de otras metodologias:
                    // --------------------------------------------------------------
                    //case "OTRO METODO":
                    //    CmbMetodologia.Text = "OTRO METODO";

                    //    CmbEtapa.Items.Clear();
                    //    CmbEtapa.Items.Add("PRIMER PASO");
                    //    CmbEtapa.Items.Add("SEGUNDO PASO");
                    //    break;
                }

                if (etapaProblema > 0)
                    CmbEtapa.SelectedIndex = etapaProblema - 1;
            }
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaAccion accion = new FrmNuevaAccion();
            
            if(accion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int idTopico = 0;
                string descripcionTopico = "ACCIONES DEL TICKET DE SERVICIO #" + Ticket.Fila().Celda("id").ToString().PadLeft(4, '0');

                // verificar si el topico existe
                Topico tp = new Topico();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@descripcion", descripcionTopico);
                tp.SeleccionarDatos("descripcion=@descripcion", parametros);

                // si existe obtiene su id, si no existe lo crea
                if (tp.TieneFilas())
                {
                    idTopico = Convert.ToInt32(tp.Fila().Celda("id"));
                }
                else
                {
                    Fila nuevoTopico = new Fila();
                    nuevoTopico.AgregarCelda("proyecto", IdProyecto);
                    nuevoTopico.AgregarCelda("descripcion", descripcionTopico);
                    nuevoTopico.AgregarCelda("estatus", "PENDIENTE");
                    nuevoTopico.AgregarCelda("fecha_creacion", DateTime.Now);
                    nuevoTopico.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                    nuevoTopico = tp.Insertar(nuevoTopico);
                    idTopico = Convert.ToInt32(nuevoTopico.Celda("id"));
                }

                // crea la tarea
                Fila nuevaTarea = new Fila();
                nuevaTarea.AgregarCelda("topico", idTopico);
                nuevaTarea.AgregarCelda("nombre", accion.Nombre);
                nuevaTarea.AgregarCelda("tarea_principal", 0);
                nuevaTarea.AgregarCelda("fecha_promesa", accion.FechaPromesa);
                nuevaTarea.AgregarCelda("estatus", "PENDIENTE");
                nuevaTarea.AgregarCelda("descripcion", "Tipo de acción: " + accion.Tipo + Environment.NewLine + Environment.NewLine + accion.Detalles);
                nuevaTarea.AgregarCelda("estatus_tiempo", string.Empty);
                nuevaTarea = TareasTopico.Modelo().Insertar(nuevaTarea);

                // crear los responsables de la tarea
                accion.UsuariosSeleccionados.ForEach(delegate(Usuario usr) 
                {
                    Fila nuevoResponsable = new Fila();
                    nuevoResponsable.AgregarCelda("tarea", nuevaTarea.Celda("id"));
                    nuevoResponsable.AgregarCelda("responsable", usr.NombreCompleto());
                    TareasResponsables.Modelo().Insertar(nuevoResponsable);
                });

                // crea la accion
                Fila nuevaAccion = new Fila();
                nuevaAccion.AgregarCelda("tipo", accion.Tipo);
                nuevaAccion.AgregarCelda("tarea", nuevaTarea.Celda("id"));
                nuevaAccion.AgregarCelda("no_conformidad", Ticket.Fila().Celda("no_conformidad"));
                nuevaAccion.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
                nuevaAccion.AgregarCelda("fecha_creacion", DateTime.Now);
                Accion.Modelo().Insertar(nuevaAccion);

                MessageBox.Show("La acción fue creada correctamente.", "Nueva acción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAcciones();
            }
        }

        public void CargarAcciones()
        {

        }

        private void CmbTipoAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAcciones();
        }

        private void BtnEnviarAvances_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea reportar al cliente el seguimiento del ticket de servicio?", "Reportar avance", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Accion acciones = new Accion();
                int idNoConformidad = Convert.ToInt32(Ticket.Fila().Celda("no_conformidad"));
                acciones.SeleccionarAccionesNoNotificadas(idNoConformidad);

                if (acciones.TieneFilas())
                {

                    BkgEnviarAvancesAlCorreo.RunWorkerAsync();

                    TicketServicio ticket = new TicketServicio();
                    ticket.CargarDatos(IdTicket);
                    ticket.Fila().ModificarCelda("fecha_ultimo_reporte", DateTime.Now);
                    ticket.GuardarDatos();

                    LblUltimoReporte.Text = "Ultimo reporte: " + Global.FechaATexto(DateTime.Now);
                }
                else
                    MessageBox.Show("No se encontraron acciones nuevas para reportar al cliente", "No hay acciones nuevas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             DialogResult result2 = MessageBox.Show("¿Está seguro que desea cerrar el ticket de servicio?", "Cierre de ticket", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result2 == System.Windows.Forms.DialogResult.Yes)
             {
                 ReporteCorreo.TicketServicioCerrado(IdTicket, "center", "#FFFFFF", "#000000");
             }
        }

        private void BkgEnviarCorreo_DoWork(object sender, DoWorkEventArgs e)
        {
            ReporteCorreo.MandarAvancesTicketServicioAlCliente(IdTicket, "center", "#FFFFFF", "#000000");
        }

        private void BkgEnviarAvancesAlCorreo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Accion acciones = new Accion();
            int idNoConformidad = Convert.ToInt32(Ticket.Fila().Celda("no_conformidad"));
            acciones.SeleccionarAccionesNoNotificadas(idNoConformidad);
            if (acciones.TieneFilas())
            {
                Accion.Modelo().SeleccionarAccionesNoNotificadas(idNoConformidad).ForEach(delegate(Fila f)
                {
                    acciones.CargarDatos(Convert.ToInt32(f.Celda("id")));
                    acciones.Fila().ModificarCelda("notificacion", "1");
                    acciones.GuardarDatos();
                });
            }

            MessageBox.Show("El seguimiento del ticket de servicio ha sido enviado al cliente");
        }

        private void CmbEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormContenido != null)
                FormContenido.Close();

            switch(CmbMetodologia.Text)
            {
                case "8D":
                    GestionarEtapas8D(CmbEtapa.SelectedIndex + 1);
                    break;
            }

        }

        public void GestionarEtapas8D(int etapa)
        {
            switch (etapa)
            {
                case 1:
                    FormContenido = new Frm8DsD1(IdProblemaPlanteado);
                    FormContenido.MdiParent = this;
                    FormContenido.WindowState = FormWindowState.Maximized;
                    FormContenido.Show();
                    BtnContinuar.Enabled = true;
                    BtnRegresar.Enabled = false;
                    break;

                case 2:
                    FormContenido = new Frm8DsD2();
                    FormContenido.MdiParent = this;
                    FormContenido.WindowState = FormWindowState.Maximized;
                    FormContenido.Show();
                    BtnContinuar.Enabled = true;
                    BtnRegresar.Enabled = true;
                    break;

                case 3:
                    FormContenido = new Frm8DsD3();
                    FormContenido.MdiParent = this;
                    FormContenido.WindowState = FormWindowState.Maximized;
                    FormContenido.Show();
                    BtnContinuar.Enabled = true;
                    BtnRegresar.Enabled = true;
                    break;

                case 4:
                    FormContenido = new Frm8DsD4();
                    FormContenido.MdiParent = this;
                    FormContenido.WindowState = FormWindowState.Maximized;
                    FormContenido.Show();
                    BtnContinuar.Enabled = true;
                    BtnRegresar.Enabled = true;
                    break;

                case 5:
                    FormContenido = new Frm8DsD5();
                    FormContenido.MdiParent = this;
                    FormContenido.WindowState = FormWindowState.Maximized;
                    FormContenido.Show();
                    BtnContinuar.Enabled = true;
                    BtnRegresar.Enabled = true;
                    break;

                case 6:
                    FormContenido = new Frm8DsD6();
                    FormContenido.MdiParent = this;
                    FormContenido.WindowState = FormWindowState.Maximized;
                    FormContenido.Show();
                    BtnContinuar.Enabled = true;
                    BtnRegresar.Enabled = true;
                    break;
            }
        }

        private void CmbMetodologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbMetodologia.Text != ProblemaPlanteado.Fila().Celda("metodologia").ToString())
            {
                DialogResult resp = MessageBox.Show("¿Estás seguro que quieres cambiar de metodología?", "Cambiar metodología", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp != System.Windows.Forms.DialogResult.Yes)
                {
                    CmbMetodologia.Text = ProblemaPlanteado.Fila().Celda("metodologia").ToString();
                    return;
                }

                ProblemaPlanteado.Fila().ModificarCelda("metodologia", CmbMetodologia.Text);
                ProblemaPlanteado.Fila().ModificarCelda("etapa", 1);
                ProblemaPlanteado.GuardarDatos();

                CargarMetodologia();
            }
        }
    }
}
