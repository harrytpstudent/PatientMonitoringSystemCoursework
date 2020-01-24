using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public partial class ModulesView : Form
	{
		private readonly ModulesController modulesController;

		public ModulesView(IBedsideSystem bedsideSystem)
		{
			InitializeComponent();

			this.modulesController = new ModulesController(this, bedsideSystem);
		}

		private void ModulesView_Load(object sender, EventArgs e)
		{
			modulesController.Initialise();
		}
	}
}
