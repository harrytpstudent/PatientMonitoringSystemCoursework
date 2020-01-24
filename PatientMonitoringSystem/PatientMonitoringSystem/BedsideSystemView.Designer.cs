namespace PatientMonitoringSystem
{
	partial class BedsideSystemView
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
			this.components = new System.ComponentModel.Container();
			this.Updater = new System.Windows.Forms.Timer(this.components);
			this.TopPanel = new System.Windows.Forms.Panel();
			this.BottomPanel = new System.Windows.Forms.Panel();
			this.Table = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.NameEntry = new System.Windows.Forms.TextBox();
			this.AddButton = new System.Windows.Forms.Button();
			this.TopPanel.SuspendLayout();
			this.BottomPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Updater
			// 
			this.Updater.Enabled = true;
			this.Updater.Interval = 1000;
			this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
			// 
			// TopPanel
			// 
			this.TopPanel.BackColor = System.Drawing.Color.Red;
			this.TopPanel.Controls.Add(this.Table);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(1349, 792);
			this.TopPanel.TabIndex = 2;
			// 
			// BottomPanel
			// 
			this.BottomPanel.BackColor = System.Drawing.Color.Green;
			this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BottomPanel.Location = new System.Drawing.Point(0, 0);
			this.BottomPanel.Name = "BottomPanel";
			this.BottomPanel.Size = new System.Drawing.Size(1349, 100);
			this.BottomPanel.TabIndex = 2;
			this.BottomPanel.Controls.Add(label1);
			this.BottomPanel.Controls.Add(NameEntry);
			this.BottomPanel.Controls.Add(AddButton);
			// 
			// Table
			// 
			this.Table.ColumnCount = 1;
			this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Table.Location = new System.Drawing.Point(0, 0);
			this.Table.Name = "Table";
			this.Table.RowCount = 1;
			this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.Table.Size = new System.Drawing.Size(1349, 792);
			this.Table.TabIndex = 0;
			// 
			// BedsideSystemView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1349, 792);
			this.Controls.Add(this.TopPanel);
			this.Controls.Add(this.BottomPanel);
			this.Name = "BedsideSystemView";
			this.Text = "Bedside System";
			this.Load += new System.EventHandler(this.BedsideSystemView_Load);
			this.TopPanel.ResumeLayout(false);
			this.BottomPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			// 
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 25);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name:";
			// 
			// NameEntry
			//
			this.NameEntry.Name = "NameEntry";
			this.NameEntry.Location = new System.Drawing.Point(100, 0);
			// 
			// AddButton
			//
			this.AddButton.Name = "AddButton";
			this.AddButton.Location = new System.Drawing.Point(200, 0);
			this.AddButton.Text = "Add";
			this.AddButton.Size = new System.Drawing.Size(208, 71);
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
		}

		#endregion
		private System.Windows.Forms.Timer Updater;
		private System.Windows.Forms.Panel TopPanel;
		private System.Windows.Forms.Panel BottomPanel;
		private System.Windows.Forms.TableLayoutPanel Table;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox NameEntry;
		private System.Windows.Forms.Button AddButton;
	}
}

