namespace Shopping.Web.Pages;

public class ProductListModel(IBasketService basketService,ICatalogService catalogService,ILogger<ProductModel> logger) : PageModel
{
    public IEnumerable<string> CategoryList { get; set; } = [];
    public IEnumerable<ProductModel> ProductList { get; set; } = [];
    
    [BindProperty(SupportsGet = true)]
    public string SelectedCategory { get; set; } = default!;
    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; } = default!;
    
    public async Task<IActionResult> OnGetAsync(string categoryName, string searchTerm)
    {
        var response = await catalogService.GetProducts();
        CategoryList = response.Products.SelectMany(p => p.Category).Distinct();
        var products = response.Products;

        if (!string.IsNullOrWhiteSpace(categoryName))
        {
            products=products.Where(p=>p.Category.Contains(categoryName));
            SelectedCategory=categoryName;
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            products = products.Where(p =>
                p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.Category.Any(c => c.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
            SearchTerm = searchTerm;
        }

        ProductList=products;
        return Page();
    }

    public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    {
        logger.LogInformation("Add to cart button is clicked");
        var productResponse = await catalogService.GetProduct(productId);
        await basketService.AddItemToBasketAsync(productResponse.Product, 1, "Black");
        return RedirectToPage("Cart");
    }
}
