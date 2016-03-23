using NServiceBus;

namespace Api
{
    public class WriteFoo: ICommand
    {
        public string message { get; set; }
    }
}
