using System;
using System.Linq;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Core.Models.Enums;
using PatientMonitoringSystem.Views.Eventing;

namespace PatientMonitoringSystem.Views
{
	public partial class BedsideSystemView : UserControl, IDisposable
	{
		private readonly BedsideSystemController controller;

		public BedsideSystemView(Guid bedsideSystemId)
		{
			InitializeComponent();

			controller = new BedsideSystemController(this, bedsideSystemId);

			Disposed += OnDisposed;
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
			ModuleType moduleType = (ModuleType)ModuleCombo.SelectedItem;
			controller.AddModule(moduleName, moduleType);
		}

		public void OnRemoveModule(object sender, OnRemoveModuleEventArgs e)
		{
			controller.RemoveModule(e.ModuleId);
		}

		public void Initialise(BedsideSystemViewModel bedsideSystemViewModel, bool canAddAnotherModule)
		{
			Text = $"{bedsideSystemViewModel.Name} ({bedsideSystemViewModel.Id})";

			Table.RowStyles.RemoveAt(0);
			Table.RowCount = 0;

			foreach (var moduleId in bedsideSystemViewModel.ModuleIds)
			{
				AddModule(moduleId);
			}

			ModuleCombo.DataSource = Enum.GetValues(typeof(ModuleType));
			AddButton.Enabled = canAddAnotherModule;
			Dock = DockStyle.Fill;
		}

		public void UpdateCurrentReading()
		{
			var moduleRowViews = Table.Controls.OfType<ModuleRowView>();

			// We want to do all of these refreshes at around the same time and avoid having lots of timers.
			foreach (var moduleRowView in moduleRowViews)
			{
				moduleRowView.RefreshCurrentReading();
			}
		}

		public void AddModule(Guid moduleId)
		{
			var moduleRowView = Program.ModuleRowController.Initialise(moduleId);
			moduleRowView.OnRemoveModule += OnRemoveModule;

			Table.RowStyles.Add(new RowStyle());
			Table.Controls.Add(moduleRowView, 0, Table.RowCount - 1);
		}

		public void AddModule(Guid moduleId, bool canAddAnotherModule)
		{
			AddModule(moduleId);

			NameEntry.Text = "";

			AddButton.Enabled = canAddAnotherModule;
		}

		public void RemoveModule(Guid moduleId)
		{
			var moduleRowView = Table.Controls.OfType<ModuleRowView>().Single(mrv => mrv.ModuleId == moduleId);

			var rowIndex = Table.GetPositionFromControl(moduleRowView).Row;

			Table.RowStyles.RemoveAt(rowIndex);
			Table.Controls.Remove(moduleRowView);

			AddButton.Enabled = true;
		}

		public void OnDisposed(object sender, EventArgs e)
		{
			Updater.Dispose(); // Just in case it doesn't happen automatically.
		}
	}
}
