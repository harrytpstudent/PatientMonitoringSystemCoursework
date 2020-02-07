﻿using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.ViewModels;
using System.Drawing;
namespace PatientMonitoringSystem.Views
{
	public partial class ModuleRowView : UserControl
	{
		private readonly ModuleRowController controller;

		private readonly Action<Guid> onRemoveModule;

		public Guid ModuleId { get; }

		public ModuleRowView(Guid moduleId, Action<Guid> onRemoveModule)
		{
			InitializeComponent();

			controller = new ModuleRowController(this, moduleId);
			this.onRemoveModule = onRemoveModule;

			ModuleId = moduleId;
		}

		private void ModuleRow_Load(object sender, EventArgs e)
		{
			controller.Initialise();
		}

		private void MinValueEntry_ValueChanged(object sender, EventArgs e)
		{

			controller.UpdateMinValue((int)MinValueEntry.Value);
		}

		private void MaxValueEntry_ValueChanged(object sender, EventArgs e)
		{
			controller.UpdateMaxValue((int)MaxValueEntry.Value);
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			controller.RemoveModule();
		}

		public void Initialise(ModuleViewModel moduleViewModel)
		{
			MinValueEntry.Value = moduleViewModel.MinValue;
			MinValueEntry.Minimum = -2147483648;
			MinValueEntry.Maximum = moduleViewModel.MaxValue;
			CurrentReadingDisplay.Value = moduleViewModel.CurrentReading;
			MaxValueEntry.Value = moduleViewModel.MaxValue;
			MaxValueEntry.Minimum = moduleViewModel.MinValue;
			MaxValueEntry.Maximum = 2147483647;
			NameDisplay.Text = moduleViewModel.Name;
		}

		public void UpdateMinValue(int value)
		{
			MinValueEntry.Value = value;
			MaxValueEntry.Minimum = value;
		}

		public void UpdateMaxValue(int value)
		{
			MaxValueEntry.Value = value;
			MinValueEntry.Maximum = value;
		}

		public void UpdateCurrentReading()
		{
			controller.UpdateCurrentReading();
		}

		public void UpdateCurrentReading(int reading, bool breached)
		{
			if (breached)
			{
				CurrentReadingDisplay.BackColor = Color.Red;
			}
			else {
				CurrentReadingDisplay.BackColor = Color.White;
			}
			CurrentReadingDisplay.Value = reading;
		}

		public void RemoveModule()
		{
			onRemoveModule(ModuleId);
		}
	}
}
