using System;
using System.Threading.Tasks;
using PatientMonitoringSystem.Core.Models;
using System.Threading;

namespace PatientMonitoringSystem.Core.Models
{


	public class Module : IModule
	{
		private int minValue;

		private int maxValue;

		private readonly Random randomNumGen;

		private readonly Task valueGenerator;

		private readonly CancellationTokenSource tokenSource;

		public Guid ModuleId { get; }

		public string Name { get; }

		public int MinValue
		{
			get => minValue;
			set
			{
				ValidateValues(value, maxValue);

				minValue = value;
			}
		}

		public bool ValueBreached {
			get;
			private set;
		}

		public event EventHandler<Guid> OnValueBreached;

		public int CurrentReading {
			get;
			private set;
		}

		public int MaxValue
		{
			get => maxValue;
			set
			{
				ValidateValues(minValue, value);

				maxValue = value;
			}
		}

		public Module(string name, int initialMinValue, int initialMaxValue)
		{
			tokenSource = new CancellationTokenSource();

			randomNumGen = new Random();

			valueGenerator = GenerateValues(tokenSource.Token);

			ValidateValues(initialMinValue, initialMaxValue);

			ModuleId = Guid.NewGuid();
			Name = name;

			MaxValue = initialMaxValue;
			MinValue = initialMinValue;
		}


		private async Task GenerateValues(CancellationToken cToken) {
			while (!cToken.IsCancellationRequested)
			{

				await Task.Delay(1000);

				CurrentReading = randomNumGen.Next(MinValue-1, MaxValue+2);
				ValueBreached = (CurrentReading > MaxValue || CurrentReading < MinValue);
				if (ValueBreached)
					OnValueBreached(this, ModuleId);
			}
		}

		private void ValidateValues(int minValue, int maxValue)
		{
			if (minValue > maxValue)
			{
				throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} must not be greater than {nameof(maxValue)}!");
			}
		}

		public void Dispose()
		{
			tokenSource.Cancel();
			valueGenerator.Wait();
		}
	}
}