using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CountriesBusinessLayer;
using ContactsBusinessLayer;

namespace Contacts_WinForms_
{
    public partial class frmAddContact : Form
    {
        public enum enMode {AddNew = 0, Update = 1};
        private enMode _Mode;

        private int _ContactID;
        private clsContacts _Contact;

        public frmAddContact(int ContactID)
        {
            InitializeComponent();
            
            _ContactID = ContactID;

            if (ContactID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void frmAddContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _FillCountriesList()
        {
            DataTable Countries = clsCountries.ListAllCountries();
            foreach (DataRow Country in Countries.Rows) 
            {
                cbCountry.Items.Add(Country["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _FillCountriesList();
            cbCountry.SelectedIndex = 0;

            if(_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Contact";
                _Contact = new clsContacts();
                return;
            }

            _Contact = clsContacts.Find(_ContactID);            
            if(_Contact == null) 
            {
                MessageBox.Show("Contact Not Found!");
                this.Close();
                return;
            }

            lblTitle.Text = "Edit Contact ID = " + _ContactID;
            lblContactID.Text = _ContactID.ToString();
            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            dtbDateOfBirth.Value = _Contact.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.FindCountryByID(_Contact.CountryID).CountryName);
            txtAddress.Text = _Contact.Address;
            if(_Contact.ImagePath != "")
            {
                pictureBox1.Load(_Contact.ImagePath);
            }

            llRemoveImage.Visible = (_Contact.ImagePath != "");
                
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountries.FindCountryByName(cbCountry.Text).CountryID;

            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.DateOfBirth = dtbDateOfBirth.Value;
            _Contact.CountryID = CountryID;

            if(pictureBox1.ImageLocation != null)
            {
                _Contact.ImagePath = pictureBox1.ImageLocation;
            }
            else
            {
                _Contact.ImagePath = "";
            }

            if (_Contact.Save())
                MessageBox.Show("Data Saved Successfully!");
            else
                MessageBox.Show("Error! Data Not Saved!");

            _Mode = enMode.Update;
            lblTitle.Text = "Edit Contact ID = " + _Contact.ID;
            lblContactID.Text = _Contact.ID.ToString();
            llRemoveImage.Visible = (_Contact.ImagePath != "");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFindImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdFindImage.FilterIndex = 1;
            ofdFindImage.RestoreDirectory = true;

            if (ofdFindImage.ShowDialog() == DialogResult.OK)
            {
                string SelectedFilePath = ofdFindImage.FileName;
                pictureBox1.Load(SelectedFilePath);
            }
            
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            llRemoveImage.Visible = false;
        }


    }
}
