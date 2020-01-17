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
				ValidateMinMaxValues(value, maxValue);

				minValue = value;
			}
		}

		public int MaxValue
		{
			get => maxValue;
			set
			{
				ValidateMinMaxValues(minValue, value);

				maxValue = value;
			}
		}

		public BloodPressureModule(int initialMinValue, int initialMaxValue)
		{
			ValidateMinMaxValues(initialMinValue, initialMaxValue);

			minValue = initialMinValue;
			maxValue = initialMaxValue;
			randomNumberGenerator = new Random();

			Id = Guid.NewGuid();
			Name = "Blood Pressure";
		}

		// We want to simulate the min/max limits occasionally being breached.
		public int GetCurrentReading() => randomNumberGenerator.Next(minValue - 1, maxValue + 2);

		private void ValidateMinMaxValues(int minValue, int maxValue)
		{
			if (minValue < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(minValue), "is negative! You can't have a negative reading!");
			}

			if (maxValue < minValue)
			{
				throw new ArgumentOutOfRangeException(nameof(maxValue), $"is less than {nameof(minValue)}!");
			}
		}
	}
}
