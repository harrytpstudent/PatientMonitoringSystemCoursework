using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public static class ExtensionMethods
	{
		public static TSubcontrol FindSubcontrol<TSubcontrol>(this Control parent, string name) where TSubcontrol : Control
		{
			TSubcontrol foundSubcontrol = null;

			foreach (Control control in parent.Controls)
			{
				if (control.Name == name)
				{
					foundSubcontrol = (TSubcontrol)control;
					break;
				}

				var subControl = control.FindSubcontrol<TSubcontrol>(name);

				if (subControl != null)
				{
					foundSubcontrol = subControl;
				}
			}

			return foundSubcontrol;
		}
	}
}
