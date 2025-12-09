using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Tests
{
    public partial class frmScheduleTest : Form
    {
        int _LDLA_ID = -1;
        clsTestTypes.enTestType _TestType;
       
        public frmScheduleTest(int ldla_ID, clsTestTypes.enTestType testType)
        {
            _LDLA_ID = ldla_ID;
            _TestType = testType;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            ucScheduleAppointment1.TestType = _TestType;
            ucScheduleAppointment1.LoadInfo(_LDLA_ID);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
