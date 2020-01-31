using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem.Models
{
	public class BedsideSystem : IBedsideSystem
	{
		public Guid BedsideSystemId { get; }

		public List<IModule> Modules { get; }

		public BedsideSystem()
		{
			BedsideSystemId = Guid.NewGuid();
			Modules = new List<IModule>();
		}
	}
}
