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
    public partial class FrmCompetenciasAgregarModificar : Form
    {
        TreeNode NodoActual;
        string Modo;

        /// <param name="nodo">Referencia de nodo seleccionado.</param>
        /// <param name="modo">Puede ser "ADD" o "MOD"</param>
        public FrmCompetenciasAgregarModificar(TreeNode nodo, string modo)
        {
            InitializeComponent();
            NodoActual = nodo;
            Modo = modo;

            if(NodoActual != null)
            {
                string[] nombreDividido = NodoActual.Name.Split('-');
                if(Modo == "MOD")
                { 
                    TxtNombre.Text = NodoActual.Text;
                    switch (nombreDividido[0])
                    {
                        case "[habilidad]":
                            LblTitulo.Text = "Modificar competencia".ToUpper();
                            this.Text = "Modificar competencia".ToUpper();
                            break;
                        case "[topico]":
                            LblTitulo.Text = "Modificar tópico".ToUpper();
                            this.Text = "Modificar tópico".ToUpper();
                            break;
                    }
                }
                else if(Modo == "ADD") 
                {
                    switch (nombreDividido[0])
                    {
                        case "[tipo]":
                            LblTitulo.Text = "Agregar competencia".ToUpper();
                            this.Text = "Agregar competencia".ToUpper();
                            break;
                        case "[habilidad]":
                            LblTitulo.Text = "Agregar tópico".ToUpper();
                            this.Text = "Agregar tópico".ToUpper();
                            break;
                    }
                }
            }

        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            switch(Modo)
            { 
                case "ADD":
                    Fila f = new Fila();

                    switch(NodoActual.Name.Split('-')[0])
                    {
                        case "[tipo]":
                            f.AgregarCelda("tipo", NodoActual.Name.Split('-')[1]);
                            f.AgregarCelda("habilidad", TxtNombre.Text);
                            Competencia.Modelo().Insertar(f);
                            break;
                        case "[habilidad]":
                            f.AgregarCelda("habilidad", Convert.ToInt32(NodoActual.Name.Split('-')[1]));
                            f.AgregarCelda("topico", TxtNombre.Text);
                            f.AgregarCelda("descripcion", string.Empty);

                            TopicoHabilidad.Modelo().Insertar(f);
                            break;
                    }
                    break;
                case "MOD":
                    switch (NodoActual.Name.Split('-')[0])
                    {
                        case "[habilidad]":
                            Competencia competenciaTemporal = new Competencia();
                            competenciaTemporal.CargarDatos(Convert.ToInt32(NodoActual.Name.Split('-')[1]));
                            if (competenciaTemporal.TieneFilas())
                            {
                                competenciaTemporal.Fila().ModificarCelda("habilidad", TxtNombre.Text);
                                competenciaTemporal.GuardarDatos();
                            }
                            break;
                        case "[topico]":
                            TopicoHabilidad topicoTemporal = new TopicoHabilidad();
                            topicoTemporal.CargarDatos(Convert.ToInt32(NodoActual.Name.Split('-')[1]));
                            if (topicoTemporal.TieneFilas())
                            {
                                topicoTemporal.Fila().ModificarCelda("topico", TxtNombre.Text);
                                topicoTemporal.GuardarDatos();
                            }
                            break;
                    }
                    break;
            }
            
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private TreeNode CrearNodo(string nombre, string texto, ContextMenuStrip menu = null)
        {
            TreeNode nodoTemp = new TreeNode();
            nodoTemp.Name = nombre;
            nodoTemp.Text = texto;
            nodoTemp.ImageIndex = 0;
            nodoTemp.SelectedImageIndex = 0;
            if (menu != null)
            {
                nodoTemp.ContextMenuStrip = menu;
            }
            return nodoTemp;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}
