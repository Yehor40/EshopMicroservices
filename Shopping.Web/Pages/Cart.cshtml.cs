namespace Shopping.Web.Pages;

public class CartModel(IBasketService basketService,ILogger<CartModel> logger) : PageModel
{
    public ShoppinCartModel Cart { get; set; }= new ShoppinCartModel(); 
    [BindProperty]
    public List<CartItemQuantityInput> CartItems { get; set; } = [];
    
    public async Task<IActionResult> OnGetAsync()
    {
        Cart = await basketService.LoadUserBasket();
        return Page();
    }

    public async Task<IActionResult> OnPostRemoveToCartAsync(Guid productId)
    {
        logger.LogInformation("Remove to cart button is clicked");
        Cart = await basketService.LoadUserBasket();
        Cart.Items.RemoveAll(x=>x.ProductId==productId);
        await basketService.StoreBasket(new StoreBasketRequest(Cart));
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpdateCartAsync()
    {
        logger.LogInformation("Update cart button is clicked");
        Cart = await basketService.LoadUserBasket();

        foreach (var cartItem in Cart.Items)
        {
            var submittedItem = CartItems.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
            if (submittedItem is not null)
            {
                cartItem.Quantity = Math.Clamp(submittedItem.Quantity, 1, 100);
            }
        }

        await basketService.StoreBasket(new StoreBasketRequest(Cart));
        return RedirectToPage();
    }

    public record CartItemQuantityInput(Guid ProductId, int Quantity);
}
