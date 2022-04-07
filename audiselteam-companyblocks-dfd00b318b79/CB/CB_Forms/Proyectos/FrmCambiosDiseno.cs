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
    public partial class FrmCambiosDiseno : Form
    {
        decimal IdProyecto = 0;
        Proyecto ProyectoCargado = new Proyecto(); 

        public FrmCambiosDiseno(decimal idProyecto)
        {
            InitializeComponent();
            ProyectoCargado.CargarDatos(idProyecto);
            LblTitulo.Text += " DEL PROYECTO " + idProyecto.ToString("F2") + " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            IdProyecto = idProyecto;
        }

        private void FrmCambiosDiseno_Load(object sender, EventArgs e)
        {
            nuevoToolStripMenuItem.Enabled = Global.VerificarPrivilegio("PROYECTOS", "CAMBIO DE DISENO");
            WindowState = FormWindowState.Maximized;
            CargarCambiosDiseno();
        }

        public void CargarCambiosDiseno()
        {
            DgvCambiosDiseno.Rows.Clear();
            CambioDiseno.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                DgvCambiosDiseno.Rows.Add(f.Celda("id"), f.Celda("tipo_cambio"), f.Celda("motivo_cambio"), f.Celda("alcance"), f.Celda("modulos_afectados"), f.Celda("usuario_solicitud"), f.Celda("fecha_solicitud"));
            });
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoCambioDiseno nuevoCambio = new FrmNuevoCambioDiseno(IdProyecto);


            if(nuevoCambio.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (nuevoCambio.Tipo == "MECANICO")
                    NuevoCambioMecanico(nuevoCambio);

                CargarCambiosDiseno();
            }
        }

        public void NuevoCambioMecanico(FrmNuevoCambioDiseno nuevoCambio)
        {
            string strModulosAfectados = string.Empty;
            Modulo moduloAfectado = new Modulo();

            int i = 1;
            nuevoCambio.ModulosAfectados.ForEach(delegate(int idModulo)
            {
                moduloAfectado.CargarDatos(idModulo);

                if (moduloAfectado.TieneFilas())
                {
                    if (nuevoCambio.Motivo == "CAMBIO DEL CLIENTE")
                        moduloAfectado.Fila().ModificarCelda("estatus_liberacion", "PENDIENTE");

                    moduloAfectado.Fila().ModificarCelda("estatus_aprobacion", "PENDIENTE");
                    moduloAfectado.GuardarDatos();
                }

                strModulosAfectados += moduloAfectado.Fila().Celda("subensamble").ToString().PadLeft(2, '0');
                if (nuevoCambio.ModulosAfectados.Count < i)
                    strModulosAfectados += ", ";
                i++;
            });

            Fila insertarNoConformidad = new Fila();
            if (nuevoCambio.Motivo == "ERROR DE DISEÑO" && nuevoCambio.Tipo == "MECANICO")
            {
                insertarNoConformidad.AgregarCelda("tipo", "INTERNA");
                insertarNoConformidad.AgregarCelda("proceso_origen", "DISEÑO MECANICO");
                insertarNoConformidad.AgregarCelda("comentarios", nuevoCambio.Alcance);
                insertarNoConformidad.AgregarCelda("fecha_creacion", DateTime.Now);
                insertarNoConformidad.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
                insertarNoConformidad.AgregarCelda("disposicion", "CAMBIO DE DISEÑO");
                insertarNoConformidad.AgregarCelda("usuario_liberacion", Global.UsuarioActual.Fila().Celda("id"));
                insertarNoConformidad.AgregarCelda("fecha_liberacion", DateTime.Now);
                insertarNoConformidad.AgregarCelda("estatus", "LIBERADO");
                insertarNoConformidad.AgregarCelda("cantidad_ok", "0");
                insertarNoConformidad.AgregarCelda("cantidad_nok", (i-1));
                insertarNoConformidad.AgregarCelda("proceso_fabricacion", "0");
                insertarNoConformidad.AgregarCelda("plano", "0");
                insertarNoConformidad.AgregarCelda("proceso_fabricacion_rechazado", "0");
                insertarNoConformidad.AgregarCelda("probabilidad_ocurrencia", nuevoCambio.RiesgoTexto);
                //insertarNoConformidad = NoConformidad.Modelo().Insertar(insertarNoConformidad);
            }

            Fila filaCambio = new Fila();
            filaCambio.AgregarCelda("proyecto", IdProyecto);
            filaCambio.AgregarCelda("tipo_cambio", nuevoCambio.Tipo);
            filaCambio.AgregarCelda("motivo_cambio", nuevoCambio.Motivo);
            filaCambio.AgregarCelda("alcance", nuevoCambio.Alcance);
            filaCambio.AgregarCelda("usuario_solicitud", Global.UsuarioActual.NombreCompleto());
            filaCambio.AgregarCelda("fecha_solicitud", DateTime.Now);
            filaCambio.AgregarCelda("modulos_afectados", strModulosAfectados);
            filaCambio.AgregarCelda("usuario_realizacion", "N/A");
            filaCambio.AgregarCelda("estatus", "PENDIENTE");
            filaCambio.AgregarCelda("nivel_riesgo", nuevoCambio.NivelRiesgo);
            filaCambio.AgregarCelda("no_conformidad", insertarNoConformidad.Celda("id"));
            filaCambio = CambioDiseno.Modelo().Insertar(filaCambio);

            nuevoCambio.ModulosAfectados.ForEach(delegate(int idModulo)
            {
                moduloAfectado.CargarDatos(idModulo);
                if (moduloAfectado.TieneFilas())
                {
                    moduloAfectado.Fila().ModificarCelda("cambio_diseno", filaCambio.Celda("id"));
                    moduloAfectado.GuardarDatos();
                }
            });
        }
    }
}
