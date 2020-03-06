﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.Core.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Core.Models.Enums;
using PatientMonitoringSystem.Views.Eventing;
namespace PatientMonitoringSystem.Views
{
	public partial class BedsideSystemView : UserControl, IDisposable
	{
		private SemaphoreSlim GetModuleRowViewsSemaphor;
		private readonly BedsideSystemController bedsideController;
		int maxModulesPerBedsideSystem;

		public BedsideSystemView(BedsideSystemController newBedsideController)
		{
			bedsideController = newBedsideController;
			GetModuleRowViewsSemaphor = new SemaphoreSlim(1, 1);

			InitializeComponent();

			maxModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["MaxModulesPerBedsideSystem"]);

			Disposed += OnDisposed;
		}

		private void BedsideSystemView_Load(object sender, EventArgs e)
		{
			var canAddAnotherModule = bedsideController.CanAddAnotherModule();
			Initialise(canAddAnotherModule);
		}

		private void Updater_Tick(object sender, EventArgs e)
		{
			UpdateCurrentReading();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			var moduleName = NameEntry.Text;
			ModuleType moduleType = (ModuleType)ModuleCombo.SelectedItem;
			Guid moduleId = bedsideController.AddModule(moduleName, moduleType);
			AddModule(moduleId);
		}

		public void OnRemoveModule(object sender, OnRemoveModuleEventArgs e)
		{
			RemoveModule(e.ModuleId);
			bedsideController.RemoveModule(e.ModuleId);
		}

		public void Initialise(bool canAddAnotherModule)
		{
			Text = bedsideController.GetBedsideName();

			Table.RowStyles.RemoveAt(0);
			Table.RowCount = 0;

			foreach (var moduleId in bedsideController.GetModuleIds())
			{
				AddModule(moduleId);
			}

			ModuleCombo.DataSource = Enum.GetValues(typeof(ModuleType));
			AddButton.Enabled = canAddAnotherModule;
			Dock = DockStyle.Fill;
		}

		public void UpdateCurrentReading()
		{
			var moduleRowViews = GetModuleRowViews();

			// We want to do all of these refreshes at around the same time and avoid having lots of timers.
			foreach (var moduleRowView in moduleRowViews)
			{
				moduleRowView.RefreshCurrentReading();
			}
		}

		public void AddModule(Guid moduleId)
		{
			//var moduleRowView = Program.ModuleRowController.Initialise(moduleId);
			ModuleRowController moduleRowView = new ModuleRowView();
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

			var moduleRowView = GetModuleRowViews().Single(mrv => mrv.ModuleId == moduleId);

			var rowIndex = Table.GetPositionFromControl(moduleRowView).Row;

			Table.RowStyles.RemoveAt(rowIndex);
			Table.Controls.Remove(moduleRowView);

			AddButton.Enabled = true;
		}

		public void OnDisposed(object sender, EventArgs e)
		{
			Updater.Dispose(); // Just in case it doesn't happen automatically.
			GetModuleRowViewsSemaphor.Dispose();
		}

		private IEnumerable<ModuleRowView> GetModuleRowViews()
		{
			GetModuleRowViewsSemaphor.Wait();

			try
			{
				return Table.Controls.OfType<ModuleRowView>()
					.ToArray(); // No lazy evaluation (deferred execution).
			}
			finally
			{
				GetModuleRowViewsSemaphor.Release();
			}
		}
	}
}
