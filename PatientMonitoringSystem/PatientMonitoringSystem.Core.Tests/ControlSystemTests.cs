using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Core.Tests
{
	[TestFixture]
	class ControlSystemTests
	{
		[Test]
		// Check that the correct class members are setup when ControlSystem object is constructed
		public void Constructor_ClassMembersInitialised()
		{
			List<BedsideSystem> bedsideList = new List<BedsideSystem>();
			bedsideList.Add(new BedsideSystem("testBedside"));

			ControlSystem controlSystem = new ControlSystem(bedsideList);
			Assert.That(controlSystem.AlarmRaised, Is.False);
			Assert.That(controlSystem.BedsideSystems, Is.Not.Null);
		}

		[Test]
		// Check that the added BedsideSystem objects are subscribed to an event
		public void AddBedside_BedsideIsSubscribed()
		{
			List<IBedsideSystem> bedsideList = new List<IBedsideSystem>();

			var mockBedside = new Mock<IBedsideSystem>();
			mockBedside.SetupAdd(bedside => bedside.OnAlarmRaised += It.IsAny<EventHandler<Guid>>());
			bedsideList.Add(mockBedside.Object);

			ControlSystem controlSystem = new ControlSystem(bedsideList);
			Assert.That(controlSystem.BedsideSystems, Does.Contain(mockBedside.Object));

			mockBedside.VerifyAdd(bedside => bedside.OnAlarmRaised += It.IsAny<EventHandler<Guid>>(), Times.Once());
		}

		[Test]
		// Check that the added BedsideSystem objects are subscribed to an event
		public void RemoveBedside_BedsideIsUnsubscribed_AndDisposed()
		{
			List<IBedsideSystem> bedsideList = new List<IBedsideSystem>();

			var mockBedside = new Mock<IBedsideSystem>();
			Guid guid = Guid.NewGuid();
			mockBedside.SetupGet(b => b.BedsideSystemId).Returns(guid);
			mockBedside.SetupRemove(bedside => bedside.OnAlarmRaised -= It.IsAny<EventHandler<Guid>>());

			bedsideList.Add(mockBedside.Object);

			ControlSystem controlSystem = new ControlSystem(bedsideList);
			Assert.That(controlSystem.BedsideSystems, Does.Contain(mockBedside.Object));
			controlSystem.RemoveBedsideSystem(guid);

			Assert.That(controlSystem.BedsideSystems, Does.Not.Contain(mockBedside.Object));

			mockBedside.VerifyRemove(bedside => bedside.OnAlarmRaised -= It.IsAny<EventHandler<Guid>>(), Times.Once());
			mockBedside.Verify(bedside => bedside.Dispose());
		}


	}
}
