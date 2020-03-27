namespace PatientMonitoringSystem.Core.Models
{
	public class User
	{
		public long UserId { get; set; }

		public Role Role { get; set; }

		public string Name { get; set; }

		// Username and PasswordHash deliberately excluded to prevent in-memory exposure.
	}
}
