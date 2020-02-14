using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
    public partial class LoginSystemView : Form
    {
        private readonly LoginSystemController controller;

        public LoginSystemView()
        {
            InitializeComponent();

            controller = new LoginSystemController(this);
        }

        public void ShowLoginView()
        {
            loginSystemPanel.Controls.Clear();
            loginSystemPanel.Controls.Add(new LoginView(RemoveLoginSystemView, ShowRegisterView, Login));
        }

        public void ShowRegisterView()
        {
            loginSystemPanel.Controls.Clear();
            loginSystemPanel.Controls.Add(new RegisterView(RemoveLoginSystemView, ShowLoginView, Register));
        }

        public void RemoveLoginSystemView()
        {
            controller.CloseView();
        }

        public void Login()
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            controller.LoginExsistingUser(username, password);
        }

        public void Register()
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            controller.RegisterNewUser(username, password);
        }
    }
}
