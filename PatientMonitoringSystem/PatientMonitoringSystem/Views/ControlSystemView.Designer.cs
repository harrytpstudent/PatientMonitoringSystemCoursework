namespace PatientMonitoringSystem.Views
{
	partial class ControlSystemView
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
			this.Table = new System.Windows.Forms.TableLayoutPanel();
			this.TopPanel = new System.Windows.Forms.Panel();
			this.TopPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Table
			// 
			this.Table.ColumnCount = 1;
			this.Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Table.Location = new System.Drawing.Point(0, 0);
			this.Table.Margin = new System.Windows.Forms.Padding(4);
			this.Table.Name = "Table";
			this.Table.RowCount = 1;
			this.Table.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.Table.Size = new System.Drawing.Size(549, 678);
			this.Table.TabIndex = 0;
			// 
			// TopPanel
			// 
			this.TopPanel.Controls.Add(this.Table);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Margin = new System.Windows.Forms.Padding(4);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(549, 678);
			this.TopPanel.TabIndex = 1;
			// 
			// ControlSystemView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(549, 678);
			this.Controls.Add(this.TopPanel);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ControlSystemView";
			this.Text = "ControlSystemView";
			this.Load += new System.EventHandler(this.ControlSystemView_Load);
			this.TopPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel Table;
		private System.Windows.Forms.Panel TopPanel;
	}
}