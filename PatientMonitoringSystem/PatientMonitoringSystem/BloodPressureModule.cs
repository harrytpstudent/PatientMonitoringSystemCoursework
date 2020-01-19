using System;

namespace PatientMonitoringSystem
{
	public class BloodPressureModule : IModule
	{
		private int minValue;

		private int maxValue;

		private readonly Random randomNumberGenerator;

		public Guid Id { get; }

		public string Name { get; }

		public int MinValue
		{
			get => minValue;
			set
			{
				ValidateMinValue(value, maxValue);

				minValue = value;
			}
		}

		public int MaxValue
		{
			get => maxValue;
			set
			{
				ValidateMaxValue(minValue, value);

				maxValue = value;
			}
		}

		public BloodPressureModule(int initialMinValue, int initialMaxValue)
		{
			ValidateMinValue(initialMinValue, initialMaxValue);

			minValue = initialMinValue;
			maxValue = initialMaxValue;
			randomNumberGenerator = new Random();

			Id = Guid.NewGuid();
			Name = "Blood Pressure";
		}

		// We want to simulate the min/max limits occasionally being breached.
		public int GetCurrentReading() => randomNumberGenerator.Next(minValue - 1, maxValue + 2);

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
