using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientMonitoringSystem.Views
{
    public partial class LoginSystemView : UserControl
    {
        private string username;
        private string password;
        private readonly Action onLogin;

        public LoginSystemView(Action onLogin)
        {
            InitializeComponent();
            this.onLogin = onLogin;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            username = UsernameTextbox.Text;
            password = PasswordTextbox.Text;
            UsernameTextbox.Clear();
            PasswordTextbox.Clear();

            //query username + password in db

            //disable email check box if only medical staff
            onLogin.Invoke();
        }
    }
}
