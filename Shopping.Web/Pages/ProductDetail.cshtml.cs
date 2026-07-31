using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shopping.Web.Pages;

public class ProductDetailModel(ICatalogService catalogService,IBasketService basketService,ILogger<ProductDetailModel>logger) : PageModel
{
    public ProductModel Product { get; set; } = default!;
    
    [BindProperty]
    public string Color { get; set; } = default!;
    [BindProperty]
    public int Quantity { get; set; }=default!;
    
    public async Task<IActionResult>  OnGetAsync(Guid productId) 
    {
        var response = await catalogService.GetProduct(productId);
        Product = response.Product;
        return Page();
    }
    
    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        logger.LogInformation("Add to cart button is clicked");
        var productResponse = await catalogService.GetProduct(productId);
        await basketService.AddItemToBasketAsync(productResponse.Product, Quantity, Color);
        return RedirectToPage("Cart");
    }
}
