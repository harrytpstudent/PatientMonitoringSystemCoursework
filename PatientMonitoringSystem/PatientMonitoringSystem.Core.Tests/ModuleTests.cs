using System;
using NUnit.Framework;
using System.Threading;
using PatientMonitoringSystem.Core.Models;
using PatientMonitoringSystem.Core.Models.Enums;

namespace PatientMonitoringSystem.Core.Tests
{
    [TestFixture]
    public class ModuleTests
    {
        [Test]
        public void Constructor_ClassMembersInitialised()
        {
            const string name = "testing";
            const ModuleType type = ModuleType.BloodPressure;
            const int maxValue = 100;
            const int minValue = 0;

            var module = new Module(name, type, minValue, maxValue);

            Assert.That(module.ModuleId, Is.Not.EqualTo(Guid.Empty));
            Assert.That(module.Name, Is.EqualTo(name));
            Assert.That(module.MinValue, Is.EqualTo(minValue));
            Assert.That(module.MaxValue, Is.EqualTo(maxValue));
            Assert.That(module.CurrentReading, Is.Not.Null);
            Assert.That(module.ValueBreached, Is.Not.Null);
        }

        [Test]
        public void CurrentReading_ValueIsChanging()
        {
            const string name = "testing";
            const ModuleType type = ModuleType.BloodPressure;
            const int maxValue = 100;
            const int minValue = 0;

            var module = new Module(name, type, minValue, maxValue);
            int currentReading = module.CurrentReading;
            Thread.Sleep(1000);

            Assert.That(module.CurrentReading, Is.Not.EqualTo(currentReading));
        }

        [Test]
        public void Dispose_IsDisposed()
        {
            const string name = "testing";
            const ModuleType type = ModuleType.BloodPressure;
            const int maxValue = 100;
            const int minValue = 0;

            var module = new Module(name, type, minValue, maxValue);
            module.Dispose();
            int currentReading = module.CurrentReading;
            Thread.Sleep(2000);
            Assert.That(module.CurrentReading, Is.EqualTo(currentReading));
        }
    }
}
