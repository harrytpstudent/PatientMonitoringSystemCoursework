using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public static class ExtensionMethods
	{
		public static TSubcontrol FindSubcontrol<TSubcontrol>(this Control parent, string name) where TSubcontrol : Control
		{
			TSubcontrol foundSubcontrol = null;

			foreach (Control subcontrol in parent.Controls)
			{
				if (subcontrol.Name == name)
				{
					foundSubcontrol = (TSubcontrol)subcontrol;
					break;
				}

				var subSubControl = subcontrol.FindSubcontrol<TSubcontrol>(name);

				if (subSubControl != null)
				{
					foundSubcontrol = subSubControl;
				}
			}

			return foundSubcontrol;
		}
	}
}
