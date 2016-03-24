using Castle.Facilities.Logging;
using Castle.Windsor;
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
            GlobalDiagnosticsContext.Set("ApplicationName", "NServiceBusEvaluation");
            NServiceBus.Logging.LogManager.Use<NLogFactory>();

            //Configure Castle Container
            var container = new WindsorContainer();
            container.AddFacility<LoggingFacility>(x => x.UseNLog());
            configuration.UseContainer<WindsorBuilder>(x => x.ExistingContainer(container));

            //Configure NServiceBus
            configuration.UsePersistence<NHibernatePersistence>();
            configuration.EndpointName("fooQueue");
            configuration.UseSerialization<JsonSerializer>();
        }
    }
}
