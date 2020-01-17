using System;

namespace PatientMonitoringSystem
{
	public interface IModule
	{
		Guid Id { get; }

		string Name { get; }

		int MinValue { get; set; }

		int MaxValue { get; set; }

		int GetCurrentReading();
	}
}
