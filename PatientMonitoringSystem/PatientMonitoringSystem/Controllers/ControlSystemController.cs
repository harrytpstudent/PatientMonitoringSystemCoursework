using System;
using System.Linq;
using System.Collections.Generic;
using PatientMonitoringSystem.Views;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Controllers
{
	public class ControlSystemController
	{

		public ControlSystem controlSystem;
		public ControlSystemController(ControlSystem newControlSystem)
		{
			controlSystem = newControlSystem;
		}

		public IBedsideSystem GetBedsideSystem(Guid bedsideSystemId)
		{
			foreach(IBedsideSystem bedsideSystem in controlSystem.BedsideSystems) {
				if (bedsideSystem.BedsideSystemId == bedsideSystemId) {
					return bedsideSystem;
				}
			}

			return null;
		}

		public Guid GetFirstBedsideSystem() {
			Guid bedsideId = controlSystem.BedsideSystems.First().BedsideSystemId;
			return bedsideId;
		}

		public List<Guid> GetBedsideSystemIds()
		{
			List<Guid> bedsideSystemIds = new List<Guid>();
			foreach (IBedsideSystem bedsideSystem in controlSystem.BedsideSystems)
			{
				bedsideSystemIds.Add(bedsideSystem.BedsideSystemId);
			}

			return bedsideSystemIds;

		}
	}
}
