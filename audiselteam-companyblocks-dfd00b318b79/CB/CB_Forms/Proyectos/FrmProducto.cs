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
    public partial class FrmProducto : Form
    {
        int IdComponente;
        int IdVariante = 0;
        decimal Proyecto = 0;
        int IdModelo = 0;
        int IdSubensamble = 0;
        int IdParteSubEnsamble = 0;
        Proyecto ProyectoCargado = new Proyecto();

        public FrmProducto(decimal proyecto)
        {
            InitializeComponent();
            Proyecto = proyecto;
            ProyectoCargado.CargarDatos(Proyecto);
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            LblTituloComponente.Text = "PRODUCTO DEL PROYECTO ";
            LblTituloComponente.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            LblTituloComponente.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            CargarModelos(Proyecto);

            if(DgvModelos.Rows.Count > 0)
                DgvModelos.Rows[0].Selected = false;

            CargarComponentes();

            if(DgvComponentes.Rows.Count > 0)
                DgvComponentes.Rows[0].Selected = false;
        }

        private void CargarComponentes()
        {
            int seleccionarFila = Global.GuardarFila(DgvComponentes);
            DgvComponentes.Rows.Clear();

            List<Fila> Componentes = ComponentesProyecto.Modelo().Filtrar(Proyecto,TxtFiltroComponente.Text);
            Componentes.ForEach(delegate(Fila f)
            {
                double pro = Convert.ToDouble(f.Celda("proyecto"));
                DgvComponentes.Rows.Add(f.Celda("id"), pro.ToString("F2"), f.Celda("nombre"));
                Global.RefrescarSeleccionarFila(DgvComponentes, seleccionarFila);
            });
            VisorPDF.LoadFile("none");
            ContextMenuComponentes.Enabled = false;
            editarVariantesToolStripMenuItem.Enabled = false;
            agregarVariantesToolStripMenuItem.Enabled = false;
            eliminarParteToolStripMenuItem.Enabled = false;
            
        }

        private bool BorrarComponente()
        {
            DialogResult diag = MessageBox.Show("¿Desea eliminar este componente?", "Eliminar componente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diag == System.Windows.Forms.DialogResult.Yes)
            {
                ComponentesProyecto comp = new ComponentesProyecto();
                comp.CargarDatos(IdComponente);
                comp.BorrarDatos(IdComponente);
                CargarComponentes();
                return true;
            }
            return false;
        }

        private void CargarVariantes(int idComponente)
        {
            int seleccionarFila = Global.GuardarFila(DgvVarianteComponente);
            DgvVarianteComponente.Rows.Clear();

            ComponenteVariante.Modelo().CargarVariantesModelos(idComponente).ForEach(delegate(Fila f)
            {
                DgvVarianteComponente.Rows.Add(f.Celda("id"), f.Celda("nombre"), f.Celda("modelo"));
                Global.RefrescarSeleccionarFila(DgvVarianteComponente, seleccionarFila);
            });
            editarVariantesToolStripMenuItem.Enabled = false;
            eliminarVarianteToolStripMenuItem.Enabled = false;
        }

        private void CargarArchivo(int Variante)
        {
            VisorPDF.LoadFile("none");
            ArchivoVariante variante = new ArchivoVariante();
            variante.SeleccionarVariante(IdVariante);
            string nombre = variante.Fila().Celda("nombre_archivo").ToString();
            Global.MostrarPDF((byte[])variante.Fila().Celda("archivo"), nombre, null, VisorPDF);
            Application.DoEvents();
        }

        private void CargarModelos(decimal proyecto)
        {
            int seleccionarFila = Global.GuardarFila(DgvModelos);
            DgvModelos.Rows.Clear();

            List<Fila> modelos = ModelosProyecto.Modelo().FiltrarModelos(proyecto, TxtFiltroModelo.Text);
            modelos.ForEach(delegate(Fila f)
            {
                proyecto = Convert.ToDecimal(f.Celda("proyecto"));
                DgvModelos.Rows.Add(f.Celda("id"), proyecto.ToString("F2"), f.Celda("nombre"));
                Global.RefrescarSeleccionarFila(DgvModelos, seleccionarFila);
            });
        }

        private void BorrarVariante(int idVar)
        {
            DialogResult dialog = MessageBox.Show("Desea eliminar las variantes seleccionadas?", "Eliminar variantes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach(DataGridViewRow row in DgvVarianteComponente.SelectedRows)
            {
                int idVariante = Convert.ToInt32(row.Cells["variante_id"].Value);
                ComponenteVariante var = new ComponenteVariante();
                var.CargarDatos(idVariante);
                var.BorrarDatos();
            }
            VisorPDF.LoadFile("none");
            CargarVariantes(IdComponente);
        }

        private int AltaModelo(string nombreModelo)
        {
            ModelosProyecto mod = new ModelosProyecto();
            Fila nuevoModelo = new Fila();
            nuevoModelo.AgregarCelda("proyecto", Proyecto);
            nuevoModelo.AgregarCelda("nombre", nombreModelo);
            nuevoModelo = mod.Insertar(nuevoModelo);
            return Convert.ToInt32(nuevoModelo.Celda("id"));
        }

        private void EditarModelo(int idModelo, string nombreModelo)
        {
            ModelosProyecto mod = new ModelosProyecto();
            mod.CargarDatos(idModelo);
            mod.Fila().ModificarCelda("nombre", nombreModelo);
            mod.GuardarDatos();
        }

        private int NuevoSubensamble(string NombreSubEnsamble)
        {
            Fila nuevoSubEnsamble = new Fila();
            nuevoSubEnsamble.AgregarCelda("proyecto", Proyecto);
            nuevoSubEnsamble.AgregarCelda("nombre", NombreSubEnsamble);
            nuevoSubEnsamble = SubensambleProyecto.Modelo().Insertar(nuevoSubEnsamble);
            return Convert.ToInt32(nuevoSubEnsamble.Celda("id"));
        }

        private int NuevoComponente(string NombreComponente)
        {
            Fila nuevoComponente = new Fila();
            nuevoComponente.AgregarCelda("proyecto", Proyecto);
            nuevoComponente.AgregarCelda("nombre", NombreComponente);
            nuevoComponente = ComponentesProyecto.Modelo().Insertar(nuevoComponente);
            return Convert.ToInt32(nuevoComponente.Celda("id"));
        }

        public void EditarComponete(int IdComponente, string NombreComponente)
        {
            ComponentesProyecto comp = new ComponentesProyecto();
            comp.CargarDatos(IdComponente);
            comp.Fila().ModificarCelda("nombre", NombreComponente);
            comp.GuardarDatos();
        }

        private void EditarSubensamble(int idSubEnsamble, string nombreSubEnsamble)
        {
            SubensambleProyecto sub = new SubensambleProyecto();
            sub.CargarDatos(IdSubensamble);
            sub.Fila().ModificarCelda("nombre", nombreSubEnsamble);
            sub.GuardarDatos();
        }

        private void CargarSubensambles(decimal Proyecto)
        {
            int seleccionarFila = Global.GuardarFila(DgvVarianteComponente);
            DgvSubEnsambles.Rows.Clear();

            SubensambleProyecto.Modelo().Filtrar(Proyecto, TxtFiltroSubEnsamble.Text).ForEach(delegate(Fila f)
            {
                DgvSubEnsambles.Rows.Add(f.Celda("id"), f.Celda("proyecto"), f.Celda("nombre"));
                Global.RefrescarSeleccionarFila(DgvVarianteComponente, seleccionarFila);
            });

            nuevaParteToolStripMenuItem.Enabled = false;
            eliminarParteToolStripMenuItem.Enabled = false;
        }

        private void EliminarSubensamble()
        {
            if (DgvSubEnsambles.SelectedRows.Count <= 0)
                return;

            DialogResult diag = MessageBox.Show("¿Desea eliminar este subensamble?", "Eliminar subensamble", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diag == System.Windows.Forms.DialogResult.Yes)
            {
                SubensambleProyecto sub = new SubensambleProyecto();
                sub.CargarDatos(IdSubensamble);
                sub.BorrarDatos(IdSubensamble);
                CargarSubensambles(Proyecto);
            }
        }

        private void EliminarParteSubensamble()
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro que deseas eliminar la parte seleccionada?", "Eliminar parte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;

            SubensambleParte sub = new SubensambleParte();
            sub.CargarDatos(IdParteSubEnsamble);
            sub.BorrarDatos();
            CargarPartesSubensamble();
        }

        private void CargarPartesSubensamble()
        {
            int seleccionarFila = Global.GuardarFila(DgvModelos);
            DgvPartesSubEnsamble.Rows.Clear();
            SubensambleParte.Modelo().SeleccionarComponentes(IdSubensamble).ForEach(delegate(Fila f)
            {
                DgvPartesSubEnsamble.Rows.Add(f.Celda("id"), f.Celda("nombre"), f.Celda("tipo"));
            });
            SubensambleParte.Modelo().SeleccionarSubensambles(IdSubensamble).ForEach(delegate(Fila f) {
                DgvPartesSubEnsamble.Rows.Add(f.Celda("id"), f.Celda("nombre"), f.Celda("tipo"));
            });
            Global.RefrescarSeleccionarFila(DgvModelos, seleccionarFila);

            eliminarParteToolStripMenuItem.Enabled = false;
        }

        private void DgvListaComponentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvComponentes.SelectedRows.Count > 0)
            {
                ContextMenuComponentes.Enabled = true;
                IdComponente = Convert.ToInt32(DgvComponentes.SelectedRows[0].Cells["id_componente"].Value);
                //Proyecto = Convert.ToDecimal(DgvComponentes.SelectedRows[0].Cells["numero_proyectos"].Value);
                CargarVariantes(IdComponente);
                VisorPDF.LoadFile("none");
                agregarVariantesToolStripMenuItem.Enabled = true;
            }
        }

        private void DgvVarianteComponente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvVarianteComponente.SelectedRows.Count > 0)
            {
                IdVariante = Convert.ToInt32(DgvVarianteComponente.SelectedRows[0].Cells["variante_id"].Value);
                CargarArchivo(IdVariante);
                editarVariantesToolStripMenuItem.Enabled = true;
                eliminarVarianteToolStripMenuItem.Enabled = true;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
     
        private void TxtFiltroComponente_TextChanged(object sender, EventArgs e)
        {
            CargarComponentes();
        }

        private void DgvModelos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ContextMenuModelos.Show(Cursor.Position);
        }

        private void DgvModelos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvModelos.SelectedRows.Count <= 0)
                return;
            
            if (DgvModelos.SelectedRows[0].Cells["id_modelo"].Value != null)
            {
                IdModelo = Convert.ToInt32(DgvModelos.SelectedRows[0].Cells["id_modelo"].Value);
                ContextMenuModelos.Enabled = true;
            }
            else
            {
                IdModelo = 0;
                ContextMenuModelos.Enabled = false;
            }
        }

        private void toolStripMenuEliminar_Click(object sender, EventArgs e)
        {
             DialogResult dialog = MessageBox.Show("¿Desea eliminar los modelos seleccionados?", "Eliminar modelos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach(DataGridViewRow row in DgvModelos.SelectedRows)
            {
                ModelosProyecto mod = new ModelosProyecto();
                if (row.Cells["id_modelo"].Value != null)
                {
                    int idModelos = Convert.ToInt32(row.Cells["id_modelo"].Value); 
                    mod.CargarDatos(idModelos);
                }
                mod.BorrarDatos();
            }
            VisorPDF.LoadFile("none");
            CargarModelos(Proyecto);
        }

        private void DgvModelos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvModelos.Rows[e.RowIndex].Cells["nombre_modelo"].Value == null)
                return;

            if (IdModelo == 0)
            {
                string nombreModelo = DgvModelos.Rows[e.RowIndex].Cells["nombre_modelo"].Value.ToString();
                DgvModelos.Rows[e.RowIndex].Cells["id_modelo"].Value = AltaModelo(nombreModelo);
            }
            else
            {
                string nombreModelo = DgvModelos.Rows[e.RowIndex].Cells["nombre_modelo"].Value.ToString();
                EditarModelo(IdModelo, nombreModelo);   
            }
        }

        private void TxtFiltroModelo_TextChanged(object sender, EventArgs e)
        {
            CargarModelos(Proyecto);
        }

        private void BtnEditarModelos_Click(object sender, EventArgs e)
        {
            if(BtnEditarModelos.Text == "Editar")
            {
                BtnEditarModelos.Text = "Finalizar";
                DgvModelos.ReadOnly = false;
                DgvModelos.AllowUserToAddRows = true;
            }
            else
            {
                BtnEditarModelos.Text = "Editar";
                DgvModelos.ReadOnly = true;
                DgvModelos.AllowUserToAddRows = false;
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    CargarModelos(Proyecto);
                    break;
                case 1:
                    CargarComponentes();
                    VisorPDF.LoadFile("none");
                    DgvVarianteComponente.Rows.Clear();
                    break;
                case 2:
                    CargarSubensambles(Proyecto);
                    DgvPartesSubEnsamble.Rows.Clear();
                    break;
            }
        }

        private void DgvSubensambles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvSubEnsambles.SelectedRows.Count <= 0 || DgvSubEnsambles.SelectedRows[0].Cells["id_subensamble"].Value == null)
            {
                IdSubensamble = 0;
                return;
            }

            nuevaParteToolStripMenuItem.Enabled = true;
            editarSubensamblesToolStripMenuItem.Enabled = true;
            IdSubensamble = Convert.ToInt32(DgvSubEnsambles.SelectedRows[0].Cells["id_subensamble"].Value);

            CargarPartesSubensamble();
        }

        private void DgvSubensambles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvSubEnsambles.Rows[e.RowIndex].Cells["nombre_subensamble"].Value == null)
                return;

            if (IdSubensamble == 0)
            {
                string subEnsamble = DgvSubEnsambles.Rows[e.RowIndex].Cells["nombre_subensamble"].Value.ToString();
                DgvSubEnsambles.Rows[e.RowIndex].Cells["id_subensamble"].Value = NuevoSubensamble(subEnsamble);
            }
            else
            {
                string subEnsamble = DgvSubEnsambles.Rows[e.RowIndex].Cells["nombre_subensamble"].Value.ToString();
                EditarSubensamble(IdSubensamble, subEnsamble);
            }
        }

        private void TxtFiltroSubensamble_TextChanged(object sender, EventArgs e)
        {
            CargarSubensambles(Proyecto);
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void nuevaParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaParteSubensamble nuevaParte = new FrmNuevaParteSubensamble(Proyecto, IdSubensamble);
            if (nuevaParte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarPartesSubensamble();
            }
        }

        private void eliminarParteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarParteSubensamble();
        }

        private void editarSubensamblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editarSubensamblesToolStripMenuItem.Text == "Editar subensambles")
            {
                editarSubensamblesToolStripMenuItem.Text = "Finalizar edición";
                DgvSubEnsambles.ReadOnly = false;
                DgvSubEnsambles.AllowUserToAddRows = true;
            }
            else
            {
                editarSubensamblesToolStripMenuItem.Text = "Editar subensambles";
                DgvSubEnsambles.ReadOnly = true;
                DgvSubEnsambles.AllowUserToAddRows = false;
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarSubensamble();
        }

        private void DgvPartesSubEnsamble_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPartesSubEnsamble.SelectedRows.Count <= 0)
                return; 
            IdParteSubEnsamble = Convert.ToInt32(DgvPartesSubEnsamble.SelectedRows[0].Cells["id_pieza_subensamble"].Value);
            eliminarParteToolStripMenuItem.Enabled = true;
        }

        private void BtnOpcionesComponentes_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesComponentes.ContextMenuStrip != null)
                BtnOpcionesComponentes.ContextMenuStrip.Show(BtnOpcionesComponentes, BtnOpcionesComponentes.PointToClient(Cursor.Position));
        }

        private void editarComponentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editarComponentesToolStripMenuItem.Text == "Editar componentes")
            {
                editarComponentesToolStripMenuItem.Text = "Finalizar edición";
                DgvComponentes.ReadOnly = false;
                DgvComponentes.AllowUserToAddRows = true;
            }
            else
            {
                editarComponentesToolStripMenuItem.Text = "Editar componentes";
                DgvComponentes.ReadOnly = true;
                DgvComponentes.AllowUserToAddRows = false;
            }
        }

        private void DgvComponentes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvComponentes.Rows[e.RowIndex].Cells["componente"].Value == null)
                return;

            if (IdComponente == 0)
            {
                string componente = DgvComponentes.Rows[e.RowIndex].Cells["componente"].Value.ToString();
                DgvComponentes.Rows[e.RowIndex].Cells["id_componente"].Value = NuevoComponente(componente);
            }
            else
            {
                string componente = DgvComponentes.Rows[e.RowIndex].Cells["componente"].Value.ToString();
                EditarComponete(IdComponente, componente);
            }
        }

        private void DgvComponentes_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ContextMenuComponentes.Show(Cursor.Position);
        }

        private void ContextEliminarComponente_Click(object sender, EventArgs e)
        {
            if (BorrarComponente())
            {
                DgvVarianteComponente.Rows.Clear();
                VisorPDF.LoadFile("none");
            }
        }

        private void agregarVariantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaVarianteComponete altvariable = new FrmAltaVarianteComponete(IdComponente, Proyecto);
            if (altvariable.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                CargarVariantes(IdComponente);
        }

        private void editarVariantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAltaVarianteComponete altvariante = new FrmAltaVarianteComponete(IdComponente, Proyecto, IdVariante);
            if (altvariante.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                CargarVariantes(IdComponente);
        }

        private void eliminarVarianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarVariante(IdVariante);
        }
    }
}