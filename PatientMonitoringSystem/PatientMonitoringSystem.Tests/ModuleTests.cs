using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PatientMonitoringSystem.Tests
{
	[TestFixture]
	public class BloodPressureModuleTests
	{
		[Test]
		public void TestStrategySet() {

			Module blood_pressure_module = new Module(new BloodPressureStrategy(), 5, 10);

			int test = blood_pressure_module.GetCurrentReading();
			Console.WriteLine(test);
		}
	}
}
