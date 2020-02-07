using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
    public partial class LoginView : UserControl
    {
        private readonly LoginController controller;
        private readonly Action onClose;
        private readonly Action onRegister;

        public LoginView(Action onClose, Action onRegister)
        {
            InitializeComponent();

            controller = new LoginController(this);
            this.onClose = onClose;
            this.onRegister = onRegister;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            controller.RegisterNewUser();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
