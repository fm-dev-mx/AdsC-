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
    public partial class FrmMostrarMaterialCancelado : Form
    {
        decimal Proyecto = 0;
        public FrmMostrarMaterialCancelado(decimal proyecto)
        {
            InitializeComponent();
            Proyecto = proyecto;
            audiselTituloForm1.Text += proyecto.ToString("F2");
        }

        private void FrmMostrarMaterialCancelado_Load(object sender, EventArgs e)
        {
            MaterialProyectoCancelacion cancelados = new MaterialProyectoCancelacion();
            cancelados.SeleccionarMaterialCanceladoDeProyecto(Proyecto).ForEach(delegate (Fila f)
            {
                DgvMaterialCancelado.Rows.Add
                (
                    f.Celda("id_material_proyecto"),
                    f.Celda("numero_parte"),
                    f.Celda("descripcion"),
                    f.Celda("usuario_requisitor"),
                    Global.FechaATexto(f.Celda("fecha"), false),
                    f.Celda("usuario_cancela")

                );
            });
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
