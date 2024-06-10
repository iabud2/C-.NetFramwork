using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class frmDateTimePicker : Form
    {
        public frmDateTimePicker()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lblShowDateTime.Text = dateTimePicker1.Text + Environment.NewLine;
            lblShowDateTime.Text += dateTimePicker1.Value.ToString("dd-MMM-yyyy") + Environment.NewLine;
            lblShowDateTime.Text += dateTimePicker1.Value.ToString("dddd-MMM-yyyy") + Environment.NewLine;
            lblShowDateTime.Text += dateTimePicker1.Value.ToString("dd/MM/yy") + Environment.NewLine;
            lblShowDateTime.Text += dateTimePicker1.Value.ToString("MM-dd-yyyy") + Environment.NewLine;
            lblShowDateTime.Text += dateTimePicker1.Value.ToString("dddd, dd-MM-yyyy");

        }

        private void btnLongFormat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToLongDateString());
        }

        private void btnShortFormat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
        }

        private void btnShowLocalTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToLocalTime().ToString());
        }
    }
}
