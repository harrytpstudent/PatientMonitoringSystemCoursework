using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public class ModuleRowController
	{
		private readonly ModuleRowView view;

		private readonly IModule model;

		public event EventHandler<OnRemoveModuleEventArgs> OnRemoveModule;

		public ModuleRowController(ModuleRowView view, IModule model)
		{
			this.view = view;
			this.model = model;
		}

		public void Initialise()
		{
			var minValueEntry = view.FindSubcontrol<NumericUpDown>("MinValueEntry");
			var currentReadingDisplay = view.FindSubcontrol<NumericUpDown>("CurrentReadingDisplay");
			var maxValueEntry = view.FindSubcontrol<NumericUpDown>("MaxValueEntry");
			var nameDisplay = view.FindSubcontrol<Label>("NameDisplay");

			minValueEntry.Value = model.MinValue;
			minValueEntry.Minimum = -2147483648;
			minValueEntry.Maximum = model.MaxValue;
			currentReadingDisplay.Value = model.GetCurrentReading();
			maxValueEntry.Value = model.MaxValue;
			maxValueEntry.Minimum = minValueEntry.Value;
			maxValueEntry.Maximum = 2147483647;
			nameDisplay.Text = model.Name;
		}

		public void MinValueUpdated(int newValue)
		{
			model.MinValue = newValue;

			var maxValueEntry = view.FindSubcontrol<NumericUpDown>("MaxValueEntry");

			maxValueEntry.Minimum = newValue;
		}

		public void MaxValueUpdated(int newValue)
		{
			model.MaxValue = newValue;

			var minValueEntry = view.FindSubcontrol<NumericUpDown>("MinValueEntry");

			minValueEntry.Maximum = newValue;
		}

		public void UpdateCurrentReading()
		{
			var currentReadingDisplay = view.FindSubcontrol<NumericUpDown>("CurrentReadingDisplay");

			currentReadingDisplay.Value = model.GetCurrentReading();
		}

		public void RemoveModule() => OnRemoveModule(this, new OnRemoveModuleEventArgs(model, view));
	}
}
