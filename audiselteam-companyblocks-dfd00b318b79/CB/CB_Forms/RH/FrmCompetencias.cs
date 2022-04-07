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

using System.Reflection;
using System.Resources;
using System.Globalization;

namespace CB
{
    public partial class FrmCompetencias : Ventana
    {
        Competencia ListaCompetencia = new Competencia();

        public FrmCompetencias()
        {
            InitializeComponent();
        }

        private void FrmCompetencias_Load(object sender, EventArgs e)
        {
            CargarCompetencias();
        }

        private void CargarCompetencias() 
        {
            TvCompetencias.Nodes.Clear();
            ListaCompetencia.SeleccionarTiposHabilidades().ForEach(delegate(Fila competencia)
            {
                TreeNode nuevoNodo = CrearNodo(
                    "[tipo]-" + competencia.Celda("tipo").ToString(),
                    competencia.Celda("tipo").ToString().ToLower().CapitalizeFirst(),
                    MenuAgregar
                    );
                
                TvCompetencias.Nodes.Add(nuevoNodo);
            });
        }

        private void CargarCompetenciasDeTipo(string tipo, TreeNode nodoPadre)
        {
            nodoPadre.Nodes.Clear();
            ListaCompetencia.SeleccionarHabilidadesDeTipo(tipo);
            ListaCompetencia.Filas().ForEach(delegate(Fila competencia)
            {
                TreeNode nuevoNodo = CrearNodo(
                   "[habilidad]-" + competencia.Celda("id").ToString(),
                   competencia.Celda("habilidad").ToString().ToLower().CapitalizeFirst(),
                   MenuAgregar
                   );

                nodoPadre.Nodes.Add(nuevoNodo);
            });
            nodoPadre.Expand();
        }

        private void CargarTopicosDeCompetencia(int id, TreeNode nodoPadre)
        {
            TopicoHabilidad topico = new TopicoHabilidad();

            nodoPadre.Nodes.Clear();
            topico.CargarTopicosHabilidad(id);
            topico.Filas().ForEach(delegate(Fila f)
            {
                TreeNode nuevoNodo = CrearNodo(
                        "[topico]-" + f.Celda("id").ToString(),
                        f.Celda("topico").ToString(),
                        MenuAgregar
                        );

                nodoPadre.Nodes.Add(nuevoNodo);
            });
            nodoPadre.Expand();
        }

        private TreeNode CrearNodo(string nombre, string texto, ContextMenuStrip menu = null)
        {
            TreeNode nodoTemp = new TreeNode();
            nodoTemp.Name = nombre;
            nodoTemp.Text = texto;
            nodoTemp.ImageIndex = 0;
            nodoTemp.SelectedImageIndex = 0;
            if (menu != null) 
            { 
                nodoTemp.ContextMenuStrip = menu;
            }
            return nodoTemp;
        }

        private void TvCompetencias_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] nombreDividido = e.Node.Name.Split('-');

            e.Node.Nodes.Clear();

            switch(nombreDividido[0])
            { 
                case "[tipo]":
                    CargarCompetenciasDeTipo(nombreDividido[1], e.Node);
                    break;
                case "[habilidad]":
                    CargarTopicosDeCompetencia(Convert.ToInt32(nombreDividido[1]), e.Node);
                    break;
            }
        }

        private void TvCompetencias_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TvCompetencias.SelectedNode = e.Node;
            string[] nombreNodoDividido = e.Node.Name.Split('-');
            agregarToolStripMenuItem.Enabled = nombreNodoDividido[0].Equals("[tipo]") || nombreNodoDividido[0].Equals("[habilidad]");
            eliminarToolStripMenuItem.Enabled = !nombreNodoDividido[0].Equals("[tipo]");
        }

        private void TvCompetencias_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNodeCollection raiz = null;
            if(e.Node.Parent == null)
            {
                raiz = TvCompetencias.Nodes;
            }
            else
            {
                raiz = e.Node.Parent.Nodes;
            }

            if (e.Node.Name.StartsWith("[tipo]"))
                raiz = TvCompetencias.Nodes;
            else if (e.Node.Name.StartsWith("[habilidad]"))
                raiz = e.Node.Parent.Nodes;

            if(raiz != null)
            {
                foreach (TreeNode nodo in raiz)
                {
                    if (nodo.Name != e.Node.Name)
                    {
                        nodo.Collapse();
                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string resxFile = @".\..\..\Idioma\GlobalString.es.resx"; // relative directory to the executable file
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                MessageBox.Show(resxSet.GetString("0001"));
            }

            if (MessageBox.Show("¿Seguro que desea eliminar este registro?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) 
            {
                string[] nombreDividido = TvCompetencias.SelectedNode.Name.Split('-');
                switch (nombreDividido[0])
                {
                    case "[habilidad]":
                        Competencia competenciaTemporal = new Competencia();
                        competenciaTemporal.CargarDatos(Convert.ToInt32(nombreDividido[1]));
                        competenciaTemporal.BorrarDatos();
                        CargarCompetenciasDeTipo(TvCompetencias.SelectedNode.Parent.Name.Split('-')[1], TvCompetencias.SelectedNode.Parent);
                        break;
                    case "[topico]":
                        TopicoHabilidad topicoTemporal = new TopicoHabilidad();
                        topicoTemporal.CargarDatos(Convert.ToInt32(nombreDividido[1]));
                        topicoTemporal.BorrarDatos();
                        CargarTopicosDeCompetencia(Convert.ToInt32(TvCompetencias.SelectedNode.Parent.Name.Split('-')[1]), TvCompetencias.SelectedNode.Parent);
                        break;
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompetenciasAgregarModificar frmModificar = new FrmCompetenciasAgregarModificar(TvCompetencias.SelectedNode, "MOD");
            if (frmModificar.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            // Refrescar lista de nodos
            string[] nombreDividido = TvCompetencias.SelectedNode.Name.Split('-');
            switch (nombreDividido[0])
            {
                case "[habilidad]":
                    CargarCompetenciasDeTipo(TvCompetencias.SelectedNode.Parent.Name.Split('-')[1], TvCompetencias.SelectedNode.Parent);
                    break;
                case "[topico]":
                    CargarTopicosDeCompetencia(Convert.ToInt32(TvCompetencias.SelectedNode.Parent.Name.Split('-')[1]), TvCompetencias.SelectedNode.Parent);
                    break;
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompetenciasAgregarModificar frmModificar = new FrmCompetenciasAgregarModificar(TvCompetencias.SelectedNode, "ADD");
            if (frmModificar.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            // Refrescar lista de nodos
            string[] nombreDividido = TvCompetencias.SelectedNode.Name.Split('-');
            switch (nombreDividido[0])
            {
                case "[tipo]":
                    CargarCompetenciasDeTipo(nombreDividido[1], TvCompetencias.SelectedNode);
                    break;
                case "[habilidad]":
                    CargarTopicosDeCompetencia(Convert.ToInt32(nombreDividido[1]), TvCompetencias.SelectedNode);
                    break;
            }
        }

        private void TvCompetencias_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.Nodes.Clear();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
