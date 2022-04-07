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

namespace CB
{
    public partial class FrmCronogramaProyecto : Ventana
    {
        decimal IdProyecto = 0;
        Proyecto ProyectoCargado = new Proyecto();
        Proyecto ProyectoPrincipal = new Proyecto();
        int IdProcesoProyectoSeleccionado = 0;
        ProyectoProceso ProyectoProcesoSeleccionado = new ProyectoProceso();
        ProyectoProceso BuscadorProyectoProceso = new ProyectoProceso();
        DateTime FechaSeleccionadaCalendario;
        Meta BuscadorMetas = new Meta();
        MetaEntregable BuscadorEntregables = new MetaEntregable();
        Modulo BuscadorModulos = new Modulo();
        PlanoProyecto BuscadorPlanos = new PlanoProyecto();
        MaterialFabricante BuscadorFabricantes = new MaterialFabricante();
        MaterialProyecto BuscadorMaterial = new MaterialProyecto();
        List<Fila> ListaMetasEncontradas = new List<Fila>();

        public FrmCronogramaProyecto(decimal idProyecto)
        {
            InitializeComponent();
            IdProyecto = idProyecto;          
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmCronogramaProyecto_Load(object sender, EventArgs e)
        {
            CargarProyecto();
        }

        private void CargarProyecto()
        {
            ProyectoCargado.CargarDatos(IdProyecto);

            if (ProyectoCargado.TieneFilas())
                ProyectoPrincipal.CargarDatos(Convert.ToInt32(ProyectoCargado.Fila().Celda("principal")));

            LblTitulo.Text = "CRONOGRAMA DEL PROYECTO " + IdProyecto.ToString("F2").PadLeft(6, '0');
            LblTitulo.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();
            WindowState = FormWindowState.Maximized;

            FechaInicio.Value = Convert.ToDateTime(ProyectoCargado.Fila().Celda("fecha_inicio"));
            FechaEntrega.Value = Convert.ToDateTime(ProyectoCargado.Fila().Celda("fecha_entrega"));

            OcultarMetas();
            CargarProcesos();
        }

        public void OcultarMetas()
        {
            SeparadorMetas.Panel2Collapsed = true;
        }

        public void MostrarMetas()
        {
            if (DgvCalendario.SelectedCells.Count <= 0)
                return;            
            DgvMetas.Rows.Clear();
            LblTituloMetas.Text = "METAS ESTABLECIDAS PARA " + Global.FechaATexto(FechaSeleccionadaCalendario, false).ToUpper();
            if (!BkgCargarMetas.IsBusy)
            {
               // DgvCalendario.Enabled = false;
                LblEstatusMetas.Text = "Cargando metas, porfavor espere...";
                ProgresoEstatusMetas.Visible = true;
                BkgCargarMetas.RunWorkerAsync();
            }
        }

        private void MenuProcesos_Opening(object sender, CancelEventArgs e)
        {
            eliminarProcesoToolStripMenuItem.Enabled = DgvProcesos.SelectedRows.Count > 0;
            modificarFechaInicioToolStripMenuItem.Enabled = DgvProcesos.SelectedRows.Count > 0;
            modificarFechaFinToolStripMenuItem.Enabled = DgvProcesos.SelectedRows.Count > 0;
            copiarDesdeProyectoPrincipalToolStripMenuItem.Enabled = Convert.ToDecimal(ProyectoCargado.Fila().Celda("principal")) != IdProyecto;
        }

        private void nuevoProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProyectoProceso procesoAnterior = new ProyectoProceso();
            procesoAnterior.CargarDatos(IdProcesoProyectoSeleccionado);

            FrmNuevoProcesoProyecto npp = new FrmNuevoProcesoProyecto(IdProyecto, FechaInicio.Value, FechaEntrega.Value, procesoAnterior);

            if(npp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarProcesos();
            }
        }

