using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem.Models
{
	public class BedsideSystem : IBedsideSystem
	{
		public Guid BedsideSystemId { get; }

		public string Name { get; }

		public List<IModule> Modules { get; }

		public BedsideSystem(string name)
		{
			BedsideSystemId = Guid.NewGuid();
			Name = name;
			Modules = new List<IModule>();
		}
	}
}
