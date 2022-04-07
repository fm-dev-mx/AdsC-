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
using CB_Base.Classes;

namespace CB
{
    public partial class FrmAdministrarClientes : Form
    {
        byte[] Datos = null;
        Cliente cliente = new Cliente();
        ClienteContacto clienteContacto = new ClienteContacto();
        string abreviacion = "";
        string PathString = "SGC\\CLIENTES\\";
        int idRegistroContacto = 0;
        int idCliente = 0;

        public FrmAdministrarClientes()
        {
            InitializeComponent();
        }

        private void FrmAdministrarClientes_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            LblInfo.Visible = false;
            CargarClientes(TxtFiltroCliente.Text, ChkMostrarInactivos.Checked);
        }

        private void CargarClientes(string filtro, bool mostrarInactivo)
        {
            GrbDatosClientes.Visible = false;
            BtnEditarCliente.Enabled = false;
            BtnAgregarContacto.Enabled = false;
            btnEliminarContacto.Enabled = false;
            BtnEditarContacto.Enabled = false;
            ChkClienteActivo.Enabled = false;

            int seleccionarFila = Global.GuardarFilaSeleccionada(DgvListaClientes);
            DgvListaClientes.Rows.Clear();

            Cliente.Modelo().Filtrar(TxtFiltroCliente.Text, Convert.ToInt32(ChkMostrarInactivos.Checked)).ForEach(delegate(Fila filaActual)
            {
                int activo = Convert.ToInt32(filaActual.Celda("activo"));
                string ActivoTexto = "";

                switch (activo)
                {
                    case 1:
                        ActivoTexto = "SI";
                        break;

                    case 0:
                        ActivoTexto = "NO";
                        break;
                }

                DgvListaClientes.Rows.Add(filaActual.Celda("id"), filaActual.Celda("nombre"), ActivoTexto);
            });

            Global.RecuperarFilaSeleccionada(DgvListaClientes, seleccionarFila);
        }

