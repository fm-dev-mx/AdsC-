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
    public partial class FrmEquipoTrabajo : Ventana
    {
        int idSeleccionado = 0;

       // Rol Roles = new Rol();
        PerfilPuesto perfilPuesto = new PerfilPuesto();
        EquipoTrabajo equipoTrabajo = new EquipoTrabajo();
        EquipoTrabajoIntegrantes equipoIntegrantes = new EquipoTrabajoIntegrantes();

        public FrmEquipoTrabajo()
        {
            InitializeComponent();
        }

        private void FrmEquipoTrabajo_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
            if (CmbLider.Items.Count > 0)
                CmbLider.SelectedIndex = 0;
            
        }

        private void CargarDepartamentos()
        {
            CmbDepartamentos.Items.Clear();           
            CmbDepartamentos.Items.Add("TODOS");

            perfilPuesto.SeleccionarDatos("departamento!=''", null, "distinct departamento").ForEach(delegate(Fila f)
            {
                CmbDepartamentos.Items.Add(f.Celda("departamento").ToString());
            });

            if (CmbDepartamentos.Items.Count > 0)
                CmbDepartamentos.SelectedIndex = 0;
        }

        private void CargarLideres()
        {
            CmbLider.Items.Clear();

            //Creamos un item con valor de texto y valor 
            ComboboxItem item = new ComboboxItem();
            item.Text = "TODOS";
            item.Value = "TODOS";
            CmbLider.Items.Add(item);

            //cargamos el combox de lider con respecto al rol(deparamento) seleccionado
            //el lider se carga deacuerdo con el valor del nivel_maximo
            string buscar = "TODOS";
            if (perfilPuesto.buscarRolDepartamento(CmbDepartamentos.Text) != null)
                buscar = Global.ObjetoATexto(perfilPuesto.Fila().Celda("rol"), "");

            EquipoTrabajo equipo = new EquipoTrabajo();
            equipo.SeleccionarLideres(buscar).ForEach(delegate(Fila f)
            {
                Usuario usuario = new Usuario();
                int idLider = Convert.ToInt32(f.Celda("lider"));
                usuario.CargarDatos(idLider).ForEach(delegate(Fila filaUsuario)
                {
                    string nombre = "";
                    object objNombre = filaUsuario.Celda("nombre");
                    if (objNombre != null)
                        nombre = objNombre.ToString();

                    object objPaterno = filaUsuario.Celda("paterno");
                    if(objPaterno != null)
                        nombre += " " + objPaterno.ToString();

                    item = new ComboboxItem();
                    item.Text = nombre.ToUpper();
                    item.Value = idLider.ToString();
                });
                CmbLider.Items.Add(item);                
            });
            CmbLider.SelectedIndex = 0;
        }

        private void CargarEquipos()
        {
            DgvEquipos.Rows.Clear();

            string departamento = CmbDepartamentos.Text;

            object objIdLider = ((ComboboxItem)CmbLider.SelectedItem);
            if (objIdLider == null)
                return;

            string idLider = ((ComboboxItem)CmbLider.SelectedItem).Value;

            //Cargamos el equipo de trabajo con respecto al rol seleccionado y el lider seleccionado
            EquipoTrabajo.Modelo().CargarEquipos(departamento, idLider).ForEach(delegate(Fila f)
            {
                string nombre = "";
                string nombreIntegrante = "";

                object objNombre = f.Celda("nombre");
                if (objNombre != null)
                    nombre = objNombre.ToString();

                object objPaterno = f.Celda("paterno");
                if(objPaterno != null)
                    nombre += " " + objPaterno.ToString();

                //Cargamos los integrantes del equipo seleccionado 'id'
                EquipoTrabajoIntegrantes.Modelo().CargarEquipo(Convert.ToInt32(f.Celda("id"))).ForEach(delegate(Fila integrantes)
                {
                   object objNombreIntegrante = integrantes.Celda("nombre");
                    if (objNombreIntegrante != null)
                        nombreIntegrante += objNombreIntegrante.ToString();

                    object objPaternoIntegrante = integrantes.Celda("paterno");
                    if(objPaternoIntegrante != null)
                        nombreIntegrante += " " + objPaternoIntegrante.ToString();

                    nombreIntegrante += Environment.NewLine;
                });
                DgvEquipos.Rows.Add(f.Celda("id").ToString(), f.Celda("departamento").ToString(), nombre, nombreIntegrante.TrimEnd());
            });

            if(DgvEquipos.Rows.Count > 0)
                DgvEquipos.ClearSelection();
        }

        private void CmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLideres();
        }

        private void BtnNuevoEquipo_Click(object sender, EventArgs e)
        {
            FrmAltaEquipoTrabajo altaEquipoTrabajo = new FrmAltaEquipoTrabajo();
            if(altaEquipoTrabajo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EquipoTrabajo equipoTrabajo = new EquipoTrabajo();
                Fila insertarEquipoTrabajo = new Fila();
                insertarEquipoTrabajo.AgregarCelda("lider", altaEquipoTrabajo.IdLiderSeleccionado);
                insertarEquipoTrabajo.AgregarCelda("departamento", altaEquipoTrabajo.Departamento);
                int idEquipoTrabajo = Convert.ToInt32(equipoTrabajo.Insertar(insertarEquipoTrabajo).Celda("id"));

                foreach (int id in altaEquipoTrabajo.idIntegrantes)
                {
                    Fila insertarIntegrantes = new Fila();
                    insertarIntegrantes.AgregarCelda("equipo", idEquipoTrabajo);
                    insertarIntegrantes.AgregarCelda("integrante", id);
                    EquipoTrabajoIntegrantes.Modelo().Insertar(insertarIntegrantes);
                }
                CargarEquipos();
            }
        }

        private void CmbLider_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEquipos();       
        }

        private void DgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            idSeleccionado = Convert.ToInt32(DgvEquipos.SelectedRows[0].Cells["id"].Value);
        }

        private void DgvEquipos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    editarToolStripMenuItem.Visible = true;
                    eliminarToolStripMenuItem.Visible = true;
                    MenuEquipos.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvEquipos_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvEquipos.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    editarToolStripMenuItem.Visible = false;
                    eliminarToolStripMenuItem.Visible = false;
                    MenuEquipos.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaEquipoTrabajo editarEquipo = new FrmAltaEquipoTrabajo(idSeleccionado);
            if(editarEquipo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EquipoTrabajoIntegrantes.Modelo().CargarEquipo(idSeleccionado).ForEach(delegate(Fila f)
                {
                    equipoIntegrantes.CargarDatos(Convert.ToInt32(f.Celda("idIntegrantes")));
                    equipoIntegrantes.BorrarDatos(Convert.ToInt32(f.Celda("idIntegrantes")));
                    equipoIntegrantes.GuardarDatos();
                });

                foreach (int id in editarEquipo.idIntegrantes)
                {
                    Fila insertarIntegrantes = new Fila();
                    insertarIntegrantes.AgregarCelda("equipo", idSeleccionado);
                    insertarIntegrantes.AgregarCelda("integrante", id);
                    EquipoTrabajoIntegrantes.Modelo().Insertar(insertarIntegrantes);
                }
            }
            CargarEquipos();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult borrar = MessageBox.Show("Los datos que son borrados no podrán ser recuperados en el futuro. ¿Desea continuar?", "Borrar equipo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (borrar == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvEquipos.SelectedRows)
                {
                    int idEquipo = Convert.ToInt32(row.Cells["id"].Value.ToString());

                    //Borramos en registro de la tabald e EquipoTrabajo
                    equipoTrabajo.CargarDatos(idEquipo);
                    equipoTrabajo.BorrarDatos(idEquipo);
                    equipoTrabajo.GuardarDatos();

                    
                    //Cargarmos todos los miembros del equipo eliminado
                    //Borramos todos los integrantes que forman parte del equipo eliminado
                    equipoIntegrantes.CargarEquipo(idEquipo).ForEach(delegate(Fila f)
                    {
                        int idIntegrantes = Convert.ToInt32(f.Celda("idIntegrantes"));
                        equipoIntegrantes.CargarDatos(idIntegrantes);
                        equipoIntegrantes.BorrarDatos(idIntegrantes);
                        equipoIntegrantes.GuardarDatos();
                    });
                }
                CargarEquipos();
            }
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
