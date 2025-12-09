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
using DVLD_BusinessLayer.Drivers;
namespace Project_DVLD_.Licenses
{
    public partial class frmShowLicenseHistory : Form
    {
        private int _DriverID = -1;
        public frmShowLicenseHistory(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
            LoadInfo();
        }

        private void LoadInfo()
        {
            clsDrivers Driver1 = clsDrivers.GetDriverInfo(_DriverID);
            ucPersonDetails1.LoadPersonData(Driver1.PersonID);
            
            
            
            ucLicensesHistory1.LoadLicensesHistory(_DriverID);
        }
    }
}
