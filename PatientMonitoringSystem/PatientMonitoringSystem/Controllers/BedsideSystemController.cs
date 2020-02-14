using System;
using System.Configuration;
using System.Linq;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;
using PatientMonitoringSystem.Enums;
using PatientMonitoringSystem.Factory;
using System.Timers;

namespace PatientMonitoringSystem.Controllers
{
	public class BedsideSystemController
	{
		private readonly BedsideSystemView bedsideSystemView;

		private readonly IBedsideSystem bedsideSystem;

		private readonly int maxModulesPerBedsideSystem;

		private Timer poller;

		public BedsideSystemController(BedsideSystemView bedsideSystemView, Guid bedsideSystemId)
		{
			this.bedsideSystemView = bedsideSystemView;
			bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId);
			maxModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["MaxModulesPerBedsideSystem"]);
			poller = new Timer();
			poller.Elapsed += new ElapsedEventHandler(UpdateCurrentReading);
			poller.Interval = 1000;
			poller.Enabled = true;
		}

		public void Initialise()
		{
			var bedsideSystemViewModel = new BedsideSystemViewModel
			{
				Name = bedsideSystem.Name,
				Id = bedsideSystem.BedsideSystemId,
				ModuleIds = bedsideSystem.Modules.Select(module => module.ModuleId)
			};

			var canAddAnotherModule = bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;

			bedsideSystemView.Initialise(bedsideSystemViewModel, canAddAnotherModule);
		}

		public void UpdateCurrentReading(object source, ElapsedEventArgs e)
		{
			bedsideSystemView.UpdateCurrentReading();
		}

		public void AddModule(string name, ModuleType moduleType)
		{
			var module = new Module(name, moduleType, 0, 0);

			Program.Modules.Add(module);

			bedsideSystem.Modules.Add(module);

			var canAddAnotherModule = bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;

			bedsideSystemView.AddModule(module.ModuleId, canAddAnotherModule);
		}

		public void RemoveModule(Guid moduleId)
		{
			var module = Program.Modules.Single(m => m.ModuleId == moduleId);

			bedsideSystem.Modules.Remove(module);

			Program.Modules.Remove(module);

			bedsideSystemView.RemoveModule(moduleId);
		}
	}
}
