using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using CB_Base.Classes;

namespace CB
{
    static class Program
    {
        static bool ProgramaCorriendo = false;
        static void Notifica()
        {
            while (ProgramaCorriendo)
            {   
                if( !Global.UsuarioActual.TieneFilas())
                    continue;
                 
                Notificaciones.NotificarEventos();

                Stopwatch stp = new Stopwatch();
                stp.Start();
                do { }
                while (ProgramaCorriendo && stp.Elapsed.Minutes < 1);
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread newThread = new Thread(Program.Notifica);
            newThread.Start();

            ProgramaCorriendo = true;
            // Application.Run(new FrmGaleria());
            Application.Run(new FrmLogin());
            ProgramaCorriendo = false;
        }
    }
}