using System;
using System.Configuration;
using System.Linq;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;

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

		public void AddModule(string name, string strategyType)
		{
			IModuleStrategy strategy = CreateStrategy(strategyType);
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

		private IModuleStrategy CreateStrategy(string strategyName) {
			switch (strategyName) {
				case "Blood Pressure":
					return new BloodPressureStrategy();
				case "Oxygen Level":
					return new OxygenStrategy();
				default:
					return new BloodPressureStrategy();
			}
		}
	}
}
