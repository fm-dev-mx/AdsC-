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
    public partial class FrmAltaAlmacenDesdePO : Form
    {
        private int Id = 0;
        private int PO = 0;
        private string NumeroDeParte;
        private int CantidadMaxima = 0;
        private int CantidadRecibida = 0;
        public FrmAltaAlmacenDesdePO()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            BtnAgregar.Enabled = false;
        }

        public void EnlistarPO()
        {
            PO = Convert.ToInt32(numericUpDownPO.Value);
            int filaSeleccionada = Global.GuardarFilaSeleccionada(DgvPartidasPO);
            DgvPartidasPO.Rows.Clear();
            int contador = 1;
           
            PoMaterial.Modelo().Conceptos(PO).ForEach(delegate(Fila po) 
            {
                string Cantidad  = po.Celda("texto_cantidad").ToString();
                DgvPartidasPO.Rows.Add(contador, po.Celda("numero_parte"),Cantidad );
                contador++;
            });

            Global.RecuperarFilaSeleccionada(DgvPartidasPO, filaSeleccionada);
        }

        //public void VerificarEstatusParaPago(int PO)
        //{
        //    int contadorEstatus = 0;
        //    MaterialProyecto.Modelo().SeleccionarPO(PO).ForEach(delegate(Fila f) 
        //    {
        //        string estatus = f.Celda("estatus_almacen").ToString();
        //        if (estatus != "RECIBIDO" && estatus != "ENTREGADO" && estatus != "PARCIALMENTE ENTREGADO")
        //            contadorEstatus++;
        //    });

        //    if (contadorEstatus == 0)
        //    {
        //        TerminoPagoProveedor terminos = new TerminoPagoProveedor();
        //        terminos.SeleccionarPO(PO).ForEach(delegate(Fila f) 
        //        {
        //            string estatusFinanzas = f.Celda("estatus").ToString();
        //            if (estatusFinanzas != "PAGABLE")
        //            {
        //                f.ModificarCelda("estatus", "PAGABLE");
        //                terminos.GuardarDatos();
        //            }
        //        });
        //    }
        //}

        public void EnlistarPartidad(string numeroParte)
        {
            
            Id = 0;
            BtnAgregar.Enabled = false;
            int FilaSeleccionada = Global.GuardarFilaSeleccionada(DgvRequisicionesPO);
            DgvRequisicionesPO.Rows.Clear();
           
            PoMaterial.Modelo().DesglosarPartida(numeroParte, PO).ForEach(delegate(Fila requisicion) 
            {
                int cantidadRecibida = 0;
                string valor = requisicion.Celda("estatus_almacen").ToString();

                if (valor == "RECIBIDO" || valor == "ENTREGADO")
                    cantidadRecibida = Convert.ToInt32(requisicion.Celda("piezas_requeridas"));
                else
                    cantidadRecibida = Convert.ToInt32(requisicion.Celda("cantidad_recibida"));

                DgvRequisicionesPO.Rows.Add(requisicion.Celda("id"), requisicion.Celda("requisitor"), Convert.ToDouble(requisicion.Celda("proyecto")).ToString("F2"), requisicion.Celda("piezas_requeridas"), cantidadRecibida, requisicion.Celda("estatus_almacen"), cantidadRecibida);
                DataGridViewCell cell = DgvRequisicionesPO.Rows[DgvRequisicionesPO.RowCount - 1].Cells["estatus_almacen"];
                cell.Style = MaterialProyecto.Modelo().ColorEstatusAlmacen(valor);
            });

            DgvRequisicionesPO.ClearSelection();
            //Global.RecuperarFilaSeleccionada(DgvRequisicionesPO, FilaSeleccionada);
        }

        public void ActualizarDatos()
        {
            PoMaterial poMaterial = new PoMaterial();
            MaterialProyecto Materiales = new MaterialProyecto();
            string usuario_alta = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");

            if (DgvPartidasPO.SelectedRows.Count > 0 && DgvRequisicionesPO.SelectedRows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea dar de alta en ALMACEN este material?", "", MessageBoxButtons.YesNo);
                if (respuesta == System.Windows.Forms.DialogResult.Yes)
                {
                    Materiales.CargarDatos(Id);
                    int cantidadMaterialAlta = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].Value);//Convert.ToInt32(Materiales.Fila().Celda("piezas_requeridas"));
                    int cantidadMaterialRecibido = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["recibido"].Value);
                    int materialEnAlmacen = Convert.ToInt32(Materiales.Fila().Celda("cantidad_almacen"));
                    int total = (cantidadMaterialAlta - cantidadMaterialRecibido) + materialEnAlmacen;
                    int idMeta = Convert.ToInt32(Materiales.Fila().Celda("meta"));

                    poMaterial.CargarDatos(Convert.ToInt32(Materiales.Fila().Celda("po")));

                   // if(cantidadMaterialAlta == Convert.ToInt32(Materiales.Fila().Celda("piezas_requeridas")))
                    {
                        foreach (DataGridViewRow row in DgvRequisicionesPO.SelectedRows)
                        {
                            if(Convert.ToInt32(row.Cells["cantidad"].Value) == Convert.ToInt32(row.Cells["cantidadRecibida1"].Value))
                            {
                                Materiales.Fila().ModificarCelda("estatus_almacen", "RECIBIDO");
                                Materiales.Fila().ModificarCelda("estatus_compra", "RECIBIDO");
                            }
                            else
                            {
                                Materiales.Fila().ModificarCelda("estatus_almacen", "RECIBIDO PARCIALMENTE");
                            }
                        }
                        //Materiales.Fila().ModificarCelda("estatus_almacen", "RECIBIDO");
                        //Materiales.Fila().ModificarCelda("estatus_compra", "RECIBIDO");
                    }
                    //else
                    { 
                       // Materiales.Fila().ModificarCelda("estatus_almacen", "RECIBIDO PARCIALMENTE");
                    }

                    Materiales.Fila().ModificarCelda("cantidad_recibida", cantidadMaterialAlta);
                    Materiales.Fila().ModificarCelda("estatus_finanzas", "FACTURABLE");
                    Materiales.Fila().ModificarCelda("fecha_recibido_almacen", DateTime.Now);
                    Materiales.Fila().ModificarCelda("usuario_recibido_almacen", usuario_alta);
                    Materiales.Fila().ModificarCelda("cantidad_almacen", total);
                    Materiales.GuardarDatos();

                    EnlistarPO();
                    EnlistarPartidad(NumeroDeParte);

                    if (idMeta > 0)
                        Meta.Modelo().ActualizarAvance(idMeta);

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@idPo", Convert.ToInt32(Materiales.Fila().Celda("po")));

                    int piezasRecibidasParcialmente = 0;
                    int piezasRecibidas = 0;
                    int piezasTotales = 0;
                    MaterialProyecto mat = new MaterialProyecto();
                    mat.SeleccionarDatos("po=@idPo", parametros).ForEach(delegate(Fila f)
                    {
                        if (f.Celda("estatus_almacen").ToString() == "RECIBIDO PARCIALMENTE")
                            piezasRecibidasParcialmente++;
                        else if (f.Celda("estatus_almacen").ToString() == "RECIBIDO")
                            piezasRecibidas++;
                        piezasTotales++;
                    });
                    
                    if(piezasRecibidasParcialmente > 0 || piezasRecibidas < piezasTotales)
                        poMaterial.Fila().ModificarCelda("estatus", "RECIBIDO PARCIALMENTE");
                    else
                        poMaterial.Fila().ModificarCelda("estatus", "RECIBIDO");

                    poMaterial.GuardarDatos();

                    //Calcular tiempo transcurrido
                    if (idMeta > 0)
                    {
                        CalcularEficienciaAvance(idMeta);
                    }
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            EnlistarPO();
            DgvRequisicionesPO.Rows.Clear();
        }

        private void DgvPartidasPO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvPartidasPO.SelectedRows.Count < 0 || e.RowIndex < 0)
                return;

            NumeroDeParte = DgvPartidasPO.SelectedRows[0].Cells["numero_parte"].Value.ToString();
            EnlistarPartidad(NumeroDeParte);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

        private void DgvRequisicionesPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*string habilitarBoton = "";
            BtnAgregar.Enabled = false;
            if (DgvRequisicionesPO.SelectedRows.Count <= 0 || Id == 0)
            {
                return;
            }

            Id = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["requisicion"].Value);
            habilitarBoton = Convert.ToString(DgvRequisicionesPO.SelectedRows[0].Cells["estatus_almacen"].Value);
            CantidadMaxima = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["cantidad"].Value);
            CantidadRecibida = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].Value);

            if (habilitarBoton == "RECIBIDO" || habilitarBoton == "ENTREGADO")
            {
                BtnAgregar.Enabled = false;
                editarCantidadToolStripMenuItem.Visible = false;
                DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
            }
            else if (habilitarBoton == "RECIBIDO PARCIALMENTE" || habilitarBoton == "ENTREGADO PARCIALMENTE" || habilitarBoton == "N/A" || habilitarBoton == "SIN RECIBIR")
            {
                editarCantidadToolStripMenuItem.Visible = true;
                if (CantidadRecibida > Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["recibido"].Value))
                {
                    BtnAgregar.Enabled = true;
                    DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
                }
                else
                {
                    BtnAgregar.Enabled = false;
                    DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
                }
                    
            }
            else
            {
                editarCantidadToolStripMenuItem.Visible = false;
                DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
                BtnAgregar.Enabled = false;         
            }*/
        }

        private void numericUpDownPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnBuscar_Click(this, new EventArgs());
        }

        private void DgvRequisicionesPO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvRequisicionesPO.SelectedRows.Count <= 0)
                return;

            int idRequisicion = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["requisicion"].Value);
            FrmDetallesMaterialProyecto req = new FrmDetallesMaterialProyecto(idRequisicion);
            req.Show();
        }

        private void DgvRequisicionesPO_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnCantidad_KeyPress);
            if (DgvRequisicionesPO.CurrentCell.ColumnIndex == 4) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnCantidad_KeyPress);
                }
            }
        }

        private void ColumnCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DgvRequisicionesPO_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int cantidadRecibida = Convert.ToInt32(DgvRequisicionesPO.Rows[e.RowIndex].Cells["cantidadRecibida1"].Value);
            int cantidadOriginal = Convert.ToInt32(DgvRequisicionesPO.Rows[e.RowIndex].Cells["recibido"].Value);

            if (DgvRequisicionesPO.CurrentCell.ColumnIndex == 4) 
            {
                if (cantidadRecibida > CantidadMaxima)
                {
                    MessageBox.Show("La cantidad de material recibido no puede ser mayor a la cantidad total", "Cantidad fuera del rango", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DgvRequisicionesPO.Rows[e.RowIndex].Cells["cantidadRecibida1"].Value = cantidadOriginal;
                    BtnAgregar.Enabled = false;
                   
                }
                else if (cantidadRecibida <= cantidadOriginal || cantidadRecibida == 0)
                {                  
                    DgvRequisicionesPO.Rows[e.RowIndex].Cells["cantidadRecibida1"].Value = cantidadOriginal;
                    BtnAgregar.Enabled = false;
                }
                else if (cantidadRecibida <= Convert.ToInt32(DgvRequisicionesPO.Rows[e.RowIndex].Cells["cantidad"].Value))
                    BtnAgregar.Enabled = true;

            }
        }

        private void DgvRequisicionesPO_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MenuEditarCantidad.Show(Cursor.Position);
        }

        private void editarCantidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = false;
            DgvRequisicionesPO.CurrentRow.Cells["cantidadRecibida1"].Selected = true;
            DgvRequisicionesPO.BeginEdit(true);
        }

        private void CalcularEficienciaAvance(int idMeta)
        {
            Meta meta = new Meta();
            meta.CargarDatos(idMeta);

            if (meta.TieneFilas())
            {
                decimal eficiencia = 0;
                int tiempoTranscurrido = 0;
                DateTime fechaAutorizacion = Convert.ToDateTime(meta.Fila().Celda("fecha_autorizacion"));
                DateTime fechaPromesa = Convert.ToDateTime(meta.Fila().Celda("fecha_promesa"));
                decimal avance = Convert.ToDecimal(meta.Fila().Celda("avance"));

                TimeSpan diferenciaTranscurrida = DateTime.Now.Date - fechaAutorizacion.Date;
                TimeSpan diferenciaAutorizacionPromesa = fechaPromesa.Date - fechaAutorizacion.Date;
                int diasTranscurridos = diferenciaTranscurrida.Days;
                int diasDelProyecto = diferenciaAutorizacionPromesa.Days;
                if (diasDelProyecto > 0)
                    tiempoTranscurrido = (diasTranscurridos * 100) / diasDelProyecto;
                else
                    tiempoTranscurrido = (diasTranscurridos * 100);
                if (tiempoTranscurrido == 0)
                    eficiencia = avance;
                else
                    eficiencia = (avance / tiempoTranscurrido) * 100;

                Fila insertarMetaEficiencia = new Fila();
                insertarMetaEficiencia.AgregarCelda("meta", idMeta);
                insertarMetaEficiencia.AgregarCelda("avance", avance);
                insertarMetaEficiencia.AgregarCelda("fecha", DateTime.Now);
                insertarMetaEficiencia.AgregarCelda("tiempo_transcurrido", tiempoTranscurrido);
                insertarMetaEficiencia.AgregarCelda("eficiencia", eficiencia);

                MetaEficiencia.Modelo().Insertar(insertarMetaEficiencia);
            }
        }

        private void FrmAltaAlmacenDesdePO_Load(object sender, EventArgs e)
        {

        }

        private void MenuEditarCantidad_Opening(object sender, CancelEventArgs e)
        {
            string habilitarBoton = "";
            BtnAgregar.Enabled = false;

            if(DgvRequisicionesPO.SelectedRows.Count <= 0)
            {
                editarCantidadToolStripMenuItem.Visible = false;
                return;
            }

            editarCantidadToolStripMenuItem.Visible = true;
            Id = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["requisicion"].Value);
            habilitarBoton = Convert.ToString(DgvRequisicionesPO.SelectedRows[0].Cells["estatus_almacen"].Value);
            CantidadMaxima = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["cantidad"].Value);
            CantidadRecibida = Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].Value);

            if (habilitarBoton == "RECIBIDO" || habilitarBoton == "ENTREGADO")
            {
                BtnAgregar.Enabled = false;
                editarCantidadToolStripMenuItem.Visible = false;
                DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
            }
            else if (habilitarBoton == "RECIBIDO PARCIALMENTE" || habilitarBoton == "ENTREGADO PARCIALMENTE" || habilitarBoton == "N/A" || habilitarBoton == "SIN RECIBIR")
            {
                editarCantidadToolStripMenuItem.Visible = true;
                if (CantidadRecibida > Convert.ToInt32(DgvRequisicionesPO.SelectedRows[0].Cells["recibido"].Value))
                {
                    BtnAgregar.Enabled = true;
                    DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
                }
                else
                {
                    BtnAgregar.Enabled = false;
                    DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
                }

            }
            else
            {
                editarCantidadToolStripMenuItem.Visible = false;
                DgvRequisicionesPO.SelectedRows[0].Cells["cantidadRecibida1"].ReadOnly = true;
                BtnAgregar.Enabled = false;
            }
        }
    }
}
