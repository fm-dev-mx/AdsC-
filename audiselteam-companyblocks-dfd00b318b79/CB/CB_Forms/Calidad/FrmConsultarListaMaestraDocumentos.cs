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
    public partial class FrmConsultarListaMaestraDocumentos : Ventana
    {
        public FrmConsultarListaMaestraDocumentos()
        {
            InitializeComponent();
        }

        private void FrmConsultarListaMaestraDocumentos_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
            CargarDocumentos(CmbFiltroDepartamento.Text);
        }

        private void CargarDepartamentos()
        {
            DocumentoSgc departamentos = new DocumentoSgc();
            CmbFiltroDepartamento.Items.Clear();

            CmbFiltroDepartamento.Items.Add("TODOS");

            departamentos.Departamentos().ForEach(delegate(Fila f)
            {
                CmbFiltroDepartamento.Items.Add(f.Celda("departamento"));
            });

            if (CmbFiltroDepartamento.Items.Count > 0)
                CmbFiltroDepartamento.SelectedIndex = 0;
        }

        private void CargarDocumentos(string departamento)
        {
            DgvListadoMaestro.Rows.Clear();

            DocumentoSgc documentos = new DocumentoSgc();

            documentos.Documentos(departamento).ForEach(delegate(Fila f)
            {
                DgvListadoMaestro.Rows.Add(f.Celda("id"), f.Celda("tipo_archivo"), f.Celda("departamento"), f.Celda("titulo"), f.Celda("revision"), f.Celda("usuario_creacion"), f.Celda("usuario_revision"), f.Celda("usuario_aprobacion"), Global.FechaATexto(f.Celda("fecha_revision")));
            });

            if (DgvListadoMaestro.Rows.Count > 0)
                DgvListadoMaestro.ClearSelection();
        }

        private void CmbFiltroDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDocumentos(CmbFiltroDepartamento.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }
}
