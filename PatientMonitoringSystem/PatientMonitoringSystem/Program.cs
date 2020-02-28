using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using PatientMonitoringSystem.Enums;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem
{
	public static class Program
	{
		public static List<IBedsideSystem> BedsideSystems;

		public static List<IModule> Modules;

		[STAThread]
		public static void Main()
		{
			BedsideSystems = new List<IBedsideSystem>();
			Modules = new List<IModule>();

			var initialBedsideSystems = int.Parse(ConfigurationManager.AppSettings["InitialBedsideSystems"]);
			var initialModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["InitialModulesPerBedsideSystem"]);
			var initialMinValue = int.Parse(ConfigurationManager.AppSettings["InitialMinValue"]);
			var initialMaxValue = int.Parse(ConfigurationManager.AppSettings["InitialMaxValue"]);

			var nextUniqueBedsideSystemNumber = 1;
			var nextUniqueModuleNumber = 1;
			var moduleTypes = Enum.GetValues(typeof(ModuleType));
			var randomNumberGenerator = new Random();

			IEnumerable<IBedsideSystem> getBedsideSystems()
			{
				for (var bedsideSystemNumber = 1; bedsideSystemNumber <= initialBedsideSystems; bedsideSystemNumber++)
				{
					var bedsideSystem = new BedsideSystem($"Bedside System {nextUniqueBedsideSystemNumber}");

					var modules = getModules();

					bedsideSystem.Modules.AddRange(modules);

					yield return bedsideSystem;

					nextUniqueBedsideSystemNumber++;
				}
			}

			IEnumerable<IModule> getModules()
			{
				for (var moduleNumber = 1; moduleNumber <= initialModulesPerBedsideSystem; moduleNumber++)
				{
					var moduleType = getModuleType();

					var module = new Module($"Module {nextUniqueModuleNumber}", moduleType, initialMinValue, initialMaxValue);

					Modules.Add(module);

					yield return module;

					nextUniqueModuleNumber++;
				}
			}

			ModuleType getModuleType()
			{
				var randomIndex = randomNumberGenerator.Next(0, moduleTypes.Length);

				return (ModuleType)moduleTypes.GetValue(randomIndex);
			}

			BedsideSystems.AddRange(getBedsideSystems());

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(GetGenericForm());
		}

		private static Form GetGenericForm()
		{
			var form = new Form
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowOnly,
				SizeGripStyle = SizeGripStyle.Show,
				FormBorderStyle = FormBorderStyle.Sizable
			};

			form.Controls.Add(new ControlSystemView());

			return form;
		}
	}
}
