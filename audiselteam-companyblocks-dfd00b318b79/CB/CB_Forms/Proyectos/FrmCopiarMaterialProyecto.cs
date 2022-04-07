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
    public partial class FrmCopiarMaterialProyecto : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        decimal proyectoDestino = 0;

        public FrmCopiarMaterialProyecto(decimal proyectoDestino)
        {
            InitializeComponent();
            this.proyectoDestino = proyectoDestino;
        }

        public void CargarUsuarios()
        {
            CmbFiltroRequisitor.Items.Clear();
            CmbFiltroRequisitor.Items.Add("TODOS");

            Usuario.Modelo().Activos().ForEach(delegate(Fila usuario)
            {
                CmbFiltroRequisitor.Items.Add(usuario.Celda("nombre").ToString() + " " + usuario.Celda("paterno").ToString());
            });
        }

        public void CargarCategorias()
        {
            CmbFiltroCategoria.Items.Clear();
            CmbFiltroCategoria.Items.Add("TODOS");

            CatalogoMaterial.Modelo().Categorias(null).ForEach(delegate(Fila categoria)
            {
                CmbFiltroCategoria.Items.Add(categoria.Celda("categoria").ToString());
            });
        }

        public void CargarFabricantes()
        {
            CmbFiltroFabricante.Items.Clear();
            CmbFiltroFabricante.Items.Add("TODOS");

            CatalogoMaterial.Modelo().Fabricantes().ForEach(delegate(Fila fabricante)
            {
                CmbFiltroFabricante.Items.Add(fabricante.Celda("fabricante").ToString());
            });
        }

        public void CargarMaterial(decimal proyecto, string estatusSeleccion = "PRELIMINAR", string estatusAutorizacion = "TODOS", string estatusCompra = "TODOS", string requisitor = "TODOS", string categoria = "TODOS", string fabricante = "TODOS")
        {
            List<Fila> material = new List<Fila>();

            material = MaterialProyecto.Modelo().Filtrar(proyecto, estatusSeleccion, estatusAutorizacion, estatusCompra, requisitor, categoria, fabricante);

            int fila = Global.GuardarFilaSeleccionada(DgvMaterial);

            DgvMaterial.Rows.Clear();
            material.ForEach(delegate(Fila mat)
            {
                string strTotal = "";

                if (mat.Celda("tipo_venta").ToString() == "POR PIEZA")
                    strTotal = mat.Celda("total").ToString() + " pieza(s)";
                else
                    strTotal = mat.Celda("total").ToString() + " paquete(s) con " + mat.Celda("piezas_paquete").ToString() + " piezas c/u";

                int accesorioPara = Convert.ToInt32(mat.Celda("accesorio_para"));
                string strAccesorioPara = "";
                if (accesorioPara > 0)
                    strAccesorioPara = "Req. #" + accesorioPara;
                else
                    strAccesorioPara = "N/A";

                DgvMaterial.Rows.Add(true, mat.Celda("id"), mat.Celda("requisitor"), mat.Celda("categoria"), mat.Celda("numero_parte"), mat.Celda("fabricante"), mat.Celda("descripcion"), mat.Celda("piezas_requeridas").ToString(), strTotal, strAccesorioPara, mat.Celda("estatus_autorizacion"), mat.Celda("estatus_compra"), mat.Celda("estatus_almacen"));

                DataGridViewCell celdaSeleccion = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["seleccion"];
                DataGridViewCell celdaNumeroParte = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["numero_parte"];
                DataGridViewCell celdaAutorizacion = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_autorizacion"];
                DataGridViewCell celdaCompra = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_compra"];
                DataGridViewCell celdaAlmacen = DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["estatus_almacen"];


                if (Convert.ToInt32(mat.Celda("accesorio_para")) > 0)
                {
                    DgvMaterial.Rows[DgvMaterial.RowCount - 1].Cells["seleccion"].ReadOnly = true;
                    DgvMaterial.Rows[DgvMaterial.RowCount - 1].DefaultCellStyle.ForeColor = Color.Gray;
                }

                if (celdaAutorizacion.Value.ToString() == "RECHAZADO")
                {
                    celdaAutorizacion.Style.BackColor = Color.Red;
                    celdaAutorizacion.Style.ForeColor = Color.White;
                }
                else if (celdaAutorizacion.Value.ToString() == "AUTORIZADO")
                {
                    celdaAutorizacion.Style.BackColor = Color.LightGreen;
                }
                if (celdaCompra.Value.ToString() == "ORDENADO")
                {
                    celdaCompra.Style.BackColor = Color.LightGreen;
                }
                if (celdaAlmacen.Value.ToString() == "RECIBIDO" || celdaAlmacen.Value.ToString() == "ENTREGADO")
                {
                    celdaAlmacen.Style.BackColor = Color.LightGreen;
                }
            });
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FrmCopiarMaterialProyecto_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarCategorias();
            CargarFabricantes();

            CmbFiltroSeleccion.Text = "PRELIMINAR";
            CmbFiltroCompra.Text = "TODOS";
            CmbFiltroFabricante.Text = "TODOS";
            CmbFiltroRequisitor.Text = Global.UsuarioActual.Fila().Celda("nombre") + " " + Global.UsuarioActual.Fila().Celda("paterno");
            CmbFiltroCategoria.Text = "TODOS";
            CmbFiltroAutorizacion.Text = "TODOS";

            Proyecto prj = new Proyecto();
            prj.CargarDatos(proyectoDestino);
            NumProyectoDestino.Value = Convert.ToDecimal(prj.Fila().Celda("id"));
            LblProyectoDestino.Text = prj.Fila().Celda("nombre").ToString();
        }

        private void NumProyectoOrigen_ValueChanged(object sender, EventArgs e)
        {
            Proyecto prj = new Proyecto();
            prj.CargarDatos(NumProyectoOrigen.Value);

            if( NumProyectoOrigen.Value == NumProyectoDestino.Value)
            {
                LblProyectoOrigen.Text = "SELECCIONA UN PROYECTO DISTINTO AL DE DESTINO";
                DgvMaterial.Rows.Clear();
                Filtros.Enabled = false;
                return;
            }
            else if(!prj.TieneFilas())
            {
                LblProyectoOrigen.Text = "EL PROYECTO NO FUE ENCONTRADO";
                DgvMaterial.Rows.Clear();
                Filtros.Enabled = false;
                return;
            }
            else if (prj.TieneFilas())
            {
                Filtros.Enabled = true;
                LblProyectoOrigen.Text = prj.Fila().Celda("nombre").ToString();
            }

            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CmbFiltroSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }

        private void CmbFiltroRequisitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            DgvMaterial.Columns["requisitor"].Visible = CmbFiltroRequisitor.Text == "TODOS";
        }

        private void CmbFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            DgvMaterial.Columns["categoria"].Visible = CmbFiltroCategoria.Text == "TODOS";
        }

        private void CmbFiltroFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            DgvMaterial.Columns["fabricante"].Visible = CmbFiltroFabricante.Text == "TODOS";
        }

        private void CmbFiltroAutorizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            DgvMaterial.Columns["estatus_autorizacion"].Visible = CmbFiltroAutorizacion.Text == "TODOS";
        }

        private void CmbFiltroCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
            DgvMaterial.Columns["estatus_compra"].Visible = CmbFiltroCompra.Text == "TODOS";
        }

        private void BtnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in DgvMaterial.Rows)
            {
                row.Cells["seleccion"].Value = true;
            }
        }

        private void BtnSeleccionarNada_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvMaterial.Rows)
            {
                row.Cells["seleccion"].Value = row.Cells["accesorio_para"].Value.ToString() != "N/A";
            }
        }

        private void BtnCopiar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Seguro que quieres copiar el material seleccionado?", "Copiar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            foreach(DataGridViewRow row in DgvMaterial.Rows)
            {
                if( Convert.ToBoolean(row.Cells["seleccion"].Value) == true)
                {
                    int idReqOrigen = Convert.ToInt32(row.Cells["id_req"].Value);
                    int nuevaReq = 0;
                    int accesorioPara = 0;
                    MaterialProyecto reqOrigen = new MaterialProyecto();
                    reqOrigen.CargarDatos(idReqOrigen);

                    accesorioPara = Convert.ToInt32(reqOrigen.Fila().Celda("accesorio_para"));

                    if(accesorioPara == 0)
                    {
                        nuevaReq = CopiarRequisicion(reqOrigen);

                        reqOrigen.Accesorios(idReqOrigen).ForEach(delegate(Fila f)
                        {
                            int idReqAccesorio = Convert.ToInt32(f.Celda("id"));
                            MaterialProyecto reqAccesorio = new MaterialProyecto();
                            reqAccesorio.CargarDatos(idReqAccesorio);

                            CopiarRequisicion(reqAccesorio, nuevaReq);
                        });
                    }
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    
        private int CopiarRequisicion(MaterialProyecto reqOrigen, int accesorioPara=0)
        {
            Fila matProyecto = new Fila();

            string requisitor = Global.UsuarioActual.Fila().Celda("nombre").ToString() + " " + Global.UsuarioActual.Fila().Celda("paterno").ToString();

            matProyecto.AgregarCelda("requisitor", requisitor);
            matProyecto.AgregarCelda("proyecto", proyectoDestino);
            matProyecto.AgregarCelda("categoria", reqOrigen.Fila().Celda("categoria"));
            matProyecto.AgregarCelda("numero_parte", reqOrigen.Fila().Celda("numero_parte"));
            matProyecto.AgregarCelda("fabricante", reqOrigen.Fila().Celda("fabricante"));
            matProyecto.AgregarCelda("descripcion", reqOrigen.Fila().Celda("descripcion"));
            matProyecto.AgregarCelda("piezas_requeridas", reqOrigen.Fila().Celda("piezas_requeridas"));
            matProyecto.AgregarCelda("piezas_stock", reqOrigen.Fila().Celda("piezas_stock"));
            matProyecto.AgregarCelda("total", reqOrigen.Fila().Celda("total"));
            matProyecto.AgregarCelda("tipo_venta", reqOrigen.Fila().Celda("tipo_venta"));
            matProyecto.AgregarCelda("piezas_paquete", reqOrigen.Fila().Celda("piezas_paquete"));
            matProyecto.AgregarCelda("po", 0);
            matProyecto.AgregarCelda("estatus_seleccion", "PRELIMINAR");
            matProyecto.AgregarCelda("estatus_compra", "PENDIENTE");
            matProyecto.AgregarCelda("accesorio_para", accesorioPara);

            matProyecto = MaterialProyecto.Modelo().Insertar(matProyecto);
            return Convert.ToInt32(matProyecto.Celda("id"));
        }

        private void ChkIncluirAccesorios_CheckedChanged(object sender, EventArgs e)
        {
            CargarMaterial(NumProyectoOrigen.Value, CmbFiltroSeleccion.Text, CmbFiltroAutorizacion.Text, CmbFiltroCompra.Text, CmbFiltroRequisitor.Text, CmbFiltroCategoria.Text, CmbFiltroFabricante.Text);
        }
    }
}
