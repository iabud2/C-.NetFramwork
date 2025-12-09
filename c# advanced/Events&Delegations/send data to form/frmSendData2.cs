using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c__advanced.send_data_to_form
{
    public partial class frmSendData2 : Form
    {

        private int _PersonID = -1;

        public frmSendData2(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if(_PersonID != -1)
                label2.Text = _PersonID.ToString();
            else
                label2.Text = "No Person ID was provided.";
        }
    }
}
