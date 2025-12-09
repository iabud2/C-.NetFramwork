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
    public partial class ucLicensesHistory : UserControl
    {
        public ucLicensesHistory()
        {
            InitializeComponent();
        }

        public void LoadLicensesHistory(int DriverID)
        {
            DataTable LocalLicenses = clsLicenses.GetLicensesListForDriverID(DriverID);
            if (LocalLicenses.Rows.Count > 0)
            {
                dgvLocalLicenses.DataSource = LocalLicenses;
                dgvLocalLicenses.Columns[0].Width = 100;
                dgvLocalLicenses.Columns[1].Width = 100;
                dgvLocalLicenses.Columns[2].Width = 250;
                dgvLocalLicenses.Columns[3].Width = 200;
                dgvLocalLicenses.Columns[4].Width = 200;
                dgvLocalLicenses.Columns[5].Width = 105;
            }
            
            
            DataTable InternationalLicenses = clsInternationalLicenses.ListInternationalLicensesForDriverID(DriverID);
            if (InternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.DataSource = InternationalLicenses;
                dgvInternationalLicenses.Columns[0].Width = 165;
                dgvInternationalLicenses.Columns[1].Width = 100;
                dgvInternationalLicenses.Columns[2].Width = 180;
                dgvInternationalLicenses.Columns[3].Width = 200;
                dgvInternationalLicenses.Columns[4].Width = 200;
                dgvInternationalLicenses.Columns[5].Width = 105;
            }


        }
    }
}
