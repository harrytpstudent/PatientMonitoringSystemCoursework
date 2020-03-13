using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Collections.Generic;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.Core.Models;
using System.Drawing;

namespace PatientMonitoringSystem.Views
{
	public partial class ControlSystemView : UserControl
	{
		TableLayoutPanel bedsideTable;
		ControlSystemController controlSystemController;
		Dictionary<Guid, BedsideSystemView> bedside_controller_map = new Dictionary<Guid, BedsideSystemView>();
		public ControlSystemView(ControlSystemController newControlSystemController)
		{
			bedsideTable = new TableLayoutPanel();
			controlSystemController = newControlSystemController;
			controlSystemController.NotifyUiAlarmRaised += SignalBedsideAlarm;
			InitializeComponent();

		}

		private void ControlSystemView_Load(object sender, System.EventArgs e)
		{
			Initialise();
		}

		public void OnViewBedsideSystem(Guid bedsideSystemId)
		{
			ViewBedsideSystem(bedsideSystemId);
		}

		public void Initialise()
		{
			Text = "Control System";
			Table.RowStyles.RemoveAt(0);
			Table.RowCount = 0;

			LoginSystemView loginSystem = new LoginSystemView();
			Table.RowStyles.Add(new RowStyle());
			Table.Controls.Add(loginSystem, 0, Table.RowCount - 1);

			bedsideTable.Size = new Size(270, 100);
			bedsideTable.AutoScroll = true;

			List <Guid> bedsideIds = controlSystemController.GetBedsideSystemIds();

			foreach (var bedsideSystemId in bedsideIds)
			{
				AddBedsideSystem(bedsideSystemId);
			}
			ViewBedsideSystem(controlSystemController.GetFirstBedsideSystem());

			bedsideTable.Dock = DockStyle.Fill;
			Table.Controls.Add(bedsideTable);
			Dock = DockStyle.Fill;
		}

		private void AddBedsideSystem(Guid bedsideSystemId)
		{
			IBedsideSystem bedside = controlSystemController.GetBedsideSystem(bedsideSystemId);
			var bedsideSystemRowView = new BedsideSystemRowView(bedside, OnViewBedsideSystem);

			BedsideSystemController bedsideSystemController = new BedsideSystemController(bedside);
			bedside_controller_map.Add(bedside.BedsideSystemId, new BedsideSystemView(bedsideSystemController));

			bedsideTable.RowStyles.Add(new RowStyle());
			bedsideTable.Controls.Add(bedsideSystemRowView, 0, Table.RowCount - 1);
		}

		public void ViewBedsideSystem(Guid bedsideSystemId)
		{
			IBedsideSystem bedside = controlSystemController.GetBedsideSystem(bedsideSystemId);
			BedsideSystemView view;
			if (bedside_controller_map.TryGetValue(bedsideSystemId, out view)) 
			{
				RightPanel.Controls.Clear();
				RightPanel.Controls.Add(view);
			}
			else
			{
				MessageBox.Show("Failed to find assosiated bedside.");
			}
		}

		public void SignalBedsideAlarm(object sender, Guid bedsideId)
		{
			foreach (BedsideSystemRowView bedsideRowView in bedsideTable.Controls) {
				if (bedsideRowView.BedsideSystemId == bedsideId) {
					bedsideRowView.BackColor = Color.Red;
				}
				//Console.WriteLine(bedsideRowView.BedsideSystemId);
			}
			//bedside_controller_map[bedsideId].BackColor = Color.Red;
		}
	}
}
