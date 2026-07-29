using System.Net;

namespace Shopping.Web.Services;

public interface IBasketService
{
    [Get("/basket-service/basket/{userName}")]
    Task<GetBasketResponse> GetBasket(string userName);

    [Post("/basket-service/basket")]
    Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

    [Delete("/basket-service/basket/{userName}")]
    Task<DeleteBasketResponse> DeleteBasket(string userName);

    [Post("/basket-service/basket/checkout")]
    Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);
    public async Task<ShoppinCartModel> LoadUserBasket()
    {
        var username = "tony";
        ShoppinCartModel basket;
        try
        {
            var basketResponse = await GetBasket(username);
            basket = basketResponse.Cart;
        }
        catch (ApiException e)when (e.StatusCode == HttpStatusCode.NotFound)
        {
            basket = new ShoppinCartModel
            {
                UserName = username,
                Items = []
            };
        }
        return basket;
    }

}