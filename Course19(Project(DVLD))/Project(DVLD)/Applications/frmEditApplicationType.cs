using DVLD_BusinessLayer.Application;
using DVLD_BusinessLayer.GeneralClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Applications
{
    public partial class frmEditApplicationTYpe : Form
    {

        private int _ID = -1;
        private clsApplicationTypes _Type;

        public frmEditApplicationTYpe(int ApplicationTypeID)
        {
            InitializeComponent();
            _ID = ApplicationTypeID;
            _LoadApplicationTypeInfo();
        }

        private void _LoadApplicationTypeInfo()
        {
            _Type = clsApplicationTypes.GetApplicationTypeInfo(this._ID);
            if (_Type == null) 
            {
                this.Close();
                return;
            }
            lbID.Text = _Type.ApplicationID.ToString();
            txtTitle.Text = _Type.ApplicationName;
            txtFees.Text = _Type.ApplicationFees.ToString();
            
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title Cannot be blank!");
            }
            else
                errorProvider1.SetError(txtTitle, null);

        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this field cannot be blank!");
                return;
            }
            else
                errorProvider1.SetError(txtTitle, null);
            
            if(!clsValidations.IsNumber(txtFees.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtFees, "Invalid Value");
            }
            else
                errorProvider1.SetError(txtFees, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields are not valid, Make sure u entered valid Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Type.ApplicationName = txtTitle.Text.Trim();
            _Type.ApplicationFees = Convert.ToSingle(txtFees.Text.Trim());

            if(_Type.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Text = _Type.ApplicationName;
                txtFees.Text = _Type.ApplicationFees.ToString();
                txtTitle.Enabled = true;
                txtFees.Enabled = true;
            }
            else
            {
                MessageBox.Show("Data Doesn't Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void lblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtTitle.Enabled = true;
            txtFees.Enabled = true;
        }
    }
}
