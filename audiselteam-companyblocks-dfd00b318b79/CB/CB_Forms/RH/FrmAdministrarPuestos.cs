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
    public partial class FrmAdministrarPuestos : Ventana
    {
        Fila RolSeleccionado = null;
        Fila Perfil = null;

        public FrmAdministrarPuestos()
        {
            InitializeComponent();
        }

        private void FrmAdministrarPuestos_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarDepartamentos();
        }

        public void CargarRoles()
        {
            CmbPuesto.Items.Clear();
            CmbCoordinador.Items.Clear();
            CmbCoordinador.Items.Add("N/A");
            Rol.Modelo().Todos().ForEach(delegate(Fila f)
            {
                CmbPuesto.Items.Add(f.Celda("rol"));
                CmbCoordinador.Items.Add(f.Celda("rol"));
            });
        }

        public void CargarDepartamentos()
        {
            CmbDepartamento.Items.Clear();
            PerfilPuesto.Modelo().Departamentos().ForEach(delegate(string dept)
            {
                CmbDepartamento.Items.Add(dept);
            });
        }

        public void CargarPerfil(Fila rol, int nivel)
        {
            int nivelMaximo = Convert.ToInt32(rol.Celda("nivel_maximo"));

            NumNivel.Maximum = nivelMaximo;

            if(nivelMaximo > 0)
            {
                NumNivel.Enabled = true;
                NumNivel.ReadOnly = false;
                NumNivel.Visible = true;
                LblNivel.Visible = true;
            }
            else
            {
                nivel = 0;
                NumNivel.Visible = false;
                LblNivel.Visible = false;
            }


            List<Fila> perfiles = PerfilPuesto.Modelo().Cargar(rol.Celda("rol").ToString(), nivel);

            if (perfiles.Count > 0)
                Perfil = perfiles[0];
            else
            {
                Perfil = new Fila();
                Perfil.AgregarCelda("rol", CmbPuesto.Text);
                Perfil.AgregarCelda("nivel", nivel);
                Perfil.AgregarCelda("departamento", "");
                Perfil.AgregarCelda("coordinador", "N/A");
                Perfil.AgregarCelda("nivel_coordinador", 0);
                Perfil.AgregarCelda("descripcion", "");
                Perfil.AgregarCelda("actividades_principales", "");
                Perfil.AgregarCelda("actividades_adicionales", "");
                Perfil.AgregarCelda("responsabilidades", "");
                Perfil.AgregarCelda("recursos_requeridos", "");
                Perfil.AgregarCelda("experiencia", "");
                Perfil.AgregarCelda("nivel_academico", "");
                Perfil.AgregarCelda("tiempo_completo", 0);
                Perfil.AgregarCelda("disponibilidad_viajar", 0);
                Perfil.AgregarCelda("ultima_modificacion", DateTime.Now);
                Perfil.AgregarCelda("modificado_por", Global.UsuarioActual.NombreCompleto());
                Perfil.AgregarCelda("plantilla_autorizada", 1);
                Perfil.AgregarCelda("salario_minimo", 1);
                Perfil.AgregarCelda("salario_maximo", 1);
                Perfil = PerfilPuesto.Modelo().Insertar(Perfil);
            }

            CmbDepartamento.Text = Perfil.Celda("departamento").ToString();
            CmbCoordinador.Text = Perfil.Celda("coordinador").ToString();
            NumNivelCoordinador.Value = Convert.ToInt32(Perfil.Celda("nivel_coordinador"));
            TxtDescripcionGeneral.Text = Perfil.Celda("descripcion").ToString();
            TxtActividadesPrincipales.Text = Perfil.Celda("actividades_principales").ToString();
            TxtActividadesAdicionales.Text = Perfil.Celda("actividades_adicionales").ToString();
            TxtResponsabilidades.Text = Perfil.Celda("responsabilidades").ToString();
            TxtRecursosRequeridos.Text = Perfil.Celda("recursos_requeridos").ToString();
            TxtExperiencia.Text = Perfil.Celda("experiencia").ToString();
            TxtNivelAcademico.Text = Perfil.Celda("nivel_academico").ToString();
            ChkDisponibilidadViajar.Checked = Convert.ToBoolean(Perfil.Celda("disponibilidad_viajar"));
            ChkTiempoCompleto.Checked = Convert.ToBoolean(Perfil.Celda("tiempo_completo"));
            LblUltimaActualizacion.Text = "Modificado: " + Convert.ToDateTime(Perfil.Celda("ultima_modificacion")).ToString("MMM dd, yyyy hh:mm:ss tt");
            LblModificadoPor.Text = "Por: " + Perfil.Celda("modificado_por").ToString();
            NumericPlantilla.Value = Convert.ToInt32(Global.ObjetoATexto(Perfil.Celda("plantilla_autorizada"), "1"));
            NumericRangoMinimo.Value = Convert.ToDecimal(Global.ObjetoATexto(Perfil.Celda("salario_minimo"), "1"));
            NumericRangoMaximo.Value = Convert.ToDecimal(Global.ObjetoATexto(Perfil.Celda("salario_maximo"), "1"));

            TxtCoordina.Text = string.Empty;
            if (nivel == 3 || nivel == 0)
            {
                PerfilPuesto.Modelo().Subordinados(CmbPuesto.Text, nivel).ForEach(delegate(Fila f)
                {
                    int nivelSubordinado = Convert.ToInt32(f.Celda("nivel"));
                    TxtCoordina.AppendText(f.Celda("rol").ToString());

                    if(nivelSubordinado > 0)
                        TxtCoordina.AppendText(" " + nivelSubordinado);

                    TxtCoordina.AppendText(Environment.NewLine);
                });
                if (TxtCoordina.Text == string.Empty)
                    TxtCoordina.AppendText("NADIE");
            }
            else TxtCoordina.Text = "NADIE";

            CargarHabilidades();
            TabPerfil.Enabled = true;
            TxtDescripcionGeneral.ReadOnly = false;
            TxtDescripcionGeneral.Enabled = true;
            CmbDepartamento.Enabled = true;
            CmbCoordinador.Enabled = true;
            NumNivelCoordinador.ReadOnly = false;
            NumNivelCoordinador.Enabled = true;
            ChkDisponibilidadViajar.Enabled = true;
            ChkTiempoCompleto.Enabled = true;
            BtnImprimir.Enabled = true;
        }

        private void CmbPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                List<Fila> roles = Rol.Modelo().SeleccionarRol(CmbPuesto.Text);

                if (roles.Count > 0)
                {
                    RolSeleccionado = roles[0];
                    CargarPerfil(RolSeleccionado, (int)NumNivel.Value);
                }
                else
                    RolNoExiste();
            }
        }

        public void RolNoExiste()
        {
            DialogResult respuesta = MessageBox.Show("El puesto seleccionado no existe, ¿quieres crearlo?", "Crear puesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
            {
                RolSeleccionado = new Fila();
                RolSeleccionado.AgregarCelda("rol", CmbPuesto.Text);
                RolSeleccionado = Rol.Modelo().Insertar(RolSeleccionado);
                CmbPuesto.Items.Add(CmbPuesto.Text);
                CmbCoordinador.Items.Add(CmbPuesto.Text);
                MessageBox.Show("El puesto fue creado correctamente.", "Puesto creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPerfil(RolSeleccionado, (int)NumNivel.Value);
            }
            else
            {
                CmbPuesto.Text = string.Empty;
            }
        }

        private void CmbPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Fila> roles = Rol.Modelo().SeleccionarRol(CmbPuesto.Text);

            if (roles.Count > 0)
            {
                RolSeleccionado = roles[0];
                CargarPerfil(RolSeleccionado, (int)NumNivel.Value);
            }
            else
                RolNoExiste();
        }

        private void CmbPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void NumNivel_ValueChanged(object sender, EventArgs e)
        {
            if(Perfil != null)
                CargarPerfil(RolSeleccionado, (int)NumNivel.Value);
        }

        public void ActualizarCoordinador()
        {
            int nivelCoordinador = (int)NumNivelCoordinador.Value;
            Rol rolCoordinador = new Rol();
            rolCoordinador.SeleccionarRol(CmbCoordinador.Text);

            if(rolCoordinador.TieneFilas())
            {
                int nivelMaximoCoordinador = Convert.ToInt32(rolCoordinador.Fila().Celda("nivel_maximo"));
                NumNivelCoordinador.Maximum = nivelMaximoCoordinador;

                if (nivelMaximoCoordinador == 0)
                {
                    nivelCoordinador = 0;
                    NumNivelCoordinador.Visible = false;
                    LblNivelCoordinador.Visible = false;
                }
                else
                {
                    NumNivelCoordinador.Visible = true;
                    LblNivelCoordinador.Visible = true;
                }
            }


            PerfilPuesto perfilModificado = new PerfilPuesto();
            perfilModificado.Cargar(Perfil.Celda("rol").ToString(), Convert.ToInt32(Perfil.Celda("nivel")));

            if (perfilModificado.TieneFilas())
            {
                perfilModificado.Fila().ModificarCelda("ultima_modificacion", DateTime.Now);
                perfilModificado.Fila().ModificarCelda("modificado_por", Global.UsuarioActual.NombreCompleto());
                perfilModificado.Fila().ModificarCelda("coordinador", CmbCoordinador.Text);
                perfilModificado.Fila().ModificarCelda("nivel_coordinador", nivelCoordinador);
                perfilModificado.GuardarDatos();
            }

        }

        private void CmbCoordinador_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCoordinador();
        }

        private void NumNivelCoordinador_ValueChanged(object sender, EventArgs e)
        {
            ActualizarCoordinador();
        }

        private void CmbDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsLetter(e.KeyChar))
            {
                e.KeyChar = Char.ToUpper(e.KeyChar);
            }
        }

        public void ActualizarDepartamento()
        {
            PerfilPuesto perfilModificado = new PerfilPuesto();
            perfilModificado.Cargar(Perfil.Celda("rol").ToString(), Convert.ToInt32(Perfil.Celda("nivel")));

            if (perfilModificado.TieneFilas())
            {
                perfilModificado.Fila().ModificarCelda("departamento", CmbDepartamento.Text);
                perfilModificado.GuardarDatos();
            }
            if(!CmbDepartamento.Items.Contains(CmbDepartamento.Text))
                CmbDepartamento.Items.Add(CmbDepartamento.Text);
        }

        private void CmbDepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ActualizarDepartamento();
            }
        }

        private void CmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDepartamento();
        }

        public void ModificarPerfil(string celda, object valor)
        {
            if (Perfil == null)
                return;

            PerfilPuesto perfilEditado = new PerfilPuesto();
            perfilEditado.Cargar(Perfil.Celda("rol").ToString(), Convert.ToInt32(Perfil.Celda("nivel")));

            if (perfilEditado.TieneFilas())
            {
                perfilEditado.Fila().ModificarCelda("ultima_modificacion", DateTime.Now);
                perfilEditado.Fila().ModificarCelda("modificado_por", Global.UsuarioActual.NombreCompleto());
                perfilEditado.Fila().ModificarCelda(celda, valor);
                perfilEditado.GuardarDatos();
            }
        }

        private void TxtDescripcionGeneral_Leave(object sender, EventArgs e)
        {
            ModificarPerfil("descripcion", TxtDescripcionGeneral.Text);
        }

        private void TxtActividadesPrincipales_Leave(object sender, EventArgs e)
        {
            ModificarPerfil("actividades_principales", TxtActividadesPrincipales.Text);
        }

        private void TxtActividadesAdicionales_Leave(object sender, EventArgs e)
        {
            ModificarPerfil("actividades_adicionales", TxtActividadesAdicionales.Text);
        }

        private void TxtResponsabilidades_Leave(object sender, EventArgs e)
        {
            ModificarPerfil("responsabilidades", TxtResponsabilidades.Text);
        }

        private void TxtRecursosRequeridos_Leave(object sender, EventArgs e)
        {
            ModificarPerfil("recursos_requeridos", TxtRecursosRequeridos.Text);
        }

        private void TxtExperiencia_Leave(object sender, EventArgs e)
        {
            ModificarPerfil("experiencia", TxtExperiencia.Text);
        }

        private void TxtNivelAcademico_Leave(object sender, EventArgs e)
        {
            ModificarPerfil("nivel_academico", TxtNivelAcademico.Text);
        }

        private void ChkTiempoCompleto_CheckedChanged(object sender, EventArgs e)
        {
            ModificarPerfil("tiempo_completo", ChkTiempoCompleto.Checked);
        }

        private void ChkDisponibilidadViajar_CheckedChanged(object sender, EventArgs e)
        {
            ModificarPerfil("disponibilidad_viajar", ChkDisponibilidadViajar.Checked);
        }

        private void LblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            Mover(sender, e);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        public void CargarHabilidades()
        {
            int idPerfil = Convert.ToInt32(Perfil.Celda("id"));
            DgvHabilidadesPersonales.Rows.Clear();
            DgvHabilidadesTecnicas.Rows.Clear();
            PerfilHabilidad.Modelo().Habilidades(idPerfil).ForEach(delegate(Fila habilidadDelPerfil)
            {
                if (habilidadDelPerfil.Celda("tipo").ToString() == "PERSONAL")
                    DgvHabilidadesPersonales.Rows.Add(habilidadDelPerfil.Celda("id"), habilidadDelPerfil.Celda("habilidad"));
                else if (habilidadDelPerfil.Celda("tipo").ToString() == "TECNICA")
                    DgvHabilidadesTecnicas.Rows.Add(habilidadDelPerfil.Celda("id"), habilidadDelPerfil.Celda("habilidad"));
            });
        }

        public void SeleccionarHabilidades(string tipo)
        {
            List<int> idHabilidadesDelPerfil = new List<int>();
            int idPerfil = Convert.ToInt32(Perfil.Celda("id"));

            PerfilHabilidad habilidadesPerfil = new PerfilHabilidad();

            habilidadesPerfil.Habilidades(idPerfil).ForEach(delegate(Fila f)
            {
                idHabilidadesDelPerfil.Add(Convert.ToInt32(f.Celda("id")));
            });

            FrmSeleccionarHabilidades selecHabilidades = new FrmSeleccionarHabilidades(tipo, idHabilidadesDelPerfil);

            if (selecHabilidades.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                habilidadesPerfil.BorrarHabilidades(idPerfil);
                selecHabilidades.HabilidadesSeleccionadas.ForEach(delegate(int habilidad)
                {
                    Fila habilidadNueva = new Fila();
                    habilidadNueva.AgregarCelda("perfil", idPerfil);
                    habilidadNueva.AgregarCelda("habilidad", habilidad);
                    habilidadesPerfil.Insertar(habilidadNueva);
                    CargarHabilidades();
                });
            }
        }

        private void seleccionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionarHabilidades("PERSONAL");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SeleccionarHabilidades("TECNICA");
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            PerfilPuesto puesto = new PerfilPuesto();
            puesto.Cargar(CmbPuesto.Text, (int)NumNivel.Value);
            if(puesto.TieneFilas())
            {
                string rol = puesto.Fila().Celda("rol").ToString();
                int idPuesto = Convert.ToInt32(puesto.Fila().Celda("id").ToString());
                int nivel = Convert.ToInt32(puesto.Fila().Celda("nivel"));

                List<Fila> coordinaA = PerfilPuesto.Modelo().Subordinados(rol, nivel);

                byte[] archivo = FormatosPDF.PerfilPuesto(puesto.Fila(), coordinaA, PerfilHabilidad.Modelo().Habilidades(idPuesto));
                FrmVisorPDF pdf = new FrmVisorPDF(archivo, "PERFIL " + rol.ToUpper() + " NIVEL " + nivel.ToString());
                pdf.ShowDialog();
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PerfilPuesto perfilModificado = new PerfilPuesto();
            perfilModificado.Cargar(Perfil.Celda("rol").ToString(), Convert.ToInt32(Perfil.Celda("nivel")));

            if (perfilModificado.TieneFilas())
            {
                perfilModificado.Fila().ModificarCelda("plantilla_autorizada", NumericPlantilla.Value);
                perfilModificado.GuardarDatos();
            }
        }

        private void NumericRangoMinimo_ValueChanged(object sender, EventArgs e)
        {
            PerfilPuesto perfilModificado = new PerfilPuesto();
            perfilModificado.Cargar(Perfil.Celda("rol").ToString(), Convert.ToInt32(Perfil.Celda("nivel")));

            if (perfilModificado.TieneFilas())
            {
                perfilModificado.Fila().ModificarCelda("salario_minimo", NumericRangoMinimo.Value);
                perfilModificado.GuardarDatos();
            }
        }

        private void NumericRangoMaximo_ValueChanged(object sender, EventArgs e)
        {
            PerfilPuesto perfilModificado = new PerfilPuesto();
            perfilModificado.Cargar(Perfil.Celda("rol").ToString(), Convert.ToInt32(Perfil.Celda("nivel")));

            if (perfilModificado.TieneFilas())
            {
                perfilModificado.Fila().ModificarCelda("salario_maximo", NumericRangoMaximo.Value);
                perfilModificado.GuardarDatos();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
