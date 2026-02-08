namespace TrafficLight_SimpleProject
{
    partial class frmTest
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
            this.btnStart = new System.Windows.Forms.Button();
            this.traffic3 = new TrafficLight_SimpleProject.ctrlTrafficLight();
            this.traffic4 = new TrafficLight_SimpleProject.ctrlTrafficLight();
            this.traffic1 = new TrafficLight_SimpleProject.ctrlTrafficLight();
            this.traffic2 = new TrafficLight_SimpleProject.ctrlTrafficLight();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(242, 295);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // traffic3
            // 
            this.traffic3.GreenTime = 10;
            this.traffic3.Location = new System.Drawing.Point(107, 338);
            this.traffic3.Name = "traffic3";
            this.traffic3.OrangeTime = 3;
            this.traffic3.Size = new System.Drawing.Size(119, 251);
            this.traffic3.TabIndex = 3;
            this.traffic3.TotalTraffics = 4;
            this.traffic3.TrafficIndex = 2;
            // 
            // traffic4
            // 
            this.traffic4.GreenTime = 10;
            this.traffic4.Location = new System.Drawing.Point(350, 338);
            this.traffic4.Name = "traffic4";
            this.traffic4.OrangeTime = 3;
            this.traffic4.Size = new System.Drawing.Size(119, 251);
            this.traffic4.TabIndex = 2;
            this.traffic4.TotalTraffics = 4;
            this.traffic4.TrafficIndex = 3;
            // 
            // traffic1
            // 
            this.traffic1.GreenTime = 10;
            this.traffic1.Location = new System.Drawing.Point(107, 48);
            this.traffic1.Name = "traffic1";
            this.traffic1.OrangeTime = 3;
            this.traffic1.Size = new System.Drawing.Size(119, 251);
            this.traffic1.TabIndex = 1;
            this.traffic1.TotalTraffics = 4;
            this.traffic1.TrafficIndex = 0;
            // 
            // traffic2
            // 
            this.traffic2.GreenTime = 10;
            this.traffic2.Location = new System.Drawing.Point(350, 48);
            this.traffic2.Name = "traffic2";
            this.traffic2.OrangeTime = 3;
            this.traffic2.Size = new System.Drawing.Size(119, 251);
            this.traffic2.TabIndex = 0;
            this.traffic2.TotalTraffics = 4;
            this.traffic2.TrafficIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(242, 324);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 636);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.traffic3);
            this.Controls.Add(this.traffic4);
            this.Controls.Add(this.traffic1);
            this.Controls.Add(this.traffic2);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTrafficLight traffic2;
        private ctrlTrafficLight traffic1;
        private ctrlTrafficLight traffic4;
        private ctrlTrafficLight traffic3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
    }
}