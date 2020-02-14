using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
    public partial class RegisterView : UserControl
    {
        private readonly RegisterController controller;
        private readonly Action onClose;
        private readonly Action onLogin;
        private readonly Action onRegister;

        public RegisterView(Action onClose, Action onLogin, Action onRegister)
        {
            InitializeComponent();

            controller = new RegisterController(this);
            this.onClose = onClose;
            this.onLogin = onLogin;
            this.onRegister = onRegister;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            controller.ProcessRegistration();
            controller.CloseView();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            controller.OpenLoginView();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            controller.CloseView();
        }

        public void OpenLoginView()
        {
            onLogin();
        }

        public void CloseRegisterView()
        {
            onClose();
        }

        public void RegisterNewUser()
        {
            onRegister();
        }
    }
}
