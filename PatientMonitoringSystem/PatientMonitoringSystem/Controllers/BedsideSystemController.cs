using System;
using System.Configuration;
using System.Linq;
using PatientMonitoringSystem.Core.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;
using PatientMonitoringSystem.Core.Models.Enums;
using System.Collections.Generic;

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

		public Guid AddModule(string name, ModuleType moduleType)
		{
			var module = new Module(name, moduleType, 0, 0);
			bedsideSystem.Modules.Add(module);
			return module.ModuleId;
		}

		public void RemoveModule(Guid moduleId)
		{
			IModule module = bedsideSystem.Modules.Single(m => m.ModuleId == moduleId);
			bedsideSystem.Modules.Remove(module);
			module.Dispose();
		}

		public bool CanAddAnotherModule() {
			return bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;
		}

		public string GetBedsideName()
		{
			return $"{bedsideSystem.Name} ({bedsideSystem.BedsideSystemId})";
		}

		public List<Guid> GetModuleIds()
		{
			List<Guid> moduleIds = new List<Guid>();
			foreach (IModule module in bedsideSystem.Modules) {
				moduleIds.Add(module.ModuleId);
			}

			return moduleIds;
		}

		public IModule GetModule(Guid moduleId)
		{
			foreach (IModule module in bedsideSystem.Modules) {
				if (module.ModuleId == moduleId) {
					return module;
				}
			}
			return null;
		}
	}
}

