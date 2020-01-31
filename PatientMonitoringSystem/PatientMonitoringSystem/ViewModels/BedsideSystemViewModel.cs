﻿using System;
using System.Collections.Generic;

namespace PatientMonitoringSystem.ViewModels
{
	public class BedsideSystemViewModel
	{
		public string BedsideSystemId { get; set; }

		public IEnumerable<Guid> ModuleIds { get; set; }
	}
}