        private void CargarDatosContacto(int idCliente)
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvContactos);
            DgvContactos.Rows.Clear();

            ClienteContacto.Modelo().SeleccionarDeCliente(idCliente).ForEach(delegate(Fila contacto) 
            {
                DgvContactos.Rows.Add(contacto.Celda("nombre").ToString(), contacto.Celda("apellidos").ToString(), contacto.Celda("celular").ToString(), contacto.Celda("tel1").ToString(), contacto.Celda("tel2").ToString(), contacto.Celda("correo"), contacto.Celda("id").ToString());   
            });

            Global.RecuperarFilaSeleccionada(DgvContactos, filaSeleccionada);
        }

        private void CargarDatosCliente()
        {
            abreviacion = cliente.Fila().Celda("abreviacion").ToString();
            TxtNombre.Text = cliente.Fila().Celda("nombre").ToString();
            TxtColonia.Text = cliente.Fila().Celda("colonia").ToString();
            TxtCalle.Text = cliente.Fila().Celda("calle").ToString();
            Txtnumero.Text = cliente.Fila().Celda("numero").ToString();
            TxtCP.Text = cliente.Fila().Celda("cp").ToString();
            TxtRazonSocial.Text = cliente.Fila().Celda("razon_social").ToString();
            TxtAbreviacion.Text = cliente.Fila().Celda("abreviacion").ToString();
            TxtEstado.Text = cliente.Fila().Celda("estado").ToString();
            TxtCiudad.Text = cliente.Fila().Celda("ciudad").ToString();
            GrbDatosClientes.Visible = true;
            BtnEditarCliente.Enabled = true;
        }

        private void NuevoContacto()
        {
            ChkClienteActivo.Checked = true;

            if (ValidarCampos())
            {
                LblInfo.Visible = true;
                LblInfo.Text = "Ingrese la informacion completa ";
            }

            else
            {
                if(Cliente.Modelo().Existe(TxtRazonSocial.Text.Trim()) || Cliente.Modelo().ExisteAbreviacion(TxtAbreviacion.Text.Trim()))
                    MessageBox.Show("Este proveedor ya fue registrado anteriormente, la razon social o la abreviacion ya fue registrada");

                else
                {
                    int activo = Convert.ToInt32(ChkClienteActivo.Checked);
                    Fila clien = new Fila();

                    clien.AgregarCelda("nombre", TxtNombre.Text.Trim());
                    clien.AgregarCelda("calle", TxtCalle.Text.Trim());
                    clien.AgregarCelda("colonia", TxtColonia.Text.Trim());
                    clien.AgregarCelda("numero", Txtnumero.Text.Trim());
                    clien.AgregarCelda("cp", TxtCP.Text.Trim());
                    clien.AgregarCelda("razon_social", TxtRazonSocial.Text.Trim());
                    clien.AgregarCelda("abreviacion", TxtAbreviacion.Text.Trim());
                    clien.AgregarCelda("ciudad", TxtCiudad.Text.Trim());
                    clien.AgregarCelda("estado", TxtEstado.Text.Trim());
                    clien.AgregarCelda("activo", activo);
                    Cliente.Modelo().Insertar(clien);

                    LblInfo.Text = "";
                    BtnNuevoCliente.Text = "Nuevo cliente";
                    LblNombreUsuario.Text = ("SELECCIONA UN CLIENTE");
                    DesactivarEdicion();
                    CargarClientes(TxtFiltroCliente.Text, ChkMostrarInactivos.Checked);
                }
            }
        }

        void ActivarEdicion()
        {
            TxtNombre.ReadOnly = false;
            TxtRazonSocial.ReadOnly = false;
            TxtCP.ReadOnly = false;
            TxtColonia.ReadOnly = false;
            TxtCalle.ReadOnly = false;
            Txtnumero.ReadOnly = false;
            TxtAbreviacion.ReadOnly = false;
            TxtCiudad.ReadOnly = false;
            TxtEstado.ReadOnly = false;
            ChkClienteActivo.Visible = true;
            ChkClienteActivo.Enabled = true;
        }

        void DesactivarEdicion()
        {
            TxtNombre.ReadOnly = true;
            TxtRazonSocial.ReadOnly = true;
            TxtCP.ReadOnly = true;
            TxtColonia.ReadOnly = true;
            TxtCalle.ReadOnly = true;
            Txtnumero.ReadOnly = true;
            TxtAbreviacion.ReadOnly = true;
            TxtEstado.ReadOnly = true;
            TxtCiudad.ReadOnly = true;
            ChkClienteActivo.Enabled = false;
        }

        void LimpiarTexbox()
        {
            TxtNombre.Text = "";
            TxtRazonSocial.Text = "";
            TxtCP.Text = "";
            TxtColonia.Text = "";
            TxtCalle.Text = "";
            Txtnumero.Text = "";
            TxtAbreviacion.Text = "";
            TxtCiudad.Text = "";
            TxtEstado.Text = "";
        }

        private bool ValidarCampos()
        {
            return (String.IsNullOrWhiteSpace(TxtNombre.Text) || String.IsNullOrWhiteSpace(TxtCiudad.Text) || String.IsNullOrWhiteSpace(TxtEstado.Text) || String.IsNullOrWhiteSpace(TxtColonia.Text) || String.IsNullOrWhiteSpace(TxtCalle.Text) || String.IsNullOrWhiteSpace(Txtnumero.Text) || String.IsNullOrWhiteSpace(TxtRazonSocial.Text) || String.IsNullOrWhiteSpace(TxtCP.Text));
                
        }

        private void LimpiarGridContacto()
        {
            DgvContactos.Rows.Clear();
            LblInfo.Visible = false;
            BtnEditarContacto.Enabled = false;
            BtnAgregarContacto.Enabled = false;
            btnEliminarContacto.Enabled = false;
        }

        private void GuardarEdicion(string abreviacion)
        {
            if (ValidarCampos())
            {
                LblInfo.Visible = true;
                LblInfo.Text = "Ingrese la informacion completa";
            }

            else
            {
                LblInfo.Visible = false;
                LblInfo.Text = "Info:";
                cliente.Fila().ModificarCelda("nombre", TxtNombre.Text.Trim());
                cliente.Fila().ModificarCelda("colonia", TxtColonia.Text.Trim());
                cliente.Fila().ModificarCelda("calle", TxtCalle.Text.Trim());
                cliente.Fila().ModificarCelda("numero", Txtnumero.Text.Trim());
                cliente.Fila().ModificarCelda("razon_social", TxtRazonSocial.Text.Trim());
                cliente.Fila().ModificarCelda("cp", TxtCP.Text.Trim());

                if (abreviacion != TxtAbreviacion.Text)
                    cliente.Fila().ModificarCelda("abreviacion", TxtAbreviacion.Text.Trim());

                cliente.Fila().ModificarCelda("ciudad", TxtCiudad.Text.Trim());
                cliente.Fila().ModificarCelda("estado", TxtCiudad.Text.Trim());
                cliente.Fila().ModificarCelda("activo", Convert.ToInt32(ChkClienteActivo.Checked));
                cliente.GuardarDatos();

                DesactivarEdicion();
                BtnEditarCliente.Text = "Editar";
                LblNombreUsuario.Text = "SELECCIONA UN CLIENTE";
                CargarClientes(TxtFiltroCliente.Text, ChkMostrarInactivos.Checked);
                DgvContactos.Rows.Clear();

                SubirImagen();
            }
        }

        private void SubirImagen()
        {
            // SUBIR IMAGEN
            if (PBImage.Image != null)
            {
                if (!ValidarTamanoLogo(PBImage.Image, 500, 158))
                {
                    Bitmap imagen = new Bitmap(PBImage.Image);
                    Datos = Global.CambiarTamanoImagen(imagen, new Size(500, 158));
                }
                else
                    Datos = Global.ImagenByte(PBImage.Image);

                splitContainer1.Panel1.Enabled = false;
                tabControl1.Enabled = false;
                DgvContactos.Enabled = false;
                Lblstatus.Visible = true;
                Progreso.Visible = true;

                BkgSubirImagen.RunWorkerAsync(idCliente.ToString());
            }
        }



        private bool ValidarTamanoLogo(Image archivo, int limiteW, int limiteH)
        {
            using (var img = new Bitmap(archivo))
            {
                if (img.Width > limiteW || img.Height > limiteH)
                    return false;
            }

            return true;
        }

        private void BorrarRegistroContacto(int idRegistro)
        {
            clienteContacto.CargarDatos(idRegistroContacto);
            clienteContacto.BorrarDatos();
        }

        private void EditarContacto(int idContacto)
        {
            clienteContacto.CargarDatos(idContacto);
            FrmEditarContacto editarContacto = new FrmEditarContacto();

            editarContacto.nombre = clienteContacto.Fila().Celda("nombre").ToString();
            editarContacto.apellido = clienteContacto.Fila().Celda("apellidos").ToString();
            editarContacto.numeroCelular = clienteContacto.Fila().Celda("celular").ToString();
            editarContacto.numeroTel1 = clienteContacto.Fila().Celda("tel1").ToString();
            editarContacto.numeroTel2 = clienteContacto.Fila().Celda("tel2").ToString();
            editarContacto.correo = clienteContacto.Fila().Celda("correo").ToString();
            editarContacto.EditarTitulo = "EDITAR CONTACTO";
            editarContacto.EditarBoton = "Guardar";
            if (editarContacto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clienteContacto.Fila().ModificarCelda("nombre", editarContacto.nombre);
                clienteContacto.Fila().ModificarCelda("apellidos", editarContacto.apellido);
                clienteContacto.Fila().ModificarCelda("celular", editarContacto.numeroCelular);
                clienteContacto.Fila().ModificarCelda("tel1", editarContacto.numeroTel1);

                if (editarContacto.numeroTel2 == "")
                    clienteContacto.Fila().ModificarCelda("tel2", "N/A");
                else
                    clienteContacto.Fila().ModificarCelda("tel2", editarContacto.numeroTel2);

                clienteContacto.Fila().ModificarCelda("correo", editarContacto.correo);
                clienteContacto.GuardarDatos();
                CargarDatosContacto(idCliente);
            }
        }

        private void AgregarContacto()
        {
            FrmEditarContacto nuevoContacto = new FrmEditarContacto();
            if (nuevoContacto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila contactoNue = new Fila();
                contactoNue.AgregarCelda("cliente", idCliente);
                contactoNue.AgregarCelda("nombre", nuevoContacto.nombre);
                contactoNue.AgregarCelda("apellidos", nuevoContacto.apellido);
                contactoNue.AgregarCelda("celular", nuevoContacto.numeroCelular);
                contactoNue.AgregarCelda("tel1", nuevoContacto.numeroTel1);

                if (nuevoContacto.numeroTel2 == "")
                    contactoNue.AgregarCelda("tel2", "N/A");
                else
                    contactoNue.AgregarCelda("tel2", nuevoContacto.numeroTel2);

                contactoNue.AgregarCelda("correo", nuevoContacto.correo);
                ClienteContacto.Modelo().Insertar(contactoNue);
                CargarDatosContacto(idCliente);
            }
        }

        private void DgvListaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaClientes.SelectedRows.Count > 0)
            {
                idCliente = Convert.ToInt32(DgvListaClientes.SelectedRows[0].Cells["id"].Value);

                PBImage.Image = null;
                cliente.CargarDatos(idCliente);

                if (cliente.Fila().Celda<int>("logo_en_servidor") > 0)
                {
                    splitContainer1.Panel1.Enabled = false;
                    tabControl1.Enabled = false;
                    DgvContactos.Enabled = false;
                    Lblstatus.Visible = true;
                    Progreso.Visible = true;
                    Progreso.Value = 0;

                    BkgDescargarImagen.RunWorkerAsync(idCliente);
                }
                else
                {
                    PBImage.Image = CB_Base.Properties.Resources.image_not_found;
                }

                CargarDatosCliente();
                CargarDatosContacto(idCliente);
                BtnAgregarContacto.Enabled = true;
                btnEliminarContacto.Enabled = false;
                BtnEditarContacto.Enabled = false;
                LblInfo.Visible = false;
                BtnNuevoCliente.Text = "Nuevo cliente";
                BtnEditarCliente.Text = "Editar";
                LblNombreUsuario.Text = cliente.Fila().Celda("nombre").ToString();

                int estatus = Convert.ToInt32(cliente.Fila().Celda("activo"));

                if (1 == estatus)
                    ChkClienteActivo.Checked = true;

                else
                    ChkClienteActivo.Checked = false;

                DesactivarEdicion();
            }
        }

        private void TxtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(TxtFiltroCliente.Text, ChkMostrarInactivos.Checked);
            BtnNuevoCliente.Text = "Nuevo cliente";
        }

        private void ChkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarClientes(TxtFiltroCliente.Text, ChkMostrarInactivos.Checked);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            switch (BtnEditarCliente.Text)
            {
                case "Editar":
                    BtnEditarCliente.Text = "Guardar";
                    ActivarEdicion();
                    LblNombreUsuario.Text = "EDITAR CLIENTE";
                    break;

                case "Guardar":
                    GuardarEdicion(abreviacion);
                    break;
            }
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        { 
            if (BtnNuevoCliente.Text == "Nuevo cliente")
            { 
                LimpiarGridContacto();
                BtnNuevoCliente.Text = "Crear cliente";
                LblNombreUsuario.Text = "NUEVO CLIENTE";

                GrbDatosClientes.Visible = true;
                LimpiarTexbox();
                ChkClienteActivo.Checked = true;
                ActivarEdicion();
            }
            else if (BtnNuevoCliente.Text == "Crear cliente")
                NuevoContacto();
        }

        private void DgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAgregarContacto.Enabled = true;
            BtnEditarContacto.Enabled = true;
            btnEliminarContacto.Enabled = true;
            LblInfo.Visible = false;

            if (DgvContactos.SelectedRows.Count > 0)
                idRegistroContacto = Convert.ToInt32(DgvContactos.SelectedRows[0].Cells["id_registro"].Value);
        }

        private void btnEliminarContacto_Click(object sender, EventArgs e)
        {
            BorrarRegistroContacto(idRegistroContacto);
            CargarDatosContacto(idCliente);
            BtnEditarContacto.Enabled = false;
            btnEliminarContacto.Enabled = false;
        }

        private void BtnAgregarContacto_Click(object sender, EventArgs e)
        {
            AgregarContacto();
        }

        private void BtnEditarContacto_Click(object sender, EventArgs e)
        {
            EditarContacto(idRegistroContacto);
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                PBImage.Image = null;
                PBImage.Image = Clipboard.GetImage();
            }
            else
            {
                PBImage.Image = CB_Base.Properties.Resources.image_not_found;
                MessageBox.Show("El elemento que intenta pegar no es una imagen", "Seleccione una imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MenuCopiarImagen_Opening(object sender, CancelEventArgs e)
        {
            pegarToolStripMenuItem.Visible = (!TxtNombre.ReadOnly);
        }

        private void BkgSubirImagen_DoWork(object sender, DoWorkEventArgs e)
        {
            string strCliente = (string)e.Argument + ".PNG";
            cliente.Fila().ModificarCelda("logo_en_servidor", 1);
            cliente.GuardarDatos();

            BkgSubirImagen.ReportProgress(10, "Subiendo imagen");

            ServidorFtp.SubirImagen(Datos, PathString, strCliente, BkgSubirImagen);
        }

        private void BkgSubirImagen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Lblstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgSubirImagen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Datos = null;
            splitContainer1.Panel1.Enabled = true;
            tabControl1.Enabled = true;
            DgvContactos.Enabled = true;
            Lblstatus.Visible = false;
            Progreso.Visible = false;
            Progreso.Value = 0;

        }

        private void BkgDescargarImagen_DoWork(object sender, DoWorkEventArgs e)
        {
            int idDocumento = (int)e.Argument;
            e.Result = ServidorFtp.DescargarArchivo(idDocumento, FormatoArchivo.Png, PathString);
        }

        private void BkgDescargarImagen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Lblstatus.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgDescargarImagen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            byte[] datos = (byte[])e.Result;

            if(datos != null)
                PBImage.Image = Global.ByteAImagen(datos);
            else
                PBImage.Image = CB_Base.Properties.Resources.image_not_found;

            splitContainer1.Panel1.Enabled = true;
            tabControl1.Enabled = true;
            DgvContactos.Enabled = true;
            Lblstatus.Visible = false;
            Progreso.Visible = false;
            Progreso.Value = 0;
           
        }
    }
}