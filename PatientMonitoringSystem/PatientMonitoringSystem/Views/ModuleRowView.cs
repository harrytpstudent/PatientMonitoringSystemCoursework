using System;
using System.Windows.Forms;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views.Eventing;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
	public partial class ModuleRowView : UserControl
	{

		public event EventHandler<OnRemoveModuleEventArgs> OnRemoveModule;
		private ModuleController moduleController;
		public Guid ModuleId;

		public ModuleRowView(ModuleController newModuleController)
		{
			moduleController = newModuleController;
			ModuleId = moduleController.GetModuleId();
			InitializeComponent();
			MinValueEntry.Minimum = -2147483648;
			MinValueEntry.Maximum = moduleController.GetMaxValue();
			MinValueEntry.Value = moduleController.GetMinValue();
			CurrentReadingDisplay.Value = moduleController.GetCurrentReading();
			MaxValueEntry.Minimum = moduleController.GetMinValue();
			MaxValueEntry.Maximum = 2147483647;
			MaxValueEntry.Value = moduleController.GetMaxValue();
			IdDisplay.Text = moduleController.GetModuleId().ToString();
			NameDisplay.Text = moduleController.GetName();
			TypeDisplay.Text = moduleController.GetType().ToString();
		}

		public void RefreshCurrentReading()
		{
			CurrentReadingDisplay.Value = moduleController.GetCurrentReading();
		}

		private void MinValueEntry_ValueChanged(object sender, EventArgs e)
		{
			var value = (int)MinValueEntry.Value;
			moduleController.SetMinValue(value);
			MaxValueEntry.Minimum = value;
		}

		private void MaxValueEntry_ValueChanged(object sender, EventArgs e)
		{
			var value = (int)MaxValueEntry.Value;
			moduleController.SetMaxValue(value);
			MinValueEntry.Maximum = value;
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			OnRemoveModule(this, new OnRemoveModuleEventArgs(ModuleId));
		}
	}
}
