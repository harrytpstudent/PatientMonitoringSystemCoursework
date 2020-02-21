using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
    public partial class LoginView : UserControl
    {
        private readonly LoginController controller;
        private readonly Action onClose;
        private readonly Action onLogin;
        private readonly Action onRegister;

        public LoginView(Action onClose, Action onRegister, Action onLogin)
        {
            InitializeComponent();

            controller = new LoginController(this);
            this.onClose = onClose;
            this.onRegister = onRegister;
            this.onLogin = onLogin;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            controller.ProcessLogin();
            controller.CloseLoginView();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            controller.RegisterNewUser();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            controller.CloseLoginView();
        }

        public void CloseView()
        {
            onClose();
        }

        public void SwitchView()
        {
            onRegister();
        }

        public void Login()
        {
            onLogin();
        }
    }
}
