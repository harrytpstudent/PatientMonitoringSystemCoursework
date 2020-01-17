using System;

namespace PatientMonitoringSystem
{
	public class OxygenPressureModule : IModule
	{
		private readonly Random randomNumberGenerator;

		public Guid Id { get; }

		public string Name { get; }

		public int MinValue { get; set; }

		public int MaxValue { get; set; }

		public OxygenPressureModule()
		{
			Id = Guid.NewGuid();
			Name = "Oxygen Pressure";
		}

		// We want to simulate the min/max limits occasionally being breached.
		public int GetCurrentReading() => randomNumberGenerator.Next(MinValue - 1, MaxValue + 2);
	}
}
