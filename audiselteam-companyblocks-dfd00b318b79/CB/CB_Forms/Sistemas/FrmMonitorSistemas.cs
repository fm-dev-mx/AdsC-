using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CB_Base.Classes;

namespace CB
{
    public partial class FrmMonitorSistemas : Form
    {
        List<Fila> EquipoComputoLista = new List<Fila>();
        int IdEquipo = 0;
        int IdMonitor = 0;
        int IdAccesorio = 0;

        public FrmMonitorSistemas()
        {
            InitializeComponent();
        }

        private void FrmEquipoComputo_Load(object sender, EventArgs e)
        {
            CargarRol();
            CargarComputadora();
        }  
    
        private void CargarRol()
        {
            Usuario rol = new Usuario();
            CmbRol.Items.Add("TODOS");
            rol.SeleccionarDatos("", null, "distinct(rol)").ForEach(delegate(Fila f)
            {
                CmbRol.Items.Add(f.Celda("rol"));
            });
            CmbRol.SelectedIndex = 0;
        }

        private void DgvComputadora_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (IdEquipo != 0)
                    {
                        editarToolStripMenuItem.Enabled = true;
                        borrarToolStripMenuItem.Enabled = true;
                        asignarToolStripMenuItem.Enabled = true;
                        liberarToolStripMenuItem1.Enabled = true;
                    }
                    else
                    {
                        editarToolStripMenuItem.Enabled = false;
                        borrarToolStripMenuItem.Enabled = false;
                        asignarToolStripMenuItem.Visible = false;
                        liberarToolStripMenuItem1.Visible = false;
                    }

                    MenuComputadora.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void TabElementos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = TabElementos.SelectedIndex;
            switch (index)
            {
                case 0:
                    CargarComputadora();
                    break;
                case 1:
                    CargarMonitores();
                    break;
                case 2:
                    CargarAccesorios();
                    break;
                    
                default:
                    break;
            }
        }

