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
using FluentFTP;

namespace CB
{
    public partial class FrmRegistrarMaterial : Ventana
    {
        public string CategoriaSeleccionada;
        public string SubcategoriaSeleccionada;
        string CatalogoUri = @"./SGC/CATALOGOMATERIAL/";
        bool NuevaVersion = false;
        bool ContieneImagen = false;
        int IdTipoCOmpra = 0;
        int IdSubcategoria = 0;
        int IdUsuario = 0;
        byte[] ImagenByte = null;

        public FrmRegistrarMaterial(int idSubCategoria = 0, int idTipoCompra = 0, bool utilizarNuevaVersion = false)
        {
            InitializeComponent();

            IdSubcategoria = idSubCategoria;
            IdTipoCOmpra = idTipoCompra;
            NuevaVersion = utilizarNuevaVersion;
            IdUsuario = Global.UsuarioActual.Fila().Celda<int>("id");
        }

        private void FrmRegistrarMaterial_Load(object sender, EventArgs e)
        {          
            NumMaximo.Enabled = false;
            NumMinimo.Enabled = false;
            Progreso.Visible = false;
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
            CargarFabricantes();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void CargarFabricantes()
        {
            CmbFabricante.Items.Clear();

            Fabricante catalogo = new Fabricante();
            catalogo.SeleccionarFabricanteAlfabeticamente().ForEach(delegate(Fila f)
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
            return true;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@numero_parte", TxtNumeroParte.Text);

            if (CatalogoMaterial.Modelo().SeleccionarDatos("numero_parte=@numero_parte", parametros).Count > 0)
            {
                LblInfo.Text = "El numero de parte ya fue registrado anteriormente.";
                LblInfo.Visible = true;
            }
            else if( ValidarInformacion() )
            {
                LblInfo.Text = "";
                LblInfo.Visible = false;
                Progreso.Visible = true;

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
                    aplicarIva.ToString()
                };


                BkgRegistrarMaterial.RunWorkerAsync(argumentos);
            }
            else
            {
                LblInfo.Text = "Ingresa toda la informacion.";
                LblInfo.Visible = true;
            }
        }

        private void CmbUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( CmbUnidades.Text == "POR PAQUETE")
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

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
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

        private void btnRegstrarFabricante_Click(object sender, EventArgs e)
        {
            FrmRegistrarFabricante registrar = new FrmRegistrarFabricante();
            if (registrar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                 CargarFabricantes();
                 CmbFabricante.SelectedItem = registrar.NombreFabricante;
            }
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

        private void SubirImagen(byte[] bytesImagen, int  idMaterial = 0)
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

        private void BkgRegistrarMaterial_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] argumentos = (string[])e.Argument;
            string categoria = argumentos[0];
            string subcategoria = argumentos[1];
            string numeroParte = argumentos[2];
            string fabricante = argumentos[3];
            string descripcion = argumentos[4];
            string link = argumentos[5];
            string unidades = argumentos[6];
            int piezasPaquetes = Convert.ToInt32(argumentos[7]);
            int minimo = Convert.ToInt32(argumentos[8]);
            int maximo = Convert.ToInt32(argumentos[9]);
            int aplicarIva = Convert.ToInt32(argumentos[10]);

            BkgRegistrarMaterial.ReportProgress(10, "Registrando material...");
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

            BkgRegistrarMaterial.ReportProgress(20, "Registrando material...");
            if (NuevaVersion)
            {
                material.AgregarCelda("min", minimo);
                material.AgregarCelda("max", maximo);

                material.AgregarCelda("subcategoria_ref", IdSubcategoria);
            }

            Fila materialRegistrado = CatalogoMaterial.Modelo().Insertar(material);

            // Registrar fabricante si no existe
            MaterialFabricante fabricantesLista = new MaterialFabricante();
            fabricantesLista.SeleccionarFabricante(fabricante);

            if (!fabricantesLista.TieneFilas())
            {
                Fila nuevoFabricante = new Fila();
                nuevoFabricante.AgregarCelda("fabricante", fabricante);
                fabricantesLista.Insertar(nuevoFabricante);
            }

            BkgRegistrarMaterial.ReportProgress(30, "Registrando material...");

            //subir imagen
            if (ContieneImagen)
                SubirImagen(ImagenByte, Convert.ToInt32(materialRegistrado.Celda("id")));

            BkgRegistrarMaterial.ReportProgress(80, "Registrando material...");

            Evento.Modelo().Crear("Validación de material solicitada", "Se ha solicitado la validación del número de parte " + TxtNumeroParte.Text + " por " + Global.UsuarioActual.NombreCompleto(), "COMPRADOR", "COMPRADOR");
            BkgRegistrarMaterial.ReportProgress(100, "Registrando material...");
            e.Result = true;
        }

        private void BkgRegistrarMaterial_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LblInfo.ForeColor = Color.Black;
            LblInfo.Font = new Font(LblInfo.Font, FontStyle.Regular);

            LblInfo.Text = e.UserState.ToString();
            Progreso.Value = e.ProgressPercentage;
        }

        private void BkgRegistrarMaterial_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result)
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                MessageBox.Show("No se pudo registrar el material");
        }

        private void ImagenMaterial_Click(object sender, EventArgs e)
        {

        }

        // PACO EL CHATO NO ESTA MUERTO
    }
}
