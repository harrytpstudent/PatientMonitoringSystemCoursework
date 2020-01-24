using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public class ModulesController
	{
		private readonly ModulesView view;

		private readonly IBedsideSystem bedsideSystem;

		public ModulesController(ModulesView view, IBedsideSystem bedsideSystem)
		{
			this.view = view;
			this.bedsideSystem = bedsideSystem;
		}

		public void Initialise()
		{
			var table = (TableLayoutPanel)view.Controls["Table"];

			foreach (var module in bedsideSystem.Modules)
			{
				var moduleRow = new ModuleRowView(module);

				table.RowCount += 1;

				var newRowIndex = table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

				table.Controls.Add(moduleRow, 0, newRowIndex);
			}
		}
	}
}
