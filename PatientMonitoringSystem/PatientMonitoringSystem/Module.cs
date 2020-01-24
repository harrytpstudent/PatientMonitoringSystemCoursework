using System;

namespace PatientMonitoringSystem
{
	public class Module : IModule
	{
		private IModuleStrategy reading_strategy;

		public Guid Id { get; }

		public string Name { get; }

		public int MinValue { get; set; }

		public int MaxValue { get; set; }

		public Module(IModuleStrategy strategy, string name, int initialMinValue, int initialMaxValue) {

			ValidateMinValue(initialMinValue, initialMaxValue);

			reading_strategy = strategy;
			Id = Guid.NewGuid();
			Name = name;
			MinValue = initialMinValue;
			MaxValue = initialMaxValue;

			SetReadingStrategy(strategy);
		}
		public int GetCurrentReading () {
			int reading = this.reading_strategy.GetCurrentReading(MinValue, MaxValue);
			return reading;
		}

		private void SetReadingStrategy(IModuleStrategy strategy) {
			this.reading_strategy = strategy;
		}
		private void ValidateMinValue(int minValue, int maxValue)
		{
			if (minValue < 0 || minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException(nameof(minValue), $"Invalid value. Value must range from 0 to {maxValue}.");
			}
		}

		private void ValidateMaxValue(int minValue, int maxValue)
		{
			if (maxValue < minValue)
			{
				throw new ArgumentOutOfRangeException(nameof(maxValue), $"Invalid value. Value must be greater than or equal to {minValue}.");
			}
		}
	}
}
