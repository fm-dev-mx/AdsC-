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
using System.IO;
using CB_Base.CB_Forms.Fabricacion;

namespace CB
{
    public partial class FrmPlanosProyecto : Form
    {
        decimal IdProyecto = 0;
        Proyecto ProyectoCargado = new Proyecto();
        int idPlanoCargado = 0;

        public FrmPlanosProyecto(decimal id)
        {
            InitializeComponent();
            ProyectoCargado.CargarDatos(id);
            IdProyecto = id;
        }

        private void FrmPlanosProyecto_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LblTitulo.Text = "PLANOS DEL PROYECTO ";
            LblTitulo.Text += Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")).ToString("F2");
            LblTitulo.Text += " - " + ProyectoCargado.Fila().Celda("nombre").ToString();

            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();

            CmbFiltroEstatus.Text = "SIN REVISAR";

            EnlistarPlanos();

            BtnSubirPlano.Visible = false;
            BtnSubirPlano.Enabled =  IdProyecto < 41 && Global.VerificarPrivilegio("DISEÑO", "SUBIR PLANO");
            menuActualizarPlano.Enabled = IdProyecto < 41 && Global.VerificarPrivilegio("DISEÑO", "ACTUALIZAR PLANO");

            CargarModulos();
        }

        public void EnlistarPlanos()
        {
            decimal idProyecto = Convert.ToDecimal(ProyectoCargado.Fila().Celda("id"));
            DgvPlanos.Rows.Clear();

            List<Fila> planos = new List<Fila>();
            planos = PlanoProyecto.Modelo().SeleccionarEstatus(CmbFiltroEstatus.Text, idProyecto, CmbFiltroModulo.Text);

            planos.ForEach(delegate(Fila plano)
            {
                Object objMiniatura = plano.Celda("miniatura");
                ImageConverter converter = new ImageConverter();
                byte[] miniatura = null;

                if (objMiniatura != null)
                    miniatura = (byte[])objMiniatura;
                else
                    miniatura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                DgvPlanos.Rows.Add(plano.Celda("id"), plano.Celda("nombre_archivo"), plano.Celda("tipo"), plano.Celda("estatus"), plano.Celda("estatus_ensamble"), miniatura);

                DataGridViewCell cell = DgvPlanos.Rows[DgvPlanos.RowCount - 1].Cells[4];
                cell.Style = PlanoProyecto.Modelo().ColorEstatusEnsamble(plano.Celda("estatus_ensamble").ToString());

            });

            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
            splitContainer3.Panel1Collapsed = false;
            splitContainer3.Panel1.Show();
            BorrarPlano();
        }

        public void CargarModulos()
        {
            CmbFiltroModulo.Items.Clear();
            CmbFiltroModulo.Items.Add("TODOS");

            int ban = 0;
            CatalogoMaterial.Modelo().Modulos(IdProyecto).ForEach(delegate (Fila modulo)
            {
                if (modulo.Celda("subensamble").ToString() == "0")
                    ban++;
            });

            if (ban <= 0)
                CmbFiltroModulo.Items.Add("00 - COMPRAS GENERALES");

            CatalogoMaterial.Modelo().Modulos(IdProyecto).ForEach(delegate (Fila modulo)
            {
                CmbFiltroModulo.Items.Add(modulo.Celda("subensamble").ToString().PadLeft(2, '0') + " - " + modulo.Celda("nombre").ToString());
            });

            CmbFiltroModulo.SelectedItem = "TODOS";
        }

        private void BtnSubirPlano_Click(object sender, EventArgs e)
        {
            if (BtnSubirPlano.ContextMenuStrip != null)
                BtnSubirPlano.ContextMenuStrip.Show(BtnSubirPlano, BtnSubirPlano.PointToClient(Cursor.Position));
        }

        private void menuSubirDesdePDF_Click(object sender, EventArgs e)
        {
            FrmSubirPlanoPDF subir = new FrmSubirPlanoPDF( Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")) );
            if( subir.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                EnlistarPlanos();
            }
        }

        private void CmbFiltroEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbFiltroEstatus.Enabled = false;
            EnlistarPlanos();
            CmbFiltroEstatus.Enabled = true;
        }

        public void MostrarPlano(int idPlano)
        {
            BorrarPlano();

            LblCargandoPlano.Visible = true;
            Application.DoEvents();

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlano);

            ArchivoPlano archivo = new ArchivoPlano();
            archivo.SeleccionarDePlano(idPlano);

            string nombre = plano.Fila().Celda("nombre_archivo").ToString();
            string fecha = Convert.ToDateTime(plano.Fila().Celda("fecha_creacion")).ToString("MMM dd yyyy, hh:mm tt");
            string usuario = plano.Fila().Celda("usuario_creacion").ToString();
            string cantidad = plano.Fila().Celda("cantidad").ToString();
            string recibido = plano.Fila().Celda("recibido").ToString();
            string proveedorMaquiando = plano.Fila().Celda("proveedor_maquinado").ToString();
            string tratamiento = plano.Fila().Celda("tratamiento").ToString();
            string estatus = plano.Fila().Celda("estatus").ToString();
            string material = plano.Fila().Celda("material").ToString();