        public void CargarProcesos()
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvProcesos);
            DgvProcesos.Rows.Clear();
            ProyectoProceso.Modelo().SeleccionarProyecto(IdProyecto).ForEach(delegate(Fila f)
            {
                DgvProcesos.Rows.Add(f.Celda("id"),
                                     f.Celda("nombre_proceso"), 
                                     Global.FechaATexto(f.Celda("fecha_inicio"), false), 
                                     Global.FechaATexto(f.Celda("fecha_fin"), false),
                                     Convert.ToDateTime(f.Celda("fecha_inicio")).ToString("yyyy-MM-dd"),
                                     Convert.ToDateTime(f.Celda("fecha_fin")).ToString("yyyy-MM-dd")
                                     );
            });
            CargarCalendario();
        }

        public void CargarCalendario()
        {
            DateTime fechaActual = FechaInicio.Value.Date;

            int indiceFilaSeleccionada = 0;
            int indiceColumnaSeleccionada = 0;
            int indicePrimeraColumnaMostrada = 0;

            if (DgvCalendario.SelectedCells.Count > 0)
            {
                indiceFilaSeleccionada = DgvCalendario.SelectedCells[0].RowIndex;
                indiceColumnaSeleccionada = DgvCalendario.SelectedCells[0].ColumnIndex;
                indicePrimeraColumnaMostrada = DgvCalendario.FirstDisplayedScrollingColumnIndex;
            }
           
            DgvCalendario.Rows.Clear();
            DgvCalendario.Columns.Clear();
            while (fechaActual.Date < FechaEntrega.Value.Date)
            {
                DgvCalendario.Columns.Add(fechaActual.ToString("yyyy-MM-dd"), fechaActual.ToString("MMM dd"));
                DgvCalendario.Columns[DgvCalendario.Columns.Count - 1].Width = 60;
                DgvCalendario.Columns[DgvCalendario.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;
                fechaActual = fechaActual.AddDays(1);
            }

            foreach(DataGridViewRow filaProceso in DgvProcesos.Rows)
            {
                int idProcesoProyecto = Convert.ToInt32(filaProceso.Cells[0].Value);
                ProyectoProceso pp = new ProyectoProceso();
                pp.CargarDatos(idProcesoProyecto);
                int idProceso = 0;

                if (pp.TieneFilas())
                    idProceso = Convert.ToInt32(pp.Fila().Celda("proceso"));

                Proceso proc = new Proceso();
                proc.CargarDatos(idProceso);

                var indiceNuevaFilaCalendario = DgvCalendario.Rows.Add();
                DateTime fechaInicioProceso = Convert.ToDateTime(filaProceso.Cells["fecha_inicio_estandar"].Value.ToString());
                DateTime fechaFinProceso = Convert.ToDateTime(filaProceso.Cells["fecha_fin_estandar"].Value.ToString());

                foreach(DataGridViewColumn columnaCalendario in DgvCalendario.Columns)
                {
                    DateTime fechaCalendario = Convert.ToDateTime(columnaCalendario.Name);
                    DataGridViewCell celda = DgvCalendario.Rows[indiceNuevaFilaCalendario].Cells[columnaCalendario.Index];

                    celda.Value = string.Empty;

                    if(fechaCalendario.Date.DayOfWeek == DayOfWeek.Saturday || fechaCalendario.Date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        celda.Style.BackColor = Color.LightGray;
                        celda.Style.ForeColor = Color.Black;
                    }
                    else if(fechaCalendario.Date >= fechaInicioProceso.Date && fechaCalendario.Date <= fechaFinProceso.Date)
                    {
                        celda.Style.BackColor = System.Drawing.ColorTranslator.FromHtml(proc.Fila().Celda("color_fondo").ToString());
                        celda.Style.ForeColor = System.Drawing.ColorTranslator.FromHtml(proc.Fila().Celda("color_texto").ToString());
                    }

                    int totalMetas = BuscadorMetas.TotalMetasProyectoFecha(IdProyecto, idProceso, fechaCalendario);

                    if (totalMetas > 0)
                        celda.Value = totalMetas.ToString() + " meta(s)";
                }
            }

            if(indiceFilaSeleccionada >= 0 &&  indiceColumnaSeleccionada >= 0)
            {
                if(DgvCalendario.Rows.Count > indiceFilaSeleccionada && DgvCalendario.Columns.Count > indiceColumnaSeleccionada)
                {
                    DgvCalendario.Rows[indiceFilaSeleccionada].Cells[indiceColumnaSeleccionada].Selected = true;

                    if (indicePrimeraColumnaMostrada < DgvCalendario.Columns.Count && indicePrimeraColumnaMostrada >= 0)
                        DgvCalendario.FirstDisplayedScrollingColumnIndex = indicePrimeraColumnaMostrada;
                }
            }
        }

        private void eliminarProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "¿Seguro que quieres borrar el proceso seleccionado?";
            msg += Environment.NewLine + Environment.NewLine + "Toma en cuenta que se borrarán todas las metas establecidas y no podrán recuperarse.";

            DialogResult resp = MessageBox.Show(msg, "Borrar proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            EliminarProcesoSeleccionado();
            CargarProcesos();
        }

        public void EliminarProcesoSeleccionado()
        {
            // buscamos las metas vinculadas con el proceso del proyecto e itera por cada una de ellas
            BuscadorMetas.SeleccionarMetaPorProyectoProceso(IdProyecto, Convert.ToInt32(ProyectoProcesoSeleccionado.Fila().Celda("proceso")));

            // eliminamos las metas vinculadas
            EliminarMetasDelBuscador();

            // finalmente borramos el proceso del proyecto
            ProyectoProcesoSeleccionado.BorrarDatos();
        }

        public void EliminarMetasDelBuscador()
        {
            BuscadorMetas.Filas().ForEach(delegate(Fila meta)
            {
                // busca los entregables vinculados con la meta actual en la iteracion
                BuscadorEntregables
                    .SeleccionarMeta(Convert.ToInt32(meta.Celda("id"))).ForEach(delegate(Fila entregable)
                    {
                        // identificamos el id y el tipo de entregable
                        int idEntregable = Convert.ToInt32(entregable.Celda("id_entregable"));
                        string tipoEntregable = entregable.Celda("tipo_entregable").ToString();

                        // procesamos el entregable acorde a su tipo
                        switch (tipoEntregable)
                        {
                            case "MODULO FABRICADO":

                                // cargamos el modulo
                                BuscadorModulos.CargarDatos(idEntregable);

                                // si lo encontramos...
                                if (BuscadorModulos.TieneFilas())
                                {
                                    // borramos la fecha promesa de fabricacion
                                    BuscadorModulos.Fila().ModificarCelda("fecha_promesa_fabricacion", null);
                                    BuscadorModulos.GuardarDatos();

                                    // ubicamos el subensamble
                                    int subensamble = Convert.ToInt32(BuscadorModulos.Fila().Celda("subensamble"));

                                    // buscamos los planos vinculados con el modulo y 
                                    // borramos la fecha promesa de fabricacion de cada plano encontrado
                                    BuscadorPlanos.SeleccionarPlanosDeModulo(IdProyecto, subensamble).ForEach(delegate(Fila plano)
                                    {
                                        plano.ModificarCelda("fecha_promesa_fabricacion", null);
                                    });
                                    BuscadorPlanos.GuardarDatos();
                                }
                                break;

                            case "PARTE FABRICADA":
                                // cargamos el plano vinculado con la meta (entregable) y le borramos la fecha promesa de fabricacion
                                BuscadorPlanos.CargarDatos(idEntregable).ForEach(delegate(Fila plano)
                                {
                                    plano.ModificarCelda("fecha_promesa_fabricacion", null);
                                });
                                BuscadorPlanos.GuardarDatos();
                                break;

                            case "MATERIAL DE REQUISICION":
                                // cargamos la requisicion de compra vinculada con la meta (entregable) y le borramos la fecha promesa de compras
                                BuscadorMaterial.CargarDatos(idEntregable).ForEach(delegate(Fila material)
                                {
                                    material.ModificarCelda("fecha_promesa_compras", null);
                                });
                                BuscadorMaterial.GuardarDatos();
                                break;

                            case "MATERIAL DE FABRICANTE":
                                // ubicamos el id del fabricante
                                BuscadorFabricantes.CargarDatos(idEntregable);

                                if(BuscadorFabricantes.TieneFilas())
                                {
                                    // cargamos las requisiciones de compra vinculadas con la meta (entregables) y les borramos la fecha promesa de compras
                                    BuscadorMaterial.SeleccionarMaterialDefinidoAutorizadoDeFabricante(IdProyecto, BuscadorFabricantes.Fila().Celda("fabricante").ToString());

                                    BuscadorMaterial.Filas().ForEach(delegate(Fila material)
                                    {
                                        material.ModificarCelda("fecha_promesa_compras", null);
                                    });
                                    BuscadorMaterial.GuardarDatos();
                                }
                                break;

                            case "MATERIAL DE MODULO":
                                // ubicamos el modulo
                                BuscadorModulos.CargarDatos(idEntregable);

                                if(BuscadorModulos.TieneFilas())
                                {
                                    BuscadorMaterial.SeleccionarMaterialDefinidoAutorizadoDeModulo(IdProyecto, Convert.ToInt32(BuscadorModulos.Fila().Celda("subensamble")));

                                    BuscadorMaterial.Filas().ForEach(delegate(Fila material)
                                    {
                                        material.ModificarCelda("fecha_promesa_compras", null);
                                    });
                                    BuscadorMaterial.GuardarDatos();
                                }
                                break;

                            case "MODULO CONGELADO":
                                // ubicamos el modulo
                                BuscadorModulos.CargarDatos(idEntregable);

                                if(BuscadorModulos.TieneFilas())
                                {
                                    BuscadorModulos.Fila().ModificarCelda("fecha_promesa_congelacion", null);
                                }
                                BuscadorModulos.GuardarDatos();
                                break;
                        }
                    });
                BuscadorEntregables.BorrarDatos(); // borramos todos los entregables vinculados con cada meta
            });
            BuscadorMetas.BorrarDatos(); // borramos todas las metas vinculadas con el proceso del proyecto
        }

        private void DgvProcesos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvProcesos.SelectedRows.Count <= 0)
                IdProcesoProyectoSeleccionado = 0;
            else
                IdProcesoProyectoSeleccionado = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells[0].Value);

            ProyectoProcesoSeleccionado.CargarDatos(IdProcesoProyectoSeleccionado);

            if (IdProcesoProyectoSeleccionado == 0)
                return;

            int indice = DgvProcesos.SelectedRows[0].Index;

            if(DgvCalendario.RowCount > indice)
            {
                int columnaSeleccionada = 0;
                
                if(DgvCalendario.SelectedCells.Count > 0)
                    columnaSeleccionada = DgvCalendario.SelectedCells[0].ColumnIndex;

                DgvCalendario.ClearSelection();
                DgvCalendario.Rows[indice].Cells[columnaSeleccionada].Selected = true;
            }
        }

        private void DgvCalendario_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvCalendario.SelectedCells.Count <= 0)
                return;

            int indice = DgvCalendario.SelectedCells[0].RowIndex;

            if(DgvProcesos.RowCount > indice)
                DgvProcesos.Rows[indice].Selected = true;

            DateTime.TryParse(DgvCalendario.Columns[DgvCalendario.SelectedCells[0].ColumnIndex].Name, out FechaSeleccionadaCalendario);
        }

        private void MenuCalendario_Opening(object sender, CancelEventArgs e)
        {
            nuevaMetaToolStripMenuItem.Enabled = FechaCalendarioEnRangoDelProceso();
        }

        public bool FechaCalendarioEnRangoDelProceso()
        {
            bool fechaEnRangoDelProcesoSeleccionado = false;

            if (DgvCalendario.SelectedCells.Count > 0)
            {
                if (ProyectoProcesoSeleccionado.TieneFilas())
                {
                    DateTime fechaInicioProceso;
                    DateTime fechaFinProceso;

                    DateTime.TryParse(ProyectoProcesoSeleccionado.Fila().Celda("fecha_inicio").ToString(), out fechaInicioProceso);
                    DateTime.TryParse(ProyectoProcesoSeleccionado.Fila().Celda("fecha_fin").ToString(), out fechaFinProceso);

                    fechaEnRangoDelProcesoSeleccionado = FechaSeleccionadaCalendario >= fechaInicioProceso && FechaSeleccionadaCalendario <= fechaFinProceso;
                }
            }
            return fechaEnRangoDelProcesoSeleccionado;
        }

        private void nuevaMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FechaSeleccionadaCalendario.Date < DateTime.Now.Date)
            {
                MessageBox.Show("No puede agregar una meta si la fecha seleccionada es menor a la fecha actual", "No puede agregar metas en fechas pasadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FrmNuevaMetaProyecto nuevaMeta = new FrmNuevaMetaProyecto(ProyectoProcesoSeleccionado, FechaSeleccionadaCalendario);

            if(nuevaMeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarCalendario();
            }
        }

        private void DgvCalendario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string valorCelda = DgvCalendario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (valorCelda.Contains("meta(s)"))
                MostrarMetas();
            else
                OcultarMetas();
        }

        private void BtnOcultarMetas_Click(object sender, EventArgs e)
        {
            OcultarMetas();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            FrmAjustarFechasProyecto ajustarFecha = new FrmAjustarFechasProyecto(IdProyecto);
            if(ajustarFecha.ShowDialog() ==  System.Windows.Forms.DialogResult.OK)
            {
                Fila insertarAjuste = new Fila();
                insertarAjuste.AgregarCelda("razon", ajustarFecha.IdRazon);
                insertarAjuste.AgregarCelda("fecha_entrega_actual", ajustarFecha.FechaActual);
                insertarAjuste.AgregarCelda("nueva_fecha", ajustarFecha.NuevaFechaAjuste);
                insertarAjuste.AgregarCelda("tipo_ajuste", ajustarFecha.TipoAjuste);
                insertarAjuste.AgregarCelda("dias_naturales", ajustarFecha.DiasNaturales);
                insertarAjuste.AgregarCelda("responsable", ajustarFecha.IdResponsable);
                insertarAjuste.AgregarCelda("fecha_ajuste", DateTime.Now);
                insertarAjuste.AgregarCelda("proyecto",IdProyecto);
                AjusteFecha.Modelo().Insertar(insertarAjuste);

                Proyecto proyecto = new Proyecto();
                proyecto.CargarDatos(IdProyecto);
                if(proyecto.TieneFilas())
                {
                    proyecto.Fila().ModificarCelda("fecha_entrega", ajustarFecha.NuevaFechaAjuste);
                    proyecto.GuardarDatos();
                }
                CargarProcesos();
            }
        }

        private void FechaEntrega_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnHistorial_Click(object sender, EventArgs e)
        {
            FrmConsultarHistorialFechas historialMetas = new FrmConsultarHistorialFechas(IdProyecto);
            historialMetas.Show();
        }

        private void MenuMetas_Opening(object sender, CancelEventArgs e)
        {
            borrarMetaToolStripMenuItem.Enabled = DgvMetas.SelectedRows.Count > 0;
            actualizarMetaToolStripMenuItem.Enabled = DgvMetas.SelectedRows.Count > 0;
        }

        private void borrarMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvMetas.SelectedRows.Count <= 0)
                return;

            DialogResult respuesta = MessageBox.Show("¿Seguro que quieres borrar la meta seleccionada?", "Borrar meta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            int idMetaSeleccionada = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells["id_meta"].Value);

            BuscadorMetas.CargarDatos(idMetaSeleccionada);
            EliminarMetasDelBuscador();
            OcultarMetas();
            CargarProcesos();
        }

        private void modificarFechaInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object fechaPromesa = null;
            int proceso = 0;
            decimal proyecto = 0;
            int idProyectoProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id_proceso"].Value);
            BuscadorProyectoProceso.CargarDatos(idProyectoProceso);
            if(BuscadorProyectoProceso.TieneFilas())
            {
                proceso = Convert.ToInt32(BuscadorProyectoProceso.Fila().Celda("proceso"));
                proyecto = Convert.ToDecimal(BuscadorProyectoProceso.Fila().Celda("proyecto"));
               

                BuscadorMetas.SeleccionarMetasDeProceso(proceso, proyecto, "ASC");
                if (BuscadorMetas.TieneFilas())
                    fechaPromesa = BuscadorMetas.Fila().Celda("fecha_promesa");
                else
                    fechaPromesa = DgvProcesos.SelectedRows[0].Cells["fecha_inicio_estandar"].Value;

                FrmSeleccionarFecha fecha = new FrmSeleccionarFecha(false, ProyectoCargado.Fila().Celda("fecha_inicio"), fechaPromesa);
                if (fecha.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BuscadorProyectoProceso.Fila().ModificarCelda("fecha_inicio", fecha.FechaSeleccionada);
                    BuscadorProyectoProceso.GuardarDatos();
                }

                CargarProcesos();
            }
        }

        private void modificarFechaFinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int proceso = 0;
            decimal proyecto = 0;
            object fechaPromesa = null;
            int idProyectoProceso = Convert.ToInt32(DgvProcesos.SelectedRows[0].Cells["id_proceso"].Value);
            BuscadorProyectoProceso.CargarDatos(idProyectoProceso);
            if (BuscadorProyectoProceso.TieneFilas())
            {
                proceso = Convert.ToInt32(BuscadorProyectoProceso.Fila().Celda("proceso"));
                proyecto = Convert.ToDecimal(BuscadorProyectoProceso.Fila().Celda("proyecto"));

                BuscadorMetas.SeleccionarMetasDeProceso(proceso, proyecto, "DESC");
                if (BuscadorMetas.TieneFilas())
                    fechaPromesa = BuscadorMetas.Fila().Celda("fecha_promesa");
                else
                    fechaPromesa = DgvProcesos.SelectedRows[0].Cells["fecha_fin_estandar"].Value;

                FrmSeleccionarFecha fecha = new FrmSeleccionarFecha(false, fechaPromesa, ProyectoCargado.Fila().Celda("fecha_entrega"));
                if (fecha.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    BuscadorProyectoProceso.Fila().ModificarCelda("fecha_fin", fecha.FechaSeleccionada);
                    BuscadorProyectoProceso.GuardarDatos();
                }

                CargarProcesos();
            }
        }

        private void copiarDesdeProyectoPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            ProyectoProceso pp = new ProyectoProceso();
            pp.SeleccionarProyecto(IdProyecto);

            if(pp.TieneFilas())
            {
                msg = "Para poder copiar los procesos del proyecto principal debes eliminar antes los procesos existentes.";
                MessageBox.Show(msg, "Imposible copiar procesos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            msg = "¿Seguro que quieres copiar los procesos desde el proyecto principal?";

            DialogResult resp = MessageBox.Show(msg, "Copiar procesos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            Proyecto subproyecto = new Proyecto();
            subproyecto.CargarDatos(IdProyecto);
            decimal idProyectoPrincipal = Convert.ToDecimal(subproyecto.Fila().Celda("principal"));

            ProyectoProceso procesosDelProyectoPrincipal = new ProyectoProceso();
            procesosDelProyectoPrincipal.SeleccionarProyecto(idProyectoPrincipal);

            if (subproyecto.TieneFilas())
            {
                procesosDelProyectoPrincipal.Filas().ForEach(delegate(Fila proceso)
                {
                    Fila nuevoProceso = new Fila();
                    nuevoProceso.AgregarCelda("proyecto", IdProyecto);
                    nuevoProceso.AgregarCelda("proceso", proceso.Celda("proceso"));
                    nuevoProceso.AgregarCelda("fecha_inicio", proceso.Celda("fecha_inicio"));
                    nuevoProceso.AgregarCelda("fecha_fin", proceso.Celda("fecha_fin"));
                    ProyectoProceso.Modelo().Insertar(nuevoProceso);
                });
            }
            CargarProcesos();
        }

        private void actualizarMetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idMeta = Convert.ToInt32(DgvMetas.SelectedRows[0].Cells["id_meta"].Value);
            Meta.Modelo().ActualizarAvance(idMeta);
            MostrarMetas();
        }

        private void BkgCargarMetas_DoWork(object sender, DoWorkEventArgs e)
        {
            int avance = 0;

            ListaMetasEncontradas =  BuscadorMetas
                .SeleccionarProyectoProcesoFecha(IdProyecto, Convert.ToInt32(ProyectoProcesoSeleccionado.Fila().Celda("proceso")), FechaSeleccionadaCalendario);

            ListaMetasEncontradas.ForEach(delegate(Fila meta)
            {
                string tipo_entregable = meta.Celda("tipo_entregable").ToString();
                string entregables = Environment.NewLine;
                int idMeta = Convert.ToInt32(meta.Celda("id"));

                BuscadorEntregables.SeleccionarMeta(idMeta).ForEach(delegate(Fila f)
                {
                    int idEntregable = Convert.ToInt32(f.Celda("id_entregable"));

                    switch (tipo_entregable)
                    {
                        case "MODULO FABRICADO":
                        case "MATERIAL DE MODULO":
                        case "MODULO CONGELADO":
                            BuscadorModulos.CargarDatos(idEntregable);
                            if (BuscadorModulos.TieneFilas())
                            {
                                entregables += BuscadorModulos.Fila().Celda("subensamble").ToString().PadLeft(2, '0') + " ";
                                entregables += BuscadorModulos.Fila().Celda("nombre").ToString();
                                entregables += Environment.NewLine;
                            }
                            break;

                        case "PARTE FABRICADA":
                            BuscadorPlanos.CargarDatos(idEntregable);
                            if (BuscadorPlanos.TieneFilas())
                            {
                                entregables += BuscadorPlanos.Fila().Celda("id").ToString().PadLeft(5, '0') + " ";
                                entregables += BuscadorPlanos.Fila().Celda("nombre_archivo").ToString();
                                entregables += Environment.NewLine;
                            }
                            break;

                        case "MATERIAL DE REQUISICION":
                            BuscadorMaterial.CargarDatos(idEntregable);
                            if (BuscadorMaterial.TieneFilas())
                            {
                                entregables += "Req. # " + BuscadorMaterial.Fila().Celda("id").ToString().PadLeft(5, '0');
                                entregables += " | " + BuscadorMaterial.Fila().Celda("numero_parte").ToString();
                                entregables += " | " + BuscadorMaterial.Fila().Celda("fabricante").ToString();
                                entregables += " | " + BuscadorMaterial.Fila().Celda("total").ToString();

                                if (BuscadorMaterial.Fila().Celda("tipo_venta").ToString() == "POR PIEZA")
                                    entregables += " pieza(s)";
                                else if (BuscadorMaterial.Fila().Celda("tipo_venta").ToString() == "POR PAQUETE")
                                    entregables += " paquete(s)";

                                entregables += Environment.NewLine;
                            }
                            break;

                        case "MATERIAL DE FABRICANTE":
                            BuscadorFabricantes.CargarDatos(idEntregable);
                            if (BuscadorFabricantes.TieneFilas())
                            {
                                entregables += BuscadorFabricantes.Fila().Celda("fabricante").ToString();
                                entregables += Environment.NewLine;
                            }
                            break;
                    }
                });

                Fila filaMetas = new Fila();
                filaMetas.AgregarCelda("idMeta", idMeta);
                filaMetas.AgregarCelda("tipoEntregable", tipo_entregable);
                filaMetas.AgregarCelda("entregables", entregables);
                filaMetas.AgregarCelda("estatusAutorizacion", meta.Celda("estatus_autorizacion"));
                filaMetas.AgregarCelda("comentariosAutorizacion", meta.Celda("comentarios_autorizacion"));
                filaMetas.AgregarCelda("avance",Convert.ToDecimal(meta.Celda("avance")).ToString("F2") + "%");

                BkgCargarMetas.ReportProgress(Global.CalcularPorcentaje(avance, ListaMetasEncontradas.Count), filaMetas);                
                avance++;
            });  
        }

        private void BkgCargarMetas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoEstatusMetas.Value = e.ProgressPercentage;
            LblEstatusMetas.Text = "Cargando metas, porfavor espere...";

            Fila meta = (Fila)e.UserState;
            DgvMetas.Rows.Add(
                meta.Celda("idMeta"),
                meta.Celda("tipoEntregable"),
                meta.Celda("entregables"),
                meta.Celda("estatusAutorizacion"),
                meta.Celda("comentariosAutorizacion"),
                meta.Celda("avance"));
        }

        private void BkgCargarMetas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LblEstatusMetas.Text = "!Metas descargadas!";
            ProgresoEstatusMetas.Visible = false;
            ProgresoEstatusMetas.Value = 0;
            SeparadorMetas.Panel2Collapsed = false;
           // DgvCalendario.Enabled = true;
        }
    }
}
