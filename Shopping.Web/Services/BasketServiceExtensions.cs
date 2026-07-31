namespace Shopping.Web.Services;

public static class BasketServiceExtensions
{
    public static async Task AddItemToBasketAsync(
        this IBasketService basketService,
        ProductModel product,
        int quantity,
        string color)
    {
        var basket = await basketService.LoadUserBasket();
        var normalizedColor = string.IsNullOrWhiteSpace(color) ? "Black" : color.Trim();
        var normalizedQuantity = Math.Clamp(quantity, 1, 100);

        var existingItem = basket.Items.FirstOrDefault(item =>
            item.ProductId == product.Id &&
            string.Equals(item.Color, normalizedColor, StringComparison.OrdinalIgnoreCase));

        if (existingItem is null)
        {
            basket.Items.Add(new ShoppingCartItemModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = normalizedQuantity,
                Color = normalizedColor
            });
        }
        else
        {
            existingItem.Quantity = Math.Clamp(existingItem.Quantity + normalizedQuantity, 1, 100);
        }

        await basketService.StoreBasket(new StoreBasketRequest(basket));
    }
}
