using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.ViewModels;

namespace PatientMonitoringSystem.Views
{
	public partial class BedsideSystemRowView : UserControl
	{
		private readonly BedsideSystemRowController controller;

		private readonly Action<Guid> onViewBedsideSystem;

		public Guid BedsideSystemId { get; }

		public BedsideSystemRowView(Guid bedsideSystemId, Action<Guid> onViewBedsideSystem)
		{
			InitializeComponent();

			controller = new BedsideSystemRowController(this, bedsideSystemId);
			this.onViewBedsideSystem = onViewBedsideSystem;

			BedsideSystemId = bedsideSystemId;
		}

		private void BedsideSystemRowView_Load(object sender, EventArgs e)
		{
			controller.Initialise();
		}

		private void ViewButton_Click(object sender, EventArgs e)
		{
			controller.ViewBedsideSystem();
		}

		public void Initialise(BedsideSystemRowViewModel bedsideSystemRowViewModel)
		{
			IdDisplay.Text = bedsideSystemRowViewModel.Id.ToString();
			NameDisplay.Text = bedsideSystemRowViewModel.Name;
		}

		public void ViewBedsideSystem()
		{
			onViewBedsideSystem(BedsideSystemId);
		}
	}
}
