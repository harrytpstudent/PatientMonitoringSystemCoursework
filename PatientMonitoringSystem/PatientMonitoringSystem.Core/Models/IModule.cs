using System;
using PatientMonitoringSystem.Core.Models.Enums;

namespace PatientMonitoringSystem.Core.Models
{
	public interface IModule : IDisposable
	{
		Guid ModuleId { get; }

		string Name { get; }

		ModuleType ModuleType { get; }

		int MinValue { get; set; }

		int CurrentReading { get; }

		int MaxValue { get; set; }

		event EventHandler<Guid> OnValueBreached;
	}
}
