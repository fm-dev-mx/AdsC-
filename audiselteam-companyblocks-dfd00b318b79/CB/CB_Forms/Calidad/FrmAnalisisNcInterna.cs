using CB_Base.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB
{
    public partial class FrmAnalisisNcInterna : Ventana
    {
        List<Fila> ListaNc = new List<Fila>();
        int IdPlano = 0;
        decimal IdProyecto = 0;
        bool ModoConsulta = false;

        public FrmAnalisisNcInterna(List<Fila> listaNc, bool modoConsulta = false)
        {
            InitializeComponent();
            ListaNc = listaNc;
            ModoConsulta = modoConsulta;
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void MostrarDetallesNoConformidad(Fila f)
        {
            ModoConsulta = f.Celda("estatus_analisis").ToString() == "FINALIZADO";
            string strProceso = string.Empty;
            string responsable = string.Empty;
            string strIdPlano = string.Empty;
            string strNombreArchivoPlano = string.Empty;
            string rechazo = string.Empty;

            TxtIdNoConformidad.Text = f.Celda("id").ToString().PadLeft(4, '0');
            TxtOrigen.Text = Global.ObjetoATexto(f.Celda("proceso_origen"), "");

            // Intenta cargar datos de plano
            PlanoProyecto plano = new PlanoProyecto();
            IdPlano = Convert.ToInt32(Global.ObjetoATexto(f.Celda("plano"), "0"));

            // Intenta cargar datos de cambio de diseno
            CambioDiseno cambioDiseno = new CambioDiseno();
            cambioDiseno.SeleccionarNoConformidad(Convert.ToInt32(f.Celda("id")));

            if (IdPlano > 0)
            {
                plano.CargarDatos(IdPlano);

                strIdPlano = Global.ObjetoATexto(plano.Fila().Celda("id"), "0").PadLeft(4, '0');
                strNombreArchivoPlano = Global.ObjetoATexto(plano.Fila().Celda("nombre_archivo"), "");
                IdProyecto = Convert.ToDecimal(plano.Fila().Celda("proyecto"));
                rechazo = Global.ObjetoATexto(f.Celda("proceso_fabricacion_rechazado"), "").PadLeft(4, '0');
                int procesoRechazado = Convert.ToInt32(Global.ObjetoATexto(f.Celda("proceso_fabricacion_rechazado"), "0"));

                PlanoProceso proceso = new PlanoProceso();
                proceso.CargarDatos(procesoRechazado);

                //Buscamos la información del proceso afectado
                if (proceso.TieneFilas())
                {
                    strProceso = Global.ObjetoATexto(proceso.Fila().Celda("proceso"), "");
                    responsable = Global.ObjetoATexto(proceso.Fila().Celda("operador"), "");
                }

                TxtSalidaNc.Text = strIdPlano + " " + strNombreArchivoPlano;
                TxtDefecto.Text = rechazo + " " + strProceso;
            }
            else if (cambioDiseno.TieneFilas())
            {
                rechazo = "ERROR DE DISEÑO";
                responsable = Global.ObjetoATexto(cambioDiseno.Fila().Celda("usuario_solicitud"), "");
                string cadenaModulo = (Global.ObjetoATexto(cambioDiseno.Fila().Celda("modulos_afectados"), "00"));
                decimal proyecto = Convert.ToDecimal(Global.ObjetoATexto(cambioDiseno.Fila().Celda("proyecto"), "0"));
                string strModulo = string.Empty;

                int modulosDetectados = cadenaModulo.Length / 2;

                //separamos los modulos de 2 en 2 (formato 02)
                int indiceCadena = 0;
                for (int i = 0; i < modulosDetectados; i++)
                {
                    strModulo += cadenaModulo.Substring(indiceCadena, 2) + ", ";
                    indiceCadena += 2;
                }

                //borramos la ultima coma del string
                strModulo = strModulo.TrimEnd().TrimEnd(',');
                TxtSalidaNc.Text = rechazo;
                TxtDefecto.Text = "MODULO(S) " + strModulo;
            }

            TxtPersonaQueOrigina.Text = responsable;
            NumUdCostoEstimado.Value = Convert.ToDecimal(f.Celda("costo_estimado"));
            NumUdDiasRetraso.Value = Convert.ToInt32(f.Celda("dias_retraso"));
            CmbProbabilidad.Text = Global.ObjetoATexto(f.Celda("probabilidad_ocurrencia"), "");
            TxtComentarios.Text = Global.ObjetoATexto(f.Celda("comentarios"), "");

            Usuario usuario = new Usuario();
            usuario.CargarDatos(Convert.ToInt32(Global.ObjetoATexto(f.Celda("usuario_creacion"), "0")));
            if (usuario.TieneFilas())
            {
                TxtInspeccion.Text = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");
                TxtFechaInspeccion.Text = Global.FechaATexto(f.Celda("fecha_creacion"));
            }

            usuario.CargarDatos(Convert.ToInt32(Global.ObjetoATexto(f.Celda("usuario_liberacion"), "0")));
            if (usuario.TieneFilas())
            {
                TxtLiberacion.Text = Global.ObjetoATexto(usuario.Fila().Celda("nombre"), "") + " " + Global.ObjetoATexto(usuario.Fila().Celda("paterno"), "");
                TxtFechaLiberacion.Text = Global.FechaATexto(f.Celda("fecha_liberacion"));
            }
            TxtDisposicion.Text = Global.ObjetoATexto(f.Celda("disposicion"), "N/A");

            CmbTipoAccion.Text = "TODAS";
            CargarAcciones();

            NumUdCostoEstimado.ReadOnly = ModoConsulta;
            NumUdCostoEstimado.Enabled = !ModoConsulta;
            NumUdDiasRetraso.ReadOnly = ModoConsulta;
            NumUdDiasRetraso.Enabled = !ModoConsulta;
            if (!ModoConsulta)
            {
                CmbProbabilidad.Enabled = true;
                nuevaAcciónToolStripMenuItem.Visible = true;
                BtnFinalizar.Visible = true;
            }
            else
            {
                CmbProbabilidad.Enabled = false;
                nuevaAcciónToolStripMenuItem.Visible = false;
                BtnFinalizar.Visible = false;
            }
        }

        private void FrmAnalisisNcInterna_Load(object sender, EventArgs e)
        {
            NumDefecto.Maximum = ListaNc.Count;
            MostrarDetallesNoConformidad(ListaNc[0]);
            LblDefecto.Text += " (" + NumDefecto.Maximum + " en total):";
        }

        public void CargarAcciones()
        {
            DgvAcciones.Rows.Clear();
            Accion.Modelo().SeleccionarNoConformidad(Convert.ToInt32(ListaNc[(int)NumDefecto.Value-1].Celda("id")), CmbTipoAccion.Text).ForEach(delegate(Fila f) {
                string strResponsables = string.Empty;
                string strFechaPromesa = Global.FechaATexto(f.Celda("fecha_promesa"), false);
                int idTarea = Convert.ToInt32(f.Celda("tarea_accion"));

                List<Fila> responsables = TareasResponsables.Modelo().SeleccionarTarea(idTarea);

                for (int i = 0; i < responsables.Count; i++)
                {
                    strResponsables += responsables[i].Celda("responsable").ToString();

                    if (i < (responsables.Count - 1))
                        strResponsables += Environment.NewLine;
                }

                DgvAcciones.Rows.Add(f.Celda("id_accion").ToString().PadLeft(4, '0'), f.Celda("tipo_accion"), f.Celda("nombre"), f.Celda("descripcion"), strResponsables, strFechaPromesa, f.Celda("estatus"));
            });
            HabilitarBtnFinalizar();
        }

        private void nuevaAcciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevaAccion accion = new FrmNuevaAccion();

            if (accion.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int idTopico = 0;
                string descripcionTopico = "ACCIONES DE LA NO CONFORMIDAD INTERNA #" + TxtIdNoConformidad.Text;

                // verificar si el topico existe
                Topico tp = new Topico();
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("@descripcion", descripcionTopico);
                tp.SeleccionarDatos("descripcion=@descripcion", parametros);

                // si existe obtiene su id, si no existe lo crea
                if (tp.TieneFilas())
                {
                    idTopico = Convert.ToInt32(tp.Fila().Celda("id"));
                }
                else
                {
                    Fila nuevoTopico = new Fila();
                    nuevoTopico.AgregarCelda("proyecto", IdProyecto.ToString("F2"));
                    nuevoTopico.AgregarCelda("descripcion", descripcionTopico);
                    nuevoTopico.AgregarCelda("estatus", "PENDIENTE");
                    nuevoTopico.AgregarCelda("fecha_creacion", DateTime.Now);
                    nuevoTopico.AgregarCelda("usuario_creacion", Global.UsuarioActual.NombreCompleto());
                    nuevoTopico = tp.Insertar(nuevoTopico);
                    idTopico = Convert.ToInt32(nuevoTopico.Celda("id"));
                }

                // crea la tarea
                Fila nuevaTarea = new Fila();
                nuevaTarea.AgregarCelda("topico", idTopico);
                nuevaTarea.AgregarCelda("nombre", accion.Nombre);
                nuevaTarea.AgregarCelda("tarea_principal", 0);
                nuevaTarea.AgregarCelda("fecha_promesa", accion.FechaPromesa);
                nuevaTarea.AgregarCelda("estatus", "PENDIENTE");
                nuevaTarea.AgregarCelda("descripcion", "Tipo de acción: " + accion.Tipo + Environment.NewLine + Environment.NewLine + accion.Detalles);
                nuevaTarea.AgregarCelda("estatus_tiempo", string.Empty);
                nuevaTarea = TareasTopico.Modelo().Insertar(nuevaTarea);

                // crear los responsables de la tarea
                accion.UsuariosSeleccionados.ForEach(delegate(Usuario usr)
                {
                    Fila nuevoResponsable = new Fila();
                    nuevoResponsable.AgregarCelda("tarea", nuevaTarea.Celda("id"));
                    nuevoResponsable.AgregarCelda("responsable", usr.NombreCompleto());
                    TareasResponsables.Modelo().Insertar(nuevoResponsable);
                });

                // crea la accion
                Fila nuevaAccion = new Fila();
                nuevaAccion.AgregarCelda("tipo", accion.Tipo);
                nuevaAccion.AgregarCelda("tarea", nuevaTarea.Celda("id"));
                nuevaAccion.AgregarCelda("no_conformidad", ListaNc[(int)NumDefecto.Value-1].Celda("id"));
                nuevaAccion.AgregarCelda("usuario_creacion", Global.UsuarioActual.Fila().Celda("id"));
                nuevaAccion.AgregarCelda("fecha_creacion", DateTime.Now);
                Accion.Modelo().Insertar(nuevaAccion);

                MessageBox.Show("La acción fue creada correctamente.", "Nueva acción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAcciones();
            }
        }

        private void CmbTipoAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAcciones();
        }

        private void NumUdCostoEstimado_ValueChanged(object sender, EventArgs e)
        {
            NoConformidad nCInterna = new NoConformidad();
            nCInterna.CargarDatos(Convert.ToInt32(TxtIdNoConformidad.Text));
            nCInterna.Fila().ModificarCelda("costo_estimado", NumUdCostoEstimado.Value);
            nCInterna.GuardarDatos();
            ListaNc[(int)NumDefecto.Value - 1] = nCInterna.Fila();
        }

        private void NumUdDiasRetraso_ValueChanged(object sender, EventArgs e)
        {
            NoConformidad nCInterna = new NoConformidad();
            nCInterna.CargarDatos(Convert.ToInt32(TxtIdNoConformidad.Text));
            nCInterna.Fila().ModificarCelda("dias_retraso", NumUdDiasRetraso.Value);
            nCInterna.GuardarDatos();
            ListaNc[(int)NumDefecto.Value - 1] = nCInterna.Fila();
        }

        private void CmbProbabilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            NoConformidad nCInterna = new NoConformidad();
            nCInterna.CargarDatos(Convert.ToInt32(TxtIdNoConformidad.Text));
            nCInterna.Fila().ModificarCelda("probabilidad_ocurrencia", CmbProbabilidad.Text);
            nCInterna.GuardarDatos();
            ListaNc[(int)NumDefecto.Value - 1] = nCInterna.Fila();

            HabilitarBtnFinalizar();
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Seguro que quieres finalizar el análisis de la no conformidad?", "Finalizar análisis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp != System.Windows.Forms.DialogResult.Yes)
                return;

            NoConformidad nCInterna = new NoConformidad();
            nCInterna.CargarDatos(Convert.ToInt32(TxtIdNoConformidad.Text));
            nCInterna.Fila().ModificarCelda("estatus_analisis", "FINALIZADO");
            nCInterna.GuardarDatos();
            ListaNc[(int)NumDefecto.Value - 1] = nCInterna.Fila();
            MostrarDetallesNoConformidad(nCInterna.Fila());
        }

        private void HabilitarBtnFinalizar()
        {
            int accionCorrectiva = 0;
            int accionPreventiva = 0;
            foreach (DataGridViewRow row in DgvAcciones.Rows)
            {
                if (row.Cells["tipo"].Value.ToString() == "PREVENTIVA")
                    accionPreventiva++;
                else if (row.Cells["tipo"].Value.ToString() == "CORRECTIVA")
                    accionCorrectiva++;

                if (accionPreventiva > 0 && accionCorrectiva > 0)
                    break;
            }

            if (CmbProbabilidad.Text == "MUY BAJA" && accionCorrectiva > 0)
                BtnFinalizar.Enabled = true;
            else if (CmbProbabilidad.Text != "MUY BAJA" && accionCorrectiva > 0 && accionPreventiva > 0) // && NumUdCostoEstimado.Value > 0 && NumUdDiasRetraso.Value
                BtnFinalizar.Enabled = true;
            else
                BtnFinalizar.Enabled = false;
        }

        private void NumDefecto_ValueChanged(object sender, EventArgs e)
        {
            MostrarDetallesNoConformidad(ListaNc[(int)NumDefecto.Value-1]);
        }
    }
}
