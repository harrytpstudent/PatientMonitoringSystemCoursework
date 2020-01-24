using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitoringSystem
{
	public class Module
	{
		private int minValue;
		private int maxValue;
		public Guid Id { get; }

		public string Name { get; }
		public int MinValue {
			get => minValue;
			set {
				ValidateMinValue(value, maxValue);
				minValue = value;
			}
		}

		public int MaxValue {
			get => maxValue;
			set {
				ValidateMaxValue(minValue, value);
				maxValue = value;
			}
		}

		private IModuleStrategy reading_strategy;

		public Module(IModuleStrategy strategy, int initialMinValue, int initialMaxValue) {

			ValidateMinValue(initialMinValue, initialMaxValue);
			minValue = initialMinValue;
			maxValue = initialMaxValue;

			SetReadingStrategy(strategy);

			Id = Guid.NewGuid();
		}
		public int GetCurrentReading () {
			int reading = this.reading_strategy.GetCurrentReading(minValue, maxValue);
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
