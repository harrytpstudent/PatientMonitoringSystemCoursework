using PatientMonitoringSystem.Core.Models.Enums;
using PatientMonitoringSystem.Core.Strategies;

namespace PatientMonitoringSystem.Core.Factories
{
	public class ModuleFactory
	{
		public IModuleStrategy CreateStrategy(ModuleType strategyType)
		{
			switch (strategyType)
			{
				case ModuleType.BloodPressure:
					return new BloodPressureStrategy();
				case ModuleType.OxygenLevel:
					return new OxygenStrategy();
				default:
					return new BloodPressureStrategy();
			}
		}
	}
}
