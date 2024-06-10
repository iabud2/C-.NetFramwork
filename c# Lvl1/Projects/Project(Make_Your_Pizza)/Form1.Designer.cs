namespace Project_Make_Your_Pizza_
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.rdbtnLarge = new System.Windows.Forms.RadioButton();
            this.rdbtnMedium = new System.Windows.Forms.RadioButton();
            this.rdbtnSmall = new System.Windows.Forms.RadioButton();
            this.gbCrustType = new System.Windows.Forms.GroupBox();
            this.rdbtnThickCrust = new System.Windows.Forms.RadioButton();
            this.rdbtnThinCrust = new System.Windows.Forms.RadioButton();
            this.gbWhereToEat = new System.Windows.Forms.GroupBox();
            this.rdbtnTakeAway = new System.Windows.Forms.RadioButton();
            this.rdbtnEatIn = new System.Windows.Forms.RadioButton();
            this.gbToppings = new System.Windows.Forms.GroupBox();
            this.chbGreenPeppers = new System.Windows.Forms.CheckBox();
            this.chbOlives = new System.Windows.Forms.CheckBox();
            this.chbOnion = new System.Windows.Forms.CheckBox();
            this.chbTomatoes = new System.Windows.Forms.CheckBox();
            this.chbMushrooms = new System.Windows.Forms.CheckBox();
            this.chbExtracheese = new System.Windows.Forms.CheckBox();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.lbShowTotalPrice = new System.Windows.Forms.Label();
            this.btnOrderPizza = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbShowSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbShowToppings = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbShowCrustType = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbShowWhereToEat = new System.Windows.Forms.Label();
            this.gbSize.SuspendLayout();
            this.gbCrustType.SuspendLayout();
            this.gbWhereToEat.SuspendLayout();
            this.gbToppings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(526, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "Make Your Pizza";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.rdbtnLarge);
            this.gbSize.Controls.Add(this.rdbtnMedium);
            this.gbSize.Controls.Add(this.rdbtnSmall);
            this.gbSize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSize.Location = new System.Drawing.Point(12, 136);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(200, 156);
            this.gbSize.TabIndex = 1;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Size";
            // 
            // rdbtnLarge
            // 
            this.rdbtnLarge.AutoSize = true;
            this.rdbtnLarge.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnLarge.Location = new System.Drawing.Point(4, 107);
            this.rdbtnLarge.Name = "rdbtnLarge";
            this.rdbtnLarge.Size = new System.Drawing.Size(72, 25);
            this.rdbtnLarge.TabIndex = 2;
            this.rdbtnLarge.Tag = "40";
            this.rdbtnLarge.Text = "Large";
            this.rdbtnLarge.UseVisualStyleBackColor = true;
            this.rdbtnLarge.CheckedChanged += new System.EventHandler(this.rdbtnLarge_CheckedChanged);
            // 
            // rdbtnMedium
            // 
            this.rdbtnMedium.AutoSize = true;
            this.rdbtnMedium.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnMedium.Location = new System.Drawing.Point(4, 67);
            this.rdbtnMedium.Name = "rdbtnMedium";
            this.rdbtnMedium.Size = new System.Drawing.Size(89, 25);
            this.rdbtnMedium.TabIndex = 1;
            this.rdbtnMedium.Tag = "30";
            this.rdbtnMedium.Text = "Medium";
            this.rdbtnMedium.UseVisualStyleBackColor = true;
            this.rdbtnMedium.CheckedChanged += new System.EventHandler(this.rdbtnMedium_CheckedChanged);
            // 
            // rdbtnSmall
            // 
            this.rdbtnSmall.AutoSize = true;
            this.rdbtnSmall.Checked = true;
            this.rdbtnSmall.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnSmall.Location = new System.Drawing.Point(4, 27);
            this.rdbtnSmall.Name = "rdbtnSmall";
            this.rdbtnSmall.Size = new System.Drawing.Size(71, 25);
            this.rdbtnSmall.TabIndex = 0;
            this.rdbtnSmall.TabStop = true;
            this.rdbtnSmall.Tag = "20";
            this.rdbtnSmall.Text = "Small";
            this.rdbtnSmall.UseVisualStyleBackColor = true;
            this.rdbtnSmall.CheckedChanged += new System.EventHandler(this.rdbtnSmall_CheckedChanged);
            // 
            // gbCrustType
            // 
            this.gbCrustType.Controls.Add(this.rdbtnThickCrust);
            this.gbCrustType.Controls.Add(this.rdbtnThinCrust);
            this.gbCrustType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCrustType.Location = new System.Drawing.Point(12, 326);
            this.gbCrustType.Name = "gbCrustType";
            this.gbCrustType.Size = new System.Drawing.Size(200, 121);
            this.gbCrustType.TabIndex = 2;
            this.gbCrustType.TabStop = false;
            this.gbCrustType.Text = "Crust Type";
            // 
            // rdbtnThickCrust
            // 
            this.rdbtnThickCrust.AutoSize = true;
            this.rdbtnThickCrust.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnThickCrust.Location = new System.Drawing.Point(6, 90);
            this.rdbtnThickCrust.Name = "rdbtnThickCrust";
            this.rdbtnThickCrust.Size = new System.Drawing.Size(114, 25);
            this.rdbtnThickCrust.TabIndex = 3;
            this.rdbtnThickCrust.TabStop = true;
            this.rdbtnThickCrust.Tag = "5";
            this.rdbtnThickCrust.Text = "Thick Crust";
            this.rdbtnThickCrust.UseVisualStyleBackColor = true;
            this.rdbtnThickCrust.CheckedChanged += new System.EventHandler(this.rdbtnThickCrust_CheckedChanged);
            // 
            // rdbtnThinCrust
            // 
            this.rdbtnThinCrust.AutoSize = true;
            this.rdbtnThinCrust.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnThinCrust.Location = new System.Drawing.Point(4, 44);
            this.rdbtnThinCrust.Name = "rdbtnThinCrust";
            this.rdbtnThinCrust.Size = new System.Drawing.Size(107, 25);
            this.rdbtnThinCrust.TabIndex = 2;
            this.rdbtnThinCrust.TabStop = true;
            this.rdbtnThinCrust.Tag = "0";
            this.rdbtnThinCrust.Text = "Thin Crust";
            this.rdbtnThinCrust.UseVisualStyleBackColor = true;
            this.rdbtnThinCrust.CheckedChanged += new System.EventHandler(this.rdbtnThinCrust_CheckedChanged);
            // 
            // gbWhereToEat
            // 
            this.gbWhereToEat.Controls.Add(this.rdbtnTakeAway);
            this.gbWhereToEat.Controls.Add(this.rdbtnEatIn);
            this.gbWhereToEat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbWhereToEat.Location = new System.Drawing.Point(284, 326);
            this.gbWhereToEat.Name = "gbWhereToEat";
            this.gbWhereToEat.Size = new System.Drawing.Size(332, 121);
            this.gbWhereToEat.TabIndex = 3;
            this.gbWhereToEat.TabStop = false;
            this.gbWhereToEat.Text = "Where to Eat";
            // 
            // rdbtnTakeAway
            // 
            this.rdbtnTakeAway.AutoSize = true;
            this.rdbtnTakeAway.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnTakeAway.Location = new System.Drawing.Point(178, 44);
            this.rdbtnTakeAway.Name = "rdbtnTakeAway";
            this.rdbtnTakeAway.Size = new System.Drawing.Size(108, 25);
            this.rdbtnTakeAway.TabIndex = 4;
            this.rdbtnTakeAway.TabStop = true;
            this.rdbtnTakeAway.Text = "TakeAway";
            this.rdbtnTakeAway.UseVisualStyleBackColor = true;
            this.rdbtnTakeAway.CheckedChanged += new System.EventHandler(this.rdbtnTakeAway_CheckedChanged);
            // 
            // rdbtnEatIn
            // 
            this.rdbtnEatIn.AutoSize = true;
            this.rdbtnEatIn.Checked = true;
            this.rdbtnEatIn.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnEatIn.Location = new System.Drawing.Point(23, 48);
            this.rdbtnEatIn.Name = "rdbtnEatIn";
            this.rdbtnEatIn.Size = new System.Drawing.Size(76, 25);
            this.rdbtnEatIn.TabIndex = 3;
            this.rdbtnEatIn.TabStop = true;
            this.rdbtnEatIn.Text = "Eat In";
            this.rdbtnEatIn.UseVisualStyleBackColor = true;
            this.rdbtnEatIn.CheckedChanged += new System.EventHandler(this.rdbtnEatIn_CheckedChanged);
            // 
            // gbToppings
            // 
            this.gbToppings.Controls.Add(this.chbGreenPeppers);
            this.gbToppings.Controls.Add(this.chbOlives);
            this.gbToppings.Controls.Add(this.chbOnion);
            this.gbToppings.Controls.Add(this.chbTomatoes);
            this.gbToppings.Controls.Add(this.chbMushrooms);
            this.gbToppings.Controls.Add(this.chbExtracheese);
            this.gbToppings.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbToppings.Location = new System.Drawing.Point(284, 136);
            this.gbToppings.Name = "gbToppings";
            this.gbToppings.Size = new System.Drawing.Size(332, 156);
            this.gbToppings.TabIndex = 4;
            this.gbToppings.TabStop = false;
            this.gbToppings.Text = "Toppings";
            // 
            // chbGreenPeppers
            // 
            this.chbGreenPeppers.AutoSize = true;
            this.chbGreenPeppers.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbGreenPeppers.Location = new System.Drawing.Point(178, 122);
            this.chbGreenPeppers.Name = "chbGreenPeppers";
            this.chbGreenPeppers.Size = new System.Drawing.Size(140, 25);
            this.chbGreenPeppers.TabIndex = 5;
            this.chbGreenPeppers.Tag = "2";
            this.chbGreenPeppers.Text = "Green Peppers";
            this.chbGreenPeppers.UseVisualStyleBackColor = true;
            this.chbGreenPeppers.CheckedChanged += new System.EventHandler(this.chbGreenPeppers_CheckedChanged);
            // 
            // chbOlives
            // 
            this.chbOlives.AutoSize = true;
            this.chbOlives.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbOlives.Location = new System.Drawing.Point(178, 80);
            this.chbOlives.Name = "chbOlives";
            this.chbOlives.Size = new System.Drawing.Size(77, 25);
            this.chbOlives.TabIndex = 4;
            this.chbOlives.Tag = "2";
            this.chbOlives.Text = "Olives";
            this.chbOlives.UseVisualStyleBackColor = true;
            this.chbOlives.CheckedChanged += new System.EventHandler(this.chbOlives_CheckedChanged);
            // 
            // chbOnion
            // 
            this.chbOnion.AutoSize = true;
            this.chbOnion.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbOnion.Location = new System.Drawing.Point(178, 38);
            this.chbOnion.Name = "chbOnion";
            this.chbOnion.Size = new System.Drawing.Size(75, 25);
            this.chbOnion.TabIndex = 3;
            this.chbOnion.Tag = "2";
            this.chbOnion.Text = "Onion";
            this.chbOnion.UseVisualStyleBackColor = true;
            this.chbOnion.CheckedChanged += new System.EventHandler(this.chbOnion_CheckedChanged);
            // 
            // chbTomatoes
            // 
            this.chbTomatoes.AutoSize = true;
            this.chbTomatoes.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbTomatoes.Location = new System.Drawing.Point(6, 122);
            this.chbTomatoes.Name = "chbTomatoes";
            this.chbTomatoes.Size = new System.Drawing.Size(106, 25);
            this.chbTomatoes.TabIndex = 2;
            this.chbTomatoes.Tag = "2";
            this.chbTomatoes.Text = "Tomatoes";
            this.chbTomatoes.UseVisualStyleBackColor = true;
            this.chbTomatoes.CheckedChanged += new System.EventHandler(this.chbTomatoes_CheckedChanged);
            // 
            // chbMushrooms
            // 
            this.chbMushrooms.AutoSize = true;
            this.chbMushrooms.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMushrooms.Location = new System.Drawing.Point(6, 80);
            this.chbMushrooms.Name = "chbMushrooms";
            this.chbMushrooms.Size = new System.Drawing.Size(117, 25);
            this.chbMushrooms.TabIndex = 1;
            this.chbMushrooms.Tag = "2";
            this.chbMushrooms.Text = "Mushrooms";
            this.chbMushrooms.UseVisualStyleBackColor = true;
            this.chbMushrooms.CheckedChanged += new System.EventHandler(this.chbMushrooms_CheckedChanged);
            // 
            // chbExtracheese
            // 
            this.chbExtracheese.AutoSize = true;
            this.chbExtracheese.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbExtracheese.Location = new System.Drawing.Point(6, 38);
            this.chbExtracheese.Name = "chbExtracheese";
            this.chbExtracheese.Size = new System.Drawing.Size(130, 25);
            this.chbExtracheese.TabIndex = 0;
            this.chbExtracheese.Tag = "2";
            this.chbExtracheese.Text = "Extra Cheese";
            this.chbExtracheese.UseVisualStyleBackColor = true;
            this.chbExtracheese.CheckedChanged += new System.EventHandler(this.chbExtracheese_CheckedChanged);
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPrice.Location = new System.Drawing.Point(754, 495);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(124, 24);
            this.lbTotalPrice.TabIndex = 6;
            this.lbTotalPrice.Text = "Total Price:";
            // 
            // lbShowTotalPrice
            // 
            this.lbShowTotalPrice.AutoSize = true;
            this.lbShowTotalPrice.Font = new System.Drawing.Font("Impact", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowTotalPrice.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbShowTotalPrice.Location = new System.Drawing.Point(854, 519);
            this.lbShowTotalPrice.Name = "lbShowTotalPrice";
            this.lbShowTotalPrice.Size = new System.Drawing.Size(76, 59);
            this.lbShowTotalPrice.TabIndex = 7;
            this.lbShowTotalPrice.Text = "$0";
            // 
            // btnOrderPizza
            // 
            this.btnOrderPizza.FlatAppearance.BorderSize = 3;
            this.btnOrderPizza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderPizza.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrderPizza.Location = new System.Drawing.Point(67, 486);
            this.btnOrderPizza.Name = "btnOrderPizza";
            this.btnOrderPizza.Size = new System.Drawing.Size(145, 45);
            this.btnOrderPizza.TabIndex = 8;
            this.btnOrderPizza.Text = "Order Pizza";
            this.btnOrderPizza.UseVisualStyleBackColor = true;
            this.btnOrderPizza.Click += new System.EventHandler(this.btnOrderPizza_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.FlatAppearance.BorderSize = 3;
            this.btnResetForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetForm.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Location = new System.Drawing.Point(284, 486);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(145, 45);
            this.btnResetForm.TabIndex = 9;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(754, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(713, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Order Summary:";
            // 
            // lbShowSize
            // 
            this.lbShowSize.AutoSize = true;
            this.lbShowSize.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowSize.Location = new System.Drawing.Point(819, 183);
            this.lbShowSize.Name = "lbShowSize";
            this.lbShowSize.Size = new System.Drawing.Size(50, 21);
            this.lbShowSize.TabIndex = 12;
            this.lbShowSize.Text = "Small";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(754, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Toppings:";
            // 
            // lbShowToppings
            // 
            this.lbShowToppings.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowToppings.Location = new System.Drawing.Point(860, 259);
            this.lbShowToppings.Name = "lbShowToppings";
            this.lbShowToppings.Size = new System.Drawing.Size(252, 69);
            this.lbShowToppings.TabIndex = 14;
            this.lbShowToppings.Text = "No Toppings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(754, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Crust Type:";
            // 
            // lbShowCrustType
            // 
            this.lbShowCrustType.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowCrustType.Location = new System.Drawing.Point(885, 341);
            this.lbShowCrustType.Name = "lbShowCrustType";
            this.lbShowCrustType.Size = new System.Drawing.Size(109, 24);
            this.lbShowCrustType.TabIndex = 16;
            this.lbShowCrustType.Text = "Thin Crust";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(754, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Where To Eat:";
            // 
            // lbShowWhereToEat
            // 
            this.lbShowWhereToEat.AutoSize = true;
            this.lbShowWhereToEat.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowWhereToEat.Location = new System.Drawing.Point(889, 426);
            this.lbShowWhereToEat.Name = "lbShowWhereToEat";
            this.lbShowWhereToEat.Size = new System.Drawing.Size(92, 21);
            this.lbShowWhereToEat.TabIndex = 18;
            this.lbShowWhereToEat.Text = "Take Away";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1584, 781);
            this.Controls.Add(this.lbShowWhereToEat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbShowCrustType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbShowToppings);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbShowSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.btnOrderPizza);
            this.Controls.Add(this.lbShowTotalPrice);
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.gbToppings);
            this.Controls.Add(this.gbWhereToEat);
            this.Controls.Add(this.gbCrustType);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.gbCrustType.ResumeLayout(false);
            this.gbCrustType.PerformLayout();
            this.gbWhereToEat.ResumeLayout(false);
            this.gbWhereToEat.PerformLayout();
            this.gbToppings.ResumeLayout(false);
            this.gbToppings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.RadioButton rdbtnLarge;
        private System.Windows.Forms.RadioButton rdbtnMedium;
        private System.Windows.Forms.RadioButton rdbtnSmall;
        private System.Windows.Forms.GroupBox gbCrustType;
        private System.Windows.Forms.RadioButton rdbtnThickCrust;
        private System.Windows.Forms.RadioButton rdbtnThinCrust;
        private System.Windows.Forms.GroupBox gbWhereToEat;
        private System.Windows.Forms.RadioButton rdbtnTakeAway;
        private System.Windows.Forms.RadioButton rdbtnEatIn;
        private System.Windows.Forms.GroupBox gbToppings;
        private System.Windows.Forms.CheckBox chbGreenPeppers;
        private System.Windows.Forms.CheckBox chbOlives;
        private System.Windows.Forms.CheckBox chbOnion;
        private System.Windows.Forms.CheckBox chbTomatoes;
        private System.Windows.Forms.CheckBox chbMushrooms;
        private System.Windows.Forms.CheckBox chbExtracheese;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label lbShowTotalPrice;
        private System.Windows.Forms.Button btnOrderPizza;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbShowSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbShowToppings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbShowCrustType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbShowWhereToEat;
    }
}

