using System;

namespace PatientMonitoringSystem.Views.Eventing
{
	public class OnRemoveModuleEventArgs : EventArgs
	{
		public Guid ModuleId { get; }

		public OnRemoveModuleEventArgs(Guid moduleId)
		{
			ModuleId = moduleId;
		}
	}
}
