using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem
{
	public interface IBedsideSystem
	{
		Guid Id { get; }

		List<Module> Modules { get; }
	}
}
