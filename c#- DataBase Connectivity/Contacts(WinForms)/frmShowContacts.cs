using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsBusinessLayer;

namespace Contacts_WinForms_
{
    public partial class frmShowContacts : Form
    {

        public frmShowContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContacts()
        {
            dgvAllContacts.DataSource = clsContacts.GetAallContacts();
        }

        private void frmShowContacts_Load(object sender, EventArgs e)
        {
            _RefreshContacts();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Form frm1 = new frmAddContact(-1);
            frm1.ShowDialog();
            _RefreshContacts();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddContact frm1 = new frmAddContact((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            frm1.ShowDialog();
            _RefreshContacts();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete contact?", "DeleteContact", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(clsContacts.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully");
                    _RefreshContacts();
                }
                else
                {
                    MessageBox.Show("Contact Not Deleted");
                }
            }
        }


    }
}
