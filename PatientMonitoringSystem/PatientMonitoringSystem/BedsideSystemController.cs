using System.Linq;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public class BedsideSystemController
	{
		private readonly BedsideSystemView view;

		private readonly IBedsideSystem model;

		public BedsideSystemController(BedsideSystemView view, IBedsideSystem model)
		{
			this.view = view;
			this.model = model;
		}

		public void Initialise()
		{
			view.Text = model.Id.ToString();

			var table = view.FindSubcontrol<TableLayoutPanel>("Table");

			table.RowCount = 0;
			table.RowStyles.RemoveAt(0);

			foreach (var module in model.Modules)
			{
				var rowView = new ModuleRowView(module);
				rowView.OnRemoveModule += (sender, e) => table.Controls.Remove(e);

				table.RowCount += 1;

				var newRowIndex = table.RowStyles.Add(new RowStyle());

				table.Controls.Add(rowView, 0, newRowIndex);
			}
		}

		public void UpdateCurrentReading()
		{
			var table = view.FindSubcontrol<TableLayoutPanel>("Table");

			var rowViews = table.Controls.OfType<ModuleRowView>();

			foreach (var rowView in rowViews)
			{
				rowView.Controller.UpdateCurrentReading();
			}
		}
	}
}
