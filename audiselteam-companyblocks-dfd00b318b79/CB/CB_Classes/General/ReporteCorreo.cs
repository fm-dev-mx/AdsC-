using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Permissions;
using iTextSharp.tool.xml.html.table;
using FluentFTP;
using CB;

namespace CB_Base.Classes
{
    public static class ReporteCorreo
    {
        
        public static void MandarTicketServicioAlCliente(int idTicket, string alignText, string fColor, string bgColor)
        {
            //int idTicket = 10;
            //string alignText = "center";
            //string fColor = "#FFFFFF";
            //string bgColor = "#000000";
            string LogoPath = "https://www.dropbox.com/s/yduybyzj8ofys00/Logo_audisel_inc.png?raw=1";
            
            TicketServicio ticketServicio = new TicketServicio();
            ticketServicio.CargarDatos(idTicket);

            HtmlDoc doc = new HtmlDoc();
            HtmlTable tablaPrincipal = new HtmlTable();
            tablaPrincipal = (HtmlTable)doc.addElement(new HtmlTable());
            tablaPrincipal.setBorder(1);

            HtmlTableRow filaTitulo = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());
            HtmlTableData tdImagen = (HtmlTableData)filaTitulo.addElement(new HtmlTableData());
            tdImagen.setColSpan(4);
            HtmlParrafo tdParrafo = (HtmlParrafo)tdImagen.addElement(new HtmlParrafo());
            HtmlImagen imagenAudisel = (HtmlImagen)tdParrafo.addElement(new HtmlImagen(LogoPath, "left", 200, 80));
            HtmlParrafo tdParrafoTexto = new HtmlParrafo();
            tdParrafoTexto = (HtmlParrafo)tdParrafo.addElement(new HtmlParrafo());
            tdParrafoTexto.setAlign("center");
            tdParrafoTexto.content = "<br>TICKET DE SERVICIO";

            //tr
            HtmlTableRow filaHeaders = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th Ticket
            HtmlTableHead thNumTicket = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thNumTicket.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColor = (HtmlFontColor)thNumTicket.addElement(new HtmlFontColor(fColor));
            fontColor.content = "NUM. TICKET";

            //th Tipo
            HtmlTableHead thTipo = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thTipo.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColortIPO = (HtmlFontColor)thTipo.addElement(new HtmlFontColor(fColor));
            fontColortIPO.content = "TIPO";

            //th fecha
            HtmlTableHead thFechaCreacionTicket = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thFechaCreacionTicket.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorFecha = (HtmlFontColor)thFechaCreacionTicket.addElement(new HtmlFontColor(fColor));
            fontColorFecha.content = "FECHA";

            //th estatus
            HtmlTableHead thEstatus = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thEstatus.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorEstatus = (HtmlFontColor)thEstatus.addElement(new HtmlFontColor(fColor));
            fontColorEstatus.content = "ESTATUS";

            //tr
            HtmlTableRow segundaFila = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td
            HtmlTableData tdTicket = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdTicket.setAlignText("center");
            tdTicket.content = "#" + Global.ObjetoATexto(ticketServicio.Fila().Celda("id"), "");

            //td tipo
            HtmlTableData tdTipo = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdTipo.content = Global.ObjetoATexto(ticketServicio.Fila().Celda("tipo"), "");

            //td fecha
            HtmlTableData tdFecha = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdFecha.content = Global.FechaATexto(ticketServicio.Fila().Celda("fecha_creacion"));

            //td estatus
            HtmlTableData tdCliente = new HtmlTableData();
            tdCliente = (HtmlTableData)segundaFila.addElement(new HtmlTableData());

