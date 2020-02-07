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
    public partial class LoginSystemView : Form
    {
        private readonly LoginSystemController controller;

        public LoginSystemView()
        {
            InitializeComponent();
        }

        public void ShowLoginView()
        {
            loginSystemPanel.Controls.Clear();
            loginSystemPanel.Controls.Add(new LoginView(RemoveLoginSystemView, ShowRegisterView));
        }

        public void ShowRegisterView()
        {
            loginSystemPanel.Controls.Clear();
            loginSystemPanel.Controls.Add(new RegisterView(RemoveLoginSystemView, ShowLoginView));
        }

        public void RemoveLoginSystemView()
        {
            loginSystemPanel.Controls.Clear();
        }

    }
}
