using System;
using PatientMonitoringSystem.Core;

namespace PatientMonitoringSystem.Core.Models
{
	public interface IModule : IDisposable
	{
		Guid ModuleId { get; }

		string Name { get; }

		int MinValue { get; set; }

		int MaxValue { get; set; }

		event EventHandler<Guid> OnValueBreached;

	}
}
