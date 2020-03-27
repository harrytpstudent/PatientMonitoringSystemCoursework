using System.Collections.Generic;

namespace PatientMonitoringSystem.Core.Models
{
	public class Role
	{
		public long RoleId { get; }

		public string Name { get; }

		public IEnumerable<Permission> Permissions { get; }

		public Role(long roleId, IEnumerable<Permission> permissions, string name)
		{
			RoleId = roleId;
			Name = name;
			Permissions = permissions;
		}
	}
}
