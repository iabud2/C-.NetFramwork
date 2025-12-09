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
    public partial class ctrlSimpleCalculator : UserControl
    {
        public ctrlSimpleCalculator()
        {
            InitializeComponent();
        }


        public class CalculateCompleteEvent : EventArgs
        {
            public int Result { get; }
            public int Value1 { get; }
            public int Value2 { get; }

            public CalculateCompleteEvent(int value1, int value2, int result)
            {
                Value1 = value1;
                Value2 = value2;
                Result = result;
            }
        }

        public event EventHandler<CalculateCompleteEvent> OnCalculateComplete;

        public void RaiseCalculateComplete(int value1, int value2, int result)
        {
            RaiseCalculateComplete(new CalculateCompleteEvent(value1, value2, result));
        }

        protected virtual void RaiseCalculateComplete(CalculateCompleteEvent e)
        {
            OnCalculateComplete?.Invoke(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val1 = int.Parse(textBox1.Text);
            int val2 = int.Parse(textBox2.Text);
            int result = val1 + val2;   

            lbResult.Text = result.ToString();
            RaiseCalculateComplete(val1, val2, result);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
