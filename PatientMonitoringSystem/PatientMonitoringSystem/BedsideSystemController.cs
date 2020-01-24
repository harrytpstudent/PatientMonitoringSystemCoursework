using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace PatientMonitoringSystem
{
	public class BedsideSystemController
	{
		private readonly BedsideSystemView view;

		private readonly IBedsideSystem model;

		private readonly int maxModulesPerBedsideSystem;

		public BedsideSystemController(BedsideSystemView view, IBedsideSystem model)
		{
			this.view = view;
			this.model = model;
			this.maxModulesPerBedsideSystem = int.Parse(ConfigurationManager.AppSettings["MaxModulesPerBedsideSystem"]);
		}

		public void Initialise()
		{
			view.Text = model.Id.ToString();

			var table = view.FindSubcontrol<TableLayoutPanel>("Table");

			table.RowCount = 0;
			table.RowStyles.RemoveAt(0);

			foreach (var module in model.Modules)
			{
				AddRowView(table, module);
			}

			var addButton = view.FindSubcontrol<Button>("AddButton");

			addButton.Enabled = model.Modules.Count < maxModulesPerBedsideSystem;
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

		public void AddModule()
		{
			var nameEntry = view.FindSubcontrol<TextBox>("NameEntry");

			var module = new Module(new BloodPressureStrategy(), nameEntry.Text, 0, 0);

			var table = view.FindSubcontrol<TableLayoutPanel>("Table");

			model.Modules.Add(module);

			AddRowView(table, module);

			nameEntry.Text = "";

			var addButton = view.FindSubcontrol<Button>("AddButton");

			addButton.Enabled = model.Modules.Count < maxModulesPerBedsideSystem;
		}

		private void AddRowView(TableLayoutPanel table, IModule module)
		{
			var rowView = new ModuleRowView(module);
			rowView.Controller.OnRemoveModule += RemoveModule;

			table.RowCount += 1;

			var newRowIndex = table.RowStyles.Add(new RowStyle());

			table.Controls.Add(rowView, 0, newRowIndex);
		}

		private void RemoveModule(object sender, OnRemoveModuleEventArgs e)
		{
			model.Modules.Remove(e.Model);

			var table = view.FindSubcontrol<TableLayoutPanel>("Table");

			table.Controls.Remove(e.View);

			var addButton = view.FindSubcontrol<Button>("AddButton");

			addButton.Enabled = true;
		}
	}
}
