using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;


namespace Project_DVLD_.Controls
{
    public partial class ucFindPerson : UserControl
    {

        private int _PersonID = -1;

        public event Action<int> OnPersonSelected;

        protected virtual void PersonFound(int PersonID)
        {
            Action<int> PersonSelected = OnPersonSelected;
            if (PersonSelected != null)
            {
                PersonSelected(PersonID);
            }
        }


        public int PersonID
        {
            get { return ucPersonDetails1.PersonID; }
        }

        public ucFindPerson()
        {
            InitializeComponent();
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ucPersonDetails1.SelectedPersonInfo; }
        }

        private void Search()
        {
            switch (cbFilterBy.Text) 
            {
                case "PersonID":
                    int CheckedID = 0;
                    if (int.TryParse(tbSearch.Text.Trim(), out CheckedID))
                    {
                        ucPersonDetails1.LoadPersonData(CheckedID);
                    }
                    else
                    {
                        MessageBox.Show("Person ID Must Be a Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider1.SetError(tbSearch, "Make Sure You Filled this field and Person ID is Valid!");
                        return;
                    }
                    break;
                case "NationalNo":
                    if (string.IsNullOrEmpty(tbSearch.Text.Trim()))
                    {
                        MessageBox.Show("Make Sure You Enter The National No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider1.SetError(tbSearch, "Make Sure You Filled this field and National No. is Valid!");
                        return;
                    }
                    else
                    {
                        ucPersonDetails1.LoadPersonData(tbSearch.Text.Trim());
                    }
                    break;
            }

            if (OnPersonSelected != null)
                OnPersonSelected(ucPersonDetails1.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {
            ucPersonDetails1.LoadPersonData(PersonID);
            tbSearch.Enabled = false;
            cbFilterBy.Enabled = false;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearch.Clear();
            tbSearch.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        public void DataBackEvent(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            tbSearch.Text = PersonID.ToString();
            ucPersonDetails1.LoadPersonData(PersonID);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            frm.DataBack += DataBackEvent;
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "PersonID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private bool _FilterEnabled = true;
        
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }

            set 
            { 
                _FilterEnabled = value;
                cbFilterBy.Enabled = _FilterEnabled;    
            }
        }

    }

}
