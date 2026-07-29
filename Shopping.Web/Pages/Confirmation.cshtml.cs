namespace Shopping.Web.Pages;

public class Confirmation : PageModel
{
    public string Message { get; set; }=default!;
    
    public void OnGetMessage()
    {
        Message = "Your email was sent.";
    }
    public void OnGetOrderSubmitted()
    {
        Message = "Your order submitted successfully.";
    }
}