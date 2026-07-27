using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
//DI container
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddRateLimiter(opt =>
{
    opt.AddFixedWindowLimiter("fixed", opts =>
    {
        opts.Window = TimeSpan.FromSeconds(10);
        opts.PermitLimit = 5;
    });
});
var app = builder.Build();
//Middleware pipeline
app.UseRateLimiter();
app.MapReverseProxy();
app.Run();