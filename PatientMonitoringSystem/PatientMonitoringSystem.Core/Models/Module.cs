using System;
using System.Threading.Tasks;
using System.Threading;
using PatientMonitoringSystem.Core.Models.Enums;

namespace PatientMonitoringSystem.Core.Models
{
	public class Module : IModule
	{
		private int minValue;

		private int maxValue;

		private readonly Random randomNumGen;

		private readonly CancellationTokenSource tokenSource;

		private readonly Task readingGenerator;

		public Guid ModuleId { get; }

		public string Name { get; }

		public ModuleType ModuleType { get; }

		public int MinValue
		{
			get => minValue;
			set
			{
				ValidateValues(value, maxValue);

				minValue = value;
			}
		}

		public bool ValueBreached { get; private set; }

		public event EventHandler<Guid> OnValueBreached;

		public int CurrentReading { get; private set; }

		public int MaxValue
		{
			get => maxValue;
			set
			{
				ValidateValues(minValue, value);

				maxValue = value;
			}
		}

		public Module(string name, ModuleType type, int minValue, int maxValue)
		{
			randomNumGen = new Random();
			tokenSource = new CancellationTokenSource();
			readingGenerator = StartGeneratingReadings(tokenSource.Token);

			ModuleId = Guid.NewGuid();
			Name = name;
			ModuleType = type;

			ValidateValues(minValue, maxValue);

			MaxValue = maxValue;
			MinValue = minValue;
		}

		private async Task StartGeneratingReadings(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				await Task.Delay(100);

				CurrentReading = randomNumGen.Next(MinValue - 1, MaxValue + 2);
				ValueBreached = CurrentReading > MaxValue || CurrentReading < MinValue;

				if (ValueBreached)
				{
					Console.WriteLine("Module {0} breached with value {1}", Name, ValueBreached);
					OnValueBreached?.Invoke(this, ModuleId);
				}
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

			if (!readingGenerator.IsCompleted)
			{
				Console.WriteLine("Waiting started");
				readingGenerator.Wait();
				Console.WriteLine("Waiting finished");
			}
		}
	}
}