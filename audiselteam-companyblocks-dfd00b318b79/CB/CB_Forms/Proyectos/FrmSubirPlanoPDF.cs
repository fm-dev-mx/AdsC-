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
using CB_Base.Classes;
using ImageMagick;


namespace CB
{
    public partial class FrmSubirPlanoPDF : Form
    {
        int Actualizar;
        int Documentar;
        decimal Proyecto;
        string NombrePlano;
        int PlanoSeleccionadoRetrabajo = 0;
        byte[] DatosPlanoPDF = null;
        byte[] DatosPlanoDXF = null;
        byte[] DatosMiniatura = null;

        public FrmSubirPlanoPDF(decimal proyecto, int actualizar=0, int documentar=0)
        {
            InitializeComponent();
            Proyecto = proyecto;
            Actualizar = actualizar;
            Documentar = documentar;
        }

        private void FrmSubirPlanoPDF_FormClosed(object sender, FormClosedEventArgs e)
        {
     
        }

        private void FrmSubirPlanoPDF_Load(object sender, EventArgs e)
        {
            if( Actualizar != 0 )
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(Actualizar);

                NombrePlano = plano.Fila().Celda("nombre_archivo").ToString();

                LblTitulo.Text = "ACTUALIZAR PLANO " + NombrePlano;
                CargarDatosDesdePlano(Actualizar);

                ArchivoPlano archivo = new ArchivoPlano();
                archivo.SeleccionarDePlano(Actualizar);

                DatosPlanoPDF = (byte[])archivo.Fila().Celda("archivo");

                Global.MostrarPDF(DatosPlanoPDF, NombrePlano, null, VisorPDF);
            }
            else if( Documentar != 0 )
            {
                PlanoProyecto plano = new PlanoProyecto();
                plano.CargarDatos(Documentar);

                NombrePlano = plano.Fila().Celda("nombre_archivo").ToString();

                LblTitulo.Text = "DOCUMENTAR PLANO " + NombrePlano;
            }
            else
            {
                LblTitulo.Text = "SUBIR PLANO DESDE PDF AL PROYECTO " + Proyecto.ToString("F2");
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void cmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( cmbPresentacion.Text.Equals("CILINDRO") )
            {
                LblEspesor.Text = "Diámetro:";

                LblAncho.Visible = false;
                TxtAncho.Visible = false;
            }
            else
            {
                LblEspesor.Text = "Espesor:";

                LblAncho.Visible = true;
                TxtAncho.Visible = true;
            }
        }

