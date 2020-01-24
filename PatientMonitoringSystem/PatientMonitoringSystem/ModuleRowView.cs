using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public partial class ModuleRowView : UserControl
	{
		public ModuleRowController Controller { get; private set; }

		public event EventHandler<ModuleRowView> OnRemoveModule;

		public ModuleRowView(IModule module)
		{
			InitializeComponent();

			Controller = new ModuleRowController(this, module);
		}

		private void ModuleRow_Load(object sender, EventArgs e)
		{
			Controller.Initialise();
		}

		private void MinValueDisplay_ValueChanged(object sender, EventArgs e)
		{
			Controller.MinValueUpdated((int)MinValueDisplay.Value);
		}

		private void MaxValueDisplay_ValueChanged(object sender, EventArgs e)
		{
			Controller.MaxValueUpdated((int)MaxValueDisplay.Value);
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			OnRemoveModule(this, this);
		}
	}
}
