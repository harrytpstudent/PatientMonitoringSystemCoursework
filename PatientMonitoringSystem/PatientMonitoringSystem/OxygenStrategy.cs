using System;

namespace PatientMonitoringSystem
{
	public class OxygenStrategy
	{
		private readonly Random randomNumberGenerator = new Random();
		public int GetCurrentReading(int minvalue, int maxvalue) => randomNumberGenerator.Next(minvalue, maxvalue + 100);
	}
}
