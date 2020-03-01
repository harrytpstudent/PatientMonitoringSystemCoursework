using System;
using System.Linq;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
	public class ControlSystemController
	{
		public ControlSystemController()
		{
		}

		public void ViewBedsideSystem(Guid bedsideSystemId, ControlSystemView controlSystemView)
		{
			var bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId);

			controlSystemView.ViewBedsideSystem(bedsideSystemId);
		}
	}
}
