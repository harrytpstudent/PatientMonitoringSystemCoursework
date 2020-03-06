namespace PatientMonitoringSystem.Views
{
	partial class BedsideSystemRowView
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
			this.NameDisplay = new System.Windows.Forms.Label();
			this.ViewButton = new System.Windows.Forms.Button();
			this.IdDisplay = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// NameDisplay
			// 
			this.NameDisplay.AutoSize = true;
			this.NameDisplay.Location = new System.Drawing.Point(37, 77);
			this.NameDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.NameDisplay.Name = "NameDisplay";
			this.NameDisplay.Size = new System.Drawing.Size(70, 25);
			this.NameDisplay.TabIndex = 6;
			this.NameDisplay.Text = "label4";
			// 
			// ViewButton
			// 
			this.ViewButton.Location = new System.Drawing.Point(283, 54);
			this.ViewButton.Margin = new System.Windows.Forms.Padding(4);
			this.ViewButton.Name = "ViewButton";
			this.ViewButton.Size = new System.Drawing.Size(208, 71);
			this.ViewButton.TabIndex = 7;
			this.ViewButton.Text = "View";
			this.ViewButton.UseVisualStyleBackColor = true;
			this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
			// 
			// IdDisplay
			// 
			this.IdDisplay.AutoSize = true;
			this.IdDisplay.Location = new System.Drawing.Point(37, 28);
			this.IdDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.IdDisplay.Name = "IdDisplay";
			this.IdDisplay.Size = new System.Drawing.Size(70, 25);
			this.IdDisplay.TabIndex = 8;
			this.IdDisplay.Text = "label5";
			// 
			// BedsideSystemRowView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.Controls.Add(this.IdDisplay);
			this.Controls.Add(this.ViewButton);
			this.Controls.Add(this.NameDisplay);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "BedsideSystemRowView";
			this.Size = new System.Drawing.Size(495, 129);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameDisplay;
		private System.Windows.Forms.Button ViewButton;
		private System.Windows.Forms.Label IdDisplay;
	}
}
