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
            registerView.RegisterNewUser();
        }

        public void OpenLoginView()
        {
            registerView.OpenLoginView();
        }
    }
}
