using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmRegistrarPlanoFueraDelSistema : Form
    {
        public FrmRegistrarPlanoFueraDelSistema()
        {
            InitializeComponent();
        }

        private void FrmRegistrarPlanoFueraDelSistema_Load(object sender, EventArgs e)
        {
            CargarSolicitante();
            CargarHerramentistas();
        }

        private void CargarHerramentistas()
        {
            DgvHerramentistas.Rows.Clear();
            Usuario herramentistas = new Usuario();
            herramentistas.SeleccionarRolActivos("TECNICO HERRAMENTISTA");
            herramentistas.Filas().ForEach(delegate (Fila f)
            {
                DgvHerramentistas.Rows.Add(f.Celda("id"), false, f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString());
            });

            DgvHerramentistas.ClearSelection();
        }

        private void CargarSolicitante()
        {
            Usuario solicitante = new Usuario();
            string noIncluirRoles = string.Empty;
            noIncluirRoles = "'COMPRADOR','LIDER DE FINANZAS','COORDINADOR DE RH',";
            noIncluirRoles += "'RESPONSABLE DE MANTENIMIENTO','COORDINADOR DE FINANZAS',";
            noIncluirRoles += "'AUXILIAR DE FINANZAS','INSPECTOR DE CALIDAD', 'MENSAJERO',";
            noIncluirRoles += "'COORDINADOR DE PUBLICIDAD','RESPONSABLE DE ALMACEN', ";
            noIncluirRoles += "'SUPERVISOR DE TOOL ROOM'";


            solicitante.SeleccionarDatos("rol not in (" + noIncluirRoles + ") and activo = 1 order by nombre, paterno asc", null).ForEach(delegate (Fila f)
            {
                if(f.Celda("nombre").ToString() != "N/A")
                    CmbSolicitante.Items.Add(f.Celda("id") .ToString() + " - " + f.Celda("nombre").ToString() + " " + f.Celda("paterno").ToString());
            });

            if (CmbSolicitante.Items.Count > 0)
                CmbSolicitante.SelectedIndex = 0;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TxtNombrePlano.Text.Trim() == "")
            {
                MessageBox.Show("Favor de indicar el nombre del plano", "Nombre del plano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //checar que no haya nulos en la hora de trabajo
            bool nulo = true;
            foreach (DataGridViewRow row in DgvHerramentistas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value))
                {
                    nulo = false;

                    if (row.Cells["tiempo_trabajo"].Value == null)
                    {
                        MessageBox.Show("Favor de colocar las horas trabajadas de herramentistas seleccionados", "Falta horas trabajadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (row.Cells["tiempo_trabajo"].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Favor de colocar las horas trabajadas de herramentistas seleccionados", "Falta horas trabajadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            if(nulo)
            {
                MessageBox.Show("Favor de seleccionar por lo menos a un herramentista", "Sleccione un herramentista", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro que desea guardar los datos del plano?", "Guardar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            int idSolicitante = Convert.ToInt32(CmbSolicitante.Text.Split('-')[0].Trim());
            string nombreSolicitante = CmbSolicitante.Text.Split('-')[1].TrimStart();

            Fila insertarPlano = new Fila();
            insertarPlano.AgregarCelda("nombre_plano", TxtNombrePlano.Text);
            insertarPlano.AgregarCelda("fecha_creacion", DateTime.Now);
            insertarPlano.AgregarCelda("id_solicitante", idSolicitante);
            insertarPlano.AgregarCelda("nombre_solicitante", nombreSolicitante);

            int idPlano = Convert.ToInt32(PlanoFueraSistema.Modelo().Insertar(insertarPlano).Celda("id"));

            foreach (DataGridViewRow row in DgvHerramentistas.Rows)
            {
                if (Convert.ToBoolean(row.Cells["check"].Value))
                {
                    int idHerramentista = 0;
                    string nombreHerramentista = string.Empty;

                    idHerramentista = Convert.ToInt32(row.Cells["id"].Value);
                    nombreHerramentista = row.Cells["herramentista"].Value.ToString();

                    Fila insertarHerramentista = new Fila();
                    insertarHerramentista.AgregarCelda("id_herramentista", idHerramentista);
                    insertarHerramentista.AgregarCelda("nombre_herramentista", nombreHerramentista);
                    insertarHerramentista.AgregarCelda("id_plano_fuera_sistema", idPlano);
                    insertarHerramentista.AgregarCelda("fecha_creacion", DateTime.Now.Date);
                    insertarHerramentista.AgregarCelda("horas_trabajo", row.Cells["tiempo_trabajo"].Value);
                    PlanoFueraSistemaHerramentista.Modelo().Insertar(insertarHerramentista);
                }
            }

            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
