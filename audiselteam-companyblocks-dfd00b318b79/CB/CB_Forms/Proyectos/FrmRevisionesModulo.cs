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
    public partial class FrmRevisionesModulo : Ventana
    {
        decimal IdProyecto = 0;
        int Subensamble = 0;

        public FrmRevisionesModulo(decimal idProyecto, int subensamble)
        {
            InitializeComponent();
            IdProyecto = idProyecto;
            Subensamble = subensamble;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        void CargarRevisiones()
        {
            Proyecto prj = new Proyecto();
            Modulo mod = new Modulo();
            prj.CargarDatos(IdProyecto);
            mod.SeleccionarProyectoSubensamble(IdProyecto, Subensamble);

            if (prj.TieneFilas())
                LblProyecto.Text = IdProyecto.ToString("F2") + " - " + prj.Fila().Celda("nombre");

            if (mod.TieneFilas())
                LblNombre.Text = Subensamble.ToString().PadLeft(2, '0') + " - " + mod.Fila().Celda("nombre").ToString();

            string strFecha = string.Empty;
            string strRevision = string.Empty;

            DgvRevisiones.Rows.Clear();
            RevisionModulo.Modelo().SeleccionarProyectoSubensamble(IdProyecto, Subensamble).ForEach(delegate(Fila f)
            {
                strRevision = "R" + f.Celda("revision").ToString().PadLeft(2, '0');
                strFecha = Global.FechaATexto(f.Celda("fecha"));
                DgvRevisiones.Rows.Add(strRevision, f.Celda("comentarios_revision"), f.Celda("usuario"), strFecha);
            });
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmRevisionesModulo_Load(object sender, EventArgs e)
        {
            CargarRevisiones();
        }
    }
}
