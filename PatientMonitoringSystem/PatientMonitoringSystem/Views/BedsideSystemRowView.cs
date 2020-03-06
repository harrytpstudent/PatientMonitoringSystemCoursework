using System;
using System.Windows.Forms;
using PatientMonitoringSystem.Controllers;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Core.Models;

namespace PatientMonitoringSystem.Views
{
	public partial class BedsideSystemRowView : UserControl
	{
		private readonly Action<Guid> onViewBedsideSystem;

		public Guid BedsideSystemId { set;  get; }

		public BedsideSystemRowView(IBedsideSystem bedside, Action<Guid> onViewBedsideSystem)
		{
			InitializeComponent();
			Initialise(bedside);
			this.onViewBedsideSystem = onViewBedsideSystem;
		}

		private void ViewButton_Click(object sender, EventArgs e)
		{
			ViewBedsideSystem();
		}

		public void Initialise(IBedsideSystem bedside)
		{
			BedsideSystemId = bedside.BedsideSystemId;
			var bedsideSystemRowViewModel = new BedsideSystemRowViewModel
			{
				Id = bedside.BedsideSystemId,
				Name = bedside.Name
			};

			IdDisplay.Text = bedsideSystemRowViewModel.Id.ToString();
			NameDisplay.Text = bedsideSystemRowViewModel.Name;
		}

		public void ViewBedsideSystem()
		{
			onViewBedsideSystem(BedsideSystemId);
		}
	}
}
