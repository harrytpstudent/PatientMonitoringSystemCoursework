using System;

namespace PatientMonitoringSystem.Models
{
	public class Module : IModule
	{
		private IModuleStrategy reading_strategy;

		public Guid ModuleId { get; }

		public string Name { get; }

		public int MinValue { get; set; }

		public int MaxValue { get; set; }

		public Module(IModuleStrategy strategy, string name, int initialMinValue, int initialMaxValue) {

			ValidateMinValue(initialMinValue, initialMaxValue);

			reading_strategy = strategy;
			ModuleId = Guid.NewGuid();
			Name = name;
			MinValue = initialMinValue;
			MaxValue = initialMaxValue;

			SetReadingStrategy(strategy);
		}
		public int GetCurrentReading () {
			int reading = this.reading_strategy.GetCurrentReading(MinValue, MaxValue);
			return reading;
		}
	}
}
