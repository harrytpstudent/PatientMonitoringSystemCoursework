using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        }

        public void RegisterNewUser()
        {
            loginView.switchView();
        }

        public void CloseLoginView()
        {
            loginView.closeView();
        }
    }
}
