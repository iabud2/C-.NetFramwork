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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Text = "Practice Project";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label3.Text = "Mohammed Abu-Hadhoud";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void btnClosePart1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
