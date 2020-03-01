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

		public BedsideSystemController(Guid bedsideSystemId)
		{
			bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId); // TODO: We need to hold a list of the bedsideSystems in this class as a member variable instead of taking the values from program.cs
			maxModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["MaxModulesPerBedsideSystem"]); 
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
		}

		public void UpdateCurrentReading(BedsideSystemView bedsideSystemView)
		{
			bedsideSystemView.UpdateCurrentReading();
		}

		public void AddModule(BedsideSystemView bedsideSystemView, string name, ModuleType moduleType) //TODO: Pull out all references from program
		{
			var module = new Module(name, moduleType, 0, 0);

			Program.Modules.Add(module); // In this case we would have something like BedsideSystems[bedsideId].AddModule(module)

			bedsideSystem.Modules.Add(module);

			var canAddAnotherModule = bedsideSystem.Modules.Count < maxModulesPerBedsideSystem;

			bedsideSystemView.AddModule(module.ModuleId, canAddAnotherModule);
		}

		public void RemoveModule(BedsideSystemView bedsideSystemView, Guid moduleId)
		{
			var module = Program.Modules.Single(m => m.ModuleId == moduleId);

			bedsideSystemView.RemoveModule(moduleId);

			bedsideSystem.Modules.Remove(module);

			Program.Modules.Remove(module);
		}
	}
}
