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
    public partial class FrmEditarInformacionEmpleado : Ventana
    {
        public delegate void EventoActualizarPuesto(string puesto);
        public event EventoActualizarPuesto _Puesto;

        public delegate void EventoActualizarNombre(string nombre);
        public event EventoActualizarNombre _ActualizarNombre;
   
        Usuario UsuarioInformacion = new Usuario();
        Rol RolUsuarios = new Rol();
        int IdDocumento = 0;
        int IdEmpleado = 0;

        public FrmEditarInformacionEmpleado(int idEmpleado)
        {
            InitializeComponent();
            IdEmpleado = idEmpleado;
            CargarDocumentos();
            DgvDocumentos.ClearSelection();
        }

        private void FrmEditarInformacionEmpleado_Load(object sender, EventArgs e)
        {
            HabilitarControles(false);
            NumNivel.Visible = false;
            LblNivel.Visible = false;

            RolUsuarios.Todos().ForEach(delegate(Fila f)
            {
                CmbPuesto.Items.Add(f.Celda("rol").ToString());
            });

            UsuarioInformacion.CargarDatos(IdEmpleado);
            if(UsuarioInformacion.TieneFilas())
            {
                string paterno = "";
                object objPaterno = UsuarioInformacion.Fila().Celda("paterno");
                if (objPaterno != null)
                    paterno = objPaterno.ToString();

                string materno = "";
                object objMaterno = UsuarioInformacion.Fila().Celda("materno");
                if (objMaterno != null)
                    materno = objMaterno.ToString();

                string correo = "";
                object objCorreo = UsuarioInformacion.Fila().Celda("correo");
                if (objCorreo != null)
                    correo = objCorreo.ToString();

                string telefono = "";
                object objTelefono = UsuarioInformacion.Fila().Celda("tel");
                if (objTelefono != null)
                    telefono = objTelefono.ToString();

                string apodo = "";
                object objApodo = UsuarioInformacion.Fila().Celda("nick_name");
                if (objApodo != null)
                    apodo = objApodo.ToString();

                TxtNombre.Text = UsuarioInformacion.Fila().Celda("nombre").ToString();
                TxtPaterno.Text = paterno;
                TxtMaterno.Text = materno;
                TxtCorreo.Text = correo;
                TxtTelefono.Text = telefono;
                TxtApodo.Text = apodo;
                CmbPuesto.Text = UsuarioInformacion.Fila().Celda("rol").ToString();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@rol", CmbPuesto.Text);
                RolUsuarios.SeleccionarDatos("rol=@rol", parametros);
                if(RolUsuarios.TieneFilas())
                {
                    if(Convert.ToInt32(RolUsuarios.Fila().Celda("nivel_maximo")) > 0)
                    {
                        NumNivel.Visible = true;
                        LblNivel.Visible = true;
                    }
                }
                NumNivel.Value = Convert.ToInt32(UsuarioInformacion.Fila().Celda("nivel").ToString());
                DtpFehcaIngreso.Value = Convert.ToDateTime(UsuarioInformacion.Fila().Celda("fecha_alta").ToString());
            }
        }

        private void HabilitarControles(bool Habilitar)
        {
            TxtNombre.Enabled = Habilitar;
            TxtMaterno.Enabled = Habilitar;
            TxtPaterno.Enabled = Habilitar;
            TxtCorreo.Enabled = Habilitar;
            TxtTelefono.Enabled = Habilitar;
            CmbPuesto.Enabled = Habilitar;
            NumNivel.Enabled = Habilitar;
            DtpFehcaIngreso.Enabled = Habilitar;
            TxtApodo.Enabled = Habilitar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(BtnEditar.Text == "Editar")
            {
                BtnEditar.Text = "Finalizar";
                BtnEditar.Image = CB_Base.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_dialog_ok_apply;
                HabilitarControles(true);
            }
            else if(BtnEditar.Text == "Finalizar")
            {
                DialogResult result = MessageBox.Show("¿Está seguro de actualizar la información actual?", "Actualizar información", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        UsuarioInformacion.CargarDatos(IdEmpleado);
                        if (UsuarioInformacion.TieneFilas())
                        {
                            UsuarioInformacion.Fila().ModificarCelda("correo", TxtCorreo.Text);
                            UsuarioInformacion.Fila().ModificarCelda("nombre", TxtNombre.Text);
                            UsuarioInformacion.Fila().ModificarCelda("paterno", TxtPaterno.Text);
                            UsuarioInformacion.Fila().ModificarCelda("materno", TxtMaterno.Text);
                            UsuarioInformacion.Fila().ModificarCelda("tel", TxtTelefono.Text);
                            UsuarioInformacion.Fila().ModificarCelda("rol", CmbPuesto.Text);
                            UsuarioInformacion.Fila().ModificarCelda("nivel", NumNivel.Value.ToString());
                            UsuarioInformacion.Fila().ModificarCelda("fecha_alta", Convert.ToDateTime(DtpFehcaIngreso.Value));
                            UsuarioInformacion.Fila().ModificarCelda("nick_name", TxtApodo.Text);
                            UsuarioInformacion.GuardarDatos();
                            MessageBox.Show("Información actualizada correctamente");
                            _Puesto(CmbPuesto.Text);
                            _ActualizarNombre(TxtNombre.Text.ToUpper() + " " + TxtPaterno.Text.ToUpper());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error, si el problema continúa contacte en contacto al personal de sistemas.\rCódigo del error:\r" + ex.ToString(), "Error ocurrido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    BtnEditar.Text = "Editar";
                    BtnEditar.Image = CB_Base.Properties.Resources.Edit;
                    HabilitarControles(false);
                }
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarDocumento documento = new FrmAgregarDocumento();
            if(documento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {             
                DateTime fechaVencimiento;

                TipoDocumentoUsuario tipoDocumento = new TipoDocumentoUsuario();
                Fila agregarDocumento = new Fila();
                int mesesvigencia = Convert.ToInt32(documento.MesesVencimiento);

                agregarDocumento.AgregarCelda("tipo", documento.TipoDocumento);
                agregarDocumento.AgregarCelda("meses_vigencia", mesesvigencia);
                agregarDocumento.AgregarCelda("fecha_registro", DateTime.Now);

                if(mesesvigencia != 0)
                {
                   fechaVencimiento  = DateTime.Now.AddMonths(Convert.ToInt32(documento.MesesVencimiento));
                   agregarDocumento.AgregarCelda("fecha_vencimiento", fechaVencimiento);
                }

                agregarDocumento.AgregarCelda("documento", documento.Documento);
                agregarDocumento.AgregarCelda("usuario", IdEmpleado);
                tipoDocumento.Insertar(agregarDocumento);

                CargarDocumentos();
            }
        }

        private void DgvDocumentos_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvDocumentos.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    agregarToolStripMenuItem.Enabled = true;
                    actualizarToolStripMenuItem.Enabled = false;
                    eliminarToolStripMenuItem.Enabled = false;
                    Menu.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvDocumentos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    eliminarToolStripMenuItem.Enabled = true;
                    actualizarToolStripMenuItem.Enabled = true;                  
                    Menu.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void CargarDocumentos()
        {
            TipoDocumentoUsuario documentos = new TipoDocumentoUsuario();
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvDocumentos);
            DgvDocumentos.Rows.Clear();

            documentos.SeleccionarDocumento(IdEmpleado).ForEach(delegate(Fila f)
            {
                string estatus = "Sin vigencia";
                string fechaVencimiento = "";
                string mesesVigencia = "Sin vigencia";

                if(Convert.ToInt32(f.Celda("meses_vigencia").ToString()) > 0)
                    mesesVigencia = f.Celda("meses_vigencia").ToString() + " meses";

                object objFechaVencimiento = f.Celda("fecha_vencimiento");
                if (objFechaVencimiento != null)
                {
                    fechaVencimiento = Convert.ToDateTime(f.Celda("fecha_vencimiento")).ToString("MMM dd, yyyy");
                    string fechaActual = DateTime.Now.ToString("MMM dd, yyyy");

                    if (Convert.ToDateTime(fechaVencimiento) > Convert.ToDateTime(fechaActual))
                        estatus = "Vigente";

                    if (Convert.ToDateTime(fechaVencimiento) < Convert.ToDateTime(fechaActual))
                        estatus = "Vencido";
                }

                DgvDocumentos.Rows.Add(f.Celda("id").ToString(), f.Celda("tipo").ToString().ToUpper(), Convert.ToDateTime(f.Celda("fecha_registro")).ToString("MMM dd, yyyy").ToUpper(), mesesVigencia.ToUpper(), fechaVencimiento.ToUpper(), estatus.ToUpper(), f.Celda("documento"));
            });

            ConfiguracionDataGridView.Recuperar(cfg, DgvDocumentos);
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarDocumento documento = new FrmAgregarDocumento(IdDocumento);
            if(documento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int mesesvigencia = Convert.ToInt32(documento.MesesVencimiento);
                 DateTime fechaVencimiento;

                TipoDocumentoUsuario tipoDocumentos = new TipoDocumentoUsuario();
                tipoDocumentos.CargarDatos(IdDocumento);
                tipoDocumentos.Fila().ModificarCelda("tipo", documento.TipoDocumento);
                tipoDocumentos.Fila().ModificarCelda("meses_vigencia", mesesvigencia);

                if(mesesvigencia != 0)
                {
                   fechaVencimiento  = DateTime.Now.AddMonths(Convert.ToInt32(documento.MesesVencimiento));
                   tipoDocumentos.Fila().ModificarCelda("fecha_vencimiento", fechaVencimiento);
                }
                if(documento.Documento != null)
                    tipoDocumentos.Fila().ModificarCelda("documento", documento.Documento);

                tipoDocumentos.GuardarDatos();
                CargarDocumentos();
            }
        }

        private void DgvDocumentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdDocumento = Convert.ToInt32(DgvDocumentos.SelectedRows[0].Cells["id"].Value);
        }

        private void DgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            byte[] datos = (byte[])DgvDocumentos.Rows[e.RowIndex].Cells["datos"].Value;

            FrmVisorPDF visor = new FrmVisorPDF(datos, DgvDocumentos.Rows[e.RowIndex].Cells["tipo"].Value.ToString());
            visor.ShowDialog();
        }

        private void DgvDocumentos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string estatus = DgvDocumentos.Rows[e.RowIndex].Cells["estatus"].Value.ToString();
            if (estatus == "Vencido")
            {
                DataGridViewCell cellEstatusEnsamble = DgvDocumentos.Rows[e.RowIndex].Cells["estatus"];
                cellEstatusEnsamble.Style.BackColor = Color.Red;
            }
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Esta seguro que desea dar de baja la información del empleado?", "Dar de baja", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                FrmRazonBajaUsuario razon = new FrmRazonBajaUsuario(IdEmpleado);
                if (razon.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Usuario usuario = new Usuario();
                    usuario.CargarDatos(IdEmpleado);
                    usuario.Fila().ModificarCelda("fecha_baja", DateTime.Now);
                    usuario.Fila().ModificarCelda("razon_baja", razon.IdRazon);
                    usuario.Fila().ModificarCelda("comentarios_baja", razon.Comentarios);
                    usuario.Fila().ModificarCelda("usuario_baja", Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
                    usuario.Fila().ModificarCelda("activo", 0);
                    usuario.GuardarDatos();

                    MessageBox.Show("El perfil del empleado ha sido dado de baja");
                    FrmMonitorRH cerrarRH = (FrmMonitorRH)Application.OpenForms["FrmMonitorRH"];
                    cerrarRH.Close();

                    FrmMonitorRH rh = new FrmMonitorRH();
                    rh.Show();
                    Close();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int docCount = 0;
            string texto = "";
            string documentos = "";
            foreach (DataGridViewRow row in DgvDocumentos.SelectedRows)
            {
                documentos += "Documento: " + row.Cells["tipo"].Value.ToString() + "\r\n";
                docCount++;
            }

            if (docCount > 1)
                texto = "¿Está seguro de borrar los documentos seleccionados?" + Environment.NewLine + documentos.ToString().TrimEnd();
            else
                texto = "¿Está seguro de borrar el documento seleccionado?" + Environment.NewLine + documentos.ToString().TrimEnd();

            DialogResult result = MessageBox.Show(texto, "Borrar documento", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                TipoDocumentoUsuario documento = new TipoDocumentoUsuario();
                foreach (DataGridViewRow row in DgvDocumentos.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    documento.CargarDatos(id);
                    documento.BorrarDatos();
                    documento.GuardarDatos();
                   
                }
                CargarDocumentos();
            }
        }
    }
}
