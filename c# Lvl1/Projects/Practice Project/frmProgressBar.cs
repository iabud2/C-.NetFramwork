using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class frmProgressBar : Form
    {

        public frmProgressBar()
        {
            InitializeComponent();
        }
        
        private void Notifity()
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Complete!";
            notifyIcon1.BalloonTipText = "Progress Complete!";
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void StartProgress()
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                btnStart.Enabled = false;
                return;
            }

            while (progressBar1.Value < progressBar1.Maximum)
            {
                Thread.Sleep(100);
                progressBar1.Value += 5;
                label1.Text = ("Progress :" + progressBar1.Value + "%");
                progressBar1.Refresh();
                label1.Refresh();
            }
            btnStart.Enabled = false;
            Notifity();
        }

        private void Reset()
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            btnStart.Enabled = true;
            label1.Text = "Progress: " + 0 + "%";
            progressBar1.Refresh();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartProgress();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
