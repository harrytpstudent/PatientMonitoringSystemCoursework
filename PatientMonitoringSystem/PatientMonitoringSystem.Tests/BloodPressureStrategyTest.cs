using System;
using NUnit.Framework;

namespace PatientMonitoringSystem.Tests
{
	[TestFixture]
	public class BloodPressureStrategyTests
	{
		[Test]
		public void TestStrategySet() { // TODO: Make this a unit test by mocking out the IModuleStrategy. I can show you how to use a cool library called Moq to do this.

			BloodPressureStrategy blood_pressure_strat = new BloodPressureStrategy();
			int test = blood_pressure_strat.GetCurrentReading(1, 10);
			Console.WriteLine(test);
		}

		// TODO: Validation hasn't changed. Copy the tests from the old BloodPressureModuleTests found in source control.
	}
}
