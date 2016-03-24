using System;
using NServiceBus;
using Api;
using Castle.Core.Logging;

namespace Host
{
    public class WriteFooHandler : IHandleMessages<WriteFoo>
    {
        public ILogger Logger { get; set; } = NullLogger.Instance;

        public void Handle(WriteFoo writeFoo)
        {
            Logger.DebugFormat("Received {0} message", nameof(writeFoo));
            Console.WriteLine($"Foo: {writeFoo.message}");
        }
    }
}
