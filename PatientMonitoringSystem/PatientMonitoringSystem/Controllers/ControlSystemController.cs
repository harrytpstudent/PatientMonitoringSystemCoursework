using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
	public class ControlSystemController
	{
		private readonly ControlSystemView controlSystemView;

		public ControlSystemController(ControlSystemView controlSystemView)
		{
			this.controlSystemView = controlSystemView;
		}

		public void Initialise()
		{
			controlSystemView.Initialise();
		}
	}
}
