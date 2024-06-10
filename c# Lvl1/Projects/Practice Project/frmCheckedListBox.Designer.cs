namespace Project1
{
    partial class frmCheckedListBox
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
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnCheckAllItems = new System.Windows.Forms.Button();
            this.btnUncheckItems = new System.Windows.Forms.Button();
            this.btnShowSelectedItems = new System.Windows.Forms.Button();
            this.btnAddItems = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnCLoseFrm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.Location = new System.Drawing.Point(306, 369);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(187, 56);
            this.btnRemoveItem.TabIndex = 11;
            this.btnRemoveItem.Text = "Remove Last Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnCheckAllItems
            // 
            this.btnCheckAllItems.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAllItems.Location = new System.Drawing.Point(93, 369);
            this.btnCheckAllItems.Name = "btnCheckAllItems";
            this.btnCheckAllItems.Size = new System.Drawing.Size(187, 56);
            this.btnCheckAllItems.TabIndex = 10;
            this.btnCheckAllItems.Text = "Check All Items";
            this.btnCheckAllItems.UseVisualStyleBackColor = true;
            this.btnCheckAllItems.Click += new System.EventHandler(this.btnCheckAllItems_Click);
            // 
            // btnUncheckItems
            // 
            this.btnUncheckItems.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheckItems.Location = new System.Drawing.Point(521, 286);
            this.btnUncheckItems.Name = "btnUncheckItems";
            this.btnUncheckItems.Size = new System.Drawing.Size(187, 56);
            this.btnUncheckItems.TabIndex = 9;
            this.btnUncheckItems.Text = "unCheck Items";
            this.btnUncheckItems.UseVisualStyleBackColor = true;
            this.btnUncheckItems.Click += new System.EventHandler(this.btnUncheckItems_Click);
            // 
            // btnShowSelectedItems
            // 
            this.btnShowSelectedItems.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowSelectedItems.Location = new System.Drawing.Point(306, 286);
            this.btnShowSelectedItems.Name = "btnShowSelectedItems";
            this.btnShowSelectedItems.Size = new System.Drawing.Size(187, 56);
            this.btnShowSelectedItems.TabIndex = 8;
            this.btnShowSelectedItems.Text = "Show Seleted Items";
            this.btnShowSelectedItems.UseVisualStyleBackColor = true;
            this.btnShowSelectedItems.Click += new System.EventHandler(this.btnShowSelectedItems_Click);
            // 
            // btnAddItems
            // 
            this.btnAddItems.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItems.Location = new System.Drawing.Point(93, 286);
            this.btnAddItems.Name = "btnAddItems";
            this.btnAddItems.Size = new System.Drawing.Size(187, 56);
            this.btnAddItems.TabIndex = 7;
            this.btnAddItems.Text = "Add Items";
            this.btnAddItems.UseVisualStyleBackColor = true;
            this.btnAddItems.Click += new System.EventHandler(this.btnAddItems_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(164, 25);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(502, 224);
            this.checkedListBox1.TabIndex = 6;
            // 
            // btnCLoseFrm
            // 
            this.btnCLoseFrm.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLoseFrm.Location = new System.Drawing.Point(521, 369);
            this.btnCLoseFrm.Name = "btnCLoseFrm";
            this.btnCLoseFrm.Size = new System.Drawing.Size(187, 56);
            this.btnCLoseFrm.TabIndex = 12;
            this.btnCLoseFrm.Text = "Close";
            this.btnCLoseFrm.UseVisualStyleBackColor = true;
            this.btnCLoseFrm.Click += new System.EventHandler(this.btnCLoseFrm_Click);
            // 
            // frmCheckedListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCLoseFrm);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.btnCheckAllItems);
            this.Controls.Add(this.btnUncheckItems);
            this.Controls.Add(this.btnShowSelectedItems);
            this.Controls.Add(this.btnAddItems);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "frmCheckedListBox";
            this.Text = "frmCheckedListBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnCheckAllItems;
        private System.Windows.Forms.Button btnUncheckItems;
        private System.Windows.Forms.Button btnShowSelectedItems;
        private System.Windows.Forms.Button btnAddItems;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnCLoseFrm;
    }
}