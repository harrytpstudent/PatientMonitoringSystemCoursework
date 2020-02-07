using System;
using System.Linq;
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

		public void ViewBedsideSystem(Guid bedsideSystemId)
		{
			var bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId);

			controlSystemView.ViewBedsideSystem(bedsideSystemId);
		}

		public void ShowLoginForm()
		{
			var loginForm = new LoginView();
			loginForm.ShowDialog();
		}
	}
}
