using System;
using System.Collections.Generic;
using NUnit.Framework;
using PatientMonitoringSystem.Models;

namespace PatientMonitoringSystem.Tests
{
	[TestFixture]
	public class BloodPressureModuleTests
	{
		[Test, Explicit] // The behaviour is non-deterministic, hence why this test should only be run manually.
		public void GetCurrentReading_ReturnsRandomValues()
		{
			const int initialMinValue = 2;
			const int initialMaxValue = 4;
			const int numberOfRuns = 1000;

			BloodPressureStrategy strat = new BloodPressureStrategy();
			var module = new Module(strat, "", initialMinValue, initialMaxValue);

			var valuesReceived = new List<int>();

			for (var run = 1; run <= numberOfRuns; run++)
			{
				var valueReceived = module.GetCurrentReading();

				valuesReceived.Add(valueReceived);
			}

			for (var expectedValue = initialMinValue - 1; expectedValue <= initialMaxValue + 1; expectedValue++)
			{
				Assert.That(valuesReceived.Contains(expectedValue));
			}
		}

        [Test]
        public void OnConstruction_WhenMinValueAndinitialMaxValueAreValid_DoesNotThrow()
        {
            const int initialMinValue = 2;
            const int initialMaxValue = 4;

			BloodPressureStrategy strat = new BloodPressureStrategy();
			Module module = null;
            Assert.DoesNotThrow(() => module = new Module(strat, "", initialMinValue, initialMaxValue));

            Assert.That(module.MinValue, Is.EqualTo(initialMinValue));
            Assert.That(module.MaxValue, Is.EqualTo(initialMaxValue));
        }

        [Test]
        public void OnConstruction_WhenMinValueIsNegative_Throws()
        {
            const int initialMinValue = -1;
            const int initialMaxValue = 4;
			BloodPressureStrategy strat = new BloodPressureStrategy();
			Assert.Throws<ArgumentOutOfRangeException>(() => new Module(strat, "", initialMinValue, initialMaxValue));
        }

        [Test]
        public void OnConstruction_WhenMinValueIsGreaterThanMaxValue_Throws()
        {
            const int initialMinValue = 3;
            const int initialMaxValue = 2;
			BloodPressureStrategy strat = new BloodPressureStrategy();
			Assert.Throws<ArgumentOutOfRangeException>(() => new Module(strat, "", initialMinValue, initialMaxValue));
        }

        [Test]
        public void OnMinValueSet_WhenMinValueIsSetNegative_DoesNotThrow()
        {
            const int initialMinValue = 1;
            const int initialMaxValue = 2;
            const int newMinValue = 0;

			BloodPressureStrategy strat = new BloodPressureStrategy();
			var module = new Module(strat, "", initialMinValue, initialMaxValue);

            Assert.DoesNotThrow(() => module.MinValue = newMinValue);

            Assert.That(module.MinValue, Is.EqualTo(newMinValue));
            Assert.That(module.MaxValue, Is.EqualTo(initialMaxValue));
        }

        [Test]
        public void OnMinValueSet_WhenMinValueIsSetNegative_Throws()
        {
            const int initialMinValue = 1;
            const int initialMaxValue = 2;
            const int newMinValue = -1;

			BloodPressureStrategy strat = new BloodPressureStrategy();
			var module = new Module(strat, "", initialMinValue, initialMaxValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => module.MinValue = newMinValue);
        }

        [Test]
        public void OnMinValueSet_WhenMinValueIsSetGreaterThanMaxValue_Throws()
        {
            const int initialMinValue = 1;
            const int initialMaxValue = 2;
            const int newMinValue = 3;

			BloodPressureStrategy strat = new BloodPressureStrategy();
			var module = new Module(strat, "", initialMinValue, initialMaxValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => module.MinValue = newMinValue);
        }

        [Test]
        public void OnMaxValueSet_WhenMinValueIsSetNegative_DoesNotThrow()
        {
            const int initialMinValue = 1;
            const int initialMaxValue = 2;
            const int newMaxValue = 3;

			BloodPressureStrategy strat = new BloodPressureStrategy();
			var module = new Module(strat, "", initialMinValue, initialMaxValue);

            Assert.DoesNotThrow(() => module.MaxValue = newMaxValue);

            Assert.That(module.MinValue, Is.EqualTo(initialMinValue));
            Assert.That(module.MaxValue, Is.EqualTo(newMaxValue));
        }

        [Test]
        public void OnMaxValueSet_WhenMaxValueIsSetLessThanMinValue_Throws()
        {
            const int initialMinValue = 1;
            const int initialMaxValue = 2;
            const int newMaxValue = 0;

			BloodPressureStrategy strat = new BloodPressureStrategy();
			var module = new Module(strat, "", initialMinValue, initialMaxValue);

            Assert.Throws<ArgumentOutOfRangeException>(() => module.MaxValue = newMaxValue);
        }
    }
}
