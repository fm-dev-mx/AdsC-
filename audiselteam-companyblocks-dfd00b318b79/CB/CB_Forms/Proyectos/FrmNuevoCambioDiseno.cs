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
    public partial class FrmNuevoCambioDiseno : Ventana
    {
        public List<int> ModulosAfectados = new List<int>();
        public string Motivo = string.Empty;
        public string RiesgoTexto = string.Empty;
        public string Tipo = string.Empty;
        public string Alcance = string.Empty;
        public decimal IdProyecto = 0;
        public int NivelRiesgo = 0;

        public FrmNuevoCambioDiseno(decimal idProyecto)
        {
            InitializeComponent();
            IdProyecto = idProyecto;
        }

        private void FrmNuevoCambioDiseno_Load(object sender, EventArgs e)
        {
            CargarModulos();
        }

        public void CargarModulos()
        {
            DgvModulosInvolucrados.Rows.Clear();
            Modulo.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                if(f.Celda("estatus_aprobacion").ToString() == "APROBADO")
                    DgvModulosInvolucrados.Rows.Add(f.Celda("id"), false, f.Celda("subensamble").ToString().PadLeft(2, '0') + " - " + f.Celda("nombre"));
            });
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Tipo = CmbTipo.Text;
            Motivo = CmbMotivo.Text;
            Alcance = TxtAlcance.Text;
            RiesgoTexto = CmbNivelRiesgo.Text;

            switch(CmbNivelRiesgo.Text)
            {
                case "MUY BAJO": NivelRiesgo = 20; break;
                case "BAJO": NivelRiesgo = 40; break;
                case "REGULAR": NivelRiesgo = 60; break;
                case "ALTO": NivelRiesgo = 80; break;
                case "MUY ALTO": NivelRiesgo = 100; break;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void TxtAlcance_TextChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = ValidarDatos();
        }

        private void CmbMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = ValidarDatos();
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnRegistrar.Enabled = ValidarDatos();
        }

        bool ValidarDatos()
        {
            return (CmbNivelRiesgo.Text != string.Empty && CmbTipo.Text != string.Empty && CmbMotivo.Text != string.Empty && TxtAlcance.Text != string.Empty && ModulosAfectados.Count > 0);
        }

        private void DgvModulosInvolucrados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
                return;

            int idModulo = Convert.ToInt32(DgvModulosInvolucrados.Rows[e.RowIndex].Cells[0].Value);
            bool seleccion = Convert.ToBoolean(DgvModulosInvolucrados.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);

            if (seleccion)
            {
                if (!ModulosAfectados.Contains(idModulo))
                    ModulosAfectados.Add(idModulo);
            }
            else
                ModulosAfectados.Remove(idModulo);

            BtnRegistrar.Enabled = ValidarDatos();
        }
    }
}
