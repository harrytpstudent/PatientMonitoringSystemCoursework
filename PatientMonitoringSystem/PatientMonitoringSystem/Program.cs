using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PatientMonitoringSystem.Models;

namespace PatientMonitoringSystem
{
	public static class Program
	{
		public static List<IBedsideSystem> BedsideSystems = new List<IBedsideSystem>();

		public static List<IModule> Modules = new List<IModule>();

		[STAThread]
		public static void Main()
		{
			var strategy = new BloodPressureStrategy();

			var module1 = new Module(strategy, "Test Module 1", 0, 2);
			var module2 = new Module(strategy, "Test Module 2", 0, 2);
			Modules.AddRange(new [] { module1, module2 });

			var bedsideSystem = new BedsideSystem();
			bedsideSystem.Modules.Add(module1);
			bedsideSystem.Modules.Add(module2);
			BedsideSystems.Add(bedsideSystem);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BedsideSystemView(bedsideSystem.BedsideSystemId));
		}
	}
}
