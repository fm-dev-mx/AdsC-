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
using System.IO;

namespace CB
{
    public partial class FrmDetallesRequerimiento : Ventana
    {
        int IdRequerimiento = 0;
        Requerimiento RequerimientoCargado = new Requerimiento();

        public FrmDetallesRequerimiento(int idRequerimiento)
        {
            InitializeComponent();
            RequerimientoCargado.CargarDatos(idRequerimiento);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        private void FrmRevisarRequerimiento_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CargarRequerimiento();
        }

        public void CargarRequerimiento()
        {
            if (RequerimientoCargado.TieneFilas())
            {
                LblNombre.Text = RequerimientoCargado.Fila().Celda("id") + " - " + RequerimientoCargado.Fila().Celda("nombre").ToString();
                TxtDescripcion.Text = RequerimientoCargado.Fila().Celda("descripcion").ToString();
                TxtDescripcion.ReadOnly = true;
                IdRequerimiento = (int)RequerimientoCargado.Fila().Celda("id");
                LblNivelRevision.Text = RequerimientoCargado.Fila().Celda("nivel_revision").ToString();
                LblOrigen.Text = RequerimientoCargado.Fila().Celda("origen").ToString();
                LblEstatus.Text = RequerimientoCargado.Fila().Celda("estatus").ToString();

                string estatus_revision = RequerimientoCargado.Fila().Celda("estatus_revision").ToString();
                TxtComentariosRevision.Text = RequerimientoCargado.Fila().Celda("comentarios_revision").ToString();

                revisarToolStripMenuItem.Enabled = (estatus_revision == "PENDIENTE" || estatus_revision == "NO CUMPLE" || estatus_revision == "NO APLICA") && Global.VerificarPrivilegio("PROYECTOS", "REVISAR REQUERIMIENTO");
                nuevoToolStripMenuItem.Enabled = (estatus_revision == "PENDIENTE" && Global.VerificarPrivilegio("PROYECTOS", "EDITAR REQUERIMIENTO")) || Tabs.SelectedIndex == 3;
                
                LblEstatusRevision.Text = estatus_revision;
                switch(estatus_revision)
                {
                    case "PENDIENTE":
                        break;

                    case "CUMPLE":
                        LblEstatusRevision.ForeColor = Color.Black;
                        LblEstatusRevision.BackColor = Color.LightGreen;
                        break;

                    case "NO CUMPLE":
                        LblEstatusRevision.ForeColor = Color.White;
                        LblEstatusRevision.BackColor = Color.Red;
                        break;
                        
                    case "NO APLICA":
                        LblEstatusRevision.ForeColor = Color.Black;
                        LblEstatusRevision.BackColor = Color.LightGray;
                        break;
                }
                
                CargarParametros();
            }
        }

        public void CargarParametros()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvParametros);
            DgvParametros.Rows.Clear();

            RequerimientoParametro.Modelo().SeleccionarRequerimiento(IdRequerimiento).ForEach(delegate(Fila f)
            {
                DgvParametros.Rows.Add(f.Celda("id"), f.Celda("parametro"), f.Celda("valor"), f.Celda("comentarios"));
            });

