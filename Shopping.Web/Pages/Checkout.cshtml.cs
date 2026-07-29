namespace Shopping.Web.Pages;

public class CheckoutModel(IBasketService basketService,ILogger<CheckoutModel>logger) : PageModel
{
    [BindProperty]
    public BasketCheckoutModel Order { get; set; }=default!;
    public ShoppinCartModel Cart { get; set; }=default!;

    public async Task<IActionResult>  OnGetAsync()
    {
        Cart = await basketService.LoadUserBasket();
        return Page();
    }
    public async Task<IActionResult>  OnPostCheckoutAsync()
    {
       logger.LogInformation("Checkout button clicked");
       Cart = await basketService.LoadUserBasket();
       if (!ModelState.IsValid)
       {
           return Page();
       }

       Order.CustomerId = new Guid("15d867e3-d37b-4a26-9a40-1d393f2a75f6");
       Order.UserName=Cart.UserName;
       Order.TotalPrice=Cart.TotalPrice;
       await basketService.CheckoutBasket(new CheckoutBasketRequest(Order));
       return RedirectToPage("Confirmation","OrderSubmitted");
    }
}