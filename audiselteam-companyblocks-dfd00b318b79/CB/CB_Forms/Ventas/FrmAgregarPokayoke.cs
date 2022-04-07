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
    public partial class FrmAgregarPokayoke : Form
    {
        int IdPokayoke = 0;
        int IdCotizacion = 0;
        CotizacionPokayoke Pokayoke = new CotizacionPokayoke();

        public FrmAgregarPokayoke(int idCotizacion, int idPokayoke = 0)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
            IdPokayoke = idPokayoke;
        }

        private void FrmAgregarPokayoke_Load(object sender, EventArgs e)
        {
            if (IdPokayoke > 0)
                Pokayoke.SeleccionarPokayokePorId(IdPokayoke);

            CargarObjetivos();
            CargarMetodos();
        }

        private void CargarObjetivos()
        {
            //entradas y salidas
            BindingSource ProcesoBinding = new BindingSource();

            CotizacionEntrada entradas = new CotizacionEntrada();
            entradas.SeleccionarEntradasDeCotizacion(IdCotizacion).ForEach(delegate(Fila f)
            {
                ProcesoBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = "entrada-" + f.Celda<int>("id")
                });
            });

            CotizacionSalida salidas = new CotizacionSalida();
            salidas.SeleccionarSalidasDeCotizacion(IdCotizacion).ForEach(delegate(Fila f)
            {
                ProcesoBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = "salida-" + f.Celda<int>("id")
                });
            });

            CmbObjetivo.DisplayMember = "Text";
            CmbObjetivo.ValueMember = "Value";
            CmbObjetivo.DataSource = ProcesoBinding;

            if (IdPokayoke > 0)
            {
                CmbObjetivo.Text = Pokayoke.Fila().Celda("target").ToString();
                CmbObjetivo.Enabled = false;
            }
        }

        private void CargarMetodos()
        {
            BindingSource MetodosBinding = new BindingSource();
            PokayokeMetodo metodo = new PokayokeMetodo();
            metodo.SeleccionarDatos("", null).ForEach(delegate(Fila f)
            {
                MetodosBinding.Add(new
                {
                    Text = f.Celda("nombre").ToString(),
                    Value = f.Celda<int>("id")
                });
            });
 
            CmbMetodos.DisplayMember = "Text";
            CmbMetodos.ValueMember = "Value";
            CmbMetodos.DataSource = MetodosBinding;

            if (IdPokayoke > 0)
                CmbMetodos.Text = Pokayoke.Fila().Celda("metodo").ToString();
        }

        private void CargarAlcance()
        {
            DgvAlcance.Rows.Clear();

            PokayokeAlcance alcance = new PokayokeAlcance();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@idMetodo", CmbMetodos.SelectedValue);
            alcance.SeleccionarDatos("id_metodo=@idMetodo", parametros).ForEach(delegate(Fila f)
            {
                bool seleccionarAlcance = false;

                int idTarget = 0;
                if (Pokayoke.TieneFilas())
                    idTarget = Pokayoke.Fila().Celda<int>("id_target");

                PokayokeAlcanceCotizacion vinculoAlcance = new PokayokeAlcanceCotizacion();
                vinculoAlcance.SeleccionarAlcancesVisculados(IdPokayoke, f.Celda<int>("id"), Convert.ToInt32(CmbMetodos.SelectedValue), idTarget);
                
                if (vinculoAlcance.TieneFilas())
                    seleccionarAlcance = true;

                DgvAlcance.Rows.Add(seleccionarAlcance, f.Celda("id"), f.Celda("nombre"));
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private string CalcularNombre()
        {
            string strAlcance = string.Empty;
            foreach (DataGridViewRow row in DgvAlcance.Rows)
            {
                bool chk = Convert.ToBoolean(DgvAlcance.Rows[row.Index].Cells["check"].Value.ToString().ToLower());
                if (chk)
                    strAlcance += DgvAlcance.Rows[row.Index].Cells["alcance"].Value.ToString() + " + ";
            }

            if (strAlcance == "")
                return null;

            strAlcance = strAlcance.Remove(strAlcance.Length - 3);
            return strAlcance;
        }

        private void BtnAcepatr_Click(object sender, EventArgs e)
        {
            string strAlcance = CalcularNombre();
            if (strAlcance == null)
            {
                MessageBox.Show("Debe seleccionar por lo menos un alcance");
                return;
            }

            if (IdPokayoke > 0)
                EditarPokayoke(strAlcance);
            else
                CrearPokayoke(strAlcance);

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CrearPokayoke(string strAlcance)
        {
            Fila insertarPokayokeTarget = new Fila();
            insertarPokayokeTarget.AgregarCelda("id_cotizacion", IdCotizacion);
            insertarPokayokeTarget.AgregarCelda("nombre", CmbObjetivo.Text);
            insertarPokayokeTarget.AgregarCelda("id_pokayoke", 0);
            int idTarget = Convert.ToInt32(PokayokeTarget.Modelo().Insertar(insertarPokayokeTarget).Celda("id"));

            Fila insertarCotizacionpokayoke = new Fila();
            insertarCotizacionpokayoke.AgregarCelda("id_cotizacion", IdCotizacion);
            insertarCotizacionpokayoke.AgregarCelda("id_metodo", CmbMetodos.SelectedValue.ToString());
            insertarCotizacionpokayoke.AgregarCelda("id_target", idTarget);
            insertarCotizacionpokayoke.AgregarCelda("alcance", strAlcance);
            IdPokayoke = Convert.ToInt32(CotizacionPokayoke.Modelo().Insertar(insertarCotizacionpokayoke).Celda("id"));

            PokayokeTarget target = new PokayokeTarget();
            target.CargarDatos(idTarget);
            if(target.TieneFilas())
            {
                target.Fila().ModificarCelda("id_pokayoke", IdPokayoke);
                target.GuardarDatos();
            }

            foreach (DataGridViewRow row in DgvAlcance.Rows)
            {
                bool chk = Convert.ToBoolean(DgvAlcance.Rows[row.Index].Cells["check"].Value.ToString().ToLower());
                if (chk)
                {
                    Fila insertarPokayokeAlcanceCotizacion = new Fila();
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_alcance", row.Cells["id"].Value);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_cotizacion", IdCotizacion);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_pokayoke", IdPokayoke);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_metodo", CmbMetodos.SelectedValue);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_target", idTarget);
                    PokayokeAlcanceCotizacion.Modelo().Insertar(insertarPokayokeAlcanceCotizacion);
                }
            }
        }

        private void EditarPokayoke(string strAlcance)
        {
            int idTarget = 0;
            PokayokeTarget target = new PokayokeTarget();
            target.SeleccionarTargetPorIdPokayoke(IdPokayoke);
            if(target.TieneFilas())
            {
                idTarget = target.Fila().Celda<int>("id");
                target.Fila().ModificarCelda("nombre", CmbObjetivo.Text);
                target.GuardarDatos();
            }

            CotizacionPokayoke actualizarInformacion = new CotizacionPokayoke();
            actualizarInformacion.CargarDatos(IdPokayoke);
            if (actualizarInformacion.TieneFilas())
            {
                actualizarInformacion.Fila().ModificarCelda("id_metodo", CmbMetodos.SelectedValue);
                actualizarInformacion.Fila().ModificarCelda("alcance", strAlcance);
                actualizarInformacion.GuardarDatos();
            }

            PokayokeAlcanceCotizacion alcanceCotizacion = new PokayokeAlcanceCotizacion();
            alcanceCotizacion.BorrarAlcancesVinculados(IdPokayoke);

            foreach (DataGridViewRow row in DgvAlcance.Rows)
            {
                bool chk = Convert.ToBoolean(DgvAlcance.Rows[row.Index].Cells["check"].Value.ToString().ToLower());
                if (chk)
                {
                    Fila insertarPokayokeAlcanceCotizacion = new Fila();
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_alcance", row.Cells["id"].Value);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_cotizacion", IdCotizacion);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_pokayoke", IdPokayoke);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_metodo", CmbMetodos.SelectedValue);
                    insertarPokayokeAlcanceCotizacion.AgregarCelda("id_target", idTarget);
                    PokayokeAlcanceCotizacion.Modelo().Insertar(insertarPokayokeAlcanceCotizacion);
                }
            }
        }

        private void DgvAlcance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvAlcance.Rows[e.RowIndex].Cells["check"];
            string strCheck = DgvAlcance.Rows[e.RowIndex].Cells["check"].Value.ToString().ToLower();
            if (strCheck == chk.TrueValue.ToString().ToLower())
            {
                chk.Value = chk.FalseValue;
            }
            else
            {
                chk.Value = chk.TrueValue;
            }
        }

        private void CmbMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAlcance();
        }

        private void CmbObjetivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