        public void CargarComputadora()
        {
            DgvComputadora.Rows.Clear();

            EquipoComputo computadoras = new EquipoComputo();
            computadoras.BuscarEquipo(CmbRol.Text).ForEach(delegate(Fila f)
            {
                string almacenamientoHdd = "N/A";
                object objHdd = f.Celda("almacenamiento_hdd_descripcion");
                if (objHdd != null)
                    almacenamientoHdd = objHdd.ToString();

                string almacenamientoSsd = "N/A";
                object objSsd = f.Celda("almacenamiento_ssd_descripcion");
                if (objSsd != null)
                    almacenamientoSsd = objSsd.ToString();

                string ram = "N/A";
                object objRam = f.Celda("ram_caracteristicas");
                if (objRam != null)
                    ram = objRam.ToString();

                string fechaAlta = "N/A";
                string usuarioAsignado = "SIN ASIGNAR";
                string fechaAsignacion = "N/A";

                object objFechaAlta = f.Celda("fecha_alta");
                if (objFechaAlta != null)
                    fechaAlta = Convert.ToDateTime(objFechaAlta).ToString("MMM dd, yyyy");

                if (CmbRol.Text != "TODOS")
                {
                    object objUsuarioNombre = f.Celda("nombre");
                    object objUsuarioMaterno = f.Celda("materno");
                    object objUsuarioPaterno = f.Celda("paterno");

                    if (objUsuarioNombre != null)
                        usuarioAsignado = f.Celda("nombre").ToString();

                    if (objUsuarioPaterno != null)
                        usuarioAsignado = f.Celda("nombre").ToString() + " " + f.Celda("paterno");

                    if (objUsuarioMaterno != null)
                        usuarioAsignado = f.Celda("nombre").ToString() + " " + f.Celda("paterno") + " " + f.Celda("materno").ToString();

                    object objFechaAsignacion = f.Celda("fecha_asignacion");
                    if (objFechaAsignacion != null)
                        fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");
                }
                else
                {
                    EquipoComputoUsuario usuario = new EquipoComputoUsuario();
                    Dictionary<string, object> parametrosUsuarios = new Dictionary<string, object>();
                    parametrosUsuarios.Add("@equipo", f.Celda("idEquipo").ToString());
                    usuario.SeleccionarDatos("equipo=@equipo", parametrosUsuarios);

                    if (usuario.TieneFilas())
                    {
                        string idUsuarioAsignado = usuario.Fila().Celda("usuario").ToString();

                        Usuario usuarios = new Usuario();
                        usuarios.CargarDatos(Convert.ToInt32(idUsuarioAsignado)).ForEach(delegate(Fila filaUsuario)
                        {
                            object objUsuarioNombre = filaUsuario.Celda("nombre");
                            object objUsuarioMaterno = filaUsuario.Celda("materno");
                            object objUsuarioPaterno = filaUsuario.Celda("paterno");

                            if (objUsuarioNombre != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString();

                            if (objUsuarioPaterno != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString() + " " + filaUsuario.Celda("paterno");

                            if (objUsuarioMaterno != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString() + " " + filaUsuario.Celda("paterno") + " " + filaUsuario.Celda("materno").ToString();

                        });

                        object objFechaAsignacion = usuario.Fila().Celda("fecha_asignacion");
                        if (objFechaAsignacion != null)
                            fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");
                    }
                }
                
                DgvComputadora.Rows.Add(f.Celda("idEquipo").ToString(),
                                            f.Celda("descripcion").ToString(),
                                            f.Celda("marca").ToString(),
                                            f.Celda("modelo").ToString(),
                                            f.Celda("numero_serie").ToString(),
                                            f.Celda("equipo_nombre").ToString(),
                                            f.Celda("equipo_usuario").ToString(),
                                            f.Celda("equipo_contrasena").ToString(),
                                            f.Celda("direccion_mac").ToString(),
                                            f.Celda("sistema_operativo_marca").ToString(),
                                            f.Celda("sistema_operativo_version").ToString(),
                                            f.Celda("sistema_operativo_tipo").ToString(),
                                            almacenamientoHdd,
                                            almacenamientoSsd,
                                            f.Celda("procesador_marca").ToString(),
                                            f.Celda("procesador_descripcion").ToString(),
                                            f.Celda("tarjeta_grafica_marca").ToString(),
                                            f.Celda("tarjeta_grafica_descripcion").ToString(),
                                            ram,
                                            fechaAlta,
                                            usuarioAsignado,
                                            fechaAsignacion,
                                            Global.ObjetoATexto(f.Celda("razon_social"), "SIN DEFINIR"));
            });
            DgvComputadora.ClearSelection();
        }

        public void CargarMonitores()
        {
            DgvMonitor.Rows.Clear();

            EquipoComputo computadoras = new EquipoComputo();
            computadoras.BuscarMonitor(CmbRol.Text).ForEach(delegate(Fila f)
            {
                string usuarioAsignado = "SIN ASIGNAR";
                string fechaAsignacion = "N/A";
                string fechaAlta = "N/A";

                object objFechaAlta = f.Celda("fecha_alta");
                if (objFechaAlta != null)
                    fechaAlta = Convert.ToDateTime(objFechaAlta).ToString("MMM dd, yyyy");

                if (CmbRol.Text != "TODOS")
                {
                    object objUsuarioNombre = f.Celda("nombre");
                    object objUsuarioMaterno = f.Celda("materno");
                    object objUsuarioPaterno = f.Celda("paterno");

                    if (objUsuarioNombre != null)
                        usuarioAsignado = f.Celda("nombre").ToString();

                    if (objUsuarioPaterno != null)
                        usuarioAsignado = f.Celda("nombre").ToString() + " " + f.Celda("paterno");

                    if (objUsuarioMaterno != null)
                        usuarioAsignado = f.Celda("nombre").ToString() + " " + f.Celda("paterno") + " " + f.Celda("materno").ToString();

                    object objFechaAsignacion = f.Celda("fecha_asignacion");
                    if (objFechaAsignacion != null)
                        fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");
                }
                else
                {
                    EquipoComputoUsuario usuario = new EquipoComputoUsuario();
                    Dictionary<string, object> parametrosUsuarios = new Dictionary<string, object>();
                    parametrosUsuarios.Add("@equipo", f.Celda("idEquipo").ToString());
                    usuario.SeleccionarDatos("equipo=@equipo", parametrosUsuarios);

                    if (usuario.TieneFilas())
                    {
                        string idUsuarioAsignado = usuario.Fila().Celda("usuario").ToString();

                        Usuario usuarios = new Usuario();
                        usuarios.CargarDatos(Convert.ToInt32(idUsuarioAsignado)).ForEach(delegate(Fila filaUsuario)
                        {
                            object objUsuarioNombre = filaUsuario.Celda("nombre");
                            object objUsuarioMaterno = filaUsuario.Celda("materno");
                            object objUsuarioPaterno = filaUsuario.Celda("paterno");

                            if (objUsuarioNombre != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString();

                            if (objUsuarioPaterno != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString() + " " + filaUsuario.Celda("paterno");

                            if (objUsuarioMaterno != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString() + " " + filaUsuario.Celda("paterno") + " " + filaUsuario.Celda("materno").ToString();

                        });

                        object objFechaAsignacion = usuario.Fila().Celda("fecha_asignacion");
                        if (objFechaAsignacion != null)
                            fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");
                    }
                }

                DgvMonitor.Rows.Add(f.Celda("idEquipo").ToString(),
                                        f.Celda("descripcion").ToString(),
                                        f.Celda("marca").ToString(),
                                        f.Celda("modelo").ToString(),
                                        f.Celda("monitor_pulgadas").ToString(),
                                        f.Celda("numero_serie").ToString(),
                                        fechaAlta,
                                        usuarioAsignado,
                                        fechaAsignacion,
                                        Global.ObjetoATexto(f.Celda("razon_social"), "SIN DEFINIR"));
            });
            DgvMonitor.ClearSelection();
        }

        private void CargarAccesorios()
        {
           // ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvAccesorios);
            DgvAccesorios.Rows.Clear();

            EquipoComputo computadoras = new EquipoComputo();
             computadoras.BuscarAccesorio(CmbRol.Text).ForEach(delegate(Fila f)
            {
                string usuarioAsignado = "SIN ASIGNAR";
                string fechaAsignacion = "N/A";
                string fechaAlta = "N/A";

                object objFechaAlta = f.Celda("fecha_alta");
                if (objFechaAlta != null)
                    fechaAlta = Convert.ToDateTime(objFechaAlta).ToString("MMM dd, yyyy");

                if (CmbRol.Text != "TODOS")
                {
                    object objUsuarioNombre = f.Celda("nombre");
                    object objUsuarioMaterno = f.Celda("materno");
                    object objUsuarioPaterno = f.Celda("paterno");

                    if (objUsuarioNombre != null)
                        usuarioAsignado = f.Celda("nombre").ToString();

                    if (objUsuarioPaterno != null)
                        usuarioAsignado = f.Celda("nombre").ToString() + " " + f.Celda("paterno");

                    if (objUsuarioMaterno != null)
                        usuarioAsignado = f.Celda("nombre").ToString() + " " + f.Celda("paterno") + " " + f.Celda("materno").ToString();

                    object objFechaAsignacion = f.Celda("fecha_asignacion");
                    if (objFechaAsignacion != null)
                        fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");
                }
                else
                {
                    EquipoComputoUsuario usuario = new EquipoComputoUsuario();
                    Dictionary<string, object> parametrosUsuarios = new Dictionary<string, object>();
                    parametrosUsuarios.Add("@equipo", f.Celda("idEquipo").ToString());
                    usuario.SeleccionarDatos("equipo=@equipo", parametrosUsuarios);

                    if (usuario.TieneFilas())
                    {
                        string idUsuarioAsignado = usuario.Fila().Celda("usuario").ToString();

                        Usuario usuarios = new Usuario();
                        usuarios.CargarDatos(Convert.ToInt32(idUsuarioAsignado)).ForEach(delegate(Fila filaUsuario)
                        {
                            object objUsuarioNombre = filaUsuario.Celda("nombre");
                            object objUsuarioMaterno = filaUsuario.Celda("materno");
                            object objUsuarioPaterno = filaUsuario.Celda("paterno");

                            if (objUsuarioNombre != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString();

                            if (objUsuarioPaterno != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString() + " " + filaUsuario.Celda("paterno");

                            if (objUsuarioMaterno != null)
                                usuarioAsignado = filaUsuario.Celda("nombre").ToString() + " " + filaUsuario.Celda("paterno") + " " + filaUsuario.Celda("materno").ToString();

                        });

                        object objFechaAsignacion = usuario.Fila().Celda("fecha_asignacion");
                        if (objFechaAsignacion != null)
                            fechaAsignacion = Convert.ToDateTime(objFechaAsignacion).ToString("MMM dd, yyyy");
                    }
                }
                DgvAccesorios.Rows.Add(f.Celda("idEquipo").ToString(),
                                        f.Celda("accesorio_tipo").ToString(),
                                        f.Celda("descripcion").ToString(),
                                        f.Celda("marca").ToString(),
                                        f.Celda("modelo").ToString(),
                                        f.Celda("numero_serie").ToString(),
                                        fechaAlta,
                                        usuarioAsignado,
                                        fechaAsignacion,
                                        Global.ObjetoATexto(f.Celda("razon_social"), "SIN DEFINIR"));

            });
           // ConfiguracionDataGridView.Recuperar(cfg, DgvAccesorios);
             DgvAccesorios.ClearSelection();
        }

        private string SeleccionarCategoria()
        {
            string categoria = string.Empty;

            switch (TabElementos.SelectedTab.Text.ToUpper())
            {
                case "COMPUTADORAS":
                    categoria = "COMPUTADORA";
                    break;

                case "MONITORES":
                    categoria = "MONITOR";
                    break;

                case "ACCESORIOS":
                    categoria = "ACCESORIO";
                    break;
            }

            return categoria;
        }

        private void DgvComputadora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            IdEquipo = Convert.ToInt32(DgvComputadora.SelectedRows[0].Cells["id_computadora"].Value);

            if((string)DgvComputadora.SelectedRows[0].Cells["asignado_computadora"].Value != "SIN ASIGNAR")
            {
                liberarToolStripMenuItem1.Visible = true;
                asignarToolStripMenuItem.Visible = false;
            }
            else
            {
                liberarToolStripMenuItem1.Visible = false;
                asignarToolStripMenuItem.Visible = true;
            }
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarEquipoComputo registrar = new FrmRegistrarEquipoComputo("COMPUTADORA");
            if (registrar.ShowDialog() == DialogResult.OK)
            {
                Fila insertarEquipoComputo = new Fila();
                insertarEquipoComputo.AgregarCelda("descripcion", registrar.Descripcion);
                insertarEquipoComputo.AgregarCelda("clase", registrar.TipoEquipo);
                insertarEquipoComputo.AgregarCelda("marca", registrar.Marca);
                insertarEquipoComputo.AgregarCelda("modelo", registrar.Modelo);
                insertarEquipoComputo.AgregarCelda("numero_serie", registrar.NumeroSerie);
                insertarEquipoComputo.AgregarCelda("sistema_operativo_marca", registrar.SOMarca);
                insertarEquipoComputo.AgregarCelda("sistema_operativo_version", registrar.SOVersion);
                insertarEquipoComputo.AgregarCelda("sistema_operativo_tipo", registrar.SOTipo);
                insertarEquipoComputo.AgregarCelda("almacenamiento_hdd", registrar.Hdd);
                insertarEquipoComputo.AgregarCelda("almacenamiento_hdd_descripcion", registrar.HddDescripcion);
                insertarEquipoComputo.AgregarCelda("almacenamiento_ssd", registrar.Ssd);
                insertarEquipoComputo.AgregarCelda("almacenamiento_ssd_descripcion", registrar.SsdDescripcion);
                insertarEquipoComputo.AgregarCelda("procesador_marca", registrar.ProcesadorMarca);
                insertarEquipoComputo.AgregarCelda("procesador_descripcion", registrar.ProcesadorDescripcion);
                insertarEquipoComputo.AgregarCelda("tarjeta_grafica_marca", registrar.TarjetaGraficaMarca);
                insertarEquipoComputo.AgregarCelda("tarjeta_grafica_descripcion", registrar.TarjetaGraficaDescripcion);
                insertarEquipoComputo.AgregarCelda("fecha_alta", DateTime.Now);
                insertarEquipoComputo.AgregarCelda("equipo_nombre", registrar.EquipoNombre);
                insertarEquipoComputo.AgregarCelda("equipo_usuario", registrar.EquipoUsuario);
                insertarEquipoComputo.AgregarCelda("equipo_contrasena", registrar.EquipoContrasena);
                insertarEquipoComputo.AgregarCelda("direccion_mac", registrar.EquipoMac);
                insertarEquipoComputo.AgregarCelda("ram_caracteristicas", registrar.RamCaracteristicas);
                insertarEquipoComputo.AgregarCelda("periodo_mantenimiento", Convert.ToInt32(registrar.PeriodoMantenimiento));
                insertarEquipoComputo.AgregarCelda("razon_social", registrar.RazonSocial);  
                EquipoComputo.Modelo().Insertar(insertarEquipoComputo);
                CargarComputadora();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegistrarEquipoComputo editar = new FrmRegistrarEquipoComputo("COMPUTADORA", IdEquipo);
            if(editar.ShowDialog() == DialogResult.OK)
            {
                EquipoComputo modificar = new EquipoComputo();

                modificar.CargarDatos(IdEquipo);
                if (!modificar.TieneFilas())
                    return;

                modificar.Fila().ModificarCelda("descripcion", editar.Descripcion);
                modificar.Fila().ModificarCelda("clase", editar.TipoEquipo);
                modificar.Fila().ModificarCelda("marca", editar.Marca);
                modificar.Fila().ModificarCelda("modelo", editar.Modelo);
                modificar.Fila().ModificarCelda("numero_serie", editar.NumeroSerie);
                modificar.Fila().ModificarCelda("sistema_operativo_marca", editar.SOMarca);
                modificar.Fila().ModificarCelda("sistema_operativo_version", editar.SOVersion);
                modificar.Fila().ModificarCelda("sistema_operativo_tipo", editar.SOTipo);
                modificar.Fila().ModificarCelda("almacenamiento_hdd", editar.Hdd);
                modificar.Fila().ModificarCelda("almacenamiento_hdd_descripcion", editar.HddDescripcion);
                modificar.Fila().ModificarCelda("almacenamiento_ssd", editar.Ssd);
                modificar.Fila().ModificarCelda("almacenamiento_ssd_descripcion", editar.SsdDescripcion);
                modificar.Fila().ModificarCelda("procesador_marca", editar.ProcesadorMarca);
                modificar.Fila().ModificarCelda("procesador_descripcion", editar.ProcesadorDescripcion);
                modificar.Fila().ModificarCelda("tarjeta_grafica_marca", editar.TarjetaGraficaMarca);
                modificar.Fila().ModificarCelda("tarjeta_grafica_descripcion", editar.TarjetaGraficaDescripcion);
                modificar.Fila().ModificarCelda("equipo_nombre", editar.EquipoNombre);
                modificar.Fila().ModificarCelda("equipo_usuario", editar.EquipoUsuario);
                modificar.Fila().ModificarCelda("equipo_contrasena", editar.EquipoContrasena);
                modificar.Fila().ModificarCelda("direccion_mac", editar.EquipoMac);
                modificar.Fila().ModificarCelda("ram_caracteristicas", editar.RamCaracteristicas);
                modificar.Fila().ModificarCelda("periodo_mantenimiento", Convert.ToInt32(editar.PeriodoMantenimiento));
                modificar.Fila().ModificarCelda("razon_social", editar.RazonSocial); 
                modificar.GuardarDatos();
                CargarComputadora();
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EquipoComputo borrarEquipo = new EquipoComputo();

            DialogResult result = MessageBox.Show("Las información de las computadoras que son borradas no puede ser recuperada en el futuro. ¿Desea continuar?", "Borrar computadora", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvComputadora.SelectedRows)
                {
                    int idComputadoras = Convert.ToInt32(row.Cells[0].Value.ToString());
                    borrarEquipo.CargarDatos(idComputadoras);
                    borrarEquipo.BorrarDatos(idComputadoras);
                    borrarEquipo.GuardarDatos();
                }

                CargarComputadora();
            }
        }

        private void DgvComputadora_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvComputadora.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    editarToolStripMenuItem.Enabled = false;
                    borrarToolStripMenuItem.Enabled = false;
                    asignarToolStripMenuItem.Visible = false;
                    liberarToolStripMenuItem1.Visible = false;

                    MenuComputadora.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRegistrarEquipoComputo registrar = new FrmRegistrarEquipoComputo("MONITOR");
            if (registrar.ShowDialog() == DialogResult.OK)
            {
                Fila insertarEquipoComputo = new Fila();
                insertarEquipoComputo.AgregarCelda("clase", "MONITOR");
                insertarEquipoComputo.AgregarCelda("descripcion", registrar.Descripcion);
                insertarEquipoComputo.AgregarCelda("marca", registrar.Marca);
                insertarEquipoComputo.AgregarCelda("modelo", registrar.Modelo);
                insertarEquipoComputo.AgregarCelda("numero_serie", registrar.NumeroSerie);
                insertarEquipoComputo.AgregarCelda("monitor_pulgadas", registrar.Pulgadas);
                insertarEquipoComputo.AgregarCelda("fecha_alta", DateTime.Now);
                insertarEquipoComputo.AgregarCelda("periodo_mantenimiento", 0);
                insertarEquipoComputo.AgregarCelda("razon_social", registrar.RazonSocial);
                EquipoComputo.Modelo().Insertar(insertarEquipoComputo);
                CargarMonitores();
            }
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRegistrarEquipoComputo editar = new FrmRegistrarEquipoComputo("MONITOR", IdMonitor);
            if (editar.ShowDialog() == DialogResult.OK)
            {
                EquipoComputo modificar = new EquipoComputo();

                modificar.CargarDatos(IdMonitor);
                if (!modificar.TieneFilas())
                    return;

                modificar.Fila().ModificarCelda("descripcion", editar.Descripcion);
                modificar.Fila().ModificarCelda("clase", editar.TipoEquipo);
                modificar.Fila().ModificarCelda("marca", editar.Marca);
                modificar.Fila().ModificarCelda("modelo", editar.Modelo);
                modificar.Fila().ModificarCelda("numero_serie", editar.NumeroSerie);
                modificar.Fila().ModificarCelda("monitor_pulgadas", editar.Pulgadas);
                modificar.Fila().ModificarCelda("periodo_mantenimiento", 0);
                modificar.Fila().ModificarCelda("razon_social", editar.RazonSocial);
                modificar.GuardarDatos();
                CargarMonitores();
            }
        }

        private void borrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EquipoComputo borrarMonitor = new EquipoComputo();

            DialogResult result = MessageBox.Show("Las información de los monitores que son borrados no puede ser recuperado en el futuro. ¿Desea continuar?", "Borrar monitores", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvMonitor.SelectedRows)
                {
                    int idMonitor = Convert.ToInt32(row.Cells[0].Value.ToString());
                    borrarMonitor.CargarDatos(idMonitor);
                    borrarMonitor.BorrarDatos(idMonitor);
                    borrarMonitor.GuardarDatos();
                }

                CargarMonitores();
            }
        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmRegistrarEquipoComputo registrar = new FrmRegistrarEquipoComputo("ACCESORIO");
            if (registrar.ShowDialog() == DialogResult.OK)
            {
                Fila insertarEquipoComputo = new Fila();
                insertarEquipoComputo.AgregarCelda("clase", "ACCESORIO");
                insertarEquipoComputo.AgregarCelda("descripcion", registrar.Descripcion);
                insertarEquipoComputo.AgregarCelda("accesorio_tipo", registrar.AccesorioTipo);
                insertarEquipoComputo.AgregarCelda("marca", registrar.Marca);
                insertarEquipoComputo.AgregarCelda("modelo", registrar.Modelo);
                insertarEquipoComputo.AgregarCelda("numero_serie", registrar.NumeroSerie);
                insertarEquipoComputo.AgregarCelda("fecha_alta", DateTime.Now);
                insertarEquipoComputo.AgregarCelda("periodo_mantenimiento", 0);
                insertarEquipoComputo.AgregarCelda("razon_social", registrar.RazonSocial);
                EquipoComputo.Modelo().Insertar(insertarEquipoComputo);
                CargarAccesorios();
            }
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmRegistrarEquipoComputo editar = new FrmRegistrarEquipoComputo("ACCESORIO", IdAccesorio);
            if (editar.ShowDialog() == DialogResult.OK)
            {
                EquipoComputo modificar = new EquipoComputo();
                modificar.CargarDatos(IdAccesorio);

                if (!modificar.TieneFilas())
                    return;
               
                modificar.Fila().ModificarCelda("clase", "ACCESORIO");
                modificar.Fila().ModificarCelda("descripcion", editar.Descripcion);
                modificar.Fila().ModificarCelda("accesorio_tipo", editar.AccesorioTipo);
                modificar.Fila().ModificarCelda("marca", editar.Marca);
                modificar.Fila().ModificarCelda("modelo", editar.Modelo);
                modificar.Fila().ModificarCelda("periodo_mantenimiento", 0);
                modificar.Fila().ModificarCelda("razon_social", editar.RazonSocial);
                modificar.GuardarDatos();
                CargarAccesorios();
            }
        }

        private void DgvMonitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            IdMonitor = Convert.ToInt32(DgvMonitor.SelectedRows[0].Cells["id_monitor"].Value);

            if ((string)DgvMonitor.SelectedRows[0].Cells["asignado_monitor"].Value != "SIN ASIGNAR")
            {
                liberarToolStripMenuItem2.Visible = true;
                asignarToolStripMenuItem1.Visible = false;
            }
            else
            {
                liberarToolStripMenuItem2.Visible = false;
                asignarToolStripMenuItem1.Visible = true;
            }
        }

        private void DgvMonitor_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (IdMonitor != 0)
                    {
                        editarToolStripMenuItem1.Enabled = true;
                        borrarToolStripMenuItem1.Enabled = true;
                        asignarToolStripMenuItem1.Enabled = true;
                        liberarToolStripMenuItem2.Enabled = true;
                    }
                    else
                    {
                        editarToolStripMenuItem1.Enabled = false;
                        borrarToolStripMenuItem1.Enabled = false;
                        asignarToolStripMenuItem1.Visible = false;
                        liberarToolStripMenuItem2.Visible = false;
                    }
                    MenuMonitor.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvMonitor_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvMonitor.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    editarToolStripMenuItem1.Enabled = false;
                    borrarToolStripMenuItem1.Enabled = false;
                    asignarToolStripMenuItem1.Visible = false;
                    liberarToolStripMenuItem2.Visible = false;

                    MenuMonitor.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvAccesorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            IdAccesorio = Convert.ToInt32(DgvAccesorios.SelectedRows[0].Cells["id_accesorio"].Value);

            if ((string)DgvAccesorios.SelectedRows[0].Cells["asignado_usuario_accesorio"].Value != "SIN ASIGNAR")
            {
                liberarToolStripMenuItem3.Visible = true;
                asignarToolStripMenuItem2.Visible = false;
            }
            else
            {
                liberarToolStripMenuItem3.Visible = false;
                asignarToolStripMenuItem2.Visible = true;
            }
        }

        private void DgvAccesorios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (IdAccesorio != 0)
                    {
                        editarToolStripMenuItem2.Enabled = true;
                        borrarToolStripMenuItem2.Enabled = true;
                        asignarToolStripMenuItem2.Enabled = true;
                        liberarToolStripMenuItem3.Enabled = true;
                    }
                    else
                    {
                        editarToolStripMenuItem2.Enabled = false;
                        borrarToolStripMenuItem2.Enabled = false;
                        asignarToolStripMenuItem2.Visible = false;
                        liberarToolStripMenuItem3.Visible = false;
                    }

                    MenuAccesorios.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvAccesorios_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvAccesorios.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    editarToolStripMenuItem2.Enabled = false;
                    borrarToolStripMenuItem2.Enabled = false;
                    asignarToolStripMenuItem2.Visible = false;
                    liberarToolStripMenuItem3.Visible = false;

                    MenuAccesorios.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void borrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EquipoComputo borrarEquipo = new EquipoComputo();

            DialogResult result = MessageBox.Show("Las información de las computadoras que son borradas no puede ser recuperada en el futuro. ¿Desea continuar?", "Borrar computadora", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvAccesorios.SelectedRows)
                {
                    int idAccesorio = Convert.ToInt32(row.Cells[0].Value.ToString());
                    borrarEquipo.CargarDatos(idAccesorio);
                    borrarEquipo.BorrarDatos(idAccesorio);
                    borrarEquipo.GuardarDatos();
                }

                CargarAccesorios();
            }
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if(usuario.ShowDialog() == DialogResult.OK)
            {
                EquipoComputoUsuario liberarComputadora = new EquipoComputoUsuario();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("equipo", IdEquipo);

                liberarComputadora.SeleccionarDatos("equipo=@equipo", parametros);
                if (liberarComputadora.TieneFilas())
                {
                    int idUsuario = Convert.ToInt32(liberarComputadora.Fila().Celda("id").ToString());
                    liberarComputadora.BorrarDatos(idUsuario);
                    liberarComputadora.GuardarDatos();
                    CargarComputadora();
                }

                string usuarioAsignado = usuario.UsuarioSeleccionado.Fila().Celda("id").ToString();
                Fila insertarUsuario = new Fila();
                insertarUsuario.AgregarCelda("usuario", usuarioAsignado);
                insertarUsuario.AgregarCelda("equipo", IdEquipo);
                insertarUsuario.AgregarCelda("fecha_asignacion", DateTime.Now);
                EquipoComputoUsuario.Modelo().Insertar(insertarUsuario);
                MessageBox.Show("Usuario asignado correctamente", "Usuario asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarComputadora();
            }
        }

        private void asignarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if (usuario.ShowDialog() == DialogResult.OK)
            {
                EquipoComputoUsuario liberarMonitor = new EquipoComputoUsuario();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("equipo", IdEquipo);

                liberarMonitor.SeleccionarDatos("equipo=@equipo", parametros);
                if (liberarMonitor.TieneFilas())
                {
                    int idUsuario = Convert.ToInt32(liberarMonitor.Fila().Celda("id").ToString());
                    liberarMonitor.BorrarDatos(idUsuario);
                    liberarMonitor.GuardarDatos();
                    CargarComputadora();
                }

                string usuarioAsignado = usuario.UsuarioSeleccionado.Fila().Celda("id").ToString();               
                Fila insertarUsuario = new Fila();
                insertarUsuario.AgregarCelda("usuario", usuarioAsignado);
                insertarUsuario.AgregarCelda("equipo", IdMonitor);
                insertarUsuario.AgregarCelda("fecha_asignacion", DateTime.Now);
                EquipoComputoUsuario.Modelo().Insertar(insertarUsuario);
                MessageBox.Show("Usuario asignado correctamente", "Usuario asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMonitores();
            }
        }

        private void asignarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario usuario = new FrmSeleccionarUsuario();
            if (usuario.ShowDialog() == DialogResult.OK)
            {
                EquipoComputoUsuario liberarAccesorio = new EquipoComputoUsuario();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("equipo", IdEquipo);

                liberarAccesorio.SeleccionarDatos("equipo=@equipo", parametros);
                if (liberarAccesorio.TieneFilas())
                {
                    int idUsuario = Convert.ToInt32(liberarAccesorio.Fila().Celda("id").ToString());
                    liberarAccesorio.BorrarDatos(idUsuario);
                    liberarAccesorio.GuardarDatos();
                    CargarComputadora();
                }

                string usuarioAsignado = usuario.UsuarioSeleccionado.Fila().Celda("id").ToString();              
                Fila insertarUsuario = new Fila();
                insertarUsuario.AgregarCelda("usuario", usuarioAsignado);
                insertarUsuario.AgregarCelda("equipo", IdAccesorio);
                insertarUsuario.AgregarCelda("fecha_asignacion", DateTime.Now);
                EquipoComputoUsuario.Modelo().Insertar(insertarUsuario);
                MessageBox.Show("Usuario asignado correctamente", "Usuario asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAccesorios();
            }
        }

        private void liberarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Al liberar la computadora la información del usuario asignado se perderá y no podrá ser recuperada en el futuro, ¿Desea liberar la computadora?", "Equipo liberado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)

            {
                EquipoComputoUsuario liberarComputadora = new EquipoComputoUsuario();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("equipo", IdEquipo);

                liberarComputadora.SeleccionarDatos("equipo=@equipo",parametros);
                int idUsuario = Convert.ToInt32(liberarComputadora.Fila().Celda("id").ToString());
                liberarComputadora.BorrarDatos(idUsuario);
                liberarComputadora.GuardarDatos();
                CargarComputadora();
            }           
        }

