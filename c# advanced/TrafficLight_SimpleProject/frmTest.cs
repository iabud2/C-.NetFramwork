using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLight_SimpleProject
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
             _= traffic1.Start();
             _= traffic2.Start();
             _= traffic4.Start();
             _= traffic3.Start();
            btnStart.Visible = false;
            btnStop.Visible = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            traffic1.Stop();
            traffic2.Stop();
            traffic3.Stop();
            traffic4.Stop();
            btnStop.Visible=false;
            btnStart.Visible=true;  
        }
    }

}
