using System;
using NServiceBus;
using Api;

namespace Host
{
    public class WriteFooHandler : IHandleMessages<WriteFoo>
    {
        public void Handle(WriteFoo writeFoo)
        {
            Console.WriteLine($"Foo: {writeFoo.message}");
        }
    }
}
