using CompoboxExercise.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompoboxExercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChangePicture()
        {
            switch (cbChangePicture.SelectedIndex)
            {
                case 0:
                    pbPicture.Image = Resources.Boy;
                    break;
                case 1:
                    pbPicture.Image = Resources.Girl;
                    break;
                case 2:
                    pbPicture.Image= Resources.Pen;
                    break;
                case 3:
                    pbPicture.Image = Resources.Book;
                    break;
            }
        }

        private void cbChangePicture_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePicture();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbChangePicture.SelectedIndex = 0;
        }
    }
}
