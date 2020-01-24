using System.Linq;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public class ModuleRowController
	{
		private readonly ModuleRowView view;

		private readonly IModule model;

		public ModuleRowController(ModuleRowView view, IModule model)
		{
			this.view = view;
			this.model = model;
		}

		public void Initialise()
		{
			var minValueDisplay = view.FindSubcontrol<NumericUpDown>("MinValueDisplay");
			var currentReadingDisplay = view.FindSubcontrol<NumericUpDown>("CurrentReadingDisplay");
			var maxValueDisplay = view.FindSubcontrol<NumericUpDown>("MaxValueDisplay");
			var nameDisplay = view.FindSubcontrol<Label>("NameDisplay");

			minValueDisplay.Value = model.MinValue;
			minValueDisplay.Minimum = -2147483648;
			minValueDisplay.Maximum = model.MaxValue;
			currentReadingDisplay.Value = model.GetCurrentReading();
			maxValueDisplay.Value = model.MaxValue;
			maxValueDisplay.Minimum = minValueDisplay.Value;
			maxValueDisplay.Maximum = 2147483647;
			nameDisplay.Text = model.Name;
		}

		public void MinValueUpdated(int newValue)
		{
			model.MinValue = newValue;

			var maxValueDisplay = view.FindSubcontrol<NumericUpDown>("MaxValueDisplay");

			maxValueDisplay.Minimum = newValue;
		}

		public void MaxValueUpdated(int newValue)
		{
			model.MaxValue = newValue;

			var minValueDisplay = view.FindSubcontrol<NumericUpDown>("MinValueDisplay");

			minValueDisplay.Maximum = newValue;
		}

		public void UpdateCurrentReading()
		{
			var currentReadingDisplay = view.FindSubcontrol<NumericUpDown>("CurrentReadingDisplay");

			currentReadingDisplay.Value = model.GetCurrentReading();
		}
	}
}
