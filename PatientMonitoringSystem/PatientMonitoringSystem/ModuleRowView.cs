using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public partial class ModuleRowView : UserControl
	{
		public ModuleRowController Controller { get; private set; }

		public ModuleRowView(IModule model)
		{
			InitializeComponent();

			Controller = new ModuleRowController(this, model);
		}

		private void ModuleRow_Load(object sender, EventArgs e)
		{
			Controller.Initialise();
		}

		private void MinValueEntry_ValueChanged(object sender, EventArgs e)
		{
			Controller.MinValueUpdated((int)MinValueEntry.Value);
		}

		private void MaxValueEntry_ValueChanged(object sender, EventArgs e)
		{
			Controller.MaxValueUpdated((int)MaxValueEntry.Value);
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			Controller.RemoveModule();
		}
	}
}
