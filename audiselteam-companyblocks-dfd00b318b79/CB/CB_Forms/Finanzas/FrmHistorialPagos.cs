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
    public partial class FrmHistorialPagos : Form
    {
        int idPlanoCargado = 0;
        public FrmHistorialPagos()
        {
            InitializeComponent();
            PlanoProyecto CuentasPagadas = new PlanoProyecto();
            EnlistarPlanos();
        }

        private void FrmHistorialPagos_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CmbFiltroHistorialFinanzas.Text = "PARTES FABRICADAS";
            CmbFiltroHistorialFinanzas.Enabled = true;
            EnlistarContenido(CmbFiltroHistorialFinanzas.Text);
        }

        public void EnlistarContenido(string filtro)
        {
            switch (filtro)
            {
                case "PARTES FABRICADAS":
                    EnlistarPlanos();
                    break;
                case "PARTES COMPRADAS":
                    EnlistarPartes();
                    break;
            }
        }
            
        public void EnlistarPartes()
        {
            DgvPlanosHistorial.Columns["id_plano"].HeaderText = "PO";
            DgvPlanosHistorial.Columns["plano"].HeaderText = "Numero Parte";
            DgvPlanosHistorial.Columns["proveedor"].HeaderText = "Fabricante";
 
            DgvPlanosHistorial.Columns[6].DefaultCellStyle.Format = "MMM dd yyy";
            DgvPlanosHistorial.Columns[7].DefaultCellStyle.Format = "MMM dd yyy";
            DgvPlanosHistorial.Rows.Clear();
            PlanoCotizacion Cotizacion_Final = new PlanoCotizacion();
            MaterialProyecto.Modelo().Pagadas().ForEach(delegate(Fila plano)
            {
                DgvPlanosHistorial.Rows.Add(plano.Celda("id"), plano.Celda("numero_parte"), plano.Celda("fabricante"), plano.Celda("numero_factura"), plano.Celda("modo_pago"), plano.Celda("referencia_pago"), plano.Celda("fecha_facturacion"), plano.Celda("fecha_pagado"), "N/A", plano.Celda("usuario_facturacion"), plano.Celda("usuario_pago"));
            });
            BorrarPlano();
        }

        public void EnlistarPlanos()
        {
            DgvPlanosHistorial.Columns["id_plano"].HeaderText = "ID";
            DgvPlanosHistorial.Columns["plano"].HeaderText = "Plano";
            DgvPlanosHistorial.Columns["proveedor"].HeaderText = "Proveedor";
            DgvPlanosHistorial.Columns[6].DefaultCellStyle.Format = "MMM dd yyy";
            DgvPlanosHistorial.Columns[7].DefaultCellStyle.Format = "MMM dd yyy";
            DgvPlanosHistorial.Rows.Clear();
            PlanoCotizacion Cotizacion_Final = new PlanoCotizacion();

            PlanoProyecto.Modelo().Pagadas().ForEach(delegate(Fila plano)
            {
                int idproducto = Convert.ToInt32(plano.Celda("cotizacion_final"));
                Cotizacion_Final.CargarDatos(idproducto);
                string preciofinal = Convert.ToInt32(Cotizacion_Final.Fila().Celda("precio_final")).ToString("C");
                DgvPlanosHistorial.Rows.Add(plano.Celda("id"),plano.Celda("nombre_archivo"), plano.Celda("proveedor_maquinado"),plano.Celda("numero_factura"),plano.Celda("modo_pago"),plano.Celda("referencia_pago"), plano.Celda("fecha_facturacion"),plano.Celda("fecha_pagado"),preciofinal,plano.Celda("usuario_facturacion"),plano.Celda("usuario_pago"));
            });

            BorrarPlano();
        }
        public void BorrarPlano()
        {
            LblNumeroPlano.Text = "SELECCIONA UN PLANO";
            GrupoInfoPlanoFinanzas.Visible = false;
            VisorPDF.LoadFile("none");
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
            string estatus_finanzas = plano.Fila().Celda("estatus_finanzas").ToString();

            LblNumeroPlano.Text = nombre;
            LblRecibido.Text = recibido + " de " + cantidad;
            LblProveedor.Text = proveedorMaquiando;
            LblFechaPlano.Text = fecha;
            LblUsuario.Text = usuario;
            LblCantidad.Text = cantidad;
            LblTratamiento.Text = tratamiento;
            GrupoInfoPlanoFinanzas.Visible = true;


            Global.MostrarPDF((byte[])archivo.Fila().Celda("archivo"), nombre, null, VisorPDF);

            idPlanoCargado = idPlano;
            BtnHistorialPlanoFinanzas.Enabled = true;
            LblCargandoPlano.Visible = false;
            Application.DoEvents();
        }

        public void MostrarPO(int idPO)
        {
            idPlanoCargado = idPO;
            BorrarPlano();

            Application.DoEvents();
            MaterialProyecto PO = new MaterialProyecto();
            GrupoInfoPlanoFinanzas.Visible = false;

            PO.CargarDatos(idPO);

            int intPo = (int)PO.Fila().Celda("po");

            ArchivoPo archivo = new ArchivoPo();
            archivo.SeleccionarPo(intPo);

            string nombre = "AUD-PO-" + idPO.ToString();
            string estatusFinanzas = PO.Fila().Celda("estatus_finanzas").ToString();
            Global.MostrarPDF((byte[])archivo.Fila().Celda("archivo"), nombre, null, VisorPDF);

            Application.DoEvents();
        }


        private void DgvPlanosHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idPlano = 0;
                switch (CmbFiltroHistorialFinanzas.Text)
                {
                    case "PARTES FABRICADAS":
                        idPlano = Convert.ToInt32(DgvPlanosHistorial.Rows[e.RowIndex].Cells[0].Value);
                        MostrarPlano(idPlano);
                        break;
                    case "PARTES COMPRADAS":
                        idPlano = Convert.ToInt32(DgvPlanosHistorial.Rows[e.RowIndex].Cells[0].Value);
                        MostrarPO(idPlano);
                        break;
                }
                //if (CmbFiltroHistorialFinanzas.Text == "PARTES FABRICADAS")
                //{
                //    int idPlano = Convert.ToInt32(DgvPlanosHistorial.Rows[e.RowIndex].Cells[0].Value);
                //    MostrarPlano(idPlano);
                //}

                //else if (CmbFiltroHistorialFinanzas.Text == "PARTES COMPRADAS")
                //{
                //    int idPlano = Convert.ToInt32(DgvPlanosHistorial.Rows[e.RowIndex].Cells[0].Value);
                //    MostrarPO(idPlano);
                //}
            }
        }

        private void BtnOpcionesPlanoFinanzas_Click(object sender, EventArgs e)
        {
            BtnHistorialPlanoFinanzas.ContextMenuStrip = MenuOpcionesPlanoRevisado;

            if (BtnHistorialPlanoFinanzas.ContextMenuStrip != null)
                BtnHistorialPlanoFinanzas.ContextMenuStrip.Show(BtnHistorialPlanoFinanzas, BtnHistorialPlanoFinanzas.PointToClient(Cursor.Position));
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void verDetallesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmDetallesPlanoFabricacion detalles = new FrmDetallesPlanoFabricacion(idPlanoCargado);
            detalles.Show();
        }

        private void CmbFiltroHistorialFinanzas_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlistarContenido(CmbFiltroHistorialFinanzas.Text);
        }
    }
}