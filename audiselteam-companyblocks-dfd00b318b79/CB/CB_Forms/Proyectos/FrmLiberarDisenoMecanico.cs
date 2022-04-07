using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmLiberarDisenoMecanico : Ventana
    {
        decimal IdProyecto = 0;
        int Subensamble = 0;

        public FrmLiberarDisenoMecanico(decimal idProyecto, int subensamble=0)
        {
            InitializeComponent();
            IdProyecto = idProyecto;
            Subensamble = subensamble;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnLiberar_Click(object sender, EventArgs e)
        {
            if(!File.Exists(TxtArchivo.Text))
            {
                MessageBox.Show("El archivo no existe!", "No existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] evidencia = File.ReadAllBytes(TxtArchivo.Text);

            Fila filaEvidencia = new Fila();
            filaEvidencia.AgregarCelda("archivo", evidencia);
            filaEvidencia = EvidenciaLiberacionModulo.Modelo().Insertar(filaEvidencia);

            int idEvidencia = Convert.ToInt32(filaEvidencia.Celda("id"));

            Modulo moduloLiberado = new Modulo();
            Proyecto proyecto = new Proyecto();

            if(Subensamble==0)
            {
                moduloLiberado.SeleccionarProyecto(IdProyecto);

                Proyecto proyectoLiberado = new Proyecto();
                proyectoLiberado.CargarDatos(IdProyecto);

                if(proyectoLiberado.TieneFilas())
                {
                    proyectoLiberado.Fila().ModificarCelda("estatus_liberacion", "LIBERADO");
                    proyectoLiberado.Fila().ModificarCelda("usuario_liberacion", Global.UsuarioActual.NombreCompleto());
                    proyectoLiberado.Fila().ModificarCelda("fecha_liberacion", DateTime.Now);
                    proyectoLiberado.Fila().ModificarCelda("evidencia_liberacion", idEvidencia);
                    proyectoLiberado.GuardarDatos();
                }
            }
            else
                moduloLiberado.SeleccionarProyectoSubensamble(IdProyecto, Subensamble);

            moduloLiberado.Filas().ForEach(delegate(Fila f)
            {
                if(f.Celda("estatus_liberacion").ToString().Trim() == "PENDIENTE")
                {
                    f.ModificarCelda("estatus_liberacion", "LIBERADO");
                    f.ModificarCelda("fecha_liberacion", DateTime.Now);
                    f.ModificarCelda("usuario_liberacion", Global.UsuarioActual.NombreCompleto());
                    f.ModificarCelda("evidencia_liberacion", idEvidencia);
                }
            });
            moduloLiberado.GuardarDatos();

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if(BuscadorArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtArchivo.Text = BuscadorArchivo.FileName;
            }
        }

        private void TxtArchivo_TextChanged(object sender, EventArgs e)
        {
            BtnLiberar.Enabled = File.Exists(TxtArchivo.Text);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
