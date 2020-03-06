using System;
using System.Linq;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
	public partial class ControlSystemView : UserControl
	{

		public ControlSystemView()
		{
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

			foreach (var bedsideSystemId in Program.BedsideSystems.Select(bs => bs.BedsideSystemId))
			{
				AddBedsideSystem(bedsideSystemId);
			}

			ViewBedsideSystem(Program.BedsideSystems.First().BedsideSystemId);

			Dock = DockStyle.Fill;
		}

		private void AddBedsideSystem(Guid bedsideSystemId)
		{
			var bedsideSystemRowView = new BedsideSystemRowView(bedsideSystemId, OnViewBedsideSystem);

			Table.RowStyles.Add(new RowStyle());
			Table.Controls.Add(bedsideSystemRowView, 0, Table.RowCount - 1);
		}

		public void ViewBedsideSystem(Guid bedsideSystemId)
		{
			RightPanel.Controls.Clear();
			RightPanel.Controls.Add(new BedsideSystemView(bedsideSystemId));
		}
	}
}
