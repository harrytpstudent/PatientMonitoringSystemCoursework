namespace PatientMonitoringSystem.Core.Strategies
{
	public interface IModuleStrategy
	{
		int GetCurrentReading(int min, int max);
	}
}
