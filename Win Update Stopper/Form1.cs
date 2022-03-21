using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Update_Stopper
{
    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;

        public Form1()
        {
            InitializeComponent();

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                ProcessStartInfo info = new ProcessStartInfo((string)Process.GetCurrentProcess().ProcessName + ".exe");
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info);
                var _process = Process.GetCurrentProcess();
                _process.Kill();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var _process = Process.GetCurrentProcess();
            _process.Kill();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo STWUP = new ProcessStartInfo();
                STWUP.FileName = "cmd.exe";
                STWUP.UseShellExecute = true;
                STWUP.WindowStyle = ProcessWindowStyle.Hidden;
                STWUP.Arguments = "/k sc config  \"wuauserv\" start=Disabled";
                Process.Start(STWUP);
                ProcessStartInfo STWUP2 = new ProcessStartInfo();
                STWUP2.FileName = "cmd.exe";
                STWUP2.UseShellExecute = true;
                STWUP2.WindowStyle = ProcessWindowStyle.Hidden;
                STWUP2.Arguments = "/k net stop \"wuauserv\"";
                Process.Start(STWUP2);
            }
            catch
            {
                MessageBox.Show("Error in Win Update Stopper", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Windows Updates has been Stopped", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo RTWUP = new ProcessStartInfo();
                RTWUP.FileName = "cmd.exe";
                RTWUP.UseShellExecute = true;
                RTWUP.WindowStyle = ProcessWindowStyle.Hidden;
                RTWUP.Arguments = "/k sc config  \"wuauserv\" start=demand";
                Process.Start(RTWUP);
                ProcessStartInfo RTWUP2 = new ProcessStartInfo();
                RTWUP2.FileName = "cmd.exe";
                RTWUP2.UseShellExecute = true;
                RTWUP2.WindowStyle = ProcessWindowStyle.Hidden;
                RTWUP2.Arguments = "/k net start \"wuauserv\"";
                Process.Start(RTWUP2);
            }
            catch
            {
                MessageBox.Show("Error in Win Update Stopper", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Windows Updates has been Started", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://instagram.com/hereioz");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/hereioz");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var _process = Process.GetCurrentProcess();
            _process.Kill();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
