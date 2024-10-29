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
using Project_DVLD_.Properties;
using System.IO;



namespace Project_DVLD_
{
    public partial class ucPersonDetails : UserControl
    {
        private clsPerson _Person;

        private int  _PersonID = -1;
        

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ucPersonDetails()
        {
            InitializeComponent();
        }

        public ucPersonDetails(int _PersonID)
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Resources.defaultfemale;
            else
                pbPersonImage.Image = Resources.defaultMale;
            
            string ImagePath = _Person.ImagePath;
            if(ImagePath != "") 
            {
                if(File.Exists(ImagePath))
                {
                    pbPersonImage.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Could Not Find This Image : " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _FillPersonInfo()
        {
            llbEditPerson.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _PersonID.ToString();
            lblFullName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblGendor.Text = _Person.Gendor == 0 ? "Female" : "Male";
         
            if (_Person.Gendor == 0)
            {
                lblGendor.Text = "Female";
                lblGendorTitle.Image = Resources.woman_avatar;
            }
            else
            {
                lblGendor.Text = "Male";
                lblGendorTitle.Image = Resources.male_user;
            }

            lblCountry.Text = clsCountries.Find(_Person.NationalityContryID).CountryName;
            _LoadPersonImage();
        }

        public void LoadPersonData(int PersonID)
        {
            _Person = clsPerson.FindPersonByID(PersonID);
            if(_Person == null) 
            {
                MessageBox.Show("Couldn't Found Person With PersonID :" + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonData(string NationalNo)
        {
            _Person = clsPerson.FindPersonByNationalityNo(NationalNo);
            if(_Person == null)
            {
                MessageBox.Show("Couldn't Found Person With National No.: " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "????";
            lblNationalNo.Text = "????";
            lblFullName.Text = "????";
            lblFullName.Text = "????";
            lblCountry.Text = "????";
            pbPersonImage.Image = Resources.defaultMale;
            lblGendorTitle.Image = Resources.defaultMale;
            lblGendor.Text = "????";
            lblDateOfBirth.Text = "????";
            lblAddress.Text = "????";
            lblPhone.Text = "????";
            lblEmail.Text = "????";
        }



        private void llbEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmAddUpdatePerson(_Person.PersonID);
            frm.ShowDialog();
        }

        private void ucPersonDetails_Load(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                llbEditPerson.Enabled = false;
            }
            else
            {
                llbEditPerson.Enabled = true;
            }
        }
    }
}
