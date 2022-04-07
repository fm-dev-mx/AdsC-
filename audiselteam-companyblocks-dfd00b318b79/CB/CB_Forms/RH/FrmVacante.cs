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
    public partial class FrmVacante : Ventana
    {
        List<Fila> Puestos = new List<Fila>();
        public FrmVacante()
        {
            InitializeComponent();
        }

        private void FrmVacante_Load(object sender, EventArgs e)
        {
            CargarPuestos();
            CargarVacantes();

            PerfilPuesto perfilPuesto = new PerfilPuesto();
            Puestos = perfilPuesto.SeleccionarPuestosOrdenadoPorNivel();

            CargarPuestos();
        }

        private void CargarPuestos()
        {
            CmbPuesto.Items.Clear();

            PerfilPuesto perfilPuesto = new PerfilPuesto();
            CmbPuesto.Items.Add("TODOS");

            perfilPuesto.TodosLosPuestos().ForEach(delegate(Fila f)
            {
                CmbPuesto.Items.Add(f.Celda("rol").ToString());
            });

            CmbPuesto.SelectedIndex = 0;
        }

        private void CargarVacantes()
        {
            DgvVacante.Rows.Clear();

            Usuario usuario = new Usuario();      
            Puestos.ForEach(delegate(Fila f)
            {
                
                int vacante = 0;
                int nivel = Convert.ToInt32(Global.ObjetoATexto(f.Celda("nivel"), "0"));
                int cantidadMaximaPlantilla = Convert.ToInt32(Global.ObjetoATexto(f.Celda("plantilla_autorizada"), "0"));

                string caracteristicasVacante = "VACANTE";
                string rol = Global.ObjetoATexto(f.Celda("rol"), "");
                string strVacante = string.Empty;

                if (CmbPuesto.Text == rol || CmbPuesto.Text == "TODOS")
                {
                    usuario.SeleccionarUsuariosDeNivel(rol, nivel);
                    if (usuario.TieneFilas())
                    {
                        //excedido
                        if (usuario.Filas().Count > cantidadMaximaPlantilla)
                        {
                            vacante = usuario.Filas().Count - cantidadMaximaPlantilla;
                            caracteristicasVacante = "PLANTILLA EXCEDIDA POR " + vacante + " EMPLEADO(S)";
                            strVacante = " -- ";
                            DgvVacante.Rows.Add(f.Celda("id").ToString(), rol, nivel.ToString(), strVacante, caracteristicasVacante);
                        }
                        //vacante
                        else if (cantidadMaximaPlantilla > usuario.Filas().Count)
                        {
                            vacante = cantidadMaximaPlantilla - usuario.Filas().Count;
                            strVacante = vacante.ToString();
                            DgvVacante.Rows.Add(f.Celda("id").ToString(), rol, nivel.ToString(), strVacante, caracteristicasVacante);
                        }
                    }
                    else
                    {
                        if (cantidadMaximaPlantilla > 0)
                        {
                            vacante = cantidadMaximaPlantilla;
                            strVacante = vacante.ToString();
                            DgvVacante.Rows.Add(f.Celda("id").ToString(), rol, nivel.ToString(), strVacante, caracteristicasVacante);
                        }
                    }
                } 
            });
            
        }

        private void CmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVacantes();
        }

        private void CmbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarVacantes();
        }

        private void DgvVacante_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvVacante.Rows[e.RowIndex].Cells["estatus"].Value.ToString();
            if(estatus == "VACANTE")
                DgvVacante.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.LightGreen;
            else
                 DgvVacante.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.Red;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
