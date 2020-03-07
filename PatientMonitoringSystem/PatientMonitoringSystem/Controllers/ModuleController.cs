using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitoringSystem.Core.Models;
using PatientMonitoringSystem.Core.Models.Enums;

namespace PatientMonitoringSystem.Controllers
{
	public class ModuleController
	{
		IModule module;

		public ModuleController(IModule newModule) {
			module = newModule;
		}

		public int GetCurrentReading() {
			return module.CurrentReading;
		}

		public string GetName() {
			return module.Name;
		}

		public ModuleType GetType() {
			return module.ModuleType;
		}

		public int GetMaxValue() {
			return module.MaxValue;
		}

		public int GetMinValue() {
			return module.MinValue;
		}

		public Guid GetModuleId() {
			return module.ModuleId;
		}

		public void SetMinValue(int newMinValue)
		{
			module.MinValue = newMinValue;
		}

		public void SetMaxValue(int newMaxValue)
		{
			module.MaxValue = newMaxValue;
		}
	}
}
