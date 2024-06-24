using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Project_DVLD_
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleTable();
        }

        private void _RefreshPeopleTable()
        {
            dgvPeople.DataSource = clsPerson.GetPeopleList();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog();
        }

        private void btnUpdatePerson_Click(object sender, EventArgs e)
        {
            Form frmUpdatePerson = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frmUpdatePerson.ShowDialog();
        }
    }
}