            Global.RecuperarFilaSeleccionada(DgvParametros, fila);
        }

        public void CargarKeyitems()
        {
            //int fila = Global.GuardarFila(DgvKeyitems);
            //DgvKeyitems.Rows.Clear();

            //RequerimientoKeyitem.Modelo().SeleccionarRequerimiento(IdRequerimiento).ForEach(delegate(Fila f)
            //{
            //    DgvKeyitems.Rows.Add(f.Celda("id"), f.Celda("tipo"), f.Celda("numero_parte"), f.Celda("fabricante"), f.Celda("piezas_requeridas"), f.Celda("descripcion"));
            //});

            //Global.RefrescarSeleccionarFila(DgvKeyitems, fila);
        }

        public void CargarRestricciones()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvRestricciones);
            DgvRestricciones.Rows.Clear();

            RequerimientoRestriccion.Modelo().SeleccionarRequerimiento(IdRequerimiento).ForEach(delegate(Fila f)
            {
                DgvRestricciones.Rows.Add(f.Celda("id"), f.Celda("tipo"), f.Celda("restriccion"));
            });

            Global.RecuperarFilaSeleccionada(DgvRestricciones, fila);
        }

        public void CargarResponsables()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvResponsables);
            DgvResponsables.Rows.Clear();

            RequerimientoResponsable.Modelo().SeleccionarRequerimiento(IdRequerimiento).ForEach(delegate(Fila f)
            {
                DgvResponsables.Rows.Add(f.Celda("id"), f.Celda("responsable"));
            });

            Global.RecuperarFilaSeleccionada(DgvResponsables, fila);
        }

        public void CargarNotas()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvNotas);
            DgvNotas.Rows.Clear();

            RequerimientoNota.Modelo().SeleccionarRequerimiento(IdRequerimiento).ForEach(delegate(Fila f)
            {
                DgvNotas.Rows.Add(f.Celda("id"), 
                                  Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMM dd, yyyy hh:mm:ss tt"), 
                                  f.Celda("usuario_creacion"));
            });

            Global.RecuperarFilaSeleccionada(DgvNotas, fila);
        }

        public void CargarAdjuntos()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvAdjuntos);
            DgvAdjuntos.Rows.Clear();

            RequerimientoAdjunto.Modelo().SeleccionarRequerimiento(IdRequerimiento).ForEach(delegate(Fila f)
            {
                DgvAdjuntos.Rows.Add(f.Celda("id"),
                                     f.Celda("usuario_creacion"),
                                     Convert.ToDateTime(f.Celda("fecha_creacion")).ToString("MMM dd yyyy hh:mm:ss tt"),
                                     f.Celda("nombre_archivo"), 
                                     f.Celda("tipo"));
            });

            Global.RecuperarFilaSeleccionada(DgvAdjuntos, fila);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(Tabs.SelectedIndex)
            {
                case 0:
                    NuevoRequerimiento();
                    break;

                case 1:
                    NuevaRestriccion();
                    break;

                case 2:
                    NuevoResponsable();
                    break;

                case 3:
                    NuevaNota();
                    break;

                case 4:
                    Adjuntar();
                    break;
            }
        }

        public void NuevoRequerimiento()
        {
            FrmNuevoParametroRequermiento np = new FrmNuevoParametroRequermiento(IdRequerimiento);
            if (np.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarParametros();
            }
        }

        public void NuevoKeyitem()
        {
            FrmNuevoKeyitem nki = new FrmNuevoKeyitem(IdRequerimiento);

            if (nki.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarKeyitems();
            }
        }

        public void NuevaRestriccion()
        {
            FrmNuevaRestriccion nre = new FrmNuevaRestriccion(IdRequerimiento);

            if (nre.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarRestricciones();
            }
        }

        public void NuevoResponsable()
        {
            FrmSeleccionarUsuario usr = new FrmSeleccionarUsuario();

            if (usr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila resp = new Fila();
                resp.AgregarCelda("requerimiento", IdRequerimiento);
                resp.AgregarCelda("responsable", usr.UsuarioSeleccionado.NombreCompleto());
                RequerimientoResponsable.Modelo().Insertar(resp);
                CargarResponsables();
            }
        }

        public void NuevaNota()
        {
            FrmIngresarComentario comentario = new FrmIngresarComentario();

            if (comentario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila nota = new Fila();
                nota.AgregarCelda("requerimiento", IdRequerimiento);
                nota.AgregarCelda("nota", comentario.Comentarios);
                nota.AgregarCelda("fecha_creacion", DateTime.Now);
                nota.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                RequerimientoNota.Modelo().Insertar(nota);
                CargarNotas();
            }
        }

        public void Adjuntar()
        {
            if( SeleccionarAdjunto.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                byte[] bytesArchivo = File.ReadAllBytes(SeleccionarAdjunto.FileName);
                int maxMB = Global.MySqlMaxAllowedPackets();

                if( (bytesArchivo.Length/(1024*1024)) > maxMB)
                {
                    MessageBox.Show("El archivo es demasiado grande para adjuntarlo, debe ser máximo " + maxMB + "MB.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Fila adjunto = new Fila();
                adjunto.AgregarCelda("requerimiento", IdRequerimiento);
                adjunto.AgregarCelda("nombre_archivo", SeleccionarAdjunto.SafeFileName);
                adjunto.AgregarCelda("tipo", Path.GetExtension(SeleccionarAdjunto.FileName));
                adjunto.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                adjunto.AgregarCelda("fecha_creacion", DateTime.Now);
                adjunto = RequerimientoAdjunto.Modelo().Insertar(adjunto);

                Fila archivoAdjunto = new Fila();
                archivoAdjunto.AgregarCelda("adjunto", adjunto.Celda("id"));
                archivoAdjunto.AgregarCelda("archivo", bytesArchivo);
                ArchivoRequerimiento.Modelo().Insertar(archivoAdjunto);

                CargarAdjuntos();
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            borrarToolStripMenuItem.Enabled = false;
            editarToolStripMenuItem.Enabled = false;

            switch (Tabs.SelectedIndex)
            {
                case 0:
                    CargarParametros();
                    break;

                case 1:
                    CargarRestricciones();
                    break;

                case 2:
                    CargarResponsables();
                    break;

                case 3:
                    CargarNotas();
                    nuevoToolStripMenuItem.Enabled = true;
                    break;

                case 4:
                    CargarAdjuntos();
                    break;
            }
        }

        private void DgvParametros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarToolStripMenuItem.Enabled = DgvParametros.SelectedRows.Count > 0 &&
                                              RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE" &&
                                              Global.VerificarPrivilegio("PROYECTOS", "EDITAR REQUERIMIENTO");
            editarToolStripMenuItem.Enabled = DgvParametros.SelectedRows.Count > 0 &&
                                              RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE" &&
                                              Global.VerificarPrivilegio("PROYECTOS", "EDITAR REQUERIMIENTO");
        }

        public void EditarParametro()
        {
            if(DgvParametros.SelectedRows.Count <= 0)
                return;

            int IdParametro = (int)DgvParametros.SelectedRows[0].Cells["id"].Value;

            FrmNuevoParametroRequermiento np = new FrmNuevoParametroRequermiento(IdRequerimiento, IdParametro);

            if( np.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                CargarParametros();
            }
        }

        public void BorrarParemetros()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quieres borrar los parámetros seleccionados?", "Borrar parámetros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach(DataGridViewRow row in DgvParametros.SelectedRows)
            {
                int idParametro = (int)row.Cells["id"].Value;
                   
                RequerimientoParametro param = new RequerimientoParametro();
                param.CargarDatos(idParametro);

                if (param.TieneFilas())
                {
                    param.BorrarDatos();
                }
            }
            CargarParametros();
        }

        public void BorrarKeyitems()
        {
            //DialogResult respuesta = MessageBox.Show("Seguro que quieres borrar los Key items seleccionados?", "Borrar key items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (respuesta != System.Windows.Forms.DialogResult.Yes)
            //    return;

            //foreach (DataGridViewRow row in DgvKeyitems.SelectedRows)
            //{
            //    RequerimientoKeyitem ki = new RequerimientoKeyitem();

            //    ki.CargarDatos((int)row.Cells["id_keyitem"].Value);
            //    ki.BorrarDatos();
            //}
            //CargarKeyitems();
        }

        public void BorrarRestricciones()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quieres borrar las restricciones seleccionadas?", "Borrar restricciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in DgvRestricciones.SelectedRows)
            {
                RequerimientoRestriccion res = new RequerimientoRestriccion();

                res.CargarDatos((int)row.Cells["id_restriccion"].Value);
                res.BorrarDatos();
            }
            CargarRestricciones();
        }

        public void BorrarResponsables()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas borrar las personas seleccionadas?", "Borrar responsables", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;
            
            foreach (DataGridViewRow row in DgvResponsables.SelectedRows)
            {
                int idResponsable = Convert.ToInt32(row.Cells["id_responsable"].Value);
                RequerimientoResponsable resp = new RequerimientoResponsable();
                resp.CargarDatos(idResponsable);
                resp.BorrarDatos();
            }
            CargarResponsables();
        }

        public void BorrarNotas()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas borrar las notas seleccioandas?", "Borrar notas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach(DataGridViewRow row in DgvNotas.SelectedRows)
            {
                int idNota = Convert.ToInt32(row.Cells["id_nota"].Value);
                string usuario = row.Cells["usuario_nota"].Value.ToString();

                if( usuario != Global.UsuarioActual.NombreCompleto().ToString())
                {
                    MessageBox.Show("No eres el dueño de esta nota, no se puede borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                RequerimientoNota nota = new RequerimientoNota();
                nota.CargarDatos(idNota);
                nota.BorrarDatos();
            }
            CargarNotas();
            MostrarNota(0);
        }

        public void BorrarAdjunto()
        {
            DialogResult respuesta = MessageBox.Show("Seguro que deseas borrar los adjuntos seleccionados?", "Borrar adjuntos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if( respuesta != System.Windows.Forms.DialogResult.Yes )
                return;

            foreach(DataGridViewRow row in DgvAdjuntos.SelectedRows)
            {
                int idAdjunto = Convert.ToInt32(row.Cells["id_adjunto"].Value);
                
                RequerimientoAdjunto adj = new RequerimientoAdjunto();
                adj.CargarDatos(idAdjunto);
                adj.BorrarDatos();

                ArchivoRequerimiento archivo = new ArchivoRequerimiento();
                archivo.SeleccionarAdjunto(idAdjunto);
                archivo.BorrarDatos();
            }
            CargarAdjuntos();
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(Tabs.SelectedIndex)
            {
                case 0:
                    BorrarParemetros();
                break;

                case 1:
                    BorrarRestricciones();
                break;

                case 2:
                    BorrarResponsables();
                break;

                case 3:
                    BorrarNotas();
                break;

                case 4:
                    BorrarAdjunto();
                break;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    EditarParametro();
                    break;

                case 3:
                    string usuarioNota = DgvNotas.SelectedRows[0].Cells["usuario_nota"].Value.ToString();

                    if (usuarioNota != Global.UsuarioActual.NombreCompleto())
                    {
                        MessageBox.Show("No eres el dueño de esta nota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TxtNota.ReadOnly = false;
                    LblNotaSeleccionada.Text = LblNotaSeleccionada.Text.Replace("(SOLO LECTURA)", "(EDITANDO)");
                    break;
            }
        }

        private void DgvParametros_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void DgvKeyitems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //borrarToolStripMenuItem.Enabled = DgvKeyitems.SelectedRows.Count > 0 && 
            //                                  RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE" &&
            //                                  Global.VerificarPrivilegio("PROYECTO", "EDITAR REQUERIMIENTO");
        }

        private void cumpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarComentario com = new FrmIngresarComentario();

            if( com.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                if(RequerimientoCargado.TieneFilas())
                {
                    RevisarRequerimiento("CUMPLE", com.Comentarios);
                    CargarRequerimiento();
                }
            }
        }

        public void RevisarRequerimiento(string estatus, string comentarios)
        {
            if (RequerimientoCargado.TieneFilas())
            {
                RequerimientoCargado.Fila().ModificarCelda("estatus_revision", estatus);
                RequerimientoCargado.Fila().ModificarCelda("comentarios_revision", comentarios);
                RequerimientoCargado.Fila().ModificarCelda("usuario_revision", Global.UsuarioActual.NombreCompleto());
                RequerimientoCargado.Fila().ModificarCelda("fecha_revision", DateTime.Now);
                RequerimientoCargado.GuardarDatos();
                CargarRequerimiento();
            }
        }

        private void noCumpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarComentario com = new FrmIngresarComentario();

            if (com.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (RequerimientoCargado.TieneFilas())
                {
                    RevisarRequerimiento("NO CUMPLE", com.Comentarios);
                    CargarRequerimiento();
                }
            }
        }

        private void noAplicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresarComentario com = new FrmIngresarComentario();

            if (com.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (RequerimientoCargado.TieneFilas())
                {
                    RevisarRequerimiento("NO APLICA", com.Comentarios);
                    CargarRequerimiento();
                }
            }
        }

        private void DgvRestricciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarToolStripMenuItem.Enabled = DgvRestricciones.SelectedRows.Count > 0 &&
                                              RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE" &&
                                              Global.VerificarPrivilegio("PROYECTO", "EDITAR REQUERIMIENTO");
        }

        private void DgvResponsables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarToolStripMenuItem.Enabled = DgvResponsables.SelectedRows.Count > 0 &&
                                              RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE" && 
                                              Global.VerificarPrivilegio("PROYECTOS", "EDITAR REQUERIMIENTO");
        }

        private void DgvNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvNotas.SelectedRows.Count <= 0)
                return;

            int idNota = Convert.ToInt32(DgvNotas.SelectedRows[0].Cells["id_nota"].Value);
            MostrarNota(idNota);

            editarToolStripMenuItem.Enabled = DgvNotas.SelectedRows.Count > 0 &&
                                              RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE";

            borrarToolStripMenuItem.Enabled = DgvNotas.SelectedRows.Count > 0 &&
                                              RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE";

        }

        public void MostrarNota(int idNota)
        {
            if(idNota==0)
            {
                TxtNota.Text = "";
                LblNotaSeleccionada.Text = "SELECCIONA UNA NOTA";
                return;
            }

            RequerimientoNota nota = new RequerimientoNota();
            nota.CargarDatos(idNota);

            if(nota.TieneFilas())
            {
                LblNotaSeleccionada.Text = nota.Fila().Celda("usuario_creacion").ToString() + " / " +
                                           Convert.ToDateTime(nota.Fila().Celda("fecha_creacion")).ToString("MMM dd yyyy hh:mm:ss tt") +
                                           " (SOLO LECTURA)";
                TxtNota.Text = nota.Fila().Celda("nota").ToString();
                TxtNota.ReadOnly = true;
            }
        }

        private void DgvAdjuntos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            borrarToolStripMenuItem.Enabled = DgvAdjuntos.SelectedRows.Count > 0 &&
                                              RequerimientoCargado.Fila().Celda("estatus_revision").ToString() != "CUMPLE" &&
                                              Global.VerificarPrivilegio("PROYECTOS", "EDITAR REQUERIMIENTO");
        }

        private void DgvParametros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void DgvAdjuntos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarAdjunto();
        }

        public void MostrarAdjunto()
        {
            int idAdjunto = Convert.ToInt32(DgvAdjuntos.SelectedRows[0].Cells["id_adjunto"].Value);
            string tipo = DgvAdjuntos.SelectedRows[0].Cells["tipo_adjunto"].Value.ToString();

            RequerimientoAdjunto adjunto = new RequerimientoAdjunto();
            adjunto.CargarDatos(idAdjunto);

            ArchivoRequerimiento ar = new ArchivoRequerimiento();
            ar.SeleccionarAdjunto(idAdjunto);

            if (!ar.TieneFilas())
            {
                MessageBox.Show("El archivo adjunto no fue encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] bytesArchivo = (byte[])ar.Fila().Celda("archivo");

            switch (tipo)
            {
                case ".pdf":
                case ".PDF":
                    FrmVisorPDF visor = new FrmVisorPDF(bytesArchivo, adjunto.Fila().Celda("nombre_archivo").ToString());
                    visor.ShowDialog();
                break;

                default:
                    GuardarAdjunto.DefaultExt = tipo.Replace(".", "");
                    GuardarAdjunto.FileName = adjunto.Fila().Celda("nombre_archivo").ToString();
                    
                    if( GuardarAdjunto.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                    {
                        File.WriteAllBytes(GuardarAdjunto.FileName, bytesArchivo);
                    }
                break;
            }
        }

        private void TxtNota_MouseLeave(object sender, EventArgs e)
        {
            if (DgvNotas.SelectedRows.Count <= 0 || TxtNota.ReadOnly)
                return;

            RequerimientoNota nota = new RequerimientoNota();
            int idNota = 0;
            idNota = Convert.ToInt32(DgvNotas.SelectedRows[0].Cells["id_nota"].Value);
            nota.CargarDatos(idNota);

            if (idNota != 0 && nota.TieneFilas())
                if (!String.IsNullOrWhiteSpace(TxtNota.Text))
                {
                    nota.Fila().ModificarCelda("nota", TxtNota.Text);
                    nota.GuardarDatos();
                }
        }
    }
}
