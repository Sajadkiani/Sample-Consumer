using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MassTransit;

namespace GettingStarted
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddMassTransit(x =>
                    {
                        x.AddConsumers(typeof(Program).Assembly);

                        x.SetEndpointNameFormatter(new SnakeCaseEndpointNameFormatter(false));
                        x.UsingRabbitMq((context,cfg) =>
                        {
                            cfg.Host("localhost", "/", h => {
                                h.Username("guest");
                                h.Password("guest");
                            });
                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    // services.AddHostedService<Worker>();
                });
    }
}
