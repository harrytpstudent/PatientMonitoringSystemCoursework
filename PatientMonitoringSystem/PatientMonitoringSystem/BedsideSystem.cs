using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem
{
	public class BedsideSystem : IBedsideSystem
	{
		public Guid Id { get; }

		public List<Module> Modules { get; }

		public BedsideSystem()
		{
			Id = Guid.NewGuid();
			Modules = new List<Module>();
		}
	}
}
