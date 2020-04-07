using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
    public partial class UserView : UserControl
    {
	    private readonly UserController controller;

	    public event EventHandler<EventArgs> OnLoginSuccess;

		public UserView(UserController controller)
		{
			this.controller = controller;

            InitializeComponent();
        }

		// TODO: Finish functionality.
	}
}
