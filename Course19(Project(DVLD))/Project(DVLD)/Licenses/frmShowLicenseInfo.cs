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

namespace Project_DVLD_.Licenses
{
    public partial class frmShowLicenseInfo : Form
    {
        private int _ApplicationID;
        public frmShowLicenseInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
            LoadLicenseInfo();
        }

        private void  LoadLicenseInfo()
        {
            if (!clsLicenses.isExists_By_AppID(_ApplicationID))
            {
                MessageBox.Show("License Not Found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            clsLicenses License = clsLicenses.GetLicensesInfoByAppID(_ApplicationID);
            ucShowLicenseInfo1.LoadInfoByLicenseID(License.LicenseID);
        }
    }
}
