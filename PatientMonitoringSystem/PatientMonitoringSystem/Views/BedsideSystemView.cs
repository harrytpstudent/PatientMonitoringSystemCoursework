using System;
using System.Linq;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem
{
	public partial class BedsideSystemView : Form
	{
		private readonly BedsideSystemController controller;

		public BedsideSystemView(Guid bedsideSystemId)
		{
			InitializeComponent();

			controller = new BedsideSystemController(this, bedsideSystemId);
		}

		private void BedsideSystemView_Load(object sender, EventArgs e)
		{
			controller.Initialise();
		}

		private void Updater_Tick(object sender, EventArgs e)
		{
			controller.UpdateCurrentReading();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			var moduleName = NameEntry.Text;

			controller.AddModule(moduleName);
		}

		public void OnRemoveModule(Guid moduleId)
		{
			controller.RemoveModule(moduleId);
		}

		public void Initialise(BedsideSystemViewModel bedsideSystemViewModel, bool canAddAnotherModule)
		{
			Text = bedsideSystemViewModel.BedsideSystemId;

			Table.RowCount = 0;
			Table.RowStyles.RemoveAt(0);

			foreach (var moduleId in bedsideSystemViewModel.ModuleIds)
			{
				AddModule(moduleId);
			}

			AddButton.Enabled = canAddAnotherModule;
		}

		public void UpdateCurrentReading()
		{
			var moduleRowViews = Table.Controls.OfType<ModuleRowView>();

			foreach (var moduleRowView in moduleRowViews)
			{
				moduleRowView.UpdateCurrentReading();
			}
		}

		public void AddModule(Guid moduleId)
		{
			var moduleRowView = new ModuleRowView(moduleId, OnRemoveModule);

			Table.RowCount += 1;

			Table.Controls.Add(moduleRowView, 0, Table.RowCount);
		}

		public void AddModule(Guid moduleId, bool canAddAnotherModule)
		{
			AddModule(moduleId);

			AddButton.Enabled = canAddAnotherModule;
		}

		public void RemoveModule(Guid moduleId)
		{
			var moduleRowView = Table.Controls.OfType<ModuleRowView>().Single(mrv => mrv.ModuleId == moduleId);

			Table.Controls.Remove(moduleRowView);

			Table.RowCount -= 1;

			AddButton.Enabled = true;
		}
	}
}
