using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitoringSystem;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
    class SubscriptionSelectionController
    {
        private string username;
        private readonly SubscriptionSelectionView subscriptionSelectionView;

        public SubscriptionSelectionController(SubscriptionSelectionView subscriptionSelectionView, string username)
        {
            this.subscriptionSelectionView = subscriptionSelectionView;
            this.username = username;
        }

        public void ShowSubscriptionSelector()
        {
            subscriptionSelectionView.Show();
        }

        public void ConfirmSelection(bool sendPagerNotifications, bool sendSMSNotifications, bool sendEmailNotifications)
        {
            //set user notification options
            var logger = new SubscriptionLogger();
            logger.LogSubscriptionSelection(username, sendPagerNotifications, sendSMSNotifications, sendEmailNotifications);
        }

        public void CloseSubscriptionSelector()
        {
            subscriptionSelectionView.Close();
        }
    }
}
