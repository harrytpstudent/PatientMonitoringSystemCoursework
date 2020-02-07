using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
    class LoginSystemController
    {
        private readonly LoginSystemView loginSystemView;

        public LoginSystemController(LoginSystemView loginSystemView)
        {
            this.loginSystemView = loginSystemView;
        }

        public void ShowLoginDialog()
        {
            loginSystemView.Show();
            loginSystemView.ShowLoginView();
        }

        public void ShowRegisterDialog()
        {
            loginSystemView.ShowRegisterView();
        }

        public void RemoveLoginView()
        {
            loginSystemView.RemoveLoginSystemView();
        }

        public void RemoveRegisterView()
        {
            loginSystemView.RemoveLoginSystemView();
        }
    }
}
