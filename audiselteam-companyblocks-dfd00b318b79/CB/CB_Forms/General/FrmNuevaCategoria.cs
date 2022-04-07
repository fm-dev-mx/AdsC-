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
    public partial class FrmNuevaCategoria : Form
    {
        int IdTipo = 0;
        SystemEnums.TipoCategoria TipoDeAgregado;
        bool Editar = false;

        public FrmNuevaCategoria(int idTipo, SystemEnums.TipoCategoria tipoDeAgregado, bool editar = false)
        {
            InitializeComponent();
            IdTipo = idTipo;
            TipoDeAgregado = tipoDeAgregado;
            Editar = editar;
        }

        private void FrmNuevaCategoria_Load(object sender, EventArgs e)
        {
            if (TipoDeAgregado == SystemEnums.TipoCategoria.Subcategoria)
                audiselTituloForm1.Text = "NUEVA SUBCATEGORIA";

            if(Editar)
            {
                switch (TipoDeAgregado)
                {
                    case SystemEnums.TipoCategoria.Categoria:
                        CategoriaMaterial categoria = new CategoriaMaterial();
                        categoria.CargarDatos(IdTipo);
                        if (categoria.TieneFilas())
                        {
                            audiselTituloForm1.Text = "EDITAR CATEGORIA";
                            TxtCategoria.Text = categoria.Fila().Celda("categoria").ToString();
                        }
                        break;
                    case SystemEnums.TipoCategoria.Subcategoria:
                        CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
                        subcategoria.CargarDatos(IdTipo);
                        if(subcategoria.TieneFilas())
                        {
                            audiselTituloForm1.Text = "EDITAR SUBCATEGORIA";
                            TxtCategoria.Text = subcategoria.Fila().Celda("nombre").ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            Fila filaTemporal = new Fila();
            switch (TipoDeAgregado)
            {
                case SystemEnums.TipoCategoria.Categoria:
                    CategoriaMaterial categoria = new CategoriaMaterial();
                    // Verificar existencia de categoria
                    categoria.SeleccionarDatos("categoria='" + TxtCategoria.Text + "'");

                    if(categoria.TieneFilas())
                    {
                        MessageBox.Show("Esta categoría ya existe, intente de nuevo.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    { 
                        if(Editar)
                        {
                            categoria.CargarDatos(IdTipo);
                            if(categoria.TieneFilas())
                            {
                                categoria.Fila().ModificarCelda("categoria", TxtCategoria.Text);
                                categoria.GuardarDatos();
                            }
                        }
                        else
                        {
                            filaTemporal.AgregarCelda("categoria", TxtCategoria.Text);
                            filaTemporal.AgregarCelda("tipo_compra", IdTipo);
                            CategoriaMaterial.Modelo().Insertar(filaTemporal);
                        }
                    }
                    break;
                case SystemEnums.TipoCategoria.Subcategoria:
                    CategoriaSubMaterial subcategoria = new CategoriaSubMaterial();
                    // Verificar existencia de subcategoria
                    subcategoria.SeleccionarDatos("nombre='" + TxtCategoria.Text + "' and categoria= " + IdTipo );

                    if(subcategoria.TieneFilas())
                    {
                        MessageBox.Show("Esta subcategoría ya existe, intente de nuevo.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else 
                    {
                        if (Editar)
                        {
                            subcategoria.CargarDatos(IdTipo);
                            if (subcategoria.TieneFilas())
                            {
                                subcategoria.Fila().ModificarCelda("nombre", TxtCategoria.Text);
                                subcategoria.GuardarDatos();
                            }
                        }
                        else
                        {
                            filaTemporal.AgregarCelda("nombre", TxtCategoria.Text);
                            filaTemporal.AgregarCelda("categoria", IdTipo);
                            CategoriaSubMaterial.Modelo().Insertar(filaTemporal);
                        }
                    }
                    break;
            }
            
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

       
    }
}

namespace SystemEnums {
    public enum TipoCategoria 
    { 
        Tipo,
        Categoria,
        Subcategoria
    }
}