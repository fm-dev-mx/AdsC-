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
    public partial class FrmSeleccionarProveedorMultiplesRequisiciones : Form
    {
        int IdRfq = 0;
        int NodosSeleccionados = 0;
        string ProveedorSeleccionado = string.Empty;

        public FrmSeleccionarProveedorMultiplesRequisiciones(int idRfq, string proveedorSeleccionado)
        {
            InitializeComponent();
            IdRfq = idRfq;
            ProveedorSeleccionado = proveedorSeleccionado;
            lblProveedor.Text = "Proveedor seleccionado: " + proveedorSeleccionado;
        }

        private void FrmSeleccionarProveedorMultiplesRequisiciones_Load(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = false;
            CargarNodosConceptos();
            if(TvConceptos.Nodes == null)
            {
                MessageBox.Show("Antes de seleccionar un proveedor debeb capturar por lo menos una cotización",
                                   "Cotizaciones sin capturar", MessageBoxButtons.OK, MessageBoxIcon.Question);
                Close();
            }

        }

        private void CargarNodosConceptos()
        {
            RfqConcepto.Modelo().SeleccionarRfqConceptoDeRfq(IdRfq).ForEach(delegate(Fila f)
            {
                // partidas (conceptos) del rfq que no tengan proveedor seleccionado
                TreeNode nodoTemp = Global.CrearNodo
                (
                    "conceptos-" + f.Celda("id") + "|numeroParte-" + f.Celda("numero_parte").ToString().Replace("-", "*"),
                    f.Celda("numero_parte").ToString(),
                    0
                );

                TvConceptos.Nodes.Add(nodoTemp);
                CargarNodosProyectos(nodoTemp);
            });
        }

        private void CargarNodosProyectos(TreeNode nodoPadre)
        {
            nodoPadre.Nodes.Clear();

            string[] strNodoPadre = nodoPadre.Name.Split('|');
            string numeroParte = strNodoPadre[1].Split('-')[1].Replace('*','-');
            MaterialProyecto material = new MaterialProyecto();
            material.ProyectosSinProveedorSeleccionado(numeroParte);

            if(material.TieneFilas())
            {
                material.Filas().ForEach(delegate(Fila f)
                {
                    TreeNode nodoTemp = Global.CrearNodo
                    (
                        "proyecto-" + f.Celda("proyecto"),
                        Convert.ToDecimal(f.Celda("proyecto")).ToString("F2"),
                        1
                    );

                    if (nodoPadre.Checked)
                    {
                        nodoTemp.Checked = true;
                        NodosSeleccionados++;
                    }

                    nodoPadre.Nodes.Add(nodoTemp);
                    CargarNodosRequisiciones(nodoTemp);
                 });
                nodoPadre.ExpandAll();
            }
            else
            {
                nodoPadre.Remove();
            }
        }

        private void CargarNodosRequisiciones(TreeNode nodoPadre)
        {
            nodoPadre.Nodes.Clear();

            string[] arrayNumeroParte = nodoPadre.Parent.Name.Split('|');
            string numeroParte = arrayNumeroParte[1].Split('-')[1].Replace('*','-');
            decimal proyecto = Convert.ToDecimal(nodoPadre.Name.Split('-')[1]);
            MaterialProyecto material = new MaterialProyecto();
            material.RequisicionesSinProveedorSeleccionado(numeroParte, proyecto);
            
            if(material.TieneFilas())
            {
                material.Filas().ForEach(delegate(Fila f)
                {
                    string cantidad = string.Empty;
                    if(f.Celda("tipo_venta").ToString() == "POR PIEZA")
                        cantidad = "PIEZAS";
                    else
                        cantidad = "PAQUETES";

                    TreeNode nodoTemp = Global.CrearNodo
                    (
                        "req-" + f.Celda("id"),
                        "REQ #" + f.Celda("id") + " | " + f.Celda("requisitor").ToString() + " " + f.Celda("total").ToString() + " " + cantidad,
                        2
                    );

                    if (nodoPadre.Checked)
                    {
                        nodoTemp.Checked = true;
                        NodosSeleccionados++;
                    }

                    nodoPadre.Nodes.Add(nodoTemp);
                });

                nodoPadre.ExpandAll();
            }
            else
            {
                nodoPadre.Remove();
            }
        }

        private void RefrescarNodo(TreeNode nodoPadre)
        {
           /* string nombreDividido = nodoPadre.Name.Split('-')[0];
            switch (nombreDividido)
            {
                case "conceptos":
                    CargarNodosProyectos(nodoPadre);
                    break;
                case "proyecto":
                    CargarNodosRequisiciones(nodoPadre);
                    break;
                default:
                    break;
            }*/
        }

        private void TvConceptos_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            RefrescarNodo(e.Node);
        }

        private void BtnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            foreach (TreeNode nodo in TvConceptos.Nodes)
            {
                nodo.Checked = true;
            }
        }

        private void BtnSeleccionarNada_Click(object sender, EventArgs e)
        {
            foreach (TreeNode nodo in TvConceptos.Nodes)
            {
                nodo.Checked = false;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string requisicionesModificadas = string.Empty;

            foreach (TreeNode nodoConcepto in TvConceptos.Nodes)
            {
                if(nodoConcepto.Checked)
                {
                    //seleccion por nodo principal
                    requisicionesModificadas += SeleccionarProveedorPreferidoPorConcepto(nodoConcepto);
                }
                else
                {
                    // si no esta seleccionado el nodo principal checamos si tiene hijos
                    if(nodoConcepto.Nodes != null)
                    {
                        foreach (TreeNode nodoProyecto in nodoConcepto.Nodes)
                        {
                            if (nodoProyecto.Checked)
                            {
                                //seleccion por proyecto
                                requisicionesModificadas += SeleccionarProveedorPreferidoPorProyecto(nodoProyecto);
                            }
                            else if (nodoProyecto.Nodes.Count > 0)
                            {
                                //seleccion individual de requisiciones 
                                foreach (TreeNode nodoRequisicion in nodoProyecto.Nodes)
                                {
                                    //if (nodoRequisicion.Checked)
                                    requisicionesModificadas += SeleccionarProveedorPreferidoPorRequisicion(nodoRequisicion);
                                }
                            }
                        }
                    }
                    
                }
            }
            if (requisicionesModificadas != string.Empty)
                requisicionesModificadas = " Las siguientes requisiciones fueron enviadas a revisión técnica ya que exceden el límite de costo asignado por finanzas " + requisicionesModificadas.Remove(requisicionesModificadas.Length - 2);

            MessageBox.Show("Se asignó a " + ProveedorSeleccionado + " como proveedor preferido para las requisiciones seleccionadas." + requisicionesModificadas,
                                "Seleccionar proveedor preferido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private string SeleccionarProveedorPreferidoPorConcepto(TreeNode nodo)
        {
            string resultado = string.Empty;
            string[] strNombreDividido = nodo.Name.Split('|');
            string[] strConcepto = strNombreDividido[0].Split('-');
            string[] strNumeroParte = strNombreDividido[1].Split('-');

            MaterialProyecto material = new MaterialProyecto();
            material.RequisicionesSinProveedorSeleccionado(strNumeroParte[1].Replace("*", "-"));

            int idConcepto = 0;

            if (nodo.Checked)
                idConcepto = Convert.ToInt32(strConcepto[1]);

            return MaterialProyecto.Modelo().SeleccionarProveedorPreferido(material, idConcepto).ToString();
        }

        private string SeleccionarProveedorPreferidoPorProyecto(TreeNode nodo)
        {
            string[] strNombreDividido = nodo.Parent.Name.Split('|');
            string[] strConcepto = strNombreDividido[0].Split('-');
            string[] strNumeroParte = strNombreDividido[1].Split('-');
            decimal proyecto = Convert.ToDecimal(nodo.Name.Split('-')[1]);

            MaterialProyecto material = new MaterialProyecto();
            material.RequisicionesSinProveedorSeleccionado(strNumeroParte[1].Replace("*", "-"), proyecto);

            int idConcepto = 0;

            if(nodo.Checked)
                idConcepto = Convert.ToInt32(strConcepto[1]);

            return MaterialProyecto.Modelo().SeleccionarProveedorPreferido(material, idConcepto);
        }

        private string SeleccionarProveedorPreferidoPorRequisicion(TreeNode nodo)
        {
            int idReq = Convert.ToInt32(nodo.Name.Split('-')[1]);
            int idConcepto = 0;
            
            if(nodo.Checked)
                idConcepto = Convert.ToInt32(nodo.Parent.Parent.Name.Split('|')[0].Split('-')[1]);

            MaterialProyecto material = new MaterialProyecto();
            material.CargarDatos(idReq);

            return MaterialProyecto.Modelo().SeleccionarProveedorPreferido(material, idConcepto);
        }

        private void TvConceptos_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void TvConceptos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                ChecarNodosHijos(e.Node, true);
                //NodosSeleccionados++;
            }
            else 
            {
               //NodosSeleccionados--;
               if(e.Node.Name.StartsWith("req"))
               {
                   if(e.Node.Parent.Checked)
                   {
                       e.Node.Parent.Checked = false;
                   }
               }
               else if(e.Node.Name.StartsWith("proyecto"))
               {
                   bool checarHijos = true;

                   foreach (TreeNode nodo in e.Node.Nodes)
                   {
                       if (!nodo.Checked)
                       {
                           checarHijos = false;
                           break;
                       }
                   }

                   if (checarHijos)
                       ChecarNodosHijos(e.Node, false);

                    if(e.Node.Parent.Checked)
                   {
                       e.Node.Parent.Checked = false;
                   }
               }
               else if(e.Node.Name.StartsWith("conceptos"))
               {
                   bool checarHijos = true;

                   foreach (TreeNode nodo in e.Node.Nodes)
                   {
                       if(!nodo.Checked)
                       {
                           checarHijos = false;
                           break;
                       }
                   }

                   if(checarHijos)
                        ChecarNodosHijos(e.Node, false);
               }
            }

            BtnAceptar.Enabled = HabilitarBoton();//(NodosSeleccionados > 0);
        }

        private bool HabilitarBoton()
        {
            bool habilitar = false;
            foreach (TreeNode nodoConceptos in TvConceptos.Nodes)
            {
                if (!nodoConceptos.Checked)
                {
                    foreach (TreeNode nodoProyecto in nodoConceptos.Nodes)
                    {
                        if (!nodoConceptos.Checked)
                        {
                            foreach (TreeNode nodo in nodoProyecto.Nodes)
                            {
                                if (nodo.Checked)
                                    return true;
                            }
                        }
                        else
                            return true;
                    }
                }
                else
                    return true;
            }

            return habilitar;
        }

        private void TvConceptos_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
           
        }

        private void ChecarNodosHijos(TreeNode nodos, bool checar)
        {
            foreach (TreeNode nodo in nodos.Nodes)
            {
                nodo.Checked = checar;

                if (nodo.Nodes.Count > 0)
                {
                    this.ChecarNodosHijos(nodo, checar);
                }
            }
        }

        private void TvConceptos_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
