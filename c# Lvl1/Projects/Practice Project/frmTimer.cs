using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class frmTimer : Form
    {
        int Counter = 0;
        public frmTimer()
        {
            InitializeComponent();
        }

        private void Notify()
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Timer!";
            notifyIcon1.BalloonTipText = Counter.ToString() + " Seconds";
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Counter++;
            label1.Text = Counter.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Notify();
        }

        private void btnResetTimer_Click(object sender, EventArgs e)
        {
            Counter = 0;
            label1.Text = Counter.ToString();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Ballon Tip Clicked!");
        }
    }
}
