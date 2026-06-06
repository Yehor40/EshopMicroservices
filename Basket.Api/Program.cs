var builder = WebApplication.CreateBuilder(args);
//DI container

var app = builder.Build();

//Middleware pipeline

app.Run();