﻿using System;

namespace PatientMonitoringSystem.Core.Strategies
{
	public class BloodPressureStrategy : IModuleStrategy
	{
		private readonly Random randomNumberGenerator = new Random();

		public int GetCurrentReading(int minvalue, int maxvalue) => randomNumberGenerator.Next(minvalue - 1, maxvalue + 2);
	}
}