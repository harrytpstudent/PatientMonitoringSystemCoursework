namespace PatientMonitoringSystem.Views
{
	partial class UserView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</aram>
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
			this.label1 = new System.Windows.Forms.Label();
			this.NameDisplay = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.RoleDisplay = new System.Windows.Forms.TextBox();
			this.LogOutButton = new System.Windows.Forms.Button();
			this.PagerNotificationsEnabledInput = new System.Windows.Forms.CheckBox();
			this.SmsNotificationsEnabledInput = new System.Windows.Forms.CheckBox();
			this.EmailNotificationsEnabledInput = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CancelButton = new System.Windows.Forms.Button();
			this.ApplyButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.EmailNotificationsDestinationInput = new System.Windows.Forms.TextBox();
			this.SmsNotificationsDestinationInput = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.PagerNotificationsDestinationInput = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// NameDisplay
			// 
			this.NameDisplay.Location = new System.Drawing.Point(67, 3);
			this.NameDisplay.Name = "NameDisplay";
			this.NameDisplay.ReadOnly = true;
			this.NameDisplay.Size = new System.Drawing.Size(100, 20);
			this.NameDisplay.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(173, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Role:";
			// 
			// RoleDisplay
			// 
			this.RoleDisplay.Location = new System.Drawing.Point(211, 3);
			this.RoleDisplay.Name = "RoleDisplay";
			this.RoleDisplay.ReadOnly = true;
			this.RoleDisplay.Size = new System.Drawing.Size(100, 20);
			this.RoleDisplay.TabIndex = 5;
			// 
			// LogOutButton
			// 
			this.LogOutButton.Location = new System.Drawing.Point(317, 1);
			this.LogOutButton.Name = "LogOutButton";
			this.LogOutButton.Size = new System.Drawing.Size(75, 23);
			this.LogOutButton.TabIndex = 9;
			this.LogOutButton.Text = "Log Out";
			this.LogOutButton.UseVisualStyleBackColor = true;
			this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
			// 
			// PagerNotificationsEnabledInput
			// 
			this.PagerNotificationsEnabledInput.AutoSize = true;
			this.PagerNotificationsEnabledInput.Location = new System.Drawing.Point(6, 19);
			this.PagerNotificationsEnabledInput.Name = "PagerNotificationsEnabledInput";
			this.PagerNotificationsEnabledInput.Size = new System.Drawing.Size(177, 17);
			this.PagerNotificationsEnabledInput.TabIndex = 10;
			this.PagerNotificationsEnabledInput.Text = "Subscribe to Pager Notifications";
			this.PagerNotificationsEnabledInput.UseVisualStyleBackColor = true;
			// 
			// SmsNotificationsEnabledInput
			// 
			this.SmsNotificationsEnabledInput.AutoSize = true;
			this.SmsNotificationsEnabledInput.Location = new System.Drawing.Point(6, 42);
			this.SmsNotificationsEnabledInput.Name = "SmsNotificationsEnabledInput";
			this.SmsNotificationsEnabledInput.Size = new System.Drawing.Size(172, 17);
			this.SmsNotificationsEnabledInput.TabIndex = 11;
			this.SmsNotificationsEnabledInput.Text = "Subscribe to SMS Notifications";
			this.SmsNotificationsEnabledInput.UseVisualStyleBackColor = true;
			// 
			// EmailNotificationsEnabledInput
			// 
			this.EmailNotificationsEnabledInput.AutoSize = true;
			this.EmailNotificationsEnabledInput.Location = new System.Drawing.Point(6, 65);
			this.EmailNotificationsEnabledInput.Name = "EmailNotificationsEnabledInput";
			this.EmailNotificationsEnabledInput.Size = new System.Drawing.Size(174, 17);
			this.EmailNotificationsEnabledInput.TabIndex = 12;
			this.EmailNotificationsEnabledInput.Text = "Subscribe to Email Notifications";
			this.EmailNotificationsEnabledInput.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CancelButton);
			this.groupBox1.Controls.Add(this.ApplyButton);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.EmailNotificationsDestinationInput);
			this.groupBox1.Controls.Add(this.SmsNotificationsDestinationInput);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.PagerNotificationsDestinationInput);
			this.groupBox1.Controls.Add(this.PagerNotificationsEnabledInput);
			this.groupBox1.Controls.Add(this.EmailNotificationsEnabledInput);
			this.groupBox1.Controls.Add(this.SmsNotificationsEnabledInput);
			this.groupBox1.Location = new System.Drawing.Point(6, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(386, 117);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Subscriptions";
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(224, 89);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 20;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// ApplyButton
			// 
			this.ApplyButton.Location = new System.Drawing.Point(305, 89);
			this.ApplyButton.Name = "ApplyButton";
			this.ApplyButton.Size = new System.Drawing.Size(75, 23);
			this.ApplyButton.TabIndex = 14;
			this.ApplyButton.Text = "Apply";
			this.ApplyButton.UseVisualStyleBackColor = true;
			this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(184, 66);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "Destination:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(184, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "Destination:";
			// 
			// EmailNotificationsDestinationInput
			// 
			this.EmailNotificationsDestinationInput.Location = new System.Drawing.Point(253, 63);
			this.EmailNotificationsDestinationInput.Name = "EmailNotificationsDestinationInput";
			this.EmailNotificationsDestinationInput.ReadOnly = true;
			this.EmailNotificationsDestinationInput.Size = new System.Drawing.Size(127, 20);
			this.EmailNotificationsDestinationInput.TabIndex = 17;
			// 
			// SmsNotificationsDestinationInput
			// 
			this.SmsNotificationsDestinationInput.Location = new System.Drawing.Point(253, 40);
			this.SmsNotificationsDestinationInput.Name = "SmsNotificationsDestinationInput";
			this.SmsNotificationsDestinationInput.ReadOnly = true;
			this.SmsNotificationsDestinationInput.Size = new System.Drawing.Size(127, 20);
			this.SmsNotificationsDestinationInput.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(184, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 15;
			this.label3.Text = "Destination:";
			// 
			// PagerNotificationsDestinationInput
			// 
			this.PagerNotificationsDestinationInput.Location = new System.Drawing.Point(253, 17);
			this.PagerNotificationsDestinationInput.Name = "PagerNotificationsDestinationInput";
			this.PagerNotificationsDestinationInput.ReadOnly = true;
			this.PagerNotificationsDestinationInput.Size = new System.Drawing.Size(127, 20);
			this.PagerNotificationsDestinationInput.TabIndex = 14;
			// 
			// UserView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.LogOutButton);
			this.Controls.Add(this.RoleDisplay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NameDisplay);
			this.Controls.Add(this.label1);
			this.Name = "UserView";
			this.Size = new System.Drawing.Size(399, 155);
			this.Load += new System.EventHandler(this.UserView_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox NameDisplay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox RoleDisplay;
		private System.Windows.Forms.Button LogOutButton;
		private System.Windows.Forms.CheckBox PagerNotificationsEnabledInput;
		private System.Windows.Forms.CheckBox SmsNotificationsEnabledInput;
		private System.Windows.Forms.CheckBox EmailNotificationsEnabledInput;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox EmailNotificationsDestinationInput;
		private System.Windows.Forms.TextBox SmsNotificationsDestinationInput;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox PagerNotificationsDestinationInput;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button ApplyButton;
		private System.Windows.Forms.Label label5;
	}
}