            if (Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "") == "ABIERTO")
                tdCliente.setBgColor("#ff99cc"); //abierto
            else if (Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "") == "CERRADO")
                tdCliente.setBgColor("#b3ffb3"); //cerrado
            tdCliente.content = Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "");

            //tr
            HtmlTableRow filaProyecto = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th proyecto            
            HtmlTableHead thProyecto = (HtmlTableHead)filaProyecto.addElement(new HtmlTableHead());
            thProyecto.setOptions(2, alignText, bgColor);
            HtmlFontColor fontColorProyecto = (HtmlFontColor)thProyecto.addElement(new HtmlFontColor(fColor));
            fontColorProyecto.content = "PROYECTO";

            //th cliente
            HtmlTableHead thCliente = (HtmlTableHead)filaProyecto.addElement(new HtmlTableHead());
            thCliente.setOptions(2, alignText, bgColor);
            HtmlFontColor fontColorCliente = (HtmlFontColor)thCliente.addElement(new HtmlFontColor(fColor));
            fontColorCliente.content = "CLIENTE";

            //tr
            HtmlTableRow filaDetallesDelProyecto = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td proyecto
            Proyecto proyecto = new Proyecto();
            proyecto.CargarDatos(Convert.ToDecimal(ticketServicio.Fila().Celda("proyecto")));
            string datosProyecto = Convert.ToDecimal(ticketServicio.Fila().Celda("proyecto")).ToString("F2") + " " + proyecto.Fila().Celda("nombre");

            //td cliente
            ClienteContacto clienteContacto = new ClienteContacto();
            clienteContacto.CargarDatos(Convert.ToInt32(ticketServicio.Fila().Celda("contacto")));
            Cliente cliente = new Cliente();
            cliente.CargarDatos(Convert.ToInt32(clienteContacto.Fila().Celda("cliente")));
            string informacionContacto = "CLIENTE: " + cliente.Fila().Celda("nombre").ToString() + "<br>" +
                                         "CONTACTO: " + clienteContacto.Fila().Celda("nombre").ToString() + " " +
                                                        clienteContacto.Fila().Celda("apellidos").ToString() + "<br>" +
                                         "CORREO: " + clienteContacto.Fila().Celda("correo").ToString();

            HtmlTableData tdProyecto = (HtmlTableData)filaDetallesDelProyecto.addElement(new HtmlTableData());
            tdProyecto.setColSpan(2);
            tdProyecto.content = datosProyecto;

            HtmlTableData tdContacto = (HtmlTableData)filaDetallesDelProyecto.addElement(new HtmlTableData());
            tdContacto.setColSpan(2);
            tdContacto.content = informacionContacto;

            //tr
            HtmlTableRow filaDetallesDelTicket = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th detalles
            HtmlTableHead thDetallesTicketServicio = (HtmlTableHead)filaDetallesDelTicket.addElement(new HtmlTableHead());
            thDetallesTicketServicio.setOptions(4, alignText, bgColor);
            HtmlFontColor fontColorDetallesTicket = (HtmlFontColor)thDetallesTicketServicio.addElement(new HtmlFontColor(fColor));
            fontColorDetallesTicket.content = "DETALLES DEL TICKET DE SERVICIO";

            //tr
            HtmlTableRow filaDatosDetallesDelTicket = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td
            HtmlTableData tdDetallesTicketServicio = (HtmlTableData)filaDatosDetallesDelTicket.addElement(new HtmlTableData());
            tdDetallesTicketServicio.setColSpan(4);
            tdDetallesTicketServicio.content = ticketServicio.Fila().Celda("detalles").ToString();

            string tel = string.Empty;
            if (Global.UsuarioActual.Fila().Celda("tel").ToString() != "TBD" && Global.UsuarioActual.Fila().Celda("tel").ToString() != "N/A" && Global.UsuarioActual.Fila().Celda("tel").ToString() != "")
                tel = "Teléfono: " + Global.UsuarioActual.Fila().Celda("tel").ToString();

            string correoPersonal = Global.ObjetoATexto(Global.UsuarioActual.Fila().Celda("correo"), "");
            HtmlParrafo parrafoFinal = (HtmlParrafo)doc.addElement(new HtmlParrafo());
            parrafoFinal.setAlign("left");
            parrafoFinal.content = "Atentamente<br><br>" + Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " +
                                    Global.UsuarioActual.Fila().Celda("paterno").ToString() + "<br>Audisel Inc.<br>" + tel;

            string asunto = "Ticket de servicio #" + idTicket;
            string contenido = "Estimado " + clienteContacto.Fila().Celda("nombre").ToString() + " " + clienteContacto.Fila().Celda("apellidos").ToString() + ":<br><br>" +
                               "Hemos recibido su solicitud de soporte por tal motivo generemos " +
                               "el ticket de servicio #" + idTicket + " con el cual se le notificará el seguimiento " +
                               "de las acciones tomadas. <br><br>" + doc.ToString();

            string contactoCorreo = clienteContacto.Fila().Celda("correo").ToString();
            List<string> usuariosCopia = new List<string>();
            Usuario usuario = new Usuario();
            usuario.SeleccionarRol("SUPERVISOR DE CALIDAD").ForEach(delegate(Fila f)
            {
                usuariosCopia.Add(f.Celda("correo").ToString());
            });

            usuariosCopia.Add(Global.UsuarioActual.Fila().Celda("correo").ToString());

            Global.EnviarCorreo(asunto, contenido, contactoCorreo, usuariosCopia);
        }

        public static string MandarAvancesTicketServicioAlCliente(int idTicket, string alignText, string fColor, string bgColor)
        {
            string LogoPath = "https://www.dropbox.com/s/yduybyzj8ofys00/Logo_audisel_inc.png?raw=1";

            TicketServicio ticketServicio = new TicketServicio();
            ticketServicio.CargarDatos(idTicket);

            HtmlDoc doc = new HtmlDoc();
            HtmlTable tablaPrincipal = new HtmlTable();
            tablaPrincipal = (HtmlTable)doc.addElement(new HtmlTable());
            tablaPrincipal.setBorder(1);

            HtmlTableRow filaTitulo = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());
            HtmlTableData tdImagen = (HtmlTableData)filaTitulo.addElement(new HtmlTableData());
            tdImagen.setColSpan(4);
            HtmlParrafo tdParrafo = (HtmlParrafo)tdImagen.addElement(new HtmlParrafo());
            HtmlImagen imagenAudisel = (HtmlImagen)tdParrafo.addElement(new HtmlImagen(LogoPath, "left", 200, 80));
            HtmlParrafo tdParrafoTexto = new HtmlParrafo();
            tdParrafoTexto = (HtmlParrafo)tdParrafo.addElement(new HtmlParrafo());
            tdParrafoTexto.setAlign("center");
            tdParrafoTexto.content = "<br>TICKET DE SERVICIO";

            //tr
            HtmlTableRow filaHeaders = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th Ticket
            HtmlTableHead thNumTicket = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thNumTicket.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColor = (HtmlFontColor)thNumTicket.addElement(new HtmlFontColor(fColor));
            fontColor.content = "NUM. TICKET";

            //th Tipo
            HtmlTableHead thTipo = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thTipo.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColortIPO = (HtmlFontColor)thTipo.addElement(new HtmlFontColor(fColor));
            fontColortIPO.content = "TIPO";

            //th fecha
            HtmlTableHead thFechaCreacionTicket = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thFechaCreacionTicket.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorFecha = (HtmlFontColor)thFechaCreacionTicket.addElement(new HtmlFontColor(fColor));
            fontColorFecha.content = "FECHA";

            //th estatus
            HtmlTableHead thEstatus = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thEstatus.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorEstatus = (HtmlFontColor)thEstatus.addElement(new HtmlFontColor(fColor));
            fontColorEstatus.content = "ESTATUS";

            //tr
            HtmlTableRow segundaFila = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td
            HtmlTableData tdTicket = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdTicket.setAlignText("center");
            tdTicket.content = "#" + Global.ObjetoATexto(ticketServicio.Fila().Celda("id"), "");

            //td tipo
            HtmlTableData tdTipo = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdTipo.content = Global.ObjetoATexto(ticketServicio.Fila().Celda("tipo"), "");

            //td fecha
            HtmlTableData tdFecha = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdFecha.content = Global.FechaATexto(ticketServicio.Fila().Celda("fecha_creacion"));

            //td estatus
            HtmlTableData tdCliente = new HtmlTableData();
            tdCliente = (HtmlTableData)segundaFila.addElement(new HtmlTableData());

            if (Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "") == "ABIERTO")
                tdCliente.setBgColor("#ff99cc"); //abierto
            else if (Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "") == "CERRADO")
                tdCliente.setBgColor("#b3ffb3"); //cerrado
            tdCliente.content = Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "");

            //tr
            HtmlTableRow filaProyecto = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th proyecto            
            HtmlTableHead thProyecto = (HtmlTableHead)filaProyecto.addElement(new HtmlTableHead());
            thProyecto.setOptions(2, alignText, bgColor);
            HtmlFontColor fontColorProyecto = (HtmlFontColor)thProyecto.addElement(new HtmlFontColor(fColor));
            fontColorProyecto.content = "PROYECTO";

            //th cliente
            HtmlTableHead thCliente = (HtmlTableHead)filaProyecto.addElement(new HtmlTableHead());
            thCliente.setOptions(2, alignText, bgColor);
            HtmlFontColor fontColorCliente = (HtmlFontColor)thCliente.addElement(new HtmlFontColor(fColor));
            fontColorCliente.content = "CLIENTE";

            //tr
            HtmlTableRow filaDetallesDelProyecto = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td proyecto
            Proyecto proyecto = new Proyecto();
            proyecto.CargarDatos(Convert.ToDecimal(ticketServicio.Fila().Celda("proyecto")));
            string datosProyecto = Convert.ToDecimal(ticketServicio.Fila().Celda("proyecto")).ToString("F2") + " " + proyecto.Fila().Celda("nombre");

            //td cliente
            ClienteContacto clienteContacto = new ClienteContacto();
            clienteContacto.CargarDatos(Convert.ToInt32(ticketServicio.Fila().Celda("contacto")));
            Cliente cliente = new Cliente();
            cliente.CargarDatos(Convert.ToInt32(clienteContacto.Fila().Celda("cliente")));
            string informacionContacto = "CLIENTE: " + cliente.Fila().Celda("nombre").ToString() + "<br>" +
                                         "CONTACTO: " + clienteContacto.Fila().Celda("nombre").ToString() + " " +
                                                        clienteContacto.Fila().Celda("apellidos").ToString() + "<br>" +
                                         "CORREO: " + clienteContacto.Fila().Celda("correo").ToString();

            HtmlTableData tdProyecto = (HtmlTableData)filaDetallesDelProyecto.addElement(new HtmlTableData());
            tdProyecto.setColSpan(2);
            tdProyecto.content = datosProyecto;

            HtmlTableData tdContacto = (HtmlTableData)filaDetallesDelProyecto.addElement(new HtmlTableData());
            tdContacto.setColSpan(2);
            tdContacto.content = informacionContacto;

            //tr
            HtmlTableRow filaDetallesDelTicket = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th detalles
            HtmlTableHead thDetallesTicketServicio = (HtmlTableHead)filaDetallesDelTicket.addElement(new HtmlTableHead());
            thDetallesTicketServicio.setOptions(4, alignText, bgColor);
            HtmlFontColor fontColorDetallesTicket = (HtmlFontColor)thDetallesTicketServicio.addElement(new HtmlFontColor(fColor));
            fontColorDetallesTicket.content = "DETALLES DEL TICKET DE SERVICIO";

            //tr
            HtmlTableRow filaDatosDetallesDelTicket = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td
            HtmlTableData tdDetallesTicketServicio = (HtmlTableData)filaDatosDetallesDelTicket.addElement(new HtmlTableData());
            tdDetallesTicketServicio.setColSpan(4);
            tdDetallesTicketServicio.content = ticketServicio.Fila().Celda("detalles").ToString();

            //tr Thacciones
            HtmlTableRow filaThAcciones = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th detalles
            HtmlTableHead thAcciones = (HtmlTableHead)filaThAcciones.addElement(new HtmlTableHead());
            thAcciones.setOptions(4, alignText, bgColor);
            HtmlFontColor FontColoracciones = (HtmlFontColor)thAcciones.addElement(new HtmlFontColor(fColor));
            FontColoracciones.content = "NUEVAS ACCIONES CORRECTIVAS IMPLEMENTADAS";

            //tr acciones header
            HtmlTableRow FilaAccionesHeader = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //ThTipo
            HtmlTableHead thTipoAccion = (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thTipoAccion.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorTipoAccion = (HtmlFontColor)thTipoAccion.addElement(new HtmlFontColor(fColor));
            fontColorTipoAccion.content = "TIPO DE ACCION";

            //Th descripcion
            HtmlTableHead thDescripcionAccion = (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thDescripcionAccion.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorDescripcionAccion = (HtmlFontColor)thDescripcionAccion.addElement(new HtmlFontColor(fColor));
            fontColorDescripcionAccion.content = "DESCRIPCION";

            //Th fechaPromesa
            HtmlTableHead thFechaPromesa= (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thFechaPromesa.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorFechaPromesa = (HtmlFontColor)thFechaPromesa.addElement(new HtmlFontColor(fColor));
            fontColorFechaPromesa.content = "FECHA PROMESA";

            //Th fechaPromesa
            HtmlTableHead thEstatusAcciones= (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thEstatusAcciones.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorEstatusAcciones = (HtmlFontColor)thEstatusAcciones.addElement(new HtmlFontColor(fColor));
            fontColorEstatusAcciones.content = "ESTATUS";

            //tr acciones  
            int idNoConformidad = Convert.ToInt32(ticketServicio.Fila().Celda("no_conformidad"));
            Accion acciones = new Accion();
            acciones.SeleccionarAccionesNoNotificadas(idNoConformidad).ForEach(delegate(Fila f)
            {
                int tarea = Convert.ToInt32(f.Celda("tarea"));
                string tipo = f.Celda("tipo").ToString();

                TareasTopico tareasTopicos = new TareasTopico();
                tareasTopicos.CargarDatos(tarea).ForEach(delegate(Fila filaTarea)
                {
                    HtmlTableRow row = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());
                    HtmlTableData tdDatosTipoAcciones = (HtmlTableData)row.addElement(new HtmlTableData());
                    tdDatosTipoAcciones.content = f.Celda("tipo").ToString().ToUpper();

                    HtmlTableData tdDatosDescripcionAcciones = (HtmlTableData)row.addElement(new HtmlTableData());
                    tdDatosDescripcionAcciones.content = filaTarea.Celda("nombre").ToString().ToUpper() + "<br><br>" + filaTarea.Celda("descripcion").ToString().ToUpper();

                    HtmlTableData tdDatosFechaPromesaAcciones = (HtmlTableData)row.addElement(new HtmlTableData());
                    tdDatosFechaPromesaAcciones.content = Global.FechaATexto(filaTarea.Celda("fecha_promesa")).ToString().ToUpper();

                    HtmlTableData tdDatosEstatusAcciones = (HtmlTableData)row.addElement(new HtmlTableData());

                    if (filaTarea.Celda("estatus").ToString().ToUpper() == "PENDIENTE")
                        tdDatosEstatusAcciones.setBgColor("#ffff80"); //Pendiente
                    else if (filaTarea.Celda("estatus").ToString().ToUpper() == "EN PROCESO")
                        tdDatosEstatusAcciones.setBgColor("#b3ffb3"); //En proceso
                    else if (filaTarea.Celda("estatus").ToString().ToUpper() == "TERMINADO")
                        tdDatosEstatusAcciones.setBgColor("#b3ffb3"); //Terminado
                    else if (filaTarea.Celda("estatus").ToString().ToUpper() == "DETENIDO")
                        tdDatosEstatusAcciones.setBgColor("#ff99cc"); //Detenido

                    tdDatosEstatusAcciones.content = filaTarea.Celda("estatus").ToString().ToUpper();

                });
            });

            string tel = string.Empty;
            if (Global.UsuarioActual.Fila().Celda("tel").ToString() != "TBD" && Global.UsuarioActual.Fila().Celda("tel").ToString() != "N/A" && Global.UsuarioActual.Fila().Celda("tel").ToString() != "")
                tel = "Teléfono: " + Global.UsuarioActual.Fila().Celda("tel").ToString();

            string correoPersonal = Global.ObjetoATexto(Global.UsuarioActual.Fila().Celda("correo"), "");
            HtmlParrafo parrafoFinal = (HtmlParrafo)doc.addElement(new HtmlParrafo());
            parrafoFinal.setAlign("left");
            parrafoFinal.content = "Atentamente<br><br>" + Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " +
                                    Global.UsuarioActual.Fila().Celda("paterno").ToString() + "<br>Audisel Inc.<br>" + tel;

            string asunto = "FW: Ticket de servicio #" + ticketServicio.Fila().Celda("id").ToString();
            string contenido = "Estimado " + clienteContacto.Fila().Celda("nombre").ToString() + " " + clienteContacto.Fila().Celda("apellidos").ToString() + ":<br><br>" +
                               "<br>Le enviamos el presente correo para notificarle que se le está dando segumiento al soporte que nos solicitó en " +
                               "el ticket de servicio #" + ticketServicio.Fila().Celda("id").ToString() + ".<br><br>" + doc.ToString();

            string contactoCorreo = clienteContacto.Fila().Celda("correo").ToString();
            List<string> usuariosCopia = new List<string>();
            Usuario usuario = new Usuario();
            usuario.SeleccionarRol("SUPERVISOR DE CALIDAD").ForEach(delegate(Fila f)
            {
                usuariosCopia.Add(f.Celda("correo").ToString());
            });

            usuariosCopia.Add(correoPersonal);

            Global.EnviarCorreo(asunto, contenido, contactoCorreo, usuariosCopia);

            return doc.ToString();
            
        }

        public static void TicketServicioCerrado(int idTicket, string alignText, string fColor, string bgColor)
        {
            string LogoPath = "https://www.dropbox.com/s/yduybyzj8ofys00/Logo_audisel_inc.png?raw=1";

            TicketServicio ticketServicio = new TicketServicio();
            ticketServicio.CargarDatos(idTicket);

            HtmlDoc doc = new HtmlDoc();
            HtmlTable tablaPrincipal = new HtmlTable();
            tablaPrincipal = (HtmlTable)doc.addElement(new HtmlTable());
            tablaPrincipal.setBorder(1);

            HtmlTableRow filaTitulo = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());
            HtmlTableData tdImagen = (HtmlTableData)filaTitulo.addElement(new HtmlTableData());
            tdImagen.setColSpan(4);
            HtmlParrafo tdParrafo = (HtmlParrafo)tdImagen.addElement(new HtmlParrafo());
            HtmlImagen imagenAudisel = (HtmlImagen)tdParrafo.addElement(new HtmlImagen(LogoPath, "left", 200, 80));
            HtmlParrafo tdParrafoTexto = new HtmlParrafo();
            tdParrafoTexto = (HtmlParrafo)tdParrafo.addElement(new HtmlParrafo());
            tdParrafoTexto.setAlign("center");
            tdParrafoTexto.content = "<br>TICKET DE SERVICIO";

            //tr
            HtmlTableRow filaHeaders = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th Ticket
            HtmlTableHead thNumTicket = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thNumTicket.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColor = (HtmlFontColor)thNumTicket.addElement(new HtmlFontColor(fColor));
            fontColor.content = "NUM. TICKET";

            //th Tipo
            HtmlTableHead thTipo = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thTipo.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColortIPO = (HtmlFontColor)thTipo.addElement(new HtmlFontColor(fColor));
            fontColortIPO.content = "TIPO";

            //th fecha
            HtmlTableHead thFechaCreacionTicket = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thFechaCreacionTicket.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorFecha = (HtmlFontColor)thFechaCreacionTicket.addElement(new HtmlFontColor(fColor));
            fontColorFecha.content = "FECHA";

            //th estatus
            HtmlTableHead thEstatus = (HtmlTableHead)filaHeaders.addElement(new HtmlTableHead());
            thEstatus.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorEstatus = (HtmlFontColor)thEstatus.addElement(new HtmlFontColor(fColor));
            fontColorEstatus.content = "ESTATUS";

            //tr
            HtmlTableRow segundaFila = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td
            HtmlTableData tdTicket = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdTicket.setAlignText("center");
            tdTicket.content = "#" + Global.ObjetoATexto(ticketServicio.Fila().Celda("id"), "");

            //td tipo
            HtmlTableData tdTipo = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdTipo.content = Global.ObjetoATexto(ticketServicio.Fila().Celda("tipo"), "");

            //td fecha
            HtmlTableData tdFecha = (HtmlTableData)segundaFila.addElement(new HtmlTableData());
            tdFecha.content = Global.FechaATexto(ticketServicio.Fila().Celda("fecha_creacion"));

            //td estatus
            HtmlTableData tdCliente = new HtmlTableData();
            tdCliente = (HtmlTableData)segundaFila.addElement(new HtmlTableData());

            if (Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "") == "ABIERTO")
                tdCliente.setBgColor("#ff99cc"); //abierto
            else if (Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "") == "CERRADO")
                tdCliente.setBgColor("#b3ffb3"); //cerrado
            tdCliente.content = Global.ObjetoATexto(ticketServicio.Fila().Celda("estatus"), "");

            //tr
            HtmlTableRow filaProyecto = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th proyecto            
            HtmlTableHead thProyecto = (HtmlTableHead)filaProyecto.addElement(new HtmlTableHead());
            thProyecto.setOptions(2, alignText, bgColor);
            HtmlFontColor fontColorProyecto = (HtmlFontColor)thProyecto.addElement(new HtmlFontColor(fColor));
            fontColorProyecto.content = "PROYECTO";

            //th cliente
            HtmlTableHead thCliente = (HtmlTableHead)filaProyecto.addElement(new HtmlTableHead());
            thCliente.setOptions(2, alignText, bgColor);
            HtmlFontColor fontColorCliente = (HtmlFontColor)thCliente.addElement(new HtmlFontColor(fColor));
            fontColorCliente.content = "CLIENTE";

            //tr
            HtmlTableRow filaDetallesDelProyecto = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td proyecto
            Proyecto proyecto = new Proyecto();
            proyecto.CargarDatos(Convert.ToDecimal(ticketServicio.Fila().Celda("proyecto")));
            string datosProyecto = Convert.ToDecimal(ticketServicio.Fila().Celda("proyecto")).ToString("F2") + " " + proyecto.Fila().Celda("nombre");

            //td cliente
            ClienteContacto clienteContacto = new ClienteContacto();
            clienteContacto.CargarDatos(Convert.ToInt32(ticketServicio.Fila().Celda("contacto")));
            Cliente cliente = new Cliente();
            cliente.CargarDatos(Convert.ToInt32(clienteContacto.Fila().Celda("cliente")));
            string informacionContacto = "CLIENTE: " + cliente.Fila().Celda("nombre").ToString() + "<br>" +
                                         "CONTACTO: " + clienteContacto.Fila().Celda("nombre").ToString() + " " +
                                                        clienteContacto.Fila().Celda("apellidos").ToString() + "<br>" +
                                         "CORREO: " + clienteContacto.Fila().Celda("correo").ToString();

            HtmlTableData tdProyecto = (HtmlTableData)filaDetallesDelProyecto.addElement(new HtmlTableData());
            tdProyecto.setColSpan(2);
            tdProyecto.content = datosProyecto;

            HtmlTableData tdContacto = (HtmlTableData)filaDetallesDelProyecto.addElement(new HtmlTableData());
            tdContacto.setColSpan(2);
            tdContacto.content = informacionContacto;

            //tr
            HtmlTableRow filaDetallesDelTicket = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th detalles
            HtmlTableHead thDetallesTicketServicio = (HtmlTableHead)filaDetallesDelTicket.addElement(new HtmlTableHead());
            thDetallesTicketServicio.setOptions(4, alignText, bgColor);
            HtmlFontColor fontColorDetallesTicket = (HtmlFontColor)thDetallesTicketServicio.addElement(new HtmlFontColor(fColor));
            fontColorDetallesTicket.content = "DETALLES DEL TICKET DE SERVICIO";

            //tr
            HtmlTableRow filaDatosDetallesDelTicket = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //td
            HtmlTableData tdDetallesTicketServicio = (HtmlTableData)filaDatosDetallesDelTicket.addElement(new HtmlTableData());
            tdDetallesTicketServicio.setColSpan(4);
            tdDetallesTicketServicio.content = ticketServicio.Fila().Celda("detalles").ToString();

            //tr Thacciones
            HtmlTableRow filaThAcciones = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //th detalles
            HtmlTableHead thAcciones = (HtmlTableHead)filaThAcciones.addElement(new HtmlTableHead());
            thAcciones.setOptions(4, alignText, bgColor);
            HtmlFontColor FontColoracciones = (HtmlFontColor)thAcciones.addElement(new HtmlFontColor(fColor));
            FontColoracciones.content = "NUEVAS ACCIONES CORRECTIVAS IMPLEMENTADAS";

            //tr acciones header
            HtmlTableRow FilaAccionesHeader = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());

            //ThTipo
            HtmlTableHead thTipoAccion = (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thTipoAccion.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorTipoAccion = (HtmlFontColor)thTipoAccion.addElement(new HtmlFontColor(fColor));
            fontColorTipoAccion.content = "TIPO DE ACCION";

            //Th descripcion
            HtmlTableHead thDescripcionAccion = (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thDescripcionAccion.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorDescripcionAccion = (HtmlFontColor)thDescripcionAccion.addElement(new HtmlFontColor(fColor));
            fontColorDescripcionAccion.content = "DESCRIPCION";

            //Th fechaPromesa
            HtmlTableHead thFechaPromesa = (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thFechaPromesa.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorFechaPromesa = (HtmlFontColor)thFechaPromesa.addElement(new HtmlFontColor(fColor));
            fontColorFechaPromesa.content = "FECHA PROMESA";

            //Th fechaPromesa
            HtmlTableHead thEstatusAcciones = (HtmlTableHead)FilaAccionesHeader.addElement(new HtmlTableHead());
            thEstatusAcciones.setOptions(0, alignText, bgColor);
            HtmlFontColor fontColorEstatusAcciones = (HtmlFontColor)thEstatusAcciones.addElement(new HtmlFontColor(fColor));
            fontColorEstatusAcciones.content = "ESTATUS";

            //tr acciones  
            int idNoConformidad = Convert.ToInt32(ticketServicio.Fila().Celda("no_conformidad"));
            Accion acciones = new Accion();
            acciones.SeleccionarAcciones(idNoConformidad).ForEach(delegate(Fila f)
            {
                int tarea = Convert.ToInt32(f.Celda("tarea"));
                string tipo = f.Celda("tipo").ToString();

                TareasTopico tareasTopicos = new TareasTopico();
                tareasTopicos.CargarDatos(tarea).ForEach(delegate(Fila filaTarea)
                {
                    HtmlTableRow row = (HtmlTableRow)tablaPrincipal.addElement(new HtmlTableRow());
                    HtmlTableData tdDatosTipoAcciones = (HtmlTableData)row.addElement(new HtmlTableData());
                    tdDatosTipoAcciones.content = f.Celda("tipo").ToString().ToUpper();

                    HtmlTableData tdDatosDescripcionAcciones = (HtmlTableData)row.addElement(new HtmlTableData());
                    tdDatosDescripcionAcciones.content = filaTarea.Celda("nombre").ToString().ToUpper() + "<br><br>" + filaTarea.Celda("descripcion").ToString().ToUpper();

                    HtmlTableData tdDatosFechaPromesaAcciones = (HtmlTableData)row.addElement(new HtmlTableData());
                    tdDatosFechaPromesaAcciones.content = Global.FechaATexto(filaTarea.Celda("fecha_promesa")).ToString().ToUpper();

                    HtmlTableData tdDatosEstatusAcciones = (HtmlTableData)row.addElement(new HtmlTableData());

                    if (filaTarea.Celda("estatus").ToString().ToUpper() == "PENDIENTE")
                        tdDatosEstatusAcciones.setBgColor("#ffff80"); //Pendiente
                    else if (filaTarea.Celda("estatus").ToString().ToUpper() == "EN PROCESO")
                        tdDatosEstatusAcciones.setBgColor("#b3ffb3"); //En proceso
                    else if (filaTarea.Celda("estatus").ToString().ToUpper() == "TERMINADO")
                        tdDatosEstatusAcciones.setBgColor("#b3ffb3"); //Terminado
                    else if (filaTarea.Celda("estatus").ToString().ToUpper() == "DETENIDO")
                        tdDatosEstatusAcciones.setBgColor("#ff99cc"); //Detenido

                    tdDatosEstatusAcciones.content = filaTarea.Celda("estatus").ToString().ToUpper();

                });
            });

            string tel = string.Empty;
            if (Global.UsuarioActual.Fila().Celda("tel").ToString() != "TBD" && Global.UsuarioActual.Fila().Celda("tel").ToString() != "N/A" && Global.UsuarioActual.Fila().Celda("tel").ToString() != "")
                tel = "Teléfono: " + Global.UsuarioActual.Fila().Celda("tel").ToString();

            string correoPersonal = Global.ObjetoATexto(Global.UsuarioActual.Fila().Celda("correo"), "");
            HtmlParrafo parrafoFinal = (HtmlParrafo)doc.addElement(new HtmlParrafo());
            parrafoFinal.setAlign("left");
            parrafoFinal.content = "Atentamente<br><br>" + Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " +
                                    Global.UsuarioActual.Fila().Celda("paterno").ToString() + "<br>Audisel Inc.<br>" + tel;

            string asunto = "FW: Ticket de servicio #" + ticketServicio.Fila().Celda("id").ToString();
            string contenido = "Estimado " + clienteContacto.Fila().Celda("nombre").ToString() + " " + clienteContacto.Fila().Celda("apellidos").ToString() + ":<br><br>" +
                               "<br>Le enviamos el presente correo para notificarle que " +
                               "el ticket de servicio #" + ticketServicio.Fila().Celda("id").ToString() + " ha sido cerrado, si tiene duda o aclaraciones favor de contactarnos.<br><br>" + doc.ToString();

            string contactoCorreo = clienteContacto.Fila().Celda("correo").ToString();
            List<string> usuariosCopia = new List<string>();
            Usuario usuario = new Usuario();
            usuario.SeleccionarRol("SUPERVISOR DE CALIDAD").ForEach(delegate(Fila f)
            {
                usuariosCopia.Add(f.Celda("correo").ToString());
            });

            usuariosCopia.Add(Global.UsuarioActual.Fila().Celda("correo").ToString());

            Global.EnviarCorreo(asunto, contenido, contactoCorreo, usuariosCopia);
        }

        public static bool ReporteDeMinuta(decimal idProyecto, string nombreProyecto, int idTarea)
        {
            string contenido = string.Empty;
            string notas = string.Empty;
            List<string> usuariosCopia = new List<string>();
            string titulo = "MINUTA DE SINCRONIZACION DEL PROYECTO " + idProyecto + " " + nombreProyecto ;
            
            //saludo
            List<string> saludo = new List<string>();
            saludo.Add("Que tal Equipo,");
            saludo.Add("Hola Equipo,");
            saludo.Add("Que tal Team,");

            DateTime horaActual = DateTime.Now;

            if(horaActual.ToString("{HH:mm: tt}").Contains("AM"))
            {
                saludo.Add("Buenos dias Equipo,");
                saludo.Add("Buenos dias a todos,");
                saludo.Add("Muy buen dia Equipo,");
                saludo.Add("Muy buenos dias a todos,");
                saludo.Add("Excelente mañana equipo,");
                saludo.Add("Buen dia Team,");
            }
            else
            {
                saludo.Add("Buenas tardes Equipo,");
                saludo.Add("Buenas tardes a todos,");
                saludo.Add("Muy buenas tardes Equipo,");
                saludo.Add("Muy buena tarde a todos,");
                saludo.Add("Excelente tarde equipo,");
                saludo.Add("Buena tarde Team,");
            }


            Random random = new Random();
            int indexSaludo = random.Next(saludo.Count);
            string strSaludo = saludo[indexSaludo];

            List<string> listaIntroduccion = new List<string>();
            listaIntroduccion.Add("A continuacion la minuta de la junta de sincronizacion del dia ");
            listaIntroduccion.Add("A continuacion la minuta y lista de pendientes a raiz de la junta de hoy ");
            listaIntroduccion.Add("Abajo la lista de pendientes y puntos de la junta de sincronizacion del dia de hoy ");
            int indexIntroduccion = random.Next(listaIntroduccion.Count);

            string introduccion = listaIntroduccion[indexIntroduccion] + Global.FechaATexto(DateTime.Today.Date, false) + ".<br><br>";
            string pendientes = string.Empty;
            
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", idProyecto);

            pendientes = "<table border=1>";

            TareasTopico tareas = new TareasTopico();
            tareas.SeleccionarDatos("topico in (SELECT id FROM topicos WHERE proyecto=@proyecto)", parametros);
            tareas.Filas().ForEach(delegate (Fila f)
            {
                //buscar nick de los responsables
                string strResponsable = string.Empty;
                TareasResponsables responsables = new TareasResponsables();
                responsables.SeleccionarTarea(Convert.ToInt32(f.Celda("id"))).ForEach(delegate (Fila filaResponsable)
                {
                    Usuario nickName = new Usuario();
                    nickName.BuscarPorNombre(filaResponsable.Celda("responsable").ToString());
                    if(nickName.TieneFilas())
                    {
                        object apodo = nickName.Fila().Celda("nick_name");
                        if(apodo != null)
                            strResponsable += apodo.ToString() + "<br>";
                        else
                            strResponsable += filaResponsable.Celda("responsable") + "<br>";
                    }
                    else
                    {
                        strResponsable += filaResponsable.Celda("responsable") + "<br>";
                    }
                });

                //involucrados
            /*    TareaInvolucrados involucrados = new TareaInvolucrados();
                involucrados.SeleccionarTarea(Convert.ToInt32(f.Celda("id"))).ForEach(delegate (Fila filaInvolucrado)
                {
                    usuariosCopia.Add(filaInvolucrado.Celda("correo").ToString());
                });*/

                //cuerpo
                pendientes += "<tr>";  
                pendientes += "<td colspan=3 align='center'><b>" + f.Celda("nombre").ToString() + "</b></td>";
                pendientes += "</tr>";
                pendientes += "<tr>";
                pendientes += "<th>RESPONSABLE(S)</th>";
                pendientes += "<th>PRIORIDAD</th>";
                pendientes += "<th>FECHA PROMESA</th>";
                pendientes += "</tr>";
                pendientes += "<tr>";
                pendientes += "<td>" +strResponsable  + "</td>";
                pendientes += "<td>" + f.Celda("prioridad").ToString() + "</td>";
                pendientes += "<td>" + Global.FechaATexto(f.Celda("fecha_promesa"), false) + "</td>";
                pendientes += "</tr>";
                pendientes += "<tr>";
                pendientes += "<td colspan=3 >" + f.Celda("descripcion") + "</td>";
                pendientes += "</tr>";
            });

            pendientes += "</table><br>NOTAS<br>";

            //notas
            Topico topico = new Topico();
            topico.CargarTopicosDeProyecto(idProyecto).ForEach(delegate (Fila f)
            {
                object nota = f.Celda("notas");
                if (nota != null)
                    notas += f.Celda("notas") + "<br>";
            });


            //despedida
            List<string> despedida = new List<string>();
            despedida.Add("Una vez más, ¡buen trabajo!");
            despedida.Add("Sinceramente gracias por el apoyo y el trabajo que estan haciendo.");
            despedida.Add("Agradezco una vez más el apoyo brindado durante el seguimiento de este proyecto");
            despedida.Add("Muchas gracias por el apoyo");
            despedida.Add("Buen trabajo con el seguimiento vamos a trabajar para conseguir la metas");
            despedida.Add("Vamos a continuar con el seguimiento y cumplimiento de las metas, gracias por su apoyo con estos pendientes.");
            despedida.Add("El seguimiento oportuno de estas tareas nos mantendran alineador a conseguir el éxito de este proyecto.");
            despedida.Add("Es importante su apoyo con el seguimiento de sus respectivas tareas, para cualquer duda pueden contar conmigo.");
            despedida.Add("No duden en buscar apoyo para cualquier asistencia con alguna de las tareas.");
            despedida.Add("Gracias por el buen trabajo hasta ahora, por favor no perder del radas estos importantes puntos.");
            despedida.Add("Agradezco su apoyo con el seguimiento respectivo, para cualquier duda estoy disponible.");
            despedida.Add("Mil gracias por el apoyo, vamos a continuar con el seguimiento oportuno y estaremos al pendiente de si alquien requiere ayuda.");
            despedida.Add("Siempre pueden contar con el apoyo conjunto para lograr estos objetivos.");
            despedida.Add("Vamos a trabajar tan bien como hasta ahora para buscar concluir con estas tareas de la mejor forma posible.");

            int despedidaIndex = random.Next(despedida.Count);
            string strDespedida = despedida[despedidaIndex];

            contenido = "<br><b>" + titulo + "</b><br><br>" + strSaludo + "<br><br><br>" + introduccion + pendientes + notas + strDespedida + "<br>" + Global.UsuarioActual.NombreCompleto();
            //usuariosCopia.Add(Global.UsuarioActual.Fila().Celda("correo").ToString());

            //responsables
            TareasResponsables resp = new TareasResponsables();
            resp.SeleccionarTarea(idTarea).ForEach(delegate (Fila f)
            {
                object correoAlterno = f.Celda("correo_alterno");
                if (correoAlterno == null)
                {
                    Usuario usuario = new Usuario();
                    usuario.CargarDatos(Convert.ToInt32(f.Celda("id_responsable")));

                    if (usuario.TieneFilas())
                    {
                        if (!usuariosCopia.Contains(usuario.Fila().Celda("correo").ToString()))
                            usuariosCopia.Add(usuario.Fila().Celda("correo").ToString());
                    }
                }
                else
                {
                    if (!usuariosCopia.Contains(f.Celda("correo_alterno").ToString()))
                        usuariosCopia.Add(f.Celda("correo_alterno").ToString());
                }
            });

            //involucrados
            TareaInvolucrados invol = new TareaInvolucrados();
            invol.SeleccionarTarea(idTarea).ForEach(delegate (Fila f)
            {
                object correoAlterno = f.Celda("correo_alterno");
                if (correoAlterno == null)
                {
                    if (!usuariosCopia.Contains(f.Celda("correo").ToString()))
                        usuariosCopia.Add(f.Celda("correo").ToString());
                }
                else
                {
                    if (!usuariosCopia.Contains(f.Celda("correo_alterno").ToString()))
                        usuariosCopia.Add(f.Celda("correo_alterno").ToString());
                }
            });


            return Global.EnviarCorreo(titulo, contenido, Global.UsuarioActual.Fila().Celda("correo").ToString(), usuariosCopia);
        }
    }
}
