using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PatientMonitoringSystem.Core.Models
{
	public class BedsideSystem : IBedsideSystem
	{
		private readonly IList<IModule> modules;

		public Guid BedsideSystemId { get; }

		public string Name { get; }

		public bool AlarmRaised { get; private set; }

		public IReadOnlyCollection<IModule> Modules => new ReadOnlyCollection<IModule>(modules);

		public event EventHandler<Guid> OnAlarmRaised; // Yes, usually you would create an EventArgs class.

		public BedsideSystem(string name)
		{
			BedsideSystemId = Guid.NewGuid();
			Name = name;
			modules = new List<IModule>();
		}

		public void AddModule(IModule newModule)
		{
			modules.Add(newModule);
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

		public void RemoveModule(Guid moduleId)
		{
			var module = Modules.Single(m => m.ModuleId == moduleId);
			modules.Remove(module);
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
