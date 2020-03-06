using System;
using System.Configuration;
using System.Linq;
using PatientMonitoringSystem.Core.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;
using PatientMonitoringSystem.Core.Models.Enums;

namespace PatientMonitoringSystem.Controllers
{
	public class BedsideSystemController
	{
		private readonly BedsideSystemView bedsideSystemView;

		private readonly IBedsideSystem bedsideSystem;

		private readonly int maxModulesPerBedsideSystem;

		public BedsideSystemController(IBedsideSystem bedside)
		{
			bedsideSystem = bedside;
			maxModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["MaxModulesPerBedsideSystem"]);
		}


		public void UpdateCurrentReading()
		{
			bedsideSystemView.UpdateCurrentReading();
		}

		public void AddModule(string name, ModuleType moduleType)
		{
			var module = new Module(name, moduleType, 0, 0);

			bedsideSystem.Modules.Add(module);

			//var canAddAnotherModule = bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;

			//bedsideSystemView.AddModule(module.ModuleId, canAddAnotherModule);
		}

		public void RemoveModule(Guid moduleId)
		{
			IModule module = bedsideSystem.Modules.Single(m => m.ModuleId == moduleId);
			bedsideSystem.Modules.Remove(module);
		}

		public bool CanAddAnotherModule() {
			return bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;
		}

	}
}
