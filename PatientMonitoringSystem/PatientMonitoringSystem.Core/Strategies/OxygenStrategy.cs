using System;

namespace PatientMonitoringSystem.Core.Strategies
{
	public class OxygenStrategy : IModuleStrategy
	{
		private readonly Random randomNumberGenerator = new Random();

		public int GetCurrentReading(int minvalue, int maxvalue) => randomNumberGenerator.Next(minvalue, maxvalue + 100);
	}
}
