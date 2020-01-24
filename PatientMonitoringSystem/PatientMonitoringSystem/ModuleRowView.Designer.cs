namespace PatientMonitoringSystem
{
	partial class ModuleRowView
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
			this.MinValueDisplay = new System.Windows.Forms.NumericUpDown();
			this.CurrentReadingDisplay = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MaxValueDisplay = new System.Windows.Forms.NumericUpDown();
			this.NameDisplay = new System.Windows.Forms.Label();
			this.RemoveButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.MinValueDisplay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentReadingDisplay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxValueDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// MinValueDisplay
			// 
			this.MinValueDisplay.Location = new System.Drawing.Point(151, 57);
			this.MinValueDisplay.Name = "MinValueDisplay";
			this.MinValueDisplay.Size = new System.Drawing.Size(120, 31);
			this.MinValueDisplay.TabIndex = 0;
			this.MinValueDisplay.ValueChanged += new System.EventHandler(this.MinValueDisplay_ValueChanged);
			// 
			// CurrentReadingDisplay
			// 
			this.CurrentReadingDisplay.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.CurrentReadingDisplay.Location = new System.Drawing.Point(491, 55);
			this.CurrentReadingDisplay.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.CurrentReadingDisplay.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
			this.CurrentReadingDisplay.Name = "CurrentReadingDisplay";
			this.CurrentReadingDisplay.ReadOnly = true;
			this.CurrentReadingDisplay.Size = new System.Drawing.Size(120, 31);
			this.CurrentReadingDisplay.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Min:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(307, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "Current:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(690, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 25);
			this.label3.TabIndex = 4;
			this.label3.Text = "Max:";
			// 
			// MaxValueDisplay
			// 
			this.MaxValueDisplay.Location = new System.Drawing.Point(797, 59);
			this.MaxValueDisplay.Name = "MaxValueDisplay";
			this.MaxValueDisplay.Size = new System.Drawing.Size(120, 31);
			this.MaxValueDisplay.TabIndex = 5;
			this.MaxValueDisplay.ValueChanged += new System.EventHandler(this.MaxValueDisplay_ValueChanged);
			// 
			// NameDisplay
			// 
			this.NameDisplay.AutoSize = true;
			this.NameDisplay.Location = new System.Drawing.Point(985, 59);
			this.NameDisplay.Name = "NameDisplay";
			this.NameDisplay.Size = new System.Drawing.Size(70, 25);
			this.NameDisplay.TabIndex = 6;
			this.NameDisplay.Text = "label4";
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(1130, 38);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(208, 71);
			this.RemoveButton.TabIndex = 7;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// ModuleRowView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.NameDisplay);
			this.Controls.Add(this.MaxValueDisplay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CurrentReadingDisplay);
			this.Controls.Add(this.MinValueDisplay);
			this.Name = "ModuleRowView";
			this.Size = new System.Drawing.Size(1371, 154);
			this.Load += new System.EventHandler(this.ModuleRow_Load);
			((System.ComponentModel.ISupportInitialize)(this.MinValueDisplay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentReadingDisplay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxValueDisplay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown MinValueDisplay;
		private System.Windows.Forms.NumericUpDown CurrentReadingDisplay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown MaxValueDisplay;
		private System.Windows.Forms.Label NameDisplay;
		private System.Windows.Forms.Button RemoveButton;
	}
}
