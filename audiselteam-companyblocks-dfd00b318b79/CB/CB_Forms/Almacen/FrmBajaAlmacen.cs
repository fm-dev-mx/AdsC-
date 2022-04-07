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
using System.Diagnostics;
using System.Drawing.Printing;

namespace CB
{
    public partial class FrmBajaAlmacen : Ventana
    {
        MaterialProyecto Materiales = new MaterialProyecto();
        MaterialStock MaterialStock = new MaterialStock();
        //int TotalMaterial;
        string StockProyecto = "";
        string BajaMaterial = string.Empty;
        List<int> IdMateriales = new List<int>();
        List<int> Cantidad = new List<int>();
        byte[] archivo = null;


        public FrmBajaAlmacen(List<int> idMaterial, string bajaMaterialOrdenStock, List<int> cantidad)
        {
            InitializeComponent();
            IdMateriales = idMaterial;
            Cantidad = cantidad;
            BajaMaterial = bajaMaterialOrdenStock;

            switch (bajaMaterialOrdenStock)
            {
                case "MATERIAL PROYECTOS":
                    StockProyecto = "MATERIAL PROYECTOS";
                    BtnEntregar.Enabled = false;
                    break;

                case "MATERIAL STOCK":
                    StockProyecto = "MATERIAL STOCK";
                    CmbUsuarios.Enabled = true;
                    BtnEntregar.Enabled = false;
                    break;
            }

            CargarUsuarios();
        }

        public void MostrarPDF(List<int> idMateriales, string nombreSolicitante)
        {
            switch (BajaMaterial)
            {
                case "MATERIAL PROYECTOS":
                    archivo = FormatosPDF.BajaMaterialAlmacen(idMateriales, CmbUsuarios.Text);
                     Global.MostrarPDF(archivo, "BAJA_ALMACEN", null, VisorPDF);
                    break;
                case "MATERIAL STOCK":
                    archivo = FormatosPDF.BajaMaterialStock(idMateriales, CmbUsuarios.Text);
                     Global.MostrarPDF(archivo, "BAJA_ALMACEN", null, VisorPDF);
                    break;
                default:
                    break;
            }
             
        }
       
        public void EntregarMaterial()
        {       

            foreach (int filaActual in IdMateriales)
            {
                Materiales.CargarDatos(filaActual);
                int cantidadAlmacen =  Convert.ToInt32(Materiales.Fila().Celda("cantidad_almacen"));
                int cantidadEntregada = Convert.ToInt32(Materiales.Fila().Celda("cantidad_entregada"));

                if(cantidadAlmacen == cantidadEntregada || cantidadEntregada == 0)
                    Materiales.Fila().ModificarCelda("cantidad_almacen", 0);
                else
                    Materiales.Fila().ModificarCelda("cantidad_almacen", cantidadAlmacen - cantidadEntregada);

                Materiales.Fila().ModificarCelda("usuario_recibido_ensamble", CmbUsuarios.Text);
                Materiales.Fila().ModificarCelda("usuario_entrega_ensamble", Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno"));
                Materiales.Fila().ModificarCelda("fecha_entregado_ensamble", DateTime.Now);
                if (Convert.ToInt32(Materiales.Fila().Celda("cantidad_recibida")) < Convert.ToInt32(Materiales.Fila().Celda("piezas_requeridas")))
                    Materiales.Fila().ModificarCelda("estatus_almacen", "ENTREGADO PARCIALMENTE");
                else
                {
                    if (cantidadAlmacen == cantidadEntregada || cantidadEntregada == 0)
                    {
                        Materiales.Fila().ModificarCelda("estatus_almacen", "ENTREGADO");
                        Materiales.Fila().ModificarCelda("cantidad_entregada", Convert.ToInt32(Materiales.Fila().Celda("piezas_requeridas")));
                    }
                    else
                        Materiales.Fila().ModificarCelda("estatus_almacen", "ENTREGADO PARCIALMENTE");
                }

                Materiales.GuardarDatos();
            }
        }

        public void EntregarMaterialStock()
        {
            MaterialStock materialStock = new MaterialStock();
            foreach (int filaActual in IdMateriales)
            {
                materialStock.CargarDatos(filaActual);
                int cantidadEntregada = Convert.ToInt32(materialStock.Fila().Celda("cantidad_entregada"));
                if(cantidadEntregada > 0)
                { 
                    int total = Convert.ToInt32(materialStock.Fila().Celda("cantidad_disponible")) - Convert.ToInt32(materialStock.Fila().Celda("cantidad_entregada"));
                    materialStock.Fila().ModificarCelda("cantidad_disponible", total);
                    materialStock.Fila().ModificarCelda("cantidad_entregada", 0);
                }
                else
                {
                    materialStock.Fila().ModificarCelda("cantidad_disponible", 0);
                }
                
                materialStock.GuardarDatos();
            }
        }

        public void CargarUsuarios()
        {
            CmbUsuarios.Items.Clear();
            Usuario.Modelo().Todos().ForEach(delegate(Fila usuario)
            {
                CmbUsuarios.Items.Add(usuario.Celda("nombre").ToString() + " " + usuario.Celda("paterno").ToString());
            });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

            switch (BajaMaterial)
            {
                case "MATERIAL PROYECTO":
                     MaterialProyecto material = new MaterialProyecto();
                    foreach (var id in IdMateriales)
                    {
                        material.CargarDatos(id);
                        material.Fila().ModificarCelda("cantidad_entregada", 0);
                        material.GuardarDatos();
                    }
                    break;
                case "MATERIAL STOCK":
                     MaterialProyecto materialStock = new MaterialProyecto();
                    foreach (var id in IdMateriales)
                    {
                        materialStock.CargarDatos(id);
                        materialStock.Fila().ModificarCelda("cantidad_entregada", 0);
                        materialStock.GuardarDatos();
                    }
                    break;
                default:
                    break;
            }
           
            Close();
           
        }

        private void BtnEntregar_Click(object sender, EventArgs e)
        {
            if (StockProyecto == "MATERIAL PROYECTOS")
            {
                EntregarMaterial();
                DialogResult = DialogResult.OK;
            }

            else if (StockProyecto == "MATERIAL STOCK")
            {
                EntregarMaterialStock();
                DialogResult = DialogResult.OK;
            }
        }

        private void CmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnEntregar.Enabled = true;
            CmbIdReq.Enabled = true;
            MostrarPDF(IdMateriales, CmbUsuarios.Text);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void FrmBajaAlmacen_Load(object sender, EventArgs e)
        {
            int count = 1;
            CmbIdReq.DisplayMember = "Text";
            CmbIdReq.ValueMember = "Value";

            foreach (var id in IdMateriales)
            {
                CmbIdReq.Items.Add(new { Text = "#" + count.ToString(), Value = id.ToString() });
                count++;
            }

            if(CmbUsuarios.Text == "")
            {
                CmbIdReq.Enabled = false;
                NumCantidad.Enabled = false;
            }
        }

        private void CmbIdReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (BajaMaterial)
            {
                case "MATERIAL PROYECTOS":
                    int indexReq = CmbIdReq.SelectedIndex;
           
                    MaterialProyecto material = new MaterialProyecto();
                    material.CargarDatos(IdMateriales[indexReq]);           
                    int cantidadEntregada = Convert.ToInt32(material.Fila().Celda("cantidad_entregada"));
                    int maximo = Convert.ToInt32(Cantidad[indexReq]) - cantidadEntregada;

                    NumCantidad.Enabled = true;
                    NumCantidad.Maximum = Convert.ToInt32(Cantidad[indexReq]);
                    NumCantidad.Minimum = 1;
                    NumCantidad.Value = Convert.ToInt32(Cantidad[indexReq]);

                    material.Fila().ModificarCelda("cantidad_entregada", NumCantidad.Value);
                    material.GuardarDatos();
                    break;
                case "MATERIAL STOCK":
                    int indexStock = CmbIdReq.SelectedIndex;

                    MaterialStock materialStock = new MaterialStock();
                    materialStock.CargarDatos(IdMateriales[indexStock]);
                    int cantidadDisponible = Convert.ToInt32(materialStock.Fila().Celda("cantidad_disponible"));
                    int maximoStock = Convert.ToInt32(Cantidad[indexStock]) - cantidadDisponible;

                    NumCantidad.Enabled = true;
                    NumCantidad.Maximum = Convert.ToInt32(Cantidad[indexStock]);
                    NumCantidad.Minimum = 1;
                    NumCantidad.Value = Convert.ToInt32(Cantidad[indexStock]);

                    materialStock.Fila().ModificarCelda("cantidad_disponible", NumCantidad.Value);
                    materialStock.GuardarDatos();
                    break;
                default:
                    break;
            }
            
        }

