using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
    class RegisterController
    {
        private readonly RegisterView registerView;

        public RegisterController(RegisterView registerView)
        {
            this.registerView = registerView;
        }

        public void CloseView()
        {
            registerView.CloseRegisterView();
        }

        public void ProcessRegistration()
        {

        }

        public void OpenLoginView()
        {
            registerView.OpenLoginView();
        }
    }
}
