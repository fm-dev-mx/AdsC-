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
    public partial class FrmAltaEquipoTrabajo : Ventana
    {
        public List<int> idIntegrantes = new List<int>();
        public string ListaIntegrantes = string.Empty;
        public string Departamento = string.Empty;
        public int IdLiderSeleccionado = 0;
        int Equipo = 0;

        Rol Roles = new Rol();
        PerfilPuesto PerfilesPuesto = new PerfilPuesto();

        public FrmAltaEquipoTrabajo(int equipo = 0)
        {
            InitializeComponent();
            Equipo = equipo;
        }

        private void FrmAltaEquipoTrabajo_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();

            //Cargar informacion de  los combobox del rol y el lider en caso de editar los integrantes
            if (Equipo != 0)
            {
                string nombre = "";
                string departamento = "";

                EquipoTrabajo equipoTrabajo = new EquipoTrabajo();
                equipoTrabajo.CargarDatos(Equipo);
                if(equipoTrabajo.TieneFilas())
                {
                    Usuario usuario = new Usuario();
                    int idLider = Convert.ToInt32(equipoTrabajo.Fila().Celda("lider"));
                    usuario.CargarDatos(idLider).ForEach(delegate(Fila f)
                    {
                        nombre = Global.ObjetoATexto(f.Celda("nombre"), "") + " " + Global.ObjetoATexto(f.Celda("paterno"), "");
                        PerfilesPuesto.CargarDepartamentoDeRol(Global.ObjetoATexto(f.Celda("rol"),""));
                        departamento = Global.ObjetoATexto(PerfilesPuesto.Fila().Celda("departamento"), "N/A");
                    });
                    CmbDepartamentos.Text = departamento;
                    CargarLideres();
                    CmbLider.Text = nombre;
                    CargarEquipos();
                }

                CmbDepartamentos.Enabled = false;
                CmbLider.Enabled = false;
                LblTitulo.Text = "EDITAR INTEGRANTES DEL EQUIPO";
                LblDepartamento.Text = "Departamento:";
                LblLider.Text = "Líder del equipo:";
                CrearLista();
            }                
        }

        void CargarDepartamentos()
        {
            CmbDepartamentos.Items.Clear();

            PerfilesPuesto.CargarDepartamentos().ForEach(delegate(Fila f)
            {
                CmbDepartamentos.Items.Add(f.Celda("departamento").ToString());
            });
        }

        void CargarLideres()
        {
            bool editar = false;
            CmbLider.Items.Clear();

            if (Equipo > 0)
                editar = true;

            string buscar = "TODOS";
            if (PerfilesPuesto.buscarRolDepartamento(CmbDepartamentos.Text) != null)
                buscar = Global.ObjetoATexto(PerfilesPuesto.Fila().Celda("departamento"), "");

            Roles.SeleccionarLideres(buscar, editar).ForEach(delegate(Fila f)
            {
                string nombre = Global.ObjetoATexto(f.Celda("nombre"), "") + " " + Global.ObjetoATexto(f.Celda("paterno"), "");

                ComboboxItem item = new ComboboxItem();
                item.Text = nombre;
                item.Value = f.Celda("id").ToString();
                CmbLider.Items.Add(item);
            });
        }

        void CargarEquipos()
        {
            string nombre = string.Empty;
            Usuario usuario = new Usuario();
            EquipoTrabajoIntegrantes integrantes = new EquipoTrabajoIntegrantes();
            integrantes.CargarEquipo(Equipo).ForEach(delegate(Fila f)
            {
                
                nombre = Global.ObjetoATexto(f.Celda("nombre"), "") + " " + Global.ObjetoATexto(f.Celda("paterno"), "");

                CheckBoxItem item = new CheckBoxItem();
                item.Text = nombre;
                item.Value = f.Celda("id").ToString();

                ChkBListaUsuarios.Items.Add(item, true);
            });

            string buscar = "TODOS";
            if (PerfilesPuesto.buscarRolDepartamento(CmbDepartamentos.Text) != null)
                buscar = Global.ObjetoATexto(PerfilesPuesto.Fila().Celda("departamento"), "");

            EquipoTrabajoIntegrantes nuevosIntegrantes = new EquipoTrabajoIntegrantes();
            nuevosIntegrantes.SeleccionarIntegrantes(buscar).ForEach(delegate(Fila filaUsuario)
            {
                nombre = Global.ObjetoATexto(filaUsuario.Celda("nombre"), "") + " " + Global.ObjetoATexto(filaUsuario.Celda("paterno"), "");

                //Se agregan los que no pertecen a ningun equipo del mismo rol
                CheckBoxItem item = new CheckBoxItem();
                item.Text = nombre;
                item.Value = filaUsuario.Celda("id").ToString();

                ChkBListaUsuarios.Items.Add(item);

            });
        }

        void CargarListaIntegrantes(int idLider)
        {
            ChkBListaUsuarios.Items.Clear();
            string buscar = "TODOS";
            if (PerfilesPuesto.buscarRolDepartamento(CmbDepartamentos.Text) != null)
                buscar = Global.ObjetoATexto(PerfilesPuesto.Fila().Celda("departamento"), "");

            EquipoTrabajoIntegrantes integrantes = new EquipoTrabajoIntegrantes();
            integrantes.CargarIntegrantesEquipo(buscar, idLider).ForEach(delegate(Fila f)
            {
                if (f.Celda("activo").ToString() == "1")
                {
                    string nombre = "";
                    nombre = Global.ObjetoATexto(f.Celda("nombre"), "") + " " + Global.ObjetoATexto(f.Celda("paterno"), "");

                    CheckBoxItem item = new CheckBoxItem();
                    item.Text = nombre;
                    item.Value = f.Celda("id").ToString();

                    ChkBListaUsuarios.Items.Add(item);
                }
            });
        }

        private void CmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkBListaUsuarios.Items.Clear();           
            CargarLideres();
            LBIntegrantes.Items.Clear();
        }

        private void CmbLider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLider.Text == "" || Equipo > 0)
                return;

            int idLider = Convert.ToInt32(((ComboboxItem)CmbLider.SelectedItem).Value.ToString());
            CargarListaIntegrantes(idLider);
        }

        private void ChkBListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrearLista();
        }

        private void CrearLista()
        {
            LBIntegrantes.Items.Clear();
            ListaIntegrantes = string.Empty;
            idIntegrantes.Clear();

            for (int i = 0; i < ChkBListaUsuarios.Items.Count; i++)
            {
                if (ChkBListaUsuarios.GetItemChecked(i))
                {
                    LBIntegrantes.Items.Add(((CheckBoxItem)ChkBListaUsuarios.Items[i]).Text);
                    ListaIntegrantes += (string)ChkBListaUsuarios.Items[i].ToString() + Environment.NewLine;
                    idIntegrantes.Add(Convert.ToInt32(((CheckBoxItem)ChkBListaUsuarios.Items[i]).Value));
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (LBIntegrantes.Items.Count <= 0)
                return;
            DialogResult result = MessageBox.Show("¿Está seguro de guardar la siguiente información?" + Environment.NewLine +
                                          "Líder del equipo: " + CmbLider.Text + Environment.NewLine + "Integrantes del equipo: " +
                                          Environment.NewLine + ListaIntegrantes.TrimEnd(), "Equipo de trabajo", MessageBoxButtons.OK, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Departamento = CmbDepartamentos.Text;
                IdLiderSeleccionado = Convert.ToInt32(((ComboboxItem)CmbLider.SelectedItem).Value);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
