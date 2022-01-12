using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace Kafka.Producer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var config = new ProducerConfig();
            config.BootstrapServers = "localhost:9092";

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                int startKey = new Random().Next(1000);

                for (int i = startKey; i < startKey + 10; i++)
                {
                    try
                    {
                        var dr = await producer.ProduceAsync("kafka-learning-orders", new Message<Null, string> { Value = "This is order" + i});
                        Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
