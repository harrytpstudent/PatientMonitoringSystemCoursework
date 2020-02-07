using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
    public partial class RegisterView : UserControl
    {
        private readonly RegisterController controller;
        private readonly Action onClose;
        private readonly Action onLogin;

        public RegisterView(Action onClose, Action onLogin)
        {
            InitializeComponent();

            controller = new RegisterController(this);
            this.onClose = onClose;
            this.onLogin = onLogin;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
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
    }
}
