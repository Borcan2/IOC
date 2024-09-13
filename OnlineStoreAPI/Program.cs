using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using OnlineStoreAPI.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

app.MapGet("/products", (IProductService productService, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching product list. ");

    var products = productService.GetProducts();
    return Results.Ok(products);
});
app.MapGet("/checkout", (IPaymentService paymentService, ILogger<Program> logger, IConfiguration config) =>
{

    logger.LogInformation("User Initiated checkout process.");

    var paymentGatway = config["PaymentSettings:PrefferedGateway"];
    var paymentResult = paymentService.ProcessPayment(paymentGatway);

    return Results.Ok(paymentResult);
});

app.Run();