using Application.DependencyInjection;
using Infrastructure.DependencyInjection;
using Application.Items.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture layers registration
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

var itemsGroup = app.MapGroup("/api/items").WithTags("Items");

itemsGroup.MapPost("/", async ([FromBody] CrearItemCommand command, IMediator mediatR) =>
{
    var itemId = await mediatR.Send(command);
    return Results.Created($"/api/items/{itemId}", new { id = itemId, nombre = command.Nombre, monto = command.Monto });
})
.WithName("CrearItem");


app.Run();
