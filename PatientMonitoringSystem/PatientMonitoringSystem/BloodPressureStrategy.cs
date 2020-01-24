using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientMonitoringSystem
{
	public class BloodPressureStrategy: IModuleStrategy
	{
		private readonly Random randomNumberGenerator = new Random();
		public int GetCurrentReading(int minvalue, int maxvalue) => randomNumberGenerator.Next(minvalue - 1, maxvalue + 2);
	}
}
