namespace Basket.Api.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UsernName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x=>x.Cart).NotNull().WithMessage("Cart is required");
        RuleFor(x=>x.Cart.UserName).NotNull().WithMessage("UserName is required");
    }
}
public class StoreBasketCommandHandler:ICommandHandler<StoreBasketCommand,StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        ShoppingCart cart = command.Cart;
        //TODO: store basket in db(Marten upsert)
        //TODO: update cache
        return new StoreBasketResult("yhr");
    }
}