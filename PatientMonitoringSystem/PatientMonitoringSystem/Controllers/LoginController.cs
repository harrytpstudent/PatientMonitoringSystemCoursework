using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
    class LoginController
    {
        private readonly LoginView loginView;

        public LoginController(LoginView loginView)
        {
            this.loginView = loginView;
        }

        public void ProcessLogin()
        {
            loginView.Login();
        }

        public void RegisterNewUser()
        {
            loginView.SwitchView();
        }

        public void CloseLoginView()
        {
            loginView.CloseView();
        }
    }
}
