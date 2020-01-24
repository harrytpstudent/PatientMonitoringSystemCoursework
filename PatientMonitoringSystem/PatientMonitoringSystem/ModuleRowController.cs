using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public class ModuleRowController
	{
		private readonly ModuleRowView view;

		private readonly IModule module;

		public ModuleRowController(ModuleRowView view, IModule module)
		{
			this.view = view;
			this.module = module;
		}

		public void Initialise()
		{
			var minValueDisplay = GetControl<NumericUpDown>("MinValueDisplay");
			var currentReadingDisplay = GetControl<NumericUpDown>("CurrentReadingDisplay");
			var maxValueDisplay = GetControl<NumericUpDown>("MaxValueDisplay");
			var nameDisplay = GetControl<Label>("NameDisplay");

			minValueDisplay.Value = module.MinValue;
			minValueDisplay.Minimum = -2147483648;
			minValueDisplay.Maximum = module.MaxValue;
			currentReadingDisplay.Value = module.GetCurrentReading();
			maxValueDisplay.Value = module.MaxValue;
			maxValueDisplay.Minimum = minValueDisplay.Value;
			maxValueDisplay.Maximum = 2147483647;
			nameDisplay.Text = module.Name;
		}

		public void MinValueUpdated(int newValue)
		{
			var maxValueDisplay = GetControl<NumericUpDown>("MaxValueDisplay");

			maxValueDisplay.Minimum = newValue;
		}

		public void MaxValueUpdated(int newValue)
		{
			var minValueDisplay = GetControl<NumericUpDown>("MinValueDisplay");

			minValueDisplay.Maximum = newValue;
		}

		private TControl GetControl<TControl>(string name) where TControl : Control => (TControl)view.Controls[name];
	}
}
