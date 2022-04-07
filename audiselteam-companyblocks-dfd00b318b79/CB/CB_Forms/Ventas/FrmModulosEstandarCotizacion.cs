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
    public partial class FrmModulosEstandarCotizacion : Form
    {
        int IdCotizacion = 0;

        public FrmModulosEstandarCotizacion(int idCotizacion)
        {
            InitializeComponent();
            IdCotizacion = idCotizacion;
        }

        private void FrmModulosEstandarCotizacion_Load(object sender, EventArgs e)
        {
            CargarModulos();
        }

        private void CargarModulos()
        {
            TvModulos.Nodes.Clear();

            //Obtenemos todos los módulos de la BD
            ModuloEstandar modulos = new ModuloEstandar();
            modulos.SeleccionarDatos("", null).ForEach(delegate(Fila f)
            {
                int imagenModulo = 0;
                int idModuloCotizacion = 0;

                //Buscamos si existen módulos vinculados a la cotización actual
                ModuloEstandarCotizacion moduloCotizacion = new ModuloEstandarCotizacion();
                moduloCotizacion.SeleccionarModulosDeCotizacion(Convert.ToInt32(f.Celda("id")), IdCotizacion);

                if (moduloCotizacion.TieneFilas())
                {
                    //Si existen módulos vinculados cambiamos la imagen del nodo y agregamos el id
                    imagenModulo = 3;
                    idModuloCotizacion = Convert.ToInt32(moduloCotizacion.Fila().Celda("id"));
                }

                //Creamos el nodo
                TreeNode nodo = Global.CrearNodo
                (
                    "modulo-" + f.Celda("id") + "-" + idModuloCotizacion,
                    f.Celda("nombre").ToString(),
                    imagenModulo,
                    MenuPrincipal
                );

                //Agregamos el nodo
                TvModulos.Nodes.Add(nodo);

                //Cargamos los nodos Hijos (En caso que contenga)
                CargarCaracteristicasOpciones(nodo);
            });
        }

        private void CargarCaracteristicasOpciones(TreeNode NodoPadre)
        {
            NodoPadre.Nodes.Clear();

            //Cargamos las opciones vinculadas
            ModuloEstandarCaracteristicaOpcion.Modelo().SeleccionarDeModuloYCotizacion(IdCotizacion, Convert.ToInt32(NodoPadre.Name.Split('-')[1])).ForEach(delegate(Fila f)
            {
                //creamos un nodo temporal con la información
                TreeNode nodoTemporal = Global.CrearNodo
                    (
                        "caracteristicaOpcion-" + f.Celda("id"),
                        f.Celda("nombre_caracteristica").ToString() + ": " + f.Celda("nombre_opcion").ToString(),
                        2,
                        MenuCaracteristicasEliminar
                    );
                //Agregamos el nodo temporal al nodo padre
                NodoPadre.Nodes.Add(nodoTemporal);
            });

            NodoPadre.ExpandAll();
        }

        private void CargarModuloSeleccionado(TreeNode nodoSeleccionado)
        {
            //Obtenemos el índice del nodo que pretendemos modificar
            int index = TvModulos.Nodes.IndexOf(nodoSeleccionado);
            //Obtenemos el id del módulo del nodo seleccionado
            int idModulo = Convert.ToInt32(nodoSeleccionado.Name.Split('-')[1]);
            //removemos el nodoactual
            TvModulos.Nodes.RemoveAt(index);
            //cargamos la información en un nodo temporal
            ModuloEstandar.Modelo().SeleccionarModuloPorId(idModulo).ForEach(delegate(Fila f)
            {
                int imagenModulo = 0;
                int idModuloCotizacion = 0;

                ModuloEstandarCotizacion moduloCotizacion = new ModuloEstandarCotizacion();
                moduloCotizacion.SeleccionarModulosDeCotizacion(Convert.ToInt32(f.Celda("id")), IdCotizacion);

                if (moduloCotizacion.TieneFilas())
                {
                    imagenModulo = 3;
                    idModuloCotizacion = Convert.ToInt32(moduloCotizacion.Fila().Celda("id"));
                }

                TreeNode nodo = Global.CrearNodo
                (
                    "modulo-" + f.Celda("id") + "-" + idModuloCotizacion,
                    f.Celda("nombre").ToString(),
                    imagenModulo,
                    MenuPrincipal
                );
                //Agregamos un nuevo nodo en el índice para reemplazar con el nuevo nodo
                TvModulos.Nodes.Insert(index, nodo);
                //Cargamos los nodos hijos(en caso de tenerlos)
                CargarCaracteristicasOpciones(nodo);
            });

        }

        private void RefrescarNodo(TreeNode nodoPadre)
        {
            string[] nombreDividido = nodoPadre.Name.ToString().Split('-');

            switch (nombreDividido[0])
            {
                case "modulo":
                    if (Convert.ToInt32(nombreDividido[2]) > 0)
                        CargarCaracteristicasOpciones(nodoPadre);
                    break;
                default:
                    break;
            }
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] nombreDividid = TvModulos.SelectedNode.Name.Split('-');
            FrmNuevaCaracteristica nueva = new FrmNuevaCaracteristica(Convert.ToInt32(nombreDividid[1]), IdCotizacion, Convert.ToInt32(nombreDividid[2]));
            if (nueva.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarModuloSeleccionado(TvModulos.SelectedNode);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result= MessageBox.Show("¿Está seguro que desea eliminar la característica seleccionada?", "Eliminar característica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            int idCaracteristicaOpcion = Convert.ToInt32(TvModulos.SelectedNode.Name.Split('-')[1]);

            //Eliminamos la opción seleccionada
            ModuloEstandarCaracteristicaOpcion caracteristicaOpciones = new ModuloEstandarCaracteristicaOpcion();
            caracteristicaOpciones.CargarDatos(idCaracteristicaOpcion);
            caracteristicaOpciones.BorrarDatos(idCaracteristicaOpcion);
            caracteristicaOpciones.GuardarDatos();
            //Actualizamos el nodo seleccionado
            RefrescarNodo(TvModulos.SelectedNode.Parent);
        }

        private void agregarMóduloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿SEstá seguro de agregar el módulo seleccionado?", "Agregar módulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                Fila insertarModulo = new Fila();
                insertarModulo.AgregarCelda("id_cotizacion", IdCotizacion);
                insertarModulo.AgregarCelda("id_modulo", Convert.ToInt32(TvModulos.SelectedNode.Name.Split('-')[1]));
                ModuloEstandarCotizacion.Modelo().Insertar(insertarModulo);

                CargarModuloSeleccionado(TvModulos.SelectedNode);
            }
        }

        private void MenuPrincipal_Opening(object sender, CancelEventArgs e)
        {
            string[] nombreDividido = TvModulos.SelectedNode.Name.Split('-');
            if (nombreDividido[0].StartsWith("caracteristicaOpcion"))
                return;

            agregarMóduloToolStripMenuItem.Visible = (Convert.ToInt32(nombreDividido[2]) == 0);
            nuevaCaracterísticaToolStripMenuItem.Visible = (Convert.ToInt32(nombreDividido[2]) > 0);
            quitarDeMóduloToolStripMenuItem.Visible = (Convert.ToInt32(nombreDividido[2]) > 0);
            eliminarCaracterísticasToolStripMenuItem.Visible = (TvModulos.SelectedNode.Nodes.Count > 0);
        }

        private void EliminarNodosHijos(TreeNode nodoPadre)
        {
            foreach (TreeNode nodo in nodoPadre.Nodes)
            {
                int idCaracteristicaOpcion = Convert.ToInt32(nodo.Name.Split('-')[1]);

                ModuloEstandarCaracteristicaOpcion borrarCaracteristicaOpcion = new ModuloEstandarCaracteristicaOpcion();
                borrarCaracteristicaOpcion.CargarDatos(idCaracteristicaOpcion);
                borrarCaracteristicaOpcion.BorrarDatos(idCaracteristicaOpcion);
                borrarCaracteristicaOpcion.GuardarDatos();
            }
        }

        private void eliminarCaracterísticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar todas las características del módulo seleccionado?", "Eliminar característica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            EliminarNodosHijos(TvModulos.SelectedNode);
            CargarModuloSeleccionado(TvModulos.SelectedNode);
        }

        private void quitarDeMóduloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea quitar el módulo seleccionado?", "Eliminar módulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            EliminarNodosHijos(TvModulos.SelectedNode);
            ModuloEstandarCotizacion.Modelo().SeleccionarModulosDeCotizacion(Convert.ToInt32(TvModulos.SelectedNode.Name.Split('-')[1]), IdCotizacion).ForEach(delegate(Fila f)
            {
                ModuloEstandarCotizacion borrarModiloEstandarCotizacion = new ModuloEstandarCotizacion();
                borrarModiloEstandarCotizacion.CargarDatos(Convert.ToInt32(f.Celda("id")));
                borrarModiloEstandarCotizacion.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                borrarModiloEstandarCotizacion.GuardarDatos();
            });

            CargarModuloSeleccionado(TvModulos.SelectedNode);
        }
    }
}
