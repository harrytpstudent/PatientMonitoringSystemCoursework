using System;
using System.Linq;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using System.Collections.Generic;

namespace PatientMonitoringSystem.Views
{
	public partial class ControlSystemView : UserControl
	{
		private readonly ControlSystemController controller;
		Dictionary<Guid, BedsideSystemView> bed_gui_map = new Dictionary<Guid, BedsideSystemView>();
		public ControlSystemView(ControlSystemController csController)
		{
			InitializeComponent();

			controller = csController;
			Initialise();
		}

		public void OnViewBedsideSystem(Guid bedsideSystemId)
		{
			controller.ViewBedsideSystem(bedsideSystemId, this);
		}

		public void Initialise()
		{
			Text = "Control System";

			Table.RowStyles.RemoveAt(0);
			Table.RowCount = 0;

			foreach (var bedsideSystemId in Program.BedsideSystems.Select(bs => bs.BedsideSystemId))
			{
				AddBedsideSystemView(bedsideSystemId);
				bed_gui_map.Add(bedsideSystemId, new BedsideSystemView(bedsideSystemId));
			}

			ViewBedsideSystem(Program.BedsideSystems.First().BedsideSystemId);

			Dock = DockStyle.Fill;
		}

		private void AddBedsideSystemView(Guid bedsideSystemId)
		{
			var bedsideSystemRowView = new BedsideSystemRowView(bedsideSystemId, OnViewBedsideSystem);

			Table.RowStyles.Add(new RowStyle());
			Table.Controls.Add(bedsideSystemRowView, 0, Table.RowCount - 1);
		}

		public void ViewBedsideSystem(Guid bedsideSystemId)
		{
			RightPanel.Controls.Clear();
			RightPanel.Controls.Add(bed_gui_map[bedsideSystemId]);
		}
	}
}
