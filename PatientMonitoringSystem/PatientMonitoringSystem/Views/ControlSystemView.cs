using System;
using System.Linq;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
	public partial class ControlSystemView : Form
	{
		private readonly ControlSystemController controller;

		public ControlSystemView()
		{
			InitializeComponent();

			controller = new ControlSystemController(this);
		}

		private void ControlSystemView_Load(object sender, System.EventArgs e)
		{
			controller.Initialise();
		}

		public void OnViewBedsideSystem(Guid bedsideSystemId)
		{
			controller.ViewBedsideSystem(bedsideSystemId);
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
		}

		private void AddBedsideSystem(Guid bedsideSystemId)
		{
			var bedsideSystemRowView = new BedsideSystemRowView(bedsideSystemId, OnViewBedsideSystem);

			Table.RowStyles.Add(new RowStyle());
			Table.Controls.Add(bedsideSystemRowView, 0, Table.RowCount - 1);
		}

		public void ViewBedsideSystem(Guid bedsideSystemId)
		{
			BedsideSystemView view = BedsideSystemView.Instance;
			view.DoStuff(bedsideSystemId);
			view.ShowDialog(this);
		}
	}
}
