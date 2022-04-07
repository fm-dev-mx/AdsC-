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
    public partial class FrmRegistrarEquipoComputo : Ventana
    {
        int IdEquipo = 0;
        string ClaseTab = string.Empty;
        public string Categoria = string.Empty;
        public string TipoEquipo = string.Empty;
        public string Marca = string.Empty;
        public string Modelo = string.Empty;
        public string NumeroSerie = string.Empty;
        public string Pulgadas = string.Empty;
        public string Descripcion = string.Empty;
        public string EquipoNombre = string.Empty;
        public string EquipoContrasena = string.Empty;
        public string EquipoUsuario = string.Empty;
        public string EquipoMac = string.Empty;
        public string SOMarca = string.Empty;
        public string SOVersion = string.Empty;
        public string SOTipo = string.Empty;
        public string Hdd = string.Empty;
        public string HddDescripcion = string.Empty;
        public string Ssd = string.Empty;
        public string SsdDescripcion = string.Empty;
        public string ProcesadorMarca = string.Empty;
        public string ProcesadorDescripcion = string.Empty;
        public string TarjetaGraficaMarca = string.Empty;
        public string TarjetaGraficaDescripcion = string.Empty;
        public string RamCaracteristicas = string.Empty;
        public string AccesorioTipo = string.Empty;
        public string RazonSocial = string.Empty;
        public int PeriodoMantenimiento = 0;
        
        public FrmRegistrarEquipoComputo(string categoria, int idEquipo = 0)
        {
            InitializeComponent();
            IdEquipo = idEquipo;
            ClaseTab = categoria;
            CmbRazonSocial.SelectedIndex = 0;
        }

        private void FrmRegistrar_Load(object sender, EventArgs e)
        {
            ControlesHabilitarDeshabilitar(ClaseTab);
            CargarAutocompleteControles();

            if(IdEquipo != 0)
            {
                //Editar existente
                LblTitulo.Text = "Editar existente";
                CargarEquipo();
                BtnGuardar.Text = "    Modificar";
            }
        }

        private void CargarEquipo()
        {
            EquipoComputo equipo = new EquipoComputo();
            equipo.CargarDatos(IdEquipo).ForEach(delegate(Fila f)
            {
                string categoria = f.Celda("clase").ToString();
                CmbGeneralMarca.Text = f.Celda("marca").ToString();
                CmbGeneralModelo.Text = f.Celda("modelo").ToString();
                TxtGeneralSN.Text = f.Celda("numero_serie").ToString();
                TxtDescripcion.Text = f.Celda("descripcion").ToString();
                if (Global.ObjetoATexto(f.Celda("razon_social"), "") != "")
                    CmbRazonSocial.Text = f.Celda("razon_social").ToString();
                else
                    CmbRazonSocial.SelectedIndex = 0;

                object objPeriodo = f.Celda("periodo_mantenimiento");
                if (objPeriodo != null)
                {
                    if(Convert.ToInt32(Global.ObjetoATexto(objPeriodo, "0")) > 0)
                        NumericPeriodo.Value = Convert.ToInt32(objPeriodo);
                    else
                        NumericPeriodo.Value = 6;
                }
                else
                    NumericPeriodo.Value = 6;

                switch (categoria)
                {
                    case "DESKTOP":
                    case "LAPTOP":

                        TxtSistemaNombre.Text = f.Celda("equipo_nombre").ToString();
                        TxtSistemaUsuario.Text = f.Celda("equipo_usuario").ToString();
                        TxtContrasena.Text = f.Celda("equipo_contrasena").ToString();
                        TxtSistemaMac.Text = f.Celda("direccion_mac").ToString();
                        CmbSOMarca.Text = f.Celda("sistema_operativo_marca").ToString();
                        CmbSOVersion.Text = f.Celda("sistema_operativo_version").ToString();
                        CmbSOTipo.Text = f.Celda("sistema_operativo_tipo").ToString();
                        int hdd = Convert.ToInt32(f.Celda("almacenamiento_hdd").ToString());
                        int ssd = Convert.ToInt32(f.Celda("almacenamiento_ssd").ToString());
                        if(hdd > 0)
                        {
                            ChkBHDD.Checked = true;
                            TxtHddDescripcion.Text = f.Celda("almacenamiento_hdd_descripcion").ToString();
                        }

                        if(ssd > 0)
                        {
                            ChkBSSD.Checked = true;
                            TxtSddDescripcion.Text = f.Celda("almacenamiento_ssd_descripcion").ToString();
                        }

                        CmbProcesadorMarca.Text = f.Celda("procesador_marca").ToString();
                        TxtProcesadorDecripcion.Text = f.Celda("procesador_descripcion").ToString();
                        TxtTarjetaGraficaDescripcion.Text = f.Celda("tarjeta_grafica_descripcion").ToString();
                        CmbTarjetaGraficaMarca.Text = f.Celda("tarjeta_grafica_marca").ToString();
                        TxtRamCaracteristicas.Text = f.Celda("ram_caracteristicas").ToString();
                        break;

                    case "MONITOR":                      
                        CmbPulgadas.Text = f.Celda("monitor_pulgadas").ToString();
                        break;

                    case "ACCESORIO":
                        CmbAccesorioTipo.Text = f.Celda("accesorio_tipo").ToString();
                        break;

                    default:
                        break;
                }
            });
        }

        private void LimpiarDatos()
        {
            CmbGeneralMarca.Text = "";
            CmbGeneralModelo.Text = "";
            TxtGeneralSN.Text = "";
            TxtSistemaNombre.Text = "";
            TxtSistemaUsuario.Text = "";
            TxtContrasena.Text = "";
            TxtSistemaMac.Text = "";
            CmbSOMarca.Text = "";
            CmbSOVersion.Text = "";
            CmbSOTipo.Text = "";
            TxtHddDescripcion.Text = "";
            TxtSddDescripcion.Text = "";
            CmbProcesadorMarca.Text = "";
            TxtProcesadorDecripcion.Text = "";
            CmbTarjetaGraficaMarca.Text = "";
            TxtTarjetaGraficaDescripcion.Text = "";
            TxtRamCaracteristicas.Text = "";
            CmbAccesorioTipo.Text = "";
            TxtDescripcion.Text = "";
        }

        private void ControlesHabilitarDeshabilitar(string categoriaTab)
        {
            switch (categoriaTab)
            {
                case "COMPUTADORA":
                    LblCategoria.Visible = false;
                    CmbAccesorioTipo.Visible = false;
                    LblPulgadas.Visible = false;
                    CmbPulgadas.Visible = false;
                    CmbRazonSocial.Location = new Point(135, 253);
                    LblRazonSocial.Location = new Point(18, 253);
                    GpBGeneral.Size = new Size(839, 298);
                    break;
                case "MONITOR":
                    LblPeriodo.Visible = false;
                    NumericPeriodo.Visible = false;
                    lblMses.Visible = false;
                    RBtnLaptop.Visible = false;
                    RBtnPc.Visible = false;
                    LblCategoria.Visible = false;
                    CmbAccesorioTipo.Visible = false;
                    GpBGeneral.Dock = DockStyle.Fill;
                    GpBSistema.Visible = false;                    
                    GpBSO.Visible = false;
                    GpBAlmacenamiento.Visible = false;
                    GpBProcesador.Visible = false;
                    GpBTarjetaGrafica.Visible = false;
                    GpBRam.Visible = false;
                    CmbRazonSocial.Visible = true;
                    CmbRazonSocial.Location = new Point(135, 287);
                    LblRazonSocial.Location = new Point(19, 287);
                    break;
                case "ACCESORIO":
                    LblPeriodo.Visible = false;
                    NumericPeriodo.Visible = false;
                    lblMses.Visible = false;
                    RBtnLaptop.Visible = false;
                    RBtnPc.Visible = false;
                    LblPulgadas.Visible = false;
                    CmbPulgadas.Visible = false;
                    LblCategoria.Location = new Point(18, 253);
                    CmbAccesorioTipo.Location = new Point(133, 253);
                    GpBGeneral.Dock = DockStyle.Fill;
                    GpBSistema.Visible = false;
                    GpBSO.Visible = false;
                    GpBAlmacenamiento.Visible = false;
                    GpBProcesador.Visible = false;
                    GpBTarjetaGrafica.Visible = false;
                    GpBRam.Visible = false;
                    CmbRazonSocial.Visible = true;
                    CmbRazonSocial.Location = new Point(135, 287);
                    LblRazonSocial.Location = new Point(19, 287);
                    break;
                default:
                    break;
            }
        }

        private void AutocompletarCmb(ComboBox comboBox, List<object> listaBusqueda)
        {
            List<Equipos> equipo = new List<Equipos>();

            foreach (object item in listaBusqueda)
            {
                if (item != null)
                    equipo.Add(new Equipos { Equipo = item.ToString() });
            }

            comboBox.DataSource = equipo;
            comboBox.DisplayMember = "Equipo";
            comboBox.SelectedIndex = -1;

            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void CargarAutocompleteControles()
        {
            List<Fila> listaEquipoComputo = new List<Fila>();

            List<object> busqueda = new List<object>();

            //GeneralMarca
            listaEquipoComputo = EquipoComputo.Modelo().SeleccionarDatos("", null, "*");

            if (ClaseTab == "COMPUTADORA")
            {
                busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "LAPTOP" || x.Celda("clase").ToString() == "DESKTOP").Select(x => x.Celda("marca")).Distinct().ToList();
                AutocompletarCmb(CmbGeneralMarca, busqueda);

                //Modelo
                busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "LAPTOP" || x.Celda("clase").ToString() == "DESKTOP").Select(x => x.Celda("modelo")).Distinct().ToList();
                AutocompletarCmb(CmbGeneralModelo, busqueda);
            }
            else if(ClaseTab == "MONITOR")
            {
                busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "MONITOR").Select(x => x.Celda("marca")).Distinct().ToList();
                AutocompletarCmb(CmbGeneralMarca, busqueda);

                //Modelo
                busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "MONITOR").Select(x => x.Celda("modelo")).Distinct().ToList();
                AutocompletarCmb(CmbGeneralModelo, busqueda);
            }
            else if (ClaseTab == "ACCESORIO")
            {
                busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "ACCESORIO").Select(x => x.Celda("marca")).Distinct().ToList();
                AutocompletarCmb(CmbGeneralMarca, busqueda);

                //Modelo
                busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "ACCESORIO").Select(x => x.Celda("modelo")).Distinct().ToList();
                AutocompletarCmb(CmbGeneralModelo, busqueda);
            }

            //Sistema operativo
            busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "LAPTOP" || x.Celda("clase").ToString() == "DESKTOP").Select(x => x.Celda("sistema_operativo_marca")).Distinct().ToList();
            AutocompletarCmb(CmbSOMarca, busqueda);

            //Sistema operativo
            busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "LAPTOP" || x.Celda("clase").ToString() == "DESKTOP").Select(x => x.Celda("sistema_operativo_version")).Distinct().ToList();
            AutocompletarCmb(CmbSOVersion, busqueda);

            //Sistema operativo
            busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "LAPTOP" || x.Celda("clase").ToString() == "DESKTOP").Select(x => x.Celda("sistema_operativo_tipo")).Distinct().ToList();
            AutocompletarCmb(CmbSOTipo, busqueda);

            //Sistema operativo
            busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "LAPTOP" || x.Celda("clase").ToString() == "DESKTOP").Select(x => x.Celda("procesador_marca")).Distinct().ToList();
            AutocompletarCmb(CmbProcesadorMarca, busqueda);

            //Sistema operativo
            busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "LAPTOP" || x.Celda("clase").ToString() == "DESKTOP").Select(x => x.Celda("tarjeta_grafica_marca")).Distinct().ToList();
            AutocompletarCmb(CmbTarjetaGraficaMarca, busqueda);

            //Monitor pulgadas
            busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "MONITOR").Select(x => x.Celda("monitor_pulgadas")).Distinct().ToList();
            AutocompletarCmb(CmbPulgadas, busqueda);

            //accesorio tipo
            busqueda = listaEquipoComputo.FindAll(x => x.Celda("clase").ToString().ToUpper() == "ACCESORIO").Select(x => x.Celda("accesorio_tipo")).Distinct().ToList();
            AutocompletarCmb(CmbAccesorioTipo, busqueda);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (RBtnLaptop.Checked)
                TipoEquipo = "LAPTOP";
            else
                TipoEquipo = "DESKTOP";

            Marca = CmbGeneralMarca.Text;
            Modelo = CmbGeneralModelo.Text;
            NumeroSerie = TxtGeneralSN.Text;
            Pulgadas = CmbPulgadas.Text;
            Descripcion = TxtDescripcion.Text;
            EquipoNombre = TxtSistemaNombre.Text;
            EquipoContrasena = TxtContrasena.Text;
            EquipoUsuario = TxtSistemaUsuario.Text;
            EquipoMac = TxtSistemaMac.Text;
            SOMarca = CmbSOMarca.Text;
            SOVersion = CmbSOVersion.Text;
            SOTipo = CmbSOTipo.Text;
            ProcesadorMarca = CmbProcesadorMarca.Text;
            ProcesadorDescripcion = TxtProcesadorDecripcion.Text;
            TarjetaGraficaMarca = CmbTarjetaGraficaMarca.Text;
            TarjetaGraficaDescripcion = TxtTarjetaGraficaDescripcion.Text;
            RamCaracteristicas = TxtRamCaracteristicas.Text;
            AccesorioTipo = CmbAccesorioTipo.Text;
            PeriodoMantenimiento = Convert.ToInt32(NumericPeriodo.Value);
            RazonSocial = CmbRazonSocial.Text;

            if (ChkBHDD.Checked)
            {
                Hdd = "1";
                HddDescripcion = TxtHddDescripcion.Text;
            }
            else
                Hdd = "0";

            if (ChkBSSD.Checked)
            {
                Ssd = "1";
                SsdDescripcion = TxtSddDescripcion.Text;
            }
            else
                Ssd = "0";

            if(Descripcion == "" || Marca == "" || Modelo == "" || NumeroSerie == "" )
            {
                MessageBox.Show("Favor de llenar todos los campos", "Información imconpleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (ClaseTab)
            {
                case "COMPUTADORA":
                    if (SOMarca == "" || SOVersion == "" || SOTipo == "" || ProcesadorMarca == "" || ProcesadorDescripcion == "" || TarjetaGraficaDescripcion == "" || RamCaracteristicas == "" || (!ChkBHDD.Checked && !ChkBSSD.Checked) || (TxtSddDescripcion.Text == "" && TxtHddDescripcion.Text == ""))
                    {
                        MessageBox.Show("Favor de llenar todos los campos", "Información imconpleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
                case "MONITOR":
                    if(Pulgadas == "")
                    {
                        MessageBox.Show("Favor de llenar todos los campos", "Información imconpleta", MessageBoxButtons.OK, MessageBoxIcon.Information);                      
                        return;
                    }
                    TipoEquipo = ClaseTab;
                    break;
                case "ACCESORIO":
                    if (AccesorioTipo == "")
                    {
                        MessageBox.Show("Favor de llenar todos los campos", "Información imconpleta", MessageBoxButtons.OK, MessageBoxIcon.Information);                      
                        return;
                    }
                    TipoEquipo = ClaseTab;
                    break;
                default:
                    break;
            }

            DialogResult = DialogResult.OK;
            MessageBox.Show("El equipo ha sido dado de alta correctamente", "Información guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CmbGeneralMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void CmbGeneralModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void CmbPulgadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtGeneralSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtSistemaNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtSistemaUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtSistemaMac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void CmbSOMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void CmbSOVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void CmbSOTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtHddDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void TxtSddDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void CmbProcesadorMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void CmbTarjetaGraficaMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void accesorioTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }
    }

    public class Equipos
    {
        public string Equipo { get; set; }
    }
}
