using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.Core.Models;
using PatientMonitoringSystem.Core.Models.Enums;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem
{
	public static class Program
	{
		public static IList<IBedsideSystem> BedsideSystems { get; } = new List<IBedsideSystem>();

		public static IList<IModule> Modules { get; } = new List<IModule>();

		public static ModuleRowController ModuleRowController { get; } = new ModuleRowController();

		[STAThread]
		public static void Main()
		{
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

					foreach (var module in modules)
					{
						bedsideSystem.Modules.Add(module);
					}

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

			foreach (var bedsideSystem in getBedsideSystems())
			{
				BedsideSystems.Add(bedsideSystem);
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(GetGenericForm());

			MessageBox.Show("About to dispose resources. Don't be surprised if it takes several seconds. Program will terminate automatically.");

			ModuleRowController.Dispose();

			foreach (var bedsideSystem in BedsideSystems) // TODO: Change code so can just call ControlSystem.Dispose()
			{
				bedsideSystem.Dispose(); // This will cascade down to the modules.
			}
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
