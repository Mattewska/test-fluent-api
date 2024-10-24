using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_fluent_api;
using test_fluent_api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<LoginContext>(builder.Configuration.GetConnectionString("DbConnection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/GetRoles", async ([FromServices] LoginContext context) =>
{
    return Results.Ok(context.Rols.Where(p => p.IdRol == 1));
});

app.MapGet("/dbContext", async ([FromServices] LoginContext context) =>
{
    context.Database.EnsureCreated();
    return Results.Ok($"Base de datos: {context.Database.EnsureCreated()}");
});



app.Run();