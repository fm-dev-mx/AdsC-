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
    public partial class FrmConsultarHistorialFechas : Ventana
    {
        decimal IdProyecto = 0;
        string NombreProyecto = string.Empty;
        public FrmConsultarHistorialFechas(decimal idProyecto)
        {
            InitializeComponent();
            IdProyecto = idProyecto;
        }

        private void FrmConsultarHistorialMetas_Load(object sender, EventArgs e)
        {
            Proyecto proyecto = new Proyecto();
            proyecto.CargarDatos(IdProyecto);
            if (proyecto.TieneFilas())
                LblTitulo.Text +=  " " + IdProyecto + " " + proyecto.Fila().Celda("nombre").ToString();

            CargarRazones();

            CargarHistorial();
        }

        private void CargarRazones()
        {
            CmbRazon.Items.Add("TODOS");
             
            AjusteFecha ajustarFecha = new AjusteFecha();
            ajustarFecha.SeleccionarRazonesProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                CmbRazon.Items.Add(f.Celda("id_razon") + " - " + f.Celda("razon"));
            });

            if (CmbRazon.Items.Count > 0)
                CmbRazon.SelectedIndex = 0;
        }

        private void CargarHistorial()
        {
            int idRazon = 0;
            if (CmbRazon.Text != "TODOS")
                idRazon = Convert.ToInt32(CmbRazon.Text.Split('-')[0].Trim());

            DgvHistorial.Rows.Clear();

            AjusteFecha historial = new AjusteFecha();
            historial.SeleccionarProyecto(IdProyecto, idRazon).ForEach(delegate(Fila f)
            {
                string razon = string.Empty;
                string responsable = string.Empty;

                RazonAjusteFecha razones = new RazonAjusteFecha();
                razones.CargarDatos(Convert.ToInt32(f.Celda("razon")));
                if(razones.TieneFilas())
                    razon = razones.Fila().Celda("razon").ToString();

                Usuario usuario = new Usuario();
                usuario.CargarDatos(Convert.ToInt32(f.Celda("responsable")));
                if(usuario.TieneFilas())
                    responsable = usuario.Fila().Celda("nombre").ToString() + " " + usuario.Fila().Celda("paterno").ToString();

                DgvHistorial.Rows.Add(f.Celda("id"),
                                      razon,
                                      Convert.ToDateTime(f.Celda("fecha_entrega_actual")).ToString("MMM dd, yyyy"),
                                      Convert.ToDateTime(f.Celda("nueva_fecha")).ToString("MMM dd, yyyy"),
                                      f.Celda("tipo_ajuste"),
                                      responsable,
                                      Convert.ToDateTime(f.Celda("fecha_ajuste")).ToString("MMM dd, yyy"));
            });
        }

        private void CmbRazon_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
