using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FluentFTP;
using System.Net;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmManualDeCalidad : Ventana
    {
        FtpClient ClienteFtp = new FtpClient();

        public FrmManualDeCalidad()
        {
            InitializeComponent();
        }

        private void FrmManualDeCalidad_Load(object sender, EventArgs e)
        {
            CargarPoliticaCalidad();
            CargarTreeView();
            TxtPolitica.ReadOnly = true;      
            LblArchivo.Text = "";

            if (Global.TipoConexion == "LOCAL")
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorLocal;
            else
                ClienteFtp.Host = Global.ConfiguracionActual.FtpServidorRemoto;

            ClienteFtp.Credentials = new NetworkCredential(Global.UsuarioActual.Fila().Celda("correo").ToString(),
                                                           Global.UsuarioActual.Fila().Celda("password").ToString());

            // Verificar conexion con servidor FTP
            try
            {
                ClienteFtp.Connect();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No fue posible crear una conexión con el servidor", "Error de comunicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void CargarTreeView()
        {
            DocumentoSgc documentoSgc = new DocumentoSgc();
            documentoSgc.Departamentos().ForEach(delegate(Fila f)
            {
                TreeNode nodoDepartamento = CrearNodosDepartamentos(f);
                if (nodoDepartamento != null)
                {
                    int indiceNodo = TvDepartamentos.Nodes.IndexOfKey(nodoDepartamento.Name);

                    if (indiceNodo >= 0)
                    {
                        TvDepartamentos.Nodes.RemoveAt(indiceNodo);
                        TvDepartamentos.Nodes.Insert(indiceNodo, nodoDepartamento);
                    }
                    else
                    {
                        TvDepartamentos.Nodes.Add(nodoDepartamento);
                    }
                }
            });
        }

        private TreeNode CrearNodosDepartamentos(Fila departamentos)
        {
            TreeNode nodoDepartamento = new TreeNode();

            string departamento = departamentos.Celda("departamento").ToString();
            nodoDepartamento.Name = departamento;
            nodoDepartamento.Text = departamento;

            nodoDepartamento.ImageIndex = 0;
            nodoDepartamento.SelectedImageIndex = 0;

            //agregar imagen del color según el estatus

            DocumentoSgc documentoSgc = new DocumentoSgc();
            List<Fila> cargarDocumentos = documentoSgc.Documentos(departamento);

            //Cargamos los nodos 
            cargarDocumentos.ForEach(delegate(Fila documento)
            {
                CargarSubNodoDocumento(nodoDepartamento, documento);
            });

            nodoDepartamento.ExpandAll();
            return nodoDepartamento;

        }

        public void CargarSubNodoDocumento(TreeNode nodoPadre, Fila filaDocumento)
        {
            TreeNode nodoDocumento = null;

            int idDocumento = Convert.ToInt32(filaDocumento.Celda("id"));
            string tipoDocumento = filaDocumento.Celda("tipo_archivo").ToString();
            string consecutivo = filaDocumento.Celda("consecutivo").ToString();
            string titulo = Path.GetFileNameWithoutExtension(filaDocumento.Celda("titulo").ToString()).Split('-').Last().TrimStart();

            string nombre = idDocumento.ToString();
            string textoNodo = tipoDocumento + "-" + consecutivo.PadLeft(2, '0') + " - " + titulo; 

            if (nodoPadre.Nodes.ContainsKey(nombre))
                nodoDocumento = nodoPadre.Nodes[nombre];
            else
                nodoDocumento = nodoPadre.Nodes.Add(nombre, textoNodo);

            if(filaDocumento.Celda("extension").ToString().ToUpper() == ".PDF")
            {
                nodoDocumento.ImageIndex = 1;
                nodoDocumento.SelectedImageIndex = 1;
            }
            else
            {
                nodoDocumento.ImageIndex = 2;
                nodoDocumento.SelectedImageIndex = 2;
            }
        }

        private void TvDepartamentos_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode tvNodo = TvDepartamentos.GetNodeAt(e.X, e.Y);
            if (tvNodo == null)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    registrarArchivoToolStripMenuItem.Visible = true;
                    actualizarToolStripMenuItem.Visible = false;
                    eliminarToolStripMenuItem.Visible = false;
                    guardarEnEquipoToolStripMenuItem.Visible = false;
                    Menu.Show(TvDepartamentos, e.Location);
                }
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {    
                    //nodo hijo, documentos
                    if (TvDepartamentos.SelectedNode.Parent != null) 
                    {
                        registrarArchivoToolStripMenuItem.Visible = false;
                        actualizarToolStripMenuItem.Visible = true;
                        eliminarToolStripMenuItem.Visible = true;
                        guardarEnEquipoToolStripMenuItem.Visible = true;
                        Menu.Show(TvDepartamentos, e.Location);
                    }
                    //nodo padre
                    else if (TvDepartamentos.SelectedNode.Parent == null)
                    {
                        registrarArchivoToolStripMenuItem.Visible = true
                            ;
                        actualizarToolStripMenuItem.Visible = false;
                        guardarEnEquipoToolStripMenuItem.Visible = false;
                        eliminarToolStripMenuItem.Visible = true;
                        Menu.Show(TvDepartamentos, e.Location);
                    }
                }
            }
        }

        private void registrarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            FrmRegistrarArchivo registrar = new FrmRegistrarArchivo();
            if(registrar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    //Guardar información del documento en la BD
                    Fila agregarDocumento = new Fila();
                    agregarDocumento.AgregarCelda("departamento", registrar.Departamento);
                    agregarDocumento.AgregarCelda("tipo_archivo", registrar.TipoArchivo);
                    agregarDocumento.AgregarCelda("consecutivo", registrar.Consecutivo);
                    agregarDocumento.AgregarCelda("revision", registrar.Revision);
                    agregarDocumento.AgregarCelda("comentarios_revision", registrar.Comentarios);
                    agregarDocumento.AgregarCelda("usuario_creacion", registrar.CreadorDocumento);
                    agregarDocumento.AgregarCelda("usuario_revision", registrar.Revisa);
                    agregarDocumento.AgregarCelda("usuario_aprobacion", registrar.UsuarioAprobacion);
                    agregarDocumento.AgregarCelda("fecha_revision", DateTime.Now);
                    agregarDocumento.AgregarCelda("titulo", registrar.NombreDocumento);
                    agregarDocumento.AgregarCelda("extension", registrar.Extension);
                    int idDocumento = Convert.ToInt32(DocumentoSgc.Modelo().Insertar(agregarDocumento).Celda("id"));

                    //Guardar documento en FTP
                    //Verificamos si existe el directorio, sino lo creamos
                    if (!ClienteFtp.DirectoryExists("SGC"))
                        ClienteFtp.CreateDirectory("SGC");

                    // enviar archivos a carpeta ftp
                    ClienteFtp.Upload(registrar.Documento, "SGC\\" + idDocumento + registrar.Extension, FtpExists.Overwrite);
                    
                    MessageBox.Show("Documento creado correctamente", "Documento creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTreeView();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error mientras se guardaba su documento, si el problema continua pongase en contacto con el personal de sistemas." + Environment.NewLine + "Error: " + ex.ToString(), "Error al guardar su documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentoSgc documentoSgc = new DocumentoSgc();
            string subNodo = TvDepartamentos.SelectedNode.Name;
            
            FrmRegistrarArchivo actualizar = new FrmRegistrarArchivo(Convert.ToInt32(subNodo));
            if (actualizar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                documentoSgc.CargarDatos(Convert.ToInt32(subNodo));
                if(documentoSgc.TieneFilas())
                {
                    try
                    {
                        documentoSgc.Fila().ModificarCelda("departamento", actualizar.Departamento);
                        documentoSgc.Fila().ModificarCelda("tipo_archivo", actualizar.TipoArchivo);
                        documentoSgc.Fila().ModificarCelda("consecutivo", actualizar.Consecutivo.PadLeft(2,'0'));
                        documentoSgc.Fila().ModificarCelda("revision", actualizar.Revision);
                        documentoSgc.Fila().ModificarCelda("comentarios_revision", actualizar.Comentarios);
                        documentoSgc.Fila().ModificarCelda("usuario_creacion", actualizar.CreadorDocumento);
                        documentoSgc.Fila().ModificarCelda("usuario_revision", actualizar.Revisa);
                        documentoSgc.Fila().ModificarCelda("usuario_aprobacion", actualizar.UsuarioAprobacion);
                        documentoSgc.Fila().ModificarCelda("fecha_revision", DateTime.Now);
                        documentoSgc.Fila().ModificarCelda("titulo", actualizar.NombreDocumento);
                        documentoSgc.Fila().ModificarCelda("extension", actualizar.Extension);
                        documentoSgc.GuardarDatos();

                        //Guardar documento en FTP
                        //Verificamos si existe el directorio, sino lo creamos
                        if (!ClienteFtp.DirectoryExists("SGC"))
                            ClienteFtp.CreateDirectory("SGC");

                        // enviar archivos a carpeta ftp
                        ClienteFtp.Upload(actualizar.Documento, "SGC\\" + subNodo + actualizar.Extension, FtpExists.Overwrite);
                        MessageBox.Show("Documento actualizado correctamente", "Documento actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTreeView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error mientras se actualizaba su información, si el problema continua pongase en contacto con el personal de sistemas." + Environment.NewLine + "Error: " + ex.ToString(), "Error al actualizar información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TvDepartamentos_DoubleClick(object sender, EventArgs e)
        {
            if (TvDepartamentos.SelectedNode == null)
                return;

            DocumentoSgc documentoSgc = new DocumentoSgc();
            string subNodo = TvDepartamentos.SelectedNode.Name;

            if (TvDepartamentos.SelectedNode.Parent != null)
            {
                documentoSgc.CargarDatos(Convert.ToInt32(subNodo));
                if (documentoSgc.TieneFilas())
                {
                    if (documentoSgc.Fila().Celda("extension").ToString().ToUpper() == ".PDF")
                    {
                        if(ClienteFtp.IsConnected)
                        {
                            string archivoRemoto = "SGC\\" + documentoSgc.Fila().Celda("id").ToString() + documentoSgc.Fila().Celda("extension").ToString();
                            if(ClienteFtp.FileExists(archivoRemoto))
                            {
                                byte[] archivo = null;                            
                                ClienteFtp.Download(out archivo, archivoRemoto);
                                Global.MostrarPDF((byte[])archivo, documentoSgc.Fila().Celda("titulo").ToString(), null, VisorPDF);
                            }
                        }
                    }
                    else
                        Global.MostrarPDF(null, "", null, VisorPDF);

                    LblArchivo.Text = "Documento: " + Path.GetFileNameWithoutExtension(documentoSgc.Fila().Celda("titulo").ToString()) + " | Rev. " + documentoSgc.Fila().Celda("revision") + " | Ultima revisión: " + documentoSgc.Fila().Celda("fecha_revision").ToString(); 
                }
            }
        }

        private void guardarEnEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentoSgc documentoSgc = new DocumentoSgc();
            string subNodo = TvDepartamentos.SelectedNode.Name;

            if (TvDepartamentos.SelectedNode.Parent != null)
            {
                documentoSgc.CargarDatos(Convert.ToInt32(subNodo));
                if (documentoSgc.TieneFilas())
                {
                    SaveFileDialog guardarArchivo = new SaveFileDialog();
                    guardarArchivo.Title = "Guardar documento";
                    guardarArchivo.FileName = documentoSgc.Fila().Celda("titulo").ToString();
                    guardarArchivo.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    guardarArchivo.FilterIndex = 2;
                    guardarArchivo.RestoreDirectory = true;
                    if (guardarArchivo.ShowDialog() == DialogResult.OK)
                    {
                        if (ClienteFtp.IsConnected)
                        {
                            string archivoRemoto = "SGC\\" + subNodo + documentoSgc.Fila().Celda("extension").ToString();
                            if (ClienteFtp.FileExists(archivoRemoto))
                            {
                                byte[] archivo = null;
                                ClienteFtp.Download(out archivo, archivoRemoto);
                                File.WriteAllBytes(guardarArchivo.FileName, (byte[])archivo);
                            }
                        }
                       
                    }
                }
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = string.Empty;
            string nodoSeleccionado = TvDepartamentos.SelectedNode.Name;
            int numerico = 0;
            DocumentoSgc documento = new DocumentoSgc();

            if (nodoSeleccionado == null || nodoSeleccionado == "")
                return;

            DialogResult result = MessageBox.Show("La información que borre no podrá ser recuperada en el futuro, ¿Desea continuar?", "Borrar información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result != DialogResult.OK)
                return;

            if (int.TryParse(nodoSeleccionado, out numerico))
            {
                int IdBorrar = (Convert.ToInt32(nodoSeleccionado));

                documento.CargarDatos(IdBorrar);
                documento.BorrarDatos(IdBorrar);
                documento.GuardarDatos();
                if (ClienteFtp.IsConnected)
                {
                    if (ClienteFtp.FileExists("SGC\\" + IdBorrar + documento.Fila().Celda("extension").ToString()))
                        ClienteFtp.DeleteFile("SGC\\" + IdBorrar + documento.Fila().Celda("extension").ToString());
                }                          
            }
            if (TvDepartamentos.SelectedNode.Parent == null)
            {//nodo padre
                string departamento = "";

                if (TvDepartamentos.SelectedNode.Parent != null)
                    departamento = TvDepartamentos.SelectedNode.Parent.Text;
                else if (TvDepartamentos.SelectedNode.Parent == null)
                    departamento = TvDepartamentos.SelectedNode.Text;

                documento.SelecionarDepartamento(departamento).ForEach(delegate(Fila f)
                {
                    int borrar = Convert.ToInt32(f.Celda("id"));
                    DocumentoSgc borrarDocumento = new DocumentoSgc();
                    borrarDocumento.CargarDatos(borrar);
                    borrarDocumento.BorrarDatos(borrar);
                    borrarDocumento.GuardarDatos();
                    if (ClienteFtp.IsConnected)
                    {
                        if (ClienteFtp.FileExists("SGC\\" + borrar + documento.Fila().Celda("extension").ToString()))
                            ClienteFtp.DeleteFile("SGC\\" + borrar + documento.Fila().Celda("extension").ToString());
                    }
                });
            }

            Global.MostrarPDF(null, "", null, VisorPDF);
            TvDepartamentos.Nodes.Clear();
            CargarTreeView();
        }

        private void nuevaPoíticaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmAgregarPoliticaCalidad registrarPolitica = new FrmAgregarPoliticaCalidad();
            if (registrarPolitica.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Fila agregarDocumento = new Fila();
                    agregarDocumento.AgregarCelda("politica", registrarPolitica.Politica);                                     
                    agregarDocumento.AgregarCelda("usuario_creacion", registrarPolitica.CreadorPolitica);
                    agregarDocumento.AgregarCelda("usuario_revision", registrarPolitica.Revisa);
                    agregarDocumento.AgregarCelda("usuario_aprobacion", registrarPolitica.UsuarioAprobacion);
                    agregarDocumento.AgregarCelda("fecha_revision", DateTime.Now);
                    agregarDocumento.AgregarCelda("comentarios_revision", registrarPolitica.Comentarios);
                    agregarDocumento.AgregarCelda("revision", registrarPolitica.Revision);                  
                    PoliticaCalidad.Modelo().Insertar(agregarDocumento);

                    MessageBox.Show("Documento creado correctamente", "Documento creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPoliticaCalidad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error mientras se guardaba su documento, si el problema continua pongase en contacto con el personal de sistemas." + Environment.NewLine + "Error: " + ex.ToString(), "Error al guardar su documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CargarPoliticaCalidad()
        {
            PoliticaCalidad politica = new PoliticaCalidad();
            politica.SeleccionarDatos("",null);

            if(politica.TieneFilas())
            {
                LblPolitica.Text = "Política de calidad | Rev. " + politica.Fila().Celda("revision").ToString() + " | " + Convert.ToDateTime(politica.Fila().Celda("fecha_revision")).ToString("MMM dd, yyyy hh:mm:ss tt");
                TxtPolitica.Text = politica.Fila().Celda("politica").ToString();
                nuevaPoíticaToolStripMenuItem.Visible = false;
                editarPolíticaToolStripMenuItem.Visible = true;
                eliminarPolíticaToolStripMenuItem.Visible = true;
            }
            else
            {
                LblPolitica.Text = "Política de calidad";
                TxtPolitica.Text = "";
                nuevaPoíticaToolStripMenuItem.Visible = true;
                editarPolíticaToolStripMenuItem.Visible = false;
                eliminarPolíticaToolStripMenuItem.Visible = false;
            }
        }

        private void editarPolíticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarPoliticaCalidad EditarPolitica = new FrmAgregarPoliticaCalidad(TxtPolitica.Text);
            if (EditarPolitica.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    PoliticaCalidad politicaCalidad = new PoliticaCalidad();
                    politicaCalidad.CargarDatos(Convert.ToInt32(EditarPolitica.IdPolitica)).ForEach(delegate(Fila f)
                    {
                        politicaCalidad.Fila().ModificarCelda("politica", EditarPolitica.Politica);
                        politicaCalidad.Fila().ModificarCelda("usuario_creacion", EditarPolitica.CreadorPolitica);
                        politicaCalidad.Fila().ModificarCelda("usuario_revision", EditarPolitica.Revisa);
                        politicaCalidad.Fila().ModificarCelda("usuario_aprobacion", EditarPolitica.UsuarioAprobacion);
                        politicaCalidad.Fila().ModificarCelda("fecha_revision", DateTime.Now);
                        politicaCalidad.Fila().ModificarCelda("comentarios_revision", EditarPolitica.Comentarios);
                        politicaCalidad.Fila().ModificarCelda("revision", EditarPolitica.Revision);
                        politicaCalidad.GuardarDatos();
                    });
                    
                    MessageBox.Show("Documento creado correctamente", "Documento creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPoliticaCalidad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error mientras se guardaba su documento, si el problema continua pongase en contacto con el personal de sistemas." + Environment.NewLine + "Error: " + ex.ToString(), "Error al guardar su documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtPolitica_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TxtPolitica.ShortcutsEnabled = false;

                if (((string)Global.UsuarioActual.Fila().Celda("rol").ToString() != "SUPERUSER"))
                    return;

                MenuPoliticaCalidad.Show(TxtPolitica, e.Location);
            }
        }

        private void eliminarPolíticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("La información está a punto de borrar no podrá ser recuperada en el futuro, ¿Esta seguro de continuar?", "Borrar política", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                PoliticaCalidad politica = new PoliticaCalidad();
                string[] lblpolitica = LblPolitica.Text.Split('|');

                politica.ObtenerId(TxtPolitica.Text, Convert.ToInt32(lblpolitica[1].Split('.')[1].Trim()));
                if (politica.TieneFilas())
                {
                    int idPolitoca = Convert.ToInt32(politica.Fila().Celda("id"));
                    politica.CargarDatos(idPolitoca);
                    politica.BorrarDatos(idPolitoca);
                    politica.GuardarDatos();
                }
                CargarPoliticaCalidad();
            }
        }

        private void TvDepartamentos_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmConsultarListaMaestraDocumentos listaMaestra = new FrmConsultarListaMaestraDocumentos();
            listaMaestra.Show();
        }
    }
}
