using PatientMonitoringSystem.Controllers;
using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem.Views
{
    public partial class LoginView : UserControl
    {
        private readonly LoginController controller;

        public event EventHandler<EventArgs> OnLoginSuccess;

        public LoginView(LoginController controller)
        {
            this.controller = controller;

            InitializeComponent();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
	        try
	        {
		        controller.Login(UsernameInput.Text, PasswordInput.Text);

		        OnLoginSuccess?.Invoke(this, EventArgs.Empty);
			}
	        catch (ArgumentException)
	        {
		        MessageBox.Show("Invalid username/password combination. Try again.");
			}
        }
    }
}
