namespace PatientMonitoringSystem.Views
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
			this.MinValueEntry = new System.Windows.Forms.NumericUpDown();
			this.CurrentReadingDisplay = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MaxValueEntry = new System.Windows.Forms.NumericUpDown();
			this.NameDisplay = new System.Windows.Forms.Label();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.IdDisplay = new System.Windows.Forms.Label();
			this.TypeDisplay = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.MinValueEntry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentReadingDisplay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxValueEntry)).BeginInit();
			this.SuspendLayout();
			// 
			// MinValueEntry
			// 
			this.MinValueEntry.Location = new System.Drawing.Point(218, 60);
			this.MinValueEntry.Margin = new System.Windows.Forms.Padding(4);
			this.MinValueEntry.Name = "MinValueEntry";
			this.MinValueEntry.Size = new System.Drawing.Size(120, 31);
			this.MinValueEntry.TabIndex = 0;
			this.MinValueEntry.ValueChanged += new System.EventHandler(this.MinValueEntry_ValueChanged);
			// 
			// CurrentReadingDisplay
			// 
			this.CurrentReadingDisplay.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.CurrentReadingDisplay.Location = new System.Drawing.Point(518, 60);
			this.CurrentReadingDisplay.Margin = new System.Windows.Forms.Padding(4);
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
			this.label1.Location = new System.Drawing.Point(22, 63);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Min:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(346, 63);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 25);
			this.label2.TabIndex = 3;
			this.label2.Text = "Current:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(646, 63);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 25);
			this.label3.TabIndex = 4;
			this.label3.Text = "Max:";
			// 
			// MaxValueEntry
			// 
			this.MaxValueEntry.Location = new System.Drawing.Point(796, 60);
			this.MaxValueEntry.Margin = new System.Windows.Forms.Padding(4);
			this.MaxValueEntry.Name = "MaxValueEntry";
			this.MaxValueEntry.Size = new System.Drawing.Size(120, 31);
			this.MaxValueEntry.TabIndex = 5;
			this.MaxValueEntry.ValueChanged += new System.EventHandler(this.MaxValueEntry_ValueChanged);
			// 
			// NameDisplay
			// 
			this.NameDisplay.AutoSize = true;
			this.NameDisplay.Location = new System.Drawing.Point(943, 66);
			this.NameDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.NameDisplay.Name = "NameDisplay";
			this.NameDisplay.Size = new System.Drawing.Size(70, 25);
			this.NameDisplay.TabIndex = 6;
			this.NameDisplay.Text = "label4";
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(1188, 40);
			this.RemoveButton.Margin = new System.Windows.Forms.Padding(4);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(208, 71);
			this.RemoveButton.TabIndex = 7;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// IdDisplay
			// 
			this.IdDisplay.AutoSize = true;
			this.IdDisplay.Location = new System.Drawing.Point(943, 15);
			this.IdDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.IdDisplay.Name = "IdDisplay";
			this.IdDisplay.Size = new System.Drawing.Size(70, 25);
			this.IdDisplay.TabIndex = 8;
			this.IdDisplay.Text = "label5";
			// 
			// TypeDisplay
			// 
			this.TypeDisplay.AutoSize = true;
			this.TypeDisplay.Location = new System.Drawing.Point(943, 117);
			this.TypeDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.TypeDisplay.Name = "TypeDisplay";
			this.TypeDisplay.Size = new System.Drawing.Size(70, 25);
			this.TypeDisplay.TabIndex = 9;
			this.TypeDisplay.Text = "label6";
			// 
			// ModuleRowView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.Controls.Add(this.TypeDisplay);
			this.Controls.Add(this.IdDisplay);
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.NameDisplay);
			this.Controls.Add(this.MaxValueEntry);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CurrentReadingDisplay);
			this.Controls.Add(this.MinValueEntry);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ModuleRowView";
			this.Size = new System.Drawing.Size(1400, 154);
			this.Load += new System.EventHandler(this.ModuleRowView_Load);
			((System.ComponentModel.ISupportInitialize)(this.MinValueEntry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentReadingDisplay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxValueEntry)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown MinValueEntry;
		private System.Windows.Forms.NumericUpDown CurrentReadingDisplay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown MaxValueEntry;
		private System.Windows.Forms.Label NameDisplay;
		private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Label IdDisplay;
		private System.Windows.Forms.Label TypeDisplay;
	}
}
