using System.Threading.Tasks;
using Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace GettingStarted;

public class TestIntegrationEventConsumer :
    IConsumer<TestIntegrationEvent>
{
    readonly ILogger<TestIntegrationEventConsumer> _logger;

    public TestIntegrationEventConsumer(ILogger<TestIntegrationEventConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<TestIntegrationEvent> context)
    {
        _logger.LogInformation("Received Text: {Text}", context.Message.UserName);

        return Task.CompletedTask;
    }
}