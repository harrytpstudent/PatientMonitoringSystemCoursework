using System;
using System.Collections.Generic;
using System.Linq;

namespace PatientMonitoringSystem.Core.Models
{
	public class BedsideSystem : IBedsideSystem
	{
		public Guid BedsideSystemId { get; }

		public string Name { get; }

		public bool AlarmRaised { get; private set; }

		public IList<IModule> Modules { get; }

		public event EventHandler<Guid> OnAlarmRaised; // Yes, usually you would create an EventArgs class.

		public BedsideSystem(string name)
		{
			BedsideSystemId = Guid.NewGuid();
			Name = name;
			Modules = new List<IModule>();
		}

		public void AddModule(IModule newModule)
		{
			Modules.Add(newModule);
			newModule.OnValueBreached += RaiseAlarm;
		}

		private void RaiseAlarm(object sender, Guid moduleId)
		{
			// Don't trigger again if the alarm has already been raised
			if (!AlarmRaised)
			{
				AlarmRaised = true;
				OnAlarmRaised?.Invoke(sender, BedsideSystemId);
			}
		}

		public void RemoveModule(Guid moduleId)
		{
			var module = Modules.Single(m => m.ModuleId == moduleId);
			
			Modules.Remove(module);
			module.OnValueBreached -= RaiseAlarm;
			module.Dispose();
		}

		public void Dispose()
		{
			foreach (var module in Modules)
			{
				module.Dispose();
			}
		}
	}
}