            LblNumeroPlano.Text = idPlano.ToString() + " | " + nombre;
            LblRecibido.Text = recibido + " de " + cantidad;
            LblProveedor.Text = proveedorMaquiando;
            LblFechaPlano.Text = fecha;
            LblUsuario.Text = usuario;
            LblCantidad.Text = cantidad;
            LblTratamiento.Text = tratamiento;
            LblMaterial.Text = material;
            GrupoInfoPlano.Visible = true;
            LblEstatus.Text = estatus;

            if( archivo.TieneFilas() )
                Global.MostrarPDF((byte[])archivo.Fila().Celda("archivo"), nombre, null, VisorPDF);

            idPlanoCargado = idPlano;
            BtnOpcionesPlano.Enabled = true;
            LblCargandoPlano.Visible = false;
            Application.DoEvents();
            
            switch (estatus)
            {
                case "SIN DOCUMENTAR": 
                    BtnOpcionesPlano.ContextMenuStrip = MenuOpcionesPlanoSinDocumentar;
                break;
                
                case "PRELIMINAR": 
                    BtnOpcionesPlano.ContextMenuStrip = MenuOpcionesPlanoSinRevisar;
                break;                
                
                default: 
                    BtnOpcionesPlano.ContextMenuStrip = MenuOpcionesPlanoRevisado;
                break;
            }
            DgvPlanos.ContextMenuStrip = null;
        }

        public void BorrarPlano()
        {
            LblNumeroPlano.Text = "DETALLES DEL PLANO";
            BtnOpcionesPlano.Enabled = false;
            GrupoInfoPlano.Visible = false;
            VisorPDF.LoadFile("none");
        }

        private void BtnOpcionesPlano_Click(object sender, EventArgs e)
        {
            if (BtnOpcionesPlano.ContextMenuStrip != null)
                BtnOpcionesPlano.ContextMenuStrip.Show(BtnOpcionesPlano, BtnOpcionesPlano.PointToClient(Cursor.Position));
        }

        private void verDetallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDetallesPlanoFabricacion detalles = new FrmDetallesPlanoFabricacion(idPlanoCargado);
            detalles.ShowDialog();
        }

        private void verDetallesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDetallesPlanoFabricacion detalles = new FrmDetallesPlanoFabricacion(idPlanoCargado);
            detalles.ShowDialog();
        }

        private void menuActualizarPlano_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlanoCargado);

            if (plano.Fila().Celda("estatus").ToString() != "PENDIENTE" && plano.Fila().Celda("estatus").ToString() != "RECHAZADO")
            {
                MessageBox.Show("Este plano ya ha sido procesado, comunícate con los lideres de fabricación para notificarles la actualización necesaria.");
                return;
            }
                
            FrmSubirPlanoPDF subir = new FrmSubirPlanoPDF(Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")), idPlanoCargado);
            
            if( subir.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                EnlistarPlanos();
            }
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlanoCargado);

            if (plano.Fila().Celda("estatus").ToString() != "PENDIENTE" && plano.Fila().Celda("estatus").ToString() != "RECHAZADO")
            {
                MessageBox.Show("Este plano ya ha sido procesado, comunícate con los lideres de fabricación para notificarles la cancelación.");
                return;
            }
            else
            {
                DialogResult resp = MessageBox.Show("Seguro que quieres cancelar la fabricación de este plano?", "Cancelar fabricación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp != System.Windows.Forms.DialogResult.Yes)
                    return;
            }
            plano.Fila().ModificarCelda("estatus", "CANCELADO");
            plano.GuardarDatos();
            this.Close();
        }

        private void BtnDefinirUniverso_Click(object sender, EventArgs e)
        {
            if( CargarPartes.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                foreach (string nombreArchivo in CargarPartes.SafeFileNames)
                {
                    string nombreArchivoSinExtension = System.IO.Path.GetFileNameWithoutExtension(nombreArchivo);
                    
                    string[] strPartesNomenclatura = nombreArchivoSinExtension.Split('-');
                    string strSubensamble = "0";

                    if (strPartesNomenclatura.ToList().Count >= 2)
                        strSubensamble = strPartesNomenclatura[1];

                    int iSubensamble = Convert.ToInt32(strSubensamble);

                    Dictionary<string, object> parametros = new Dictionary<string,object>();
                    parametros.Add("@nombre_archivo", nombreArchivoSinExtension);
                    parametros.Add("@proyecto", ProyectoCargado.Fila().Celda("id"));

                    PlanoProyecto p = new PlanoProyecto();
                    p.SeleccionarDatos("nombre_archivo=@nombre_archivo AND proyecto=@proyecto", parametros);

                    if (p.TieneFilas())
                    {
                        string nombreArchivoDuplicado = p.Fila().Celda("nombre_archivo").ToString();
                        DialogResult dialog = MessageBox.Show("El plano " + nombreArchivoDuplicado +  " ya existe en este universo, ¿desea subir un plano con el mismo nombre?", "Plano duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog != System.Windows.Forms.DialogResult.Yes)
                            continue;
                    }
                        
                    Fila filaPlano = new Fila();

                    filaPlano.AgregarCelda("proyecto", ProyectoCargado.Fila().Celda("id"));
                    filaPlano.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                    filaPlano.AgregarCelda("cantidad", 0);
                    filaPlano.AgregarCelda("tipo", "N/A");
                    filaPlano.AgregarCelda("material", "N/A");
                    filaPlano.AgregarCelda("presentacion", "N/A");
                    filaPlano.AgregarCelda("size", "N/A");
                    filaPlano.AgregarCelda("tratamiento", "N/A"); 
                    filaPlano.AgregarCelda("nombre_archivo", nombreArchivoSinExtension);
                    filaPlano.AgregarCelda("estatus", "SIN DOCUMENTAR");
                    filaPlano.AgregarCelda("fecha_creacion", DateTime.Now);
                    filaPlano.AgregarCelda("plano_retrabajo", 0);
                    filaPlano.AgregarCelda("comentarios_retrabajo", "");
                    filaPlano.AgregarCelda("comentarios_ensamble", "");
                    filaPlano.AgregarCelda("comentarios_revision", "");
                    filaPlano.AgregarCelda("subensamble", iSubensamble);

                    PlanoProyecto.Modelo().Insertar(filaPlano);
                }
                EnlistarPlanos();
            }
        }

        private void documentarPlanoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSubirPlanoPDF subir = new FrmSubirPlanoPDF(Convert.ToDecimal(ProyectoCargado.Fila().Celda("id")), 0, idPlanoCargado);
            
            if( subir.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                EnlistarPlanos();
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que quieres borrar el plano seleccionado?", "Borrar plano", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(idPlanoCargado);
                plano.BorrarDatos();
                BorrarPlano();
                EnlistarPlanos();
            }
        }

        private void BtnOcultarDetalles_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel2Collapsed = true;
            splitContainer3.Panel2.Hide();
            splitContainer3.Panel1Collapsed = false;
            splitContainer3.Panel1.Show();
            splitContainer2.Panel1Collapsed = false;
            splitContainer2.Panel1.Show();
        }

        private void DgvPlanos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                splitContainer3.Panel2Collapsed = false;
                splitContainer3.Panel2.Show();
                splitContainer3.Panel1Collapsed = true;
                splitContainer3.Panel1.Hide();
                splitContainer2.Panel1Collapsed = true;
                splitContainer2.Panel1.Hide();

                int idPlano = Convert.ToInt32(DgvPlanos.Rows[e.RowIndex].Cells[0].Value);
                MostrarPlano(idPlano);
            }
        }

        private void DgvPlanos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1 && DgvPlanos.ContextMenuStrip != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    var relativeMousePosition = DgvPlanos.PointToClient(Cursor.Position);
                    DgvPlanos.ContextMenuStrip.Show(DgvPlanos, relativeMousePosition);
                }
            }
        }

        private void DgvPlanos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvPlanos.SelectedRows.Count <= 0)
                return;

            idPlanoCargado = Convert.ToInt32(DgvPlanos.SelectedRows[0].Cells[0].Value);
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlanoCargado);

            if (plano.TieneFilas())
            {
                switch (plano.Fila().Celda("estatus").ToString())
                {
                    case "SIN DOCUMENTAR":
                        DgvPlanos.ContextMenuStrip = MenuOpcionesPlanoSinDocumentar;
                        break;

                    case "PRELIMINAR":
                        DgvPlanos.ContextMenuStrip = MenuOpcionesPlanoSinRevisar;
                        break;

                    default:
                        DgvPlanos.ContextMenuStrip = MenuOpcionesPlanoRevisado;
                        break;
                }
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            FrmEscanearPlano scan = new FrmEscanearPlano();
            if (scan.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int idPlano = scan.Id;
                splitContainer3.Panel2Collapsed = false;
                splitContainer3.Panel2.Show();
                splitContainer3.Panel1Collapsed = true;
                splitContainer3.Panel1.Hide();
                splitContainer2.Panel1Collapsed = true;
                splitContainer2.Panel1.Hide();
                MostrarPlano(idPlano);
            }
        }

        private void CmbFiltroModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbFiltroModulo.Enabled = false;
            EnlistarPlanos();
            CmbFiltroModulo.Enabled = true;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            btnReporte.ContextMenuStrip.Show(btnReporte, btnReporte.PointToClient(Cursor.Position));
        }

        private void estatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstatusPlanos estatus = new FrmEstatusPlanos(IdProyecto);
            estatus.Show();
        }
    }
}
