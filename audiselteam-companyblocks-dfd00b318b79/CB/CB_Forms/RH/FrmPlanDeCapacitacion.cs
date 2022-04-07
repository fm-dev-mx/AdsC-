using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FluentFTP;
using System.Net;

namespace CB
{
    public partial class FrmPlanDeCapacitacion : Ventana
    {
        int IdCapacitacion = 0;
        string Detalles = string.Empty;
        string Material = string.Empty;
        string NumeroParte = string.Empty;
        bool ModoEdicion = true;
        FtpClient ClienteFtp = new FtpClient();

        public FrmPlanDeCapacitacion(int idCapacitacion, bool modoEdicion = true)
        {
            InitializeComponent();
            IdCapacitacion = idCapacitacion;
            BtnImprimir.Visible = false;
            ModoEdicion = modoEdicion;
        }

        private void FrmPlanDeCapacitacion_Load(object sender, EventArgs e)
        {
            PlanCapacitacion planCapacitacion = new PlanCapacitacion();
            planCapacitacion.CargarDatos(IdCapacitacion);
            if (planCapacitacion.TieneFilas())
            {
                TxtID.Text = Global.ObjetoATexto(planCapacitacion.Fila().Celda("id"), "0").PadLeft(4, '0');
                TxtNombreCapacitacion.Text = Global.ObjetoATexto(planCapacitacion.Fila().Celda("nombre"), "");
                NumDuracion.Value = Convert.ToInt32(Global.ObjetoATexto(planCapacitacion.Fila().Celda("duracion"), "1"));

                CatalogoMaterial CargarDatosMaterial = new CatalogoMaterial();
                CargarDatosMaterial.CargarDatos(Convert.ToInt32(Global.ObjetoATexto(planCapacitacion.Fila().Celda("catalogo_material"), "0")));
                if (CargarDatosMaterial.TieneFilas())
                    NumeroParte = Global.ObjetoATexto(CargarDatosMaterial.Fila().Celda("numero_parte"), "");

                string strUsuario = string.Empty;
                string fecha= string.Empty;

                Usuario usuario = new Usuario();
                usuario.CargarDatos(Convert.ToInt32(Global.ObjetoATexto(planCapacitacion.Fila().Celda("usuario_modificacion"), "0")));
                if(usuario.TieneFilas())
                {
                    strUsuario = usuario.Fila().Celda("nombre") + " " + usuario.Fila().Celda("paterno");
                    fecha = Global.FechaATexto(planCapacitacion.Fila().Celda("fecha_modificacion"));
                }
                else
                {
                    usuario.CargarDatos(Convert.ToInt32(Global.ObjetoATexto(planCapacitacion.Fila().Celda("usuario_creacion"), "0")));
                    strUsuario = usuario.Fila().Celda("nombre") + " " + usuario.Fila().Celda("paterno");
                    fecha = Global.FechaATexto(planCapacitacion.Fila().Celda("fecha_creacion"));
                }

                LblModificadoPor.Text += strUsuario;
                LblUltimaActualizacion.Text += fecha;

                Detalles = Global.ObjetoATexto(planCapacitacion.Fila().Celda("descripcion"), "");
                Material = Global.ObjetoATexto(planCapacitacion.Fila().Celda("material"), "");
                TxtDetalles.Text = Detalles;
                TxtNumeroParte.Text = NumeroParte;
                TxtRecursosRequeridos.Text = Material;
            }

            CargarHabilidadesTecnicas("TECNICA");
            CargarHabilidadesPersonales("PERSONAL");
            CargarTemas();
            CargarPracticas();
            CargarDocumentos();

            if (!ModoEdicion)
            {
                TxtDetalles.ReadOnly = true;
                TxtRecursosRequeridos.ReadOnly = true;
            }

            if (Global.TipoConexion == "LOCAL")
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
            else
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

            ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                           Global.UsuarioActual.Fila().Celda("password").ToString());

            // Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Connect();
            }
            catch
            {
                MessageBox.Show("No fue posible crear una conexión con el servidor", "Error de comunicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void CargarHabilidadesPersonales(string tipo)
        {
            DgvCompetenciasPersonales.Rows.Clear();

            PlanCapacitacionCompetencia.Modelo().SeleccionarHabilidades(Convert.ToInt32(TxtID.Text), tipo).ForEach(delegate(Fila f)
            {
                DgvCompetenciasPersonales.Rows.Add(f.Celda("idCompetencia"), f.Celda("habilidad"), f.Celda("id_competencias"));
            });
        }

        private void CargarHabilidadesTecnicas(string tipo)
        {
            DgvCompetenciasTecnicas.Rows.Clear();

            PlanCapacitacionCompetencia.Modelo().SeleccionarHabilidades(Convert.ToInt32(TxtID.Text), tipo).ForEach(delegate(Fila f)
            {
                DgvCompetenciasTecnicas.Rows.Add(f.Celda("idCompetencia"), f.Celda("habilidad"), f.Celda("id_competencias"));
            });
        }

        private void NumDuracion_ValueChanged(object sender, EventArgs e)
        {
            PlanCapacitacion planCapacitacion = new PlanCapacitacion();
            planCapacitacion.CargarDatos(IdCapacitacion);
            planCapacitacion.Fila().ModificarCelda("duracion", NumDuracion.Value);
            planCapacitacion.Fila().ModificarCelda("usuario_modificacion", Global.UsuarioActual.Fila().Celda("id"));
            planCapacitacion.Fila().ModificarCelda("fecha_modificacion", DateTime.Now);
            planCapacitacion.GuardarDatos();
        }

        private void TxtDetalles_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void agregarCompetenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionarHabilidades("PERSONAL");
        }

        private void toolStripMenuItemTecnica_Click(object sender, EventArgs e)
        {
            SeleccionarHabilidades("TECNICA");
        }

        private void eliminarCompetenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de borrar la competencia seleccionada?", "Borrar competencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                int idCompetencia = Convert.ToInt32(DgvCompetenciasPersonales.SelectedRows[0].Cells["id_competenciaPlan_personal"].Value);

                PlanCapacitacionCompetencia borrarCompetencia = new PlanCapacitacionCompetencia();
                borrarCompetencia.CargarDatos(idCompetencia);
                borrarCompetencia.BorrarDatos(idCompetencia);
                borrarCompetencia.GuardarDatos();

                CargarHabilidadesPersonales("PERSONAL");
                string competencia = string.Empty;

                PlanCapacitacionCompetencia competencias = new PlanCapacitacionCompetencia();
                competencias.SeleccionarCompetencias(Convert.ToInt32(TxtID.Text)).ForEach(delegate(Fila f)
                {
                    Habilidad habilidad = new Habilidad();
                    habilidad.CargarDatos(Convert.ToInt32(f.Celda("competencia")));
                    if(habilidad.TieneFilas())
                        competencia += habilidad.Fila().Celda("habilidad") + ",";
                });

                competencia = competencia.TrimEnd(',');
                if(competencia.Contains(","))
                {
                    int indiceUltimaComa = competencia.LastIndexOf(',');
                    competencia = competencia.Remove(indiceUltimaComa, 1).Insert(indiceUltimaComa, ",").Replace(",", " Y ");
                }

                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.CargarDatos(Convert.ToInt32(TxtID.Text));
                if(planCapacitacion.TieneFilas())
                {
                    planCapacitacion.Fila().ModificarCelda("nombre", competencia);
                    planCapacitacion.Fila().ModificarCelda("usuario_modificacion", Global.UsuarioActual.Fila().Celda("id"));
                    planCapacitacion.Fila().ModificarCelda("fecha_modificacion", DateTime.Now);
                    planCapacitacion.GuardarDatos();
                    TxtNombreCapacitacion.Text = competencia;
                }
            }
        }

        private void eliminarCompetenciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de borrar la competencia seleccionada?", "Borrar competencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idCompetencia = Convert.ToInt32(DgvCompetenciasTecnicas.SelectedRows[0].Cells["id_competenciaPlan_tecnica"].Value);

                PlanCapacitacionCompetencia borrarCompetencia = new PlanCapacitacionCompetencia();
                borrarCompetencia.CargarDatos(idCompetencia);
                borrarCompetencia.BorrarDatos(idCompetencia);
                borrarCompetencia.GuardarDatos();

                CargarHabilidadesTecnicas("TECNICA");
                string competencia = string.Empty;

                PlanCapacitacionCompetencia competencias = new PlanCapacitacionCompetencia();
                competencias.SeleccionarCompetencias(Convert.ToInt32(TxtID.Text)).ForEach(delegate(Fila f)
                {
                    Habilidad habilidad = new Habilidad();
                    habilidad.CargarDatos(Convert.ToInt32(f.Celda("competencia")));
                    if (habilidad.TieneFilas())
                        competencia += habilidad.Fila().Celda("habilidad") + ",";
                });

                competencia = competencia.TrimEnd(',');
                if (competencia.Contains(","))
                {
                    int indiceUltimaComa = competencia.LastIndexOf(',');
                    competencia = competencia.Remove(indiceUltimaComa, 1).Insert(indiceUltimaComa, ",").Replace(",", " Y ");
                }

                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.CargarDatos(Convert.ToInt32(TxtID.Text));
                if (planCapacitacion.TieneFilas())
                {
                    planCapacitacion.Fila().ModificarCelda("nombre", competencia);
                    planCapacitacion.Fila().ModificarCelda("usuario_modificacion", Global.UsuarioActual.Fila().Celda("id"));
                    planCapacitacion.Fila().ModificarCelda("fecha_modificacion", DateTime.Now);
                    planCapacitacion.GuardarDatos();
                    TxtNombreCapacitacion.Text = competencia;
                }
            }
        }

        public void SeleccionarHabilidades(string tipo)
        {
            FrmSeleccionarHabilidades selecHabilidades = new FrmSeleccionarHabilidades(tipo, null);
            if (selecHabilidades.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //verificar si ya contiene la competencia
                List<int> idCompetenciaLista = new List<int>();
                foreach (DataGridViewRow row in DgvCompetenciasPersonales.Rows)
                    selecHabilidades.HabilidadesSeleccionadas.Remove(Convert.ToInt32(row.Cells["id"].Value));

                foreach (DataGridViewRow row in DgvCompetenciasTecnicas.Rows)
                    selecHabilidades.HabilidadesSeleccionadas.Remove(Convert.ToInt32(row.Cells["id_habilidad_tecnica"].Value));

                if (selecHabilidades.HabilidadesSeleccionadas.Count <= 0)
                    return;

                //verificamos que no sean más de 3 competencias totales
                if (selecHabilidades.HabilidadesSeleccionadas.Count + DgvCompetenciasPersonales.Rows.Count + DgvCompetenciasTecnicas.Rows.Count > 3)
                {
                    MessageBox.Show("No puede agregar las competencias seleccionadas, seleccione solamente 3 en total", "Seleccione 3 competencias en total", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string agregarCapacitacion = string.Empty;
                string nombreCapacitacion = string.Empty;

                //insertamos las competencias seleccionadas
                foreach (int idCompetencia in selecHabilidades.HabilidadesSeleccionadas)
                {
                    Fila insertarNuevaCompetencia = new Fila();
                    insertarNuevaCompetencia.AgregarCelda("plan_capacitacion", Convert.ToInt32(TxtID.Text));
                    insertarNuevaCompetencia.AgregarCelda("competencia", idCompetencia);
                    PlanCapacitacionCompetencia.Modelo().Insertar(insertarNuevaCompetencia);

                    Habilidad habilidad = new Habilidad();
                    habilidad.CargarDatos(idCompetencia);
                    if (habilidad.TieneFilas())
                        agregarCapacitacion += habilidad.Fila().Celda("habilidad") + ",";
                }

                agregarCapacitacion = agregarCapacitacion.TrimEnd(',');
               
                //construimos el nombre con las competencias
                if (TxtNombreCapacitacion.Text.Contains(" Y "))
                {
                    nombreCapacitacion = TxtNombreCapacitacion.Text.Replace(" Y ", ", ");
                    nombreCapacitacion += " Y " + agregarCapacitacion;
                }
                else
                {
                    nombreCapacitacion = TxtNombreCapacitacion.Text + "," + agregarCapacitacion;
                    int indiceUltimaComa = nombreCapacitacion.LastIndexOf(',');
                    nombreCapacitacion = nombreCapacitacion.Remove(indiceUltimaComa, 1).Insert(indiceUltimaComa, " Y ").Replace(",", ", ");
                }

                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.CargarDatos(IdCapacitacion);
                planCapacitacion.Fila().ModificarCelda("nombre", nombreCapacitacion);
                planCapacitacion.Fila().ModificarCelda("usuario_modificacion", Global.UsuarioActual.Fila().Celda("id"));
                planCapacitacion.Fila().ModificarCelda("fecha_modificacion", DateTime.Now);
                planCapacitacion.GuardarDatos();

                TxtNombreCapacitacion.Text = nombreCapacitacion;

                CargarHabilidadesTecnicas("TECNICA");
                CargarHabilidadesPersonales("PERSONAL");
            }
        }

        private void MenuCompetenciaPersonal_Opening(object sender, CancelEventArgs e)
        {
            if (!ModoEdicion)
                return;

            int CompetenciasMaximas = DgvCompetenciasPersonales.Rows.Count + DgvCompetenciasTecnicas.Rows.Count;
            if (CompetenciasMaximas < 3)
                agregarCompetenciaToolStripMenuItem.Visible = true;
            else
                agregarCompetenciaToolStripMenuItem.Visible = false;

            if (DgvCompetenciasPersonales.Rows.Count + DgvCompetenciasTecnicas.Rows.Count <= 1)
                eliminarCompetenciaToolStripMenuItem.Visible = false;
            else
                eliminarCompetenciaToolStripMenuItem.Visible = true;

        }

        private void MenuCompetenciaTecnica_Opening(object sender, CancelEventArgs e)
        {
            if (!ModoEdicion)
                return;

            int CompetenciasMaximas = DgvCompetenciasPersonales.Rows.Count + DgvCompetenciasTecnicas.Rows.Count;
            if (CompetenciasMaximas < 3)
                toolStripMenuItemTecnica.Visible = true;
            else
                toolStripMenuItemTecnica.Visible = false;

            if (DgvCompetenciasPersonales.Rows.Count + DgvCompetenciasTecnicas.Rows.Count <= 1)
                eliminarCompetenciaToolStripMenuItem1.Visible = false;
            else
                eliminarCompetenciaToolStripMenuItem1.Visible = true;
        }

        private void agregarTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minutosRestantes = Convert.ToInt32(NumDuracion.Value);
            foreach (DataGridViewRow row in DgvPracticas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_practica"].Value);
            foreach (DataGridViewRow row in DgvTemas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_tema"].Value);

            FrmAgregarPuntosPrograma nuevoTema = new FrmAgregarPuntosPrograma("AGREGAR NUEVO TEMA", "TEMA", minutosRestantes);
            if(nuevoTema.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                Fila insertarNuevoTema = new Fila();
                insertarNuevoTema.AgregarCelda("tema", nuevoTema.Texto);
                insertarNuevoTema.AgregarCelda("duracion", nuevoTema.Duracion);
                insertarNuevoTema.AgregarCelda("plan_capacitacion", Convert.ToInt32(TxtID.Text));
                TemaCapacitacion.Modelo().Insertar(insertarNuevoTema);
                CargarTemas();
            }
        }

        private void editarTemaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int minutosRestantes = Convert.ToInt32(NumDuracion.Value);
            foreach (DataGridViewRow row in DgvPracticas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_practica"].Value);
            foreach (DataGridViewRow row in DgvTemas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_tema"].Value);

            TemaCapacitacion temas = new TemaCapacitacion();
            temas.CargarDatos(Convert.ToInt32(DgvTemas.SelectedRows[0].Cells["id_tema"].Value));
            if (temas.TieneFilas())
            {
                string tema = Global.ObjetoATexto(temas.Fila().Celda("tema"), "");
                int duracion = Convert.ToInt32(Global.ObjetoATexto(temas.Fila().Celda("duracion"), "1"));

                FrmAgregarPuntosPrograma nuevoTema = new FrmAgregarPuntosPrograma("EDITAR TEMA", "TEMA", minutosRestantes + duracion, tema, duracion);
                if (nuevoTema.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    temas.Fila().ModificarCelda("tema", nuevoTema.Texto);
                    temas.Fila().ModificarCelda("duracion", nuevoTema.Duracion);
                    temas.GuardarDatos();
                    CargarTemas();
                }
            }
        }

        private void CargarTemas()
        {
            DgvTemas.Rows.Clear();

            TemaCapacitacion temas = new TemaCapacitacion();
            temas.SeleccionarTemas(Convert.ToInt32(TxtID.Text)).ForEach(delegate(Fila f)
            {
                DgvTemas.Rows.Add(f.Celda("id"), Global.ObjetoATexto(f.Celda("tema"), ""), f.Celda("duracion"));
            });

            if (DgvTemas.Rows.Count > 0)
                DgvTemas.ClearSelection();
        }

        private void CargarPracticas()
        {
            DgvPracticas.Rows.Clear();

            PracticaCapacitacion temas = new PracticaCapacitacion();
            temas.SeleccionarPracticas(Convert.ToInt32(TxtID.Text)).ForEach(delegate(Fila f)
            {
                DgvPracticas.Rows.Add(f.Celda("id"), Global.ObjetoATexto(f.Celda("practica"), ""), f.Celda("duracion"));
            });

            if (DgvPracticas.Rows.Count > 0)
                DgvPracticas.ClearSelection();
        }

        private void MenuTemario_Opening(object sender, CancelEventArgs e)
        {
            if (!ModoEdicion)
                return;

            if(DgvTemas.Rows.Count == 0)
            {
                editarTemaToolStripMenuItem2.Visible = false;
                eliminarTemaToolStripMenuItem.Visible = false;
            }
            else if(DgvTemas.SelectedRows.Count == 1)
            {
                editarTemaToolStripMenuItem2.Visible = true;
                eliminarTemaToolStripMenuItem.Visible = true;
            }
            else if(DgvTemas.SelectedRows.Count > 1)
            {
                editarTemaToolStripMenuItem2.Visible = false;
                eliminarTemaToolStripMenuItem.Visible = true;
            }
            else if(DgvTemas.SelectedRows.Count == 0)
            {
                editarTemaToolStripMenuItem2.Visible = false;
                eliminarTemaToolStripMenuItem.Visible = false;
            }

            int minutosRestantes = Convert.ToInt32(NumDuracion.Value);
            foreach (DataGridViewRow row in DgvPracticas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_practica"].Value);
            foreach (DataGridViewRow row in DgvTemas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_tema"].Value);

            if (minutosRestantes > 0)
                agregarTemaToolStripMenuItem.Visible = true;
            else
                agregarTemaToolStripMenuItem.Visible = false;

        }

        private void eliminarTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string temas = string.Empty;
            foreach (DataGridViewRow row in DgvTemas.SelectedRows)
                temas += row.Cells["tema"].Value + Environment.NewLine;

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar las tareas seleccionadas?" + Environment.NewLine + temas, "Eliminar tareas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvTemas.SelectedRows)
                {
                    TemaCapacitacion borrarTema = new TemaCapacitacion();
                    borrarTema.CargarDatos(Convert.ToInt32(row.Cells["id_tema"].Value));
                    borrarTema.BorrarDatos(Convert.ToInt32(row.Cells["id_tema"].Value));
                    borrarTema.GuardarDatos();
                }
                CargarTemas();
            }
        }

        private void agregarPrácticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minutosRestantes = Convert.ToInt32(NumDuracion.Value);
            foreach (DataGridViewRow row in DgvPracticas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_practica"].Value);
            foreach (DataGridViewRow row in DgvTemas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_tema"].Value);

            FrmAgregarPuntosPrograma nuevaPractica = new FrmAgregarPuntosPrograma("AGREGAR NUEVA PRACTICA", "Práctica", minutosRestantes);
            if (nuevaPractica.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                Fila insertarNuevaPractica = new Fila();
                insertarNuevaPractica.AgregarCelda("practica", nuevaPractica.Texto);
                insertarNuevaPractica.AgregarCelda("duracion", nuevaPractica.Duracion);
                insertarNuevaPractica.AgregarCelda("plan_capacitacion", Convert.ToInt32(TxtID.Text));
                PracticaCapacitacion.Modelo().Insertar(insertarNuevaPractica);
                CargarPracticas();
            }
        }

        private void editarPrácticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minutosRestantes = Convert.ToInt32(NumDuracion.Value);
            foreach (DataGridViewRow row in DgvPracticas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_practica"].Value);
            foreach (DataGridViewRow row in DgvTemas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_tema"].Value);

            PracticaCapacitacion practicas = new PracticaCapacitacion();
            practicas.CargarDatos(Convert.ToInt32(DgvPracticas.SelectedRows[0].Cells["id_practica"].Value));
            if (practicas.TieneFilas())
            {
                string practica = Global.ObjetoATexto(practicas.Fila().Celda("practica"), "");
                int duracion = Convert.ToInt32(Global.ObjetoATexto(practicas.Fila().Celda("duracion"), "1"));

                FrmAgregarPuntosPrograma nuevaPractica = new FrmAgregarPuntosPrograma("EDITAR PRACTICA", "Práctica", minutosRestantes + duracion, practica, duracion);
                if (nuevaPractica.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    practicas.Fila().ModificarCelda("practica", nuevaPractica.Texto);
                    practicas.Fila().ModificarCelda("duracion", nuevaPractica.Duracion);
                    practicas.GuardarDatos();
                    CargarPracticas();
                }
            }
        }

        private void MenuPractica_Opening(object sender, CancelEventArgs e)
        {
            if (!ModoEdicion)
                return;

            if (DgvPracticas.Rows.Count == 0)
            {
                editarPrácticaToolStripMenuItem.Visible = false;
                eliminarPrácticaToolStripMenuItem.Visible = false;
            }
            else if (DgvPracticas.SelectedRows.Count == 1)
            {
                editarPrácticaToolStripMenuItem.Visible = true;
                eliminarPrácticaToolStripMenuItem.Visible = true;
            }
            else if (DgvPracticas.SelectedRows.Count > 1)
            {
                editarPrácticaToolStripMenuItem.Visible = false;
                eliminarPrácticaToolStripMenuItem.Visible = true;
            }
            else if (DgvPracticas.SelectedRows.Count == 0)
            {
                editarPrácticaToolStripMenuItem.Visible = false;
                eliminarPrácticaToolStripMenuItem.Visible = false;
            }

            int minutosRestantes = Convert.ToInt32(NumDuracion.Value);
            foreach (DataGridViewRow row in DgvPracticas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_practica"].Value);
            foreach (DataGridViewRow row in DgvTemas.Rows)
                minutosRestantes -= Convert.ToInt32(row.Cells["duracion_tema"].Value);

            if (minutosRestantes > 0)
                agregarPrácticaToolStripMenuItem.Visible = true;
            else
                agregarPrácticaToolStripMenuItem.Visible = false;
        }

        private void eliminarPrácticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string practicas = string.Empty;
            foreach (DataGridViewRow row in DgvPracticas.SelectedRows)
                practicas += row.Cells["practica"].Value + Environment.NewLine;

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar las prácticas seleccionadas?" + Environment.NewLine + practicas, "Eliminar prácticas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvPracticas.SelectedRows)
                {
                    PracticaCapacitacion borrarTema = new PracticaCapacitacion();
                    borrarTema.CargarDatos(Convert.ToInt32(row.Cells["id_practica"].Value));
                    borrarTema.BorrarDatos(Convert.ToInt32(row.Cells["id_practica"].Value));
                    borrarTema.GuardarDatos();
                }
                CargarPracticas();
            }
        }

        private void registrarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files (*.*)|*.*";

            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Seleccione los documentos";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var file in openFileDialog1.FileNames)
                {
                    try
                    {
                        //Guardar información del documento en la BD
                        Fila agregarDocumento = new Fila();
                        agregarDocumento.AgregarCelda("nombre_archivo", Path.GetFileName(file));
                        agregarDocumento.AgregarCelda("plan_capacitacion", Convert.ToInt32(TxtID.Text));
                        int idDocumento = Convert.ToInt32(AnexoCapacitacion.Modelo().Insertar(agregarDocumento).Celda("id"));

                        byte[] documentoDatos = File.ReadAllBytes(file);

                        //Guardar documento en FTP
                        //Verificamos si existe el directorio, sino lo creamos
                        if (!ClienteFtp.DirectoryExists("SGC\\CAPACITACION\\ANEXOS\\"))
                            ClienteFtp.CreateDirectory("SGC\\CAPACITACION\\ANEXOS\\");

                        // enviar archivos a carpeta ftp
                        ClienteFtp.Upload(documentoDatos, "SGC\\CAPACITACION\\ANEXOS\\" + idDocumento + Path.GetExtension(file), FtpExists.Overwrite);                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error mientras se guardaba su documento, si el problema continua pongase en contacto con el personal de sistemas." + Environment.NewLine + "Error: " + ex.ToString(), "Error al guardar su documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                MessageBox.Show("Documento creado correctamente", "Documento creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDocumentos();
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files (*.*)|*.*";

            openFileDialog1.Multiselect = false;
            openFileDialog1.Title = "Seleccione el documento";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    try
                    {
                        int idAnexo = Convert.ToInt32(DgvAnexos.SelectedRows[0].Cells["id_anexo"].Value);
                        string extension = Path.GetExtension(DgvAnexos.SelectedRows[0].Cells["anexos"].Value.ToString());

                        //Actualizar información del documento en la BD
                        AnexoCapacitacion actualizarAnexo = new AnexoCapacitacion();
                        actualizarAnexo.CargarDatos(idAnexo);
                        actualizarAnexo.Fila().ModificarCelda("nombre_archivo", Path.GetFileName(file));
                        actualizarAnexo.GuardarDatos();

                        byte[] documentoDatos = File.ReadAllBytes(file);

                        //Guardar documento en FTP
                        //Verificamos si existe el directorio, sino lo creamos
                        if (!ClienteFtp.DirectoryExists("SGC\\CAPACITACION\\ANEXOS\\"))
                             ClienteFtp.CreateDirectory("SGC\\CAPACITACION\\ANEXOS\\");

                        // borramos archivo en caso que cambie a extension
                        if (ClienteFtp.FileExists("SGC\\CAPACITACION\\ANEXOS\\" + idAnexo + extension))
                             ClienteFtp.DeleteFile("SGC\\CAPACITACION\\ANEXOS\\" + idAnexo + extension);

                        // enviar archivos a carpeta ftp
                        ClienteFtp.Upload(documentoDatos, "SGC\\CAPACITACION\\ANEXOS\\" + Convert.ToInt32(DgvAnexos.SelectedRows[0].Cells["id_anexo"].Value) + Path.GetExtension(file), FtpExists.Overwrite);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error mientras se guardaba su documento, si el problema continua pongase en contacto con el personal de sistemas." + Environment.NewLine + "Error: " + ex.ToString(), "Error al guardar su documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                MessageBox.Show("Documento creado correctamente", "Documento creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDocumentos();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string anexos = string.Empty;
            foreach (DataGridViewRow row in DgvTemas.SelectedRows)
                anexos += row.Cells["anexos"].Value + Environment.NewLine;

            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar los archivos seleccionados?" + Environment.NewLine + anexos, "Eliminar anexos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DgvAnexos.SelectedRows)
                {
                    int idAnexo = Convert.ToInt32(row.Cells["id_anexo"].Value);
                    string extension = Path.GetExtension(row.Cells["anexos"].Value.ToString());

                    AnexoCapacitacion borrarAnexo = new AnexoCapacitacion();                   
                    borrarAnexo.CargarDatos(idAnexo);
                    borrarAnexo.BorrarDatos(idAnexo);
                    borrarAnexo.GuardarDatos();

                    //Verificamos si existe el directorio, sino lo creamos
                    if (ClienteFtp.DirectoryExists("SGC\\CAPACITACION\\ANEXOS\\"))
                    {
                        // borrar archivo de ftp
                        ClienteFtp.DeleteFile("SGC\\CAPACITACION\\ANEXOS\\" + idAnexo + extension);
                    }
                }
                CargarDocumentos();
            }
        }

        private void CargarDocumentos()
        {
            DgvAnexos.Rows.Clear();

            AnexoCapacitacion anexo = new AnexoCapacitacion();
            anexo.BuscarAnexo(Convert.ToInt32(TxtID.Text)).ForEach(delegate(Fila f)
            {
                DgvAnexos.Rows.Add(f.Celda("id"), f.Celda("nombre_archivo"));
            });

            if (DgvAnexos.Rows.Count > 0)
                DgvAnexos.ClearSelection();
        }

        private void MenuAnexo_Opening(object sender, CancelEventArgs e)
        {
            if (!ModoEdicion)
            {
                if (DgvAnexos.SelectedRows.Count == 1)
                {
                    guardarToolStripMenuItem.Visible = true;
                    verToolStripMenuItem.Visible = true;
                }
                else
                {
                    guardarToolStripMenuItem.Visible = false;
                    verToolStripMenuItem.Visible = false;
                }
                return;
            }

            if (DgvAnexos.Rows.Count == 0)
            {
                actualizarToolStripMenuItem.Visible = false;
                eliminarToolStripMenuItem.Visible = false;
                guardarToolStripMenuItem.Visible = false;
                verToolStripMenuItem.Visible = false;
            }
            else if (DgvAnexos.SelectedRows.Count == 1)
            {
                actualizarToolStripMenuItem.Visible = true;
                eliminarToolStripMenuItem.Visible = true;
                guardarToolStripMenuItem.Visible = true;
                verToolStripMenuItem.Visible = true;
            }
            else if (DgvAnexos.SelectedRows.Count > 1)
            {
                actualizarToolStripMenuItem.Visible = false;
                guardarToolStripMenuItem.Visible = false;
                eliminarToolStripMenuItem.Visible = true;
                verToolStripMenuItem.Visible = false;
            }
            else if (DgvAnexos.SelectedRows.Count == 0)
            {
                actualizarToolStripMenuItem.Visible = false;
                guardarToolStripMenuItem.Visible = false;
                eliminarToolStripMenuItem.Visible = false;
                verToolStripMenuItem.Visible = false;
            }

            registrarArchivoToolStripMenuItem.Visible = true;
        }

        private void TxtRecursosRequeridos_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idDocumento = Convert.ToInt32(DgvAnexos.SelectedRows[0].Cells["id_anexo"].Value);
            if (ClienteFtp.IsConnected)
            {
                AnexoCapacitacion anexo = new AnexoCapacitacion();
                anexo.CargarDatos(idDocumento);
                string nombreArchivo = anexo.Fila().Celda("nombre_archivo").ToString();
                byte[] datos = null;

                ClienteFtp.Download(out datos, "SGC\\CAPACITACION\\ANEXOS\\" + idDocumento + Path.GetExtension(nombreArchivo));
                
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.Title = "Guardar archivo " + nombreArchivo;
                saveFileDialog1.FileName = nombreArchivo;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog1.FileName, datos);
                }
            }
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idDocumento = Convert.ToInt32(DgvAnexos.SelectedRows[0].Cells["id_anexo"].Value);
            if (ClienteFtp.IsConnected)
            {
                AnexoCapacitacion anexo = new AnexoCapacitacion();
                anexo.CargarDatos(idDocumento);
                string nombreArchivo = anexo.Fila().Celda("nombre_archivo").ToString();
                byte[] datos = null;
                ClienteFtp.Download(out datos, "SGC\\CAPACITACION\\ANEXOS\\" + idDocumento + Path.GetExtension(nombreArchivo));

                if (Path.GetExtension(nombreArchivo).ToUpper() == ".PDF")
                {
                    FrmVisorPDF visor = new FrmVisorPDF(datos, nombreArchivo);
                    visor.Show();
                }
                else
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "All files (*.*)|*.*";
                    saveFileDialog1.Title = "Guardar archivo " + nombreArchivo;
                    saveFileDialog1.FileName = nombreArchivo;
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog1.FileName, datos);
                    }
                }
            }
        }

        private void TxtDetalles_Leave(object sender, EventArgs e)
        {
            if (TxtDetalles.Text != Detalles)
            {
                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.CargarDatos(IdCapacitacion);
                planCapacitacion.Fila().ModificarCelda("descripcion", TxtDetalles.Text);
                planCapacitacion.Fila().ModificarCelda("usuario_modificacion", Global.UsuarioActual.Fila().Celda("id"));
                planCapacitacion.Fila().ModificarCelda("fecha_modificacion", DateTime.Now);
                planCapacitacion.GuardarDatos();
            }
        }

        private void TxtRecursosRequeridos_Leave(object sender, EventArgs e)
        {
            if (TxtRecursosRequeridos.Text != Material)
            {
                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.CargarDatos(Convert.ToInt32(TxtID.Text));
                if (planCapacitacion.TieneFilas())
                {
                    planCapacitacion.Fila().ModificarCelda("material", TxtRecursosRequeridos.Text);
                    planCapacitacion.Fila().ModificarCelda("usuario_modificacion", Global.UsuarioActual.Fila().Celda("id"));
                    planCapacitacion.Fila().ModificarCelda("fecha_modificacion", DateTime.Now);
                    planCapacitacion.GuardarDatos();
                }
            }
        }

        private void BtnNumeroParte_Click(object sender, EventArgs e)
        {
            List<string> filtro = new List<string>()
            {
                "SERVICIOS"
            };

            FrmSeleccionarMaterialCatalogo2 Catalogo = new FrmSeleccionarMaterialCatalogo2(filtro, false, false);
            //FrmSeleccionarMaterialCatalogo Catalogo = new FrmSeleccionarMaterialCatalogo( false, false);
            if (Catalogo.ShowDialog() == DialogResult.OK)
            {
                int idMaterial = Catalogo.IdMaterial;

                PlanCapacitacion planCapacitacion = new PlanCapacitacion();
                planCapacitacion.CargarDatos(Convert.ToInt32(TxtID.Text));
                planCapacitacion.Fila().ModificarCelda("catalogo_material", idMaterial);
                planCapacitacion.GuardarDatos();

                CatalogoMaterial CargarDatosMaterial = new CatalogoMaterial();
                CargarDatosMaterial.CargarDatos(idMaterial);
                if(CargarDatosMaterial.TieneFilas())
                    TxtNumeroParte.Text = Global.ObjetoATexto(CargarDatosMaterial.Fila().Celda("numero_parte"), "");
            }
        }

        private void TxtNumeroParte_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
