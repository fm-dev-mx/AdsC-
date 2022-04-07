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
    public partial class FrmAgregarEtapa : Ventana
    {
        decimal IdProyecto = 0;
        int IdEtapa = 0;
        EtapaProyecto Etapas = new EtapaProyecto();
        public FrmAgregarEtapa(decimal proyecto, int idEtapa=0)
        {
            InitializeComponent();
            IdProyecto = proyecto;
            IdEtapa = idEtapa;
        }

        private void CargarEtapas()
        {
            CmbEtapa.Items.Clear();
            Etapa.Modelo().Etapas().ForEach(delegate(Fila f) 
            {
                CmbEtapa.Items.Add(f.Celda("etapa"));
            });
        }

        private void CargarDatosEtapa()
        {
            CmbEtapa.Items.Clear();
            Etapas.CargarDatos(IdEtapa);
            string nombre = Etapas.Fila().Celda("nombre").ToString();
            CmbEtapa.Items.Add(nombre);
            CmbEtapa.SelectedItem = nombre;
            DtInicio.Value = Convert.ToDateTime(Etapas.Fila().Celda("inicio"));
            DtCierre.Value = Convert.ToDateTime(Etapas.Fila().Celda("cierre"));
            LblTitulo.Text = "EDITAR ETAPA";
            BtnRegistrar.Text = "Editar";
            CmbEtapa.Enabled = false;
        }

        private void NuevaEtapa()
        {
            if (CmbEtapa.Text == "")
                return;
 
            string fechaInicio = DtInicio.Value.ToString("MMM dd yyy hh:mm:ss tt");
            string fechaCierre = DtCierre.Value.ToString("MMM dd yyy hh:mm:ss tt");
            Fila nuevaEtapa = new Fila();
            nuevaEtapa.AgregarCelda("proyecto", IdProyecto);
            nuevaEtapa.AgregarCelda("nombre", CmbEtapa.Text);
            nuevaEtapa.AgregarCelda("inicio",Convert.ToDateTime(fechaInicio));
            nuevaEtapa.AgregarCelda("cierre", Convert.ToDateTime(fechaCierre));
            EtapaProyecto.Modelo().Insertar(nuevaEtapa);
            DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void EditarEtapa()
        {
            string fechaInicio = DtInicio.Value.ToString("MMM dd yyy hh:mm:ss tt");
            string fechaCierre = DtCierre.Value.ToString("MMM dd yyy hh:mm:ss tt");

            Etapas.CargarDatos(IdEtapa);
            if (Etapas.TieneFilas())
            {
                Etapas.Fila().ModificarCelda("inicio", Convert.ToDateTime(fechaInicio));
                Etapas.Fila().ModificarCelda("cierre", Convert.ToDateTime(fechaCierre));
                Etapas.GuardarDatos();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);   
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAgregarEtapa_Load(object sender, EventArgs e)
        {
            if (IdEtapa == 0)
                CargarEtapas();
            else
                CargarDatosEtapa();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (IdEtapa == 0)
                NuevaEtapa();
            else
                EditarEtapa();
        }
    }
}
