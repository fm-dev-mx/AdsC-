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
    public partial class FrmImprimirFormatoLiberacionDiseno : Form
    {
        byte[] VistaPreviaSubensamble = null;
        byte[] DatosPdf = null;
        decimal IdProyecto = 0;
        int Modulo = 0;
        int IdModulo = 0;
        bool Parcial = false;
        Usuario CargarUsuarios = new Usuario();

        public FrmImprimirFormatoLiberacionDiseno(byte[] vistaPreviaSubensamble, decimal idProyecto, bool parcial,  int modulo=0, int idModulo = 0)
        {
            InitializeComponent();
            VistaPreviaSubensamble = vistaPreviaSubensamble;
            IdProyecto = idProyecto;
            Modulo = modulo;
            IdModulo = idModulo;
            CmbContactoCliente.Enabled = true;
            CmbDisenadorMecanico.Enabled = true;
            CmbLiderDeProyecto.Enabled = true;
            CmbLiderMecanico.Enabled = true;
            Parcial = parcial;

            if(idModulo != 0)
                TxtComentarios.ReadOnly = CambioDiseno();
        }

        private void FrmImprimirFormatoLiberacionDiseno_Load(object sender, EventArgs e)
        {
            if (VistaPreviaSubensamble != null)
            {
                var ms = new MemoryStream(VistaPreviaSubensamble);
                PicSubensamble.Image = Image.FromStream(ms);
            }

            CargarDisenadoresMecanicos(CmbDisenadorMecanico, "DISEÑADOR MECANICO", 0);
            CargarDisenadoresMecanicos(CmbLiderMecanico, "LIDER DE DISEÑO MECANICO", 0);
            CargarDisenadoresMecanicos(CmbLiderDeProyecto, "LIDER DE PROYECTO", 0);

            Proyecto proyecto = new Proyecto();
            proyecto.CargarDatos(IdProyecto);
            if(proyecto.TieneFilas())
            {
                int idCliente = Convert.ToInt32(proyecto.Fila().Celda("cliente"));

                ClienteContacto contactoCliente = new ClienteContacto();
                contactoCliente.SeleccionarDeCliente(idCliente).ForEach(delegate(Fila f)
                {
                    string nombre = "";
                    object objNombre = f.Celda("nombre");
                    if(objNombre != null)
                        nombre = objNombre.ToString();

                    object objApellidos= f.Celda("apellidos");
                    if(objApellidos != null)
                        nombre += " " + objApellidos.ToString();

                    CmbContactoCliente.Items.Add(nombre);
                });
            }
        }

        private bool CambioDiseno()
        {
            Modulo modulo = new Modulo();
            CambioDiseno cambioDiseno = new CambioDiseno();

            modulo.BuscarCambioDiseno(IdModulo);

            if (modulo.TieneFilas())
            {
                int idCambioDiseno = Convert.ToInt32(modulo.Fila().Celda("cambio_diseno"));
                cambioDiseno.CargarDatos(idCambioDiseno).ForEach(delegate(Fila f)
                {
                    string encabezado = "CAMBIO DE DISEÑO DEL CLIENTE SOLICITADO EN " + Global.FechaATexto(Convert.ToDateTime(cambioDiseno.Fila().Celda("fecha_solicitud"))).ToUpper() + Environment.NewLine;
                    string alcance = "ALCANCE: " + cambioDiseno.Fila().Celda("alcance").ToString().ToUpper();
                    TxtComentarios.Text = encabezado + Environment.NewLine + alcance + Environment.NewLine;
                });
                return true;
            }
            else
                return false;
        }

        private void CargarDisenadoresMecanicos(ComboBox Cmb, string rol, int nivel)
        {
            CargarUsuarios.SeleccionarUsuariosDeNivel(rol, nivel).ForEach(delegate(Fila f)
            {
                string nombre = "";
                object objNombre = f.Celda("nombre");
                if(objNombre != null)
                    nombre = objNombre.ToString();

                object objPaterno= f.Celda("paterno");
                if(objPaterno != null)
                    nombre += " " + objPaterno.ToString();

                object objMaterno = f.Celda("materno");
                if(objMaterno != null)
                    nombre += " " + objMaterno.ToString();


                Cmb.Items.Add(nombre);
            });
        }

        private void CrearPDF()
        {
            if (CmbDisenadorMecanico.Text == "" || CmbLiderMecanico.Text == "" || CmbLiderDeProyecto.Text == "" || CmbContactoCliente.Text == "")
                return;

            List<string> usuarios = new List<string>();
            usuarios.Add(CmbDisenadorMecanico.Text);
            usuarios.Add(CmbLiderMecanico.Text);
            usuarios.Add(CmbLiderDeProyecto.Text);
            usuarios.Add(CmbContactoCliente.Text);
            string descripcion = "EL PRESENTE DOCUMENTO AVALA QUE EL DISEÑO MECANICO DEL PROYECTO CITADO FUE VALIDADO " +
                                 " POR EL CLIENTE, CUMPLIENDO EL 100% DE LOS REQUERIMIENTOS" +
                                 " SOLICITADOS." + Environment.NewLine + Environment.NewLine + "POR LO TANTO, SE AUTORIZA EL INICIO DE LA FABRICACION" +
                                 " DE PIEZAS Y LA COMPRA DEL MATERIAL REQUERIDO PARA LA CONSTRUCCION DE LOS MODULOS QUE FUERON VALIDADOS. EN CASO DE REQUERIR IMAGENES DETALLADAS SOBRE EL DISEÑO O SOLIDOS 3D DEBERAN SER SOLICITADOS AL LIDER DE PROYECTO.";

            DatosPdf = FormatosPDF.ReporteDeValidacionDiseno(VistaPreviaSubensamble, IdProyecto, usuarios, "AUDISEL INC.", descripcion, TxtComentarios.Text, Parcial, Modulo);
            Global.MostrarPDF(DatosPdf, "FORMATO DE VALIDACION DE DISEÑO DEL PROYECTO " + IdProyecto, null, VisorPDF);
        }

        private void CmbLiderMecanico_SelectedIndexChanged(object sender, EventArgs e)
        {

            CrearPDF();
        }

        private void CmbDisenadorMecanico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrearPDF();
        }

        private void CmbLiderDeProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrearPDF();
        }

        private void CmbContactoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CrearPDF();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            CrearPDF();
        }
    }
}
