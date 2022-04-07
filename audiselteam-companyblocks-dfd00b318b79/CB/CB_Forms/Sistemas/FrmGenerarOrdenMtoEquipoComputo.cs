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
    public partial class FrmGenerarOrdenMtoEquipoComputo : Ventana
    {
        string TipoEquipo = "";
        string Equipo = "";

        public FrmGenerarOrdenMtoEquipoComputo(string tipoEquipo = "", string equipo = "")
        {
            InitializeComponent();
            CmbTiposMantenimiento.Items.Add(tipoEquipo);
            CmbTiposMantenimiento.SelectedIndex = 0;
            TipoEquipo = tipoEquipo;
            Equipo = equipo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if(usuario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (ChkBUsuarioActual.Checked)
                    ChkBUsuarioActual.Checked = false;

                string nombre = "";
                object objId = usuario.UsuarioSeleccionado.Fila().Celda("id");
                if (objId != null)
                    nombre = objId.ToString() + " - ";

                object objNombre = usuario.UsuarioSeleccionado.Fila().Celda("nombre");
                if (objNombre != null)
                    nombre += objNombre.ToString().TrimStart().TrimEnd();

                object objPaterno = usuario.UsuarioSeleccionado.Fila().Celda("paterno");
                if (objPaterno != null)
                    nombre += " " + objPaterno.ToString().TrimStart().TrimEnd();

                TxtUsuario.Text = nombre;               
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkBUsuarioActual.Checked)
                TxtUsuario.Text = Global.UsuarioActual.Fila().Celda("id").ToString() + " - " + Global.UsuarioActual.NombreCompleto();
            else
                TxtUsuario.Text = "";
        }

        private void CargarEquipos( int usuario, string tipoEquipo, string nombreUsuario)
        {
            CmbEquipos.Items.Clear();

            switch (tipoEquipo)
            {
                case "EQUIPO DE COMPUTO":
                    EquipoComputoUsuario.Modelo().CargarEquiposDeUsuario(usuario).ForEach(delegate(Fila f)
                    {
                        EquipoComputo.Modelo().CargarEquipos(Convert.ToInt32(f.Celda("equipo"))).ForEach(delegate(Fila filaEquipo)
                        {                          
                            CmbEquipos.Items.Add(filaEquipo.Celda("id").ToString() + " - " + filaEquipo.Celda("numero_serie").ToString());
                        });
                    });                    
                    break;
                case "VEHICULO":
                    Vehiculo.Modelo().SeleccionarResponsable(nombreUsuario).ForEach(delegate(Fila f)
                    {
                        CmbEquipos.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("numero_serie").ToString());
                    });
                    break;
                case "MAQUINARIA":
                    MaquinaHerramienta maquinaria = new MaquinaHerramienta();
                    maquinaria.SeleccionarNombreOperador(nombreUsuario).ForEach(delegate(Fila f)
                    {
                        CmbEquipos.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("serie").ToString());
                    });
                    break;
                case "EDIFICIO":
                    Edificio.Modelo().CargarEdificios(nombreUsuario).ForEach(delegate(Fila f)
                    {
                        CmbEquipos.Items.Add(f.Celda("id").ToString() + " - " + f.Celda("clave_catastral").ToString());
                    });
                    break;
                default:
                    break;
            }

            if (CmbEquipos.Items.Count > 0)
                CmbEquipos.SelectedIndex = 0;
        }

        private void FrmOrdenesTrabajo_Load(object sender, EventArgs e)
        {
            if (TipoEquipo != "" && Equipo != "")
            {
                CmbTiposMantenimiento.Text = TipoEquipo;              
                ChkBUsuarioActual.Checked = true;
                CmbEquipos.Text = Equipo;
            }
            else
            {
                CmbTiposMantenimiento.Enabled = false;
                CmbEquipos.Enabled = false;
            }
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            if(TxtUsuario.Text != "")
            {
                CmbTiposMantenimiento.Enabled = true;
                CmbEquipos.Enabled = true;

                string[] datos = TxtUsuario.Text.Split('-');
                int idUsuario = Convert.ToInt32(datos[0].ToString().Trim());

                CargarEquipos(idUsuario, CmbTiposMantenimiento.Text, datos[1].TrimStart());
            }
            else
            {
                CmbTiposMantenimiento.Enabled = false;
                CmbEquipos.Enabled = false;
            }
        }

        private void CmbTiposMantenimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == "")
                return;

            string[] datos = TxtUsuario.Text.Split('-');
            int idUsuario = Convert.ToInt32(datos[0].ToString().Trim());

            CargarEquipos(idUsuario, CmbTiposMantenimiento.Text, datos[1].TrimStart());
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            if(TxtUsuario.Text == "" || CmbTiposMantenimiento.Text == "" || CmbEquipos.Text == "" || TxtPuntosReparar.Text == "")
            {
                MessageBox.Show("Favor de llenar toda la información.", "Información incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] datosEquipo = CmbEquipos.Text.Split('-');
            string[] datosUsuario = TxtUsuario.Text.Split('-');

            try
            {
                Fila insertarOrden = new Fila();
                insertarOrden.AgregarCelda("tipo_equipo", CmbTiposMantenimiento.Text);
                insertarOrden.AgregarCelda("equipo", Convert.ToInt32(datosEquipo[0].ToString().Trim()));
                insertarOrden.AgregarCelda("puntos_reparacion", TxtPuntosReparar.Text.ToUpper());
                insertarOrden.AgregarCelda("solicitado_por", datosUsuario[1].TrimStart());
                insertarOrden.AgregarCelda("fecha_registro", DateTime.Now);
                insertarOrden.AgregarCelda("usuario_registro", Global.UsuarioActual.NombreCompleto());
                insertarOrden.AgregarCelda("estatus", "PENDIENTE");
                OrdenTrabajoMantenimiento.Modelo().Insertar(insertarOrden);
                MessageBox.Show("Su orden de trabajo ha sido creada correctamente", "Orden creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error mientras se generaba su orden de trabajo, vuelva a intentarlo. Si el problema continua contacte al personal de sistemas." + Environment.NewLine + "Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
