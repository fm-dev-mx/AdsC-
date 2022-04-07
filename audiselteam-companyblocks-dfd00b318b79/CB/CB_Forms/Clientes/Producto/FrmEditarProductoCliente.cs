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

namespace CB
{
    public partial class FrmEditarProductoCliente : Form
    {
        public ClienteProducto Producto = new ClienteProducto();

        public FrmEditarProductoCliente(int idProducto)
        {
            InitializeComponent();
            Producto.CargarDatos(idProducto);
        }

        private void FrmEditarProductoCliente_Load(object sender, EventArgs e)
        {
            MostrarDatosProducto();
            CargarClientes();
        }

        public void MostrarDatosProducto()
        {
            TxtNombreProducto.Text = Global.ObjetoATexto(Producto.Fila().Celda("nombre"), "N/A");
            TxtDescripcion.Text = Global.ObjetoATexto(Producto.Fila().Celda("descripcion"), "N/A");
        }

        public void CargarClientes()
        {
            int indice = -1;
            int i = 0;
            int idCliente = Convert.ToInt32(Producto.Fila().Celda("cliente"));

            CmbEditarCliente.Items.Clear();
            Cliente.Modelo().Activos().ForEach(delegate(Fila f)
            {
                CmbEditarCliente.Items.Add(f.Celda("id") + " - " + f.Celda("nombre"));

                if (idCliente == Convert.ToInt32(f.Celda("id")))
                    indice = i;

                i++;
            });

            if(indice >= 0)
                CmbEditarCliente.SelectedIndex = indice;
            
            CargarIndustrias(idCliente);
        }

        public void CargarIndustrias(int idCliente)
        {
            int indice = -1;
            int i = 0;
            int idIndustria = Convert.ToInt32(Producto.Fila().Celda("industria"));

            CmbEditarIndustria.Items.Clear();
            ClienteIndustria.Modelo().SeleccionarCliente(idCliente).ForEach(delegate(Fila f)
            {
                CmbEditarIndustria.Items.Add(f.Celda("id").ToString().PadLeft(3, '0') + " - " + f.Celda("industria"));

                if (idIndustria == Convert.ToInt32(f.Celda("id")))
                    indice = i;

                i++;
            });

            if(indice >= 0)
                CmbEditarIndustria.SelectedIndex = indice;
        }

        private void CmbEditarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbEditarCliente.Text == string.Empty)
                return;

            int idCliente = Convert.ToInt32(CmbEditarCliente.Text.Split('-')[0]);

            CargarIndustrias(idCliente);
        }

        private void BtnFinalizarEdicion_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void MenuModelos_Opening(object sender, CancelEventArgs e)
        {
            editarModeloToolStripMenuItem.Enabled = DgvEditarModelos.SelectedRows.Count > 0;
        }

        private void nuevoModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoModeloProductoCliente nuevo = new FrmNuevoModeloProductoCliente(Convert.ToInt32(Producto.Fila().Celda("id")));
            
            if(nuevo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarModelos();
            }
        }

        public void MostrarModelos()
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvEditarModelos);

            DgvEditarModelos.Rows.Clear();
            ClienteProductoModelo.Modelo().SeleccionarProducto(Convert.ToInt32(Producto.Fila().Celda("id"))).ForEach(delegate(Fila f)
            {
                DgvEditarModelos.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), f.Celda("familia"), f.Celda("modelo"));
            });

            Global.RecuperarFilaSeleccionada(DgvEditarModelos, filaSeleccionada);
        }

        private void TabsProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(TabsProducto.SelectedIndex)
            {
                case 0:

                    break;

                case 1:
                    MostrarModelos();
                    break;

                case 2:
                    MostrarComponentes();
                    break;
            }
        }

        private void editarModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvEditarModelos.SelectedRows.Count <= 0)
                return;

            int idModeloSeleccionado = Convert.ToInt32(DgvEditarModelos.SelectedRows[0].Cells[0].Value);

            FrmNuevoModeloProductoCliente editarModelo = new FrmNuevoModeloProductoCliente(Convert.ToInt32(Producto.Fila().Celda("id")), idModeloSeleccionado);

            if(editarModelo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarModelos();
            }
        }

        private void MenuComponentes_Opening(object sender, CancelEventArgs e)
        {
            editarComponenteToolStripMenuItem.Enabled = DgvEditarComponentes.SelectedRows.Count > 0;
            eliminarComponenteToolStripMenuItem.Enabled = DgvEditarComponentes.SelectedRows.Count > 0;
        }

        private void nuevoComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoComponenteProductoCliente nc = new FrmNuevoComponenteProductoCliente(Convert.ToInt32(Producto.Fila().Celda("id")));

            if(nc.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarComponentes();
            }
        }

        public void MostrarComponentes()
        {
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvEditarComponentes);
            DgvEditarComponentes.Rows.Clear();
            ClienteProductoComponente.Modelo()
                                     .SeleccionarProducto(Convert.ToInt32(Producto.Fila().Celda("id")))
                                     .ForEach(delegate(Fila f)
            {
                DgvEditarComponentes.Rows.Add(f.Celda("id").ToString().PadLeft(4, '0'), f.Celda("nombre"), "X", "Y", "Z");
            });
            Global.RecuperarFilaSeleccionada(DgvEditarComponentes, filaSeleccionada);
        }

        private void eliminarComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvEditarComponentes.SelectedRows.Count <= 0)
                return;

            DialogResult resp = MessageBox.Show("¿Seguro que quieres eliminar el componente seleccionado?", "Eliminar componente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            int idComponente = Convert.ToInt32(DgvEditarComponentes.SelectedRows[0].Cells[0].Value);

            ClienteProductoComponente comp = new ClienteProductoComponente();
            comp.CargarDatos(idComponente);
            comp.BorrarDatos();
            MostrarComponentes();
        }

        private void eliminarModeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvEditarModelos.SelectedRows.Count <= 0)
                return;

            DialogResult resp = MessageBox.Show("¿Seguro que quieres eliminar el modelo seleccionado?", "Eliminar modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            int idModelo = Convert.ToInt32(DgvEditarModelos.SelectedRows[0].Cells[0].Value);

            ClienteProductoModelo mod = new ClienteProductoModelo();
            mod.CargarDatos(idModelo);
            mod.BorrarDatos();
            MostrarModelos();
        }

        private void editarComponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DgvEditarComponentes.SelectedRows.Count <= 0) 
                return;

            int idComponente = Convert.ToInt32(DgvEditarComponentes.SelectedRows[0].Cells[0].Value);

            FrmNuevoComponenteProductoCliente editar 
                = new FrmNuevoComponenteProductoCliente(Convert.ToInt32(Producto.Fila().Celda("id")), idComponente);

            if(editar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MostrarComponentes();
            }
        }

    }
}
