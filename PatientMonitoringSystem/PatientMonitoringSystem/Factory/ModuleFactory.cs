using PatientMonitoringSystem.Enums;

namespace PatientMonitoringSystem.Factory
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
