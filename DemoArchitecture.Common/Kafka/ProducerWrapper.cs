using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace DemoArchitecture.Common.Kafka
{
    public class ProducerWrapper<Tkey, TValue> : IDisposable
    {
        private readonly IProducer<Tkey, TValue> _producer;

        private readonly string _topic;

        private readonly ProducerConfig _producerConfig;

        public ProducerWrapper(ProducerConfig producerConfig, string topic)
        {
            _producerConfig = producerConfig;
            _topic = topic;
            _producer = new ProducerBuilder<Tkey, TValue>(_producerConfig).Build();
        }

        public async Task SendMessage(TValue message)
        {
            try
            {
                var dr = await _producer.ProduceAsync(_topic, new Message<Tkey, TValue>()
                {
                    Value = message
                });
                Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
            }
            catch (ProduceException<Tkey, TValue> ex)
            {
                Console.WriteLine($"Failed: {ex.Error.Reason}");
            }
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
