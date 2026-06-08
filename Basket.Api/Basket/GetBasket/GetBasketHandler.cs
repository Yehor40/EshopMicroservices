namespace Basket.Api.Basket.GetBasket;
public record GetBasketQuery(string UsernName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);

public class GetBasketQueryHandler(IBasketRepository _repository)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await _repository.GetBasket(request.UsernName, cancellationToken);
        return new GetBasketResult(basket);
    }
    
}