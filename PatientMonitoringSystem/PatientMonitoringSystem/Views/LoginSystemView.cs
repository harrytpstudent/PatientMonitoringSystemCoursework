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

        public LoginSystemView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            username = UsernameTextbox.Text;
            password = PasswordTextbox.Text;
            UsernameTextbox.Clear();
            PasswordTextbox.Clear();

            //query username + password in db
            //log notificaion settings in db
        }
    }
}
