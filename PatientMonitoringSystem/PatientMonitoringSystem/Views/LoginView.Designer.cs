namespace PatientMonitoringSystem.Views
{
    partial class LoginView
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.UsernameInput = new System.Windows.Forms.TextBox();
			this.PasswordInput = new System.Windows.Forms.TextBox();
			this.LoginButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(190, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// UsernameInput
			// 
			this.UsernameInput.Location = new System.Drawing.Point(69, 0);
			this.UsernameInput.Name = "UsernameInput";
			this.UsernameInput.Size = new System.Drawing.Size(100, 20);
			this.UsernameInput.TabIndex = 2;
			// 
			// PasswordInput
			// 
			this.PasswordInput.Location = new System.Drawing.Point(252, 1);
			this.PasswordInput.Name = "PasswordInput";
			this.PasswordInput.Size = new System.Drawing.Size(100, 20);
			this.PasswordInput.TabIndex = 3;
			this.PasswordInput.UseSystemPasswordChar = true;
			// 
			// LoginButton
			// 
			this.LoginButton.Location = new System.Drawing.Point(369, 0);
			this.LoginButton.Name = "LoginButton";
			this.LoginButton.Size = new System.Drawing.Size(75, 23);
			this.LoginButton.TabIndex = 4;
			this.LoginButton.Text = "Login";
			this.LoginButton.UseVisualStyleBackColor = true;
			this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
			// 
			// LoginView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.LoginButton);
			this.Controls.Add(this.PasswordInput);
			this.Controls.Add(this.UsernameInput);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "LoginView";
			this.Size = new System.Drawing.Size(457, 33);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox UsernameInput;
		private System.Windows.Forms.TextBox PasswordInput;
		private System.Windows.Forms.Button LoginButton;
	}
}
