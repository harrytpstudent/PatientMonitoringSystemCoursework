using System;

namespace PatientMonitoringSystem.ViewModels
{
	public class ModuleRowViewModel
	{
		public int MinValue { get; set; }

		public int CurrentReading { get; set; }

		public int MaxValue { get; set; }

		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Type { get; set; }
	}
}
