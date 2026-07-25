using MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(IPublishEndpoint endpoint,IFeatureManager manager,ILogger<OrderCreatedEventHandler> logger): INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order Created Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        if(await manager.IsEnabledAsync("OrderFulfillment")){
            var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
            await endpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);

        }
    }
}