using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoArchitecture.Schedule
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					var configuration = hostContext.Configuration;
					var consumerConfig = new ConsumerConfig();
					configuration.Bind("Kafka:Consumer", consumerConfig);

					var producerConfig = new ProducerConfig();
					configuration.Bind("Kafka:Producer", producerConfig);

					services.AddSingleton<ConsumerConfig>(consumerConfig);
					services.AddSingleton<ProducerConfig>(producerConfig);

					services.AddHostedService<Worker>();
				});
	}
}
