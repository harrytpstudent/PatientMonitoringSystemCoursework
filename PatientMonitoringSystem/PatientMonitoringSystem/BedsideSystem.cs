using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem
{
	public class BedsideSystem : IBedsideSystem
	{
		public Guid Id { get; }

		public List<IModule> Modules { get; }

		public BedsideSystem()
		{
			Id = Guid.NewGuid();
			Modules = new List<IModule>();
		}
	}
}
