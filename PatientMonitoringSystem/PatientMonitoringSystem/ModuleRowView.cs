using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public partial class ModuleRowView : UserControl
	{
		private readonly ModuleRowController controller;

		public ModuleRowView(IModule module)
		{
			InitializeComponent();

			controller = new ModuleRowController(this, module);
		}

		private void ModuleRow_Load(object sender, EventArgs e)
		{
			controller.Initialise();
		}

		private void MinValueDisplay_ValueChanged(object sender, EventArgs e)
		{
			controller.MinValueUpdated((int)MinValueDisplay.Value);
		}

		private void MaxValueDisplay_ValueChanged(object sender, EventArgs e)
		{
			controller.MaxValueUpdated((int)MaxValueDisplay.Value);
		}
	}
}
