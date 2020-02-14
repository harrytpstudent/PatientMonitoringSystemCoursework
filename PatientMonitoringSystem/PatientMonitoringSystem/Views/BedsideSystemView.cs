﻿using System;
using System.Linq;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Enums;

namespace PatientMonitoringSystem.Views
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

		private void AddButton_Click(object sender, EventArgs e)
		{
			var moduleName = NameEntry.Text;
			ModuleType moduleType = (ModuleType)ModuleCombo.SelectedItem;
			controller.AddModule(moduleName, moduleType);
		}

		public void OnRemoveModule(Guid moduleId)
		{
			controller.RemoveModule(moduleId);
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
	}
}
