using System;
using Api;
using NServiceBus;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new BusConfiguration();
            config.EndpointName("fooQueue");
            config.UseSerialization<JsonSerializer>();
            config.UsePersistence<InMemoryPersistence>();
            config.UseTransport<MsmqTransport>();
            
            IBus bus = Bus.Create(config);

            while (true)
            {
                Console.WriteLine("Type a message and press enter:");
                var message = Console.ReadLine();
                bus.Send(new WriteFoo {message = message});
                Console.WriteLine("Message sent.");
            }
        }
    }

}
