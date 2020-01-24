using System;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public partial class BedsideSystemView : Form
	{
		public BedsideSystemController Controller { get; private set; }

		public BedsideSystemView(IBedsideSystem bedsideSystem)
		{
			InitializeComponent();

			this.Controller = new BedsideSystemController(this, bedsideSystem);
		}

		private void BedsideSystemView_Load(object sender, EventArgs e)
		{
			Controller.Initialise();
		}

		private void Updater_Tick(object sender, EventArgs e)
		{
			Controller.UpdateCurrentReading();
		}
	}
}
