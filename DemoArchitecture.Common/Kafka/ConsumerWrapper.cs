using Confluent.Kafka;
using Newtonsoft.Json;
using System;

namespace DemoArchitecture.Common.Kafka
{
    public class ConsumerWrapper<TKey, TValue> : IDisposable
    {
        private readonly ConsumerConfig _consumerConfig;
        private readonly IConsumer<TKey, TValue> _consumer;
        private readonly string _topic;

        public ConsumerWrapper(ConsumerConfig config, string topic)
        {
            _consumerConfig = config;
            _topic = topic;
            _consumer = new ConsumerBuilder<TKey, TValue>(_consumerConfig).Build();
            _consumer.Subscribe(_topic);
        }

        public TValue ReadMessage()
        {
            var message = _consumer.Consume();
            if (message.Message != null)
            {
                return message.Message.Value;
            }
            return JsonConvert.DeserializeObject<TValue>(message.Message.ToString());
        }

        public void Dispose()
        {
            _consumer.Dispose();

        }
    }
}
