using System;

namespace PatientMonitoringSystem
{
	// TODO: Consider whether MinValue and MaxValue should be extracted into a struct.
	// The values are related, and in the UI we may want to validate after both have been specified.
	// Currently, there are scenarios where you have to reduce MinValue before you can reduce MaxValue.
	public interface IModule
	{
		Guid Id { get; }

		string Name { get; }

		int MinValue { get; set; }

		int MaxValue { get; set; }

		int GetCurrentReading();
	}
}