        private void liberarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Al liberar el monitor, la información del usuario asignado se perderá y no podrá ser recuperada en el futuro, ¿Desea liberar el monitor?", "Equipo liberado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                EquipoComputoUsuario liberarComputadora = new EquipoComputoUsuario();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("equipo", IdMonitor);

                liberarComputadora.SeleccionarDatos("equipo=@equipo", parametros);
                int idUsuario = Convert.ToInt32(liberarComputadora.Fila().Celda("id").ToString());
                liberarComputadora.BorrarDatos(idUsuario);
                liberarComputadora.GuardarDatos();
                CargarMonitores();
            } 
        }

        private void liberarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Al liberarlo, la información del usuario asignado se perderá y no podrá ser recuperada en el futuro, ¿Desea liberar la información?", "Equipo liberado", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                EquipoComputoUsuario liberarComputadora = new EquipoComputoUsuario();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("equipo", IdAccesorio);

                liberarComputadora.SeleccionarDatos("equipo=@equipo", parametros);
                int idUsuario = Convert.ToInt32(liberarComputadora.Fila().Celda("id").ToString());
                liberarComputadora.BorrarDatos(idUsuario);
                liberarComputadora.GuardarDatos();
                CargarAccesorios();
            }
        }

        private void CmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TabElementos.SelectedIndex)
            {
                case 0:
                    CargarComputadora();
                    break;
                case 1:
                    CargarMonitores();
                    break;
                case 2:
                    CargarAccesorios();
                    break;
                default:
                    break;
            }
            
        }

        private void BtnMantenimiento_Click(object sender, EventArgs e)
        {
            FrmPlanMantenimientoEquipoComputo mantenimiento = new FrmPlanMantenimientoEquipoComputo();
            mantenimiento.Show();
        }

        private void BtnMantenimientoCorrectivo_Click(object sender, EventArgs e)
        {
            List<Fila> CargarModeloEquipoComputo = new List<Fila>();

            OrdenTrabajoMantenimiento ordenTrabajo = new OrdenTrabajoMantenimiento();
            ordenTrabajo.CargarOrdenMantenimiento().ForEach(delegate(Fila f)
            {
                EquipoComputo equipoCOmputo = new EquipoComputo();
                equipoCOmputo.CargarDatos(Convert.ToInt32(f.Celda("equipo")));

                if (equipoCOmputo.TieneFilas())
                {
                    if (f.Celda("tipo_equipo").ToString() == "EQUIPO DE COMPUTO")
                    {
                        Fila equipoDeComputo = new Fila();
                        equipoDeComputo.AgregarCelda("id", Global.ObjetoATexto(f.Celda("id"), "0").PadLeft(4, '0'));
                        equipoDeComputo.AgregarCelda("equipoId", Global.ObjetoATexto(equipoCOmputo.Fila().Celda("id"), "0"));
                        equipoDeComputo.AgregarCelda("numero_serie", Global.ObjetoATexto(equipoCOmputo.Fila().Celda("numero_serie"), "0"));
                        equipoDeComputo.AgregarCelda("solicitado_por", Global.ObjetoATexto(f.Celda("solicitado_por"), "0"));
                        equipoDeComputo.AgregarCelda("fecha_registro", Convert.ToDateTime(f.Celda("fecha_registro").ToString()));
                        equipoDeComputo.AgregarCelda("estatus", Global.ObjetoATexto(f.Celda("estatus"), ""));
                        CargarModeloEquipoComputo.Add(equipoDeComputo);
                    }
                }
            });
            FrmSeleccionOrdenTrabajo orden = new FrmSeleccionOrdenTrabajo("EQUIPO DE COMPUTO", CargarModeloEquipoComputo);
            orden.Show();
        }
    }
}
