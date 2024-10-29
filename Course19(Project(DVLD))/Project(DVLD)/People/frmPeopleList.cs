using DVLD_BusinessLayer;
using Project_DVLD_.People;
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
    public partial class frmPeopleList : Form
    {
        private static DataTable _dtPeopleList = clsPerson.GetPeopleList();

        DataTable _People = _dtPeopleList.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                                            "LastName", "DateOfBirth", "GendorCaption", "Address", "Phone", "Email", "CountryName"); 



        public frmPeopleList()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleTable();
            cbFilterBy.SelectedIndex = 0;
        }

        private void _RefreshPeopleTable()
        {
            _dtPeopleList = clsPerson.GetPeopleList();
            _People = _dtPeopleList.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName",
                                            "LastName", "DateOfBirth", "GendorCaption", "Address", "Phone", "Email", "CountryName");
            
            dgvPeopleList.DataSource = _People;
            lblPeopleCount.Text = _People.Rows.Count.ToString() + " Record(s)";
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddUpdatePerson();
            frmAddPerson.ShowDialog();
            _RefreshPeopleTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNew_Click(sender, e);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmUpdatePerson = new frmAddUpdatePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frmUpdatePerson.ShowDialog();
            _RefreshPeopleTable();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("are you sure you want to delete this record?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(clsPerson.DeletePerson((int)dgvPeopleList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Record Deleted Successfully", "Delete Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleTable();
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Visible = (cbFilterBy.Text != "None");
            lbSearch.Visible = (cbFilterBy.Text != "None");

            if(tbSearch.Visible)
            {
                tbSearch.Text = string.Empty;
                tbSearch.Focus();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilterBy.Text)
            {
                case "None":
                    FilterColumn = "";
                    break;

                case "PersonID":
                    FilterColumn = "PersonID";
                    break;
                
                case "NationalNo":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Country":
                    FilterColumn = "CountryName";
                    break;
            }

            if(cbFilterBy.Text == "None" || tbSearch.Text.Trim() == "")
            {
                _People.DefaultView.RowFilter = "";
                return;
            }

            if(FilterColumn == "PersonID")
            {
                _People.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbSearch.Text.Trim());
            }
            else
            {
                _People.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbSearch.Text.Trim());
            }

                
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "PersonID")
            {
                e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
            }
        }

        private void dgvPeopleList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form form = new frmShowPersonDetails((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            form.ShowDialog();
            _RefreshPeopleTable();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowPersonDetails((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }


    }
}
