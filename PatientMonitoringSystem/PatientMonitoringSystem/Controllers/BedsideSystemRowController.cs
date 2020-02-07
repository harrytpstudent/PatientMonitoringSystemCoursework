using System;
using System.Linq;
using PatientMonitoringSystem.Models;
using PatientMonitoringSystem.ViewModels;
using PatientMonitoringSystem.Views;

namespace PatientMonitoringSystem.Controllers
{
	public class BedsideSystemRowController
	{
		private readonly BedsideSystemRowView bedsideSystemRowView;

		private readonly IBedsideSystem bedsideSystem;

		public BedsideSystemRowController(BedsideSystemRowView bedsideSystemeRowView, Guid bedsideSystemId)
		{
			this.bedsideSystemRowView = bedsideSystemeRowView;
			bedsideSystem = Program.BedsideSystems.Single(bs => bs.BedsideSystemId == bedsideSystemId);
		}

		public void Initialise()
		{
			var bedsideSystemRowViewModel = new BedsideSystemRowViewModel
			{
				Id = bedsideSystem.BedsideSystemId,
				Name = bedsideSystem.Name
			};

			bedsideSystemRowView.Initialise(bedsideSystemRowViewModel);
		}

		public void ViewBedsideSystem()
		{
			bedsideSystemRowView.ViewBedsideSystem();
		}
	}
}
