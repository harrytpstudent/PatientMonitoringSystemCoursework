using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem.Models
{
	public interface IBedsideSystem
	{
		Guid BedsideSystemId { get; }

		string Name { get; }

		List<IModule> Modules { get; }
	}
}
