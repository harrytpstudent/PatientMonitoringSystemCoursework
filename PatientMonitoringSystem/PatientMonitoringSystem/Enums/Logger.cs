using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitoringSystem.Enums
{
	public class Logger
	{
		private static Logger log_instance = null;
		private static readonly object _lock = new object();

		Logger() { }

		public static Logger Instance {
			get
			{
				lock (_lock)
				{
					if (log_instance == null)
					{
						log_instance = new Logger();
					}
				}
				return log_instance;
			}
		}
	}
}
