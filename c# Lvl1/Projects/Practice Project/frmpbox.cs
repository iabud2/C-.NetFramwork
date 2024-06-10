using Project1.Properties;
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
    public partial class frmpbox : Form
    {
        public frmpbox()
        {
            InitializeComponent();
        }

        private void btnApple_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.Apple;
        }

        private void btnBanana_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.Banana;
        }

        private void ImageFromFile_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\iabud\Downloads\Person.jpeg");
        }
    }
}
