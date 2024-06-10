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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        Form from1 = new Form1();
        private void btnShowPart1_Click(object sender, EventArgs e)
        {
            from1.Show();
        }

        Form form2 = new Form1();
        private void ShowForm1AsDialog_Click(object sender, EventArgs e)
        {

            form2.Show();
        }


        private void ClosePart2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Form frorm3 = new frmMessageBox();
        private void btnMessageboxfrm_Click(object sender, EventArgs e)
        {
            frorm3.ShowDialog();
        }


        Form form4 = new frmCheckBox();
        private void btwShowCheckBox_Click(object sender, EventArgs e)
        {
            form4.Show();
        }

        Form form5 = new frmMoreTextBox();
        private void button1_Click(object sender, EventArgs e)
        {
            form5.Show();
        }

        Form form6 = new frmpbox();
        private void btnpbform_Click(object sender, EventArgs e)
        {
            form6.Show();  
        }

        Form form7 = new frmPictureBoxExercise();
        private void btnpbExercise_Click(object sender, EventArgs e)
        {
            form7.Show();
        }

        Form form8 = new frmDrawing();
        private void btnPainting_Click(object sender, EventArgs e)
        {
            form8.Show();
        }

        Form form9 = new frmMtb_lnklbl_Cb();
        private void btnMtb_Cb_lnklbl_Click(object sender, EventArgs e)
        {
            form9.Show();
        }

        Form form10 = new frmCheckedListBox();
        private void btnCheckedListBox_Click(object sender, EventArgs e)
        {
            form10.Show();
        }

        Form form11 = new frmDateTimePicker();
        private void btnDatetimePicker_Click(object sender, EventArgs e)
        {
            form11.Show();
        }

        Form form12 = new frmMonthCalender();
        private void btnMonthCalender_Click(object sender, EventArgs e)
        {
            form12.Show();
        }

        Form form13 =new frmTimer();
        private void btnTimer_Click(object sender, EventArgs e)
        {
            form13.Show();
        }

        Form form14 = new frmTreeView();
        private void btnShowTreeView_Click(object sender, EventArgs e)
        {
            
            form14.Show();
        }


        Form frm15 = new frmProgressBar();
        private void frmProgressBar_Click(object sender, EventArgs e)
        {
            frm15.Show();
        }

        Form frm16 = new frmListView();
        private void btnfrmListView_Click(object sender, EventArgs e)
        {
            frm16.Show();
        }

        Form form17 = new frmErrorProvider();
        private void frmErrorProvider_Click(object sender, EventArgs e)
        {
            form17.Show();   
        }

        Form form18 = new frmTrackBar();
        private void btnfrmTrackBar_Click(object sender, EventArgs e)
        {
            form18.Show();
        }

        Form form19 = new NumericUpDown();
        private void btnfrmNumericUpDown_Click(object sender, EventArgs e)
        {  
            form19.Show();
        }


        Form frm20 = new TabControl();
        private void frmTabControls_Click(object sender, EventArgs e)
        {
 
            frm20.Show();
        }

        Form form21 = new frmPanel();
        private void frmPanel_Click(object sender, EventArgs e)
        {
            form21.ShowDialog();
        }

        Form form22 = new frmDialogs();
        private void btnfrmDialogs_Click(object sender, EventArgs e)
        {
            form22.Show();
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, This is a Practice Project!");
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void ContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form23.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Form form23 = new frmContextMenue();
        private void btnContextMenu_Click(object sender, EventArgs e)
        {
            form23.Show();
        }
    }
}
