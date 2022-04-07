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
    public partial class FrmNuevoBug : Ventana
    {
        decimal Proyecto = 0;
        int IdBug = 0;

        public FrmNuevoBug(decimal proyecto, int idbug=0)
        {
            InitializeComponent();
            Proyecto = proyecto;
            IdBug = idbug;
        }

        private bool ValidarCampos()
        {
            return (!String.IsNullOrWhiteSpace(CmbCategoria.Text) && !String.IsNullOrWhiteSpace(TxtDescripcion.Text) && !String.IsNullOrWhiteSpace(CmbEstatus.Text) && !String.IsNullOrWhiteSpace(CmbOrigen.Text));
        }

        private void NuevoBug()
        {
            Fila bugs = new Fila();

            bugs.AgregarCelda("categoria", CmbCategoria.Text);
            bugs.AgregarCelda("descripcion", TxtDescripcion.Text);
            bugs.AgregarCelda("proyecto", Proyecto);
            bugs.AgregarCelda("origen", CmbOrigen.Text);
            bugs.AgregarCelda("perpetuada_por", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno"));
            bugs.AgregarCelda("fecha_reporte", DateTime.Now);
            bugs.AgregarCelda("estatus", CmbEstatus.Text);
            Bug.Modelo().Insertar(bugs);
        }

        private void EditarBug()
        {
            Bug modificarBug = new Bug();
            modificarBug.CargarDatos(IdBug);

            if (modificarBug.TieneFilas())
            {
                modificarBug.Fila().ModificarCelda("categoria", CmbCategoria.Text);
                modificarBug.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                modificarBug.Fila().ModificarCelda("estatus", CmbEstatus.Text);
                modificarBug.GuardarDatos();
            }
        }

        private void CargarDatos()
        {
            Bug DatosBug = new Bug();
            DatosBug.CargarDatos(IdBug);
            CmbCategoria.Text = DatosBug.Fila().Celda("categoria").ToString();
            TxtDescripcion.Text = DatosBug.Fila().Celda("descripcion").ToString();
            CmbEstatus.Text = DatosBug.Fila().Celda("estatus").ToString();
            CmbOrigen.Text = DatosBug.Fila().Celda("origen").ToString();
            CmbOrigen.Enabled = false;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmNuevoBug_Load(object sender, EventArgs e)
        {
            LblInfo.Visible = false;
            if (0 != IdBug)
            {
                CargarDatos();
                LblTitulo.Text = "EDITAR BUG";
                BtnRegistrar.Text = "Editar";
            }
                
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (IdBug == 0)
                    NuevoBug();
                else
                    EditarBug();

                DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            else
            {
                LblInfo.Text = "Favor de ingresar los datos completos";
                LblInfo.Visible = true;
            }
                
        }
    }
}
