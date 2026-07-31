namespace Shopping.Web.Pages;

public class IndexModel(ICatalogService catalogService,IBasketService basketService, ILogger<IndexModel> logger) : PageModel
{
    public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

    public async Task<IActionResult> OnGetAsync()
    {
        logger.LogInformation("Index page visited");
        var result = await catalogService.GetProducts();
        ProductList = result.Products;
        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        logger.LogInformation("Add to cart button clicked");
        var productResponse = await catalogService.GetProduct(productId);
        await basketService.AddItemToBasketAsync(productResponse.Product, 1, "Black");
        return RedirectToPage("/Cart");
    }
}
