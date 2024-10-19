using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using test_fluent_api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<LoginContext>(builder.Configuration.GetConnectionString("DbConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbContext", async ([FromServices] LoginContext context) =>
{
    context.Database.EnsureCreated();
    return Results.Ok($"Base de datos: {context.Database.EnsureCreated()}");
});

app.Run();