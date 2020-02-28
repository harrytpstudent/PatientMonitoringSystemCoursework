using System;
using System.Windows.Forms;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views.Eventing;

namespace PatientMonitoringSystem.Views
{
	public partial class ModuleRowView : UserControl
	{
		public Guid ModuleId { get; }

		public event EventHandler<OnRemoveModuleEventArgs> OnRemoveModule;

		public ModuleRowView(Guid moduleId, ModuleRowViewModel viewModel)
		{
			ModuleId = moduleId;
			InitializeComponent();
			MinValueEntry.Minimum = -2147483648;
			MinValueEntry.Maximum = viewModel.MaxValue;
			MinValueEntry.Value = viewModel.MinValue;
			CurrentReadingDisplay.Value = viewModel.CurrentReading;
			MaxValueEntry.Minimum = viewModel.MinValue;
			MaxValueEntry.Maximum = 2147483647;
			MaxValueEntry.Value = viewModel.MaxValue;
			IdDisplay.Text = viewModel.Id.ToString();
			NameDisplay.Text = viewModel.Name;
			TypeDisplay.Text = viewModel.Type.ToString();
		}

		public void RefreshCurrentReading()
		{
			CurrentReadingDisplay.Value = Program.ModuleRowController.GetCurrentReading(ModuleId);
		}

		private void MinValueEntry_ValueChanged(object sender, EventArgs e)
		{
			var value = (int)MinValueEntry.Value;
			Program.ModuleRowController.NotifyMinValueChanged(ModuleId, value);
			MaxValueEntry.Minimum = value;
		}

		private void MaxValueEntry_ValueChanged(object sender, EventArgs e)
		{
			var value = (int)MaxValueEntry.Value;
			Program.ModuleRowController.NotifyMaxValueChanged(ModuleId, value);
			MinValueEntry.Maximum = value;
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			OnRemoveModule(this, new OnRemoveModuleEventArgs(ModuleId));
		}
	}
}
