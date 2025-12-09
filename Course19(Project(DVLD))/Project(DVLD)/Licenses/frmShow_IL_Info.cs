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
    public partial class frmShow_IL_Info : Form
    {
        private int _DriverID = -1;

        public frmShow_IL_Info(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
            Fill_License_Info();
        }

        public void Fill_License_Info()
        {
            if(!clsInternationalLicenses.IsExistByDriverID(_DriverID))
            {
                MessageBox.Show("Driver Does Not have International Driving License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            ucShow_IL_Info1.LoadInfoByDriverID(_DriverID);
        }

        
    }
}
