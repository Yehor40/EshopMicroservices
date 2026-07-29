namespace Shopping.Web.Pages;

public class OrderListModel(IOrderingService orderingService,ILogger<OrderListModel>logger) : PageModel
{
    public IEnumerable<OrderModel> Orders { get; set; } = default!;
    
    public async Task<IActionResult> OnGetAsync()
    {
        var customerId = new Guid("15d867e3-d37b-4a26-9a40-1d393f2a75f6");
        var response = await orderingService.GetOrdersByCustomer(customerId);
        Orders = response.Orders;
        return Page();
    }
}