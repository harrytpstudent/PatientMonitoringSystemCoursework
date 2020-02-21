using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Models
{
	public class BedsideSystem : IBedsideSystem
	{
	
		public Guid BedsideSystemId { get; }

		public string Name { get; }

		public bool AlarmRaised {
			get;
			private set;
		}

		public List<IModule> Modules { get; }

		public event EventHandler<Guid> OnAlarmRaised;
		public BedsideSystem(string name)
		{
			BedsideSystemId = Guid.NewGuid();
			Name = name;
			Modules = new List<IModule>();
		}

		public void AddModule(IModule newModule) {
			Modules.Add(newModule);
			newModule.OnValueBreached += RaiseAlarm;
		}

		private void RaiseAlarm(object sender, Guid moduleId)
		{
			// Don't trigger again if the alarm has already been raised
			if (!AlarmRaised)
			{
				AlarmRaised = true;
				OnAlarmRaised(sender, BedsideSystemId);
			}
			
		}

		public void RemoveModule(Guid moduleId) {
			var module = Modules.Single(m => m.ModuleId == moduleId);
			Modules.Remove(module);
			module.OnValueBreached -= RaiseAlarm;
			module.Dispose();
		}

		public void Dispose()
		{
			foreach (var module in Modules) {
				module.Dispose();
			}
		}
	}
}
