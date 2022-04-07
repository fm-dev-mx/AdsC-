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
    public partial class FrmAnalisisNcCliente : Form
    {
        NoConformidad NC = new NoConformidad();
        TicketServicio Ticket = new TicketServicio();
        Proyecto Prj = new Proyecto();
        ClienteContacto Contacto = new ClienteContacto();
        Cliente Cli = new Cliente();

        public FrmAnalisisNcCliente(int idNcExterna)
        {
            InitializeComponent();
            NC.CargarDatos(idNcExterna);
            Ticket.SeleccionarNoConformidad(idNcExterna);
            Prj.CargarDatos(Convert.ToInt32(Ticket.Fila().Celda("proyecto")));
            Contacto.CargarDatos(Convert.ToInt32(Ticket.Fila().Celda("contacto")));
            Cli.CargarDatos(Convert.ToInt32(Contacto.Fila().Celda("cliente")));
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void FrmAnalisisNcCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos()
        {
            TxtIdNoConformidad.Text = NC.Fila().Celda("id").ToString().PadLeft(4, '0');
            TxtIdTicketServicio.Text = Ticket.Fila().Celda("id").ToString().PadLeft(4, '0');
            TxtTipo.Text = Ticket.Fila().Celda("tipo").ToString();
            TxtProyecto.Text = Convert.ToDecimal(Prj.Fila().Celda("id")).ToString("F2").PadLeft(6, '0') + " - " + Prj.Fila().Celda("nombre").ToString();
            TxtCliente.Text = Cli.Fila().Celda("nombre").ToString();
            TxtContacto.Text = Contacto.Fila().Celda("nombre").ToString() + " " + Contacto.Fila().Celda("apellidos").ToString();
            TxtComentarios.Text = Ticket.Fila().Celda("detalles").ToString();
        }

        private void TabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(TabPrincipal.SelectedIndex)
            {
                case 0:
                    break;

                case 1:

                    if(TxtCausaRaiz.Text.Length < 50)
                    {
                        MessageBox.Show("Debes ingresar al menos 50 caracteres en la causa raiz de la no conformidad antes de poder determinar el riesgo.", "Imposible determinar riesgo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CmbConsecuencia.Enabled = false;
                        CmbPerspectiva.Enabled = false;
                        CmbProbabilidad.Enabled = false;
                    }
                    else
                    {
                        CmbConsecuencia.Enabled = true;
                        CmbPerspectiva.Enabled = true;
                        CmbProbabilidad.Enabled = true;
                        CargarPespectivaRiesgo();
                        CargarProbabilidades();
                        DeterminarImpacto();
                    }
                    break;
            }
        }

        public void CargarPespectivaRiesgo()
        {
            // cargar perspectivas 
            CmbPerspectiva.Items.Clear();
            CmbPerspectiva.Items.Add(string.Empty);
            CriterioRiesgo.Modelo().Perspectivas().ForEach(delegate(Fila f)
            {
                CmbPerspectiva.Items.Add(f.Celda("perspectiva"));
            });

        }

        public void CargarConsecuenciaRiesgo(string perspectiva)
        {
            // cargar consecuencias
            CmbConsecuencia.Items.Clear();
            CmbConsecuencia.Items.Add(string.Empty);
            CriterioRiesgo.Modelo().Consecuencias(perspectiva).ForEach(delegate(Fila f)
            {
                CmbConsecuencia.Items.Add(f.Celda("nivel_riesgo") + " - " + f.Celda("consecuencia"));
            });
        }

        public void CargarProbabilidades()
        {
            CmbProbabilidad.Items.Clear();
            CmbProbabilidad.Items.Add(string.Empty);
            ProbabilidadRiesgo.Modelo().Todas().ForEach(delegate(Fila f)
            {
                CmbProbabilidad.Items.Add(f.Celda("nivel_probabilidad") + " - " + f.Celda("probabilidad"));
            });
        }

        public void DeterminarImpacto()
        {
            if(CmbConsecuencia.Text == string.Empty || CmbProbabilidad.Text == string.Empty)
            {
                TxtImpacto.Text = "SIN DEFINIR";
                TxtImpacto.BackColor = Color.LightGray;
                TxtImpacto.ForeColor = Color.Black;
                
                LblAccionRecomendada.Text = "SIN DEFINIR";
                LblAccionRecomendada.BackColor = Color.LightGray;
                LblAccionRecomendada.ForeColor = Color.Black;

                return;
            }

            int nivelProbabilidad = Convert.ToInt32(CmbProbabilidad.Text.Split('-')[0]); 
            int nivelConsecuencia = Convert.ToInt32(CmbConsecuencia.Text.Split('-')[0]);

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@probabilidad", nivelProbabilidad);
            parametros.Add("@consecuencia", nivelConsecuencia);

            Color colorFondo;
            Color colorTexto;

            ProbabilidadConsecuencia pc = new ProbabilidadConsecuencia();
            pc.SeleccionarDatos("nivel_probabilidad=@probabilidad AND nivel_consecuencia=@consecuencia", parametros).ForEach(delegate(Fila f)
            {
                int nivelImpacto = Convert.ToInt32(f.Celda("nivel_impacto").ToString());

                TratamientoRiesgo trat = new TratamientoRiesgo();
                trat.SeleccionarImpacto(nivelImpacto);

                if(trat.TieneFilas())
                {
                    TxtImpacto.Text = nivelImpacto + " - " + trat.Fila().Celda("tratamiento_requerido");
                    LblAccionRecomendada.Text = trat.Fila().Celda("recomendacion").ToString();

                    colorFondo = System.Drawing.ColorTranslator.FromHtml(trat.Fila().Celda("color_fondo").ToString());
                    colorTexto = System.Drawing.ColorTranslator.FromHtml(trat.Fila().Celda("color_texto").ToString());

                    TxtImpacto.BackColor = colorFondo;
                    TxtImpacto.ForeColor = colorTexto;

                    LblAccionRecomendada.BackColor = colorFondo;
                    LblAccionRecomendada.ForeColor = colorTexto;
                }
            });
        }

        private void CmbPerspectiva_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarConsecuenciaRiesgo(CmbPerspectiva.Text);
        }

        private void CmbConsecuencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeterminarImpacto();
        }

        private void CmbProbabilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeterminarImpacto();
        }
    }
}
