using System;
using Moq;
using NUnit.Framework;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Core.Tests
{
	[TestFixture]
	public class BedsideSystemTests
	{
		[Test]
		public void Constructor_ClassMembersInitialised()
		{
			const string name = "testing";

			var bedsideSystem = new BedsideSystem(name);

			Assert.That(bedsideSystem.BedsideSystemId, Is.Not.EqualTo(Guid.Empty));
			Assert.That(bedsideSystem.Name, Is.EqualTo(name));
			Assert.That(bedsideSystem.AlarmRaised, Is.False);
			Assert.That(bedsideSystem.Modules, Is.Not.Null);
		}

		[Test]
		public void AddModule_ModuleIsSubscribed()
		{
			const string name = "testing";

			var mockModule = new Mock<IModule>();

			mockModule.SetupAdd(module => module.OnValueBreached += It.IsAny<EventHandler<Guid>>());

			var bedsideSystem = new BedsideSystem(name);

			bedsideSystem.AddModule(mockModule.Object);

			Assert.That(bedsideSystem.Modules, Does.Contain(mockModule.Object));

			mockModule.VerifyAdd(module => module.OnValueBreached += It.IsAny<EventHandler<Guid>>(), Times.Once());
		}

		[Test]
		public void RemoveModule_ModuleIsUnsubscribed_AndDisposed()
		{
			const string name = "testing";

			var mockModule = new Mock<IModule>();

			mockModule.SetupRemove(module => module.OnValueBreached -= It.IsAny<EventHandler<Guid>>());

			var bedsideSystem = new BedsideSystem(name);

			bedsideSystem.AddModule(mockModule.Object);
			bedsideSystem.RemoveModule(mockModule.Object.ModuleId);

			Assert.That(bedsideSystem.Modules, Does.Not.Contain(mockModule.Object));

			mockModule.VerifyRemove(module => module.OnValueBreached -= It.IsAny<EventHandler<Guid>>(), Times.Once());
			mockModule.Verify(module => module.Dispose());
		}

		[Test]
		public void AlarmRaised_IsSetToTrue_AndOnAlarmRaised_IsTriggered_OnValueBreached()
		{
			const string name = "testing";

			var mockModule = new Mock<IModule>();

			var bedsideSystem = new BedsideSystem(name);

			var onAlarmRaisedWasTriggered = false;

			bedsideSystem.OnAlarmRaised += (sender, moduleId) => onAlarmRaisedWasTriggered = true;

			bedsideSystem.AddModule(mockModule.Object);

			mockModule.Raise(module => module.OnValueBreached += It.IsAny<EventHandler<Guid>>(), mockModule.Object, mockModule.Object.ModuleId);

			Assert.That(bedsideSystem.AlarmRaised, Is.True);
			Assert.That(onAlarmRaisedWasTriggered, Is.True);
		}
	}
}
