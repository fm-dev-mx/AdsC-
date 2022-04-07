using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB_Base.Classes;

namespace CB_Base.CB_Controles
{

    public partial class NiuTriViu : UserControl
    {
        public class EspecificacionNivel 
        {
            string NombreNivel;
            
            Func<object, List<Fila>> Coleccion;
            
            string NombreColId;

            public string SiguienteNivel;

            public EspecificacionNivel(string nombreNivel, Func<object, List<Fila>> coleccion, string nombreColId, string siguienteNivel = null)
            {
                NombreNivel = nombreNivel;
                Coleccion = coleccion;
                NombreColId = nombreColId;
                SiguienteNivel = siguienteNivel;
            }


            public void CargarNivel(object nodoPadre, object parametroQuery)
            {
                TreeNodeCollection coleccionDeNodos = null;

                if (nodoPadre is TreeView)
                {
                    coleccionDeNodos = (nodoPadre as TreeView).Nodes;
                }

                if (nodoPadre is TreeNode)
                {
                    coleccionDeNodos = (nodoPadre as TreeNode).Nodes;
                }

                coleccionDeNodos.Clear();
                Coleccion(parametroQuery).ForEach(delegate(Fila dato)
                {
                    TreeNode nuevoNodo = Global.CrearNodo(
                        NombreNivel + "-" + dato.Celda(NombreColId).ToString(),
                        dato.Celda(NombreColId).ToString().ToLower().CapitalizeFirst()
                        );

                    coleccionDeNodos.Add(nuevoNodo);
                });   
            }

            public void CargarSiguienteNivel()
            { 
                
            }
        }

        Dictionary<string, EspecificacionNivel> Niveles;

        public TreeView Tv {
            get {
                return treeView1;
            }
        }

        public NiuTriViu()
        {
            InitializeComponent();

            Niveles = new Dictionary<string, EspecificacionNivel>(){
                { 
                    "tipo",  
                    new EspecificacionNivel(
                    "tipo",
                    (parametroNulo) =>
                    {
                        Competencia ListaCompetencia = new Competencia();
                        return ListaCompetencia.SeleccionarTiposHabilidades();
                    },
                    "tipo",
                    "habilidad"
                    )
                },
                {
                    "habilidad",
                    new EspecificacionNivel(
                        "habilidad",
                        (tipo) =>
                        {
                            Competencia ListaCompetencia = new Competencia();
                            return ListaCompetencia.SeleccionarHabilidadesDeTipo(tipo.ToString());
                        },
                        "habilidad",
                        "topico"
                        )
                },
                {
                    "topico",
                    new EspecificacionNivel(
                        "topico",
                        (habilidadId) =>
                        {
                            TopicoHabilidad topico = new TopicoHabilidad();
                            return topico.CargarTopicosHabilidad(Convert.ToInt32(habilidadId));
                        },
                        "topico"
                        )
                }
            };
        }

        private void NiuTriViu_Load(object sender, EventArgs e)
        {
            Niveles["tipo"].CargarNivel(treeView1, null);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] nombreDividido = e.Node.Name.Split('-');
            if(Niveles[nombreDividido[0]].SiguienteNivel != null)
            {
                Niveles[Niveles[nombreDividido[0]].SiguienteNivel].CargarNivel(e.Node, nombreDividido[1]);
            }
        }
    }
}
