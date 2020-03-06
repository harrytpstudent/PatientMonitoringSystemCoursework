using System;
using System.Linq;
using PatientMonitoringSystem.Views;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Controllers
{
	public class ControlSystemController
	{

		public ControlSystemController()
		{
		}

		public ControlSystemView Initialise()
		{
			//controlSystemView.Initialise();
			return new ControlSystemView();
		}

		public IBedsideSystem ViewBedsideSystem(Guid bedsideSystemId)
		{
			var bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId);
			return bedsideSystem;
		}
	}
}
