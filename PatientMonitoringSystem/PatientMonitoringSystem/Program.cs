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

		public static Array moduleTypes = Enum.GetValues(typeof(ModuleType));
		public static Random randomNumberGenerator = new Random();
		public static ModuleType getModuleType()
		{
			var randomIndex = randomNumberGenerator.Next(0, moduleTypes.Length);

			return (ModuleType)moduleTypes.GetValue(randomIndex);
		}

		public static User CurrentUser { get; set; }

		public static IEnumerable<Subscription> CurrentUserSubscriptions { get; set; }

		[STAThread]
		public static void Main()
		{
			var initialBedsideSystems = int.Parse(ConfigurationManager.AppSettings["InitialBedsideSystems"]);
			var initialModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["InitialModulesPerBedsideSystem"]);
			var initialMinValue = int.Parse(ConfigurationManager.AppSettings["InitialMinValue"]);
			var initialMaxValue = int.Parse(ConfigurationManager.AppSettings["InitialMaxValue"]);

			int nextModuleNumber = 1;

			// Create all of the bedside systems and their modules
			for (var bedsideSystemNumber = 1; bedsideSystemNumber <= initialBedsideSystems; bedsideSystemNumber++) {

				IBedsideSystem bedsideSystem = new BedsideSystem($"Bedside System {bedsideSystemNumber}");
				for (var moduleNumber = 1; moduleNumber < initialModulesPerBedsideSystem+1; moduleNumber++) {

					ModuleType moduleType = getModuleType();
					IModule newModule = new Module($"Module {nextModuleNumber}", moduleType, initialMinValue, initialMaxValue);

					nextModuleNumber++;
					bedsideSystem.AddModule(newModule);
				}
				// Add the newly created bedside system to the list
				BedsideSystems.Add(bedsideSystem);
			}

			// Create the Control System
			ControlSystem controlSystem = new ControlSystem(BedsideSystems);
			ControlSystemController controlSytemController = new ControlSystemController(controlSystem);

			// Now create the view for the Control System
			Application.SetCompatibleTextRenderingDefault(false);
			ControlSystemView controlSystemView = new ControlSystemView(controlSytemController);


			// Start the view for the Control System
			Application.EnableVisualStyles();
			Application.Run(CreateControlForm(controlSystemView));

			// Closing the control system view form causes the controlSystem to dispose, which then cascades to
			// disposing bedside systems and their associated modules.
			controlSystem.Dispose();
		}

		private static Form CreateControlForm(ControlSystemView view)
		{
			var form = new Form
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowOnly,
				SizeGripStyle = SizeGripStyle.Show,
				FormBorderStyle = FormBorderStyle.Sizable
			};

			form.Controls.Add(view);

			return form;
		}
	}
}
