using PatientMonitoringSystem.Controllers;
using System.Windows.Forms;

namespace PatientMonitoringSystem.Views
{
	public partial class ControlSystemView : Form
	{
		private readonly ControlSystemController controller;

		public ControlSystemView()
		{
			InitializeComponent();

			controller = new ControlSystemController(this);
		}

		public void Initialise()
		{
			Text = "Control System";
		}
	}
}
