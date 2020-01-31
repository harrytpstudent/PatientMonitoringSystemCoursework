using System;
using System.Linq;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
	public class ModuleRowController
	{
		private readonly ModuleRowView moduelRowView;

		private readonly IModule module;

		public ModuleRowController(ModuleRowView moduelRowView, Guid moduleId)
		{
			this.moduelRowView = moduelRowView;
			module = Program.Modules.Single(m => m.ModuleId == moduleId);
		}

		public void Initialise()
		{
			var reading = module.GetCurrentReading();

			var moduleViewModel = new ModuleViewModel
			{
				MinValue = module.MinValue,
				CurrentReading = reading,
				MaxValue = module.MaxValue,
				Name = module.Name
			};

			moduelRowView.Initialise(moduleViewModel);
		}

		public void UpdateMinValue(int value)
		{
			module.MinValue = value;

			moduelRowView.UpdateMinValue(value);
		}

		public void UpdateMaxValue(int value)
		{
			module.MaxValue = value;

			moduelRowView.UpdateMaxValue(value);
		}

		public void UpdateCurrentReading()
		{
			var reading = module.GetCurrentReading();

			moduelRowView.UpdateCurrentReading(reading);
		}

		public void RemoveModule()
		{
			moduelRowView.RemoveModule();
		}
	}
}
