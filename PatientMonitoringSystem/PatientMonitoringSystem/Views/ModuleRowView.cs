﻿using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.Enums;
using PatientMonitoringSystem.ViewModels;

namespace PatientMonitoringSystem.Views
{
	public partial class ModuleRowView : UserControl
	{
		private readonly ModuleRowController controller;

		private readonly Action<Guid> onRemoveModule;

		private delegate void SafeUpdateCurrentReading(int reading);
		public Guid ModuleId { get; }

		public ModuleRowView(Guid moduleId, Action<Guid> onRemoveModule)
		{
			InitializeComponent();

			controller = new ModuleRowController(this, moduleId);
			this.onRemoveModule = onRemoveModule;

			ModuleId = moduleId;
		}

		private void ModuleRowView_Load(object sender, EventArgs e)
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

		public void Initialise(ModuleRowViewModel moduleViewModel)
		{
			MinValueEntry.Minimum = -2147483648;
			MinValueEntry.Maximum = moduleViewModel.MaxValue;
			MinValueEntry.Value = moduleViewModel.MinValue;
			CurrentReadingDisplay.Value = moduleViewModel.CurrentReading;
			MaxValueEntry.Minimum = moduleViewModel.MinValue;
			MaxValueEntry.Maximum = 2147483647;
			MaxValueEntry.Value = moduleViewModel.MaxValue;
			IdDisplay.Text = moduleViewModel.Id.ToString();
			NameDisplay.Text = moduleViewModel.Name;
			TypeDisplay.Text = Enum.GetName(typeof(ModuleType), moduleViewModel.Type);
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

		public void UpdateCurrentReading(int reading)
		{
			if (CurrentReadingDisplay.InvokeRequired)
			{
				var dlg = new SafeUpdateCurrentReading(UpdateCurrentReading);
				CurrentReadingDisplay.Invoke(dlg, new object[] { reading });
			}
			else
			{
				CurrentReadingDisplay.Value = reading;
			}
		}

		public void RemoveModule()
		{
			onRemoveModule(ModuleId);
		}
	}
}
