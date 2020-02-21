using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Core.Models
{
	class ControlSystem : IControlSystem
	{
		public List<IBedsideSystem> BedsideSystems {
			get;
		}

		public ControlSystem(IEnumerable<IBedsideSystem> bedsideSystems) {
			BedsideSystems = new List<IBedsideSystem>();
			bedsideSystems.ToList().ForEach(b => AddBedsideSystem(b));
		}

		public bool AlarmRaised {
			get;
			private set;
		}

		private void AddBedsideSystem(IBedsideSystem bedsideSystem) {

			BedsideSystems.Add(bedsideSystem);
			bedsideSystem.OnAlarmRaised += NotifyAlarmRaised;
		}

		private void RemoveBedsideSystem(Guid bedsideId)
		{
			var bedsideSystem = BedsideSystems.Single(b => b.BedsideSystemId == bedsideId);
			BedsideSystems.Remove(bedsideSystem);
			bedsideSystem.OnAlarmRaised -= NotifyAlarmRaised;
			bedsideSystem.Dispose();
		}

		private void NotifyAlarmRaised(object sender, Guid bedsideId) {
			// Don't trigger again if the alarm has already been raised
			if (!AlarmRaised)
			{
				AlarmRaised = true;
			}
		}

		public void Dispose()
		{
		}
	}
}
