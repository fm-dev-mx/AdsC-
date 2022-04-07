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
using FluentFTP;
using System.Net;
using System.Threading;
using SolidWorks.Interop.swconst;
using System.Diagnostics;
using System.Management;

namespace CB
{
    public partial class FrmDetallesModulo : Ventana
    {
        decimal IdProyecto = 0;
        int Modulo = 0;
        int Subensamble = 0;
        int IdModoFalla = 0;
        int IdCausa = 0;
        int IdEfecto = 0;
        int IdControl = 0;

        string Vista = string.Empty;
        string RaizFtp = string.Empty;
        string NombreImagen = string.Empty;
        string UsuarioBloqueoMecanico = string.Empty;
        string FechaBloqueoMecanico = string.Empty;
        string UsuarioAprobacion = string.Empty;
        string FechaAprobacion = string.Empty;
        string RutaParcial = string.Empty;
        string StrRevision = string.Empty;

        bool DisenoLiberado = false;
        string FechaLiberacion = string.Empty;
        string UsuarioLiberacion = string.Empty;
        bool FtpConectado = false;
        bool BloqueoMecanico = false;
        bool SoloLectura = false;
        bool Aprobado = false;

        Modulo ModuloCargado = new Modulo();
        FtpClient ClienteFtp = new FtpClient();
        SolidWorksAPI SW = null;
        List<string> RutasParcialesArchivos = new List<string>();
        List<string> RutasParcialesArchivosPendientes = new List<string>();
        Dictionary<string, string> CustomPropertiesParte;
        List<ManagementObject> ProcesosSolidWorks = new List<ManagementObject>();

        byte[] VistaPreviaParte = null;

        FrmBajarDiseno VentanaBajarDiseno = null;

        public FrmDetallesModulo(int idModulo)
        {
            InitializeComponent();
            ModuloCargado.CargarDatos(idModulo);
            Modulo = idModulo;

            if (!ModuloCargado.TieneFilas())
            {
                MessageBox.Show("El modulo no fue encontrado");
                Close();
            }
            else
            {
                string strProyecto = Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto")).ToString("F2").PadLeft(6, '0').Replace(".", "_");
                RaizFtp = strProyecto + "/M" + strProyecto;
                IdProyecto = Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto"));
                Subensamble = Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble"));
            }
        }

        public void CargarDetalles()
        {
            Proyecto prj = new Proyecto();
            prj.CargarDatos(IdProyecto);

            LblProyecto.Text = Convert.ToDecimal(prj.Fila().Celda("id")).ToString("F2") + " - " + prj.Fila().Celda("nombre").ToString();
            LblNombre.Text = ModuloCargado.Fila().Celda("subensamble").ToString().PadLeft(2, '0') + " - " + ModuloCargado.Fila().Celda("nombre").ToString();
            LblDescripcion.Text = ModuloCargado.Fila().Celda("descripcion").ToString();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (BkgCrearArchivosCache.IsBusy)
            {
                BkgCrearArchivosCache.CancelAsync();
                BkgCrearArchivosCache.Dispose();
            }
            if(BkgMostrarPlano.IsBusy)
            {
                BkgMostrarPlano.CancelAsync();
                BkgMostrarPlano.Dispose();
            }

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (BtnOpciones.ContextMenuStrip != null)
                BtnOpciones.ContextMenuStrip.Show(BtnOpciones, BtnOpciones.PointToClient(Cursor.Position));
        }

        public void CargarElementos()
        {
            int idModulo = (int)ModuloCargado.Fila().Celda("id");

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", idModulo);

            LlenarDataGridView(Elemento.Modelo().SeleccionarDatos("modulo=@modulo", parametros), DgvElementos);
        }

        public void NuevoElemento()
        {
            FrmNuevoElemento ne = new FrmNuevoElemento((int)ModuloCargado.Fila().Celda("id"));

            if (ne.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarElementos();
            }
        }

        public void EditarElemento()
        {
            if (DgvElementos.SelectedRows.Count <= 0)
                return;

            int idElemento = (int)DgvElementos.SelectedRows[0].Cells["id"].Value;

            FrmNuevoElemento ne = new FrmNuevoElemento((int)ModuloCargado.Fila().Celda("id"), idElemento);

            if (ne.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarElementos();
            }
        }

