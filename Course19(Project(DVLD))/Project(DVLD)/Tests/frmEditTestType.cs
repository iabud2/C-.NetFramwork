using DVLD_BusinessLayer.GeneralClasses;
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
    public partial class frmEditTestType : Form
    {

        private int _TestID = -1;
        clsTestTypes Type;
        public frmEditTestType(int ID)
        {
            InitializeComponent();
            _TestID = ID;
            _LoadTestTypeInfo();
        }

        public void _LoadTestTypeInfo()
        {
            Type = clsTestTypes.GetTestTypeInfo(_TestID);
            if(Type == null)
            {
                MessageBox.Show("Some thing Happened Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbID.Text = Type.ID.ToString();
            txtTitle.Text = Type.Title;
            txtDescription.Text = Type.Description;
            txtFees.Text = Type.Fees.ToString();

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
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "this field cannot be blank!");
                return;
            }
            else
                errorProvider1.SetError(txtTitle, null);

            if (!clsValidations.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Value");
            }
            else
                errorProvider1.SetError(txtFees, null);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Title Cannot be blank!");
            }
            else
                errorProvider1.SetError(txtDescription, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Not Valid Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Type.Title = txtTitle.Text.Trim();
            Type.Description = txtDescription.Text.Trim();
            Type.Fees = Convert.ToSingle(txtFees.Text.Trim());

            if(Type.Save())
            {
                    MessageBox.Show("Saved Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Enabled = false;
                txtDescription.Enabled = false;
                txtFees.Enabled = false;

                txtTitle.Text = Type.Title;
                txtDescription.Text = Type.Description;
                txtFees.Text = Type.Fees.ToString();
            }
            else
            {
                MessageBox.Show("Save Faild!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtTitle.Enabled = true;
            txtDescription.Enabled = true;
            txtFees.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
