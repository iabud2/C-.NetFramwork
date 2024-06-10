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
    public partial class frmCheckedListBox : Form
    {
        public frmCheckedListBox()
        {
            InitializeComponent();
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Item" + (checkedListBox1.Items.Count + 1));
        }

        private void btnShowSelectedItems_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListBox1.CheckedItems.Count; i++) 
            {
                MessageBox.Show(checkedListBox1.CheckedItems[i].ToString());
            }
        }

        private void btnCLoseFrm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckAllItems_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void btnUncheckItems_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if(checkedListBox1.Items.Count == 0)
            {
                return;
            }
            checkedListBox1.Items.RemoveAt((checkedListBox1.Items.Count - 1));
        }
    }
}
