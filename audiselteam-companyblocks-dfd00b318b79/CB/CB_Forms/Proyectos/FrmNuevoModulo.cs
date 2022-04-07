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

    public partial class FrmNuevoModulo : Ventana
    {
        int IdModulo = 0;
        int SubEnsamble = 0;
        decimal IdProyecto = 0;
        Modulo ModuloCargado = new Modulo();
        Proyecto ProyectoCargado = new Proyecto();
        bool Editar = false;

        public FrmNuevoModulo(decimal idProyecto, int idModulo=0)
        {
            InitializeComponent();
            IdModulo = idModulo;
            IdProyecto = idProyecto;
            if(IdModulo > 0)
                ModuloCargado.CargarDatos(IdModulo);

            if (IdProyecto > 0)
                ProyectoCargado.CargarDatos(IdProyecto);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void FrmNuevoModulo_Load(object sender, EventArgs e)
        {
            if(ModuloCargado.TieneFilas())
            {
                LblTitulo.Text = "EDITAR MODULO";                
                TxtDescripcion.Text = ModuloCargado.Fila().Celda("descripcion").ToString();
                NumSubensamble.Value = Convert.ToDecimal(ModuloCargado.Fila().Celda("subensamble"));
                SubEnsamble = Convert.ToInt32(ModuloCargado.Fila().Celda("subensamble"));
                BtnRegistrar.Text = "Guardar";
                TxtNombre.Text = ModuloCargado.Fila().Celda("nombre").ToString();
                Editar = true;
            }
            NumSubensamble.Value = 1;
        }

        public bool ValidarDatos()
        {
            return TxtNombre.Text != "" && TxtDescripcion.Text != "";
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Modulo modulo = new Modulo();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@proyecto", IdProyecto);
            parametros.Add("@subensamble", NumSubensamble.Value);
            modulo.SeleccionarDatos("proyecto=@proyecto AND subensamble=@subensamble",parametros);
            if (modulo.TieneFilas())
            {
                if (Editar)
                {
                    ModuloCargado.Fila().ModificarCelda("nombre", TxtNombre.Text);
                    ModuloCargado.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                    ModuloCargado.GuardarDatos();
                    DialogResult = System.Windows.Forms.DialogResult.OK;                   
                }
                else
                {
                    LblInfo.Visible = true;
                    LblInfo.Text = "El subensamble " + NumSubensamble.Value + " ya fue asignado";
                }
                    
            }
            else
            {
                LblInfo.Visible = false;
                if (!ValidarDatos())
                {
                    LblInfo.Text = "Ingresa toda la informacion requerida";
                    LblInfo.Visible = true;
                    return;
                }

                if (ModuloCargado.TieneFilas())
                {
                    ModuloCargado.Fila().ModificarCelda("nombre", TxtNombre.Text);
                    ModuloCargado.Fila().ModificarCelda("descripcion", TxtDescripcion.Text);
                    ModuloCargado.Fila().ModificarCelda("subensamble", Convert.ToInt32(NumSubensamble.Value));
                    ModuloCargado.GuardarDatos();
                }
                else
                {
                    Fila mod = new Fila();
                    mod.AgregarCelda("nombre", TxtNombre.Text);
                    mod.AgregarCelda("descripcion", TxtDescripcion.Text);
                    mod.AgregarCelda("proyecto", IdProyecto);
                    mod.AgregarCelda("subensamble", Convert.ToInt32(NumSubensamble.Value));
                 
                    mod.AgregarCelda("usuario_bloqueo_mecanico", "N/A");
                    mod.AgregarCelda("bloqueo_mecanico", 0);
                    mod.AgregarCelda("estatus_aprobacion", "PENDIENTE");
                    mod.AgregarCelda("usuario_aprobacion", "N/A");
                    mod.AgregarCelda("revision", 0);
                    mod.AgregarCelda("comentarios_revision", string.Empty);

                    if(ProyectoCargado.TieneFilas())
                    {
                        if(ProyectoCargado.Fila().Celda("estatus_liberacion").ToString() == "LIBERADO")
                        {
                            mod.AgregarCelda("estatus_liberacion", ProyectoCargado.Fila().Celda("estatus_liberacion"));
                            mod.AgregarCelda("usuario_liberacion", ProyectoCargado.Fila().Celda("usuario_liberacion"));
                            mod.AgregarCelda("fecha_liberacion", ProyectoCargado.Fila().Celda("fecha_liberacion"));
                            mod.ModificarCelda("evidencia_liberacion", ProyectoCargado.Fila().Celda("evidencia_liberacion"));
                        }
                        else
                        {
                            mod.AgregarCelda("estatus_liberacion", "PENDIENTE");
                            mod.AgregarCelda("usuario_liberacion", "N/A");
                            mod.ModificarCelda("evidencia_liberacion", 0);
                        }
                    }
                    Modulo.Modelo().Insertar(mod);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void NumSubensamble_ValueChanged(object sender, EventArgs e)
        {
           /* switch (Convert.ToInt32(NumSubensamble.Value))
            {
                case 1:
                    TxtNombre.Text = "LOWER STRUCTURE";
                    TxtNombre.ReadOnly = true;
                    break;
                case 2:
                    TxtNombre.Text = "MAIN TOOLING PLATE";
                    TxtNombre.ReadOnly = true;
                    break;
                case 3:
                    TxtNombre.Text = "UPPER STRUCTURE";
                    TxtNombre.ReadOnly = true;
                    break;
                case 4:
                    TxtNombre.Text = "LOWER STRUCTURE DOOR STYLE 1";
                    TxtNombre.ReadOnly = true;
                    break;
                case 5:
                    TxtNombre.Text = "LOWER STRUCTURE DOOR STYLE 2";
                    TxtNombre.ReadOnly = true;
                    break;
                case 6:
                    TxtNombre.Text = "UPPER STRUCTURE DOOR STYLE 1";
                    TxtNombre.ReadOnly = true;
                    break;
                case 7:
                    TxtNombre.Text = "UPPER STRUCTURE DOOR STYLE 2";
                    TxtNombre.ReadOnly = true;
                    break;
                case 8:
                    TxtNombre.Text = "DIAL INDEX SYSTEM";
                    TxtNombre.ReadOnly = true;
                    break;
                case 9:
                    TxtNombre.Text = "PNEUMATIC BASE PLATE";
                    TxtNombre.ReadOnly = true;
                    break;
                case 10:
                    TxtNombre.Text = "HMI FRAME";
                    TxtNombre.ReadOnly = true;
                    break;
                default:
                   
                    TxtNombre.ReadOnly = false;                 
                    TxtNombre.Text = "";
                    break;
            }*/
            ModuloEstandar moduloEstandar = new ModuloEstandar();
            moduloEstandar.CargarDatos(Convert.ToInt32(NumSubensamble.Value));

            if(moduloEstandar.TieneFilas())
            {
                TxtNombre.Text = moduloEstandar.Fila().Celda("nombre").ToString();
                TxtNombre.ReadOnly = true;
            }
            else
            {
                TxtNombre.ReadOnly = false;
                TxtNombre.Text = "";
            }

            BtnRegistrar.Enabled = TxtNombre.Text != "STD SPARE";
        }
    }
}
