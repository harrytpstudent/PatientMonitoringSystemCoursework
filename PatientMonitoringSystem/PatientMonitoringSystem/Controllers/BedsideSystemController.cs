using System;
using System.Configuration;
using System.Linq;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;
using PatientMonitoringSystem.Enums;
using PatientMonitoringSystem.Factory;

namespace PatientMonitoringSystem.Controllers
{
	public class BedsideSystemController
	{
		private readonly BedsideSystemView bedsideSystemView;

		private readonly IBedsideSystem bedsideSystem;

		private readonly int maxModulesPerBedsideSystem;

		public BedsideSystemController(BedsideSystemView bedsideSystemView, Guid bedsideSystemId)
		{
			this.bedsideSystemView = bedsideSystemView;
			bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId);
			maxModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["MaxModulesPerBedsideSystem"]);
		}

		public void Initialise()
		{
			var bedsideSystemViewModel = new BedsideSystemViewModel
			{
				BedsideSystemId = bedsideSystem.BedsideSystemId.ToString(),
				ModuleIds = bedsideSystem.Modules.Select(module => module.ModuleId)
			};

			var canAddAnotherModule = bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;

			bedsideSystemView.Initialise(bedsideSystemViewModel, canAddAnotherModule);
		}

		public void UpdateCurrentReading()
		{
			bedsideSystemView.UpdateCurrentReading();
		}

		public void AddModule(string name, ModuleType strategyType)
		{
			ModuleFactory module_factory = new ModuleFactory();
			IModuleStrategy strategy = module_factory.CreateStrategy(strategyType);
			var module = new Module(strategy, name, 0, 0);

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
