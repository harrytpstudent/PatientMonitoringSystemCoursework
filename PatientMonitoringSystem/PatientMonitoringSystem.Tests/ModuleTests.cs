using System;
using NUnit.Framework;
using PatientMonitoringSystem.Models;

namespace PatientMonitoringSystem.Tests
{
	[TestFixture]
	public class ModuleTests // TODO: Be sure to also test the different strategies in different test classes.
	{
		[Test]
		public void TestStrategySet() { // TODO: Make this a unit test by mocking out the IModuleStrategy. I can show you how to use a cool library called Moq to do this.

			Module blood_pressure_module = new Module(new BloodPressureStrategy(), "foobar", 5, 10);

			int test = blood_pressure_module.GetCurrentReading();
			Console.WriteLine(test);
		}

		// TODO: Validation hasn't changed. Copy the tests from the old BloodPressureModuleTests found in source control.
	}
}
