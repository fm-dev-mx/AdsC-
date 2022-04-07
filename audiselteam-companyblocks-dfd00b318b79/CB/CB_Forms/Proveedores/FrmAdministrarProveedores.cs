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
using OfficeOpenXml;
using System.IO;

namespace CB
{
    public partial class FrmAdministrarProveedores : Form
    {
        Proveedor proveedor = new Proveedor();
        ProveedorFabricacion provFabricacion = new ProveedorFabricacion();
        ProveedorContacto provContacto = new ProveedorContacto();
        string abreviacion = "";
        int IdRegistroContacto = 0;
        int IdProveedor = 0;
        public FrmAdministrarProveedores()
        {
            InitializeComponent();
        }

        private void FrmAdministrarProveedores_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            LblInfo.Visible = false;
            CargarProveedores(TxtFiltroProveedor.Text, ChkMostrarInactivos.Checked);
        }

        private void DesahabilitarBotones()
        {
            GrbDatosProveedor.Visible = false;
            BtnEditarUsuario.Enabled = false;
            BtnAgregarContacto.Enabled = false;
            btnEliminarContacto.Enabled = false;
            BtnEditarContacto.Enabled = false;
            ChkProveedorActivo.Enabled = false;
            chkProveedorGeneral.Enabled = false;
            ChkproveedorFabricacion.Enabled = false;
        }

        public void CargarProveedores(string filtro, bool mostrarInactivo)
        {
            DesahabilitarBotones();
            
            int seleccionarFila = Global.GuardarFilaSeleccionada(DgvListaProveedores);
            DgvListaProveedores.Rows.Clear();

            Proveedor.Modelo().Filtrar(TxtFiltroProveedor.Text, Convert.ToInt32(ChkMostrarInactivos.Checked)).ForEach(delegate(Fila filaActual)
            {
                int activo = Convert.ToInt32(filaActual.Celda("activo"));
                string activoTexto = "";

                switch (activo)
                {
                    case 1:
                        activoTexto = "SI";
                        break;
                    case 0:
                        activoTexto = "NO";
                        break;
                }

                DgvListaProveedores.Rows.Add( filaActual.Celda("id"),filaActual.Celda("nombre"), activoTexto);
            });

            Global.RecuperarFilaSeleccionada(DgvListaProveedores, seleccionarFila);
        }

