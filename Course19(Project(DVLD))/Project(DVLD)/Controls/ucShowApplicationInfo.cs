using DVLD_BusinessLayer.Application;
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
    public partial class ucShowApplicationInfo : UserControl
    {
        public ucShowApplicationInfo()
        {
            InitializeComponent();
        }
        private void LoadInfo(int LDLA_ID)
        {
            cls_LDLA LDL_Application = cls_LDLA.GetLDLAInfo(LDLA_ID);
                
                
                
        }


    }
}
