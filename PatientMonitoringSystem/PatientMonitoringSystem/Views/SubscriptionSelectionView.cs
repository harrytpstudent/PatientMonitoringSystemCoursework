using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;

namespace PatientMonitoringSystem.Views
{
    public partial class SubscriptionSelectionView : Form
    {
        private readonly SubscriptionSelectionController controller;

        public SubscriptionSelectionView(string username)
        {
            InitializeComponent();

            controller = new SubscriptionSelectionController(this, username);
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var sendPagerNotifications = PagerNotificationCheckBox.Checked;
            var sendSMSNotifications = SmsNotificationCheckBox.Checked;
            var sendEmailNotifications = EmailNotificationCheckBox.Checked;
            controller.ConfirmSelection(sendPagerNotifications, sendSMSNotifications, sendEmailNotifications);
            controller.CloseSubscriptionSelector();
        }
    }
}
