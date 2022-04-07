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
    public partial class FrmCalcularCosto : Form
    {
        public FrmCalcularCosto()
        {
            InitializeComponent();
        }

        private void FrmCalcularCosto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtProyectos.Text == "")
                return;

            string ListaProyectos = TxtProyectos.Text;
            CalcularCosto(ListaProyectos, "MXN");
        }

        void CalcularCosto(string proyectoLista, string moneda)
        {
            List<int> lista = new List<int>();

            foreach (string id in proyectoLista.Split(','))
                lista.Add(Convert.ToInt32(id));

            foreach (int idProyecto in lista)
            {
                MaterialProyecto materialProyecto = new MaterialProyecto();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@ordenado", "ORDENADO");
                parametros.Add("@moneda", moneda);
                parametros.Add("@proyecto", moneda);

                string queryCondition = "proyecto=@proyecto AND precio_moneda=@moneda AND estatus_compra=@ordenado";
                materialProyecto.SeleccionarDatos(queryCondition, parametros, "SUM(precio_suma_final) as suma_final");
            }         
        } 
    }
}
