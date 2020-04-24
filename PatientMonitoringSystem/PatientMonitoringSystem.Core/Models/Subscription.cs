namespace PatientMonitoringSystem.Core.Models
{
	public class Subscription
	{
		public long SubscriptionId { get; set; }

		public User User { get; set; }

		public NotificationType NotificationType { get; set; }

		public string Destination { get; set; }
	}
}
