using DVLD_BusinessLayer;
using Project_DVLD_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_BusinessLayer.GeneralClasses;


namespace Project_DVLD_
{
    public partial class frmAddUpdatePerson : Form
    {
        enum enMode {AddNew = 0, Update = 1}
        enum enGendor { Female = 0, Male = 1 }
        enMode Mode;
        private int _PersonID = -1;
        clsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            _Person = new clsPerson();
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _PersonID = PersonID;
        }


        private void _ResetForm()
        {
            _FillCountriesInComboBox();

            if(Mode == enMode.AddNew)
            {
                lbTitle.Text = "Add New Person";
            }
            else
            {
                lbTitle.Text = "Update Person";
            }


            btnRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            cbCountries.SelectedIndex = cbCountries.FindString("Palestine");

            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbNationalNo.Text = "";
            rbMale.Checked = true;
            tbPhone.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";
        }

        private void _FillCountriesInComboBox()
        {
            DataTable countries = clsCountries.GetAllCountries();

            foreach(DataRow row in countries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
        }

        private void _LoadPersonData()
        {
            _Person = clsPerson.FindPersonByID(_PersonID);

            if(_Person == null)
            {
                MessageBox.Show($"Person With PersonID: {_PersonID} Not Found!");
                this.Close();
                return;
            }

            //Personal Info:
            lblPersonID.Text = _Person.PersonID.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNo.Text = _Person.NationalNo;

            if (_Person.Gendor == 1)
            {
                rbMale.Checked = true;
                pbPersonImage.Image = Resources.defaultMale;
            }
            else
            {
                rbFemale.Checked = true;
                pbPersonImage.Image = Resources.defaultfemale;
            }

            dtpDateOfBirth.Value = _Person.DateOfBirth;

            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            tbAddress.Text = _Person.Address;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);

            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            btnRemoveImage.Visible = (_Person.ImagePath != "" && _Person.ImagePath != null);
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetForm();

            if (Mode == enMode.Update)
                _LoadPersonData();
        }

        private bool ManagePersonImage()
        {
            if(_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch(IOException ex)
                    {
                        //Handle the Erros as u like in case file doesn't deleted.
                    }


                }

                if(pbPersonImage.ImageLocation != null)
                {
                    string ImageSourceFile = pbPersonImage.ImageLocation.ToString();
                
                    if(clsUtil.CopyImageToProjectImagesFolder(ref ImageSourceFile)) 
                    {
                        pbPersonImage.ImageLocation = ImageSourceFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error: faild to copy image file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid, make sure all data is valid, check the red icon(s) to see the error", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ManagePersonImage())
                return;
            //--------------
            //if all fileds is valid:

            int NationalityCountryID = clsCountries.Find(cbCountries.Text).ID;

            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Address = tbAddress.Text.Trim();
            _Person.Phone = tbPhone.Text.Trim();
            _Person.Email = tbEmail.Text.Trim();

            if(rbMale.Checked)
            {
                _Person.Gendor = (int)enGendor.Male;
            }
            else
            {
                _Person.Gendor =(int)enGendor.Female;
            }

            _Person.NationalityContryID = NationalityCountryID;

            if(pbPersonImage.ImageLocation != null) 
            {
                _Person.ImagePath = pbPersonImage.ImageLocation.ToString();
            }
            else
            {
                _Person.ImagePath = "";
            }

            if(_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                Mode = enMode.Update;
                lbTitle.Text = "Update Person";
                MessageBox.Show("Person Added Successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Person Doesn't Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtEmailValidation(object sender, CancelEventArgs e)
        {
            if (tbEmail.Text.Trim() == "")
                return;

            if(!clsValidations.ValidateEmail(tbEmail.Text)) 
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "InvalidEmailAddress");
            }
            else
            {
                errorProvider1.SetError(tbEmail, null);
            }
        }

        //----------------------
        private void tbNationalNoValidation(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNo, "Required Field!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, null);
            }
            //tbNationalNo.Text.Trim() != _Person.NationalNo && 
            if (tbNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNo, "National Number used for another person!");
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, null);
            }
        }

        //------------------------------
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.defaultMale;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.defaultfemale;
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbMale.Checked)
                pbPersonImage.Image = Resources.defaultMale;
            else
                pbPersonImage.Image = Resources.defaultfemale;

            btnRemoveImage.Visible = false;
        }

        private void btnSetImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "ImageFiles|*.jpeg;*.jpg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                string SelectedImageFile = openFileDialog1.FileName;
                pbPersonImage.Load(SelectedImageFile);
                btnRemoveImage.Visible =true;
            }
        }

        private void EmptyTextBoxValidation(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            if(string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "Required Field!");
            }
            else
            {
                errorProvider1.SetError(Temp, null);
            }
        }
    }
}