        public void BorrarElementos()
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres borrar los elementos seleccionados?", "Borrar elementos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in DgvElementos.SelectedRows)
            {
                int idElemento = (int)row.Cells["id"].Value;

                Elemento el = new Elemento();
                el.CargarDatos(idElemento);
                el.BorrarDatos();
            }
            CargarElementos();
        }

        public void CargarPasos()
        {
            int fila = Global.GuardarFilaSeleccionada(DgvSecuencia);
            DgvSecuencia.Rows.Clear();
            ModuloPaso.Modelo().SeleccionarModulo(Convert.ToInt32(ModuloCargado.Fila().Celda("id"))).ForEach(delegate(Fila f)
            {
                DgvSecuencia.Rows.Add(f.Celda("id"), f.Celda("paso"), f.Celda("elemento_nombre"), f.Celda("accion"));
            });
            Global.RecuperarFilaSeleccionada(DgvSecuencia, fila);
        }

        public void NuevoPaso()
        {
            FrmNuevoPasoModulo np = new FrmNuevoPasoModulo(Convert.ToInt32(ModuloCargado.Fila().Celda("id")));

            if (np.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarPasos();
            }
        }

        public void BorrarPasos()
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres borrar el paso seleccionado?", "Borrar paso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach (DataGridViewRow row in DgvSecuencia.SelectedRows)
            {
                int idPaso = Convert.ToInt32(row.Cells["id_paso"].Value);
                ModuloPaso paso = new ModuloPaso();
                paso.CargarDatos(idPaso);
                paso.BorrarDatos();
            }
            CargarPasos();
        }

        public void CargarModoFalla()
        {
            int guardarFila = Global.GuardarFilaSeleccionada(DgvModoFalla);
            DgvModoFalla.Rows.Clear();

            ModoFalla.Modelo().SeleccionarModulo(Modulo).ForEach(delegate(Fila f)
            {
                DgvModoFalla.Rows.Add(f.Celda("id"), f.Celda("nombre"));
            });

            editarToolStripMenuItem.Enabled = false;
            borrarToolStripMenuItem.Enabled = false;
            NuevaCausatoolStripMenu.Enabled = false;
            EditarCausatoolStripMenuI.Enabled = false;
            BorrarCausatoolStripMenu.Enabled = false;
        }

        public void NuevoModoFalla()
        {
            FrmInformacionModoFalla nuevoModoFalla = new FrmInformacionModoFalla("MODO DE FALLA");
            if (nuevoModoFalla.ShowDialog() == DialogResult.Yes)
            {
                Fila datos = new Fila();
                datos.AgregarCelda("nombre", nuevoModoFalla.Nombre);
                datos.AgregarCelda("descripcion", nuevoModoFalla.Descripcion);
                datos.AgregarCelda("modulo", Modulo);
                ModoFalla.Modelo().Insertar(datos);
                DgvModoFalla.ReadOnly = true;
                DgvModoFalla.AllowUserToAddRows = false;
                CargarModoFalla();
            }
        }

        public void EditarModoFalla(int idModofalla)
        {
            ModoFalla editar = new ModoFalla();
            editar.CargarDatos(idModofalla);
            string descripcion = editar.Fila().Celda("descripcion").ToString();
            string nombre = editar.Fila().Celda("nombre").ToString();

            FrmInformacionModoFalla editarModoFalla = new FrmInformacionModoFalla("MODO DE FALLA", nombre, descripcion);
            if (editarModoFalla.ShowDialog() == DialogResult.Yes)
            {

                editar.Fila().ModificarCelda("nombre", editarModoFalla.Nombre);
                editar.Fila().ModificarCelda("descripcion", editarModoFalla.Descripcion);
                editar.GuardarDatos();
                CargarModoFalla();
                TxtDescripcionModoFalla.Text = editarModoFalla.Descripcion;
            }
        }

        public void BorrarModoFalla(int idModoFalla)
        {
            ModoFalla eliminar = new ModoFalla();
            eliminar.CargarDatos(idModoFalla);
            eliminar.BorrarDatos();
            CargarModoFalla();
            DgvCausas.Rows.Clear();
            DgvEfectos.Rows.Clear();
            DgvControles.Rows.Clear();
            TxtDescripcionModoFalla.Text = "";
        }

        public void CargarCausaFalla(int idModoFalla)
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvCausas);
            DgvCausas.Rows.Clear();
            FallaCausa.Modelo().SeleccionarModoFalla(idModoFalla).ForEach(delegate(Fila f)
            {
                DgvCausas.Rows.Add(f.Celda("id"), f.Celda("descripcion"));
            });
            EditarCausatoolStripMenuI.Enabled = false;
            BorrarCausatoolStripMenu.Enabled = false;
            DgvCausas.ReadOnly = true;
            DgvCausas.AllowUserToAddRows = false;
            ConfiguracionDataGridView.Recuperar(cfg, DgvCausas);
        }

        public void EditarCausas(int idCausa)
        {
            FallaCausa falla = new FallaCausa();
            falla.CargarDatos(idCausa);

            string descripcion = falla.Fila().Celda("descripcion").ToString();
            FrmElementoModoFalla causa = new FrmElementoModoFalla("CAUSA", descripcion);
            if (causa.ShowDialog() == DialogResult.Yes)
            {
                falla.Fila().ModificarCelda("descripcion", causa.Descripcion);
                falla.GuardarDatos();
                DgvCausas.ReadOnly = true;
                DgvCausas.AllowUserToAddRows = false;
                CargarCausaFalla(IdModoFalla);
            }
        }

        public void NuevaCausa(int idModoFalla)
        {
            FrmElementoModoFalla nuevaCausa = new FrmElementoModoFalla("CAUSA");
            if (nuevaCausa.ShowDialog() == DialogResult.Yes)
            {
                Fila datos = new Fila();
                datos.AgregarCelda("modo_falla", idModoFalla);
                datos.AgregarCelda("descripcion", nuevaCausa.Descripcion);
                FallaCausa.Modelo().Insertar(datos);
                DgvCausas.ReadOnly = true;
                DgvCausas.AllowUserToAddRows = false;
                CargarCausaFalla(IdModoFalla);
            }
        }

        public void BorrarCausa(int idCausa)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres borrar el elementos seleccionado?", "Borrar causa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                FallaCausa falla = new FallaCausa();
                falla.CargarDatos(idCausa);
                falla.BorrarDatos();
                CargarCausaFalla(IdModoFalla);
            }
        }

        public void CargarEfectoFalla(int idModoFalla)
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvEfectos);
            DgvEfectos.Rows.Clear();
            FallaEfecto.Modelo().SeleccionarModoFalla(idModoFalla).ForEach(delegate(Fila f)
            {
                DgvEfectos.Rows.Add(f.Celda("id"), f.Celda("descripcion"));
            });
            EditarCausatoolStripMenuI.Enabled = false;
            BorrarCausatoolStripMenu.Enabled = false;
            DgvEfectos.ReadOnly = true;
            DgvEfectos.AllowUserToAddRows = false;
            ConfiguracionDataGridView.Recuperar(cfg, DgvEfectos);
        }

        public void EditarEfectos(int idEfecto)
        {
            FallaEfecto efecto = new FallaEfecto();
            efecto.CargarDatos(idEfecto);
            string descripcion = efecto.Fila().Celda("descripcion").ToString();

            FrmElementoModoFalla editarEfecto = new FrmElementoModoFalla("EFECTO", descripcion);
            if (editarEfecto.ShowDialog() == DialogResult.Yes)
            {
                efecto.Fila().ModificarCelda("descripcion", editarEfecto.Descripcion);
                efecto.GuardarDatos();
                DgvEfectos.ReadOnly = true;
                DgvEfectos.AllowUserToAddRows = false;
                CargarEfectoFalla(IdModoFalla);
            }

        }

        public void NuevoEfecto(int idModoFalla)
        {
            FrmElementoModoFalla nuevoEfecto = new FrmElementoModoFalla("EFECTO");
            if (nuevoEfecto.ShowDialog() == DialogResult.Yes)
            {
                Fila datos = new Fila();
                datos.AgregarCelda("modo_falla", idModoFalla);
                datos.AgregarCelda("descripcion", nuevoEfecto.Descripcion);
                FallaEfecto.Modelo().Insertar(datos);
                DgvEfectos.ReadOnly = true;
                DgvEfectos.AllowUserToAddRows = false;
                CargarEfectoFalla(IdModoFalla);
            }
        }

        public void BorrarEfecto(int idEfecto)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres borrar el elementos seleccionado?", "Borrar Efecto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                FallaEfecto efecto = new FallaEfecto();
                efecto.CargarDatos(idEfecto);
                efecto.BorrarDatos();
                CargarEfectoFalla(IdModoFalla);
            }
        }

        public void CargarFallaControles(int idModoFalla)
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvControles);
            DgvControles.Rows.Clear();
            FallaControles.Modelo().SeleccionarModoFalla(idModoFalla).ForEach(delegate(Fila f)
            {
                DgvControles.Rows.Add(f.Celda("id"), f.Celda("descripcion"));
            });
            EditarCausatoolStripMenuI.Enabled = false;
            BorrarCausatoolStripMenu.Enabled = false;
            DgvControles.ReadOnly = true;
            DgvControles.AllowUserToAddRows = false;
            ConfiguracionDataGridView.Recuperar(cfg, DgvControles);
        }

        public void NuevoControl(int idModoFalla)
        {
            FrmElementoModoFalla nuevoControl = new FrmElementoModoFalla("CONTROL");
            if (nuevoControl.ShowDialog() == DialogResult.Yes)
            {
                Fila datos = new Fila();
                datos.AgregarCelda("modo_falla", idModoFalla);
                datos.AgregarCelda("descripcion", nuevoControl.Descripcion);
                FallaControles.Modelo().Insertar(datos);
                DgvControles.ReadOnly = true;
                DgvControles.AllowUserToAddRows = false;
                CargarFallaControles(IdModoFalla);
            }
        }

        public void EditarControles(int idCausa)
        {

            FallaControles controles = new FallaControles();
            controles.CargarDatos(idCausa);
            string descripcion = controles.Fila().Celda("descripcion").ToString();

            FrmElementoModoFalla editarControl = new FrmElementoModoFalla("CONTROL", descripcion);
            if (editarControl.ShowDialog() == DialogResult.Yes)
            {
                controles.Fila().ModificarCelda("descripcion", editarControl.Descripcion);
                controles.GuardarDatos();
                DgvControles.ReadOnly = true;
                DgvControles.AllowUserToAddRows = false;
                CargarFallaControles(IdModoFalla);
            }
        }

        public void BorrarControles(int idCausa)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres borrar el elementos seleccionado?", "Borrar control", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == System.Windows.Forms.DialogResult.Yes)
            {
                FallaControles control = new FallaControles();
                control.CargarDatos(idCausa);
                control.BorrarDatos();
                CargarFallaControles(IdModoFalla);
            }
        }

        private void CargarRequerimientos()
        {
            vincularToolStripMenuItem.Enabled = HabilitarVincularToolOption();
            desvincularToolStripMenuItem.Enabled = HabilitarDesvincularToolOption();

            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvRequerimientos);
            DgvRequerimientos.Rows.Clear();

            Dictionary<string, object> parametrosModulo = new Dictionary<string, object>();
            parametrosModulo.Add("@proyecto", Convert.ToDecimal(IdProyecto));
            parametrosModulo.Add("@modulo", Modulo);

            Requerimiento requerimiento = new Requerimiento();
            requerimiento.SeleccionarDatos("proyecto=@proyecto AND modulo=@modulo", parametrosModulo).ForEach(delegate(Fila f)
            {
                DgvRequerimientos.Rows.Add(f.Celda("id").ToString(), f.Celda("nombre").ToString(), f.Celda("descripcion").ToString(), f.Celda("origen").ToString(), f.Celda("estatus").ToString(), f.Celda("nivel_revision").ToString(), f.Celda("estatus_revision").ToString());
            });

            ConfiguracionDataGridView.Recuperar(cfg, DgvRequerimientos);

        }

        private void FrmDetallesModulo_Load(object sender, EventArgs e)
        {
            CargarDetalles();
            CargarElementos();

            Modulo modulo = new Modulo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", Modulo);

            modulo.SeleccionarDatos("id=@modulo", parametros);
            if (modulo.TieneFilas())
            {
                IdProyecto = Convert.ToDecimal(modulo.Fila().Celda("proyecto").ToString());
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SW != null)
                SW.Terminar();

            BtnOpciones.Enabled = true;

            switch (Tabs.SelectedIndex)
            {
                case 0:
                    CargarElementos();
                    break;

                case 1:
                    CargarPasos();
                    break;
                case 2:
                    CargarModoFalla();
                    DgvModoFalla.ClearSelection();
                    DgvCausas.Rows.Clear();
                    DgvEfectos.Rows.Clear();
                    DgvControles.Rows.Clear();
                    break;

                case 3:
                    BtnOpciones.Enabled = false;
                    CargarRequerimientos();
                    break;

                case 4:                    
                    SplitEstatusDiseno.Panel1Collapsed = true;
                    BtnOpciones.Enabled = false;
                    ProgresoDiseno.Visible = true;
                    TxtEstatusDiseno.Text = "";
                    BkgInicializarDiseno.RunWorkerAsync();
                    break;
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    NuevoElemento();
                    break;

                case 1:
                    NuevoPaso();
                    break;
                case 2:
                    NuevoModoFalla();
                    break;
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    EditarElemento();
                    break;
                case 2:
                    EditarModoFalla(IdModoFalla);
                    break;
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (Tabs.SelectedIndex)
            {
                case 0:
                    BorrarElementos();
                    break;

                case 1:
                    BorrarPasos();
                    break;
                case 2:
                    BorrarModoFalla(IdModoFalla);
                    break;
            }
        }

        public void ReordenarPasos()
        {
            foreach (DataGridViewRow row in DgvSecuencia.Rows)
            {
                int idPaso = Convert.ToInt32(row.Cells["id_paso"].Value);
                ModuloPaso paso = new ModuloPaso();
                paso.CargarDatos(idPaso);
                paso.Fila().ModificarCelda("paso", row.Index + 1);
                paso.GuardarDatos();
            }
        }

        private void DgvSecuencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift))
            {
                if (e.KeyCode == Keys.Down)
                {
                    Global.MoverFilaAbajo(DgvSecuencia);
                    ReordenarPasos();
                    //CargarPasos();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    Global.MoverFilaArriba(DgvSecuencia);
                    ReordenarPasos();
                    //CargarPasos();
                }
            }
        }

        private void DgvModoFalla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvModoFalla.SelectedRows.Count <= 0)
                return;


            editarToolStripMenuItem.Enabled = true;
            NuevaCausatoolStripMenu.Enabled = true;
            borrarToolStripMenuItem.Enabled = true;

            IdModoFalla = Convert.ToInt32(DgvModoFalla.SelectedRows[0].Cells["id_modo_falla"].Value);
            if (IdModoFalla != 0)
            {
                ModoFalla falla = new ModoFalla();
                falla.CargarDatos(IdModoFalla);
                TxtDescripcionModoFalla.Text = falla.Fila().Celda("descripcion").ToString();
            }

            switch (TabsFMEA.SelectedIndex)
            {
                case 0:
                    CargarCausaFalla(IdModoFalla);
                    DgvCausas.ClearSelection();
                    break;

                case 1:
                    CargarEfectoFalla(IdModoFalla);
                    DgvEfectos.ClearSelection();
                    break;

                case 2:
                    CargarFallaControles(IdModoFalla);
                    DgvControles.ClearSelection();
                    break;
            }
        }

        private void DgvCausas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MenuCausaEfecto.Show(Cursor.Position);
        }

        private void NuevaCausatoolStripMenu_Click(object sender, EventArgs e)
        {
            switch (TabsFMEA.SelectedIndex)
            {
                case 0:
                    NuevaCausa(IdModoFalla);
                    break;
                case 1:
                    NuevoEfecto(IdModoFalla);
                    break;
                case 2:
                    NuevoControl(IdModoFalla);
                    break;
            }
        }

        private void EditarCausatoolStripMenuI_Click(object sender, EventArgs e)
        {
            switch (TabsFMEA.SelectedIndex)
            {
                case 0:
                    EditarCausas(IdCausa);
                    break;

                case 1:
                    EditarEfectos(IdEfecto);
                    break;
                case 2:
                    EditarControles(IdControl);
                    break;
            }
        }

        private void DgvCausas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvCausas.SelectedRows.Count <= 0)
                return;

            IdCausa = Convert.ToInt32(DgvCausas.SelectedRows[0].Cells["id_tabla_causa"].Value);
            EditarCausatoolStripMenuI.Enabled = true;
            BorrarCausatoolStripMenu.Enabled = true;
        }

        private void BorrarCausatoolStripMenu_Click(object sender, EventArgs e)
        {
            switch (TabsFMEA.SelectedIndex)
            {
                case 0:
                    if (DgvCausas.SelectedRows.Count <= 0)
                        break;
                    int idCausa = Convert.ToInt32(DgvCausas.SelectedRows[0].Cells["id_tabla_causa"].Value);
                    if (idCausa != 0)
                        BorrarCausa(idCausa);
                    break;

                case 1:
                    if (DgvEfectos.SelectedRows.Count <= 0)
                        break;
                    int idEfecto = Convert.ToInt32(DgvEfectos.SelectedRows[0].Cells["id_tabla_efecto"].Value);
                    if (idEfecto != 0)
                        BorrarEfecto(idEfecto);
                    break;
                case 2:
                    if (DgvControles.SelectedRows.Count <= 0)
                        break;
                    int idControl = Convert.ToInt32(DgvControles.SelectedRows[0].Cells["id_tabla_control"].Value);
                    if (idControl != 0)
                        BorrarControles(idControl);
                    break;
            }
        }

        private void DgvEfectos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvEfectos.SelectedRows.Count <= 0)
                return;

            IdEfecto = Convert.ToInt32(DgvEfectos.SelectedRows[0].Cells["id_tabla_efecto"].Value);
            EditarCausatoolStripMenuI.Enabled = true;
            BorrarCausatoolStripMenu.Enabled = true;
        }

        private void DgvEfectos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MenuCausaEfecto.Show(Cursor.Position);
        }

        private void DgvControles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvControles.SelectedRows.Count <= 0)
                return;

            IdControl = Convert.ToInt32(DgvControles.SelectedRows[0].Cells["id_tabla_control"].Value);
            EditarCausatoolStripMenuI.Enabled = true;
            BorrarCausatoolStripMenu.Enabled = true;
        }

        private void DgvControles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MenuCausaEfecto.Show(Cursor.Position);
        }

        private void TabsFMEA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DgvModoFalla.SelectedRows.Count <= 0)
                return;

            switch (TabsFMEA.SelectedIndex)
            {
                case 0:
                    CargarCausaFalla(IdModoFalla);
                    DgvCausas.ClearSelection();
                    break;
                case 1:
                    CargarEfectoFalla(IdModoFalla);
                    DgvEfectos.ClearSelection();
                    break;
                case 2:
                    CargarFallaControles(IdModoFalla);
                    DgvControles.ClearSelection();
                    break;
            }
        }


        private void DgvRequerimientos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int mouseX = Cursor.Position.X;
                int mouseY = Cursor.Position.Y;
                //vincularToolStripMenuItem.Enabled = HabilitarVincularToolOption();
                //desvincularToolStripMenuItem.Enabled = HabilitarDesvincularToolOption();
                MenuRequerimiento.Show(mouseX, mouseY);
            }
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Modulo modulo = new Modulo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", Modulo);

            modulo.SeleccionarDatos("id=@modulo", parametros);
            if (modulo.TieneFilas())
            {
                FrmNuevoRequerimiento nuevoRequerimiento = new FrmNuevoRequerimiento(Convert.ToDecimal(modulo.Fila().Celda("proyecto").ToString()), 0, false, Modulo);
                nuevoRequerimiento.ShowDialog();
            }
            CargarRequerimientos();
        }

        private void vincularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Requerimiento requerimiento = new Requerimiento();
            FrmSeleccionarRequerimiento req = new FrmSeleccionarRequerimiento(Modulo);
            if (req.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                List<int> idRequerimientos = new List<int>();
                idRequerimientos = req.RequerimientosId;

                foreach (int item in idRequerimientos)
                {
                    int id = item;
                    requerimiento.CargarDatos(id);
                    if (requerimiento.TieneFilas())
                    {
                        requerimiento.Fila().ModificarCelda("modulo", Modulo);
                        requerimiento.GuardarDatos();
                    }
                }
                MessageBox.Show("Se ha guardado su selección en la base de datos", "Información guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRequerimientos();
            }
        }

        private bool HabilitarVincularToolOption()
        {
            Dictionary<string, object> parametrosModulo = new Dictionary<string, object>();
            parametrosModulo.Add("@proyecto", IdProyecto);

            Requerimiento requerimiento = new Requerimiento();
            requerimiento.SeleccionarDatos("proyecto=@proyecto AND modulo=0", parametrosModulo);
            if (requerimiento.TieneFilas())
                return true;
            else
                return false;
        }

        private bool HabilitarDesvincularToolOption()
        {
            Dictionary<string, object> parametrosModulo = new Dictionary<string, object>();
            parametrosModulo.Add("@proyecto", IdProyecto);
            parametrosModulo.Add("@modulo", Modulo);
            Requerimiento requerimiento = new Requerimiento();
            requerimiento.SeleccionarDatos("proyecto=@proyecto AND modulo=@modulo", parametrosModulo);
            if (requerimiento.TieneFilas())
                return true;
            else
                return false;

        }

        private void desvincularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Requerimiento requerimiento = new Requerimiento();
            FrmSeleccionarRequerimiento req = new FrmSeleccionarRequerimiento(Modulo, true);
            if (req.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                List<int> idRequerimientos = new List<int>();
                idRequerimientos = req.RequerimientosId;

                foreach (int item in idRequerimientos)
                {
                    int id = item;
                    requerimiento.CargarDatos(id);
                    if (requerimiento.TieneFilas())
                    {
                        requerimiento.Fila().ModificarCelda("modulo", 0);
                        requerimiento.GuardarDatos();
                    }
                }
                MessageBox.Show("Se ha desvinculado los requerimientos seleccionados", "Información guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRequerimientos();
            }
        }

        private void DgvRequerimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmDetallesRequerimiento detalles = new FrmDetallesRequerimiento(Convert.ToInt32(DgvRequerimientos.SelectedRows[0].Cells[0].Value));
            detalles.ShowDialog();
        }

        private void BkgDescargarDiseno_DoWork(object sender, DoWorkEventArgs e)
        {
            int subensamble = Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble"));

            List<Fila> archivosDiseno = SolidWorksProyecto.Modelo().SeleccionarProyectoSubensamble(IdProyecto, subensamble);
            int i = 0;
            archivosDiseno.ForEach(delegate(Fila f)
            {
                i++;
                BkgDescargarDiseno.ReportProgress(Global.CalcularPorcentaje(i, archivosDiseno.Count()), f);
            });
        }

        private void BkgDescargarDiseno_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDiseno.Value = e.ProgressPercentage;
            Fila f = (Fila)e.UserState;
            AgregarElementoArbolDiseno(f);

        }

        public void AgregarElementoArbolDiseno(Fila archivoActual)
        {
            RutaParcial = archivoActual.Celda("nombre_archivo").ToString();
            string estatusRevision = archivoActual.Celda("estatus_revision").ToString();
            string estatusAprobacion = archivoActual.Celda("estatus_aprobacion").ToString();
            string estatusSincronizacion = archivoActual.Celda("estatus_sincronizacion").ToString();
            List<string> elementos = RutaParcial.Split('\\').ToList();

            if (elementos.Count == 0)
                return;

            elementos.Remove("");
            RutasParcialesArchivos.Add(RutaParcial);

            if (RutaParcial.ToUpper().EndsWith(".SLDDRW") && estatusRevision == "PENDIENTE")
            {
                RutasParcialesArchivosPendientes.Add(RutaParcial);
                RutasParcialesArchivosPendientes = RutasParcialesArchivosPendientes.Distinct().ToList();
            }

            string idSiguienteNodo = String.Empty;
            TreeNode UltimoNodo = null;
            TreeNode[] Nodos = null;

            elementos.ForEach(delegate(string siguienteNodo)
            {
                idSiguienteNodo = siguienteNodo;
                Nodos = TvDiseno.Nodes.Find(idSiguienteNodo, true);
                string extension = Path.GetExtension(siguienteNodo).ToLower();

                if (Nodos.Length == 0)
                {

                    if (UltimoNodo == null)
                        UltimoNodo = TvDiseno.Nodes.Add(idSiguienteNodo, siguienteNodo);
                    else
                        UltimoNodo = UltimoNodo.Nodes.Add(idSiguienteNodo, siguienteNodo);

                    if (extension == string.Empty)
                    {
                        UltimoNodo.ImageIndex = 0;
                        UltimoNodo.SelectedImageIndex = 0;
                    }
                    else
                    {
                        ConfigurarIconoSolidWorks(UltimoNodo, extension, estatusRevision, estatusAprobacion, estatusSincronizacion);
                    }
                }
                else
                {
                    UltimoNodo = Nodos[0];
                    ConfigurarIconoSolidWorks(UltimoNodo, extension, estatusRevision, estatusAprobacion, estatusSincronizacion);
                }
            });            
        }

        public void CrearArchivosCache(string rutaParcialConExtension, bool reconstruirArchivosCache = false)
        {
            if (Path.GetExtension(rutaParcialConExtension).ToUpper() != ".SLDDRW" || SW == null || !ClienteFtp.IsConnected)
                return;

            string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(rutaParcialConExtension);
            string rutaParcialSinExtension = Path.ChangeExtension(rutaParcialConExtension, null);
            string pathDrawingCarpetaTemporal = Path.GetTempPath() + Path.GetFileName(rutaParcialConExtension);
            string pathParteCarpetaTemporal = Path.GetTempPath() + Path.GetFileName(rutaParcialSinExtension);
            byte[] planoImagen;
            byte[] vistaIsometrica;

            if (!ClienteFtp.FileExists(RaizFtp + rutaParcialConExtension))
                return;

            //verificar si existen los archivos caché.
            //verificar si los archivos caché fueron renombrados
            if (ClienteFtp.FileExists(RaizFtp + rutaParcialSinExtension + ".PNG") && ClienteFtp.FileExists(RaizFtp + rutaParcialSinExtension + ".PDF") && !reconstruirArchivosCache)
                return;          

            try
            {
                // descargamos el drawing (.SLDDRW)
                ClienteFtp.DownloadFile(pathDrawingCarpetaTemporal, RaizFtp + rutaParcialConExtension, true, FtpVerify.Retry);
            }
            catch
            {   //corrige error de acceso denegado
                File.SetAttributes(pathDrawingCarpetaTemporal, FileAttributes.Normal);
                File.Delete(pathDrawingCarpetaTemporal);
                ClienteFtp.DownloadFile(pathDrawingCarpetaTemporal, RaizFtp + rutaParcialConExtension, true, FtpVerify.Retry);
            }

            // descargamos la parte o el ensamble correspondiente al drawing (.SLDPRT / .SLDASM)
            if (ClienteFtp.FileExists(RaizFtp + rutaParcialSinExtension + ".SLDPRT"))
            {
                pathParteCarpetaTemporal += ".SLDPRT";
                ClienteFtp.DownloadFile(pathParteCarpetaTemporal, RaizFtp + rutaParcialSinExtension + ".SLDPRT", true, FtpVerify.Retry);
            }
            else if (ClienteFtp.FileExists(RaizFtp + rutaParcialSinExtension + ".SLDASM"))
            {
                pathParteCarpetaTemporal += ".SLDASM";
                ClienteFtp.DownloadFile(pathParteCarpetaTemporal, RaizFtp + rutaParcialSinExtension + ".SLDASM", true, FtpVerify.Retry);
            }
            else return;

            if (!File.Exists(pathDrawingCarpetaTemporal) || !File.Exists(pathParteCarpetaTemporal))
                return;

            //    - convertimos a pdf
            //    - convertimos a imagen
            //    - convertimos a imagen miniatura
            //    - convertimos a imagen isométrica
            // Luego enviamos los archivos a la carpeta ftp

            // convertir drawing de solidworks a pdf
            byte[] planoPDF;

            try
            {
                // generar PDF a partir del solido
                SW.DrawingAPDF(pathDrawingCarpetaTemporal, out planoPDF);
            }
            catch
            {
                BkgCrearArchivosCache.ReportProgress(100, "[ERROR AL GENERAR PDF]" + Environment.NewLine);
                return;
            }

            try
            {
                //generar vista isometrica a partir del solido
                SW.VistaPrevia(pathParteCarpetaTemporal, swDocumentTypes_e.swDocPART, out vistaIsometrica);
            }
            catch
            {
                BkgCrearArchivosCache.ReportProgress(100, "[ERROR AL GENERAR VISTA ISOMETRICA]" + Environment.NewLine);
                return;
            }
            try
            {
                // convertir pdf a imagen
                string pathPdfTemp = Path.GetTempFileName();
                File.WriteAllBytes(pathPdfTemp, planoPDF);

                planoImagen = FormatosPDF.MiniaturaPDF(pathPdfTemp, 0, 0, 150);

                // enviar archivos a carpeta ftp
                ClienteFtp.Upload(planoImagen, RaizFtp + rutaParcialSinExtension + ".PNG", FtpExists.Overwrite);
                ClienteFtp.Upload(planoPDF, RaizFtp + rutaParcialSinExtension + ".PDF", FtpExists.Overwrite);
                ClienteFtp.Upload(CrearMiniatura(planoImagen), RaizFtp + rutaParcialSinExtension + "_MIN.PNG", FtpExists.Overwrite);
                ClienteFtp.Upload(vistaIsometrica, RaizFtp + rutaParcialSinExtension + "_ISO.PNG", FtpExists.Overwrite);
            }
            catch
            {
                //Si se interrumpe la subida del archivo
            }
            if (File.Exists(pathDrawingCarpetaTemporal))
                File.Delete(pathDrawingCarpetaTemporal);

            if (File.Exists(pathParteCarpetaTemporal))
                File.Delete(pathParteCarpetaTemporal);
        }

        public byte[] CrearMiniatura(byte[] imagen, int width = 264, int height = 204)
        {
            using (var stream = new System.IO.MemoryStream(imagen))
            {
                var img = Image.FromStream(stream);
                var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                using (var thumbStream = new System.IO.MemoryStream())
                {
                    thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Png);
                    return thumbStream.GetBuffer();
                }
            }
        }

        public void ConfigurarIconoSolidWorks(TreeNode nodo, string extension, string estatusRevision, string estatusAprobacion, string estatusSincronizacion)
        {
            switch (extension)
            {
                case ".sldprt":
                    
                    if(estatusSincronizacion == "SINCRONIZADO")
                    {
                        nodo.ImageIndex = 1;
                        nodo.SelectedImageIndex = 1;
                    }
                    else if (estatusSincronizacion == "MODIFICADO")
                    {
                        nodo.ImageIndex = 8;
                        nodo.SelectedImageIndex = 8;
                    }
                    else if(estatusSincronizacion == "NUEVO")
                    {
                        nodo.ImageIndex = 9;
                        nodo.SelectedImageIndex = 9;
                    }
                    break;

                case ".sldasm":
                    nodo.ImageIndex = 2;
                    nodo.SelectedImageIndex = 2;
                    break;

                case ".slddrw":
                    if (estatusRevision == "PENDIENTE")
                    {
                        nodo.ImageIndex = 4;
                        nodo.SelectedImageIndex = 4;
                    }
                    else if (estatusRevision == "RECHAZADO")
                    {
                        nodo.ImageIndex = 5;
                        nodo.SelectedImageIndex = 5;
                    }
                    else if (estatusRevision == "ACEPTADO")
                    {
                        if (estatusAprobacion == "PENDIENTE")
                        {
                            nodo.ImageIndex = 6;
                            nodo.SelectedImageIndex = 6;
                        }
                        else if (estatusAprobacion == "APROBADO")
                        {
                            nodo.ImageIndex = 7;
                            nodo.SelectedImageIndex = 7;
                        }
                    }
                    else
                    {
                        nodo.ImageIndex = 3;
                        nodo.SelectedImageIndex = 3;
                    }
                    break;
            }
        }

        private void BkgDescargarDiseno_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string usuarioLiberacion = string.Empty;
            object objUsuarioLiberacion = ModuloCargado.Fila().Celda("usuario_liberacion");
            if(objUsuarioLiberacion != null)
                usuarioLiberacion = objUsuarioLiberacion.ToString();

            ProgresoDiseno.Visible = false;
            BloqueoMecanico = Convert.ToBoolean(ModuloCargado.Fila().Celda("bloqueo_mecanico"));
            UsuarioBloqueoMecanico = ModuloCargado.Fila().Celda("usuario_bloqueo_mecanico").ToString();
            FechaBloqueoMecanico = Global.FechaATexto(ModuloCargado.Fila().Celda("fecha_bloqueo_mecanico"));
            Aprobado = ModuloCargado.Fila().Celda("estatus_aprobacion").ToString() == "APROBADO";
            DisenoLiberado = ModuloCargado.Fila().Celda("estatus_liberacion").ToString() == "LIBERADO";
            UsuarioLiberacion = usuarioLiberacion;
            FechaLiberacion = Global.FechaATexto(ModuloCargado.Fila().Celda("fecha_liberacion"));
            StrRevision = "R" + ModuloCargado.Fila().Celda("revision").ToString().PadLeft(2, '0');

            UsuarioAprobacion = ModuloCargado.Fila().Celda("usuario_aprobacion").ToString();
            FechaAprobacion = Global.FechaATexto(ModuloCargado.Fila().Celda("fecha_aprobacion"));
            LblRevision.Text = StrRevision + " | " + UsuarioAprobacion + " | " + FechaAprobacion;
            LblRevision.Visible = true;
            LblRevision.Visible = Convert.ToInt32(ModuloCargado.Fila().Celda("cambio_diseno")) > 0;

            BtnActualizar.Enabled = true;
            BtnBajar.Enabled = Global.VerificarPrivilegio("DISEÑO", "BAJAR MODULO");


            if (BloqueoMecanico)
            {
                LblEstatusModulo.Text = "Diseño bloqueado por " + UsuarioBloqueoMecanico;
                LblEstatusModulo.Text += " @ " + FechaBloqueoMecanico;
                LblEstatusModulo.ForeColor = Color.Red;
                PicEstatusModulo.Image = CB_Base.Properties.Resources.locked_48;

                BtnAprobar.Enabled = false;
                BtnLiberar.Enabled = true;
                BtnSubir.Enabled = Global.UsuarioActual.NombreCompleto() == UsuarioBloqueoMecanico;
            }
            else if(!BloqueoMecanico && !DisenoLiberado)
            {
                LblEstatusModulo.Text = "Diseño sin validar por el cliente";
                LblEstatusModulo.ForeColor = Color.Black;
                PicEstatusModulo.Image = CB_Base.Properties.Resources.draft_48;

                BtnSubir.Enabled = Global.VerificarPrivilegio("DISEÑO", "SUBIR MODULO");
                BtnLiberar.Enabled = Global.VerificarPrivilegio("PROYECTOS", "LIBERAR MODULO");
                BtnAprobar.Enabled = false;
            }
            else if(!BloqueoMecanico && DisenoLiberado)
            {
                LblEstatusModulo.Text = "Diseño validado por el cliente";
                LblEstatusModulo.ForeColor = Color.Black;
                PicEstatusModulo.Image = CB_Base.Properties.Resources.draft_48;

                BtnSubir.Enabled = Global.VerificarPrivilegio("DISEÑO", "SUBIR MODULO");
                BtnLiberar.Enabled = Global.VerificarPrivilegio("PROYECTOS", "LIBERAR MODULO");
                BtnAprobar.Enabled = Global.VerificarPrivilegio("DISEÑO", "CONGELAR MODULO");

                if (Aprobado)
                {
                    LblEstatusModulo.Text = "Diseño congelado";
                    LblEstatusModulo.ForeColor = Color.Blue;
                    PicEstatusModulo.Image = CB_Base.Properties.Resources.ice_48;

                    ToolTip toolTipComentarios = new ToolTip();
                    toolTipComentarios.ToolTipIcon = ToolTipIcon.Info;
                    toolTipComentarios.IsBalloon = true;
                    toolTipComentarios.ShowAlways = true;
                    toolTipComentarios.SetToolTip(LblRevision, ModuloCargado.Fila().Celda("comentarios_revision").ToString());

                    BtnSubir.Enabled = false;
                    BtnAprobar.Enabled = false;
                }
            }
            LblEstatusModulo.Visible = true;
            SoloLectura = (BloqueoMecanico && (Global.UsuarioActual.NombreCompleto() != UsuarioBloqueoMecanico));
        }

        private void TvDiseno_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string extension = Path.GetExtension(e.Node.Name);

            if (e.Node.Parent == null)
                return;

            if (e.Button == MouseButtons.Right)
            {
                bool planoFabricable = false;

                TreeNode nodoPadre = e.Node.Parent;
                while(nodoPadre != null)
                {
                    planoFabricable = (nodoPadre.Text == "CP" || nodoPadre.Text.Contains("MP"));

                    if (planoFabricable)
                        break;
                    else
                        nodoPadre = nodoPadre.Parent;
                }

                if (extension.ToLower() == ".slddrw")
                {
                    revisarDrawingToolStripMenuItem.Enabled = !Aprobado && !BloqueoMecanico && planoFabricable;
                    drawingCorregidoToolStripMenuItem.Enabled = !Aprobado && !BloqueoMecanico && planoFabricable;
                    reconstruirToolStripMenuItem.Enabled = !Aprobado && !BloqueoMecanico && planoFabricable;
                    borrarArchivosCachéToolStripMenuItem.Enabled = !Aprobado && !BloqueoMecanico && planoFabricable;
                    MenuDrawing.Show(TvDiseno, e.Location);
                }
            }
        }

        private void BtnSubir_Click(object sender, EventArgs e)
        {
            if (VentanaBajarDiseno != null)
            {
                if (VentanaBajarDiseno.Visible)
                {
                    MessageBox.Show("Espera a terminar de bajar el diseño para continuar!", "Subir diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Proyecto prj = new Proyecto();
            prj.CargarDatos(IdProyecto);

            if (Convert.ToBoolean(prj.Fila().Celda("bloqueo_mecanico")))
            {
                string msg = "No es posible subir este modulo ya que todo el proyecto fue bloqueado por ";
                msg += prj.Fila().Celda("usuario_bloqueo_mecanico").ToString();
                msg += " @ " + Convert.ToDateTime(prj.Fila().Celda("fecha_bloqueo_mecanico")).ToString("MMM dd, yyyy hh:mm:ss tt");
                MessageBox.Show(msg, "Imposible subir modulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ModuloCargado.CargarDatos(Convert.ToInt32(ModuloCargado.Fila().Celda("id")));

            string carpetaProyecto = "M" + IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');
            string carpetaModulo = Subensamble.ToString().PadLeft(2, '0');

            if (BuscadorCarpetas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string carpetaSeleccionada = Path.GetFileName(BuscadorCarpetas.SelectedPath);
                string carpetaBase = Path.GetDirectoryName(BuscadorCarpetas.SelectedPath);
                carpetaBase = Path.GetFileName(carpetaBase);

                if (carpetaBase == carpetaProyecto)
                {
                    if (carpetaSeleccionada == carpetaModulo)
                    {
                        FrmSubirDiseno sincronizar = new FrmSubirDiseno(Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto")),
                                                                                    Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble")),
                                                                                    BuscadorCarpetas.SelectedPath, "MODULO", SW);

                        if (sincronizar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            ProgresoDiseno.Visible = true;
                            TvDiseno.Nodes.Clear();
                            ModuloCargado.CargarDatos(Convert.ToInt32(ModuloCargado.Fila().Celda("id")));
                            BkgDescargarDiseno.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La carpeta seleccionada no coincide con el modulo " + carpetaModulo, "Carpeta equivocada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BtnSubir_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("La carpeta seleccionada no coincide con el proyecto " + carpetaProyecto, "Carpeta equivocada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnSubir_Click(sender, e);
                }
            }
        }

        private void BkgDescargarArchivoSolid_DoWork(object sender, DoWorkEventArgs e)
        {
            string archivo = e.Argument.ToString();
            BkgDescargarArchivoSolid.ReportProgress(0, "Descargando archivo '" + archivo + "'" + Environment.NewLine);

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", ModuloCargado.Fila().Celda("proyecto"));
            parametros.Add("@subensamble", ModuloCargado.Fila().Celda("subensamble"));

            SolidWorksProyecto indiceSolid = new SolidWorksProyecto();
            indiceSolid.SeleccionarDatos("nombre_archivo LIKE '%" + archivo + "'", parametros, "*");

            if (indiceSolid.TieneFilas() == false)
            {
                BkgDescargarArchivoSolid.ReportProgress(100, "Error al descargar archivo... [ERROR]" + Environment.NewLine);
                return;
            }

            string temporal = Path.GetTempPath() + archivo;
            
            if (ClienteFtp.DownloadFile(temporal, RaizFtp + "/" + indiceSolid.Fila().Celda("nombre_archivo").ToString(), true, FtpVerify.Retry))
            {
                BkgDescargarArchivoSolid.ReportProgress(50, "Archivo descargado correctamente, extrayendo Custom properties..." + Environment.NewLine);
                SW.ExtraerPropiedadesParte(temporal, out CustomPropertiesParte);


                if (CustomPropertiesParte.Count > 0)
                {
                    BkgDescargarArchivoSolid.ReportProgress(75, "Custom properties extraidas correctamente... [OK]" + Environment.NewLine);
                }
                else
                {
                    BkgDescargarArchivoSolid.ReportProgress(100, "Error al extraer Custom properties... [ERROR]" + Environment.NewLine);
                }

                BkgDescargarArchivoSolid.ReportProgress(75, "Generando vista previa..." + Environment.NewLine);

                //28/08/2018 Clara Laborde: Modo de falla no siempre será una parte, puede ser sldasm
                if (temporal.ToUpper().EndsWith(".SLDASM"))
                    SW.VistaPrevia(temporal, swDocumentTypes_e.swDocASSEMBLY, out VistaPreviaParte);
                else if(temporal.ToUpper().EndsWith(".SLDPRT"))
                    SW.VistaPrevia(temporal, swDocumentTypes_e.swDocPART, out VistaPreviaParte);

                if (VistaPreviaParte != null)
                {
                    BkgDescargarArchivoSolid.ReportProgress(75, "Vista previa generada correctamente... [OK]" + Environment.NewLine);
                    var ms = new MemoryStream(VistaPreviaParte);
                    PicParteDiseno.Image = Image.FromStream(ms);
                }
                else
                {
                    BkgDescargarArchivoSolid.ReportProgress(75, "Error al generar vista previa... [ERROR]" + Environment.NewLine);
                }
            }
            else
            {
                BkgDescargarArchivoSolid.ReportProgress(100, "Error al descargar archivo... [ERROR]" + Environment.NewLine);
            }
        }


        private void BkgInicializarDiseno_DoWork(object sender, DoWorkEventArgs e)
        { 
            // Cierra cualquier proceso vinculado con solidworks
            ProcesosSolidWorks = Global.BuscarProcesos("sldworks");

            if(ProcesosSolidWorks.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("Estás a punto de conectarte con SolidWorks, asegúrate de guardar tus cambios y cerrar todos los archivos que tengas abiertos... cuando estés listo presiona OK.", "Conectando a SolidWorks", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (respuesta != System.Windows.Forms.DialogResult.OK)
                {
                    BkgInicializarDiseno.ReportProgress(100, "Conexión con SolidWorks cancelada por el usuario" + System.Environment.NewLine);
                    return;
                }
                BkgInicializarDiseno.ReportProgress(50, "Cerrando otras instancias de SolidWorks... ");
                Global.TerminarProcesos(ProcesosSolidWorks);
                System.Threading.Thread.Sleep(2000);
                BkgInicializarDiseno.ReportProgress(100, "[OK]" + System.Environment.NewLine);
            }

            // Crear nueva conexion con SolidWorks
            BkgInicializarDiseno.ReportProgress(0, "Conectando con SolidWorks... ");
            SW = new SolidWorksAPI();

            // Verificar conexion con SolidWorks
            if (SW.Aplicacion == null)
                BkgInicializarDiseno.ReportProgress(50, "[ERROR]" + System.Environment.NewLine);
            else
                BkgInicializarDiseno.ReportProgress(0, "[OK]" + System.Environment.NewLine);

            // Conectar con servidor FTP
            BkgInicializarDiseno.ReportProgress(0, "Conectando con servidor FTP... ");
            if (Global.TipoConexion == "LOCAL")
            {
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }
            else
            {
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;
                ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                               Global.UsuarioActual.Fila().Celda("password").ToString());
            }


            // Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Connect();

                BkgInicializarDiseno.ReportProgress(100, "[OK]" + System.Environment.NewLine);
                FtpConectado = true;
            }
            catch (Exception ex)
            {
                BkgInicializarDiseno.ReportProgress(100, "[ERROR]" + System.Environment.NewLine + ex.ToString());
                FtpConectado = false;
            }
        }

        private void BkgInicializarDiseno_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (FtpConectado && SW.Aplicacion != null)
            {
                SplitEstatusDiseno.Panel1Collapsed = false;
                BkgDescargarDiseno.RunWorkerAsync();

            }
        }

        private void BkgInicializarDiseno_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDiseno.Value = e.ProgressPercentage;
            TxtEstatusDiseno.AppendText(e.UserState.ToString());
        }

        private void BkgDescargarArchivoSolid_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TxtEstatusDiseno.AppendText(e.UserState.ToString());
            ProgresoDiseno.Value = e.ProgressPercentage;
        }

        private void BkgDescargarArchivoSolid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled || CustomPropertiesParte == null)
            {
                TvDiseno.Enabled = true;
                return;
            }

            LvCustomProperties.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in CustomPropertiesParte)
            {
                ListViewItem it = new ListViewItem();
                it.Text = kvp.Key;
                it.SubItems.Add(kvp.Value);
                LvCustomProperties.Items.Add(it);
            }
            TvDiseno.Enabled = true;
        }

        private void FrmDetallesModulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SW != null)
            {
                if (SW.Aplicacion != null)
                    SW.Terminar();
                ProcesosSolidWorks = Global.BuscarProcesos("sldworks");
                Global.TerminarProcesos(ProcesosSolidWorks);
            }
        }

        private void TvDiseno_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string extension = Path.GetExtension(e.Node.Name);

            if (e.Button == MouseButtons.Left && extension.ToUpper() == ".SLDPRT")
            {
                LvCustomProperties.Items.Clear();
                TvDiseno.Enabled = false;
                PicParteDiseno.Image = null;
                LblArchivoDisenoSeleccionado.Text = e.Node.Name;
                BkgDescargarArchivoSolid.RunWorkerAsync(e.Node.Name);
            }
            else if (e.Button == MouseButtons.Left && extension.ToUpper() == ".SLDDRW")
            {
                LvCustomProperties.Items.Clear();
                TvDiseno.Enabled = false;
                PicParteDiseno.Image = null;
                LblArchivoDisenoSeleccionado.Text = e.Node.Name;
                BkgMostrarPlano.RunWorkerAsync(e.Node.Name);
            }
        }

        private void revisarDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BloqueoMecanico)
            {
                MessageBox.Show("El diseño debe estar desbloqueado para poder revisar planos.", "Imposible revisar plano", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreDrawing = TvDiseno.SelectedNode.Name;
            FrmRevisarDrawing rev = new FrmRevisarDrawing(Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto")),
                                                          Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble")),
                                                          nombreDrawing, SW);

            DialogResult resp = new DialogResult();
            resp = rev.ShowDialog();

            if (resp == DialogResult.OK)
            {
                TxtEstatusDiseno.AppendText("Plano '" + nombreDrawing + "' revisado correctamente." + Environment.NewLine);
                BkgDescargarDiseno.RunWorkerAsync();
            }
        }

        private void BtnAprobar_Click(object sender, EventArgs e)
        {
            ModuloCargado.CargarDatos(Convert.ToInt32(ModuloCargado.Fila().Celda("id")));
            SolidWorksProyecto sinAceptar = new SolidWorksProyecto();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto")));
            parametros.Add("@subensamble", Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble")));
            parametros.Add("@pendiente", "PENDIENTE");
            parametros.Add("@rechazado", "RECHAZADO");

            // ignora drawings en raiz (deben existir mas de dos '\' en el path para que el drawing no este en raiz)
            string condiciones = "";
            condiciones = "proyecto=@proyecto AND ";
            condiciones += "subensamble=@subensamble AND ";
            condiciones += "(estatus_revision=@pendiente OR estatus_revision=@rechazado) AND ";
            condiciones += "nombre_archivo LIKE '%.slddrw' AND (LENGTH(`nombre_archivo`) - LENGTH(REPLACE(`nombre_archivo`, '\', ''))) > 2";
            sinAceptar.SeleccionarDatos(condiciones, parametros);

            if (sinAceptar.TieneFilas())
            {
                MessageBox.Show("Antes de aprobar el diseño del módulo deben revisarse y aceptarse todos los planos de las carpetas CP y MP.",
                                "Imposible aprobar diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                FrmAprobarDisenoModulo aprobar = new FrmAprobarDisenoModulo(ModuloCargado, SW);
                
                if(aprobar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string comentariosRevision = string.Empty;
                    Fila revisionDelModulo = new Fila();
                    int revision = Convert.ToInt32(ModuloCargado.Fila().Celda("revision"));
                    int idCambioDiseno = Convert.ToInt32(ModuloCargado.Fila().Celda("cambio_diseno"));

                    if(idCambioDiseno > 0)
                    {
                        CambioDiseno cambio = new CambioDiseno();
                        cambio.CargarDatos(idCambioDiseno);

                        revision++;
                        ModuloCargado.Fila().ModificarCelda("revision", revision);
                        ModuloCargado.Fila().ModificarCelda("comentarios_revision", cambio.Fila().Celda("alcance"));
                        ModuloCargado.GuardarDatos();

                        revisionDelModulo.AgregarCelda("proyecto", IdProyecto);
                        revisionDelModulo.AgregarCelda("subensamble", Subensamble);
                        revisionDelModulo.AgregarCelda("revision", revision);

                        comentariosRevision = "CAMBIO #" + cambio.Fila().Celda("id").ToString().PadLeft(5, '0') + Environment.NewLine;
                        comentariosRevision += cambio.Fila().Celda("motivo_cambio").ToString() + Environment.NewLine + Environment.NewLine;
                        comentariosRevision += cambio.Fila().Celda("alcance");

                        revisionDelModulo.AgregarCelda("comentarios_revision", comentariosRevision);
                        revisionDelModulo.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto());
                        revisionDelModulo.AgregarCelda("fecha", DateTime.Now);

                        RevisionModulo.Modelo().Insertar(revisionDelModulo);
                    }
                    else
                    {
                        ModuloCargado.Fila().ModificarCelda("revision", 0);
                        ModuloCargado.Fila().ModificarCelda("comentarios_revision", "REVISION INCIAL");
                        ModuloCargado.GuardarDatos();

                        revisionDelModulo.AgregarCelda("proyecto", IdProyecto);
                        revisionDelModulo.AgregarCelda("subensamble", Subensamble);
                        revisionDelModulo.AgregarCelda("revision", 0);
                        revisionDelModulo.AgregarCelda("comentarios_revision", "REVISION INICIAL");
                        revisionDelModulo.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto());
                        revisionDelModulo.AgregarCelda("fecha", DateTime.Now);
                        RevisionModulo.Modelo().Insertar(revisionDelModulo);
                    }
                }

                BkgDescargarDiseno.RunWorkerAsync();
            }
        }

        private void BtnBajar_Click(object sender, EventArgs e)
        {
            if (VentanaBajarDiseno != null)
            {
                if (VentanaBajarDiseno.Visible)
                {
                    MessageBox.Show("Ya estas bajando el diseño!", "Bajar diseño", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ModuloCargado.CargarDatos(Convert.ToInt32(ModuloCargado.Fila().Celda("id")));

            string carpetaProyecto = "M" + IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');
            string carpetaModulo = Subensamble.ToString().PadLeft(2, '0');

            if(Aprobado)
            {
                string msg = "Este módulo fue congelado por " + ModuloCargado.Fila().Celda("usuario_aprobacion");
                msg += ", se descargará una copia en modo de sólo lectura.";

                DialogResult resp = MessageBox.Show(msg, "Módulo congelado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (resp != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            else if (BloqueoMecanico)
            {
                string msg = "Este módulo fue bloqueado por " + ModuloCargado.Fila().Celda("usuario_bloqueo_mecanico");
                msg += ", se descargará una copia en modo de sólo lectura.";
                DialogResult resp = MessageBox.Show(msg, "Módulo bloqueado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (resp != System.Windows.Forms.DialogResult.OK)
                    return;
            }

            if (BuscadorFolderExportar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string carpetaSeleccionada = Path.GetFileName(BuscadorFolderExportar.SelectedPath);
                string carpetaBase = Path.GetDirectoryName(BuscadorFolderExportar.SelectedPath);
                carpetaBase = Path.GetFileName(carpetaBase);

                if (carpetaBase == carpetaProyecto)
                {
                    if (carpetaSeleccionada == carpetaModulo)
                    {
                        VentanaBajarDiseno = new FrmBajarDiseno(ClienteFtp, BuscadorFolderExportar.SelectedPath, RaizFtp, IdProyecto, Subensamble, BloqueoMecanico, SoloLectura || Aprobado);
                        
                        if(VentanaBajarDiseno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            BtnActualizar_Click(null, null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La carpeta seleccionada no corresponde al modulo " + carpetaModulo, "Carpeta equivocada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BtnBajar_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("La carpeta seleccionada no corresponde al proyecto " + carpetaProyecto, "Carpeta equivocada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BtnBajar_Click(sender, e);
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            BtnActualizar.Enabled = false;
            ProgresoDiseno.Visible = true;
            TvDiseno.Nodes.Clear();
            ModuloCargado.CargarDatos(Convert.ToInt32(ModuloCargado.Fila().Celda("id")));
            BkgDescargarDiseno.RunWorkerAsync();
        }

        private void comentariosDeRevisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreDrawing = TvDiseno.SelectedNode.Name;

            SolidWorksProyecto drw = new SolidWorksProyecto();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", Convert.ToDecimal(ModuloCargado.Fila().Celda("proyecto")));
            parametros.Add("@subensamble", Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble")));

            drw.SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND nombre_archivo LIKE '%" + nombreDrawing + "'", parametros);

            if (drw.TieneFilas())
            {
                FrmComentariosRevisionDrawing comentarios = new FrmComentariosRevisionDrawing(Convert.ToInt32(drw.Fila().Celda("id")));
                comentarios.Show();
            }
            else
            {
                MessageBox.Show("Error: el plano no fue encontrado!", "Plano no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void drawingCorregidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreDrawing = TvDiseno.SelectedNode.Name;

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", IdProyecto);
            parametros.Add("@subensamble", Subensamble);

            SolidWorksProyecto drawing = new SolidWorksProyecto();
            drawing.SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble AND nombre_archivo LIKE '%" + nombreDrawing + "'", parametros);

            if (drawing.TieneFilas())
            {
                if (drawing.Fila().Celda("estatus_revision").ToString() != "RECHAZADO")
                {
                    MessageBox.Show("Este plano no ha sido rechazado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string msg = "Seguro que quieres marcar el plano '" + nombreDrawing + "' como corregido?";
                DialogResult resp = MessageBox.Show(msg, "Plano corregido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp != DialogResult.Yes)
                    return;

                drawing.Fila().ModificarCelda("estatus_revision", "PENDIENTE");
                drawing.GuardarDatos();
                BkgDescargarDiseno.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("El plano no fue encontrado", "Plano no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BkgCrearArchivosCache_DoWork(object sender, DoWorkEventArgs e)
        {
            if (BkgCrearArchivosCache.CancellationPending || e.Cancel || RutasParcialesArchivosPendientes.Count == 0)
                return;
 
            BkgCrearArchivosCache.ReportProgress(0, "Generando archivos caché... ");
            for (int i = 0; i < RutasParcialesArchivosPendientes.Count; i++)
            {
                CrearArchivosCache(RutasParcialesArchivosPendientes[i]);
            }
            BkgCrearArchivosCache.ReportProgress(100, "[OK]"  + Environment.NewLine);
        }

        private void BkgCrearArchivosCache_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDiseno.Value = e.ProgressPercentage;
            TxtEstatusDiseno.AppendText(e.UserState.ToString());
        }

        private void BkgCrearArchivosCache_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RutasParcialesArchivosPendientes.Clear();
        }

        private void reconstruirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reconstruirToolStripMenuItem.Enabled = false;

            //nombre del drawing del nodo seleccionado
            string nombreDrawing = TvDiseno.SelectedNode.Name;

            //se crea la ruta del archivo del nodo seleccionado           
            string rutaParcialConExtension = "\\" + Subensamble.ToString().PadLeft(2, '0') + "\\CP\\" +  nombreDrawing;

            //se crean los archivos
            BkgReconstruirDrawing.RunWorkerAsync(rutaParcialConExtension);
        }

        private void BkgReconstruirDrawing_DoWork(object sender, DoWorkEventArgs e)
        {
            BkgReconstruirDrawing.ReportProgress(0, "Reconstruyendo archivo: " + e.Argument.ToString());
            CrearArchivosCache(e.Argument.ToString(), true);
        }

        private void BkgReconstruirDrawing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDiseno.Value = e.ProgressPercentage;
            TxtEstatusDiseno.AppendText(e.UserState.ToString() + Environment.NewLine);
            TxtEstatusDiseno.Refresh(); 
        }

        private void BkgReconstruirDrawing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxtEstatusDiseno.AppendText("Archivos caché reconstruídos... [OK]" + Environment.NewLine);
            reconstruirToolStripMenuItem.Enabled = true;
        }

        private void BkgMostrarPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string rutaRemotaConExtension = RaizFtp + "\\" + Subensamble.ToString().PadLeft(2, '0') + "\\CP\\" + e.Argument.ToString();
                string rutaRemotaSinExtencion = Path.ChangeExtension(rutaRemotaConExtension, "");
                string temporal = string.Empty;
                byte[] datosImagen = null;
                string[] archivosServidor = null;

                // Descargamos la parte o el ensamble correspondiente al drawing (.SLDPRT / .SLDASM) 
                // para crear los Custom properties y para generar el plano en tiempo real si es necesario
                if (ClienteFtp.FileExists(rutaRemotaSinExtencion + "SLDPRT"))
                {
                    temporal = Path.GetTempPath() + Path.GetFileNameWithoutExtension(e.Argument.ToString()) + ".SLDPRT";
                    ClienteFtp.DownloadFile(temporal, rutaRemotaSinExtencion + "SLDPRT");
                    BkgMostrarPlano.ReportProgress(0, "Descargando archivo '" + Path.GetFileNameWithoutExtension(e.Argument.ToString()) + ".SLDPRT" + "'" + Environment.NewLine);
                }
                else if (ClienteFtp.FileExists(RaizFtp + rutaRemotaSinExtencion + "SLDASM"))
                {
                    temporal = Path.GetTempPath() + Path.GetFileNameWithoutExtension(e.Argument.ToString()) + ".SLDASM";
                    ClienteFtp.DownloadFile(temporal, RaizFtp + rutaRemotaSinExtencion + "SLDASM");
                    BkgMostrarPlano.ReportProgress(0, "Descargando archivo '" + Path.GetFileNameWithoutExtension(e.Argument.ToString()) + ".SLDPRT" + "'" + "'" + Environment.NewLine);
                }

                // Se verifica si existen los archivos caché y se bajan en memoria.
                if (ClienteFtp.FileExists(rutaRemotaSinExtencion + "PNG"))
                    ClienteFtp.Download(out datosImagen, rutaRemotaSinExtencion + "PNG");
                else
                {
                    // En caso de no existir, se obtiene la lista de los archivos guardados en el servidor Y
                    // se busca el archivo que tenga el mismo nombre y mayor id
                    archivosServidor = ClienteFtp.GetNameListing(Path.GetDirectoryName(rutaRemotaConExtension) + "\\");
                    string[] listaPathArchivosEnServidor = Array.FindAll(archivosServidor, servidor => servidor.Contains(Path.GetFileNameWithoutExtension(e.Argument.ToString()) + ".PNG"));

                    if (listaPathArchivosEnServidor.Length <= 0)
                    {
                        //sino existen se genera el plano en tiempo real
                        byte[] datosPdf;
                        string nombreTemporal = Path.GetTempFileName();
                        SW.DrawingAPDF(Path.GetTempPath() + e.Argument.ToString(), out datosPdf);
                        File.WriteAllBytes(nombreTemporal, datosPdf);
                        datosImagen = FormatosPDF.MiniaturaPDF(nombreTemporal, 0, 0, 150);
                    }
                    else
                        ClienteFtp.Download(out datosImagen, listaPathArchivosEnServidor.Last());
                }

                // se generan los custom properties con los archivos descargados anteriormente
                BkgMostrarPlano.ReportProgress(50, "Archivos descargados correctamente, extrayendo Custom properties..." + Environment.NewLine);
                SW.ExtraerPropiedadesParte(temporal, out CustomPropertiesParte);

                if (CustomPropertiesParte.Count > 0)
                    BkgMostrarPlano.ReportProgress(75, "Custom properties extraidas correctamente... [OK]" + Environment.NewLine);
                else
                    BkgMostrarPlano.ReportProgress(100, "Error al extraer Custom properties... [ERROR]" + Environment.NewLine);

                //Generar y mostrar el plano 
                BkgMostrarPlano.ReportProgress(80, "Generando vista previa..." + Environment.NewLine);

                if (datosImagen != null)
                {
                    BkgMostrarPlano.ReportProgress(80, "Vista previa generada correctamente... [OK]" + Environment.NewLine);
                    var ms = new MemoryStream(datosImagen);
                    PicParteDiseno.Image = Image.FromStream(ms);
                    ms.Close();
                }
                else
                {
                    BkgMostrarPlano.ReportProgress(80, "Error al generar vista previa... [ERROR]" + Environment.NewLine);
                }
            }
            catch { /*evitamos excepciones en caso de cancelar el BackgroundWorker mientras genera o descarga un archivo*/ }
        }

        private void BkgMostrarPlano_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDiseno.Value = e.ProgressPercentage;
            TxtEstatusDiseno.AppendText(e.UserState.ToString());
        }

        private void BkgMostrarPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TvDiseno.Enabled = true;
            if (e.Cancelled || CustomPropertiesParte == null)
                return;

            LvCustomProperties.Items.Clear();
            foreach (KeyValuePair<string, string> kvp in CustomPropertiesParte)
            {
                ListViewItem it = new ListViewItem();
                it.Text = kvp.Key;
                it.SubItems.Add(kvp.Value);
                LvCustomProperties.Items.Add(it);
            }
        }

        private void BkgBorrarArchivosCache_DoWork(object sender, DoWorkEventArgs e)
        {
            string rutaRemotaConExtension = RaizFtp + "\\" + Subensamble.ToString().PadLeft(2, '0') + "\\CP\\" + e.Argument.ToString();
            string rutaRemotaSinExtencion = Path.ChangeExtension(rutaRemotaConExtension, "");

            if (rutaRemotaSinExtencion.EndsWith("."))
                rutaRemotaSinExtencion = rutaRemotaSinExtencion.Remove(rutaRemotaSinExtencion.Length - 1);

            BkgBorrarArchivosCache.ReportProgress(0, "Borrando caché del archivo: '" + e.Argument.ToString() + "'" + Environment.NewLine);
            //borrar archivos
            foreach (string extension in ".PDF, .PNG, _MIN.PNG, _ISO.PNG, _REV.PNG".Split(','))
            {
                string borrarPath = rutaRemotaSinExtencion + extension.Trim();

                if (ClienteFtp.FileExists(borrarPath))
                    ClienteFtp.DeleteFile(borrarPath);
            }          
        }

        private void BkgBorrarArchivosCache_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgresoDiseno.Value = e.ProgressPercentage;
            TxtEstatusDiseno.AppendText(e.UserState.ToString());
        }

        private void BkgBorrarArchivosCache_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TxtEstatusDiseno.AppendText("Archivos caché borrados... [OK]" + Environment.NewLine);
            borrarArchivosCachéToolStripMenuItem.Enabled = true;
        }

        private void borrarArchivosCachéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrarArchivosCachéToolStripMenuItem.Enabled = false;
            BkgBorrarArchivosCache.RunWorkerAsync(TvDiseno.SelectedNode.Text);
        }

        private void BtnLiberar_Click(object sender, EventArgs e)
        {
            if(BtnLiberar.ContextMenuStrip != null)
            {
                imprimirFormatoToolStripMenuItem.Enabled = ModuloCargado.Fila().Celda("estatus_liberacion").ToString() == "PENDIENTE";
                liberarDisenoToolStripMenuItem.Enabled = ModuloCargado.Fila().Celda("estatus_liberacion").ToString() == "PENDIENTE";
                evidenciaDeLiberacionToolStripMenuItem.Enabled = ModuloCargado.Fila().Celda("estatus_liberacion").ToString() == "LIBERADO";
                BtnLiberar.ContextMenuStrip.Show(BtnLiberar, BtnLiberar.PointToClient(Cursor.Position));
            }
        }

        private void imprimirFormatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string carpetaSolidos = "C:\\CompanyBlocks\\Solidos";
            string strProyecto = IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0');
            string strSubensamble = Subensamble.ToString().PadLeft(2, '0');
            carpetaSolidos += "\\M" + strProyecto;
            carpetaSolidos += "\\" + strSubensamble;
            string rutaSubensamble = carpetaSolidos + "\\M" + strProyecto + "-" + strSubensamble + ".SLDASM";

            VentanaBajarDiseno = new FrmBajarDiseno(ClienteFtp, carpetaSolidos, RaizFtp, IdProyecto, Subensamble, true, true);
            
            if(VentanaBajarDiseno.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FrmGenerarVistaPreviaSubensamble generarVistaPrevia = new FrmGenerarVistaPreviaSubensamble(rutaSubensamble, SW);

                if (generarVistaPrevia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FrmImprimirFormatoLiberacionDiseno imprimirLiberacion = new FrmImprimirFormatoLiberacionDiseno(generarVistaPrevia.VistaPrevia, IdProyecto, true, Convert.ToInt32(Subensamble), Modulo);
                    imprimirLiberacion.Show();
                }
            }
        }

        private void liberarDisenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLiberarDisenoMecanico liberar = new FrmLiberarDisenoMecanico(IdProyecto, Subensamble);

            if(liberar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BtnActualizar_Click(null, null);
            }
        }

        private void evidenciaDeLiberacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idEvidenciaLiberacion = Convert.ToInt32(ModuloCargado.Fila().Celda("evidencia_liberacion"));

            EvidenciaLiberacionModulo evidencia = new EvidenciaLiberacionModulo();
            evidencia.CargarDatos(idEvidenciaLiberacion);

            if(evidencia.TieneFilas())
            {
                byte[] archivoEvidencia = (byte[])evidencia.Fila().Celda("archivo");
                FrmVisorPDF visor = new FrmVisorPDF(archivoEvidencia, "EVIDENCIA DE LIBERACION DE DISEÑO M" + IdProyecto.ToString("F2").Replace(".", "_").PadLeft(6, '0') + "-" + Subensamble.ToString().PadLeft(2, '0'));
                visor.Show();
            }
        }

        private void LblRevision_DoubleClick(object sender, EventArgs e)
        {
            FrmRevisionesModulo rev = new FrmRevisionesModulo(IdProyecto, Subensamble);
            rev.ShowDialog();
        }

 
    }
}