        private void NumCantidad_ValueChanged(object sender, EventArgs e)
        {
            switch (BajaMaterial)
            {
                case "MATERIAL PROYECTOS":
                    int indexReq = CmbIdReq.SelectedIndex;

                    MaterialProyecto material = new MaterialProyecto();
                    material.CargarDatos(IdMateriales[indexReq]);   
                    material.Fila().ModificarCelda("cantidad_entregada", NumCantidad.Value);
                    material.GuardarDatos();

                    archivo = FormatosPDF.BajaMaterialAlmacen(IdMateriales, CmbUsuarios.Text);
                    Global.MostrarPDF(archivo, "BAJA_ALMACEN", null, VisorPDF);
                    break;
                case "MATERIAL STOCK":
                     int indexStock = CmbIdReq.SelectedIndex;

                     MaterialStock materialStock = new MaterialStock();
                     materialStock.CargarDatos(IdMateriales[indexStock]);
                     materialStock.Fila().ModificarCelda("cantidad_entregada", NumCantidad.Value);
                     materialStock.GuardarDatos();

                    archivo = FormatosPDF.BajaMaterialStock(IdMateriales, CmbUsuarios.Text);
                    Global.MostrarPDF(archivo, "BAJA_ALMACEN", null, VisorPDF);
                    break;
            }
            
        }

        private void NumCantidad_Enter(object sender, EventArgs e)
        {
            
        }

        private void FrmBajaAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (archivo != null)
            {
                string pathValesAlmacen = Directory.GetCurrentDirectory() + @"\SGC\VALES\ALMACEN";
                if (!Directory.Exists(pathValesAlmacen))
                    Directory.CreateDirectory(pathValesAlmacen);

                string hora = DateTime.Now.ToString().Replace(":", "-").Replace("/", "_").Trim();
                string nombreVale = pathValesAlmacen + @"\BAJA_ALMACEN_" + hora + ".pdf";

                File.WriteAllBytes(nombreVale, archivo);
                MessageBox.Show("Una copia del vale ha sido guardado en " + nombreVale);

                //BORRAR DESARGAS
                string pathDescargas = Directory.GetCurrentDirectory() + "//IMPRIMIR//VALE_SALIDA_ALMACEN";
                if (Directory.Exists(pathDescargas)) 
                    Directory.Delete(pathDescargas, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(archivo == null)
            {
                MessageBox.Show("Favor de generar el documento pdf", "Generar documento pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Global.MostrarPDFWebBrowser(archivo, "VALE_SALIDA_ALMACEN", "BAJA_ALMACEN");
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
