using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using CB_Base.CB_Classes;

namespace CB_Base.CB_Controles
{
    public partial class AudiselNotification : UserControl
    {
        int IdNotificacion = 0;
        string Fecha = "";
        string Contenido = "";
        string Titulo = "";
        Control ControlPadre = null;

        public AudiselNotification()
        { }

        public AudiselNotification(string fecha, string contenido, string titulo, int idNotificacion)
        {
            InitializeComponent();
            Fecha = fecha;
            Contenido = contenido;
            Titulo = titulo;
            IdNotificacion = idNotificacion;
        }

        private void AudiselNotification_Load(object sender, EventArgs e)
        {
            LblFecha.Text = Fecha;
            LblContenido.Text = Contenido;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(GlobalPaths.PathUtilidades))
            {
                Directory.CreateDirectory(GlobalPaths.PathUtilidades);
            }

            if (!File.Exists(GlobalPaths.PathUtilidades + GlobalPaths.ArchivoNotificacionesExcluidas))
            {
                File.Create(GlobalPaths.PathUtilidades + GlobalPaths.ArchivoNotificacionesExcluidas);
            }

            using (System.IO.StreamWriter file = File.AppendText(GlobalPaths.PathUtilidades + GlobalPaths.ArchivoNotificacionesExcluidas))
            {
                file.WriteLine(IdNotificacion.ToString());
            }

            if (this.Parent != null)
                this.Parent.Controls.Remove(this);
        }
    }
}
