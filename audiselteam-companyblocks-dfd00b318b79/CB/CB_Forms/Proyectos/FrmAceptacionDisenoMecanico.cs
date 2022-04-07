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
    public partial class FrmAceptacionDisenoMecanico : Ventana
    {
        int IdModulo = 0;
        int SubensambleId = 0;
        bool Concepto = false;
        decimal Proyecto = 0;

        List<int> Vista = new List<int>();
        List<int> Requerimientos = new List<int>();
        List<int> Elementos = new List<int>();
        List<int> Secuencia = new List<int>();
        List<int> Fallas = new List<int>();

        public FrmAceptacionDisenoMecanico(int id, int subensamble, bool concepto = false)
        {
            InitializeComponent();
            IdModulo = id;
            Concepto = concepto;
            SubensambleId = subensamble;

            Modulo modulo = new Modulo();
            Requerimiento requerimiento = new Requerimiento();

            modulo.CargarDatos(IdModulo);
            if (modulo.TieneFilas())
                Proyecto = Convert.ToDecimal(modulo.Fila().Celda("proyecto"));

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", IdModulo);
            requerimiento.SeleccionarDatos("modulo=@modulo", parametros);

            if (!Concepto)
            {
                Elemento elemento = new Elemento();
                elemento.SeleccionarDatos("modulo=@modulo",parametros);
                ChkElemento.Enabled = elemento.TieneFilas();

                ModuloPaso sec = new ModuloPaso();
                sec.SeleccionarDatos("modulo=@modulo", parametros);
                ChkSecuencia.Enabled = sec.TieneFilas();

                ModoFalla falla = new ModoFalla();
                falla.SeleccionarDatos("modulo=@modulo", parametros);
                ChkModoFalla.Enabled = falla.TieneFilas();

                LblModulos.Enabled = true;
                
            }

            ChkCliente.Checked = (requerimiento.TieneFilas());
            ChkCliente.Enabled = (requerimiento.TieneFilas());          
            ChkInterno.Enabled = (requerimiento.TieneFilas());
        }

        private void FrmAceptacionDisenoMecanico_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            CargarVistas();
            CargarRequerimientos();

            foreach (DataGridViewRow row in DgvRequerimentos.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                chk.Value = true;              
                Requerimientos.Add(Convert.ToInt32(row.Cells[0].Value));
            }
            HabilitarMenuRequerimiento();
        }

        public void CargarVistas()
        {
            int id = 0;
            string descripcion = "";
            string strVista = "";

            Modulo modulo = new Modulo();
            ImagenModulo imagenModulo = new ImagenModulo();

            Dictionary<string,object> parametros = new Dictionary<string,object>();
            parametros.Add("@modulo",IdModulo);
            ImagenModulo.Modelo().SeleccionarDatos("modulo=@modulo", parametros).ForEach(delegate(Fila f)
            {
                id = Convert.ToInt32(f.Celda("id"));
                descripcion = f.Celda("descripcion").ToString();
                strVista = f.Celda("vista").ToString();

                Object objMiniatura = f.Celda("archivo");
                Image img = null;
                ImageConverter converter = new ImageConverter();

                byte[] miniatrura = (byte[])converter.ConvertTo(CB_Base.Properties.Resources.downloadPdf_gray, typeof(byte[]));

                if (objMiniatura != null)
                {
                    int alto = 80;
                    int largo = 80;

                    miniatrura = (byte[])f.Celda("archivo");
                    ImageConverter ic = new ImageConverter();
                    img = (Image)(ic.ConvertFrom(miniatrura));

                    if (img.Width > alto | img.Height > largo)
                    {
                        Bitmap bitmap = new Bitmap(alto, largo);
                        using (Graphics graphics = Graphics.FromImage((Image)bitmap))
                            graphics.DrawImage(img, 0, 0, alto, largo);
                        img = bitmap;
                    }
                }
                DgvImagenModulo.Rows.Add(id, false, strVista, descripcion, img);
            });
            
        }

        public void CargarRequerimientos()
        {
            DgvRequerimentos.Rows.Clear();
            Requerimiento requerimiento = new Requerimiento();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            string proyecto = "";
            string query = "";

            Modulo.Modelo().CargarDatos(IdModulo).ForEach(delegate(Fila f)
            {
                proyecto = Convert.ToDecimal(f.Celda("proyecto")).ToString("F2");
            });

            if (ChkInterno.Checked)
            {
                parametros.Add("@interno", "INTERNO");
                query = "origen=@interno";
            }
            else
            {
                if (parametros.ContainsKey("@interno"))
                    parametros.Remove("@interno");
            }
            if (ChkCliente.Checked)
            {
                parametros.Add("@cliente", "CLIENTE");
                if (query != "")
                    query += " OR ";
                query += "origen=@cliente";
            }
            else
            {
                if (parametros.ContainsKey("@cliente"))
                    parametros.Remove("@cliente");
            }

            if (ChkCliente.Checked || ChkInterno.Checked)
            {
                parametros.Add("@definido", "DEFINIDO");

                if(Concepto)
                    parametros.Add("@nivel", "CONCEPTO");
                else
                    parametros.Add("@nivel", "DISEÑO");

                parametros.Add("@proyecto", proyecto);
                parametros.Add("@modulo", IdModulo);

                query = query.Insert(0, "(");
                query = query.Insert(query.Length, ")");

                query += " AND estatus=@definido AND nivel_revision=@nivel AND proyecto=@proyecto AND modulo=@modulo";

                requerimiento.SeleccionarDatos(query, parametros).ForEach(delegate(Fila f)
                {
                    DgvRequerimentos.Rows.Add(Convert.ToInt32(f.Celda("id")), false, f.Celda("nombre").ToString(), f.Celda("origen").ToString());
                });
            }
        }

        public void CargarElemento()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", IdModulo);
            Elemento.Modelo().SeleccionarDatos("modulo=@modulo order by id",parametros).ForEach(delegate(Fila f)
            {
                Elementos.Add(Convert.ToInt32(f.Celda("id").ToString()));
            });
        }

        public void CargarSecuencia()
        {
            Elemento elementos = new Elemento();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", IdModulo);
            ModuloPaso.Modelo().SeleccionarDatos("modulo=@modulo order by id", parametros).ForEach(delegate(Fila f)
            {
                elementos.CargarDatos(Convert.ToInt32(f.Celda("elemento")));
                if(elementos.TieneFilas())
                {
                    Secuencia.Add(Convert.ToInt32(f.Celda("id").ToString()));
                }
            });
        }

        public void CargarFallas()
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@modulo", IdModulo);
            ModoFalla.Modelo().SeleccionarDatos("modulo=@modulo order by id", parametros).ForEach(delegate(Fila f)
            {
                Fallas.Add(Convert.ToInt32(f.Celda("id").ToString()));
            });
        }

        public void CargarPDF()
        {
            byte[] archivo = null;
            string nombreArchivo = "";
            if (!Concepto)
                nombreArchivo = "Final_design_aproval_module_" + IdModulo;
            else
                nombreArchivo = "Concept_design_aproval_module_" + IdModulo;

            int idUsuario = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));
            archivo = FormatosPDF.AceptacionDisenoFinal(Proyecto, Vista, Requerimientos, Elementos, Secuencia, Fallas, IdModulo, SubensambleId, Concepto);
            Global.MostrarPDF(archivo, nombreArchivo, null, VisorPDF);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if(HabilitarPDF())
                CargarPDF();
        }

        private void BorrarElemento(string tipo)
        {
            Requerimiento req = new Requerimiento();
            int reqId = 0;

            for (int i = Requerimientos.Count - 1; i >= 0; i--)
            {
                reqId = Requerimientos[i];
                req.CargarDatos(reqId);

                if (req.TieneFilas())
                {
                    if (req.Fila().Celda("origen").ToString() == tipo)
                        Requerimientos.Remove(reqId);               

                    BorrarFilas(tipo);
                }
            }
            CargarPDF();
        }

        private void BorrarFilas(string tipo)
        {           
            for (int i = 0; i <= DgvRequerimentos.Rows.Count - 1; i++)
            {
                int reqId = Convert.ToInt32(DgvRequerimentos.Rows[i].Cells["id_req"].Value);
                if (DgvRequerimentos.Rows[i].Cells["origen"].Value.ToString() == tipo)
                {
                    DgvRequerimentos.Rows.RemoveAt(i);
                    if(DgvRequerimentos.Rows.Count >= 0)
                        i = -1;
                } 
            }

            if(Requerimientos.Count > 0)
                CargarPDF();
        }

        private void CargarElemento(string tipo)
        {
            Requerimiento requerimiento = new Requerimiento();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            string proyecto = "";

            Modulo.Modelo().CargarDatos(IdModulo).ForEach(delegate(Fila f)
            {
                proyecto = Convert.ToDecimal(f.Celda("proyecto")).ToString("F2");
            });

            parametros.Add("@tipo", tipo);
            string query = "origen=@tipo";

            parametros.Add("@definido", "DEFINIDO");
            if(!Concepto)
                parametros.Add("@nivel", "DISEÑO");
            else
                parametros.Add("@nivel", "CONCEPTO");

            parametros.Add("@proyecto", proyecto);
            parametros.Add("@modulo", IdModulo);

            query = query.Insert(0, "(");
            query = query.Insert(query.Length, ")");

            query += " AND estatus=@definido AND nivel_revision=@nivel AND proyecto=@proyecto AND modulo=@modulo";

            requerimiento.SeleccionarDatos(query, parametros).ForEach(delegate(Fila f)
            {
                DgvRequerimentos.Rows.Add(Convert.ToInt32(f.Celda("id")), false, f.Celda("nombre").ToString(), f.Celda("origen").ToString());
            });                
        }

        private bool HabilitarPDF()
        {
            return (Vista.Count > 0 || Requerimientos.Count > 0 || Elementos.Count > 0 || Secuencia.Count > 0 || Fallas.Count > 0);
        }

        private bool HabilitarSeleccionarTodos()
        {
            bool habilitar = true;
            foreach (DataGridViewRow row in DgvRequerimentos.Rows)
            {
                if (row.Cells[1].Value.ToString().ToLower() != "true")
                {
                    habilitar = true;
                    return habilitar;
                }
            }

            if (DgvRequerimentos.Rows.Count > 0)
                return false;
            else
                return false;
        }

        private bool HabilitarSeleccionarNada()
        {
            bool habilitar = true;
            foreach (DataGridViewRow row in DgvRequerimentos.Rows)
            {
                if (row.Cells[1].Value.ToString().ToLower() != "false")
                {
                    habilitar = true;
                    return habilitar;
                }
            }

            if (DgvRequerimentos.Rows.Count > 0)
                return false;
            else
                return false;
        }

        private void HabilitarMenuRequerimiento()
        {
            seleccionarTodoToolStripMenuItem.Enabled = HabilitarSeleccionarTodos();
            seleccionarTodoToolStripMenuItem.Visible = HabilitarSeleccionarTodos();
            seleccionarNadaToolStripMenuItem.Enabled = HabilitarSeleccionarNada();
            seleccionarNadaToolStripMenuItem.Visible = HabilitarSeleccionarNada();
        }

        private void ChkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkCliente.Checked)
            {
                if (Requerimientos.Count > 0)
                    BorrarElemento("CLIENTE");
                else
                    BorrarFilas("CLIENTE");
            }


            if (ChkCliente.Checked)
                CargarElemento("CLIENTE");

            HabilitarMenuRequerimiento();
        }

        private void ChkInterno_CheckStateChanged(object sender, EventArgs e)
        {
            if (!ChkInterno.Checked)
            {
                if (Requerimientos.Count > 0)
                    BorrarElemento("INTERNO");
                else
                    BorrarFilas("INTERNO");
            }

            if (ChkInterno.Checked)
                CargarElemento("INTERNO");

            HabilitarMenuRequerimiento();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (HabilitarPDF())
            {
                string nombreArchivo = "";
                if(!Concepto)
                    nombreArchivo = "Final_design_aproval_module_" + IdModulo;
                else
                    nombreArchivo = "Concept_design_aproval_module_" + IdModulo;

                byte[] archivo = null;
                int idUsuario = Convert.ToInt32(Global.UsuarioActual.Fila().Celda("id"));
                archivo = FormatosPDF.AceptacionDisenoFinal(Proyecto, Vista, Requerimientos, Elementos, Secuencia, Fallas, IdModulo, SubensambleId, Concepto);

                SaveFileDialog guardarArchivo = new SaveFileDialog();

                guardarArchivo.Title = "Guardar archivo ";
                guardarArchivo.FilterIndex = 1;
                guardarArchivo.RestoreDirectory = true;
                guardarArchivo.FileName = nombreArchivo;
                guardarArchivo.Filter = "PDF files|*.pdf";

                if (guardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(guardarArchivo.FileName, archivo);
                }
            }
            else
            {
                MessageBox.Show("Debe terminar la creación del archivo PDF para poder guardarlo","Archivo incompleto",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void ChkElemento_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkElemento.Checked)
                CargarElemento();
            else
                Elementos.Clear();
            CargarPDF();
        }

        private void ChkSecuencia_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSecuencia.Checked)
                CargarSecuencia();
            else
                Secuencia.Clear();
            CargarPDF();
        }

        private void ChkModoFalla_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkModoFalla.Checked)
                CargarFallas();
            else
                Fallas.Clear();
            CargarPDF();
        }

        private void MunuRequerimientosCheck()
        {
            if(ChkCliente.Checked)
            {
                foreach (DataGridViewRow row in DgvRequerimentos.Rows)
                {
                    if (row.Cells["origen"].Value.ToString() == "CLIENTE")
                    {
                        row.Cells[1].Value = true;
                        if (!Requerimientos.Exists(x => x == Convert.ToInt32(Convert.ToInt32(row.Cells[0].Value))))
                            Requerimientos.Add(Convert.ToInt32(row.Cells[0].Value));
                    }
                }
            }
            if(ChkInterno.Checked)
            {
                foreach (DataGridViewRow row in DgvRequerimentos.Rows)
                {
                    if (row.Cells["origen"].Value.ToString() == "INTERNO")
                    {
                        row.Cells[1].Value = true;
                        if (!Requerimientos.Exists(x => x == Convert.ToInt32(Convert.ToInt32(row.Cells[0].Value))))
                            Requerimientos.Add(Convert.ToInt32(row.Cells[0].Value));
                    }
                }
            }
            DgvRequerimentos.EndEdit();
            CargarPDF();
        }

        private void DgvRequerimentos_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo clickDgvRequerimentos = DgvRequerimentos.HitTest(e.X, e.Y);
            TerminoPagoProveedor termino = new TerminoPagoProveedor();


            if (clickDgvRequerimentos.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;


                    MenuRequerimiento.Show(mouseX, mouseY);
                }
                DgvRequerimentos.ClearSelection();
            } 
        }

        private void DgvRequerimentos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    int mouseX = Cursor.Position.X;
                    int mouseY = Cursor.Position.Y;
                    MenuRequerimiento.Show(mouseX, mouseY);
                }
            }
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MunuRequerimientosCheck();
            HabilitarMenuRequerimiento();
        }

        private void seleccionarNadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChkCliente.Checked)
            {
                foreach (DataGridViewRow row in DgvRequerimentos.Rows)
                {
                    if (row.Cells["origen"].Value.ToString() == "CLIENTE")
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                        chk.Value = false;
                        if (Requerimientos.Exists(x => x == Convert.ToInt32(Convert.ToInt32(row.Cells[0].Value))))
                            Requerimientos.Remove(Convert.ToInt32(row.Cells[0].Value));
                    }
                }

            }
            if (ChkInterno.Checked)
            {
                
                foreach (DataGridViewRow row in DgvRequerimentos.Rows)
                {
                    if (row.Cells["origen"].Value.ToString() == "INTERNO")
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];
                        chk.Value = false;                      
                        if (Requerimientos.Exists(x => x == Convert.ToInt32(Convert.ToInt32(row.Cells[0].Value))))
                            Requerimientos.Remove(Convert.ToInt32(row.Cells[0].Value));
                    }
                }
            }

            DgvRequerimentos.EndEdit();
            HabilitarMenuRequerimiento();
            CargarPDF();
        }

        private void DgvRequerimentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
                check = (DataGridViewCheckBoxCell)DgvRequerimentos.Rows[e.RowIndex].Cells[1];

                switch (check.Value.ToString())
                {
                    case "True":
                        check.Value = false;
                        Requerimientos.Remove(Convert.ToInt32(DgvRequerimentos.Rows[e.RowIndex].Cells["id_req"].Value));
                        break;
                    case "False":
                        check.Value = true;
                        Requerimientos.Add(Convert.ToInt32(DgvRequerimentos.Rows[e.RowIndex].Cells["id_req"].Value));
                        break;
                }
                DgvRequerimentos.EndEdit();
                HabilitarMenuRequerimiento();
                CargarPDF();
            }
        }

        private void DgvImagenModulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                DataGridViewCheckBoxCell check = new DataGridViewCheckBoxCell();
                check = (DataGridViewCheckBoxCell)DgvImagenModulo.Rows[e.RowIndex].Cells[1]; //DgvImagenModulo.CurrentRow.Index

                if (check.Value == null)
                    check.Value = false;
                switch (check.Value.ToString())
                {
                    case "True":
                        check.Value = false;
                        Vista.Remove(Convert.ToInt32(DgvImagenModulo.Rows[e.RowIndex].Cells["id"].Value));
                        break;
                    case "False":
                        check.Value = true;
                        Vista.Add(Convert.ToInt32(DgvImagenModulo.Rows[e.RowIndex].Cells["id"].Value));
                        break;
                }
                DgvImagenModulo.EndEdit();              
                CargarPDF();
            }
        }
    }
}
