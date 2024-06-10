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
    public partial class frmDrawing : Form
    {
        public frmDrawing()
        {
            InitializeComponent();
        }

        private void frmDrawing_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.FromArgb(255, 0, 0, 0);
            Pen pen = new Pen(Black);
            pen.Width = 5;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Flat;

            e.Graphics.DrawLine(pen, 100, 70, 100, 170);
            e.Graphics.DrawEllipse(pen, 200, 100, 200, 100);
            e.Graphics.DrawRectangle(pen, 100, 200, 100, 100);
        }
    }
}
