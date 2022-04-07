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
    public partial class FrmNuevoTicketServicio : Ventana
    {
        string TipoTicket = string.Empty;
        string ParteInteresada = string.Empty;
        TicketServicio BuscadorTickets = new TicketServicio();

        public FrmNuevoTicketServicio(string parteInteresada="EXTERNA")
        {
            InitializeComponent();
            ParteInteresada = parteInteresada;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        public void CargarProyectos()
        {
            CmbProyecto.Items.Clear();
            Proyecto.Modelo().SeleccionarDatos("0=0 ORDER BY id DESC").ForEach(delegate(Fila f)
            {
                CmbProyecto.Items.Add(Convert.ToDecimal(f.Celda("id")).ToString("F2").PadLeft(5, '0') + " - " + f.Celda("nombre"));
            });
        }

        public void CargarContactos(int idCliente)
        {
            CmbContacto.Items.Clear();
            ClienteContacto.Modelo().SeleccionarDeCliente(idCliente).ForEach(delegate(Fila f)
            {
                CmbContacto.Items.Add(Convert.ToDecimal(f.Celda("id")) + " - " + f.Celda("nombre") + " " + f.Celda("apellidos"));
            });
        }
        

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Seguro que quieres registrar el ticket de servicio?", "Registrar ticket de servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;
            
            Decimal idProyecto = Convert.ToDecimal(CmbProyecto.Text.Split('-')[0]);
            int idContacto = Convert.ToInt32(CmbContacto.Text.Split('-')[0]);

            Fila insertarNoConformidad = new Fila();

            if (ParteInteresada == "EXTERNA")
                insertarNoConformidad.AgregarCelda("tipo", "CLIENTE");
            else if (ParteInteresada == "INTERNA")
                insertarNoConformidad.AgregarCelda("tipo", "PROVEEDOR");

            insertarNoConformidad.AgregarCelda("proceso_origen", TipoTicket);
            insertarNoConformidad.AgregarCelda("comentarios", TxtDetalles.Text);
            insertarNoConformidad.AgregarCelda("fecha_creacion", DateTime.Now);
            insertarNoConformidad.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
            insertarNoConformidad.AgregarCelda("cantidad_ok", 0);
            insertarNoConformidad.AgregarCelda("cantidad_nok", 1);
            insertarNoConformidad.AgregarCelda("proceso_fabricacion", 0);
            insertarNoConformidad.AgregarCelda("plano", 0);
            insertarNoConformidad.AgregarCelda("proceso_fabricacion_rechazado", 0);
            insertarNoConformidad.AgregarCelda("estatus", "LIBERADO");
            insertarNoConformidad.AgregarCelda("disposicion", "SERVICIO");
            insertarNoConformidad.AgregarCelda("usuario_liberacion", Global.UsuarioActual.Fila().Celda("id"));
            insertarNoConformidad.AgregarCelda("fecha_liberacion", DateTime.Now);
            insertarNoConformidad.AgregarCelda("costo_estimado", 0);
            insertarNoConformidad.AgregarCelda("dias_retraso", 0);
            insertarNoConformidad.AgregarCelda("estatus_analisis", "PENDIENTE");
            //insertarNoConformidad = NoConformidad.Modelo().Insertar(insertarNoConformidad);

            Fila insertarTicket = new Fila();
            insertarTicket.AgregarCelda("tipo", TipoTicket);
            insertarTicket.AgregarCelda("proyecto", idProyecto);
            insertarTicket.AgregarCelda("contacto", idContacto);
            insertarTicket.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
            insertarTicket.AgregarCelda("fecha_creacion", DateTime.Now);
            insertarTicket.AgregarCelda("estatus", "ABIERTO");
            insertarTicket.AgregarCelda("detalles", TxtDetalles.Text);
            insertarTicket.AgregarCelda("usuario_cierre", 0);
            insertarTicket.AgregarCelda("fecha_cierre", null);
            insertarTicket.AgregarCelda("comentarios_cierre", string.Empty);
            insertarTicket.AgregarCelda("no_conformidad", insertarNoConformidad.Celda("id"));
            int idTicketServicio = Convert.ToInt32(TicketServicio.Modelo().Insertar(insertarTicket).Celda("id"));

            if(TipoTicket == "RECLAMO OFICIAL" || TipoTicket == "INCIDENTE DE CALIDAD")
            {
                // crear el problema en la base de datos
                Fila problema = new Fila();
                problema.AgregarCelda("ticket_servicio", idTicketServicio);
                problema.AgregarCelda("usuario_registro", Global.UsuarioActual.Fila().Celda("id"));
                problema.AgregarCelda("fecha_registro", DateTime.Now);
                problema.AgregarCelda("que", TxtDetalles.Text);
                problema.AgregarCelda("etapa", 1);
                problema = Problema.Modelo().Insertar(problema);

                int idProblema = Convert.ToInt32(problema.Celda("id"));

                // agregar el usuario actual como integrante en el grupo de resolucion del problema
                Fila pg = new Fila();
                pg.AgregarCelda("problema", idProblema);
                pg.AgregarCelda("integrante", Global.UsuarioActual.Fila().Celda("id"));
                ProblemaGrupo.Modelo().Insertar(pg);
            }

            if(!BkgEnviarCorreo.IsBusy)
                BkgEnviarCorreo.RunWorkerAsync(idTicketServicio);

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void ValidarDatos()
        {
            bool datosExisten = TipoTicket != string.Empty && CmbProyecto.Text != string.Empty && CmbContacto.Text != string.Empty;

            LblEstatus.Text = (TxtDetalles.MaxLength - TxtDetalles.Text.Length).ToString() + " caracteres disponibles";

            BtnRegistrar.Enabled = datosExisten && TxtDetalles.Text.Length > 0;
        }

        private void CmbProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();

            if(CmbProyecto.Text != string.Empty)
            {
                decimal idProyecto = Convert.ToDecimal(CmbProyecto.Text.Split('-')[0]);
                int idCliente = 0;

                Proyecto prj = new Proyecto();
                prj.CargarDatos(idProyecto);

                if(prj.TieneFilas())
                {
                    idCliente = Convert.ToInt32(prj.Fila().Celda("cliente"));
                    CargarContactos(idCliente);
                }
            }

            RdReclamoOficial.Enabled = CmbProyecto.Text != string.Empty && CmbContacto.Text != string.Empty;
            RdIncidenteCalidad.Enabled = CmbProyecto.Text != string.Empty && CmbContacto.Text != string.Empty;
            RdSeguimientoGarantia.Enabled = CmbProyecto.Text != string.Empty && CmbContacto.Text != string.Empty;
        }

        private void CmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarDatos();
            RdReclamoOficial.Enabled = CmbProyecto.Text != string.Empty && CmbContacto.Text != string.Empty;
            RdIncidenteCalidad.Enabled = CmbProyecto.Text != string.Empty && CmbContacto.Text != string.Empty;
            RdSeguimientoGarantia.Enabled = CmbProyecto.Text != string.Empty && CmbContacto.Text != string.Empty;
        }

        private void TxtDetalles_TextChanged(object sender, EventArgs e)
        {
            ValidarDatos();

            if(!BkgBuscador.IsBusy)
            {
                BkgBuscador.RunWorkerAsync();
            }
        }

        private void FrmNuevoTicketServicio_Load(object sender, EventArgs e)
        {
            CargarProyectos();
        }

        private void BkgEnviarCorreo_DoWork(object sender, DoWorkEventArgs e)
        {
            ReporteCorreo.MandarTicketServicioAlCliente(Convert.ToInt32(e.Argument), "center", "#FFFFFF", "#000000");
        }

        private void BkgEnviarCorreo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("El reporte del ticket de servicio ha sido enviado al cliente");
        }

        private void RdReclamoOficial_CheckedChanged(object sender, EventArgs e)
        {
            TipoTicket = "RECLAMO OFICIAL";
            ValidarDatos();
            TxtDetalles.Enabled = true;
        }

        private void RdIncidenteCalidad_CheckedChanged(object sender, EventArgs e)
        {
            TipoTicket = "INCIDENTE DE CALIDAD";
            ValidarDatos();
            TxtDetalles.Enabled = true;
        }

        private void RdSeguimientoGarantia_CheckedChanged(object sender, EventArgs e)
        {
            TipoTicket = "SEGUIMIENTO DE GARANTIA";
            ValidarDatos();
            TxtDetalles.Enabled = true;
        }

        private void BkgBuscador_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string sintoma = string.Empty;

            if(!BuscadorTickets.TieneFilas())
            {
                ListaSintomas.Items.Clear();
                return;
            }

            BuscadorTickets.Filas().ForEach(delegate(Fila f)
            {
                sintoma = f.Celda("detalles").ToString();
                ListViewItem lvi = new ListViewItem(sintoma);
                lvi.Name = f.Celda("id").ToString(); 

                if(!ListaSintomas.Items.ContainsKey(f.Celda("id").ToString()))
                    ListaSintomas.Items.Add(lvi);
            });
        }

        private void BkgBuscador_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@filtro", TxtDetalles.Text);
            BuscadorTickets.SeleccionarDatos("MATCH (detalles) AGAINST (@filtro IN BOOLEAN MODE) AND CHAR_LENGTH(detalles)<=50", parametros, "id, detalles, tipo", BkgBuscador);
        }

        private void ListaSintomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListaSintomas.SelectedItems.Count == 0)
                return;
            TxtDetalles.Text = ListaSintomas.SelectedItems[0].Text;
        }




    }
}
