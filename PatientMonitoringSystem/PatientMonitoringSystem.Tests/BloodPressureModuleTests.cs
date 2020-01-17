using System.Collections.Generic;
using NUnit.Framework;

namespace PatientMonitoringSystem.Tests
{
	[TestFixture]
	public class BloodPressureModuleTests
	{
		[Test, Explicit]
		public void GetCurrentReading_ReturnsRandomValues()
		{
			const int minValue = 2;
			const int maxValue = 4;
			const int numberOfRuns = 1000;

			var module = new BloodPressureModule(minValue, maxValue);

			var valuesReceived = new List<int>();

			for (var run = 1; run <= numberOfRuns; run++)
			{
				var valueReceived = module.GetCurrentReading();

				valuesReceived.Add(valueReceived);
			}

			for (var expectedValue = minValue - 1; expectedValue <= maxValue + 1; expectedValue++)
			{
				Assert.That(valuesReceived.Contains(expectedValue));
			}
		}
	}
}
