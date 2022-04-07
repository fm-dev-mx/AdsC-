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
    public partial class FrmAccionesKPIs : Ventana
    {
        int IdProceso = 0;
        int IdAccion = 0;
        bool Editar = false;
        string Indicador = string.Empty;

        public FrmAccionesKPIs(int idProceso, string indicador)
        {
            InitializeComponent();
            IdProceso = idProceso;
            Indicador = indicador;
            CmbFiltro.SelectedIndex = 0;
            CmbFiltroEfectividad.SelectedIndex = 0;
        }

        private void FrmAccionesKPIs_Load(object sender, EventArgs e)
        {
            Proceso proceso = new Proceso();
            proceso.CargarDatos(IdProceso);
            if(proceso.TieneFilas())
            {
                TxtProceso.Text = proceso.Fila().Celda("nombre").ToString();
                TxtIndicador.Text = Indicador;
            }
            
            CargarAcciones();
        }

        private void CargarAcciones()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvAcciones);
            DgvAcciones.Rows.Clear();

            IndicadorProceso indicadoresProceso = new IndicadorProceso();
            indicadoresProceso.SeleccionarNombre(IdProceso, Indicador);

            if(indicadoresProceso.TieneFilas())
            {
                Accion accion = new Accion();
                accion.CargarAccionesPorIndicador(Convert.ToInt32(indicadoresProceso.Fila().Celda("id")), CmbFiltro.Text, CmbFiltroEfectividad.Text).ForEach(delegate(Fila f)
                {
                    object fechaPromesa = f.Celda("fecha_promesa");
                    object fechaEvaluacion = f.Celda("fecha_evaluacion");
                    string duenioDelProceso = string.Empty;

                    if (fechaPromesa != null)
                        fechaPromesa = Convert.ToDateTime(fechaPromesa).ToString("MMM dd, yyyy");
                    else
                        fechaPromesa = "";

                    if (fechaEvaluacion != null)
                        fechaEvaluacion = Global.FechaATexto(fechaEvaluacion);

                    Proceso proceso = new Proceso();
                    proceso.CargarDatos(IdProceso);
                    if (proceso.TieneFilas())
                    {
                        int idRol = Convert.ToInt32(proceso.Fila().Celda("puesto_responsable"));
                        Rol roles = new Rol();
                        roles.CargarDatos(idRol);
                        if(roles.TieneFilas())
                        {
                            Usuario usuario = new Usuario();
                            usuario.SeleccionarRol(roles.Fila().Celda("rol").ToString());
                            if (usuario.TieneFilas())
                                duenioDelProceso = usuario.NombreCompleto();
                        }
                    }

                    DgvAcciones.Rows.Add(f.Celda("idAcciones"),
                                         Global.ObjetoATexto(f.Celda("tipo"), ""),
                                         f.Celda("descripcion"),
                                         fechaPromesa,
                                         duenioDelProceso,
                                         Global.ObjetoATexto(f.Celda("estatus"), ""),
                                         Global.ObjetoATexto(f.Celda("responsable"), ""),
                                         fechaEvaluacion,
                                         Global.ObjetoATexto(f.Celda("efectividad"), "SIN EVALUAR"));                    
                });
                ConfiguracionDataGridView.Recuperar(cfg, DgvAcciones);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvAcciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            IdAccion = Convert.ToInt32(DgvAcciones.Rows[e.RowIndex].Cells["id"].Value);          
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void agregarAcciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarAccionesIndicadorKPI agregar = new FrmAgregarAccionesIndicadorKPI(TxtProceso.Text, Indicador);
            if(agregar.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                int idIdentificador = 0;

                IndicadorProceso indicador = new IndicadorProceso();
                indicador.SeleccionarNombre(IdProceso, Indicador);
                if (indicador.TieneFilas())
                    idIdentificador = Convert.ToInt32(indicador.Fila().Celda("id"));
                else
                {
                    MessageBox.Show("No fue posible encontrar el indicador", "Indicador no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Fila agregarTarea = new Fila();
                agregarTarea.AgregarCelda("topico", 0);
                agregarTarea.AgregarCelda("nombre", "");
                agregarTarea.AgregarCelda("tarea_principal", 0);
                agregarTarea.AgregarCelda("estatus", agregar.estatus);
                agregarTarea.AgregarCelda("descripcion", agregar.Detalles);
                agregarTarea.AgregarCelda("fecha_promesa", agregar.FechaPromesa);
                int idTarea = Convert.ToInt32(TareasTopico.Modelo().Insertar(agregarTarea).Celda("id"));

                Fila insertarAcciones = new Fila();
                insertarAcciones.AgregarCelda("tipo", agregar.tipoAccion);
                insertarAcciones.AgregarCelda("tarea", idTarea);
                insertarAcciones.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
                insertarAcciones.AgregarCelda("no_conformidad", 0);
                insertarAcciones.AgregarCelda("notificacion", 0);
                insertarAcciones.AgregarCelda("indicador", idIdentificador);
                insertarAcciones.AgregarCelda("fecha_creacion", DateTime.Now);
                Accion.Modelo().Insertar(insertarAcciones);

                Fila insertarResponsable = new Fila();
                insertarResponsable.AgregarCelda("tarea", idTarea);
                insertarResponsable.AgregarCelda("responsable", Global.UsuarioActual.NombreCompleto());
                TareasResponsables.Modelo().Insertar(insertarResponsable);
                CargarAcciones();
            }
        }

        private void editarAcciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarAccionesIndicadorKPI editar = new FrmAgregarAccionesIndicadorKPI(TxtProceso.Text, Indicador, IdAccion);
            if (editar.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                int IdTarea = 0;

                Accion acciones = new Accion();
                acciones.CargarDatos(IdAccion);
                if(acciones.TieneFilas())
                {
                    acciones.Fila().ModificarCelda("tipo", editar.tipoAccion);
                    IdTarea = Convert.ToInt32(acciones.Fila().Celda("tarea"));
                    acciones.GuardarDatos();
                }

                TareasTopico tarea = new TareasTopico();
                tarea.CargarDatos(IdTarea);
                if(tarea.TieneFilas())
                {
                    tarea.Fila().ModificarCelda("fecha_promesa", editar.FechaPromesa);
                    tarea.Fila().ModificarCelda("estatus", editar.estatus);
                    tarea.Fila().ModificarCelda("descripcion", editar.Detalles);
                    tarea.GuardarDatos();
                }
                CargarAcciones();
            }
        }

        private void MenuOpciones_Opening(object sender, CancelEventArgs e)
        {
            if (DgvAcciones.Rows.Count <= 0)
            {
                editarAcciónToolStripMenuItem.Enabled = false;
                eliminarAccióToolStripMenuItem.Enabled = false;
                evaluarToolStripMenuItem.Enabled = false;
            }
            else
            {
                if(DgvAcciones.SelectedRows[0].Cells["estatus"].Value.ToString() == "TERMINADO")
                {
                    editarAcciónToolStripMenuItem.Enabled = false;
                    eliminarAccióToolStripMenuItem.Enabled = false;

                    if(DgvAcciones.SelectedRows[0].Cells["efectividad"].Value.ToString() == "SIN EVALUAR")
                        evaluarToolStripMenuItem.Enabled = true;
                    else
                        evaluarToolStripMenuItem.Enabled = false;
                }
                else
                {
                    editarAcciónToolStripMenuItem.Enabled = true;
                    eliminarAccióToolStripMenuItem.Enabled = true;
                    evaluarToolStripMenuItem.Enabled = false;
                }
            }
        }

        private void eliminarAccióToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult resul = MessageBox.Show("La información que borre no podrá ser recuperada nuevamente, ¿Desea borrar los datos?", "Borrar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if(resul == System.Windows.Forms.DialogResult.Yes)
            {
                int IdTarea = 0;

                foreach (DataGridViewRow row in DgvAcciones.SelectedRows)
                {
                    int idAccion = Convert.ToInt32(row.Cells["id"].Value);

                    Accion buscarAccion = new Accion();
                    buscarAccion.CargarDatos(idAccion);
                    if (buscarAccion.TieneFilas())
                    {
                        IdTarea = Convert.ToInt32(buscarAccion.Fila().Celda("tarea"));
                        Accion acciones = new Accion();
                        acciones.CargarDatos(Convert.ToInt32(buscarAccion.Fila().Celda("id")));
                        acciones.BorrarDatos(Convert.ToInt32(buscarAccion.Fila().Celda("id")));
                        acciones.GuardarDatos();
                    }

                    TareasTopico.Modelo().CargarDatos(IdTarea).ForEach(delegate(Fila f)
                    {
                        TareasTopico tarea = new TareasTopico();
                        tarea.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        tarea.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                        tarea.GuardarDatos();
                    });

                    TareasResponsables.Modelo().SeleccionarTarea(IdTarea).ForEach(delegate(Fila f)
                    {
                        TareasResponsables responsable = new TareasResponsables();
                        responsable.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        responsable.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                        responsable.GuardarDatos();
                    });
                }

                CargarAcciones();
            }
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAcciones();
        }

        private void CmbFiltroEfectividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAcciones();
        }

        private void DgvAcciones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatusAccion = DgvAcciones.Rows[e.RowIndex].Cells["estatus"].Value.ToString();
            string estatusEfectividad = DgvAcciones.Rows[e.RowIndex].Cells["efectividad"].Value.ToString();

            switch (estatusAccion)
            {
                case "PENDIENTE":
                    DgvAcciones.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.Yellow;
                    DgvAcciones.Rows[e.RowIndex].Cells["estatus"].Style.ForeColor = Color.Black;
                    break;
                case "EN PROCESO":
                    DgvAcciones.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.DarkBlue;
                    DgvAcciones.Rows[e.RowIndex].Cells["estatus"].Style.ForeColor = Color.White;
                    break;
                case "TERMINADO":
                    DgvAcciones.Rows[e.RowIndex].Cells["estatus"].Style.BackColor = Color.LightGreen;
                    DgvAcciones.Rows[e.RowIndex].Cells["estatus"].Style.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }

            switch (estatusEfectividad)
            {
                case "EFECTIVA":
                    DgvAcciones.Rows[e.RowIndex].Cells["efectividad"].Style.BackColor = Color.LightGreen;
                    DgvAcciones.Rows[e.RowIndex].Cells["efectividad"].Style.ForeColor = Color.Black;
                    break;
                case "NO EFECTIVA":
                    DgvAcciones.Rows[e.RowIndex].Cells["efectividad"].Style.BackColor = Color.Crimson;
                    DgvAcciones.Rows[e.RowIndex].Cells["efectividad"].Style.ForeColor = Color.White;
                    break;
                default:
                    break;
            }
        }

        private void efectivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idAccion = Convert.ToInt32(DgvAcciones.SelectedRows[0].Cells["id"].Value);

            DialogResult result = MessageBox.Show("¿Está seguro que deseas marcar como 'EFECTIVA' esta acción?", "Efectiva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Accion accion = new Accion();
                accion.CargarDatos(idAccion);
                if (accion.TieneFilas())
                {
                    accion.Fila().ModificarCelda("efectividad", "EFECTIVA");
                    accion.Fila().ModificarCelda("fecha_evaluacion", DateTime.Now);
                    accion.GuardarDatos();
                }

                CargarAcciones();
            }
        }

        private void noEfectivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idAccion = Convert.ToInt32(DgvAcciones.SelectedRows[0].Cells["id"].Value);

            DialogResult result = MessageBox.Show("¿Está seguro que deseas marcar como 'NO EFECTIVA' esta acción?", "No efectiva", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Accion accion = new Accion();
                accion.CargarDatos(idAccion);
                if (accion.TieneFilas())
                {
                    accion.Fila().ModificarCelda("efectividad", "NO EFECTIVA");
                    accion.GuardarDatos();
                }

                CargarAcciones();
            }
        }
    }
}
