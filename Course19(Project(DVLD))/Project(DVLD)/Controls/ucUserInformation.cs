using DVLD_BusinessLayer;
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
    public partial class ucUserInformation : UserControl
    {

        public ucUserInformation()
        {
            InitializeComponent();
        }


        public void LoadInformation(int UserID)
        {

            clsUsers User = clsUsers.FindUser(UserID);

            if (User == null)
                return;

            ucPersonDetails1.LoadPersonData(User.PersonID);
            lbUserID.Text = UserID.ToString();
            lbUsername.Text = User.UserName;
            if (User.IsActive)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";
                    
        }

    }
}
