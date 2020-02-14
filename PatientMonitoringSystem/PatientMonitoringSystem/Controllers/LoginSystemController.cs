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

        public void CloseView()
        {
            loginSystemView.Close();
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

        public void LoginExsistingUser(string username, string password)
        {
            //login

            //then select subscription options
            CreateSubscriptionView(username);
        }

        public void RegisterNewUser(string username, string password)
        {
            //register

            //then select subscription options
            CreateSubscriptionView(username);
        }

        private void CreateSubscriptionView(string username)
        {
            var subscriptionSelection = new SubscriptionSelectionController(new SubscriptionSelectionView(username), username);
            subscriptionSelection.ShowSubscriptionSelector();
        }
    }
}
