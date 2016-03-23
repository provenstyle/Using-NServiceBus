using NLog;
using NLog.Config;
using NLog.Targets;

namespace Host
{
    using NServiceBus;

    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server
    {
        public void Customize(BusConfiguration configuration)
        {
            //Configure Logging
            var config = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget
            {
                Layout = "Foo: ${level}|${logger}|${message}${onexception:${newline}${exception:format=tostring}}"
            };
            config.AddTarget("console", consoleTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, consoleTarget));
            LogManager.Configuration = config;

            NServiceBus.Logging.LogManager.Use<NLogFactory>();

            //Configure NServiceBus
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.EndpointName("fooQueue");
            configuration.UseSerialization<JsonSerializer>();
        }
    }
}
