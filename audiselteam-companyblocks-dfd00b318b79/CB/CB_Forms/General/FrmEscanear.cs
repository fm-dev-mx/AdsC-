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
    public enum TipoEscaneo 
    {
        PlanoMecanico,
        IdEmpleado
    };

    public partial class FrmEscanear : Form
    {
        public string TextoEscaneado = string.Empty;
        public Enum Escaneo;
        int Counter = 30;
        Timer TimerMostrarBtnSalir = new Timer();

        public FrmEscanear(TipoEscaneo tipoEscaneo)
        {
            InitializeComponent();
            Escaneo = tipoEscaneo;
        }

        private void FrmEscanear_Load(object sender, EventArgs e)
        {
            TxtEscaner.Focus();
            if(Escaneo.ToString() == TipoEscaneo.IdEmpleado.ToString())
                LblInstrucciones.Text = "ESCANEA TU GAFETE PARA CONTINUAR...";
            else
                LblInstrucciones.Text = "ESCANEA EL CODIGO DEL PLANO PARA CONTINUAR...";
        }

        private void TxtEscaner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && TxtEscaner.Text != "" )//&& TxtEscaner.Text != "0")
            {
                TextoEscaneado = TxtEscaner.Text;
                if (Escaneo.ToString() == TipoEscaneo.IdEmpleado.ToString())
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;                    
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.Yes;
                    MessageBox.Show("Plano escaneado correctamente, prepare su gafete para ser escaneado", "Plano escaneado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            FrmIngresarContrasena pswd = new FrmIngresarContrasena();
            if (pswd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
                Close();
            }
            else
            {
                ActiveControl = TxtEscaner;
                TxtEscaner.Focus();
            }
        }

        private void TxtEscaner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))//) && TxtEscaner.Text !="") //&& TxtEscaner.Text != "0")
                e.Handled = true;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (BtnSalir.Visible)
                    return;

                BtnSalir.Visible = true;
                Counter = 30;
                TimerMostrarBtnSalir.Tick += new EventHandler(TimerMostrarBtnSalir_Tick);
                TimerMostrarBtnSalir.Interval = 1000;
                TimerMostrarBtnSalir.Start();
                
            }
        }

        private void TimerMostrarBtnSalir_Tick(object sender, EventArgs e)
        {
            Counter--;
            if (Counter == 0)
            {
                TimerMostrarBtnSalir.Stop();
                TimerMostrarBtnSalir.Tick -= TimerMostrarBtnSalir_Tick;
                TimerMostrarBtnSalir.Dispose();
                BtnSalir.Visible = false;
                ActiveControl = TxtEscaner;
                TxtEscaner.Focus();
            }
        }

        private void FrmEscanear_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerMostrarBtnSalir.Stop();
            TimerMostrarBtnSalir.Tick -= TimerMostrarBtnSalir_Tick;
            TimerMostrarBtnSalir.Dispose();
        }
    }
}
