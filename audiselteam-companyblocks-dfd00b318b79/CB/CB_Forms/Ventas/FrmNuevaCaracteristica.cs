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
    public partial class FrmNuevaCaracteristica : Form
    {
        BindingSource CaracteristicaBinding = new BindingSource();
        BindingSource OpcionesBinding = new BindingSource();
        int IdModulo = 0;
        int IdCotizacion = 0;
        int IdModuloCotizacion = 0;

        public FrmNuevaCaracteristica(int idModulo, int idCotizacion, int idModeloCotizacion)
        {
            InitializeComponent();
            IdModulo = idModulo;
            IdCotizacion = idCotizacion;
            IdModuloCotizacion = idModeloCotizacion;
        }

        private void FrmNuevaCaracteristica_Load(object sender, EventArgs e)
        {
            CargarCaracteristicas();
        }

        private void CargarCaracteristicas()
        {
            CaracteristicaBinding.Clear();
            CaracteristicaBinding.Add
            (
                new
                {
                    Text = "",
                    Value = 0
                }
            );

            ModuloEstandarCaracteristica caracteristica = new ModuloEstandarCaracteristica();
            caracteristica.SeleccionarCaracteristicasDeModulo(IdModulo, IdCotizacion).ForEach(delegate(Fila f)
            {
                CaracteristicaBinding.Add
                (
                    new
                    {
                        Text = f.Celda("nombre").ToString(),
                        Value = f.Celda<int>("id")
                    }
                );
            });

            CmbCaracteristica.DisplayMember = "Text";
            CmbCaracteristica.ValueMember = "Value";
            CmbCaracteristica.DataSource = CaracteristicaBinding;

        }

        private void CargarOpciones()
        {
            OpcionesBinding.Clear();
            OpcionesBinding.Add
            (
                new
                {
                    Text = "",
                    Value = 0
                }
            );

            ModuloEstandarOpcion opciones = new ModuloEstandarOpcion();
            opciones.SeleccionarOpcionesDeCaracteristica(CmbCaracteristica.Text).ForEach(delegate(Fila f)
            {
                OpcionesBinding.Add
                (
                    new
                    {
                        Text = f.Celda("nombre").ToString(),
                        Value = f.Celda<int>("id")
                    }
                );
            });

            CmbOpciones.DisplayMember = "Text";
            CmbOpciones.ValueMember = "Value";
            CmbOpciones.DataSource = OpcionesBinding;
        }

        private decimal CalcularCostoPromedio()
        {
            decimal costoPromedio = 0;
            ModuloEstandarCaracteristicaOpcion costo = new ModuloEstandarCaracteristicaOpcion();
            costo.ObteberCostoPromedio(CmbCaracteristica.Text,CmbOpciones.Text);

            if (costo.TieneFilas())
                costoPromedio = Convert.ToDecimal(costo.Fila().Celda("costo_promedio"));

            return costoPromedio;
        }

        private void CmbCaracteristica_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarCaracteristica();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmbCaracteristica_TextChanged(object sender, EventArgs e)
        {
            ValidarCaracteristica();
        }

        private void ValidarCaracteristica()
        {
            bool encontrado = false;
            foreach (var item in CaracteristicaBinding.List)
            {
                var valor = item.ToString().ToString().Replace("{", "").Replace("}", "").Replace('"', ' ').Trim().Split(',');
                string nombreDividido = valor[0].Trim();
                string valorBuscado = "Text = " + CmbCaracteristica.Text;
                if (nombreDividido.Trim() == valorBuscado.Trim())
                {
                    CargarOpciones();
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
                OpcionesBinding.Clear();
        }

        private void CmbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CmbCaracteristica.Text != "")
                NumCosto.Value = CalcularCostoPromedio();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //en caso de que el costo sea 0 el usuario debe confirmalo
            if (NumCosto.Value <= 0)
            {
                DialogResult result = MessageBox.Show("¿Desea crear una nueva característica con valor 0?", "Caracerística sin valor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result != System.Windows.Forms.DialogResult.Yes)
                {
                    MessageBox.Show("No ha sido posible Crear la característica");
                    return;
                }
            }

            //CARACTERISTICA
            int idCaracteristica = 0;
            int idOpcion = 0;
                
            //se busca una caracteristica que concuerde con la seleccionada
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", CmbCaracteristica.Text);
            ModuloEstandarCaracteristica caracteristica = new ModuloEstandarCaracteristica();
            caracteristica.SeleccionarDatos("nombre=@nombre", parametros);

            //Se agarra el id de la caracteristica en caso de existir
            if(caracteristica.TieneFilas())
                idCaracteristica = caracteristica.Fila().Celda<int>("id");
            else
            {
                //Se crea una caracteristica y se agarra el id
                Fila insertarCaracteristica = new Fila();
                insertarCaracteristica.AgregarCelda("nombre", CmbCaracteristica.Text);
                insertarCaracteristica.AgregarCelda("modulo_id", IdModulo);
                idCaracteristica = Convert.ToInt32(ModuloEstandarCaracteristica.Modelo().Insertar(insertarCaracteristica).Celda("id"));
            }

            //se busca un modelo en base a la caracteristica seleccionada
            parametros = new Dictionary<string, object>();
            parametros.Add("@nombre", CmbOpciones.Text);
            ModuloEstandarOpcion opcion = new ModuloEstandarOpcion();
            opcion.SeleccionarDatos("nombre=@nombre", parametros);

           //si existe se agarra el id
            if (opcion.TieneFilas())
                idOpcion = opcion.Fila().Celda<int>("id");
            else //si no existe se crea
            {
                Fila insertarCaracteristica = new Fila();
                insertarCaracteristica.AgregarCelda("nombre", CmbOpciones.Text);
                insertarCaracteristica.AgregarCelda("caracteristica", CmbCaracteristica.Text);
                idOpcion = Convert.ToInt32(ModuloEstandarOpcion.Modelo().Insertar(insertarCaracteristica).Celda("id"));
            }

            /*Fila insertarModuloCotizacion = new Fila();
            insertarModuloCotizacion.AgregarCelda("id_cotizacion", IdCotizacion);
            insertarModuloCotizacion.AgregarCelda("id_modulo", IdModulo);
            int idModeloCotizacion = Convert.ToInt32(ModuloEstandarCotizacion.Modelo().Insertar(insertarModuloCotizacion).Celda("id"));*/

            //se Guarda la caracteristica y modelo en base a la id de la cotizacion
            Fila insertarModuloEstandarCaracteriscaOpciones = new Fila();
            insertarModuloEstandarCaracteriscaOpciones.AgregarCelda("caracteristica", CmbCaracteristica.Text);
            insertarModuloEstandarCaracteriscaOpciones.AgregarCelda("opcion", CmbOpciones.Text);
            insertarModuloEstandarCaracteriscaOpciones.AgregarCelda("costo", NumCosto.Value);
            insertarModuloEstandarCaracteriscaOpciones.AgregarCelda("id_modulo_estandar_cotizacion", IdModuloCotizacion);
            ModuloEstandarCaracteristicaOpcion.Modelo().Insertar(insertarModuloEstandarCaracteriscaOpciones);

            MessageBox.Show("La característica fue creada correctamente", "Característica creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CmbCaracteristica_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
            base.OnKeyPress(e);
        }

        private void CmbOpciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = e.KeyChar.ToString().ToUpper()[0];
            base.OnKeyPress(e);
        }
    }
}
