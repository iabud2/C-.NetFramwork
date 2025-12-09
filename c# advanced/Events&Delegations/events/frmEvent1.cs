using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c__advanced.events
{
    public partial class frmEvent1 : Form
    {
        public frmEvent1()
        {
            InitializeComponent();
        }

        private void ctrlSimpleCalculator1_OnCalculateComplete(object sender, ctrlSimpleCalculator.CalculateCompleteEvent e)
        {
            MessageBox.Show($"Calculation complete: {e.Value1} + {e.Value2} = {e.Result}");
        }
    }
}
