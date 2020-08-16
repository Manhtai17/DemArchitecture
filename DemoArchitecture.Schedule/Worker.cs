using Confluent.Kafka;
using DemoArchitecture.Common.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DemoArchitecture.Schedule
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly ConsumerConfig _consumerConfig;

		public Worker(ILogger<Worker> logger, ConsumerConfig consumerConfig)
		{
			_consumerConfig = consumerConfig;
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{

				_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				var topics = new List<string> { "test_topic" };
				foreach (var topic in topics)
				{
					var th = new Thread(() =>
					{
						using (var consumer = new ConsumerWrapper<Null, string>(_consumerConfig, topic))
						{
							while (true)
							{
								var message = consumer.ReadMessage();
								if (message == null)
								{
									continue;
								}
								Console.WriteLine(message);
							}
						}
					});

					th.Start();
				}

				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
