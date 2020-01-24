using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PatientMonitoringSystem.Tests
{
	[TestFixture]
	public class BloodPressureModuleTests2
	{
		[Test]
		public void TestStrategySet() {

			BloodPressureStrategy blood_pressure_strat = new BloodPressureStrategy();
			int test = blood_pressure_strat.GetCurrentReading(1, 10);
			Console.WriteLine(test);
		}
	}
}
