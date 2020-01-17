using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public static class Program
	{
		[STAThread]
		public static void Main()
		{
			BedsideSystems = new List<IBedsideSystem>();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		public static List<IBedsideSystem> BedsideSystems;
	}
}
