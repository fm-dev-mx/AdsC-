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
using FluentFTP;


namespace CB
{
    public partial class FrmRegistrarMaterialUrgente : Form
    {
        BindingSource comprasTipoBinding = new BindingSource();
        BindingSource categoriaoBinding = new BindingSource();
        BindingSource subcategoriaBinding = new BindingSource();

        public string CategoriaSeleccionada;
        public string SubcategoriaSeleccionada;
        string CatalogoUri = @"./SGC/CATALOGOMATERIAL/";
        bool NuevaVersion = false;
        bool ContieneImagen = false;
        int IdTipoCOmpra = 0;
        int IdSubcategoria = 0;
        int IdUsuario = 0;
        int IdProveedor = 0;
        byte[] ImagenByte = null;
        decimal IdProyecto = 0;


        public FrmRegistrarMaterialUrgente(decimal idProyecto)
        {
            IdProyecto = idProyecto;
            InitializeComponent();
        }

        private void FrmRegistrarMaterialUrgente_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            CargarTipoMaterial();
            Progreso.Visible = false;
        }

        private void CargarTipoMaterial()
        {
            comprasTipoBinding.Clear();
             ComprasTipos comprasTipos = new ComprasTipos();
            comprasTipos.SeleccionarTodo().ForEach(delegate (Fila f)
            {
                comprasTipoBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = Convert.ToInt32(f.Celda("id"))
                });
            });

            CmbTipoCompra.DisplayMember = "Text";
            CmbTipoCompra.ValueMember = "Value";
            CmbTipoCompra.DataSource = comprasTipoBinding;

            if (CmbTipoCompra.Items.Count > 0)
                CmbTipoCompra.SelectedIndex = 0;
        }

        private void CargarCategorias(int idTipo)
        {
            categoriaoBinding.Clear();
             CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.SeleccionCategoriasDeTipoCompra(idTipo).ForEach(delegate (Fila f)
            {
                categoriaoBinding.Add(new
                {
                    Text = f.Celda("categoria").ToString(),
                    Value = Convert.ToInt32(f.Celda("id"))
                });
            });

            CmbCategoria.DisplayMember = "Text";
            CmbCategoria.ValueMember = "Value";
            CmbCategoria.DataSource = categoriaoBinding;

        }

        private void CargarSubcategorias(int idCategoria)
        {
            subcategoriaBinding.Clear();
            CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
            subcategoria.SeleccionarSubCategoriasDeCategoria(idCategoria).ForEach(delegate (Fila f)
            {
                subcategoriaBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = Convert.ToInt32(f.Celda("id"))
                });
            });

            CmbSubcategoria.DisplayMember = "Text";
            CmbSubcategoria.ValueMember = "Value";
            CmbSubcategoria.DataSource = subcategoriaBinding;

        }

        private void CargarFabricantes()
        {
            CmbFabricante.Items.Clear();

            Fabricante catalogo = new Fabricante();
            catalogo.SeleccionarFabricanteAlfabeticamente().ForEach(delegate (Fila f)
            {
                CmbFabricante.Items.Add(f.Celda("nombre"));
                CmbFabricante.AutoCompleteCustomSource.Add(f.Celda("nombre").ToString());
            });
        }

        bool ValidarInformacion()
        {
            if (TxtNumeroParte.Text == "")
                return false;
            if (CmbFabricante.Text == "")
                return false;
            if (TxtDescripcion.Text == "")
                return false;
            if (NumPiezasPaquete.Value < 1)
                return false;
            if (CmbUnidades.Text == "")
                return false;
           if (CmbUnidades.Text == "")
                return false;
            if (Convert.ToDecimal(numCantidad.Value) <= 0)
                return false;
            if (Convert.ToDecimal(NumPrecioUnitario.Value) <= 0)
                return false;
            if (CmbMoneda.Text == "")
                return false;
            if (Convert.ToDecimal(NumTiempoEntrega.Value) <= 0)
                return false;
            if (CmbTiempo.Text == "")
                return false;
            if (TxtProveedor.Text == "")
                return false;
            return true;
        }

        private void CmbTipoCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCategorias(Convert.ToInt32(CmbTipoCompra.SelectedValue));
        }

        private void CmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaSeleccionada = CmbCategoria.Text;
            CargarSubcategorias(Convert.ToInt32(CmbCategoria.SelectedValue));
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel2.Enabled == false)
                panel2.Enabled = true;

            CargarFabricantes();
            NumMaximo.Enabled = false;
            NumMinimo.Enabled = false;
            ChkIva.Checked = true;
            ChkIva.Enabled = (Global.VerificarPrivilegio("COMPRAS", "CREAR PO"));

            ImagenMaterial.SizeMode = PictureBoxSizeMode.StretchImage;
            ImagenMaterial.Image = CB_Base.Properties.Resources.manu_prod;

            if (NuevaVersion)
            {
                ComprasTipos comprasTipo = new ComprasTipos();
                comprasTipo.SeleccionarDatos("nombre IN ('MATERIA PRIMA COMUN', 'M.R.O.')", null);
                int tipoCompra = comprasTipo.Fila().Celda<int>("id");

                PnlMinMax.Enabled = (tipoCompra == IdTipoCOmpra);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                ImageConverter converter = new ImageConverter();
                ImagenMaterial.Image = Clipboard.GetImage();
                ContieneImagen = true;
            }
            else
            {
                ContieneImagen = false;
                ImagenMaterial.Image = CB_Base.Properties.Resources.manu_prod;
                MessageBox.Show("Debe copiar una imagen antes de pegarla");
            }
        }

        private void btnRegstrarFabricante_Click(object sender, EventArgs e)
        {
            FrmRegistrarFabricante registrar = new FrmRegistrarFabricante();
            if (registrar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CargarFabricantes();
                CmbFabricante.SelectedItem = registrar.NombreFabricante;
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea crear la requisición de forma urgente?", "Crear requisición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            CategoriaSeleccionada = CmbSubcategoria.Text;
            SubcategoriaSeleccionada = CmbSubcategoria.Text;
            IdSubcategoria = Convert.ToInt32(CmbSubcategoria.SelectedValue);
            IdTipoCOmpra = Convert.ToInt32(CmbTipoCompra.SelectedValue);
            IdUsuario = Global.UsuarioActual.Fila().Celda<int>("id");

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numero_parte", TxtNumeroParte.Text);

            if (CatalogoMaterial.Modelo().SeleccionarDatos("numero_parte=@numero_parte", parametros).Count > 0)
            {
                MessageBox.Show("El numero de parte ya fue registrado anteriormente.", "Material duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else if (ValidarInformacion())
            {
                Progreso.Visible = true;
                LblInfo.Text = "";
                LblInfo.Visible = true;

                ImagenByte = Global.ImagenByte(ImagenMaterial.Image);
                int aplicarIva = 1;
                if (!ChkIva.Checked)
                    aplicarIva = 0;

                string[] argumentos = new string[] {
                    CategoriaSeleccionada,
                    SubcategoriaSeleccionada,
                    TxtNumeroParte.Text,
                    CmbFabricante.Text,
                    TxtDescripcion.Text,
                    TxtLink.Text,
                    CmbUnidades.Text,
                    NumPiezasPaquete.Value.ToString(),
                    NumMinimo.Value.ToString(),
                    NumMaximo.Value.ToString(),
                    aplicarIva.ToString(),
                    NumPrecioUnitario.Value.ToString(),
                    CmbMoneda.Text,
                    NumTiempoEntrega.Value.ToString(),
                    CmbTiempo.Text,
                    numCantidad.Value.ToString(),
                    CmbTipoCompra.Text,
                    IdProveedor.ToString()
                };


                BkgRegistrarMat.RunWorkerAsync(argumentos);
            }
            else
            {
                MessageBox.Show("Ingresa toda la informacion.", "Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void CmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CmbUnidades.Text == "POR PAQUETE")
            {
                LblEtiquetaPiezasPorPaquete.Visible = true;
                NumPiezasPaquete.Visible = true;
            }
            else
            {
                LblEtiquetaPiezasPorPaquete.Visible = false;
                NumPiezasPaquete.Visible = false;
            }
        }

        private void CmbFabricante_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void NumMinimo_ValueChanged(object sender, EventArgs e)
        {
            if (NumMaximo.Value < NumMinimo.Value)
            {
                NumMaximo.Value = NumMinimo.Value;
            }
        }

        private void NumMaximo_ValueChanged(object sender, EventArgs e)
        {
            if (NumMinimo.Value > NumMaximo.Value)
            {
                NumMinimo.Value = NumMaximo.Value;
            }
        }

        private void SubirImagen(byte[] bytesImagen, int idMaterial = 0)
        {
            FtpClient clienteFtp = new FtpClient();
            Global.CrearConexionFTP(clienteFtp);

            if (clienteFtp.IsConnected)
            {
                if (bytesImagen != null)
                {
                    if (!clienteFtp.DirectoryExists(CatalogoUri))
                        clienteFtp.CreateDirectory(CatalogoUri);

                    clienteFtp.Upload(bytesImagen, CatalogoUri + idMaterial + ".PNG");

                    CatalogoMaterial mat = new CatalogoMaterial();
                    mat.CargarDatos(idMaterial);
                    if (mat.TieneFilas())
                    {
                        mat.Fila().ModificarCelda("imagen_servidor", 1);
                        mat.GuardarDatos();
                    }
                }
            }
        }

        private void BkgRegistrarMat_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] argumentos = (string[])e.Argument;
            string categoria = argumentos[0];
            string subcategoria = argumentos[1];
            string numeroParte = argumentos[2];
            string fabricante = argumentos[3];
            string descripcion = argumentos[4];
            string link = argumentos[5];
            string unidades = argumentos[6];
            string moneda = argumentos[12];
            string tiempo = argumentos[14];
            string tipoVenta = argumentos[16];

            int piezasPaquetes = Convert.ToInt32(argumentos[7]);
            int minimo = Convert.ToInt32(argumentos[8]);
            int maximo = Convert.ToInt32(argumentos[9]);
            int aplicarIva = Convert.ToInt32(argumentos[10]);
            int tiempoEntrega = Convert.ToInt32(argumentos[13]);
            int cantidad = Convert.ToInt32(argumentos[15]);
            int idProveedor = Convert.ToInt32(argumentos[17]);
            decimal precioUnitario = Convert.ToDecimal(argumentos[11]);

            BkgRegistrarMat.ReportProgress(5, "Registrando material...");

            Fila rfq = new Fila();
            rfq.AgregarCelda("fecha_creacion", DateTime.Now);
            rfq.AgregarCelda("usuario", Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString());
            rfq.AgregarCelda("proveedor", IdProveedor);
            rfq.AgregarCelda("contacto", 0);
            rfq.AgregarCelda("estatus", "ENVIADO");
            int idRfq = Convert.ToInt32(RfqMaterial.Modelo().Insertar(rfq).Celda("id"));

            Fila f = new Fila();
            f.AgregarCelda("rfq", idRfq);
            f.AgregarCelda("numero_parte", numeroParte);
            f.AgregarCelda("fabricante", fabricante);
            f.AgregarCelda("descripcion", descripcion);
            f.AgregarCelda("precio_unitario", precioUnitario);
            f.AgregarCelda("tiempo_entrega", tiempoEntrega);
            f.AgregarCelda("moneda", moneda);
            f.AgregarCelda("cantidad_disponible", cantidad);
            f.AgregarCelda("cantidad_estimada", cantidad);
            f.AgregarCelda("tipo_venta", tipoVenta);
            f.AgregarCelda("fecha_cotizacion", DateTime.Today);
            Fila concepto = RfqConcepto.Modelo().Insertar(f);

            BkgRegistrarMat.ReportProgress(10, "Registrando material...");

            Fila material = new Fila();
            material.AgregarCelda("categoria", categoria);
            material.AgregarCelda("subcategoria", subcategoria);
            material.AgregarCelda("numero_parte", numeroParte);
            material.AgregarCelda("fabricante", fabricante);
            material.AgregarCelda("descripcion", descripcion);
            material.AgregarCelda("link", link);
            material.AgregarCelda("tipo_venta", unidades);
            material.AgregarCelda("piezas_paquete", piezasPaquetes);
            material.AgregarCelda("usuario_registro", Global.UsuarioActual.Fila().Celda<int>("id"));
            material.AgregarCelda("fecha_registro", DateTime.Now);
            material.AgregarCelda("aplicar_iva", aplicarIva);
            material.AgregarCelda("min", minimo);
            material.AgregarCelda("max", maximo);
            material.AgregarCelda("subcategoria_ref", IdSubcategoria);
            material.AgregarCelda("registro_rapido", 1);
            Fila materialRegistrado = CatalogoMaterial.Modelo().Insertar(material);

            BkgRegistrarMat.ReportProgress(20, "Creando requisición...");
            int idCatalogo = Convert.ToInt32(materialRegistrado.Celda("id"));
            int idRfqConcepto = Convert.ToInt32(concepto.Celda("id"));
            CrearRequisicionMaterial(idCatalogo, cantidad,0,precioUnitario,tiempoEntrega,moneda, idRfqConcepto);

            // Registrar fabricante si no existe
            MaterialFabricante fabricantesLista = new MaterialFabricante();
            fabricantesLista.SeleccionarFabricante(fabricante);

            if (!fabricantesLista.TieneFilas())
            {
                Fila nuevoFabricante = new Fila();
                nuevoFabricante.AgregarCelda("fabricante", fabricante);
                fabricantesLista.Insertar(nuevoFabricante);
            }

            RelacionMaterialRfq relacionesRfq = new RelacionMaterialRfq();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@rfqOrigen", idRfq);
            parametros.Add("@numeroParte", numeroParte);
            relacionesRfq.SeleccionarDatos("id_rfq=@rfqOrigen and numero_parte=@numeroParte", parametros);

            Fila insertarRelacion = new Fila();
            insertarRelacion.AgregarCelda("numero_parte", numeroParte);
            insertarRelacion.AgregarCelda("id_rfq", idRfq);
            insertarRelacion.AgregarCelda("id_material_proyecto", materialRegistrado.Celda("id"));
            insertarRelacion.AgregarCelda("id_concepto", concepto.Celda("id"));
            RelacionMaterialRfq.Modelo().Insertar(insertarRelacion);

            BkgRegistrarMat.ReportProgress(30, "Creando requisición...");

            //subir imagen
            if (ContieneImagen)
                SubirImagen(ImagenByte, Convert.ToInt32(materialRegistrado.Celda("id")));

            BkgRegistrarMat.ReportProgress(100, "Creando requisición...");

            e.Result = true;
        }

        private void BkgRegistrarMat_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblInfo.ForeColor = Color.Black;
            LblInfo.Font = new Font(LblInfo.Font, FontStyle.Regular);

            LblInfo.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgRegistrarMat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LblInfo.Text = "";
            LblInfo.Visible = false;
            Progreso.Visible = false;

            if ((bool)e.Result)
            {
                MessageBox.Show("Requisición registrada");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("No se pudo registrar la requisición");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSeleccionarProveedor seleccionarProv = new FrmSeleccionarProveedor();
            if(seleccionarProv.ShowDialog() == DialogResult.OK)
            {
                TxtProveedor.Text = seleccionarProv.NombreProveedor.ToString();
                IdProveedor = seleccionarProv.IdProveedor;
            }
        }

        public int CrearRequisicionMaterial(int idCatalogo, int cantidad, int subensamble, decimal precioUnitario, int tiempoEntrega, string moneda, int rfqConcepto, int accesorioPara = 0)
        {
            CatalogoMaterial material = new CatalogoMaterial();
            material.CargarDatos(idCatalogo);

            int total = 0;
            int piezasPaquete = Convert.ToInt32(material.Fila().Celda("piezas_paquete"));
            int piezasStock = 0;

            if (material.Fila().Celda("tipo_venta").ToString() == "POR PAQUETE")
            {
                decimal piezasEntrePaquete = (decimal)cantidad / (decimal)piezasPaquete;
                total = (int)Math.Ceiling(piezasEntrePaquete);
                piezasStock = (total * piezasPaquete) - cantidad;
            }
            else
            {
                total = cantidad;
            }

            Fila matProyecto = new Fila();

            string requisitor = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();
            decimal idProyecto = IdProyecto;

            matProyecto.AgregarCelda("requisitor", requisitor);
            matProyecto.AgregarCelda("proyecto", idProyecto);
            matProyecto.AgregarCelda("categoria", material.Fila().Celda("categoria"));
            matProyecto.AgregarCelda("numero_parte", material.Fila().Celda("numero_parte"));
            matProyecto.AgregarCelda("fabricante", material.Fila().Celda("fabricante"));
            matProyecto.AgregarCelda("descripcion", material.Fila().Celda("descripcion"));
            matProyecto.AgregarCelda("piezas_requeridas", cantidad);
            matProyecto.AgregarCelda("piezas_stock", piezasStock);
            matProyecto.AgregarCelda("total", total);
            matProyecto.AgregarCelda("precio_unitario", precioUnitario);
            matProyecto.AgregarCelda("tiempo_entrega", tiempoEntrega);
            matProyecto.AgregarCelda("precio_suma_final", (cantidad * precioUnitario));
            matProyecto.AgregarCelda("precio_moneda", moneda);
            matProyecto.AgregarCelda("rfq_concepto", rfqConcepto);
            matProyecto.AgregarCelda("tipo_venta", material.Fila().Celda("tipo_venta"));
            matProyecto.AgregarCelda("piezas_paquete", material.Fila().Celda("piezas_paquete"));
            matProyecto.AgregarCelda("po", 0);
            matProyecto.AgregarCelda("estatus_seleccion", "DEFINIDO");

            if (Global.UsuarioActual.Fila().Celda("rol").ToString() == "COMPRADOR")
            {
                matProyecto.AgregarCelda("estatus_compra", "EN REVISION TECNICA");
            }
            else
            {
                matProyecto.AgregarCelda("fecha_promesa_compras", DateTime.Today);
                matProyecto.AgregarCelda("estatus_compra", "EN REVISION FINANCIERA");
                matProyecto.AgregarCelda("estatus_autorizacion", "AUTORIZADO");
                matProyecto.AgregarCelda("usuario_autorizacion", Global.UsuarioActual.NombreCompleto());
            }

            matProyecto.AgregarCelda("accesorio_para", accesorioPara);
            matProyecto.AgregarCelda("fecha_creacion", DateTime.Now);
            matProyecto.AgregarCelda("subensamble", subensamble);
            matProyecto.AgregarCelda("subcategoria", material.Fila().Celda("subcategoria_ref"));
            matProyecto = MaterialProyecto.Modelo().Insertar(matProyecto);

            string titulo = "Nueva requisición de material";
            string contenido = "";
            contenido += Global.UsuarioActual.NombreCompleto();
            contenido += " creó la requisición de material #" + matProyecto.Celda("id").ToString() + " para el proyecto " + idProyecto.ToString();

            Evento.Modelo().Crear(titulo, contenido, "COMPRADOR");

            return Convert.ToInt32(matProyecto.Celda("id"));
        }
    }
}
