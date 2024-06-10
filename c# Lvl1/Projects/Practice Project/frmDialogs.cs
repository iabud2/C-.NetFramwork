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
    public partial class frmDialogs : Form
    {
        public frmDialogs()
        {
            InitializeComponent();
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK) 
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
            }    
        }

        private void btnTabColor_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog(this) == DialogResult.OK) 
            {
                tabPage1.BackColor = colorDialog1.Color;
            }
        }

        private void btnFormColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowApply = true;
            fontDialog1.ShowHelp = true;
            fontDialog1.ShowEffects = true;
            fontDialog1.ShowColor = true;

            fontDialog1.Font = lblTest.Font;
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                lblTest.Font = fontDialog1.Font;
                lblTest.ForeColor = fontDialog1.Color;
            }

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            lblTest.Font = fontDialog1.Font;
            lblTest.ForeColor = fontDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Practice Project";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*|Images (*.jpeg)|*.JPEG";
            saveFileDialog1.FilterIndex = 3;


            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("File '" + saveFileDialog1.FileName + "' saved Successfully");
                txtFileName.Text = saveFileDialog1.FileName;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Practice Project";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*|Images (*.jpeg)|*.JPEG";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOpenFile.Text = openFileDialog1.FileName;
                MessageBox.Show(openFileDialog1.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt file (*.txt)|*.txt|all files (*.*)|*.*|Images (*.jpeg)|*.JPEG";
            openFileDialog1.Multiselect = true;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                byte Counter = 1;
                foreach (string name in openFileDialog1.FileNames) 
                {

                    MessageBox.Show(name, "File" + Counter);
                    Counter++;
                }
            }
        }

        private void btnFolderBrowsing_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = folderBrowserDialog1.SelectedPath;   
            }
        }
    }
}
