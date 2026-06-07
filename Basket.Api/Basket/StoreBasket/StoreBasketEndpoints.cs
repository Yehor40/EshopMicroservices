namespace Basket.Api.Basket.StoreBasket;
public record StoreBasketRequest(ShoppingCart Cart);
public record StoreBasketResponse(string UsernName);
public class StoreBasketEndpoints:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<StoreBasketResponse>();
            return Results.Created($"/basket/{result.UsernName}", response);
        })
        .WithName("StoreBasket")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store basket")
        .WithDescription("Store basket");
    }
} 