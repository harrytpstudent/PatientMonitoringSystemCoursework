using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.Views.Eventing;
using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem.Views
{
    public partial class LoginView : UserControl
    {
        private readonly LoginController controller;

        public event EventHandler<OnLoginSuccessEventArgs> OnLoginSuccess;

        public LoginView(LoginController controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            var user = controller.Login(UsernameInput.Text, PasswordInput.Text);

            if (user == null)
            {
                MessageBox.Show("Invalid username/password combination. Try again.");

                return;
            }

            OnLoginSuccess?.Invoke(this, new OnLoginSuccessEventArgs(user));
        }
    }
}
