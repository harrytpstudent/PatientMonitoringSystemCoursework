using System;
using System.Linq;
using PatientMonitoringSystem.Core.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
	public class ModuleRowController : IDisposable
	{
		public ModuleRowView Initialise(Guid moduleId)
		{
			var module = GetModuleById(moduleId);

			var viewModel = new ModuleRowViewModel
			{
				MinValue = module.MinValue,
				CurrentReading = module.CurrentReading,
				MaxValue = module.MaxValue,
				Id = module.ModuleId,
				Name = module.Name,
				Type = module.ModuleType.ToString()
			};

			return new ModuleRowView(module.ModuleId, viewModel);
		}

		public int GetCurrentReading(Guid moduleId) => GetModuleById(moduleId).CurrentReading;

		public void NotifyMinValueChanged(Guid moduleId, int value) => GetModuleById(moduleId).MinValue = value;

		public void NotifyMaxValueChanged(Guid moduleId, int value) => GetModuleById(moduleId).MaxValue = value;

		private IModule GetModuleById(Guid moduleId)
		{
			IModule module;
			lock (Program.modules_lock)
			{
				module = Program.Modules.Single(m => m.ModuleId == moduleId);
			}
			return module;
		}

		public void Dispose()
		{
			// Dispose stuff in here if necessary.
		}
	}
}
