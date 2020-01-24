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

			var strategy = new BloodPressureStrategy();
			var module1 = new Module(strategy, "Test Module 1", 0, 2);
			var module2 = new Module(strategy, "Test Module 2", 0, 2);
			var bedsideSystem = new BedsideSystem();
			bedsideSystem.Modules.Add(module1);
			bedsideSystem.Modules.Add(module2);
			BedsideSystems.Add(bedsideSystem);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BedsideSystemView(bedsideSystem));
		}

		public static List<IBedsideSystem> BedsideSystems;
	}
}
