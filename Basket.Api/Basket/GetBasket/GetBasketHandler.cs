namespace Basket.Api.Basket.GetBasket;
public record GetBasketQuery(string UsernName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);

public class GetBasketQueryHandler: IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        //TODO
        // var basker = await _repository.GetBasket(request.UserName);
        return new GetBasketResult(new ShoppingCart("yhr"));
    }
    
}