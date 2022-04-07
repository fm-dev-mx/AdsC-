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
    public partial class FrmHistorialMantenimiento : Ventana
    {

        string TipoEquipo = string.Empty;
        List<Fila> ListaMantenimiento = new List<Fila>();

        public FrmHistorialMantenimiento(List<Fila> listaMantenimiento, string tipoEquipo)
        {
            InitializeComponent();
            TipoEquipo = tipoEquipo;
            ListaMantenimiento = listaMantenimiento;
        }

        private void FrmHistorialMantenimiento_Load(object sender, EventArgs e)
        {
            CmbEquipo.Items.Add(TipoEquipo);
            CmbMantenimiento.SelectedIndex = 0;
            CmbEquipo.SelectedIndex = 0;
            CargarEquipos();
        }

        private void CargarEquipos()
        {
            DgvHistorial.Rows.Clear();

            List<string> ChecarDuplicados = new List<string>();

            ListaMantenimiento.ForEach(delegate(Fila f)
            {
                 string duplicado = f.Celda("idEquipo").ToString() + " " + f.Celda("tipo_mantenimiento").ToString() + " " + f.Celda("tipo_equipo").ToString();
                 if (!ChecarDuplicados.Contains(duplicado))
                 {
                     if (f.Celda("tipo_mantenimiento").ToString() == CmbMantenimiento.Text)
                         DgvHistorial.Rows.Add(f.Celda("id").ToString(), f.Celda("tipo_mantenimiento").ToString(), f.Celda("tipo_equipo").ToString(), f.Celda("idEquipo").ToString() + " - " + f.Celda("numero_serie").ToString(), f.Celda("nombre").ToString());
                     else if (CmbMantenimiento.Text == "TODOS")
                         DgvHistorial.Rows.Add(f.Celda("id").ToString(), f.Celda("tipo_mantenimiento").ToString(), f.Celda("tipo_equipo").ToString(), f.Celda("idEquipo").ToString() + " - " + f.Celda("numero_serie").ToString(), f.Celda("nombre").ToString());
                 }
            });
        }

        private void CmbMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEquipos();
        }

        private void CmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEquipos();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            byte[] archivo = null;
            FrmVisorPDF pdf = null;
            string[] datos = DgvHistorial.SelectedRows[0].Cells["equipo"].Value.ToString().Split('-');
            int idEquipo = Convert.ToInt32(datos[0].Trim());
            List<Fila> filaEquipo = new List<Fila>();

            switch (CmbEquipo.Text)
            {
                case "EQUIPO DE COMPUTO":
                    EquipoComputo.Modelo().CargarDatos(idEquipo).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEquipo = new Fila();
                        nuevaFilaEquipo.AgregarCelda("numero_serie", f.Celda("numero_serie"));
                        nuevaFilaEquipo.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("clase", f.Celda("clase"));
                        filaEquipo.Add(nuevaFilaEquipo);
                    });         
                    break;
                case "EDIFICIO":
                    Edificio.Modelo().CargarDatos(idEquipo).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEquipo = new Fila();
                        nuevaFilaEquipo.AgregarCelda("numero_serie", f.Celda("clave_catastral"));
                        nuevaFilaEquipo.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("clase", f.Celda("clase"));
                        filaEquipo.Add(nuevaFilaEquipo);
                    });
                    break;
                case "MAQUINARIA":
                    MaquinaHerramienta.Modelo().CargarDatos(idEquipo).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEquipo = new Fila();
                        nuevaFilaEquipo.AgregarCelda("numero_serie", f.Celda("serie"));
                        nuevaFilaEquipo.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("clase", f.Celda("clase"));
                        filaEquipo.Add(nuevaFilaEquipo);
                    });
                    break;
                case "VEHICULO":
                    Vehiculo.Modelo().CargarDatos(idEquipo).ForEach(delegate(Fila f)
                    {
                        Fila nuevaFilaEquipo = new Fila();
                        nuevaFilaEquipo.AgregarCelda("numero_serie", f.Celda("numero_serie"));
                        nuevaFilaEquipo.AgregarCelda("ultimo_mantenimiento", f.Celda("ultimo_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("responsable_mantenimiento", f.Celda("responsable_mantenimiento"));
                        nuevaFilaEquipo.AgregarCelda("clase", f.Celda("clase"));
                        filaEquipo.Add(nuevaFilaEquipo);
                    });
                    break;
                default:
                    break;
            }

            string nombrePdf = string.Empty;
            if(DgvHistorial.SelectedRows[0].Cells["equipo"].Value.ToString().Contains('/'))
                nombrePdf = DgvHistorial.SelectedRows[0].Cells["equipo"].Value.ToString().Replace('/','_');
            else
                nombrePdf = DgvHistorial.SelectedRows[0].Cells["equipo"].Value.ToString();

            archivo = FormatosPDF.HistorialMantenimiento(idEquipo, CmbEquipo.Text, CmbMantenimiento.Text, filaEquipo);
            pdf = new FrmVisorPDF(archivo, "HISTORIAL DE MANTENIMIENTO " + CmbMantenimiento.Text + " DE " + CmbEquipo.Text + " " + nombrePdf);
            pdf.ShowDialog();
        }
    }
}
