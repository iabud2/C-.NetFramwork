using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Controls
{
    public partial class ucShow_IL_Info : UserControl
    {

        public int IL_ID = -1;
        public int DriverID = -1;
        public clsInternationalLicenses InternationalLicenseInfo = new clsInternationalLicenses();

        public ucShow_IL_Info()
        {
            InitializeComponent();
        }
        
        public void LoadInfo(int InternationalLicenseID)
        {
            IL_ID = InternationalLicenseID;
            InternationalLicenseInfo = clsInternationalLicenses.GetInternationalLicenseInfo(IL_ID);

            lbName.Text = InternationalLicenseInfo.PersonFullName;
            lbNational_No.Text = clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).NationalNo;
            if (clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).Gendor == 1)
                lbGender.Text = "Male";
            else
                lbGender.Text = "Female";

            lbBirthDate.Text = clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).DateOfBirth.ToString();
            lbIssueDate.Text = InternationalLicenseInfo.IssueDate.ToString();
            lbExpirationDate.Text = InternationalLicenseInfo.ExpirationDate.ToString();
            lbDriverID.Text = InternationalLicenseInfo.DriverID.ToString();
            lbIntLicenseID.Text = IL_ID.ToString();
            lbLocalLicenseID.Text = InternationalLicenseInfo.LocalLicenseID.ToString();
            lbApplicationID.Text = InternationalLicenseInfo.ApplicationID.ToString();

            if (InternationalLicenseInfo.IsActive)
                lbIsAcitve.Text = "Yes";
            else
                lbIsAcitve.Text = "No";
            
            pbPersonImage.ImageLocation = clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).ImagePath;

        }

        public void LoadInfoByDriverID(int driverID)
        {
            DriverID = driverID;
            InternationalLicenseInfo = clsInternationalLicenses.GetInternationalLicenseInfoByDriverID(DriverID);
            IL_ID = InternationalLicenseInfo.InternationalLicenseID;

            lbName.Text = InternationalLicenseInfo.PersonFullName;
            lbNational_No.Text = clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).NationalNo;
            if (clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).Gendor == 1)
                lbGender.Text = "Male";
            else
                lbGender.Text = "Female";

            lbBirthDate.Text = clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).DateOfBirth.ToString();
            lbIssueDate.Text = InternationalLicenseInfo.IssueDate.ToString();
            lbExpirationDate.Text = InternationalLicenseInfo.ExpirationDate.ToString();
            lbDriverID.Text = DriverID.ToString();
            lbIntLicenseID.Text = IL_ID.ToString();
            lbLocalLicenseID.Text = InternationalLicenseInfo.LocalLicenseID.ToString();
            lbApplicationID.Text = InternationalLicenseInfo.ApplicationID.ToString();

            if (InternationalLicenseInfo.IsActive)
                lbIsAcitve.Text = "Yes";
            else
                lbIsAcitve.Text = "No";

            pbPersonImage.ImageLocation = clsPerson.FindPersonByID(InternationalLicenseInfo.PersonID).ImagePath;

        }

    }
}
