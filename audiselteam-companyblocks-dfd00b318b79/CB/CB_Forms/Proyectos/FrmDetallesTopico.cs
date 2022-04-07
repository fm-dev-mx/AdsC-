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
    public partial class FrmDetallesTopico : Ventana
    {
        int IdTopico = 0;
        int IdTarea = 0;
        int IdSeguimiento = 0;
        int IdJuntaSeleccionada = 0;
        decimal IdProyecto = 0;
        string Descripcion = string.Empty;
        string EstatusTiempo = string.Empty;
        bool RecargarSeguimiento = false;
        bool CargarInformacion = true;
        bool MostrarOpcionRevisados = true; 

        List<Fila> CargarTopicos = new List<Fila>();        
        TareasTopico CargarTarea = new TareasTopico();
        TareasResponsables CargarResponsable = new TareasResponsables();
        TareaInvolucrados CargarInvolucrados = new TareaInvolucrados();
        TareasSeguimiento CargarSeguimiento = new TareasSeguimiento();
        JuntaInvitado BorrarInvitado = new JuntaInvitado();

        public FrmDetallesTopico(int idTopico, decimal idProyecto)
        {
            InitializeComponent();
            IdTopico = idTopico;
            IdProyecto = idProyecto;
        }

        private void FrmDetallesTopico_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabJuntas);
            CargarTopicos = CargarDatosTopico(IdTopico);
            CargarTopicoInformacion();
            LblEstatusTiempo.Text = "";
            CargarTreeView();           
            splitContainer2.Panel2.Hide();
            ocultarRevisadosToolStripMenuItem.Visible = !MostrarOpcionRevisados;
        }

        private void CargarTopicoInformacion()
        {
            CargarTopicos.ForEach(delegate(Fila topico)
            {
                CmbEstatus.SelectedIndex = 0;

                object notas = topico.Celda("notas");
                if (notas != null)
                    TxtNotas.Text = topico.Celda("notas").ToString();
                else
                    TxtNotas.Text = string.Empty;

                Descripcion = TxtNotas.Text;
                LblFecha.Text = Convert.ToDateTime(topico.Celda("fecha_creacion")).ToString("MMM dd, yyyy hh:mm:ss tt");
                LblCreadoPor.Text = topico.Celda("usuario_creacion").ToString();
                LblEstatus.Text = topico.Celda("estatus").ToString();
                LblTitulo.Text = topico.Celda("descripcion").ToString();
                LblEstatus.Refresh();
                if (topico.Celda("estatus").ToString() == "TERMINADO")
                {
                    HabilitarContenido(false);
                    BtnTerminarJunta.Enabled = false;
                    TxtNotas.ReadOnly = true;
                }
                else
                {
                    BtnTerminarJunta.Enabled = true;
                    TxtNotas.ReadOnly = false;
                    HabilitarContenido(true);
                }

            });
        }

        public TreeNode CrearNodoTarea(Fila filaTarea)
        {
            TreeNode nodoTarea = new TreeNode();

            int idTarea = Convert.ToInt32(filaTarea.Celda("id"));
            string estatus = filaTarea.Celda("estatus").ToString();
            string estatusTiempo = filaTarea.Celda("estatus_tiempo").ToString();
            string prioridad = filaTarea.Celda("prioridad").ToString();

            nodoTarea.Name = filaTarea.Celda("id").ToString() + " - " + filaTarea.Celda("nombre") + "-" + filaTarea.Celda("prioridad").ToString();
            nodoTarea.Text = filaTarea.Celda("id").ToString() + " - " + filaTarea.Celda("nombre") + " | " + filaTarea.Celda("estatus").ToString();

            //agregar imagen del color según el estatus
            switch (estatus)
            {
                case "PENDIENTE":
                    if (estatusTiempo == "PENDIENTE A TIEMPO")
                    {
                        nodoTarea.ImageIndex = 6;
                        nodoTarea.SelectedImageIndex = 6;
                    }
                    else if (estatusTiempo == "PENDIENTE LIMITE")
                    {
                        nodoTarea.ImageIndex = 7;
                        nodoTarea.SelectedImageIndex = 7;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "PENDIENTE TARDE")
                    {
                        nodoTarea.ImageIndex = 8;
                        nodoTarea.SelectedImageIndex = 8;
                    }
                    break;
                case "TERMINADO":
                    if (estatusTiempo == "TERMINADO A TIEMPO")
                    {
                        nodoTarea.ImageIndex = 9;
                        nodoTarea.SelectedImageIndex = 9;
                    }
                    else if (estatusTiempo == "TERMINADO LIMITE")
                    {
                        nodoTarea.ImageIndex = 10;
                        nodoTarea.SelectedImageIndex = 10;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "TERMINADO TARDE")
                    {
                        nodoTarea.ImageIndex = 11;
                        nodoTarea.SelectedImageIndex = 11;
                    }
                    break;
                case "EN PROCESO":
                    if (estatusTiempo == "EN PROCESO A TIEMPO")
                    {
                        nodoTarea.ImageIndex = 3;
                        nodoTarea.SelectedImageIndex = 3;
                    }
                    else if (estatusTiempo == "EN PROCESO LIMITE")
                    {
                        nodoTarea.ImageIndex = 4;
                        nodoTarea.SelectedImageIndex = 4;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "EN PROCESO TARDE")
                    {
                        nodoTarea.ImageIndex = 5;
                        nodoTarea.SelectedImageIndex = 5;
                    }
                    break;
                case "DETENIDO":
                    if (estatusTiempo == "DETENIDO A TIEMPO")
                    {
                        nodoTarea.ImageIndex = 0;
                        nodoTarea.SelectedImageIndex = 0;
                    }
                    else if (estatusTiempo == "DETENIDO LIMITE")
                    {
                        nodoTarea.ImageIndex = 1;
                        nodoTarea.SelectedImageIndex = 1;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "DETENIDO TARDE")
                    {
                        nodoTarea.ImageIndex = 2;
                        nodoTarea.SelectedImageIndex = 2;
                    }
                    break;
                case "DESCARTADO":
                    nodoTarea.ImageIndex = 12;
                    nodoTarea.SelectedImageIndex = 12;
                    break;
                case "REVISADO":
                    nodoTarea.ImageIndex = 13;
                    nodoTarea.SelectedImageIndex = 13;
                    break;
                default:
                    break;
            }

            if (prioridad == "URGENTE")
                nodoTarea.ForeColor = Color.Red;

            List<Fila> cargarTareas = CargarDatosTareas(idTarea, mostrarRevisadosToolStripMenuItem.Checked);

            //Cargamos los nodos con las subtareas
            cargarTareas.ForEach(delegate(Fila subTarea)
            {
                CargarSubTarea(nodoTarea, subTarea);
            });

            nodoTarea.ExpandAll();
            return nodoTarea;
        }

        public void CargarSubTarea(TreeNode nodoPadre, Fila filaTarea)
        {
            int idSubtarea = Convert.ToInt32(filaTarea.Celda("id"));
            string nombre = idSubtarea + " - " + filaTarea.Celda("nombre").ToString() + " " + filaTarea.Celda("estatus");
            string estatus = filaTarea.Celda("estatus").ToString();
            string estatusTiempo = filaTarea.Celda("estatus_tiempo").ToString();
            string prioridad = filaTarea.Celda("prioridad").ToString();

            TreeNode nodoSubTarea = Global.CrearNodo
            (
                idSubtarea + "-" + filaTarea.Celda("nombre").ToString() + "-" + filaTarea.Celda("estatus") + "-" + filaTarea.Celda("prioridad"),
                idSubtarea + " - " + filaTarea.Celda("nombre").ToString() + " | " + filaTarea.Celda("estatus")
            );

            if(prioridad == "URGENTE")
                nodoSubTarea.ForeColor = Color.Red;

            if (nodoPadre.Nodes.ContainsKey(nombre))
            {
                nodoPadre.Nodes.Add(nodoSubTarea);
            }
            else
                nodoPadre.Nodes.Add(nodoSubTarea);

            

            //agregar imagen del color según el estatus
            switch (estatus)
            {
                case "PENDIENTE":
                    ActualizarImagenNodos(estatusTiempo, estatus, nodoSubTarea);   
                    break;
                case "TERMINADO":
                    ActualizarImagenNodos(estatusTiempo, estatus, nodoSubTarea);
                    break;
                case "EN PROCESO":
                    ActualizarImagenNodos(estatusTiempo, estatus, nodoSubTarea);
                    break;
                case "DETENIDO":
                    ActualizarImagenNodos(estatusTiempo, estatus, nodoSubTarea);
                    break;
                case "DESCARTADO":
                    nodoSubTarea.ImageIndex = 12;
                    nodoSubTarea.SelectedImageIndex = 12;
                    break;
                case "REVISADO":
                    nodoSubTarea.ImageIndex = 13;
                    nodoSubTarea.SelectedImageIndex = 13;
                    break;
                default:
                    break;
            }
        }

        public void CargarFormatoTopicos()
        {
            CargarInformacion = true;
            string nombreNodo = "";
           
            if(TvTareas.SelectedNode.Parent != null) //nodo hijo
                nombreNodo = TvTareas.SelectedNode.Parent.Text + " | "  + TvTareas.SelectedNode.Text.ToString();
            else //nodo padre
                nombreNodo = TvTareas.SelectedNode.Text.ToString();

            LblTarea.Text = nombreNodo.ToUpper();

            if (nombreNodo == "")
                return;

            splitContainer2.Panel2.Show();

            int idNodoTarea = Convert.ToInt32(TvTareas.SelectedNode.Text.Split('-')[0].Trim());
            CargarTarea.CargarDatos(idNodoTarea);

            if (CargarTarea.TieneFilas())
            {
                object descripcion = CargarTarea.Fila().Celda("descripcion");
                object fecha = CargarTarea.Fila().Celda("fecha_promesa");
                object estatus = CargarTarea.Fila().Celda("estatus");
                object estatusTiempo = CargarTarea.Fila().Celda("estatus_tiempo");
                object notas = CargarTarea.Fila().Celda("notas");
                object prioridad = CargarTarea.Fila().Celda("prioridad");
                object horas = CargarTarea.Fila().Celda("horas");

                if (LblEstatus.Text != "TERMINADO")
                {
                    if (estatus.ToString() == "REVISADO")
                    {
                        HabilitarContenido(false);
                    }
                    else if (estatus.ToString() == "TERMINADO")
                    {
                        HabilitarContenido(false);
                        CmbEstatus.Items.Clear();
                        CmbEstatus.Items.Add("REVISADO");
                        CmbEstatus.Enabled = Global.PrivilegioPorRol("LIDER DE PROYECTO");
                    }
                    else
                    {
                        HabilitarContenido(true);
                    }
                }
                else
                {
                    HabilitarContenido(false);
                }


                if (descripcion != null)
                    TxtDescripcion_tarea.Text = CargarTarea.Fila().Celda("descripcion").ToString();

                if (prioridad != null)
                    CmbPrioridad.Text = prioridad.ToString();

                if (estatus != null)
                    CmbEstatus.Text = estatus.ToString();

                if(fecha != null)
                    DtpFechaPromesa.Value = Convert.ToDateTime(fecha);

                string strHoras = string.Empty;

                switch (horas)
                {
                    case 0.25:
                        strHoras = "15 minutos";
                        break;
                    case 0.5:
                        strHoras = "30 minutos";
                        break;
                    case 0.75:
                        strHoras = "45 minutos";
                        break;
                    case 1.0:
                        strHoras = "1:00 hora ";
                        break;
                    case 1.25:
                        strHoras = "1:15 horas";
                        break;
                    case 1.5:
                        strHoras = "1.30 horas";
                        break;
                    case 1.75:
                        strHoras = "1.45 horas";
                        break;
                    case 2.0:
                        strHoras = "2:00 horas";
                        break;
                    case 2.25:
                        strHoras = "2:15 horas";
                        break;
                    case 2.5:
                        strHoras = "2.30 horas";
                        break;
                    case 2.75:
                        strHoras = "2.45 horas";
                        break;
                    case 3.0:
                        strHoras = "3:00 horas";
                        break;
                    case 3.25:
                        strHoras = "3.15 horas";
                        break;
                    case 3.5:
                        strHoras = "3.30 horas";
                        break;
                    case 3.75:
                        strHoras = "3.45 horas";
                        break;
                    case 4.0:
                        strHoras = "4:00 horas";
                        break;
                    case 4.25:
                        strHoras = "4:15 horas";
                        break;
                    case 4.5:
                        strHoras = "4:30 horas";
                        break;
                    case 4.75:
                        strHoras = "4.45 horas";
                        break;
                    case 5.0:
                        strHoras = "5:00 horas";
                        break;
                    case 5.25:
                        strHoras = "5:15 horas";
                        break;
                    case 5.5:
                        strHoras = "5:30 horas";
                        break;
                    case 5.75:
                        strHoras = "5:45 horas";
                        break;
                    case 6.0:
                        strHoras = "6:00 horas";
                        break;
                    case 6.25:
                        strHoras = "6:15 horas";
                        break;
                    case 6.5:
                        strHoras = "6:30 horas";
                        break;
                    case 6.75:
                        strHoras = "6:45 horas";
                        break;
                    case 7.0:
                        strHoras = "7:00 horas";
                        break;
                    case 7.25:
                        strHoras = "7:15 horas";
                        break;
                    case 7.5:
                        strHoras = "7:30 horas";
                        break;
                    case 7.75:
                        strHoras = "7:45 horas";
                        break;
                    case 8.0:
                        strHoras = "8:00 horas";
                        break;
                    default:
                        break;
                }

                if (horas != null)
                     CmbHoras.Text = strHoras;//NumHoras.Value = Convert.ToDecimal(horas);


                if (estatusTiempo != null)
                {
                    if(estatusTiempo.ToString().EndsWith("TIEMPO"))
                    {
                        LblEstatusTiempo.Text = "A " + estatusTiempo.ToString().Split(' ').Last();
                        LblEstatusTiempo.BackColor = Color.LightGreen;
                    }
                    if (estatusTiempo.ToString().EndsWith("LIMITE"))
                    {
                        LblEstatusTiempo.Text = estatusTiempo.ToString().Split(' ').Last();
                        LblEstatusTiempo.BackColor = Color.Yellow;
                    }
                    if (estatusTiempo.ToString().EndsWith("TARDE"))
                    {
                        LblEstatusTiempo.Text = estatusTiempo.ToString().Split(' ').Last();
                        LblEstatusTiempo.BackColor = Color.Red;
                    }
                }
            }

            CargarDgvResponsable(CargarDatosResponsable(IdTarea));
            CargarDgvSeguimiento(CargarDatosdSeguimiento(IdTarea));
            CargarDgvInvolucrados(CargarDatosInvolucrado(IdTarea));
            CargarInformacion = false;
        }


        private void HabilitarContenido(bool habilitar)
        {
            TxtDescripcion_tarea.ReadOnly = !habilitar;
            CmbPrioridad.Enabled = habilitar; 
            DtpFechaPromesa.Enabled = habilitar;
            DgvResponsable.Enabled = habilitar;
            DgvInvolucrados.Enabled = habilitar;
            CmbEstatus.Enabled = habilitar;
            NumHoras.Enabled = habilitar;
            CmbHoras.Enabled = habilitar;
        }

        public string CalcularEstatusTiempo(DateTime fecha)
        {
            if (Convert.ToDateTime(fecha).Date > DateTime.Now.Date)
                return "A TIEMPO";
            else if (Convert.ToDateTime(fecha).Date == DateTime.Now.Date)
                return "LIMITE";
            else
                return "TARDE";
        }

        public void ActualizarImagenNodos(string estatusTiempo, string estatus, TreeNode nodoSeleccionado)
        {
            switch (estatus)
            {
                case "DETENIDO":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "DETENIDO A TIEMPO")
                    {
                        nodoSeleccionado.ImageIndex = 0;
                        nodoSeleccionado.SelectedImageIndex = 0;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.LightGreen;
                    }
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "DETENIDO LIMITE")
                    {
                        nodoSeleccionado.ImageIndex = 1;
                        nodoSeleccionado.SelectedImageIndex = 1;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.Yellow;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "DETENIDO TARDE")
                    {
                        nodoSeleccionado.ImageIndex = 2;
                        nodoSeleccionado.SelectedImageIndex = 2;

                        LblEstatusTiempo.Text = "TARDE";
                        LblEstatusTiempo.BackColor = Color.Red;
                    }
                    break;
                case "EN PROCESO":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "EN PROCESO A TIEMPO")
                    {
                        nodoSeleccionado.ImageIndex = 3;
                        nodoSeleccionado.SelectedImageIndex = 3;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.LightGreen;
                    }
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "EN PROCESO LIMITE")
                    {
                        nodoSeleccionado.ImageIndex = 4;
                        nodoSeleccionado.SelectedImageIndex = 4;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.Yellow;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "EN PROCESO TARDE")
                    {
                        nodoSeleccionado.ImageIndex = 5;
                        nodoSeleccionado.SelectedImageIndex = 5;

                        LblEstatusTiempo.Text = "TARDE";
                        LblEstatusTiempo.BackColor = Color.Red;
                    }
                    break;

                case "PENDIENTE":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "PENDIENTE A TIEMPO")
                    {
                        nodoSeleccionado.ImageIndex = 6;
                        nodoSeleccionado.SelectedImageIndex = 6;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.LightGreen;
                    }
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "PENDIENTE LIMITE")
                    {
                        nodoSeleccionado.ImageIndex = 7;
                        nodoSeleccionado.SelectedImageIndex = 7;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.Yellow;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "PENDIENTE TARDE")
                    {
                        nodoSeleccionado.ImageIndex = 8;
                        nodoSeleccionado.SelectedImageIndex = 8;

                        LblEstatusTiempo.Text = "TARDE";
                        LblEstatusTiempo.BackColor = Color.Red;
                    }
                    break;
                case "TERMINADO":
                    if (estatusTiempo == "A TIEMPO" || estatusTiempo == "TERMINADO A TIEMPO")
                    {
                        nodoSeleccionado.ImageIndex = 9;
                        nodoSeleccionado.SelectedImageIndex = 9;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.LightGreen;
                    }
                    else if (estatusTiempo == "LIMITE" || estatusTiempo == "TERMINADO LIMITE")
                    {
                        nodoSeleccionado.ImageIndex = 10;
                        nodoSeleccionado.SelectedImageIndex = 10;

                        LblEstatusTiempo.Text = "A TIEMPO";
                        LblEstatusTiempo.BackColor = Color.Yellow;
                    }
                    else if (estatusTiempo == "TARDE" || estatusTiempo == "TERMINADO TARDE")
                    {
                        nodoSeleccionado.ImageIndex = 11;
                        nodoSeleccionado.SelectedImageIndex = 11;

                        LblEstatusTiempo.Text = "TARDE";
                        LblEstatusTiempo.BackColor = Color.Red;
                    }
                    break;

                case "DESCARTADO":
                    nodoSeleccionado.ImageIndex = 12;
                    nodoSeleccionado.SelectedImageIndex = 12;
                    break;
                case "REVISADO":
                    nodoSeleccionado.ImageIndex = 13;
                    nodoSeleccionado.SelectedImageIndex = 13;
                    break;
                default:
                    break;
            }
        }

        public void CargarTreeView() 
        {
            TvTareas.Nodes.Clear();

            //Cargamos el Tree View con la información de las tareas
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@topico", IdTopico);
            parametros.Add("@proyecto", IdProyecto);
            parametros.Add("@principal", 0);
            string agregarRevisados = string.Empty;
            if (mostrarRevisadosToolStripMenuItem.Checked)
                agregarRevisados = "topico in (SELECT id FROM topicos WHERE proyecto=@proyecto) AND tarea_principal=@principal";
            else
                agregarRevisados = "topico in (SELECT id FROM topicos WHERE proyecto=@proyecto) AND tarea_principal=@principal and estatus not in ('REVISADO')";

            List<Fila> CargarTreeView = CargarTarea.SeleccionarDatos(agregarRevisados, parametros); //Topico=@topico
            CargarTreeView.ForEach(delegate(Fila f)
            {
                TreeNode nodoTarea = CrearNodoTarea(f);
                if (nodoTarea != null)
                {
                    int indiceNodo = TvTareas.Nodes.IndexOfKey(nodoTarea.Name);

                    if (indiceNodo >= 0)
                    {
                        TvTareas.Nodes.RemoveAt(indiceNodo);
                        TvTareas.Nodes.Insert(indiceNodo, nodoTarea);
                    }
                    else
                    {
                        TvTareas.Nodes.Add(nodoTarea);
                    }
                }
            });
        }

        public void LimpiarCampos()
        {
            DtpFechaPromesa.Value = DateTime.Now;
            CmbEstatus.Text = string.Empty;
            LblEstatusTiempo.Text = string.Empty;
            LblEstatusTiempo.BackColor = Color.Transparent;
            TxtDescripcion_tarea.Text = string.Empty;
            DgvResponsable.Rows.Clear();
            DgvSeguimiento.Rows.Clear();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void nuevaTareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaTarea nuevaTarea = new FrmNuevaTarea("NUEVA TAREA");
            if(nuevaTarea.ShowDialog() == DialogResult.OK)
            {
                string rol = Global.UsuarioActual.Fila().Celda("rol").ToString();
                Fila insertarTarea = new Fila();
                insertarTarea.AgregarCelda("topico", IdTopico);
                insertarTarea.AgregarCelda("nombre", nuevaTarea.Nuevo);
                insertarTarea.AgregarCelda("fecha_promesa", DateTime.Now);
                insertarTarea.AgregarCelda("tarea_principal", 0);
                insertarTarea.AgregarCelda("estatus", "PENDIENTE");
                insertarTarea.AgregarCelda("estatus_tiempo", "PENDIENTE LIMITE");
                int idTarea = Convert.ToInt32( TareasTopico.Modelo().Insertar(insertarTarea).Celda("id").ToString());

                //Cada vez que se agrega una nueva tarea se crea el seguimiento
                Fila insertarSeguimiento = new Fila();
                insertarSeguimiento.AgregarCelda("tarea", idTarea);
                insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
                insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
                insertarSeguimiento.AgregarCelda("comentario", "NUEVA TAREA CREADA: " + nuevaTarea.Nuevo);
                TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);

                //si no es lider de proyecto sera responsable de forma automatica
                if(rol != "LIDER DE PROYECTO")
                {
                    Fila insertarResponsable = new Fila();
                    insertarResponsable.AgregarCelda("tarea", idTarea);
                    insertarResponsable.AgregarCelda("responsable", Global.UsuarioActual.NombreCompleto());
                    insertarResponsable.AgregarCelda("id_responsable", Global.UsuarioActual.Fila().Celda("id"));
                    TareasResponsables.Modelo().Insertar(insertarResponsable);
                }

                CargarTreeView();
                TvTareas.SelectedNode = TvTareas.Nodes.Find(idTarea + " - " + nuevaTarea.Nuevo + "-" + "REGULAR" , true)[0];
                TvTareas_NodeMouseDoubleClick(this, null);
            }
        }

        private void nuevaSubtareaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreNodo = TvTareas.SelectedNode.Name.ToString();

            if (nombreNodo == "")
                return;

            FrmNuevaTarea nuevaTarea = new FrmNuevaTarea("NUEVA SUBTAREA");
            if (nuevaTarea.ShowDialog() == DialogResult.OK)
            {
                Fila insertarSubtarea = new Fila();
                insertarSubtarea.AgregarCelda("topico", IdTopico);
                insertarSubtarea.AgregarCelda("nombre", nuevaTarea.Nuevo);
                insertarSubtarea.AgregarCelda("tarea_principal", nombreNodo.Split('-')[0].Trim());
                insertarSubtarea.AgregarCelda("fecha_promesa", DateTime.Now);
                insertarSubtarea.AgregarCelda("estatus", "PENDIENTE");
                insertarSubtarea.AgregarCelda("estatus_tiempo", "PENDIENTE LIMITE");
                int idTarea = Convert.ToInt32(TareasTopico.Modelo().Insertar(insertarSubtarea).Celda("id"));

                //Cada vez que se agrega una nueva sub tarea se crea el seguimiento
                Fila insertarSeguimiento = new Fila();
                insertarSeguimiento.AgregarCelda("tarea", idTarea);
                insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
                insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
                insertarSeguimiento.AgregarCelda("comentario", "NUEVA TAREA CREADA: " + nuevaTarea.Nuevo);
                TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);
                
                CargarTreeView();
                TvTareas.SelectedNode = TvTareas.Nodes.Find(idTarea + "-" + nuevaTarea.Nuevo + "-" + "PENDIENTE" + "-" + "REGULAR", true)[0];
                TvTareas_NodeMouseDoubleClick(this, null);
            }
        }

        private void TvTareas_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode tvNodo = TvTareas.GetNodeAt(e.X,e.Y);

            if (tvNodo == null)
            {//agregar nuevo nodo
                if (e.Button == MouseButtons.Right)
                {
                    nuevaSubtareaToolStripMenuItem.Visible = false;
                    nuevaTareaToolStripMenuItem.Visible = true;
                    if(LblEstatus.Text != "TERMINADO")
                        MenuOpciones.Show(TvTareas, e.Location);
                }
            }
            else
            {//nodos
                if (e.Button == MouseButtons.Right)
                {
                    if (TvTareas.SelectedNode.Parent == null) // nodo padre
                    {
                        nuevaTareaToolStripMenuItem.Visible = false;
                        nuevaSubtareaToolStripMenuItem.Visible = true;
                        editarToolStripMenuItem.Visible = true;
                        eliminarToolStripMenuItem.Visible = true;
                        if (LblEstatus.Text != "TERMINADO")
                            MenuOpciones.Show(TvTareas, e.Location);
                    }
                    else  if(TvTareas.SelectedNode.Parent != null) //nodo hijo
                    {
                        editarToolStripMenuItem.Visible = true;
                        eliminarToolStripMenuItem.Visible = true;
                        nuevaTareaToolStripMenuItem.Visible = false;
                        nuevaSubtareaToolStripMenuItem.Visible = false;
                        if (LblEstatus.Text != "TERMINADO")
                            MenuOpciones.Show(TvTareas, e.Location);
                    }
                }

                string nombreNodo = TvTareas.GetNodeAt(e.X, e.Y).Text;

                nuevaSubtareaToolStripMenuItem.Visible = !nombreNodo.EndsWith(" REVISADO");
                nuevaTareaToolStripMenuItem.Visible = !nombreNodo.EndsWith(" REVISADO");
                editarToolStripMenuItem1.Visible = !nombreNodo.EndsWith(" REVISADO");
                eliminarToolStripMenuItem1.Visible = !nombreNodo.EndsWith(" REVISADO");
                planificarTiempoExtraToolStripMenuItem.Visible = !nombreNodo.EndsWith(" REVISADO");
            }
        }

        private void TvTareas_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (TvTareas.SelectedNode.Text == "")
                return;

            string nombreNodo = TvTareas.SelectedNode.Text.ToString();
            IdTarea = Convert.ToInt32(nombreNodo.Split('-')[0].Trim());

            LimpiarCampos();
            CargarFormatoTopicos();
        }

        private void DtpFechaPromesa_CloseUp(object sender, EventArgs e)
        {
            TreeNode nodoSeleccionado = TvTareas.SelectedNode;
            CargarTarea.CargarDatos(IdTarea);
            CargarTarea.Fila().ModificarCelda("fecha_promesa", Convert.ToDateTime(DtpFechaPromesa.Value));          
            CargarTarea.GuardarDatos();

            //Cada vez que se modifica la fecha promesa se guarda en la tabla de segumiento
            Fila insertarSeguimiento = new Fila();
            insertarSeguimiento.AgregarCelda("tarea", IdTarea);
            insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
            insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
            insertarSeguimiento.AgregarCelda("comentario", "LA FECHA PROMESA FUE EDITADA, LA NUEVA FECHA ES " + Convert.ToDateTime(DtpFechaPromesa.Value).ToString("MMM dd, yyyy hh:mm:ss tt").ToString().ToUpper());
            TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);
            
            //Refrescamos el DgvSeguimiento
            CargarDgvSeguimiento(CargarDatosdSeguimiento(IdTarea));
            string estatusTiempo = CalcularEstatusTiempo(Convert.ToDateTime(DtpFechaPromesa.Value));

            //Cambiamos iconos de acuerdo al estatus y el estatus tiempo
            switch (CmbEstatus.Text)
            {
                case "PENDIENTE":
                    ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                    ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                    break;
                case "TERMINADO":
                    ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                    ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                    break;
                case "EN PROCESO":
                    ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                    ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                    break;
                case "DETENIDO":
                    ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                    ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                    break;
                case "REVISADO":
                    ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                    ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                    break;
                case "DESCARTADO":

                    break;
                default:
                    break;
            }
            CargarTarea.GuardarDatos();
            CargarFormatoTopicos();
        }

        private void CmbEstatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<string> listaResponsables = new List<string>();
            foreach (DataGridViewRow row in DgvResponsable.Rows)
            {
                listaResponsables.Add(row.Cells["responsable"].Value.ToString());
            }

            string estatusTarea = CmbEstatus.Text;
            string nombreResponsable = listaResponsables.FirstOrDefault(s => s.Contains(Global.UsuarioActual.NombreCompleto()));
            string rol = Global.UsuarioActual.Fila().Celda("rol").ToString();

            if (rol != "LIDER DE PROYECTO")
            {
                if (nombreResponsable == null)
                {
                    MessageBox.Show("Solamente los responsables pueden cambiar el estatus de la tarea");
                    return;
                }
            }

            //CHECAR QUE TENGA a un responsable
            if (estatusTarea == "REVISADO")
            {
                if (DgvResponsable.Rows.Count <= 0)
                {
                    MessageBox.Show("Debe seleccionar a un responsable", "Seleccione responsable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string estatusAnterior = TvTareas.SelectedNode.Text.Split('|')[1].Trim();
                    CmbEstatus.Text = estatusAnterior;
                    return;
                }
            }

            Topico topico = new Topico();
            TareasTopico tareas = new TareasTopico();

            TreeNode nodoSeleccionado = TvTareas.SelectedNode;

            tareas.CargarDatos(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()));
            if (tareas.TieneFilas())
            {
                string estatusTiempo = CalcularEstatusTiempo(Convert.ToDateTime(DtpFechaPromesa.Value));//tareas.Fila().Celda("estatus_tiempo").ToString();

                //Modificamos el color del nodo dependiendo de CmbEstatus
                switch (CmbEstatus.Text)
                {
                    case "PENDIENTE":                     

                        //actualizamos la información y creamos un nuevo seguimiento
                        ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text);
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), null, "fecha_tarea_terminada");
                        InsertarSeguimiento(IdTarea, "ESTATUS ACTUAL MODIFICADO:  " + CmbEstatus.Text.ToUpper());
                        break;

                    case "TERMINADO":

                        //actualizamos la información y creamos un nuevo seguimiento
                        ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), "TERMINADO");
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), DateTime.Now, "fecha_tarea_terminada");
                        InsertarSeguimiento(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), "ESTATUS ACTUALIZADO: TERMINADO");
                        break;

                    case "EN PROCESO":
   
                        int idTareaParentEnProceso = Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim());

                        //actualizar y crear nuevo segumiento
                        ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                        ModificarTareasTopico(idTareaParentEnProceso, CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");        
                        ModificarTareasTopico(idTareaParentEnProceso, CmbEstatus.Text);
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), null, "fecha_tarea_terminada");
                        InsertarSeguimiento(idTareaParentEnProceso, "ESTATUS ACTUALIZADO: EN PROCESO");

                        break;
                    case "DETENIDO":

                        ActualizarImagenNodos(estatusTiempo, CmbEstatus.Text, nodoSeleccionado);
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text + " " + estatusTiempo, "estatus_tiempo");
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0]), CmbEstatus.Text);
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), null, "fecha_tarea_terminada");
                        InsertarSeguimiento(IdTarea, "ESTATUS ACTUAL MODIFICADO A:  " + CmbEstatus.Text.ToUpper());

                        break;
                    case "DESCARTADO":
                        nodoSeleccionado.ImageIndex = 12;
                        nodoSeleccionado.SelectedImageIndex = 12;

                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text);
                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), null, "fecha_tarea_terminada");
                        InsertarSeguimiento(IdTarea, "ESTATUS ACTUAL MODIFICADO A:  " + CmbEstatus.Text.ToUpper());
                        break;
                    case "REVISADO":
                        nodoSeleccionado.ImageIndex = 13;
                        nodoSeleccionado.SelectedImageIndex = 13;

                        ModificarTareasTopico(Convert.ToInt32(nodoSeleccionado.Text.Split('-')[0].Trim()), CmbEstatus.Text);
                        InsertarSeguimiento(IdTarea, "ESTATUS ACTUAL MODIFICADO A:  " + CmbEstatus.Text.ToUpper());
                        break;
                    default:
                        break;
                }

                //renombrar nombre de nodo
                string[] nodoNombre = nodoSeleccionado.Text.Split('|');
                nodoSeleccionado.Text = nodoNombre[0] + " | " + CmbEstatus.Text;

                CargarFormatoTopicos();
            }
        }

        public void InsertarSeguimiento(int idTarea, string comentario)
        {
            TareasSeguimiento tareaSeguimiento = new TareasSeguimiento();
            Fila insertarSeguimiento = new Fila();
            insertarSeguimiento.AgregarCelda("tarea", idTarea);
            insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
            insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
            insertarSeguimiento.AgregarCelda("comentario", comentario);
            tareaSeguimiento.Insertar(insertarSeguimiento);

            Accion acciones = new Accion();
            acciones.SeleccionarTarea(idTarea);
            if(acciones.TieneFilas())
            {
                acciones.Fila().ModificarCelda("notificacion", "0");
                acciones.GuardarDatos();
            }
        }

        public void ModificarTareasTopico(int idTarea, object columnaValor, string columna="estatus")
        {
            TareasTopico tareaTopico = new TareasTopico();
            tareaTopico.CargarDatos(idTarea);
            tareaTopico.Fila().ModificarCelda(columna, columnaValor);
            tareaTopico.GuardarDatos();

            Accion acciones = new Accion();
            acciones.SeleccionarTarea(idTarea);
            if (acciones.TieneFilas())
            {
                acciones.Fila().ModificarCelda("notificacion", "0");
                acciones.GuardarDatos();
            }
        }


        private void TxtDescripcion_tarea_Validating(object sender, CancelEventArgs e)
        {
            CargarTarea.CargarDatos(IdTarea);
            object descripcion = CargarTarea.Fila().Celda("descripcion");

            //si la descripción es diferente a la cargada anteriormente y es distinto a nada agregamos
            //el contenido de la descripción
            if (TxtDescripcion_tarea.Text == "" || (string)descripcion == TxtDescripcion_tarea.Text)
                return;

            CargarTarea.Fila().ModificarCelda("descripcion", TxtDescripcion_tarea.Text);
            CargarTarea.GuardarDatos();

            //actualizamos las notificaciones al cliente
            Accion acciones = new Accion();
            acciones.SeleccionarTarea(IdTarea);
            if (acciones.TieneFilas())
            {
                acciones.Fila().ModificarCelda("notificacion", "0");
                acciones.GuardarDatos();
            }

            //Mostramos un tooltip para informar al usuario de los cambios guardados
            Tool.Show("Su información ha sido guardada de forma automática", TxtDescripcion_tarea, 2200);
        }

        public List<Fila> CargarDatosdSeguimiento(int idTarea)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tarea", idTarea);
            return CargarSeguimiento.SeleccionarDatos("tarea=@tarea", parametros);
        }

        public List<Fila> CargarDatosTopico(int idTarea)
        {
            Topico cargarTopico = new Topico();
            return cargarTopico.CargarDatos(IdTopico);
        }

        public List<Fila> CargarDatosTareas(int idTarea, bool mostrarRevisados)
        {
            TareasTopico cargarTarea = new TareasTopico();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tareaPrincipal", idTarea);
            string revisados = string.Empty;

            if (mostrarRevisados)
                revisados = "tarea_principal=@tareaPrincipal";
            else
                revisados = "tarea_principal=@tareaPrincipal and estatus not in ('REVISADO')";

            return cargarTarea.SeleccionarDatos(revisados, parametros);
        }

        public List<Fila> CargarDatosResponsable(int idTarea)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tarea", idTarea);
            return CargarResponsable.SeleccionarDatos("tarea=@tarea", parametros);
        }

        public List<Fila> CargarDatosInvolucrado(int idTarea)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@tarea", idTarea);
            return CargarInvolucrados.SeleccionarDatos("tarea=@tarea", parametros);
        }

        public void CargarDgvSeguimiento(List<Fila> DatosSeguimiento)
        {
            Application.DoEvents();
            RecargarSeguimiento = false;
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvSeguimiento);
            
            DgvSeguimiento.Rows.Clear();
            int rowIndex = 0;
            DatosSeguimiento.ForEach(delegate(Fila f)
            {               
                DgvSeguimiento.Rows.Add(f.Celda("id").ToString(), Convert.ToDateTime(f.Celda("fecha")).ToString("MMM dd, yyyy hh:mm:ss tt"), f.Celda("usuario").ToString(), f.Celda("comentario").ToString(), f.Celda("editable").ToString());
                DgvSeguimiento.Rows[rowIndex].ReadOnly = true;
                rowIndex++;
            });

            ConfiguracionDataGridView.Recuperar(cfg, DgvSeguimiento);
        }

        public void CargarDgvResponsable(List<Fila> listaResponsables)
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvResponsable);
            DgvResponsable.Rows.Clear();
            foreach (Fila responsable in listaResponsables)
                DgvResponsable.Rows.Add(responsable.Celda("id").ToString(), responsable.Celda("responsable").ToString(), responsable.Celda("correo_alterno"));

            ConfiguracionDataGridView.Recuperar(cfg, DgvResponsable);
        }

        public void CargarDgvInvolucrados(List<Fila> listaInvolucrados)
        {
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvInvolucrados);
            DgvInvolucrados.Rows.Clear();
            foreach (Fila invol in listaInvolucrados)
                DgvInvolucrados.Rows.Add(invol.Celda("id").ToString(), invol.Celda("nombre_usuario").ToString(), invol.Celda("correo_alterno"));

            ConfiguracionDataGridView.Recuperar(cfg, DgvInvolucrados);
        }

        private void DgvResponsable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    borrarToolStripMenuItem.Enabled = true;
                    MenuResponsable.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvResponsable_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvResponsable.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    borrarToolStripMenuItem.Enabled = false;
                    MenuResponsable.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario responsable = new FrmSeleccionarUsuario("", true);
            if(responsable.ShowDialog() == DialogResult.OK)
            {
                foreach (var usuario in responsable.UsuariosSeleccionados)
                {
                    string resp = usuario.NombreCompleto();
                    int idResp = Convert.ToInt32(usuario.Fila().Celda("id"));
                    Dictionary<string,object> parametros = new Dictionary<string,object>();
                    parametros.Add("@idTarea", IdTarea);
                    parametros.Add("@responsable", resp);
                    CargarResponsable.SeleccionarDatos("tarea=@idTarea and responsable=@responsable", parametros);
                    if(!CargarResponsable.TieneFilas())
                    {
                        Fila insertarResponsable = new Fila();
                        insertarResponsable.AgregarCelda("tarea", IdTarea);
                        insertarResponsable.AgregarCelda("responsable", resp);
                        insertarResponsable.AgregarCelda("id_responsable", idResp);
                        CargarResponsable.Insertar(insertarResponsable);
                    }

                }
                CargarDgvResponsable(CargarDatosResponsable(IdTarea));
                CargarDgvInvolucrados(CargarDatosInvolucrado(IdTarea));
            }
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los datos que son borrados no podrán ser recuperados en el futuro. ¿Desea continuar?", "Borrar responsables", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvResponsable.SelectedRows)
                {
                    int idResponsable = Convert.ToInt32(row.Cells["id"].Value.ToString());
                    CargarResponsable.BorrarDatos(idResponsable);
                    CargarResponsable.GuardarDatos();
                }
                CargarDgvResponsable(CargarDatosResponsable(IdTarea));
                CargarDgvInvolucrados(CargarDatosInvolucrado(IdTarea));
            }
        }

        private void DgvSeguimiento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object idSeguimiento = DgvSeguimiento.Rows[e.RowIndex].Cells["id_seguimiento"].Value;

            //si contiene un id diferente a null significa que va a editar el comentario
            if (idSeguimiento != null)
            {
                TareasSeguimiento seguimiento = new TareasSeguimiento();
                seguimiento.CargarDatos(Convert.ToInt32(idSeguimiento));
                seguimiento.Fila().ModificarCelda("comentario", DgvSeguimiento.Rows[e.RowIndex].Cells["comentarios"].Value.ToString().ToUpper());
                seguimiento.Fila().ModificarCelda("fecha", DateTime.Now);               
                seguimiento.Fila().ModificarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString().ToUpper());
                seguimiento.GuardarDatos();

                Accion acciones = new Accion();
                acciones.SeleccionarTarea(IdTarea);
                if (acciones.TieneFilas())
                {
                    acciones.Fila().ModificarCelda("notificacion", "0");
                    acciones.GuardarDatos();
                }
                return;
            }

            try
            {
                //de lo contrario significa que el usuario va a agregar un nuevo comentario
                object comentario = DgvSeguimiento.Rows[e.RowIndex].Cells["comentarios"].Value;
                if (comentario != null)
                {
                    DgvSeguimiento.Rows[e.RowIndex].Cells["fecha"].Value = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
                    DgvSeguimiento.Rows[e.RowIndex].Cells["usuario"].Value = Global.UsuarioActual.NombreCompleto();

                    Fila insertarSeguimiento = new Fila();
                    insertarSeguimiento.AgregarCelda("tarea", IdTarea);
                    insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
                    insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
                    insertarSeguimiento.AgregarCelda("comentario", DgvSeguimiento.Rows[e.RowIndex].Cells["comentarios"].Value.ToString().ToUpper());
                    insertarSeguimiento.AgregarCelda("editable", "1");
                    TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);                    
                    DgvSeguimiento.Rows[e.RowIndex].ReadOnly = true;

                    Accion acciones = new Accion();
                    acciones.SeleccionarTarea(IdTarea);
                    if (acciones.TieneFilas())
                    {
                        acciones.Fila().ModificarCelda("notificacion", "0");
                        acciones.GuardarDatos();
                    }
                }
                RecargarSeguimiento = true;
            } 
            catch { /*evitar cualquier excepcion del DGV */}
        }

        private void DgvSeguimiento_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Convertimos a upper case lo que el usuario haya tecleado dentro de la celda
            if (DgvSeguimiento.CurrentCell.ColumnIndex == 0 || DgvSeguimiento.CurrentCell.ColumnIndex == 3)
            {
                if (e.Control is TextBox)
                    ((TextBox)(e.Control)).CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void TvTareas_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void FrmDetallesTopico_FormClosing(object sender, FormClosingEventArgs e)
        {
            Topico topico = new Topico();
            topico.CargarDatos(IdTopico);
            topico.Fila().ModificarCelda("notas", TxtNotas.Text);
            topico.GuardarDatos();

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public void CargarJuntas(int idTopico)
        {
            JuntaEvento juntaEvento = new JuntaEvento();
            JuntaInvitado juntaInvitado = new JuntaInvitado();
            ConfiguracionDataGridView cfg = ConfiguracionDataGridView.Guardar(DgvJunta);

            DgvJunta.Rows.Clear();
            Dictionary<string,object> parametros = new Dictionary<string,object>();
            parametros.Add("@idTopicos", idTopico);
            juntaEvento.SeleccionarDatos("topico=@idTopicos",parametros).ForEach(delegate(Fila evento)
            {
                string invitados = string.Empty;
                juntaInvitado.SeleccionaInvitado(Convert.ToInt32(evento.Celda("id"))).ForEach(delegate(Fila invitado)
                {
                    invitados += invitado.Celda("nombre").ToString() + " " + invitado.Celda("paterno").ToString() + " " + invitado.Celda("materno").ToString() + Environment.NewLine;
                });
                DgvJunta.Rows.Add(evento.Celda("id").ToString(), evento.Celda("nombre").ToString(), evento.Celda("descripcion").ToString(), Convert.ToDateTime(evento.Celda("fecha")).ToString("MMM dd, yyyy hh:mm:ss tt"), invitados, evento.Celda("tipo").ToString());
            });
            ConfiguracionDataGridView.Recuperar(cfg, DgvJunta);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    CargarJuntas(IdTopico);
                    break;
                default:
                    break;
            }
        }

        private void DgvJunta_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                    MenuJuntas.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JuntaEvento juntaEventos = new JuntaEvento();
            JuntaInvitado invitado = new JuntaInvitado();
            List<int> usuarioId = new List<int>();

            DialogResult borrar = MessageBox.Show("Los datos que son borrados no podrán ser recuperados en el futuro. ¿Desea continuar?", "Borrar responsables", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (borrar == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvJunta.SelectedRows)
                {
                    int idJunta = Convert.ToInt32(row.Cells["id_DgvJunta"].Value.ToString());
                    juntaEventos.CargarDatos(idJunta);
                    juntaEventos.BorrarDatos(idJunta);
                    juntaEventos.GuardarDatos();

                    
                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@evento", idJunta);

                    invitado.SeleccionarDatos("evento=@evento", parametros).ForEach(delegate(Fila f)
                    {
                      // usuarioId.Add(Convert.ToInt32(f.Celda("id")));       
                        BorrarInvitado.CargarDatos(Convert.ToInt32(f.Celda("id")));
                        BorrarInvitado.BorrarDatos(Convert.ToInt32(f.Celda("id")));
                        BorrarInvitado.GuardarDatos();
                    });                    
                }
                CargarJuntas(IdTopico);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdJuntaSeleccionada == 0)
                return;

            List<string> tipoJunta = new List<string>();
            List<string> idUsuario = new List<string>();
            List<string> nombreUsuario = new List<string>();

            string descripcion = string.Empty;
            string nombreJunta = string.Empty;

            tipoJunta.Add("ADMINISTRATIVA");
            tipoJunta.Add("TECNICA");

            //obtenemos el id y el nombre de los invitados para enviarlos en una lista al form
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@evento", IdJuntaSeleccionada);

            JuntaInvitado.Modelo().SeleccionarDatos("evento=@evento", parametros).ForEach(delegate(Fila f)
            {
                Usuario.Modelo().CargarDatos(Convert.ToInt32(f.Celda("usuario"))).ForEach(delegate(Fila usuario)
                {
                    if (!nombreUsuario.Contains(usuario.Celda("nombre").ToString() + " " + usuario.Celda("paterno").ToString() + " " + usuario.Celda("materno").ToString()))
                    {
                        idUsuario.Add(usuario.Celda("id").ToString());
                        nombreUsuario.Add(usuario.Celda("nombre").ToString() + " " + usuario.Celda("paterno").ToString() + " " + usuario.Celda("materno").ToString());
                    }
                });
            });

            nombreUsuario = nombreUsuario.Distinct().ToList();
            idUsuario = idUsuario.Distinct().ToList();

            JuntaEvento.Modelo().CargarDatos(IdJuntaSeleccionada).ForEach(delegate(Fila f)
            {
                descripcion = f.Celda("descripcion").ToString();
                nombreJunta = f.Celda("nombre").ToString();
            });

            FrmNuevaJunta nuevaJunta = new FrmNuevaJunta(tipoJunta, descripcion, "EDITAR JUNTA", nombreJunta, IdTopico, idUsuario, nombreUsuario, true);
             if (nuevaJunta.ShowDialog() == DialogResult.OK)
             {
                 JuntaEvento junta = new JuntaEvento();
                 junta.CargarDatos(IdJuntaSeleccionada);
                 junta.Fila().ModificarCelda("nombre", nuevaJunta.Nombre);
                 junta.Fila().ModificarCelda("descripcion", nuevaJunta.Descripcion);
                 junta.Fila().ModificarCelda("fecha", DateTime.Parse(nuevaJunta.FechaJunta));
                 junta.Fila().ModificarCelda("tipo", nuevaJunta.TipoDeJunta);
                 junta.GuardarDatos();

                 Dictionary<string, object> parametrosBorrar = new Dictionary<string,object>();
                 parametrosBorrar.Add("@evento", IdJuntaSeleccionada);

                 //borramos los usuarios invitados correspondientes con la junta seleccionada
                 JuntaInvitado borrarInvitado = new JuntaInvitado();
                 List<Fila> borrar = borrarInvitado.SeleccionarDatos("evento=@evento", parametrosBorrar);
                
                 for (int i = 0; i < borrar.Count; i++)
                 {
                     int idBorrar = Convert.ToInt32(borrar[i].Celda("id"));
                     borrarInvitado.CargarDatos(idBorrar);
                     borrarInvitado.BorrarDatos(idBorrar);
                     borrarInvitado.GuardarDatos();
                 }

                 //guardamos los nuevos invitados
                 foreach (string usuario in nuevaJunta.Invitados)
                 {
                     Fila insertarInvitados = new Fila();
                     insertarInvitados.AgregarCelda("evento", IdJuntaSeleccionada);
                     insertarInvitados.AgregarCelda("usuario", usuario);
                     JuntaInvitado.Modelo().Insertar(insertarInvitados);
                 }
                 CargarJuntas(IdTopico);
             }
        }

        private void DgvJunta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            editarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem.Enabled = true;
            IdJuntaSeleccionada = Convert.ToInt32(DgvJunta.SelectedRows[0].Cells["id_DgvJunta"].Value);
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> tipoJunta = new List<string>();
            tipoJunta.Add("JUNTA TECNICA");
            tipoJunta.Add("JUNTA DE PLANEACION");

            FrmNuevaJunta nuevaJunta = new FrmNuevaJunta(tipoJunta, Descripcion, "NUEVA EVENTO", "", IdTopico, null, null);
            if (nuevaJunta.ShowDialog() == DialogResult.OK)
            {
                Fila InsertarJunta = new Fila();
                InsertarJunta.AgregarCelda("nombre", nuevaJunta.Nombre);
                InsertarJunta.AgregarCelda("descripcion", nuevaJunta.Descripcion);
                InsertarJunta.AgregarCelda("fecha", DateTime.Parse(nuevaJunta.FechaJunta));
                InsertarJunta.AgregarCelda("topico", nuevaJunta.IdTopico);
                InsertarJunta.AgregarCelda("tipo", nuevaJunta.TipoDeJunta);
                int idEvento = Convert.ToInt32(JuntaEvento.Modelo().Insertar(InsertarJunta).Celda("id"));

                foreach (string idUsuario in nuevaJunta.Invitados)
                {
                    Fila insertarInvitados = new Fila();
                    insertarInvitados.AgregarCelda("evento", idEvento);
                    insertarInvitados.AgregarCelda("usuario", idUsuario);
                    JuntaInvitado.Modelo().Insertar(insertarInvitados);
                }
                CargarJuntas(IdTopico);
            }
        }

        private void DgvJunta_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht = DgvJunta.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    editarToolStripMenuItem.Enabled = false;
                    eliminarToolStripMenuItem.Enabled = false;

                    MenuJuntas.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string nombre = string.Empty;
            string nodoSeleccionado = TvTareas.SelectedNode.Text;
            string editarTitulo = string.Empty;

            if (nodoSeleccionado == null || nodoSeleccionado == "")
                return;

            CargarTarea.CargarDatos(Convert.ToInt32(nodoSeleccionado.Split('-')[0].Trim()));
            if(CargarTarea.TieneFilas())
                nombre = CargarTarea.Fila().Celda("nombre").ToString();

            if (TvTareas.SelectedNode.Parent != null)
                editarTitulo = "EDITAR SUBTAREA"; //nodo hijo
            else if (TvTareas.SelectedNode.Parent == null)
                editarTitulo = "EDITAR TAREA"; //nodo padre

            FrmNuevaTarea editarTarea = new FrmNuevaTarea(editarTitulo, nombre);
            if(editarTarea.ShowDialog() == DialogResult.OK)
            {
                CargarTarea.Fila().ModificarCelda("nombre", editarTarea.Nuevo);
                CargarTarea.GuardarDatos();

                TvTareas.SelectedNode.Text = nodoSeleccionado.Split('-')[0].Trim() + " - " + editarTarea.Nuevo;

                InsertarSeguimiento(Convert.ToInt32(nodoSeleccionado.Split('-')[0].Trim()), "SE HA CAMBIADO EL NOMBRE: " + editarTarea.Nuevo);
                CargarDgvSeguimiento(CargarDatosdSeguimiento(Convert.ToInt32(nodoSeleccionado.Split('-')[0].Trim())));
                LblTarea.Text = nodoSeleccionado.Split('-')[0].Trim() + " - " + editarTarea.Nuevo;
            }            
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string nombre = string.Empty;
            string nodoSeleccionado = TvTareas.SelectedNode.Text;

            if (nodoSeleccionado == null || nodoSeleccionado == "")
                return;
           
            DialogResult result = MessageBox.Show("La información que borre no podrá ser recuperada en el futuro, ¿Desea continuar?", "Borrar información", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result != DialogResult.OK)
                return;

            TareasTopico tareas = new TareasTopico();
            int IdBorrar = (Convert.ToInt32(nodoSeleccionado.Split('-')[0].Trim()));

            tareas.CargarDatos(IdBorrar);
            tareas.BorrarDatos(IdBorrar);
            tareas.GuardarDatos();

            if (TvTareas.SelectedNode.Parent == null)
            {//nodo padre
                Dictionary<string, object> parametros = new Dictionary<string,object>();
                parametros.Add("@tareaPrincipal", IdBorrar);
              
                tareas.SeleccionarDatos("tarea_principal=@tareaPrincipal",parametros).ForEach(delegate(Fila f)
                {
                    int borrar = Convert.ToInt32(f.Celda("id"));
                    TareasTopico borrarTarea = new TareasTopico();
                    borrarTarea.CargarDatos(borrar);
                    borrarTarea.BorrarDatos(borrar);
                    borrarTarea.GuardarDatos();
                });
            }
            splitContainer2.Panel2.Hide();
            CargarTreeView();
        }

        private void DgvSeguimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (DgvSeguimiento.SelectedRows[0].Cells["id_seguimiento"].Value != null && Convert.ToInt32(DgvSeguimiento.SelectedRows[0].Cells["editable"].Value) != 0)
            {
                IdSeguimiento = Convert.ToInt32(DgvSeguimiento.SelectedRows[0].Cells["id_seguimiento"].Value);
                editarToolStripMenuItem2.Visible = true;
            }
            else
                editarToolStripMenuItem2.Visible = false;
        }

        private void DgvSeguimiento_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           /* if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                    MenuSeguimiento.Show(Cursor.Position.X, Cursor.Position.Y);
            }*/
        }

        private void editarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DgvSeguimiento.SelectedRows[0].Cells["comentarios"].ReadOnly = false;

            string seguimientoComentario = DgvSeguimiento.SelectedRows[0].Cells["comentarios"].Value.ToString();
            DgvSeguimiento.CurrentCell = DgvSeguimiento.SelectedRows[0].Cells["comentarios"];
            DgvSeguimiento.CurrentRow.Cells["comentarios"].Selected = true;
            DgvSeguimiento.BeginEdit(true);
        }

        private void DgvSeguimiento_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (RecargarSeguimiento)
            {
                DgvSeguimiento.Enabled = false;
                TPDgvSeguimiento.Show("Actualizando información", DgvSeguimiento, 2200);
                CargarDgvSeguimiento(CargarDatosdSeguimiento(IdTarea));               
                DgvSeguimiento.Enabled = true;
            }
        }

        private void LblEstatus_MouseUp(object sender, MouseEventArgs e)
        {
            string estatus = LblEstatus.Text;

            switch (estatus)
            {
                case "EN PROCESO":
                    enProcesoToolStripMenuItem.Visible = false;
                    detenidoToolStripMenuItem.Visible = true;
                    terminadoToolStripMenuItem.Visible = true;
                    descartadoToolStripMenuItem.Visible = true;
                    pendienteToolStripMenuItem.Visible = true;

                    break;
                case "PENDIENTE":
                    enProcesoToolStripMenuItem.Visible = true;
                    detenidoToolStripMenuItem.Visible = true;
                    terminadoToolStripMenuItem.Visible = true;
                    descartadoToolStripMenuItem.Visible = true;
                    pendienteToolStripMenuItem.Visible = false;

                    break;
                case "DETENIDO":
                    enProcesoToolStripMenuItem.Visible = true;
                    detenidoToolStripMenuItem.Visible = false;
                    terminadoToolStripMenuItem.Visible = true;
                    descartadoToolStripMenuItem.Visible = true;
                    pendienteToolStripMenuItem.Visible = true;

                    break;
                case "TERMINADO":
                    enProcesoToolStripMenuItem.Visible = true;
                    detenidoToolStripMenuItem.Visible = true;
                    terminadoToolStripMenuItem.Visible = false;
                    descartadoToolStripMenuItem.Visible = true;
                    pendienteToolStripMenuItem.Visible = true;

                    break;
                case "DESCARTADO":
                    enProcesoToolStripMenuItem.Visible = true;
                    detenidoToolStripMenuItem.Visible = true;
                    terminadoToolStripMenuItem.Visible = true;
                    descartadoToolStripMenuItem.Visible = false;
                    pendienteToolStripMenuItem.Visible = true;

                    break;
                default:
                    break;
            }

            if(e.Button == MouseButtons.Right)
            {
                MenuEstatus.Show(LblEstatus, e.Location);
            }
        }

        private void pendienteToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Topico topico = new Topico();
            topico.CargarDatos(IdTopico);
            if(topico.TieneFilas())
            {
                topico.Fila().ModificarCelda("estatus", "PENDIENTE");
                topico.GuardarDatos();
            }
            LblEstatus.Text = "PENDIENTE";
        }

        private void enProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Topico topico = new Topico();
            topico.CargarDatos(IdTopico);
            if (topico.TieneFilas())
            {
                topico.Fila().ModificarCelda("estatus", "EN PROCESO");
                topico.GuardarDatos();
            }
            LblEstatus.Text = "EN PROCESO";
        }

        private void detenidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Topico topico = new Topico();
            topico.CargarDatos(IdTopico);
            if (topico.TieneFilas())
            {
                topico.Fila().ModificarCelda("estatus", "DETENIDO");
                topico.GuardarDatos();
            }
            LblEstatus.Text = "DETENIDO";
        }

        private void terminadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TareasTopico tareas = new TareasTopico();
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("@topico", IdTopico);
            TareasTopico.Modelo().SeleccionarDatos("topico=@topico", parametros).ForEach(delegate(Fila f)
            {
                int a = Convert.ToInt32(f.Celda("id"));
                tareas.CargarDatos(Convert.ToInt32(f.Celda("id")));
                if (tareas.TieneFilas())
                {
                  //  string tiempo = CalcularEstatusTiempo(Convert.ToDateTime(f.Celda("fecha_promesa")));
                    string estatusTiemp = "";
                    string tiempo = tareas.Fila().Celda("estatus_tiempo").ToString();
                    if (tiempo.EndsWith("TIEMPO"))
                        estatusTiemp = "TERMINADO A TIEMPO";
                    if (tiempo.EndsWith("LIMITE"))
                        estatusTiemp = "TERMINADO LIMITE";
                    if (tiempo.EndsWith("TARDE"))
                        estatusTiemp = "TERMINADO TARDE"; 

                    tareas.Fila().ModificarCelda("estatus", "TERMINADO");
                    tareas.Fila().ModificarCelda("estatus_tiempo", estatusTiemp);
                    tareas.GuardarDatos();
                }
            });

            Topico topico = new Topico();
            topico.CargarDatos(IdTopico);
            if (topico.TieneFilas())
            {
                topico.Fila().ModificarCelda("estatus", "TERMINADO");
                topico.GuardarDatos();
            }
            LblEstatus.Text = "TERMINADO";
            CargarTreeView();
            splitContainer2.Panel2.Hide();
        }

        private void descartadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Topico topico = new Topico();
            topico.CargarDatos(IdTopico);
            if (topico.TieneFilas())
            {
                topico.Fila().ModificarCelda("estatus", "DESCARTADO");
                topico.GuardarDatos();
            }
            LblEstatus.Text = "DESCARTADO";
        }

        private void planificarTiempoExtraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = string.Empty;
            string nodoSeleccionado = TvTareas.SelectedNode.Text;
            string editarTitulo = string.Empty;

            if (nodoSeleccionado == null || nodoSeleccionado == "")
                return;

            int idTarea = Convert.ToInt32(nodoSeleccionado.Split('-')[0].Trim());

            FrmPlanificarTiempoExtra planificar = new FrmPlanificarTiempoExtra(0, idTarea);
            planificar.Show();
        }

        private void CmbPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!Global.PrivilegioPorRol("LIDER DE PROYECTO"))
            {
                MessageBox.Show("Solamente los líderes de proyecto pueden cambiar la prioridad de la tarea");
                return;
            }

            if (CargarInformacion)
                return;

            string estatusPrioridad = CmbPrioridad.Text;
            int totalNodo = TvTareas.Nodes.Count;
            int contadorTareasUrgentes = 0;
            decimal porcentaje = 0;


            switch (estatusPrioridad)
            {
                case "URGENTE":
                    if (totalNodo < 10)
                        break;

                    foreach (TreeNode nodo in TvTareas.Nodes)
                    {

                        if (nodo.Name.EndsWith("-URGENTE"))
                            contadorTareasUrgentes++;
                    }

                    //no debe exceder el 20%
                    porcentaje = (contadorTareasUrgentes * 100) / totalNodo;
                    if (porcentaje >= 20)
                    {
                        MessageBox.Show("No puede haber más del 20% con prioridad URGENTE", "No se puede editar la prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
                case "REQUIERE ATENCION":
                    if (totalNodo < 10)
                        break;

                    foreach (TreeNode nodo in TvTareas.Nodes)
                    {

                        if (nodo.Name.EndsWith("-REQUIERE ATENCION"))
                            contadorTareasUrgentes++;
                    }

                    //no debe exceder el 20%
                    porcentaje = (contadorTareasUrgentes * 100) / totalNodo;
                    if (porcentaje >= 30)
                    {
                        MessageBox.Show("No puede haber más del 30% con prioridad REQUIERE ATENCION", "No se puede editar la prioridad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    break;
                default:
                    
                    break;
            }

            TreeNode nodoSeleccionado = TvTareas.SelectedNode;
            CargarTarea.CargarDatos(IdTarea);
            CargarTarea.Fila().ModificarCelda("prioridad", CmbPrioridad.Text);
            CargarTarea.GuardarDatos();

            //Cada vez que se modifica la fecha promesa se guarda en la tabla de segumiento
            Fila insertarSeguimiento = new Fila();
            insertarSeguimiento.AgregarCelda("tarea", IdTarea);
            insertarSeguimiento.AgregarCelda("fecha", DateTime.Now);
            insertarSeguimiento.AgregarCelda("usuario", Global.UsuarioActual.NombreCompleto().ToString());
            insertarSeguimiento.AgregarCelda("comentario", "LA PRIORIDAD DE LA TAREA HA SIDO MODIFICADA A " + CmbPrioridad.Text);
            TareasSeguimiento.Modelo().Insertar(insertarSeguimiento);

            //renombrar nombre de nodo
            string[] nodoNombre = TvTareas.SelectedNode.Name.Split('-');
            TvTareas.SelectedNode.Name = nodoNombre[0] + "-" + nodoNombre[1] + "-" + CmbPrioridad.Text;

            if (CmbPrioridad.Text == "URGENTE")
                TvTareas.SelectedNode.ForeColor = Color.Red;
            else
                TvTareas.SelectedNode.ForeColor = Color.Black;

            //Refrescamos el DgvSeguimiento
            CargarDgvSeguimiento(CargarDatosdSeguimiento(IdTarea));
            CargarFormatoTopicos();

        }

        private void MenuOpciones_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void mostrarRevisadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarTreeView();
            splitContainer2.Panel2.Hide();
        }

        private void BtnTerminarJunta_Click(object sender, EventArgs e)
        {

            if(DgvResponsable.Rows.Count <= 0)
            {
                MessageBox.Show("Debe asignar a un responsable");
                return;
            }

            Topico topico = new Topico();
            topico.CargarDatos(IdTopico);
            topico.Fila().ModificarCelda("notas", TxtNotas.Text);
            topico.GuardarDatos();

            Proyecto proy = new Proyecto();
            proy.CargarDatos(IdProyecto);

            bool terminarTarea = ReporteCorreo.ReporteDeMinuta(IdProyecto, proy.Fila().Celda("nombre").ToString(), IdTarea);
            if (terminarTarea)
            {
                topico.CargarDatos(IdTopico);
                topico.Fila().ModificarCelda("estatus", "TERMINADO");
                topico.GuardarDatos();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo ht =DgvInvolucrados.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                if (e.Button == MouseButtons.Right)
                {
                    borrarToolStripMenuItem.Enabled = false;
                    MenuInvolucrado.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void DgvInvolucrados_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 || e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    borrarToolStripMenuItem.Enabled = true;
                    MenuInvolucrado.Show(Cursor.Position.X, Cursor.Position.Y);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmSeleccionarUsuario involucrado = new FrmSeleccionarUsuario("", true);
            if (involucrado.ShowDialog() == DialogResult.OK)
            {
                foreach (var usuario in involucrado.UsuariosSeleccionados)
                {
                    string resp = usuario.NombreCompleto();
                    string correo = usuario.Fila().Celda("correo").ToString();
                    int idUsuario = Convert.ToInt32(usuario.Fila().Celda("id"));

                    Dictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add("@idTarea", IdTarea);
                    parametros.Add("@responsable", resp);

                    CargarInvolucrados.CargarInvolucradosDeTarea(IdTarea, resp);

                    if (!CargarInvolucrados.TieneFilas())
                    {
                        Fila insertarResponsable = new Fila();
                        insertarResponsable.AgregarCelda("tarea", IdTarea);
                        insertarResponsable.AgregarCelda("id_usuario", idUsuario);
                        insertarResponsable.AgregarCelda("nombre_usuario", resp);
                        insertarResponsable.AgregarCelda("correo", correo);
                        CargarInvolucrados.Insertar(insertarResponsable);
                    }

                }
                //CargarDgvResponsable(CargarDatosResponsable(IdTarea));
                CargarDgvInvolucrados(CargarDatosInvolucrado(IdTarea));
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Los datos que son borrados no podrán ser recuperados en el futuro. ¿Desea continuar?", "Borrar involucrados", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                foreach (DataGridViewRow row in DgvInvolucrados.SelectedRows)
                {
                    int idInvolucrado = Convert.ToInt32(row.Cells["id_involucrado"].Value.ToString());
                    CargarInvolucrados.BorrarDatos(idInvolucrado);
                    CargarInvolucrados.GuardarDatos();
                }
                CargarDgvInvolucrados(CargarDatosInvolucrado(IdTarea));
            }
        }

        private void MenuResponsable_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItem3.Visible = (DgvResponsable.SelectedRows.Count == 1);
        }

        private void CmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (CargarInformacion)
                return;

            CargarTarea.CargarDatos(IdTarea);
            CargarTarea.Fila().ModificarCelda("horas", NumHoras.Value);
            CargarTarea.GuardarDatos();

            //Mostramos un tooltip para informar al usuario de los cambios guardados
            Tool.Show("Su información ha sido guardada de forma automática", NumHoras, 2200);
        }

        private void TxtNotas_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmAgregarCorreoAlterno correo = new FrmAgregarCorreoAlterno();
            if(correo.ShowDialog() == DialogResult.OK)
            {
                TareasResponsables tareaResp = new TareasResponsables();
                tareaResp.CargarDatos(Convert.ToInt32(DgvResponsable.SelectedRows[0].Cells["id"].Value.ToString()));

                if(tareaResp.TieneFilas())
                {
                    tareaResp.Fila().ModificarCelda("correo_alterno", correo.CorreoAlterno);
                    tareaResp.GuardarDatos();
                    CargarDgvResponsable(CargarDatosResponsable(IdTarea));
                }
            }
        }

        private void correoAlternoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarCorreoAlterno correo = new FrmAgregarCorreoAlterno();
            if (correo.ShowDialog() == DialogResult.OK)
            {
                TareaInvolucrados tareaResp = new TareaInvolucrados();
                tareaResp.CargarDatos(Convert.ToInt32(DgvInvolucrados.SelectedRows[0].Cells["id_involucrado"].Value.ToString()));

                if (tareaResp.TieneFilas())
                {
                    tareaResp.Fila().ModificarCelda("correo_alterno", correo.CorreoAlterno);
                    tareaResp.GuardarDatos();
                    CargarDgvInvolucrados(CargarDatosInvolucrado(IdTarea));
                }
            }
        }

        private void MenuInvolucrado_Opening(object sender, CancelEventArgs e)
        {
            correoAlternoToolStripMenuItem.Visible = (DgvInvolucrados.SelectedRows.Count == 1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CargarInformacion)
                return;

            double horas = 0;

            switch (CmbHoras.Text)
            {
                case "15 minutos":
                    horas = 0.25;
                    break;
                case "30 minutos":
                    horas = 0.5;
                    break;
                case "45 minutos":
                    horas = 0.75;
                    break;
                case "1:00 hora ":
                    horas = 1.0;
                    break;
                case "1:15 horas":
                    horas = 1.25;
                    break;
                case "1.30 horas":
                    horas = 1.5;
                    break;
                case "1.45 horas":
                    horas = 1.75;
                    break;
                case "2:00 horas":
                    horas = 2.0;
                    break;
                case "2:15 horas":
                    horas = 2.25;
                    break;
                case "2.30 horas":
                    horas = 2.5;
                    break;
                case "2.45 horas":
                    horas = 2.75;
                    break;
                case "3:00 horas":
                    horas = 3.0;
                    break;
                case "3.15 horas":
                    horas = 3.25;
                    break;
                case "3.30 horas":
                    horas = 3.5;
                    break;
                case "3.45 horas":
                    horas = 3.75;
                    break;
                case "4:00 horas":
                    horas = 4.0;
                    break;
                case "4:15 horas":
                    horas = 4.25;
                    break;
                case "4:30 horas":
                    horas = 4.5;
                    break;
                case "4.45 horas":
                    horas = 4.75;
                    break;
                case "5:00 horas":
                    horas = 5.0;
                    break;
                case "5:15 horas":
                    horas = 5.25;
                    break;
                case "5:30 horas":
                    horas = 5.5;
                    break;
                case "5:45 horas":
                    horas = 5.75;
                    break;
                case "6:00 horas":
                    horas = 6.0;
                    break;
                case "6:15 horas":
                    horas = 6.25;
                    break;
                case "6:30 horas":
                    horas = 6.5;
                    break;
                case "6:45 horas":
                    horas = 6.75;
                    break;
                case "7:00 horas":
                    horas = 7.0;
                    break;
                case "7:15 horas":
                    horas = 7.25;
                    break;
                case "7:30 horas":
                    horas = 7.5;
                    break;
                case "7:45 horas":
                    horas = 7.75;
                    break;
                case "8:00 horas":
                    horas = 8.0;
                    break;
                default:
                    break;
            }


            CargarTarea.CargarDatos(IdTarea);
            CargarTarea.Fila().ModificarCelda("horas", horas);
            CargarTarea.GuardarDatos();

            //Mostramos un tooltip para informar al usuario de los cambios guardados
            Tool.Show("Su información ha sido guardada de forma automática", NumHoras, 2200);
        }
    }
}
