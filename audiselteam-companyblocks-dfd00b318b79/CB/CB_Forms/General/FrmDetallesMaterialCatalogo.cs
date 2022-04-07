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

namespace CB
{
    public partial class FrmDetallesMaterialCatalogo : Ventana
    {
        private int Id = 0;
        public FrmDetallesMaterialCatalogo(int id)
        {
            InitializeComponent();
            Id = id;
            CargarDatosMaterial(Id);
        }

        public void CargarDatosMaterial(int id)
        {
            CatalogoMaterial mat = new CatalogoMaterial();
            mat.CargarDatos(id);

            object numero_parte = mat.Fila().Celda("numero_parte");
            object fabricante = mat.Fila().Celda("fabricante");
            object descripcion = mat.Fila().Celda("descripcion");
            object usuario_registro = Global.ObjetoATexto(mat.Fila().Celda("usuario_registro"), "N/A");
            object comentarios_validacion = mat.Fila().Celda("comentario_validacion");
            object tipo_venta = mat.Fila().Celda("tipo_venta");

            object piezas_paquete = mat.Fila().Celda("piezas_paquete");
            object fecha_registro = Global.FechaATexto(mat.Fila().Celda("fecha_registro"));

            // Número de parte
            ListViewItem numeroDeParte = new ListViewItem("Número de parte: ");
            numeroDeParte.SubItems.Add( numero_parte.ToString() );
            numeroDeParte.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(numeroDeParte);

            // Fabricante
            ListViewItem fab = new ListViewItem("Fabricante: ");
            fab.SubItems.Add( fabricante.ToString() );
            fab.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(fab);

            // Descripcion
            ListViewItem desc = new ListViewItem("Descripción: ");
            desc.SubItems.Add( descripcion.ToString() );
            desc.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(desc);

            // Unidades
            ListViewItem unidades = new ListViewItem("Unidades: ");
            unidades.SubItems.Add( tipo_venta.ToString() );
            unidades.Group = LvInfoMaterial.Groups["General"];
            LvInfoMaterial.Items.Add(unidades);

            //===== Autorizacion =======================================================

            if(usuario_registro.ToString() != "N/A")
            {
                Usuario busquedaUsuario = new Usuario();
                busquedaUsuario.CargarDatos(Convert.ToInt32(usuario_registro));

                if(busquedaUsuario.TieneFilas())
                {
                    usuario_registro = busquedaUsuario.Fila().Celda("nombre") + " " + busquedaUsuario.Fila().Celda("paterno");
                }
            }

            // Usuario autorizacion
            ListViewItem uaut = new ListViewItem("Usuario registro: ");
            uaut.SubItems.Add(usuario_registro.ToString());
            uaut.Group = LvInfoMaterial.Groups["Registro"];
            LvInfoMaterial.Items.Add(uaut);

            // Fecha autorizacion
            ListViewItem faut = new ListViewItem("Fecha registro: ");
            if (fecha_registro != null)
                faut.SubItems.Add(fecha_registro.ToString());
            else
                faut.SubItems.Add("N/A");
            faut.Group = LvInfoMaterial.Groups["Registro"];
            LvInfoMaterial.Items.Add(faut);

            // Comentarios autorizacion
            ListViewItem caut = new ListViewItem("Últimos comentarios: ");
            caut.SubItems.Add(Global.ObjetoATexto(comentarios_validacion, "N/A"));
            caut.Group = LvInfoMaterial.Groups["Registro"];
            LvInfoMaterial.Items.Add(caut);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
