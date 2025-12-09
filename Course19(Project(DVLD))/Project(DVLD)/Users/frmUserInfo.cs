using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.Users
{
    public partial class frmUserInfo : Form
    {
        private int _UserID = -1;

        public frmUserInfo(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }


        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            if (_UserID == -1)
                return;

            ucUserInformation1.LoadInformation(_UserID);
        }

    }
}