        public bool ValidarInformacion()
        {
            if (TxtArchivoPDF.Text.Equals("") && DatosPlanoPDF == null)
                return false;

            if ( (cmbTipoTrabajo.Text == "WATER JET" || cmbTipoTrabajo.Text == "LASER") && (TxtArchivoDXF.Text.Equals("") || DatosPlanoDXF == null) )
                return false;

            if (cmbTipoTrabajo.Text.Equals(""))
                return false;

            if (cmbPresentacion.Text.Equals("") )
                return false;

            if (TxtEspesor.Text.Equals("") )
                return false;

            if (TxtLargo.Text.Equals(""))
                return false;

            if (TxtAncho.Text.Equals("") && !cmbPresentacion.Text.Equals("CILINDRO"))
                return false;

            return true;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            abrirArchivo.DefaultExt = ".pdf";
            abrirArchivo.Filter = "Archivos PDF (.pdf)|*.pdf"; 
            
            if( abrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                NombrePlano = abrirArchivo.SafeFileName.ToUpper().Replace(".PDF", "");
                if (!PlanoProyecto.Modelo().Existe(Proyecto, NombrePlano) || Documentar>0 || Actualizar>0 )
                {   
                    DatosPlanoPDF = File.ReadAllBytes(abrirArchivo.FileName);
                    DatosMiniatura = FormatosPDF.MiniaturaPDF(abrirArchivo.FileName);

                    //DatosPlanoPDF = FormatosPDF.IncrustarQR(DatosPlanoPDF, NombrePlano, 1150, 35);

                    Global.MostrarPDF(DatosPlanoPDF, NombrePlano, null, VisorPDF);
                    TxtArchivoPDF.Text = NombrePlano;
                }
                else
                    MessageBox.Show("El nombre del archivo ya existe para este proyecto");
            }
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if( ValidarInformacion() )
            {
                try
                {
                    if (Actualizar != 0)
                        ActualizarPlano();
                    else if (Documentar != 0)
                        DocumentarPlano();
                    else
                        SubirPlano();

                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                LblInfo.Text = "Ingresa toda la información.";
                LblInfo.Visible = true;
            }
        }

        public void SubirPlano()
        {
            string nombreUsuario = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();

            string[] strPartesNomenclatura = NombrePlano.Split('-');
            string strSubensamble = "0";

            if (strPartesNomenclatura.ToList().Count >= 2)
                strSubensamble = strPartesNomenclatura[1];

            int iSubensamble = Convert.ToInt32(strSubensamble);

            PlanoProyecto plano = new PlanoProyecto();
            Fila filaPlano = new Fila();

            ArchivoPlano archivoPDF = new ArchivoPlano();
            Fila filaArchivoPDF = new Fila();

            ArchivoPlanoDXF archivoDXF = new ArchivoPlanoDXF();
            Fila filaArchivoDXF = new Fila();

            string size = "";

            if (cmbPresentacion.Text != "CILINDRO")
                size = TxtEspesor.Text + " X " + TxtAncho.Text + " X " + TxtLargo.Text;
            else
                size = TxtEspesor.Text + " DIAM. X " + TxtLargo.Text + " LG.";

            filaPlano.AgregarCelda("proyecto", Proyecto);
            filaPlano.AgregarCelda("usuario_creacion", nombreUsuario);
            filaPlano.AgregarCelda("cantidad", NumCantidad.Value);
            filaPlano.AgregarCelda("tipo", cmbTipoTrabajo.Text);
            filaPlano.AgregarCelda("material", "N/A");
            filaPlano.AgregarCelda("presentacion", cmbPresentacion.Text);
            filaPlano.AgregarCelda("size", size);
            filaPlano.AgregarCelda("tratamiento", "N/A");
            filaPlano.AgregarCelda("nombre_archivo", NombrePlano);
            filaPlano.AgregarCelda("estatus", "PRELIMINAR");
            filaPlano.AgregarCelda("fecha_creacion", DateTime.Now);
            filaPlano.AgregarCelda("plano_retrabajo", PlanoSeleccionadoRetrabajo);
            filaPlano.AgregarCelda("comentarios_retrabajo", "");
            filaPlano.AgregarCelda("comentarios_ensamble", "");
            filaPlano.AgregarCelda("comentarios_revision", "");
            filaPlano.AgregarCelda("subensamble", iSubensamble);
            plano.Insertar(filaPlano);

            int idPlano = Convert.ToInt32(filaPlano.Celda("id"));
            
            DatosPlanoPDF = FormatosPDF.IncrustarQR(DatosPlanoPDF, NombrePlano,idPlano.ToString(), 1150, 35);

            filaArchivoPDF.AgregarCelda("plano", idPlano);
            filaArchivoPDF.AgregarCelda("archivo", DatosPlanoPDF);
            filaArchivoPDF.AgregarCelda("miniatura", DatosMiniatura);
            archivoPDF.Insertar(filaArchivoPDF);

            if( DatosPlanoDXF != null)
            {
                filaArchivoDXF.AgregarCelda("plano", idPlano);
                filaArchivoDXF.AgregarCelda("archivo", DatosPlanoDXF);
                archivoDXF.Insertar(filaArchivoDXF);
            }
        }

        public void ActualizarPlano()
        {
            string nombreUsuario = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(Actualizar);

            ArchivoPlano archivoPDF = new ArchivoPlano();
            archivoPDF.SeleccionarDePlano(Actualizar);

            ArchivoPlanoDXF archivoDXF = new ArchivoPlanoDXF();
            archivoDXF.SeleccionarDePlano(Actualizar);

            string size = "";

            if (cmbPresentacion.Text != "CILINDRO")
                size = TxtEspesor.Text + " X " + TxtAncho.Text + " X " + TxtLargo.Text;
            else
                size = TxtEspesor.Text + " DIAM. X " + TxtLargo.Text + " LG.";

            plano.Fila().ModificarCelda("proyecto", Proyecto);
            plano.Fila().ModificarCelda("usuario_creacion", nombreUsuario);
            plano.Fila().ModificarCelda("cantidad", NumCantidad.Value);
            plano.Fila().ModificarCelda("tipo", cmbTipoTrabajo.Text);
            plano.Fila().ModificarCelda("material", "N/A");
            plano.Fila().ModificarCelda("presentacion", cmbPresentacion.Text);
            plano.Fila().ModificarCelda("size", size);
            plano.Fila().ModificarCelda("tratamiento", "N/A");
            plano.Fila().ModificarCelda("nombre_archivo", NombrePlano);
            plano.Fila().ModificarCelda("estatus", "PRELIMINAR");
            plano.Fila().ModificarCelda("fecha_creacion", DateTime.Now);
            plano.Fila().ModificarCelda("plano_retrabajo", PlanoSeleccionadoRetrabajo);
            plano.GuardarDatos();

            archivoPDF.Fila().ModificarCelda("archivo", DatosPlanoPDF);
            archivoPDF.Fila().ModificarCelda("miniatura", DatosMiniatura);
            archivoPDF.GuardarDatos();

            if (DatosPlanoDXF != null)
            {
                archivoDXF.Fila().ModificarCelda("archivo", DatosPlanoDXF);
                archivoDXF.GuardarDatos();
            }
        }

        public void DocumentarPlano()
        {
            string nombreUsuario = Global.UsuarioActual.NombreCompleto();

            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(Documentar);

            string size = "";

            if (cmbPresentacion.Text != "CILINDRO")
                size = TxtEspesor.Text + " X " + TxtAncho.Text + " X " + TxtLargo.Text;
            else
                size = TxtEspesor.Text + " DIAM. X " + TxtLargo.Text + " LG.";

            plano.Fila().ModificarCelda("proyecto", Proyecto);
            plano.Fila().ModificarCelda("usuario_creacion", nombreUsuario);
            plano.Fila().ModificarCelda("cantidad", NumCantidad.Value);
            plano.Fila().ModificarCelda("tipo", cmbTipoTrabajo.Text);
            plano.Fila().ModificarCelda("material", "N/A");
            plano.Fila().ModificarCelda("presentacion", cmbPresentacion.Text);
            plano.Fila().ModificarCelda("size", size);
            plano.Fila().ModificarCelda("tratamiento", "N/A");
            plano.Fila().ModificarCelda("estatus", "PRELIMINAR");
            plano.Fila().ModificarCelda("fecha_creacion", DateTime.Now);
            plano.Fila().ModificarCelda("plano_retrabajo", PlanoSeleccionadoRetrabajo);
            plano.GuardarDatos();

            Fila archivoPDF = new Fila();
            archivoPDF.AgregarCelda("plano", Documentar);
            archivoPDF.AgregarCelda("archivo", DatosPlanoPDF);
            archivoPDF.AgregarCelda("miniatura", DatosMiniatura);
            ArchivoPlano.Modelo().Insertar(archivoPDF);
        }

        private void cmbTipoTrabajo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbTipoTrabajo.Text == "WATER JET")
            //{
            //    cmbPresentacion.Enabled = false;
            //    cmbPresentacion.Text = "PLACA";
            //    BtnIncluirDXF.Visible = false;

