using CB_Base.Classes;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmLibreriasDme : Form
    {
        protected Form Contenido = null;
        string RaizFtp = "\\SGC\\LIB_DME\\";

        public List<System.Management.ManagementObject> ProcesosSolidWorks { get; set; }

        public FrmLibreriasDme()
        {
            InitializeComponent();
        }

        private void FrmLibreriasDme_Load(object sender, EventArgs e)
        {
            CargarNodoCategorias();
        }

        private int ImagenIndex(string extension)
        {
            int imagen = 0;
            switch (extension.ToLower())
            {
                case ".sldprt":
                    imagen = 1;
                    break;
                case ".sldasm":
                    imagen = 2;
                    break;
                default:
                    break;
            }
            return imagen;
        }

        private void CargarNodoCategorias()
        {
            TvLibrerias.Nodes.Clear();
            LibreriaDme lib = new LibreriaDme();
            lib.SeleccionarCategoriaDeSubcategoriasDeLibrerias("MATERIA PRIMA ESPECIAL").ForEach(delegate(Fila f)
            {
                TreeNode tempNode = Global.CrearNodo
                    (
                        "categoria-" + f.Celda("categoria_id"),
                        f.Celda("categoria_nombre").ToString(),
                        ImagenIndex("")
                    );
                TvLibrerias.Nodes.Add(tempNode);
            });
            TvLibrerias.ExpandAll();
        }

        private void CargarSubcategorias(TreeNode nodoPadre)
        {
            nodoPadre.Nodes.Clear();
            string[] nombreDividio = nodoPadre.Name.Split('-');
            LibreriaDme lib = new LibreriaDme();
            lib.SeleccionarSubcategoriasDeLibrerias(nombreDividio[1]).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemp = Global.CrearNodo
                    (
                        "subcategoria-" + f.Celda("subcategoria"),
                        f.Celda("nombre").ToString(),
                        ImagenIndex("")
                    );
                nodoPadre.Nodes.Add(nodoTemp);
            });

        }

        private void CargarFabricantes(TreeNode nodoPadre)
        {
            nodoPadre.Nodes.Clear();
            string[] nombreDividio = nodoPadre.Name.Split('-');
            LibreriaDme lib = new LibreriaDme();
            lib.SeleccionarFabricantesDeLibrerias(nombreDividio[1]).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemp = Global.CrearNodo
                    (
                        "fabricante-" + f.Celda("id"),
                        f.Celda("nombre").ToString(),
                        ImagenIndex("")
                    );
                nodoPadre.Nodes.Add(nodoTemp);
            });
            nodoPadre.Expand();
        }

        private void CargarLibreria(TreeNode nodoPadre)
        {
            nodoPadre.Nodes.Clear();
            string[] nombreDividio = nodoPadre.Name.Split('-');
            LibreriaDme lib = new LibreriaDme();
            lib.CargarLibreria(Convert.ToInt32(nodoPadre.Parent.Name.Split('-')[1]), Convert.ToInt32(nodoPadre.Name.Split('-')[1])).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemp = Global.CrearNodo
                    (
                        "libreria-" + f.Celda("id"),
                        Path.GetFileNameWithoutExtension(f.Celda("nombre_archivo").ToString()),
                        ImagenIndex(Path.GetExtension(f.Celda("nombre_archivo").ToString()))
                    );

                nodoPadre.Nodes.Add(nodoTemp);
                nodoPadre.Expand();
            });
        }

        private void CargarArchivos(TreeNode nodoPadre)
        {
            nodoPadre.Nodes.Clear();
            string[] nombreDividio = nodoPadre.Name.Split('-');
            LibreriaDmeArchivo lib = new LibreriaDmeArchivo();
            lib.SeleccionarArchivosDeLibreria(Convert.ToInt32(nodoPadre.Name.Split('-')[1])).ForEach(delegate(Fila f)
            {
                TreeNode nodoTemp = Global.CrearNodo
                    (
                        "libreriaArchivo-" + f.Celda("id"),
                        Path.GetFileNameWithoutExtension(f.Celda("nombre_archivo").ToString()),
                        ImagenIndex(Path.GetExtension(f.Celda("nombre_archivo").ToString()))
                    );

                nodoPadre.Nodes.Add(nodoTemp);
                nodoPadre.Expand();
            });
        }

        private void registrarLibreríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarLibreriaDme lib = new FrmRegistrarLibreriaDme();
            if(lib.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CargarNodoCategorias();
        }

        private void MenuLibreria_Opening(object sender, CancelEventArgs e)
        {
            string nodoSeleccionado = TvLibrerias.SelectedNode.Name.Split('-')[0];
            registrarLibreríaToolStripMenuItem.Visible = (Global.VerificarPrivilegio("ADMINISTRAR", "LIBRERIAS"));
            editarToolStripMenuItem.Visible = (nodoSeleccionado == "libreria" && Global.VerificarPrivilegio("ADMINISTRAR", "LIBRERIAS"));
            eliminarRemotoToolStripMenuItem.Visible = (nodoSeleccionado == "libreria" &&  Global.VerificarPrivilegio("ADMINISTRAR", "LIBRERIAS"));
            actualizarToolStripMenuItem.Visible = (nodoSeleccionado == "libreria");
            configurarToolStripMenuItem.Visible = (nodoSeleccionado == "libreria");
            eliminarLocalToolStripMenuItem.Visible = (nodoSeleccionado == "libreria");
            
        }

        private void TvLibrerias_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodo(e.Node);
        }

        private void RefrescarNodo(TreeNode nodoPadre)
        {
            string[] nombreDividido = nodoPadre.Name.Split('-');

            switch (nombreDividido[0])
            {
                case "categoria":
                    CargarSubcategorias(nodoPadre);
                    break;
                case "subcategoria":
                    CargarFabricantes(nodoPadre);
                    break;
                case "fabricante":
                    CargarLibreria(nodoPadre);
                    break;
                case "libreria":
                    CargarArchivos(nodoPadre);
                    break;
                default:
                    break;
            }
        }

        public void MostrarContenido(Form contenido)
        {
            if (!(this.Contenido == null))
            {
                this.Contenido.Close();
            }

            Contenido = contenido;
            Contenido.MdiParent = this;
            Contenido.Show();
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea configurar la libreria seleccionada?", "COnfigurar", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if(result != System.Windows.Forms.DialogResult.Yes)
                return;

            string pathLibreriaLocal = string.Empty;
            int idLibreria = Convert.ToInt32(TvLibrerias.SelectedNode.Name.Split('-')[1]);

            LibreriaDme libreria = new LibreriaDme();
            libreria.CargarDatos(idLibreria);

            if (libreria.TieneFilas())
            {
                string libreriaPath = @Directory.GetCurrentDirectory() + RaizFtp + idLibreria.ToString().PadLeft(3, '0');

                //verificar si existe la carpeta en forma local, si no se descargan los documentos
                if (Directory.Exists(libreriaPath))
                {
                    string[] carpetaConArchivos = Directory.GetFiles(libreriaPath, "*.*", SearchOption.AllDirectories);
                    pathLibreriaLocal = Array.Find(carpetaConArchivos, x => x.ToLower().Contains("-lib.sldprt") || x.ToLower().Contains("-lib.sldasm"));
                }
                else
                {
                    // Si no existe la carpeta local se descarga
                    FrmBajarArchivos bajarArchivos = new FrmBajarArchivos(RaizFtp + idLibreria.ToString().PadLeft(3, '0') + "\\", Path.GetFileName(libreria.Fila().Celda("nombre_archivo").ToString()));
                    if (bajarArchivos.ShowDialog() == DialogResult.OK)
                        pathLibreriaLocal = bajarArchivos.PathLocal;
                }

                if (pathLibreriaLocal != null)
                    MostrarContenido(new FrmConfigurarLibreriaDme(pathLibreriaLocal));
                else
                    MessageBox.Show("No se encontró un archivo con terminación '-LIB.sldprt' ó '-LIB.SLDASM'", "Librería no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
                MessageBox.Show("No se encontró en el servidor la librería seleccionada", "Librería no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea actualizar la librería de forma local?", "Actailizar librería", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if(result == System.Windows.Forms.DialogResult.Yes)
            {
                int idLibreria = Convert.ToInt32(TvLibrerias.SelectedNode.Name.Split('-')[1]);
                string pathLocal = Directory.GetCurrentDirectory() + "\\SGC\\LIB_DME\\" + idLibreria.ToString().PadLeft(3, '0');

                LibreriaDme libreria = new LibreriaDme();
                libreria.CargarDatos(idLibreria);

                if (!libreria.TieneFilas())
                {
                    MessageBox.Show("No se pudo encontrar la librería seleccionada", "Librería no encontrada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
                
                ProcesosSolidWorks = Global.BuscarProcesos("sldworks");
                if (ProcesosSolidWorks.Count > 0)
                {
                    FrmCerrarProceso cerrarProcesos = new FrmCerrarProceso(ProcesosSolidWorks, "solidworks");
                    if(cerrarProcesos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //Borrar archivos locales
                        BorrarDirectorioLocal(pathLocal, true);

                        //se descarga nuevamente la librería
                       FrmBajarArchivos bajarArchivos = new FrmBajarArchivos(RaizFtp + idLibreria.ToString().PadLeft(3, '0') + "\\", Path.GetFileName(libreria.Fila().Celda("nombre_archivo").ToString()));
                       bajarArchivos.Show();
                    }
                }
                else
                {
                    //Borrar archivos locales
                    BorrarDirectorioLocal(pathLocal, true);

                    //se descarga nuevamente la librería
                    FrmBajarArchivos bajarArchivos = new FrmBajarArchivos(RaizFtp + idLibreria.ToString().PadLeft(3, '0') + "\\", Path.GetFileName(libreria.Fila().Celda("nombre_archivo").ToString()));
                    bajarArchivos.Show();
                }
            }
        }

        public bool BorrarDirectorioLocal(string pathLocal, bool Recursivo)
        {
            bool directorioBorrado = false;

            try
            {
                //Se borra la librería local
                System.Threading.Thread.Sleep(300);
                Directory.Delete(pathLocal, true);
                directorioBorrado = true;
            }
            catch
            {
                directorioBorrado = false;
            }

            return directorioBorrado;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idLibreria = Convert.ToInt32(TvLibrerias.SelectedNode.Name.Split('-')[1]);
            FrmRegistrarLibreriaDme editar = new FrmRegistrarLibreriaDme(idLibreria);
            editar.Show();
        }

        private void eliminarRemotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("¿Está seguro que desea borra la librería seleccionada?", "Borrar librería", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if(result  == System.Windows.Forms.DialogResult.Yes)
            {
                int idLibreria = Convert.ToInt32(TvLibrerias.SelectedNode.Name.Split('-')[1]);
                if(ServidorFtp.EliminarDirectorio(RaizFtp + idLibreria.ToString().PadLeft(3, '0')))
                {
                    //borrar libreria
                    LibreriaDme borrarLibreria = new LibreriaDme();
                    borrarLibreria.CargarDatos(idLibreria);
                    borrarLibreria.BorrarDatos(idLibreria);
                    borrarLibreria.GuardarDatos();

                    //borrar archivos fr la libreria del ftp
                    LibreriaDmeArchivo.Modelo().SeleccionarArchivosDeLibreria(idLibreria).ForEach(delegate(Fila f)
                    {
                        LibreriaDmeArchivo borrarArchivos = new LibreriaDmeArchivo();
                        borrarArchivos.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        borrarArchivos.BorrarDatos(Convert.ToInt32(borrarArchivos.Fila().Celda("id")));
                        borrarArchivos.GuardarDatos();
                    });
                }

                MessageBox.Show("Librería borrada exitosamente");
                RefrescarNodo(TvLibrerias.SelectedNode.Parent);
            }
        }

        private void eliminarLocalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la librería almacenada en su equipo?", "Eliminar librería",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int idLibreria = Convert.ToInt32(TvLibrerias.SelectedNode.Name.Split('-')[1]);
                string pathLocal = Directory.GetCurrentDirectory() + "\\SGC\\LIB_DME\\" + idLibreria.ToString().PadLeft(3, '0');

                ProcesosSolidWorks = Global.BuscarProcesos("sldworks");
                if (ProcesosSolidWorks.Count > 0)
                {
                    FrmCerrarProceso cerrarProcesos = new FrmCerrarProceso(ProcesosSolidWorks, "solidworks");
                    if (cerrarProcesos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (!BorrarDirectorioLocal(pathLocal, true))
                        {
                            MessageBox.Show("La librería local fue encontrada en su equipo", "Librería no eliminada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                else
                {
                    if (!BorrarDirectorioLocal(pathLocal, true))
                    {
                        MessageBox.Show("La librería local no fue encontrada en su equipo", "Librería no eliminada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                MessageBox.Show("Se eliminó la librería de forma exitosa.", "Eliminar librería", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
