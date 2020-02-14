namespace PatientMonitoringSystem.Views
{
    partial class SubscriptionSelectionView
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
            this.PagerNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.SmsNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.EmailNotificationCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PagerNotificationCheckBox
            // 
            this.PagerNotificationCheckBox.AutoSize = true;
            this.PagerNotificationCheckBox.Location = new System.Drawing.Point(50, 60);
            this.PagerNotificationCheckBox.Name = "PagerNotificationCheckBox";
            this.PagerNotificationCheckBox.Size = new System.Drawing.Size(115, 17);
            this.PagerNotificationCheckBox.TabIndex = 0;
            this.PagerNotificationCheckBox.Text = "Pager Notifications";
            this.PagerNotificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // SmsNotificationCheckBox
            // 
            this.SmsNotificationCheckBox.AutoSize = true;
            this.SmsNotificationCheckBox.Location = new System.Drawing.Point(50, 83);
            this.SmsNotificationCheckBox.Name = "SmsNotificationCheckBox";
            this.SmsNotificationCheckBox.Size = new System.Drawing.Size(110, 17);
            this.SmsNotificationCheckBox.TabIndex = 1;
            this.SmsNotificationCheckBox.Text = "SMS Notifications";
            this.SmsNotificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmailNotificationCheckBox
            // 
            this.EmailNotificationCheckBox.AutoSize = true;
            this.EmailNotificationCheckBox.Location = new System.Drawing.Point(50, 106);
            this.EmailNotificationCheckBox.Name = "EmailNotificationCheckBox";
            this.EmailNotificationCheckBox.Size = new System.Drawing.Size(112, 17);
            this.EmailNotificationCheckBox.TabIndex = 2;
            this.EmailNotificationCheckBox.Text = "Email Notifications";
            this.EmailNotificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(65, 145);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select any number of options \r\nto subscribe to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SubscriptionSelectionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 181);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.EmailNotificationCheckBox);
            this.Controls.Add(this.SmsNotificationCheckBox);
            this.Controls.Add(this.PagerNotificationCheckBox);
            this.Name = "SubscriptionSelectionView";
            this.Text = "Subscriptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox PagerNotificationCheckBox;
        private System.Windows.Forms.CheckBox SmsNotificationCheckBox;
        private System.Windows.Forms.CheckBox EmailNotificationCheckBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label1;
    }
}
