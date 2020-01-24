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
            this.MinValueEntry = new System.Windows.Forms.NumericUpDown();
            this.CurrentReadingDisplay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxValueEntry = new System.Windows.Forms.NumericUpDown();
            this.NameDisplay = new System.Windows.Forms.Label();
            this.RemoveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinValueEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentReadingDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxValueEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // MinValueEntry
            // 
            this.MinValueEntry.Location = new System.Drawing.Point(109, 31);
            this.MinValueEntry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinValueEntry.Name = "MinValueEntry";
            this.MinValueEntry.Size = new System.Drawing.Size(60, 20);
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
            this.CurrentReadingDisplay.Location = new System.Drawing.Point(259, 31);
            this.CurrentReadingDisplay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.CurrentReadingDisplay.Size = new System.Drawing.Size(60, 20);
            this.CurrentReadingDisplay.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max:";
            // 
            // MaxValueEntry
            // 
            this.MaxValueEntry.Location = new System.Drawing.Point(398, 31);
            this.MaxValueEntry.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaxValueEntry.Name = "MaxValueEntry";
            this.MaxValueEntry.Size = new System.Drawing.Size(60, 20);
            this.MaxValueEntry.TabIndex = 5;
            this.MaxValueEntry.ValueChanged += new System.EventHandler(this.MaxValueEntry_ValueChanged);
            // 
            // NameDisplay
            // 
            this.NameDisplay.AutoSize = true;
            this.NameDisplay.Location = new System.Drawing.Point(471, 33);
            this.NameDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameDisplay.Name = "NameDisplay";
            this.NameDisplay.Size = new System.Drawing.Size(35, 13);
            this.NameDisplay.TabIndex = 6;
            this.NameDisplay.Text = "label4";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(594, 21);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(104, 37);
            this.RemoveButton.TabIndex = 7;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ModuleRowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.NameDisplay);
            this.Controls.Add(this.MaxValueEntry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentReadingDisplay);
            this.Controls.Add(this.MinValueEntry);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ModuleRowView";
            this.Size = new System.Drawing.Size(700, 80);
            this.Load += new System.EventHandler(this.ModuleRow_Load);
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
	}
}
