using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", (ILogger<Program> logger, IConfiguration config) =>
    {

        logger.LogInformation("Toy Factory API is running!");
        var factoryName = config["FactoryName"];

        return $"Welcome to {factoryName}!";

    });

app.Run();


