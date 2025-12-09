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
    public partial class frmListAppointments : Form
    {
        private int _LDLA_ID = -1;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        DataTable dt_Appointments;
    
        public frmListAppointments(int ldla_ID, clsTestTypes.enTestType testType)
        {
            InitializeComponent();
            _LDLA_ID = ldla_ID;
            _TestType = testType;
            
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshAppointmentsTable()
        {
            dt_Appointments = clsTestsAppointments.GetAppointmentsListPerTestTypeForLDLA(_LDLA_ID, _TestType);

            if (dt_Appointments.Rows.Count > 0)
            {
                dgvAppointmentsList.DataSource = dt_Appointments;
                dgvAppointmentsList.Columns[0].Width = 100;
                dgvAppointmentsList.Columns[1].Width = 200;
                dgvAppointmentsList.Columns[2].Width = 100;
                dgvAppointmentsList.Columns[3].Width = 100;
                lbRecords.Text = dgvAppointmentsList.Rows.Count.ToString() + " Record(s)";
            }
            else
                lbRecords.Text = "No Appointments Listed Yet";
        }

        private void _LoadApplicationInfo()
        {
            lbTitle.Text = clsTestTypes.GetTestTypeInfo(_TestType).Title;
            ucShowApplicationInfo1.LoadInfo(_LDLA_ID);
            _RefreshAppointmentsTable();
        }

        private void frmListAppointments_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (cls_LDLA.DoesPassTestType(_LDLA_ID, _TestType))
            {
                MessageBox.Show("You Already Finish This Test, You Cannot Retake it!", "Test Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form frm = new frmScheduleTest(_LDLA_ID, _TestType);
            frm.ShowDialog();
            _RefreshAppointmentsTable();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTakeTest((int)dgvAppointmentsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAppointmentsTable();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmShowTestInfo((int)dgvAppointmentsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
