using System;
using System.Linq;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.ViewModels;

namespace PatientMonitoringSystem.Controllers
{
	public class BedsideSystemController
	{
		private readonly BedsideSystemView bedsideSystemView;

		private readonly IBedsideSystem bedsideSystem;

		public BedsideSystemController(BedsideSystemView bedsideSystemView, Guid bedsideSystemId)
		{
			this.bedsideSystemView = bedsideSystemView;
			bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId);
		}

		public void Initialise()
		{
			var bedsideSystemViewModel = new BedsideSystemViewModel
			{
				BedsideSystemId = bedsideSystem.BedsideSystemId.ToString(),
				ModuleIds = bedsideSystem.Modules.Select(module => module.ModuleId)
			};

			bedsideSystemView.Initialise(bedsideSystemViewModel);
		}

		public void UpdateCurrentReading()
		{
			bedsideSystemView.UpdateCurrentReading();
		}

		public void AddModule(string name)
		{
			var module = new Module(new BloodPressureStrategy(), name, 0, 0);

			Program.Modules.Add(module);

			bedsideSystem.Modules.Add(module);

			bedsideSystemView.AddModule(module.ModuleId);
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
