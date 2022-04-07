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
using System.IO;

namespace CB
{
    public partial class FrmDetallesPlanoFabricacion : Form
    {
        PlanoProyecto plano = new PlanoProyecto();

        public FrmDetallesPlanoFabricacion(int idPlano)
        {
            InitializeComponent();
            CargarDatosPlano(idPlano);
            CargarDimensionesCriticas(idPlano);
        }

        public void CargarDatosPlano(int idPlano)
        {
            plano.CargarDatos(idPlano);

            object creacion = plano.Fila().Celda("fecha_creacion");
            object asignacion = plano.Fila().Celda("fecha_asignacion");
            object terminado = plano.Fila().Celda("fecha_terminado");
            object entregado = plano.Fila().Celda("fecha_entrega");
            int cotizacion_final = Convert.ToInt32(plano.Fila().Celda("cotizacion_final"));
            string cantidadPiezas = plano.Fila().Celda("cantidad").ToString();
            string piezasRecibidas = plano.Fila().Celda("recibido").ToString();
            object recibidoFecha = plano.Fila().Celda("fecha_recibido");
            string proveedor_maquinado = plano.Fila().Celda("proveedor_maquinado").ToString();
            string revisado_por = plano.Fila().Celda("usuario_revision").ToString();
            object revision = plano.Fila().Celda("fecha_revision");
            object ensambladoFecha = plano.Fila().Celda("fecha_ensamblado");
            object retrabajoFecha = plano.Fila().Celda("fecha_retrabajo");
            object perdidoFecha = plano.Fila().Celda("fecha_perdido");
            object recibidoEnsambleFecha = plano.Fila().Celda("fecha_recibido_ensamble");
            object comentariosRetrabajo = plano.Fila().Celda("comentarios_retrabajo");
            object comentariosEnsamble = plano.Fila().Celda("comentarios_ensamble");

            string strComentariosRetrabajo = "";
            if (comentariosRetrabajo != null)
                strComentariosRetrabajo = comentariosRetrabajo.ToString();

            string strComentariosEnsamble = "";
            if(comentariosEnsamble != null )
                strComentariosEnsamble = comentariosEnsamble.ToString();

            PlanoCotizacion cotizacion = new PlanoCotizacion();

            if (cotizacion_final != 0)
                cotizacion.CargarDatos(cotizacion_final);

            ListViewItem numeroPlano = new ListViewItem("Número: ");
            numeroPlano.SubItems.Add(plano.Fila().Celda("nombre_archivo").ToString());
            numeroPlano.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(numeroPlano);

            ListViewItem fechaPlano = new ListViewItem("Fecha creación: ");
            if (creacion == null)
                fechaPlano.SubItems.Add("N/A");
            else
                fechaPlano.SubItems.Add(Convert.ToDateTime(creacion).ToString("MMM dd yyyy, hh:mm tt"));
            fechaPlano.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(fechaPlano);

            ListViewItem usuarioCreacion = new ListViewItem("Creado por: ");
            usuarioCreacion.SubItems.Add(plano.Fila().Celda("usuario_creacion").ToString());
            usuarioCreacion.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(usuarioCreacion);

            ListViewItem tipo = new ListViewItem("Tipo de trabajo: ");
            tipo.SubItems.Add(plano.Fila().Celda("tipo").ToString());
            tipo.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(tipo);

            ListViewItem cantidad = new ListViewItem("Cantidad: ");
            cantidad.SubItems.Add(cantidadPiezas);
            cantidad.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(cantidad);

            ListViewItem material = new ListViewItem("Material: ");
            material.SubItems.Add(plano.Fila().Celda("material").ToString());
            material.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(material);

            ListViewItem size = new ListViewItem("Stock size: ");
            size.SubItems.Add(plano.Fila().Celda("size").ToString());
            size.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(size);

            ListViewItem tratamiento = new ListViewItem("Tratamiento: ");
            tratamiento.SubItems.Add(plano.Fila().Celda("tratamiento").ToString());
            tratamiento.Group = LvInfoPieza.Groups["General"];
            LvInfoPieza.Items.Add(tratamiento);

            ListViewItem revisado = new ListViewItem("Revisado por: ");
            revisado.SubItems.Add(revisado_por);
            revisado.Group = LvInfoPieza.Groups["Revision"];
            LvInfoPieza.Items.Add(revisado);

            ListViewItem fechaRevision = new ListViewItem("Fecha revisión: ");
            if (revision == null)
                fechaRevision.SubItems.Add("N/A");
            else
                fechaRevision.SubItems.Add(Convert.ToDateTime(revision).ToString("MMM dd yyyy, hh:mm tt"));
            fechaRevision.Group = LvInfoPieza.Groups["Revision"];
            LvInfoPieza.Items.Add(fechaRevision);

            ListViewItem estatus = new ListViewItem("Estatus fabricación: ");
            estatus.SubItems.Add(plano.Fila().Celda("estatus").ToString());
            estatus.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(estatus);

            ListViewItem proveedorMaquinado = new ListViewItem("Fabricado por: ");
            proveedorMaquinado.SubItems.Add(proveedor_maquinado);
            proveedorMaquinado.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(proveedorMaquinado);

            ListViewItem precio = new ListViewItem("Cotización: ");
            if (cotizacion.TieneFilas() && Global.VerificarPrivlegio("GENERAL", "VISUALIZAR COSTOS") )
            {
                string precio_unitario = String.Format("{0:C}", Convert.ToDecimal(cotizacion.Fila().Celda("precio_final")));
                string tiempo_entrega = cotizacion.Fila().Celda("tiempo_final").ToString();
                precio.SubItems.Add(precio_unitario + " por pieza / " + tiempo_entrega + " dia(s)");
            }
            else
                precio.SubItems.Add("N/A");
            precio.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(precio);

            ListViewItem fechaAsignacion = new ListViewItem("Fecha asignación: ");
            if (asignacion == null)
                fechaAsignacion.SubItems.Add("N/A");
            else
                fechaAsignacion.SubItems.Add(Convert.ToDateTime(asignacion).ToString("MMM dd yyyy, hh:mm tt"));
            fechaAsignacion.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(fechaAsignacion);

            ListViewItem proveedorTratamiento = new ListViewItem("Tratamiento por: ");
            proveedorTratamiento.SubItems.Add(plano.Fila().Celda("proveedor_tratamiento").ToString());
            proveedorTratamiento.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(proveedorTratamiento);

            ListViewItem recibido = new ListViewItem("Recibido: ");
            recibido.SubItems.Add( piezasRecibidas + " de " + cantidadPiezas  );
            recibido.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(recibido);

            ListViewItem recibidoFabricacion = new ListViewItem("Fecha recibido: ");
            if (recibidoFecha == null)
                recibidoFabricacion.SubItems.Add("N/A");
            else
                recibidoFabricacion.SubItems.Add(Convert.ToDateTime(recibidoFecha).ToString("MMM dd yyyy, hh:mm tt"));
            recibidoFabricacion.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(recibidoFabricacion);

            ListViewItem fechaTerminado = new ListViewItem("Fecha terminado: ");
            if (terminado == null)
                fechaTerminado.SubItems.Add("N/A");
            else
                fechaTerminado.SubItems.Add(Convert.ToDateTime(terminado).ToString("MMM dd yyyy, hh:mm tt"));
            fechaTerminado.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(fechaTerminado);

            ListViewItem usuarioEntrega = new ListViewItem("Entregado a: ");
            usuarioEntrega.SubItems.Add(plano.Fila().Celda("usuario_entrega").ToString());
            usuarioEntrega.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(usuarioEntrega);

            ListViewItem fechaEntrega = new ListViewItem("Fecha entrega: ");
            if (entregado == null)
                fechaEntrega.SubItems.Add("N/A");
            else
                fechaEntrega.SubItems.Add(Convert.ToDateTime(entregado).ToString("MMM dd yyyy, hh:mm tt"));
            fechaEntrega.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(fechaEntrega);

            ListViewItem folioEntrega = new ListViewItem("Folio entrega: ");
            folioEntrega.SubItems.Add(plano.Fila().Celda("folio_entrega").ToString());
            folioEntrega.Group = LvInfoPieza.Groups["Fabricacion"];
            LvInfoPieza.Items.Add(folioEntrega);

            ListViewItem estatusEnsamble = new ListViewItem("Estatus ensamble: ");
            estatusEnsamble.SubItems.Add(plano.Fila().Celda("estatus_ensamble").ToString());
            estatusEnsamble.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(estatusEnsamble);

            ListViewItem fechaRecibidoEnsamble = new ListViewItem("Fecha recibido: ");
            if (recibidoEnsambleFecha == null)
                fechaRecibidoEnsamble.SubItems.Add("N/A");
            else
                fechaRecibidoEnsamble.SubItems.Add(plano.Fila().Celda("fecha_recibido_ensamble").ToString());
            fechaRecibidoEnsamble.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(fechaRecibidoEnsamble);

            ListViewItem usuarioRecibidoEnsamble = new ListViewItem("Recibido por: ");
            usuarioRecibidoEnsamble.SubItems.Add(plano.Fila().Celda("usuario_recibido_ensamble").ToString());
            usuarioRecibidoEnsamble.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(usuarioRecibidoEnsamble);

            ListViewItem fechaEnsamblado = new ListViewItem("Fecha de ensamble: ");
            if( ensambladoFecha == null )
                fechaEnsamblado.SubItems.Add("N/A");
            else
                fechaEnsamblado.SubItems.Add(plano.Fila().Celda("fecha_ensamblado").ToString());
            fechaEnsamblado.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(fechaEnsamblado);

            ListViewItem usuarioEnsamblado = new ListViewItem("Ensamblado por: ");
            usuarioEnsamblado.SubItems.Add(plano.Fila().Celda("usuario_ensamblado").ToString());
            usuarioEnsamblado.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(usuarioEnsamblado);

            ListViewItem fechaRetrabajo = new ListViewItem("Fecha de retrabajo: ");
            if (retrabajoFecha == null)
                fechaRetrabajo.SubItems.Add("N/A");
            else
                fechaRetrabajo.SubItems.Add(plano.Fila().Celda("fecha_retrabajo").ToString());
            fechaRetrabajo.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(fechaRetrabajo);

            ListViewItem usuarioRetrabajo = new ListViewItem("Retrabajo solicitado por: ");
            usuarioRetrabajo.SubItems.Add(plano.Fila().Celda("usuario_retrabajo").ToString());
            usuarioRetrabajo.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(usuarioRetrabajo);


            ListViewItem fechaPerdido = new ListViewItem("Fecha perdido: ");
            if (perdidoFecha == null)
                fechaPerdido.SubItems.Add("N/A");
            else
                fechaPerdido.SubItems.Add(plano.Fila().Celda("fecha_perdido").ToString());
            fechaPerdido.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(fechaPerdido);

            ListViewItem usuarioPerdido = new ListViewItem("Reportado perdido por: ");
            usuarioPerdido.SubItems.Add(plano.Fila().Celda("usuario_perdido").ToString());
            usuarioPerdido.Group = LvInfoPieza.Groups["Ensamble"];
            LvInfoPieza.Items.Add(usuarioPerdido);

            TxtComentariosRetrabajo.Text = strComentariosRetrabajo;
            TxtComentariosEnsamble.Text = strComentariosEnsamble;
            TxtComentariosRevision.Text = plano.Fila().Celda("comentarios_revision").ToString();
        }

        public void CargarDimensionesCriticas(int IdPlano)
        {
            DgvDimensiones.Rows.Clear();

            DimensionCritica.Modelo().SeleccionarPlano(IdPlano).ForEach(delegate(Fila dim)
            {
                DgvDimensiones.Rows.Add( dim.Celda("descripcion"), dim.Celda("nominal"), dim.Celda("minimo"), dim.Celda("maximo"), dim.Celda("instrumento_medicion") );
            });
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDescargarDXF_Click(object sender, EventArgs e)
        {
            ArchivoPlanoDXF dxf = new ArchivoPlanoDXF();
            dxf.SeleccionarDePlano(Convert.ToInt32(plano.Fila().Celda("id")));

            if( !dxf.TieneFilas() )
            {
                MessageBox.Show("Este plano no tiene un archivo DXF asignado");
            }
            else
            {
                saveDXF.FileName = plano.Fila().Celda("nombre_archivo").ToString() + ".dxf";
                saveDXF.Filter = "DXF|*.dxf";
                saveDXF.DefaultExt = ".dxf";
                
                if( saveDXF.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                {
                    File.WriteAllBytes(saveDXF.FileName, (byte[])dxf.Fila().Celda("archivo"));
                }
            }
        }

       
    }
}
