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
    public partial class FrmListaPokayoke : Form
    {
        int IdCotizacion = 0;

        public FrmListaPokayoke(int idCotizacion)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
        }

        private void FrmPokayoke_Load(object sender, EventArgs e)
        {
            CargarlistaPokayoke();
        }

        private void CargarlistaPokayoke()
        {
            DgvPokayokes.Rows.Clear();
            CotizacionPokayoke cotizacionpokayoke = new CotizacionPokayoke();
            cotizacionpokayoke.SeleccionarPokayokesDeCotizacion(IdCotizacion).ForEach(delegate(Fila f)
            {
                DgvPokayokes.Rows.Add
                (
                    f.Celda("id"),
                    f.Celda("target"),
                    f.Celda("alcance"),
                    f.Celda("metodo")
                );
            });
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarPokayoke agregar = new FrmAgregarPokayoke(IdCotizacion);
            if(agregar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarlistaPokayoke();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarPokayoke editar = new FrmAgregarPokayoke(IdCotizacion, Convert.ToInt32(DgvPokayokes.SelectedRows[0].Cells["id"].Value));
            if (editar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarlistaPokayoke();
        }

        private void Menu_Opening(object sender, CancelEventArgs e)
        {
            editarToolStripMenuItem.Visible = (DgvPokayokes.SelectedRows.Count == 1);
            eliminarToolStripMenuItem.Visible = (DgvPokayokes.SelectedRows.Count == 1);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("¿Está seguro de eliminar de forma permanente el poka-yoke seleccionado?", "Borrar poka-yoke", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resul == System.Windows.Forms.DialogResult.Yes)
            {
                int idPokayoke = Convert.ToInt32(DgvPokayokes.SelectedRows[0].Cells["id"].Value);
                CotizacionPokayoke pokayoke = new CotizacionPokayoke();
                pokayoke.CargarDatos(idPokayoke);

                if(pokayoke.TieneFilas())
                {
                    PokayokeTarget borrarPokayokeTarget = new PokayokeTarget();
                    borrarPokayokeTarget.BorrarTarget(pokayoke.Fila().Celda<int>("id_target"));

                    PokayokeAlcanceCotizacion borrarAlcanceCotizacion = new PokayokeAlcanceCotizacion();
                    borrarAlcanceCotizacion.BorrarAlcancesVinculados(idPokayoke);

                    pokayoke.BorrarDatos(idPokayoke);
                    pokayoke.GuardarDatos();

                    MessageBox.Show("Pokayoke borrado correctamente", "Pokayoke borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarlistaPokayoke();
                }
            }
        }
    }
}
