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
    public partial class FrmAgregarTerminoPago : Ventana
    {
        public int IdPo = 0;
        public int IdProveedor = 0;
        public int IdTermino = 0;
        public int Maximo = 0;
        public int Porcentaje = 0;
        public string Concepto = "";

        public FrmAgregarTerminoPago(int idPo, int idProveedor,  int idTermino = 0)
        {
            IdPo = idPo;            
            IdTermino = idTermino;
            IdProveedor = idProveedor;
            InitializeComponent();

            if (ObtenerPorcentajeMaximo() <= 0)
                Maximo = 100;
            else
                Maximo = ObtenerPorcentajeMaximo();

            NumPorcentaje.Minimum = 0;

            if (IdTermino != 0)
            {
                TerminoPagoProveedor terminos = new TerminoPagoProveedor();
                terminos.CargarDatos(IdTermino);
                if (terminos.TieneFilas())
                {
                    TxtTermino.Text = terminos.Fila().Celda("terminos").ToString();
                    NumPorcentaje.Value = Convert.ToInt32(terminos.Fila().Celda("porcentaje"));
                    NumPorcentaje.Maximum = Convert.ToInt32(terminos.Fila().Celda("porcentaje")) + ObtenerPorcentajeMaximo();
                }
                LblTitulo.Text = "EDITAR TERMINO DE PAGO";
                LblDescripcion.Text = "Edite el porcentaje y el concepto del término en un rango igual o menor a " + (Convert.ToInt32(terminos.Fila().Celda("porcentaje")) + ObtenerPorcentajeMaximo()) + "%";
                BtnRegistrar.Text = "Editar";
            }
            else
            {
                NumPorcentaje.Maximum = Maximo;
                LblDescripcion.Text = "Agregue el término de pago y porcentaje en un rango igual o menor a " + Maximo.ToString() + "%";
            }
        }

        public int ObtenerPorcentajeMaximo()
        {
            TerminoPagoProveedor termino = new TerminoPagoProveedor();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@po", IdPo);
            parametros.Add("@proveedor", IdProveedor);

            termino.SeleccionarDatos("po=@po and @proveedor=@proveedor", parametros, "SUM(porcentaje) AS suma");
            if (termino.TieneFilas())
            {
                if (termino.Fila().Celda("suma") != null)
                {
                    if (Convert.ToInt32(termino.Fila().Celda("suma").ToString()) > 0)
                    {
                        return 100 - Convert.ToInt32(termino.Fila().Celda("suma").ToString());
                    }
                }           
            }              
            return 0;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            TerminoPagoProveedor terminos = new TerminoPagoProveedor();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@po", IdPo);
            parametros.Add("@proveedor", IdProveedor);
            int terminoAnterior = 0;

            if(TxtTermino.Text != "" && NumPorcentaje.Value != 0)
            {
                if(IdTermino == 0)
                {
                    Fila agregarTermino = new Fila();
                    agregarTermino.AgregarCelda("po", IdPo);
                    agregarTermino.AgregarCelda("proveedor", IdProveedor);
                    agregarTermino.AgregarCelda("porcentaje", NumPorcentaje.Value);
                    agregarTermino.AgregarCelda("terminos", TxtTermino.Text);
                    agregarTermino.AgregarCelda("anterior", 0);
                    TerminoPagoProveedor.Modelo().Insertar(agregarTermino);
                    
                    terminos.SeleccionarDatos("po=@po AND proveedor=@proveedor ORDER by id asc",parametros);
                    if (terminos.TieneFilas())
                    {
                        terminos.SeleccionarDatos("po=@po AND proveedor=@proveedor ORDER by id asc", parametros).ForEach(delegate(Fila f)
                        {
                            f.ModificarCelda("anterior", terminoAnterior);
                            terminos.GuardarDatos();
                            terminoAnterior = Convert.ToInt32(f.Celda("id"));
                        });
                    }
                }
                else
                {
                    terminos.CargarDatos(IdTermino);
                    if(terminos.TieneFilas())
                    {
                        terminos.Fila().ModificarCelda("porcentaje", NumPorcentaje.Value);
                        terminos.Fila().ModificarCelda("terminos",TxtTermino.Text);
                        terminos.GuardarDatos();
                    }
                }
                
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            LblInformacion.Text = "Favor de llenar correctamente cada campo";
            LblInformacion.Visible = true;
        }     

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
