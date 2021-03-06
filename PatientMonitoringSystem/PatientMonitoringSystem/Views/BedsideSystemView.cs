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
		private readonly BedsideSystemController bedsideController;
		private List<ModuleRowView> moduleRowViewList = new List<ModuleRowView>();

		int maxModulesPerBedsideSystem;

		public BedsideSystemView(BedsideSystemController newBedsideController)
		{
			bedsideController = newBedsideController;

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

			if (Program.CurrentUser == null)
			{
				ShowLoginView();
			}
			else
			{
				ShowUserView();
			}

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
			// We want to do all of these refreshes at around the same time and avoid having lots of timers.
			foreach (var moduleRowView in moduleRowViewList)
			{
				moduleRowView.RefreshCurrentReading();
			}
		}

		public void AddModule(Guid moduleId)
		{
			IModule module = bedsideController.GetModule(moduleId);
			ModuleController moduleController = new ModuleController(module);
			ModuleRowView moduleRowView = new ModuleRowView(moduleController);

			moduleRowViewList.Add(moduleRowView);
			moduleRowView.OnRemoveModule += OnRemoveModule;

			Table.RowStyles.Add(new RowStyle());
			Table.Controls.Add(moduleRowView, 0, Table.RowCount - 1);

			AddButton.Enabled = bedsideController.CanAddAnotherModule();
		}

		public void AddModule(Guid moduleId, bool canAddAnotherModule)
		{
			AddModule(moduleId);

			NameEntry.Text = "";

			AddButton.Enabled = canAddAnotherModule;
		}

		public void RemoveModule(Guid moduleId)
		{
			ModuleRowView moduleRowView = moduleRowViewList.Single(mrv => mrv.ModuleId == moduleId);
			var rowIndex = Table.GetPositionFromControl(moduleRowView).Row -1;
			Table.RowStyles.RemoveAt(rowIndex);
			Table.Controls.Remove(moduleRowView);

			AddButton.Enabled = true;
		}

		public void OnLoginSuccess(object sender, EventArgs e) 
		{
			MessageBox.Show($"Login success! Show the UserView so that the user can subscribe to notifications.\nName: {Program.CurrentUser.Name}, Role: {Program.CurrentUser.Role.Name}");

			ShowUserView();
		}

		public void OnLogout(object sender, EventArgs e)
		{
			ShowLoginView();
		}

		public void OnDisposed(object sender, EventArgs e)
		{
			Updater.Dispose(); // Just in case it doesn't happen automatically.
		}

		private void ShowLoginView()
		{
			Table.Controls.OfType<UserView>().ToList().ForEach(userView => Table.Controls.Remove(userView));

			var loginView = new LoginView(new LoginController());

			loginView.OnLoginSuccess += OnLoginSuccess;

			Table.Controls.Add(loginView);
		}

		private void ShowUserView()
		{
			Table.Controls.OfType<LoginView>().ToList().ForEach(loginView => Table.Controls.Remove(loginView));

			var userView = new UserView(new UserController());

			userView.OnLogout += OnLogout;

			Table.Controls.Add(userView);
		}
	}
}
