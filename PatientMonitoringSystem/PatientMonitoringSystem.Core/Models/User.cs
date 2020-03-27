namespace PatientMonitoringSystem.Core.Models
{
	public class User
	{
		public long UserId { get; }

		public Role Role { get; }

		public string Name { get; }

		// Username and PasswordHash deliberately excluded to prevent in-memory exposure.

		public User(long userId, Role role, string name)
		{
			UserId = userId;
			Role = role;
			Name = name;
		}
	}
}
