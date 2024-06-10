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
    public partial class frmListView : Form
    {
        public frmListView()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtName.Text))
                return;

            ListViewItem item = new ListViewItem(txtID.Text.Trim());
            if(rbMale.Checked)
                { item.ImageIndex = 0; }
            else
                { item.ImageIndex = 1; }

            item.SubItems.Add(txtName.Text.Trim());
            listView1.Items.Add(item);


            txtID.Clear();
            txtName.Clear();
            txtID.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void btnDetails_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void btnTile_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
        }

        private void btnList_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void btnLargeIcons_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void btnSmallIcons_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void btnFillRandom_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                ListViewItem item= new ListViewItem(i.ToString());
                item.SubItems.Add("Person" + i);
                if(i > 5)
                {
                    item.ImageIndex = 1;
                }
                else
                {
                    item.ImageIndex = 0;
                }

                listView1.Items.Add(item);
            }
        }
    }
}
