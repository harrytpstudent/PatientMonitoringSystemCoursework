using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PatientMonitoringSystem.Models;
using System.Threading.Tasks;
namespace PatientMonitoringSystem.Core.Tests
{
	[TestFixture]
	public class UnitTest1
	{
		[Test]
		public void TestMethod1()
		{
			var module = new Module("Module 1", 1, 10);
			Task.Delay(100000).Wait();
			module.Dispose();
		}
	}
}
