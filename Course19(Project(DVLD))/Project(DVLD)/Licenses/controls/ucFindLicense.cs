using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer.Licenses;

namespace Project_DVLD_.Controls
{
    public partial class ucFindLicense: UserControl
    {

        public int LicenseID = -1;
        public clsLicenses LicenseInfo = new clsLicenses();

        public ucFindLicense()
        {
            InitializeComponent();
        }


        public event Action<int> OnLicenseSelected;
        
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if(handler != null)
            {
                handler(LicenseID);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtLicenseID.Text == "")
                return;
            LicenseID = Convert.ToInt32(txtLicenseID.Text);
            if(!clsLicenses.IsExists(LicenseID))
            {
                MessageBox.Show($"There is No Active License With LicenseID:{LicenseID} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LicenseInfo = clsLicenses.GetLicenseInfo(LicenseID);

            if(LicenseInfo.LicenseClassID != 13)
            {
                MessageBox.Show($"Driver Must Have Ordinary driving License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucShowLicenseInfo1.LoadInfoByLicenseID(int.Parse(txtLicenseID.Text));
            if(OnLicenseSelected != null)
            {
                LicenseSelected(LicenseID);
            }
            
        }

        public void FillData(int _LicenseID)
        {
            this.LicenseID = _LicenseID;
            this.LicenseInfo = clsLicenses.GetLicenseInfo(this.LicenseID);
            btnSearch.Enabled = false;
            txtLicenseID.Text = LicenseID.ToString();
            txtLicenseID.ReadOnly = true;
            ucShowLicenseInfo1.LoadInfoByLicenseID(this.LicenseID);
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        public void ActiveSearch(bool Status)
        {
            txtLicenseID.Enabled = Status;
            btnSearch.Enabled = Status;
        }
    }
}