        public void cargarDatosContacto(int idProveedor)
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvContactos);
            DgvContactos.Rows.Clear();

            ProveedorContacto.Modelo().CargarDeProveedor(idProveedor).ForEach(delegate(Fila contacto)
            {
                DgvContactos.Rows.Add(contacto.Celda("nombre").ToString(), contacto.Celda("apellidos").ToString(), contacto.Celda("celular").ToString(), contacto.Celda("tel1").ToString(), contacto.Celda("tel2").ToString(), contacto.Celda("correo").ToString(),contacto.Celda("id").ToString());
            });

            Global.RecuperarFilaSeleccionada(DgvContactos, filaSeleccionada);
        }

        public void cargarDatosProveedor()
        {
            abreviacion = proveedor.Fila().Celda("abreviacion").ToString();
            TxtNombre.Text = proveedor.Fila().Celda("nombre").ToString();
            TxtColonia.Text = proveedor.Fila().Celda("colonia").ToString();
            TxtCalle.Text = proveedor.Fila().Celda("calle").ToString();
            Txtnumero.Text = proveedor.Fila().Celda("numero").ToString();
            TxtCP.Text = proveedor.Fila().Celda("cp").ToString();
            TxtRazonSocial.Text = proveedor.Fila().Celda("razon_social").ToString();
            TxtAbreviacion.Text = proveedor.Fila().Celda("abreviacion").ToString();
            TxtEstado.Text = proveedor.Fila().Celda("estado").ToString();
            TxtCiudad.Text = proveedor.Fila().Celda("ciudad").ToString();
            string categoria = Global.ObjetoATexto(proveedor.Fila().Celda("categoria"), string.Empty);
            if (categoria == string.Empty)
                categoria = "SELECCIONAR";
            CmbCategoria.Text = categoria;
            GrbDatosProveedor.Visible = true;
            BtnEditarUsuario.Enabled = true;
        }

        public void nuevoProveedor()
        {
            ChkProveedorActivo.Checked = true;
            if (validarCampos())
            {
                LblInfo.Visible = true;
                LblInfo.Text = "Ingrese la informacion completa ";
            }

            else
            {
                if (Proveedor.Modelo().Existe(TxtRazonSocial.Text.Trim()) || Proveedor.Modelo().ExisteAbreviacion(TxtAbreviacion.Text.Trim()))
                    MessageBox.Show("Este proveedor ya fue registrado anteriormente!, la razón social o la abreviacion ya fueron registradas");

                else
                {
                    int activo = Convert.ToInt32(ChkProveedorActivo.Checked);
                    Fila prov = new Fila();

                    prov.AgregarCelda("nombre", TxtNombre.Text.Trim());
                    prov.AgregarCelda("calle", TxtCalle.Text.Trim());
                    prov.AgregarCelda("colonia", TxtColonia.Text.Trim());
                    prov.AgregarCelda("numero", Txtnumero.Text.Trim());
                    prov.AgregarCelda("cp", TxtCP.Text.Trim());
                    prov.AgregarCelda("razon_social", TxtRazonSocial.Text.Trim());
                    prov.AgregarCelda("abreviacion", TxtAbreviacion.Text.Trim());
                    prov.AgregarCelda("ciudad", TxtCiudad.Text.Trim());
                    prov.AgregarCelda("estado", TxtEstado.Text.Trim());
                    prov.AgregarCelda("categoria", CmbCategoria.Text);
                    prov.AgregarCelda("activo", activo);
                    Proveedor.Modelo().Insertar(prov);
                    
                    if (ChkProveedorWeb.Checked)
                    {
                        proveedor.SeleccionarNombre(TxtNombre.Text.Trim(), TxtAbreviacion.Text.Trim());
                        int idNuevoPRovedor = (int) proveedor.Fila().Celda("id");
                        CreaContactoWeb(idNuevoPRovedor);
                    }

                    LblInfo.Text = "";
                    BtnNuevoProveedor.Text = "Nuevo proveedor";
                    LblNombreUsuario.Text = "SELECCIONA UN PROVEEDOR";
                    desactivarEdicion();
                    CargarProveedores(TxtFiltroProveedor.Text, ChkMostrarInactivos.Checked);
                }
            }
        }

        void activarEdicion()
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
            ChkProveedorActivo.Visible = true;
            ChkProveedorActivo.Enabled = true;
            ChkproveedorFabricacion.Enabled = true;
            ChkProveedorWeb.Enabled = true;
            CmbCategoria.Enabled = true;
        }

        void desactivarEdicion()
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
            ChkproveedorFabricacion.Enabled = false;
            ChkProveedorActivo.Enabled = false;
            ChkProveedorWeb.Enabled = false;
            CmbCategoria.Enabled = false;
        }

        void limpiarTexbox()
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
            CmbCategoria.SelectedText = "SELECCIONAR";
        }

        private void guardarEdicion(string abreviacion)
        {
            if (validarCampos())
            {
                LblInfo.Visible = true;
                LblInfo.Text = "Ingrese la informacion completa ";
            }
            else
            {
                provFabricacion.SeleccionarProveedor(IdProveedor);

                if (!provFabricacion.Existe(IdProveedor) && ChkproveedorFabricacion.Checked)
                {
                    Fila fabricacionProv = new Fila();
                    fabricacionProv.AgregarCelda("proveedor", IdProveedor);
                    ProveedorFabricacion.Modelo().Insertar(fabricacionProv);
                    provFabricacion.GuardarDatos();
                }

                else if (provFabricacion.Existe(IdProveedor) && !ChkproveedorFabricacion.Checked)
                    provFabricacion.BorrarDatos();

                LblInfo.Visible = false;
                LblInfo.Text = "Info";
                proveedor.Fila().ModificarCelda("nombre", TxtNombre.Text.Trim());
                proveedor.Fila().ModificarCelda("colonia", TxtColonia.Text.Trim());
                proveedor.Fila().ModificarCelda("calle", TxtCalle.Text.Trim());
                proveedor.Fila().ModificarCelda("numero", Txtnumero.Text.Trim());
                proveedor.Fila().ModificarCelda("razon_social", TxtRazonSocial.Text.Trim());
                proveedor.Fila().ModificarCelda("cp", TxtCP.Text.Trim());
                
                if (abreviacion != TxtAbreviacion.Text)
                    proveedor.Fila().ModificarCelda("abreviacion", TxtAbreviacion.Text.Trim());

                proveedor.Fila().ModificarCelda("ciudad", TxtCiudad.Text.Trim());
                proveedor.Fila().ModificarCelda("estado", TxtEstado.Text.Trim());
                proveedor.Fila().ModificarCelda("categoria", CmbCategoria.Text);
                proveedor.Fila().ModificarCelda("activo", Convert.ToInt32(ChkProveedorActivo.Checked));
                proveedor.GuardarDatos();

                if (ChkProveedorWeb.Checked && !provContacto.ExisteProveedorWeb(IdProveedor))
                    CreaContactoWeb(IdProveedor);

                else if (!ChkProveedorWeb.Checked && provContacto.ExisteProveedorWeb(IdProveedor))
                    BorrarContactoWeb();

                desactivarEdicion();

                BtnEditarUsuario.Text = "     Editar";
                LblNombreUsuario.Text = "SELECCIONA UN PROVEEDOR";
                CargarProveedores(TxtFiltroProveedor.Text, ChkMostrarInactivos.Checked);
                DgvContactos.Rows.Clear();
            }
        }

        private bool validarCampos()
        {
            if (String.IsNullOrWhiteSpace(TxtNombre.Text) || String.IsNullOrWhiteSpace(TxtCiudad.Text) || String.IsNullOrWhiteSpace(TxtEstado.Text) || String.IsNullOrWhiteSpace(TxtColonia.Text) || String.IsNullOrWhiteSpace(TxtCalle.Text) || String.IsNullOrWhiteSpace(Txtnumero.Text) || String.IsNullOrWhiteSpace(TxtRazonSocial.Text) || String.IsNullOrWhiteSpace(TxtCP.Text) || CmbCategoria.Text == "SELECCIONAR" || CmbCategoria.Text == "")
                return true;
            else
                return false;
        }

        private void borrarRegistroContacto(int idRegistro)
        {
            provContacto.CargarDatos(idRegistro);
            provContacto.BorrarDatos();
        }

        private void CreaContactoWeb(int idProvWeb)
        {
            if (!provContacto.ExisteProveedorWeb(idProvWeb))
            {
                Fila registroProvedorWeb = new Fila();
                registroProvedorWeb.AgregarCelda("nombre", "PAGINA");
                registroProvedorWeb.AgregarCelda("apellidos", "WEB");
                registroProvedorWeb.AgregarCelda("celular", "N/A");
                registroProvedorWeb.AgregarCelda("proveedor", idProvWeb);
                registroProvedorWeb.AgregarCelda("tel1", "N/A");
                registroProvedorWeb.AgregarCelda("tel2", "N/A");
                registroProvedorWeb.AgregarCelda("correo", "");

                provContacto.Insertar(registroProvedorWeb);
                provContacto.GuardarDatos();
            }
        }

        private void EditarContacto(int idContacto)
        {
            provContacto.CargarDatos(idContacto);
            FrmEditarContacto editContacto = new FrmEditarContacto();

            editContacto.nombre = provContacto.Fila().Celda("nombre").ToString();
            editContacto.apellido = provContacto.Fila().Celda("apellidos").ToString();
            editContacto.numeroCelular = provContacto.Fila().Celda("celular").ToString();
            editContacto.numeroTel1 = provContacto.Fila().Celda("tel1").ToString();
            editContacto.numeroTel2 = provContacto.Fila().Celda("tel2").ToString();
            editContacto.correo = provContacto.Fila().Celda("correo").ToString();
            editContacto.EditarTitulo = "EDITAR CONTACTO";
            editContacto.EditarBoton = "     Guardar";

            if (editContacto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                provContacto.Fila().ModificarCelda("nombre", editContacto.nombre);
                provContacto.Fila().ModificarCelda("apellidos", editContacto.apellido);
                provContacto.Fila().ModificarCelda("celular", editContacto.numeroCelular);
                provContacto.Fila().ModificarCelda("tel1", editContacto.numeroTel1);

                if (editContacto.numeroTel2 == "")
                    provContacto.Fila().ModificarCelda("tel2", "N/A");

                else
                    provContacto.Fila().ModificarCelda("tel2", editContacto.numeroTel2);

                provContacto.Fila().ModificarCelda("correo", editContacto.correo);
                provContacto.GuardarDatos();
                cargarDatosContacto(IdProveedor);
            }
        }

        private void AgregarContacto()
        {
            FrmEditarContacto nuevoContacto = new FrmEditarContacto();
            if (nuevoContacto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Fila contactoNue = new Fila();

                contactoNue.AgregarCelda("proveedor", IdProveedor);
                contactoNue.AgregarCelda("nombre", nuevoContacto.nombre);
                contactoNue.AgregarCelda("apellidos", nuevoContacto.apellido);
                contactoNue.AgregarCelda("celular", nuevoContacto.numeroCelular);
                contactoNue.AgregarCelda("tel1", nuevoContacto.numeroTel1);

                if (nuevoContacto.numeroTel2 == "")
                    contactoNue.AgregarCelda("tel2", "N/A");
                else
                    contactoNue.AgregarCelda("tel2", nuevoContacto.numeroTel2);

                contactoNue.AgregarCelda("correo", nuevoContacto.correo);
                ProveedorContacto.Modelo().Insertar(contactoNue);
                cargarDatosContacto(IdProveedor);
            }
        }

        private void BorrarContactoWeb()
        {
            provContacto.BorrarWeb(IdProveedor);
            provContacto.BorrarDatos();
        }

        private void TxtFiltroProveedor_TextChanged(object sender, EventArgs e)
        {
            CargarProveedores(TxtFiltroProveedor.Text, ChkMostrarInactivos.Checked);
            BtnNuevoProveedor.Text = "Nuevo proveedor";
        }

        private void ChkMostrarInactivos_CheckedChanged(object sender, EventArgs e)
        {
            CargarProveedores(TxtFiltroProveedor.Text, ChkMostrarInactivos.Checked);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvListaProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaProveedores.SelectedRows.Count > 0)
            {
                IdProveedor = Convert.ToInt32(DgvListaProveedores.SelectedRows[0].Cells["id"].Value);

                if(provFabricacion.Existe(IdProveedor))
                    ChkproveedorFabricacion.Checked = true;

                else
                    ChkproveedorFabricacion.Checked = false;

                proveedor.CargarDatos(IdProveedor);
                cargarDatosProveedor();
                cargarDatosContacto(IdProveedor);
                BtnAgregarContacto.Enabled = true;
                btnEliminarContacto.Enabled = false;
                BtnEditarContacto.Enabled = false;
                LblInfo.Visible = false;
                BtnNuevoProveedor.Text = "Nuevo proveedor";
                BtnEditarUsuario.Text = "     Editar";
                LblNombreUsuario.Text = proveedor.Fila().Celda("nombre").ToString();
                int estatus = Convert.ToInt32(proveedor.Fila().Celda("activo"));

                if (estatus == 1)
                    ChkProveedorActivo.Checked = true;

                else
                    ChkProveedorActivo.Checked = false;

                if (provContacto.ExisteProveedorWeb(IdProveedor))
                    ChkProveedorWeb.Checked = true;

                else
                    ChkProveedorWeb.Checked = false;

                desactivarEdicion();
            }
        }

        private void BtnEditarUsuario_Click(object sender, EventArgs e)
        {
            switch (BtnEditarUsuario.Text.Trim())
            {
                case "Editar":
                    BtnEditarUsuario.Text = "     Guardar";
                    activarEdicion();
                    LblNombreUsuario.Text = "EDITAR PROVEEDOR";
                    break;

                case "Guardar":
                    guardarEdicion(abreviacion);
                    break;
            }
        }

        private void limpiarGridContacto()
        {
            DgvContactos.Rows.Clear();
            LblInfo.Visible = false;
            BtnEditarContacto.Enabled = false;
            BtnAgregarContacto.Enabled = false;
            btnEliminarContacto.Enabled = false;
        }

        private void BtnNuevoUsuario_Click(object sender, EventArgs e)
        {
            switch (BtnNuevoProveedor.Text)
            {
                case "Nuevo proveedor":
                    
                    BtnNuevoProveedor.Text = "Crear proveedor";
                    LblNombreUsuario.Text = "NUEVO PROVEEDOR";
                
                    ChkProveedorWeb.Checked = false;
                    ChkProveedorActivo.Checked = true;
                    GrbDatosProveedor.Visible = true;
                
                    limpiarGridContacto();
                    limpiarTexbox();
                    activarEdicion();
                    break;

                case "Crear proveedor":
                    nuevoProveedor();
                    break;
            }
        }

        private void DgvContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnAgregarContacto.Enabled = true;
            BtnEditarContacto.Enabled = true;
            btnEliminarContacto.Enabled = true;
            LblInfo.Visible = false;

            if (DgvContactos.SelectedRows.Count > 0)
                IdRegistroContacto = Convert.ToInt32(DgvContactos.SelectedRows[0].Cells["id_registro"].Value);
        }

        private void btnEliminarContacto_Click(object sender, EventArgs e)
        {
            borrarRegistroContacto(IdRegistroContacto);
            cargarDatosContacto(IdProveedor);
            BtnEditarContacto.Enabled = false;
            btnEliminarContacto.Enabled = false;
        }

        private void BtnAgregarContacto_Click(object sender, EventArgs e)
        {
            AgregarContacto();
        }

        private void BtnEditarContacto_Click(object sender, EventArgs e)
        {
            EditarContacto(IdRegistroContacto);
        }

        private void ChkProveedorWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkProveedorWeb.Checked)
                BtnAgregarContacto.Enabled = false;

            else if (!ChkProveedorWeb.Checked && BtnNuevoProveedor.Text == "Nuevo proveedor")
                BtnAgregarContacto.Enabled = true;
        }

        private void BtnEvaluar_Click(object sender, EventArgs e)
        {
            if (IdProveedor <= 0)
                return;

            EvaluacionProveedor evaluacionesProveedor = new EvaluacionProveedor();
            List<Fila> ListaEvaluacion = evaluacionesProveedor.VerificarEvaluacionPendiente(IdProveedor);

            //existe una evaluacion pendiente
            if (evaluacionesProveedor.TieneFilas())
            {
                FrmEvaluarDesempenoProveedores desempenoProveedores = new FrmEvaluarDesempenoProveedores(ListaEvaluacion, "PROVEEDOR");
                if(desempenoProveedores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Subir o bajar a proveedor de categoria
                    //en base a las últimas 3 evaluaciones
                    // 80=> A
                    // 80 < B
                    int categoriaA = 0;
                    List<Fila> proveedores = evaluacionesProveedor.Seleccionar3UltimasEvaluaciones(IdProveedor);

                    if (proveedores.Count < 3)
                        return;

                    proveedores.ForEach(delegate(Fila f)
                    {
                        if(Convert.ToInt32(f.Celda("resultado").ToString()) >= 80)
                            categoriaA++;
                    });

                    Proveedor proveedor = new Proveedor();
                    proveedor.CargarDatos(IdProveedor);

                    if (categoriaA == 3)
                    {
                        proveedor.Fila().ModificarCelda("categoria", "A");
                        CmbCategoria.Text = "A";
                    }
                    else
                    {
                        proveedor.Fila().ModificarCelda("categoria", "B");
                        CmbCategoria.Text = "B";
                    }
                    
                    proveedor.GuardarDatos();
                }
            }
            else //Se crea una nueva evaluacion
            {
                DialogResult result = MessageBox.Show("¿Desea crear una evaluación?", "Nueva evaluación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Fila nuevaEvaluacion = new Fila();
                    nuevaEvaluacion.AgregarCelda("proveedor", IdProveedor);
                    nuevaEvaluacion.AgregarCelda("evaluador", Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id").ToString()));
                    evaluacionesProveedor.Insertar(nuevaEvaluacion);
                    ListaEvaluacion.Add(nuevaEvaluacion);

                    FrmEvaluarDesempenoProveedores desempenoProveedores = new FrmEvaluarDesempenoProveedores(ListaEvaluacion, "PROVEEDOR");
                    if (desempenoProveedores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //Subir o bajar a proveedor de categoria
                        //en base a las últimas 3 evaluaciones
                        // 80=> A
                        // 80 < B
                        int categoriaA = 0;
                        List<Fila> proveedores = evaluacionesProveedor.Seleccionar3UltimasEvaluaciones(IdProveedor);

                        if (proveedores.Count < 3)
                            return;

                        proveedores.ForEach(delegate(Fila f)
                        {
                            if (Convert.ToInt32(f.Celda("resultado").ToString()) >= 80)
                                categoriaA++;
                        });

                        Proveedor proveedor = new Proveedor();
                        proveedor.CargarDatos(IdProveedor);


                        if (categoriaA == 3)
                        {
                            proveedor.Fila().ModificarCelda("categoria", "A");
                            CmbCategoria.Text = "A";
                        }
                        else
                        {
                            proveedor.Fila().ModificarCelda("categoria", "B");
                            CmbCategoria.Text = "B";
                        }

                        proveedor.GuardarDatos();
                        
                    }
                }
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEvaluacionesProveedor evaluacionesProveedor = new FrmEvaluacionesProveedor(IdProveedor);
            evaluacionesProveedor.Show();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}