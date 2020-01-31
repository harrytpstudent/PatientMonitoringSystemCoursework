using System;

namespace PatientMonitoringSystem.Models
{


	public class Module : IModule
	{
		private int minValue;

		private int maxValue;

		private IModuleStrategy reading_strategy;

		public Guid ModuleId { get; }

		public string Name { get; }

		public int MinValue
		{
			get => minValue;
			set
			{
				ValidateValues(value, maxValue);

				minValue = value;
			}
		}

		public int MaxValue
		{
			get => maxValue;
			set
			{
				ValidateValues(minValue, value);

				maxValue = value;
			}
		}

		public Module(IModuleStrategy strategy, string name, int initialMinValue, int initialMaxValue)
		{

			ValidateValues(initialMinValue, initialMaxValue);

			reading_strategy = strategy;
			ModuleId = Guid.NewGuid();
			Name = name;
			MaxValue = initialMaxValue;
			MinValue = initialMinValue;

			SetReadingStrategy(strategy);
		}
		public int GetCurrentReading()
		{
			int reading = this.reading_strategy.GetCurrentReading(MinValue, MaxValue);
			return reading;
		}

		private void SetReadingStrategy(IModuleStrategy strategy)
		{
			this.reading_strategy = strategy;
		}
		private void ValidateValues(int minValue, int maxValue)
		{
			if (minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} must not be greater than {nameof(maxValue)}!");
			}
		}
	}
}