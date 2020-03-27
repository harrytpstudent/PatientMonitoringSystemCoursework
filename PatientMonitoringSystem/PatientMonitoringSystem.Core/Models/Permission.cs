namespace PatientMonitoringSystem.Core.Models
{
	public class Permission
	{
		public long PermissionId { get; }

		public string Name { get; }

		public Permission(long permissionId, string name)
		{
			PermissionId = permissionId;
			Name = name;
		}
	}
}
