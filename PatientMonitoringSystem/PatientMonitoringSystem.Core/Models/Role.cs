using System.Collections.Generic;

namespace PatientMonitoringSystem.Core.Models
{
	public class Role
	{
		public long RoleId { get; set; }

		public string Name { get; set; }

		public IEnumerable<Permission> Permissions { get; set; }
	}
}
