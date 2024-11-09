using DVLD_BusinessLayer.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Applications
{
    public partial class frmLDLAL_List : Form
    {
        DataTable dt;
        public frmLDLAL_List()
        {
            InitializeComponent();
            _RefreshLDLA_List();
        }

        
        private void _RefreshLDLA_List()
        {
            dt = cls_LDLA.ListAll_LDLA();
            dgvLDLA_List.DataSource = dt;

            dgvLDLA_List.Columns[0].Width = 100;
            dgvLDLA_List.Columns[0].HeaderText = "LDLA_ID";
            dgvLDLA_List.Columns[1].Width = 250;
            dgvLDLA_List.Columns[2].Width = 100;
            dgvLDLA_List.Columns[3].Width = 250;
            dgvLDLA_List.Columns[4].Width = 150;
            dgvLDLA_List.Columns[5].Width = 99;
            dgvLDLA_List.Columns[6].Width = 100;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewLDLA_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateLDL_Apllication();
            frm.ShowDialog();
        }


    }
}
