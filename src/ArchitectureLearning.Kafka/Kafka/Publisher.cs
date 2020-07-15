using System.Threading.Tasks;
using ArchitectureLearning.Kafka.Extensions;
using Confluent.Kafka;

namespace ArchitectureLearning.Kafka.Kafka
{
    public class Publisher
    {
        private readonly ProducerConfig _configuration;

        public Publisher(KafkaOptions options)
        {
            _configuration =
                new ProducerConfig(options.Configuration);
        }

        public async Task Publish<T>(T message, string topic = null)
        {
            using var producer = new ProducerBuilder<Null, T>(_configuration)
                .SetValueSerializer(new JsonSerializer<T>())
                .Build();

            await producer.ProduceAsync(topic ?? typeof(T).CollectionName(), new Message<Null, T>() { Value = message });
        }
    }
}