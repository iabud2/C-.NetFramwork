using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DVLD_.People
{
    public partial class frmShowPersonDetails : Form
    {
        public frmShowPersonDetails(int _PersonID)
        {
            InitializeComponent();
            ucPersonDetails1.LoadPersonData(_PersonID);
        }


    }
}
