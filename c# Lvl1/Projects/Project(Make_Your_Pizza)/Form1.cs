using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Make_Your_Pizza_
{
    public partial class Form1 : Form
    {
        int TotalPrice = 0;
        string[] PizzaToppings;
        public Form1()
        {
            InitializeComponent();
        }

        void ConfirmOrder()
        {
            gbCrustType.Enabled = false;
            gbSize.Enabled = false;
            gbToppings.Enabled = false;
            btnOrderPizza.Enabled = false;
            gbWhereToEat.Enabled = false;
        }
        void ResetForm()
        {
            //Group boxes
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;

            //Size:
            rdbtnSmall.Checked = true;
            //Toppings
            chbExtracheese.Checked = false;
            chbOnion.Checked = false;
            chbMushrooms.Checked = false;
            chbOlives.Checked = false;
            chbTomatoes.Checked = false;
            chbGreenPeppers.Checked = false;

            //Buttons:
            btnOrderPizza.Enabled = true;

            //Where To Eat:

            rdbtnEatIn.Checked =true;
        }

        private void UpdateSize()
        {
            UpdateTotalPrice();
            if (rdbtnSmall.Checked)
            {
                lbShowSize.Text = "Small";
                return;
            }    
            if(rdbtnMedium.Checked) 
            {
                lbShowSize.Text = "Medium";
                return;
            }
            if(rdbtnLarge.Checked) 
            {
                lbShowSize.Text = "Large";
                return;
            }
        }

        private void UpdateToppings()
        {
            UpdateTotalPrice();
            string ToppingsString = "";

            if (chbExtracheese.Checked)
            {
                ToppingsString = "Extra Cheese";
         
            }
            if (chbMushrooms.Checked)
            {
                ToppingsString += ", Mushrooms";
           
            }
            if (chbGreenPeppers.Checked)
            {
                ToppingsString += ", Green Peppers";
           
            }
            if(chbOnion.Checked)
            {
                ToppingsString += ", Onion";
    
            }
            if(chbTomatoes.Checked)
            {
                ToppingsString += ", Tomatoes";

            }
            if(chbOlives.Checked)
            {
                ToppingsString += ", Olives";
            }
            if(ToppingsString.StartsWith(","))
            {
                ToppingsString = ToppingsString.Substring(1, ToppingsString.Length -1).Trim();
            }
            if(ToppingsString == "")
            {
                ToppingsString = "No Toppings";
            }
            lbShowToppings.Text = ToppingsString;
            
        }

        private void UpdateWhereToEat()
        {
            if (rdbtnEatIn.Checked)
            {
                lbShowWhereToEat.Text = "Eat In";
                return;
            }
            if (rdbtnTakeAway.Checked == true)
            {
                lbShowWhereToEat.Text = "TakeAway";
                return;
            }
        }

        private void UpdateCrustType()
        {
            UpdateTotalPrice();
            if (rdbtnThickCrust.Checked)
            {
                lbShowCrustType.Text = "Thick";
                return;
            }
            if(rdbtnThinCrust.Checked)
            {
                lbShowCrustType.Text = "Thin";
                return;
            }
        }

        private void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateWhereToEat();
            UpdateCrustType();
            UpdateTotalPrice();
        }

        private float  GetSizePrice()
        {
            float sizePrice = 0;
            if(rdbtnSmall.Checked)
            {
                sizePrice = Convert.ToSingle(rdbtnSmall.Tag);
            }
            if(rdbtnMedium.Checked)
            {
                sizePrice = Convert.ToSingle(rdbtnMedium.Tag);
            }
            if(rdbtnLarge.Checked)
            {
                sizePrice = Convert.ToSingle(rdbtnLarge.Tag);
            }
            return sizePrice;
        }

        private float GetCrustPrice()
        {
            float crustPrice = 0;
            if(rdbtnThickCrust.Checked)
            {
                crustPrice = Convert.ToSingle(rdbtnThickCrust.Tag);
            }
            if(rdbtnThinCrust.Checked)
            {
                crustPrice = Convert.ToSingle(rdbtnThinCrust.Tag);
            }
            return crustPrice;
        }

        private float CalculateToppingsPrice()
        {
            float TotalPrice = 0;

            if(chbExtracheese.Checked) 
            {
                TotalPrice += Convert.ToSingle(chbExtracheese.Tag);
            }
            
            if(chbOnion.Checked)
            {
                TotalPrice += Convert.ToSingle(chbOnion.Tag);
            }

            if(chbMushrooms.Checked)
            {
                TotalPrice += Convert.ToSingle(chbMushrooms.Tag);
            }
         
            if(chbOlives.Checked)
            {
                TotalPrice += Convert.ToSingle(chbOlives.Tag);
            }
           
            if(chbTomatoes.Checked)
            {
                TotalPrice += Convert.ToSingle(chbTomatoes.Tag);
            }
            
            if(chbGreenPeppers.Checked)
            {
                TotalPrice += Convert.ToSingle(chbGreenPeppers.Tag);
            }
          
            return TotalPrice;
        }
  
        private float CalculateTotalPrice()
        {
            return CalculateToppingsPrice() + GetSizePrice() + GetCrustPrice();
        }
   
        private void UpdateTotalPrice()
        {
            lbShowTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        private void rdbtnSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdbtnMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdbtnLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdbtnThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rdbtnThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rdbtnEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rdbtnTakeAway_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void chbExtracheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                ConfirmOrder();
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
