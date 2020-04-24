using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Views
{
    public partial class UserView : UserControl
    {
	    private readonly UserController controller;

	    public event EventHandler<EventArgs> OnLogout;

	    // Caching the user here, in the front-end code, may constitute a security vulnerability.
		// Ideally, the front-end would be calling a web service, and the web service would store the user and in the session.
		private User currentUser;

		public UserView(UserController controller)
		{
			this.controller = controller;

            InitializeComponent();
		}

		private void UserView_Load(object sender, EventArgs e)
		{
			currentUser = controller.GetCurrentUser();

			NameDisplay.Text = currentUser.Name;

			RoleDisplay.Text = currentUser.Role.Name;

			var pagerNotificationsAllowed = currentUser.Role.Permissions.Any(permission =>
				permission.Name == Constants.PermissionNames.ReceivePagerNotifications);

			var smsNotificationsAllowed = currentUser.Role.Permissions.Any(permission =>
				permission.Name == Constants.PermissionNames.ReceiveSmsNotifications);

			var emailNotificationsAllowed = currentUser.Role.Permissions.Any(permission =>
				permission.Name == Constants.PermissionNames.ReceiveEmailNotifications);

			PagerNotificationsEnabledInput.Enabled = pagerNotificationsAllowed;

			SmsNotificationsEnabledInput.Enabled = smsNotificationsAllowed;

			EmailNotificationsEnabledInput.Enabled = emailNotificationsAllowed;

			PopulateSubscriptionRelatedControls();
		}

		private void PopulateSubscriptionRelatedControls()
		{
			var subscriptions = controller.GetCurrentUserSubscriptions();

			var pagerSubscription = subscriptions.SingleOrDefault(subscription =>
				subscription.NotificationType.Name == Constants.NotificationTypeNames.Pager);

			var smsSubscription = subscriptions.SingleOrDefault(subscription =>
				subscription.NotificationType.Name == Constants.NotificationTypeNames.Sms);

			var emailSubscription = subscriptions.SingleOrDefault(subscription =>
				subscription.NotificationType.Name == Constants.NotificationTypeNames.Email);

			if (pagerSubscription != null)
			{
				PagerNotificationsEnabledInput.Checked = true;
				PagerNotificationsDestinationInput.Text = pagerSubscription.Destination;
			}

			if (smsSubscription != null)
			{
				SmsNotificationsEnabledInput.Checked = true;
				SmsNotificationsDestinationInput.Text = smsSubscription.Destination;
			}

			if (emailSubscription != null)
			{
				EmailNotificationsEnabledInput.Checked = true;
				EmailNotificationsDestinationInput.Text = emailSubscription.Destination;
			}
		}

		private void LogOutButton_Click(object sender, EventArgs e)
		{
			controller.LogOut();

			OnLogout?.Invoke(this, EventArgs.Empty);

			// No need to reset the view as we are expecting the parent to dispose it.
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			PopulateSubscriptionRelatedControls();
		}

		private void ApplyButton_Click(object sender, EventArgs e)
		{
			var subscriptions = new List<Subscription>();

			if (PagerNotificationsEnabledInput.Checked)
			{
				subscriptions.Add(new Subscription
				{
					User = currentUser,
					NotificationType = new NotificationType { Name = Constants.NotificationTypeNames.Pager },
					Destination = PagerNotificationsDestinationInput.Text
				});
			}

			if (SmsNotificationsEnabledInput.Checked)
			{
				subscriptions.Add(new Subscription
				{
					User = currentUser,
					NotificationType = new NotificationType { Name = Constants.NotificationTypeNames.Sms },
					Destination = SmsNotificationsDestinationInput.Text
				});
			}

			if (EmailNotificationsEnabledInput.Checked)
			{
				subscriptions.Add(new Subscription
				{
					User = currentUser,
					NotificationType = new NotificationType { Name = Constants.NotificationTypeNames.Email },
					Destination = EmailNotificationsDestinationInput.Text
				});
			}

			controller.SaveCurrentUserSubscriptions(subscriptions);
		}
    }
}
