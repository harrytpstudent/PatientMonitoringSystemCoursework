using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PatientMonitoringSystem.Enums;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.Factory;

namespace PatientMonitoringSystem.Tests
{
	[TestFixture]
	class ModuleCreationTests
	{
		[TestCase]
		public void CreateStrategyReturnsBloodPressure() {
			ModuleFactory module_factory = new ModuleFactory();
			IModuleStrategy returned_strat = module_factory.CreateStrategy(ModuleType.BloodPressure);
			Assert.IsInstanceOf(typeof(BloodPressureStrategy), returned_strat);
		}

		[TestCase]
		public void CreateStrategyReturnsOxygenLevel()
		{
			ModuleFactory module_factory = new ModuleFactory();
			IModuleStrategy returned_strat = module_factory.CreateStrategy(ModuleType.OxygenLevel);
			Assert.IsInstanceOf(typeof(OxygenStrategy), returned_strat);
		}

		[TestCase]
		public void CreateStrategyReturnsCorrectDefault()
		{
			ModuleFactory module_factory = new ModuleFactory();
			IModuleStrategy returned_strat = module_factory.CreateStrategy((ModuleType)3);
			Assert.IsInstanceOf(typeof(BloodPressureStrategy), returned_strat);
		}
	}
}
