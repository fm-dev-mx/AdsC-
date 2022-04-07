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
    public partial class FrmAgregarDocumento : Ventana
    {
        public string TipoDocumento = "";
        public int MesesVencimiento = 0;
        public byte[] Documento = null;
        int IdDocumento = 0;

        public FrmAgregarDocumento(int idDocumento = 0)
        {
            InitializeComponent();
            BtnAceptar.Enabled = false;
            LblNombreArchivo.Text = "";
            IdDocumento = idDocumento;
            CargarTipoDeDocumentos();

            if(idDocumento > 0)
            {
                TipoDocumentoUsuario tipo = new TipoDocumentoUsuario();
                tipo.CargarDatos(idDocumento).ForEach(delegate(Fila f)
                {
                    CmbTipoDocumento.Text = f.Celda("tipo").ToString();
                    NumMesesVencimiento.Value = Convert.ToInt32(f.Celda("meses_vigencia"));
                });

                LblTitulo.Text = "ACTUALIZAR DOCUMENTO";
                BtnAceptar.Enabled = true;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if(CmbTipoDocumento.Text == "")
            {
                MessageBox.Show("Favor de seleccionar el documento que capturará", "Seleccionar documento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TipoDocumento = CmbTipoDocumento.Text;
            MesesVencimiento = Convert.ToInt32(NumMesesVencimiento.Value);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSeleccionarArchivo_Click_1(object sender, EventArgs e)
        {
            FDArchivo.Filter = "archivos pdf|*.pdf";
            FDArchivo.DefaultExt = "pdf";
            FDArchivo.Title = "Seleccionar documento";
            FDArchivo.FileName = CmbTipoDocumento.Text;
            if (FDArchivo.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = FDArchivo.FileName;
                Documento = File.ReadAllBytes(nombreArchivo);
                BtnAceptar.Enabled = true;
            }
            LblNombreArchivo.Text = FDArchivo.SafeFileName;
        }

        private void CmbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        public void NoExisteDocumento()
        {
            DialogResult result = MessageBox.Show("El documento seleccionado no existe, ¿quieres crearlo?", "Crear tipo de documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                Fila agregarDocumento = new Fila();
                agregarDocumento.AgregarCelda("tipo", CmbTipoDocumento.Text);
                TipoDocumentoUsuario.Modelo().Insertar(agregarDocumento);
                string documentoAgregado = CmbTipoDocumento.Text;
                CargarTipoDeDocumentos();
                CmbTipoDocumento.Text = documentoAgregado;
            }
        }

        public void CargarTipoDeDocumentos()
        {
            TipoDocumentoUsuario.Modelo().SeleccionarTiposDocumentos().ForEach(delegate(Fila f)
            {
                CmbTipoDocumento.Items.Add(f.Celda("tipo").ToString());
            });
        }

        public void CargarMesesVigencia()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tipo", CmbTipoDocumento.Text);

            TipoDocumentoUsuario.Modelo().SeleccionarDatos("tipo=@tipo limit 1", parametros).ForEach(delegate(Fila f)
            {
                NumMesesVencimiento.Value = Convert.ToInt32(f.Celda("meses_vigencia"));
            });
        }

        private void CmbTipoDocumento_KeyDown(object sender, KeyEventArgs e)
        {
           /* if(e.KeyCode == Keys.Enter)
            {
                List<Fila> tipos = TipoDocumentoUsuario.Modelo().SeleccionarDocumento(CmbTipoDocumento.Text);
                if(tipos.Count <= 0)
                    NoExisteDocumento();
            }*/
        }

        private void CmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMesesVigencia();
        }
    }
}
