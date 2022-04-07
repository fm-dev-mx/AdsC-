using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmNuevoProyecto : Ventana
    {
        public string Mensaje = "";
        public string StrProyecto = "";
        public bool ProyectoCreado = false;
        private int CmbClienteIndex = 0;
        private int terminoId = 0;
        private int ordenesId = 0;
        private int IdTermino = 0;

        private Proyecto ProyectoDecimal = new Proyecto();
        Dictionary<string, byte[]> ArchivosAdjuntos = new Dictionary<string, byte[]>();
        Dictionary<int, string> listaTerminos = new Dictionary<int, string>();

        public FrmNuevoProyecto()
        {
            InitializeComponent();

            ProyectoDecimal.SeleccionarDatos("id=format(id,00) order by id DESC limit 1", null, "id");
            if (ProyectoDecimal.TieneFilas())
            {
                ProyectoDecimal.SeleccionarDatos("id=format(id,00) order by id DESC limit 1", null, "id");
                StrProyecto = (Convert.ToDecimal(ProyectoDecimal.Fila().Celda("id")) + 1).ToString("f2");
            }

            ArchivosAdjuntos.Clear();
            CargarClientes();
            CargarLideres();
            mostrarArchivo();
            CalcularFechaFin();
            eliminarToolStripMenuItem1.Enabled = false;
            FechaInicio.MaxDate = DateTime.Now;
        }

        private void CargarClientes()
        {
            CmbCliente.Items.Clear();

            Cliente.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbCliente.Items.Add(f.Celda("id") + "-" + f.Celda("nombre"));
            });
        }

        private void CargarContactos()
        {
            CmbContacto.Items.Clear();
            ClienteContacto.Modelo().SeleccionarDeCliente(Convert.ToInt32(CmbCliente.Text.Split('-')[0])).ForEach(delegate(Fila f)
            {
                CmbContacto.Items.Add(f.Celda("id") + "-" + f.Celda("nombre") + " " + f.Celda("apellidos"));
            });
            CmbContacto.SelectedIndex = 0;
        }

        private void CargarLideres()
        {
            CmbLiderProyecto.Items.Clear();
            Dictionary<string,object> parametros = new Dictionary<string,object>();
            parametros.Add("@rol","LIDER DE PROYECTO");
            parametros.Add("@activo",1);

            Usuario.Modelo().SeleccionarDatos("rol=@rol AND activo=@activo",parametros).ForEach(delegate(Fila f)
            {
                CmbLiderProyecto.Items.Add(f.Celda("id") + "-" + f.Celda("nombre") + " " + f.Celda("paterno") + " " + f.Celda("materno"));
            });

            CmbLiderProyecto.SelectedIndex = 0;
        }  

        private void mostrarArchivo()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvOrdenCompra);
            DgvOrdenCompra.Rows.Clear();
            ArchivosAdjuntos.Clear();

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", StrProyecto);

            PoProyecto.Modelo().SeleccionarDatos("proyecto=@proyecto",parametros).ForEach(delegate(Fila f)
            {
                DgvOrdenCompra.Rows.Add(Convert.ToInt32(f.Celda("id").ToString()),f.Celda("nombre_archivo").ToString());
                ArchivosAdjuntos.Add(f.Celda("nombre_archivo").ToString(), (byte[])f.Celda("archivo"));
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvOrdenCompra);
        }

        public int ObtenerPorcentajeMaximo()
        {
            int total = 0;
            foreach (DataGridViewRow row in DgvTerminoPago.Rows)
                total += Convert.ToInt32(row.Cells["porcentaje"].Value.ToString().Split('%')[0]);

            return total;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();           
            
            string id = "";
            string serie = "";
            int anterior = 0;

            ProyectoDecimal.SeleccionarDatos("id=format(id,00) order by id DESC limit 1", null, "id");
            if (ProyectoDecimal.TieneFilas())
            {
                foreach (KeyValuePair<string, byte[]> archivo in ArchivosAdjuntos)
                {
                    Fila insertarOrdenes = new Fila();
                    insertarOrdenes.AgregarCelda("proyecto", StrProyecto);
                    insertarOrdenes.AgregarCelda("nombre_archivo", archivo.Key);
                    insertarOrdenes.AgregarCelda("extension", ".pdf");
                    insertarOrdenes.AgregarCelda("archivo", archivo.Value);
                    PoProyecto.Modelo().Insertar(insertarOrdenes);
                }              

                foreach (KeyValuePair<int, string> termino in listaTerminos)
                {
                    Fila insertarTerminos = new Fila();
                    insertarTerminos.AgregarCelda("proyecto", StrProyecto);
                    insertarTerminos.AgregarCelda("cliente", CmbCliente.Text.Split('-')[0]);
                    insertarTerminos.AgregarCelda("porcentaje", termino.Value.Split(',')[0].Split('%')[0]);
                    insertarTerminos.AgregarCelda("termino", termino.Value.Split(',')[1]);
                    insertarTerminos.AgregarCelda("anterior", anterior);
                    anterior = Convert.ToInt32(TerminoPagoCliente.Modelo().Insertar(insertarTerminos).Celda("id"));
                }

                try
                {
                    ProyectoDecimal.SeleccionarDatos("id=format(id,00) order by id DESC limit 1", null, "id");
                    cliente.CargarDatos(Convert.ToInt32(CmbCliente.Text.Split('-')[0]), "abreviacion");
                    
                    id= (Convert.ToDecimal(ProyectoDecimal.Fila().Celda("id").ToString()) + 1).ToString("F2");
                    serie = cliente.Fila().Celda("abreviacion").ToString() + "-" + Convert.ToDouble(id).ToString("000.00") + DateTime.Now.ToString("-MMyy");
                   
                    Fila insertarProyecto = new Fila();
                    insertarProyecto.AgregarCelda("id", id);
                    insertarProyecto.AgregarCelda("nombre", TxtProyectoNombre.Text);
                    insertarProyecto.AgregarCelda("tipo", 1);
                    insertarProyecto.AgregarCelda("fecha_alta", DateTime.Now);
                    insertarProyecto.AgregarCelda("fecha_inicio",FechaInicio.Value);
                    insertarProyecto.AgregarCelda("fecha_entrega", FechaEntrega.Value);
                    insertarProyecto.AgregarCelda("usuario", Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id")));
                    insertarProyecto.AgregarCelda("cliente", CmbCliente.Text.Split('-')[0]);
                    insertarProyecto.AgregarCelda("contacto", CmbContacto.Text.Split('-')[0]);
                    insertarProyecto.AgregarCelda("liderproyecto", CmbLiderProyecto.Text.Split('-')[0]);
                    insertarProyecto.AgregarCelda("principal", id);
                    insertarProyecto.AgregarCelda("activo", 1);
                    insertarProyecto.AgregarCelda("serie",  serie);
                    insertarProyecto.AgregarCelda("estatus_liberacion", "PENDIENTE");
                    insertarProyecto.AgregarCelda("usuario_liberacion", "N/A");
                    insertarProyecto.AgregarCelda("evidencia_liberacion", 0);
                    Proyecto.Modelo().Insertar(insertarProyecto);
                }
                catch
                {
                    ProyectoDecimal.SeleccionarDatos("id=format(id,00) order by id DESC limit 1", null, "id");
                    string idComprobar = (Convert.ToDecimal(ProyectoDecimal.Fila().Celda("id").ToString())).ToString("F2");
                    if(id == idComprobar)
                    {
                        Mensaje = "Se ha creado de forma exitosa el proyecto:\r\n#" + id + "-" + TxtProyectoNombre.Text + "\r\n¿Desea cargar el proyecto?";
                        ProyectoCreado = true;
                    }
                    else
                        Mensaje = "No ha sido posible crear el proyecto #" + id + "-" + TxtProyectoNombre.Text + "\r\nContacte al administrador del sistema.";                                      
                }
                DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarContactos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = (CmbCliente.Text != "" && TxtProyectoNombre.Text != "" && ObtenerPorcentajeMaximo() == 100);
        }

        private void CmbContacto_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = (CmbCliente.Text != "" && TxtProyectoNombre.Text != "" && ObtenerPorcentajeMaximo() == 100);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarTermino termino = new FrmAgregarTermino(ObtenerPorcentajeMaximo());
            if (termino.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (termino.Termino != "" && termino.PorcentajeVal != 0)
                {
                    if (termino.IdTermino == 0)
                    {
                        listaTerminos.Add(terminoId, Convert.ToInt32(termino.PorcentajeVal) + "%," + termino.Termino);
                        DgvTerminoPago.Rows.Add(terminoId,termino.PorcentajeVal + "%",termino.Termino);
                        DgvTerminoPago.ClearSelection();
                        DgvTerminoPago.Rows[DgvTerminoPago.Rows.Count - 1].Selected = true;
                        terminoId++;
                    }
                }
                btnRegistrar.Enabled = (CmbCliente.Text != "" && TxtProyectoNombre.Text != "" && ObtenerPorcentajeMaximo() == 100);
            }         
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog seleccionarArchivo = new OpenFileDialog();
            seleccionarArchivo.Filter = "PDF files (*.pdf)|*.pdf";

            if (seleccionarArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string archivo = seleccionarArchivo.FileName;
                string nombreArchivo = seleccionarArchivo.SafeFileName;
                string extension = Path.GetExtension(seleccionarArchivo.FileName);
                byte[] datos = File.ReadAllBytes(archivo);

                if (ArchivosAdjuntos.ContainsKey(nombreArchivo))
                {
                    MessageBox.Show("Este archivo ya fue incluido anteriormente!");
                    return;
                }

                ArchivosAdjuntos.Add(nombreArchivo, datos);
                DgvOrdenCompra.Rows.Add(ordenesId,nombreArchivo);
                DgvOrdenCompra.ClearSelection();
                DgvOrdenCompra.Rows[DgvOrdenCompra.Rows.Count - 1].Selected = true;
                ordenesId++;
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    eliminarToolStripMenuItem1.Enabled = (DgvOrdenCompra.SelectedRows.Count > 0);
                    MenuOrdenCompra.Show(mouseX, mouseY);
                }
            }
        }

        private void DgvOrdenCompra_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvOrdenCompra = DgvOrdenCompra.HitTest(e.X, e.Y);

            if (clickDgvOrdenCompra.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    if(DgvOrdenCompra.SelectedRows.Count > 0)
                        eliminarToolStripMenuItem1.Enabled = false;

                    MenuOrdenCompra.Show(mouseX, mouseY);
                }
                DgvOrdenCompra.ClearSelection();
            }
        }

        private void DgvTerminoPago_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvTerminoPago = DgvTerminoPago.HitTest(e.X, e.Y);

            if (clickDgvTerminoPago.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    if (ObtenerPorcentajeMaximo() != 100)
                        agregarToolStripMenuItem.Enabled = true;
                    else
                        agregarToolStripMenuItem.Enabled = false;
                    
                    modificarToolStripMenuItem.Enabled = false;
                    eliminarToolStripMenuItem.Enabled = false;
                    MenuTerminoPago.Show(mouseX, mouseY);
                }
                DgvTerminoPago.ClearSelection();
            }         
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string archivo = "";
            string texto = "";

            int actividades = 0;

            foreach (DataGridViewRow row in DgvOrdenCompra.SelectedRows)
            {
                archivo += "Archivo: " + row.Cells["orden_compra"].Value.ToString() + "\r\n";
                actividades++;
            }

            if (actividades > 1)
                texto = "¿Seguro que desea borrar estas órdenes de compra?\n";
            else
                texto = "¿Seguro que desea borrar esta órden de compra?\r\n";

            DialogResult respuesta = MessageBox.Show(texto + archivo, "Eliminar órden de compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                if (respuesta != DialogResult.Yes)
                    return;

                foreach (DataGridViewRow row in DgvOrdenCompra.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["id_orden"].Value);
                    ArchivosAdjuntos.Remove(row.Cells["orden_compra"].Value.ToString());
                    DgvOrdenCompra.Rows.RemoveAt(row.Index);
                }
                DgvOrdenCompra.ClearSelection();               
            }
        }

        private void DgvOrdenCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                eliminarToolStripMenuItem1.Enabled = true;
            }
        }

        private void DgvOrdenCompra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                string nombreArchivo = ArchivosAdjuntos.ElementAt(e.RowIndex).Key;
                byte[] datosArchivo = ArchivosAdjuntos.ElementAt(e.RowIndex).Value;
                FrmVisorPDF pdf = new FrmVisorPDF(datosArchivo, nombreArchivo);
                pdf.ShowDialog();
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarTermino termino = new FrmAgregarTermino(ObtenerPorcentajeMaximo(), 1, DgvTerminoPago.SelectedRows[0].Cells["porcentaje"].Value.ToString().Split('%')[0], DgvTerminoPago.SelectedRows[0].Cells["termino"].Value.ToString());
            if (termino.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (termino.Termino != "" && termino.PorcentajeVal != 0)
                {
                    listaTerminos[IdTermino] = termino.PorcentajeVal + "%," + termino.Termino;
                    MostrarTerminos(); 
 
                    btnRegistrar.Enabled = (CmbCliente.Text != "" && TxtProyectoNombre.Text != "" && ObtenerPorcentajeMaximo() == 100);
                }
            }
        }

        public void MostrarTerminos()
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvTerminoPago);
            DgvTerminoPago.Rows.Clear();

            foreach (KeyValuePair<int, string> term in listaTerminos)
            {
                DgvTerminoPago.Rows.Add(term.Key, term.Value.Split(',')[0] + "%", term.Value.Split(',')[1]);
            }
             ConfiguracionDataGridView.Recuperar(cfg, DgvTerminoPago);
        }

        private void CalcularFechaFin()
        {
            FechaEntrega.Value = FechaInicio.Value.AddDays((int)NumSemana.Value * 7); 
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string terminosPago = "";
            string texto = "";

            int actividades = 0;

            foreach (DataGridViewRow row in DgvTerminoPago.SelectedRows)
            {
                terminosPago += "Término: " + row.Cells["porcentaje"].Value.ToString() + "% " + row.Cells["termino"].Value.ToString() + "\r\n";
                actividades++;
            }

            if (actividades > 1)
                texto = "¿Seguro que desea borrar estos términos de pago?\r\n";
            else
                texto = "¿Seguro que desea borrar este término de pago?\r\n";

            DialogResult respuesta = MessageBox.Show(texto + terminosPago, "Eliminar término", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                if (respuesta != DialogResult.Yes)
                    return;

                foreach (DataGridViewRow row in DgvTerminoPago.SelectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["id_termino"].Value);
                    listaTerminos.Remove(id);
                    DgvTerminoPago.Rows.RemoveAt(row.Index);
                }
                DgvTerminoPago.ClearSelection();
            }
        }

        private void DgvTerminoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                IdTermino = Convert.ToInt32(DgvTerminoPago.SelectedRows[0].Cells["id_termino"].Value);

                if (ObtenerPorcentajeMaximo() != 100)
                    agregarToolStripMenuItem.Enabled = true;
                else
                    agregarToolStripMenuItem.Enabled = false;
                eliminarToolStripMenuItem.Enabled = true;
                modificarToolStripMenuItem.Enabled = true;
            }
        }

        private void DgvTerminoPago_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;

                    if (ObtenerPorcentajeMaximo() != 100)
                        agregarToolStripMenuItem.Enabled = true;
                    else
                        agregarToolStripMenuItem.Enabled = false;
                    eliminarToolStripMenuItem.Enabled = (DgvTerminoPago.SelectedRows.Count > 0);
                    modificarToolStripMenuItem.Enabled = (DgvTerminoPago.SelectedRows.Count > 0);
                    MenuTerminoPago.Show(mouseX, mouseY);
                }
            }
        }

        private void CmbCliente_Click(object sender, EventArgs e)
        {
            CmbClienteIndex = CmbCliente.SelectedIndex;
        }

        private void DgvTerminoPago_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnRegistrar.Enabled = (CmbCliente.Text != "" && TxtProyectoNombre.Text != "" && ObtenerPorcentajeMaximo() == 100);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            
           
        }

        private void LblTitulo_MouseDown_1(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }
    }
}
