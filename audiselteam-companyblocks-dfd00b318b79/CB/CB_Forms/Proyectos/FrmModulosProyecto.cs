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
    public partial class FrmModulosProyecto : Ventana
    {
        decimal IdProyecto = 0;
        int IdModulo = 0;
        Proyecto ProyectoCargado = new Proyecto();

        public FrmModulosProyecto(decimal proyecto)
        {
            InitializeComponent();
            IdProyecto = proyecto;
            ProyectoCargado.CargarDatos(IdProyecto);

            if( !ProyectoCargado.TieneFilas() )
            {
                MessageBox.Show("El proyecto " + IdProyecto.ToString("F2") + " no existe!");
                Close();
            }
        }

        private void FrmModulosProyecto_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LblTitulo.Text = "MODULOS DEL PROYECTO ";
            LblTitulo.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2") + " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            LblUltimaActualizacion.Text = "";
            CargarModulos(IdProyecto);
        }

        public void CargarModulos(decimal proyecto)
        {
            //Dictionary<string, object> parametros = new Dictionary<string, object>();  
            //parametros.Add("@proyecto", proyecto);
            int guardarFila = Global.GuardarFilaSeleccionada(DgvModulos);
            DgvModulos.Rows.Clear();
            //LlenarDataGridView(Modulo.Modelo().SeleccionarDatos("proyecto=@proyecto", parametros), DgvModulos);
            Modulo.Modelo().SeleccionarProyecto(proyecto).ForEach(delegate(Fila f) 
            {
                int idModulo = Convert.ToInt32(f.Celda("id"));

                string fechaPromesaFabricacion = "N/A";

                if (f.Celda("fecha_promesa_fabricacion") != null)
                    fechaPromesaFabricacion = Convert.ToDateTime(f.Celda("fecha_promesa_fabricacion")).ToString("MMM dd, yyyy");

                IdModulo = idModulo;
                ImageConverter converter = new ImageConverter();
                Elemento elemento = new Elemento();
                byte[] elementoImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                elemento.SeleccionarModulo(idModulo);
                if (elemento.TieneFilas())
                    elementoImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.puzzle, typeof(byte[]));

                ModuloPaso paso = new ModuloPaso();
                byte[] pasoImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                paso.SeleccionarModulo(idModulo);
                if (paso.TieneFilas())
                    pasoImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.Data_Flow_Chart_icon, typeof(byte[]));

                ModoFalla modoFalla = new ModoFalla();
                byte[] fallaImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.whiteIcon1, typeof(byte[]));
                modoFalla.SeleccionarModulo(idModulo);
                if (modoFalla.TieneFilas())
                    fallaImagen = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.alert_24, typeof(byte[]));



                DgvModulos.Rows.Add(Convert.ToInt32(f.Celda("id")), f.Celda("subensamble").ToString().PadLeft(2, '0'), f.Celda("nombre"), f.Celda("descripcion"), fechaPromesaFabricacion, f.Celda("mecanico"), f.Celda("electrico"), f.Celda("programador"), elementoImagen, pasoImagen, fallaImagen);
            });
            Global.RecuperarFilaSeleccionada(DgvModulos, guardarFila);
            LblUltimaActualizacion.Text = "Ultima actualización: " + DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");

            editarToolStripMenuItem.Enabled = false;
            borrarToolStripMenuItem.Enabled = false;
            asignarToolStripMenuItem.Enabled = false;
            verDetallesToolStripMenuItem.Enabled = false;
            aceptarToolStripMenuItem.Enabled = false;
            diseñoDeConceptoToolStripMenuItem.Enabled = false;
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoModulo nm = new FrmNuevoModulo(IdProyecto, 0);
            
            if( nm.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarModulos(IdProyecto);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CargarModulos(IdProyecto);
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quieres borrar los módulos seleccionados?", "Borrar módulos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes || DgvModulos.SelectedRows.Count <= 0)
                return;

            foreach(DataGridViewRow row in DgvModulos.SelectedRows)
            {
                int idModulo = (int)row.Cells["id"].Value;
                Modulo mod = new Modulo();
                mod.CargarDatos(idModulo);
                mod.BorrarDatos();
            }
            CargarModulos(IdProyecto);
        }

        private void diseñadorMecánicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usr = new FrmSeleccionarUsuario("DISEÑADOR MECANICO");

            if( usr.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                if(usr.UsuarioSeleccionado.TieneFilas())
                {
                    int IdModulo = (int)DgvModulos.SelectedRows[0].Cells["id"].Value;

                    Modulo mod = new Modulo();
                    mod.CargarDatos(IdModulo);

                    if(mod.TieneFilas())
                    {
                        mod.Fila().ModificarCelda("mecanico", usr.UsuarioSeleccionado.NombreCompleto());
                        mod.GuardarDatos();
                        CargarModulos(IdProyecto);
                    }
                }
            }
        }

        private void DgvModulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editarToolStripMenuItem.Enabled = DgvModulos.SelectedRows.Count > 0;
            borrarToolStripMenuItem.Enabled = DgvModulos.SelectedRows.Count > 0;
            asignarToolStripMenuItem.Enabled = DgvModulos.SelectedRows.Count > 0;
            verDetallesToolStripMenuItem.Enabled = DgvModulos.SelectedRows.Count > 0;
            aceptarToolStripMenuItem.Enabled = (Global.VerificarPrivilegio("PROYECTOS", "ACEPTACION DISEÑO FINAL") && DgvModulos.SelectedRows.Count > 0);
            diseñoDeConceptoToolStripMenuItem.Enabled = (Global.VerificarPrivilegio("PROYECTOS", "ACEPTACION DISEÑO FINAL") && DgvModulos.SelectedRows.Count > 0);
        }

        private void diseñadorEléctricoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmSeleccionarUsuario usr = new FrmSeleccionarUsuario("DISEÑADOR ELECTRICO");

            if (usr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (usr.UsuarioSeleccionado.TieneFilas())
                {
                    int IdModulo = (int)DgvModulos.SelectedRows[0].Cells["id"].Value;

                    Modulo mod = new Modulo();
                    mod.CargarDatos(IdModulo);

                    if (mod.TieneFilas())
                    {
                        mod.Fila().ModificarCelda("electrico", usr.UsuarioSeleccionado.NombreCompleto());
                        mod.GuardarDatos();
                        CargarModulos(IdProyecto);
                    }
                }
            }
        }

        private void programadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usr = new FrmSeleccionarUsuario("PROGRAMADOR");

            if (usr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (usr.UsuarioSeleccionado.TieneFilas())
                {
                    int IdModulo = (int)DgvModulos.SelectedRows[0].Cells["id"].Value;

                    Modulo mod = new Modulo();
                    mod.CargarDatos(IdModulo);

                    if (mod.TieneFilas())
                    {
                        mod.Fila().ModificarCelda("programador", usr.UsuarioSeleccionado.NombreCompleto());
                        mod.GuardarDatos();
                        CargarModulos(IdProyecto);
                    }
                }
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvModulos.SelectedRows.Count <= 0)
                return;

            int idModulo = (int)DgvModulos.SelectedRows[0].Cells["id"].Value;

            FrmNuevoModulo edit = new FrmNuevoModulo(IdProyecto, idModulo);

            if (edit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarModulos(IdProyecto);
            }
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerDetalles();
        }

        private void DgvModulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VerDetalles();
        }

        public void VerDetalles()
        {
            int idModulo = Convert.ToInt32(DgvModulos.SelectedRows[0].Cells["id"].Value);

            FrmDetallesModulo det = new FrmDetallesModulo(idModulo);
            det.ShowDialog();
            CargarModulos(IdProyecto);

        }

        private void diseñoFinalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idModulo = (int)DgvModulos.SelectedRows[0].Cells["id"].Value;
            int subensamble = (int)DgvModulos.SelectedRows[0].Cells["subensamble"].Value;
            FrmAceptacionDisenoMecanico aceptacionFinal = new FrmAceptacionDisenoMecanico(idModulo, subensamble);
            aceptacionFinal.ShowDialog();
        }

        private void diseñoDeConceptoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idModulo = (int)DgvModulos.SelectedRows[0].Cells["id"].Value;
            int subensamble = (int)DgvModulos.SelectedRows[0].Cells["subensamble"].Value;
            FrmAceptacionDisenoMecanico aceptacionFinal = new FrmAceptacionDisenoMecanico(idModulo, subensamble, true);
            aceptacionFinal.ShowDialog();
        }

        private void fechaPromesaParaEnsambleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var picker = new DateTimePicker();
            Form f = new Form();
            f.Controls.Add(picker);

            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                //get selected date
            }
        }
    }
}
