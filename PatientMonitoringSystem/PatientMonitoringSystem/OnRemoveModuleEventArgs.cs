using System;


namespace PatientMonitoringSystem
{
	public class OnRemoveModuleEventArgs : EventArgs
	{
		public IModule Model { get; private set; }

		public ModuleRowView View { get; private set; }

		public OnRemoveModuleEventArgs(IModule model, ModuleRowView view)
		{
			Model = model;
			View = view;
		}
	}
}
