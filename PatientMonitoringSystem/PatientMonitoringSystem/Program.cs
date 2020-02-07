using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
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
			var strategyTypes = Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.GetInterfaces().Contains(typeof(IModuleStrategy)))
				.ToArray();

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
					var strategy = getStrategy();

					var module = new Models.Module(strategy, $"Module {nextUniqueModuleNumber}", initialMinValue, initialMaxValue);

					Modules.Add(module);

					yield return module;

					nextUniqueModuleNumber++;
				}
			}

			IModuleStrategy getStrategy()
			{
				var randomIndex = new Random().Next(0, strategyTypes.Length);

				var strategyType = strategyTypes[randomIndex];

				return (IModuleStrategy)Activator.CreateInstance(strategyType);
			}

			BedsideSystems.AddRange(getBedsideSystems());

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new ControlSystemView());
		}
	}
}
