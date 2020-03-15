namespace PatientMonitoringSystem.Views
{
    partial class SubscriptionSystemView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginButton = new System.Windows.Forms.Button();
            this.PagerCheckBox = new System.Windows.Forms.CheckBox();
            this.SMSCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmailCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(590, 20);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(100, 40);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Confirm";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PagerCheckBox
            // 
            this.PagerCheckBox.AutoSize = true;
            this.PagerCheckBox.Location = new System.Drawing.Point(15, 43);
            this.PagerCheckBox.Name = "PagerCheckBox";
            this.PagerCheckBox.Size = new System.Drawing.Size(174, 17);
            this.PagerCheckBox.TabIndex = 6;
            this.PagerCheckBox.Text = "Subscribe to pager notifications";
            this.PagerCheckBox.UseVisualStyleBackColor = true;
            // 
            // SMSCheckBox
            // 
            this.SMSCheckBox.AutoSize = true;
            this.SMSCheckBox.Location = new System.Drawing.Point(210, 43);
            this.SMSCheckBox.Name = "SMSCheckBox";
            this.SMSCheckBox.Size = new System.Drawing.Size(170, 17);
            this.SMSCheckBox.TabIndex = 7;
            this.SMSCheckBox.Text = "Subscribe to SMS notifications";
            this.SMSCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Notification Subscribtion";
            // 
            // EmailCheckBox
            // 
            this.EmailCheckBox.AutoSize = true;
            this.EmailCheckBox.Location = new System.Drawing.Point(404, 43);
            this.EmailCheckBox.Name = "EmailCheckBox";
            this.EmailCheckBox.Size = new System.Drawing.Size(171, 17);
            this.EmailCheckBox.TabIndex = 9;
            this.EmailCheckBox.Text = "Subscribe to email notifications";
            this.EmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // SubscriptionSystemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EmailCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SMSCheckBox);
            this.Controls.Add(this.PagerCheckBox);
            this.Controls.Add(this.LoginButton);
            this.Name = "SubscriptionSystemView";
            this.Size = new System.Drawing.Size(700, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.CheckBox PagerCheckBox;
        private System.Windows.Forms.CheckBox SMSCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox EmailCheckBox;
    }
}
