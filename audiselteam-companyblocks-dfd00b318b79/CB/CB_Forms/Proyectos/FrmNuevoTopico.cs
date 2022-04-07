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
    public partial class FrmNuevoTopico : Ventana
    {
        bool EditarTopico;
        decimal Proyecto = 0;
        int IdTopico = 0;

        public FrmNuevoTopico(decimal proyecto, int idTopico, bool editarTopico = false)
        {
            InitializeComponent();
            EditarTopico = editarTopico;
            Proyecto = proyecto;
            IdTopico = idTopico;
        }

        private void FrmNuevoTopico_Load(object sender, EventArgs e)
        {
            if (!EditarTopico)
            {
                CmbEstatus.Text = "PENDIENTE";
            }
            LblInfo.Text = "";
            CargarDatos(IdTopico);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (TxtDescripcion.Text == "")
            {
                LblInfo.Text = "Ingresa todos los datos requeridos";
                return;
            }

            if (!EditarTopico)
            {
                Fila req = new Fila();
                req.AgregarCelda("estatus", CmbEstatus.Text);
                req.AgregarCelda("proyecto", Proyecto);
                req.AgregarCelda("descripcion", TxtDescripcion.Text);
                req.AgregarCelda("fecha_creacion", DateTime.Now);
                req.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
                Topico.Modelo().Insertar(req);
            }
            else
            {
                Topico topico = new Topico();
                topico.CargarDatos(IdTopico);

                if (topico.TieneFilas())
                {
                    topico.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                    topico.Fila().ModificarCelda("estatus", CmbEstatus.Text);

                    topico.GuardarDatos();
                }     
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
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

        public void CargarDatos(int idTopico)
        {
            Topico topico = new Topico();
            topico.CargarDatos(idTopico);
            if(topico.TieneFilas())
            {
                TxtDescripcion.Text = topico.Fila().Celda("descripcion").ToString();
                CmbEstatus.SelectedItem = topico.Fila().Celda("estatus");
            }
        }
        
    }
}
