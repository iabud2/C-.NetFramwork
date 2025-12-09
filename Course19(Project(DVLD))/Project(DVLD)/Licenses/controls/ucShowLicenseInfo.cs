using DVLD_BusinessLayer;
using DVLD_BusinessLayer.Drivers;
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
    public partial class ucShowLicenseInfo : UserControl
    {
        public ucShowLicenseInfo()
        {
            InitializeComponent();
        }

        private string WrapTextByWords(string text, int maxCharsPerLine)
        {
            string[] words = text.Split(' ');
            List<string> lines = new List<string>();
            string currentLine = "";

            foreach (string word in words)
            {
                if ((currentLine + word).Length > maxCharsPerLine)
                {
                    lines.Add(currentLine.Trim());
                    currentLine = "";
                }

                currentLine += word + " ";
            }

            if (!string.IsNullOrWhiteSpace(currentLine))
                lines.Add(currentLine.Trim());

            return string.Join("\n", lines);
        }

        public void LoadInfoByApplicationID(int ApplicationID)
        {
            clsLicenses license = clsLicenses.GetLicensesInfoByAppID(ApplicationID);
            clsPerson Person = clsPerson.FindPersonByID(license.DriverInfo.PersonID);

            lbLicenseClass.Text = clsLicenseClasses.Find(license.LicenseClassID).ClassName;
            lbName.Text = Person.FullName;
            lbLicenseID.Text = license.LicenseID.ToString();
            lbNational_No.Text = Person.NationalNo;
            
            if (Person.Gendor == 0)
                lbGender.Text = "Female";
            else
                lbGender.Text = "Male";

            lbIssueDate.Text = license.IssueDate.ToString();
            lbIssueReason.Text = WrapTextByWords(license.IssueReason, 50);
            lbExpirationDate.Text = license.ExpirationDate.ToString();
            if (license.Notes != "")
                lbNotes.Text = WrapTextByWords(license.Notes, 50);
            else
                lbNotes.Text = "N/A";
            lbBirthDate.Text =Person.DateOfBirth.ToString();
            lbDriverID.Text = license.DriverID.ToString();
            
            if(license.IsActive)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";

            if (license.isDetained())
                lbIsDetained.Text = "Yes";
            else
                lbIsDetained.Text = "No";

            pbPersonImage.ImageLocation = Person.ImagePath;

        }

        public void LoadInfoByLicenseID(int LicenseID)
        {
            clsLicenses license = clsLicenses.GetLicenseInfo(LicenseID);
            clsPerson Person = clsPerson.FindPersonByID(license.DriverInfo.PersonID);

            lbLicenseClass.Text = clsLicenseClasses.Find(license.LicenseClassID).ClassName;
            lbName.Text = Person.FullName;
            lbLicenseID.Text = license.LicenseID.ToString();
            lbNational_No.Text = Person.NationalNo;

            if (Person.Gendor == 0)
                lbGender.Text = "Female";
            else
                lbGender.Text = "Male";

            lbIssueDate.Text = license.IssueDate.ToString();
            lbIssueReason.Text = WrapTextByWords(license.IssueReason, 50);
            lbExpirationDate.Text = license.ExpirationDate.ToString();

            if(license.Notes != "")
                lbNotes.Text = WrapTextByWords(license.Notes, 50);
            else
                lbNotes.Text = "N/A";
            lbBirthDate.Text = Person.DateOfBirth.ToString();
            lbDriverID.Text = license.DriverID.ToString();

            if (license.IsActive)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";

            if (license.isDetained())
                lbIsDetained.Text = "Yes";
            else
                lbIsDetained.Text = "No";

            pbPersonImage.ImageLocation = Person.ImagePath;

        }


    }
}
