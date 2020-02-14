using System;
using System.Linq;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
	public class ModuleRowController
	{
		private readonly ModuleRowView moduleRowView;

		private readonly IModule module;

		public ModuleRowController(ModuleRowView moduleRowView, Guid moduleId)
		{
			this.moduleRowView = moduleRowView;
			module = Program.Modules.Single(m => m.ModuleId == moduleId);
		}

		public void Initialise()
		{
			var reading = module.GetCurrentReading();

			var moduleRowViewModel = new ModuleRowViewModel
			{
				MinValue = module.MinValue,
				CurrentReading = reading,
				MaxValue = module.MaxValue,
				Id = module.ModuleId,
				Name = module.Name,
				Type= module.Type
			};

			moduleRowView.Initialise(moduleRowViewModel);
		}

		public void UpdateMinValue(int value)
		{
			module.MinValue = value;

			moduleRowView.UpdateMinValue(value);
		}

		public void UpdateMaxValue(int value)
		{
			module.MaxValue = value;

			moduleRowView.UpdateMaxValue(value);
		}

		public bool CheckValueBreached(int value) {
			if (value > module.MaxValue)
			{
				Console.WriteLine("BREACH of MAX value {0} with new value {1}", module.MaxValue, value);
				return true;
			}
			else if (value < module.MinValue)
			{
				Console.WriteLine("BREACH of MIN value {0} with new value {1}", module.MinValue, value);
				return true;
			}

			return false;
		}

		public void UpdateCurrentReading()
		{
			var reading = module.GetCurrentReading();
			bool breached = CheckValueBreached(reading);
			moduleRowView.UpdateCurrentReading(reading);
		}

		public void RemoveModule()
		{
			moduleRowView.RemoveModule();
		}
	}
}