            //    FrmSubirPlanoDXF subir = new FrmSubirPlanoDXF();
                
            //    if( subir.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            //    {
            //        DatosPlanoDXF = subir.DatosPlanoDXF;
            //    }
            //    else
            //    {
            //        cmbTipoTrabajo.Text = "REGULAR";
            //    }
            //}
            //else if(cmbTipoTrabajo.Text == "REWORK")
            //{
            //    FrmSeleccionarPlanoRetrabajo retrabajo = new FrmSeleccionarPlanoRetrabajo(Proyecto);

            //    if( retrabajo.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            //    {
            //        this.PlanoSeleccionadoRetrabajo = retrabajo.PlanoSeleccionado;
            //        CargarDatosDesdePlano(retrabajo.PlanoSeleccionado);
            //    }
            //    else
            //    {
            //        cmbTipoTrabajo.Text = "REGULAR";
            //    }
            //}
            //else if(cmbTipoTrabajo.Text == "EXTRA WORK")
            //{
            //    /*
            //    FrmSeleccionarTipoExtrawork extrawork = new FrmSeleccionarTipoExtrawork();

            //    if( extrawork.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            //    {

            //        LblTipoExtrawork.Text = "EXTRAWORK A " + extrawork.NombrePlano;
            //    }
            //    else
            //    {
            //        cmbTipoMaterial.Text = "";
            //        LblTipoExtrawork.Text = "EXTRAWORK A PARTE COMPRADA";
            //    }
            //    LblTipoExtrawork.Visible = true;
            //     */
            //}
            //else
            //{
            //    cmbPresentacion.Enabled = true;
            //    //BtnIncluirDXF.Visible = true;
            //    DatosPlanoDXF = null;
            //}
        }

        void CargarDatosDesdePlano(int idPlano)
        {
            PlanoProyecto plano = new PlanoProyecto();
            plano.CargarDatos(idPlano);

            string tipo = plano.Fila().Celda("tipo").ToString();

            if (tipo == "REGULAR")
                cmbTipoTrabajo.Text = tipo;

            cmbPresentacion.Text = plano.Fila().Celda("presentacion").ToString();

            MaterialMaquinado material = new MaterialMaquinado();
            material.SeleccionarNombre(plano.Fila().Celda("material").ToString());

            string[] dimensiones = plano.Fila().Celda("size").ToString().Split('X');

            TxtEspesor.Text = dimensiones[0].Trim();
            TxtAncho.Text = dimensiones[1].Trim();

            if(dimensiones.Count() >= 3)
                TxtLargo.Text = dimensiones[2].Trim();

            NumCantidad.Value = Convert.ToInt32(plano.Fila().Celda("cantidad"));
        }

        private void BtnIncluirDXF_Click(object sender, EventArgs e)
        {

        }

        private void BtnBuscarDXF_Click(object sender, EventArgs e)
        {
            abrirArchivo.DefaultExt = ".dxf";
            abrirArchivo.Filter = "Archivos DXF (.dxf)|*.dxf";

            if (abrirArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtArchivoDXF.Text = abrirArchivo.SafeFileName.ToUpper().Replace(".DXF", "");
                DatosPlanoDXF = File.ReadAllBytes(abrirArchivo.FileName);
            }
        }
    }
}
