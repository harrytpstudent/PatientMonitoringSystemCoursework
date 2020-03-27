using PatientMonitoringSystem.Core.Models;
using System;

namespace PatientMonitoringSystem.Views.Eventing
{
	public class OnLoginSuccessEventArgs : EventArgs
	{
		public User User { get; }

		public OnLoginSuccessEventArgs(User user)
		{
			User = user;
		}
	}
}
