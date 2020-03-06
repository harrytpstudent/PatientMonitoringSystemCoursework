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
		private readonly IBedsideSystem bedsideSystem;

		private readonly int maxModulesPerBedsideSystem;

		public BedsideSystemController(IBedsideSystem bedside)
		{
			bedsideSystem = bedside;
			maxModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["MaxModulesPerBedsideSystem"]);
		}

		public void AddModule(string name, ModuleType moduleType)
		{
			var module = new Module(name, moduleType, 0, 0);

			bedsideSystem.Modules.Add(module);
		}

		public void RemoveModule(Guid moduleId)
		{
			IModule module = bedsideSystem.Modules.Single(m => m.ModuleId == moduleId);
			bedsideSystem.Modules.Remove(module);
			Program.Modules.Remove(module);
			module.Dispose();
		}

		public bool CanAddAnotherModule() {
			return bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;
		}
	}
}

