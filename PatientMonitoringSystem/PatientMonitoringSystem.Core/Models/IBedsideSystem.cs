using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem.Core.Models
{
	public interface IBedsideSystem: IDisposable
	{
		Guid BedsideSystemId { get; }

		string Name { get; }

		IReadOnlyCollection<IModule> Modules { get; }

		event EventHandler<Guid> OnAlarmRaised;
	}
}
